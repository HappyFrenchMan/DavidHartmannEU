using System.Diagnostics;

namespace DHA.UTIL.Log4Net
{
    public class LogData
    {
        private string _strMessage;
        private Stopwatch _stopWatch;

        public LogData(string pStrMessage)
        {
            _strMessage = pStrMessage;
            _stopWatch = Stopwatch.StartNew();
        }

        public override string ToString()
        {
            _stopWatch.Stop();
            return _strMessage + " End : " + _stopWatch.Elapsed.ToString("c");
        }
    }//class
}//namespace
