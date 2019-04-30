#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Efl UI nstate class</summary>
[Efl.Ui.Nstate.NativeMethods]
public class Nstate : Efl.Ui.Button, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Nstate))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_nstate_class_get();
    /// <summary>Initializes a new instance of the <see cref="Nstate"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Nstate(Efl.Object parent
            , System.String style = null) : base(efl_ui_nstate_class_get(), typeof(Nstate), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Nstate"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Nstate(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="Nstate"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Nstate(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
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

    /// <summary>Called when the value changed.</summary>
    public event EventHandler ChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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

                string key = "_EFL_UI_NSTATE_EVENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_NSTATE_EVENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ChangedEvt.</summary>
    public void OnChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_NSTATE_EVENT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Maximum number of states</summary>
    /// <returns>The number of states.</returns>
    virtual public int GetCount() {
         var _ret_var = Efl.Ui.Nstate.NativeMethods.efl_ui_nstate_count_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Maximum number of states</summary>
    /// <param name="nstate">The number of states.</param>
    virtual public void SetCount(int nstate) {
                                 Efl.Ui.Nstate.NativeMethods.efl_ui_nstate_count_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),nstate);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the state value.</summary>
    /// <returns>The state.</returns>
    virtual public int GetValue() {
         var _ret_var = Efl.Ui.Nstate.NativeMethods.efl_ui_nstate_value_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the particular state given in (0...nstate}.</summary>
    /// <param name="state">The state.</param>
    virtual public void SetValue(int state) {
                                 Efl.Ui.Nstate.NativeMethods.efl_ui_nstate_value_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),state);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Activate widget</summary>
    virtual public void Activate() {
         Efl.Ui.Nstate.NativeMethods.efl_ui_nstate_activate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Maximum number of states</summary>
/// <value>The number of states.</value>
    public int Count {
        get { return GetCount(); }
        set { SetCount(value); }
    }
    /// <summary>Get the state value.</summary>
/// <value>The state.</value>
    public int Value {
        get { return GetValue(); }
        set { SetValue(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Nstate.efl_ui_nstate_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Button.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_nstate_count_get_static_delegate == null)
            {
                efl_ui_nstate_count_get_static_delegate = new efl_ui_nstate_count_get_delegate(count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_nstate_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_nstate_count_get_static_delegate) });
            }

            if (efl_ui_nstate_count_set_static_delegate == null)
            {
                efl_ui_nstate_count_set_static_delegate = new efl_ui_nstate_count_set_delegate(count_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_nstate_count_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_nstate_count_set_static_delegate) });
            }

            if (efl_ui_nstate_value_get_static_delegate == null)
            {
                efl_ui_nstate_value_get_static_delegate = new efl_ui_nstate_value_get_delegate(value_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_nstate_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_nstate_value_get_static_delegate) });
            }

            if (efl_ui_nstate_value_set_static_delegate == null)
            {
                efl_ui_nstate_value_set_static_delegate = new efl_ui_nstate_value_set_delegate(value_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_nstate_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_nstate_value_set_static_delegate) });
            }

            if (efl_ui_nstate_activate_static_delegate == null)
            {
                efl_ui_nstate_activate_static_delegate = new efl_ui_nstate_activate_delegate(activate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Activate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_nstate_activate"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_nstate_activate_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Nstate.efl_ui_nstate_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate int efl_ui_nstate_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_nstate_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_nstate_count_get_api_delegate> efl_ui_nstate_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_nstate_count_get_api_delegate>(Module, "efl_ui_nstate_count_get");

        private static int count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_nstate_count_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Nstate)wrapper).GetCount();
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
                return efl_ui_nstate_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_nstate_count_get_delegate efl_ui_nstate_count_get_static_delegate;

        
        private delegate void efl_ui_nstate_count_set_delegate(System.IntPtr obj, System.IntPtr pd,  int nstate);

        
        public delegate void efl_ui_nstate_count_set_api_delegate(System.IntPtr obj,  int nstate);

        public static Efl.Eo.FunctionWrapper<efl_ui_nstate_count_set_api_delegate> efl_ui_nstate_count_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_nstate_count_set_api_delegate>(Module, "efl_ui_nstate_count_set");

        private static void count_set(System.IntPtr obj, System.IntPtr pd, int nstate)
        {
            Eina.Log.Debug("function efl_ui_nstate_count_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Nstate)wrapper).SetCount(nstate);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_nstate_count_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), nstate);
            }
        }

        private static efl_ui_nstate_count_set_delegate efl_ui_nstate_count_set_static_delegate;

        
        private delegate int efl_ui_nstate_value_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_nstate_value_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_nstate_value_get_api_delegate> efl_ui_nstate_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_nstate_value_get_api_delegate>(Module, "efl_ui_nstate_value_get");

        private static int value_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_nstate_value_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Nstate)wrapper).GetValue();
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
                return efl_ui_nstate_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_nstate_value_get_delegate efl_ui_nstate_value_get_static_delegate;

        
        private delegate void efl_ui_nstate_value_set_delegate(System.IntPtr obj, System.IntPtr pd,  int state);

        
        public delegate void efl_ui_nstate_value_set_api_delegate(System.IntPtr obj,  int state);

        public static Efl.Eo.FunctionWrapper<efl_ui_nstate_value_set_api_delegate> efl_ui_nstate_value_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_nstate_value_set_api_delegate>(Module, "efl_ui_nstate_value_set");

        private static void value_set(System.IntPtr obj, System.IntPtr pd, int state)
        {
            Eina.Log.Debug("function efl_ui_nstate_value_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Nstate)wrapper).SetValue(state);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_nstate_value_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), state);
            }
        }

        private static efl_ui_nstate_value_set_delegate efl_ui_nstate_value_set_static_delegate;

        
        private delegate void efl_ui_nstate_activate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_nstate_activate_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_nstate_activate_api_delegate> efl_ui_nstate_activate_ptr = new Efl.Eo.FunctionWrapper<efl_ui_nstate_activate_api_delegate>(Module, "efl_ui_nstate_activate");

        private static void activate(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_nstate_activate was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((Nstate)wrapper).Activate();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_nstate_activate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_nstate_activate_delegate efl_ui_nstate_activate_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

