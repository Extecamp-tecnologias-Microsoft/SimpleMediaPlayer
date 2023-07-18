using System;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;
using Microsoft.Win32;
using MessageBox = System.Windows.MessageBox;

namespace SimpleMediaPlayer
{

  public partial class MainWindow : UiWindow
  {
    public MainWindow()
    {
      InitializeComponent();
    }
    // botao de play
    private void Play_Button(object sender, RoutedEventArgs e)
    {
      MediaState ms = MediaState.Play;
      me.LoadedBehavior = ms;
    }
    // botao de pause
    private void Pause_Button(object sender, RoutedEventArgs e)
    {
      MediaState ms = MediaState.Pause;
      me.LoadedBehavior = ms;
    }
    // botao de parar
    private void Stop_Button(object sender, RoutedEventArgs e)
    {
      MediaState ms = MediaState.Stop;
      me.LoadedBehavior = ms;
    }
    // botao de procurar midia
    private void Browser_Button(object sender, RoutedEventArgs e)
    {
      MediaState ms = MediaState.Pause;
      me.LoadedBehavior = ms; // pausando o audio para procurar outro arquivo

      // responsavel por procurar o aquivo para reproduzir video ou musica
      try
      {
        OpenFileDialog fd = new OpenFileDialog();
        fd.Filter = "MP3 Files (*.mp3)|*.mp3|MP4 File (*.mp4)|*.mp4|3GP File (*.3gp)|*.3gp|Audio File (*.wma)|*.wma|MOV File (*.mov)|*.mov|AVI File (*.avi)|*.avi|Flash Video(*.flv)|*.flv|Video File (*.wmv)|*.wmv|MPEG-2 File (*.mpeg)|*.mpeg|WebM Video (*.webm)|*.webm|All files (*.*)|*.*";
        fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        fd.ShowDialog();

        // pega o caminho do arquivo de vídeo/áudio atualmente selecionado e armazena em uma string
        string filename = fd.FileName;
        if (filename != "")
        {
          Uri u = new Uri(filename);
          me.Source = u;
          MediaState opt = MediaState.Play;
          me.LoadedBehavior = opt;
        }
        else
        {
          MessageBox.Show("Nada selecionado", "vazio");
        }

        // Tratativa em caso de nenhum arquivo selecionado 
      }
      catch (Exception ex)
      {
        System.Console.WriteLine("Erro" + ex.Message);

      }
    }

    // chamado automaticamente quando o app e iniciado 
    string videoURL = @"C:\Users\Apena\Videos\SnapInsta.io-Kanye West - Heartless-(480p).mp4";
    private void Window_loaded(object sender, RoutedEventArgs e)
    {
      try
      {
        // Configurando video local com URL do path do arquivo
        Uri obj = new Uri(videoURL);
        me.Source = obj;

      }
      catch (Exception ex)
      {
        System.Console.WriteLine("Erro" + ex.Message);

      }

    }


    private void Exit_Button(object sender, RoutedEventArgs e)
    {
      // usando o environment para sair do programa 
      Environment.Exit(0);
    }


    private void Progress_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      me.Position = TimeSpan.FromMilliseconds(Progress_Slider.Value);
    }


  }
}
