using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class GraphicsTypeTest : IExample
    {
        private Window window;
        private ScrollableBase rootView;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();

            rootView = new ScrollableBase()
            {
                WidthSdpecification = LayoutParamPolicies.MatchParent,
                HeightSdpecification = LayoutParamPolicies.MatchParent,
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

            var sdpConvertText = new TextLabel();
            var sdp = 100.0f;
            sdpConvertText.Text = $"sdp : {sdp}, pixel : {SdpTypeConverter.Instance.ConvertToPixel(sdp)}";
            rootView.Add(sdpConvertText);

            pxConvertText = new TextLabel();
            px = 100.0f;
            pxConvertText.Text = $"pixel : {px}, sdp : {PointTypeConverter.Instance.ConvertFromPixel(px)}";
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

            var sdpToPxFloatText = new TextLabel();
            sdpToPxFloatText.Text = $"sdp : {100.01f}, pixel : {100.01f.Sdp()}";
            rootView.Add(sdpToPxFloatText);

            var pixelToSdpFloatText = new TextLabel();
            pixelToSdpFloatText.Text = $"pixel : {60.01f}, sdp : {60.01f.PxToSdp()}";
            rootView.Add(pixelToSdpFloatText);

            var sdpToPxIntText = new TextLabel();
            sdpToPxIntText.Text = $"sdp : {100}, pixel : {100.Sdp()}";
            rootView.Add(sdpToPxIntText);

            var pixelToSdpIntText = new TextLabel();
            pixelToSdpIntText.Text = $"pixel : {60}, sdp : {60.PxToSdp()}";
            rootView.Add(pixelToSdpIntText);

            var sdpToPxSizeText = new TextLabel();
            var sdpSize = new Size(100.0f, 100.0f);
            var pixelSize = sdpSize.SdpToPx();
            sdpToPxSizeText.Text = $"sdp : ({sdpSize.Width}, {sdpSize.Height}), pixel : ({pixelSize.Width}, {pixelSize.Height})";
            rootView.Add(sdpToPxSizeText);

            var pixelToSdpSizeText = new TextLabel();
            pixelSize = new Size(100.0f, 100.0f);
            sdpSize = pixelSize.PxToSdp();
            pixelToSdpSizeText.Text = $"pixel : ({pixelSize.Width}, {pixelSize.Height}), sdp : ({sdpSize.Width}, {sdpSize.Height})";
            rootView.Add(pixelToSdpSizeText);

            var sdpToPxPosText = new TextLabel();
            var sdpPos = new Position(100.0f, 100.0f);
            var pixelPos = sdpPos.SdpToPx();
            sdpToPxPosText.Text = $"sdp : ({sdpPos.X}, {sdpPos.Y}), pixel : ({pixelPos.X}, {pixelPos.Y})";
            rootView.Add(sdpToPxPosText);

            var pixelToSdpPosText = new TextLabel();
            pixelPos = new Position(100.0f, 100.0f);
            sdpPos = pixelPos.PxToSdp();
            pixelToSdpPosText.Text = $"pixel : ({pixelPos.X}, {pixelPos.Y}), sdp : ({sdpPos.X}, {sdpPos.Y})";
            rootView.Add(pixelToSdpPosText);

            var sdpToPxRectText = new TextLabel();
            var sdpRect = new Rectangle(100, 100, 100, 100);
            var pixelRect = sdpRect.SdpToPx();
            sdpToPxRectText.Text = $"sdp : ({sdpRect.X}, {sdpRect.Y}, {sdpRect.Width}, {sdpRect.Height}), pixel : ({pixelRect.X}, {pixelRect.Y}, {pixelRect.Width}, {pixelRect.Height})";
            rootView.Add(sdpToPxRectText);

            var pixelToSdpRectText = new TextLabel();
            pixelRect =new Rectangle(100, 100, 100, 100);
            sdpRect = pixelRect.PxToSdp();
            pixelToSdpRectText.Text = $"pixel : ({pixelRect.X}, {pixelRect.Y}, {pixelRect.Width}, {pixelRect.Height}), sdp : ({sdpRect.X}, {sdpRect.Y}, {sdpRect.Width}, {sdpRect.Height})";
            rootView.Add(pixelToSdpRectText);

            var sdpToPxExtentText = new TextLabel();
            var sdpExtent = new Extents(10, 10, 10, 10);
            var pixelExtent = sdpExtent.SdpToPx();
            sdpToPxExtentText.Text = $"sdp : ({sdpExtent.Start}, {sdpExtent.End}, {sdpExtent.Top}, {sdpExtent.Bottom}), pixel : ({pixelExtent.Start}, {pixelExtent.End}, {pixelExtent.Top}, {pixelExtent.Bottom})";
            rootView.Add(sdpToPxExtentText);

            var pixelToDpExtentText = new TextLabel();
            pixelExtent =new Extents(10, 10, 10, 10);
            sdpExtent = pixelExtent.PxToSdp();
            pixelToDpExtentText.Text = $"pixel : ({pixelExtent.Start}, {pixelExtent.End}, {pixelExtent.Top}, {pixelExtent.Bottom}), sdp : ({sdpExtent.Start}, {sdpExtent.End}, {sdpExtent.Top}, {sdpExtent.Bottom})";
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
            rootView.Disdpose();
            rootView = null;
        }
    }
}