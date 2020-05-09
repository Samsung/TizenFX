using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
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

    public class ListBridge : FlexibleView.Adapter
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

        public override FlexibleView.ViewHolder OnCreateViewHolder(int viewType)
        {
            FlexibleView.ViewHolder viewHolder = new FlexibleView.ViewHolder(new ListItemView());
            //Console.WriteLine($"OnCreateViewHolder... viewType: {viewType} viewID: {viewHolder.ItemView.ID}");

            return viewHolder;
        }

        public override void OnBindViewHolder(FlexibleView.ViewHolder holder, int position)
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

        public override void OnDestroyViewHolder(FlexibleView.ViewHolder holder)
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
            FlexibleView.ViewHolder previousFocusView = flexibleView.FindViewHolderForAdapterPosition(previousFocus);
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
            FlexibleView.ViewHolder currentFocusView = flexibleView.FindViewHolderForAdapterPosition(currentFocus);
            if (currentFocusView != null)
            {
                //Console.WriteLine($"currentFocus {currentFocus.AdapterPosition}");
                currentFocusView.ItemView.BackgroundColor = Color.Magenta;
                //currentFocus.SizeWidth = 200;
                //currentFocus.SizeHeight = 100;
                //NotifyItemChanged(currentFocus.AdapterPosition);
            }
        }

        public override void OnViewAttachedToWindow(FlexibleView.ViewHolder holder)
        {
            //Console.WriteLine($"+Attached: {holder.AdapterPosition}");
        }

        public override void OnViewDetachedFromWindow(FlexibleView.ViewHolder holder)
        {
            //Console.WriteLine($" --Detached: {holder.AdapterPosition}");
        }
    }

    public class FlexibleViewSample : IExample
    {
        private FlexibleView flexibleView1;
        private FlexibleView flexibleView2;
        private ListBridge adapter;

        private ScrollBar scrollBar1;
        private ScrollBar scrollBar2;

        private View root, parent;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            root = new View()
            {
                Size = new Size(1920, 1080),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
            };
            window.Add(root);

            parent = new View()
            {
                Position = new Position(300, 300),
                Size = new Size(1150, 450)
            };
            parent.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                LinearAlignment = LinearLayout.Alignment.Bottom,
                CellPadding = new Size(50, 50)
            };
            root.Add(parent);

            // Create vertical flexibleView
            flexibleView1 = new FlexibleView();
            flexibleView1.Name = "RecyclerView1";
            flexibleView1.WidthSpecification = 400;
            flexibleView1.HeightSpecification = 450;
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
            flexibleView1.SetLayoutManager(layoutManager1);

            flexibleView1.FocusedItemIndex = 0;

            parent.Add(flexibleView1);

            flexibleView1.Focusable = true;

            flexibleView1.KeyEvent += RecyclerView_KeyEvent;
            flexibleView1.FocusGained += FlexibleView_FocusGained;
            flexibleView1.FocusLost += FlexibleView_FocusLost;

            scrollBar1 = new ScrollBar();
            scrollBar1.Direction = ScrollBar.DirectionType.Vertical;
            scrollBar1.Position = new Position(394, 2);
            scrollBar1.WidthSpecification = 2;
            scrollBar1.HeightSpecification = 446;
            scrollBar1.TrackImage.BackgroundColor = Color.Green;
            scrollBar1.ThumbImage.Size = new Size(4, 30);
            scrollBar1.ThumbImage.BackgroundColor = Color.Yellow;
            scrollBar1.TrackImage.ResourceUrl = CommonResource.GetTVResourcePath() + "component/c_progressbar/c_progressbar_white_buffering.png";
            flexibleView1.AttachScrollBar(scrollBar1);

            // Create horizontal flexibleView
            flexibleView2 = new FlexibleView();
            flexibleView2.Name = "RecyclerView2";
            flexibleView2.WidthSpecification = 700;
            flexibleView2.HeightSpecification = 200;
            flexibleView2.Padding = new Extents(10, 10, 10, 10);
            flexibleView2.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.4f);

            flexibleView2.SetAdapter(adapter);

            GridLayoutManager layoutManager2 = new GridLayoutManager(3, LinearLayoutManager.HORIZONTAL);
            flexibleView2.SetLayoutManager(layoutManager2);

            flexibleView2.FocusedItemIndex = 0;

            parent.Add(flexibleView2);

            flexibleView2.Focusable = true;

            flexibleView2.KeyEvent += RecyclerView_KeyEvent;
            flexibleView2.FocusGained += FlexibleView_FocusGained;
            flexibleView2.FocusLost += FlexibleView_FocusLost;

            scrollBar2 = new ScrollBar();
            scrollBar2.Direction = ScrollBar.DirectionType.Horizontal;
            scrollBar2.Position = new Position(2, 194);
            scrollBar2.WidthSpecification = 696;
            scrollBar2.HeightSpecification = 4;
            scrollBar2.TrackImage.BackgroundColor = Color.Green;
            scrollBar2.ThumbImage.Size = new Size(30, 4);
            scrollBar2.ThumbImage.BackgroundColor = Color.Yellow;
            scrollBar2.TrackImage.ResourceUrl = CommonResource.GetTVResourcePath() + "component/c_progressbar/c_progressbar_white_buffering.png";
            flexibleView2.AttachScrollBar(scrollBar2);

            FocusManager.Instance.SetCurrentFocusView(flexibleView1);
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
            return ProcessKey(flexibleView, e.Key);
        }

        private bool ProcessKey(FlexibleView flexibleView, Key key)
        {
            if (key.State == Key.StateType.Down)
            {
                if (key.KeyPressedName == "Up")
                {
                    flexibleView.MoveFocus(FlexibleView.LayoutManager.Direction.Up);
                }
                else if (key.KeyPressedName == "Down")
                {
                    flexibleView.MoveFocus(FlexibleView.LayoutManager.Direction.Down);
                }
                if (key.KeyPressedName == "Left")
                {
                    flexibleView.MoveFocus(FlexibleView.LayoutManager.Direction.Left);
                }
                else if (key.KeyPressedName == "Right")
                {
                    flexibleView.MoveFocus(FlexibleView.LayoutManager.Direction.Right);
                }
                else if (key.KeyPressedName == "0")
                {
                    if (flexibleView == flexibleView1)
                    {
                        FocusManager.Instance.SetCurrentFocusView(flexibleView2);
                    }
                    else if (flexibleView == flexibleView2)
                    {
                        FocusManager.Instance.SetCurrentFocusView(flexibleView1);
                    }
                }
                else if (key.KeyPressedName == "1")
                {
                    adapter.InsertData(1);
                }
                else if (key.KeyPressedName == "2")
                {
                    adapter.RemoveData(1);
                }
                else if (key.KeyPressedName == "8")
                {
                    flexibleView.FocusedItemIndex = 0;
                }
                else if (key.KeyPressedName == "9")
                {
                    flexibleView.FocusedItemIndex = 15;
                }
                else if (key.KeyPressedName == "7")
                {
                }
            }

            return false;
        }

        public void Deactivate()
        {
            flexibleView1.DetachScrollBar();
            scrollBar1.Dispose();
            scrollBar1 = null;
            flexibleView2.DetachScrollBar();
            scrollBar2.Dispose();
            scrollBar2 = null;

            parent.Remove(flexibleView1);
            flexibleView1.Dispose();
            flexibleView1 = null;
            parent.Remove(flexibleView2);
            flexibleView2.Dispose();
            flexibleView2 = null;

            root.Remove(parent);
            parent.Dispose();
            parent = null;

            NUIApplication.GetDefaultWindow().Remove(root);
            root.Dispose();
            root = null;
        }
    }
}
