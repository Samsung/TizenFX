#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Io {

/// <summary>Generic interface for objects that can read data into a provided memory.
/// This interface allows external objects to transparently monitor for new data and as it to be read into a provided memory slice.
/// 
/// Calls to <see cref="Efl.Io.IReader.Read"/> may or may not block, that&apos;s not up to this interface to specify. The user can check based on <see cref="Efl.Io.IReader.Eos"/> property and signal if the stream reached an end, with event &quot;can_read,changed&quot; or property <see cref="Efl.Io.IReader.CanRead"/> to known whenever a read would have data to return.
/// (Since EFL 1.22)</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Io.ReaderConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IReader : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</returns>
bool GetCanRead();
        /// <summary>If <c>true</c> will notify end of stream.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if end of stream, <c>false</c> otherwise</returns>
bool GetEos();
        /// <summary>Reads data into a pre-allocated buffer.
/// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
/// 
/// You can understand this method as read(2) libc function.
/// (Since EFL 1.22)</summary>
/// <param name="rw_slice">Provides a pre-allocated memory to be filled up to rw_slice.len. It will be populated and the length will be set to the actually used amount of bytes, which can be smaller than the request.</param>
/// <returns>0 on succeed, a mapping of errno otherwise</returns>
Eina.Error Read(ref  Eina.RwSlice rw_slice);
                        /// <summary>Notifies can_read property changed.
    /// If <see cref="Efl.Io.IReader.CanRead"/> is <c>true</c> there is data to <see cref="Efl.Io.IReader.Read"/> without blocking/error. If <see cref="Efl.Io.IReader.CanRead"/> is <c>false</c>, <see cref="Efl.Io.IReader.Read"/> would either block or fail.
    /// 
    /// Note that usually this event is dispatched from inside <see cref="Efl.Io.IReader.Read"/>, thus before it returns.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Io.ReaderCanReadChangedEventArgs"/></value>
    event EventHandler<Efl.Io.ReaderCanReadChangedEventArgs> CanReadChangedEvent;
    /// <summary>Notifies end of stream, when property is marked as true.
    /// If this is used alongside with an <see cref="Efl.Io.ICloser"/>, then it should be emitted before that call.
    /// 
    /// It should be emitted only once for an object unless it implements <see cref="Efl.Io.IPositioner.Seek"/>.
    /// 
    /// The property <see cref="Efl.Io.IReader.CanRead"/> should change to <c>false</c> before this event is dispatched.
    /// (Since EFL 1.22)</summary>
    event EventHandler EosEvent;
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</value>
    bool CanRead {
        get;
    }
    /// <summary>If <c>true</c> will notify end of stream.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if end of stream, <c>false</c> otherwise</value>
    bool Eos {
        get;
    }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Io.IReader.CanReadChangedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ReaderCanReadChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Notifies can_read property changed.</value>
    public bool arg { get; set; }
}
/// <summary>Generic interface for objects that can read data into a provided memory.
/// This interface allows external objects to transparently monitor for new data and as it to be read into a provided memory slice.
/// 
/// Calls to <see cref="Efl.Io.IReader.Read"/> may or may not block, that&apos;s not up to this interface to specify. The user can check based on <see cref="Efl.Io.IReader.Eos"/> property and signal if the stream reached an end, with event &quot;can_read,changed&quot; or property <see cref="Efl.Io.IReader.CanRead"/> to known whenever a read would have data to return.
/// (Since EFL 1.22)</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class ReaderConcrete :
    Efl.Eo.EoWrapper
    , IReader
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ReaderConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private ReaderConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_io_reader_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IReader"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ReaderConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Notifies can_read property changed.
    /// If <see cref="Efl.Io.IReader.CanRead"/> is <c>true</c> there is data to <see cref="Efl.Io.IReader.Read"/> without blocking/error. If <see cref="Efl.Io.IReader.CanRead"/> is <c>false</c>, <see cref="Efl.Io.IReader.Read"/> would either block or fail.
    /// 
    /// Note that usually this event is dispatched from inside <see cref="Efl.Io.IReader.Read"/>, thus before it returns.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Io.ReaderCanReadChangedEventArgs"/></value>
    public event EventHandler<Efl.Io.ReaderCanReadChangedEventArgs> CanReadChangedEvent
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
                        Efl.Io.ReaderCanReadChangedEventArgs args = new Efl.Io.ReaderCanReadChangedEventArgs();
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

                string key = "_EFL_IO_READER_EVENT_CAN_READ_CHANGED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_IO_READER_EVENT_CAN_READ_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event CanReadChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnCanReadChangedEvent(Efl.Io.ReaderCanReadChangedEventArgs e)
    {
        var key = "_EFL_IO_READER_EVENT_CAN_READ_CHANGED";
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
    /// <summary>Notifies end of stream, when property is marked as true.
    /// If this is used alongside with an <see cref="Efl.Io.ICloser"/>, then it should be emitted before that call.
    /// 
    /// It should be emitted only once for an object unless it implements <see cref="Efl.Io.IPositioner.Seek"/>.
    /// 
    /// The property <see cref="Efl.Io.IReader.CanRead"/> should change to <c>false</c> before this event is dispatched.
    /// (Since EFL 1.22)</summary>
    public event EventHandler EosEvent
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

                string key = "_EFL_IO_READER_EVENT_EOS";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_IO_READER_EVENT_EOS";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event EosEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnEosEvent(EventArgs e)
    {
        var key = "_EFL_IO_READER_EVENT_EOS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
#pragma warning disable CS0628
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</returns>
    public bool GetCanRead() {
         var _ret_var = Efl.Io.ReaderConcrete.NativeMethods.efl_io_reader_can_read_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <param name="can_read"><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</param>
    protected void SetCanRead(bool can_read) {
                                 Efl.Io.ReaderConcrete.NativeMethods.efl_io_reader_can_read_set_ptr.Value.Delegate(this.NativeHandle,can_read);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>If <c>true</c> will notify end of stream.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if end of stream, <c>false</c> otherwise</returns>
    public bool GetEos() {
         var _ret_var = Efl.Io.ReaderConcrete.NativeMethods.efl_io_reader_eos_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify end of stream.
    /// (Since EFL 1.22)</summary>
    /// <param name="is_eos"><c>true</c> if end of stream, <c>false</c> otherwise</param>
    protected void SetEos(bool is_eos) {
                                 Efl.Io.ReaderConcrete.NativeMethods.efl_io_reader_eos_set_ptr.Value.Delegate(this.NativeHandle,is_eos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Reads data into a pre-allocated buffer.
    /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
    /// 
    /// You can understand this method as read(2) libc function.
    /// (Since EFL 1.22)</summary>
    /// <param name="rw_slice">Provides a pre-allocated memory to be filled up to rw_slice.len. It will be populated and the length will be set to the actually used amount of bytes, which can be smaller than the request.</param>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    public Eina.Error Read(ref  Eina.RwSlice rw_slice) {
                                 var _ret_var = Efl.Io.ReaderConcrete.NativeMethods.efl_io_reader_read_ptr.Value.Delegate(this.NativeHandle,ref rw_slice);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</value>
    public bool CanRead {
        get { return GetCanRead(); }
        protected set { SetCanRead(value); }
    }
    /// <summary>If <c>true</c> will notify end of stream.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if end of stream, <c>false</c> otherwise</value>
    public bool Eos {
        get { return GetEos(); }
        protected set { SetEos(value); }
    }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Io.ReaderConcrete.efl_io_reader_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_io_reader_can_read_get_static_delegate == null)
            {
                efl_io_reader_can_read_get_static_delegate = new efl_io_reader_can_read_get_delegate(can_read_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCanRead") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_reader_can_read_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_can_read_get_static_delegate) });
            }

            if (efl_io_reader_eos_get_static_delegate == null)
            {
                efl_io_reader_eos_get_static_delegate = new efl_io_reader_eos_get_delegate(eos_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEos") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_reader_eos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_eos_get_static_delegate) });
            }

            if (efl_io_reader_read_static_delegate == null)
            {
                efl_io_reader_read_static_delegate = new efl_io_reader_read_delegate(read);
            }

            if (methods.FirstOrDefault(m => m.Name == "Read") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_reader_read"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_read_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Io.ReaderConcrete.efl_io_reader_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_io_reader_can_read_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_io_reader_can_read_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_reader_can_read_get_api_delegate> efl_io_reader_can_read_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_can_read_get_api_delegate>(Module, "efl_io_reader_can_read_get");

        private static bool can_read_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_reader_can_read_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IReader)ws.Target).GetCanRead();
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
                return efl_io_reader_can_read_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_reader_can_read_get_delegate efl_io_reader_can_read_get_static_delegate;

        
        private delegate void efl_io_reader_can_read_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool can_read);

        
        public delegate void efl_io_reader_can_read_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool can_read);

        public static Efl.Eo.FunctionWrapper<efl_io_reader_can_read_set_api_delegate> efl_io_reader_can_read_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_can_read_set_api_delegate>(Module, "efl_io_reader_can_read_set");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_io_reader_eos_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_io_reader_eos_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_reader_eos_get_api_delegate> efl_io_reader_eos_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_eos_get_api_delegate>(Module, "efl_io_reader_eos_get");

        private static bool eos_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_reader_eos_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IReader)ws.Target).GetEos();
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
                return efl_io_reader_eos_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_reader_eos_get_delegate efl_io_reader_eos_get_static_delegate;

        
        private delegate void efl_io_reader_eos_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool is_eos);

        
        public delegate void efl_io_reader_eos_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool is_eos);

        public static Efl.Eo.FunctionWrapper<efl_io_reader_eos_set_api_delegate> efl_io_reader_eos_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_eos_set_api_delegate>(Module, "efl_io_reader_eos_set");

        
        private delegate Eina.Error efl_io_reader_read_delegate(System.IntPtr obj, System.IntPtr pd,  ref  Eina.RwSlice rw_slice);

        
        public delegate Eina.Error efl_io_reader_read_api_delegate(System.IntPtr obj,  ref  Eina.RwSlice rw_slice);

        public static Efl.Eo.FunctionWrapper<efl_io_reader_read_api_delegate> efl_io_reader_read_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_read_api_delegate>(Module, "efl_io_reader_read");

        private static Eina.Error read(System.IntPtr obj, System.IntPtr pd, ref  Eina.RwSlice rw_slice)
        {
            Eina.Log.Debug("function efl_io_reader_read was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((IReader)ws.Target).Read(ref rw_slice);
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
                return efl_io_reader_read_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ref rw_slice);
            }
        }

        private static efl_io_reader_read_delegate efl_io_reader_read_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_IoReaderConcrete_ExtensionMethods {
    public static Efl.BindableProperty<bool> CanRead<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Io.IReader, T>magic = null) where T : Efl.Io.IReader {
        return new Efl.BindableProperty<bool>("can_read", fac);
    }

    public static Efl.BindableProperty<bool> Eos<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Io.IReader, T>magic = null) where T : Efl.Io.IReader {
        return new Efl.BindableProperty<bool>("eos", fac);
    }

}
#pragma warning restore CS1591
#endif
