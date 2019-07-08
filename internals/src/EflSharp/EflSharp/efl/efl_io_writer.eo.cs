#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Io {

/// <summary>Generic interface for objects that can write data from a provided memory.
/// This interface allows external objects to transparently write data to this object and be notified whether more data can be written or if it&apos;s reached capacity.
/// 
/// Calls to <see cref="Efl.Io.IWriter.Write"/> may or may not block: that&apos;s not up to this interface to specify. The user can check with event &quot;can_write,changed&quot; or property <see cref="Efl.Io.IWriter.CanWrite"/> to known whenever a write could push more data.
/// (Since EFL 1.22)</summary>
[Efl.Io.IWriterConcrete.NativeMethods]
public interface IWriter : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</returns>
bool GetCanWrite();
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.
/// (Since EFL 1.22)</summary>
/// <param name="can_write"><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</param>
void SetCanWrite(bool can_write);
    /// <summary>Writes data from a pre-populated buffer.
/// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
/// 
/// You can understand this method as write(2) libc function.
/// (Since EFL 1.22)</summary>
/// <param name="slice">Provides a pre-populated memory to be used up to slice.len. The returned slice will be adapted as length will be set to the actually used amount of bytes, which can be smaller than the request.</param>
/// <param name="remaining">Convenience to output the remaining parts of slice that was not written. If the full slice was written, this will be a slice of zero-length.</param>
/// <returns>0 on succeed, a mapping of errno otherwise</returns>
Eina.Error Write(ref Eina.Slice slice, ref Eina.Slice remaining);
                /// <summary>Notifies can_write property changed.
    /// If <see cref="Efl.Io.IWriter.CanWrite"/> is <c>true</c> there is data to <see cref="Efl.Io.IWriter.Write"/> without blocking/error. If <see cref="Efl.Io.IWriter.CanWrite"/> is <c>false</c>, <see cref="Efl.Io.IWriter.Write"/> would either block or fail.
    /// 
    /// Note that usually this event is dispatched from inside <see cref="Efl.Io.IWriter.Write"/>, thus before it returns.
    /// (Since EFL 1.22)</summary>
    event EventHandler<Efl.Io.IWriterCanWriteChangedEvt_Args> CanWriteChangedEvt;
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</value>
    bool CanWrite {
        get ;
        set ;
    }
}
///<summary>Event argument wrapper for event <see cref="Efl.Io.IWriter.CanWriteChangedEvt"/>.</summary>
public class IWriterCanWriteChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public bool arg { get; set; }
}
/// <summary>Generic interface for objects that can write data from a provided memory.
/// This interface allows external objects to transparently write data to this object and be notified whether more data can be written or if it&apos;s reached capacity.
/// 
/// Calls to <see cref="Efl.Io.IWriter.Write"/> may or may not block: that&apos;s not up to this interface to specify. The user can check with event &quot;can_write,changed&quot; or property <see cref="Efl.Io.IWriter.CanWrite"/> to known whenever a write could push more data.
/// (Since EFL 1.22)</summary>
sealed public class IWriterConcrete :
    Efl.Eo.EoWrapper
    , IWriter
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IWriterConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_io_writer_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IWriter"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IWriterConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Notifies can_write property changed.
    /// If <see cref="Efl.Io.IWriter.CanWrite"/> is <c>true</c> there is data to <see cref="Efl.Io.IWriter.Write"/> without blocking/error. If <see cref="Efl.Io.IWriter.CanWrite"/> is <c>false</c>, <see cref="Efl.Io.IWriter.Write"/> would either block or fail.
    /// 
    /// Note that usually this event is dispatched from inside <see cref="Efl.Io.IWriter.Write"/>, thus before it returns.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Io.IWriterCanWriteChangedEvt_Args> CanWriteChangedEvt
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
                        Efl.Io.IWriterCanWriteChangedEvt_Args args = new Efl.Io.IWriterCanWriteChangedEvt_Args();
                        args.arg = Marshal.ReadByte(evt.Info) != 0;
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

                string key = "_EFL_IO_WRITER_EVENT_CAN_WRITE_CHANGED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_IO_WRITER_EVENT_CAN_WRITE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event CanWriteChangedEvt.</summary>
    public void OnCanWriteChangedEvt(Efl.Io.IWriterCanWriteChangedEvt_Args e)
    {
        var key = "_EFL_IO_WRITER_EVENT_CAN_WRITE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg ? (byte) 1 : (byte) 0);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</returns>
    public bool GetCanWrite() {
         var _ret_var = Efl.Io.IWriterConcrete.NativeMethods.efl_io_writer_can_write_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <param name="can_write"><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</param>
    public void SetCanWrite(bool can_write) {
                                 Efl.Io.IWriterConcrete.NativeMethods.efl_io_writer_can_write_set_ptr.Value.Delegate(this.NativeHandle,can_write);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Writes data from a pre-populated buffer.
    /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
    /// 
    /// You can understand this method as write(2) libc function.
    /// (Since EFL 1.22)</summary>
    /// <param name="slice">Provides a pre-populated memory to be used up to slice.len. The returned slice will be adapted as length will be set to the actually used amount of bytes, which can be smaller than the request.</param>
    /// <param name="remaining">Convenience to output the remaining parts of slice that was not written. If the full slice was written, this will be a slice of zero-length.</param>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    public Eina.Error Write(ref Eina.Slice slice, ref Eina.Slice remaining) {
                                                         var _ret_var = Efl.Io.IWriterConcrete.NativeMethods.efl_io_writer_write_ptr.Value.Delegate(this.NativeHandle,ref slice, ref remaining);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</value>
    public bool CanWrite {
        get { return GetCanWrite(); }
        set { SetCanWrite(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Io.IWriterConcrete.efl_io_writer_interface_get();
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

            if (efl_io_writer_can_write_get_static_delegate == null)
            {
                efl_io_writer_can_write_get_static_delegate = new efl_io_writer_can_write_get_delegate(can_write_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCanWrite") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_writer_can_write_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_can_write_get_static_delegate) });
            }

            if (efl_io_writer_can_write_set_static_delegate == null)
            {
                efl_io_writer_can_write_set_static_delegate = new efl_io_writer_can_write_set_delegate(can_write_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCanWrite") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_writer_can_write_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_can_write_set_static_delegate) });
            }

            if (efl_io_writer_write_static_delegate == null)
            {
                efl_io_writer_write_static_delegate = new efl_io_writer_write_delegate(write);
            }

            if (methods.FirstOrDefault(m => m.Name == "Write") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_writer_write"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_write_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Io.IWriterConcrete.efl_io_writer_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_io_writer_can_write_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_io_writer_can_write_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_writer_can_write_get_api_delegate> efl_io_writer_can_write_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_writer_can_write_get_api_delegate>(Module, "efl_io_writer_can_write_get");

        private static bool can_write_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_writer_can_write_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IWriter)ws.Target).GetCanWrite();
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
                return efl_io_writer_can_write_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_writer_can_write_get_delegate efl_io_writer_can_write_get_static_delegate;

        
        private delegate void efl_io_writer_can_write_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool can_write);

        
        public delegate void efl_io_writer_can_write_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool can_write);

        public static Efl.Eo.FunctionWrapper<efl_io_writer_can_write_set_api_delegate> efl_io_writer_can_write_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_writer_can_write_set_api_delegate>(Module, "efl_io_writer_can_write_set");

        private static void can_write_set(System.IntPtr obj, System.IntPtr pd, bool can_write)
        {
            Eina.Log.Debug("function efl_io_writer_can_write_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IWriter)ws.Target).SetCanWrite(can_write);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_io_writer_can_write_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), can_write);
            }
        }

        private static efl_io_writer_can_write_set_delegate efl_io_writer_can_write_set_static_delegate;

        
        private delegate Eina.Error efl_io_writer_write_delegate(System.IntPtr obj, System.IntPtr pd,  ref Eina.Slice slice,  ref Eina.Slice remaining);

        
        public delegate Eina.Error efl_io_writer_write_api_delegate(System.IntPtr obj,  ref Eina.Slice slice,  ref Eina.Slice remaining);

        public static Efl.Eo.FunctionWrapper<efl_io_writer_write_api_delegate> efl_io_writer_write_ptr = new Efl.Eo.FunctionWrapper<efl_io_writer_write_api_delegate>(Module, "efl_io_writer_write");

        private static Eina.Error write(System.IntPtr obj, System.IntPtr pd, ref Eina.Slice slice, ref Eina.Slice remaining)
        {
            Eina.Log.Debug("function efl_io_writer_write was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                remaining = default(Eina.Slice);                            Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((IWriter)ws.Target).Write(ref slice, ref remaining);
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
                return efl_io_writer_write_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ref slice, ref remaining);
            }
        }

        private static efl_io_writer_write_delegate efl_io_writer_write_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

