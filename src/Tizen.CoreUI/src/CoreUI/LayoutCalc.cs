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
namespace CoreUI.Layout {
    /// <summary>This interface defines a common set of APIs used to trigger calculations with layout objects.
    /// 
    /// This defines all the APIs supported by legacy &quot;Edje&quot; object, known in EO API as CoreUI.Canvas.Layout.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Layout.ICalcNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface ICalc : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Whether this object updates its size hints automatically.
        /// 
        /// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
        /// 
        /// A layout recalculation can be triggered by <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcPartsExtends"/> or even any other internal event.</summary>
        /// <returns>Whether or not update the size hints.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetCalcAutoUpdateHints();

        /// <summary>Whether this object updates its size hints automatically.
        /// 
        /// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
        /// 
        /// A layout recalculation can be triggered by <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcPartsExtends"/> or even any other internal event.</summary>
        /// <param name="update">Whether or not update the size hints.<br/>The default value is <c>false</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetCalcAutoUpdateHints(bool update);

        /// <summary>Calculates the minimum required size for a given layout object.
        /// 
        /// This call will trigger an internal recalculation of all parts of the object, in order to return its minimum required dimensions for width and height. The user might choose to impose those minimum sizes, making the resulting calculation to get to values greater or equal than <c>restricted</c> in both directions.
        /// 
        /// <b>NOTE: </b>At the end of this call, the object won&apos;t be automatically resized to the new dimensions, but just return the calculated sizes. The caller is the one up to change its geometry or not.
        /// 
        /// <b>WARNING: </b>Be advised that invisible parts in the object will be taken into account in this calculation.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="restricted">The minimum size constraint as input, the returned size can not be lower than this (in both directions).</param>
        /// <returns>The minimum required size.</returns>
        CoreUI.DataTypes.Size2D CalcSizeMin(CoreUI.DataTypes.Size2D restricted);

        /// <summary>Calculates the geometry of the region, relative to a given layout object&apos;s area, occupied by all parts in the object.
        /// 
        /// This function gets the geometry of the rectangle equal to the area required to group all parts in obj&apos;s group/collection. The x and y coordinates are relative to the top left corner of the whole obj object&apos;s area. Parts placed out of the group&apos;s boundaries will also be taken in account, so that x and y may be negative.
        /// 
        /// <b>NOTE: </b>On failure, this function will make all non-<c>null</c> geometry pointers&apos; pointed variables be set to zero.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The calculated region.</returns>
        CoreUI.DataTypes.Rect CalcPartsExtends();

        /// <summary>Freezes the layout object.
        /// 
        /// This function puts all changes on hold. Successive freezes will nest, requiring an equal number of thaws.
        /// 
        /// See also <see cref="CoreUI.Layout.ICalc.ThawCalc"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The frozen state or 0 on error</returns>
        int FreezeCalc();

        /// <summary>Thaws the layout object.
        /// 
        /// This function thaws (in other words &quot;unfreezes&quot;) the given layout object.
        /// 
        /// <b>NOTE: </b>If successive freezes were done, an equal number of thaws will be required.
        /// 
        /// See also <see cref="CoreUI.Layout.ICalc.FreezeCalc"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The frozen state or 0 if the object is not frozen or on error.</returns>
        int ThawCalc();

