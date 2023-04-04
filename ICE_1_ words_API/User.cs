using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System.Data.SqlClient;
using System.Security.Policy;

namespace ICE_1__words_API
{
    public class User
    {
        //db connection
        static string connString = @"Data Source = st10085288.database.windows.net; Initial Catalog = WordleApp; Persist Security Info=True;User ID = st10085288; Password=Lgnbxlnk0108;  Trusted_Connection=False; MultipleActiveResultSets=true";
        private static string url = "https://wordapidata.000webhostapp.com/";

        public string Id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string imageURL { get; set; }


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


        public static async void GetUserDataURL()
        {
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
                        User.InsertUserIntoDB(user);
                    }
                }
            }
        }
    }

    


}
