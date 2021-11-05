
using global::System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class ShowErrorPage : IExample
    {
        View root;
        TextLabel title, msg;
        Button goback;
        public void Activate()
        {
            var win = NUIApplication.GetDefaultWindow();
            var winSize = win.Size;
            root = new View()
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = NUI.ParentOrigin.Center,
                PivotPoint = NUI.PivotPoint.Center,
                Size = winSize,
                BackgroundColor = Color.BlueViolet,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    Padding = new Extents(30, 30, 30, 30),
                },
            };
            win.Add(root);
            title = new TextLabel()
            {
                BackgroundColor = Color.Beige,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15,
                MultiLine = true,
                Text = "Error, please check the exception below!",
                Padding = new Extents(10, 10, 10, 10),
            };
            root.Add(title);

            msg = new TextLabel()
            {
                BackgroundColor = Color.LightCoral,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = winSize.Height / 2,
                PointSize = 19,
                MultiLine = true,
            };
            root.Add(msg);

            goback = new Button()
            {
                BackgroundColor = Color.HotPink,
                Text = "Please go back by keyboard \"back\" button",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            root.Add(goback);
        }

        public void Deactivate()
        {
            root?.Unparent();

            goback?.Unparent();
            goback?.Dispose();

            msg?.Unparent();
            msg?.Dispose();

            title?.Unparent();
            title?.Dispose();

            root?.Dispose();
        }

        public void ShowExcpetionText(string message)
        {
            if (msg)
            {
                msg.Text = message;
            }
        }
    }
}
