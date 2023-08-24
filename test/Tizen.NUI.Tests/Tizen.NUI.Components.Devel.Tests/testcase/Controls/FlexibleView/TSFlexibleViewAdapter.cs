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
    [Description("Controls/FlexibleView/FlexibleViewAdapter")]
    public class FlexibleViewAdapterTest
    {
        private const string tag = "NUITEST";

        private Vector2 scrnSize;
        private ListBridge adapter;
        private FlexibleView horizontalFlexibleView;
        private LinearLayoutManager horizontalLayoutManager;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            scrnSize = new Vector2(1920, 1080);
        }

        [TearDown]
        public void Destroy()
        {
            scrnSize?.Dispose();
            tlog.Info(tag, "Destroy() is called!");
        }

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
                return viewHolder;
            }

            public override void OnBindViewHolder(FlexibleViewViewHolder holder, int position)
            {
                ListItemData listItemData = mDatas[position];

                ListItemView listItemView = holder.ItemView as ListItemView;
                listItemView.Name = "Item" + position;
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
                    if (previousFocusView.AdapterPosition % 2 == 0)
                        previousFocusView.ItemView.BackgroundColor = Color.Cyan;
                    else
                        previousFocusView.ItemView.BackgroundColor = Color.Yellow;
                }
                FlexibleViewViewHolder currentFocusView = flexibleView.FindViewHolderForAdapterPosition(currentFocus);
                if (currentFocusView != null)
                {
                    currentFocusView.ItemView.BackgroundColor = Color.Magenta;
                }
            }
        }

        private FlexibleView GetHorizontalFlexibleView()
        {
            horizontalFlexibleView = new FlexibleView();
            Assert.IsNotNull(horizontalFlexibleView, "should be not null");
            Assert.IsInstanceOf<FlexibleView>(horizontalFlexibleView, "should be an instance of testing target class!");

            horizontalFlexibleView.Name = "FlexibleView";
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

            return horizontalFlexibleView;
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewAdapter NotifyItemChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.FlexibleViewAdapter.NotifyItemChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewAdapterNotifyItemChanged()
        {
            tlog.Debug(tag, $"FlexibleViewAdapterNotifyItemChanged START");

            var testingTarget = GetHorizontalFlexibleView();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleView>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.GetAdapter().NotifyItemChanged(2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewAdapterNotifyItemChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewAdapter NotifyItemRangeChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleView.FlexibleViewAdapter.NotifyItemRangeChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewAdapterNotifyItemRangeChanged()
        {
            tlog.Debug(tag, $"FlexibleViewAdapterNotifyItemRangeChanged START");

            var testingTarget = GetHorizontalFlexibleView();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleView>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.GetAdapter().NotifyItemRangeChanged(2, 2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexibleViewAdapterNotifyItemRangeChanged END (OK)");
        }
    }
}
