using Microsoft.AspNetCore.Routing.Constraints;
using System.Net;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using Newtonsoft.Json;

namespace ICE_1__words_API
{
    public class DBControl
    {
        private static string url = "https://wordapidata.000webhostapp.com/";
        private List<string> userData = new List<string>();
        private List<string> afr = new List<string>();
        private List<string> eng = new List<string>();
        private List<string> xho = new List<string>();
        List<char> charsToRemove = new List<char>() { '[', ']' };


        //gets data from url as json file. Not working :(
        public  T download_serialized_json_data<T>() where T: new ()
        {
            using (var w =new System.Net.WebClient())
            {
                var json_data = string.Empty;
                try{
                    json_data = w.DownloadString(url + "?getuserdb");
                    }
                catch(Exception)
                {}
                var new_json_data = json_data.Trim(new char[] {'[', ']' });
                return !string.IsNullOrEmpty(new_json_data) ? JsonConvert.DeserializeObject<T>(new_json_data) : new T();
            }
        }


        //gets data as a list of strings
        public String[] UserData()
        {
            long length = 0;
            int i = 0;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?getuserdb");

            request.Method = "GET";
            request.Timeout = Timeout.Infinite;
            request.KeepAlive = true;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    length = response.ContentLength;
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFronServer = reader.ReadToEnd();
                    Console.WriteLine(responseFronServer);


                    string[] data = responseFronServer.Split(new char[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    while (data.Length > i)
                    {
                        userData.Add(data[i]);
                        i++;
                        Console.WriteLine(data[i]);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return userData.ToArray();
        }


       

        public String[] English()
        {
            long length = 0;
            int i = 0;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?getnamesenglish");

            request.Method = "GET";
            request.Timeout = Timeout.Infinite;
            request.KeepAlive = true;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    
                    length = response.ContentLength;
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFronServer = reader.ReadToEnd();
                    Console.WriteLine(responseFronServer);

                    foreach (var item in charsToRemove)
                    {
                        responseFronServer = responseFronServer.Replace(item.ToString(), string.Empty);
                    }

                    string[] data = responseFronServer.Split(new char[] { '[', '{', ',', '\"', ']' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    while (data.Length > i)
                    {
                        eng.Add(data[i]);
                        i++;
                        Console.WriteLine(data[i]);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return eng.ToArray();
        }

        public String[] Afrkaans()
        {
            long length = 0;
            int i = 0;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?getnamesafrikaans");

            request.Method = "GET";
            request.Timeout = Timeout.Infinite;
            request.KeepAlive = true;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    length = response.ContentLength;
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFronServer = reader.ReadToEnd();
                    Console.WriteLine(responseFronServer);

                    foreach (var item in charsToRemove)
                    {
                        responseFronServer = responseFronServer.Replace(item.ToString(), string.Empty);
                    }

                    string[] data = responseFronServer.Split(new char[] { '[', '{', ',', '\"' }, StringSplitOptions.RemoveEmptyEntries);
                    while (data.Length > i)
                    {
                        afr.Add(data[i]);
                        i++;
                        Console.WriteLine(data[i]);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return afr.ToArray();
        }

        public String[] Xhosa()
        {
            long length = 0;
            int i = 0;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?getnamesxhosa");

            request.Method = "GET";
            request.Timeout = Timeout.Infinite;
            request.KeepAlive = true;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    length = response.ContentLength;
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFronServer = reader.ReadToEnd();
                    Console.WriteLine(responseFronServer);
                    foreach (var item in charsToRemove)
                    {
                        responseFronServer = responseFronServer.Replace(item.ToString(), string.Empty);
                    }
                    string[] data = responseFronServer.Split(new char[] { '[', '{', ',', '\"' }, StringSplitOptions.RemoveEmptyEntries);
                    while (data.Length > i)
                    {
                        xho.Add(data[i]);
                        i++;
                        Console.WriteLine(data[i]);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return xho.ToArray();
        }

    }
}
