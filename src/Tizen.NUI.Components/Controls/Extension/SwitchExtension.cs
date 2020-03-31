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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The SwitchExtension class allows developers to access the Switch's components and extend their behavior in various states.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class SwitchExtension : ButtonExtension
    {
        /// <summary>
        /// Called immediately after the Switch creates the track part.
        /// </summary>
        /// <param name="switchButton">The Switch instance that the extension currently applied to.</param>
        /// <param name="track">The created Switch's track part.</param>
        /// <param name="style">The initial style that will be appled to Switch's track part.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnCreateTrack(Switch switchButton, ref ImageView track, ImageViewStyle style)
        {
        }

        /// <summary>
        /// Called immediately after the Switch creates the thumb part.
        /// </summary>
        /// <param name="switchButton">The Switch instance that the extension currently applied to.</param>
        /// <param name="thumb">The created Switch's thumb part.</param>
        /// <param name="style">The initial style that will be appled to Switch's thumb part.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnCreateThumb(Switch switchButton, ref ImageView thumb, ImageViewStyle style)
        {
        }
    }
}
