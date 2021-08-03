using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/Uint16Pair")]
    public class InternalUint16PairTest
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
        [Description("Uint16Pair constructor.")]
        [Property("SPEC", "Tizen.NUI.Uint16Pair.Uint16Pair C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Uint16PairConstructor()
        {
            tlog.Debug(tag, $"Uint16PairConstructor START");

            using (Uint16Pair data = new Uint16Pair(1, 2))
            {
                var testingTarget = new Uint16Pair(data);
                Assert.IsNotNull(testingTarget, "Can't create success object Uint16Pair");
                Assert.IsInstanceOf<Uint16Pair>(testingTarget, "Should be an instance of Uint16Pair type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"Uint16PairConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Uint16Pair SetWidth.")]
        [Property("SPEC", "Tizen.NUI.Uint16Pair.SetWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Uint16PairSetWidth()
        {
            tlog.Debug(tag, $"Uint16PairSetWidth START");

            var testingTarget = new Uint16Pair(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object Uint16Pair");
            Assert.IsInstanceOf<Uint16Pair>(testingTarget, "Should be an instance of Uint16Pair type.");

            try
            {
                testingTarget.SetWidth(2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"Uint16PairSetWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Uint16Pair SetHeight.")]
        [Property("SPEC", "Tizen.NUI.Uint16Pair.SetHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Uint16PairSetHeight()
        {
            tlog.Debug(tag, $"Uint16PairSetHeight START");

            var testingTarget = new Uint16Pair(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object Uint16Pair");
            Assert.IsInstanceOf<Uint16Pair>(testingTarget, "Should be an instance of Uint16Pair type.");

            try
            {
                testingTarget.SetHeight(1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"Uint16PairSetHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Uint16Pair SetX.")]
        [Property("SPEC", "Tizen.NUI.Uint16Pair.SetX M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Uint16PairSetX()
        {
            tlog.Debug(tag, $"Uint16PairSetX START");

            var testingTarget = new Uint16Pair(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object Uint16Pair");
            Assert.IsInstanceOf<Uint16Pair>(testingTarget, "Should be an instance of Uint16Pair type.");

            try
            {
                testingTarget.SetX(2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"Uint16PairSetX END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Uint16Pair SetY.")]
        [Property("SPEC", "Tizen.NUI.Uint16Pair.SetY M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Uint16PairSetY()
        {
            tlog.Debug(tag, $"Uint16PairSetY START");

            var testingTarget = new Uint16Pair(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object Uint16Pair");
            Assert.IsInstanceOf<Uint16Pair>(testingTarget, "Should be an instance of Uint16Pair type.");

            try
            {
                testingTarget.SetY(2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"Uint16PairSetY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Uint16Pair Assign.")]
        [Property("SPEC", "Tizen.NUI.Uint16Pair.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Uint16PairAssign()
        {
            tlog.Debug(tag, $"Uint16PairAssign START");

            using (Uint16Pair data = new Uint16Pair(1, 2))
            {
                var testingTarget = data.Assign(data);
                Assert.IsNotNull(testingTarget, "Can't create success object Uint16Pair");
                Assert.IsInstanceOf<Uint16Pair>(testingTarget, "Should be an instance of Uint16Pair type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"Uint16PairAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Uint16Pair <.")]
        [Property("SPEC", "Tizen.NUI.Uint16Pair.LessThan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Uint16PairLessThan()
        {
            tlog.Debug(tag, $"Uint16PairLessThan START");

            var testingTarget = new Uint16Pair(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object Uint16Pair");
            Assert.IsInstanceOf<Uint16Pair>(testingTarget, "Should be an instance of Uint16Pair type.");

            using (Uint16Pair obj = new Uint16Pair(1, 0))
            {
                var result = testingTarget < obj;
                tlog.Debug(tag, result.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Uint16PairLessThan END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Uint16Pair >.")]
        [Property("SPEC", "Tizen.NUI.Uint16Pair.LessThan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Uint16PairGreaterThan()
        {
            tlog.Debug(tag, $"Uint16PairGreaterThan START");

            var testingTarget = new Uint16Pair(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object Uint16Pair");
            Assert.IsInstanceOf<Uint16Pair>(testingTarget, "Should be an instance of Uint16Pair type.");

            using (Uint16Pair obj = new Uint16Pair(1, 0))
            {
                var result = testingTarget > obj;
                tlog.Debug(tag, result.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Uint16PairGreaterThan END (OK)");
        }
    }
}
