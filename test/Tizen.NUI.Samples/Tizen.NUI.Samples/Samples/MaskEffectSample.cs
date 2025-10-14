using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class MaskEffectSample : IExample
    {
        const int WINDOW_WIDTH = 1920;
        const int WINDOW_HEIGHT = 1080;
        const int IMAGE_WIDTH = 1920;
        const int IMAGE_HEIGHT = 700;
        const int BOTTOM_HEIGHT = 200;
        const int TARGET_WIDTH = 200;
        const int LABEL_POINT_SIZE = 200;
        const int SMALL_LABEL_POINT_SIZE = 20;
        const int BUTTON_WIDTH = 300;
        const int BUTTON_HEIGHT = 100;
        const float positionX = 0.0f;
        const float positionY = 0.0f;
        const float scaleX = 1.0f;
        const float scaleY = 1.0f;
        private Window window;
        private View MainView;
        private View ButtonView;
        private View ImageView;
        private View BottomView;
        private View TargetView;
        private View SourceView;
        private int TargetImageMode = 1;
        private int SourceImageMode = 1;
        private MaskEffectMode maskMode = MaskEffectMode.Alpha;
        private View TargetImage1;
        private ImageView TargetImage2;
        private TextLabel SourceImage1;
        private ImageView SourceImage2;
        private View SmallTargetImage1;
        private ImageView SmallTargetImage2;
        private TextLabel SmallSourceImage1;
        private ImageView SmallSourceImage2;
        private Tizen.NUI.MaskEffect renderEffect;
        private ColorVisual backgroundVisual;
        private bool targetMaskOnce = false;
        private bool sourceMaskOnce = false;

        private void EnableRenderEffect()
        {
            TargetImage1.Unparent();
            TargetImage2.Unparent();

            TargetImage1.ClearRenderEffect();
            TargetImage2.ClearRenderEffect();

            renderEffect.Dispose();

            if (TargetImageMode == 1)
            {
                ImageView.Add(TargetImage1);

                if (SourceImageMode == 1)
                {
                    renderEffect = RenderEffect.CreateMaskEffect(SourceImage1, maskMode, positionX, positionY, scaleX, scaleY);
                    renderEffect.TargetMaskOnce = targetMaskOnce;
                    renderEffect.SourceMaskOnce = sourceMaskOnce;
                    TargetImage1.SetRenderEffect(renderEffect);
                }
                else
                {
                    renderEffect = RenderEffect.CreateMaskEffect(SourceImage2, maskMode, positionX, positionY, scaleX, scaleY);
                    renderEffect.TargetMaskOnce = targetMaskOnce;
                    renderEffect.SourceMaskOnce = sourceMaskOnce;
                    TargetImage1.SetRenderEffect(renderEffect);
                }
            }
            else
            {
                ImageView.Add(TargetImage2);
                TargetImage2.Unparent();
                ImageView.Add(TargetImage2);

                if (SourceImageMode == 1)
                {
                    renderEffect = RenderEffect.CreateMaskEffect(SourceImage1, maskMode, positionX, positionY, scaleX, scaleY);
                    renderEffect.TargetMaskOnce = targetMaskOnce;
                    renderEffect.SourceMaskOnce = sourceMaskOnce;
                    TargetImage2.SetRenderEffect(renderEffect);
                }
                else
                {
                    renderEffect = RenderEffect.CreateMaskEffect(SourceImage2, maskMode, positionX, positionY, scaleX, scaleY);
                    renderEffect.TargetMaskOnce = targetMaskOnce;
                    renderEffect.SourceMaskOnce = sourceMaskOnce;
                    TargetImage2.SetRenderEffect(renderEffect);
                }
            }
        }
        private void MaskTarget1ButtonClicked(object sender, ClickedEventArgs args)
        {
            TargetImageMode = 1;
            SmallTargetImage2.Unparent();
            TargetView.Add(SmallTargetImage1);

            EnableRenderEffect();
        }

        private void MaskTarget2ButtonClicked(object sender, ClickedEventArgs args)
        {
            TargetImageMode = 2;
            SmallTargetImage1.Unparent();
            TargetView.Add(SmallTargetImage2);

            EnableRenderEffect();
        }

        private void AlphaMaskModeButtonClicked(object sender, ClickedEventArgs args)
        {
            SourceImageMode = 1;
            SourceImage2.Unparent();
            ImageView.Add(SourceImage1);
            SmallSourceImage2.Unparent();
            SourceView.Add(SmallSourceImage1);

            maskMode = MaskEffectMode.Alpha;
            EnableRenderEffect();
        }

        private void LuminanceMaskModeButtonClicked(object sender, ClickedEventArgs args)
        {
            SourceImageMode = 2;
            SourceImage1.Unparent();
            ImageView.Add(SourceImage2);
            SmallSourceImage1.Unparent();
            SourceView.Add(SmallSourceImage2);

            maskMode = MaskEffectMode.Luminance;
            EnableRenderEffect();
        }

        private void TargetMaskOnceButtonClicked(object sender, ClickedEventArgs args)
        {
            targetMaskOnce = !targetMaskOnce;
            renderEffect.TargetMaskOnce = targetMaskOnce;
        }

        private void SourceMaskOnceButtonClicked(object sender, ClickedEventArgs args)
        {
            sourceMaskOnce = !sourceMaskOnce;
            renderEffect.SourceMaskOnce = sourceMaskOnce;
        }

        ImageView makeImageView(string url)
        {
            var image = new ImageView
            {
                ResourceUrl = url,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            };

            return image;
        }

        public void Activate()
        {
            string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

            window = NUIApplication.GetDefaultWindow();
            window.WindowSize = new Size(WINDOW_WIDTH, WINDOW_HEIGHT);
            window.BackgroundColor = Color.White;

            MainView = new View()
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Transparent,
                Margin = new Extents(0, 0, 6, 6),
            };

            ButtonView = new View
            {
                Size2D = new Size2D(WINDOW_WIDTH, WINDOW_HEIGHT - IMAGE_HEIGHT - BOTTOM_HEIGHT),
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                ParentOrigin = ParentOrigin.TopLeft,
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },
            };

            Button MaskTarget1Button = new Button()
            {
                Text = "MaskTarget1",
                BackgroundColor = Color.Red,
                Size2D = new Size2D(BUTTON_WIDTH, BUTTON_HEIGHT),
            };
            ButtonView.Add(MaskTarget1Button);
            MaskTarget1Button.Clicked += MaskTarget1ButtonClicked;

            Button MaskTarget2Button = new Button()
            {
                Text = "MaskTarget2",
                BackgroundColor = Color.Red,
                Size2D = new Size2D(BUTTON_WIDTH, BUTTON_HEIGHT),
            };
            ButtonView.Add(MaskTarget2Button);
            MaskTarget2Button.Clicked += MaskTarget2ButtonClicked;

            Button AlphaMaskModeButton = new Button()
            {
                Text = "AlphaMaskMode",
                BackgroundColor = Color.Blue,
                Size2D = new Size2D(BUTTON_WIDTH, BUTTON_HEIGHT),
            };
            ButtonView.Add(AlphaMaskModeButton);
            AlphaMaskModeButton.Clicked += AlphaMaskModeButtonClicked;

            Button LuminanceMaskModeButton = new Button()
            {
                Text = "LuminanceMaskMode",
                BackgroundColor = Color.Blue,
                Size2D = new Size2D(BUTTON_WIDTH, BUTTON_HEIGHT),
            };
            ButtonView.Add(LuminanceMaskModeButton);
            LuminanceMaskModeButton.Clicked += LuminanceMaskModeButtonClicked;

            Button TargetMaskOnceButton = new Button()
            {
                Text = "TargetMaskOnce",
                BackgroundColor = Color.Green,
                Size2D = new Size2D(BUTTON_WIDTH, BUTTON_HEIGHT),
            };
            ButtonView.Add(TargetMaskOnceButton);
            TargetMaskOnceButton.Clicked += TargetMaskOnceButtonClicked;

            Button SourceMaskOnceButton = new Button()
            {
                Text = "SourceMaskOnce",
                BackgroundColor = Color.Green,
                Size2D = new Size2D(BUTTON_WIDTH, BUTTON_HEIGHT),
            };
            ButtonView.Add(SourceMaskOnceButton);
            SourceMaskOnceButton.Clicked += SourceMaskOnceButtonClicked;

            backgroundVisual = new ColorVisual()
            {
                Color = Color.Black,
            };

            ImageView = new View
            {
                Size2D = new Size2D(IMAGE_WIDTH, IMAGE_HEIGHT),
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                ParentOrigin = ParentOrigin.TopLeft,

                Background = backgroundVisual.OutputVisualMap,
            };

            TargetImage1 = new View()
            {
                Size2D = new Size2D(IMAGE_WIDTH, IMAGE_HEIGHT),
                ParentOrigin = Position.ParentOriginTopLeft,
                PivotPoint = Position.PivotPointTopLeft,
                PositionUsesPivotPoint = true,
            };

            using (PropertyMap map = new PropertyMap())
            {
                map.Insert((int)Visual.Property.Type, new PropertyValue((int)Visual.Type.Gradient));
                map.Insert((int)GradientVisualProperty.StartPosition, new PropertyValue(new Vector2(0, 0)));
                map.Insert((int)GradientVisualProperty.EndPosition, new PropertyValue(new Vector2(WINDOW_WIDTH, WINDOW_HEIGHT)));

                var stopOffsetArray = new PropertyArray();
                stopOffsetArray.Add(new PropertyValue(0.0f));
                stopOffsetArray.Add(new PropertyValue(0.5f));
                stopOffsetArray.Add(new PropertyValue(1.0f));
                map.Insert((int)GradientVisualProperty.StopOffset, new PropertyValue(stopOffsetArray));

                var stopColorArray = new PropertyArray();
                stopColorArray.Add(new PropertyValue(Color.Red));
                stopColorArray.Add(new PropertyValue(Color.Green));
                stopColorArray.Add(new PropertyValue(Color.Blue));
                map.Insert((int)GradientVisualProperty.StopColor, new PropertyValue(stopColorArray));
                map.Insert((int)GradientVisualProperty.SpreadMethod, new PropertyValue((int)GradientVisualSpreadMethodType.Pad));
                map.Insert((int)GradientVisualProperty.Units, new PropertyValue((int)GradientVisualUnitsType.UserSpace));

                map.Insert((int)GradientVisualProperty.StartOffset, new PropertyValue(0.0f));

                TargetImage1.Background = map;
            }

            TargetImage2 = makeImageView(resourcePath + "/images/MaskEffectSample/ocean.gif");

            SourceImage1 = new TextLabel()
            {
                Size2D = new Size2D(IMAGE_WIDTH, IMAGE_HEIGHT),
                Text = "Hello, World!",
                PointSize = LABEL_POINT_SIZE,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            SourceImage2 = makeImageView(resourcePath + "/images/MaskEffectSample/blackwhite.gif");

            ImageView.Add(TargetImage1);
            ImageView.Add(SourceImage1);

            renderEffect = RenderEffect.CreateMaskEffect(SourceImage1);
            TargetImage1.SetRenderEffect(renderEffect);

            BottomView = new View()
            {
                Size2D = new Size2D(WINDOW_WIDTH, BOTTOM_HEIGHT),
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                ParentOrigin = ParentOrigin.TopLeft,
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },
            };

            TargetView = new View()
            {
                Size2D = new Size2D(TARGET_WIDTH, BOTTOM_HEIGHT),
            };
            SourceView = new View()
            {
                Size2D = new Size2D(TARGET_WIDTH, BOTTOM_HEIGHT),
            };

            TextLabel targetLabel = new TextLabel()
            {
                Text = "TARGET: ",
                Margin = new Extents(100, 50, 0, 0),
            };
            TextLabel sourceLabel = new TextLabel()
            {
                Text = "SOURCE: ",
                Margin = new Extents(100, 50, 0, 0),
            };

            BottomView.Add(targetLabel);
            BottomView.Add(TargetView);
            BottomView.Add(sourceLabel);
            BottomView.Add(SourceView);

            SmallTargetImage1 = new View()
            {
                Size2D = new Size2D(TARGET_WIDTH, BOTTOM_HEIGHT),
                ParentOrigin = Position.ParentOriginTopLeft,
                PivotPoint = Position.PivotPointTopLeft,
                PositionUsesPivotPoint = true,
            };

            using (PropertyMap map = new PropertyMap())
            {
                map.Insert((int)Visual.Property.Type, new PropertyValue((int)Visual.Type.Gradient));
                map.Insert((int)GradientVisualProperty.StartPosition, new PropertyValue(new Vector2(0, 0)));
                map.Insert((int)GradientVisualProperty.EndPosition, new PropertyValue(new Vector2(TARGET_WIDTH, BOTTOM_HEIGHT)));

                var stopOffsetArray = new PropertyArray();
                stopOffsetArray.Add(new PropertyValue(0.0f));
                stopOffsetArray.Add(new PropertyValue(0.5f));
                stopOffsetArray.Add(new PropertyValue(1.0f));
                map.Insert((int)GradientVisualProperty.StopOffset, new PropertyValue(stopOffsetArray));

                var stopColorArray = new PropertyArray();
                stopColorArray.Add(new PropertyValue(Color.Red));
                stopColorArray.Add(new PropertyValue(Color.Green));
                stopColorArray.Add(new PropertyValue(Color.Blue));
                map.Insert((int)GradientVisualProperty.StopColor, new PropertyValue(stopColorArray));
                map.Insert((int)GradientVisualProperty.SpreadMethod, new PropertyValue((int)GradientVisualSpreadMethodType.Pad));
                map.Insert((int)GradientVisualProperty.Units, new PropertyValue((int)GradientVisualUnitsType.UserSpace));

                map.Insert((int)GradientVisualProperty.StartOffset, new PropertyValue(0.0f));

                SmallTargetImage1.Background = map;
            }

            SmallTargetImage2 = makeImageView(resourcePath + "/images/MaskEffectSample/ocean.gif");

            SmallSourceImage1 = new TextLabel()
            {
                Size2D = new Size2D(TARGET_WIDTH, BOTTOM_HEIGHT),
                Text = "Hello, World!",
                PointSize = SMALL_LABEL_POINT_SIZE,
                TextColor = Color.Black,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            SmallSourceImage2 = makeImageView(resourcePath + "/images/MaskEffectSample/blackwhite.gif");

            TargetView.Add(SmallTargetImage1);
            SourceView.Add(SmallSourceImage1);

            MainView.Add(ButtonView);
            MainView.Add(ImageView);
            MainView.Add(BottomView);

            window.Add(MainView);
        }

        public void Deactivate()
        {
            MainView?.Unparent();
            MainView?.DisposeRecursively();

            backgroundVisual?.Dispose();

            renderEffect?.Dispose();
        }
    }
}
