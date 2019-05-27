#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Efl Ui Factory that provides object caching.
/// This factory handles caching of one type of object that must be an <see cref="Efl.Gfx.IEntity"/> with an <see cref="Efl.Ui.IView"/> interface defined. This factory will rely on its parent class <see cref="Efl.Ui.WidgetFactory"/> for creating the subset of class that match <see cref="Efl.Ui.Widget"/> interface. The factory will automatically empties the cache when the application goes into pause.
/// 
/// Creating objects is costly and time consuming, keeping a few on hand for when you next will need them helps a lot. This is what this factory caching infrastructure provides. It will create the object from the class defined on it and set the parent and the model as needed for all created items. The View has to release the Item using the release function of the Factory interface for all of this to work properly.
/// 
/// The cache might decide to flush itself when the application event pause is triggered.</summary>
[Efl.Ui.CachingFactory.NativeMethods]
public class CachingFactory : Efl.Ui.WidgetFactory, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(CachingFactory))
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
        efl_ui_caching_factory_class_get();
    /// <summary>Initializes a new instance of the <see cref="CachingFactory"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="itemClass">Define the class of the item returned by this factory. See <see cref="Efl.Ui.WidgetFactory.SetItemClass"/></param>
    public CachingFactory(Efl.Object parent
            , Type itemClass = null) : base(efl_ui_caching_factory_class_get(), typeof(CachingFactory), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(itemClass))
        {
            SetItemClass(Efl.Eo.Globals.GetParamHelper(itemClass));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="CachingFactory"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected CachingFactory(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="CachingFactory"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected CachingFactory(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
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

    /// <summary>Define the maxium size in Bytes that all the object waiting on standby in the cache take. They must provide the <see cref="Efl.Cached.IItem"/> interface for an accurate accounting.</summary>
    /// <returns>When set to zero, there is no limit on the amount of memory the cache will use.</returns>
    virtual public uint GetMemoryLimit() {
         var _ret_var = Efl.Ui.CachingFactory.NativeMethods.efl_ui_caching_factory_memory_limit_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Define the maxium size in Bytes that all the object waiting on standby in the cache take. They must provide the <see cref="Efl.Cached.IItem"/> interface for an accurate accounting.</summary>
    /// <param name="limit">When set to zero, there is no limit on the amount of memory the cache will use.</param>
    virtual public void SetMemoryLimit(uint limit) {
                                 Efl.Ui.CachingFactory.NativeMethods.efl_ui_caching_factory_memory_limit_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),limit);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Define how many maximum number of items are waiting on standby in the cache.</summary>
    /// <returns>When set to zero, there is no limit to the amount of items stored in the cache.</returns>
    virtual public uint GetItemsLimit() {
         var _ret_var = Efl.Ui.CachingFactory.NativeMethods.efl_ui_caching_factory_items_limit_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Define how many maximum number of items are waiting on standby in the cache.</summary>
    /// <param name="limit">When set to zero, there is no limit to the amount of items stored in the cache.</param>
    virtual public void SetItemsLimit(uint limit) {
                                 Efl.Ui.CachingFactory.NativeMethods.efl_ui_caching_factory_items_limit_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),limit);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Define the maxium size in Bytes that all the object waiting on standby in the cache take. They must provide the <see cref="Efl.Cached.IItem"/> interface for an accurate accounting.</summary>
/// <value>When set to zero, there is no limit on the amount of memory the cache will use.</value>
    public uint MemoryLimit {
        get { return GetMemoryLimit(); }
        set { SetMemoryLimit(value); }
    }
    /// <summary>Define how many maximum number of items are waiting on standby in the cache.</summary>
/// <value>When set to zero, there is no limit to the amount of items stored in the cache.</value>
    public uint ItemsLimit {
        get { return GetItemsLimit(); }
        set { SetItemsLimit(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.CachingFactory.efl_ui_caching_factory_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.WidgetFactory.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_caching_factory_memory_limit_get_static_delegate == null)
            {
                efl_ui_caching_factory_memory_limit_get_static_delegate = new efl_ui_caching_factory_memory_limit_get_delegate(memory_limit_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMemoryLimit") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_caching_factory_memory_limit_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_memory_limit_get_static_delegate) });
            }

            if (efl_ui_caching_factory_memory_limit_set_static_delegate == null)
            {
                efl_ui_caching_factory_memory_limit_set_static_delegate = new efl_ui_caching_factory_memory_limit_set_delegate(memory_limit_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMemoryLimit") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_caching_factory_memory_limit_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_memory_limit_set_static_delegate) });
            }

            if (efl_ui_caching_factory_items_limit_get_static_delegate == null)
            {
                efl_ui_caching_factory_items_limit_get_static_delegate = new efl_ui_caching_factory_items_limit_get_delegate(items_limit_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetItemsLimit") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_caching_factory_items_limit_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_items_limit_get_static_delegate) });
            }

            if (efl_ui_caching_factory_items_limit_set_static_delegate == null)
            {
                efl_ui_caching_factory_items_limit_set_static_delegate = new efl_ui_caching_factory_items_limit_set_delegate(items_limit_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetItemsLimit") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_caching_factory_items_limit_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_items_limit_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.CachingFactory.efl_ui_caching_factory_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate uint efl_ui_caching_factory_memory_limit_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_ui_caching_factory_memory_limit_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_caching_factory_memory_limit_get_api_delegate> efl_ui_caching_factory_memory_limit_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_caching_factory_memory_limit_get_api_delegate>(Module, "efl_ui_caching_factory_memory_limit_get");

        private static uint memory_limit_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_caching_factory_memory_limit_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((CachingFactory)wrapper).GetMemoryLimit();
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
                return efl_ui_caching_factory_memory_limit_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_caching_factory_memory_limit_get_delegate efl_ui_caching_factory_memory_limit_get_static_delegate;

        
        private delegate void efl_ui_caching_factory_memory_limit_set_delegate(System.IntPtr obj, System.IntPtr pd,  uint limit);

        
        public delegate void efl_ui_caching_factory_memory_limit_set_api_delegate(System.IntPtr obj,  uint limit);

        public static Efl.Eo.FunctionWrapper<efl_ui_caching_factory_memory_limit_set_api_delegate> efl_ui_caching_factory_memory_limit_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_caching_factory_memory_limit_set_api_delegate>(Module, "efl_ui_caching_factory_memory_limit_set");

        private static void memory_limit_set(System.IntPtr obj, System.IntPtr pd, uint limit)
        {
            Eina.Log.Debug("function efl_ui_caching_factory_memory_limit_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((CachingFactory)wrapper).SetMemoryLimit(limit);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_caching_factory_memory_limit_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), limit);
            }
        }

        private static efl_ui_caching_factory_memory_limit_set_delegate efl_ui_caching_factory_memory_limit_set_static_delegate;

        
        private delegate uint efl_ui_caching_factory_items_limit_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_ui_caching_factory_items_limit_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_caching_factory_items_limit_get_api_delegate> efl_ui_caching_factory_items_limit_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_caching_factory_items_limit_get_api_delegate>(Module, "efl_ui_caching_factory_items_limit_get");

        private static uint items_limit_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_caching_factory_items_limit_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((CachingFactory)wrapper).GetItemsLimit();
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
                return efl_ui_caching_factory_items_limit_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_caching_factory_items_limit_get_delegate efl_ui_caching_factory_items_limit_get_static_delegate;

        
        private delegate void efl_ui_caching_factory_items_limit_set_delegate(System.IntPtr obj, System.IntPtr pd,  uint limit);

        
        public delegate void efl_ui_caching_factory_items_limit_set_api_delegate(System.IntPtr obj,  uint limit);

        public static Efl.Eo.FunctionWrapper<efl_ui_caching_factory_items_limit_set_api_delegate> efl_ui_caching_factory_items_limit_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_caching_factory_items_limit_set_api_delegate>(Module, "efl_ui_caching_factory_items_limit_set");

        private static void items_limit_set(System.IntPtr obj, System.IntPtr pd, uint limit)
        {
            Eina.Log.Debug("function efl_ui_caching_factory_items_limit_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((CachingFactory)wrapper).SetItemsLimit(limit);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_caching_factory_items_limit_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), limit);
            }
        }

        private static efl_ui_caching_factory_items_limit_set_delegate efl_ui_caching_factory_items_limit_set_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

