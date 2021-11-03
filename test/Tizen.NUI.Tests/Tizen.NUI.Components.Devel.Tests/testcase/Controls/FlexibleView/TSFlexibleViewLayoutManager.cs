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
    }
}
