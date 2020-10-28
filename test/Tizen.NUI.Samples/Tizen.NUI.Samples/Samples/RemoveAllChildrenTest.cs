
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using NUnit.Framework;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    using tlog = Tizen.Log;
    public class RemoveAllChildrenTest : IExample
    {
        const string tag = "NUITEST";

        public void Activate()
        {
            test();
        }
        public void Deactivate()
        {
        }

        private TextLabel t1, t2, t3, t4;
        private Window window;
        private ScrollableBase scroll;
        private View grid;

        void test()
        {
            window = NUIApplication.GetDefaultWindow();
            window.KeyEvent += OnKeyEvent;

            t1 = new TextLabel()
            {
                Size = new Size(400, 100),
                Position = new Position(10, 10),
                Text = "TextLable-1",
                BackgroundColor = Color.Yellow,
                Name = "tl-1",
            };
            window.Add(t1);

            t2 = new TextLabel()
            {
                Size = new Size(400, 150),
                Position = new Position(10, 120),
                Text = "TextLable-2",
                BackgroundColor = Color.Green,
                Name = "tl-2",
            };
            window.Add(t2);

            scroll = new ScrollableBase()
            {
                Size = new Size(400, 500),
                Position = new Position(10, 280),
                BackgroundColor = Color.Red,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                Padding = new Extents(20, 20, 20, 20),
                Name = "scr-1",
            };
            window.Add(scroll);

            grid = new View()
            {
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Vertical,
                    Columns = 3,
                    Rows = 3,
                },
                WidthSpecification = 390,
                HeightSpecification = 590,
                BackgroundColor = new Color(global::System.Drawing.Color.FromName("SlateBlue")),
                Padding = new Extents(5, 5, 5, 5),
                Name = "grid-1",
            };
            scroll.Add(grid);

            for (int i = 0; i < 9; i++)
            {
                var t = new TextLabel()
                {
                    Size = new Size(100, 180),
                    Text = $"con-{i}",
                    BackgroundColor = new Color(0.5f, (100 + 10 * i) / 255.0f, 0.5f, 1),
                    Margin = new Extents(2, 2, 2, 2),
                    Name = $"sub-tl-{i}",
                };
                grid.Add(t);
            }

            t3 = new TextLabel()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 200,
                Text = "TextLable-3",
                BackgroundColor = Color.Magenta,
                Margin = new Extents(10, 10, 10, 10),
                Name = "tl-3",
            };
            scroll.Add(t3);

            t4 = new TextLabel()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 200,
                Text = "TextLable-4",
                BackgroundColor = new Color(global::System.Drawing.Color.FromName("HotPink")),
                Margin = new Extents(10, 10, 10, 10),
                Name = "tl-4",
            };
            scroll.Add(t4);
        }


        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "1")
                {
                    ChangeScrollableBaseSizeBigger();
                }
                else if (e.Key.KeyPressedName == "2")
                {
                    ChangeScrollableBaseSizeSmaller();
                }
                else if (e.Key.KeyPressedName == "3")
                {
                    RemoveAllChildrenDisposeFalse();
                }
                else if (e.Key.KeyPressedName == "4")
                {
                    RemoveAllChildrenDisposeTrue();
                }
                else if (e.Key.KeyPressedName == "5")
                {
                    AddChildrenInScrollableBase();
                }
            }
        }

        [Test]
        void ChangeScrollableBaseSizeBigger()
        {
            tlog.Debug(tag, "ChangeScrollableBaseSizeBigger test");
            t2.Position += new Position(10, -100);
            scroll.Position += new Position(0, -100);
            scroll.HeightSpecification += 100;
        }

        [Test]
        void ChangeScrollableBaseSizeSmaller()
        {
            tlog.Debug(tag, "ChangeScrollableBaseSizeSmaller test");
            t2.Position += new Position(-10, 100);
            scroll.Position += new Position(0, 100);
            scroll.HeightSpecification -= 100;

        }

        [Test]
        void AddChildrenInScrollableBase()
        {
            tlog.Debug(tag, "AddChildrenInScrollableBase test");

            grid = new View()
            {
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Vertical,
                    Columns = 3,
                    Rows = 3,
                },
                WidthSpecification = 390,
                HeightSpecification = 590,
                BackgroundColor = new Color(global::System.Drawing.Color.FromName("SlateBlue")),
                Padding = new Extents(5, 5, 5, 5),
                Name = "grid-1",
            };
            scroll.Add(grid);

            for (int i = 0; i < 9; i++)
            {
                var t = new TextLabel()
                {
                    Size = new Size(100, 180),
                    Text = $"con-{i}",
                    BackgroundColor = new Color(0.5f, (100 + 10 * i) / 255.0f, 0.5f, 1),
                    Margin = new Extents(2, 2, 2, 2),
                    Name = $"sub-tl-{i}",
                };
                grid.Add(t);
            }

            t3 = new TextLabel()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 200,
                Text = "TextLable-3",
                BackgroundColor = Color.Magenta,
                Margin = new Extents(10, 10, 10, 10),
                Name = "tl-3",
            };
            scroll.Add(t3);

            t4 = new TextLabel()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 200,
                Text = "TextLable-4",
                BackgroundColor = new Color(global::System.Drawing.Color.FromName("HotPink")),
                Margin = new Extents(10, 10, 10, 10),
                Name = "tl-4",
            };
            scroll.Add(t4);
        }

        [Test]
        void RemoveAllChildrenDisposeTrue()
        {
            tlog.Debug(tag, "RemoveAllChildrenDisposeTrue test");

            scroll.RemoveAllChildren(true);
        }

        [Test]
        void RemoveAllChildrenDisposeFalse()
        {
            tlog.Debug(tag, "RemoveAllChildrenDisposeFalse test");

            scroll.RemoveAllChildren(false);
        }

    }
}
