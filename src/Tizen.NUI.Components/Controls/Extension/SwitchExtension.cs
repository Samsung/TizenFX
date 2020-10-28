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
    /// The SwitchExtension class allows developers to access the Switch's components and extend their behavior in various states.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class SwitchExtension : ButtonExtension
    {
        internal SwitchExtension() : base()
        {
        }

        /// <summary>
        /// Called immediately after the Switch creates the track part.
        /// </summary>
        /// <param name="switchButton">The Switch instance that the extension currently applied to.</param>
        /// <param name="track">The created Switch's track part.</param>
        /// <return>The refined switch track.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageView OnCreateTrack(Switch switchButton, ImageView track)
        {
            return track;
        }

        /// <summary>
        /// Called immediately after the Switch creates the thumb part.
        /// </summary>
        /// <param name="switchButton">The Switch instance that the extension currently applied to.</param>
        /// <param name="thumb">The created Switch's thumb part.</param>
        /// <return>The refined switch thumb.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageView OnCreateThumb(Switch switchButton, ImageView thumb)
        {
            if (switchButton.IsSelected)
            {
                OnSelectedChanged(switchButton);
            }
            return thumb;
        }

        /// <summary>
        /// Called when the Switch's selection has changed.
        /// </summary>
        /// <param name="switchButton">The Switch instance that the extension currently applied to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnSelectedChanged(Switch switchButton)
        {
        }
    }
}
