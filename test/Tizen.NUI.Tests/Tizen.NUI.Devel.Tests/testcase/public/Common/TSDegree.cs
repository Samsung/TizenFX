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
    [Description("public/Common/Degree")]
    public class PublicDegreeTest
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
        [Description("Degree constructor.")]
        [Property("SPEC", "Tizen.NUI.Degree.Degree C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DegreeConstructor()
        {
            tlog.Debug(tag, $"DegreeConstructor START");

            var testingTarget = new Degree();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Degree>(testingTarget, "Should return Degree instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DegreeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Degree constructor. With float.")]
        [Property("SPEC", "Tizen.NUI.Degree.Degree C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DegreeConstructorWithFloat()
        {
            tlog.Debug(tag, $"DegreeConstructorWithFloat START");

            var testingTarget = new Degree(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Degree>(testingTarget, "Should return Degree instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DegreeConstructorWithFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Degree constructor. With Radian.")]
        [Property("SPEC", "Tizen.NUI.Degree.Degree C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DegreeConstructorWithRadian()
        {
            tlog.Debug(tag, $"DegreeConstructorWithRadian START");

            using (Radian radian = new Radian(1.0f))
            {
                var testingTarget = new Degree(radian);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<Degree>(testingTarget, "Should return Degree instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"DegreeConstructorWithRadian END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Degree Value.")]
        [Property("SPEC", "Tizen.NUI.Degree.Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DegreeValue()
        {
            tlog.Debug(tag, $"DegreeValue START");

            var testingTarget = new Degree(1.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Degree>(testingTarget, "Should return Degree instance.");

            Assert.AreEqual(1.0f, testingTarget.Value, "Should be equal to 1.0f.");

            testingTarget.Value = 2.0f;
            Assert.AreEqual(2.0f, testingTarget.Value, "Should be equal to 2.0f.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DegreeValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Degree Dispose.")]
        [Property("SPEC", "Tizen.NUI.Degree.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DegreeDispose()
        {
            tlog.Debug(tag, $"DegreeDispose START");

            var testingTarget = new Degree(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Degree>(testingTarget, "Should return Degree instance.");

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

            tlog.Debug(tag, $"DegreeDispose END (OK)");
        }
    }
}
