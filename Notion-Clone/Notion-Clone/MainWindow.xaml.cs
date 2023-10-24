using System;
using System.Diagnostics.Metrics;
using System.Windows;
using System.Windows.Threading;
namespace Notion_Clone
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        private const int startTimeInSecond = 1;
        private int counter=0;
        public MainWindow()
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
            lblTime.Content = TimeSpan.FromSeconds(counter++).ToString(@"hh\:mm\:ss");
        }
    }
}
