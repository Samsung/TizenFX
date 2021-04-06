// ****************************************************************************************************
// Namespace:       NUnitLite.TUnit
// Class:           TRunner
// Description:     Tizen UnitTest Runner to run Tizen C# test-suite automatically
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
using System.IO;
using System.Reflection;
using System.Xml;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework.TUnit;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace NUnitLite.TUnit
{
    public class TRunner
    {
        private Assembly _testAssembly;
        private TextRunner _textRunner;
        private string[] args;
        public static string TESTCASE_XML_NAME = "test";
        private string pkgName = "";

#if TIZEN
        /**
         * @summary: Declares event will be emitted when a single test execution done.
         */
        public event EventHandler<SingleTestDoneEventArgs> SingleTestDone;

        /**
         * @summary: Forwards event when a single test execution done.
         */
        protected virtual void OnSingleTestDone(SingleTestDoneEventArgs e)
        {
            EventHandler<SingleTestDoneEventArgs> handler = SingleTestDone;
            if (handler != null)
            {
                handler(this, e);
            }
        }
#endif

        public TRunner(Assembly testAssembly)
        {
            _testAssembly = testAssembly;
            Tizen.Log.Fatal("NUITEST", $"");
            Tizen.Log.Fatal("NUITEST", $"TRunner() _testAssembly={_testAssembly}");
#if TIZEN
            TSettings.GetInstance().ConnectTestkitStub();
#endif
        }

        public TRunner() : this(Assembly.GetEntryAssembly())
        {
            Tizen.Log.Fatal("NUITEST", $"");
            Tizen.Log.Fatal("NUITEST", $"TRunner()");
        }

        /// <summary>
        /// Get the app name of the Tizen package
        /// </summary>
        private string GetPackageName(string basePath)
        {
            // basePath = "/opt/home/owner/apps_rw/Tizen.Applications.Manual.Tests/bin/";
            if (basePath.Contains("bin\\Debug"))
            {
                // If build on Window, return "Test"
                //LogUtils.Write(LogUtils.ERROR, LogUtils.TAG, "Run on Window");
                return "Test";
            }

            string[] delimiter = { "/" };
            string[] delimiterDot = { "." };
            string[] strAry;
            string returnValue = "";
            try
            {
                strAry = basePath.Split(delimiter, StringSplitOptions.None);
                foreach (string str in strAry)
                {
                    if (str.Contains("Tizen."))
                    {
                        returnValue = str.Substring(6, str.Length - 12); //remove Tizen. and .Tests
                        // LogUtils.Write(LogUtils.ERROR, LogUtils.TAG, "check : "+ returnValue);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                TLogger.WriteError(e.Message + e.ToString() + ". Please edit packageId as per guideline");
            }

            return returnValue;
        }

        /// <summary>
        /// Execute the test suite automatically on the Tizen devidce
        /// </summary>
        public void LoadTestsuite()
        {
            Tizen.Log.Fatal("NUITEST", $"");
            Tizen.Log.Fatal("NUITEST", $"LoadTestsuite()");
            TSettings.CurTCIndex = 0;
            string cache_path = Tizen.Applications.Application.Current.DirectoryInfo.Cache;
            string dllPath = cache_path.Replace("cache", "bin");
            string pkgName = GetPackageName(dllPath);
            if (pkgName == "")
            {
                Tizen.Log.Fatal("NUITEST", $"The package name is invalid!");
                TLogger.WriteError("The package name is invalid!");
                return;
            }

            //TLogger.Write("Executing the application: " + pkgName + "...");
            Tizen.Log.Fatal("NUITEST", $"Executing the application: {pkgName}");

            string exeFilePathName = string.Format(dllPath + "Tizen.{0}.Tests.exe", pkgName);
            //TLogger.Write("exeFilePathName : " + exeFilePathName);
            Tizen.Log.Fatal("NUITEST", $"exeFilePathName : {exeFilePathName}");

            AssemblyName asmName = new AssemblyName(GetAssemblyName(exeFilePathName));
            _testAssembly = Assembly.Load(asmName);

            string pkgShareDir = string.Format("/home/owner/share/{0}", pkgName);
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(pkgShareDir);
            if (di.Exists == false)
            {
                di.Create();
            }

            string outputFilePathName = string.Format("{0}/{1}.xml", pkgShareDir, TESTCASE_XML_NAME);
            
            TSettings.GetInstance().SetOutputFilePathName(outputFilePathName);
            string[] s = new string[1] { exeFilePathName };

            Tizen.Log.Fatal("NUITEST", $"outputFilePathName : {outputFilePathName}");
            
            //new TextRunner(_testAssembly).Execute(s);
            LoadTestsuite(s, outputFilePathName);
        }

        /// <summary>
        /// Execute the test suite automatically on the Tizen devidce
        /// </summary>
        public void LoadTestsuite(string dllPath, string pkgName)
        {
            TSettings.CurTCIndex = 0;
            if (pkgName == "")
            {
                TLogger.Write("The package name is invalid!");
                return;
            }
            TLogger.Write("Executing the application: " + pkgName + "...");


            string exeFilePathName = string.Format(dllPath + "Tizen.{0}.Tests.exe", pkgName);

            AssemblyName asmName = new AssemblyName(GetAssemblyName(exeFilePathName));
            _testAssembly = Assembly.Load(asmName);

            string pkgShareDir = string.Format("/home/owner/share/{0}", pkgName);
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(pkgShareDir);
            if (di.Exists == false)
            {
                di.Create();
            }

            string outputFilePathName = string.Format("{0}/{1}.xml", pkgShareDir, TESTCASE_XML_NAME);
            TSettings.GetInstance().SetOutputFilePathName(outputFilePathName);
            string[] s = new string[1] { exeFilePathName };
            //new TextRunner(_testAssembly).Execute(s);
            LoadTestsuite(s, outputFilePathName);
        }

        /// <summary>
        /// Execute the tests in the assembly, passing in
        /// a list of arguments.
        /// </summary>
        /// <param name="args">arguments for NUnitLite to use</param>
        public void Execute()
        {
#if TIZEN
            #region tronghieu.d - Create new thread to run test and mainthread waiting for invoke test method.
            TAsyncThreadMgr asyncThreadMgr = TAsyncThreadMgr.GetInstance();
            ManualResetEvent methodExecutionResetEvent = asyncThreadMgr.GetMethodExecutionResetEvent();
            methodExecutionResetEvent.Reset();

            Task t = Task.Run(() =>
                {
                    _textRunner.Execute(args);
                    asyncThreadMgr.SetData(null, null, null, null, false);
                    methodExecutionResetEvent.Set();
                });
            t.GetAwaiter().OnCompleted(() =>
                {
                    OnSingleTestDone(TSettings.GetInstance().GetSingleTestDoneEventArgs());
                });
            methodExecutionResetEvent.WaitOne();
            asyncThreadMgr.RunTestMethod();
            #endregion
#else
            new TextRunner(_testAssembly).Execute(args);
#endif
        }

        private string GetAssemblyName(string assemblyFullPath)
        {

            string[] delimiter1 = { "\\" };
            string[] delimiter2 = { "/" };
            string[] delimiterDot = { "." };
            string[] delimiterExe = { ".exe" };
            string[] strAry;
            string returnValue = "";
            try
            {
                strAry = assemblyFullPath.Split(delimiter1, StringSplitOptions.None);

                if (strAry.Length < 2)
                    strAry = assemblyFullPath.Split(delimiter2, StringSplitOptions.None);

                foreach (string str in strAry)
                {
                    if (str.Contains(".Tests.dll"))
                    {
                        string[] strSplit = str.Split(delimiterDot, StringSplitOptions.None);
                        returnValue = strSplit[0];
                        //LogUtils.Write(LogUtils.ERROR, LogUtils.TAG, "check : "+ returnValue);
                        break;
                    }
                    if (str.Contains(".exe"))
                    {
                        string[] strSplit = str.Split(delimiterExe, StringSplitOptions.None);
                        returnValue = strSplit[0];
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                TLogger.WriteError(TLogger.ExceptionTag , e.Message + e.ToString() + ". Please edit packageId as per guideline");
            }

            return returnValue;
        }

        public void LoadTestsuite(string[] args, string tcListPath = "")
        {
            this.args = args;
            _textRunner = new TextRunner(_testAssembly);
#if TIZEN
            _textRunner.LoadTest(args);
            //WriteTestList(tcListPath);
#endif
        }
#if TIZEN
        public Dictionary<string, ITest> GetTestList()
        {
            return _textRunner.TestcaseList;
        }

        public void WriteTestList(string path)
        {
            LogUtils.Write(LogUtils.INFO, LogUtils.TAG, "In WriteTestList");
            XMLUtils xmlUtils = new XMLUtils();
            TestcaseEnvironment testEnv = new TestcaseEnvironment();
            testEnv.build_id = "test";
            testEnv.device_id = "csharp_device";
            testEnv.device_model = "";
            testEnv.device_name = "N/A";
            testEnv.host = "N/A";
            testEnv.resolution = "N/A";

            List<TestcaseData> tcList = new List<TestcaseData>();

            foreach (KeyValuePair<string, ITest> pair in _textRunner.TestcaseList)
            {
                TestcaseData testData = new TestcaseData();
                testData.id = pair.Key;
                if (pkgName.Contains("manual"))
                    testData.execution_type = "manual";
                else
                    testData.execution_type = "auto";
                tcList.Add(testData);
            }

            try
            {
                xmlUtils.writeResult("", path, testEnv, tcList);
            }
            catch (Exception e)
            {
                TLogger.WriteError(TLogger.ExceptionTag, e.Message + e.ToString());
                LogUtils.Write(LogUtils.ERROR, LogUtils.TAG, e.Message + e.ToString());
            }
        }

#endif
    }
}
