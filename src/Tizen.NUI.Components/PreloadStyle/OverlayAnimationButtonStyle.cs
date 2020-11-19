/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Describes Button Animation used in OneUI_Watch2.X
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class OverlayAnimationButtonStyle : ButtonStyle
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public OverlayAnimationButtonStyle() : base()
        {
            CornerRadius = 10;
            BackgroundColor = new Selector<Color> { All = new Color(0.3f, 0.3f, 0.3f, 0.5f) };
            // PositionUsesPivotPoint = true;
            IconRelativeOrientation = Button.IconOrientation.Top;
            Text = new TextLabelStyle
            {
                FontFamily = "SamsungOne 700",
                PixelSize = 20,
                TextColor = new Selector<Color>
                {
                    Normal = new Color(1, 1, 1, 0.70f),
                    Pressed = new Color(1, 1, 1, 0.60f),
                    Disabled = new Color(1, 1, 1, 0.40f),
                },
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            Icon = new ImageViewStyle
            {
                WidthResizePolicy = ResizePolicyType.SizeRelativeToParent,
                HeightResizePolicy = ResizePolicyType.SizeRelativeToParent,
                SizeModeFactor = new Vector3(0.35f, 0.35f, 0.35f),
                Opacity = new Selector<float?>
                {
                    Normal = 0.7f,
                    Pressed = 0.5f
                }
            };
            Opacity = new Selector<float?>
            {
                Disabled = 0.3f,
                Other = 1.0f
            };
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ButtonExtension CreateExtension()
        {
            return new OverlayAnimationButtonExtension();
        }
    }

    /// <summary>
    /// OverlayAnimationButtonExtension class is a extended ButtonExtension class that make the overlay image blinking on a Button pressed.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class OverlayAnimationButtonExtension : ButtonExtension
    {
        private Animation PressAnimation { get; set; }

        /// <summary>
        /// Creates a new instance of a OverlayAnimationButtonExtension.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OverlayAnimationButtonExtension() : base()
        {
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageView OnCreateOverlayImage(Button button, ImageView overlayImage)
        {
            overlayImage.Hide();

            return overlayImage;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnControlStateChanged(Button button, View.ControlStateChangedEventArgs args)
        {
            if (button.ControlState != ControlState.Pressed)
            {
                return;
            }

            var overlayImage = button.OverlayImage;

            if (overlayImage == null)
            {
                return;
            }

            if (null == PressAnimation)
            {
                var keyFrames = new KeyFrames();
                keyFrames.Add(0.0f, 0.0f);
                AlphaFunction linear = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);
                keyFrames.Add(0.25f, 1.0f, linear);
                linear.Dispose();
                AlphaFunction ease = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut);
                keyFrames.Add(1.0f, 0.0f, ease);
                ease.Dispose();

                PressAnimation = new Animation(600);
                PressAnimation.EndAction = Animation.EndActions.StopFinal;
                PressAnimation.AnimateBetween(overlayImage, "Opacity", keyFrames);
                keyFrames.Dispose();
                Vector3 vec = new Vector3(1, 1, 1);
                AlphaFunction easeout = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut);
                PressAnimation.AnimateTo(overlayImage, "Scale", vec, 0, 600, easeout);
                vec.Dispose();
                easeout.Dispose();
            }

            if (PressAnimation.State == Animation.States.Playing)
            {
                PressAnimation.Stop();
                overlayImage.Hide();
            }

            overlayImage.Opacity = 0.0f;
            overlayImage.CornerRadius = button.CornerRadius;
            overlayImage.Background = button.Background;
            overlayImage.Size = button.Size;
            overlayImage.Scale = new Vector3(0.80f, 0.80f, 1);
            overlayImage.Show();

            PressAnimation.Play();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnDispose(Button button)
        {
            if (PressAnimation == null)
            {
                return;
            }

            if (PressAnimation.State == Animation.States.Playing)
            {
                PressAnimation.Stop();
            }
            PressAnimation.Dispose();
            PressAnimation = null;
        }
    }
}
