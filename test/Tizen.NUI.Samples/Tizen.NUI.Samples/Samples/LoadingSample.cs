using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class LoadingSample : IExample
    {
        private TextLabel[] textLabel = new TextLabel[3];
        private Button[] button = new Button[3];
        private Loading[] loading = new Loading[2];
        private View root;
        private View gridLayout;
        private View[] layout = new View[4];
        private string[] imageArray;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = new Size(1920, 1080),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f)
            };
            window.Add(root);

            gridLayout = new View()
            {
                Position = new Position(400, 200),
                Size = new Size(1920, 1080)
            };
            gridLayout.Layout = new GridLayout()
            {
                Rows = 4,
                GridOrientation = GridLayout.Orientation.Horizontal,
                
            };
            //parent.Layout.Measure(new MeasureSpecification(new LayoutLength(1000), MeasureSpecification.ModeType.Exactly), new MeasureSpecification(new LayoutLength(780), MeasureSpecification.ModeType.Exactly));
            root.Add(gridLayout);

            imageArray = new string[36];
            for (int i = 0; i < 36; i++)
            {
                if (i < 10)
                {
                    imageArray[i] = CommonResource.GetFHResourcePath() + "9. Controller/Loading Sequence_Native/loading_0" + i + ".png";
                }
                else
                {
                    imageArray[i] = CommonResource.GetFHResourcePath() + "9. Controller/Loading Sequence_Native/loading_" + i + ".png";
                }
            }

            CreatePropLayout();
            CreateAttrLayout();
        }

        void CreatePropLayout()
        {
            textLabel[0] = new TextLabel();
            textLabel[0].WidthSpecification = 500;
            textLabel[0].HeightSpecification = 100;
            //To set spacing between grid cells.
            textLabel[0].Margin = new Extents(0, 20, 0, 100);
            textLabel[0].PointSize = 20;
            textLabel[0].HorizontalAlignment = HorizontalAlignment.Center;
            textLabel[0].VerticalAlignment = VerticalAlignment.Center;
            textLabel[0].BackgroundColor = Color.Magenta;
            textLabel[0].Text = "Property construction";
            gridLayout.Add(textLabel[0]);

            // layout for loading which is created by properties.
            // It'll update the visual when framerate is changed, so put loading into a layout.
            layout[1] = new View();
            layout[1].Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                LinearAlignment = LinearLayout.Alignment.Center
            };
            loading[0] = new Loading();
            loading[0].Size = new Size(100, 100);
            loading[0].ImageArray = imageArray;
            layout[1].Add(loading[0]);
            gridLayout.Add(layout[1]);

            CreatePropBtnLayout();

            textLabel[1] = new TextLabel();
            textLabel[1].PointSize = 20;
            textLabel[1].HorizontalAlignment = HorizontalAlignment.Center;
            textLabel[1].VerticalAlignment = VerticalAlignment.Center;
            textLabel[1].BackgroundColor = Color.Magenta;
            textLabel[1].Text = "log pad";
            textLabel[1].PointSize = 15;
            gridLayout.Add(textLabel[1]);
        }

        void CreatePropBtnLayout()
        {
            // layout for button.
            // To avoid button size same as the grid cell.
            layout[0] = new View() {};
            layout[0].Layout = new LinearLayout()
            { 
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                LinearAlignment = LinearLayout.Alignment.Center,
                CellPadding = new Size(10, 50)
            };
           
            button[0] = new Button();
            button[0].Size = new Size(200, 50);
            button[0].Text = "FPS++";
            button[0].PointSize = 15;
            button[0].BackgroundColor = Color.Green;
            layout[0].Add(button[0]);
            button[0].Focusable = true;
            button[0].Clicked += propFpsAdd;
            FocusManager.Instance.SetCurrentFocusView(button[0]);

            button[1] = new Button();
            button[1].Size = new Size(200, 50);
            button[1].Text = "FPS--";
            button[1].PointSize = 15;
            button[1].BackgroundColor = Color.Green;
            layout[0].Add(button[1]);
            button[1].Focusable = true;
            button[1].Clicked += propFpsMinus;
            FocusManager.Instance.SetCurrentFocusView(button[1]);

            gridLayout.Add(layout[0]);

            button[0].RightFocusableView = button[1];
            button[1].LeftFocusableView = button[0];
        }

        private void CreateAttrLayout()
        {
            textLabel[2] = new TextLabel();
            textLabel[2].PointSize = 20;
            textLabel[2].HorizontalAlignment = HorizontalAlignment.Center;
            textLabel[2].VerticalAlignment = VerticalAlignment.Center;
            textLabel[2].BackgroundColor = Color.Magenta;
            textLabel[2].Text = "Attribute construction";
            gridLayout.Add(textLabel[2]);

            // layout for loading which is created by attributes.
            // It'll update the visual when framerate is changed, so put loading into a layout.
            layout[2] = new View();
            layout[2].Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                LinearAlignment = LinearLayout.Alignment.Center
            };
            LoadingStyle style = new LoadingStyle
            {
                Images = imageArray
            };
            loading[1] = new Loading(style);
            loading[1].Size = new Size(100, 100);
            layout[2].Add(loading[1]);
            gridLayout.Add(layout[2]);

            // layout for button.
            // To avoid button size same as the grid cell.
            layout[3] = new View() { };
            layout[3].Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                LinearAlignment = LinearLayout.Alignment.Center
            };
            button[2] = new Button();
            button[2].Size = new Size(400, 50);
            button[2].Text = "Normal Loading";
            button[2].PointSize = 15;
            button[2].BackgroundColor = Color.Green;
            layout[3].Add(button[2]);
            gridLayout.Add(layout[3]);
            button[2].Focusable = true;
            FocusManager.Instance.SetCurrentFocusView(button[2]);
        }

        private void propFpsAdd(object sender, global::System.EventArgs e)
        {
            loading[0].FrameRate += 1;
            textLabel[1].Text = "loading1_1 FPS: " + loading[0].FrameRate.ToString();
        }

        private void propFpsMinus(object sender, global::System.EventArgs e)
        {
            loading[0].FrameRate -= 1;
            textLabel[1].Text = "loading1_1 FPS: " + loading[0].FrameRate.ToString();
        }

        private void FocusLost(object sender, global::System.EventArgs e)
        {
            View view = sender as View;
            view.Scale = new Vector3(1.2f, 1.2f, 1.0f);
        }

        private void FocusGained(object sender, global::System.EventArgs e)
        {
            View view = sender as View;
            view.Scale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        public void Deactivate()
        {
            if (root != null)
            {
                layout[0].Remove(button[0]);
                button[0].Dispose();
                button[0] = null;

                layout[0].Remove(button[1]);
                button[1].Dispose();
                button[1] = null;

                gridLayout.Remove(layout[0]);
                layout[0].Dispose();
                layout[0] = null;

                gridLayout.Remove(textLabel[0]);
                textLabel[0].Dispose();
                textLabel[0] = null;

                layout[1].Remove(loading[0]);
                loading[0].Dispose();
                loading[0] = null;

                gridLayout.Remove(layout[1]);
                layout[1].Dispose();
                layout[1] = null;

                gridLayout.Remove(textLabel[1]);
                textLabel[1].Dispose();
                textLabel[1] = null;

                gridLayout.Remove(textLabel[2]);
                textLabel[2].Dispose();
                textLabel[2] = null;

                layout[2].Remove(loading[1]);
                loading[1].Dispose();
                loading[1] = null;

                gridLayout.Remove(layout[2]);
                layout[2].Dispose();
                layout[2] = null;

                layout[3].Remove(button[2]);
                button[2].Dispose();
                button[2] = null;

                gridLayout.Remove(layout[3]);
                layout[3].Dispose();
                layout[3] = null;

                root.Remove(gridLayout);
                gridLayout.Dispose();
                gridLayout = null;

                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
                root = null;
            }
        }
    }
}
