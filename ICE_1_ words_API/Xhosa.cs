namespace ICE_1__words_API
{
    public class Xhosa : IWords
    {
        String[] arrXhosa = new String[10];
        private Xhosa()
        {
            arrXhosa[0] = "Kholeka";
            arrXhosa[1] = "Mdladlana";
            arrXhosa[2] = "Phathiswa ";
            arrXhosa[3] = "Mhlambiso";
            arrXhosa[4] = "Ziyanda ";
            arrXhosa[5] = "Kolisi";
            arrXhosa[6] = "Buyiswa ";
            arrXhosa[7] = "Ncamashe";
            arrXhosa[8] = "Faniswa";
            arrXhosa[9] = "Vetyeka";
        }

        public string Single()
        {
            Random random = new Random();
            return arrXhosa[random.Next(arrXhosa.Length)];
        }

        public string[] Sorted()
        {
            return arrXhosa.OrderBy(x => x).ToArray();
        }


        public string[] All()
        {
            return arrXhosa;
        }
    }
}
