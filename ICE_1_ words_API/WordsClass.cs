using System;
using System.Collections.Immutable;
using System.Security.Cryptography;

namespace ICE_1__words_API
{
    public class WordsClass
    {
        private static WordsClass instance;
        //meneer se code
         String[] arrWords = new String[10];


        
        private  WordsClass()
        {
            arrWords[0] = "Freezing";
            arrWords[1] = "Bracing";
            arrWords[2] = "Chilly";
            arrWords[3] = "Cool";
            arrWords[4] = "Mild";
            arrWords[5] = "Warm";
            arrWords[6] = "Balmy";
            arrWords[7] = "Hot";
            arrWords[8] = "Sweltering";
            arrWords[9] = "Scorching";
        }

        public static WordsClass getInstance()
        {
            if (instance == null)
            {
                instance = new WordsClass();
            }
            return instance;
        }

        public  String[] All()
        {
            return arrWords;
        }

        public  String[] Sorted()
        {
            return arrWords.OrderBy(x => x).ToArray();
        }

        public   String Single()
        {
            Random random= new Random();
            return arrWords[random.Next(arrWords.Length)];

        }

        //My code
        //public string word { get; set; }
    }
}
