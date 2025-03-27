using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System;

namespace Tizen.NUI.Samples
{
    public class SpringAnimationSample : IExample
    {
        private View root;
        private View customSpringView;
        private View control;

        private View spring;
        private uint springDecorationCount = 10;

        private Animation animation;

        private bool readyToAnimation;
        private bool readyToPrepare;
        private delegate float UserAlphaFunctionDelegate(float progress);
        private UserAlphaFunctionDelegate customSpringAlphaFunction;
        private AlphaFunction customAlphaFunction;

        // Control properties
        private static readonly float controlSize = 100.0f;
        private static readonly float targetOffset = 10.0f;

        // Physical properties
        private float b = 0.3f; // Air Resistance
        private float k = 1.5f; // Spring constant

        private uint rotationCount = 4; // The number of complex coordinate rotation

        // Physical properties controller
        private Slider sliderb;
        private Slider sliderk;

        private TextLabel labelb;
        private TextLabel labelk;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            // Basic controller
            root = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            sliderb = new Slider()
            {
                Position = new Position(0, 0),
                WidthResizePolicy = ResizePolicyType.FillToParent,
                MinValue = 0.01f,
                MaxValue = 1.0f,
                CurrentValue = b,
            };
            labelb = new TextLabel()
            {
                Position = new Position(0, 30),
                Text = "Air Resistance : " + b.ToString(),
            };
            root.Add(sliderb);
            root.Add(labelb);
            sliderk = new Slider()
            {
                Position = new Position(0, 60),
                WidthResizePolicy = ResizePolicyType.FillToParent,
                MinValue = 0.1f,
                MaxValue = 10.0f,
                CurrentValue = k,
            };
            labelk = new TextLabel()
            {
                Position = new Position(0, 90),
                Text = "Spring constant : " + k.ToString(),
            };
            root.Add(sliderk);
            root.Add(labelk);

            sliderb.ValueChanged += (o, e) =>
            {
                b = e.CurrentValue;
                labelb.Text = "Air Resistance : " + b.ToString();
            };
            sliderk.ValueChanged += (o, e) =>
            {
                k = e.CurrentValue;
                labelk.Text = "Spring constant : " + k.ToString();
            };

            // Prepare to change slider
            sliderb.IsEnabled = true;
            sliderk.IsEnabled = true;
            readyToPrepare = true;

            customSpringView = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FitToChildren,
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1.0f),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,

