using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;
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
        public string GetSingle(string userInput)
        {
            WordFactory wordFactory = new WordFactory();
            IWords lang = wordFactory.getLanguage(userInput);
            WordsClass w = WordsClass.getInstance();

            /*//get ip address
            string ip = Response.HttpContext.Connection.RemoteIpAddress.ToString();
            if (ip == "::1")
            {
                ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
            }

            //log info
            log.Log("GetSingle method " + " # Language: " + userInput + " # Time: " + now.ToString() + "# IP Address: " + ip);*/

            return w.Single(lang.getNames());
        }


        [HttpGet("GetAll")]
        public String[] GetAll(string userInput)
        {
            WordFactory wordFactory = new WordFactory();
            IWords lang = wordFactory.getLanguage(userInput);
            WordsClass w = WordsClass.getInstance();

            /*//get ip address
            string ip = Response.HttpContext.Connection.RemoteIpAddress.ToString();
            if (ip == "::1")
            {
                ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
            }

            //log info
            log.Log("GetSingle method " + " # Language: " + userInput + " # Time: " + now.ToString() + "# IP Address: " + ip);*/

            return w.All(lang.getNames());
        }

        [HttpGet("GetSorted")]
        public String[] GetSorted(string userInput)
        {
            WordFactory wordFactory = new WordFactory();
            IWords lang = wordFactory.getLanguage(userInput);
            WordsClass w = WordsClass.getInstance();

            //get ip address
            string ip = Response.HttpContext.Connection.RemoteIpAddress.ToString();
            if (ip == "::1")
            {
                ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
            }

            //log info
            log.Log("GetSingle method " + " # Language: " + userInput + " # Time: " + now.ToString() + "# IP Address: " + ip);

            return w.Sorted(lang.getNames());
        }


        [HttpGet("GetUserData")]
        public  String[] GetUserData()
        {

            WordsClass w = WordsClass.getInstance();

            //get ip address
            string ip = Response.HttpContext.Connection.RemoteIpAddress.ToString();
            if (ip == "::1")
            {
                ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
            }

            //log info
            log.Log("GetUserData method " + "# Time: " + now.ToString() + "# IP Address: " + ip);

            DBControl dBControl = new DBControl();
            return dBControl.UserData();
        }


        [HttpPost("PostWords")]
        public  void PostWords(string userInput) 
        {
            WordFactory wordFactory = new WordFactory();
            IWords lang = wordFactory.getLanguage(userInput);
            WordsClass w = WordsClass.getInstance();

            w.postWords(userInput, w.All(lang.getNames()));

            //get ip address
            string ip = Response.HttpContext.Connection.RemoteIpAddress.ToString();
            if (ip == "::1")
            {
                ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
            }

            //log info
            log.Log("PostWords method " + " # Language: " + userInput + " # Time: " + now.ToString() + "# IP Address: " + ip);
        }

        //get from DB
        [HttpGet("getWords")]
        public string GetRandomWord(string userInput)
        {
            WordFactory wordFactory = new WordFactory();
            IWords lang = wordFactory.getLanguage(userInput);
            WordsClass w = WordsClass.getInstance();


            ////get ip address
            //string ip = Response.HttpContext.Connection.RemoteIpAddress.ToString();
            //if (ip == "::1")
            //{
            //    ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
            //}

            ////log info
            //log.Log("PostWords method " + " # Language: " + userInput + " # Time: " + now.ToString() + "# IP Address: " + ip);

            return w.getRandomWord(userInput);
        }


        /* [HttpPost("PostUserInFo")]
         public void PostUserInfo()
         {
             WordFactory wordFactory = new WordFactory();
             IWords lang = wordFactory.getLanguage(userInput);
             WordsClass w = WordsClass.getInstance();



             //get ip address
             string ip = Response.HttpContext.Connection.RemoteIpAddress.ToString();
             if (ip == "::1")
             {
                 ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
             }

             //log info
             log.Log("PostUser method " + " # Time: " + now.ToString() + "# IP Address: " + ip);
         }*/



    }
}
