using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Xml.Linq;

namespace ICE_1__words_API.Controllers
{

   

    [ApiController]
    [Route("[controller]")]


    public class WordsController : Controller
    {
        
        static string connString = @"Data Source = st10085288.database.windows.net; Initial Catalog = WordleApp; Persist Security Info=True;User ID = st10085288; Password=Lgnbxlnk0108;  Trusted_Connection=False; MultipleActiveResultSets=true";
        SqlConnection dbConn = new SqlConnection(connString);
        SqlCommand dbComm = new SqlCommand();


        DateTime now = DateTime.Now;
        ILogger log = new ILogger();

        [HttpGet("GetSingle")]
        public ActionResult<string> GetSingle(string userInput)
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

            return w.Single(lang.getNames());
        }


        [HttpGet("GetAll")]
        public String[] GetAll(string userInput)
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
        public String[] GetURLData()
        {
            //get ip address
            string ip = Response.HttpContext.Connection.RemoteIpAddress.ToString();
            if (ip == "::1")
            {
                ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
            }

            //log info
            log.Log("GetUserData method "  + "# Time: " + now.ToString() + "# IP Address: " + ip);

            DBControl dBControl = new DBControl();
            return dBControl.UserData();
        }


        [HttpPost("PostWords")]
        public void Post(string userInput) 
        {
            WordFactory wordFactory = new WordFactory();
            IWords lang = wordFactory.getLanguage(userInput);
            WordsClass w = WordsClass.getInstance();
            foreach (var item in w.All(lang.getNames()))
            {
                dbConn.Open();
                string sql = "Insert into " + userInput + " (word) Values (" + "'" + item + "') ;";
                dbComm = new SqlCommand(sql, dbConn);
                int i = dbComm.ExecuteNonQuery();
                if (i >= 1)
                {
                    Console.WriteLine("Added Successfully");

                }
                else
                {
                    Console.WriteLine("Not Added");

                }
                dbConn.Close();
            }


        }




    }
}
