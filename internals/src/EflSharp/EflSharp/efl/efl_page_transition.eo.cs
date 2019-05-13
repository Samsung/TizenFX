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
/// A page transition is essential to <see cref="Efl.Ui.Pager"/> object and invoked whenever pages are rearranged or scrolled (see <see cref="Efl.Ui.Pager"/>).</summary>
[Efl.Page.Transition.NativeMethods]
public class Transition : Efl.Object, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Transition))
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
        efl_page_transition_class_get();
    /// <summary>Initializes a new instance of the <see cref="Transition"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Transition(Efl.Object parent= null
            ) : base(efl_page_transition_class_get(), typeof(Transition), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Transition"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Transition(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="Transition"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Transition(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
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

    /// <summary>set object</summary>
    /// <param name="pager">pager object</param>
    /// <param name="group">a dummy object for layer adjustment</param>
    virtual public void Bind(Efl.Ui.Pager pager, Efl.Canvas.Group group) {
                                                         Efl.Page.Transition.NativeMethods.efl_page_transition_bind_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),pager, group);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Page.Transition.efl_page_transition_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_page_transition_bind_static_delegate == null)
            {
                efl_page_transition_bind_static_delegate = new efl_page_transition_bind_delegate(bind);
            }

            if (methods.FirstOrDefault(m => m.Name == "Bind") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_page_transition_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_page_transition_bind_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Page.Transition.efl_page_transition_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate void efl_page_transition_bind_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Pager pager, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Group group);

        
        public delegate void efl_page_transition_bind_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Pager pager, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Group group);

        public static Efl.Eo.FunctionWrapper<efl_page_transition_bind_api_delegate> efl_page_transition_bind_ptr = new Efl.Eo.FunctionWrapper<efl_page_transition_bind_api_delegate>(Module, "efl_page_transition_bind");

        private static void bind(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Pager pager, Efl.Canvas.Group group)
        {
            Eina.Log.Debug("function efl_page_transition_bind was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((Transition)wrapper).Bind(pager, group);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_page_transition_bind_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pager, group);
            }
        }

        private static efl_page_transition_bind_delegate efl_page_transition_bind_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

