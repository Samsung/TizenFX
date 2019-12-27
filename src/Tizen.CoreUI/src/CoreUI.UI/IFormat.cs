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
/// <param name="str">Output formatted string. Its contents will be overwritten by this method.</param>
/// <param name="value">The <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span> to convert to text.</param>
/// <returns>Whether the conversion succeeded or not.</returns>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public delegate bool FormatFunc(CoreUI.DataTypes.Strbuf str, CoreUI.DataTypes.Value value);
[return: MarshalAs(UnmanagedType.U1)]internal delegate bool FormatFuncInternal(IntPtr data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StrbufKeepOwnershipMarshaler))] CoreUI.DataTypes.Strbuf str,  CoreUI.DataTypes.ValueNative value);
internal class FormatFuncWrapper
{

    private FormatFuncInternal _cb;
    private IntPtr _cb_data;
    private CoreUI.DataTypes.Callbacks.EinaFreeCb _cb_free_cb;

    internal FormatFuncWrapper (FormatFuncInternal _cb, IntPtr _cb_data, CoreUI.DataTypes.Callbacks.EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~FormatFuncWrapper()
    {
        if (this._cb_free_cb != null)
        {
            CoreUI.Wrapper.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
        }
    }

    internal bool ManagedCb(CoreUI.DataTypes.Strbuf str, CoreUI.DataTypes.Value value)
    {
var _ret_var = _cb(_cb_data, str, value);
CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
    }

    [return: MarshalAs(UnmanagedType.U1)]    internal static bool Cb(IntPtr cb_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StrbufKeepOwnershipMarshaler))] CoreUI.DataTypes.Strbuf str,  CoreUI.DataTypes.ValueNative value)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        FormatFunc cb = (FormatFunc)handle.Target;
bool _ret_var = default(bool);        try {
            _ret_var = cb(str, value);
        } catch (Exception e) {
            CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
            CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
        }
        return _ret_var;    }
}
}

namespace CoreUI.UI {
    /// <summary>Helper mixin that simplifies converting numerical values to text.
    /// 
    /// A number of widgets represent a numerical value but display a text representation. For example, an <see cref="CoreUI.UI.ProgressBar"/> can hold the number 0.75 but display the string &quot;75%&quot;, or an <see cref="CoreUI.UI.Spin"/> can hold numbers 1 to 7, but display the strings &quot;Monday&quot; thru &quot;Sunday&quot;.
    /// 
    /// This conversion can be controlled through the <see cref="CoreUI.UI.IFormat.FormatFunc"/>, <see cref="CoreUI.UI.IFormat.FormatValues"/> and <see cref="CoreUI.UI.IFormat.FormatString"/> properties. Only one of them needs to be set. When more than one is set <see cref="CoreUI.UI.IFormat.FormatValues"/> has the highest priority, followed by <see cref="CoreUI.UI.IFormat.FormatFunc"/> and then <see cref="CoreUI.UI.IFormat.FormatString"/>. If one mechanism fails to produce a valid string the others will be tried (if provided) in descending order of priority. If no user-provided mechanism works, a fallback is used that just displays the value.
    /// 
    /// Widgets including this mixin offer their users different properties to control how <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span>&apos;s are converted to text.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.IFormatNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IFormat : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>User-provided function which takes care of converting an <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
        /// <returns>User-provided formatting function.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.UI.FormatFunc GetFormatFunc();

        /// <summary>User-provided function which takes care of converting an <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
        /// <param name="func">User-provided formatting function.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetFormatFunc(CoreUI.UI.FormatFunc func);

        /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="CoreUI.UI.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
        /// <returns>Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from CoreUI.DataTypes.Array, CoreUI.DataTypes.List or even plain C arrays.</returns>
        /// <since_tizen> 6 </since_tizen>
        IEnumerable<CoreUI.UI.FormatValue> GetFormatValues();

        /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="CoreUI.UI.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
        /// <param name="values">Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from CoreUI.DataTypes.Array, CoreUI.DataTypes.List or even plain C arrays.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetFormatValues(IEnumerable<CoreUI.UI.FormatValue> values);

