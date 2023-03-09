namespace ICE_1__words_API
{
    public class English :IWords
    {
        String[] arrEnglish = new String[10];
        //public English()
        //{
        //    arrEnglish[0] = "Freezing";
        //    arrEnglish[1] = "Bracing";
        //    arrEnglish[2] = "Chilly";
        //    arrEnglish[3] = "Cool";
        //    arrEnglish[4] = "Mild";
        //    arrEnglish[5] = "Warm";
        //    arrEnglish[6] = "Balmy";
        //    arrEnglish[7] = "Hot";
        //    arrEnglish[8] = "Sweltering";
        //    arrEnglish[9] = "Scorching";
        //}

        //public string Single()
        //{
        //    Random random = new Random();
        //    return arrEnglish[random.Next(arrEnglish.Length)];
        //}

        //public string[] Sorted()
        //{
        //    return arrEnglish.OrderBy(x => x).ToArray();
        //}


        //public string[] All()
        //{
        //    return arrEnglish;
        //}

        public string[] getNames()
        {
            arrEnglish[0] = "Freezing";
            arrEnglish[1] = "Bracing";
            arrEnglish[2] = "Chilly";
            arrEnglish[3] = "Cool";
            arrEnglish[4] = "Mild";
            arrEnglish[5] = "Warm";
            arrEnglish[6] = "Balmy";
            arrEnglish[7] = "Hot";
            arrEnglish[8] = "Sweltering";
            arrEnglish[9] = "Scorching";
            return arrEnglish;
        }
    }
}
