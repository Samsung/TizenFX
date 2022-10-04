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
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        /// <summary>
        /// Gets or sets accessibility name.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AccessibilityName
        {
            get
            {
#if NUI_PROPERTY_CHANGE_DEBUG
AccessibilityNameGetter++;
#endif
                return (string)GetValue(AccessibilityNameProperty);
            }
            set
            {
#if NUI_PROPERTY_CHANGE_DEBUG
AccessibilityNameSetter++;
#endif
                SetValue(AccessibilityNameProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets accessibility description.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AccessibilityDescription
        {
            get
            {
#if NUI_PROPERTY_CHANGE_DEBUG
AccessibilityDescriptionGetter++;
#endif
                return (string)GetValue(AccessibilityDescriptionProperty);
            }
            set
            {
#if NUI_PROPERTY_CHANGE_DEBUG
AccessibilityDescriptionSetter++;
#endif
                SetValue(AccessibilityDescriptionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets accessibility translation domain.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AccessibilityTranslationDomain
        {
            get
            {
#if NUI_PROPERTY_CHANGE_DEBUG
AccessibilityTranslationDomainGetter++;
#endif
                return (string)GetValue(AccessibilityTranslationDomainProperty);
            }
            set
            {
#if NUI_PROPERTY_CHANGE_DEBUG
AccessibilityTranslationDomainSetter++;
#endif
                SetValue(AccessibilityTranslationDomainProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets accessibility role.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Role AccessibilityRole
        {
            get
            {
#if NUI_PROPERTY_CHANGE_DEBUG
AccessibilityRoleGetter++;
#endif
                return (Role)GetValue(AccessibilityRoleProperty);
            }
            set
            {
#if NUI_PROPERTY_CHANGE_DEBUG
AccessibilityRoleSetter++;
#endif
                SetValue(AccessibilityRoleProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets whether the view is highlightable for accessibility or not.
        /// </summary>
        /// <remarks>
        /// For views, which intend to receive accessibility highlight focus, this value should  be set as true.
        /// Otherwise it is set to false by default and the object is omitted in AT-SPI2 navigation.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AccessibilityHighlightable
        {
            get
            {
#if NUI_PROPERTY_CHANGE_DEBUG
AccessibilityHighlightableGetter++;
#endif
                return (bool)GetValue(AccessibilityHighlightableProperty);
            }
            set
            {
#if NUI_PROPERTY_CHANGE_DEBUG
AccessibilityHighlightableSetter++;
#endif
                SetValue(AccessibilityHighlightableProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Controls whether the view is hidden from the AT-SPI tree.
        /// </summary>
        /// <remarks>
        /// False by default. Hiding an object means that any AT-SPI clients are not able to see it.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AccessibilityHidden
        {
            get
            {
#if NUI_PROPERTY_CHANGE_DEBUG
AccessibilityHiddenGetter++;
#endif
                return (bool)GetValue(AccessibilityHiddenProperty);
            }
            set
            {
#if NUI_PROPERTY_CHANGE_DEBUG
AccessibilityHiddenSetter++;
#endif
                SetValue(AccessibilityHiddenProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value that allows the automation framework to find and interact with this element.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string AutomationId
        {
            get
            {
#if NUI_PROPERTY_CHANGE_DEBUG
AutomationIdGetter++;
#endif
                return GetValue(AutomationIdProperty) as string;
            }
            set
            {
#if NUI_PROPERTY_CHANGE_DEBUG
AutomationIdSetter++;
#endif
                SetValue(AutomationIdProperty, value);
                NotifyPropertyChanged();
            }
        }
    }
}
