
using global::System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Text;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;
    public class InnerShadowRadiusTest : IExample
    {
        private Vector4 ShadowColor = Color.Gray;
        private Vector4 backgroundColor = Color.LightGray;
        private Vector4 fontColor = new Vector4(0.5f, 0.5f, 0.5f, 1.0f);
        private Window window;
        Size ViewSize = new Size(350.0f, 200.0f);
        float cornerRadius = 40.0f;

        private View button;

        private float posS = -20.0f;
        private float posE = 10.0f;
        private float posT = -20.0f;
        private float posB = 10.0f;

        private Animation radiusLargerAnimation;
        private Animation radiusSmallerAnimation;
        private bool isAnimated = false;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            window.KeyEvent += OnKeyEvent;
            window.SetBackgroundColor(backgroundColor);

            button = CreateLowerButtonStyle(ViewSize, cornerRadius, new UIExtents(posS, posE, posT, posB), "inset");
            window.Add(button);


            TextLabel guide = new TextLabel()
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.BottomLeft,
                PivotPoint = PivotPoint.BottomLeft,
                MultiLine = true,
                Text = "Press lowercase l/r/t/b to expand the inner shadow outwards (Left/Right/Top/Bottom).\nPress uppercase L/R/T/B to shrink the inner shadow inwards.\nPress a to animate corner radius to 0.0.\n Press A to animate corner radius to half of the height.",
            };
            window.Add(guide); // Add guide to the window
        }

        private View CreateLowerButtonStyle(Size size, float cornerRadius, UIExtents extents, string text)
        {
            float blurRadius = 20.0f;
            TextLabel button = new TextLabel(text)
            {
                Name = "test_root",
                Size = size,
                CornerRadius = cornerRadius,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = fontColor,
                BackgroundColor = backgroundColor,

                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center
            };

            button.InnerShadow = new InnerShadow(extents, blurRadius, ShadowColor);

            return button;
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (isAnimated)
                {
                    return;
                }
                if (e.Key.KeyPressed == "a")
                {
                    if(radiusSmallerAnimation != null)
                    {
                        radiusSmallerAnimation.Dispose();
                    }

                    radiusSmallerAnimation = new Animation(2000);
                    radiusSmallerAnimation.AnimateTo(button, "CornerRadius", new Vector4(0.0f, 0.0f, 0.0f, 0.0f));
                    radiusSmallerAnimation.LoopingMode = Animation.LoopingModes.AutoReverse;
                    radiusSmallerAnimation.LoopCount = 1;
                    radiusSmallerAnimation.Play();
                    isAnimated = true;
                    radiusSmallerAnimation.Finished += (s, e) =>
                    {
                        isAnimated = false;
                    };
                    return;
                }
                if (e.Key.KeyPressed == "A")
                {
                    if(radiusLargerAnimation != null)
                    {
                        radiusLargerAnimation.Dispose();
                    }
                    radiusLargerAnimation = new Animation(2000);
                    radiusLargerAnimation.AnimateTo(button, "CornerRadius", new Vector4(100.0f, 100.0f, 100.0f, 100.0f));
                    radiusLargerAnimation.LoopingMode = Animation.LoopingModes.AutoReverse;
                    radiusLargerAnimation.LoopCount = 1;
                    radiusLargerAnimation.Play();
                    isAnimated = true;
                    radiusLargerAnimation.Finished += (s, e) =>
                    {
                        isAnimated = false;
                    };
                    return;
                }
                if (e.Key.KeyPressed == "l")
                {
                    posS -= 5.0f;
                }
                else if (e.Key.KeyPressed == "L")
                {
                    posS += 5.0f;
                }
                else if (e.Key.KeyPressed == "r")
                {
                    posE -= 5.0f;
                }
                else if (e.Key.KeyPressed == "R")
                {
                    posE += 5.0f;
                }
                else if (e.Key.KeyPressed == "t")
                {
                    posT -= 5.0f;
                }
                else if (e.Key.KeyPressed == "T")
                {
                    posT += 5.0f;
                }
                else if (e.Key.KeyPressed == "b")
                {
                    posB -= 5.0f;
                }
                else if (e.Key.KeyPressed == "B")
                {
                    posB += 5.0f;
                }
                window.Remove(button);
                button.Dispose();
                button = CreateLowerButtonStyle(ViewSize, cornerRadius, new UIExtents(posS, posE, posT, posB), "inset");
                window.Add(button);
            }
        }

        public void Deactivate()
        {
            var root = NUIApplication.GetDefaultWindow().GetRootLayer();
            while (root.ChildCount > 0)
            {
                var child = root.GetChildAt(0);
                root.Remove(child);
                child.DisposeRecursively();
            }
        }
    }
}
