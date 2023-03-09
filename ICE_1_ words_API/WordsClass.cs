using System;
using System.Collections.Immutable;
using System.Security.Cryptography;

namespace ICE_1__words_API
{
    public class WordsClass
    {
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

        public  String[] All(String[] arrWords)
        {
            return arrWords;
        }

        public  String[] Sorted(String[] arrWords)
        {
            return arrWords.OrderBy(x => x).ToArray();
        }

        public   String Single(String[] arrWords)
        {
            Random random= new Random();
            return arrWords[random.Next(arrWords.Length)];

        }
    }
}
