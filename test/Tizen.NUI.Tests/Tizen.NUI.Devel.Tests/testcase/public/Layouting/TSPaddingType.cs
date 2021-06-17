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
    [Description("public/Layouting/PaddingType")]

    public class PublicPaddingTypeTest
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
        [Description("PaddingType constructor")]
        [Property("SPEC", "Tizen.NUI.PaddingType.PaddingType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaddingTypeConstructor()
        {
            tlog.Debug(tag, $"PaddingTypeConstructor START");

            var testingTarget = new PaddingType();
            Assert.IsNotNull(testingTarget, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget, "Should be an instance of PaddingType type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PaddingTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PaddingType constructor. With parameters")]
        [Property("SPEC", "Tizen.NUI.PaddingType.PaddingType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaddingTypeConstructorWithParameters()
        {
            tlog.Debug(tag, $"PaddingTypeConstructorWithParameters START");

            var testingTarget = new PaddingType(0.0f, 0.0f, 0.0f, 0.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget, "Should be an instance of PaddingType type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PaddingTypeConstructorWithParameters END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PaddingType Start")]
        [Property("SPEC", "Tizen.NUI.PaddingType.Start A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaddingTypeStart()
        {
            tlog.Debug(tag, $"PaddingTypeStart START");

            var testingTarget = new PaddingType();
            Assert.IsNotNull(testingTarget, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget, "Should be an instance of PaddingType type.");

            testingTarget.Start = 20.0f;
            Assert.AreEqual(20.0f, testingTarget.Start, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PaddingTypeStart END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PaddingType End")]
        [Property("SPEC", "Tizen.NUI.PaddingType.End A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaddingTypeEnd()
        {
            tlog.Debug(tag, $"PaddingTypeEnd START");

            var testingTarget = new PaddingType();
            Assert.IsNotNull(testingTarget, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget, "Should be an instance of PaddingType type.");

            testingTarget.End = 20.0f;
            Assert.AreEqual(20.0f, testingTarget.End, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PaddingTypeEnd END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PaddingType Bottom")]
        [Property("SPEC", "Tizen.NUI.PaddingType.Bottom A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaddingTypeBottom()
        {
            tlog.Debug(tag, $"PaddingTypeEnd START");

            var testingTarget = new PaddingType();
            Assert.IsNotNull(testingTarget, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget, "Should be an instance of PaddingType type.");

            testingTarget.Bottom = 20.0f;
            Assert.AreEqual(20.0f, testingTarget.Bottom, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PaddingTypeEnd END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PaddingType Top")]
        [Property("SPEC", "Tizen.NUI.PaddingType.Top A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaddingTypeTop()
        {
            tlog.Debug(tag, $"PaddingTypeTop START");

            var testingTarget = new PaddingType();
            Assert.IsNotNull(testingTarget, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget, "Should be an instance of PaddingType type.");

            testingTarget.Top = 20.0f;
            Assert.AreEqual(20.0f, testingTarget.Top, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PaddingTypeTop END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PaddingType Equality")]
        [Property("SPEC", "Tizen.NUI.PaddingType.== A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaddingTypeEquality()
        {
            tlog.Debug(tag, $"PaddingTypeEquality START");

            var testingTarget1 = new PaddingType(0.0f, 0.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget1, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget1, "Should be an instance of PaddingType type.");

            var testingTarget2 = new PaddingType(0.0f, 0.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget2, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget2, "Should be an instance of PaddingType type.");

            bool flag = false;
            if (testingTarget1 == testingTarget2)
            {
                flag = true;
            }
            Assert.IsTrue(flag, "Should be true!");

            // If both are null
            PaddingType testingTarget3 = null;
            PaddingType testingTarget4 = null;
            Assert.IsTrue(testingTarget3 == testingTarget4);

            // If one is null, but not both
            PaddingType testingTarget5 = null;
            Assert.IsFalse(testingTarget5 == testingTarget1);

            testingTarget1.Dispose();
            testingTarget2.Dispose();
            tlog.Debug(tag, $"PaddingTypeEquality END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PaddingType Inequality")]
        [Property("SPEC", "Tizen.NUI.PaddingType.!= A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaddingTypeInequality()
        {
            tlog.Debug(tag, $"PaddingTypeInequality START");

            var testingTarget1 = new PaddingType(0.0f, 0.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget1, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget1, "Should be an instance of PaddingType type.");

            var testingTarget2 = new PaddingType(0.0f, 0.0f, 30.0f, 20.0f);
            Assert.IsNotNull(testingTarget2, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget2, "Should be an instance of PaddingType type.");

            bool flag = false;
            if (testingTarget1 != testingTarget2)
            {
                flag = true;
            }
            Assert.IsTrue(flag, "Should be true!");

            testingTarget1.Dispose();
            testingTarget2.Dispose();
            tlog.Debug(tag, $"PaddingTypeInequality END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PaddingType Set")]
        [Property("SPEC", "Tizen.NUI.PaddingType.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaddingTypeSet()
        {
            tlog.Debug(tag, $"PaddingTypeSet START");

            var testingTarget = new PaddingType();
            Assert.IsNotNull(testingTarget, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget, "Should be an instance of PaddingType type.");

            testingTarget.Set(0.0f, 0.0f, 20.0f, 30.0f);
            Assert.AreEqual(testingTarget.Start, 0.0f, "should be equal.");
            Assert.AreEqual(testingTarget.End, 0.0f, "should be equal.");
            Assert.AreEqual(testingTarget.Top, 20.0f, "should be equal.");
            Assert.AreEqual(testingTarget.Bottom, 30.0f, "should be equal.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PaddingTypeSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PaddingType Dispose")]
        [Property("SPEC", "Tizen.NUI.PaddingType.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaddingTypeDispose()
        {
            tlog.Debug(tag, $"PaddingTypeDispose START");

            var testingTarget = new PaddingType();
            Assert.IsNotNull(testingTarget, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget, "Should be an instance of PaddingType type.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"PaddingTypeDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PaddingType Equals")]
        [Property("SPEC", "Tizen.NUI.PaddingType.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Equals_CHECK_RETURN_VALUE()
        {
            tlog.Debug(tag, $"PaddingTypeDispose START");

            var testingTarget1 = new PaddingType(0.0f, 0.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget1, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget1, "Should be an instance of PaddingType type.");

            var testingTarget2 = new PaddingType(0.0f, 0.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget2, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget2, "Should be an instance of PaddingType type.");

            var testingTarget3 = new PaddingType(10.0f, 0.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget3, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget3, "Should be an instance of PaddingType type.");

            bool flagTrue = testingTarget1.Equals(testingTarget2);
            Assert.IsTrue(flagTrue, "Should be true!");

            bool flagFalse = testingTarget1.Equals(testingTarget3);
            Assert.IsFalse(flagFalse, "Should be false!");

            // object is null
            Assert.IsFalse(testingTarget1.Equals(null));

            // object is not a PaddingType
            using (Size size = new Size(100, 200))
            {
                Assert.IsFalse(testingTarget1.Equals(size));
            }

            testingTarget1.Dispose();
            testingTarget2.Dispose();
            testingTarget3.Dispose();
            tlog.Debug(tag, $"PaddingTypeDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PaddingType GetHashCode")]
        [Property("SPEC", "Tizen.NUI.PaddingType.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaddingTypeGetHashCode()
        {
            tlog.Debug(tag, $"PaddingTypeGetHashCode START");

            var testingTarget = new PaddingType();
            Assert.IsNotNull(testingTarget, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(testingTarget, "Should be an instance of PaddingType type.");

            Assert.GreaterOrEqual(testingTarget.GetHashCode(), 0, "Should be true");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PaddingTypeGetHashCode END (OK)");
        }
    }
}
