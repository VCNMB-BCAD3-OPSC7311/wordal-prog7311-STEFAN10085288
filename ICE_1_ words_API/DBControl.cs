using Microsoft.AspNetCore.Routing.Constraints;
using System.Net;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace ICE_1__words_API
{
    public class DBControl
    {
        static string connString = @"Data Source = st10085288.database.windows.net; Initial Catalog = WordleApp; Persist Security Info=True;User ID = st10085288; Password=Lgnbxlnk0108;  Trusted_Connection=False; MultipleActiveResultSets=true";
        SqlConnection dbConn = new SqlConnection(connString);
        SqlCommand dbComm = new SqlCommand();

        private static string url = "https://wordapidata.000webhostapp.com/";
        private List<string> afr = new List<string>();
        private List<string> eng = new List<string>();
        private List<string> xho = new List<string>();
        List<char> charsToRemove = new List<char>() { '[', ']' };
        

        //gets user data from json url
        public static async void GetUserDataURL()
        {
            WordsClass w = WordsClass.getInstance();

            using (HttpClient client = new HttpClient())
            {
                string uesrUrl = url + "?getuserdb";
                HttpResponseMessage response = await client.GetAsync(uesrUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

                    foreach (User user in users)
                    {
                        InsertUserIntoDB(user);
                    }
                }
            }
        }

        //adds user data to DB
        public static void InsertUserIntoDB(User user)
        {
            using (SqlConnection dbconn = new SqlConnection(connString))
            {
                dbconn.Open();
                string sql = "INSERT INTO UserData (name, password, imageURL) VALUES (@name, @password, @imageURL);";
                SqlCommand dbcomm = new SqlCommand(sql, dbconn);
                dbcomm.Parameters.AddWithValue("@name", user.name);
                dbcomm.Parameters.AddWithValue("@password", user.password);
                dbcomm.Parameters.AddWithValue("@imageURL", user.imageURL);
                dbcomm.ExecuteNonQuery();
            }
        }

        //gets english words from json url
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

        //gets afrikaans words from json url
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

        //gets xhosa words from json url
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

        //gets random word from DB
        public string getRandomWord(string userInput)
        {
            dbConn.Open();
            string sql = "SELECT TOP 1 word FROM " + userInput + " where len(word) = 5 ORDER BY NEWID() ;";
            dbComm = new SqlCommand(sql, dbConn);
            int i = dbComm.ExecuteNonQuery();
            string output = (string)dbComm.ExecuteScalar();
            if (i >= 1)
            {
                Console.WriteLine("Retrieved Successfully");
            }
            else
            {
                Console.WriteLine("Not retrieved");
            }

            dbConn.Close();
            return output;
        }

        //adds  words to DB
        public void postWords(string userInput, String[] arrWords)
        {
            foreach (var item in arrWords)
            {
                dbConn.Open();
                string sql = "Insert into " + userInput + " (word) Values (" + "'" + item + "') ;";
                dbComm = new SqlCommand(sql, dbConn);
                int i = dbComm.ExecuteNonQuery();
                if (i >= 1)
                {
                    Console.WriteLine("Added Successfully");

                }
                else
                {
                    Console.WriteLine("Not Added");

                }
                dbConn.Close();
            }
        }

    }
}
