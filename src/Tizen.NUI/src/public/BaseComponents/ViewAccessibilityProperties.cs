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
using Tizen.NUI.Binding;

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
                    return GetInternalAccessibilityName();
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
                    SetInternalAccessibilityName(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAccessibilityName(string name)
        {
            if (name != null)
            {
                Object.InternalSetPropertyString(SwigCPtr, Property.AccessibilityName, name);
            }
        }

        private string GetInternalAccessibilityName()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.AccessibilityName);
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
                    return GetInternalAccessibilityDescription();
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
                    SetInternalAccessibilityDescription(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAccessibilityDescription(string description)
        {
            if (description != null)
            {
                Object.InternalSetPropertyString(SwigCPtr, Property.AccessibilityDescription, description);
            }
        }

        private string GetInternalAccessibilityDescription()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.AccessibilityDescription);
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
                    return GetInternalAccessibilityTranslationDomain();
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
                    SetInternalAccessibilityTranslationDomain(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAccessibilityTranslationDomain(string domain)
        {
            if (domain != null)
            {
                Object.InternalSetPropertyString(SwigCPtr, Property.AccessibilityTranslationDomain, domain);
            }
        }

        private string GetInternalAccessibilityTranslationDomain()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.AccessibilityTranslationDomain);
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
                    return GetInternalAccessibilityRole();
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
                    SetInternalAccessibilityRole(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAccessibilityRole(Role role)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.AccessibilityRole, (int)role);
        }

        private Role GetInternalAccessibilityRole()
        {
            return (Role)Object.InternalGetPropertyInt(SwigCPtr, Property.AccessibilityRole);
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
                    return GetInternalAccessibilityHighlightable();
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
                    SetInternalAccessibilityHighlightable(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAccessibilityHighlightable(bool highlightable)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.AccessibilityHighlightable, highlightable);
        }

        private bool GetInternalAccessibilityHighlightable()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.AccessibilityHighlightable);
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
                    return GetInternalAccessibilityHidden();
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
                    SetInternalAccessibilityHidden(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAccessibilityHidden(bool hidden)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.AccessibilityHidden, hidden);
        }

        private bool GetInternalAccessibilityHidden()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.AccessibilityHidden);
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
                    return GetInternalAutomationId();
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
                    SetInternalAutomationId(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAutomationId(string newValue)
        {
            if (newValue != null)
            {
                Object.InternalSetPropertyString(SwigCPtr, Property.AutomationId, newValue);
            }
        }

        private string GetInternalAutomationId()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.AutomationId);
        }
    }
}
