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
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// CircularPaginationStyle used to config the circularPagination represent.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CircularPaginationStyle : ControlStyle
    {
        static CircularPaginationStyle() { }

        /// <summary>
        /// Creates a new instance of a CircularPaginationStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularPaginationStyle() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a CircularPaginationStyle using style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularPaginationStyle(CircularPaginationStyle style) : base(style)
        {
            if (null == style) return;

            this.CopyFrom(style);
        }

        /// <summary>
        /// Gets or sets the size of the indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size IndicatorSize { get; set; }

        /// <summary>
        /// Gets or sets the resource of indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> IndicatorImageURL { get; set; } = new Selector<string>();

        /// <summary>
        /// Gets or sets the resource of the center indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> CenterIndicatorImageURL { get; set; } = new Selector<string>();

        /// <summary>
        /// Retrieves a copy of CircularPaginationStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            CircularPaginationStyle circularPaginationStyle = bindableObject as CircularPaginationStyle;
            if (null != circularPaginationStyle)
            {
                if (null != circularPaginationStyle.IndicatorSize)
                {
                    IndicatorSize = new Size(circularPaginationStyle.IndicatorSize.Width, circularPaginationStyle.IndicatorSize.Height);
                }
                if (null != circularPaginationStyle.IndicatorImageURL)
                {
                    IndicatorImageURL?.Clone(circularPaginationStyle.IndicatorImageURL);
                }
                if (null != circularPaginationStyle.CenterIndicatorImageURL)
                {
                    CenterIndicatorImageURL?.Clone(circularPaginationStyle.CenterIndicatorImageURL);
                }
            }
        }

        private void Initialize()
        {
            IndicatorImageURL = new Selector<string>()
            {
                Normal = "/usr/share/dotnet.tizen/framework/res/" + "nui_component_default_pagination_normal_dot.png",
                Selected = "/usr/share/dotnet.tizen/framework/res/" + "nui_component_default_pagination_focus_dot.png",
            };
            IndicatorSize = new Size(10, 10);
        }
    }
}
