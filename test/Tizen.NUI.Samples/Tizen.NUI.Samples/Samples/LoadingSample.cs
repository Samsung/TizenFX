using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class LoadingSample : IExample
    {
        private TextLabel propBoard, propLogBoard, attrBoard;
        private Button propFpsAddBtn, propFpsMinusBtn, attrBtn;
        private Loading propLoading, attrLoading;
        private View root;
        private View parent, propParent, propBtnParent, attrParent;
        private string[] imageArray;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = new Size(1920, 1080),
            };
            window.Add(root);

            parent = new View()
            {
                Position = new Position(100, 200),
                Size = new Size(1000, 780)
            };
            parent.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
                CellPadding = new Size(20, 0)
            };

            propParent = new View()
            {
                Position = new Position(100, 200),
                Size = new Size(500, 780)
            };
            propParent.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
                CellPadding = new Size(20, 100)
            };

            attrParent = new View()
            {
                Position = new Position(600, 200),
                Size = new Size(500, 780)
            };
            attrParent.Layout = new LinearLayout() {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
                CellPadding = new Size(20, 100)
            };

            root.Add(parent);
            parent.Add(propParent);
            parent.Add(attrParent);

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
            propBoard = new TextLabel();
            propBoard.WidthSpecification = 380;
            propBoard.HeightSpecification = 70;
            propBoard.PointSize = 20;
            propBoard.HorizontalAlignment = HorizontalAlignment.Center;
            propBoard.VerticalAlignment = VerticalAlignment.Center;
            propBoard.BackgroundColor = Color.Magenta;
            propBoard.Text = "Property construction";
            propParent.Add(propBoard);

            propLoading = new Loading();
            propLoading.WidthSpecification = 100;
            propLoading.HeightSpecification = 100;
            propLoading.Images = imageArray;
            propParent.Add(propLoading);

            CreatePropBtnLayout();

            propLogBoard = new TextLabel();
            propLogBoard.WidthSpecification = 380;
            propLogBoard.HeightSpecification = 70;
            propLogBoard.PointSize = 20;
            propLogBoard.HorizontalAlignment = HorizontalAlignment.Center;
            propLogBoard.VerticalAlignment = VerticalAlignment.Center;
            propLogBoard.BackgroundColor = Color.Magenta;
            propLogBoard.Text = "log pad";
            propLogBoard.PointSize = 15;
            propParent.Add(propLogBoard);
        }

        void CreatePropBtnLayout()
        {
            propBtnParent = new View()
            {
                Size = new Size(400, 50)
            };
            var propBtnLayout = new LinearLayout();
            propBtnLayout.LinearOrientation = LinearLayout.Orientation.Horizontal;
            propBtnLayout.LinearAlignment = LinearLayout.Alignment.Center;
            propBtnLayout.CellPadding = new Size(10, 50);
            propBtnParent.Layout = propBtnLayout;
            propParent.Add(propBtnParent);

            propFpsAddBtn = new Button();
            propFpsAddBtn.WidthSpecification = 150;
            propFpsAddBtn.HeightSpecification = 50;
            var propFpsAddStyle = propFpsAddBtn.Style;
            propFpsAddStyle.Text.Text = "FPS++";
            propFpsAddStyle.Text.PointSize = 15;
            propFpsAddBtn.ApplyStyle(propFpsAddStyle);
            propBtnParent.Add(propFpsAddBtn);
            propFpsAddBtn.Focusable = true;
            propFpsAddBtn.ClickEvent += propFpsAdd;
            FocusManager.Instance.SetCurrentFocusView(propFpsAddBtn);

            propFpsMinusBtn = new Button();
            propFpsMinusBtn.WidthSpecification = 150;
            propFpsMinusBtn.HeightSpecification = 50;
            var propFpsMinusStyle = propFpsMinusBtn.Style;
            propFpsMinusStyle.Text.Text = "FPS--";
            propFpsMinusStyle.Text.PointSize = 15;
            propFpsMinusBtn.ApplyStyle(propFpsMinusStyle);
            propBtnParent.Add(propFpsMinusBtn);
            propFpsMinusBtn.Focusable = true;
            propFpsMinusBtn.ClickEvent += propFpsMinus;
            FocusManager.Instance.SetCurrentFocusView(propFpsMinusBtn);

            propFpsAddBtn.RightFocusableView = propFpsMinusBtn;
            propFpsMinusBtn.LeftFocusableView = propFpsAddBtn;
        }

        private void CreateAttrLayout()
        {
            attrBoard = new TextLabel();
            attrBoard.WidthSpecification = 380;
            attrBoard.HeightSpecification = 70;
            attrBoard.PointSize = 20;
            attrBoard.HorizontalAlignment = HorizontalAlignment.Center;
            attrBoard.VerticalAlignment = VerticalAlignment.Center;
            attrBoard.BackgroundColor = Color.Magenta;
            attrBoard.Text = "Attribute construction";
            attrParent.Add(attrBoard);

            LoadingStyle style = new LoadingStyle
            {
                Images = imageArray
            };
            attrLoading = new Loading(style);
            attrLoading.Size = new Size(100, 100);
            attrParent.Add(attrLoading);

            attrBtn = new Button()
            {
                WidthSpecification = 300,
                HeightSpecification = 50,
            };
            var attrBtnStyle = attrBtn.Style;
            attrBtnStyle.Text.Text = "Normal Loading";
            attrBtnStyle.Text.PointSize = 15;
            attrBtn.ApplyStyle(attrBtnStyle);
            attrParent.Add(attrBtn);
            attrBtn.Focusable = true;
            FocusManager.Instance.SetCurrentFocusView(attrBtn);
        }

        private void propFpsAdd(object sender, global::System.EventArgs e)
        {
            propLoading.FrameRate += 1;
            propLogBoard.Text = "loading1_1 FPS: " + propLoading.FrameRate.ToString();
        }

        private void propFpsMinus(object sender, global::System.EventArgs e)
        {
            propLoading.FrameRate -= 1;
            propLogBoard.Text = "loading1_1 FPS: " + propLoading.FrameRate.ToString();
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
                propBtnParent.Remove(propFpsAddBtn);
                propFpsAddBtn.Dispose();
                propFpsAddBtn = null;

                propBtnParent.Remove(propFpsMinusBtn);
                propFpsMinusBtn.Dispose();
                propFpsMinusBtn = null;

                propParent.Remove(propBtnParent);
                propBtnParent.Dispose();
                propBtnParent = null;

                propParent.Remove(propBoard);
                propBoard.Dispose();
                propBoard = null;

                propParent.Remove(propLoading);
                propLoading.Dispose();
                propLoading = null;

                propParent.Remove(propLogBoard);
                propLogBoard.Dispose();
                propLogBoard = null;

                attrParent.Remove(attrBoard);
                attrBoard.Dispose();
                attrBoard = null;

                attrParent.Remove(attrLoading);
                attrLoading.Dispose();
                attrLoading = null;

                attrParent.Remove(attrBtn);
                attrBtn.Dispose();
                attrBtn = null;

                parent.Remove(propParent);
                propParent.Dispose();
                propParent = null;

                parent.Remove(attrParent);
                attrParent.Dispose();
                attrParent = null;

                root.Remove(parent);
                parent.Dispose();
                parent = null;

                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
                root = null;
            }
        }
    }
}
