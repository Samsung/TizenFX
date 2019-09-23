#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.ListViewModelConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
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
                            (int, int) LoadRange {
        set;
    }
    int ModelSize {
        get;
    }
    /// <summary>Minimal content size.</summary>
    Eina.Size2D MinSize {
        get;
        set;
    }
}
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class ListViewModelConcrete :
    Efl.Eo.EoWrapper
    , IListViewModel
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ListViewModelConcrete))
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
    private ListViewModelConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_list_view_model_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IListViewModel"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ListViewModelConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    public void SetLoadRange(int first, int count) {
                                                         Efl.Ui.ListViewModelConcrete.NativeMethods.efl_ui_list_view_model_load_range_set_ptr.Value.Delegate(this.NativeHandle,first, count);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    public int GetModelSize() {
         var _ret_var = Efl.Ui.ListViewModelConcrete.NativeMethods.efl_ui_list_view_model_size_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Minimal content size.</summary>
    public Eina.Size2D GetMinSize() {
         var _ret_var = Efl.Ui.ListViewModelConcrete.NativeMethods.efl_ui_list_view_model_min_size_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Minimal content size.</summary>
    public void SetMinSize(Eina.Size2D min) {
         Eina.Size2D.NativeStruct _in_min = min;
                        Efl.Ui.ListViewModelConcrete.NativeMethods.efl_ui_list_view_model_min_size_set_ptr.Value.Delegate(this.NativeHandle,_in_min);
        Eina.Error.RaiseIfUnhandledException();
                         }
    public Efl.Ui.ListViewLayoutItem Realize(ref Efl.Ui.ListViewLayoutItem item) {
         Efl.Ui.ListViewLayoutItem.NativeStruct _in_item = item;
                        var _ret_var = Efl.Ui.ListViewModelConcrete.NativeMethods.efl_ui_list_view_model_realize_ptr.Value.Delegate(this.NativeHandle,ref _in_item);
        Eina.Error.RaiseIfUnhandledException();
                item = _in_item;
        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.ListViewLayoutItem>(_ret_var);
        
        return __ret_tmp;
 }
    public void Unrealize(ref Efl.Ui.ListViewLayoutItem item) {
         Efl.Ui.ListViewLayoutItem.NativeStruct _in_item = item;
                        Efl.Ui.ListViewModelConcrete.NativeMethods.efl_ui_list_view_model_unrealize_ptr.Value.Delegate(this.NativeHandle,ref _in_item);
        Eina.Error.RaiseIfUnhandledException();
                item = _in_item;
         }
    public (int, int) LoadRange {
        set { SetLoadRange( value.Item1,  value.Item2); }
    }
    public int ModelSize {
        get { return GetModelSize(); }
    }
    /// <summary>Minimal content size.</summary>
    public Eina.Size2D MinSize {
        get { return GetMinSize(); }
        set { SetMinSize(value); }
    }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ListViewModelConcrete.efl_ui_list_view_model_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
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
            return Efl.Ui.ListViewModelConcrete.efl_ui_list_view_model_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_list_view_model_load_range_set_delegate(System.IntPtr obj, System.IntPtr pd,  int first,  int count);

        
        public delegate void efl_ui_list_view_model_load_range_set_api_delegate(System.IntPtr obj,  int first,  int count);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_load_range_set_api_delegate> efl_ui_list_view_model_load_range_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_load_range_set_api_delegate>(Module, "efl_ui_list_view_model_load_range_set");

        private static void load_range_set(System.IntPtr obj, System.IntPtr pd, int first, int count)
        {
            Eina.Log.Debug("function efl_ui_list_view_model_load_range_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IListViewModel)ws.Target).SetLoadRange(first, count);
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
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IListViewModel)ws.Target).GetModelSize();
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
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IListViewModel)ws.Target).GetMinSize();
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
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_min = min;
                            
                try
                {
                    ((IListViewModel)ws.Target).SetMinSize(_in_min);
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
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Ui.ListViewLayoutItem _in_item = item;
                            Efl.Ui.ListViewLayoutItem _ret_var = default(Efl.Ui.ListViewLayoutItem);
                try
                {
                    _ret_var = ((IListViewModel)ws.Target).Realize(ref _in_item);
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
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Ui.ListViewLayoutItem _in_item = item;
                            
                try
                {
                    ((IListViewModel)ws.Target).Unrealize(ref _in_item);
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiListViewModelConcrete_ExtensionMethods {
    
    
    public static Efl.BindableProperty<Eina.Size2D> MinSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IListViewModel, T>magic = null) where T : Efl.Ui.IListViewModel {
        return new Efl.BindableProperty<Eina.Size2D>("min_size", fac);
    }

}
#pragma warning restore CS1591
#endif
