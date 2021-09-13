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

            /* GraphicsTypeManager test. */
            var defaultDensityDpiText = new TextLabel();
            defaultDensityDpiText.Text = $"Default Density Dpi : {GraphicsTypeManager.Instance.DefaultDpi}";
            rootView.Add(defaultDensityDpiText);

            var densityText = new TextLabel();
            densityText.Text = $"Density : {GraphicsTypeManager.Instance.Density}";
            rootView.Add(densityText);

            var dpiText = new TextLabel();
            dpiText.Text = $"Dpi : {GraphicsTypeManager.Instance.Dpi}";
            rootView.Add(dpiText);

            var scaledDpiText = new TextLabel();
            scaledDpiText.Text = $"Scaled Dpi : {GraphicsTypeManager.Instance.ScaledDpi}";
            rootView.Add(scaledDpiText);


            /* DpExtension test. */
            var dpToPixelText = new TextLabel();
            var dp = 100.0f;
            dpToPixelText.Text = $"dp : {dp}, pixel : {dp.ToPixel()}";
            rootView.Add(dpToPixelText);

            var pixelToDpText = new TextLabel();
            var pix = 100.0f;
            pixelToDpText.Text = $"pixel : {pix}, dp : {pix.ToDp()}";
            rootView.Add(pixelToDpText);

            /* Dp class test. below code is experimental class */
            var dp1 = new Dp(100);
            var dpText = new TextLabel();
            dpText.Text = $" Dp {dp1.Value} Pixel {dp1.Pixel}";
            rootView.Add(dpText);

            var dp2 = Dp.GetDp(dp1.Pixel);
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