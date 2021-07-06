using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/ConnectionTracker")]
    public class InternalConnectionTrackerTest
    {
        private const string tag = "NUITEST";

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

        [Test]
        [Category("P1")]
        [Description("ConnectionTracker constructor.")]
        [Property("SPEC", "Tizen.NUI.ConnectionTracker.ConnectionTracker C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ConnectionTrackerConstructor()
        {
            tlog.Debug(tag, $"ConnectionTrackerConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ConnectionTracker(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ConnectionTracker>(testingTarget, "Should be an Instance of ConnectionTracker!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ConnectionTrackerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ConnectionTracker GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ConnectionTracker.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ConnectionTrackerGetConnectionCount()
        {
            tlog.Debug(tag, $"ConnectionTrackerGetConnectionCount START");

            using (View view = new View())
            {
                var testingTarget = new ConnectionTracker(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ConnectionTracker>(testingTarget, "Should be an Instance of ConnectionTracker!");

                try
                {
                    testingTarget.GetConnectionCount();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"ConnectionTrackerGetConnectionCount END (OK)");
        }
    }
}
