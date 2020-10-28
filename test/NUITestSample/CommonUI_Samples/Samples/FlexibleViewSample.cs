using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using System.Collections.Generic;

namespace NuiCommonUiSamples
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

    public class ListBridge : Tizen.NUI.CommonUI.FlexibleView.Adapter
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

        public override Tizen.NUI.CommonUI.FlexibleView.ViewHolder OnCreateViewHolder(int viewType)
        {
            Tizen.NUI.CommonUI.FlexibleView.ViewHolder viewHolder = new Tizen.NUI.CommonUI.FlexibleView.ViewHolder(new ListItemView());
            //Console.WriteLine($"OnCreateViewHolder... viewType: {viewType} viewID: {viewHolder.ItemView.ID}");

            return viewHolder;
        }

        public override void OnBindViewHolder(Tizen.NUI.CommonUI.FlexibleView.ViewHolder holder, int position)
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

        public override void OnDestroyViewHolder(Tizen.NUI.CommonUI.FlexibleView.ViewHolder holder)
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

        public override void OnFocusChange(Tizen.NUI.CommonUI.FlexibleView flexibleView, int previousFocus, int currentFocus)
        {
            Tizen.NUI.CommonUI.FlexibleView.ViewHolder previousFocusView = flexibleView.FindViewHolderForAdapterPosition(previousFocus);
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
            Tizen.NUI.CommonUI.FlexibleView.ViewHolder currentFocusView = flexibleView.FindViewHolderForAdapterPosition(currentFocus);
            if (currentFocusView != null)
            {
                //Console.WriteLine($"currentFocus {currentFocus.AdapterPosition}");
                currentFocusView.ItemView.BackgroundColor = Color.Magenta;
                //currentFocus.SizeWidth = 200;
                //currentFocus.SizeHeight = 100;
                //NotifyItemChanged(currentFocus.AdapterPosition);
            }
        }

        public override void OnViewAttachedToWindow(Tizen.NUI.CommonUI.FlexibleView.ViewHolder holder)
        {
            //Console.WriteLine($"+Attached: {holder.AdapterPosition}");
        }

        public override void OnViewDetachedFromWindow(Tizen.NUI.CommonUI.FlexibleView.ViewHolder holder)
        {
            //Console.WriteLine($" --Detached: {holder.AdapterPosition}");
        }

    }

    public class FlexibleView : IExample
    {
        private SampleLayout root;
        private Tizen.NUI.CommonUI.FlexibleView flexibleView1;
        private Tizen.NUI.CommonUI.FlexibleView flexibleView2;
        private ListBridge adapter;

        private ScrollBar scrollBar1;
        private ScrollBar scrollBar2;

        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            root = new SampleLayout(false);
            root.HeaderText = "FlexibleView";

            flexibleView1 = new Tizen.NUI.CommonUI.FlexibleView();
            flexibleView1.Name = "FlexibleView1";
            flexibleView1.Position2D = new Position2D(300, 20);
            flexibleView1.Size2D = new Size2D(400, 450);
            flexibleView1.Padding = new Extents(10, 10, 10, 10);
            flexibleView1.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.4f);

            List<ListItemData> dataList = new List<ListItemData>();
            for (int i = 0; i < 131; ++i)
            {
                dataList.Add(new ListItemData(i));
            }
            adapter = new ListBridge(dataList);
            flexibleView1.SetAdapter(adapter);

            LinearLayoutManager layoutManager1 = new LinearLayoutManager(LinearLayoutManager.VERTICAL);
            //GridLayoutManager layoutManager1 = new GridLayoutManager(3, LinearLayoutManager.VERTICAL);
            flexibleView1.SetLayoutManager(layoutManager1);

            root.Add(flexibleView1);

            scrollBar1 = new ScrollBar("DAScrollbar");
            scrollBar1.Direction = ScrollBar.DirectionType.Vertical;
            scrollBar1.Position2D = new Position2D(394, 2);
            scrollBar1.Size2D = new Size2D(4, 446);
            scrollBar1.ThumbSize = new Size2D(4, 30);
            flexibleView1.AttachScrollBar(scrollBar1);


            flexibleView2 = new Tizen.NUI.CommonUI.FlexibleView();
            flexibleView2.Name = "FlexibleView2";
            flexibleView2.Position2D = new Position2D(150, 520);
            flexibleView2.Size2D = new Size2D(700, 200);
            flexibleView2.Padding = new Extents(10, 10, 10, 10);
            flexibleView2.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.4f);

            flexibleView2.SetAdapter(adapter);

            GridLayoutManager layoutManager2 = new GridLayoutManager(3, LinearLayoutManager.HORIZONTAL);
            flexibleView2.SetLayoutManager(layoutManager2);

            root.Add(flexibleView2);

            scrollBar2 = new ScrollBar("DAScrollbar");
            scrollBar2.Position2D = new Position2D(2, 194);
            scrollBar2.Size2D = new Size2D(696, 4);
            scrollBar2.ThumbSize = new Size2D(30, 4);
            flexibleView2.AttachScrollBar(scrollBar2);

        }


        public void Deactivate()
        {
            flexibleView1.DetachScrollBar();
            scrollBar1.Dispose();
            flexibleView2.DetachScrollBar();
            scrollBar2.Dispose();

            root.Remove(flexibleView1);
            flexibleView1.Dispose();
            root.Remove(flexibleView2);
            flexibleView2.Dispose();

            root.Dispose();
        }
    }
}
