#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl control interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.ControlConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IControl : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Control the priority of the object.</summary>
/// <returns>The priority of the object</returns>
int GetPriority();
    /// <summary>Control the priority of the object.</summary>
/// <param name="priority">The priority of the object</param>
void SetPriority(int priority);
    /// <summary>Controls whether the object is suspended or not.</summary>
/// <returns>Controls whether the object is suspended or not.</returns>
bool GetSuspend();
    /// <summary>Controls whether the object is suspended or not.</summary>
/// <param name="suspend">Controls whether the object is suspended or not.</param>
void SetSuspend(bool suspend);
                    /// <summary>Control the priority of the object.</summary>
    /// <value>The priority of the object</value>
    int Priority {
        get;
        set;
    }
    /// <summary>Controls whether the object is suspended or not.</summary>
    /// <value>Controls whether the object is suspended or not.</value>
    bool Suspend {
        get;
        set;
    }
}
/// <summary>Efl control interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class ControlConcrete :
    Efl.Eo.EoWrapper
    , IControl
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ControlConcrete))
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
    private ControlConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_control_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IControl"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ControlConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Control the priority of the object.</summary>
    /// <returns>The priority of the object</returns>
    public int GetPriority() {
         var _ret_var = Efl.ControlConcrete.NativeMethods.efl_control_priority_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the priority of the object.</summary>
    /// <param name="priority">The priority of the object</param>
    public void SetPriority(int priority) {
                                 Efl.ControlConcrete.NativeMethods.efl_control_priority_set_ptr.Value.Delegate(this.NativeHandle,priority);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Controls whether the object is suspended or not.</summary>
    /// <returns>Controls whether the object is suspended or not.</returns>
    public bool GetSuspend() {
         var _ret_var = Efl.ControlConcrete.NativeMethods.efl_control_suspend_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Controls whether the object is suspended or not.</summary>
    /// <param name="suspend">Controls whether the object is suspended or not.</param>
    public void SetSuspend(bool suspend) {
                                 Efl.ControlConcrete.NativeMethods.efl_control_suspend_set_ptr.Value.Delegate(this.NativeHandle,suspend);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the priority of the object.</summary>
    /// <value>The priority of the object</value>
    public int Priority {
        get { return GetPriority(); }
        set { SetPriority(value); }
    }
    /// <summary>Controls whether the object is suspended or not.</summary>
    /// <value>Controls whether the object is suspended or not.</value>
    public bool Suspend {
        get { return GetSuspend(); }
        set { SetSuspend(value); }
    }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.ControlConcrete.efl_control_interface_get();
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

            if (efl_control_priority_get_static_delegate == null)
            {
                efl_control_priority_get_static_delegate = new efl_control_priority_get_delegate(priority_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPriority") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_control_priority_get"), func = Marshal.GetFunctionPointerForDelegate(efl_control_priority_get_static_delegate) });
            }

            if (efl_control_priority_set_static_delegate == null)
            {
                efl_control_priority_set_static_delegate = new efl_control_priority_set_delegate(priority_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPriority") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_control_priority_set"), func = Marshal.GetFunctionPointerForDelegate(efl_control_priority_set_static_delegate) });
            }

            if (efl_control_suspend_get_static_delegate == null)
            {
                efl_control_suspend_get_static_delegate = new efl_control_suspend_get_delegate(suspend_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSuspend") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_control_suspend_get"), func = Marshal.GetFunctionPointerForDelegate(efl_control_suspend_get_static_delegate) });
            }

            if (efl_control_suspend_set_static_delegate == null)
            {
                efl_control_suspend_set_static_delegate = new efl_control_suspend_set_delegate(suspend_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSuspend") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_control_suspend_set"), func = Marshal.GetFunctionPointerForDelegate(efl_control_suspend_set_static_delegate) });
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
            return Efl.ControlConcrete.efl_control_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate int efl_control_priority_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_control_priority_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_control_priority_get_api_delegate> efl_control_priority_get_ptr = new Efl.Eo.FunctionWrapper<efl_control_priority_get_api_delegate>(Module, "efl_control_priority_get");

        private static int priority_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_control_priority_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IControl)ws.Target).GetPriority();
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
                return efl_control_priority_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_control_priority_get_delegate efl_control_priority_get_static_delegate;

        
        private delegate void efl_control_priority_set_delegate(System.IntPtr obj, System.IntPtr pd,  int priority);

        
        public delegate void efl_control_priority_set_api_delegate(System.IntPtr obj,  int priority);

        public static Efl.Eo.FunctionWrapper<efl_control_priority_set_api_delegate> efl_control_priority_set_ptr = new Efl.Eo.FunctionWrapper<efl_control_priority_set_api_delegate>(Module, "efl_control_priority_set");

        private static void priority_set(System.IntPtr obj, System.IntPtr pd, int priority)
        {
            Eina.Log.Debug("function efl_control_priority_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IControl)ws.Target).SetPriority(priority);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_control_priority_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), priority);
            }
        }

        private static efl_control_priority_set_delegate efl_control_priority_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_control_suspend_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_control_suspend_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_control_suspend_get_api_delegate> efl_control_suspend_get_ptr = new Efl.Eo.FunctionWrapper<efl_control_suspend_get_api_delegate>(Module, "efl_control_suspend_get");

        private static bool suspend_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_control_suspend_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IControl)ws.Target).GetSuspend();
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
                return efl_control_suspend_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_control_suspend_get_delegate efl_control_suspend_get_static_delegate;

        
        private delegate void efl_control_suspend_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool suspend);

        
        public delegate void efl_control_suspend_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool suspend);

        public static Efl.Eo.FunctionWrapper<efl_control_suspend_set_api_delegate> efl_control_suspend_set_ptr = new Efl.Eo.FunctionWrapper<efl_control_suspend_set_api_delegate>(Module, "efl_control_suspend_set");

        private static void suspend_set(System.IntPtr obj, System.IntPtr pd, bool suspend)
        {
            Eina.Log.Debug("function efl_control_suspend_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IControl)ws.Target).SetSuspend(suspend);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_control_suspend_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), suspend);
            }
        }

        private static efl_control_suspend_set_delegate efl_control_suspend_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflControlConcrete_ExtensionMethods {
    public static Efl.BindableProperty<int> Priority<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.IControl, T>magic = null) where T : Efl.IControl {
        return new Efl.BindableProperty<int>("priority", fac);
    }

    public static Efl.BindableProperty<bool> Suspend<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.IControl, T>magic = null) where T : Efl.IControl {
        return new Efl.BindableProperty<bool>("suspend", fac);
    }

}
#pragma warning restore CS1591
#endif
