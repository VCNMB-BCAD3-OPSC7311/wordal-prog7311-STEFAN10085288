using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Immutable;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace ICE_1__words_API
{
    public class WordsClass
    {
        //db connection
        static string connString = @"Data Source = st10085288.database.windows.net; Initial Catalog = WordleApp; Persist Security Info=True;User ID = st10085288; Password=Lgnbxlnk0108;  Trusted_Connection=False; MultipleActiveResultSets=true";
        SqlConnection dbConn = new SqlConnection(connString);
        SqlCommand dbComm = new SqlCommand();
        public String  randomWord = "";
        List<String> list = new List<String>();

        //singleton
        private static WordsClass instance;
       
        private  WordsClass()
        {
           
        }

        public static WordsClass getInstance()
        {
            if (instance == null)
            {
                instance = new WordsClass();
            }
            return instance;
        }

        public String[] All(String[] arrWords)
        {
            return arrWords;
        }

        public String[] Sorted(String[] arrWords)
        {
            return arrWords.OrderBy(x => x).ToArray();
        }

        public String Single(String[] arrWords)
        {
           
            Random random= new Random();
            foreach (String word in arrWords)
            {
               if(word.Length == 5)
                {
                    list.Add(word);
                }
            }        
            int index = random.Next(list.Count);
            randomWord = list[index];     
            return randomWord;

        }

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


        public string getRandomWord(string userInput)
        {
            dbConn.Open();
            string sql =  "SELECT TOP 1 word FROM " + userInput + " where len(word) = 5 ORDER BY NEWID() ;";
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

        public void postUserInfo(User user)
        {
/*            foreach (var item in)
            {
                dbConn.Open();
                string sql = "Insert into Users (name, password, imageURl) Values ('" + user.Name + "','" + user.Password + "','" + user.ImgUrl + "' ) ;";
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
            }*/
        }





    }
}
