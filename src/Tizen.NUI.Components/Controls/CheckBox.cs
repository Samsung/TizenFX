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

namespace Tizen.NUI.Components
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CheckBox : SelectButton
    {
        static CheckBox() { }
        /// <summary>
        /// Creates a new instance of a CheckBox.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CheckBox() : base() { }

        /// <summary>
        /// Creates a new instance of a CheckBox with style.
        /// </summary>
        /// <param name="style"></param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CheckBox(string style) : base(style) { }

        /// <summary>
        /// Creates a new instance of a CheckBox with style.
        /// </summary>
        /// <param name="buttonStyle"></param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CheckBox(ButtonStyle buttonStyle) : base(buttonStyle) { }

        /// <summary>
        /// Creates a new instance of a CheckBox with a custom Adapter.
        /// </summary>
        /// <param name="adapter">A custom UI adapter for the CheckBox.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CheckBox(ButtonAdapter adapter) : base(adapter)
        {
        }

        /// <summary>
        /// Creates a new instance of a CheckBox with style and a custon Adapter.
        /// </summary>
        /// <param name="buttonStyle">Create Button by style customized by user.</param>
        /// <param name="adapter">Optional parameter to set a custom UI adapter for the CheckBox.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CheckBox(ButtonStyle buttonStyle, ButtonAdapter adapter) : base(buttonStyle, adapter)
        {
        }

        /// <summary>
        /// Get CheckBoxGroup to which this CheckBox belong.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CheckBoxGroup ItemGroup
        {
            get
            {
                return itemGroup as CheckBoxGroup;
            }
            internal set
            {
                itemGroup = value;
            }
        }
    }
}
