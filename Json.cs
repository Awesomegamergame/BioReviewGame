using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static BioReviewGame.MainWindow;
using System.Collections.Generic;

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
        public static double time;
        public static int JsonReader(string jsonFile)
        {
            int size = 0;
            try
            {
                GameWindow.Select.IsEnabled = true;
                GameWindow.Start.IsEnabled = true;
                questionlist.Clear();
                a1List.Clear();
                a2List.Clear();
                a3List.Clear();
                a4List.Clear();
                cList.Clear();
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
                    double ctime = ReadTimer(data.Name, "minutes", jsonFile) * 60000;
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
        public static string ReadJson(string GVersion, string Property, string json)
        {
            JObject rss = JObject.Parse(json);
            return (string)rss["Questions"][GVersion][Property];
        }
        public static double ReadTimer(string GVersion, string Property, string dir)
        {
            JObject rss = JObject.Parse(dir);
            return (double)rss["Timer"][GVersion][Property];
        }
    }
}
