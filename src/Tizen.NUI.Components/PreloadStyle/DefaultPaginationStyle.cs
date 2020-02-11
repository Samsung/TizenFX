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
    /// The default Pagination style
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DefaultPaginationStyle : StyleBase
    {
        /// <summary>
        /// Return default Pagination style
        /// </summary>
        internal protected override ViewStyle GetAttributes()
        {
            PaginationStyle style = new PaginationStyle
            {
                Size = new Size(400, 30),
                IndicatorImageURL = new Selector<string>
                {
                    Normal = DefaultStyle.GetResourcePath("nui_component_default_pagination_n.png"),
                    Selected = DefaultStyle.GetResourcePath("nui_component_default_pagination_s.png"),
                },
                IndicatorSize = new Size(26, 26),
                IndicatorSpacing = 8,
                IndicatorCount = 5
            };
            return style;
        }
    }
}
