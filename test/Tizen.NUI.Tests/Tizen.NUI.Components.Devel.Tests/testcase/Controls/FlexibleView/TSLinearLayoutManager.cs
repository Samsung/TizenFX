using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/FlexibleView/LinearLayoutManager")]
    class TSLinearLayoutManager
    {
        private const string tag = "NUITEST";

        private Vector2 scrnSize;

        [SetUp]
        public void Init()
        {
            scrnSize = new Vector2(1920, 1080);
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
            scrnSize?.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayoutManager constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayoutManager C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void LinearLayoutManagerConstructor()
        {
            tlog.Debug(tag, $"LinearLayoutManagerConstructor START");

            var testingTarget = new LinearLayoutManager(LinearLayoutManager.HORIZONTAL);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LinearLayoutManager>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearLayoutManagerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayoutManager FirstVisibleItemPosition.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayoutManager.FirstVisibleItemPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void LinearLayoutManagerFirstVisibleItemPosition()
        {
            tlog.Debug(tag, $"LinearLayoutManagerFirstVisibleItemPosition START");

            var testingTarget = new LinearLayoutManager(LinearLayoutManager.HORIZONTAL);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LinearLayoutManager>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(testingTarget.FirstVisibleItemPosition, -1, "should be equal.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearLayoutManagerFirstVisibleItemPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayoutManager FirstCompleteVisibleItemPosition.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayoutManager.FirstCompleteVisibleItemPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void LinearLayoutManagerFirstCompleteVisibleItemPosition()
        {
            tlog.Debug(tag, $"LinearLayoutManagerFirstCompleteVisibleItemPosition START");

            var testingTarget = new LinearLayoutManager(LinearLayoutManager.HORIZONTAL);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LinearLayoutManager>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(testingTarget.FirstCompleteVisibleItemPosition, -1, "should be equal to 0.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearLayoutManagerFirstCompleteVisibleItemPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayoutManager LastVisibleItemPosition.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayoutManager.LastVisibleItemPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void LinearLayoutManagerLastVisibleItemPosition()
        {
            tlog.Debug(tag, $"LinearLayoutManagerLastVisibleItemPosition START");

            var testingTarget = new LinearLayoutManager(LinearLayoutManager.HORIZONTAL);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LinearLayoutManager>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(testingTarget.LastVisibleItemPosition, -1, "should be equal to 0.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearLayoutManagerLastVisibleItemPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayoutManager LastCompleteVisibleItemPosition.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayoutManager.LastCompleteVisibleItemPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void LinearLayoutManagerLastCompleteVisibleItemPosition()
        {
            tlog.Debug(tag, $"LinearLayoutManagerLastCompleteVisibleItemPosition START");

            var testingTarget = new LinearLayoutManager(LinearLayoutManager.HORIZONTAL);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LinearLayoutManager>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(testingTarget.LastCompleteVisibleItemPosition, -1, "should be equal to 0.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearLayoutManagerLastCompleteVisibleItemPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayoutManager CanScrollHorizontally.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayoutManager.CanScrollHorizontally M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void LinearLayoutManagerCanScrollHorizontally()
        {
            tlog.Debug(tag, $"LinearLayoutManagerCanScrollHorizontally START");

            var testingTarget = new LinearLayoutManager(LinearLayoutManager.HORIZONTAL);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LinearLayoutManager>(testingTarget, "should be an instance of testing target class!");
            Assert.IsTrue(testingTarget.CanScrollHorizontally(), "should be true.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearLayoutManagerCanScrollHorizontally END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayoutManager CanScrollVertically.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayoutManager.CanScrollVertically M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void LinearLayoutManagerCanScrollVertically()
        {
            tlog.Debug(tag, $"LinearLayoutManagerCanScrollVertically START");

            var testingTarget = new LinearLayoutManager(LinearLayoutManager.HORIZONTAL);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LinearLayoutManager>(testingTarget, "should be an instance of testing target class!");
            Assert.IsFalse(testingTarget.CanScrollVertically(), "should be false.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearLayoutManagerCanScrollVertically END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayoutManager OnFocusSearchFailed.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayoutManager.OnFocusSearchFailed M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void LinearLayoutManagerOnFocusSearchFailed()
        {
            tlog.Debug(tag, $"LinearLayoutManagerCanScrollVertically START");

            var testingTarget = UtilityOfFlexView.CreateLinearFlexibleView(scrnSize, LinearLayoutManager.VERTICAL, 8);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleView>(testingTarget, "should be an instance of testing target class!");

            var layout = testingTarget.GetLayoutManager();
            var recycler = testingTarget.GetRecycler();
            layout.OnFocusSearchFailed(null, FlexibleViewLayoutManager.Direction.Up, recycler);
            layout.OnFocusSearchFailed(null, FlexibleViewLayoutManager.Direction.Down, recycler);
            layout.OnFocusSearchFailed(null, FlexibleViewLayoutManager.Direction.Left, recycler);
            layout.OnFocusSearchFailed(null, FlexibleViewLayoutManager.Direction.Right, recycler);

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearLayoutManagerCanScrollVertically END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayoutManager ScrollHorizontallyBy.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayoutManager.ScrollHorizontallyBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void LinearLayoutManagerScrollHorizontallyBy()
        {
            tlog.Debug(tag, $"LinearLayoutManagerScrollHorizontallyBy START");

            var testingTarget = UtilityOfFlexView.CreateLinearFlexibleView(scrnSize, LinearLayoutManager.VERTICAL, 8);

            var layout = testingTarget.GetLayoutManager();
            var recycler = testingTarget.GetRecycler();

            layout.ScrollHorizontallyBy(20, recycler, false);
            testingTarget.Dispose();

            testingTarget = UtilityOfFlexView.CreateLinearFlexibleView(scrnSize, LinearLayoutManager.HORIZONTAL, 4);

            layout = testingTarget.GetLayoutManager();
            recycler = testingTarget.GetRecycler();

            layout.ScrollHorizontallyBy(20, recycler, false);
            layout.ScrollHorizontallyBy(20, recycler, true);
            layout.ScrollHorizontallyBy(-20, recycler, false);
            layout.ScrollHorizontallyBy(-20, recycler, true);

            testingTarget.Dispose();

            tlog.Debug(tag, $"LinearLayoutManagerScrollHorizontallyBy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayoutManager ScrollVerticallyBy.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayoutManager.ScrollVerticallyBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void LinearLayoutManagerScrollVerticallyBy()
        {
            tlog.Debug(tag, $"LinearLayoutManagerScrollVerticallyBy START");

            var testingTarget = UtilityOfFlexView.CreateLinearFlexibleView(scrnSize, LinearLayoutManager.HORIZONTAL, 4);

            var layout = testingTarget.GetLayoutManager();
            var recycler = testingTarget.GetRecycler();

            layout.ScrollHorizontallyBy(20, recycler, false);
            testingTarget.Dispose();

            testingTarget = UtilityOfFlexView.CreateLinearFlexibleView(scrnSize, LinearLayoutManager.VERTICAL, 8);

            layout = testingTarget.GetLayoutManager();
            recycler = testingTarget.GetRecycler();

            layout.ScrollVerticallyBy(20, recycler, false);
            layout.ScrollVerticallyBy(20, recycler, true);
            layout.ScrollVerticallyBy(-20, recycler, false);
            layout.ScrollVerticallyBy(-20, recycler, true);

            testingTarget.Dispose();

            tlog.Debug(tag, $"LinearLayoutManagerScrollVerticallyBy END (OK)");
        }
    }
}
