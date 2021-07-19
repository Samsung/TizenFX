using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/RulerDomain")]
    public class InternalRulerDomainTest
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
        [Description("RulerDomain constructor.")]
        [Property("SPEC", "Tizen.NUI.RulerDomain.RulerDomain C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerDomainConstructor()
        {
            tlog.Debug(tag, $"RulerDomainConstructor START");

            var testingTarget = new RulerDomain(0.0f, 100.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object RulerDomain.");
            Assert.IsInstanceOf<RulerDomain>(testingTarget, "Should return RulerDomain instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerDomainConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerDomain min.")]
        [Property("SPEC", "Tizen.NUI.RulerDomain.min A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerDomainMinimize()
        {
            tlog.Debug(tag, $"RulerDomainMinimize START");

            var testingTarget = new RulerDomain(0.0f, 100.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object RulerDomain.");
            Assert.IsInstanceOf<RulerDomain>(testingTarget, "Should return RulerDomain instance.");

            testingTarget.min = 10.0f;
            Assert.AreEqual(10.0f, testingTarget.min, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerDomainMinimize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerDomain max.")]
        [Property("SPEC", "Tizen.NUI.RulerDomain.max A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerDomainMaximize()
        {
            tlog.Debug(tag, $"RulerDomainMaximize START");

            var testingTarget = new RulerDomain(0.0f, 100.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object RulerDomain.");
            Assert.IsInstanceOf<RulerDomain>(testingTarget, "Should return RulerDomain instance.");

            testingTarget.max = 110.0f;
            Assert.AreEqual(110.0f, testingTarget.max, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerDomainMaximize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerDomain enabled.")]
        [Property("SPEC", "Tizen.NUI.RulerDomain.enabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerDomainEnabled()
        {
            tlog.Debug(tag, $"RulerDomainEnabled START");

            var testingTarget = new RulerDomain(0.0f, 100.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object RulerDomain.");
            Assert.IsInstanceOf<RulerDomain>(testingTarget, "Should return RulerDomain instance.");

            testingTarget.enabled = true;
            Assert.AreEqual(true, testingTarget.enabled, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerDomainEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerDomain Clamp.")]
        [Property("SPEC", "Tizen.NUI.RulerDomain.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerDomainClamp()
        {
            tlog.Debug(tag, $"RulerDomainClamp START");

            var testingTarget = new RulerDomain(0.0f, 100.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object RulerDomain.");
            Assert.IsInstanceOf<RulerDomain>(testingTarget, "Should return RulerDomain instance.");

            var result = testingTarget.Clamp(10.0f);
            tlog.Debug(tag, "Clamp : " + result);
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerDomainClamp END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerDomain Clamp. With length.")]
        [Property("SPEC", "Tizen.NUI.RulerDomain.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerDomainClampWithLength()
        {
            tlog.Debug(tag, $"RulerDomainClampWithLength START");

            var testingTarget = new RulerDomain(0.0f, 100.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object RulerDomain.");
            Assert.IsInstanceOf<RulerDomain>(testingTarget, "Should return RulerDomain instance.");

            var result = testingTarget.Clamp(10.0f, 50.0f);
            tlog.Debug(tag, "Clamp : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerDomainClampWithLength END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerDomain Clamp. With scale.")]
        [Property("SPEC", "Tizen.NUI.RulerDomain.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerDomainClampWithScale()
        {
            tlog.Debug(tag, $"RulerDomainClampWithScale START");

            var testingTarget = new RulerDomain(0.0f, 100.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object RulerDomain.");
            Assert.IsInstanceOf<RulerDomain>(testingTarget, "Should return RulerDomain instance.");

            var result = testingTarget.Clamp(10.0f, 50.0f, 100.0f);
            tlog.Debug(tag, "Clamp : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerDomainClampWithScale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerDomain Clamp. With ClampState.")]
        [Property("SPEC", "Tizen.NUI.RulerDomain.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerDomainClampWithClampState()
        {
            tlog.Debug(tag, $"RulerDomainClampWithClampState START");

            var testingTarget = new RulerDomain(0.0f, 100.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object RulerDomain.");
            Assert.IsInstanceOf<RulerDomain>(testingTarget, "Should return RulerDomain instance.");

            var result = testingTarget.Clamp(10.0f, 50.0f, 100.0f, new SWIGTYPE_p_Dali__Toolkit__ClampState(testingTarget.SwigCPtr.Handle));
            tlog.Debug(tag, "Clamp : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerDomainClampWithClampState END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RulerDomain GetSize.")]
        [Property("SPEC", "Tizen.NUI.RulerDomain.GetSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerDomainGetSize()
        {
            tlog.Debug(tag, $"RulerDomainGetSize START");

            var testingTarget = new RulerDomain(0.0f, 100.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object RulerDomain.");
            Assert.IsInstanceOf<RulerDomain>(testingTarget, "Should return RulerDomain instance.");

            var result = testingTarget.GetSize();
            tlog.Debug(tag, "Size : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerDomainGetSize END (OK)");
        }
    }
}
