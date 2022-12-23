using System;

namespace steelchemquality

{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            //判斷：不分大小寫
            if (!fileName.EndsWith(".log", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            return true;
        }
    }
}