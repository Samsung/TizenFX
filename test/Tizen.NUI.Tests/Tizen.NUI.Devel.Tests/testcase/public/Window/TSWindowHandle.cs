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
    [Description("public/Window/WindowHandle")]
     class PublicWindowHandleTest 
     {
        private const string tag = "NUITEST";

        internal class SafeNativeWindowHandleImpl : SafeNativeWindowHandle
        {
            public SafeNativeWindowHandleImpl(Window win) : base(win)
            {  }

            public bool OnReleaseHandle()
            {
                return base.ReleaseHandle();
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
        [Description("SafeNativeWindowHandle constructor.")]
        [Property("SPEC", "Tizen.NUI.SafeNativeWindowHandle.SafeNativeWindowHandle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SafeNativeWindowHandleConstructor()
        {
            tlog.Debug(tag, $"PropertyNotifySignalConstructor START");

            var testingTarget = new SafeNativeWindowHandle(Window.Instance);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<SafeNativeWindowHandle>(testingTarget, "Should be an Instance of SafeNativeWindowHandle!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SafeNativeWindowHandle END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("SafeNativeWindowHandle IsInvalid.")]
        [Property("SPEC", "Tizen.NUI.SafeNativeWindowHandle.SafeNativeWindowHandle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SafeNativeWindowHandleIsInvalid()
        {
            tlog.Debug(tag, $"PropertyNotifySignalConstructor START");
            
            var testingTarget = new SafeNativeWindowHandle(Window.Instance);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<SafeNativeWindowHandle>(testingTarget, "Should be an Instance of SafeNativeWindowHandle!");

            var result = testingTarget.IsInvalid;
            tlog.Debug(tag, "IsInvalid : " + result);
			
            testingTarget.Dispose();
            tlog.Debug(tag, $"SafeNativeWindowHandle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SafeNativeWindowHandle ReleaseHandle.")]
        [Property("SPEC", "Tizen.NUI.SafeNativeWindowHandle.ReleaseHandle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SafeNativeWindowHandleReleaseHandle()
        {
            tlog.Debug(tag, $"SafeNativeWindowHandleReleaseHandle START");

            using (Rectangle rec = new Rectangle(0, 0, Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height))
            {
                Window win = new Window(rec);
                win.BackgroundColor = Color.Cyan;
                win.Raise();

                var testingTarget = new SafeNativeWindowHandleImpl(win);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<SafeNativeWindowHandleImpl>(testingTarget, "Should be an Instance of SafeNativeWindowHandleImpl!");

                var result = testingTarget.OnReleaseHandle();
                tlog.Debug(tag, "ReleaseHandle : " + result);

                win.Dispose();
                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"SafeNativeWindowHandleReleaseHandle END (OK)");
        }
    }
}