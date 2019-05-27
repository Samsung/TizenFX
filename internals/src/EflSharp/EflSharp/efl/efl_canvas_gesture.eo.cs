#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>EFL Gesture abstract class</summary>
[Efl.Canvas.Gesture.NativeMethods]
public abstract class Gesture : Efl.Object, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Gesture))
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
        efl_canvas_gesture_class_get();
    /// <summary>Initializes a new instance of the <see cref="Gesture"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Gesture(Efl.Object parent= null
            ) : base(efl_canvas_gesture_class_get(), typeof(Gesture), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Gesture"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Gesture(System.IntPtr raw) : base(raw)
    {
            }

    [Efl.Eo.PrivateNativeClass]
    private class GestureRealized : Gesture
    {
        private GestureRealized(IntPtr ptr) : base(ptr)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Gesture"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Gesture(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
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

    /// <summary>This property holds the type of the gesture.</summary>
    /// <returns>gesture type</returns>
    virtual public Efl.EventDescription GetGestureType() {
         var _ret_var = Efl.Canvas.Gesture.NativeMethods.efl_gesture_type_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.EventDescription>(_ret_var);
        
        return __ret_tmp;
 }
    /// <summary>This property holds the current state of the gesture.</summary>
    /// <returns>gesture state</returns>
    virtual public Efl.Canvas.GestureState GetState() {
         var _ret_var = Efl.Canvas.Gesture.NativeMethods.efl_gesture_state_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This property holds the current state of the gesture.</summary>
    /// <param name="state">gesture state</param>
    virtual public void SetState(Efl.Canvas.GestureState state) {
                                 Efl.Canvas.Gesture.NativeMethods.efl_gesture_state_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),state);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This property holds the hotspot of the current gesture.</summary>
    /// <returns>hotspot co-ordinate</returns>
    virtual public Eina.Vector2 GetHotspot() {
         var _ret_var = Efl.Canvas.Gesture.NativeMethods.efl_gesture_hotspot_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This property holds the hotspot of the current gesture.</summary>
    /// <param name="hotspot">hotspot co-ordinate</param>
    virtual public void SetHotspot(Eina.Vector2 hotspot) {
         Eina.Vector2.NativeStruct _in_hotspot = hotspot;
                        Efl.Canvas.Gesture.NativeMethods.efl_gesture_hotspot_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_hotspot);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This property holds the type of the gesture.</summary>
/// <value>gesture type</value>
    public Efl.EventDescription GestureType {
        get { return GetGestureType(); }
    }
    /// <summary>This property holds the current state of the gesture.</summary>
/// <value>gesture state</value>
    public Efl.Canvas.GestureState State {
        get { return GetState(); }
        set { SetState(value); }
    }
    /// <summary>This property holds the hotspot of the current gesture.</summary>
/// <value>hotspot co-ordinate</value>
    public Eina.Vector2 Hotspot {
        get { return GetHotspot(); }
        set { SetHotspot(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Gesture.efl_canvas_gesture_class_get();
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

            if (efl_gesture_type_get_static_delegate == null)
            {
                efl_gesture_type_get_static_delegate = new efl_gesture_type_get_delegate(type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGestureType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_type_get_static_delegate) });
            }

            if (efl_gesture_state_get_static_delegate == null)
            {
                efl_gesture_state_get_static_delegate = new efl_gesture_state_get_delegate(state_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_state_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_state_get_static_delegate) });
            }

            if (efl_gesture_state_set_static_delegate == null)
            {
                efl_gesture_state_set_static_delegate = new efl_gesture_state_set_delegate(state_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_state_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_state_set_static_delegate) });
            }

            if (efl_gesture_hotspot_get_static_delegate == null)
            {
                efl_gesture_hotspot_get_static_delegate = new efl_gesture_hotspot_get_delegate(hotspot_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHotspot") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_hotspot_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_hotspot_get_static_delegate) });
            }

            if (efl_gesture_hotspot_set_static_delegate == null)
            {
                efl_gesture_hotspot_set_static_delegate = new efl_gesture_hotspot_set_delegate(hotspot_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHotspot") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_hotspot_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_hotspot_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Gesture.efl_canvas_gesture_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate System.IntPtr efl_gesture_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_gesture_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gesture_type_get_api_delegate> efl_gesture_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_type_get_api_delegate>(Module, "efl_gesture_type_get");

        private static System.IntPtr type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gesture_type_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.EventDescription _ret_var = default(Efl.EventDescription);
                try
                {
                    _ret_var = ((Gesture)wrapper).GetGestureType();
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
                return efl_gesture_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gesture_type_get_delegate efl_gesture_type_get_static_delegate;

        
        private delegate Efl.Canvas.GestureState efl_gesture_state_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Canvas.GestureState efl_gesture_state_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gesture_state_get_api_delegate> efl_gesture_state_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_state_get_api_delegate>(Module, "efl_gesture_state_get");

        private static Efl.Canvas.GestureState state_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gesture_state_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.Canvas.GestureState _ret_var = default(Efl.Canvas.GestureState);
                try
                {
                    _ret_var = ((Gesture)wrapper).GetState();
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
                return efl_gesture_state_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gesture_state_get_delegate efl_gesture_state_get_static_delegate;

        
        private delegate void efl_gesture_state_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.GestureState state);

        
        public delegate void efl_gesture_state_set_api_delegate(System.IntPtr obj,  Efl.Canvas.GestureState state);

        public static Efl.Eo.FunctionWrapper<efl_gesture_state_set_api_delegate> efl_gesture_state_set_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_state_set_api_delegate>(Module, "efl_gesture_state_set");

        private static void state_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.GestureState state)
        {
            Eina.Log.Debug("function efl_gesture_state_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Gesture)wrapper).SetState(state);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gesture_state_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), state);
            }
        }

        private static efl_gesture_state_set_delegate efl_gesture_state_set_static_delegate;

        
        private delegate Eina.Vector2.NativeStruct efl_gesture_hotspot_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Vector2.NativeStruct efl_gesture_hotspot_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gesture_hotspot_get_api_delegate> efl_gesture_hotspot_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_hotspot_get_api_delegate>(Module, "efl_gesture_hotspot_get");

        private static Eina.Vector2.NativeStruct hotspot_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gesture_hotspot_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Eina.Vector2 _ret_var = default(Eina.Vector2);
                try
                {
                    _ret_var = ((Gesture)wrapper).GetHotspot();
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
                return efl_gesture_hotspot_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gesture_hotspot_get_delegate efl_gesture_hotspot_get_static_delegate;

        
        private delegate void efl_gesture_hotspot_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Vector2.NativeStruct hotspot);

        
        public delegate void efl_gesture_hotspot_set_api_delegate(System.IntPtr obj,  Eina.Vector2.NativeStruct hotspot);

        public static Efl.Eo.FunctionWrapper<efl_gesture_hotspot_set_api_delegate> efl_gesture_hotspot_set_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_hotspot_set_api_delegate>(Module, "efl_gesture_hotspot_set");

        private static void hotspot_set(System.IntPtr obj, System.IntPtr pd, Eina.Vector2.NativeStruct hotspot)
        {
            Eina.Log.Debug("function efl_gesture_hotspot_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
        Eina.Vector2 _in_hotspot = hotspot;
                            
                try
                {
                    ((Gesture)wrapper).SetHotspot(_in_hotspot);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gesture_hotspot_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), hotspot);
            }
        }

        private static efl_gesture_hotspot_set_delegate efl_gesture_hotspot_set_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

