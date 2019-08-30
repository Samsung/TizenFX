#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>EFL Gesture Manager class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.GestureManager.NativeMethods]
[Efl.Eo.BindingEntity]
public class GestureManager : Efl.Object
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(GestureManager))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_gesture_manager_class_get();
    /// <summary>Initializes a new instance of the <see cref="GestureManager"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public GestureManager(Efl.Object parent= null
            ) : base(efl_canvas_gesture_manager_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected GestureManager(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="GestureManager"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected GestureManager(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="GestureManager"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected GestureManager(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>This property holds the config value for the recognizer</summary>
    /// <param name="name">propery name</param>
    /// <returns>value of the property</returns>
    virtual public Eina.Value GetConfig(System.String name) {
                                 var _ret_var = Efl.Canvas.GestureManager.NativeMethods.efl_gesture_manager_config_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>This property holds the config value for the recognizer</summary>
    /// <param name="name">propery name</param>
    /// <param name="value">value of the property</param>
    virtual public void SetConfig(System.String name, Eina.Value value) {
                                                         Efl.Canvas.GestureManager.NativeMethods.efl_gesture_manager_config_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, value);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This function is called to register a new Efl.Canvas.Gesture_Recognizer</summary>
    /// <param name="recognizer">The gesture recognizer object</param>
    virtual public void RecognizerRegister(Efl.Canvas.GestureRecognizer recognizer) {
                                 Efl.Canvas.GestureManager.NativeMethods.efl_gesture_manager_recognizer_register_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),recognizer);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This function is called to unregister a Efl.Canvas.Gesture_Recognizer</summary>
    /// <param name="recognizer">The gesture recognizer object</param>
    virtual public void RecognizerUnregister(Efl.Canvas.GestureRecognizer recognizer) {
                                 Efl.Canvas.GestureManager.NativeMethods.efl_gesture_manager_recognizer_unregister_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),recognizer);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets event type&apos;s recognizer</summary>
    /// <param name="gesture_type">The gesture type</param>
    /// <returns>The gesture recognizer</returns>
    virtual public Efl.Canvas.GestureRecognizer GetRecognizer(Efl.Canvas.GestureRecognizerType gesture_type) {
                                 var _ret_var = Efl.Canvas.GestureManager.NativeMethods.efl_gesture_manager_recognizer_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),gesture_type);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.GestureManager.efl_canvas_gesture_manager_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gesture_manager_config_get_static_delegate == null)
            {
                efl_gesture_manager_config_get_static_delegate = new efl_gesture_manager_config_get_delegate(config_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetConfig") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_manager_config_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_manager_config_get_static_delegate) });
            }

            if (efl_gesture_manager_config_set_static_delegate == null)
            {
                efl_gesture_manager_config_set_static_delegate = new efl_gesture_manager_config_set_delegate(config_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetConfig") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_manager_config_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_manager_config_set_static_delegate) });
            }

            if (efl_gesture_manager_recognizer_register_static_delegate == null)
            {
                efl_gesture_manager_recognizer_register_static_delegate = new efl_gesture_manager_recognizer_register_delegate(recognizer_register);
            }

            if (methods.FirstOrDefault(m => m.Name == "RecognizerRegister") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_manager_recognizer_register"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_manager_recognizer_register_static_delegate) });
            }

            if (efl_gesture_manager_recognizer_unregister_static_delegate == null)
            {
                efl_gesture_manager_recognizer_unregister_static_delegate = new efl_gesture_manager_recognizer_unregister_delegate(recognizer_unregister);
            }

            if (methods.FirstOrDefault(m => m.Name == "RecognizerUnregister") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_manager_recognizer_unregister"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_manager_recognizer_unregister_static_delegate) });
            }

            if (efl_gesture_manager_recognizer_get_static_delegate == null)
            {
                efl_gesture_manager_recognizer_get_static_delegate = new efl_gesture_manager_recognizer_get_delegate(recognizer_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRecognizer") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_manager_recognizer_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_manager_recognizer_get_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.GestureManager.efl_canvas_gesture_manager_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]
        private delegate Eina.Value efl_gesture_manager_config_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]
        public delegate Eina.Value efl_gesture_manager_config_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_gesture_manager_config_get_api_delegate> efl_gesture_manager_config_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_manager_config_get_api_delegate>(Module, "efl_gesture_manager_config_get");

        private static Eina.Value config_get(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_gesture_manager_config_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Value _ret_var = default(Eina.Value);
                try
                {
                    _ret_var = ((GestureManager)ws.Target).GetConfig(name);
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
                return efl_gesture_manager_config_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_gesture_manager_config_get_delegate efl_gesture_manager_config_get_static_delegate;

        
        private delegate void efl_gesture_manager_config_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))] Eina.Value value);

        
        public delegate void efl_gesture_manager_config_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))] Eina.Value value);

        public static Efl.Eo.FunctionWrapper<efl_gesture_manager_config_set_api_delegate> efl_gesture_manager_config_set_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_manager_config_set_api_delegate>(Module, "efl_gesture_manager_config_set");

        private static void config_set(System.IntPtr obj, System.IntPtr pd, System.String name, Eina.Value value)
        {
            Eina.Log.Debug("function efl_gesture_manager_config_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((GestureManager)ws.Target).SetConfig(name, value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gesture_manager_config_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, value);
            }
        }

        private static efl_gesture_manager_config_set_delegate efl_gesture_manager_config_set_static_delegate;

        
        private delegate void efl_gesture_manager_recognizer_register_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.GestureRecognizer recognizer);

        
        public delegate void efl_gesture_manager_recognizer_register_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.GestureRecognizer recognizer);

        public static Efl.Eo.FunctionWrapper<efl_gesture_manager_recognizer_register_api_delegate> efl_gesture_manager_recognizer_register_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_manager_recognizer_register_api_delegate>(Module, "efl_gesture_manager_recognizer_register");

        private static void recognizer_register(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.GestureRecognizer recognizer)
        {
            Eina.Log.Debug("function efl_gesture_manager_recognizer_register was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((GestureManager)ws.Target).RecognizerRegister(recognizer);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gesture_manager_recognizer_register_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), recognizer);
            }
        }

        private static efl_gesture_manager_recognizer_register_delegate efl_gesture_manager_recognizer_register_static_delegate;

        
        private delegate void efl_gesture_manager_recognizer_unregister_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.GestureRecognizer recognizer);

        
        public delegate void efl_gesture_manager_recognizer_unregister_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.GestureRecognizer recognizer);

        public static Efl.Eo.FunctionWrapper<efl_gesture_manager_recognizer_unregister_api_delegate> efl_gesture_manager_recognizer_unregister_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_manager_recognizer_unregister_api_delegate>(Module, "efl_gesture_manager_recognizer_unregister");

        private static void recognizer_unregister(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.GestureRecognizer recognizer)
        {
            Eina.Log.Debug("function efl_gesture_manager_recognizer_unregister was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((GestureManager)ws.Target).RecognizerUnregister(recognizer);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gesture_manager_recognizer_unregister_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), recognizer);
            }
        }

        private static efl_gesture_manager_recognizer_unregister_delegate efl_gesture_manager_recognizer_unregister_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.GestureRecognizer efl_gesture_manager_recognizer_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.GestureRecognizerType gesture_type);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.GestureRecognizer efl_gesture_manager_recognizer_get_api_delegate(System.IntPtr obj,  Efl.Canvas.GestureRecognizerType gesture_type);

        public static Efl.Eo.FunctionWrapper<efl_gesture_manager_recognizer_get_api_delegate> efl_gesture_manager_recognizer_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_manager_recognizer_get_api_delegate>(Module, "efl_gesture_manager_recognizer_get");

        private static Efl.Canvas.GestureRecognizer recognizer_get(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.GestureRecognizerType gesture_type)
        {
            Eina.Log.Debug("function efl_gesture_manager_recognizer_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Canvas.GestureRecognizer _ret_var = default(Efl.Canvas.GestureRecognizer);
                try
                {
                    _ret_var = ((GestureManager)ws.Target).GetRecognizer(gesture_type);
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
                return efl_gesture_manager_recognizer_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), gesture_type);
            }
        }

        private static efl_gesture_manager_recognizer_get_delegate efl_gesture_manager_recognizer_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_CanvasGestureManager_ExtensionMethods {
    
}
#pragma warning restore CS1591
#endif
