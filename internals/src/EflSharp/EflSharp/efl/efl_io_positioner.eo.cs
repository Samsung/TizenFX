#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Io {

/// <summary>Generic interface for objects that can change or report position.</summary>
[Efl.Io.IPositionerConcrete.NativeMethods]
public interface IPositioner : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Position property</summary>
/// <returns>Position in file or buffer</returns>
ulong GetPosition();
    /// <summary>Try to set position object, relative to start of file. See <see cref="Efl.Io.IPositioner.Seek"/></summary>
/// <param name="position">Position in file or buffer</param>
/// <returns><c>true</c> if could reposition, <c>false</c> if errors.</returns>
bool SetPosition(ulong position);
    /// <summary>Seek in data</summary>
/// <param name="offset">Offset in byte relative to whence</param>
/// <param name="whence">Whence</param>
/// <returns>0 on succeed, a mapping of errno otherwise</returns>
Eina.Error Seek(long offset, Efl.Io.PositionerWhence whence);
                /// <summary>Notifies position changed</summary>
    event EventHandler PositionChangedEvt;
    /// <summary>Position property</summary>
    /// <value>Position in file or buffer</value>
    ulong Position {
        get ;
        set ;
    }
}
/// <summary>Generic interface for objects that can change or report position.</summary>
sealed public class IPositionerConcrete :
    Efl.Eo.EoWrapper
    , IPositioner
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IPositionerConcrete))
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
        efl_io_positioner_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IPositioner"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IPositionerConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Notifies position changed</summary>
    public event EventHandler PositionChangedEvt
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

                string key = "_EFL_IO_POSITIONER_EVENT_POSITION_CHANGED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_IO_POSITIONER_EVENT_POSITION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event PositionChangedEvt.</summary>
    public void OnPositionChangedEvt(EventArgs e)
    {
        var key = "_EFL_IO_POSITIONER_EVENT_POSITION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Position property</summary>
    /// <returns>Position in file or buffer</returns>
    public ulong GetPosition() {
         var _ret_var = Efl.Io.IPositionerConcrete.NativeMethods.efl_io_positioner_position_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Try to set position object, relative to start of file. See <see cref="Efl.Io.IPositioner.Seek"/></summary>
    /// <param name="position">Position in file or buffer</param>
    /// <returns><c>true</c> if could reposition, <c>false</c> if errors.</returns>
    public bool SetPosition(ulong position) {
                                 var _ret_var = Efl.Io.IPositionerConcrete.NativeMethods.efl_io_positioner_position_set_ptr.Value.Delegate(this.NativeHandle,position);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Seek in data</summary>
    /// <param name="offset">Offset in byte relative to whence</param>
    /// <param name="whence">Whence</param>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    public Eina.Error Seek(long offset, Efl.Io.PositionerWhence whence) {
                                                         var _ret_var = Efl.Io.IPositionerConcrete.NativeMethods.efl_io_positioner_seek_ptr.Value.Delegate(this.NativeHandle,offset, whence);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Position property</summary>
    /// <value>Position in file or buffer</value>
    public ulong Position {
        get { return GetPosition(); }
        set { SetPosition(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Io.IPositionerConcrete.efl_io_positioner_mixin_get();
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

            if (efl_io_positioner_position_get_static_delegate == null)
            {
                efl_io_positioner_position_get_static_delegate = new efl_io_positioner_position_get_delegate(position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_positioner_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_position_get_static_delegate) });
            }

            if (efl_io_positioner_position_set_static_delegate == null)
            {
                efl_io_positioner_position_set_static_delegate = new efl_io_positioner_position_set_delegate(position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_positioner_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_position_set_static_delegate) });
            }

            if (efl_io_positioner_seek_static_delegate == null)
            {
                efl_io_positioner_seek_static_delegate = new efl_io_positioner_seek_delegate(seek);
            }

            if (methods.FirstOrDefault(m => m.Name == "Seek") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_positioner_seek"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_seek_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Io.IPositionerConcrete.efl_io_positioner_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate ulong efl_io_positioner_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate ulong efl_io_positioner_position_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_positioner_position_get_api_delegate> efl_io_positioner_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_positioner_position_get_api_delegate>(Module, "efl_io_positioner_position_get");

        private static ulong position_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_positioner_position_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            ulong _ret_var = default(ulong);
                try
                {
                    _ret_var = ((IPositioner)ws.Target).GetPosition();
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
                return efl_io_positioner_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_positioner_position_get_delegate efl_io_positioner_position_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_io_positioner_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  ulong position);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_io_positioner_position_set_api_delegate(System.IntPtr obj,  ulong position);

        public static Efl.Eo.FunctionWrapper<efl_io_positioner_position_set_api_delegate> efl_io_positioner_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_positioner_position_set_api_delegate>(Module, "efl_io_positioner_position_set");

        private static bool position_set(System.IntPtr obj, System.IntPtr pd, ulong position)
        {
            Eina.Log.Debug("function efl_io_positioner_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPositioner)ws.Target).SetPosition(position);
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
                return efl_io_positioner_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), position);
            }
        }

        private static efl_io_positioner_position_set_delegate efl_io_positioner_position_set_static_delegate;

        
        private delegate Eina.Error efl_io_positioner_seek_delegate(System.IntPtr obj, System.IntPtr pd,  long offset,  Efl.Io.PositionerWhence whence);

        
        public delegate Eina.Error efl_io_positioner_seek_api_delegate(System.IntPtr obj,  long offset,  Efl.Io.PositionerWhence whence);

        public static Efl.Eo.FunctionWrapper<efl_io_positioner_seek_api_delegate> efl_io_positioner_seek_ptr = new Efl.Eo.FunctionWrapper<efl_io_positioner_seek_api_delegate>(Module, "efl_io_positioner_seek");

        private static Eina.Error seek(System.IntPtr obj, System.IntPtr pd, long offset, Efl.Io.PositionerWhence whence)
        {
            Eina.Log.Debug("function efl_io_positioner_seek was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((IPositioner)ws.Target).Seek(offset, whence);
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
                return efl_io_positioner_seek_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), offset, whence);
            }
        }

        private static efl_io_positioner_seek_delegate efl_io_positioner_seek_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

namespace Efl {

namespace Io {

/// <summary>Seek position modes</summary>
public enum PositionerWhence
{
/// <summary>Seek from start of the stream/file</summary>
Start = 0,
/// <summary>Seek from current position</summary>
Current = 1,
/// <summary>Seek from the end of stream/file</summary>
End = 2,
}

}

}

