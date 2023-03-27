namespace ICE_1__words_API
{
    public class Afrikaans :IWords
    {
        String[] arrAfrikaans = new String[10];

        public string[] getNames()
        {
            DBControl dBControl = new DBControl();
            return dBControl.Afrkaans();
            /*arrAfrikaans[0] = "Huis";
            arrAfrikaans[1] = "Boot";
            arrAfrikaans[2] = "Geweer";
            arrAfrikaans[3] = "Kool";
            arrAfrikaans[4] = "Pa";
            arrAfrikaans[5] = "Ma";
            arrAfrikaans[6] = "Rekenaar";
            arrAfrikaans[7] = "Boom";
            arrAfrikaans[8] = "Weer";
            arrAfrikaans[9] = "Sit";
            return arrAfrikaans;*/
        }

    }
}
