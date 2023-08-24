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
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

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
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CheckBoxGroup : SelectGroup
    {
        /// <summary>
        /// IsGroupHolderProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsGroupHolderProperty = BindableProperty.CreateAttached("IsGroupHolder", typeof(bool), typeof(View), false, propertyChanged: OnIsGroupHolderChanged);

        private static readonly BindableProperty CheckBoxGroupProperty = BindableProperty.CreateAttached("CheckBoxGroup", typeof(CheckBoxGroup), typeof(View), null, propertyChanged: OnCheckBoxGroupChanged);

        static CheckBoxGroup() { }

        /// <summary>
        /// Construct CheckBoxGroup
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CheckBoxGroup() : base()
        {
        }

        /// <summary>
        /// Gets a CheckBoxGroup.IsGroupHolder property of a view.
        /// </summary>
        /// <param name="view">The group holder.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool GetIsGroupHolder(View view) => (bool)view.GetValue(IsGroupHolderProperty);

        /// <summary>
        /// Sets a CheckBoxGroup.IsGroupHolder property for a view.
        /// </summary>
        /// <param name="view">The group holder.</param>
        /// <param name="value">The value to set.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetIsGroupHolder(View view, bool value) => view.SetValue(IsGroupHolderProperty, value, false, true);

        /// <summary>
        /// Gets a attached CheckBoxGroup for a view.
        /// </summary>
        /// <param name="view">The group holder.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CheckBoxGroup GetCheckBoxGroup(View view) => view.GetValue(CheckBoxGroupProperty) as CheckBoxGroup;

        /// <summary>
        /// Add CheckBox to the end of CheckBoxGroup.
        /// </summary>
        /// <param name="check">The CheckBox to be added to the CheckBoxGroup</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(CheckBox check)
        {
            if (null == check) return;
            base.AddSelection(check);
            check.ItemGroup = this;
        }

        /// <summary>
        /// Remove CheckBox from the CheckBoxGroup.
        /// </summary>
        /// <param name="check">The CheckBox to remove from the CheckBoxGroup</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Remove(CheckBox check)
        {
            if (null == check) return;
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CheckBox GetItem(int index)
        {
            return ItemGroup[index] as CheckBox;
        }

        /// <summary>
        /// Get the index array of checked items.
        /// </summary>
        /// <returns>The array of index</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int[] GetCheckedIndices()
        {
            List<int> selectedItemsList = new List<int>();
            for (int i = 0; i < ItemGroup.Count; i++)
            {
                if (ItemGroup[i].IsSelected)
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CheckBox[] GetCheckedItems()
        {
            List<CheckBox> selectedList = new List<CheckBox>();

            foreach (CheckBox check in ItemGroup)
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsCheckedAll()
        {
            foreach (CheckBox cb in ItemGroup)
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CheckAll(bool state)
        {
            foreach (CheckBox cb in ItemGroup)
            {
                cb.IsSelected = state;
            }
        }

        private static void OnIsGroupHolderChanged(Binding.BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;

            if (view == null) return;

            if (!(bool)newValue)
            {
                view.SetValue(CheckBoxGroupProperty, null, false, true);
                return;
            }

            if (view.GetValue(CheckBoxGroupProperty) == null)
            {
                view.SetValue(CheckBoxGroupProperty, new CheckBoxGroup(), false, true);
            }
        }

        private static void OnCheckBoxGroupChanged(Binding.BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;

            if (view == null) return;

            if (oldValue is CheckBoxGroup oldGroup)
            {
                view.ChildAdded -= oldGroup.OnChildChanged;
                view.ChildRemoved -= oldGroup.OnChildChanged;
                oldGroup.RemoveAll();
            }

            if (newValue is CheckBoxGroup newGroup)
            {
                view.ChildAdded += newGroup.OnChildChanged;
                view.ChildRemoved += newGroup.OnChildChanged;
                newGroup.OnChildChanged(view, null);
            }
        }

        private void OnChildChanged(object sender, EventArgs args)
        {
            if (sender is View view)
            {
                RemoveAll();
                foreach (var child in view.Children)
                {
                    if (child is CheckBox checkBox) Add(checkBox);
                }
            }
        }
    }
}
