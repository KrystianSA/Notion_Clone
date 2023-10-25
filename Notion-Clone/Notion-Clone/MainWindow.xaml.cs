using System.Windows;
namespace Notion_Clone
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ButtonForTimer(object sender, RoutedEventArgs e) 
        {
            new Timer().Show();
        }
        public void ButtonForList(object sender, RoutedEventArgs e)
        {
            new List().Show();
        }
    }
}
