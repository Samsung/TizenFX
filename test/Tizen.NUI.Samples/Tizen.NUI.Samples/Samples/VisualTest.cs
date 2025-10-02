using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
    public class VisualTest : IExample
    {
        Window window = null;

        static private string DEMO_IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";

        static private readonly string[] ImageUrlList = {
            //DEMO_IMAGE_DIR + "Dali/DaliDemo/application-icon-1.png",
            //DEMO_IMAGE_DIR + "AGIF/dog-anim.gif",
            //DEMO_IMAGE_DIR + "Dali/DaliDemo/Kid1.svg",
            DEMO_IMAGE_DIR + "Dali/ContactCard/gallery-small-2.jpg",
            DEMO_IMAGE_DIR + "Dali/ContactCard/gallery-small-3.jpg",
            DEMO_IMAGE_DIR + "Dali/ContactCard/gallery-small-4.jpg",
            DEMO_IMAGE_DIR + "Dali/ContactCard/gallery-small-5.jpg",
        };
        string MaskImageUrl = DEMO_IMAGE_DIR + "Dali/DaliDemo/shape-circle.png";

        const float viewSizeWidth = 320.0f;
        const float viewSizeHeight = 280.0f;
        const float thumbnailAreaHeight = 96.0f;
        const float thumbnailSize = 72.0f;
        const float viewGap = 24.0f;
        const float defaultCornerRadius = 16.0f;

        float cornerRadius = defaultCornerRadius;
        float cornerSquareness = 0.0f;

        View rootView;

        View[] visualViewList = new View[4];

        Visuals.ColorVisual focusIndicatorBorderVisual;
        Visuals.ColorVisual focusIndicatorInnerShadowVisual1;
        Visuals.ColorVisual focusIndicatorInnerShadowVisual2;
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
                Tizen.Log.Error("NUI", $"Key pressed. {e.Key.KeyPressedName}\n");
                if (e.Key.KeyPressedName == "1")
                {
                    Tizen.Log.Error("NUI", $"Reset scene\n");

                    rootView?.Unparent();
                    rootView?.Dispose();

                    focusIndicatorBorderVisual?.Dispose();
                    focusIndicatorInnerShadowVisual1?.Dispose();
                    focusIndicatorInnerShadowVisual2?.Dispose();
                    shadowVisual1?.Dispose();
                    shadowVisual2?.Dispose();

                    CreateFocusedVisuals();

                    CreateLayoutViews();

                    UpdateCornerRadius();
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
                    focusIndicatorBorderVisual.BorderlineWidth = 5.0f - focusIndicatorBorderVisual.BorderlineWidth;

                    focusIndicatorInnerShadowVisual1.BorderlineWidth = 8.0f - focusIndicatorInnerShadowVisual1.BorderlineWidth;

                    focusIndicatorInnerShadowVisual1.ExtraWidth = 20.0f - focusIndicatorInnerShadowVisual1.ExtraWidth;
                    focusIndicatorInnerShadowVisual1.ExtraHeight = 20.0f - focusIndicatorInnerShadowVisual1.ExtraHeight;
                    focusIndicatorInnerShadowVisual1.OffsetX = 10.0f - focusIndicatorInnerShadowVisual1.OffsetX;
                    focusIndicatorInnerShadowVisual1.OffsetY = 10.0f - focusIndicatorInnerShadowVisual1.OffsetY;

                    focusIndicatorInnerShadowVisual2.BorderlineWidth = 5.0f - focusIndicatorInnerShadowVisual2.BorderlineWidth;

                    focusIndicatorInnerShadowVisual2.Opacity = 0.15f - focusIndicatorInnerShadowVisual2.Opacity;

                    focusIndicatorInnerShadowVisual2.ExtraWidth = 20.0f - focusIndicatorInnerShadowVisual2.ExtraWidth;
                    focusIndicatorInnerShadowVisual2.ExtraHeight = 20.0f - focusIndicatorInnerShadowVisual2.ExtraHeight;
                    focusIndicatorInnerShadowVisual2.OffsetX = -10.0f - focusIndicatorInnerShadowVisual2.OffsetX;
                    focusIndicatorInnerShadowVisual2.OffsetY = -10.0f - focusIndicatorInnerShadowVisual2.OffsetY;
                }
                else if(e.Key.KeyPressedName == "5")
                {
                    cornerRadius += defaultCornerRadius;
                    if(cornerRadius > thumbnailAreaHeight * 0.5f + 1.0f)
                    {
                        cornerRadius = defaultCornerRadius;
                        cornerSquareness = 0.6f - cornerSquareness;
                    }

                    Tizen.Log.Error("NUI", $"Use corner radius {cornerRadius} and corner squareness {cornerSquareness} Scene\n");

                    UpdateCornerRadius();
                }
                else if(e.Key.KeyPressedName == "6")
                {
                    View focusedView = FocusManager.Instance.GetCurrentFocusView();
                    if(focusedView != null)
                    {
                        var thumbnailVisual = focusedView.FindVisualByName("thumbnailImage") as Visuals.ImageVisual;
                        if(thumbnailVisual != null)
                        {
                            thumbnailVisual.SamplingMode = GetNextSamplingModeType(thumbnailVisual.SamplingMode);
                        }
                    }
                }
                else if(e.Key.KeyPressedName == "7")
                {
                    View focusedView = FocusManager.Instance.GetCurrentFocusView();
                    if(focusedView != null)
                    {
                        var mainVisual = focusedView.FindVisualByName("mainImage") as Visuals.ImageVisual;
                        if(mainVisual != null)
                        {
                            if(string.IsNullOrEmpty(mainVisual.AlphaMaskUrl))
                            {
                                mainVisual.AlphaMaskUrl = MaskImageUrl;
                            }
                            else
                            {
                                mainVisual.AlphaMaskUrl = null;
                            }
                        }
                    }
                }
                else if (e.Key.KeyPressedName == "8")
                {
                    // Toggle some transform infomations
                    if (shadowVisual1 != null)
                    {
                        shadowVisual1.ExtraWidth = 20.0f - shadowVisual1.ExtraWidth;
                        shadowVisual1.ExtraHeight = 20.0f - shadowVisual1.ExtraHeight;

                        shadowVisual1.OffsetX = 100.0f - shadowVisual1.OffsetX;
                    }
                    if (shadowVisual2 != null)
                    {
                        shadowVisual2.ExtraWidth = 10.0f - shadowVisual2.ExtraWidth;
                        shadowVisual2.ExtraHeight = 10.0f - shadowVisual2.ExtraHeight;

                        shadowVisual2.OffsetY = 100.0f - shadowVisual2.OffsetY;
                    }
                }
            }
        }

        public void Deactivate()
        {
            window.KeyEvent -= WinKeyEvent;

            FocusManager.Instance.EnableDefaultAlgorithm(false);
            rootView?.Unparent();
            rootView?.Dispose();

            focusIndicatorBorderVisual?.Dispose();
            focusIndicatorInnerShadowVisual1?.Dispose();
            focusIndicatorInnerShadowVisual2?.Dispose();
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
            focusIndicatorBorderVisual = new Visuals.ColorVisual()
            {
                Name = "indicator",

                Origin = Visual.AlignType.Center,
                PivotPoint = Visual.AlignType.Center,

                Color = Color.Transparent,

                Width = 1.0f,
                Height = 1.0f,

                ExtraWidth = 1.0f,
                ExtraHeight = 1.0f,

                CornerRadius = new Vector4(16.5f, 16.5f, 16.5f, 16.5f),

                BorderlineWidth = 5.0f,
                BorderlineColor = Color.White,
                BorderlineOffset = -1.0f,
            };

            focusIndicatorInnerShadowVisual1 = new Visuals.ColorVisual()
            {
                Name = "indicator-shadow",

                Origin = Visual.AlignType.Center,
                PivotPoint = Visual.AlignType.Center,

                Color = Color.Transparent,

                Width = 1.0f,
                Height = 1.0f,

                ExtraWidth = -1.0f,
                ExtraHeight = -1.0f,

                OffsetXPolicy = VisualTransformPolicyType.Absolute,
                OffsetYPolicy = VisualTransformPolicyType.Absolute,

                CornerRadius = new Vector4(15.5f, 15.5f, 15.5f, 15.5f),

                BorderlineWidth = 3.0f,
                BorderlineColor = Color.Black,
                BorderlineOffset = -1.0f,

                BlurRadius = 5.0f,

                CutoutPolicy = ColorVisualCutoutPolicyType.CutoutOutsideWithCornerRadius,
            };

            focusIndicatorInnerShadowVisual2 = new Visuals.ColorVisual()
            {
                Name = "indicator-shadow2",

                Origin = Visual.AlignType.Center,
                PivotPoint = Visual.AlignType.Center,

                Color = Color.Transparent,

                Width = 1.0f,
                Height = 1.0f,

                ExtraWidth = -1.0f,
                ExtraHeight = -1.0f,

                OffsetXPolicy = VisualTransformPolicyType.Absolute,
                OffsetYPolicy = VisualTransformPolicyType.Absolute,

                CornerRadius = new Vector4(15.5f, 15.5f, 15.5f, 15.5f),

                BorderlineWidth = 0.0f,
                BorderlineColor = Color.White,
                BorderlineOffset = -1.0f,

                BlurRadius = 5.0f,

                CutoutPolicy = ColorVisualCutoutPolicyType.CutoutOutsideWithCornerRadius,
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

                CornerRadius = new Vector4(0.5f, 0.5f, 0.5f, 0.5f),
                CornerSquareness = new Vector4(0.6f, 0.6f, 0.6f, 0.6f),
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,

                BorderlineWidth = 2.0f,
                BorderlineColor = new Color(1.0f, 1.0f, 1.0f, 0.8f),
                BorderlineOffset = -1.0f,

                Origin = Visual.AlignType.BottomBegin,
                PivotPoint = Visual.AlignType.Center,

                OffsetX = thumbnailAreaHeight / 2.0f,
                OffsetY = -thumbnailAreaHeight / 2.0f,

                Width = thumbnailSize,
                Height = thumbnailSize,

                SynchronousSizing = true,

                SamplingMode = SamplingModeType.BoxThenLanczos,

                OffsetXPolicy = VisualTransformPolicyType.Absolute,
                OffsetYPolicy = VisualTransformPolicyType.Absolute,
                WidthPolicy = VisualTransformPolicyType.Absolute,
                HeightPolicy = VisualTransformPolicyType.Absolute,
            };

            Visuals.ColorVisual thumbnailShadow = new Visuals.ColorVisual()
            {
                Name = "thumbnailShadow",

                Color = Color.White,
                Opacity = 0.5f,

                CornerRadius = new Vector4(0.5f, 0.5f, 0.5f, 0.5f),
                CornerSquareness = new Vector4(0.6f, 0.6f, 0.6f, 0.6f),
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,

                BlurRadius = 8.0f,

                Origin = Visual.AlignType.BottomBegin,
                PivotPoint = Visual.AlignType.Center,

                OffsetX = thumbnailAreaHeight / 2.0f,
                OffsetY = -thumbnailAreaHeight / 2.0f,

                Width = thumbnailSize * 1.1f,
                Height = thumbnailSize * 1.1f,

                OffsetXPolicy = VisualTransformPolicyType.Absolute,
                OffsetYPolicy = VisualTransformPolicyType.Absolute,
                WidthPolicy = VisualTransformPolicyType.Absolute,
                HeightPolicy = VisualTransformPolicyType.Absolute,
            };

            view.AddVisual(backgroundVisual, ViewVisualContainerRange.Content);
            view.AddVisual(imageVisual, ViewVisualContainerRange.Content);
            view.AddVisual(foregroundVisual, ViewVisualContainerRange.Content);
            view.AddVisual(textVisual, ViewVisualContainerRange.Content);
            view.AddVisual(subTextVisual, ViewVisualContainerRange.Content);
            view.AddVisual(thumbnailShadow, ViewVisualContainerRange.Content);
            view.AddVisual(thumbnailVisual, ViewVisualContainerRange.Content);

            view.FocusGained += (s, e) =>
            {
                View me = s as View;
                if(me != null)
                {
                    Tizen.Log.Error("NUI", $"View {me.ID} focus gained.\n");

                    me.AddVisual(focusIndicatorInnerShadowVisual1, ViewVisualContainerRange.Decoration);
                    me.AddVisual(focusIndicatorInnerShadowVisual2, ViewVisualContainerRange.Decoration);
                    me.AddVisual(focusIndicatorBorderVisual, ViewVisualContainerRange.Decoration);
                    me.AddVisual(shadowVisual1, ViewVisualContainerRange.Background);
                    me.AddVisual(shadowVisual2, ViewVisualContainerRange.Background);

                    // focusIndicatorInnerShadowVisual1.RaiseToTop();
                    // focusIndicatorInnerShadowVisual2.RaiseAbove(focusIndicatorInnerShadowVisual1);
                    // focusIndicatorBorderVisual.RaiseAbove(focusIndicatorInnerShadowVisual2);
                    // shadowVisual1.LowerToBottom();
                    // shadowVisual2.LowerBelow(shadowVisual1);

                    var visual = me.FindVisualByName("foreground");
                    visual.Color = Color.LightGray;
                    visual.Opacity = 0.5f;

                    //visual = me.FindVisualByName("background");
                    visual = me.GetVisualAt(0u, ViewVisualContainerRange.Content); // Should be background
                    visual.Color = Color.White;

                    visual = me.FindVisualByName("thumbnailShadow");
                    visual.Color = Color.Black;
                    visual.Opacity = 0.5f;

                    var thumbnailVisual = me.FindVisualByName("thumbnailImage") as Visuals.ImageVisual;
                    thumbnailVisual.BorderlineColor = new Color(0.0f, 0.0f, 0.0f, 0.8f);

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

                    me.RemoveVisual(focusIndicatorBorderVisual);
                    me.RemoveVisual(focusIndicatorInnerShadowVisual1);
                    me.RemoveVisual(focusIndicatorInnerShadowVisual2);
                    me.RemoveVisual(shadowVisual1);
                    me.RemoveVisual(shadowVisual2);

                    var visual = me.FindVisualByName("foreground");
                    visual.Color = Color.LightSlateGray;
                    visual.Opacity = 0.5f;

                    //visual = me.FindVisualByName("background");
                    visual = me.GetVisualAt(0u, ViewVisualContainerRange.Content); // Should be background
                    visual.Color = Color.Gray;

                    visual = me.FindVisualByName("thumbnailShadow");
                    visual.Color = Color.White;
                    visual.Opacity = 0.5f;

                    var thumbnailVisual = me.FindVisualByName("thumbnailImage") as Visuals.ImageVisual;
                    thumbnailVisual.BorderlineColor = new Color(1.0f, 1.0f, 1.0f, 0.8f);

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

        private void UpdateCornerRadius()
        {
            foreach (var view in visualViewList)
            {
                if(view != null)
                {
                    view.CornerRadius = new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius);
                    view.CornerSquareness = new Vector4(cornerSquareness, cornerSquareness, cornerSquareness, cornerSquareness);

                    {
                        var visual = view.FindVisualByName("background") as Visuals.ColorVisual;
                        visual.CornerRadius = new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius);
                        visual.CornerSquareness = new Vector4(cornerSquareness, cornerSquareness, cornerSquareness, cornerSquareness);
                    }

                    {
                        var visual = view.FindVisualByName("mainImage") as Visuals.ImageVisual;
                        visual.CornerRadius = new Vector4(cornerRadius, cornerRadius, 0.0f, 0.0f);
                        visual.CornerSquareness = new Vector4(cornerSquareness, cornerSquareness, 0.0f, 0.0f);
                    }

                    {
                        var visual = view.FindVisualByName("foreground") as Visuals.ColorVisual;
                        visual.CornerRadius = new Vector4(0.0f, 0.0f, cornerRadius, cornerRadius);
                        visual.CornerSquareness = new Vector4(0.0f, 0.0f, cornerSquareness, cornerSquareness);
                    }
                }
            }

            float borderCornerRadius = cornerRadius + 0.5f;
            focusIndicatorBorderVisual.CornerRadius = new Vector4(borderCornerRadius, borderCornerRadius, borderCornerRadius, borderCornerRadius);
            focusIndicatorBorderVisual.CornerSquareness = new Vector4(cornerSquareness, cornerSquareness, cornerSquareness, cornerSquareness);

            borderCornerRadius = cornerRadius - 0.5f;
            focusIndicatorInnerShadowVisual1.CornerRadius = new Vector4(borderCornerRadius, borderCornerRadius, borderCornerRadius, borderCornerRadius);
            focusIndicatorInnerShadowVisual1.CornerSquareness = new Vector4(cornerSquareness, cornerSquareness, cornerSquareness, cornerSquareness);
            focusIndicatorInnerShadowVisual2.CornerRadius = new Vector4(borderCornerRadius, borderCornerRadius, borderCornerRadius, borderCornerRadius);
            focusIndicatorInnerShadowVisual2.CornerSquareness = new Vector4(cornerSquareness, cornerSquareness, cornerSquareness, cornerSquareness);

            shadowVisual1.CornerRadius = new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius);
            shadowVisual1.CornerSquareness = new Vector4(cornerSquareness, cornerSquareness, cornerSquareness, cornerSquareness);
            shadowVisual2.CornerRadius = new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius);
            shadowVisual2.CornerSquareness = new Vector4(cornerSquareness, cornerSquareness, cornerSquareness, cornerSquareness);
        }

        static private SamplingModeType GetNextSamplingModeType(SamplingModeType currentSamplingMode)
        {
            SamplingModeType nextSamplingMode = SamplingModeType.DontCare;
            switch(currentSamplingMode)
            {
                case SamplingModeType.Box:
                {
                    nextSamplingMode = SamplingModeType.Nearest;
                    break;
                }
                case SamplingModeType.Nearest:
                {
                    nextSamplingMode = SamplingModeType.Linear;
                    break;
                }
                case SamplingModeType.Linear:
                {
                    nextSamplingMode = SamplingModeType.BoxThenNearest;
                    break;
                }
                case SamplingModeType.BoxThenNearest:
                {
                    nextSamplingMode = SamplingModeType.BoxThenLinear;
                    break;
                }
                case SamplingModeType.BoxThenLinear:
                {
                    nextSamplingMode = SamplingModeType.Lanczos;
                    break;
                }
                case SamplingModeType.Lanczos:
                {
                    nextSamplingMode = SamplingModeType.BoxThenLanczos;
                    break;
                }
                case SamplingModeType.BoxThenLanczos:
                {
                    nextSamplingMode = SamplingModeType.DontCare;
                    break;
                }
                case SamplingModeType.DontCare:
                default:
                {
                    nextSamplingMode = SamplingModeType.Box;
                    break;
                }
            }
            Tizen.Log.Error("NUI", $"Change sampling mode from [{currentSamplingMode}] to [{nextSamplingMode}]\n");

            return nextSamplingMode;
        }
    }
}
