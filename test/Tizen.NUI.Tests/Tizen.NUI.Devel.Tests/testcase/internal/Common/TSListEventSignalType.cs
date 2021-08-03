using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ListEventSignalType")]
    public class InternalListEventSignalTypeTest
    {
        private const string tag = "NUITEST";

		private delegate bool dummyCallback(IntPtr signal);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        //[Test]
        //[Category("P1")]
        //[Description("ListEventSignalType constructor.")]
        //[Property("SPEC", "Tizen.NUI.ListEventSignalType.ListEventSignalType C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void ListEventSignalTypeConstructor()
        //{
        //    tlog.Debug(tag, $"ListEventSignalTypeConstructor START");

        //    var testingTarget = new ListEventSignalType();
        //    Assert.IsNotNull(testingTarget, "Should be not null!");
        //    Assert.IsInstanceOf<ListEventSignalType>(testingTarget, "Should be an Instance of ListEventSignalType!");

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"ListEventSignalTypeConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("ListEventSignalType Empty.")]
        //[Property("SPEC", "Tizen.NUI.ListEventSignalType.Empty M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void ListEventSignalTypeEmpty()
        //{
        //    tlog.Debug(tag, $"ListEventSignalTypeEmpty START");

        //    var testingTarget = new ListEventSignalType();
        //    Assert.IsNotNull(testingTarget, "Should be not null!");
        //    Assert.IsInstanceOf<ListEventSignalType>(testingTarget, "Should be an Instance of ListEventSignalType!");

        //    try
        //    {
        //        testingTarget.Empty();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();

        //    tlog.Debug(tag, $"ListEventSignalTypeEmpty END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("ListEventSignalType GetConnectionCount.")]
        //[Property("SPEC", "Tizen.NUI.ListEventSignalType.GetConnectionCount M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void ListEventSignalTypeGetConnectionCount()
        //{
        //    tlog.Debug(tag, $"ListEventSignalTypeGetConnectionCount START");

        //    var testingTarget = new ListEventSignalType();
        //    Assert.IsNotNull(testingTarget, "Should be not null!");
        //    Assert.IsInstanceOf<ListEventSignalType>(testingTarget, "Should be an Instance of ListEventSignalType!");

        //    try
        //    {
        //        testingTarget.GetConnectionCount();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();

        //    tlog.Debug(tag, $"ListEventSignalTypeGetConnectionCount END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("ListEventSignalType Connect.")]
        //[Property("SPEC", "Tizen.NUI.ListEventSignalType.Connect M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void ListEventSignalTypeConnect()
        //{
        //    tlog.Debug(tag, $"ListEventSignalTypeConnect START");

        //    var testingTarget = new ListEventSignalType();
        //    Assert.IsNotNull(testingTarget, "Should be not null!");
        //    Assert.IsInstanceOf<ListEventSignalType>(testingTarget, "Should be an Instance of ListEventSignalType!");

        //    try
        //    {
        //        dummyCallback callback = OnDummyCallback;
        //        testingTarget.Connect(callback);
        //        testingTarget.Disconnect(callback);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();

        //    tlog.Debug(tag, $"ListEventSignalTypeConnect END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("ListEventSignalType Emit.")]
        //[Property("SPEC", "Tizen.NUI.ListEventSignalType.Emit M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void ListEventSignalTypeEmit()
        //{
        //    tlog.Debug(tag, $"ListEventSignalTypeEmit START");
        //    var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
        //    var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

        //    tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

        //    using (View view = new View())
        //    {
        //        var testingTarget = new ListEventSignalType();
        //        Assert.IsNotNull(testingTarget, "Should be not null!");
        //        Assert.IsInstanceOf<ListEventSignalType>(testingTarget, "Should be an Instance of ListEventSignalType!");

        //        try
        //        {
        //            testingTarget.Emit(view);
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"ListEventSignalTypeEmit END (OK)");
        //}
    }
}
