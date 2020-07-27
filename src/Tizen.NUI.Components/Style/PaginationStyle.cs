﻿/*
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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// PaginationStyle used to config the pagination represent.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class PaginationStyle : ControlStyle
    {
        static PaginationStyle() { }

        /// <summary>
        /// Creates a new instance of a PaginationStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public PaginationStyle() : base() { }

        /// <summary>
        /// Creates a new instance of a PaginationStyle using style.
        /// </summary>
        /// <param name="style">Create PaginationStyle by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public PaginationStyle(PaginationStyle style) : base(style)
        {
            if (null == style) return;            

            this.CopyFrom(style);
        }

        /// <summary>
        /// Gets or sets the size of the indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Size IndicatorSize { get; set; }

        /// <summary>
        /// Gets or sets the resource of indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Selector<string> IndicatorImageUrl { get; set; } = new Selector<string>();

        /// <summary>
        /// Gets or sets the space of the indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public int IndicatorSpacing { get; set; }

        /// <summary>
        /// Retrieves a copy of PaginationStyle.
        /// </summary>
        /// <param name="bindableObject">The style that need to copy.</param>
        /// <since_tizen> 8 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            PaginationStyle paginationStyle = bindableObject as PaginationStyle;
            if (null != paginationStyle)
            {
                if (null != paginationStyle.IndicatorSize)
                {
                    IndicatorSize = new Size(paginationStyle.IndicatorSize.Width, paginationStyle.IndicatorSize.Height);
                }
                if (null != paginationStyle.IndicatorImageUrl)
                {
                    IndicatorImageUrl?.Clone(paginationStyle.IndicatorImageUrl);
                }
                IndicatorSpacing = paginationStyle.IndicatorSpacing;
            }
        }
    }
}
