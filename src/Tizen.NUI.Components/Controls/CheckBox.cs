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

namespace Tizen.NUI.Components
{
    /// <since_tizen> 8 </since_tizen>
    public class CheckBox : SelectButton
    {
        static CheckBox() { }
        /// <summary>
        /// Creates a new instance of a CheckBox.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public CheckBox() : base() { }

        /// <summary>
        /// Creates a new instance of a CheckBox with style.
        /// </summary>
        /// <param name="style"></param>
        /// <since_tizen> 8 </since_tizen>
        public CheckBox(string style) : base(style) { }

        /// <summary>
        /// Creates a new instance of a CheckBox with style.
        /// </summary>
        /// <param name="buttonStyle"></param>
        /// <since_tizen> 8 </since_tizen>
        public CheckBox(ButtonStyle buttonStyle) : base(buttonStyle) { }

        /// <summary>
        /// Initialize AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();

            SetAccessibilityConstructor(Role.CheckBox);
            WidthSpecification = LayoutParamPolicies.WrapContent;
            HeightSpecification = LayoutParamPolicies.WrapContent;
        }

        /// <summary>
        /// Get CheckBoxGroup to which this CheckBox belong.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new CheckBoxGroup ItemGroup
        {
            get
            {
                return base.ItemGroup as CheckBoxGroup;
            }
            internal set
            {
                base.ItemGroup = value;
            }
        }
    }
}
