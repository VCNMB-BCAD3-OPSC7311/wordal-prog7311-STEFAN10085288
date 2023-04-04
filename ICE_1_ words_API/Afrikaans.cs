namespace ICE_1__words_API
{
    public class Afrikaans :IWords
    {
        String[] arrAfrikaans = new String[10];

        public string[] getNames()
        {
            DBControl dBControl = new DBControl();
            return dBControl.Afrkaans();

        }

    }
}
