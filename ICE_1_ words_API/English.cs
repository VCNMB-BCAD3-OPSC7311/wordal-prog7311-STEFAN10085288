namespace ICE_1__words_API
{
    public class English :IWords
    {

        public string[] getNames()
        {
            DBControl dBControl = new DBControl();
            return dBControl.English();

        }
    }
}
