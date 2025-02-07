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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

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
        /// IsGroupHolderProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsGroupHolderProperty = null;

        private static readonly BindableProperty RadioButtonGroupProperty = null;

        private static Dictionary<View, bool> isGroupHolderMap = null;
        private static Dictionary<View, RadioButtonGroup> radioButtonGroupMap = null;

        static RadioButtonGroup()
        {
            if (NUIApplication.IsUsingXaml)
            {
                IsGroupHolderProperty = BindableProperty.CreateAttached("IsGroupHolder", typeof(bool), typeof(View), false,
                    propertyChanged: OnIsGroupHolderChanged);
                RadioButtonGroupProperty = BindableProperty.CreateAttached("RadioButtonGroup", typeof(RadioButtonGroup), typeof(View), null,
                    propertyChanged: OnRadioButtonGroupChanged);
            }
            else
            {
                isGroupHolderMap = new Dictionary<View, bool>();
                radioButtonGroupMap = new Dictionary<View, RadioButtonGroup>();
            }
        }

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
        /// Gets a RadioButtonGroup.IsGroupHolder property of a view.
        /// </summary>
        /// <param name="view">The group holder.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool GetIsGroupHolder(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return (bool)view.GetValue(IsGroupHolderProperty);
            }
            else
            {
                return isGroupHolderMap[view];
            }
        }

        /// <summary>
        /// Sets a RadioButtonGroup.IsGroupHolder property for a view.
        /// </summary>
        /// <param name="view">The group holder.</param>
        /// <param name="value">The value to set.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetIsGroupHolder(View view, bool value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                view.SetValue(IsGroupHolderProperty, value, false, true);
            }
            else
            {
                isGroupHolderMap[view] = value;
            }
        }

        /// <summary>
        /// Gets a attached RadioButtonGroup for a view.
        /// </summary>
        /// <param name="view">The group holder.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RadioButtonGroup GetRadioButtonGroup(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return view.GetValue(RadioButtonGroupProperty) as RadioButtonGroup;
            }
            else
            {
                return radioButtonGroupMap[view];
            }
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
        /// Get the RadioButton object at the currently selected. If no item selected, returns null.
        /// </summary>
        /// <returns>Currently selected radio button</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RadioButton GetSelectedItem()
        {
            return (SelectedIndex >= 0 && SelectedIndex < ItemGroup.Count) ? ItemGroup[SelectedIndex] as RadioButton : null;
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

        private static void OnIsGroupHolderChanged(Binding.BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;

            if (view == null) return;

            if (!(bool)newValue)
            {
                if (NUIApplication.IsUsingXaml)
                {
                    view.SetValue(RadioButtonGroupProperty, null, false, true);
                }
                else
                {
                    radioButtonGroupMap[view] = null;
                }
                return;
            }

            if (NUIApplication.IsUsingXaml)
            {
                if (view.GetValue(RadioButtonGroupProperty) == null)
                {
                    view.SetValue(RadioButtonGroupProperty, new RadioButtonGroup(), false, true);
                }
            }
            else
            {
                if (radioButtonGroupMap[view] == null)
                {
                    radioButtonGroupMap[view] = new RadioButtonGroup();
                }
            }
        }

        private static void OnRadioButtonGroupChanged(Binding.BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;

            if (view == null) return;

            if (oldValue is RadioButtonGroup oldGroup)
            {
                view.ChildAdded -= oldGroup.OnChildChanged;
                view.ChildRemoved -= oldGroup.OnChildChanged;
                oldGroup.RemoveAll();
            }

            if (newValue is RadioButtonGroup newGroup)
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
                    if (child is RadioButton radioButton)
                        Add(radioButton);
            }
        }
    }
}
