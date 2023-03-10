namespace ICE_1__words_API
{
    public abstract class LogBase
    {
        public abstract void Log(string message);
    }


    public class ILogger : LogBase
    {
       
        public override void Log(string message)
        {
            StreamWriter sw = new StreamWriter("LogFile.txt", true);         
            sw.WriteLine(message);
            sw.Close();
            
        }
    }


    

}