        /// <summary>The layout was recalculated.</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler Recalc;
        /// <summary>A circular dependency between parts of the object was found.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Layout.CalcCircularDependencyEventArgs"/></value>
        event EventHandler<CoreUI.Layout.CalcCircularDependencyEventArgs> CircularDependency;
        /// <summary>Whether this object updates its size hints automatically.
        /// 
        /// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
        /// 
        /// A layout recalculation can be triggered by <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcPartsExtends"/> or even any other internal event.</summary>
        /// <value>Whether or not update the size hints.</value>
        /// <since_tizen> 6 </since_tizen>
        bool CalcAutoUpdateHints {
            get;
            set;
        }

    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Layout.ICalc.CircularDependency"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class CalcCircularDependencyEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>A circular dependency between parts of the object was found.</value>
        /// <since_tizen> 6 </since_tizen>
        public IList<System.String> Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ICalcNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Edje)] internal static extern System.IntPtr
            efl_layout_calc_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Edje);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_layout_calc_auto_update_hints_get_static_delegate == null)
            {
                efl_layout_calc_auto_update_hints_get_static_delegate = new efl_layout_calc_auto_update_hints_get_delegate(calc_auto_update_hints_get);
            }

            if (methods.Contains("GetCalcAutoUpdateHints"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_auto_update_hints_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_auto_update_hints_get_static_delegate) });
            }

            if (efl_layout_calc_auto_update_hints_set_static_delegate == null)
            {
                efl_layout_calc_auto_update_hints_set_static_delegate = new efl_layout_calc_auto_update_hints_set_delegate(calc_auto_update_hints_set);
            }

            if (methods.Contains("SetCalcAutoUpdateHints"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_auto_update_hints_set"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_auto_update_hints_set_static_delegate) });
            }

            if (efl_layout_calc_size_min_static_delegate == null)
            {
                efl_layout_calc_size_min_static_delegate = new efl_layout_calc_size_min_delegate(calc_size_min);
            }

            if (methods.Contains("CalcSizeMin"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_size_min"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_size_min_static_delegate) });
            }

            if (efl_layout_calc_parts_extends_static_delegate == null)
            {
                efl_layout_calc_parts_extends_static_delegate = new efl_layout_calc_parts_extends_delegate(calc_parts_extends);
            }

            if (methods.Contains("CalcPartsExtends"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_parts_extends"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_parts_extends_static_delegate) });
            }

            if (efl_layout_calc_freeze_static_delegate == null)
            {
                efl_layout_calc_freeze_static_delegate = new efl_layout_calc_freeze_delegate(calc_freeze);
            }

            if (methods.Contains("FreezeCalc"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_freeze"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_freeze_static_delegate) });
            }

            if (efl_layout_calc_thaw_static_delegate == null)
            {
                efl_layout_calc_thaw_static_delegate = new efl_layout_calc_thaw_delegate(calc_thaw);
            }

            if (methods.Contains("ThawCalc"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_thaw"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_thaw_static_delegate) });
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
            return efl_layout_calc_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_layout_calc_auto_update_hints_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_layout_calc_auto_update_hints_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_auto_update_hints_get_api_delegate> efl_layout_calc_auto_update_hints_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_auto_update_hints_get_api_delegate>(Module, "efl_layout_calc_auto_update_hints_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool calc_auto_update_hints_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_calc_auto_update_hints_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ICalc)ws.Target).GetCalcAutoUpdateHints();
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
                return efl_layout_calc_auto_update_hints_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_layout_calc_auto_update_hints_get_delegate efl_layout_calc_auto_update_hints_get_static_delegate;

        
        private delegate void efl_layout_calc_auto_update_hints_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool update);

        
        internal delegate void efl_layout_calc_auto_update_hints_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool update);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_auto_update_hints_set_api_delegate> efl_layout_calc_auto_update_hints_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_auto_update_hints_set_api_delegate>(Module, "efl_layout_calc_auto_update_hints_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void calc_auto_update_hints_set(System.IntPtr obj, System.IntPtr pd, bool update)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_calc_auto_update_hints_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ICalc)ws.Target).SetCalcAutoUpdateHints(update);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_layout_calc_auto_update_hints_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), update);
            }
        }

        private static efl_layout_calc_auto_update_hints_set_delegate efl_layout_calc_auto_update_hints_set_static_delegate;

        
        private delegate CoreUI.DataTypes.Size2D efl_layout_calc_size_min_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Size2D restricted);

        
        internal delegate CoreUI.DataTypes.Size2D efl_layout_calc_size_min_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Size2D restricted);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_size_min_api_delegate> efl_layout_calc_size_min_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_size_min_api_delegate>(Module, "efl_layout_calc_size_min");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Size2D calc_size_min(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Size2D restricted)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_calc_size_min was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _in_restricted = restricted;
CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                try
                {
                    _ret_var = ((ICalc)ws.Target).CalcSizeMin(_in_restricted);
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
                return efl_layout_calc_size_min_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), restricted);
            }
        }

        private static efl_layout_calc_size_min_delegate efl_layout_calc_size_min_static_delegate;

        
        private delegate CoreUI.DataTypes.Rect efl_layout_calc_parts_extends_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Rect efl_layout_calc_parts_extends_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_parts_extends_api_delegate> efl_layout_calc_parts_extends_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_parts_extends_api_delegate>(Module, "efl_layout_calc_parts_extends");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Rect calc_parts_extends(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_calc_parts_extends was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Rect _ret_var = default(CoreUI.DataTypes.Rect);
                try
                {
                    _ret_var = ((ICalc)ws.Target).CalcPartsExtends();
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
                return efl_layout_calc_parts_extends_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_layout_calc_parts_extends_delegate efl_layout_calc_parts_extends_static_delegate;

        
        private delegate int efl_layout_calc_freeze_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate int efl_layout_calc_freeze_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_freeze_api_delegate> efl_layout_calc_freeze_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_freeze_api_delegate>(Module, "efl_layout_calc_freeze");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int calc_freeze(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_calc_freeze was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((ICalc)ws.Target).FreezeCalc();
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
                return efl_layout_calc_freeze_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_layout_calc_freeze_delegate efl_layout_calc_freeze_static_delegate;

        
        private delegate int efl_layout_calc_thaw_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate int efl_layout_calc_thaw_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_thaw_api_delegate> efl_layout_calc_thaw_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_thaw_api_delegate>(Module, "efl_layout_calc_thaw");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int calc_thaw(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_calc_thaw was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((ICalc)ws.Target).ThawCalc();
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
                return efl_layout_calc_thaw_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_layout_calc_thaw_delegate efl_layout_calc_thaw_static_delegate;

        
        private delegate void efl_layout_calc_force_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_layout_calc_force_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_force_api_delegate> efl_layout_calc_force_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_force_api_delegate>(Module, "efl_layout_calc_force");

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.Layout {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class CalcExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> CalcAutoUpdateHints<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Layout.ICalc, T>magic = null) where T : CoreUI.Layout.ICalc {
            return new CoreUI.BindableProperty<bool>("calc_auto_update_hints", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

