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
    [Description("internal/FrameBroker/SafeFrameBrokerHandle")]
    public class InternalSafeFrameBrokerHandleTest
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
        [Description("SafeFrameBrokerHandle constructor.")]
        [Property("SPEC", "Tizen.NUI.SafeFrameBrokerHandle.SafeFrameBrokerHandle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SafeFrameBrokerHandleConstructor()
        {
            tlog.Debug(tag, $"SafeFrameBrokerHandleConstructor START");

            using (Animation ani = new Animation(300))
            {
                ani.SetDefaultAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInSquare));

                var testingTarget = new SafeFrameBrokerHandle(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object CustomView");
                Assert.IsInstanceOf<SafeFrameBrokerHandle>(testingTarget, "Should be an instance of SafeFrameBrokerHandle type.");
            }

            tlog.Debug(tag, $"SafeFrameBrokerHandleConstructor END (OK)");
        }
    }
}
