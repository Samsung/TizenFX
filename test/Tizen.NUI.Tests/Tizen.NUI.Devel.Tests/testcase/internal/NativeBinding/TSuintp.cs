using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/NativeBinding/uintp")]
    public class InternalUintpTest
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
        [Description("uintp constructor.")]
        [Property("SPEC", "Tizen.NUI.uintp.uintp C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void uintpConstructor()
        {
            tlog.Debug(tag, $"uintpConstructor START");

            var testingTarget = new uintp();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<uintp>(testingTarget, "Should be an Instance of uintp!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"uintpConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("uintp assign.")]
        [Property("SPEC", "Tizen.NUI.uintp.assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void uintpAssign()
        {
            tlog.Debug(tag, $"uintpAssign START");

            var testingTarget = new uintp();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<uintp>(testingTarget, "Should be an Instance of uintp!");

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
            tlog.Debug(tag, $"uintpAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("uintp value.")]
        [Property("SPEC", "Tizen.NUI.uintp.value M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void uintpValue()
        {
            tlog.Debug(tag, $"uintpValue START");

            var testingTarget = new uintp();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<uintp>(testingTarget, "Should be an Instance of uintp!");

            var result = testingTarget.value();
            tlog.Debug(tag, "value : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"uintpValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("uintp cast.")]
        [Property("SPEC", "Tizen.NUI.uintp.cast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void uintpCast()
        {
            tlog.Debug(tag, $"uintpCast START");

            var testingTarget = new uintp();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<uintp>(testingTarget, "Should be an Instance of uintp!");

            var result = testingTarget.cast();
            tlog.Debug(tag, "value : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"uintpCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("uintp frompointer.")]
        [Property("SPEC", "Tizen.NUI.uintp.frompointer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void uintpFrompointer()
        {
            tlog.Debug(tag, $"uintpFrompointer START");

            using (uintp data = new uintp())
            {
                var testingTarget = uintp.frompointer(data.cast());
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<uintp>(testingTarget, "Should be an Instance of uintp!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"uintpFrompointer END (OK)");
        }
    }
}
