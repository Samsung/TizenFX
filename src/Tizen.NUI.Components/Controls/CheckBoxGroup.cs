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
using System.Collections.Generic;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The CheckboxGroup class is used to group together a set of CheckBox control
    /// </summary>
    /// <code>
    /// CheckBoxGroup checkGroup = new CheckBoxGroup();
    /// CheckBox check1 = new CheckBox();
    /// CheckBox check2 = new CheckBox();
    /// checkGroup.Add(check1);
    /// checkGroup.Add(check2);
    /// </code>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    public class CheckBoxGroup : SelectGroup
    {
        /// <summary>
        /// Construct CheckBoxGroup
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public CheckBoxGroup() : base()
        {

        }

        /// <summary>
        /// Add CheckBox to the end of CheckBoxGroup.
        /// </summary>
        /// <param name="check">The CheckBox to be added to the CheckBoxGroup</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public void Add(CheckBox check)
        {
            base.AddSelection(check);
            check.ItemGroup = this;
        }

        /// <summary>
        /// Remove CheckBox from the CheckBoxGroup.
        /// </summary>
        /// <param name="check">The CheckBox to remove from the CheckBoxGroup</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public void Remove(CheckBox check)
        {
            base.RemoveSelection(check);
            check.ItemGroup = null;
        }

        /// <summary>
        /// Get the CheckBox object at the specified index.
        /// </summary>
        /// <param name="index">The item index</param>
        /// <returns>CheckBox</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public CheckBox GetItemByIndex(int index)
        {
            return itemGroup[index] as CheckBox;
        }

        /// <summary>
        /// Get the index array of checked items.
        /// </summary>
        /// <returns>The array of index</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public int[] GetCheckedIndexArray()
        {
            List<int> selectedItemsList = new List<int>();
            for (int i = 0; i < itemGroup.Count; i++)
            {
                if (itemGroup[i].IsSelected)
                {
                    selectedItemsList.Add(i);
                }
            }

            return selectedItemsList.ToArray();
        }


        /// <summary>
        /// Get the CheckBox array of checked items.
        /// </summary>
        /// <returns>The array of CheckBox</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public CheckBox[] GetCheckedItemArray()
        {
            List<CheckBox> selectedList = new List<CheckBox>();

            foreach (CheckBox check in itemGroup)
            {
                if (check.IsSelected)
                {
                    selectedList.Add(check);
                }
            }

            return selectedList.ToArray();
        }

        /// <summary>
        /// Determines whether every checkboxes in the CheckBoxGroup are checked
        /// </summary>
        /// <returns>If all of CheckBoxes are checked, return true. otherwise false</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public bool IsCheckedAll()
        {
            foreach (CheckBox cb in itemGroup)
            {
                if (!cb.IsSelected)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check or Uncheck all of child checkboxes by the specified value
        /// </summary>
        /// <param name="state">The boolean state of the check box</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public void CheckingAll(bool state)
        {
            foreach (CheckBox cb in itemGroup)
            {
                cb.IsSelected = state;
            }
        }
    }
}
