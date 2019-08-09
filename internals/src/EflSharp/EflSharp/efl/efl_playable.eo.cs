#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl media playable interface</summary>
[Efl.IPlayableConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IPlayable : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Get the length of play for the media file.</summary>
/// <returns>The length of the stream in seconds.</returns>
double GetLength();
    bool GetPlayable();
    /// <summary>Get whether the media file is seekable.</summary>
/// <returns><c>true</c> if seekable.</returns>
bool GetSeekable();
                /// <summary>Get the length of play for the media file.</summary>
    /// <value>The length of the stream in seconds.</value>
    double Length {
        get ;
    }
    bool Playable {
        get ;
    }
    /// <summary>Get whether the media file is seekable.</summary>
    /// <value><c>true</c> if seekable.</value>
    bool Seekable {
        get ;
    }
}
/// <summary>Efl media playable interface</summary>
sealed public class IPlayableConcrete :
    Efl.Eo.EoWrapper
    , IPlayable
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IPlayableConcrete))
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
    private IPlayableConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_playable_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IPlayable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IPlayableConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Get the length of play for the media file.</summary>
    /// <returns>The length of the stream in seconds.</returns>
    public double GetLength() {
         var _ret_var = Efl.IPlayableConcrete.NativeMethods.efl_playable_length_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    public bool GetPlayable() {
         var _ret_var = Efl.IPlayableConcrete.NativeMethods.efl_playable_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get whether the media file is seekable.</summary>
    /// <returns><c>true</c> if seekable.</returns>
    public bool GetSeekable() {
         var _ret_var = Efl.IPlayableConcrete.NativeMethods.efl_playable_seekable_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the length of play for the media file.</summary>
    /// <value>The length of the stream in seconds.</value>
    public double Length {
        get { return GetLength(); }
    }
    public bool Playable {
        get { return GetPlayable(); }
    }
    /// <summary>Get whether the media file is seekable.</summary>
    /// <value><c>true</c> if seekable.</value>
    public bool Seekable {
        get { return GetSeekable(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.IPlayableConcrete.efl_playable_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_playable_length_get_static_delegate == null)
            {
                efl_playable_length_get_static_delegate = new efl_playable_length_get_delegate(length_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLength") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_playable_length_get"), func = Marshal.GetFunctionPointerForDelegate(efl_playable_length_get_static_delegate) });
            }

            if (efl_playable_get_static_delegate == null)
            {
                efl_playable_get_static_delegate = new efl_playable_get_delegate(playable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPlayable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_playable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_playable_get_static_delegate) });
            }

            if (efl_playable_seekable_get_static_delegate == null)
            {
                efl_playable_seekable_get_static_delegate = new efl_playable_seekable_get_delegate(seekable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSeekable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_playable_seekable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_playable_seekable_get_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.IPlayableConcrete.efl_playable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_playable_length_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_playable_length_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_playable_length_get_api_delegate> efl_playable_length_get_ptr = new Efl.Eo.FunctionWrapper<efl_playable_length_get_api_delegate>(Module, "efl_playable_length_get");

        private static double length_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_playable_length_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((IPlayable)ws.Target).GetLength();
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
                return efl_playable_length_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_playable_length_get_delegate efl_playable_length_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_playable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_playable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_playable_get_api_delegate> efl_playable_get_ptr = new Efl.Eo.FunctionWrapper<efl_playable_get_api_delegate>(Module, "efl_playable_get");

        private static bool playable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_playable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayable)ws.Target).GetPlayable();
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
                return efl_playable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_playable_get_delegate efl_playable_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_playable_seekable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_playable_seekable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_playable_seekable_get_api_delegate> efl_playable_seekable_get_ptr = new Efl.Eo.FunctionWrapper<efl_playable_seekable_get_api_delegate>(Module, "efl_playable_seekable_get");

        private static bool seekable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_playable_seekable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayable)ws.Target).GetSeekable();
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
                return efl_playable_seekable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_playable_seekable_get_delegate efl_playable_seekable_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

