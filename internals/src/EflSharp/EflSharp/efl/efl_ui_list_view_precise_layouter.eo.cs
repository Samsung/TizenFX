#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary></summary>
[ListViewPreciseLayouterNativeInherit]
public class ListViewPreciseLayouter : Efl.Object, Efl.Eo.IWrapper,Efl.Ui.IListViewRelayout
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (ListViewPreciseLayouter))
                return Efl.Ui.ListViewPreciseLayouterNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_list_view_precise_layouter_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public ListViewPreciseLayouter(Efl.Object parent= null
            ) :
        base(efl_ui_list_view_precise_layouter_class_get(), typeof(ListViewPreciseLayouter), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected ListViewPreciseLayouter(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected ListViewPreciseLayouter(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
    ///<summary>Verifies if the given object is equal to this one.</summary>
    public override bool Equals(object obj)
    {
        var other = obj as Efl.Object;
        if (other == null)
            return false;
        return this.NativeHandle == other.NativeHandle;
    }
    ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }
    ///<summary>Turns the native pointer into a string representation.</summary>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }
    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
    }
    /// <summary>Model that is/will be</summary>
    /// <param name="model">Efl model</param>
    /// <returns></returns>
    virtual public void SetModel( Efl.IModel model) {
                                 Efl.Ui.IListViewRelayoutNativeInherit.efl_ui_list_view_relayout_model_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), model);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary></summary>
    /// <returns>The order to use</returns>
    virtual public Eina.List<Efl.Gfx.IEntity> GetElements() {
         var _ret_var = Efl.Ui.IListViewRelayoutNativeInherit.efl_ui_list_view_relayout_elements_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Gfx.IEntity>(_ret_var, false, false);
 }
    /// <summary></summary>
    /// <param name="modeler"></param>
    /// <param name="first"></param>
    /// <param name="children"></param>
    /// <returns></returns>
    virtual public void LayoutDo( Efl.Ui.IListViewModel modeler,  int first,  EflUiListViewSegArray children) {
                                                                                 Efl.Ui.IListViewRelayoutNativeInherit.efl_ui_list_view_relayout_layout_do_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), modeler,  first,  children);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary></summary>
    /// <param name="item"></param>
    /// <returns></returns>
    virtual public void ContentCreated( ref Efl.Ui.ListViewLayoutItem item) {
         Efl.Ui.ListViewLayoutItem.NativeStruct _in_item = item;
                        Efl.Ui.IListViewRelayoutNativeInherit.efl_ui_list_view_relayout_content_created_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), ref _in_item);
        Eina.Error.RaiseIfUnhandledException();
                item = _in_item;
         }
    /// <summary>Model that is/will be</summary>
/// <value>Efl model</value>
    public Efl.IModel Model {
        set { SetModel( value); }
    }
    /// <summary></summary>
