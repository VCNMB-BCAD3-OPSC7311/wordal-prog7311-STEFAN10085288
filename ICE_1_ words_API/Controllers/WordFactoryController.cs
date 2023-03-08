using Microsoft.AspNetCore.Mvc;

namespace ICE_1__words_API.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class WordFactoryController : Controller
    {
        
        WordFactory wordFactory = new WordFactory();

        //[HttpPost]
        //public IActionResult PsorLang([FromBody] string lang)
        //{

        //    IWords words = wordFactory.getLanguage(lang);          
        //    return Ok("user input recieved successfully");
        //}


        [HttpGet("{userInput1}/single")]
        public ActionResult<string> GetSingle(string userInput1)
        {
            IWords words = wordFactory.getLanguage(userInput1);
            return words.Single();

        }

        [HttpGet("{userInput2}/all")]
        public String[] GetAll(string userInput2)
        {

            IWords words = wordFactory.getLanguage(userInput2);
            return words.All();
        }

        [HttpGet("{userInput3}/sorted")]
        public String[] GetSorted(string userInput3)
        {
            IWords words = wordFactory.getLanguage(userInput3);
            return words.Sorted();
        }

    }
}
