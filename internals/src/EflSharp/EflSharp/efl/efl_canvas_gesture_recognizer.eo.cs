#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>EFL Gesture Recognizer abstract class</summary>
[Efl.Canvas.GestureRecognizer.NativeMethods]
public abstract class GestureRecognizer : Efl.Object, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(GestureRecognizer))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_gesture_recognizer_class_get();
    /// <summary>Initializes a new instance of the <see cref="GestureRecognizer"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public GestureRecognizer(Efl.Object parent= null
            ) : base(efl_canvas_gesture_recognizer_class_get(), typeof(GestureRecognizer), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="GestureRecognizer"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected GestureRecognizer(System.IntPtr raw) : base(raw)
    {
            }

    [Efl.Eo.PrivateNativeClass]
    private class GestureRecognizerRealized : GestureRecognizer
    {
        private GestureRecognizerRealized(IntPtr ptr) : base(ptr)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="GestureRecognizer"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected GestureRecognizer(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
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
                                 var _ret_var = Efl.Canvas.GestureRecognizer.NativeMethods.efl_gesture_recognizer_config_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>This function is called to create a new Efl.Canvas.Gesture object for the given target</summary>
    /// <param name="target">The target widget</param>
    /// <returns>Returns the Efl.Canvas.Gesture event object</returns>
    virtual public Efl.Canvas.Gesture Create(Efl.Object target) {
                                 var _ret_var = Efl.Canvas.GestureRecognizer.NativeMethods.efl_gesture_recognizer_create_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),target);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Handles the given event for the watched object.
    /// Updates the state of the gesture object as required, and returns a suitable result for the current recognition step.</summary>
    /// <param name="gesture">The gesture object</param>
    /// <param name="watched">The watched object</param>
    /// <param name="kw_event">The pointer event</param>
    /// <returns>Returns the Efl.Canvas.Gesture event object</returns>
    virtual public Efl.Canvas.GestureRecognizerResult Recognize(Efl.Canvas.Gesture gesture, Efl.Object watched, Efl.Canvas.GestureTouch kw_event) {
                                                                                 var _ret_var = Efl.Canvas.GestureRecognizer.NativeMethods.efl_gesture_recognizer_recognize_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),gesture, watched, kw_event);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>This function is called by the framework to reset a given gesture.</summary>
    /// <param name="gesture">The gesture object</param>
    virtual public void Reset(Efl.Canvas.Gesture gesture) {
                                 Efl.Canvas.GestureRecognizer.NativeMethods.efl_gesture_recognizer_reset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),gesture);
        Eina.Error.RaiseIfUnhandledException();
                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.GestureRecognizer.efl_canvas_gesture_recognizer_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gesture_recognizer_config_get_static_delegate == null)
            {
                efl_gesture_recognizer_config_get_static_delegate = new efl_gesture_recognizer_config_get_delegate(config_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetConfig") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_recognizer_config_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_recognizer_config_get_static_delegate) });
            }

            if (efl_gesture_recognizer_create_static_delegate == null)
            {
                efl_gesture_recognizer_create_static_delegate = new efl_gesture_recognizer_create_delegate(create);
            }

            if (methods.FirstOrDefault(m => m.Name == "Create") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_recognizer_create"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_recognizer_create_static_delegate) });
            }

            if (efl_gesture_recognizer_recognize_static_delegate == null)
            {
                efl_gesture_recognizer_recognize_static_delegate = new efl_gesture_recognizer_recognize_delegate(recognize);
            }

            if (methods.FirstOrDefault(m => m.Name == "Recognize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_recognizer_recognize"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_recognizer_recognize_static_delegate) });
            }

            if (efl_gesture_recognizer_reset_static_delegate == null)
            {
                efl_gesture_recognizer_reset_static_delegate = new efl_gesture_recognizer_reset_delegate(reset);
            }

            if (methods.FirstOrDefault(m => m.Name == "Reset") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_recognizer_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_recognizer_reset_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.GestureRecognizer.efl_canvas_gesture_recognizer_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]
        private delegate Eina.Value efl_gesture_recognizer_config_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]
        public delegate Eina.Value efl_gesture_recognizer_config_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_gesture_recognizer_config_get_api_delegate> efl_gesture_recognizer_config_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_recognizer_config_get_api_delegate>(Module, "efl_gesture_recognizer_config_get");

        private static Eina.Value config_get(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_gesture_recognizer_config_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    Eina.Value _ret_var = default(Eina.Value);
                try
                {
                    _ret_var = ((GestureRecognizer)wrapper).GetConfig(name);
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
                return efl_gesture_recognizer_config_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_gesture_recognizer_config_get_delegate efl_gesture_recognizer_config_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Gesture efl_gesture_recognizer_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object target);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Gesture efl_gesture_recognizer_create_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object target);

        public static Efl.Eo.FunctionWrapper<efl_gesture_recognizer_create_api_delegate> efl_gesture_recognizer_create_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_recognizer_create_api_delegate>(Module, "efl_gesture_recognizer_create");

        private static Efl.Canvas.Gesture create(System.IntPtr obj, System.IntPtr pd, Efl.Object target)
        {
            Eina.Log.Debug("function efl_gesture_recognizer_create was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    Efl.Canvas.Gesture _ret_var = default(Efl.Canvas.Gesture);
                try
                {
                    _ret_var = ((GestureRecognizer)wrapper).Create(target);
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
                return efl_gesture_recognizer_create_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), target);
            }
        }

        private static efl_gesture_recognizer_create_delegate efl_gesture_recognizer_create_static_delegate;

        
        private delegate Efl.Canvas.GestureRecognizerResult efl_gesture_recognizer_recognize_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Gesture gesture, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object watched, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.GestureTouch kw_event);

        
        public delegate Efl.Canvas.GestureRecognizerResult efl_gesture_recognizer_recognize_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Gesture gesture, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object watched, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.GestureTouch kw_event);

        public static Efl.Eo.FunctionWrapper<efl_gesture_recognizer_recognize_api_delegate> efl_gesture_recognizer_recognize_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_recognizer_recognize_api_delegate>(Module, "efl_gesture_recognizer_recognize");

        private static Efl.Canvas.GestureRecognizerResult recognize(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Gesture gesture, Efl.Object watched, Efl.Canvas.GestureTouch kw_event)
        {
            Eina.Log.Debug("function efl_gesture_recognizer_recognize was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    Efl.Canvas.GestureRecognizerResult _ret_var = default(Efl.Canvas.GestureRecognizerResult);
                try
                {
                    _ret_var = ((GestureRecognizer)wrapper).Recognize(gesture, watched, kw_event);
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
                return efl_gesture_recognizer_recognize_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), gesture, watched, kw_event);
            }
        }

        private static efl_gesture_recognizer_recognize_delegate efl_gesture_recognizer_recognize_static_delegate;

        
        private delegate void efl_gesture_recognizer_reset_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Gesture gesture);

        
        public delegate void efl_gesture_recognizer_reset_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Gesture gesture);

        public static Efl.Eo.FunctionWrapper<efl_gesture_recognizer_reset_api_delegate> efl_gesture_recognizer_reset_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_recognizer_reset_api_delegate>(Module, "efl_gesture_recognizer_reset");

        private static void reset(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Gesture gesture)
        {
            Eina.Log.Debug("function efl_gesture_recognizer_reset was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((GestureRecognizer)wrapper).Reset(gesture);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gesture_recognizer_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), gesture);
            }
        }

        private static efl_gesture_recognizer_reset_delegate efl_gesture_recognizer_reset_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

