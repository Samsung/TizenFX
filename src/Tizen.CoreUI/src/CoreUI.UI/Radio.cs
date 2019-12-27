/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI.UI {
    /// <summary>Elementary radio button class.
    /// 
    /// Radio buttons are like check boxes in that they can be either checked or unchecked. However, radio buttons are always bunched together in groups, and only one button in each group can be checked at any given time. Pressing a different button in the group will automatically uncheck any previously checked button.
    /// 
    /// They are a common way to allow a user to select one option among a list.
    /// 
    /// To handle button grouping, you can either use an <see cref="CoreUI.UI.RadioGroupImpl"/> object or use more convenient widgets like <see cref="CoreUI.UI.RadioBox"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Radio.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Radio : CoreUI.UI.Check
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Radio))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_radio_class_get();

        /// <summary>Initializes a new instance of the <see cref="Radio"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Radio(CoreUI.Object parent, System.String style = null) : base(efl_ui_radio_class_get(), parent)
        {
            if (CoreUI.Wrapper.Globals.ParamHelperCheck(style))
            {
                SetStyle(CoreUI.Wrapper.Globals.GetParamHelper(style));
            }

            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Radio(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Radio"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Radio(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Radio"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Radio(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Integer value that this radio button represents.
        /// 
        /// Each radio button in a group must have a unique value. The selected button in a group can then be set or retrieved through the <see cref="CoreUI.UI.IRadioGroup.SelectedValue"/> property. This value is also informed through the <see cref="CoreUI.UI.IRadioGroup.ValueChanged"/> event.
        /// 
        /// All non-negative values are legal but keep in mind that 0 is the starting value for all new groups: If no button in the group has this value, then no button in the group is initially selected. -1 is the value that <see cref="CoreUI.UI.IRadioGroup.SelectedValue"/> returns when no button is selected and therefore cannot be used.</summary>
        /// <returns>The value to use when this radio button is selected. Any value can be used but 0 and -1 have special meanings as described above.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetStateValue() {
            var _ret_var = CoreUI.UI.Radio.NativeMethods.efl_ui_radio_state_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Integer value that this radio button represents.
        /// 
        /// Each radio button in a group must have a unique value. The selected button in a group can then be set or retrieved through the <see cref="CoreUI.UI.IRadioGroup.SelectedValue"/> property. This value is also informed through the <see cref="CoreUI.UI.IRadioGroup.ValueChanged"/> event.
        /// 
        /// All non-negative values are legal but keep in mind that 0 is the starting value for all new groups: If no button in the group has this value, then no button in the group is initially selected. -1 is the value that <see cref="CoreUI.UI.IRadioGroup.SelectedValue"/> returns when no button is selected and therefore cannot be used.</summary>
        /// <param name="value">The value to use when this radio button is selected. Any value can be used but 0 and -1 have special meanings as described above.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetStateValue(int value) {
            CoreUI.UI.Radio.NativeMethods.efl_ui_radio_state_value_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), value);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Integer value that this radio button represents.
        /// 
        /// Each radio button in a group must have a unique value. The selected button in a group can then be set or retrieved through the <see cref="CoreUI.UI.IRadioGroup.SelectedValue"/> property. This value is also informed through the <see cref="CoreUI.UI.IRadioGroup.ValueChanged"/> event.
        /// 
        /// All non-negative values are legal but keep in mind that 0 is the starting value for all new groups: If no button in the group has this value, then no button in the group is initially selected. -1 is the value that <see cref="CoreUI.UI.IRadioGroup.SelectedValue"/> returns when no button is selected and therefore cannot be used.</summary>
        /// <value>The value to use when this radio button is selected. Any value can be used but 0 and -1 have special meanings as described above.</value>
        /// <since_tizen> 6 </since_tizen>
        public int StateValue {
            get { return GetStateValue(); }
            set { SetStateValue(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Radio.efl_ui_radio_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.Check.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_ui_radio_state_value_get_static_delegate == null)
                {
                    efl_ui_radio_state_value_get_static_delegate = new efl_ui_radio_state_value_get_delegate(state_value_get);
                }

                if (methods.Contains("GetStateValue"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_state_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_state_value_get_static_delegate) });
                }

                if (efl_ui_radio_state_value_set_static_delegate == null)
                {
                    efl_ui_radio_state_value_set_static_delegate = new efl_ui_radio_state_value_set_delegate(state_value_set);
                }

                if (methods.Contains("SetStateValue"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_state_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_state_value_set_static_delegate) });
                }

                if (includeInherited)
                {
                    var all_interfaces = type.GetInterfaces();
                    foreach (var iface in all_interfaces)
                    {
                        var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                        if (moredescs != null)
                            descs.AddRange(moredescs);
                    }
                }
                descs.AddRange(base.GetEoOps(type, false));
                return descs;
            }

            /// <summary>Returns the Eo class for the native methods of this class.
            /// </summary>
            /// <returns>The native class pointer.</returns>
            internal override IntPtr GetCoreUIClass()
            {
                return CoreUI.UI.Radio.efl_ui_radio_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate int efl_ui_radio_state_value_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_ui_radio_state_value_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_radio_state_value_get_api_delegate> efl_ui_radio_state_value_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_radio_state_value_get_api_delegate>(Module, "efl_ui_radio_state_value_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int state_value_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_radio_state_value_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Radio)ws.Target).GetStateValue();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_radio_state_value_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_radio_state_value_get_delegate efl_ui_radio_state_value_get_static_delegate;

            
            private delegate void efl_ui_radio_state_value_set_delegate(System.IntPtr obj, System.IntPtr pd,  int value);

            
            internal delegate void efl_ui_radio_state_value_set_api_delegate(System.IntPtr obj,  int value);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_radio_state_value_set_api_delegate> efl_ui_radio_state_value_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_radio_state_value_set_api_delegate>(Module, "efl_ui_radio_state_value_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void state_value_set(System.IntPtr obj, System.IntPtr pd, int value)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_radio_state_value_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Radio)ws.Target).SetStateValue(value);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_radio_state_value_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), value);
                }
            }

            private static efl_ui_radio_state_value_set_delegate efl_ui_radio_state_value_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class RadioExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> StateValue<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Radio, T>magic = null) where T : CoreUI.UI.Radio {
            return new CoreUI.BindableProperty<int>("state_value", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

