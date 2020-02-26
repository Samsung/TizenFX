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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// LoadingStyle is a class which saves Loading's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class LoadingStyle : ControlStyle
    {
        static LoadingStyle() { }

        /// <summary>
        /// Creates a new instance of a LoadingStyle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public LoadingStyle() : base() { }

        /// <summary>
        /// Creates a new instance of a LoadingStyle with style.
        /// </summary>
        /// <param name="style">Create LoadingStyle by style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        public LoadingStyle(LoadingStyle style) : base(style)
        {
            if(null == style)
            {
                return;
            }
            this.CopyFrom(style);
        }

        /// <summary>
        /// Gets or sets loading image resources.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string[] Images { get; set; }

        /// <summary>
        /// Gets or sets loading image size.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Size LoadingSize { get; set; }

        /// <summary>
        /// Gets or sets loading frame per second.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Selector<int?> FrameRate { get; set; } = new Selector<int?>();

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            LoadingStyle loadingStyle = bindableObject as LoadingStyle;

            if (null != loadingStyle)
            {
                if (null != loadingStyle.FrameRate)
                {
                    FrameRate.Clone(loadingStyle.FrameRate);
                }
                if (null != loadingStyle.LoadingSize)
                {
                    LoadingSize = loadingStyle.LoadingSize;
                }
                if (null != loadingStyle.Images)
                {
                    Images = loadingStyle.Images;
                }
            }
        }
    }
}