/// <value>The order to use</value>
    public Eina.List<Efl.Gfx.IEntity> Elements {
        get { return GetElements(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ListViewPreciseLayouter.efl_ui_list_view_precise_layouter_class_get();
    }
}
public class ListViewPreciseLayouterNativeInherit : Efl.ObjectNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_list_view_relayout_model_set_static_delegate == null)
            efl_ui_list_view_relayout_model_set_static_delegate = new efl_ui_list_view_relayout_model_set_delegate(model_set);
        if (methods.FirstOrDefault(m => m.Name == "SetModel") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_list_view_relayout_model_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_relayout_model_set_static_delegate)});
        if (efl_ui_list_view_relayout_elements_get_static_delegate == null)
            efl_ui_list_view_relayout_elements_get_static_delegate = new efl_ui_list_view_relayout_elements_get_delegate(elements_get);
        if (methods.FirstOrDefault(m => m.Name == "GetElements") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_list_view_relayout_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_relayout_elements_get_static_delegate)});
        if (efl_ui_list_view_relayout_layout_do_static_delegate == null)
            efl_ui_list_view_relayout_layout_do_static_delegate = new efl_ui_list_view_relayout_layout_do_delegate(layout_do);
        if (methods.FirstOrDefault(m => m.Name == "LayoutDo") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_list_view_relayout_layout_do"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_relayout_layout_do_static_delegate)});
        if (efl_ui_list_view_relayout_content_created_static_delegate == null)
            efl_ui_list_view_relayout_content_created_static_delegate = new efl_ui_list_view_relayout_content_created_delegate(content_created);
        if (methods.FirstOrDefault(m => m.Name == "ContentCreated") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_list_view_relayout_content_created"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_relayout_content_created_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.ListViewPreciseLayouter.efl_ui_list_view_precise_layouter_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ListViewPreciseLayouter.efl_ui_list_view_precise_layouter_class_get();
    }


     private delegate void efl_ui_list_view_relayout_model_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.IModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.IModel model);


     public delegate void efl_ui_list_view_relayout_model_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.IModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.IModel model);
     public static Efl.Eo.FunctionWrapper<efl_ui_list_view_relayout_model_set_api_delegate> efl_ui_list_view_relayout_model_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_relayout_model_set_api_delegate>(_Module, "efl_ui_list_view_relayout_model_set");
     private static void model_set(System.IntPtr obj, System.IntPtr pd,  Efl.IModel model)
    {
        Eina.Log.Debug("function efl_ui_list_view_relayout_model_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ListViewPreciseLayouter)wrapper).SetModel( model);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_list_view_relayout_model_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  model);
        }
    }
    private static efl_ui_list_view_relayout_model_set_delegate efl_ui_list_view_relayout_model_set_static_delegate;


     private delegate System.IntPtr efl_ui_list_view_relayout_elements_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate System.IntPtr efl_ui_list_view_relayout_elements_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_list_view_relayout_elements_get_api_delegate> efl_ui_list_view_relayout_elements_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_relayout_elements_get_api_delegate>(_Module, "efl_ui_list_view_relayout_elements_get");
     private static System.IntPtr elements_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_list_view_relayout_elements_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.List<Efl.Gfx.IEntity> _ret_var = default(Eina.List<Efl.Gfx.IEntity>);
            try {
                _ret_var = ((ListViewPreciseLayouter)wrapper).GetElements();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var.Handle;
        } else {
            return efl_ui_list_view_relayout_elements_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_list_view_relayout_elements_get_delegate efl_ui_list_view_relayout_elements_get_static_delegate;


     private delegate void efl_ui_list_view_relayout_layout_do_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.IListViewModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.IListViewModel modeler,   int first,   EflUiListViewSegArray children);


     public delegate void efl_ui_list_view_relayout_layout_do_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.IListViewModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.IListViewModel modeler,   int first,   EflUiListViewSegArray children);
     public static Efl.Eo.FunctionWrapper<efl_ui_list_view_relayout_layout_do_api_delegate> efl_ui_list_view_relayout_layout_do_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_relayout_layout_do_api_delegate>(_Module, "efl_ui_list_view_relayout_layout_do");
     private static void layout_do(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.IListViewModel modeler,  int first,  EflUiListViewSegArray children)
    {
        Eina.Log.Debug("function efl_ui_list_view_relayout_layout_do was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                
            try {
                ((ListViewPreciseLayouter)wrapper).LayoutDo( modeler,  first,  children);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                } else {
            efl_ui_list_view_relayout_layout_do_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  modeler,  first,  children);
        }
    }
    private static efl_ui_list_view_relayout_layout_do_delegate efl_ui_list_view_relayout_layout_do_static_delegate;


     private delegate void efl_ui_list_view_relayout_content_created_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Ui.ListViewLayoutItem.NativeStruct item);


     public delegate void efl_ui_list_view_relayout_content_created_api_delegate(System.IntPtr obj,   ref Efl.Ui.ListViewLayoutItem.NativeStruct item);
     public static Efl.Eo.FunctionWrapper<efl_ui_list_view_relayout_content_created_api_delegate> efl_ui_list_view_relayout_content_created_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_relayout_content_created_api_delegate>(_Module, "efl_ui_list_view_relayout_content_created");
     private static void content_created(System.IntPtr obj, System.IntPtr pd,  ref Efl.Ui.ListViewLayoutItem.NativeStruct item)
    {
        Eina.Log.Debug("function efl_ui_list_view_relayout_content_created was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Efl.Ui.ListViewLayoutItem _in_item = item;
                            
            try {
                ((ListViewPreciseLayouter)wrapper).ContentCreated( ref _in_item);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                item = _in_item;
                } else {
            efl_ui_list_view_relayout_content_created_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref item);
        }
    }
    private static efl_ui_list_view_relayout_content_created_delegate efl_ui_list_view_relayout_content_created_static_delegate;
}
} } 
