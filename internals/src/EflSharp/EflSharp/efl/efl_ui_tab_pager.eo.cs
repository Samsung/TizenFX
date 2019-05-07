#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Tab Pager class</summary>
[Efl.Ui.TabPager.NativeMethods]
public class TabPager : Efl.Ui.Pager, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(TabPager))
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
        efl_ui_tab_pager_class_get();
    /// <summary>Initializes a new instance of the <see cref="TabPager"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public TabPager(Efl.Object parent
            , System.String style = null) : base(efl_ui_tab_pager_class_get(), typeof(TabPager), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="TabPager"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected TabPager(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="TabPager"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected TabPager(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
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

    virtual public Efl.Canvas.Object GetTabBar() {
         var _ret_var = Efl.Ui.TabPager.NativeMethods.efl_ui_tab_pager_tab_bar_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    virtual public void SetTabBar(Efl.Canvas.Object tab_bar) {
                                 Efl.Ui.TabPager.NativeMethods.efl_ui_tab_pager_tab_bar_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),tab_bar);
        Eina.Error.RaiseIfUnhandledException();
                         }
        public Efl.Canvas.Object TabBar {
        get { return GetTabBar(); }
        set { SetTabBar(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.TabPager.efl_ui_tab_pager_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Pager.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_tab_pager_tab_bar_get_static_delegate == null)
            {
                efl_ui_tab_pager_tab_bar_get_static_delegate = new efl_ui_tab_pager_tab_bar_get_delegate(tab_bar_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTabBar") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_pager_tab_bar_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_pager_tab_bar_get_static_delegate) });
            }

            if (efl_ui_tab_pager_tab_bar_set_static_delegate == null)
            {
                efl_ui_tab_pager_tab_bar_set_static_delegate = new efl_ui_tab_pager_tab_bar_set_delegate(tab_bar_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTabBar") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_pager_tab_bar_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_pager_tab_bar_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.TabPager.efl_ui_tab_pager_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_ui_tab_pager_tab_bar_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_ui_tab_pager_tab_bar_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_pager_tab_bar_get_api_delegate> efl_ui_tab_pager_tab_bar_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_pager_tab_bar_get_api_delegate>(Module, "efl_ui_tab_pager_tab_bar_get");

        private static Efl.Canvas.Object tab_bar_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_tab_pager_tab_bar_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((TabPager)wrapper).GetTabBar();
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
                return efl_ui_tab_pager_tab_bar_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_tab_pager_tab_bar_get_delegate efl_ui_tab_pager_tab_bar_get_static_delegate;

        
        private delegate void efl_ui_tab_pager_tab_bar_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object tab_bar);

        
        public delegate void efl_ui_tab_pager_tab_bar_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object tab_bar);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_pager_tab_bar_set_api_delegate> efl_ui_tab_pager_tab_bar_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_pager_tab_bar_set_api_delegate>(Module, "efl_ui_tab_pager_tab_bar_set");

        private static void tab_bar_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object tab_bar)
        {
            Eina.Log.Debug("function efl_ui_tab_pager_tab_bar_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((TabPager)wrapper).SetTabBar(tab_bar);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_tab_pager_tab_bar_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), tab_bar);
            }
        }

        private static efl_ui_tab_pager_tab_bar_set_delegate efl_ui_tab_pager_tab_bar_set_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

