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
    class TSFlexibleViewLayoutManager
    {
        private const string tag = "NUITEST";

        public class ListItemData
        {
            private string str;

            public ListItemData(int i)
            {
                str = "Text" + i.ToString();
            }

            public string TextString
            {
                get
                {
                    return str;
                }
            }
        }

        public class ListItemView : View
        {
            private TextLabel mText;

            public ListItemView()
            {
                mText = new TextLabel();
                mText.WidthResizePolicy = ResizePolicyType.FillToParent;
                mText.HeightResizePolicy = ResizePolicyType.FillToParent;
                mText.PointSize = 22;
                mText.HorizontalAlignment = HorizontalAlignment.Center;
                mText.VerticalAlignment = VerticalAlignment.Center;
                Add(mText);
            }

            public string MainText
            {
                get
                {
                    return mText.Text;
                }
                set
                {
                    mText.Text = value;
                }
            }
        }

        public class ListBridge : FlexibleViewAdapter
        {
            private List<ListItemData> mDatas;

            public ListBridge(List<ListItemData> datas)
            {
                mDatas = datas;
            }

            public void InsertData(int position)
            {
                mDatas.Insert(position, new ListItemData(1000 + position));
                NotifyItemInserted(position);
            }

            public void RemoveData(int position)
            {
                mDatas.RemoveAt(position);
                NotifyItemRemoved(position);
            }

            public override FlexibleViewViewHolder OnCreateViewHolder(int viewType)
            {
                FlexibleViewViewHolder viewHolder = new FlexibleViewViewHolder(new ListItemView());
                //Console.WriteLine($"OnCreateViewHolder... viewType: {viewType} viewID: {viewHolder.ItemView.ID}");

                return viewHolder;
            }

            public override void OnBindViewHolder(FlexibleViewViewHolder holder, int position)
            {
                //Console.WriteLine($"OnBindItemView... position: {position}");
                ListItemData listItemData = mDatas[position];

                ListItemView listItemView = holder.ItemView as ListItemView;
                listItemView.Name = "Item" + position;
                //Random rd = new Random();
                listItemView.SizeWidth = 150;
                listItemView.SizeHeight = 60;
                if (listItemView != null)
                {
                    listItemView.MainText = String.Format("{0:D2}", position) + " : " + listItemData.TextString;
                }
                listItemView.Margin = new Extents(2, 2, 2, 2);
                if (position % 2 == 0)
                    listItemView.BackgroundColor = Color.Cyan;
                else
                    listItemView.BackgroundColor = Color.Yellow;
            }

            public override void OnDestroyViewHolder(FlexibleViewViewHolder holder)
            {
                //Console.WriteLine($"OnDestroyViewHolder... viewID: {holder.ItemView?.ID}");
                if (holder.ItemView != null)
                {
                    holder.ItemView.Dispose();
                }
            }

            public override int GetItemCount()
            {
                return mDatas.Count;
            }

            public override void OnFocusChange(FlexibleView flexibleView, int previousFocus, int currentFocus)
            {
                FlexibleViewViewHolder previousFocusView = flexibleView.FindViewHolderForAdapterPosition(previousFocus);
                if (previousFocusView != null)
                {
                    //Console.WriteLine($"previousFocus {previousFocus.AdapterPosition}");
                    if (previousFocusView.AdapterPosition % 2 == 0)
                        previousFocusView.ItemView.BackgroundColor = Color.Cyan;
                    else
                        previousFocusView.ItemView.BackgroundColor = Color.Yellow;
                    //previousFocus.SizeWidth = 150;
                    //previousFocus.SizeHeight = 60;
                    //NotifyItemChanged(previousFocus.AdapterPosition);
                }
                FlexibleViewViewHolder currentFocusView = flexibleView.FindViewHolderForAdapterPosition(currentFocus);
                if (currentFocusView != null)
                {
                    //Console.WriteLine($"currentFocus {currentFocus.AdapterPosition}");
                    currentFocusView.ItemView.BackgroundColor = Color.Magenta;
                    //currentFocus.SizeWidth = 200;
                    //currentFocus.SizeHeight = 100;
                    //NotifyItemChanged(currentFocus.AdapterPosition);
                }
            }

            public override void OnViewAttachedToWindow(FlexibleViewViewHolder holder)
            {
                //Console.WriteLine($"+Attached: {holder.AdapterPosition}");
            }

            public override void OnViewDetachedFromWindow(FlexibleViewViewHolder holder)
            {
                //Console.WriteLine($" --Detached: {holder.AdapterPosition}");
            }
        }

        private FlexibleView GetVerticalFlexibleView()
        {
            if (null == verticalFlexibleView)
            {
                verticalFlexibleView = new FlexibleView();

                Assert.IsNotNull(verticalFlexibleView, "should be not null");
                Assert.IsInstanceOf<FlexibleView>(verticalFlexibleView, "should be an instance of testing target class!");

                verticalFlexibleView = new FlexibleView();
                verticalFlexibleView.OnRelayout(scrnSize, null);

                verticalFlexibleView.Name = "RecyclerView1";
                verticalFlexibleView.WidthSpecification = 400;
                verticalFlexibleView.HeightSpecification = 450;
                verticalFlexibleView.Padding = new Extents(10, 10, 10, 10);
                verticalFlexibleView.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.4f);

                List<ListItemData> dataList = new List<ListItemData>();
                for (int i = 0; i < 8; ++i)
                {
                    dataList.Add(new ListItemData(i));
                }
                adapter = new ListBridge(dataList);
                verticalFlexibleView.SetAdapter(adapter);
                verticalFlexibleView.OnRelayout(scrnSize, null);

                verticalLayoutManager = new LinearLayoutManager(LinearLayoutManager.VERTICAL);
                verticalFlexibleView.SetLayoutManager(verticalLayoutManager);
                verticalFlexibleView.OnRelayout(scrnSize, null);

                verticalFlexibleView.Focusable = true;

                verticalFlexibleView.KeyEvent += RecyclerView_KeyEvent;
                verticalFlexibleView.FocusGained += FlexibleView_FocusGained;
                verticalFlexibleView.FocusLost += FlexibleView_FocusLost;
            }

            return verticalFlexibleView;
        }

        private FlexibleView GetHorizontalFlexibleView()
        {
            if (null == horizontalFlexibleView)
            {
                horizontalFlexibleView = new FlexibleView();

                Assert.IsNotNull(horizontalFlexibleView, "should be not null");
                Assert.IsInstanceOf<FlexibleView>(horizontalFlexibleView, "should be an instance of testing target class!");

                horizontalFlexibleView = new FlexibleView();
                horizontalFlexibleView.OnRelayout(scrnSize, null);

                horizontalFlexibleView.Name = "RecyclerView1";
                horizontalFlexibleView.WidthSpecification = 400;
                horizontalFlexibleView.HeightSpecification = 450;
                horizontalFlexibleView.Padding = new Extents(10, 10, 10, 10);
                horizontalFlexibleView.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.4f);

                List<ListItemData> dataList = new List<ListItemData>();
                for (int i = 0; i < 4; ++i)
                {
                    dataList.Add(new ListItemData(i));
                }
                adapter = new ListBridge(dataList);
                horizontalFlexibleView.SetAdapter(adapter);
                horizontalFlexibleView.OnRelayout(scrnSize, null);

                horizontalLayoutManager = new LinearLayoutManager(LinearLayoutManager.HORIZONTAL);
                horizontalFlexibleView.SetLayoutManager(horizontalLayoutManager);
                horizontalFlexibleView.OnRelayout(scrnSize, null);

                horizontalFlexibleView.Focusable = true;

                horizontalFlexibleView.KeyEvent += RecyclerView_KeyEvent;
                horizontalFlexibleView.FocusGained += FlexibleView_FocusGained;
                horizontalFlexibleView.FocusLost += FlexibleView_FocusLost;
            }

            return horizontalFlexibleView;
        }

        internal class FlexibleViewLayoutManagerImpl : FlexibleViewLayoutManager
        {
            public FlexibleViewLayoutManagerImpl() : base()
            { }

            public override void OnLayoutChildren(FlexibleViewRecycler recycler)
            {
                throw new NotImplementedException();
            }

            protected override int GetNextPosition(int position, Direction direction)
            {
                throw new NotImplementedException();
            }

            public override bool CanScrollHorizontally() 
            {
                return base.CanScrollHorizontally();
            }

            public override bool CanScrollVertically()
            {
                return base.CanScrollVertically();
            }

            public override float ScrollHorizontallyBy(float dy, FlexibleViewRecycler recycler, bool immediate)
            {
                return base.ScrollHorizontallyBy(dy, recycler, immediate);
            }

            public override float ScrollVerticallyBy(float dy, FlexibleViewRecycler recycler, bool immediate)
            {
                return base.ScrollVerticallyBy(dy, recycler, immediate);
            }

            public override float ComputeScrollExtent()
            {
                return base.ComputeScrollExtent();
            }

            public override float ComputeScrollOffset()
            {
                return base.ComputeScrollOffset();
            }

            public override float ComputeScrollRange()
            {
                return base.ComputeScrollRange();
            }

            public FlexibleViewViewHolder OnFindFirstVisibleItemView()
            {
                return base.FindFirstVisibleItemView();
            }

            public FlexibleViewViewHolder OnFindLastVisibleItemView()
            {
                return base.FindLastVisibleItemView();
            }

            internal override FlexibleViewViewHolder OnFocusSearchFailed(FlexibleViewViewHolder focused, FlexibleViewLayoutManager.Direction direction, FlexibleViewRecycler recycler)
            {
                return base.OnFocusSearchFailed(focused, direction, recycler);
            }
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
            verticalFlexibleView?.Dispose();
            horizontalFlexibleView?.Dispose();
            scrnSize?.Dispose();
            verticalLayoutManager?.Dispose();
            horizontalLayoutManager?.Dispose();
        }

        private FlexibleView verticalFlexibleView;
        private FlexibleView horizontalFlexibleView;
        private ListBridge adapter;
        private LinearLayoutManager verticalLayoutManager;
        private LinearLayoutManager horizontalLayoutManager;

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
        [Description("FlexibleViewLayoutManager OffsetChildrenHorizontal.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewLayoutManager.OffsetChildrenHorizontal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewLayoutManagerOffsetChildrenHorizontal()
        {
            tlog.Debug(tag, $"FlexibleViewLayoutManagerOffsetChildrenHorizontal START");

            var testingTarget = GetHorizontalFlexibleView();
            testingTarget.Padding = new Extents(20, 20, 120, 20);

            try
            {
                horizontalLayoutManager.OffsetChildrenHorizontal(0, true);
                horizontalLayoutManager.OffsetChildrenHorizontal(30, true);
                horizontalLayoutManager.OffsetChildrenHorizontal(30, false);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"FlexibleViewLayoutManagerOffsetChildrenHorizontal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewLayoutManager OffsetChildrenVertical.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewLayoutManager.OffsetChildrenVertical A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewLayoutManagerOffsetChildrenVertical()
        {
            tlog.Debug(tag, $"FlexibleViewLayoutManagerOffsetChildrenVertical START");

            var testingTarget = GetVerticalFlexibleView();
            testingTarget.Padding = new Extents(20, 20, 120, 20);

            try
            {
                verticalLayoutManager.OffsetChildrenVertical(0, true);
                verticalLayoutManager.OffsetChildrenVertical(30, true);
                verticalLayoutManager.OffsetChildrenVertical(30, false);

                verticalLayoutManager.StopScroll(true);
                verticalFlexibleView = null;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"FlexibleViewLayoutManagerOffsetChildrenVertical END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewLayoutManager CanScrollHorizontally.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewLayoutManager.CanScrollHorizontally M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewLayoutManagerCanScrollHorizontally()
        {
            tlog.Debug(tag, $"FlexibleViewLayoutManagerCanScrollHorizontally START");

            var testingTarget = new FlexibleViewLayoutManagerImpl();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewLayoutManager>(testingTarget, "should be an instance of testing target class!");

            var result = horizontalLayoutManager.CanScrollHorizontally();
            tlog.Debug(tag, "CanScrollHorizontally : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewLayoutManagerCanScrollHorizontally END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewLayoutManager CanScrollVertically.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewLayoutManager.CanScrollVertically M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewLayoutManagerCanScrollVertically()
        {
            tlog.Debug(tag, $"FlexibleViewLayoutManagerCanScrollVertically START");

            var testingTarget = new FlexibleViewLayoutManagerImpl();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewLayoutManager>(testingTarget, "should be an instance of testing target class!");

            var result = horizontalLayoutManager.CanScrollVertically();
            tlog.Debug(tag, "CanScrollVertically : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewLayoutManagerCanScrollVertically END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewLayoutManager ScrollHorizontallyBy.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewLayoutManager.ScrollHorizontallyBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewLayoutManagerScrollHorizontallyBy()
        {
            tlog.Debug(tag, $"FlexibleViewLayoutManagerScrollHorizontallyBy START");

            var testingTarget = new FlexibleViewLayoutManagerImpl();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewLayoutManager>(testingTarget, "should be an instance of testing target class!");

            using (FlexibleView view = new FlexibleView() { Padding = new Extents(10, 10, 10, 10) })
            {
                FlexibleViewRecycler recycler = new FlexibleViewRecycler(view);
                var result = testingTarget.ScrollHorizontallyBy(1.0f, recycler, false);
                tlog.Debug(tag, "ScrollHorizontallyBy : " + result);
            }
                
            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewLayoutManagerScrollHorizontallyBy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewLayoutManager ScrollVerticallyBy.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewLayoutManager.ScrollVerticallyBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewLayoutManagerScrollVerticallyBy()
        {
            tlog.Debug(tag, $"FlexibleViewLayoutManagerScrollVerticallyBy START");

            var testingTarget = new FlexibleViewLayoutManagerImpl();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewLayoutManager>(testingTarget, "should be an instance of testing target class!");

            using (FlexibleView view = new FlexibleView() { Padding = new Extents(10, 10, 10, 10) })
            {
                FlexibleViewRecycler recycler = new FlexibleViewRecycler(view);
                var result = testingTarget.ScrollVerticallyBy(1.0f, recycler, false);
                tlog.Debug(tag, "ScrollVerticallyBy : " + result);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewLayoutManagerScrollVerticallyBy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewLayoutManager ComputeScrollExtent.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewLayoutManager.ComputeScrollExtent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewLayoutManagerComputeScrollExtent()
        {
            tlog.Debug(tag, $"FlexibleViewLayoutManagerComputeScrollExtent START");

            var testingTarget = new FlexibleViewLayoutManagerImpl();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewLayoutManager>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.ComputeScrollExtent();
            tlog.Debug(tag, "ComputeScrollExtent : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewLayoutManagerComputeScrollExtent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewLayoutManager ComputeScrollOffset.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewLayoutManager.ComputeScrollOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewLayoutManagerComputeScrollOffset()
        {
            tlog.Debug(tag, $"FlexibleViewLayoutManagerComputeScrollOffset START");

            var testingTarget = new FlexibleViewLayoutManagerImpl();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewLayoutManager>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.ComputeScrollOffset();
            tlog.Debug(tag, "ComputeScrollOffset : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewLayoutManagerComputeScrollOffset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewLayoutManager ComputeScrollRange.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewLayoutManager.ComputeScrollRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewLayoutManagerComputeScrollRange()
        {
            tlog.Debug(tag, $"FlexibleViewLayoutManagerComputeScrollRange START");

            var testingTarget = new FlexibleViewLayoutManagerImpl();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewLayoutManager>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.ComputeScrollRange();
            tlog.Debug(tag, "ComputeScrollRange : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewLayoutManagerComputeScrollRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewLayoutManager RemoveAndRecycleViewAt.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewLayoutManager.RemoveAndRecycleViewAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewLayoutManagerRemoveAndRecycleViewAt()
        {
            tlog.Debug(tag, $"FlexibleViewLayoutManagerRemoveAndRecycleViewAt START");

            var testingTarget = GetVerticalFlexibleView();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleView>(testingTarget, "should be an instance of testing target class!");

            try
            {
                verticalLayoutManager.RemoveAndRecycleViewAt(0, testingTarget.GetRecycler());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewLayoutManagerRemoveAndRecycleViewAt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewLayoutManager FindFirstVisibleItemView.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewLayoutManager.FindFirstVisibleItemView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewLayoutManagerFindFirstVisibleItemView()
        {
            tlog.Debug(tag, $"FlexibleViewLayoutManagerFindFirstVisibleItemView START");

            var testingTarget = new FlexibleViewLayoutManagerImpl();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewLayoutManager>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.OnFindFirstVisibleItemView();
            tlog.Debug(tag, "FindFirstVisibleItemView : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewLayoutManagerFindFirstVisibleItemView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewLayoutManager FindLastVisibleItemView.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewLayoutManager.FindLastVisibleItemView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewLayoutManagerFindLastVisibleItemView()
        {
            tlog.Debug(tag, $"FlexibleViewLayoutManagerFindLastVisibleItemView START");

            var testingTarget = new FlexibleViewLayoutManagerImpl();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewLayoutManager>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.OnFindLastVisibleItemView();
            tlog.Debug(tag, "FindLastVisibleItemView : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewLayoutManagerFindLastVisibleItemView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewLayoutManager OnFocusSearchFailed.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewLayoutManager.OnFocusSearchFailed M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewLayoutManagerOnFocusSearchFailed()
        {
            tlog.Debug(tag, $"FlexibleViewLayoutManagerOnFocusSearchFailed START");

            var testingTarget = new FlexibleViewLayoutManagerImpl();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewLayoutManager>(testingTarget, "should be an instance of testing target class!");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                FlexibleViewViewHolder focused = new FlexibleViewViewHolder(view);

                using (FlexibleView recyclerView = new FlexibleView() { Padding = new Extents(10, 10, 10, 10) })
                {
                    FlexibleViewRecycler recycler = new FlexibleViewRecycler(recyclerView);

                    var result = testingTarget.OnFocusSearchFailed(focused, FlexibleViewLayoutManager.Direction.Down, recycler);
                    tlog.Debug(tag, "OnFocusSearchFailed : " + result);
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewLayoutManagerOnFocusSearchFailed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewLayoutManager RemoveAndRecycleViewAt.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewLayoutManager.RemoveAndRecycleViewAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewLayoutManagerOnLayoutComplete()
        {
            tlog.Debug(tag, $"FlexibleViewLayoutManagerOnLayoutComplete START");

            var testingTarget = GetVerticalFlexibleView();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleView>(testingTarget, "should be an instance of testing target class!");

            var vHelper = new VerticalHelper(verticalLayoutManager);
            try
            {
                vHelper.OnLayoutComplete();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewLayoutManagerOnLayoutComplete END (OK)");
        }
    }
}
