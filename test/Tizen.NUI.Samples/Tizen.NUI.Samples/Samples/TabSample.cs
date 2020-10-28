using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class TabSample : IExample
    {
        private View root;
        private View[] parentView = new View[3];

        private TextLabel[] createText = new TextLabel[2];
        private Tab tab = null;
        private Tab tab2 = null;
        private Button button = null;
        private Button button2 = null;
        private int index = 0;

        private static string[] mode = new string[]
        {
            "Utility Tab",
            "Family Tab",
            "Food Tab",
            "Kitchen Tab",
        };
        private static Color[] color = new Color[]
        {
        new Color(0.05f, 0.63f, 0.9f, 1),//#ff0ea1e6 Utility
        new Color(0.14f, 0.77f, 0.28f, 1),//#ff24c447 Family
        new Color(0.75f, 0.46f, 0.06f, 1),//#ffec7510 Food
        new Color(0.59f, 0.38f, 0.85f, 1),//#ff9762d9 Kitchen
        };

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = new Size(1920, 1080),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
            };
            root.Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical };
            window.Add(root);

            CreateTextView();
            CreateTabView();
            CreateButtonView();
        }
        private void CreateTextView()
        {
            // Init parent of TextView
            parentView[0] = new View();
            parentView[0].Size = new Size(1920, 300);
            parentView[0].Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Horizontal, LinearAlignment = LinearLayout.Alignment.Center, CellPadding = new Size2D(100, 0) };
            root.Add(parentView[0]);

            for (int i = 0; i < 2; i++)
            {
                createText[i] = new TextLabel();
                createText[i].Size = new Size(500, 100);
                createText[i].PointSize = 20.0f;
                createText[i].BackgroundColor = Color.Magenta;
                createText[i].HorizontalAlignment = HorizontalAlignment.Center;
                createText[i].VerticalAlignment = VerticalAlignment.Center;
                createText[i].MultiLine = true;
                parentView[0].Add(createText[i]);
            }

            // Text of "Create Switch just by Properties"
            createText[0].Text = "Create Tab just by Properties";

            // Text of "Create Switch just by Style"
            createText[1].Text = "Create Tab just by Style";
        }

        private void CreateTabView()
        {
            // Init parent of TabView
            parentView[1] = new View();
            parentView[1].Size = new Size(1920, 200);
            parentView[1].Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Horizontal, LinearAlignment = LinearLayout.Alignment.Center, CellPadding = new Size2D(100, 0) };
            root.Add(parentView[1]);

            ///////////////////////////////////////////////Create by Property//////////////////////////////////////////////////////////
            tab = new Tab();
            tab.Size = new Size(700, 108);
            tab.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            tab.Underline.Size = new Size(1, 3);
            tab.Underline.BackgroundColor = color[0];
            tab.PointSize = 25;
            tab.TextColorSelector = new ColorSelector
            {
                Normal = Color.Black,
                Selected = color[0],
            };
            tab.ItemChangedEvent += TabItemChangedEvent;
            parentView[1].Add(tab);

            for (int i = 0; i < 3; i++)
            {
                Tab.TabItemData item = new Tab.TabItemData();
                item.Text = "Tab " + i;
                if (i == 1)
                {
                    item.Text = "Long Tab " + i;
                }
                tab.AddItem(item);
            }
            tab.SelectedItemIndex = 0;

            ///////////////////////////////////////////////Create by Style//////////////////////////////////////////////////////////
            TabStyle st = new TabStyle
            {
                //IsNatureTextWidth = false,
                ItemPadding = new Extents(56, 56, 1, 0),
                UnderLine = new ViewStyle
                {
                    Size = new Size(1, 3),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                    BackgroundColor = new Selector<Color> { All = color[0] },
                },
                Text = new TextLabelStyle
                {
                    PointSize = new Selector<float?> { All = 25 },
                    TextColor = new Selector<Color>
                    {
                        Normal = Color.Black,
                        Selected = color[0],
                    },
                },
            };

            tab2 = new Tab(st);
            tab2.Size = new Size(500, 108);
            tab2.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            tab2.ItemChangedEvent += Tab2ItemChangedEvent;
            parentView[1].Add(tab2);

            for (int i = 0; i < 3; i++)
            {
                Tab.TabItemData item = new Tab.TabItemData();
                item.Text = "Tab " + i;
                tab2.AddItem(item);
            }
            tab2.SelectedItemIndex = 0;
        }

        private void CreateButtonView()
        {
            // Init parent of ButtonView
            parentView[2] = new View();
            parentView[2].Size = new Size(1920, 200);
            parentView[2].Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Horizontal, LinearAlignment = LinearLayout.Alignment.Center, CellPadding = new Size2D(100, 0) };
            root.Add(parentView[2]);

            // Create Buttons
            var buttonStyle = new ButtonStyle()
            {
                Size = new Size(300, 80),
                Overlay = new ImageViewStyle()
                {
                    ResourceUrl = new Selector<string>
                    {
                        Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png",
                        Other = ""
                    },
                    Border = new Rectangle(5, 5, 5, 5)
                },
                Text = new TextLabelStyle()
                {
                    TextColor = new Selector<Color>
                    {
                        Normal = new Color(0, 0, 0, 1),
                        Pressed = new Color(0, 0, 0, 0.7f),
                        Selected = new Color(0.058f, 0.631f, 0.92f, 1),
                        Disabled = new Color(0, 0, 0, 0.4f)
                    },
                    PointSize = 18,
                },
                BackgroundImage = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_normal.png",
                BackgroundImageBorder = new Rectangle(5, 5, 5, 5),
            };

            // Button of switching mode
            button = new Button(buttonStyle);
            button.Size = new Size(500, 80);
            button.TextLabel.Text = mode[index];
            button.Clicked += ButtonClicked;
            parentView[2].Add(button);

            // Button of LayoutDirection
            button2 = new Button(buttonStyle);
            button2.Size = new Size(500, 80);
            button2.TextLabel.Text = "LayoutDirection is left to right";
            button2.Clicked += ButtonClicked2;
            parentView[2].Add(button2);
        }

        private void TabItemChangedEvent(object sender, Tab.ItemChangedEventArgs e)
        {
            createText[0].Text = "Create Tab just by properties, Selected index from " + e.PreviousIndex + " to " + e.CurrentIndex;
        }

        public void Deactivate()
        {
            if (root != null)
            {
                if (button != null)
                {
                    button.Dispose();
                    button = null;
                }

                if (button2 != null)
                {
                    button2.Dispose();
                    button2 = null;
                }

                if (tab != null)
                {
                    tab.Dispose();
                    tab = null;
                }

                if (tab2 != null)
                {
                    tab2.Dispose();
                    tab2 = null;
                }

                if (createText[0] != null)
                {
                    createText[0].Dispose();
                    createText[0] = null;
                }

                if (createText[1] != null)
                {
                    createText[1].Dispose();
                    createText[1] = null;
                }

                for (int j = 0; j < 3; j++)
                {
                    if (parentView[j] != null)
                    {
                        parentView[j].Dispose();
                        parentView[j] = null;
                    }
                }

                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
                root = null;
            }
        }

        private void Tab2ItemChangedEvent(object sender, Tab.ItemChangedEventArgs e)
        {
            createText[1].Text = "Create Tab just by Style, Selected index from " + e.PreviousIndex + " to " + e.CurrentIndex;
        }

        private void ButtonClicked(object sender, ClickedEventArgs e)
        {
            index = (index + 1) % 4;
            button.TextLabel.Text = mode[index];
            tab.Underline.BackgroundColor = color[index];
            tab.TextColorSelector = new ColorSelector
            {
                Normal = Color.Black,
                Selected = color[index],
            };
            tab2.Underline.BackgroundColor = color[index];
            tab2.TextColorSelector = new ColorSelector
            {
                Normal = Color.Black,
                Selected = color[index],
            };
        }

        private void ButtonClicked2(object sender, ClickedEventArgs e)
        {
            if (tab.LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                tab.LayoutDirection = ViewLayoutDirectionType.RTL;
                tab2.LayoutDirection = ViewLayoutDirectionType.RTL;
                button2.TextLabel.Text = "LayoutDirection is right to left";
            }
            else
            {
                tab.LayoutDirection = ViewLayoutDirectionType.LTR;
                tab2.LayoutDirection = ViewLayoutDirectionType.LTR;
                button2.TextLabel.Text = "LayoutDirection is left to right";
            }
        }
    }
}
