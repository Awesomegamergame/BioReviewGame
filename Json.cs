using System.IO;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static BioReviewGame.MainWindow;
using System.Collections.Generic;
using System.Reflection;

namespace BioReviewGame
{
    internal class Json
    {
        public static List<string> questionlist = new List<string>();
        public static List<string> a1List = new List<string>();
        public static List<string> a2List = new List<string>();
        public static List<string> a3List = new List<string>();
        public static List<string> a4List = new List<string>();
        public static List<string> cList = new List<string>();
        public static int time;
        public static int JsonReader(string directory)
        {
            int size = 0;
            try
            {
                GameWindow.Embed.IsEnabled = true;
                GameWindow.Select.IsEnabled = true;
                GameWindow.Start.IsEnabled = true;
                questionlist.Clear();
                a1List.Clear();
                a2List.Clear();
                a3List.Clear();
                a4List.Clear();
                cList.Clear();
                string jsonFile = new StreamReader(directory).ReadToEnd();
                dynamic obj = JsonConvert.DeserializeObject<dynamic>(jsonFile);
                dynamic json = obj.Questions;
                foreach (JProperty data in json)
                {
                    questionlist.Add(ReadJson(data.Name, "question", jsonFile));
                    a1List.Add(ReadJson(data.Name, "a1", jsonFile));
                    a2List.Add(ReadJson(data.Name, "a2", jsonFile));
                    a3List.Add(ReadJson(data.Name, "a3", jsonFile));
                    a4List.Add(ReadJson(data.Name, "a4", jsonFile));
                    cList.Add(ReadJson(data.Name, "c", jsonFile));
                    size++;
                }
                dynamic timer = obj.Timer;
                foreach (JProperty data in timer)
                {
                    int ctime = ReadTimer(data.Name, "minutes", jsonFile) * 60000;
                    time = ctime;
                }
            }
            catch (JsonSerializationException ex)
            {
                GameWindow.Start.IsEnabled = false;
                MessageBox.Show($"Something is wrong with the json file.\n\nError Code: {ex}");
            }
            catch (System.NullReferenceException ex)
            {
                GameWindow.Start.IsEnabled = false;
                MessageBox.Show($"Something is wrong with the json file.\n\nError Code: {ex}");
            }
            return size;
        }
        public static int JsonReaderEmbed()
        {
            int size = 0;
            try
            {
                questionlist.Clear();
                a1List.Clear();
                a2List.Clear();
                a3List.Clear();
                a4List.Clear();
                cList.Clear();
                var DataStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BioReviewGame.Data.json");
                string jsonEmbed = new StreamReader(DataStream).ReadToEnd();
                dynamic obj = JsonConvert.DeserializeObject<dynamic>(jsonEmbed);
                dynamic json = obj.Questions;
                foreach (JProperty data in json)
                {
                    questionlist.Add(ReadJsonEmbed(data.Name, "question", jsonEmbed));
                    a1List.Add(ReadJsonEmbed(data.Name, "a1", jsonEmbed));
                    a2List.Add(ReadJsonEmbed(data.Name, "a2", jsonEmbed));
                    a3List.Add(ReadJsonEmbed(data.Name, "a3", jsonEmbed));
                    a4List.Add(ReadJsonEmbed(data.Name, "a4", jsonEmbed));
                    cList.Add(ReadJsonEmbed(data.Name, "c", jsonEmbed));
                    size++;
                }
                dynamic timer = obj.Timer;
                foreach (JProperty data in timer)
                {
                    int ctime = ReadTimer(data.Name, "minutes", jsonEmbed) * 60000;
                    time = ctime;
                }
            }
            catch (JsonSerializationException ex)
            {
                MessageBox.Show($"Something is wrong with the json file.\n\nError Code: {ex}");
                Application.Current.Shutdown();
            }
            GameWindow.Embed.IsEnabled = false;
            GameWindow.Select.IsEnabled = true;
            GameWindow.Start.IsEnabled = true;
            return size;
        }
        public static string ReadJson(string GVersion, string Property, string json)
        {
            JObject rss = JObject.Parse(json);
            return (string)rss["Questions"][GVersion][Property];
        }
        public static string ReadJsonEmbed(string GVersion, string Property, string Embed)
        {
            JObject rss = JObject.Parse(Embed);
            return (string)rss["Questions"][GVersion][Property];
        }
        public static int ReadTimer(string GVersion, string Property, string dir)
        {
            JObject rss = JObject.Parse(dir);
            return (int)rss["Timer"][GVersion][Property];
        }
    }
}
