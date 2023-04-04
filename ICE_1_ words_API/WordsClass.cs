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
        DBControl dbControl = new DBControl();

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

        //posts words to DB
        public void postWords(string userInput, String[] arrWords)
        {            
            dbControl.postWords(userInput, arrWords);
        }


        //gets random word from DB
        public string getRandomWord(string userInput)
        {
            return dbControl.getRandomWord(userInput);


        }

        //posts user info to DB
        public  void postUserData()
        {
            DBControl.GetUserDataURL();
        }





    }
}
