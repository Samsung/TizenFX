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
    /// <summary>A Button Spin.
    /// 
    /// This is a widget which allows the user to increase or decrease numeric values using the arrow buttons or to edit values directly by clicking over them and inputting new ones.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.SpinButton.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class SpinButton : CoreUI.UI.Spin, CoreUI.UI.ILayoutOrientable, CoreUI.UI.IRangeInteractive
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(SpinButton))
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
            efl_ui_spin_button_class_get();

        /// <summary>Initializes a new instance of the <see cref="SpinButton"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public SpinButton(CoreUI.Object parent, System.String style = null) : base(efl_ui_spin_button_class_get(), parent)
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
        protected SpinButton(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SpinButton"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal SpinButton(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SpinButton"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected SpinButton(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Called when the widget&apos;s value has changed and has remained unchanged for 0.2s. This allows filtering out unwanted &quot;noise&quot; from the widget if you are only interested in its final position. Use this event instead of <see cref="CoreUI.UI.IRangeDisplay.Changed"/> if you are going to perform a costly operation on its handler.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Steady
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_RANGE_EVENT_STEADY";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_RANGE_EVENT_STEADY";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Steady.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnSteady()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_RANGE_EVENT_STEADY", IntPtr.Zero, null);
        }

        /// <summary>Control whether the spin should circulate value when it reaches its minimum or maximum value.
        /// 
        /// Disabled by default. If disabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will be the maximum value. The same happens when the user tries to decrement it but the value less step is less than minimum value. In this case, the new displayed value will be the minimum value.
        /// 
        /// If enabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will become the minimum value. When the user tries to decrement it, if the value minus step is less than minimum value, the new displayed value will be the maximum value.
        /// 
        /// E.g.: <c>min</c> = 10 <c>max</c> = 50 <c>step</c> = 20 <c>displayed</c> = 20
        /// 
        /// When the user decrements the value (using left or bottom arrow), it will display $50.</summary>
        /// <returns><c>true</c> to enable circulate or <c>false</c> to disable it.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetWraparound() {
            var _ret_var = CoreUI.UI.SpinButton.NativeMethods.efl_ui_spin_button_wraparound_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control whether the spin should circulate value when it reaches its minimum or maximum value.
        /// 
        /// Disabled by default. If disabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will be the maximum value. The same happens when the user tries to decrement it but the value less step is less than minimum value. In this case, the new displayed value will be the minimum value.
        /// 
        /// If enabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will become the minimum value. When the user tries to decrement it, if the value minus step is less than minimum value, the new displayed value will be the maximum value.
        /// 
        /// E.g.: <c>min</c> = 10 <c>max</c> = 50 <c>step</c> = 20 <c>displayed</c> = 20
        /// 
        /// When the user decrements the value (using left or bottom arrow), it will display $50.</summary>
        /// <param name="circulate"><c>true</c> to enable circulate or <c>false</c> to disable it.<br/>The default value is <c>false</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetWraparound(bool circulate) {
            CoreUI.UI.SpinButton.NativeMethods.efl_ui_spin_button_wraparound_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), circulate);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <returns>Direction of the widget.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.LayoutOrientation GetOrientation() {
            var _ret_var = CoreUI.UI.ILayoutOrientableNativeMethods.efl_ui_layout_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <param name="dir">Direction of the widget.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetOrientation(CoreUI.UI.LayoutOrientation dir) {
            CoreUI.UI.ILayoutOrientableNativeMethods.efl_ui_layout_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dir);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control the step used to increment or decrement values for given widget.
        /// 
        /// This value will be incremented or decremented to the displayed value.
        /// 
        /// By default step value is equal to 1.
        /// 
        /// <b>WARNING: </b>The step value should be bigger than 0.</summary>
        /// <returns>The step value.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetRangeStep() {
            var _ret_var = CoreUI.UI.IRangeInteractiveNativeMethods.efl_ui_range_step_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control the step used to increment or decrement values for given widget.
        /// 
        /// This value will be incremented or decremented to the displayed value.
        /// 
        /// By default step value is equal to 1.
        /// 
        /// <b>WARNING: </b>The step value should be bigger than 0.</summary>
        /// <param name="step">The step value.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetRangeStep(double step) {
            CoreUI.UI.IRangeInteractiveNativeMethods.efl_ui_range_step_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), step);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control whether the spin should circulate value when it reaches its minimum or maximum value.
        /// 
        /// Disabled by default. If disabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will be the maximum value. The same happens when the user tries to decrement it but the value less step is less than minimum value. In this case, the new displayed value will be the minimum value.
        /// 
        /// If enabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will become the minimum value. When the user tries to decrement it, if the value minus step is less than minimum value, the new displayed value will be the maximum value.
        /// 
        /// E.g.: <c>min</c> = 10 <c>max</c> = 50 <c>step</c> = 20 <c>displayed</c> = 20
        /// 
        /// When the user decrements the value (using left or bottom arrow), it will display $50.</summary>
        /// <value><c>true</c> to enable circulate or <c>false</c> to disable it.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Wraparound {
            get { return GetWraparound(); }
            set { SetWraparound(value); }
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <value>Direction of the widget.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.LayoutOrientation Orientation {
            get { return GetOrientation(); }
            set { SetOrientation(value); }
        }

        /// <summary>Control the step used to increment or decrement values for given widget.
        /// 
        /// This value will be incremented or decremented to the displayed value.
        /// 
        /// By default step value is equal to 1.
        /// 
        /// <b>WARNING: </b>The step value should be bigger than 0.</summary>
        /// <value>The step value.</value>
        /// <since_tizen> 6 </since_tizen>
        public double RangeStep {
            get { return GetRangeStep(); }
            set { SetRangeStep(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.SpinButton.efl_ui_spin_button_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.Spin.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_ui_spin_button_wraparound_get_static_delegate == null)
                {
                    efl_ui_spin_button_wraparound_get_static_delegate = new efl_ui_spin_button_wraparound_get_delegate(wraparound_get);
                }

                if (methods.Contains("GetWraparound"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spin_button_wraparound_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spin_button_wraparound_get_static_delegate) });
                }

                if (efl_ui_spin_button_wraparound_set_static_delegate == null)
                {
                    efl_ui_spin_button_wraparound_set_static_delegate = new efl_ui_spin_button_wraparound_set_delegate(wraparound_set);
                }

                if (methods.Contains("SetWraparound"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spin_button_wraparound_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spin_button_wraparound_set_static_delegate) });
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
                return CoreUI.UI.SpinButton.efl_ui_spin_button_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_spin_button_wraparound_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_spin_button_wraparound_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_spin_button_wraparound_get_api_delegate> efl_ui_spin_button_wraparound_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_spin_button_wraparound_get_api_delegate>(Module, "efl_ui_spin_button_wraparound_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool wraparound_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_spin_button_wraparound_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((SpinButton)ws.Target).GetWraparound();
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
                    return efl_ui_spin_button_wraparound_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_spin_button_wraparound_get_delegate efl_ui_spin_button_wraparound_get_static_delegate;

            
            private delegate void efl_ui_spin_button_wraparound_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool circulate);

            
            internal delegate void efl_ui_spin_button_wraparound_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool circulate);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_spin_button_wraparound_set_api_delegate> efl_ui_spin_button_wraparound_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_spin_button_wraparound_set_api_delegate>(Module, "efl_ui_spin_button_wraparound_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void wraparound_set(System.IntPtr obj, System.IntPtr pd, bool circulate)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_spin_button_wraparound_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((SpinButton)ws.Target).SetWraparound(circulate);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_spin_button_wraparound_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), circulate);
                }
            }

            private static efl_ui_spin_button_wraparound_set_delegate efl_ui_spin_button_wraparound_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class SpinButtonExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Wraparound<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.SpinButton, T>magic = null) where T : CoreUI.UI.SpinButton {
            return new CoreUI.BindableProperty<bool>("wraparound", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation> Orientation<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.SpinButton, T>magic = null) where T : CoreUI.UI.SpinButton {
            return new CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation>("orientation", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> RangeStep<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.SpinButton, T>magic = null) where T : CoreUI.UI.SpinButton {
            return new CoreUI.BindableProperty<double>("range_step", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

