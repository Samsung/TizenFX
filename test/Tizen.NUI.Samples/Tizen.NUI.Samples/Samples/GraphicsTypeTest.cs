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
            var baseDpiText = new TextLabel();
            baseDpiText.Text = $"Baseline Dpi : {GraphicsTypeManager.Instance.BaselineDpi}";
            rootView.Add(baseDpiText);

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

            var dpToPixelSizeText = new TextLabel();
            var dpSize = new Size(100.0f, 100.0f);
            var pixelSize = dpSize.ToPixel();
            dpToPixelSizeText.Text = $"dp : ({dpSize.Width}, {dpSize.Height}), pixel : ({pixelSize.Width}, {pixelSize.Height})";
            rootView.Add(dpToPixelSizeText);

            var pixelToDpSizeText = new TextLabel();
            pixelSize = new Size(100.0f, 100.0f);
            dpSize = pixelSize.ToDp();
            pixelToDpSizeText.Text = $"pixel : ({pixelSize.Width}, {pixelSize.Height}), dp : ({dpSize.Width}, {dpSize.Height})";
            rootView.Add(pixelToDpSizeText);

            var dpToPixelPosText = new TextLabel();
            var dpPos = new Position(100.0f, 100.0f);
            var pixelPos = dpPos.ToPixel();
            dpToPixelPosText.Text = $"dp : ({dpPos.X}, {dpPos.Y}), pixel : ({pixelPos.X}, {pixelPos.Y})";
            rootView.Add(dpToPixelPosText);

            var pixelToDpPosText = new TextLabel();
            pixelPos = new Position(100.0f, 100.0f);
            dpPos = pixelPos.ToDp();
            pixelToDpPosText.Text = $"pixel : ({pixelPos.X}, {pixelPos.Y}), dp : ({dpPos.X}, {dpPos.Y})";
            rootView.Add(pixelToDpPosText);

            var dpToPixelRectText = new TextLabel();
            var dpRect = new Rectangle(100, 100, 100, 100);
            var pixelRect = dpRect.ToPixel();
            dpToPixelRectText.Text = $"dp : ({dpRect.X}, {dpRect.Y}, {dpRect.Width}, {dpRect.Height}), pixel : ({pixelRect.X}, {pixelRect.Y}, {pixelRect.Width}, {pixelRect.Height})";
            rootView.Add(dpToPixelRectText);

            var pixelToDpRectText = new TextLabel();
            pixelRect =new Rectangle(100, 100, 100, 100);
            dpRect = pixelRect.ToDp();
            pixelToDpRectText.Text = $"pixel : ({pixelRect.X}, {pixelRect.Y}, {pixelRect.Width}, {pixelRect.Height}), dp : ({dpRect.X}, {dpRect.Y}, {dpRect.Width}, {dpRect.Height})";
            rootView.Add(pixelToDpRectText);

            var dpToPixelExtentText = new TextLabel();
            var dpExtent = new Extents(10, 10, 10, 10);
            var pixelExtent = dpExtent.ToPixel();
            dpToPixelExtentText.Text = $"dp : ({dpExtent.Start}, {dpExtent.End}, {dpExtent.Top}, {dpExtent.Bottom}), pixel : ({pixelExtent.Start}, {pixelExtent.End}, {pixelExtent.Top}, {pixelExtent.Bottom})";
            rootView.Add(dpToPixelExtentText);

            var pixelToDpExtentText = new TextLabel();
            pixelExtent =new Extents(10, 10, 10, 10);
            dpExtent = pixelExtent.ToDp();
            pixelToDpExtentText.Text = $"pixel : ({pixelExtent.Start}, {pixelExtent.End}, {pixelExtent.Top}, {pixelExtent.Bottom}), dp : ({dpExtent.Start}, {dpExtent.End}, {dpExtent.Top}, {dpExtent.Bottom})";
            rootView.Add(pixelToDpExtentText);

            var pixelToPointText = new TextLabel();
            var fontPxSize = 30.0f;
            pixelToPointText.PointSize = fontPxSize.PixelToPoint();
            pixelToPointText.Text = $"pixel : {fontPxSize}, point: {fontPxSize.PixelToPoint()}";
            rootView.Add(pixelToPointText);

            var dpToPointText = new TextLabel();
            var dpPxSize = 80.0f;
            dpToPointText.PointSize = dpPxSize.DpToPoint();
            dpToPointText.Text = $"pixel : {dpPxSize}, point: {dpPxSize.DpToPoint()}";
            rootView.Add(dpToPointText);


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