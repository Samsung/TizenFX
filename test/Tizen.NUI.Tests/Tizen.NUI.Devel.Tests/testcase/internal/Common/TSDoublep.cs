using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;


namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/doublep")]
    public class InternalDoublepTest
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
        [Description("doublep constructor.")]
        [Property("SPEC", "Tizen.NUI.doublep.doublep C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void doublepConstructor()
        {
            tlog.Debug(tag, $"doublepConstructor START");

            var testingTarget = new doublep();
            Assert.IsNotNull(testingTarget, "Can't create success object doublep.");
            Assert.IsInstanceOf<doublep>(testingTarget, "Should return doublep instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"doublepConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("doublep assign.")]
        [Property("SPEC", "Tizen.NUI.doublep.assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void doublepAssign()
        {
            tlog.Debug(tag, $"doublepAssign START");

            var testingTarget = new doublep();
            Assert.IsNotNull(testingTarget, "Can't create success object doublep.");
            Assert.IsInstanceOf<doublep>(testingTarget, "Should return doublep instance.");

            try
            {
                testingTarget.assign(6.92);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"doublepAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("doublep value.")]
        [Property("SPEC", "Tizen.NUI.doublep.value M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void doublepValue()
        {
            tlog.Debug(tag, $"doublepValue START");

            var testingTarget = new doublep();
            Assert.IsNotNull(testingTarget, "Can't create success object doublep.");
            Assert.IsInstanceOf<doublep>(testingTarget, "Should return doublep instance.");

            var result = testingTarget.value();
            tlog.Debug(tag, "value : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"doublepValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("doublep cast.")]
        [Property("SPEC", "Tizen.NUI.doublep.cast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void doublepCast()
        {
            tlog.Debug(tag, $"doublepCast START");

            var testingTarget = new doublep();
            Assert.IsNotNull(testingTarget, "Can't create success object doublep.");
            Assert.IsInstanceOf<doublep>(testingTarget, "Should return doublep instance.");

            var result = testingTarget.cast();
            tlog.Debug(tag, "cast : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"doublepCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("doublep frompointer.")]
        [Property("SPEC", "Tizen.NUI.doublep.frompointer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void doublepFrompointer()
        {
            tlog.Debug(tag, $"doublepFrompointer START");

            var testingTarget = new doublep();
            Assert.IsNotNull(testingTarget, "Can't create success object doublep.");
            Assert.IsInstanceOf<doublep>(testingTarget, "Should return doublep instance.");

            var result = doublep.frompointer(new SWIGTYPE_p_double(testingTarget.SwigCPtr.Handle));
            tlog.Debug(tag, "cast : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"doublepFrompointer END (OK)");
        }
    }
}
