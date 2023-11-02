using MongoDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace Notion_Clone
{
    public class Data
    {
        public object DataToSend(TextBox text)
        {
            var exercise = new Exercise();
            {
                exercise.Body = text.Text.ToString();
            };
            return exercise;
        }
    }
}
