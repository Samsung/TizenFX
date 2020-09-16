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
            InitSubStyle();
        }

        /// <summary>
        /// Creates a new instance of a ProgressStyle with style.
        /// </summary>
        /// <param name="style">Create ProgressStyle by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public ProgressStyle(ProgressStyle style) : base(style)
        {
            if (null == style) return;

            InitSubStyle();

            this.CopyFrom(style);
        }

        /// <summary>
        /// Get or set track image.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Track { get; set; }

        /// <summary>
        /// Get or set progress image.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Progress { get; set; }

        /// <summary>
        /// Get or set buffer image.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Buffer { get; set; }

        /// <summary>
        /// Style's clone function.
        /// </summary>
        /// <param name="bindableObject">The style that need to copy.</param>
        /// <since_tizen> 8 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            ProgressStyle progressStyle = bindableObject as ProgressStyle;

            if (null != progressStyle)
            {
                if (null != progressStyle.Track)
                {
                    Track?.CopyFrom(progressStyle.Track);
                }

                if (null != progressStyle.Progress)
                {
                    Progress?.CopyFrom(progressStyle.Progress);
                }

                if (null != progressStyle.Buffer)
                {
                    Buffer?.CopyFrom(progressStyle.Buffer);
                }
            }
        }

        private void InitSubStyle()
        {
            Track = new ImageViewStyle()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                PositionUsesPivotPoint = true,
                ParentOrigin = NUI.ParentOrigin.TopLeft,
                PivotPoint = NUI.PivotPoint.TopLeft
            };

            Progress = new ImageViewStyle()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft
            };

            Buffer = new ImageViewStyle()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft
            };
        }
    }
}
