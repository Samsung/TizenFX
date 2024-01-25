using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Components.Devel.Tests
{
    public static class UtilityOfFlexView
    {
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

        public static FlexibleView CreateLinearFlexibleView(Vector2 scrnSize, int orientation, int itemCount)
        {
            var flexibleView = new FlexibleView();

            Assert.IsNotNull(flexibleView, "should be not null");
            Assert.IsInstanceOf<FlexibleView>(flexibleView, "should be an instance of testing target class!");

            Assert.IsNotNull(flexibleView.Padding, "should be not null");

            flexibleView.OnRelayout(scrnSize, null);

            flexibleView.Name = "RecyclerView1";
            flexibleView.WidthSpecification = 400;
            flexibleView.HeightSpecification = 450;
            flexibleView.Padding = new Extents(10, 10, 10, 10);
            flexibleView.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.4f);

            flexibleView.FocusedItemIndex = -1;
            flexibleView.FocusedItemIndex = 0;

            List<ListItemData> dataList = new List<ListItemData>();
            for (int i = 0; i < itemCount; ++i)
            {
                dataList.Add(new ListItemData(i));
            }

            var adapter = new ListBridge(dataList);
            flexibleView.SetAdapter(null);
            flexibleView.SetAdapter(adapter);
            flexibleView.OnRelayout(scrnSize, null);

            var layoutManager = new LinearLayoutManager(orientation);
            flexibleView.SetLayoutManager(null);
            flexibleView.SetLayoutManager(layoutManager);
            flexibleView.OnRelayout(scrnSize, null);

            flexibleView.Focusable = true;

            return flexibleView;
        }

        public static FlexibleView CreateGridFlexibleView(Vector2 scrnSize, int orientation, int itemCount)
        {
            var flexibleView = new FlexibleView();

            Assert.IsNotNull(flexibleView, "should be not null");
            Assert.IsInstanceOf<FlexibleView>(flexibleView, "should be an instance of testing target class!");

            Assert.IsNotNull(flexibleView.Padding, "should be not null");

            flexibleView.OnRelayout(scrnSize, null);

            flexibleView.Name = "RecyclerView1";
            flexibleView.WidthSpecification = 400;
            flexibleView.HeightSpecification = 450;
            flexibleView.Padding = new Extents(10, 10, 10, 10);
            flexibleView.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.4f);

            flexibleView.FocusedItemIndex = -1;
            flexibleView.FocusedItemIndex = 0;

            List<ListItemData> dataList = new List<ListItemData>();
            for (int i = 0; i < itemCount; ++i)
            {
                dataList.Add(new ListItemData(i));
            }

            var adapter = new ListBridge(dataList);
            flexibleView.SetAdapter(null);
            flexibleView.SetAdapter(adapter);
            flexibleView.OnRelayout(scrnSize, null);

            var layoutManager = new GridLayoutManager(3, orientation);
            flexibleView.SetLayoutManager(null);
            flexibleView.SetLayoutManager(layoutManager);
            flexibleView.OnRelayout(scrnSize, null);

            flexibleView.Focusable = true;

            return flexibleView;
        }
    }
}
