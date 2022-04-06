// ****************************************************************************************************
// Namespace:       NUnit.Framework.TUnit
// Class:           TSettings
// Description:     Tizen UnitTest Settings
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
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;

namespace NUnit.Framework.TUnit
{
    public class TSettings
    {
        private static int DefaultTCDelay = 50; // Default time delay for each test case execution (millisecond) to reduce CPU consumption
        private static string OutputFilePathName = ""; // XML Result File Path Name
        public static long CurTCIndex = 0; // HACKING: Curent TC Index

        private static TSettings _instance;
        private static object lockObject = new object();

        public static TSettings GetInstance()
        {
            lock (lockObject)
            {
                if (_instance == null)
                {
                    _instance = new TSettings();
                }
            }
            return _instance;
        }

        private TSettings()
        {
            IsManual = false;
        }

        public void SetDefaultTCDelay(int defaultTCDelay)
        {
            DefaultTCDelay = defaultTCDelay;
        }

        public int GetDefaultTCDelay()
        {
            return DefaultTCDelay;
        }

        public void SetOutputFilePathName(string outputFilePathName)
        {
            OutputFilePathName = outputFilePathName;
        }

        public string GetOutputFilePathName()
        {
            return OutputFilePathName;
        }

        #region testkit-stub api
        // [Hyukin.Kwon-code]: session_id for communication with testkit-stub
        private static bool _isSlaveMode = false;
        private static int _session_id;
        private static string _server = "http://127.0.0.1:8000";
        // private static string _proxy = "http://10.112.1.184:8080/";

        public static bool IsLastTC = false;
        private static string _testcase_id;

        public void ConnectTestkitStub()
        {
            TLogger.Write("############### ConnectTestkitStub ###############");
            Random rnd = new Random();
            _session_id = rnd.Next(1000, 9999);
            _server = "http://127.0.0.1:8000";
            _isSlaveMode = SyncSessionIdRequest();
            Console.WriteLine("[TUnitTest] - " + "IsSlaveMode : " + _isSlaveMode);
        }

        private bool SyncSessionIdRequest()
        {
            TLogger.Write("############### In SyncSessionIdRequest ###############");
            Console.WriteLine("[TUnitTest] - " + "In SyncSessionIdRequest");

            string result = RequestGET("init_session_id", _session_id);

            if (result == null)
                return false;

            CheckServer();

            //string[] jobj = ResultParser (result);
            //if (jobj [1] == "OK" && jobj [2] == "1")
            //	return true;

            Dictionary<string, string> dic = parseJson(result);

            if (dic["OK"].Equals("1"))
                return true;
            else
                return false;
        }

        private bool CheckServer()
        {
            TLogger.Write("############### In CheckServer ###############");
            Console.WriteLine("[TUnitTest] - " + "In CheckServer");
            string result = RequestGET("check_server");

            if (result == null)
                return false;

            string[] jobj = ResultParser(result);
            if (jobj != null)
                return true;
            else
                return false;
        }

        private string RequestGET(string key)
        {
            TLogger.Write("############### In RequestGET ###############");
            Console.WriteLine("[TUnitTest] - " + "In RequestGET");

            string result = null;
            string url = _server + "/" + key;

            Console.WriteLine("[TUnitTest] - " + "RequestGET url : " + url);
            TLogger.Write("############### RequestGET url ###############");

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                //Reference
                // https://msdn.microsoft.com/en-us/library/czdt10d3(v=vs.110).aspx

                WebProxy proxyObject = new WebProxy(_server, true);
                request.Proxy = proxyObject;


                IWebProxy proxy = request.Proxy;

                if (proxy != null)
                {
                    Console.WriteLine("[TUnitTest] - Proxy is NOT null. Is ByPassed : " + proxy.IsBypassed(new Uri(url)));
                }
                else
                {
                    Console.WriteLine("[TUnitTest] - " + "Proxy is null; no proxy will be used");
                }

                Task<WebResponse> res = request.GetResponseAsync();
                res.Wait();
                WebResponse response = res.Result;
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                result = reader.ReadToEnd();
                Console.WriteLine("[TUnitTest] - " + "RequestGET Result : " + result);
                TLogger.Write("############### RequestGET Result : " + result + " ###############");
                stream.Dispose();
                response.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("[TUnitTest] - " + "RequestGET error : " + e.ToString());
            }

            return result;
        }

