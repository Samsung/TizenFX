// ****************************************************************************************************
// Namespace:       NUnit.Framework.TUnit
// Class:           TLogger
// Description:     Tizen UnitTest Logger
// Author:          Nguyen Truong Duong <duong.nt1@samsung.com>
// Notes:          
// Revision History:
// Name:           Date:        Description:
// ****************************************************************************************************
#define PORTABLE
#define TIZEN
#define NUNIT_FRAMEWORK
#define NUNITLITE
#define NET_4_5
#define PARALLEL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Framework.TUnit
{
    public class TLogger
    {
        public static string DefaultTag = "TUnit";
        public static string TUnitTag = "TUnit";
        public static string ExceptionTag = "TException";

        public static void Write(string logTag, string message)
        {
            Tizen.Log.Info(TUnitTag, message);
            Console.WriteLine(logTag + message);
        }

        public static void Write(string message)
        {
            Write(DefaultTag, message);
        }

        public static void WriteError(string message)
        {
            Tizen.Log.Error(TUnitTag, message);
        }
        public static void WriteError(string tag, string message)
        {
            Tizen.Log.Error(tag, message);
        }
    }

    public class LogUtils
    {
        static public string DEBUG = "D";
        static public string INFO = "I";
        static public string ERROR = "E";
        static public string TAG = "TUnit";

        static public void Write(string level, string tag, string msg)
        {
            foreach (string line in msg.Split('\n'))
            {
                Console.WriteLine(tag + "[" + level + "] | " + line);
                WriteDlog(level, tag, line);
           }
        }

        static private void WriteDlog(string level, string tag, string msg)
        {
            if (level.Equals(DEBUG))
            {
                Tizen.Log.Debug(tag, msg);
            }
            else if (level.Equals(INFO))
            {
                Tizen.Log.Info(tag, msg);
            }
            else if (level.Equals(ERROR))
            {
                Tizen.Log.Error(tag, msg);
            }
            else
            {
                Tizen.Log.Info(tag, msg);
            }
        }
    }
}
