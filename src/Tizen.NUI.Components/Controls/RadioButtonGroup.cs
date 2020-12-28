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
    /// <summary>
    /// The RadioButtonGroup class is used to group together a set of RadioButton control
    /// It enables the user to select exclusively single radio button of group.
    /// </summary>
    /// <code>
    /// RadioButtonGroup radioGroup = new RadioButtonGroup();
    /// RadioButton radio1 = new RadioButton();
    /// RadioButton radio2 = new RadioButton();
    /// radioGroup.Add(radio1);
    /// radioGroup.Add(radio2);
    /// </code>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RadioButtonGroup : SelectGroup
    {
        /// <summary>
        /// Construct RadioButtonGroup
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RadioButtonGroup() : base()
        {
            EnableMultiSelection = false;
        }

        /// <summary>
        /// Get the RadioButton object at the specified index.
        /// </summary>
        /// <param name="index">item index</param>
        /// <returns>RadioButton</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RadioButton GetItem(int index)
        {
            return ItemGroup[index] as RadioButton;
        }

        /// <summary>
        /// Add RadioButton to the end of RadioButtonGroup.
        /// </summary>
        /// <param name="radio">The RadioButton to be added to the RadioButtonGroup</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(RadioButton radio)
        {
            if (null == radio) return;
            base.AddSelection(radio);
            radio.ItemGroup = this;
        }

        /// <summary>
        /// Remove RadioButton from the RadioButtonGroup.
        /// </summary>
        /// <param name="radio">The RadioButton to remove from the RadioButtonGroup</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Remove(RadioButton radio)
        {
            if (null == radio) return;
            base.RemoveSelection(radio);
            radio.ItemGroup = null;
        }
    }
}
