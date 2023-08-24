using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace NuiCommonUiSamples
{
    public class Tab : IExample
    {
        private SampleLayout root;
        private Tizen.NUI.CommonUI.Tab tab = null;
        private Tizen.NUI.CommonUI.Button[] button = new Tizen.NUI.CommonUI.Button[2];
        private int num = 2;

        private static string[] mode = new string[]
        {
            "LargeTab",
            "Small Tab",
        };

        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            root = new SampleLayout();
            root.HeaderText = "Tab";

            tab = new Tizen.NUI.CommonUI.Tab("Tab");
            tab.IsNatureTextWidth = false;
            tab.Size2D = new Size2D(1080, 108);
            tab.Position2D = new Position2D(0, 300);
            tab.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            root.Add(tab);

            for (int i = 0; i < 3; i++)
            {
                Tizen.NUI.CommonUI.Tab.TabItemData item = new Tizen.NUI.CommonUI.Tab.TabItemData();
                item.Text = "Tab " + i;
                if (i == 1)
                {
                    item.Text = "Long long Tab " + i;
                }
                tab.AddItem(item);
            }

            for (int i = 0; i < num; i++)
            {
                button[i] = new Tizen.NUI.CommonUI.Button("ServiceButton");
                button[i].Size2D = new Size2D(240, 80);
                button[i].Position2D = new Position2D(280 + i * 260, 700);
                button[i].Text = mode[i];
                button[i].ClickEvent += ButtonClickEvent;
                root.Add(button[i]);
            }
        }

        public void Deactivate()
        {
            if (root != null)
            {
                if (tab != null)
                {
                    root.Remove(tab);
                    tab.Dispose();
                    tab = null;
                }

                for (int i = 0; i < num; i++)
                {
                    if (button[i] != null)
                    {
                        root.Remove(button[i]);
                        button[i].Dispose();
                        button[i] = null;
                    }
                }

                root.Dispose();
            }
        }

        private void ButtonClickEvent(object sender, Tizen.NUI.CommonUI.Button.ClickEventArgs e)
        {
            Tizen.NUI.CommonUI.Button btn = sender as Tizen.NUI.CommonUI.Button;
            if (button[0] == btn)
            {
                tab.IsNatureTextWidth = false;
            }
            else if (button[1] == btn)
            {
                tab.IsNatureTextWidth = true;
            }

            //tab.DeleteItem(0);

            //Tab.TabItemData item = new Tab.TabItemData();
            //item.Text = "insert Tab ";
            //tab.InsertItem(item, 1);
        }
    }
}
