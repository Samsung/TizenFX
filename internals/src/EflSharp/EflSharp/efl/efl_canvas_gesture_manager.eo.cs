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
[Efl.Canvas.GestureManager.NativeMethods]
public class GestureManager : Efl.Object, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
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
            ) : base(efl_canvas_gesture_manager_class_get(), typeof(GestureManager), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="GestureManager"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected GestureManager(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="GestureManager"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected GestureManager(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    /// <summary>This property holds the config value for the recognizer</summary>
    /// <param name="name">propery name</param>
    /// <returns>value of the property</returns>
    virtual public Eina.Value GetConfig(System.String name) {
                                 var _ret_var = Efl.Canvas.GestureManager.NativeMethods.efl_gesture_manager_config_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>This property holds the config value for the recognizer</summary>
    /// <param name="name">propery name</param>
    /// <param name="value">value of the property</param>
    virtual public void SetConfig(System.String name, Eina.Value value) {
                                                         Efl.Canvas.GestureManager.NativeMethods.efl_gesture_manager_config_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),name, value);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This function is called to register a new Efl.Canvas.Gesture_Recognizer</summary>
    /// <param name="recognizer">The gesture recognizer object</param>
    /// <returns>Returns the Efl.Event_Description type the recognizer supports</returns>
    virtual public Efl.EventDescription RecognizerRegister(Efl.Canvas.GestureRecognizer recognizer) {
                                 var _ret_var = Efl.Canvas.GestureManager.NativeMethods.efl_gesture_manager_recognizer_register_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),recognizer);
        Eina.Error.RaiseIfUnhandledException();
                        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.EventDescription>(_ret_var);
        
        return __ret_tmp;
 }
    /// <summary>This function is called to unregister a Efl.Canvas.Gesture_Recognizer</summary>
    /// <param name="recognizer">The gesture recognizer object</param>
    virtual public void RecognizerUnregister(Efl.Canvas.GestureRecognizer recognizer) {
                                 Efl.Canvas.GestureManager.NativeMethods.efl_gesture_manager_recognizer_unregister_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),recognizer);
        Eina.Error.RaiseIfUnhandledException();
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

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.GestureManager.efl_canvas_gesture_manager_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]
        private delegate Eina.Value efl_gesture_manager_config_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]
        public delegate Eina.Value efl_gesture_manager_config_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_gesture_manager_config_get_api_delegate> efl_gesture_manager_config_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_manager_config_get_api_delegate>(Module, "efl_gesture_manager_config_get");

        private static Eina.Value config_get(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_gesture_manager_config_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    Eina.Value _ret_var = default(Eina.Value);
                try
                {
                    _ret_var = ((GestureManager)wrapper).GetConfig(name);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((GestureManager)wrapper).SetConfig(name, value);
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

        
        private delegate System.IntPtr efl_gesture_manager_recognizer_register_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.GestureRecognizer recognizer);

        
        public delegate System.IntPtr efl_gesture_manager_recognizer_register_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.GestureRecognizer recognizer);

        public static Efl.Eo.FunctionWrapper<efl_gesture_manager_recognizer_register_api_delegate> efl_gesture_manager_recognizer_register_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_manager_recognizer_register_api_delegate>(Module, "efl_gesture_manager_recognizer_register");

        private static System.IntPtr recognizer_register(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.GestureRecognizer recognizer)
        {
            Eina.Log.Debug("function efl_gesture_manager_recognizer_register was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    Efl.EventDescription _ret_var = default(Efl.EventDescription);
                try
                {
                    _ret_var = ((GestureManager)wrapper).RecognizerRegister(recognizer);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        return Eina.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);

            }
            else
            {
                return efl_gesture_manager_recognizer_register_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), recognizer);
            }
        }

        private static efl_gesture_manager_recognizer_register_delegate efl_gesture_manager_recognizer_register_static_delegate;

        
        private delegate void efl_gesture_manager_recognizer_unregister_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.GestureRecognizer recognizer);

        
        public delegate void efl_gesture_manager_recognizer_unregister_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.GestureRecognizer recognizer);

        public static Efl.Eo.FunctionWrapper<efl_gesture_manager_recognizer_unregister_api_delegate> efl_gesture_manager_recognizer_unregister_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_manager_recognizer_unregister_api_delegate>(Module, "efl_gesture_manager_recognizer_unregister");

        private static void recognizer_unregister(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.GestureRecognizer recognizer)
        {
            Eina.Log.Debug("function efl_gesture_manager_recognizer_unregister was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((GestureManager)wrapper).RecognizerUnregister(recognizer);
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

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

