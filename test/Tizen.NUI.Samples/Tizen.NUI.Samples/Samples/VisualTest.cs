using System.Net.Mime;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
    public class VisualTest : IExample
    {
        Window window = null;

        static private string DEMO_IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";

        static private readonly string focusIndicatorImageUrl = DEMO_IMAGE_DIR + "i_focus_stroke_tile_2unit.9.webp";
        static private readonly string[] ImageUrlList = {
            DEMO_IMAGE_DIR + "Dali/DaliDemo/application-icon-1.png",
            DEMO_IMAGE_DIR + "Dali/DaliDemo/application-icon-6.png",
            DEMO_IMAGE_DIR + "Dali/DaliDemo/Kid1.svg",
            DEMO_IMAGE_DIR + "Dali/ContactCard/gallery-small-2.jpg",
        };

        const float viewSizeWidth = 320.0f;
        const float viewSizeHeight = 280.0f;
        const float thumbnailAreaHeight = 96.0f;
        const float thumbnailSize = 72.0f;
        const float viewGap = 24.0f;

        View rootView;

        View[] visualViewList = new View[4];

        Visuals.NPatchVisual focusIndicatorVisual;
        Visuals.ColorVisual shadowVisual1;
        Visuals.ColorVisual shadowVisual2;

        public void Activate()
        {
            FocusManager.Instance.EnableDefaultAlgorithm(true);

            // To use custom indicator, in this sample, removed default indicator
            FocusManager.Instance.FocusIndicator = null;

            window = NUIApplication.GetDefaultWindow();

            CreateFocusedVisuals();

            CreateLayoutViews();

            window.KeyEvent += WinKeyEvent;
        }

        private void WinKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "1")
                {
                    Tizen.Log.Error("NUI", $"Reset scene\n");

                    rootView?.Unparent();
                    rootView?.Dispose();

                    focusIndicatorVisual?.Dispose();
                    shadowVisual1?.Dispose();
                    shadowVisual2?.Dispose();

                    CreateFocusedVisuals();

                    CreateLayoutViews();
                }
                else if(e.Key.KeyPressedName == "2")
                {
                    Tizen.Log.Error("NUI", $"GC test\n");
                    FullGC();
                }
                else if(e.Key.KeyPressedName == "3")
                {
                    View focusedView = FocusManager.Instance.GetCurrentFocusView();
                    if(focusedView != null)
                    {
                        float tmp = focusedView.SizeWidth;
                        focusedView.SizeWidth = focusedView.SizeHeight * 2.0f;
                        focusedView.SizeHeight = tmp / 2.0f;
                    }
                }
                else if(e.Key.KeyPressedName == "4")
                {
                    focusIndicatorVisual.ResourceUrl = null;
                }
                else if(e.Key.KeyPressedName == "5")
                {
                    focusIndicatorVisual.ResourceUrl = focusIndicatorImageUrl;
                }
            }
        }

        public void Deactivate()
        {
            window.KeyEvent -= WinKeyEvent;

            FocusManager.Instance.EnableDefaultAlgorithm(false);
            rootView?.Unparent();
            rootView?.Dispose();

            focusIndicatorVisual?.Dispose();
            shadowVisual1?.Dispose();
            shadowVisual2?.Dispose();
        }

        private void FullGC()
        {
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }

        private void CreateFocusedVisuals()
        {
            focusIndicatorVisual = new Visuals.NPatchVisual()
            {
                Name = "indicator",

                ResourceUrl = focusIndicatorImageUrl,

                Origin = Visual.AlignType.Center,
                PivotPoint = Visual.AlignType.Center,

                Width = 1.01f,
                Height = 1.01f,

                BorderOnly = true,
            };
            shadowVisual1 = new Visuals.ColorVisual()
            {
                Name = "shadow1",

                Color = new Color(0.0f, 0.0f, 0.0f, 0.2f),

                CornerRadius = new Vector4(16.0f, 16.0f, 16.0f, 16.0f),

                OffsetX = 2.0f,
                OffsetY = 5.0f,
                Width = 1.03f,
                Height = 1.01f,

                OffsetXPolicy = VisualTransformPolicyType.Absolute,
                OffsetYPolicy = VisualTransformPolicyType.Absolute,
            };
            shadowVisual2 = new Visuals.ColorVisual()
            {
                Name = "shadow2",

                Color = new Color(0.0f, 0.0f, 0.0f, 0.3f),

                CornerRadius = new Vector4(16.0f, 16.0f, 16.0f, 16.0f),

                OffsetX = 2.0f,
                OffsetY = 5.0f,
                Width = 1.01f,
                Height = 1.0f,

                OffsetXPolicy = VisualTransformPolicyType.Absolute,
                OffsetYPolicy = VisualTransformPolicyType.Absolute,
            };
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

            for(int i=0; i<4; i++)
            {
                visualViewList[i] = CreateViewWithVisual(i);
                rootView.Add(visualViewList[i]);
            }

            window.Add(rootView);
        }

        private View CreateViewWithVisual(int id)
        {
            View view = new View()
            {
                Name = $"ID{id}",

                SizeWidth = viewSizeWidth,
                SizeHeight = viewSizeHeight,
                PositionX = viewGap + (id % 2) * (viewSizeWidth + viewGap),
                PositionY = viewGap + (id / 2) * (viewSizeHeight + viewGap),

                Focusable = true,
                FocusableInTouch = true,
                KeyInputFocus = true,

                Padding = new Extents(10, 10, 10, (ushort)thumbnailAreaHeight),
            };

            Visuals.ColorVisual backgroundVisual = new Visuals.ColorVisual()
            {
                Name = "background",

                Color = Color.Gray,

                CornerRadius = new Vector4(16.0f, 16.0f, 16.0f, 16.0f),
            };

            Visuals.ImageVisual imageVisual = new Visuals.ImageVisual()
            {
                Name = "mainImage",

                ResourceUrl = ImageUrlList[id % 4],

                CornerRadius = new Vector4(16.0f, 16.0f, 0.0f, 0.0f),

                FittingMode = VisualFittingModeType.FitKeepAspectRatio,
            };

            Visuals.ColorVisual foregroundVisual = new Visuals.ColorVisual()
            {
                Name = "foreground",

                Color = Color.LightSlateGray,
                Opacity = 0.5f,

                CornerRadius = new Vector4(0.0f, 0.0f, 16.0f, 16.0f),

                Origin = Visual.AlignType.BottomBegin,
                PivotPoint = Visual.AlignType.BottomBegin,

                Height = thumbnailAreaHeight,

                HeightPolicy = VisualTransformPolicyType.Absolute,
            };

            Visuals.TextVisual textVisual = new Visuals.TextVisual()
            {
                Name = "text",

                Text = $"View {id} long text long long long long looooong",
                TextColor = Color.White,
                PointSize = 20.0f,

                Origin = Visual.AlignType.BottomBegin,
                PivotPoint = Visual.AlignType.BottomBegin,
                
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,

                OffsetX = thumbnailAreaHeight,
                OffsetY = -thumbnailAreaHeight * 0.4f,
                Width = viewSizeWidth - thumbnailAreaHeight,
                Height = thumbnailAreaHeight * 0.6f,

                OffsetXPolicy = VisualTransformPolicyType.Absolute,
                OffsetYPolicy = VisualTransformPolicyType.Absolute,
                WidthPolicy = VisualTransformPolicyType.Absolute,
                HeightPolicy = VisualTransformPolicyType.Absolute,
            };

            Visuals.AdvancedTextVisual subTextVisual = new Visuals.AdvancedTextVisual()
            {
                Name = "subtext",

                Text = "subtext",
                TextColor = Color.White,
                PointSize = 12.0f,

                Origin = Visual.AlignType.BottomBegin,
                PivotPoint = Visual.AlignType.BottomBegin,
                
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,

                OffsetX = thumbnailAreaHeight,
                Width = viewSizeWidth - thumbnailAreaHeight,
                Height = thumbnailAreaHeight * 0.4f,

                OffsetXPolicy = VisualTransformPolicyType.Absolute,
                WidthPolicy = VisualTransformPolicyType.Absolute,
                HeightPolicy = VisualTransformPolicyType.Absolute,
            };

            try
            {
                subTextVisual.TranslatableText = "SID_OK";
            }
            catch(global::System.Exception e)
            {
                subTextVisual.Text = e.Message;
            }

            Visuals.ImageVisual thumbnailVisual = new Visuals.ImageVisual()
            {
                Name = "thumbnailImage",

                ResourceUrl = ImageUrlList[id % 4],

                CornerRadius = new Vector4(8.0f, 8.0f, 8.0f, 8.0f),

                Origin = Visual.AlignType.BottomBegin,
                PivotPoint = Visual.AlignType.Center,

                OffsetX = thumbnailAreaHeight / 2.0f,
                OffsetY = -thumbnailAreaHeight / 2.0f,

                Width = thumbnailSize,
                Height = thumbnailSize,

                DesiredWidth = (int)thumbnailSize,
                DesiredHeight = (int)thumbnailSize,

                OffsetXPolicy = VisualTransformPolicyType.Absolute,
                OffsetYPolicy = VisualTransformPolicyType.Absolute,
                WidthPolicy = VisualTransformPolicyType.Absolute,
                HeightPolicy = VisualTransformPolicyType.Absolute,
            };

            view.AddVisual(backgroundVisual);
            view.AddVisual(imageVisual);
            view.AddVisual(foregroundVisual);
            view.AddVisual(textVisual);
            view.AddVisual(subTextVisual);
            view.AddVisual(thumbnailVisual);

            view.FocusGained += (s, e) =>
            {
                View me = s as View;
                if(me != null)
                {
                    Tizen.Log.Error("NUI", $"View {me.ID} focus gained.\n");

                    me.AddVisual(focusIndicatorVisual);
                    me.AddVisual(shadowVisual1);
                    me.AddVisual(shadowVisual2);

                    focusIndicatorVisual.RaiseToTop();
                    shadowVisual1.LowerToBottom();
                    shadowVisual2.LowerBelow(shadowVisual1);

                    var visual = me.FindVisualByName("foreground");
                    visual.Color = Color.LightGray;
                    visual.Opacity = 0.5f;

                    //visual = me.FindVisualByName("background");
                    visual = me.GetVisualAt(2u); // Should be background
                    visual.Color = Color.White;

                    var textVisual = me.FindVisualByName("text") as Visuals.TextVisual;
                    textVisual.TextColor = Color.Black;
                    textVisual = me.FindVisualByName("subtext") as Visuals.TextVisual;
                    textVisual.TextColor = Color.Black;
                }
            };

            view.FocusLost += (s, e) =>
            {
                View me = s as View;
                if(me != null)
                {
                    Tizen.Log.Error("NUI", $"View {me.ID} focus losted.\n");

                    me.RemoveVisual(focusIndicatorVisual);
                    me.RemoveVisual(shadowVisual1);
                    me.RemoveVisual(shadowVisual2);

                    var visual = me.FindVisualByName("foreground");
                    visual.Color = Color.LightSlateGray;
                    visual.Opacity = 0.5f;

                    //visual = me.FindVisualByName("background");
                    visual = me.GetVisualAt(0u); // Should be background
                    visual.Color = Color.Gray;

                    var textVisual = me.FindVisualByName("text") as Visuals.TextVisual;
                    textVisual.TextColor = Color.White;
                    textVisual = me.FindVisualByName("subtext") as Visuals.TextVisual;
                    textVisual.TextColor = Color.White;
                }
            };

            view.TouchEvent += (o, e) =>
            {
                return true;
            };

            return view;
        }
    }
}
