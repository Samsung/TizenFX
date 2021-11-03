using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class GraphicsTypeTest : IExample
    {
        private int oldPageCount = 0;

        private Window window;
        private ScrollableBase rootView;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();

            rootView = new ScrollableBase()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical},
                Padding = new Extents(20, 20, 0, 0)
            };

            /* GraphicsTypeManager test. */
            var managerTitleText = new TextLabel();
            managerTitleText.Text = "GraphicsTypeManager";
            managerTitleText.PointSize = 40;
            managerTitleText.TextColor = Color.Blue;
            managerTitleText.Padding = new Extents(0, 0, 0, 10);
            rootView.Add(managerTitleText);

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

            /* GraphicsTypeConverter test. */
            var converterTitleText = new TextLabel();
            converterTitleText.Text = "GraphicsTypeConverter";
            converterTitleText.PointSize = 40;
            converterTitleText.TextColor = Color.Red;
            converterTitleText.Padding = new Extents(0, 0, 10, 10);
            rootView.Add(converterTitleText);

            var dpConvertText = new TextLabel();
            var dp = 100.0f;
            dpConvertText.Text = $"dp : {dp}, pixel : {DpTypeConverter.Instance.ConvertToPixel(dp)}";
            rootView.Add(dpConvertText);

            var pxConvertText = new TextLabel();
            var px = 100.0f;
            pxConvertText.Text = $"pixel : {px}, dp : {DpTypeConverter.Instance.ConvertFromPixel(px)}";
            rootView.Add(pxConvertText);

            var spConvertText = new TextLabel();
            var sp = 100.0f;
            spConvertText.Text = $"sp : {sp}, pixel : {SpTypeConverter.Instance.ConvertToPixel(sp)}";
            rootView.Add(spConvertText);

            pxConvertText = new TextLabel();
            px = 100.0f;
            pxConvertText.Text = $"pixel : {px}, sp : {PointTypeConverter.Instance.ConvertFromPixel(px)}";
            rootView.Add(pxConvertText);

            var ptConvertText = new TextLabel();
            var pt = 100.0f;
            ptConvertText.Text = $"point : {pt}, pixel : {PointTypeConverter.Instance.ConvertToPixel(pt)}";
            rootView.Add(pxConvertText);

            pxConvertText = new TextLabel();
            px = 100.0f;
            pxConvertText.Text = $"pixel : {px}, point : {PointTypeConverter.Instance.ConvertFromPixel(px)}";
            rootView.Add(pxConvertText);

            /* GraphicsTypeExtension test. */
            var extTitleText = new TextLabel();
            extTitleText.Text = "GraphicsTypeExtensions";
            extTitleText.PointSize = 40;
            extTitleText.TextColor = Color.Green;
            extTitleText.Padding = new Extents(0, 0, 10, 10);
            rootView.Add(extTitleText);

            var spToPxFloatText = new TextLabel();
            spToPxFloatText.Text = $"sp : {100.01f}, pixel : {100.01f.SpToPx()}";
            rootView.Add(spToPxFloatText);

            var pixelToSpFloatText = new TextLabel();
            pixelToSpFloatText.Text = $"pixel : {60.01f}, sp : {60.01f.PxToSp()}";
            rootView.Add(pixelToSpFloatText);

            var spToPxIntText = new TextLabel();
            spToPxIntText.Text = $"sp : {100}, pixel : {100.SpToPx()}";
            rootView.Add(spToPxIntText);

            var pixelToSpIntText = new TextLabel();
            pixelToSpIntText.Text = $"pixel : {60}, sp : {60.PxToSp()}";
            rootView.Add(pixelToSpIntText);

            var spToPxSizeText = new TextLabel();
            var spSize = new Size(100.0f, 100.0f);
            var pixelSize = spSize.SpToPx();
            spToPxSizeText.Text = $"sp : ({spSize.Width}, {spSize.Height}), pixel : ({pixelSize.Width}, {pixelSize.Height})";
            rootView.Add(spToPxSizeText);

            var pixelToSpSizeText = new TextLabel();
            pixelSize = new Size(100.0f, 100.0f);
            spSize = pixelSize.PxToSp();
            pixelToSpSizeText.Text = $"pixel : ({pixelSize.Width}, {pixelSize.Height}), sp : ({spSize.Width}, {spSize.Height})";
            rootView.Add(pixelToSpSizeText);

            var spToPxPosText = new TextLabel();
            var spPos = new Position(100.0f, 100.0f);
            var pixelPos = spPos.SpToPx();
            spToPxPosText.Text = $"sp : ({spPos.X}, {spPos.Y}), pixel : ({pixelPos.X}, {pixelPos.Y})";
            rootView.Add(spToPxPosText);

            var pixelToSpPosText = new TextLabel();
            pixelPos = new Position(100.0f, 100.0f);
            spPos = pixelPos.PxToSp();
            pixelToSpPosText.Text = $"pixel : ({pixelPos.X}, {pixelPos.Y}), sp : ({spPos.X}, {spPos.Y})";
            rootView.Add(pixelToSpPosText);

            var spToPxRectText = new TextLabel();
            var spRect = new Rectangle(100, 100, 100, 100);
            var pixelRect = spRect.SpToPx();
            spToPxRectText.Text = $"sp : ({spRect.X}, {spRect.Y}, {spRect.Width}, {spRect.Height}), pixel : ({pixelRect.X}, {pixelRect.Y}, {pixelRect.Width}, {pixelRect.Height})";
            rootView.Add(spToPxRectText);

            var pixelToSpRectText = new TextLabel();
            pixelRect =new Rectangle(100, 100, 100, 100);
            spRect = pixelRect.PxToSp();
            pixelToSpRectText.Text = $"pixel : ({pixelRect.X}, {pixelRect.Y}, {pixelRect.Width}, {pixelRect.Height}), sp : ({spRect.X}, {spRect.Y}, {spRect.Width}, {spRect.Height})";
            rootView.Add(pixelToSpRectText);

            var spToPxExtentText = new TextLabel();
            var spExtent = new Extents(10, 10, 10, 10);
            var pixelExtent = spExtent.SpToPx();
            spToPxExtentText.Text = $"sp : ({spExtent.Start}, {spExtent.End}, {spExtent.Top}, {spExtent.Bottom}), pixel : ({pixelExtent.Start}, {pixelExtent.End}, {pixelExtent.Top}, {pixelExtent.Bottom})";
            rootView.Add(spToPxExtentText);

            var pixelToDpExtentText = new TextLabel();
            pixelExtent =new Extents(10, 10, 10, 10);
            spExtent = pixelExtent.PxToSp();
            pixelToDpExtentText.Text = $"pixel : ({pixelExtent.Start}, {pixelExtent.End}, {pixelExtent.Top}, {pixelExtent.Bottom}), sp : ({spExtent.Start}, {spExtent.End}, {spExtent.Top}, {spExtent.Bottom})";
            rootView.Add(pixelToDpExtentText);

            var pixelToPointText = new TextLabel();
            var fontPxSize = 30.0f;
            pixelToPointText.PointSize = fontPxSize.PxToPt();
            pixelToPointText.Text = $"pixel : {fontPxSize}, point: {fontPxSize.PxToPt()}";
            rootView.Add(pixelToPointText);

            var dpToPointText = new TextLabel();
            var dpPxSize = 80.0f;
            dpToPointText.PointSize = dpPxSize.DpToPt();
            dpToPointText.Text = $"pixel : {dpPxSize}, point: {dpPxSize.DpToPt()}";
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