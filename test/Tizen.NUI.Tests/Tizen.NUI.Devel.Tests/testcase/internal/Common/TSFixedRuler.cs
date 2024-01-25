using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/FixedRuler")]
    public class InternalFixedRulerTest
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
        [Description("FixedRuler constructor.")]
        [Property("SPEC", "Tizen.NUI.FixedRuler.FixedRuler C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FixedRulerConstructor()
        {
            tlog.Debug(tag, $"FixedRulerConstructor START");

            var testingTarget = new FixedRuler();
            Assert.IsNotNull(testingTarget, "Can't create success object FixedRuler.");
            Assert.IsInstanceOf<FixedRuler>(testingTarget, "Should return FixedRuler instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FixedRulerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FixedRuler constructor. With spacing.")]
        [Property("SPEC", "Tizen.NUI.FixedRuler.FixedRuler C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FixedRulerConstructorWithSpacing()
        {
            tlog.Debug(tag, $"FixedRulerConstructorWithSpacing START");

            var testingTarget = new FixedRuler(0.3f);
            Assert.IsNotNull(testingTarget, "Can't create success object FixedRuler.");
            Assert.IsInstanceOf<FixedRuler>(testingTarget, "Should return FixedRuler instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FixedRulerConstructorWithSpacing END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FixedRuler Snap.")]
        [Property("SPEC", "Tizen.NUI.FixedRuler.Snap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FixedRulerSnap()
        {
            tlog.Debug(tag, $"FixedRulerSnap START");

            var testingTarget = new FixedRuler();
            Assert.IsNotNull(testingTarget, "Can't create success object FixedRuler.");
            Assert.IsInstanceOf<FixedRuler>(testingTarget, "Should return FixedRuler instance.");

            try
            {
                var result = testingTarget.Snap(0.3f, 0.1f);
                tlog.Debug(tag, "Snap :" + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FixedRulerSnap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FixedRuler GetPositionFromPage.")]
        [Property("SPEC", "Tizen.NUI.FixedRuler.GetPositionFromPage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FixedRulerGetPositionFromPage()
        {
            tlog.Debug(tag, $"FixedRulerGetPositionFromPage START");

            var testingTarget = new FixedRuler();
            Assert.IsNotNull(testingTarget, "Can't create success object FixedRuler.");
            Assert.IsInstanceOf<FixedRuler>(testingTarget, "Should return FixedRuler instance.");

            try
            {
                var result = testingTarget.GetPositionFromPage(1, out uint vloume, true);
                tlog.Debug(tag, "GetPositionFromPage :" + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FixedRulerGetPositionFromPage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FixedRuler GetPageFromPosition.")]
        [Property("SPEC", "Tizen.NUI.FixedRuler.GetPageFromPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FixedRulerGetPageFromPosition()
        {
            tlog.Debug(tag, $"FixedRulerGetPageFromPosition START");

            var testingTarget = new FixedRuler();
            Assert.IsNotNull(testingTarget, "Can't create success object FixedRuler.");
            Assert.IsInstanceOf<FixedRuler>(testingTarget, "Should return FixedRuler instance.");

            try
            {
                var result = testingTarget.GetPageFromPosition(0.3f, true);
                tlog.Debug(tag, "GetPageFromPosition :" + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FixedRulerGetPageFromPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FixedRuler GetTotalPages.")]
        [Property("SPEC", "Tizen.NUI.FixedRuler.GetTotalPages M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FixedRulerGetTotalPages()
        {
            tlog.Debug(tag, $"FixedRulerGetTotalPages START");

            var testingTarget = new FixedRuler();
            Assert.IsNotNull(testingTarget, "Can't create success object FixedRuler.");
            Assert.IsInstanceOf<FixedRuler>(testingTarget, "Should return FixedRuler instance.");

            try
            {
                var result = testingTarget.GetTotalPages();
                tlog.Debug(tag, "GetTotalPages :" + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FixedRulerGetTotalPages END (OK)");
        }
    }
}
