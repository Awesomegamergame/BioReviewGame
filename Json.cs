using System.IO;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Environment;
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
        public static int JsonReader(string directory)
        {
            int size = 0;
            try
            {
                string jsonFile = new StreamReader(directory).ReadToEnd();
                dynamic obj = JsonConvert.DeserializeObject<dynamic>(jsonFile);
                dynamic json = obj.Questions;
                foreach (JProperty data in json)
                {
                    questionlist.Add(ReadJson(data.Name, "question", jsonFile, "Questions"));
                    a1List.Add(ReadJson(data.Name, "a1", jsonFile, "Questions"));
                    a2List.Add(ReadJson(data.Name, "a2", jsonFile, "Questions"));
                    a3List.Add(ReadJson(data.Name, "a3", jsonFile, "Questions"));
                    a4List.Add(ReadJson(data.Name, "a4", jsonFile, "Questions"));
                    cList.Add(ReadJson(data.Name, "c", jsonFile, "Questions"));
                    size++;
                }
            }
            catch (JsonSerializationException ex)
            {
                MessageBox.Show($"Something is wrong with the json file.\n\nError Code: {ex}");
                Application.Current.Shutdown();
            }
            return size;
        }
        public static int JsonReaderEmbed()
        {
            int size = 0;
            try
            {
                var DataStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BioReviewGame.Data.json");
                string jsonEmbed = new StreamReader(DataStream).ReadToEnd();
                dynamic obj = JsonConvert.DeserializeObject<dynamic>(jsonEmbed);
                dynamic json = obj.Questions;
                foreach (JProperty data in json)
                {
                    questionlist.Add(ReadJsonEmbed(data.Name, "question", jsonEmbed, "Questions"));
                    a1List.Add(ReadJsonEmbed(data.Name, "a1", jsonEmbed, "Questions"));
                    a2List.Add(ReadJsonEmbed(data.Name, "a2", jsonEmbed, "Questions"));
                    a3List.Add(ReadJsonEmbed(data.Name, "a3", jsonEmbed, "Questions"));
                    a4List.Add(ReadJsonEmbed(data.Name, "a4", jsonEmbed, "Questions"));
                    cList.Add(ReadJsonEmbed(data.Name, "c", jsonEmbed, "Questions"));
                    size++;
                }
            }
            catch (JsonSerializationException ex)
            {
                MessageBox.Show($"Something is wrong with the json file.\n\nError Code: {ex}");
                Application.Current.Shutdown();
            }
            return size;
        }
        public static string ReadJson(string GVersion, string Property, string json, string TopLevel)
        {
            JObject rss = JObject.Parse(json);
            return (string)rss[TopLevel][GVersion][Property];
        }
        public static string ReadJsonEmbed(string GVersion, string Property, string Embed, string TopLevel)
        {
            JObject rss = JObject.Parse(Embed);
            return (string)rss[TopLevel][GVersion][Property];
        }

    }
}
