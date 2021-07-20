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
    [Description("public/Utility/ScrollViewEffect")]
    public class PublicScrollViewEffectTest
    {
        private const string tag = "NUITEST";

        internal class MyScrollViewEffect : ScrollViewEffect
        {
            public MyScrollViewEffect() : base()
            { }

            public void OnReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
            {
                base.ReleaseSwigCPtr(swigCPtr);
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
        [Description("ScrollViewEffect constructor.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewEffect.ScrollViewEffect C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewEffectConstructor()
        {
            tlog.Debug(tag, $"ScrollViewEffectConstructor START");

            var testingTarget = new ScrollViewEffect();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollViewEffect");
            Assert.IsInstanceOf<ScrollViewEffect>(testingTarget, "Should be an instance of ScrollViewEffect type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewEffectConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollViewEffect ReleaseSwigCPtr.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewEffect.ReleaseSwigCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewEffectReleaseSwigCPtr()
        {
            tlog.Debug(tag, $"ScrollViewEffectReleaseSwigCPtr START");

            var testingTarget = new MyScrollViewEffect();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollViewEffect");
            Assert.IsInstanceOf<ScrollViewEffect>(testingTarget, "Should be an instance of ScrollViewEffect type.");

            try
            {
                testingTarget.OnReleaseSwigCPtr(testingTarget.SwigCPtr);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ScrollViewEffectReleaseSwigCPtr END (OK)");
        }
    }
}
