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

        public List<bool> checkCharacterPosition(string letter, string word)
        {
            List<bool> arrPositionResults = new List<bool>();
            bool result = false;
            foreach (char c in word) 
            {
                result = letter.Equals(c.ToString());
                arrPositionResults.Add(result);
            }
            return arrPositionResults;
        }

        public List<bool> checkCharacterContain(string letter, string word)
        {
            List<bool> arrContainsResults = new List<bool>();
            bool isExist = false;
            foreach (char c in word)
            {
                isExist = word.Contains(letter.ToString());
                arrContainsResults.Add(isExist);
            }
            return arrContainsResults;
        }
    }
}
