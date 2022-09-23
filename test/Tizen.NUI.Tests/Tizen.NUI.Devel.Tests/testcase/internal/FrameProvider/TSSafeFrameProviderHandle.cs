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
    [Description("internal/FrameBroker/SafeFrameProviderHandle")]
    public class InternalSafeFrameProviderHandleTest
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
        [Description("SafeFrameProviderHandle constructor.")]
        [Property("SPEC", "Tizen.NUI.SafeFrameProviderHandle.SafeFrameProviderHandle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SafeFrameProviderHandleConstructor()
        {
            tlog.Debug(tag, $"SafeFrameProviderHandleConstructor START");

            using (Animation ani = new Animation(300))
            {
                ani.SetDefaultAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInSquare));

                var testingTarget = new SafeFrameProviderHandle(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object CustomView");
                Assert.IsInstanceOf<SafeFrameProviderHandle>(testingTarget, "Should be an instance of SafeFrameProviderHandle type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"SafeFrameProviderHandleConstructor END (OK)");
        }
    }
}
