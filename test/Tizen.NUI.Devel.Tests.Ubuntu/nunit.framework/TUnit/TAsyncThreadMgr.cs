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
using System.Reflection;
using NUnit.Framework.Internal;
using System.Threading;
using NUnit.Framework.Internal.Commands;

namespace NUnit.Framework.TUnit
{
    #region tronghieu.d - added class
    public class TAsyncThreadMgr
    {
        private static TAsyncThreadMgr _instance;
        private static object lockObject = new object();

        public static TAsyncThreadMgr GetInstance()
        {
            lock (lockObject)
            {
                if (_instance == null)
                {
                    _instance = new TAsyncThreadMgr();
                }
            }
            return _instance;
        }

        private TAsyncThreadMgr()
        {
            this.testCommand = null;
            this.testMethod = null;
            this.arguments = null;
            this.context = null;
        }

        public void SetData(TestCommand testCommand, TestMethod testMethod, object[] arguments, TestExecutionContext context, bool IsAsyncOperation)
        {
            this.testCommand = testCommand;
            this.testMethod = testMethod;
            this.arguments = arguments;
            this.context = context;
            this.IsAsyncOperation = IsAsyncOperation;
            this.exception = null;
        }
        #region nguyen.vtan setData for setup & teardown to run on main thread
        public void SetData(SetUpTearDownItem setupteardownItem)
        {
            this._setupteardownItem.Add(setupteardownItem);
        }
        public void SetTearDownData(SetUpTearDownItem setupteardownItem)
        {
            this._teardownItem.Add(setupteardownItem);
        }
        public void ClearSetUpTearDown()
        {
            _setupteardownItem.Clear();
            _teardownItem.Clear();
        }
        #endregion


        private TestCommand testCommand;
        private TestMethod testMethod;
        private object[] arguments;
        private TestExecutionContext context;
        private bool IsAsyncOperation;
        private object result;
        private Exception exception;
        readonly List<SetUpTearDownItem> _setupteardownItem = new List<SetUpTearDownItem>();
        readonly List<SetUpTearDownItem> _teardownItem = new List<SetUpTearDownItem>();
        //ManualResetEvent _singnalOneTimeTearDown;

        private readonly ManualResetEvent _methodExecutionResetEvent = new ManualResetEvent(false);

        public ManualResetEvent GetMethodExecutionResetEvent()
        {
            return _methodExecutionResetEvent;
        }

        /* Invoke async test method in main thread*/
        public void RunTestMethod()
        {
            if (testCommand == null || testMethod == null || context == null)
            {
                return;
            }
            TLogger.Write("##### RunTestMethod in TAsyncThreadMgr class #####");
            if (IsAsyncOperation)
                RunAsyncTestMethod();
            else
                RunNonAsyncTestMethod();
        }

        public void RunAsyncTestMethod()
        {
            TLogger.Write("##### RunAsyncTestMethod in TAsyncThreadMgr class #####");
            try
            {
                result = null;
                #region nguyen.vtan add Setup
                runSetup();
                #endregion
                result = Reflect.InvokeMethod(testMethod.Method.MethodInfo, context.TestObject, arguments);
            }
            catch (Exception e)
            {
                exception = e;
                // Console.WriteLine(e.Message);
            }
            finally
            {
                if (result == null)
                {
                    #region nguyen.vtan add Setup
                    runTearDown();
                    Thread.Sleep(50);
                    #endregion
                    testCommand._testMethodRunComplete.Set();
                    _methodExecutionResetEvent.Reset();
                    _methodExecutionResetEvent.WaitOne();
                    RunTestMethod();
                }
                else
                {
                    ((Task)result).GetAwaiter().OnCompleted(() =>
                    {
                        #region nguyen.vtan add TearDown
                        runTearDown();
                        Thread.Sleep(50);
                        #endregion
                        testCommand._testMethodRunComplete.Set();
                        _methodExecutionResetEvent.Reset();
                        _methodExecutionResetEvent.WaitOne();
                        RunTestMethod();
                    });
                }
            }
        }

        public void RunNonAsyncTestMethod()
        {
            TLogger.Write("##### RunNonAsyncTestMethod in TAsyncThreadMgr class #####");
            try
            {
                runSetup();
                result = testMethod.Method.Invoke(context.TestObject, arguments);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            #region nguyen.vtan add TearDown
            runTearDown();
            Thread.Sleep(50);
            #endregion
            testCommand._testMethodRunComplete.Set();
            _methodExecutionResetEvent.Reset();
            _methodExecutionResetEvent.WaitOne();
            RunTestMethod();
        }

        public object GetResult()
        {
            return result;
        }

        public Exception GetNonAsyncMethodException()
        {
            return exception;
        }

        #region add by nguyen.vtan rewrite setup & teardown method to run on main thread
        public void runSetup()
        {
            TLogger.Write("##### runSetup in TAsyncThreadMgr class #####");
            foreach (var item in _setupteardownItem)
            {
                if (item?._setUpMethods != null)
                    foreach (MethodInfo setUpMethod in item._setUpMethods)
                    {
                        item.RunSetUpOrTearDownMethod(context, setUpMethod);
                    }
            }
        }
        public void runTearDown()
        {

            TLogger.Write("##### runTearDown in TAsyncThreadMgr class #####");
            if (context?.ExecutionStatus == TestExecutionStatus.AbortRequested)
            {
                return;
            }

            try
            {
                foreach (var item in _teardownItem)
                {
                    // Even though we are only running one level at a time, we
                    // run the teardowns in reverse order to provide consistency.
                    if (item?._tearDownMethods != null)
                    {
                        int index = item._tearDownMethods.Count;
                        while (--index >= 0)
                        {
                            item.RunSetUpOrTearDownMethod(context, item._tearDownMethods[index]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                context.CurrentResult.RecordTearDownException(ex);
            }
        }
        #endregion
    }
    #endregion
}