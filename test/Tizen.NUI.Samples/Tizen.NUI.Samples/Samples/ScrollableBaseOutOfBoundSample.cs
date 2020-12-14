using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class ScrollableBaseOutOfBoundSample : IExample
    {
        private View root;
        private Components.ScrollableBase mScrollableBase = null;
        private TextLabel[] items;

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
                LinearOrientation = LinearLayout.Orientation.Vertical
            };
            window.Add(root);

            CreateScrollableBase();
        }

        private void CreateScrollableBase()
        {
            mScrollableBase = new Components.ScrollableBase()
            {
                Position = new Position(300, 100),
                Size = new Size(400, 300),
                ScrollingDirection = Components.ScrollableBase.Direction.Vertical,
                EnableOverShootingEffect = true,
            };
            mScrollableBase.ScrollOutOfBoundWithDisplacement += OnScrollOutOfBound;

            items = new TextLabel[5];
            for (int i = 0; i < 5; i++)
            {
                items[i] = new TextLabel
                {
                    Position = new Position(0, i * 100),
                    Size = new Size(800, 100),
                    PointSize = 12.0f,
                    TextColor = Color.Black,
                };
                if (i % 2 == 0)
                {
                    items[i].BackgroundColor = Color.White;
                }
                else
                {
                    items[i].BackgroundColor = Color.Cyan;
                }
                mScrollableBase.Add(items[i]);
            }
            root.Add(mScrollableBase);
        }

        private void OnScrollOutOfBound(object sender, Components.ScrollOutOfBoundWithDisplacementEventArgs e)
        {
            if (e.Displacement > 100)
            {
                if (e.PanDirection == Components.ScrollOutOfBoundWithDisplacementEventArgs.Direction.Down)
                {
                    items[0].Text = $"Reached at the top, panned displacement is {e.Displacement}.";
                }
            }
            else if (0 - e.Displacement > 100)
            {
                if (e.PanDirection == Components.ScrollOutOfBoundWithDisplacementEventArgs.Direction.Up)
                {
                    items[4].Text = $"Reached at the bottom, panned displacement is {e.Displacement}.";
                }
            }
        }

        public void Deactivate()
        {
            for (int i = 0; i < 5; i++)
            {
                if (items[i] != null)
                {
                    mScrollableBase.Remove(items[i]);
                    items[i].Dispose();
                }
            }
            if (mScrollableBase != null)
            {
                root.Remove(mScrollableBase);
                mScrollableBase.Dispose();
            }
            root.Dispose();
        }
    }
}
