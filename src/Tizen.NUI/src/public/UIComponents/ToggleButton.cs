/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// A ToggleButton allows the user to change a setting between two or more states.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// This will be deprecated
    [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ToggleButton : Tizen.NUI.UIComponents.Button
    {
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StateVisualsProperty = BindableProperty.Create("StateVisuals", typeof(PropertyArray), typeof(ToggleButton), new PropertyArray(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var toggleButton = (ToggleButton)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(toggleButton.swigCPtr, ToggleButton.Property.STATE_VISUALS, new Tizen.NUI.PropertyValue((PropertyArray)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var toggleButton = (ToggleButton)bindable;
            Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
            Tizen.NUI.Object.GetProperty(toggleButton.swigCPtr, ToggleButton.Property.STATE_VISUALS).Get(temp);
            return temp;
        });

        /// Only for XAML property binding. This will be changed as Inhouse API by ACR later.
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TooltipsProperty = BindableProperty.Create("Tooltips", typeof(PropertyArray), typeof(ToggleButton), new PropertyArray(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var toggleButton = (ToggleButton)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(toggleButton.swigCPtr, ToggleButton.Property.TOOLTIPS, new Tizen.NUI.PropertyValue((PropertyArray)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var toggleButton = (ToggleButton)bindable;
            Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
            Tizen.NUI.Object.GetProperty(toggleButton.swigCPtr, ToggleButton.Property.TOOLTIPS).Get(temp);
            return temp;
        });

        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentStateIndexProperty = BindableProperty.Create("CurrentStateIndex", typeof(int), typeof(ToggleButton), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var toggleButton = (ToggleButton)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(toggleButton.swigCPtr, ToggleButton.Property.CURRENT_STATE_INDEX, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var toggleButton = (ToggleButton)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(toggleButton.swigCPtr, ToggleButton.Property.CURRENT_STATE_INDEX).Get(out temp);
            return temp;
        });


        /// <summary>
        /// Create an instance for toggleButton.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ToggleButton() : this(Interop.ToggleButton.ToggleButton_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ToggleButton(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.ToggleButton.ToggleButton_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        /// <summary>
        /// Gets and Sets the state visual array of toggle button.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyArray StateVisuals
        {
            get
            {
                return (PropertyArray)GetValue(StateVisualsProperty);
            }
            set
            {
                SetValue(StateVisualsProperty, value);
            }
        }

        /// <summary>
        /// Gets and Sets the tooltips of toggle button.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyArray Tooltips
        {
            get
            {
                return (PropertyArray)GetValue(TooltipsProperty);
            }
            set
            {
                SetValue(TooltipsProperty, value);
            }
        }

        /// <summary>
        /// Gets and Sets the current state index of toggle button.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CurrentStateIndex
        {
            get
            {
                return (int)GetValue(CurrentStateIndexProperty);
            }
            set
            {
                SetValue(CurrentStateIndexProperty, value);
            }
        }


        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ToggleButton.delete_ToggleButton(swigCPtr);
        }

        /// <summary>
        /// This should be internal, please do not use.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new class Property
        {
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int STATE_VISUALS = Interop.ToggleButton.ToggleButton_Property_STATE_VISUALS_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int TOOLTIPS = Interop.ToggleButton.ToggleButton_Property_TOOLTIPS_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int CURRENT_STATE_INDEX = Interop.ToggleButton.ToggleButton_Property_CURRENT_STATE_INDEX_get();
        }
    }
}
