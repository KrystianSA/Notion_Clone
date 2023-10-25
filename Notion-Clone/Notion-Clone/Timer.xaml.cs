using NAudio.Wave;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace Notion_Clone
{
    public partial class Timer : Window
    {
        private DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        private const int startTimeInSecond = 1;
        private int counter = 0;
        private WaveOutEvent _outputDevice;
        private AudioFileReader _audioFile;
        public Timer()
        {
            InitializeComponent();
        }
        public void StartTimeButton(object sender, RoutedEventArgs e)
        {
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(startTimeInSecond);
            _dispatcherTimer.Tick += TimerTick;
            _dispatcherTimer.Start();
        }
        public void StopTimeButton(object sender, RoutedEventArgs e)
        {
            _dispatcherTimer.Tick -= TimerTick;
            _dispatcherTimer.Stop();
        }
        public void TimerTick(object sender, EventArgs e)
        {
            counter++;
            if (counter == 3000)
            {
                EndOf50MinutesTimeToStartMusic();
            }
            lblTime.Content = TimeSpan.FromSeconds(counter).ToString(@"hh\:mm\:ss");
        }

        private void EndOf50MinutesTimeToStartMusic()
        {
            _outputDevice = new WaveOutEvent();
            _audioFile = new AudioFileReader(ConvertWavFileToMp3());
            _outputDevice.Init(_audioFile);
            _outputDevice.Play();
        }

        private string ConvertWavFileToMp3()
        {
            var mp3FilePath = "videoplayback.mp3";
            using (var reader = new WaveFileReader(GetPathForMusic()))
            {
                MediaFoundationEncoder.EncodeToMp3(reader, mp3FilePath);
            }
            return mp3FilePath;
        }

        private Stream GetPathForMusic()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var path = assembly.GetManifestResourceStream("Notion_Clone.Sounds.videoplayback.wav");
            return path;
        }
    }
}
