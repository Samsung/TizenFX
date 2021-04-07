using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI;

namespace Tizen.NUI.Samples
{
    public class ProgressSample : IExample
    {
        private TextLabel[] board = new TextLabel[4];
        private Button[] button = new Button[2];
        private Progress[] progressBar = new Progress[4];
        private View[] layout = new View[4];

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            // Root layout.
            layout[0] = new View()
            {
                Size = new Size(1920, 1080),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
            };
            layout[0].Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                LinearAlignment = LinearLayout.Alignment.Center
            };
            window.Add(layout[0]);

            // Layout for progress parent layout.
            layout[1] = new View()
            {
                Size = new Size(1000, 730)
            };
            layout[1].Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                LinearAlignment = LinearLayout.Alignment.Center
            };
            layout[0].Add(layout[1]);

            // Layout for progress layout which is created by properties.
            layout[2] = new View()
            {
                Size = new Size(450, 630)
            };
            layout[2].Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
                CellPadding = new Size2D(50, 100)
            };
            layout[1].Add(layout[2]);

            // Layout for progress layout which is created by attributes.
            layout[3] = new View()
            {
                Size = new Size(450, 630)
            };
            layout[3].Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
                CellPadding = new Size2D(50, 100)
            };
            layout[1].Add(layout[3]);

            CreatePropElements();
            CreateAttrElements();
            CreateIndeterminateProgress();
            layout[1].Add(layout[2]);
            layout[1].Add(layout[3]);

            board[0] = new TextLabel();
            board[0].WidthSpecification = 900;
            board[0].HeightSpecification = 100;
            board[0].PointSize = 30;
            board[0].HorizontalAlignment = HorizontalAlignment.Center;
            board[0].VerticalAlignment = VerticalAlignment.Center;
            board[0].BackgroundColor = Color.Magenta;
            board[0].Text = "log pad";
            layout[0].Add(board[0]);
            board[0].Focusable = true;
            board[0].FocusGained += Board_FocusGained;
            board[0].FocusLost += Board_FocusLost;
            board[0].UpFocusableView = button[0];
            FocusManager.Instance.SetCurrentFocusView(button[0]);
        }

        void CreatePropElements()
        {
            ///////////////////////////////////////////////Create by Properties//////////////////////////////////////////////////////////
            board[1] = new TextLabel();
            board[1].WidthSpecification = 380;
            board[1].HeightSpecification = 70;
            board[1].PointSize = 20;
            board[1].HorizontalAlignment = HorizontalAlignment.Center;
            board[1].VerticalAlignment = VerticalAlignment.Center;
            board[1].BackgroundColor = Color.Magenta;
            board[1].Text = "Property construction";
            layout[2].Add(board[1]);
            board[1].Focusable = true;
            board[1].FocusGained += Board_FocusGained;
            board[1].FocusLost += Board_FocusLost;

            progressBar[0] = new Progress();
            progressBar[0].WidthSpecification = 240;
            progressBar[0].HeightSpecification = 4;
            progressBar[0].MaxValue = 100;
            progressBar[0].MinValue = 0;
            progressBar[0].CurrentValue = 45;
            layout[2].Add(progressBar[0]);

            progressBar[1] = new Progress();
            progressBar[1].WidthSpecification = 240;
            progressBar[1].HeightSpecification = 4;
            progressBar[1].MaxValue = 100;
            progressBar[1].MinValue = 0;
            progressBar[1].CurrentValue = 30;
            progressBar[1].TrackColor = Color.Yellow;
            progressBar[1].ProgressColor = Color.Black;
            layout[2].Add(progressBar[1]);

            button[0] = new Button();
            button[0].WidthSpecification = 140;
            button[0].HeightSpecification = 50;
            button[0].Text = "+";
            button[0].BackgroundColor = Color.Green;
            layout[2].Add(button[0]);
            button[0].Focusable = true;
            button[0].Clicked += ProgressAdd;

            button[1] = new Button();
            button[1].WidthSpecification = 140;
            button[1].HeightSpecification = 50;
            button[1].Text = "-";
            button[1].BackgroundColor = Color.Green;
            layout[2].Add(button[1]);
            button[1].Focusable = true;
            button[1].Clicked += ProgressMinus;
        }

        private void CreateAttrElements()
        {
            ///////////////////////////////////////////////Create by attributes//////////////////////////////////////////////////////////
            board[2] = new TextLabel();
            board[2].WidthSpecification = 380;
            board[2].HeightSpecification = 70;
            board[2].PointSize = 20;
            board[2].HorizontalAlignment = HorizontalAlignment.Center;
            board[2].VerticalAlignment = VerticalAlignment.Center;
            board[2].BackgroundColor = Color.Magenta;
            board[2].Text = "Attribute construction";
            layout[3].Add(board[2]);
            board[2].Focusable = true;
            board[2].FocusGained += Board_FocusGained;
            board[2].FocusLost += Board_FocusLost;

            ProgressStyle attr = new ProgressStyle
            {
                Track = new ImageViewStyle
                {
                    BackgroundColor = new Selector<Color>
                    {
                        All = Color.Cyan
                    }
                },
                Progress = new ImageViewStyle
                {
                    BackgroundColor = new Selector<Color>
                    {
                        All = Color.Red
                    }
                },
                Buffer = new ImageViewStyle
                {
                    BackgroundColor = new Selector<Color>
                    {
                        All = Color.Green
                    }
                }
            };
            progressBar[2] = new Progress(attr);
            progressBar[2].WidthSpecification = 240;
            progressBar[2].HeightSpecification = 4;
            progressBar[2].MaxValue = 100;
            progressBar[2].MinValue = 0;
            progressBar[2].CurrentValue = 30;
            layout[3].Add(progressBar[2]);
        }

        private void CreateIndeterminateProgress()
        {
            board[3] = new TextLabel();
            board[3].WidthSpecification = 380;
            board[3].HeightSpecification = 70;
            board[3].PointSize = 20;
            board[3].HorizontalAlignment = HorizontalAlignment.Center;
            board[3].VerticalAlignment = VerticalAlignment.Center;
            board[3].BackgroundColor = Color.Magenta;
            board[3].Text = "Indeterminate Progress";
            layout[3].Add(board[3]);
            board[3].Focusable = true;
            board[3].FocusGained += Board_FocusGained; // Not sure to connect this event
            board[3].FocusLost += Board_FocusLost;

            progressBar[3] = new Progress();
            progressBar[3].WidthSpecification = 240;
            progressBar[3].HeightSpecification = 4;
            progressBar[3].ProgressState = Progress.ProgressStatusType.Indeterminate;
            layout[3].Add(progressBar[3]);
        }

        private void Board_FocusLost(object sender, global::System.EventArgs e)
        {
            board[0].BackgroundColor = Color.Magenta;
        }

        private void Board_FocusGained(object sender, global::System.EventArgs e)
        {
            board[0].BackgroundColor = Color.Cyan;
        }

        private void ProgressAdd(object sender, global::System.EventArgs e)
        {
            if (progressBar[0].CurrentValue == 100)
            {
                board[0].Text = "Current value is: 100";
            }
            else
            {
                board[0].Text = "Current value is: " + ++progressBar[0].CurrentValue;
            }
        }
        private void ProgressMinus(object sender, global::System.EventArgs e)
        {
            if (progressBar[0].CurrentValue == 0)
            {
                board[0].Text = "Current value is: 0";
            }
            else
            {
                board[0].Text = "Current value is: " + --progressBar[0].CurrentValue;
            }
        }

        public void Deactivate()
        {
            if (layout[0] != null)
            {
                layout[2].Remove(board[1]);
                board[1].Dispose();
                board[1] = null;
                layout[2].Remove(progressBar[0]);
                progressBar[0].Dispose();
                progressBar[0] = null;
                layout[2].Remove(progressBar[1]);
                progressBar[1].Dispose();
                progressBar[1] = null;
                layout[2].Remove(button[0]);
                button[0].Dispose();
                button[0] = null;
                layout[2].Remove(button[1]);
                button[1].Dispose();
                button[1] = null;

                layout[3].Remove(board[2]);
                board[2].Dispose();
                board[2] = null;
                layout[3].Remove(progressBar[2]);
                progressBar[2].Dispose();
                progressBar[2] = null;

                layout[1].Remove(layout[2]);
                layout[2].Dispose();
                layout[2] = null;
                layout[1].Remove(layout[3]);
                layout[3].Dispose();
                layout[3] = null;

                layout[0].Remove(layout[1]);
                layout[1].Dispose();
                layout[1] = null;
                layout[0].Remove(board[0]);
                board[0].Dispose();
                board[0] = null;

                NUIApplication.GetDefaultWindow().Remove(layout[0]);
                layout[0].Dispose();
                layout[0] = null;
            }
        }
    }
}
