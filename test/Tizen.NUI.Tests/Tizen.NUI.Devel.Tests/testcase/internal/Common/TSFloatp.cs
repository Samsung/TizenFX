using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/floatp")]
    public class InternalFloatpTest
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
        [Description("floatp constructor.")]
        [Property("SPEC", "Tizen.NUI.floatp.floatp C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FloatpConstructor()
        {
            tlog.Debug(tag, $"FloatpConstructor START");

            var testingTarget = new floatp();
            Assert.IsNotNull(testingTarget, "Can't create success object floatp.");
            Assert.IsInstanceOf<floatp>(testingTarget, "Should return floatp instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FloatpConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("floatp Assign.")]
        [Property("SPEC", "Tizen.NUI.floatp.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FloatpAssign()
        {
            tlog.Debug(tag, $"FloatpConstructor START");

            var testingTarget = new floatp();
            Assert.IsNotNull(testingTarget, "Can't create success object floatp.");
            Assert.IsInstanceOf<floatp>(testingTarget, "Should return floatp instance.");

            try
            {
                testingTarget.assign(0.3f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FloatpConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("floatp value.")]
        [Property("SPEC", "Tizen.NUI.floatp.value M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FloatpValue()
        {
            tlog.Debug(tag, $"FloatpValue START");

            var testingTarget = new floatp();
            Assert.IsNotNull(testingTarget, "Can't create success object floatp.");
            Assert.IsInstanceOf<floatp>(testingTarget, "Should return floatp instance.");

            try
            {
                var result = testingTarget.value();
                tlog.Debug(tag, "value : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FloatpValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("floatp cast.")]
        [Property("SPEC", "Tizen.NUI.floatp.cast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FloatpCast()
        {
            tlog.Debug(tag, $"FloatpCast START");

            var testingTarget = new floatp();
            Assert.IsNotNull(testingTarget, "Can't create success object floatp.");
            Assert.IsInstanceOf<floatp>(testingTarget, "Should return floatp instance.");

            try
            {
                var result = testingTarget.cast();
                tlog.Debug(tag, "cast : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FloatpCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("floatp frompointer.")]
        [Property("SPEC", "Tizen.NUI.floatp.frompointer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FloatpFrompointer()
        {
            tlog.Debug(tag, $"FloatpFrompointer START");

            var testingTarget = new floatp();
            Assert.IsNotNull(testingTarget, "Can't create success object floatp.");
            Assert.IsInstanceOf<floatp>(testingTarget, "Should return floatp instance.");

            try
            {
                var result = floatp.frompointer(testingTarget.cast());
                tlog.Debug(tag, "frompointer : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FloatpFrompointer END (OK)");
        }
    }
}
