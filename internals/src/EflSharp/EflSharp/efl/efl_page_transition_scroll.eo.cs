#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Page {

/// <summary>Page transition for <see cref="Efl.Ui.Pager"/>
/// With this type of transition, pages are arranged linearly and move parallel to the screen by scrolling. The current page is displayed at center, and previous and next pages might be displayed optionally.</summary>
[Efl.Page.TransitionScroll.NativeMethods]
public class TransitionScroll : Efl.Page.Transition, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(TransitionScroll))
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
        efl_page_transition_scroll_class_get();
    /// <summary>Initializes a new instance of the <see cref="TransitionScroll"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public TransitionScroll(Efl.Object parent= null
            ) : base(efl_page_transition_scroll_class_get(), typeof(TransitionScroll), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="TransitionScroll"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected TransitionScroll(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="TransitionScroll"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected TransitionScroll(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
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

    /// <summary>The number of pages displayed on each side of the current page</summary>
    virtual public int GetSidePageNum() {
         var _ret_var = Efl.Page.TransitionScroll.NativeMethods.efl_page_transition_scroll_side_page_num_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The number of pages displayed on each side of the current page</summary>
    virtual public void SetSidePageNum(int side_page_num) {
                                 Efl.Page.TransitionScroll.NativeMethods.efl_page_transition_scroll_side_page_num_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),side_page_num);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The number of pages displayed on each side of the current page</summary>
    public int SidePageNum {
        get { return GetSidePageNum(); }
        set { SetSidePageNum(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Page.TransitionScroll.efl_page_transition_scroll_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Page.Transition.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_page_transition_scroll_side_page_num_get_static_delegate == null)
            {
                efl_page_transition_scroll_side_page_num_get_static_delegate = new efl_page_transition_scroll_side_page_num_get_delegate(side_page_num_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSidePageNum") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_page_transition_scroll_side_page_num_get"), func = Marshal.GetFunctionPointerForDelegate(efl_page_transition_scroll_side_page_num_get_static_delegate) });
            }

            if (efl_page_transition_scroll_side_page_num_set_static_delegate == null)
            {
                efl_page_transition_scroll_side_page_num_set_static_delegate = new efl_page_transition_scroll_side_page_num_set_delegate(side_page_num_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSidePageNum") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_page_transition_scroll_side_page_num_set"), func = Marshal.GetFunctionPointerForDelegate(efl_page_transition_scroll_side_page_num_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Page.TransitionScroll.efl_page_transition_scroll_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate int efl_page_transition_scroll_side_page_num_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_page_transition_scroll_side_page_num_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_page_transition_scroll_side_page_num_get_api_delegate> efl_page_transition_scroll_side_page_num_get_ptr = new Efl.Eo.FunctionWrapper<efl_page_transition_scroll_side_page_num_get_api_delegate>(Module, "efl_page_transition_scroll_side_page_num_get");

        private static int side_page_num_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_page_transition_scroll_side_page_num_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((TransitionScroll)wrapper).GetSidePageNum();
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
                return efl_page_transition_scroll_side_page_num_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_page_transition_scroll_side_page_num_get_delegate efl_page_transition_scroll_side_page_num_get_static_delegate;

        
        private delegate void efl_page_transition_scroll_side_page_num_set_delegate(System.IntPtr obj, System.IntPtr pd,  int side_page_num);

        
        public delegate void efl_page_transition_scroll_side_page_num_set_api_delegate(System.IntPtr obj,  int side_page_num);

        public static Efl.Eo.FunctionWrapper<efl_page_transition_scroll_side_page_num_set_api_delegate> efl_page_transition_scroll_side_page_num_set_ptr = new Efl.Eo.FunctionWrapper<efl_page_transition_scroll_side_page_num_set_api_delegate>(Module, "efl_page_transition_scroll_side_page_num_set");

        private static void side_page_num_set(System.IntPtr obj, System.IntPtr pd, int side_page_num)
        {
            Eina.Log.Debug("function efl_page_transition_scroll_side_page_num_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((TransitionScroll)wrapper).SetSidePageNum(side_page_num);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_page_transition_scroll_side_page_num_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), side_page_num);
            }
        }

        private static efl_page_transition_scroll_side_page_num_set_delegate efl_page_transition_scroll_side_page_num_set_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

