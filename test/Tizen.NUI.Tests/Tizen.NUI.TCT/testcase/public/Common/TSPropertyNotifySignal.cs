using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests.testcase
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/PropertyNotifySignal")]
    class PublicPropertyNotifySignalTest
    {
        private const string tag = "NUITEST";
        private delegate void dummyCallback();
        private void OnDummyCallback()
        { }

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
        [Description("PropertyNotifySignal constructor.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.PropertyNotifySignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotifySignalConstructor()
        {
            tlog.Debug(tag, $"PropertyNotifySignalConstructor START");

            var testingTarget = new PropertyNotifySignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyNotifySignal>(testingTarget, "Should be an Instance of PropertyNotifySignal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyNotifySignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotifySignal Empty")]
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotifySignalEmpty()
        {
            tlog.Debug(tag, $"PropertyNotifySignalEmpty START");

            var testingTarget = new PropertyNotifySignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyNotifySignal>(testingTarget, "Should be an Instance of PropertyNotifySignal!");

            Assert.IsTrue(testingTarget.Empty());

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyNotifySignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotifySignal GetConnectionCount")]
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotifySignalGetConnectionCount()
        {
            tlog.Debug(tag, $"PropertyNotifySignalGetConnectionCount START");

            var testingTarget = new PropertyNotifySignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyNotifySignal>(testingTarget, "Should be an Instance of PropertyNotifySignal!");

            Assert.AreEqual(0, testingTarget.GetConnectionCount(), "Should be zero!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyNotifySignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotifySignal Connect")]
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotifySignalConnect()
        {
            tlog.Debug(tag, $"PropertyNotifySignalConnect START");

            var testingTarget = new PropertyNotifySignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyNotifySignal>(testingTarget, "Should be an Instance of PropertyNotifySignal!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyNotifySignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotifySignal Disconnect")]
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.Disconnect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotifySignalDisconnect()
        {
            tlog.Debug(tag, $"PropertyNotifySignalDisconnect START");

            var testingTarget = new PropertyNotifySignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyNotifySignal>(testingTarget, "Should be an Instance of PropertyNotifySignal!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyNotifySignalDisconnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotifySignal Emit")]
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotifySignalEmit()
        {
            tlog.Debug(tag, $"PropertyNotifySignalEmit START");

            var testingTarget = new PropertyNotifySignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyNotifySignal>(testingTarget, "Should be an Instance of PropertyNotifySignal!");

            View view = new View()
            {
                Size = new Size(200, 200),
                BackgroundColor = Color.Red
            };
            Window.Instance.Add(view);

            var dummy = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(dummy, "Should be not null!");
            Assert.IsInstanceOf<PropertyNotification>(dummy, "Should be an Instance of PropertyNotification!");

            testingTarget.Emit(dummy);

            testingTarget.Dispose();
            dummy.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"PropertyNotifySignalEmit END (OK)");
        }
    }
}
