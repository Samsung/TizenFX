using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/DefaultRuler")]
    public class InternalDefaultRulerTest
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
        [Description("DefaultRuler constructor.")]
        [Property("SPEC", "Tizen.NUI.DefaultRuler.DefaultRuler C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultRulerConstructor()
        {
            tlog.Debug(tag, $"DefaultRulerConstructor START");

            var testingTarget = new DefaultRuler();
            Assert.IsNotNull(testingTarget, "Can't create success object DefaultRuler.");
            Assert.IsInstanceOf<DefaultRuler>(testingTarget, "Should return DefaultRuler instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultRulerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultRuler Snap.")]
        [Property("SPEC", "Tizen.NUI.DefaultRuler.Snap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultRulerSnap()
        {
            tlog.Debug(tag, $"DefaultRulerSnap START");

            var testingTarget = new DefaultRuler();
            Assert.IsNotNull(testingTarget, "Can't create success object DefaultRuler.");
            Assert.IsInstanceOf<DefaultRuler>(testingTarget, "Should return DefaultRuler instance.");

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
            tlog.Debug(tag, $"DefaultRulerSnap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultRuler GetPositionFromPage.")]
        [Property("SPEC", "Tizen.NUI.DefaultRuler.GetPositionFromPage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultRulerGetPositionFromPage()
        {
            tlog.Debug(tag, $"DefaultRulerGetPositionFromPage START");

            var testingTarget = new DefaultRuler();
            Assert.IsNotNull(testingTarget, "Can't create success object DefaultRuler.");
            Assert.IsInstanceOf<DefaultRuler>(testingTarget, "Should return DefaultRuler instance.");

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
            tlog.Debug(tag, $"DefaultRulerGetPositionFromPage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultRuler GetPageFromPosition.")]
        [Property("SPEC", "Tizen.NUI.DefaultRuler.GetPageFromPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultRulerGetPageFromPosition()
        {
            tlog.Debug(tag, $"DefaultRulerGetPageFromPosition START");

            var testingTarget = new DefaultRuler();
            Assert.IsNotNull(testingTarget, "Can't create success object DefaultRuler.");
            Assert.IsInstanceOf<DefaultRuler>(testingTarget, "Should return DefaultRuler instance.");

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
            tlog.Debug(tag, $"DefaultRulerGetPageFromPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultRuler GetTotalPages.")]
        [Property("SPEC", "Tizen.NUI.DefaultRuler.GetTotalPages M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultRulerGetTotalPages()
        {
            tlog.Debug(tag, $"DefaultRulerGetTotalPages START");

            var testingTarget = new DefaultRuler();
            Assert.IsNotNull(testingTarget, "Can't create success object DefaultRuler.");
            Assert.IsInstanceOf<DefaultRuler>(testingTarget, "Should return DefaultRuler instance.");

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
            tlog.Debug(tag, $"DefaultRulerGetTotalPages END (OK)");
        }
    }
}
