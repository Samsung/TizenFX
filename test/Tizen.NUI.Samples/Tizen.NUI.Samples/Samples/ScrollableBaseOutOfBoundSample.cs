
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class ScrollableBaseOutOfBoundSample : IExample
    {
        private View root;
        private Components.ScrollableBase horizontalScrollableBase = null;
        private TextLabel[] horizontalItems;

        private Components.ScrollableBase verticalScrollableBase = null;
        private TextLabel[] verticalItems;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            root = new View()
            {
                Size = new Size(1920, 1080),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
            };
            root.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            };
            window.Add(root);

            CreateHorizontalScrollableBase();

            CreateVerticalScrollableBase();
        }

        private void CreateHorizontalScrollableBase()
        {
            horizontalScrollableBase = new Components.ScrollableBase()
            {
                Size = new Size(400, 300),
                ScrollingDirection = Components.ScrollableBase.Direction.Horizontal,
                HideScrollbar = false,
            };
            horizontalScrollableBase.ScrollOutOfBound += OnHorizontalScrollOutOfBound;

            horizontalItems = new TextLabel[5];
            for (int i = 0; i < 5; i++)
            {
                horizontalItems[i] = new TextLabel
                {
                    Position = new Position(i * 200, 0),
                    Size = new Size(200, 300),
                    PointSize = 12.0f,
                    TextColor = Color.Black,
                };
                if (i % 2 == 0)
                {
                    horizontalItems[i].BackgroundColor = Color.White;
                }
                else
                {
                    horizontalItems[i].BackgroundColor = Color.Cyan;
                }
                horizontalScrollableBase.Add(horizontalItems[i]);
            }
            root.Add(horizontalScrollableBase);
        }

        private void OnHorizontalScrollOutOfBound(object sender, Components.ScrollOutOfBoundEventArgs e)
        {
            if (e.PanDirection == Components.ScrollOutOfBoundEventArgs.Direction.Left)
            {
                horizontalItems[0].Text = "Reached at the left.";
            }
            else if (e.PanDirection == Components.ScrollOutOfBoundEventArgs.Direction.Right)
            {
                horizontalItems[4].Text = "Reached at the right.";
            }
        }

        private void CreateVerticalScrollableBase()
        {
            verticalScrollableBase = new Components.ScrollableBase()
            {
                Size = new Size(400, 300),
                ScrollingDirection = Components.ScrollableBase.Direction.Vertical,
                EnableOverShootingEffect = true,
                HideScrollbar = false,
            };
            verticalScrollableBase.ScrollOutOfBound += OnVerticalScrollOutOfBound;

            verticalItems = new TextLabel[5];
            for (int i = 0; i < 5; i++)
            {
                verticalItems[i] = new TextLabel
                {
                    Position = new Position(0, i * 100),
                    Size = new Size(400, 100),
                    PointSize = 12.0f,
                    TextColor = Color.Black,
                };
                if (i % 2 == 0)
                {
                    verticalItems[i].BackgroundColor = Color.White;
                }
                else
                {
                    verticalItems[i].BackgroundColor = Color.Cyan;
                }
                verticalScrollableBase.Add(verticalItems[i]);
            }
            root.Add(verticalScrollableBase);
        }

        private void OnVerticalScrollOutOfBound(object sender, Components.ScrollOutOfBoundEventArgs e)
        {
            if (e.Displacement > 100)
            {
                if (e.PanDirection == Components.ScrollOutOfBoundEventArgs.Direction.Down)
                {
                    verticalItems[0].Text = $"Reached at the top, panned displacement is {e.Displacement}.";
                }
            }
            else if (0 - e.Displacement > 100)
            {
                if (e.PanDirection == Components.ScrollOutOfBoundEventArgs.Direction.Up)
                {
                    verticalItems[4].Text = $"Reached at the bottom, panned displacement is {e.Displacement}.";
                }
            }
        }

        public void Deactivate()
        {
            for (int i = 0; i < 5; i++)
            {
                if (verticalItems[i] != null)
                {
                    verticalScrollableBase.Remove(verticalItems[i]);
                    verticalItems[i].Dispose();
                }
            }
            if (verticalScrollableBase != null)
            {
                root.Remove(verticalScrollableBase);
                verticalScrollableBase.Dispose();
            }
            for (int i = 0; i < 5; i++)
            {
                if (horizontalItems[i] != null)
                {
                    horizontalScrollableBase.Remove(horizontalItems[i]);
                    horizontalItems[i].Dispose();
                }
            }
            if (horizontalScrollableBase != null)
            {
                root.Remove(horizontalScrollableBase);
                horizontalScrollableBase.Dispose();
            }
            root.Dispose();
        }
    }
}
