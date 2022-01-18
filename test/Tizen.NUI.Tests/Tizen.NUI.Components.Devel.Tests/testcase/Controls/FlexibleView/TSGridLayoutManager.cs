using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/FlexibleView/LinearLayoutManager")]
    class TSGridLayoutManager
    {
        private const string tag = "NUITEST";
        private Vector2 scrnSize;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            scrnSize = new Vector2(1920, 1080);
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
            scrnSize?.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("GridLayoutManager constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.GridLayoutManager C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void GridLayoutManagerConstructor()
        {
            tlog.Debug(tag, $"GridLayoutManagerConstructor START");

            var testingTarget = new GridLayoutManager(2, GridLayoutManager.HORIZONTAL);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<GridLayoutManager>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GridLayoutManagerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayoutManager EnsureAnchorReady.")]
        [Property("SPEC", "Tizen.NUI.Components.GridLayoutManager EnsureAnchorReady")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void GridLayoutManagerEnsureAnchorReady()
        {
            tlog.Debug(tag, $"GridLayoutManagerEnsureAnchorReady START");

            var flexView = UtilityOfFlexView.CreateGridFlexibleView(scrnSize, GridLayoutManager.HORIZONTAL, 20);

            var layout = flexView.GetLayoutManager() as GridLayoutManager;
            var recycler = flexView.GetRecycler();
            var t = new Components.LinearLayoutManager.AnchorInfo()
            {
                Position = 6,
            };
            layout.EnsureAnchorReady(recycler, t, GridLayoutManager.LayoutState.LAYOUT_START);

            t.Position = 5;
            layout.EnsureAnchorReady(recycler, t, GridLayoutManager.LayoutState.ITEM_DIRECTION_TAIL);

            flexView.Dispose();
            tlog.Debug(tag, $"GridLayoutManagerEnsureAnchorReady END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayoutManager GetNextPosition.")]
        [Property("SPEC", "Tizen.NUI.Components.GridLayoutManager GetNextPosition")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void GridLayoutManagerGetNextPosition()
        {
            tlog.Debug(tag, $"GridLayoutManagerGetNextPosition START");

            var flexView = UtilityOfFlexView.CreateGridFlexibleView(scrnSize, GridLayoutManager.HORIZONTAL, 20);

            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Left);
            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Up);
            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Right);
            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Down);

            flexView.FocusedItemIndex = 10;
            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Up);
            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Down);
            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Left);
            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Right);

            flexView.Dispose();

            flexView = UtilityOfFlexView.CreateGridFlexibleView(scrnSize, GridLayoutManager.VERTICAL, 20);

            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Left);
            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Up);
            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Right);
            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Down);

            flexView.FocusedItemIndex = 10;
            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Up);
            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Down);
            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Left);
            flexView.MoveFocus(FlexibleViewLayoutManager.Direction.Right);

            flexView.Dispose();
        }
    }
}