        /// <summary>A user-provided, string used to format the numerical value.
        /// 
        /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
        /// 
        /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
        /// 
        /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="CoreUI.UI.FormatStringType.Simple"/> for simple numerical values and <see cref="CoreUI.UI.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
        /// 
        /// Pass <c>NULL</c> to disable this mechanism.</summary>
        /// <param name="kw_string">Formatting string containing regular characters and format specifiers.</param>
        /// <param name="type">Type of formatting string, which controls how the different format specifiers are to be translated.<br/>The default value is <see cref="CoreUI.UI.FormatStringType.Simple"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetFormatString(out System.String kw_string, out CoreUI.UI.FormatStringType type);

        /// <summary>A user-provided, string used to format the numerical value.
        /// 
        /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
        /// 
        /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
        /// 
        /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="CoreUI.UI.FormatStringType.Simple"/> for simple numerical values and <see cref="CoreUI.UI.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
        /// 
        /// Pass <c>NULL</c> to disable this mechanism.</summary>
        /// <param name="kw_string">Formatting string containing regular characters and format specifiers.</param>
        /// <param name="type">Type of formatting string, which controls how the different format specifiers are to be translated.<br/>The default value is <see cref="CoreUI.UI.FormatStringType.Simple"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetFormatString(System.String kw_string, CoreUI.UI.FormatStringType type);

