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
using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Extension
{
    /// <summary>
    /// The SlidingSwitchExtension class makes attached Switch to animate thumb when selected/unselected.
    /// <remark>
    /// This extension must be used within a class implementing SwitchStyle.
    /// </remark>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class SlidingSwitchExtension : SwitchExtension
    {
        private Animation slidingAnimation;

        public SlidingSwitchExtension() : base()
        {
            slidingAnimation = new Animation(100);
        }

        public override void OnClick(Button button, Button.ClickEventArgs eventArgs)
        {
            if (button as Switch == null)
            {
                throw new Exception("SlidingSwitchExtension must be used within a SwitchStyle or derived class.");
            }

            var switchButton = (Switch)button;
            var track = switchButton.GetCurrentTrack(this);
            var thumb = switchButton.GetCurrentThumb(this);

            if (track == null || thumb == null || null == slidingAnimation)
            {
                return;
            }

            if (slidingAnimation.State == Animation.States.Playing)
            {
                slidingAnimation.Stop();
            }

            slidingAnimation.Clear();
            slidingAnimation.AnimateTo(thumb, "PositionX", track.Size.Width - thumb.Size.Width - thumb.Position.X);
            slidingAnimation.Play();
        }

        public override void OnDispose(Button button)
        {
            if (slidingAnimation != null)
            {
                if (slidingAnimation.State == Animation.States.Playing)
                {
                    slidingAnimation.Stop();
                }
                slidingAnimation.Dispose();
                slidingAnimation = null;
            }
        }
    }
}
