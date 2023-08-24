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
        /// Perform further processing of the switch thumb.
        /// </summary>
        /// <param name="switchButton">The switch instance that the extension currently applied to.</param>
        /// <param name="thumb">The reference of the switch thumb.</param>
        /// <return>True if the given thumb is replaced.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ProcessThumb(Switch switchButton, ref ImageView thumb)
        {
            if (switchButton.IsSelected)
            {
                OnSelectedChanged(switchButton);
            }
            return false;
        }

        /// <summary>
        /// Called when the Switch's selection has changed.
        /// </summary>
        /// <param name="switchButton">The Switch instance that the extension currently applied to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnSelectedChanged(Switch switchButton)
        {
        }

        /// <summary> Called when the Switch's track or thumb resized. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnTrackOrThumbResized(Switch switchButton, ImageView track, ImageView thumb)
        {
        }
    }
}
