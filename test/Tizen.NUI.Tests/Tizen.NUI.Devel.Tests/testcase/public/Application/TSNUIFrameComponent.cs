using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Application/NUIFrameComponent")]
    class PublicNUIFrameComponentTest
    {
        private const string tag = "NUITEST";

        internal class MyNUIFrameComponent : NUIFrameComponent
        {
            public MyNUIFrameComponent() : base()
            { }

            public void MyOnCreate()
            {
                base.OnCreate();
            }

            public void MyOnStart(Tizen.Applications.AppControl appControl, bool restarted)
            {
                base.OnStart(appControl, restarted);
            }

            public void MyOnResume()
            {
                base.OnResume();
            }

            public void MyOnPause()
            {
                base.OnPause();
            }

            public void MyOnStop()
            {
                base.OnStop();
            }

            public void MyOnDestroy()
            {
                base.OnDestroy();
            }
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

        [Test]
        [Category("P1")]
        [Description("NUIFrameComponent NUIWindowInfo")]
        [Property("SPEC", "Tizen.NUI.NUIFrameComponent.NUIWindowInfo A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIFrameComponentNUIWindowInfo()
        {
            tlog.Debug(tag, $"NUIFrameComponentNUIWindowInfo START");

            var testingTarget = new NUIFrameComponent();
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIFrameComponent>(testingTarget, "Should be an instance of NUIFrameComponent type.");

            testingTarget.NUIWindowInfo = new NUIWindowInfo(Window.Instance);
            tlog.Debug(tag, "testingTarget.NUIWindowInfo : " + testingTarget.NUIWindowInfo);
            Assert.IsNotNull(testingTarget.NUIWindowInfo);

            tlog.Debug(tag, $"NUIFrameComponentNUIWindowInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIFrameComponent Window")]
        [Property("SPEC", "Tizen.NUI.NUIFrameComponent.Window A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIFrameComponentWindow()
        {
            tlog.Debug(tag, $"NUIFrameComponentWindow START");

            var testingTarget = new NUIFrameComponent();
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIFrameComponent>(testingTarget, "Should be an instance of NUIFrameComponent type.");

            try
            {
                testingTarget.Window = NUIApplication.GetDefaultWindow();
                tlog.Debug(tag, "Window :" + testingTarget.Window);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"NUIFrameComponentWindow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIFrameComponent OnCreate.")]
        [Property("SPEC", "Tizen.NUI.NUIFrameComponent.OnCreate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIFrameComponentOnCreate()
        {
            tlog.Debug(tag, $"NUIFrameComponentOnCreate START");

            var testingTarget = new MyNUIFrameComponent();
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIFrameComponent>(testingTarget, "Should be an instance of NUIFrameComponent type.");

            try
            {
                testingTarget.MyOnCreate();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"NUIFrameComponentOnCreate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIFrameComponent OnStart.")]
        [Property("SPEC", "Tizen.NUI.NUIFrameComponent.OnStart M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIFrameComponentOnStart()
        {
            tlog.Debug(tag, $"NUIFrameComponentOnStart START");

            var testingTarget = new MyNUIFrameComponent();
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIFrameComponent>(testingTarget, "Should be an instance of NUIFrameComponent type.");

            try
            {
                Tizen.Applications.AppControl appControl = new Tizen.Applications.AppControl(true);
                testingTarget.MyOnStart(appControl, false);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"NUIFrameComponentOnStart END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIFrameComponent OnResume.")]
        [Property("SPEC", "Tizen.NUI.NUIFrameComponent.OnResume M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIFrameComponentOnResume()
        {
            tlog.Debug(tag, $"NUIFrameComponentOnResume START");

            var testingTarget = new MyNUIFrameComponent();
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIFrameComponent>(testingTarget, "Should be an instance of NUIFrameComponent type.");

            try
            {
                testingTarget.MyOnResume();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"NUIFrameComponentOnResume END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIFrameComponent OnPause.")]
        [Property("SPEC", "Tizen.NUI.NUIFrameComponent.OnPause M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIFrameComponentOnPause()
        {
            tlog.Debug(tag, $"NUIFrameComponentOnPause START");

            var testingTarget = new MyNUIFrameComponent();
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIFrameComponent>(testingTarget, "Should be an instance of NUIFrameComponent type.");

            try
            {
                testingTarget.MyOnPause();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"NUIFrameComponentOnPause END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIFrameComponent OnStop.")]
        [Property("SPEC", "Tizen.NUI.NUIFrameComponent.OnStop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIFrameComponentOnStop()
        {
            tlog.Debug(tag, $"NUIFrameComponentOnStop START");

            var testingTarget = new MyNUIFrameComponent();
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIFrameComponent>(testingTarget, "Should be an instance of NUIFrameComponent type.");

            try
            {
                testingTarget.MyOnStop();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"NUIFrameComponentOnStop END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIFrameComponent OnDestroy.")]
        [Property("SPEC", "Tizen.NUI.NUIFrameComponent.OnDestroy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIFrameComponentOnDestroy()
        {
            tlog.Debug(tag, $"NUIFrameComponentOnDestroy START");

            var testingTarget = new MyNUIFrameComponent();
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIFrameComponent>(testingTarget, "Should be an instance of NUIFrameComponent type.");

            try
            {
                testingTarget.MyOnDestroy();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"NUIFrameComponentOnDestroy END (OK)");
        }
    }
}
