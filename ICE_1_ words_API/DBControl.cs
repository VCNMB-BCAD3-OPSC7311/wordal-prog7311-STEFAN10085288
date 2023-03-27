using Microsoft.AspNetCore.Routing.Constraints;
using System.Net;

namespace ICE_1__words_API
{
    public class DBControl
    {
        private static string url = "https://wordapidata.000webhostapp.com/";
        private List<string> userData = new List<string>();
        private List<string> afr = new List<string>();
        private List<string> eng = new List<string>();
        private List<string> xho = new List<string>();
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
                    string[] data = responseFronServer.Split(new char[] { '[', '{', ',', '\"' }, StringSplitOptions.RemoveEmptyEntries);
                   
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
                    string[] data = responseFronServer.Split(new char[] { '[', '{', ',', '\"' }, StringSplitOptions.RemoveEmptyEntries);
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
