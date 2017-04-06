using System;
using System.IO;

namespace SecurityApplication.Util
{
    public class LogApp
    {
        /// <summary>
        ///     Function Log Database Error
        /// </summary>
        /// <param name="messageLog"></param>
        public static void LogDatabaseError(string messageLog)
        {
            var objFilestream =
                 new FileStream("D:\\" + ConstantVariable.LogDatabase, FileMode.Append, FileAccess.Write);
            DateTime localDate = DateTime.Now;
            var objStreamWriter = new StreamWriter(objFilestream);
            objStreamWriter.WriteLine(localDate + " - " + messageLog);
            objStreamWriter.Close();
            objFilestream.Close();
        }

        /// <summary>
        ///     Function Log Application Error
        /// </summary>
        /// <param name="messageLog"></param>
        public static void LogApplicationError(string messageLog)
        {
            var objFilestream =
                 new FileStream("D:\\" + ConstantVariable.LogApplcation, FileMode.Append, FileAccess.Write);
            DateTime localDate = DateTime.Now;
            var objStreamWriter = new StreamWriter(objFilestream);
            objStreamWriter.WriteLine(localDate + " - " + messageLog);
            objStreamWriter.Close();
            objFilestream.Close();
        }
    }
}