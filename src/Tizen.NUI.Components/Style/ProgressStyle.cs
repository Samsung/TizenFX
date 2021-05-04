/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ProgressStyle is a class which saves Progress's ux data.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class ProgressStyle : ControlStyle
    {
        static ProgressStyle() { }

        /// <summary>
        /// Creates a new instance of a ProgressStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ProgressStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a ProgressStyle with style.
        /// </summary>
        /// <param name="style">Create ProgressStyle by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public ProgressStyle(ProgressStyle style) : base(style)
        {
        }

        /// <summary>
        /// Gets or sets track image.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Track { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Gets or sets progress image.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Progress { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Gets or sets buffer image.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Buffer { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Gets or sets indeterminate progress resource.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string IndeterminateImageUrl { get; set; }

        /// <inheritdoc/>
        /// <since_tizen> 8 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is ProgressStyle progressStyle)
            {
                Track.CopyFrom(progressStyle.Track);
                Progress.CopyFrom(progressStyle.Progress);
                Buffer.CopyFrom(progressStyle.Buffer);
                IndeterminateImageUrl = progressStyle.IndeterminateImageUrl;
            }
        }
    }
}