        /// <summary>User-provided function which takes care of converting an <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
        /// <value>User-provided formatting function.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.UI.FormatFunc FormatFunc {
            get;
            set;
        }

        /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="CoreUI.UI.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
        /// <value>Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from CoreUI.DataTypes.Array, CoreUI.DataTypes.List or even plain C arrays.</value>
        /// <since_tizen> 6 </since_tizen>
        IEnumerable<CoreUI.UI.FormatValue> FormatValues {
            get;
            set;
        }

        /// <summary>A user-provided, string used to format the numerical value.
        /// 
        /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
        /// 
        /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
        /// 
        /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="CoreUI.UI.FormatStringType.Simple"/> for simple numerical values and <see cref="CoreUI.UI.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
        /// 
        /// Pass <c>NULL</c> to disable this mechanism.</summary>
        /// <value>Formatting string containing regular characters and format specifiers.</value>
        /// <since_tizen> 6 </since_tizen>
        (System.String, CoreUI.UI.FormatStringType) FormatString {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IFormatNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_format_mixin_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_format_func_get_static_delegate == null)
            {
                efl_ui_format_func_get_static_delegate = new efl_ui_format_func_get_delegate(format_func_get);
            }

            if (methods.Contains("GetFormatFunc"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_func_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_func_get_static_delegate) });
            }

            if (efl_ui_format_func_set_static_delegate == null)
            {
                efl_ui_format_func_set_static_delegate = new efl_ui_format_func_set_delegate(format_func_set);
            }

            if (methods.Contains("SetFormatFunc"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_func_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_func_set_static_delegate) });
            }

            if (efl_ui_format_values_get_static_delegate == null)
            {
                efl_ui_format_values_get_static_delegate = new efl_ui_format_values_get_delegate(format_values_get);
            }

            if (methods.Contains("GetFormatValues"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_values_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_values_get_static_delegate) });
            }

            if (efl_ui_format_values_set_static_delegate == null)
            {
                efl_ui_format_values_set_static_delegate = new efl_ui_format_values_set_delegate(format_values_set);
            }

            if (methods.Contains("SetFormatValues"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_values_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_values_set_static_delegate) });
            }

            if (efl_ui_format_string_get_static_delegate == null)
            {
                efl_ui_format_string_get_static_delegate = new efl_ui_format_string_get_delegate(format_string_get);
            }

            if (methods.Contains("GetFormatString"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_get_static_delegate) });
            }

            if (efl_ui_format_string_set_static_delegate == null)
            {
                efl_ui_format_string_set_static_delegate = new efl_ui_format_string_set_delegate(format_string_set);
            }

            if (methods.Contains("SetFormatString"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_set_static_delegate) });
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
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return efl_ui_format_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate CoreUI.UI.FormatFunc efl_ui_format_func_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.UI.FormatFunc efl_ui_format_func_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_format_func_get_api_delegate> efl_ui_format_func_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_format_func_get_api_delegate>(Module, "efl_ui_format_func_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.UI.FormatFunc format_func_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_format_func_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.UI.FormatFunc _ret_var = default(CoreUI.UI.FormatFunc);
                try
                {
                    _ret_var = ((IFormat)ws.Target).GetFormatFunc();
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
                return efl_ui_format_func_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_format_func_get_delegate efl_ui_format_func_get_static_delegate;

        
        private delegate void efl_ui_format_func_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, CoreUI.UI.FormatFuncInternal func, CoreUI.DataTypes.Callbacks.EinaFreeCb func_free_cb);

        
        internal delegate void efl_ui_format_func_set_api_delegate(System.IntPtr obj,  IntPtr func_data, CoreUI.UI.FormatFuncInternal func, CoreUI.DataTypes.Callbacks.EinaFreeCb func_free_cb);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_format_func_set_api_delegate> efl_ui_format_func_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_format_func_set_api_delegate>(Module, "efl_ui_format_func_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void format_func_set(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, CoreUI.UI.FormatFuncInternal func, CoreUI.DataTypes.Callbacks.EinaFreeCb func_free_cb)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_format_func_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                    CoreUI.UI.FormatFuncWrapper func_wrapper = new CoreUI.UI.FormatFuncWrapper(func, func_data, func_free_cb);

                try
                {
                    ((IFormat)ws.Target).SetFormatFunc(func_wrapper.ManagedCb);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_format_func_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), func_data, func, func_free_cb);
            }
        }

        private static efl_ui_format_func_set_delegate efl_ui_format_func_set_static_delegate;

        
        private delegate System.IntPtr efl_ui_format_values_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate System.IntPtr efl_ui_format_values_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_format_values_get_api_delegate> efl_ui_format_values_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_format_values_get_api_delegate>(Module, "efl_ui_format_values_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.IntPtr format_values_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_format_values_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                IEnumerable<CoreUI.UI.FormatValue> _ret_var = null;
                try
                {
                    _ret_var = ((IFormat)ws.Target).GetFormatValues();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return CoreUI.Wrapper.Globals.IEnumerableToAccessor(_ret_var, true);
            }
            else
            {
                return efl_ui_format_values_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_format_values_get_delegate efl_ui_format_values_get_static_delegate;

        
        private delegate void efl_ui_format_values_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr values);

        
        internal delegate void efl_ui_format_values_set_api_delegate(System.IntPtr obj,  System.IntPtr values);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_format_values_set_api_delegate> efl_ui_format_values_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_format_values_set_api_delegate>(Module, "efl_ui_format_values_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void format_values_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr values)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_format_values_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_values = CoreUI.Wrapper.Globals.AccessorToIEnumerable<CoreUI.UI.FormatValue>(values);

                try
                {
                    ((IFormat)ws.Target).SetFormatValues(_in_values);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_format_values_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), values);
            }
        }

        private static efl_ui_format_values_set_delegate efl_ui_format_values_set_static_delegate;

        
        private delegate void efl_ui_format_string_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] out System.String kw_string,  out CoreUI.UI.FormatStringType type);

        
        internal delegate void efl_ui_format_string_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] out System.String kw_string,  out CoreUI.UI.FormatStringType type);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_format_string_get_api_delegate> efl_ui_format_string_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_format_string_get_api_delegate>(Module, "efl_ui_format_string_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void format_string_get(System.IntPtr obj, System.IntPtr pd, out System.String kw_string, out CoreUI.UI.FormatStringType type)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_format_string_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _out_kw_string = default(System.String);
type = default(CoreUI.UI.FormatStringType);
                try
                {
                    ((IFormat)ws.Target).GetFormatString(out _out_kw_string, out type);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

        kw_string = _out_kw_string;
        
            }
            else
            {
                efl_ui_format_string_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out kw_string, out type);
            }
        }

        private static efl_ui_format_string_get_delegate efl_ui_format_string_get_static_delegate;

        
        private delegate void efl_ui_format_string_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String kw_string,  CoreUI.UI.FormatStringType type);

        
        internal delegate void efl_ui_format_string_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String kw_string,  CoreUI.UI.FormatStringType type);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_format_string_set_api_delegate> efl_ui_format_string_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_format_string_set_api_delegate>(Module, "efl_ui_format_string_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void format_string_set(System.IntPtr obj, System.IntPtr pd, System.String kw_string, CoreUI.UI.FormatStringType type)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_format_string_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IFormat)ws.Target).SetFormatString(kw_string, type);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_format_string_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), kw_string, type);
            }
        }

        private static efl_ui_format_string_set_delegate efl_ui_format_string_set_static_delegate;

        
        private delegate void efl_ui_format_formatted_value_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StrbufKeepOwnershipMarshaler))] CoreUI.DataTypes.Strbuf str,  CoreUI.DataTypes.ValueNative value);

        
        internal delegate void efl_ui_format_formatted_value_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StrbufKeepOwnershipMarshaler))] CoreUI.DataTypes.Strbuf str,  CoreUI.DataTypes.ValueNative value);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_format_formatted_value_get_api_delegate> efl_ui_format_formatted_value_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_format_formatted_value_get_api_delegate>(Module, "efl_ui_format_formatted_value_get");

        
        private delegate int efl_ui_format_decimal_places_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate int efl_ui_format_decimal_places_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_format_decimal_places_get_api_delegate> efl_ui_format_decimal_places_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_format_decimal_places_get_api_delegate>(Module, "efl_ui_format_decimal_places_get");

        
        private delegate void efl_ui_format_apply_formatted_value_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_ui_format_apply_formatted_value_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_format_apply_formatted_value_api_delegate> efl_ui_format_apply_formatted_value_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_format_apply_formatted_value_api_delegate>(Module, "efl_ui_format_apply_formatted_value");

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class FormatExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.FormatFunc> FormatFunc<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IFormat, T>magic = null) where T : CoreUI.UI.IFormat {
            return new CoreUI.BindableProperty<CoreUI.UI.FormatFunc>("format_func", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<IEnumerable<CoreUI.UI.FormatValue>> FormatValues<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IFormat, T>magic = null) where T : CoreUI.UI.IFormat {
            return new CoreUI.BindableProperty<IEnumerable<CoreUI.UI.FormatValue>>("format_values", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI.UI {
    /// <summary>Type of formatting string.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum FormatStringType
    {
        /// <summary>This is the simplest formatting mechanism, working pretty much like <c>printf</c>. Accepted formats are <c>s</c>, <c>f</c>, <c>F</c>, <c>d</c>, <c>u</c>, <c>i</c>, <c>o</c>, <c>x</c> and <c>X</c>. For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.</summary>
        /// <since_tizen> 6 </since_tizen>
        Simple = 0,
        /// <summary>A strftime-style string used to format date and time values. For example, &quot;%A&quot; for the full name of the day or &quot;%y&quot; for the year as a decimal number without a century (range 00 to 99). Note that these are not the <c>printf</c> formats. See the man page for the <c>strftime</c> function for the complete list.</summary>
        /// <since_tizen> 6 </since_tizen>
        Time = 1,
    }
}

namespace CoreUI.UI {
    /// <summary>A value which should always be displayed as a specific text string. See <see cref="CoreUI.UI.IFormat.FormatValues"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct FormatValue : IEquatable<FormatValue>
    {
        
        private int value;
        /// <summary>Internal wrapper for field text</summary>
        private System.IntPtr text;

        /// <summary>Input value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public int Value { get => value; }
        /// <summary>Text string to replace it.</summary>
        /// <since_tizen> 6 </since_tizen>
        public System.String Text { get => CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(text); }
        /// <summary>Constructor for FormatValue.
        /// </summary>
        /// <param name="value">Input value.</param>
        /// <param name="text">Text string to replace it.</param>
        /// <since_tizen> 6 </since_tizen>
        public FormatValue(
            int value = default(int),
            System.String text = default(System.String))
        {
            this.value = value;
            this.text = CoreUI.DataTypes.MemoryNative.StrDup(text);
        }

        /// <summary>Packs tuple into FormatValue object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator FormatValue((int value, System.String text) tuple)
            => new FormatValue(tuple.value, tuple.text);

        /// <summary>Unpacks FormatValue into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out int value,
            out System.String text
        )
        {
            value = this.Value;
            text = this.Text;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Value.GetHashCode();
            hash = hash * 23 + Text.GetHashCode(StringComparison.Ordinal);
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(FormatValue other)
        {
            return Value == other.Value && Text == other.Text;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is FormatValue) ? Equals((FormatValue)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(FormatValue lhs, FormatValue rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(FormatValue lhs, FormatValue rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator FormatValue(IntPtr ptr)
        {
            return (FormatValue)Marshal.PtrToStructure(ptr, typeof(FormatValue));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static FormatValue FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