        private string RequestGET(string key, int sessionId)
        {
            TLogger.Write("############### In RequestGET ###############");
            Console.WriteLine("[TUnitTest] - " + "In RequestGET");

            string result = null;
            string url = _server + "/" + key + "?session_id=" + _session_id;

            Console.WriteLine("[TUnitTest] - " + "RequestGET url : " + url);
            TLogger.Write("############### RequestGET url : " + url + " ###############");

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                //Reference
                // https://msdn.microsoft.com/en-us/library/czdt10d3(v=vs.110).aspx

                WebProxy proxyObject = new WebProxy(_server, true);
                request.Proxy = proxyObject;


                IWebProxy proxy = request.Proxy;

                if (proxy != null)
                {
                    Console.WriteLine("[TUnitTest] - Proxy is NOT null. Is ByPassed : " + proxy.IsBypassed(new Uri(url)));
                }
                else
                {
                    Console.WriteLine("[TUnitTest] - " + "Proxy is null; no proxy will be used");
                }

                Task<WebResponse> res = request.GetResponseAsync();
                res.Wait();
                WebResponse response = res.Result;
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                result = reader.ReadToEnd();
                Console.WriteLine("[TUnitTest] - " + "RequestGET Result: " + result);
                stream.Dispose();
                response.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("[TUnitTest] - " + "RequestGET error : " + e.Message);
            }
            return result;
        }

        private string[] ResultParser(string TCID)
        {
            string[] delimiter = { "{\"", "\":\"", "\":", ",\"", "\"}", "}" };
            string[] stringPieces = null;

            try
            {
                stringPieces = TCID.Split(delimiter, StringSplitOptions.None);
            }
            catch (Exception e)
            {
                Console.WriteLine("[TUnitTest] - " + "ResultParser : " + e.Message);
            }

            return stringPieces;
        }

        public Dictionary<string, string> parseJson(string jsonString)
        {
            Dictionary<string, string> jsonDic = new Dictionary<string, string>();
            jsonString = jsonString.Replace("\n", "");
            jsonString = jsonString.Replace("{", "");
            jsonString = jsonString.Replace("}", "");

            string[] ary = jsonString.Split(',');

            foreach (string item in ary)
            {
                if (!item.Equals(""))
                {
                    string[] keyValue = item.Split(':');
                    keyValue[0] = keyValue[0].Replace(" ", "");
                    keyValue[0] = keyValue[0].Replace("\"", "");

                    // 처음 공백 제거
                    while (keyValue[1].StartsWith(" "))
                        keyValue[1] = keyValue[1].Substring(1);
                    // 마지막 공백 제거
                    while (keyValue[1].EndsWith(" "))
                        keyValue[1] = keyValue[1].Substring(0, keyValue[1].Length - 2);

                    keyValue[1] = keyValue[1].Replace("\"", "");

                    Console.Write(" key : " + keyValue[0] + ", value : " + keyValue[1] + "\n");
                    jsonDic.Add(keyValue[0], keyValue[1].Replace("\"", ""));
                }
            }

            return jsonDic;
        }

        public bool CheckExecutionProgressRequest()
        {
            Console.WriteLine("[TUnitTest] - " + "In CheckExecutionProgressRequest");

            string result = RequestGET("check_execution_progress", _session_id);

            if (result == null)
                return false;

            string[] jobj = ResultParser(result);
            if (jobj != null)
                return true;
            else
                return false;
        }

        public bool AskNextStepRequest()
        {
            Console.WriteLine("[TUnitTest] - " + "In AskNextStepRequest");

            string result = RequestGET("ask_next_step", _session_id);
            TLogger.Write("############### In AskNextStepRequest ###############");

            if (result == null)
                return false;

            Dictionary<string, string> dic = parseJson(result);

            if (dic == null)
                return false;

            if (dic["step"].Equals("continue"))
                return true;
            else
                return false;
        }

        public List<string> ManualTestTaskRequest()
        {
            List<string> list = new List<string>();
            string result = RequestGET("manual_cases", _session_id);
            if (result == null)
                return list;

            result = result.Replace("[", "");
            result = result.Replace("]", "");
            result = result.Replace("\n", "");
            result = result.Replace("{", "");
            result = result.Replace("}", "");
            result = result.Replace(" ", "");

            string[] arr = result.Split(',');

            foreach (string item in arr)
            {
                if (!item.Equals("") && item.Contains("case_id"))
                {
                    string tmp = item.Replace("\"", "");
                    string[] keyValue = tmp.Split(':');
                    list.Add(keyValue[1]);
                }
            }

            return list;
        }

        public string AutoTestTaskRequest()
        {
            Console.WriteLine("[TUnitTest] - " + "In AutoTestTaskRequest");

            string result = RequestGET("auto_test_task", _session_id);
            TLogger.Write("############### In AutoTestTaskRequest ###############");
            TLogger.Write("");
            TLogger.Write("");
            TLogger.Write("");

            if (result == null)
                return "";

            Dictionary<string, string> dic = parseJson(result);

            if (dic == null)
                return "";

            if (dic.ContainsKey("none"))
                IsLastTC = true;

            try
            {
                Console.WriteLine("[TUnitTest] - " + "TC name received:[" + dic["case_id"] + "]");
            }
            catch (Exception e)
            {
                Console.WriteLine("[TUnitTest] - " + "Json parsing Error : " + e.Message);
                return "";
            }

            return dic["case_id"];

        }
        public string RequestPOST(string key, string json)
        {
            Console.WriteLine("[TUnitTest] - " + "In RequestPOST");
            string result = null;
            TLogger.Write("############### In RequestPOST ###############");
            string url = _server + "/" + key;
            json = json + "&session_id=" + _session_id;

            Console.WriteLine("[TUnitTest] - " + "RequestPOST url :" + url);

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // WebRequest 객체 형성 및 HttpWebRequest 로 형변환


                //Reference
                // https://msdn.microsoft.com/en-us/library/czdt10d3(v=vs.110).aspx

                WebProxy proxyObject = new WebProxy(_server, true);
                request.Proxy = proxyObject;


                IWebProxy proxy = request.Proxy;

                if (proxy != null)
                {
                    Console.WriteLine("[TUnitTest] - Proxy is NOT null. Is ByPassed : " + proxy.IsBypassed(new Uri(url)));
                }
                else
                {
                    Console.WriteLine("[TUnitTest] - " + "Proxy is null; no proxy will be used");
                }

                request.Method = "POST"; // 전송 방법 "GET" or "POST"
                request.ContentType = "application/json";

                byte[] byteArray = Encoding.UTF8.GetBytes(json);

                Task<Stream> dataAsync = request.GetRequestStreamAsync();
                dataAsync.Wait();
                Stream dataStream = dataAsync.Result;
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Dispose();

                Task<WebResponse> resAsync = request.GetResponseAsync();
                resAsync.Wait();

                WebResponse response = resAsync.Result;

                Stream respPostStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(respPostStream);
                result = reader.ReadToEnd();

                Console.WriteLine("[TUnitTest] - " + "###############Asavin############### RequestPOST Result :" + result);
                reader.Dispose();

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("[TUnitTest] - " + "RequestPOST ERROR :" + e.Message);
            }
            return result;
        }

        public void SubmitManualResult()
        {
            TLogger.Write("############### SubmitManualResult ###############");
            LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Manual test execution done.");

            if (_isSlaveMode == true)
            {
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Submit result to inform manual execution done.");
                RequestGET("generate_xml");
            }
        }

