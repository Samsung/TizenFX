using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/RulerPtr")]
    public class InternalRulerPtrTest
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
        [Description("RulerPtr constructor.")]
        [Property("SPEC", "Tizen.NUI.RulerPtr.RulerPtr C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerPtrConstructor()
        {
            tlog.Debug(tag, $"RulerPtrConstructor START");

            var testingTarget = new RulerPtr();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerPtrConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerPtr constructor. With RulerPtr.")]
        [Property("SPEC", "Tizen.NUI.RulerPtr.RulerPtr C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerPtrConstructorWithRulerPtr()
        {
            tlog.Debug(tag, $"RulerPtrConstructorWithRulerPtr START");

            using (RulerPtr ruler = new RulerPtr())
            {
                var testingTarget = new RulerPtr(ruler);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

                testingTarget.Dispose();
            }
               
            tlog.Debug(tag, $"RulerPtrConstructorWithRulerPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerPtr Get.")]
        [Property("SPEC", "Tizen.NUI.RulerPtr.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerPtrGet()
        {
            tlog.Debug(tag, $"RulerPtrGet START");

            var testingTarget = new RulerPtr();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

            var result = testingTarget.Get();
            tlog.Debug(tag, "RulerPtrGet : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerPtrGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerPtr __deref__.")]
        [Property("SPEC", "Tizen.NUI.RulerPtr.__deref__ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerPtr__deref__()
        {
            tlog.Debug(tag, $"RulerPtr__deref__ START");

            var testingTarget = new RulerPtr();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

            var result = testingTarget.__deref__();
            tlog.Debug(tag, "__deref__ : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerPtr__deref__ END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerPtr __ref__.")]
        [Property("SPEC", "Tizen.NUI.RulerPtr.__ref__ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerPtr__ref__()
        {
            tlog.Debug(tag, $"RulerPtr__ref__ START");

            using (RulerPtr ruler = new RulerPtr())
            {
                var testingTarget = ruler.__ref__();
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerPtr__ref__ END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerPtr Assign.")]
        [Property("SPEC", "Tizen.NUI.RulerPtr.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerPtrAssign()
        {
            tlog.Debug(tag, $"RulerPtrAssign START");

            using (RulerPtr ruler = new RulerPtr())
            {
                var testingTarget = ruler.Assign(ruler);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerPtrAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerPtr Reset.")]
        [Property("SPEC", "Tizen.NUI.RulerPtr.Reset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerPtrReset()
        {
            tlog.Debug(tag, $"RulerPtrReset START");

            var testingTarget = new RulerPtr();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

            try
            {
                testingTarget.Reset();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget?.Dispose();
            tlog.Debug(tag, $"RulerPtrReset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerPtr Detach.")]
        [Property("SPEC", "Tizen.NUI.RulerPtr.Detach M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerPtrDetach()
        {
            tlog.Debug(tag, $"RulerPtrDetach START");

            var testingTarget = new RulerPtr();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

            var result = testingTarget.Detach();
            tlog.Debug(tag, "RulerPtrDetach : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerPtrDetach END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("RulerPtr Snap.")]
        //[Property("SPEC", "Tizen.NUI.RulerPtr.Snap M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void RulerPtrSnap()
        //{
        //    tlog.Debug(tag, $"RulerPtrSnap START");

        //    using (DefaultRuler ruler = new DefaultRuler())
        //    {
        //        var testingTarget = new RulerPtr(ruler);
        //        Assert.IsNotNull(testingTarget, "null handle");
        //        Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

        //        // float x
        //        var result = testingTarget.Snap(0.3f);
        //        tlog.Debug(tag, "Snap : " + result);

        //        // float x, float bias
        //        result = testingTarget.Snap(0.3f, 0.2f);
        //        tlog.Debug(tag, "Snap : " + result);

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"RulerPtrSnap END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("RulerPtr Enable.")]
        //[Property("SPEC", "Tizen.NUI.RulerPtr.Enable M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void RulerPtrEnable()
        //{
        //    tlog.Debug(tag, $"RulerPtrEnable START");

        //    using (DefaultRuler ruler = new DefaultRuler())
        //    {
        //        var testingTarget = new RulerPtr(ruler);
        //        Assert.IsNotNull(testingTarget, "null handle");
        //        Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

        //        testingTarget.Enable();
        //        var result = testingTarget.IsEnabled();
        //        tlog.Debug(tag, "IsEnabled : " + result);

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"RulerPtrEnable END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("RulerPtr Disable.")]
        //[Property("SPEC", "Tizen.NUI.RulerPtr.Disable M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void RulerPtrDisable()
        //{
        //    tlog.Debug(tag, $"RulerPtrDisable START");

        //    using (DefaultRuler ruler = new DefaultRuler())
        //    {
        //        var testingTarget = new RulerPtr(ruler);
        //        Assert.IsNotNull(testingTarget, "null handle");
        //        Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

        //        testingTarget.Disable();
        //        var result = testingTarget.IsEnabled();
        //        tlog.Debug(tag, "IsEnabled : " + result);

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"RulerPtrDisable END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("RulerPtr SetDomain.")]
        //[Property("SPEC", "Tizen.NUI.RulerPtr.SetDomain M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void RulerPtrSetDomain()
        //{
        //    tlog.Debug(tag, $"RulerPtrSetDomain START");

        //    using (DefaultRuler ruler = new DefaultRuler())
        //    {
        //        var testingTarget = new RulerPtr(ruler);
        //        Assert.IsNotNull(testingTarget, "null handle");
        //        Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

        //        try
        //        {
        //            using (RulerDomain domain = new RulerDomain(0.0f, 1.0f, false))
        //            {
        //                testingTarget.SetDomain(domain);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception : Failed!");
        //        }

        //        var result = testingTarget.GetDomain();
        //        tlog.Debug(tag, "GetDomain : " + result);

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"RulerPtrSetDomain END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("RulerPtr DisableDomain.")]
        //[Property("SPEC", "Tizen.NUI.RulerPtr.DisableDomain M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void RulerPtrDisableDomain()
        //{
        //    tlog.Debug(tag, $"RulerPtrDisableDomain START");

        //    using (DefaultRuler ruler = new DefaultRuler())
        //    {
        //        var testingTarget = new RulerPtr(ruler);
        //        Assert.IsNotNull(testingTarget, "null handle");
        //        Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

        //        try
        //        {
        //            testingTarget.DisableDomain();
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception : Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"RulerPtrDisableDomain END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("RulerPtr Clamp.")]
        //[Property("SPEC", "Tizen.NUI.RulerPtr.Clamp M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void RulerPtrClamp()
        //{
        //    tlog.Debug(tag, $"RulerPtrClamp START");

        //    using (DefaultRuler ruler = new DefaultRuler())
        //    {
        //        var testingTarget = new RulerPtr(ruler);
        //        Assert.IsNotNull(testingTarget, "null handle");
        //        Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

        //        try
        //        {
        //            // float x
        //            var result = testingTarget.Clamp(0.3f);
        //            tlog.Debug(tag, "Clamp : " + result);

        //            // float x, float length
        //            result = testingTarget.Clamp(0.3f, 0.8f);
        //            tlog.Debug(tag, "Clamp : " + result);

        //            // float x, float length, float scale
        //            result = testingTarget.Clamp(0.3f, 0.8f, 0.5f);
        //            tlog.Debug(tag, "Clamp : " + result);
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception : Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"RulerPtrClamp END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("RulerPtr SnapAndClamp.")]
        //[Property("SPEC", "Tizen.NUI.RulerPtr.SnapAndClamp M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void RulerPtrSnapAndClamp()
        //{
        //    tlog.Debug(tag, $"RulerPtrSnapAndClamp START");

        //    using (DefaultRuler ruler = new DefaultRuler())
        //    {
        //        var testingTarget = new RulerPtr(ruler);
        //        Assert.IsNotNull(testingTarget, "null handle");
        //        Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

        //        // float x
        //        var result = testingTarget.SnapAndClamp(0.3f);
        //        tlog.Debug(tag, "SnapAndClamp : " + result);

        //        // float x, float bias
        //        result = testingTarget.SnapAndClamp(0.3f, 0.1f);
        //        tlog.Debug(tag, "SnapAndClamp : " + result);

        //        // float x, float bias, float length
        //        result = testingTarget.SnapAndClamp(0.3f, 0.1f, 1.0f);
        //        tlog.Debug(tag, "SnapAndClamp : " + result);

        //        // float x, float bias, float length, float scale
        //        result = testingTarget.SnapAndClamp(0.3f, 0.1f, 1.0f, 0.5f);
        //        tlog.Debug(tag, "SnapAndClamp : " + result);

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"RulerPtrSnapAndClamp END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("RulerPtr Reference.")]
        //[Property("SPEC", "Tizen.NUI.RulerPtr.Reference M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void RulerPtrReference()
        //{
        //    tlog.Debug(tag, $"RulerPtrReference START");

        //    using (DefaultRuler ruler = new DefaultRuler())
        //    {
        //        var testingTarget = new RulerPtr(ruler);
        //        Assert.IsNotNull(testingTarget, "null handle");
        //        Assert.IsInstanceOf<RulerPtr>(testingTarget, "Should return RulerPtr instance.");

        //        try
        //        {
        //            testingTarget.Reference();
        //            tlog.Debug(tag, "ReferenceCount : " + testingTarget.ReferenceCount());

        //            testingTarget.Unreference();
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception : Failed!");
        //        }

        //        testingTarget.Dispose();
        //        tlog.Debug(tag, $"RulerPtrReference END (OK)");
        //    }
        //}
    }
}
