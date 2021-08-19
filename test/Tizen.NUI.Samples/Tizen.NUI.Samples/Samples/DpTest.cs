using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class DpTest : IExample
    {
        private int oldPageCount = 0;

        private Window window;
        private View rootView;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();

            rootView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical}
            };

            var defaultDensityDpiText = new TextLabel();
            defaultDensityDpiText.Text = $"Default Density Dpi : {GraphicsTypeManager.DefaultDpi}";
            rootView.Add(defaultDensityDpiText);

            var densityText = new TextLabel();
            densityText.Text = $"Density : {GraphicsTypeManager.Density}";
            rootView.Add(densityText);

            var densityDpiText = new TextLabel();
            densityDpiText.Text = $"Density Dpi : {GraphicsTypeManager.Dpi}";
            rootView.Add(densityDpiText);

            var dpi = GraphicsTypeManager.Dpi;
            var dpiText = new TextLabel();
            dpiText.Text = $"dpi x : {dpi.X} dpi y : {dpi.Y}";
            rootView.Add(dpiText);

            var dp = new Dp(100);
            var dpText = new TextLabel();
            dpText.Text = $" Dp {dp.Value} Pixel {dp.Pixel}";
            rootView.Add(dpText);

            var dp2 = Dp.GetDp(dp.Pixel);
            var dp2Text = new TextLabel();
            dp2Text.Text = $" Dp {dp2.Value} Pixel {dp2.Pixel}";
            rootView.Add(dp2Text);

            var dp3Text = new TextLabel();
            dp3Text.Text = $"{dp2.ToString()}";
            rootView.Add(dp3Text);

            var Size = new Size(100, 100);
            var sizeText = new TextLabel();
            sizeText.Text = $" Size test {Size.ToString()}";
            rootView.Add(sizeText);

            window.Add(rootView);
        }

        public void Deactivate()
        {
            window.Remove(rootView);
            rootView.Dispose();
            rootView = null;
        }
    }
}