using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Net;
using System.Xml.Linq;

namespace ICE_1__words_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WordsController : Controller
    {
        DateTime now = DateTime.Now;
        ILogger log = new ILogger();

        [HttpGet("GetSingle")]
        public ActionResult<string> GetSingle(string userInput)
        {
            WordFactory wordFactory = new WordFactory();
            IWords lang = wordFactory.getLanguage(userInput);
            WordsClass w = WordsClass.getInstance();

            string ip = Response.HttpContext.Connection.RemoteIpAddress.ToString();
            if (ip == "::1")
            {
                ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
            }

            log.Log("GetSingle method " + " # Language: " + userInput + " # Time: " + now.ToString() + "# IP Address: "  + ip);

            return w.Single(lang.getNames());
        }


        [HttpGet("GetAll")]
        public String[] GetAll(string userInput)
        {
            WordFactory wordFactory = new WordFactory();
            IWords lang = wordFactory.getLanguage(userInput);
            WordsClass w = WordsClass.getInstance();

            StreamWriter write = new StreamWriter("log.txt", true);
            write.WriteLine("GetAll method " + " # " + "Language: " + userInput + " # " + "Time: " + now.ToString());
            write.Close();

            return w.All(lang.getNames());
        }

        [HttpGet("GetSorted")]
        public String[] GetSorted(string userInput)
        {
            WordFactory wordFactory = new WordFactory();
            IWords lang = wordFactory.getLanguage(userInput);
            WordsClass w = WordsClass.getInstance();

            StreamWriter write = new StreamWriter("log.txt", true);
            write.WriteLine("GetSorted method " + " # " + "Language: " + userInput + " # " + "Time: " + now.ToString());
            write.Close();

            return w.Sorted(lang.getNames());
        }

    }
}
