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

        internal class MyNUIApplication : NUIApplication
        {
            public MyNUIApplication() : base()
            { }

            public void MyOnTerminate()
            {
                base.OnTerminate();
            }

            public void MyOnLocaleChanged(LocaleChangedEventArgs e)
            {
                base.OnLocaleChanged(e);
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
            Assert.IsInstanceOf<NUIApplication>(testingTarget, "Should be an instance of NUIApplication type.");

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
            Assert.IsInstanceOf<NUIApplication>(testingTarget, "Should be an instance of NUIApplication type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIApplicationConstructorWithStringAndWindowModeAndWindowSizeAndPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication constructor. With BackendType.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.NUIApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationConstructorWithBackendType()
        {
            tlog.Debug(tag, $"NUIApplicationConstructorWithBackendType START");

            var testingTarget = new NUIApplication(Graphics.BackendType.Vulkan);
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIApplication>(testingTarget, "Should be an instance of NUIApplication type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIApplicationConstructorWithBackendType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication constructor. With ThemeOptions.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.NUIApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationConstructorWithThemeOptions()
        {
            tlog.Debug(tag, $"NUIApplicationConstructorWithThemeOptions START");

            var testingTarget = new NUIApplication(NUIApplication.ThemeOptions.PlatformThemeEnabled);
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIApplication>(testingTarget, "Should be an instance of NUIApplication type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIApplicationConstructorWithThemeOptions END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication constructor. With windowSize, windowPosition and options.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.NUIApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationConstructorWithSizePositionAndThemeOptions()
        {
            tlog.Debug(tag, $"NUIApplicationConstructorWithSizePositionAndThemeOptions START");

            Size2D windowSize = new Size2D(100, 50);
            Position2D windowPosition = new Position2D(20, 30);
            var testingTarget = new NUIApplication(windowSize, windowPosition, NUIApplication.ThemeOptions.PlatformThemeEnabled);
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIApplication>(testingTarget, "Should be an instance of NUIApplication type.");

            windowSize.Dispose();
            windowPosition.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIApplicationConstructorWithSizePositionAndThemeOptions END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication constructor. Support IME window.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.NUIApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationConstructorForImeWindow()
        {
            tlog.Debug(tag, $"NUIApplicationConstructorForImeWindow START");

            var application = new NUIApplication("stylesheet", NUIApplication.WindowMode.Opaque, WindowType.Ime);
            Assert.IsNotNull(application, "NUIApplication Should return NUIApplication instance.");
            Assert.IsInstanceOf<NUIApplication>(testingTarget, "Should be an instance of NUIApplication type.");

            windowSize.Dispose();
            windowPosition.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIApplicationConstructorForImeWindow END (OK)");
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

        [Test]
        [Category("P1")]
        [Description("NUIApplication OnTerminate")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.OnTerminate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationOnTerminate()
        {
            tlog.Debug(tag, $"NUIApplicationOnTerminate START");

            var testingTarget = new MyNUIApplication();
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIApplication>(testingTarget, "Should be an instance of Window type.");

            try
            {
                testingTarget.MyOnTerminate();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"NUIApplicationOnTerminate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIApplication OnLocaleChanged")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.OnLocaleChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationOnLocaleChanged()
        {
            tlog.Debug(tag, $"NUIApplicationOnLocaleChanged START");

            var testingTarget = new MyNUIApplication();
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIApplication>(testingTarget, "Should be an instance of Window type.");

            try
            {
                testingTarget.MyOnLocaleChanged(new LocaleChangedEventArgs("Shanghai"));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"NUIApplicationOnTerminate END (OK)");
        }
    }
}
