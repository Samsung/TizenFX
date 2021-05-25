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
                return (string)GetValue(AccessibilityNameProperty);
            }
            set
            {
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
                return (string)GetValue(AccessibilityDescriptionProperty);
            }
            set
            {
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
                return (string)GetValue(AccessibilityTranslationDomainProperty);
            }
            set
            {
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
                return (Role)GetValue(AccessibilityRoleProperty);
            }
            set
            {
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
                return (bool)GetValue(AccessibilityHighlightableProperty);
            }
            set
            {
                SetValue(AccessibilityHighlightableProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets whether the view is animated for accessibility or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AccessibilityAnimated
        {
            get
            {
                return (bool)GetValue(AccessibilityAnimatedProperty);
            }
            set
            {
                SetValue(AccessibilityAnimatedProperty, value);
                NotifyPropertyChanged();
            }
        }
    }
}