#if TIZEN
        public List<string> GetNotPassListManual()
        {
            List<string> list = new List<string>();
            LogUtils.Write(LogUtils.INFO, LogUtils.TAG, "############### GetNotPassListManual ###############");
            if (AskNextStepRequest())
            {
                CheckExecutionProgressRequest();
                list = ManualTestTaskRequest();
            }
            return list;
        }

        public void NextStepRequest()
        {
            TLogger.Write("############### NextStepRequest ###############");
            if (AskNextStepRequest())
            {
                CheckExecutionProgressRequest();
            }
            if (AskNextStepRequest())
            {
                Testcase_ID = AutoTestTaskRequest();
            }
        }

        public SingleTestDoneEventArgs GetSingleTestDoneEventArgs()
        {
            SingleTestDoneEventArgs singleTestArgs = new SingleTestDoneEventArgs();
            singleTestArgs.Name = Testcase_ID;
            singleTestArgs.Result = TCResult;
            singleTestArgs.Message = TCMessage;
            return singleTestArgs;
        }

        public bool IsSlaveMode
        {
            get { return _isSlaveMode; }
        }

        public bool IsManual
        {
            get;
            set;
        }

        public string Testcase_ID
        {
            get { return _testcase_id; }
            set { _testcase_id = value; }
        }


        public string TCResult
        {
            get;
            set;
        }

        public string TCMessage
        {
            get;
            set;
        }

#endif

        #endregion
    }


    public class SingleTestDoneEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
    }
}
