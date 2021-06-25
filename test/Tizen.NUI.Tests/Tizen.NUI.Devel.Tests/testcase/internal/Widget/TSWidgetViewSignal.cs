using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Widget/WidgetViewSignal")]
    public class WidgetViewSignalTests
    {
        private const string tag = "NUITEST";
        private delegate void SignalCallback();

        private static void MyDelegate()
        {
            Log.Fatal("TCT", "[TestCase][AddIdle][NUIApplication] Pass");
        }

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetViewSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.WidgetViewSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewSignalConstructor()
        {
            tlog.Debug(tag, $"WidgetViewSignalConstructor START");

            var testingTarget = new WidgetViewSignal() ;
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WidgetViewSignal>(testingTarget, "Should be an Instance of WidgetViewSignal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetViewSignal Dispose.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewSignalDispose()
        {
            tlog.Debug(tag, $"WidgetViewSignalDispose START");

            var testingTarget = new WidgetViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WidgetViewSignal>(testingTarget, "Should be an Instance of WidgetViewSignal!");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewSignalDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetViewSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewSignalEmpty()
        {
            tlog.Debug(tag, $"WidgetViewSignalEmpty START");

            var testingTarget = new WidgetViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WidgetViewSignal>(testingTarget, "Should be an Instance of WidgetViewSignal!");

            Assert.IsTrue(testingTarget.Empty(), "Should be true here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetViewSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"WidgetViewSignalGetConnectionCount START");

            var testingTarget = new WidgetViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WidgetViewSignal>(testingTarget, "Should be an Instance of WidgetViewSignal!");

            Assert.AreEqual(0, testingTarget.GetConnectionCount(), "Should be zero here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetViewSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewSignalConnect()
        {
            tlog.Debug(tag, $"WidgetViewSignalConnect START");

            var testingTarget = new WidgetViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WidgetViewSignal>(testingTarget, "Should be an Instance of WidgetViewSignal!");

            try
            {
                SignalCallback signalCallback = new SignalCallback(MyDelegate);
                testingTarget.Connect(signalCallback);
                Assert.AreEqual(1, testingTarget.GetConnectionCount(), "Should be one here!");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewSignalConnect END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("WidgetViewSignal Connect. With null.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewSignalConnectWithNull()
        {
            tlog.Debug(tag, $"WidgetViewSignalConnectWithNull START");

            var testingTarget = new WidgetViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WidgetViewSignal>(testingTarget, "Should be an Instance of WidgetViewSignal!");

            try
            {
                testingTarget.Connect(null);
                Assert.Fail("Should throw the ArgumentNullException!");
            }
            catch (ArgumentNullException e)
            {
                Assert.True(true);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewSignalConnectWithNull END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetViewSignal Disconnect")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.Disconnect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewSignalDisconnect()
        {
            tlog.Debug(tag, $"WidgetViewSignalDisconnect START");

            var testingTarget = new WidgetViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WidgetViewSignal>(testingTarget, "Should be an Instance of WidgetViewSignal!");

            SignalCallback signalCallback = new SignalCallback(MyDelegate);

            try
            {
                testingTarget.Connect(signalCallback);
                Assert.AreEqual(1, testingTarget.GetConnectionCount(), "Should be one here!");
                
                testingTarget.Disconnect(signalCallback);
                Assert.AreEqual(0, testingTarget.GetConnectionCount(), "Should be zero here!");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewSignalDisconnect END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("WidgetViewSignal Disconnect. With null.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.Disconnect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewSignalDisconnectWithNull()
        {
            tlog.Debug(tag, $"WidgetViewSignalDisconnect START");

            var testingTarget = new WidgetViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WidgetViewSignal>(testingTarget, "Should be an Instance of WidgetViewSignal!");

            try
            {
                testingTarget.Disconnect(null);
                Assert.Fail("Should throw the ArgumentNullException!");
            }
            catch (ArgumentNullException e)
            {
                Assert.True(true);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewSignalDisconnect END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("WidgetViewSignal Emit. With null.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewSignalEmitWithNull()
        {
            tlog.Debug(tag, $"WidgetViewSignalEmitWithNull START");

            var testingTarget = new WidgetViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WidgetViewSignal>(testingTarget, "Should be an Instance of WidgetViewSignal!");
            
            try
            {
                testingTarget.Emit(null);
                Assert.Fail("Should throw the ArgumentNullException!");
            }
            catch (ArgumentNullException e)
            {
                Assert.True(true);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewSignalEmitWithNull END (OK)");
        }
    }

}
