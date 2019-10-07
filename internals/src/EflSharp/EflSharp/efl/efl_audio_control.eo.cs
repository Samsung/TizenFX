#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Player interface for audio related properties</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.AudioControlConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IAudioControl : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <returns>The volume level</returns>
    double GetVolume();

    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <param name="volume">The volume level</param>
    void SetVolume(double volume);

    /// <summary>This property controls the audio mute state.</summary>
    /// <returns>The mute state. <c>true</c> or <c>false</c>.</returns>
    bool GetMute();

    /// <summary>This property controls the audio mute state.</summary>
    /// <param name="mute">The mute state. <c>true</c> or <c>false</c>.</param>
    void SetMute(bool mute);

    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <value>The volume level</value>
    double Volume {
        get;
        set;
    }

    /// <summary>This property controls the audio mute state.</summary>
    /// <value>The mute state. <c>true</c> or <c>false</c>.</value>
    bool Mute {
        get;
        set;
    }

}

/// <summary>Player interface for audio related properties</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class AudioControlConcrete :
    Efl.Eo.EoWrapper
    , IAudioControl
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(AudioControlConcrete))
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
    private AudioControlConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_audio_control_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IAudioControl"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private AudioControlConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <returns>The volume level</returns>
    public double GetVolume() {
        var _ret_var = Efl.AudioControlConcrete.NativeMethods.efl_audio_control_volume_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <param name="volume">The volume level</param>
    public void SetVolume(double volume) {
        Efl.AudioControlConcrete.NativeMethods.efl_audio_control_volume_set_ptr.Value.Delegate(this.NativeHandle,volume);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This property controls the audio mute state.</summary>
    /// <returns>The mute state. <c>true</c> or <c>false</c>.</returns>
    public bool GetMute() {
        var _ret_var = Efl.AudioControlConcrete.NativeMethods.efl_audio_control_mute_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>This property controls the audio mute state.</summary>
    /// <param name="mute">The mute state. <c>true</c> or <c>false</c>.</param>
    public void SetMute(bool mute) {
        Efl.AudioControlConcrete.NativeMethods.efl_audio_control_mute_set_ptr.Value.Delegate(this.NativeHandle,mute);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <value>The volume level</value>
    public double Volume {
        get { return GetVolume(); }
        set { SetVolume(value); }
    }

    /// <summary>This property controls the audio mute state.</summary>
    /// <value>The mute state. <c>true</c> or <c>false</c>.</value>
    public bool Mute {
        get { return GetMute(); }
        set { SetMute(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.AudioControlConcrete.efl_audio_control_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Efl);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_audio_control_volume_get_static_delegate == null)
            {
                efl_audio_control_volume_get_static_delegate = new efl_audio_control_volume_get_delegate(volume_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetVolume") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_audio_control_volume_get"), func = Marshal.GetFunctionPointerForDelegate(efl_audio_control_volume_get_static_delegate) });
            }

            if (efl_audio_control_volume_set_static_delegate == null)
            {
                efl_audio_control_volume_set_static_delegate = new efl_audio_control_volume_set_delegate(volume_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetVolume") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_audio_control_volume_set"), func = Marshal.GetFunctionPointerForDelegate(efl_audio_control_volume_set_static_delegate) });
            }

            if (efl_audio_control_mute_get_static_delegate == null)
            {
                efl_audio_control_mute_get_static_delegate = new efl_audio_control_mute_get_delegate(mute_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_audio_control_mute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_audio_control_mute_get_static_delegate) });
            }

            if (efl_audio_control_mute_set_static_delegate == null)
            {
                efl_audio_control_mute_set_static_delegate = new efl_audio_control_mute_set_delegate(mute_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_audio_control_mute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_audio_control_mute_set_static_delegate) });
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
            return Efl.AudioControlConcrete.efl_audio_control_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_audio_control_volume_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_audio_control_volume_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_audio_control_volume_get_api_delegate> efl_audio_control_volume_get_ptr = new Efl.Eo.FunctionWrapper<efl_audio_control_volume_get_api_delegate>(Module, "efl_audio_control_volume_get");

        private static double volume_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_audio_control_volume_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IAudioControl)ws.Target).GetVolume();
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
                return efl_audio_control_volume_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_audio_control_volume_get_delegate efl_audio_control_volume_get_static_delegate;

        
        private delegate void efl_audio_control_volume_set_delegate(System.IntPtr obj, System.IntPtr pd,  double volume);

        
        public delegate void efl_audio_control_volume_set_api_delegate(System.IntPtr obj,  double volume);

        public static Efl.Eo.FunctionWrapper<efl_audio_control_volume_set_api_delegate> efl_audio_control_volume_set_ptr = new Efl.Eo.FunctionWrapper<efl_audio_control_volume_set_api_delegate>(Module, "efl_audio_control_volume_set");

        private static void volume_set(System.IntPtr obj, System.IntPtr pd, double volume)
        {
            Eina.Log.Debug("function efl_audio_control_volume_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IAudioControl)ws.Target).SetVolume(volume);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_audio_control_volume_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), volume);
            }
        }

        private static efl_audio_control_volume_set_delegate efl_audio_control_volume_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_audio_control_mute_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_audio_control_mute_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_audio_control_mute_get_api_delegate> efl_audio_control_mute_get_ptr = new Efl.Eo.FunctionWrapper<efl_audio_control_mute_get_api_delegate>(Module, "efl_audio_control_mute_get");

        private static bool mute_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_audio_control_mute_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IAudioControl)ws.Target).GetMute();
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
                return efl_audio_control_mute_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_audio_control_mute_get_delegate efl_audio_control_mute_get_static_delegate;

        
        private delegate void efl_audio_control_mute_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool mute);

        
        public delegate void efl_audio_control_mute_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool mute);

        public static Efl.Eo.FunctionWrapper<efl_audio_control_mute_set_api_delegate> efl_audio_control_mute_set_ptr = new Efl.Eo.FunctionWrapper<efl_audio_control_mute_set_api_delegate>(Module, "efl_audio_control_mute_set");

        private static void mute_set(System.IntPtr obj, System.IntPtr pd, bool mute)
        {
            Eina.Log.Debug("function efl_audio_control_mute_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IAudioControl)ws.Target).SetMute(mute);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_audio_control_mute_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mute);
            }
        }

        private static efl_audio_control_mute_set_delegate efl_audio_control_mute_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflAudioControlConcrete_ExtensionMethods {
    public static Efl.BindableProperty<double> Volume<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.IAudioControl, T>magic = null) where T : Efl.IAudioControl {
        return new Efl.BindableProperty<double>("volume", fac);
    }

    public static Efl.BindableProperty<bool> Mute<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.IAudioControl, T>magic = null) where T : Efl.IAudioControl {
        return new Efl.BindableProperty<bool>("mute", fac);
    }

}
#pragma warning restore CS1591
#endif
