using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/NativeBinding/intp")]
    public class InternalIntpTest
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
        [Description("intp constructor.")]
        [Property("SPEC", "Tizen.NUI.intp.intp C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void intpConstructor()
        {
            tlog.Debug(tag, $"intpConstructor START");

            var testingTarget = new intp();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<intp>(testingTarget, "Should be an Instance of intp!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"intpConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("intp assign.")]
        [Property("SPEC", "Tizen.NUI.intp.assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void intpAssign()
        {
            tlog.Debug(tag, $"intpAssign START");

            var testingTarget = new intp();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<intp>(testingTarget, "Should be an Instance of intp!");

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
            tlog.Debug(tag, $"intpAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("intp value.")]
        [Property("SPEC", "Tizen.NUI.intp.value M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void intpValue()
        {
            tlog.Debug(tag, $"intpValue START");

            var testingTarget = new intp();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<intp>(testingTarget, "Should be an Instance of intp!");

            var result = testingTarget.value();
            tlog.Debug(tag, "value : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"intpValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("intp cast.")]
        [Property("SPEC", "Tizen.NUI.intp.cast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void intpCast()
        {
            tlog.Debug(tag, $"intpCast START");

            var testingTarget = new intp();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<intp>(testingTarget, "Should be an Instance of intp!");

            var result = testingTarget.cast();
            tlog.Debug(tag, "value : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"intpCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("intp frompointer.")]
        [Property("SPEC", "Tizen.NUI.intp.frompointer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void intpFrompointer()
        {
            tlog.Debug(tag, $"intpFrompointer START");

            using (intp data = new intp())
            {
                var testingTarget = intp.frompointer(data.cast());
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<intp>(testingTarget, "Should be an Instance of intp!");
                
                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"intpFrompointer END (OK)");
        }
    }
}
