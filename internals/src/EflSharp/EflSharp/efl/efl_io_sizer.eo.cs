#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Io {

/// <summary>Generic interface for objects that can resize or report size of themselves.
/// This interface allows external objects to transparently resize or report its size.</summary>
[Efl.Io.ISizerConcrete.NativeMethods]
public interface ISizer : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Size property</summary>
/// <returns>Object size</returns>
ulong GetSize();
    /// <summary>Try to resize the object, check with get if the value was accepted or not.</summary>
/// <param name="size">Object size</param>
/// <returns><c>true</c> if could resize, <c>false</c> if errors.</returns>
bool SetSize(ulong size);
    /// <summary>Resize object</summary>
/// <param name="size">Object size</param>
/// <returns>0 on succeed, a mapping of errno otherwise</returns>
Eina.Error Resize(ulong size);
                /// <summary>Notifies size changed</summary>
    event EventHandler SizeChangedEvt;
    /// <summary>Size property</summary>
    /// <value>Object size</value>
    ulong Size {
        get ;
        set ;
    }
}
/// <summary>Generic interface for objects that can resize or report size of themselves.
/// This interface allows external objects to transparently resize or report its size.</summary>
sealed public class ISizerConcrete :
    Efl.Eo.EoWrapper
    , ISizer
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ISizerConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_io_sizer_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="ISizer"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private ISizerConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Notifies size changed</summary>
    public event EventHandler SizeChangedEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_IO_SIZER_EVENT_SIZE_CHANGED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_IO_SIZER_EVENT_SIZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event SizeChangedEvt.</summary>
    public void OnSizeChangedEvt(EventArgs e)
    {
        var key = "_EFL_IO_SIZER_EVENT_SIZE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Size property</summary>
    /// <returns>Object size</returns>
    public ulong GetSize() {
         var _ret_var = Efl.Io.ISizerConcrete.NativeMethods.efl_io_sizer_size_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Try to resize the object, check with get if the value was accepted or not.</summary>
    /// <param name="size">Object size</param>
    /// <returns><c>true</c> if could resize, <c>false</c> if errors.</returns>
    public bool SetSize(ulong size) {
                                 var _ret_var = Efl.Io.ISizerConcrete.NativeMethods.efl_io_sizer_size_set_ptr.Value.Delegate(this.NativeHandle,size);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Resize object</summary>
    /// <param name="size">Object size</param>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    public Eina.Error Resize(ulong size) {
                                 var _ret_var = Efl.Io.ISizerConcrete.NativeMethods.efl_io_sizer_resize_ptr.Value.Delegate(this.NativeHandle,size);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Size property</summary>
    /// <value>Object size</value>
    public ulong Size {
        get { return GetSize(); }
        set { SetSize(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Io.ISizerConcrete.efl_io_sizer_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_io_sizer_size_get_static_delegate == null)
            {
                efl_io_sizer_size_get_static_delegate = new efl_io_sizer_size_get_delegate(size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_sizer_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_size_get_static_delegate) });
            }

            if (efl_io_sizer_size_set_static_delegate == null)
            {
                efl_io_sizer_size_set_static_delegate = new efl_io_sizer_size_set_delegate(size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_sizer_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_size_set_static_delegate) });
            }

            if (efl_io_sizer_resize_static_delegate == null)
            {
                efl_io_sizer_resize_static_delegate = new efl_io_sizer_resize_delegate(resize);
            }

            if (methods.FirstOrDefault(m => m.Name == "Resize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_sizer_resize"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_resize_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Io.ISizerConcrete.efl_io_sizer_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate ulong efl_io_sizer_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate ulong efl_io_sizer_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_sizer_size_get_api_delegate> efl_io_sizer_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_sizer_size_get_api_delegate>(Module, "efl_io_sizer_size_get");

        private static ulong size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_sizer_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            ulong _ret_var = default(ulong);
                try
                {
                    _ret_var = ((ISizerConcrete)ws.Target).GetSize();
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
                return efl_io_sizer_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_sizer_size_get_delegate efl_io_sizer_size_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_io_sizer_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  ulong size);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_io_sizer_size_set_api_delegate(System.IntPtr obj,  ulong size);

        public static Efl.Eo.FunctionWrapper<efl_io_sizer_size_set_api_delegate> efl_io_sizer_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_sizer_size_set_api_delegate>(Module, "efl_io_sizer_size_set");

        private static bool size_set(System.IntPtr obj, System.IntPtr pd, ulong size)
        {
            Eina.Log.Debug("function efl_io_sizer_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISizerConcrete)ws.Target).SetSize(size);
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
                return efl_io_sizer_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size);
            }
        }

        private static efl_io_sizer_size_set_delegate efl_io_sizer_size_set_static_delegate;

        
        private delegate Eina.Error efl_io_sizer_resize_delegate(System.IntPtr obj, System.IntPtr pd,  ulong size);

        
        public delegate Eina.Error efl_io_sizer_resize_api_delegate(System.IntPtr obj,  ulong size);

        public static Efl.Eo.FunctionWrapper<efl_io_sizer_resize_api_delegate> efl_io_sizer_resize_ptr = new Efl.Eo.FunctionWrapper<efl_io_sizer_resize_api_delegate>(Module, "efl_io_sizer_resize");

        private static Eina.Error resize(System.IntPtr obj, System.IntPtr pd, ulong size)
        {
            Eina.Log.Debug("function efl_io_sizer_resize was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((ISizerConcrete)ws.Target).Resize(size);
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
                return efl_io_sizer_resize_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size);
            }
        }

        private static efl_io_sizer_resize_delegate efl_io_sizer_resize_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

