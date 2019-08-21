#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Layout {

/// <summary>This interface defines a common set of APIs used to trigger calculations with layout objects.
/// This defines all the APIs supported by legacy &quot;Edje&quot; object, known in EO API as Efl.Canvas.Layout.
/// (Since EFL 1.22)</summary>
[Efl.Layout.ICalcConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface ICalc : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Whether this object updates its size hints automatically.
/// (Since EFL 1.22)</summary>
/// <returns>Whether or not update the size hints.</returns>
bool GetCalcAutoUpdateHints();
    /// <summary>Enable or disable auto-update of size hints.
/// (Since EFL 1.22)</summary>
/// <param name="update">Whether or not update the size hints.</param>
void SetCalcAutoUpdateHints(bool update);
    /// <summary>Calculates the minimum required size for a given layout object.
/// This call will trigger an internal recalculation of all parts of the object, in order to return its minimum required dimensions for width and height. The user might choose to impose those minimum sizes, making the resulting calculation to get to values greater or equal than <c>restricted</c> in both directions.
/// 
/// Note: At the end of this call, the object won&apos;t be automatically resized to the new dimensions, but just return the calculated sizes. The caller is the one up to change its geometry or not.
/// 
/// Warning: Be advised that invisible parts in the object will be taken into account in this calculation.
/// (Since EFL 1.22)</summary>
/// <param name="restricted">The minimum size constraint as input, the returned size can not be lower than this (in both directions).</param>
/// <returns>The minimum required size.</returns>
Eina.Size2D CalcSizeMin(Eina.Size2D restricted);
    /// <summary>Calculates the geometry of the region, relative to a given layout object&apos;s area, occupied by all parts in the object.
/// This function gets the geometry of the rectangle equal to the area required to group all parts in obj&apos;s group/collection. The x and y coordinates are relative to the top left corner of the whole obj object&apos;s area. Parts placed out of the group&apos;s boundaries will also be taken in account, so that x and y may be negative.
/// 
/// Note: On failure, this function will make all non-<c>null</c> geometry pointers&apos; pointed variables be set to zero.
/// (Since EFL 1.22)</summary>
/// <returns>The calculated region.</returns>
Eina.Rect CalcPartsExtends();
    /// <summary>Freezes the layout object.
/// This function puts all changes on hold. Successive freezes will nest, requiring an equal number of thaws.
/// 
/// See also <see cref="Efl.Layout.ICalc.ThawCalc"/>.
/// (Since EFL 1.22)</summary>
/// <returns>The frozen state or 0 on error</returns>
int FreezeCalc();
    /// <summary>Thaws the layout object.
/// This function thaws (in other words &quot;unfreezes&quot;) the given layout object.
/// 
/// Note: If successive freezes were done, an equal number of thaws will be required.
/// 
/// See also <see cref="Efl.Layout.ICalc.FreezeCalc"/>.
/// (Since EFL 1.22)</summary>
/// <returns>The frozen state or 0 if the object is not frozen or on error.</returns>
int ThawCalc();
    /// <summary>Forces a Size/Geometry calculation.
/// Forces the object to recalculate its layout regardless of freeze/thaw. This API should be used carefully.
/// 
/// See also <see cref="Efl.Layout.ICalc.FreezeCalc"/> and <see cref="Efl.Layout.ICalc.ThawCalc"/>.
/// (Since EFL 1.22)</summary>
void CalcForce();
                                /// <summary>The layout was recalculated.
    /// (Since EFL 1.22)</summary>
    event EventHandler RecalcEvt;
    /// <summary>A circular dependency between parts of the object was found.
    /// (Since EFL 1.22)</summary>
    event EventHandler<Efl.Layout.ICalcCircularDependencyEvt_Args> CircularDependencyEvt;
    /// <summary>Whether this object updates its size hints automatically.
    /// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
    /// 
    /// A layout recalculation can be triggered by <see cref="Efl.Layout.ICalc.CalcSizeMin"/>, <see cref="Efl.Layout.ICalc.CalcSizeMin"/>, <see cref="Efl.Layout.ICalc.CalcPartsExtends"/> or even any other internal event.
    /// (Since EFL 1.22)</summary>
    /// <value>Whether or not update the size hints.</value>
    bool CalcAutoUpdateHints {
        get ;
        set ;
    }
}
///<summary>Event argument wrapper for event <see cref="Efl.Layout.ICalc.CircularDependencyEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ICalcCircularDependencyEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Eina.Array<System.String> arg { get; set; }
}
/// <summary>This interface defines a common set of APIs used to trigger calculations with layout objects.
/// This defines all the APIs supported by legacy &quot;Edje&quot; object, known in EO API as Efl.Canvas.Layout.
/// (Since EFL 1.22)</summary>
sealed public class ICalcConcrete :
    Efl.Eo.EoWrapper
    , ICalc
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ICalcConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private ICalcConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)] internal static extern System.IntPtr
        efl_layout_calc_interface_get();
    /// <summary>Initializes a new instance of the <see cref="ICalc"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ICalcConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>The layout was recalculated.
    /// (Since EFL 1.22)</summary>
    public event EventHandler RecalcEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_LAYOUT_EVENT_RECALC";
                AddNativeEventHandler(efl.Libs.Edje, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_LAYOUT_EVENT_RECALC";
                RemoveNativeEventHandler(efl.Libs.Edje, key, value);
            }
        }
    }
    ///<summary>Method to raise event RecalcEvt.</summary>
    public void OnRecalcEvt(EventArgs e)
    {
        var key = "_EFL_LAYOUT_EVENT_RECALC";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Edje, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>A circular dependency between parts of the object was found.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Layout.ICalcCircularDependencyEvt_Args> CircularDependencyEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Layout.ICalcCircularDependencyEvt_Args args = new Efl.Layout.ICalcCircularDependencyEvt_Args();
                        args.arg = new Eina.Array<System.String>(evt.Info, false, false);
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
                AddNativeEventHandler(efl.Libs.Edje, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
                RemoveNativeEventHandler(efl.Libs.Edje, key, value);
            }
        }
    }
    ///<summary>Method to raise event CircularDependencyEvt.</summary>
    public void OnCircularDependencyEvt(Efl.Layout.ICalcCircularDependencyEvt_Args e)
    {
        var key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Edje, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.Handle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Whether this object updates its size hints automatically.
    /// (Since EFL 1.22)</summary>
    /// <returns>Whether or not update the size hints.</returns>
    public bool GetCalcAutoUpdateHints() {
         var _ret_var = Efl.Layout.ICalcConcrete.NativeMethods.efl_layout_calc_auto_update_hints_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enable or disable auto-update of size hints.
    /// (Since EFL 1.22)</summary>
    /// <param name="update">Whether or not update the size hints.</param>
    public void SetCalcAutoUpdateHints(bool update) {
                                 Efl.Layout.ICalcConcrete.NativeMethods.efl_layout_calc_auto_update_hints_set_ptr.Value.Delegate(this.NativeHandle,update);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Calculates the minimum required size for a given layout object.
    /// This call will trigger an internal recalculation of all parts of the object, in order to return its minimum required dimensions for width and height. The user might choose to impose those minimum sizes, making the resulting calculation to get to values greater or equal than <c>restricted</c> in both directions.
    /// 
    /// Note: At the end of this call, the object won&apos;t be automatically resized to the new dimensions, but just return the calculated sizes. The caller is the one up to change its geometry or not.
    /// 
    /// Warning: Be advised that invisible parts in the object will be taken into account in this calculation.
    /// (Since EFL 1.22)</summary>
    /// <param name="restricted">The minimum size constraint as input, the returned size can not be lower than this (in both directions).</param>
    /// <returns>The minimum required size.</returns>
    public Eina.Size2D CalcSizeMin(Eina.Size2D restricted) {
         Eina.Size2D.NativeStruct _in_restricted = restricted;
                        var _ret_var = Efl.Layout.ICalcConcrete.NativeMethods.efl_layout_calc_size_min_ptr.Value.Delegate(this.NativeHandle,_in_restricted);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Calculates the geometry of the region, relative to a given layout object&apos;s area, occupied by all parts in the object.
    /// This function gets the geometry of the rectangle equal to the area required to group all parts in obj&apos;s group/collection. The x and y coordinates are relative to the top left corner of the whole obj object&apos;s area. Parts placed out of the group&apos;s boundaries will also be taken in account, so that x and y may be negative.
    /// 
    /// Note: On failure, this function will make all non-<c>null</c> geometry pointers&apos; pointed variables be set to zero.
    /// (Since EFL 1.22)</summary>
    /// <returns>The calculated region.</returns>
    public Eina.Rect CalcPartsExtends() {
         var _ret_var = Efl.Layout.ICalcConcrete.NativeMethods.efl_layout_calc_parts_extends_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Freezes the layout object.
    /// This function puts all changes on hold. Successive freezes will nest, requiring an equal number of thaws.
    /// 
    /// See also <see cref="Efl.Layout.ICalc.ThawCalc"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>The frozen state or 0 on error</returns>
    public int FreezeCalc() {
         var _ret_var = Efl.Layout.ICalcConcrete.NativeMethods.efl_layout_calc_freeze_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Thaws the layout object.
    /// This function thaws (in other words &quot;unfreezes&quot;) the given layout object.
    /// 
    /// Note: If successive freezes were done, an equal number of thaws will be required.
    /// 
    /// See also <see cref="Efl.Layout.ICalc.FreezeCalc"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>The frozen state or 0 if the object is not frozen or on error.</returns>
    public int ThawCalc() {
         var _ret_var = Efl.Layout.ICalcConcrete.NativeMethods.efl_layout_calc_thaw_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Forces a Size/Geometry calculation.
    /// Forces the object to recalculate its layout regardless of freeze/thaw. This API should be used carefully.
    /// 
    /// See also <see cref="Efl.Layout.ICalc.FreezeCalc"/> and <see cref="Efl.Layout.ICalc.ThawCalc"/>.
    /// (Since EFL 1.22)</summary>
    public void CalcForce() {
         Efl.Layout.ICalcConcrete.NativeMethods.efl_layout_calc_force_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Whether this object updates its size hints automatically.
    /// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
    /// 
    /// A layout recalculation can be triggered by <see cref="Efl.Layout.ICalc.CalcSizeMin"/>, <see cref="Efl.Layout.ICalc.CalcSizeMin"/>, <see cref="Efl.Layout.ICalc.CalcPartsExtends"/> or even any other internal event.
    /// (Since EFL 1.22)</summary>
    /// <value>Whether or not update the size hints.</value>
    public bool CalcAutoUpdateHints {
        get { return GetCalcAutoUpdateHints(); }
        set { SetCalcAutoUpdateHints(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Layout.ICalcConcrete.efl_layout_calc_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Edje);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_layout_calc_auto_update_hints_get_static_delegate == null)
            {
                efl_layout_calc_auto_update_hints_get_static_delegate = new efl_layout_calc_auto_update_hints_get_delegate(calc_auto_update_hints_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCalcAutoUpdateHints") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_auto_update_hints_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_auto_update_hints_get_static_delegate) });
            }

            if (efl_layout_calc_auto_update_hints_set_static_delegate == null)
            {
                efl_layout_calc_auto_update_hints_set_static_delegate = new efl_layout_calc_auto_update_hints_set_delegate(calc_auto_update_hints_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCalcAutoUpdateHints") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_auto_update_hints_set"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_auto_update_hints_set_static_delegate) });
            }

            if (efl_layout_calc_size_min_static_delegate == null)
            {
                efl_layout_calc_size_min_static_delegate = new efl_layout_calc_size_min_delegate(calc_size_min);
            }

            if (methods.FirstOrDefault(m => m.Name == "CalcSizeMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_size_min"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_size_min_static_delegate) });
            }

            if (efl_layout_calc_parts_extends_static_delegate == null)
            {
                efl_layout_calc_parts_extends_static_delegate = new efl_layout_calc_parts_extends_delegate(calc_parts_extends);
            }

            if (methods.FirstOrDefault(m => m.Name == "CalcPartsExtends") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_parts_extends"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_parts_extends_static_delegate) });
            }

            if (efl_layout_calc_freeze_static_delegate == null)
            {
                efl_layout_calc_freeze_static_delegate = new efl_layout_calc_freeze_delegate(calc_freeze);
            }

            if (methods.FirstOrDefault(m => m.Name == "FreezeCalc") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_freeze"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_freeze_static_delegate) });
            }

            if (efl_layout_calc_thaw_static_delegate == null)
            {
                efl_layout_calc_thaw_static_delegate = new efl_layout_calc_thaw_delegate(calc_thaw);
            }

            if (methods.FirstOrDefault(m => m.Name == "ThawCalc") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_thaw"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_thaw_static_delegate) });
            }

            if (efl_layout_calc_force_static_delegate == null)
            {
                efl_layout_calc_force_static_delegate = new efl_layout_calc_force_delegate(calc_force);
            }

            if (methods.FirstOrDefault(m => m.Name == "CalcForce") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_force"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_force_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Layout.ICalcConcrete.efl_layout_calc_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_layout_calc_auto_update_hints_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_layout_calc_auto_update_hints_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_get_api_delegate> efl_layout_calc_auto_update_hints_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_get_api_delegate>(Module, "efl_layout_calc_auto_update_hints_get");

        private static bool calc_auto_update_hints_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_calc_auto_update_hints_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ICalc)ws.Target).GetCalcAutoUpdateHints();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_layout_calc_auto_update_hints_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_calc_auto_update_hints_get_delegate efl_layout_calc_auto_update_hints_get_static_delegate;

        
        private delegate void efl_layout_calc_auto_update_hints_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool update);

        
        public delegate void efl_layout_calc_auto_update_hints_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool update);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_set_api_delegate> efl_layout_calc_auto_update_hints_set_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_set_api_delegate>(Module, "efl_layout_calc_auto_update_hints_set");

        private static void calc_auto_update_hints_set(System.IntPtr obj, System.IntPtr pd, bool update)
        {
            Eina.Log.Debug("function efl_layout_calc_auto_update_hints_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ICalc)ws.Target).SetCalcAutoUpdateHints(update);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_layout_calc_auto_update_hints_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), update);
            }
        }

        private static efl_layout_calc_auto_update_hints_set_delegate efl_layout_calc_auto_update_hints_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_layout_calc_size_min_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct restricted);

        
        public delegate Eina.Size2D.NativeStruct efl_layout_calc_size_min_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct restricted);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_size_min_api_delegate> efl_layout_calc_size_min_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_size_min_api_delegate>(Module, "efl_layout_calc_size_min");

        private static Eina.Size2D.NativeStruct calc_size_min(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct restricted)
        {
            Eina.Log.Debug("function efl_layout_calc_size_min was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_restricted = restricted;
                            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((ICalc)ws.Target).CalcSizeMin(_in_restricted);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        return _ret_var;

            }
            else
            {
                return efl_layout_calc_size_min_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), restricted);
            }
        }

        private static efl_layout_calc_size_min_delegate efl_layout_calc_size_min_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_layout_calc_parts_extends_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_layout_calc_parts_extends_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_parts_extends_api_delegate> efl_layout_calc_parts_extends_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_parts_extends_api_delegate>(Module, "efl_layout_calc_parts_extends");

        private static Eina.Rect.NativeStruct calc_parts_extends(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_calc_parts_extends was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((ICalc)ws.Target).CalcPartsExtends();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_layout_calc_parts_extends_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_calc_parts_extends_delegate efl_layout_calc_parts_extends_static_delegate;

        
        private delegate int efl_layout_calc_freeze_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_layout_calc_freeze_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_freeze_api_delegate> efl_layout_calc_freeze_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_freeze_api_delegate>(Module, "efl_layout_calc_freeze");

        private static int calc_freeze(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_calc_freeze was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((ICalc)ws.Target).FreezeCalc();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_layout_calc_freeze_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_calc_freeze_delegate efl_layout_calc_freeze_static_delegate;

        
        private delegate int efl_layout_calc_thaw_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_layout_calc_thaw_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_thaw_api_delegate> efl_layout_calc_thaw_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_thaw_api_delegate>(Module, "efl_layout_calc_thaw");

        private static int calc_thaw(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_calc_thaw was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((ICalc)ws.Target).ThawCalc();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_layout_calc_thaw_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_calc_thaw_delegate efl_layout_calc_thaw_static_delegate;

        
        private delegate void efl_layout_calc_force_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_layout_calc_force_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_force_api_delegate> efl_layout_calc_force_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_force_api_delegate>(Module, "efl_layout_calc_force");

        private static void calc_force(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_calc_force was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((ICalc)ws.Target).CalcForce();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_layout_calc_force_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_calc_force_delegate efl_layout_calc_force_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

