#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

[Efl.Ui.IListViewModelConcrete.NativeMethods]
public interface IListViewModel : 
    Efl.Eo.IWrapper, IDisposable
{
    void SetLoadRange(int first, int count);
    int GetModelSize();
    /// <summary>Minimal content size.</summary>
Eina.Size2D GetMinSize();
    /// <summary>Minimal content size.</summary>
void SetMinSize(Eina.Size2D min);
    Efl.Ui.ListViewLayoutItem Realize(ref Efl.Ui.ListViewLayoutItem item);
    void Unrealize(ref Efl.Ui.ListViewLayoutItem item);
                                int ModelSize {
        get ;
    }
    /// <summary>Minimal content size.</summary>
    Eina.Size2D MinSize {
        get ;
        set ;
    }
}
sealed public class IListViewModelConcrete : 

IListViewModel
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IListViewModelConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle
    {
        get { return handle; }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_list_view_model_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IListViewModel"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IListViewModelConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~IListViewModelConcrete()
    {
        Dispose(false);
    }

    ///<summary>Releases the underlying native instance.</summary>
    private void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero)
        {
            IntPtr h = handle;
            handle = IntPtr.Zero;

            IntPtr gcHandlePtr = IntPtr.Zero;
            if (disposing)
            {
                Efl.Eo.Globals.efl_mono_native_dispose(h, gcHandlePtr);
            }
            else
            {
                Monitor.Enter(Efl.All.InitLock);
                if (Efl.All.MainLoopInitialized)
                {
                    Efl.Eo.Globals.efl_mono_thread_safe_native_dispose(h, gcHandlePtr);
                }

                Monitor.Exit(Efl.All.InitLock);
            }
        }

    }

    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
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

    public void SetLoadRange(int first, int count) {
                                                         Efl.Ui.IListViewModelConcrete.NativeMethods.efl_ui_list_view_model_load_range_set_ptr.Value.Delegate(this.NativeHandle,first, count);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    public int GetModelSize() {
         var _ret_var = Efl.Ui.IListViewModelConcrete.NativeMethods.efl_ui_list_view_model_size_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Minimal content size.</summary>
    public Eina.Size2D GetMinSize() {
         var _ret_var = Efl.Ui.IListViewModelConcrete.NativeMethods.efl_ui_list_view_model_min_size_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Minimal content size.</summary>
    public void SetMinSize(Eina.Size2D min) {
         Eina.Size2D.NativeStruct _in_min = min;
                        Efl.Ui.IListViewModelConcrete.NativeMethods.efl_ui_list_view_model_min_size_set_ptr.Value.Delegate(this.NativeHandle,_in_min);
        Eina.Error.RaiseIfUnhandledException();
                         }
    public Efl.Ui.ListViewLayoutItem Realize(ref Efl.Ui.ListViewLayoutItem item) {
         Efl.Ui.ListViewLayoutItem.NativeStruct _in_item = item;
                        var _ret_var = Efl.Ui.IListViewModelConcrete.NativeMethods.efl_ui_list_view_model_realize_ptr.Value.Delegate(this.NativeHandle,ref _in_item);
        Eina.Error.RaiseIfUnhandledException();
                item = _in_item;
        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.ListViewLayoutItem>(_ret_var);
        
        return __ret_tmp;
 }
    public void Unrealize(ref Efl.Ui.ListViewLayoutItem item) {
         Efl.Ui.ListViewLayoutItem.NativeStruct _in_item = item;
                        Efl.Ui.IListViewModelConcrete.NativeMethods.efl_ui_list_view_model_unrealize_ptr.Value.Delegate(this.NativeHandle,ref _in_item);
        Eina.Error.RaiseIfUnhandledException();
                item = _in_item;
         }
        public int ModelSize {
        get { return GetModelSize(); }
    }
    /// <summary>Minimal content size.</summary>
    public Eina.Size2D MinSize {
        get { return GetMinSize(); }
        set { SetMinSize(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IListViewModelConcrete.efl_ui_list_view_model_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_list_view_model_load_range_set_static_delegate == null)
            {
                efl_ui_list_view_model_load_range_set_static_delegate = new efl_ui_list_view_model_load_range_set_delegate(load_range_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLoadRange") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_model_load_range_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_load_range_set_static_delegate) });
            }

            if (efl_ui_list_view_model_size_get_static_delegate == null)
            {
                efl_ui_list_view_model_size_get_static_delegate = new efl_ui_list_view_model_size_get_delegate(model_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetModelSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_model_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_size_get_static_delegate) });
            }

            if (efl_ui_list_view_model_min_size_get_static_delegate == null)
            {
                efl_ui_list_view_model_min_size_get_static_delegate = new efl_ui_list_view_model_min_size_get_delegate(min_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMinSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_model_min_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_min_size_get_static_delegate) });
            }

            if (efl_ui_list_view_model_min_size_set_static_delegate == null)
            {
                efl_ui_list_view_model_min_size_set_static_delegate = new efl_ui_list_view_model_min_size_set_delegate(min_size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMinSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_model_min_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_min_size_set_static_delegate) });
            }

            if (efl_ui_list_view_model_realize_static_delegate == null)
            {
                efl_ui_list_view_model_realize_static_delegate = new efl_ui_list_view_model_realize_delegate(realize);
            }

            if (methods.FirstOrDefault(m => m.Name == "Realize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_model_realize"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_realize_static_delegate) });
            }

            if (efl_ui_list_view_model_unrealize_static_delegate == null)
            {
                efl_ui_list_view_model_unrealize_static_delegate = new efl_ui_list_view_model_unrealize_delegate(unrealize);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unrealize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_model_unrealize"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_unrealize_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IListViewModelConcrete.efl_ui_list_view_model_interface_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate void efl_ui_list_view_model_load_range_set_delegate(System.IntPtr obj, System.IntPtr pd,  int first,  int count);

        
        public delegate void efl_ui_list_view_model_load_range_set_api_delegate(System.IntPtr obj,  int first,  int count);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_load_range_set_api_delegate> efl_ui_list_view_model_load_range_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_load_range_set_api_delegate>(Module, "efl_ui_list_view_model_load_range_set");

        private static void load_range_set(System.IntPtr obj, System.IntPtr pd, int first, int count)
        {
            Eina.Log.Debug("function efl_ui_list_view_model_load_range_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((IListViewModel)wrapper).SetLoadRange(first, count);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_list_view_model_load_range_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), first, count);
            }
        }

        private static efl_ui_list_view_model_load_range_set_delegate efl_ui_list_view_model_load_range_set_static_delegate;

        
        private delegate int efl_ui_list_view_model_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_list_view_model_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_size_get_api_delegate> efl_ui_list_view_model_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_size_get_api_delegate>(Module, "efl_ui_list_view_model_size_get");

        private static int model_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_list_view_model_size_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IListViewModel)wrapper).GetModelSize();
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
                return efl_ui_list_view_model_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_list_view_model_size_get_delegate efl_ui_list_view_model_size_get_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_ui_list_view_model_min_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_ui_list_view_model_min_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_min_size_get_api_delegate> efl_ui_list_view_model_min_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_min_size_get_api_delegate>(Module, "efl_ui_list_view_model_min_size_get");

        private static Eina.Size2D.NativeStruct min_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_list_view_model_min_size_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IListViewModel)wrapper).GetMinSize();
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
                return efl_ui_list_view_model_min_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_list_view_model_min_size_get_delegate efl_ui_list_view_model_min_size_get_static_delegate;

        
        private delegate void efl_ui_list_view_model_min_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct min);

        
        public delegate void efl_ui_list_view_model_min_size_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct min);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_min_size_set_api_delegate> efl_ui_list_view_model_min_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_min_size_set_api_delegate>(Module, "efl_ui_list_view_model_min_size_set");

        private static void min_size_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct min)
        {
            Eina.Log.Debug("function efl_ui_list_view_model_min_size_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
        Eina.Size2D _in_min = min;
                            
                try
                {
                    ((IListViewModel)wrapper).SetMinSize(_in_min);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_list_view_model_min_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), min);
            }
        }

        private static efl_ui_list_view_model_min_size_set_delegate efl_ui_list_view_model_min_size_set_static_delegate;

        
        private delegate System.IntPtr efl_ui_list_view_model_realize_delegate(System.IntPtr obj, System.IntPtr pd,  ref Efl.Ui.ListViewLayoutItem.NativeStruct item);

        
        public delegate System.IntPtr efl_ui_list_view_model_realize_api_delegate(System.IntPtr obj,  ref Efl.Ui.ListViewLayoutItem.NativeStruct item);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_realize_api_delegate> efl_ui_list_view_model_realize_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_realize_api_delegate>(Module, "efl_ui_list_view_model_realize");

        private static System.IntPtr realize(System.IntPtr obj, System.IntPtr pd, ref Efl.Ui.ListViewLayoutItem.NativeStruct item)
        {
            Eina.Log.Debug("function efl_ui_list_view_model_realize was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
        Efl.Ui.ListViewLayoutItem _in_item = item;
                            Efl.Ui.ListViewLayoutItem _ret_var = default(Efl.Ui.ListViewLayoutItem);
                try
                {
                    _ret_var = ((IListViewModel)wrapper).Realize(ref _in_item);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                item = _in_item;
        return Eina.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);

            }
            else
            {
                return efl_ui_list_view_model_realize_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ref item);
            }
        }

        private static efl_ui_list_view_model_realize_delegate efl_ui_list_view_model_realize_static_delegate;

        
        private delegate void efl_ui_list_view_model_unrealize_delegate(System.IntPtr obj, System.IntPtr pd,  ref Efl.Ui.ListViewLayoutItem.NativeStruct item);

        
        public delegate void efl_ui_list_view_model_unrealize_api_delegate(System.IntPtr obj,  ref Efl.Ui.ListViewLayoutItem.NativeStruct item);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_unrealize_api_delegate> efl_ui_list_view_model_unrealize_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_unrealize_api_delegate>(Module, "efl_ui_list_view_model_unrealize");

        private static void unrealize(System.IntPtr obj, System.IntPtr pd, ref Efl.Ui.ListViewLayoutItem.NativeStruct item)
        {
            Eina.Log.Debug("function efl_ui_list_view_model_unrealize was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
        Efl.Ui.ListViewLayoutItem _in_item = item;
                            
                try
                {
                    ((IListViewModel)wrapper).Unrealize(ref _in_item);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                item = _in_item;
        
            }
            else
            {
                efl_ui_list_view_model_unrealize_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ref item);
            }
        }

        private static efl_ui_list_view_model_unrealize_delegate efl_ui_list_view_model_unrealize_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

