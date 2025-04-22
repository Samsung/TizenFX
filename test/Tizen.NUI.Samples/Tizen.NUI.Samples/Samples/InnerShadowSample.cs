using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
    public class InnerShadowSample : IExample
    {
        Window window = null;

        static private string DEMO_IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";

        static private readonly string[] ImageUrlList = {
            DEMO_IMAGE_DIR + "PopupTest/circle.jpg", // 360 x 360
            DEMO_IMAGE_DIR + "PaletteTest/red2.jpg", // 487 x 650
            DEMO_IMAGE_DIR + "PaletteTest/rock.jpg", // 626 x 469
            DEMO_IMAGE_DIR + "Dali/DaliDemo/Logo-for-demo.png", // 300 x 208
        };

        const float viewGap = 24.0f;
        const float defaultCornerRadius = 16.0f / 320.0f;
        const float defaultViewSizeWidth = 400.0f;
        const float defaultViewSizeHeight = 200.0f;
        const float defaultBorderlineWidth = 10.0f;
        const float defaultInnerShadowBlurRadius = 16.0f;
        const float defaultShadowBlurRadius = 24.0f;

        float viewSizeWidth = defaultViewSizeWidth;
        float viewSizeHeight = defaultViewSizeHeight;
        float cornerRadius = defaultCornerRadius * 4.0f;
        float cornerSquareness = 0.0f;

        static private readonly UIExtents[] shadowExtentsList = new UIExtents[]
        {
            // begin, end, top, bottom
            new UIExtents(defaultBorderlineWidth * 2.0f, 0.0f, defaultBorderlineWidth * 2.0f, 0.0f),
            new UIExtents(0.0f, defaultBorderlineWidth * 2.0f, 0.0f, defaultBorderlineWidth * 2.0f),
            new UIExtents(defaultBorderlineWidth * 2.0f, 0.0f),
            new UIExtents(0.0f, defaultBorderlineWidth * 2.0f),
            new UIExtents(defaultBorderlineWidth * 2.0f),
            new UIExtents(defaultBorderlineWidth * 4.0f),
            new UIExtents(defaultBorderlineWidth * 4.0f, 0.0f, 0.0f, 0.0f),
            new UIExtents(0.0f, defaultBorderlineWidth * 4.0f, 0.0f, 0.0f),
            new UIExtents(0.0f, 0.0f, defaultBorderlineWidth * 4.0f, 0.0f),
            new UIExtents(0.0f, 0.0f, 0.0f, defaultBorderlineWidth * 4.0f),
            new UIExtents(0.0f),
        };

        uint extentsIndex;
        UIExtents innerShadowExtents;

        FittingModeType fittingMode = FittingModeType.Fill;

        View rootView;

        ImageView[] imageViewList = new ImageView[4];

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();

            CreateLayoutViews();

            innerShadowExtents = shadowExtentsList[extentsIndex];

            RegenerateViews();

            window.KeyEvent += WinKeyEvent;
        }

        private void WinKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                Tizen.Log.Error("NUI", $"Key pressed. {e.Key.KeyPressedName}\n");
                if (e.Key.KeyPressedName == "1")
                {
                    viewSizeWidth -= 20.0f;
                    viewSizeHeight += 20.0f;
                    if(viewSizeWidth < defaultViewSizeHeight)
                    {
                        viewSizeWidth = defaultViewSizeWidth;
                        viewSizeHeight = defaultViewSizeHeight;
                    }
                    RegenerateViews();
                }
                else if(e.Key.KeyPressedName == "2")
                {
                    switch(fittingMode)
                    {
                        case FittingModeType.ShrinkToFit: fittingMode = FittingModeType.ScaleToFill; break;
                        case FittingModeType.ScaleToFill: fittingMode = FittingModeType.Center; break;
                        case FittingModeType.Center:      fittingMode = FittingModeType.Fill; break;
                        case FittingModeType.Fill:        fittingMode = FittingModeType.FitHeight; break;
                        case FittingModeType.FitHeight:   fittingMode = FittingModeType.FitWidth; break;
                        case FittingModeType.FitWidth:    fittingMode = FittingModeType.ShrinkToFit; break;
                    }
                    RegenerateViews();
                }
                else if(e.Key.KeyPressedName == "3")
                {
                    cornerRadius += defaultCornerRadius;
                    if(cornerRadius > 0.5001f)
                    {
                        cornerRadius = defaultCornerRadius;
                        cornerSquareness = 0.6f - cornerSquareness;
                    }
                    RegenerateViews();
                }
                else if(e.Key.KeyPressedName == "4")
                {
                    extentsIndex = (extentsIndex + 1) % (uint)shadowExtentsList.Length;
                    innerShadowExtents = shadowExtentsList[extentsIndex];
                    RegenerateViews();
                }
            }
        }

        public void Deactivate()
        {
            window.KeyEvent -= WinKeyEvent;

            rootView?.Unparent();
            rootView?.Dispose();
        }

        private void FullGC()
        {
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }

        private void CreateLayoutViews()
        {
            rootView = new View()
            {
                Name = "rootView",
                BackgroundColor = new Color("#7c9df0"),

                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };

            window.Add(rootView);
        }

        private void RegenerateViews()
        {
            Tizen.Log.Error("NUITest", $"Generate View with size {viewSizeWidth} x {viewSizeHeight} and fittingmode {fittingMode}, corner radius {cornerRadius} with {cornerSquareness}\n");
            Tizen.Log.Error("NUITest", $"  InnerShadow extents start : {innerShadowExtents.Start}, end : {innerShadowExtents.End} top : {innerShadowExtents.Top}, bottom : {innerShadowExtents.Bottom}\n");

            for(int i=0; i<4; i++)
            {
                imageViewList[i]?.Dispose();
                imageViewList[i]?.Unparent();
                imageViewList[i] = CreateImageView(i);
                rootView.Add(imageViewList[i]);
            }
        }

        private ImageView CreateImageView(int id)
        {
            ImageView view = new ImageView()
            {
                Name = $"ID{id}",

                ResourceUrl = ImageUrlList[id],

                SizeWidth = viewSizeWidth,
                SizeHeight = viewSizeHeight,
                FittingMode = fittingMode,

                PositionX = viewGap + (id % 2) * (viewSizeWidth + viewGap),
                PositionY = viewGap + (id / 2) * (viewSizeHeight + viewGap),

                InnerShadow = new InnerShadow(innerShadowExtents, defaultInnerShadowBlurRadius, Color.Black),
                BoxShadow = new Shadow(defaultShadowBlurRadius, ColorVisualCutoutPolicyType.CutoutViewWithCornerRadius, new Color(1.0f, 1.0f, 1.0f, 0.5f), new Vector2(0.0f, defaultShadowBlurRadius), new Vector2(defaultShadowBlurRadius, defaultShadowBlurRadius)),

                BorderlineWidth = defaultBorderlineWidth,
                BorderlineColor = Color.White,
                BorderlineOffset = -0.875f,

                CornerRadius = cornerRadius,
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                CornerSquareness = cornerSquareness,
            };

            return view;
        }
    }
}
