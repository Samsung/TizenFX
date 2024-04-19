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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(AccessibilityNameProperty);
                }
                else
                {
                    return (string)GetInternalAccessibilityNameProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AccessibilityNameProperty, value);
                }
                else
                {
                    SetInternalAccessibilityNameProperty(this, null, value);
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(AccessibilityDescriptionProperty);
                }
                else
                {
                    return (string)GetInternalAccessibilityDescriptionProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AccessibilityDescriptionProperty, value);
                }
                else
                {
                    SetInternalAccessibilityDescriptionProperty(this, null, value);
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(AccessibilityTranslationDomainProperty);
                }
                else
                {
                    return (string)GetInternalAccessibilityTranslationDomainProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AccessibilityTranslationDomainProperty, value);
                }
                else
                {
                    SetInternalAccessibilityTranslationDomainProperty(this, null, value);
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (Role)GetValue(AccessibilityRoleProperty);
                }
                else
                {
                    return (Role)GetInternalAccessibilityRoleProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AccessibilityRoleProperty, value);
                }
                else
                {
                    SetInternalAccessibilityRoleProperty(this, null, value);
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(AccessibilityHighlightableProperty);
                }
                else
                {
                    return (bool)GetInternalAccessibilityHighlightableProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AccessibilityHighlightableProperty, value);
                }
                else
                {
                    SetInternalAccessibilityHighlightableProperty(this, null, value);
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(AccessibilityHiddenProperty);
                }
                else
                {
                    return (bool)GetInternalAccessibilityHiddenProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AccessibilityHiddenProperty, value);
                }
                else
                {
                    SetInternalAccessibilityHiddenProperty(this, null, value);
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(AutomationIdProperty) as string;
                }
                else
                {
                    return GetInternalAutomationIdProperty(this) as string;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AutomationIdProperty, value);
                }
                else
                {
                    SetInternalAutomationIdProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
    }
}
