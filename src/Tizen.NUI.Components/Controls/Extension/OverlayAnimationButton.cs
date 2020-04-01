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

namespace Tizen.NUI.Components.Extension
{
    /// <summary>
    /// OverlayAnimationButton class is a extended Button class that make the overlay image blinking on pressed.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class OverlayAnimationButton : Button
    {
        private Animation PressAnimation { get; set; }

        /// <summary>
        /// Creates a new instance of a OverlayAnimationButton.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OverlayAnimationButton() : base()
        {
        }

        /// <summary>
        /// Creates a new instance with style.
        /// </summary>
        /// <param name="buttonStyle">The style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OverlayAnimationButton(ButtonStyle buttonStyle) : base(buttonStyle)
        {
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ImageView CreateOverlay(ImageViewStyle style)
        {
            var overlayImage = new ImageView();
            overlayImage.Hide();

            return overlayImage;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool OnControlStateChanged(ControlStates previousState, Touch touchInfo)
        {
            if (ControlState != ControlStates.Pressed || null == ButtonOverlay)
            {
                return true;
            }

            if (null == PressAnimation)
            {
                var keyFrames = new KeyFrames();
                keyFrames.Add(0.0f, 0.0f);
                keyFrames.Add(0.25f, 1.0f, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
                keyFrames.Add(1.0f, 0.0f, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut));

                PressAnimation = new Animation(400);
                PressAnimation.EndAction = Animation.EndActions.StopFinal;
                PressAnimation.AnimateBetween(ButtonOverlay, "Opacity", keyFrames);
                PressAnimation.AnimateTo(ButtonOverlay, "Scale", new Vector3(1, 1, 1), 0, 300, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut));
            }

            if (PressAnimation.State == Animation.States.Playing)
            {
                PressAnimation.Stop();
                ButtonOverlay.Hide();
            }

            ButtonOverlay.Opacity = 0.0f;
            ButtonOverlay.CornerRadius = CornerRadius;
            ButtonOverlay.Background = Background;
            ButtonOverlay.Size = Size;
            ButtonOverlay.Scale = new Vector3(0.86f, 0.86f, 1);
            ButtonOverlay.Show();

            PressAnimation.Play();

            return true;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (null != PressAnimation)
            {
                if (PressAnimation.State == Animation.States.Playing)
                {
                    PressAnimation.Stop();
                }
                PressAnimation.Dispose();
                PressAnimation = null;
            }

            base.Dispose(type);
        }
    }
}