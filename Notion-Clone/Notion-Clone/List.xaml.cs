using MongoDbModels;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using Newtonsoft.Json.Bson;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Json;

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
            HttpClient client = new HttpClient();
            string apiURL = ConfigurationManager.AppSettings["AddTaskApi"];
            client.BaseAddress = new Uri(apiURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var exercise = new Exercise();
            exercise.Body = text.Text.ToString();

            string data = JsonConvert.SerializeObject(exercise);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(apiURL, content).Result;
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
