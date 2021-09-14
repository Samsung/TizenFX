using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class GraphicsTypeTest : IExample
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

            var scalingFactorText = new TextLabel();
            scalingFactorText.Text = $"ScalingFactor : {GraphicsTypeManager.Instance.ScalingFactor}";
            rootView.Add(scalingFactorText);

            var scaledDpiText = new TextLabel();
            scaledDpiText.Text = $"Scaled Dpi : {GraphicsTypeManager.Instance.ScaledDpi}";
            rootView.Add(scaledDpiText);

            var defConvertText = new TextLabel();
            defConvertText.Text = $"DefaultTypeConverter : {GraphicsTypeManager.Instance.TypeConverter}";
            rootView.Add(defConvertText);

            /* GraphicsTypeConverter test. */
            var dpConvertText = new TextLabel();
            var dp = 100.0f;
            dpConvertText.Text = $"dp : {dp}, pixel : {DpTypeConverter.Instance.ConvertToPixel(dp)}";
            rootView.Add(dpConvertText);

            var pxConvertText = new TextLabel();
            var px = 100.0f;
            pxConvertText.Text = $"pixel : {px}, dp : {DpTypeConverter.Instance.ConvertToPixel(px)}";
            rootView.Add(pxConvertText);

            /* GraphicsTypeExtension test. */
            var dpToPixelText = new TextLabel();
            dpToPixelText.Text = $"dp : {100.01f}, pixel : {100.01f.ToPixel()}";
            rootView.Add(dpToPixelText);

            var pixelToDpText = new TextLabel();
            pixelToDpText.Text = $"pixel : {60.01f}, dp : {60.01f.ToDp()}";
            rootView.Add(pixelToDpText);

            var dpToPixel2Text = new TextLabel();
            dpToPixel2Text.Text = $"dp : {100}, pixel : {100.ToPixel()}";
            rootView.Add(dpToPixel2Text);

            var pixelToDp2Text = new TextLabel();
            pixelToDp2Text.Text = $"pixel : {60}, dp : {60.ToDp()}";
            rootView.Add(pixelToDp2Text);

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