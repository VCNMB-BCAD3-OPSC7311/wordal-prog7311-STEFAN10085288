using Microsoft.AspNetCore.Mvc;

namespace ICE_1__words_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WordsController : Controller
    {

       
        
        [HttpGet("GetSingle")]
        public ActionResult<string> GetSingle(string userInput)
        {
            WordFactory wordFactory = new WordFactory();
            IWords lang = wordFactory.getLanguage(userInput);
            WordsClass w = WordsClass.getInstance();
            return w.Single(lang.getNames());
        }


        [HttpGet("GetAll")]
        public String[] GetAll(string userInput)
        {
            WordFactory wordFactory = new WordFactory();
            IWords lang = wordFactory.getLanguage(userInput);
            WordsClass w = WordsClass.getInstance();
            return w.All(lang.getNames());
        }

        [HttpGet("GetSorted")]
        public String[] GetSorted(string userInput)
        {
            WordFactory wordFactory = new WordFactory();
            IWords lang = wordFactory.getLanguage(userInput);
            WordsClass w = WordsClass.getInstance();
            return w.Sorted(lang.getNames());
        }



        


    }
}
