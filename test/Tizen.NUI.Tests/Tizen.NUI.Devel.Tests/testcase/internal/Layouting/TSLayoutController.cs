using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Layouting/LayoutController")]
    public class InternalLayoutControllerTest
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
        [Description("LayoutController GetId.")]
        [Property("SPEC", "Tizen.NUI.LayoutController.GetId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutControllerGetId()
        {
            tlog.Debug(tag, $"LayoutControllerGetId START");

            var testingTarget = new LayoutController(Window.Instance);
            Assert.IsNotNull(testingTarget, "Can't create success object LayoutController");
            Assert.IsInstanceOf<LayoutController>(testingTarget, "Should be an instance of LayoutController type.");

            tlog.Debug(tag, testingTarget.GetId().ToString());

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutControllerGetId END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutController RequestLayout.")]
        [Property("SPEC", "Tizen.NUI.LayoutController.RequestLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutControllerRequestLayout()
        {
            tlog.Debug(tag, $"LayoutControllerRequestLayout START");

            var testingTarget = new LayoutController(Window.Instance);
            Assert.IsNotNull(testingTarget, "Can't create success object LayoutController");
            Assert.IsInstanceOf<LayoutController>(testingTarget, "Should be an instance of LayoutController type.");

            using (LayoutItem layoutItem = new LayoutItem())
            {
                using (View view = new View())
                {
                    view.Layout = layoutItem;
                    view.Name = "parentView";

                    try
                    {
                        testingTarget.RequestLayout(layoutItem);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception : Failed!");
                    }
                }

            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutControllerRequestLayout END (OK)");
        }
    }
}
