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
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// SelectionGroup is the base class of CheckBoxGroup and RadioButtonGroup.
    /// It defines a group that is set of selections and enables the user to choose one or multiple selection.
    /// </summary>
    /// <code>
    /// Refer to CheckBoxGroup and RadioButtonGroup
    /// </code>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class SelectGroup
    {
        /// <summary> Selection group composed of items </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected List<SelectButton> itemGroup;

        private int selectedIndex;

        /// <summary>
        /// Get the number of items in the SelectionGroup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Count => itemGroup.Count;

        /// <summary>
        /// Get the index of currently or latest selected item.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SelectedIndex => selectedIndex;

        /// <summary>
        /// Construct SelectionGroup
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected SelectGroup()
        {
            itemGroup = new List<SelectButton>();
        }

        /// <summary>
        /// Determine whether selection is in the SelectionGroup
        /// </summary>
        /// <param name="selection">selection in the SelectionGroup</param>
        /// <returns>true if selection is found in the SelectionGroup; otherwise, false.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Contains(SelectButton selection)
        {
            return itemGroup.Contains(selection);
        }

        /// <summary>
        /// Get the index of given selection.
        /// </summary>
        /// <param name="selection">selection in the SelectionGroup</param>
        /// <returns>The index of the selection in selection group if found; otherwise, return -1</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetIndex(SelectButton selection)
        {
            return itemGroup.IndexOf(selection);
        }

        /// <summary>
        /// Adds an selection to the end of the SelectionGroup
        /// </summary>
        /// <param name="selection">The selection to be added to the end of the SelectionGroup</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void AddSelection(SelectButton selection)
        {
            if (itemGroup.Contains(selection))
            {
                return;
            }
            itemGroup.Add(selection);
            selection.SelectedEvent += OnSelectedEvent;
        }

        /// <summary>
        /// Removes an selection to the end of the SelectionGroup
        /// </summary>
        /// <param name="selection">The selection to remove from the SelectionGroup</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void RemoveSelection(SelectButton selection)
        {
            if (!itemGroup.Contains(selection))
            {
                return;
            }
            selection.SelectedEvent -= OnSelectedEvent;
            itemGroup.Remove(selection);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior after pressing return key by user.
        /// </summary>
        /// <param name="selection">The selection selected by user</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void SelectionHandler(SelectButton selection)
        {
        }

        private void OnSelectedEvent(object sender, SelectButton.SelectEventArgs args)
        {
            SelectButton selection = sender as SelectButton;
            if (selection != null)
            {
                if (args.IsSelected == true)
                {
                    selectedIndex = selection.Index;
                    SelectionHandler(selection);
                }
            }
        }

        /// <summary>
        /// Selection group event arguments
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class SelectGroupEventArgs : EventArgs
        {
            /// <summary>The index of selected item</summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int SelectedIndex;
        }
    }
}
