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
using Tizen.NUI.Components;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// PopupStyle used to config the Popup represent.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PopupStyle : ControlStyle
    {
        static PopupStyle() { }

        /// <summary>
        /// Creates a new instance of a PopupStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PopupStyle() : base()
        {
            initSubStyle();
        }

        /// <summary>
        /// Creates a new instance of a PopupStyle using style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PopupStyle(PopupStyle style) : base(style)
        {
            if (null == style)
            {
                return;
            }
            initSubStyle();
            CopyFrom(style);
        }

        /// <summary>
        /// WrapContent
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? WrapContent
        {
            get;
            set;
        }

        /// <summary>
        /// Retrieves a copy of PopupStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            PopupStyle popupStyle = bindableObject as PopupStyle;
            if (null != popupStyle)
            {
                if (null != popupStyle.WrapContent)
                {
                    WrapContent = popupStyle.WrapContent;
                }
            }
        }

        private void initSubStyle()
        {
            WrapContent = false;
            //to do
            Size = new Size(10, 10);
        }

    }
}
