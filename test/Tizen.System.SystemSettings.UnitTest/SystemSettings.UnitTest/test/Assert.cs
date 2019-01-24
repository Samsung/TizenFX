using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace SystemSettingsUnitTest
{
    public class Assert
    {
        static public string result;
        static public string errorMessage;

        public Assert()
        {
            result = StrUtils.INIT;
            errorMessage = null;
        }

        static internal void SetExceptionMessage(Exception exception)
        {
            string errMessage = "Exception: " + exception.Message + Environment.NewLine;
            errMessage += "  Trace: " + exception.StackTrace + Environment.NewLine;
            Fail(errMessage);
        }

        static public void Pass()
        {
            // If it was marked Failed before, keep the result fail.
            if (result != StrUtils.FAIL) result = StrUtils.PASS;
        }

        static public void Fail(string message)
        {
            result = StrUtils.FAIL;
            // To remember message from first failure
            if (errorMessage == null) errorMessage = message;
            LogUtils.Write(LogUtils.INFO, LogUtils.TAG, "  " + message);
        }

        static public void Init()
        {
            result = StrUtils.INIT;
            errorMessage = null;
        }

        static public string GetResult()
        {
            return result;
        }

        static public void True(bool condition, string message = "Expects true, but got false.")
        {
            if (condition == true) Pass(); else Fail(message);
        }

        static public void IsTrue(bool condition, string message = "Expects true, but got false.")
        {
            if (condition == true) Pass(); else Fail(message);
        }

        static public void False(bool condition, string message = "Expects false, but got true.")
        {
            if (condition == false) Pass(); else Fail(message);
        }

        static public void IsFalse(bool condition, string message = "Expects false, but got true.")
        {
            if (condition == false) Pass(); else Fail(message);
        }

        static public void AreEqual<T>(T expected, T actual, string message = "Expects given values to be equal, but given values are not.")
        {
            if (EqualityComparer<T>.Default.Equals(expected, actual)) Pass(); else Fail(message);
        }

        static public void AreNotEqual<T>(T expected, T actual, string message = "Expects given values to be unequal, but given values are identical.")
        {
            if (!EqualityComparer<T>.Default.Equals(expected, actual)) Pass(); else Fail(message);
        }

        static public void NotNull(object anObject, string message = "Given object is not null.")
        {
            if (anObject != null) Pass(); else Fail(message);
        }

        static public void IsNull(object anObject, string message = "Given object is not null.")
        {
            if (anObject == null) Pass(); else Fail(message);
        }

        static public void IsNotNull(object anObject, string message = "Given object is null.")
        {
            if (anObject != null) Pass(); else Fail(message);
        }

        static public void IsA<T>(object actual, string message = "Given object is NOT an instance of specified type.")
        {
            if (actual is T) Pass(); else Fail(message);
        }

        static public void IsInstanceOf<T>(object actual, string message = "Given object is NOT an instance of specified type.")
        {
            if (actual.GetType() == typeof(T)) Pass(); else Fail(message);
        }

        static public void Greater<T>(T actual, T expected, string message) where T : IComparable<T>
        {
            if (actual.CompareTo(expected) > 0) Pass(); else Fail(message);
        }

        static public void Smaller<T>(T actual, T expected, string message) where T : IComparable<T>
        {
            if (actual.CompareTo(expected) < 0) Pass(); else Fail(message);
        }

        static public void IsNotEmpty(IEnumerable collection, string message)
        {
            foreach(object item in collection)
            {
                Pass();
                return;
            }

            Fail(message);
        }
    }

    public class StrUtils
    {
        static public string PASS = "PASS";
        static public string FAIL = "FAIL";
        static public string INIT = "INIT";
    }

    public class LogUtils
    {
        // write with white font
        static public string DEBUG = "D";

        // write with blue font
        static public string INFO = "I";

        // write with red font
        static public string ERROR = "E";

        static public string TAG = "CS-SYSTEM-SETTINGS";

        static public int ok_cnt = 0;
        static public int chk_cnt = 0;
        static public int not_support_cnt = 0;

        static public void Write(string level, string tag, string msg)
        {
            foreach (string line in msg.Split('\n'))
            {
                Tizen.Log.Debug(TAG, line);
            }

            //if (level == INFO)
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //else if (level == DEBUG)
            //    Console.ForegroundColor = ConsoleColor.White;
            //else if (level == ERROR)
            //    Console.ForegroundColor = ConsoleColor.Red;

            //Console.WriteLine(tag + " : [" + level + "] | " + msg);
            //Console.ResetColor();
        }
        static public void initWriteResult()
        {
            ok_cnt = 0;
            chk_cnt = 0;
            not_support_cnt = 0;

        }

        static public void StartTest()
        {
            chk_cnt++;
        }

        static public void NotSupport()
        {
            not_support_cnt++;
        }

        static public void WriteOK([CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Tizen.Log.Debug(TAG, "ok",file, func, line);
            ok_cnt++;
        }
        static public void WriteResult()
        {
            Tizen.Log.Debug(TAG, "Result : " + ok_cnt + " Pass / " + not_support_cnt + " Not Support / " + (chk_cnt - (ok_cnt + not_support_cnt)) + " Failed");
        }

    }
}
