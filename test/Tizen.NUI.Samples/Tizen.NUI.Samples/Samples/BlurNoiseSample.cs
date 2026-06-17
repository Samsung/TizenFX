using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class BlurNoiseSample : IExample
    {
        private const uint DefaultBlurRadius = 40u;
        private const float DefaultDownscaleFactor = 0.15f;
        private const float InitialNoiseStrength = 0.1f;
        private const int ImageSize = 200;
        private const int ImageGapX = 120;
        private const int ImageGapY = 90;
        private const int BoardColumns = 6;
        private const int BoardRows = 4;

        private static readonly Color[] BackgroundColors =
        {
            new Color(0.02f, 0.03f, 0.04f, 1.0f),
            new Color(0.11f, 0.10f, 0.13f, 1.0f),
            new Color(0.07f, 0.12f, 0.10f, 1.0f),
            new Color(0.15f, 0.10f, 0.05f, 1.0f),
        };

        private Window window;
        private View root;
        private View imageBoard;
        private View blurPane;
        private TextLabel statusLabel;
        private Animation boardAnimation;
        private BackgroundBlurEffect backgroundBlur;
        private uint blurRadius = DefaultBlurRadius;
        private float noiseStrength = InitialNoiseStrength;
        private int speedIndex = 1;
        private int colorIndex;
        private bool blurEnabled = true;
        private bool animationPlaying = true;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();

            root = new View
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = BackgroundColors[colorIndex],
            };
            window.Add(root);

            CreateImageBoard();
            CreateBlurPane();
            CreateLabels();
            CreateAnimation();

            window.KeyEvent += OnKeyEvent;
        }

        public void Deactivate()
        {
            if (window != null)
            {
                window.KeyEvent -= OnKeyEvent;
            }

            boardAnimation?.Stop();
            boardAnimation?.Dispose();
            boardAnimation = null;

            backgroundBlur?.Dispose();
            backgroundBlur = null;

            root?.Unparent();
            root?.Dispose();
            root = null;
            imageBoard = null;
            blurPane = null;
            statusLabel = null;
        }

        private void CreateImageBoard()
        {
            imageBoard = new View
            {
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                Size2D = new Size2D(BoardColumns * ImageSize + (BoardColumns - 1) * ImageGapX, BoardRows * ImageSize + (BoardRows - 1) * ImageGapY),
            };
            root.Add(imageBoard);

            string imageDirectory = CommonResource.GetDaliResourcePath() + "CubeTransitionEffect/";
            for (int row = 0; row < BoardRows; row++)
            {
                for (int column = 0; column < BoardColumns; column++)
                {
                    int imageIndex = (row * BoardColumns + column) % 21 + 1;
                    ImageView image = new ImageView(imageDirectory + $"gallery-large-{imageIndex}.jpg")
                    {
                        ParentOrigin = ParentOrigin.Center,
                        PivotPoint = PivotPoint.Center,
                        PositionUsesPivotPoint = true,
                        Size2D = new Size2D(ImageSize, ImageSize),
                        Position = new Position((column - (BoardColumns - 1) * 0.5f) * (ImageSize + ImageGapX),
                                                (row - (BoardRows - 1) * 0.5f) * (ImageSize + ImageGapY),
                                                0.0f),
                        FittingMode = FittingModeType.ScaleToFill,
                    };
                    imageBoard.Add(image);
                }
            }
        }

        private void CreateBlurPane()
        {
            blurPane = new View
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };

            backgroundBlur = RenderEffect.CreateBackgroundBlurEffect(DefaultBlurRadius);
            backgroundBlur.BlurOnce = false;
            backgroundBlur.BlurDownscaleFactor = DefaultDownscaleFactor;
            backgroundBlur.DitherNoiseStrength = noiseStrength;

            blurPane.SetRenderEffect(backgroundBlur);
            root.Add(blurPane);
        }

        private void CreateLabels()
        {
            statusLabel = new TextLabel
            {
                ParentOrigin = ParentOrigin.TopRight,
                PivotPoint = PivotPoint.TopRight,
                PositionUsesPivotPoint = true,
                Position = new Position(-16.0f, 16.0f, 0.0f),
                Size2D = new Size2D(360, 48),
                TextColor = Color.White,
                PointSize = 8.0f,
                HorizontalAlignment = HorizontalAlignment.End,
                VerticalAlignment = VerticalAlignment.Center,
            };
            root.Add(statusLabel);

            TextLabel guideLabel = new TextLabel("1 Blur  2 Speed  3/4 Radius -/+  5 BG  6 Animation  7/8 Noise -/+  Esc/Back Quit")
            {
                ParentOrigin = ParentOrigin.BottomCenter,
                PivotPoint = PivotPoint.BottomCenter,
                PositionUsesPivotPoint = true,
                Position = new Position(0.0f, -12.0f, 0.0f),
                Size2D = new Size2D(940, 46),
                BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.62f),
                TextColor = new Color(1.0f, 0.88f, 0.20f, 1.0f),
                PointSize = 7.2f,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            root.Add(guideLabel);

            UpdateStatus();
        }

        private void CreateAnimation()
        {
            boardAnimation?.Stop();
            boardAnimation?.Dispose();

            int duration = speedIndex switch
            {
                0 => 9000,
                1 => 5500,
                _ => 3000,
            };

            boardAnimation = new Animation(duration)
            {
                Looping = true,
            };

            KeyFrames positionFrames = new KeyFrames();
            positionFrames.Add(0.00f, new Vector3(-120.0f, -80.0f, 0.0f));
            positionFrames.Add(0.25f, new Vector3(160.0f, -40.0f, 0.0f));
            positionFrames.Add(0.50f, new Vector3(100.0f, 130.0f, 0.0f));
            positionFrames.Add(0.75f, new Vector3(-170.0f, 90.0f, 0.0f));
            positionFrames.Add(1.00f, new Vector3(-120.0f, -80.0f, 0.0f));
            boardAnimation.AnimateBetween(imageBoard, "Position", positionFrames);

            if (animationPlaying)
            {
                boardAnimation.Play();
            }
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State != Key.StateType.Down)
            {
                return;
            }

            switch (e.Key.KeyPressedName)
            {
                case "1":
                    blurEnabled = !blurEnabled;
                    if (blurEnabled)
                    {
                        blurPane.Show();
                    }
                    else
                    {
                        blurPane.Hide();
                    }
                    break;
                case "2":
                    speedIndex = (speedIndex + 1) % 3;
                    CreateAnimation();
                    break;
                case "3":
                    blurRadius = Math.Max(1u, blurRadius - 5u);
                    backgroundBlur.BlurRadius = blurRadius;
                    break;
                case "4":
                    blurRadius += 5u;
                    backgroundBlur.BlurRadius = blurRadius;
                    break;
                case "5":
                    colorIndex = (colorIndex + 1) % BackgroundColors.Length;
                    root.BackgroundColor = BackgroundColors[colorIndex];
                    break;
                case "6":
                    animationPlaying = !animationPlaying;
                    if (animationPlaying)
                    {
                        boardAnimation.Play();
                    }
                    else
                    {
                        boardAnimation.Stop();
                    }
                    break;
                case "7":
                    noiseStrength = Math.Max(0.0f, noiseStrength - 0.05f);
                    backgroundBlur.DitherNoiseStrength = noiseStrength;
                    break;
                case "8":
                    noiseStrength = Math.Min(1.0f, noiseStrength + 0.05f);
                    backgroundBlur.DitherNoiseStrength = noiseStrength;
                    break;
            }

            UpdateStatus();
        }

        private void UpdateStatus()
        {
            if (statusLabel == null)
            {
                return;
            }

            string blurText = blurEnabled ? "ON" : "OFF";
            string animationText = animationPlaying ? "ON" : "OFF";
            statusLabel.Text = $"Blur {blurText}  Radius {blurRadius}  Downscale {backgroundBlur.BlurDownscaleFactor:0.00}  Noise {noiseStrength:0.00}  Animation {animationText}";
        }
    }
}
