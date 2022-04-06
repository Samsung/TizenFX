// ***********************************************************************
// Copyright (c) 2012 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************
#define PORTABLE
#define TIZEN
#define NUNIT_FRAMEWORK
#define NUNITLITE
#define NET_4_5
#define PARALLEL
using System;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
using NUnit.Compatibility;
using NUnit.Framework.Internal.Commands;
using NUnit.Framework.Interfaces;
using NUnit.Framework.TUnit;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace NUnit.Framework.Internal.Execution
{
    /// <summary>
    /// A CompositeWorkItem represents a test suite and
    /// encapsulates the execution of the suite as well
    /// as all its child tests.
    /// </summary>
    public class CompositeWorkItem : WorkItem
    {
        //        static Logger log = InternalTrace.GetLogger("CompositeWorkItem");

        private TestSuite _suite;
        private TestSuiteResult _suiteResult;
        private ITestFilter _childFilter;
        private TestCommand _setupCommand;
        private TestCommand _teardownCommand;
        private List<WorkItem> _children;
        private TSettings tsettings;

        /// <summary>
        /// List of Child WorkItems
        /// </summary>
        public List<WorkItem> Children
        {
            get { return _children; }
            private set { _children = value; }
        }

        /// <summary>
        /// A count of how many tests in the work item have a value for the Order Property
        /// </summary>
        private int _countOrder;

        private CountdownEvent _childTestCountdown;

        /// <summary>
        /// Construct a CompositeWorkItem for executing a test suite
        /// using a filter to select child tests.
        /// </summary>
        /// <param name="suite">The TestSuite to be executed</param>
        /// <param name="childFilter">A filter used to select child tests</param>
        public CompositeWorkItem(TestSuite suite, ITestFilter childFilter)
            : base(suite)
        {
            _suite = suite;
            _suiteResult = Result as TestSuiteResult;
            _childFilter = childFilter;
            _countOrder = 0;
            tsettings = TSettings.GetInstance();
        }

        /// <summary>
        /// Method that actually performs the work. Overridden
        /// in CompositeWorkItem to do setup, run all child
        /// items and then do teardown.
        /// </summary>
        protected override void PerformWork()
        {
            // Inititialize actions, setup and teardown
            // We can't do this in the constructor because
            // the context is not available at that point.
            InitializeSetUpAndTearDownCommands();

            if (!CheckForCancellation())
                // [tronghieu.d] - Add more conditions for check slave mode
                if (Test.TestType.Equals("Assembly") || !tsettings.IsSlaveMode || tsettings.Testcase_ID.Contains(Test.FullName))
                    // [tronghieu.d] - end
                    if (Test.RunState == RunState.Explicit && !_childFilter.IsExplicitMatch(Test))
                        SkipFixture(ResultState.Explicit, GetSkipReason(), null);
                    else
                        switch (Test.RunState)
                        {
                            default:
                            case RunState.Runnable:
                            case RunState.Explicit:
                                // Assume success, since the result will be inconclusive
                                // if there is no setup method to run or if the
                                // context initialization fails.
                                Result.SetResult(ResultState.Success);

                                if (_children == null)
                                    CreateChildWorkItems();

                                if (_children.Count > 0)
                                {
                                    PerformOneTimeSetUp();

                                    if (!CheckForCancellation())
                                        switch (Result.ResultState.Status)
                                        {
                                            case TestStatus.Passed:
                                                RunChildren();
                                                return;
                                            // Just return: completion event will take care
                                            // of TestFixtureTearDown when all tests are done.

                                            case TestStatus.Skipped:
                                            case TestStatus.Inconclusive:
                                            case TestStatus.Failed:
                                                SkipChildren(_suite, Result.ResultState.WithSite(FailureSite.Parent), "OneTimeSetUp: " + Result.Message);
                                                break;
                                        }

                                    // Directly execute the OneTimeFixtureTearDown for tests that
                                    // were skipped, failed or set to inconclusive in one time setup
                                    // unless we are aborting.
                                    if (Context.ExecutionStatus != TestExecutionStatus.AbortRequested)
                                        PerformOneTimeTearDown();
                                }
                                break;

                            case RunState.Skipped:
                                SkipFixture(ResultState.Skipped, GetSkipReason(), null);
                                break;

                            case RunState.Ignored:
                                SkipFixture(ResultState.Ignored, GetSkipReason(), null);
                                break;

                            case RunState.NotRunnable:
                                SkipFixture(ResultState.NotRunnable, GetSkipReason(), GetProviderStackTrace());
                                break;
                        }

            // Fall through in case nothing was run.
            // Otherwise, this is done in the completion event.
            WorkItemComplete();

        }

        #region Helper Methods

        private bool CheckForCancellation()
        {
            if (Context.ExecutionStatus != TestExecutionStatus.Running)
            {
                Result.SetResult(ResultState.Cancelled, "Test cancelled by user");
                return true;
            }

            return false;
        }

        private void InitializeSetUpAndTearDownCommands()
        {
            List<SetUpTearDownItem> setUpTearDownItems = _suite.TypeInfo != null
                ? CommandBuilder.BuildSetUpTearDownList(_suite.TypeInfo.Type, typeof(OneTimeSetUpAttribute), typeof(OneTimeTearDownAttribute))
                : new List<SetUpTearDownItem>();

            var actionItems = new List<TestActionItem>();
            foreach (ITestAction action in Actions)
            {
                // Special handling here for ParameterizedMethodSuite is a bit ugly. However,
                // it is needed because Tests are not supposed to know anything about Action
                // Attributes (or any attribute) and Attributes don't know where they were
                // initially applied unless we tell them.
                //
                // ParameterizedMethodSuites and individual test cases both use the same
                // MethodInfo as a source of attributes. We handle the Test and Default targets
                // in the test case, so we don't want to doubly handle it here.
                bool applyToSuite = (action.Targets & ActionTargets.Suite) == ActionTargets.Suite
                    || action.Targets == ActionTargets.Default && !(Test is ParameterizedMethodSuite);

                bool applyToTest = (action.Targets & ActionTargets.Test) == ActionTargets.Test
                    && !(Test is ParameterizedMethodSuite);

                if (applyToSuite)
                    actionItems.Add(new TestActionItem(action));

                if (applyToTest)
                    Context.UpstreamActions.Add(action);
            }

            _setupCommand = CommandBuilder.MakeOneTimeSetUpCommand(_suite, setUpTearDownItems, actionItems);
            _teardownCommand = CommandBuilder.MakeOneTimeTearDownCommand(_suite, setUpTearDownItems, actionItems);
        }

        private void PerformOneTimeSetUp()
        {
            try
            {
                _setupCommand.Execute(Context);

                // SetUp may have changed some things in the environment
                Context.UpdateContextFromEnvironment();
            }
            catch (Exception ex)
            {
                if (ex is NUnitException || ex is TargetInvocationException)
                    ex = ex.InnerException;

                Result.RecordException(ex, FailureSite.SetUp);
            }
        }

        private void RunChildren()
        {
            int childCount = _children.Count;
            if (childCount == 0)
                throw new InvalidOperationException("RunChildren called but item has no children");

            _childTestCountdown = new CountdownEvent(childCount);

            foreach (WorkItem child in _children)
            {
                if (CheckForCancellation())
                    break;


                #region tronghieu.d - testkit-stub
#if TIZEN
                if (child is CompositeWorkItem || !tsettings.IsManual
                    || child.Test.FullName.Equals(tsettings.Testcase_ID))
#endif
                #endregion
                {
                    if (child is SimpleWorkItem && tsettings.IsSlaveMode && !child.Test.FullName.Equals(tsettings.Testcase_ID)) continue;
                    child.Completed += new EventHandler(OnChildCompleted);
                    if (child.Context == null)
                    {
                        child.InitializeContext(new TestExecutionContext(Context));
                    }
                    Context.Dispatcher.Dispatch(child);
                    childCount--;
                }
            }

            if (childCount > 0)
            {
                while (childCount-- > 0)
                    CountDownChildTest();
            }
        }

        private void CreateChildWorkItems()
        {
            _children = new List<WorkItem>();

            foreach (ITest test in _suite.Tests)
            {
                if (_childFilter.Pass(test))
                {
                    var child = WorkItem.CreateWorkItem(test, _childFilter);
                    child.WorkerId = this.WorkerId;

#if !PORTABLE && !SILVERLIGHT && !NETCF
                    if (child.TargetApartment == ApartmentState.Unknown && TargetApartment != ApartmentState.Unknown)
                        child.TargetApartment = TargetApartment;
#endif

                    if (test.Properties.ContainsKey(PropertyNames.Order))
                    {
                        _children.Insert(0, child);
                        _countOrder++;
                    }
                    else
                    {
                        _children.Add(child);
                    }
                }
            }

            if (_countOrder != 0) SortChildren();
        }

        private class WorkItemOrderComparer : IComparer<WorkItem>
        {
            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
            /// </summary>
            /// <returns>
            /// A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table.Value Meaning Less than zero<paramref name="x"/> is less than <paramref name="y"/>.Zero<paramref name="x"/> equals <paramref name="y"/>.Greater than zero<paramref name="x"/> is greater than <paramref name="y"/>.
            /// </returns>
            /// <param name="x">The first object to compare.</param><param name="y">The second object to compare.</param>
            public int Compare(WorkItem x, WorkItem y)
            {
                var xKey = int.MaxValue;
                var yKey = int.MaxValue;

                if (x.Test.Properties.ContainsKey(PropertyNames.Order))
                    xKey = (int)x.Test.Properties[PropertyNames.Order][0];

                if (y.Test.Properties.ContainsKey(PropertyNames.Order))
                    yKey = (int)y.Test.Properties[PropertyNames.Order][0];

                return xKey.CompareTo(yKey);
            }
        }

        /// <summary>
        /// Sorts tests under this suite.
        /// </summary>
        private void SortChildren()
        {
            _children.Sort(0, _countOrder, new WorkItemOrderComparer());
        }

        private void SkipFixture(ResultState resultState, string message, string stackTrace)
        {
            Result.SetResult(resultState.WithSite(FailureSite.SetUp), message, StackFilter.Filter(stackTrace));
            SkipChildren(_suite, resultState.WithSite(FailureSite.Parent), "OneTimeSetUp: " + message);
        }

        private void SkipChildren(TestSuite suite, ResultState resultState, string message)
        {
            foreach (Test child in suite.Tests)
            {
                if (_childFilter.Pass(child))
                {
                    TestResult childResult = child.MakeTestResult();
                    childResult.SetResult(resultState, message);
                    _suiteResult.AddResult(childResult);
#if TIZEN
                    //[tronghieu.d] - return FAIL TC in case it is skipped.
                    if (tsettings.IsSlaveMode && childResult.FullName.Equals(tsettings.Testcase_ID))
                    {
                        tsettings.TCResult = "FAIL";
                        tsettings.TCMessage = childResult.Message;
                        string json = "case_id=" + tsettings.Testcase_ID + "&result=" + tsettings.TCResult + "&msg=" + tsettings.TCMessage + "\n" + childResult.StackTrace;
                        if (!tsettings.IsManual)
                        {
                            tsettings.RequestPOST("commit_result", json);
                            tsettings.NextStepRequest();
                        }
                        else
                            tsettings.RequestPOST("commit_manual_result", json);
                    }
#endif
                    // Some runners may depend on getting the TestFinished event
                    // even for tests that have been skipped at a higher level.
                    Context.Listener.TestFinished(childResult);

                    if (child.IsSuite)
                        SkipChildren((TestSuite)child, resultState, message);
                }
            }
        }

        private void PerformOneTimeTearDown()
        {
            // Our child tests or even unrelated tests may have
            // executed on the same thread since the time that
            // this test started, so we have to re-establish
            // the proper execution environment
            this.Context.EstablishExecutionEnvironment();
            _teardownCommand.Execute(this.Context);
        }

        private string GetSkipReason()
        {
            return (string)Test.Properties.Get(PropertyNames.SkipReason);
        }

        private string GetProviderStackTrace()
        {
            return (string)Test.Properties.Get(PropertyNames.ProviderStackTrace);
        }

        private object _completionLock = new object();

        private void OnChildCompleted(object sender, EventArgs e)
        {
            lock (_completionLock)
            {
                WorkItem childTask = sender as WorkItem;
                if (childTask != null)
                {
                    childTask.Completed -= new EventHandler(OnChildCompleted);
#if !TIZEN
                    _suiteResult.AddResult(childTask.Result);
#else
                    #region tronghieu.d - testkit-stub
                    if (!tsettings.IsSlaveMode && !tsettings.IsManual)
                        _suiteResult.AddResult(childTask.Result);
                    else
                    {
                        if (!_suiteResult.HasChildren)
                            _suiteResult.AddResult(childTask.Result);
                        else
                        {
                            ITestResult[] children;
#if PARALLEL
                            var childrenAsConcurrentQueue = _suiteResult.Children as ConcurrentQueue<ITestResult>;
                            if (childrenAsConcurrentQueue != null)
                                children = childrenAsConcurrentQueue.ToArray();
                            else
#endif
                            {
                                var childrenAsIList = Children as IList<ITestResult>;
                                if (childrenAsIList != null)
                                    children = (ITestResult[])childrenAsIList;
                                else
                                    throw new NotSupportedException("cannot add results to Children");

                            }
                            bool exist = false;
                            for (int i = 0; i < children.Length; i++)
                            {
                                if (children[i].FullName.Equals(childTask.Result.FullName))
                                {
                                    exist = true;
                                    break;
                                }
                            }
                            if (!exist)
                                _suiteResult.AddResult(childTask.Result);
                        }
                        if (childTask is SimpleWorkItem)
                        {
                            string result = childTask.Result.ResultState.Status.ToString();
                            if (tsettings.IsManual && tsettings.TCResult.Length != 0)
                            {

                            }
                            else
                            {
                                result = result.Substring(0, result.Length - 2);
                                tsettings.TCResult = result.ToUpper();
                            }
                            tsettings.Testcase_ID = childTask.Result.FullName;
                            tsettings.TCMessage = childTask.Result.Message;
                            TLogger.Write("##### Result of [" + tsettings.Testcase_ID + "] TC : " + tsettings.TCResult + " With Message: " + tsettings.TCMessage);

                            if (tsettings.IsSlaveMode)
                            {
                                string json = "case_id=" + tsettings.Testcase_ID + "&result=" + tsettings.TCResult + "&msg=" + tsettings.TCMessage + "\n" + childTask.Result.StackTrace;
                                if (!tsettings.IsManual)
                                {
                                    tsettings.RequestPOST("commit_result", json);
                                    tsettings.NextStepRequest();
                                }
                                else
                                    tsettings.RequestPOST("commit_manual_result", json);
                            }
                        }
                    }
                    #endregion
#endif

                    if (Context.StopOnError && childTask.Result.ResultState.Status == TestStatus.Failed)
                        Context.ExecutionStatus = TestExecutionStatus.StopRequested;

                    // Check to see if all children completed
                    CountDownChildTest();
                }
            }
        }

        private void CountDownChildTest()
        {
            _childTestCountdown.Signal();
            if (_childTestCountdown.CurrentCount == 0)
            {
                if (Context.ExecutionStatus != TestExecutionStatus.AbortRequested)
                    PerformOneTimeTearDown();

                foreach (var childResult in _suiteResult.Children)
                    if (childResult.ResultState == ResultState.Cancelled)
                    {
                        this.Result.SetResult(ResultState.Cancelled, "Cancelled by user");
                        break;
                    }
                WorkItemComplete();
            }
        }

        private static bool IsStaticClass(Type type)
        {
            return type.GetTypeInfo().IsAbstract && type.GetTypeInfo().IsSealed;
        }

        private object cancelLock = new object();

        /// <summary>
        /// Cancel (abort or stop) a CompositeWorkItem and all of its children
        /// </summary>
        /// <param name="force">true if the CompositeWorkItem and all of its children should be aborted, false if it should allow all currently running tests to complete</param>
        public override void Cancel(bool force)
        {
            lock (cancelLock)
            {
                if (_children == null)
                    return;

                foreach (var child in _children)
                {
                    var ctx = child.Context;
                    if (ctx != null)
                        ctx.ExecutionStatus = force ? TestExecutionStatus.AbortRequested : TestExecutionStatus.StopRequested;

                    if (child.State == WorkItemState.Running)
                        child.Cancel(force);
                }
            }
        }

        private string GetCaseID(string TCID)
        {
            string[] delimiter = { "." };
            string[] stringPieces;
            string ClassName = "";
            string MethodName = "";
            stringPieces = TCID.Split(delimiter, StringSplitOptions.None);
            for (int i = 0; i < stringPieces.Length; i++)
            {
                if (i == stringPieces.Length - 1)
                    MethodName = stringPieces[i];
                else if (i == stringPieces.Length - 2)
                    ClassName = stringPieces[i];
            }

            return ClassName + "." + MethodName;
        }

        #endregion
    }
}
