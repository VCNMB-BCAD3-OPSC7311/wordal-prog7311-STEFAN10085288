namespace ICE_1__words_API
{
    public class WordFactory
    {
        public IWords returnInstance;

        public IWords getLanguage(string lang)
        {
            if (lang.ToLower().Equals("english"))
            {
                returnInstance = new English();
            }
            else if (lang.ToLower().Equals("afrikaans"))
            {
                returnInstance = new Afrikaans();
            }
            else
            {
                returnInstance = new Xhosa();
            }
            return returnInstance;
        }
    }
}