                GrabTouchAfterLeave = true, // Keep touch event
                AllowOnlyOwnTouch = true,
            };
            customSpringView.TouchEvent += (o, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down || e.Touch.GetState(0) == PointStateType.Motion)
                {
                    if (control)
                    {
                        readyToAnimation = true;
                        if (readyToPrepare)
                        {
                            // Do not change physical coefficient during animation prepare.
                            sliderb.IsEnabled = false;
                            sliderk.IsEnabled = false;
                            readyToPrepare = false;
                        }
                        else
                        {
                            // Stil animating now. Stop it.
                            animation?.Stop();
                        }
                        spring.SizeWidth = e.Touch.GetScreenPosition(0).X;
                    }
                }
                else if (e.Touch.GetState(0) == PointStateType.Finished || e.Touch.GetState(0) == PointStateType.Up || e.Touch.GetState(0) == PointStateType.Interrupted || e.Touch.GetState(0) == PointStateType.Leave)
                {
                    if (readyToAnimation)
                    {
                        if (control != null && animation != null)
                        {
                            readyToAnimation = false;
                            Tizen.Log.Error("NUI", $"Shoot!\n");
                            animation.Play();
                        }
                    }
                }
                else
                {
                    Tizen.Log.Error("NUI", $"customSlider get {e.Touch.GetState(0)} event!\n");
                }
                return true;
            };
            root.Add(customSpringView);

            // Add Decorations to custom spring
            spring = new View()
            {
                SizeWidth = controlSize * 0.5f + targetOffset,
                HeightResizePolicy = ResizePolicyType.FitToChildren,
                Position = new Position(0, 0),

                ParentOrigin = ParentOrigin.CenterLeft,
                PivotPoint = PivotPoint.CenterLeft,
                PositionUsesPivotPoint = true,
            };
            customSpringView.Add(spring);

            View decorator = new View()
            {
                // Follow the size even parent size changed by animation
                WidthResizePolicy = ResizePolicyType.KeepSizeFollowingParent,

                SizeHeight = controlSize * 0.5f,
                Position = new Position(0, 0),
                BackgroundColor = Color.Blue,

                CornerRadius = 0.5f,
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,

                ParentOrigin = ParentOrigin.CenterLeft,
                PivotPoint = PivotPoint.CenterLeft,
                PositionUsesPivotPoint = true,
            };
            spring.Add(decorator);

            // Show end of spring
            control = new View()
            {
                Size = new Size(controlSize, controlSize),
                Position = new Position(0, 0),

                ParentOrigin = ParentOrigin.CenterRight,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,

                BackgroundColor = Color.White,
                BoxShadow = new Shadow(0, new Color(0.2f, 0.2f, 0.2f, 0.3f), new Vector2(5, 5)),

                CornerRadius = 0.5f,
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                BorderlineWidth = controlSize * 0.1f,
                BorderlineColor = Color.Blue,
                BorderlineOffset = 1.0f,
            };

            spring.Add(control);

            customSpringAlphaFunction = new UserAlphaFunctionDelegate(CustomSpringAlphaFunction);
            customAlphaFunction = new AlphaFunction(customSpringAlphaFunction);

            animation = new Animation(2000);
            animation.AnimateTo(spring, "SizeWidth", controlSize * 0.5f + targetOffset, customAlphaFunction);
            animation.Finished += (o, e) =>
            {
                if (!readyToAnimation)
                {
                    sliderb.IsEnabled = true;
                    sliderk.IsEnabled = true;
                    readyToPrepare = true;
                }
                else
                {
                    // Animation is preparing now. Keep disabled.
                }
            };

            // Remove alpha function now, for test UserAlphaFunctionDelegate alived. 
            customSpringAlphaFunction = null;
            customAlphaFunction?.Dispose();

            window.Add(root);
        }

        private float CustomSpringAlphaFunction(float progress)
        {
            // F = ma + bv + kx = mx'' + bx' + kx = 0 (no gravity + mass is 1.0f)
            // Note : We can assume that m = 0.5f; Because we are not doing real physics!

            // Let w is result of 0.5x^2 + bx + k = 0.
            // Then, w = -b +- sqrt(b^2-2k).

            // Let D = b^2 - 2k
            // Then, x(t) = e^(wt) = e^(-bt) * e^(sqrt(D)*t)

            float t = progress;
            // Special case to resolve unknown error case.
            if (b == 0.0f || t > 0.999f)
            {
                return progress;
            }

            // Extend t as the number of rotation.
            t = t * rotationCount * 2.0f * MathF.PI;

            // Heuristic dumping rate resolver to make sure progress = 1.0f will return 1.0f
            float minimumDumpingRate = MathF.Exp(-b * rotationCount * 2.0f * MathF.PI);
            float dumpingRate = MathF.Exp(-b * t);

            float D = b * b - 2.0f * k;
            float x = 0.0f;
            if (D < 0.0f)
            {
                float theta = MathF.Sqrt(-D) * t;
                // e^(sqrt(D)*t) = cos(sqrt(-D)*t) + i sin(sqrt(-D)*t)
                x = MathF.Cos(theta);
            }
            else
            {
                x = MathF.Exp(MathF.Sqrt(D) * t);
            }
            return 1.0f - x * (dumpingRate - minimumDumpingRate) / (1.0f - minimumDumpingRate);
        }

        public void Deactivate()
        {
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.DisposeRecursively();
            }
            animation?.Stop();
            animation?.Clear();
            animation?.Dispose();
        }
    }
}
