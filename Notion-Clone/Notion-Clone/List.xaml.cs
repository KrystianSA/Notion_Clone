using MongoDbModels;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using Newtonsoft.Json;
using System.Text;
using Notion_Clone.Extensions;

namespace Notion_Clone
{
    public partial class List : Window
    {
        public List()
        {
            InitializeComponent();
        }
        public void btnAddTask(object sender, RoutedEventArgs e)
        {
            var data = new Data().DataToSend(text);
            var serializeData = data.Serialize();

            var client = new HttpService(new HttpClient());
            string apiURL = client.GenerateUrl();
            var content = client.PutContent(serializeData);
            var response = client.ExaminePostVerb(apiURL, content);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Send Successfully");
            }
            else
            {
                MessageBox.Show("Send Failed...");
            }
        }
    }
}
