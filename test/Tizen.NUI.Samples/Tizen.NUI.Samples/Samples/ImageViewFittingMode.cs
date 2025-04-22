using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
    public class ImageViewFittingMode : IExample
    {
        Window window = null;

        static private string DEMO_IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";

        static private readonly string[] ImageUrlList = {
            DEMO_IMAGE_DIR + "PopupTest/circle.jpg",   // 360 x 360
            DEMO_IMAGE_DIR + "PaletteTest/red2.jpg",   // 487 x 650
            DEMO_IMAGE_DIR + "PaletteTest/rock.jpg",   // 626 x 469
            DEMO_IMAGE_DIR + "Dali/DaliDemo/Kid1.svg", // 307 x 417
        };

        const float viewGap = 24.0f;
        const float defaultCornerRadius = 16.0f;
        const float defaultViewSizeWidth = 400.0f;
        const float defaultViewSizeHeight = 200.0f;

        float viewSizeWidth = defaultViewSizeWidth;
        float viewSizeHeight = defaultViewSizeHeight;
        float cornerRadius = defaultCornerRadius;
        float cornerSquareness = 0.0f;

        FittingModeType fittingMode = FittingModeType.ShrinkToFit;

        View rootView;

        ImageView[] imageViewList = new ImageView[4];

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();

            CreateLayoutViews();

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
                    if(cornerRadius > 160.0f)
                    {
                        cornerRadius = defaultCornerRadius;
                        cornerSquareness = 0.6f - cornerSquareness;
                    }
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

                BorderlineWidth = 20.0f,
                BorderlineColor = Color.Blue,
                BorderlineOffset = -1.0f,

                CornerRadius = cornerRadius,
                CornerSquareness = cornerSquareness,
            };

            return view;
        }
    }
}
