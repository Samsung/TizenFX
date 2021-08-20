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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Tizen.NUI;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    internal static class VisualStateManager
    {
        internal class CommonStates
        {
            public const string Normal = "Normal";
            public const string Disabled = "Disabled";
            public const string Focused = "Focused";
        }

        private static VisualStateGroupList visualStateGroups;
        public static readonly BindableProperty VisualStateGroupsProperty =
            BindableProperty.CreateAttached("VisualStateGroups", typeof(VisualStateGroupList), typeof(/*VisualElement*/BaseHandle),
                defaultValue: null, propertyChanged: VisualStateGroupsPropertyChanged,
                defaultValueCreator: (BindableObject obj)=>
                {
                    if (null == visualStateGroups)
                    {
                        visualStateGroups = new VisualStateGroupList();
                    }

                    return visualStateGroups;
                });

        static void VisualStateGroupsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            GoToState((/*VisualElement*/BaseHandle)bindable, CommonStates.Normal);
        }

        public static IList<VisualStateGroup> GetVisualStateGroups(/*VisualElement*/BaseHandle visualElement)
        {
            return (IList<VisualStateGroup>)visualElement.GetValue(VisualStateGroupsProperty);
        }

        public static void SetVisualStateGroups(/*VisualElement*/BaseHandle visualElement, VisualStateGroupList value)
        {
            visualElement.SetValue(VisualStateGroupsProperty, value);
        }

        public static bool GoToState(/*VisualElement*/BaseHandle visualElement, string name)
        {
            if (!visualElement.IsSet(VisualStateGroupsProperty))
            {
                return false;
            }

            var groups = (IList<VisualStateGroup>)visualElement.GetValue(VisualStateGroupsProperty);

            foreach (VisualStateGroup group in groups)
            {
                if (group.CurrentState?.Name == name)
                {
                    // We're already in the target state; nothing else to do
                    return true;
                }

                // See if this group contains the new state
                var target = group.GetState(name);
                if (target == null)
                {
                    continue;
                }

                // If we've got a new state to transition to, unapply the setters from the current state
                if (group.CurrentState != null)
                {
                    foreach (Setter setter in group.CurrentState.Setters)
                    {
                        setter.UnApply(visualElement);
                    }
                }

                // Update the current state
                group.CurrentState = target;

                // Apply the setters from the new state
                foreach (Setter setter in target.Setters)
                {
                    setter.Apply(visualElement);
                }

                return true;
            }

            return false;
        }

        public static bool HasVisualStateGroups(this /*VisualElement*/BaseHandle element)
        {
            return element.IsSet(VisualStateGroupsProperty);
        }
    }
}
