namespace ICE_1__words_API
{
    public abstract class LogBase
    {
        public abstract void Log(string message);
    }


    public class ILogger : LogBase
    {
        public string filePath = @"D:\Varsity IT\Year3\PROG\ICE_1_ words_API\ICE_1_ words_API\log.txt";
        public override void Log(string message)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(message);
                sw.Close();
            }
        }
    }

}
