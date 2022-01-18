using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Application/WatchBoolSignal")]
    public class InternalWatchBoolSignalTest
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
        [Description("WatchBoolSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.WatchBoolSignal.WatchBoolSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchBoolSignalConstructor()
        {
            tlog.Debug(tag, $"WatchBoolSignalConstructor START");

            using (ImageView imageView = new ImageView())
            {
                var testingTarget = new WatchBoolSignal(imageView.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchBoolSignal>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WatchBoolSignalConstructor END (OK)");
        }
    }
}
