using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace NuiCommonUiSamples
{
    public class DropDown : IExample
    {
        private SampleLayout root;
        private Tizen.NUI.CommonUI.DropDown dropDown = null;
        private Tizen.NUI.CommonUI.DropDown dropDown2 = null;
        private ScrollBar scrollBar = null;
        private TextLabel text = null;

        private static string[] iconImage = new string[]
        {
            CommonResource.GetResourcePath() + "10. Drop Down/img_dropdown_fahrenheit.png",
            CommonResource.GetResourcePath() + "10. Drop Down/img_dropdown_celsius.png",
        };

        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            root = new SampleLayout();
            root.HeaderText = "DropDown";

            text = new TextLabel();
            text.Text = "DropDown Clicked item string is ";
            text.PointSize = 14;
            text.Size2D = new Size2D(880, 50);
            text.Position2D = new Position2D(100, 10);
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.MultiLine = true;
            root.Add(text);

            dropDown = new Tizen.NUI.CommonUI.DropDown("HeaderDropDown");
            dropDown.Size2D = new Size2D(1080, 108);
            dropDown.Position2D = new Position2D(0, 100);
            dropDown.ListSize2D = new Size2D(360, 500);
            dropDown.HeaderText = "Header area";
            dropDown.ButtonText = "Normal list 1";
            dropDown.ItemClickEvent += DropDownItemClickEvent;
            root.Add(dropDown);

            for (int i = 0; i < 8; i++)
            {
                Tizen.NUI.CommonUI.DropDown.DropDownItemData item = new Tizen.NUI.CommonUI.DropDown.DropDownItemData("TextListItem");
                item.Size2D = new Size2D(360, 96);
                item.Text = "Normal list " + i;
                dropDown.AddItem(item);
            }

            dropDown.SelectedItemIndex = 1;
            ////////Attach scrollbar///////////
            scrollBar = new ScrollBar();
            scrollBar.Direction = ScrollBar.DirectionType.Vertical;
            scrollBar.Position2D = new Position2D(394, 2);
            scrollBar.Size2D = new Size2D(4, 446);
            scrollBar.TrackColor = Color.Green;
            scrollBar.ThumbSize = new Size2D(4, 30);
            scrollBar.ThumbColor = Color.Yellow;
            scrollBar.TrackImageURL = CommonResource.GetResourcePath() + "component/c_progressbar/c_progressbar_white_buffering.png";
            dropDown.AttachScrollBar(scrollBar);

            //////////////////ListSpinner DropDown////////////////////////
            dropDown2 = new Tizen.NUI.CommonUI.DropDown("ListDropDown");
            dropDown2.Size2D = new Size2D(1080, 108);
            dropDown2.Position2D = new Position2D(0, 300);
            dropDown2.ListSize2D = new Size2D(360, 192);
            dropDown2.HeaderText = "List area";
            dropDown2.ButtonText = "Menu";
            root.Add(dropDown2);

            for (int i = 0; i < 2; i++)
            {
                Tizen.NUI.CommonUI.DropDown.DropDownItemData item = new Tizen.NUI.CommonUI.DropDown.DropDownItemData("IconListItem");
                item.Size2D = new Size2D(360, 96);
                item.IconResourceUrl = iconImage[i];
                dropDown2.AddItem(item);
            }

            dropDown2.SelectedItemIndex = 0;

            dropDown.RaiseToTop();
        }

        private void DropDownItemClickEvent(object sender, Tizen.NUI.CommonUI.DropDown.ItemClickEventArgs e)
        {
            text.Text = "DropDown Clicked item string is " + e.Text;
        }

        public void Deactivate()
        {
            if (root != null)
            {
                if (text != null)
                {
                    root.Remove(text);
                    text.Dispose();
                    text = null;
                }

                if (dropDown != null)
                {
                    if (scrollBar != null)
                    {
                        dropDown.DetachScrollBar();
                        scrollBar.Dispose();
                        scrollBar = null;
                    }

                    root.Remove(dropDown);
                    dropDown.Dispose();
                    dropDown = null;
                }

                if (dropDown2 != null)
                {
                    root.Remove(dropDown2);
                    dropDown2.Dispose();
                    dropDown2 = null;
                }

                root.Dispose();
            }
        }

        private void ButtonClickEvent(object sender, Tizen.NUI.CommonUI.Button.ClickEventArgs e)
        {
            Tizen.NUI.CommonUI.Button btn = sender as Tizen.NUI.CommonUI.Button;

        }
    }
}
