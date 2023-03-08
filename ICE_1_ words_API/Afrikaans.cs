namespace ICE_1__words_API
{
    public class Afrikaans :IWords
    {
        String[] arrAfrikaans = new String[10];
        private Afrikaans()
        {
            arrAfrikaans[0] = "Huis";
            arrAfrikaans[1] = "Boot";
            arrAfrikaans[2] = "Geweer";
            arrAfrikaans[3] = "Kool";
            arrAfrikaans[4] = "Pa";
            arrAfrikaans[5] = "Ma";
            arrAfrikaans[6] = "Rekenaar";
            arrAfrikaans[7] = "Boom";
            arrAfrikaans[8] = "Weer";
            arrAfrikaans[9] = "Sit";
        }

        public string Single()
        {
            Random random = new Random();
            return arrAfrikaans[random.Next(arrAfrikaans.Length)];
        }

        public string[] Sorted()
        {
            return arrAfrikaans.OrderBy(x => x).ToArray();
        }


        public string[] All()
        {
            return arrAfrikaans;
        }
    }
}
