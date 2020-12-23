// ****************************************************************************************************
// Namespace:       NUnit.Framework.TUnit
// Class:           TTestMethodCommand
// Description:     Tizen TestMethod Command
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
using NUnit.Framework.Interfaces;
using System.Threading;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace NUnit.Framework.TUnit
{
    /// <summary>
    /// TTestMethodCommand is the lowest level concrete command
    /// used to run actual test cases.
    /// </summary>
    public class TTestMethodCommand : TestCommand
    {
        private readonly TestMethod testMethod;
        private readonly object[] arguments;

        /// <summary>
        /// Initializes a new instance of the <see cref="TTestMethodCommand"/> class.
        /// </summary>
        /// <param name="testMethod">The test.</param>
        public TTestMethodCommand(TestMethod testMethod)
            : base(testMethod)
        {
            this.testMethod = testMethod;
            this.arguments = testMethod.Arguments;
        }

        /// <summary>
        /// Runs the test, saving a TestResult in the execution context, as
        /// well as returning it. If the test has an expected result, it
        /// is asserts on that value. Since failed tests and errors throw
        /// an exception, this command must be wrapped in an outer command,
        /// will handle that exception and records the failure. This role
        /// is usually played by the SetUpTearDown command.
        /// </summary>
        /// <param name="context">The execution context</param>
        public override TestResult Execute(TestExecutionContext context)
        {
            // TODO: Decide if we should handle exceptions here
            object result = RunTestMethod(context);

            if (testMethod.HasExpectedResult)
                NUnit.Framework.Assert.AreEqual(testMethod.ExpectedResult, result);

            context.CurrentResult.SetResult(ResultState.Success);
            // TODO: Set assert count here?
            //context.CurrentResult.AssertCount = context.AssertCount;
            return context.CurrentResult;
        }

        private object RunTestMethod(TestExecutionContext context)
        {
            // [DuongNT]: Sleep 50 ms to reduce CPU consumption
            ++TSettings.CurTCIndex;
            if (TSettings.CurTCIndex % 10 == 0)
                Thread.Sleep(2000);
            else
                Thread.Sleep(TSettings.GetInstance().GetDefaultTCDelay());

            TUnit.TLogger.Write("##### Running Test Case [" + TSettings.CurTCIndex + "]: " + testMethod.Method.TypeInfo.FullName + "." +
                testMethod.Method.Name);

#if NET_4_0 || NET_4_5 || PORTABLE
            if (AsyncInvocationRegion.IsAsyncOperation(testMethod.Method.MethodInfo))
                return RunAsyncTestMethod(context);
            else
#endif
                return RunNonAsyncTestMethod(context);
        }

#if NET_4_0 || NET_4_5 || PORTABLE || TIZEN
        private object RunAsyncTestMethod(TestExecutionContext context)
        {
            TLogger.Write("##### RunAsyncTestMethod in TTestMethodCommand class #####");
            #region tronghieu.d - invoke async test method in application thread. This thread is blocked for waiting result.
            using (AsyncInvocationRegion region = AsyncInvocationRegion.Create(testMethod.Method.MethodInfo))
            {
                TAsyncThreadMgr asyncThreadMgr = TAsyncThreadMgr.GetInstance();
                asyncThreadMgr.SetData(this, testMethod, arguments, context, true);
                asyncThreadMgr.GetMethodExecutionResetEvent().Set(); // release main thread to invoke method
                _testMethodRunComplete.WaitOne(); // wait for result in current thread
                if (asyncThreadMgr.GetNonAsyncMethodException() != null)
                    throw asyncThreadMgr.GetNonAsyncMethodException();
                try
                {
                    if (asyncThreadMgr.GetResult() == null)
                    {
                        return asyncThreadMgr.GetResult();
                    }
                    return region.WaitForPendingOperationsToComplete(asyncThreadMgr.GetResult());
                }
                catch (Exception e)
                {
                    throw new NUnitException("Rethrown", e);
                }
            }
            #endregion
        }
#endif

        private object RunNonAsyncTestMethod(TestExecutionContext context)
        {
            TLogger.Write("##### RunNonAsyncTestMethod in TTestMethodCommand class #####");
            #region tronghieu.d - invoke async test method in application thread. This thread is blocked for waiting result.
            TAsyncThreadMgr asyncThreadMgr = TAsyncThreadMgr.GetInstance();
            asyncThreadMgr.SetData(this, testMethod, arguments, context, false);
            asyncThreadMgr.GetMethodExecutionResetEvent().Set(); // release main thread to invoke method
            _testMethodRunComplete.WaitOne(); // wait for result in current thread

            if (asyncThreadMgr.GetNonAsyncMethodException() != null)
                throw asyncThreadMgr.GetNonAsyncMethodException();

            return asyncThreadMgr.GetResult();
            #endregion
            //return testMethod.Method.Invoke(context.TestObject, arguments);
        }
    }
}