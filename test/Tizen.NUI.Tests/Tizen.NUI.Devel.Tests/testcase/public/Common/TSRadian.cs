using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/Radian")]
    public class PublicRadianTest
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
        [Description("Radian constructor.")]
        [Property("SPEC", "Tizen.NUI.Radian.Radian C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RadianConstructor()
        {
            tlog.Debug(tag, $"RadianConstructor START");

            var testingTarget = new Radian();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should return Radian instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RadianConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Radian constructor. With Float.")]
        [Property("SPEC", "Tizen.NUI.Radian.Radian C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RadianConstructorWithFloat()
        {
            tlog.Debug(tag, $"RadianConstructorWithFloat START");

            var testingTarget = new Radian(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should return Radian instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RadianConstructorWithFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Radian constructor. With Degree.")]
        [Property("SPEC", "Tizen.NUI.Radian.Radian C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RadianConstructorWithDegree()
        {
            tlog.Debug(tag, $"RadianConstructorWithDegree START");
            
            using (Degree degree = new Degree())
            {
                var testingTarget = new Radian(degree);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<Radian>(testingTarget, "Should return Radian instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RadianConstructorWithDegree END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Radian ConvertToFloat.")]
        [Property("SPEC", "Tizen.NUI.Radian.ConvertToFloat M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RadianConvertToFloat()
        {
            tlog.Debug(tag, $"RadianConvertToFloat START");

            var testingTarget = new Radian(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should return Radian instance.");

            var result = testingTarget.ConvertToFloat();
            Assert.AreEqual(10.0f, result, "ConvertToFloat function does not work, return error value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RadianConvertToFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Radian Value.")]
        [Property("SPEC", "Tizen.NUI.Radian.Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RadianValue()
        {
            tlog.Debug(tag, $"RadianValue START");

            var testingTarget = new Radian(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should return Radian instance.");

            testingTarget.Value = 30.0f;
            Assert.AreEqual(30.0f, testingTarget.Value, "radian function does not work, return error value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RadianValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Radian Dispose.")]
        [Property("SPEC", "Tizen.NUI.Radian.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RadianDispose()
        {
            tlog.Debug(tag, $"RadianDispose START");

            var testingTarget = new Radian(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Radian>(testingTarget, "Should return Radian instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"RadianDispose END (OK)");
        }
    }
}
