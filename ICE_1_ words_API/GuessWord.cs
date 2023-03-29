using System.Collections;

namespace ICE_1__words_API
{
    public class GuessWord
    {

        public Boolean checkWord(string guess, string word)
        {
            bool result = false;
            if (guess.Equals(word))
            {
                result = true;
            }
            return result;
        }

        public ArrayList checkCharacterPosition(string letter, string word)
        {
            ArrayList arrPositionResults = new ArrayList();
            bool result = false;
            foreach (char c in word) 
            {
                result = letter.Equals(c);
                arrPositionResults.Add(result);
            }
            return arrPositionResults;
        }

        public ArrayList checkCharacterContain(string letter, string word)
        {
            ArrayList arrContainsResults = new ArrayList();
            bool isExist = false;
            foreach (char c in word)
            {
                isExist = word.Contains(c);
                arrContainsResults.Add(isExist);
            }
            return arrContainsResults;
        }
    }
}
