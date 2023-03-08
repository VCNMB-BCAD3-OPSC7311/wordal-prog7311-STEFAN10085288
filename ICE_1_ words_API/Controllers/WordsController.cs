using Microsoft.AspNetCore.Mvc;

namespace ICE_1__words_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WordsController : Controller
    {

       
        //meneer se code
        [HttpGet("GetSingle")]
        public ActionResult<string> GetSingle()
        {
            WordsClass w = WordsClass.getInstance();
            return w.Single();
        }


        [HttpGet("GetAll")]
        public String[] GetAll()
        {
            WordsClass w = WordsClass.getInstance();
            return w.All();
        }

        [HttpGet("GetSorted")]
        public String[] GetSorted()
        {
            WordsClass w = WordsClass.getInstance();
            return w.Sorted();
        }



        


    }
}
