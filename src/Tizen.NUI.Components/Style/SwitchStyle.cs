/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// SwitchStyle is a class which saves Switch's ux data.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class SwitchStyle : ButtonStyle
    {
        static SwitchStyle() { }

        /// <summary>
        /// Creates a new instance of a SwitchStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public SwitchStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a SwitchStyle with style.
        /// </summary>
        /// <param name="style">Create SwitchStyle by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public SwitchStyle(SwitchStyle style) : base(style)
        {
        }

        /// <summary>
        /// Thumb image's style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Thumb { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Track image's style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Track { get; set; } = new ImageViewStyle();

        /// <inheritdoc/>
        /// <since_tizen> 8 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is SwitchStyle switchStyle)
            {
                Track.CopyFrom(switchStyle.Track);
                Thumb.CopyFrom(switchStyle.Thumb);
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ButtonExtension CreateExtension()
        {
            return new SlidingSwitchExtension();
        }
    }
}
