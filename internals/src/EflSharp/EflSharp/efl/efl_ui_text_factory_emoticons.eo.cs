#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

namespace TextFactory {

/// <summary>Factory that creates emoticons from the current theme given a key.</summary>
[Efl.Ui.TextFactory.Emoticons.NativeMethods]
public class Emoticons : Efl.Object, Efl.Eo.IWrapper,Efl.Canvas.ITextFactory
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Emoticons))
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
        efl_ui_text_factory_emoticons_class_get();
    /// <summary>Initializes a new instance of the <see cref="Emoticons"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Emoticons(Efl.Object parent= null
            ) : base(efl_ui_text_factory_emoticons_class_get(), typeof(Emoticons), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Emoticons"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Emoticons(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="Emoticons"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Emoticons(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
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

    /// <summary>Translates a given <c>key</c> to an item object, and returns the object. The returned object should be owned by the passed <c>object</c>.</summary>
    /// <param name="kw_object">The parent of the created object</param>
    /// <param name="key">Key that is associated to an item object</param>
    virtual public Efl.Canvas.Object Create(Efl.Canvas.Object kw_object, System.String key) {
                                                         var _ret_var = Efl.Canvas.ITextFactoryConcrete.NativeMethods.efl_canvas_text_factory_create_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),kw_object, key);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.TextFactory.Emoticons.efl_ui_text_factory_emoticons_class_get();
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

            if (efl_canvas_text_factory_create_static_delegate == null)
            {
                efl_canvas_text_factory_create_static_delegate = new efl_canvas_text_factory_create_delegate(create);
            }

            if (methods.FirstOrDefault(m => m.Name == "Create") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_factory_create"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_factory_create_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.TextFactory.Emoticons.efl_ui_text_factory_emoticons_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))]
        private delegate Efl.Canvas.Object efl_canvas_text_factory_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object kw_object, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))]
        public delegate Efl.Canvas.Object efl_canvas_text_factory_create_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object kw_object, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_factory_create_api_delegate> efl_canvas_text_factory_create_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_factory_create_api_delegate>(Module, "efl_canvas_text_factory_create");

        private static Efl.Canvas.Object create(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object kw_object, System.String key)
        {
            Eina.Log.Debug("function efl_canvas_text_factory_create was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((Emoticons)wrapper).Create(kw_object, key);
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
                return efl_canvas_text_factory_create_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_object, key);
            }
        }

        private static efl_canvas_text_factory_create_delegate efl_canvas_text_factory_create_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

}

