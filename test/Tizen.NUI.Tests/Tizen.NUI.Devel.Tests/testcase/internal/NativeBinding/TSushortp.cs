using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/NativeBinding/ushortp")]
    public class InternalUShortpTest
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
        [Description("ushortp constructor.")]
        [Property("SPEC", "Tizen.NUI.ushortp.ushortp C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ushortpConstructor()
        {
            tlog.Debug(tag, $"ushortpConstructor START");

            var testingTarget = new ushortp();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ushortp>(testingTarget, "Should be an Instance of ushortp!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ushortpConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ushortp assign.")]
        [Property("SPEC", "Tizen.NUI.ushortp.assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ushortpAssign()
        {
            tlog.Debug(tag, $"ushortpAssign START");

            var testingTarget = new ushortp();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ushortp>(testingTarget, "Should be an Instance of ushortp!");

            try
            {
                testingTarget.assign(1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ushortpAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ushortp value.")]
        [Property("SPEC", "Tizen.NUI.ushortp.value M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ushortpValue()
        {
            tlog.Debug(tag, $"ushortpValue START");

            var testingTarget = new ushortp();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ushortp>(testingTarget, "Should be an Instance of ushortp!");

            var result = testingTarget.value();
            tlog.Debug(tag, "value : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ushortpValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ushortp cast.")]
        [Property("SPEC", "Tizen.NUI.ushortp.cast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ushortpCast()
        {
            tlog.Debug(tag, $"ushortpCast START");

            var testingTarget = new ushortp();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ushortp>(testingTarget, "Should be an Instance of ushortp!");

            var result = testingTarget.cast();
            tlog.Debug(tag, "value : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ushortpCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ushortp frompointer.")]
        [Property("SPEC", "Tizen.NUI.ushortp.frompointer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ushortpFrompointer()
        {
            tlog.Debug(tag, $"ushortpFrompointer START");

            using (ushortp data = new ushortp())
            {
                var testingTarget = ushortp.frompointer(data.cast());
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ushortp>(testingTarget, "Should be an Instance of ushortp!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ushortpFrompointer END (OK)");
        }
    }
}
