namespace ICE_1__words_API
{
    public class Xhosa : IWords
    {

        public string[] getNames()
        {
            DBControl dBControl = new DBControl();
            return dBControl.Xhosa();

        }

       

    }
}
