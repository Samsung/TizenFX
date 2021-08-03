using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Globalization;
using System.Resources;
using Tizen.Applications;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Application/NUIApplication")]
    class PublicNUIApplicationTest
    {
        private const string tag = "NUITEST";
        private delegate bool dummyCallback(IntPtr NUIApplication);
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

        [Test]
        [Category("P1")]
        [Description("NUIApplication constructor.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.NUIApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationConstructor()
        {
            tlog.Debug(tag, $"NUIApplicationConstructor START");

            var testingTarget = new NUIApplication();
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIApplication>(testingTarget, "Should be an instance of NUIApplication type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIApplicationConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication constructor. With window size and position")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.NUIApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationConstructorWithWindowSizeAndPosition()
        {
            tlog.Debug(tag, $"NUIApplicationConstructorWithWindowSizeAndPosition START");

            Size size = new Size(100, 200);
            Position pos = new Position(200, 300);
            var testingTarget = new NUIApplication(size, pos);
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIApplication>(testingTarget, "Should be an instance of NUIApplication type.");

            pos.Dispose();
            size.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIApplicationConstructorWithWindowSizeAndPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication constructor. With stylesheet.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.NUIApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationConstructorWithStyleSheet()
        {
            tlog.Debug(tag, $"NUIApplicationConstructorWithStyleSheet START");

            var testingTarget = new NUIApplication("stylesheet");
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIApplication>(testingTarget, "Should be an instance of NUIApplication type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIApplicationConstructorWithStyleSheet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication constructor. With stylesheet, window size, position.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.NUIApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationConstructorWithStyleSheetAndWindowSizeAndPostion()
        {
            tlog.Debug(tag, $"NUIApplicationConstructorWithStyleSheetAndWindowSizeAndPostion START");

            var testingTarget = new NUIApplication("stylesheet", new Size(100, 200), new Position(200, 300));
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIApplication>(testingTarget, "Should be an instance of NUIApplication type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIApplicationConstructorWithStyleSheetAndWindowSizeAndPostion END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication constructor. With stylesheet and WindowMode.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.NUIApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationConstructorWithStringAndWindowMode()
        {
            tlog.Debug(tag, $"NUIApplicationConstructorWithStringAndWindowMode START");

            var testingTarget = new NUIApplication("stylesheet", NUIApplication.WindowMode.Opaque);
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsNotNull(testingTarget, "NUIApplication Should return NUIApplication instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIApplicationConstructorWithStringAndWindowMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication constructor. With stylesheet, WindowMode, window size and position")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.NUIApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationConstructorWithStringAndWindowModeAndWindowSizeAndPosition()
        {
            tlog.Debug(tag, $"NUIApplicationConstructorWithStringAndWindowModeAndWindowSizeAndPosition START");

            var testingTarget = new NUIApplication("stylesheet", NUIApplication.WindowMode.Opaque, new Size(100, 200), new Position(200, 300));
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsNotNull(testingTarget, "NUIApplication Should return NUIApplication instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIApplicationConstructorWithStringAndWindowModeAndWindowSizeAndPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("dali NUIApplication constructor test for IME Window type. Check whether object which set WindowType with IME is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.NUIApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "string,WindowMode,WindowType")]
        [Property("AUTHOR", "Wonsik Jung, sidein@samsung.com")]
        public void NUIApplication_INIT_WITH_STRING_WINDOWMODE_IMEWINDOWTYPE()
        {
            /* TEST CODE */
            var application = new NUIApplication("stylesheet", NUIApplication.WindowMode.Opaque, NUIApplication.WindowType.Ime);
            Assert.IsNotNull(application, "NUIApplication Should return NUIApplication instance.");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication RegisterAssembly.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.RegisterAssembly M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationRegisterAssembly()
        {
            tlog.Debug(tag, $"NUIApplicationRegisterAssembly START");

            try
            {
                NUIApplication.RegisterAssembly(typeof(NUIApplication).Assembly);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"NUIApplicationRegisterAssembly END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication MultilingualResourceManager.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.MultilingualResourceManager A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationMultilingualResourceManager()
        {
            tlog.Debug(tag, $"NUIApplicationMultilingualResourceManager START");

            NUIApplication.MultilingualResourceManager = Resource.ResourceManager;
            Assert.IsNotNull(NUIApplication.MultilingualResourceManager, "Should be not null!");

            string str = null;
            str = NUIApplication.MultilingualResourceManager?.GetString("Test");
            Assert.AreEqual("Test", str, "Picture should be Beeld in Dutch");

            tlog.Debug(tag, $"NUIApplicationMultilingualResourceManager END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication AppId")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.AppId A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationAppId()
        {
            tlog.Debug(tag, $"NUIApplicationAppId START");

            var testingTarget = new NUIApplication();
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIApplication>(testingTarget, "Should be an instance of NUIApplication type.");

            var result = testingTarget.AppId;
            Assert.IsNotNull(result, "Should be not null.");

            tlog.Debug(tag, $"NUIApplicationAppId END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication GetDefaultWindow")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.GetDefaultWindow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationGetDefaultWindow()
        {
            tlog.Debug(tag, $"NUIApplicationGetDefaultWindow START");

            var testingTarget = NUIApplication.GetDefaultWindow();
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<Window>(testingTarget, "Should be an instance of Window type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIApplicationGetDefaultWindow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication AddIdle")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.AddIdle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationAddIdle()
        {
            tlog.Debug(tag, $"NUIApplicationAddIdle START");

            dummyCallback callback = OnDummyCallback;
            var result = Application.Instance.AddIdle(callback);
            Assert.IsTrue(result);

            tlog.Debug(tag, $"NUIApplicationAddIdle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication SetRenderRefreshRate")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.SetRenderRefreshRate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationSetRenderRefreshRate()
        {
            tlog.Debug(tag, $"NUIApplicationSetRenderRefreshRate START");

            try
            {
                NUIApplication.SetRenderRefreshRate(2);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"NUIApplicationSetRenderRefreshRate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication TransitionOptions")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.TransitionOptions A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationTransitionOptions()
        {
            tlog.Debug(tag, $"NUIApplicationTransitionOptions START");

            var testingTarget = new NUIApplication();
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIApplication>(testingTarget, "Should be an instance of Window type.");

            TransitionOptions transitionOption = new TransitionOptions(Window.Instance);
            testingTarget.TransitionOptions = transitionOption;

            var result = testingTarget.TransitionOptions;
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<TransitionOptions>(result, "Should be an instance of TransitionOptions type.");

            result.Dispose();
            transitionOption.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIApplicationTransitionOptions END (OK)");
        }
    }
}
