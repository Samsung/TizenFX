using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/FlexibleView/FlexibleView")]
    class TSFlexibleView
    {
        private const string tag = "NUITEST";

        private FlexibleView GetFlexibleView()
        {
            if (null == flexibleView)
            {
                flexibleView = UtilityOfFlexView.CreateLinearFlexibleView(scrnSize, LinearLayoutManager.VERTICAL, 131);

                flexibleView.ItemClicked += FlexibleViewItemClicked;
                flexibleView.ItemClicked -= FlexibleViewItemClicked;

                flexibleView.ItemTouch += FlexibleViewItemTouch;
                flexibleView.ItemTouch -= FlexibleViewItemTouch;

                flexibleView.StyleChanged += FlexibleViewStyleChanged;
                flexibleView.StyleChanged -= FlexibleViewStyleChanged;

                flexibleView.Focusable = true;

                flexibleView.KeyEvent += RecyclerView_KeyEvent;
                flexibleView.FocusGained += FlexibleView_FocusGained;
                flexibleView.FocusLost += FlexibleView_FocusLost;
            }

            return flexibleView;
        }

        private void FlexibleViewStyleChanged(object sender, NUI.StyleManager.StyleChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FlexibleViewItemTouch(object sender, FlexibleViewItemTouchEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FlexibleViewItemClicked(object sender, FlexibleViewItemClickedEventArgs e)
        {
            throw new NotImplementedException();
        }

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
            flexibleView?.Dispose();
            scrnSize?.Dispose();
        }

        private FlexibleView flexibleView;

        private Vector2 scrnSize;

        private View onPreFocusChange(object sender, NUI.FocusManager.PreFocusChangeEventArgs e)
        {
            return e.CurrentView;
        }

        private void FlexibleView_FocusLost(object sender, EventArgs e)
        {
            View flexibleView = sender as View;
            flexibleView.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.4f);
        }

        private void FlexibleView_FocusGained(object sender, EventArgs e)
        {
            View flexibleView = sender as View;
            flexibleView.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.8f);
        }

        private bool RecyclerView_KeyEvent(object source, View.KeyEventArgs e)
        {
            FlexibleView flexibleView = source as FlexibleView;
            return true;
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleView Padding.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.Padding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewPadding()
        {
            tlog.Debug(tag, $"EmptySource START");

            var testingTarget = GetFlexibleView();

            testingTarget.Padding = new Extents(10, 10, 10, 10);
            Assert.IsNotNull(testingTarget.Padding, "should not be null.");

            tlog.Debug(tag, $"EmptySource END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleView Padding.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.Padding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewPaddingNull()
        {
            tlog.Debug(tag, $"EmptySource START");

            var testingTarget = GetFlexibleView();
            Assert.IsNotNull(testingTarget.Padding, "should not be null.");
            tlog.Debug(tag, $"EmptySource END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleView FocusedItemIndex.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.FocusedItemIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewFocusedItemIndex()
        {
            tlog.Debug(tag, $"FlexibleViewFocusedItemIndex START");

            var testingTarget = GetFlexibleView();
            testingTarget.Padding = new Extents(20, 20, 120, 20);

            try
            {
                testingTarget.FocusedItemIndex = 1;
                testingTarget.OnRelayout(scrnSize, null);
                Assert.AreEqual(testingTarget.FocusedItemIndex, 1, "should be equal.");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"FlexibleViewFocusedItemIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleView SetAdapter.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.SetAdapter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewSetAdapter()
        {
            tlog.Debug(tag, $"FlexibleViewSetAdapter START");

            var testingTarget = GetFlexibleView();

            testingTarget.FocusedItemIndex = 1;
            testingTarget.OnRelayout(scrnSize, null);

            var adapter = testingTarget.GetAdapter() as UtilityOfFlexView.ListBridge;
            adapter.InsertData(0);
            adapter.RemoveData(0);
            adapter.RemoveData(1);
            testingTarget.OnRelayout(scrnSize, null);

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewSetAdapter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleView FindViewHolderForLayoutPosition.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.FindViewHolderForLayoutPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewFindViewHolderForLayoutPosition()
        {
            tlog.Debug(tag, $"FlexibleViewFindViewHolderForLayoutPosition START");

            EventHandler onRelayout = (s, e) => {};

            var testingTarget = GetFlexibleView();
            testingTarget.Relayout += onRelayout;

            testingTarget.OnRelayout(scrnSize, null);

            try
            {
                testingTarget.FindViewHolderForLayoutPosition(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            Window.Instance.Remove(testingTarget);
            testingTarget.Relayout -= onRelayout;

            tlog.Debug(tag, $"FlexibleViewFindViewHolderForLayoutPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleView FindViewHolderForAdapterPosition.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.FindViewHolderForAdapterPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewFindViewHolderForAdapterPosition()
        {
            tlog.Debug(tag, $"FlexibleViewFindViewHolderForAdapterPosition START");

            var testingTarget = GetFlexibleView();

            Window.Instance.Add(testingTarget);

            try
            {
                testingTarget.FindViewHolderForLayoutPosition(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            if (testingTarget != null)
            {
                Window.Instance.Remove(testingTarget);
            }
            tlog.Debug(tag, $"FlexibleViewFindViewHolderForAdapterPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleView ScrollToPositionWithOffset.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.ScrollToPositionWithOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewScrollToPositionWithOffset()
        {
            tlog.Debug(tag, $"FlexibleViewScrollToPositionWithOffset START");

            var testingTarget = GetFlexibleView();

            Window.Instance.Add(testingTarget);

            try
            {
                testingTarget.ScrollToPositionWithOffset(10, 10);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            if (testingTarget != null)
            {
                Window.Instance.Remove(testingTarget);
            }
            tlog.Debug(tag, $"FlexibleViewScrollToPositionWithOffset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleView MoveFocus.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.MoveFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewMoveFocus()
        {
            tlog.Debug(tag, $"FlexibleViewMoveFocus START");

            var testingTarget = GetFlexibleView();

            Window.Instance.Add(testingTarget);

            try
            {
                testingTarget.MoveFocus(FlexibleViewLayoutManager.Direction.Down);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            if (testingTarget != null)
            {
                Window.Instance.Remove(testingTarget);
            }
            tlog.Debug(tag, $"FlexibleViewMoveFocus END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("FlexibleView MoveFocus.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.MoveFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewMoveFocusUp()
        {
            tlog.Debug(tag, $"FlexibleViewMoveFocusUp START");
            var testingTarget = GetFlexibleView();

            Window.Instance.Add(testingTarget);

            try
            {
                testingTarget.MoveFocus(FlexibleViewLayoutManager.Direction.Up);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            if (testingTarget != null)
            {
                Window.Instance.Remove(testingTarget);
            }
            tlog.Debug(tag, $"FlexibleViewMoveFocusUp END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("FlexibleView MoveFocus.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.MoveFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewMoveFocusLeft()
        {
            tlog.Debug(tag, $"FlexibleViewMoveFocusLeft START");

            var testingTarget = GetFlexibleView();

            try
            {
                testingTarget.MoveFocus(FlexibleViewLayoutManager.Direction.Left);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            if (testingTarget != null)
            {
                Window.Instance.Remove(testingTarget);
            }
            tlog.Debug(tag, $"FlexibleViewMoveFocusLeft END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("FlexibleView MoveFocus.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.MoveFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewMoveFocusRight()
        {
            tlog.Debug(tag, $"FlexibleViewMoveFocusRight START");

            var testingTarget = GetFlexibleView();

            Window.Instance.Add(testingTarget);

            try
            {
                testingTarget.MoveFocus(FlexibleViewLayoutManager.Direction.Right);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            if (testingTarget != null)
            {
                Window.Instance.Remove(testingTarget);
            }
            tlog.Debug(tag, $"FlexibleViewMoveFocusRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleView AttachScrollBar.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.AttachScrollBar M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        [Obsolete]
        public void FlexibleViewAttachScrollBar()
        {
            tlog.Debug(tag, $"FlexibleViewAttachScrollBar START");

            var testingTarget = GetFlexibleView();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleView>(testingTarget, "should be an instance of testing target class!");

            var scrollBar = new ScrollBar();
            scrollBar.Direction = ScrollBar.DirectionType.Vertical;
            scrollBar.Position = new Position(394, 2);
            scrollBar.WidthSpecification = 4;
            scrollBar.HeightSpecification = 446;
            scrollBar.TrackColor = Color.Green;
            scrollBar.ThumbSize = new Size(4, 30);
            scrollBar.ThumbColor = Color.Yellow;

            try
            {
                testingTarget.AttachScrollBar(null);
                testingTarget.AttachScrollBar(scrollBar);
                testingTarget.FocusedItemIndex = 10;
                testingTarget.OnRelayout(scrnSize, null);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            scrollBar.Dispose();
            tlog.Debug(tag, $"FlexibleViewAttachScrollBar END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleView DetachScrollBar.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.DetachScrollBar M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewDetachScrollBar()
        {
            tlog.Debug(tag, $"FlexibleViewDetachScrollBar START");

            var testingTarget = GetFlexibleView();

            var scrollBar = new ScrollBar();
            scrollBar.Direction = ScrollBar.DirectionType.Vertical;
            scrollBar.Position = new Position(394, 2);
            scrollBar.WidthSpecification = 4;
            scrollBar.HeightSpecification = 446;
            scrollBar.TrackColor = Color.Green;
            scrollBar.ThumbSize = new Size(4, 30);
            scrollBar.ThumbColor = Color.Yellow;

            try
            {
                testingTarget.AttachScrollBar(scrollBar);
                testingTarget.DetachScrollBar();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            scrollBar.Dispose();
            tlog.Debug(tag, $"FlexibleViewDetachScrollBar END (OK)");
        }
    }
}
