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
    internal class SlidingSwitchExtension : SwitchExtension, IDisposable
    {
        private bool disposed = false;
        private Animation slidingAnimation;

        public SlidingSwitchExtension() : base()
        {
            slidingAnimation = new Animation(100);
        }

        /// <inheritdoc/>
        public override void OnSelectedChanged(Switch switchButton)
        {
            var track = switchButton.Track;
            var thumb = switchButton.Thumb;

            if (track == null || thumb == null || null == slidingAnimation)
            {
                return;
            }

            if (slidingAnimation.State == Animation.States.Playing)
            {
                slidingAnimation.EndAction = Animation.EndActions.StopFinal;
                slidingAnimation.Stop();
            }

            float destinationPosX = switchButton.IsSelected ? track.Size.Width - thumb.Size.Width : 0;

            if (switchButton.IsOnWindow)
            {
                slidingAnimation.Clear();
                slidingAnimation.AnimateTo(thumb, "PositionX", destinationPosX);
                slidingAnimation.EndAction = Animation.EndActions.StopFinal;
                slidingAnimation.Play();
            }
            else
            {
                thumb.PositionX = destinationPosX;
            }
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

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageView OnCreateTrack(Switch switchButton, ImageView track)
        {
            base.OnCreateTrack(switchButton, track);
            track.Relayout += (s, e) => {
                if (slidingAnimation.State == Animation.States.Playing) return;
                switchButton.Thumb.PositionX = switchButton.IsSelected ? switchButton.Track.Size.Width - switchButton.Thumb.Size.Width : 0;
            };
            return track;
        }

        /// <inheritdoc/>
        public override ImageView OnCreateThumb(Switch switchButton, ImageView thumb)
        {
            base.OnCreateThumb(switchButton, thumb);
            thumb.Relayout += (s, e) => {
                if (slidingAnimation.State == Animation.States.Playing) return;
                thumb.PositionX = switchButton.IsSelected ? switchButton.Track.Size.Width - thumb.Size.Width : 0;
            };
            return thumb;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                slidingAnimation?.Dispose();
            }
            disposed = true;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            global::System.GC.SuppressFinalize(this);
        }
    }
}
