#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Tab Pager class</summary>
[TabPagerNativeInherit]
public class TabPager : Efl.Ui.Pager, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.TabPagerNativeInherit nativeInherit = new Efl.Ui.TabPagerNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (TabPager))
            return Efl.Ui.TabPagerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_tab_pager_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
   public TabPager(Efl.Object parent
         ,  System.String style = null) :
      base(efl_ui_tab_pager_class_get(), typeof(TabPager), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(style))
         SetStyle(Efl.Eo.Globals.GetParamHelper(style));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public TabPager(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected TabPager(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static TabPager static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new TabPager(obj.NativeHandle);
   }
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
   protected override void register_event_proxies()
   {
      base.register_event_proxies();
   }
   /// <summary></summary>
   /// <returns></returns>
   virtual public Efl.Canvas.Object GetTabBar() {
       var _ret_var = Efl.Ui.TabPagerNativeInherit.efl_ui_tab_pager_tab_bar_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary></summary>
   /// <param name="tab_bar"></param>
   /// <returns></returns>
   virtual public  void SetTabBar( Efl.Canvas.Object tab_bar) {
                         Efl.Ui.TabPagerNativeInherit.efl_ui_tab_pager_tab_bar_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), tab_bar);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary></summary>
/// <value></value>
   public Efl.Canvas.Object TabBar {
      get { return GetTabBar(); }
      set { SetTabBar( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.TabPager.efl_ui_tab_pager_class_get();
   }
}
public class TabPagerNativeInherit : Efl.Ui.PagerNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_tab_pager_tab_bar_get_static_delegate == null)
      efl_ui_tab_pager_tab_bar_get_static_delegate = new efl_ui_tab_pager_tab_bar_get_delegate(tab_bar_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tab_pager_tab_bar_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_pager_tab_bar_get_static_delegate)});
      if (efl_ui_tab_pager_tab_bar_set_static_delegate == null)
      efl_ui_tab_pager_tab_bar_set_static_delegate = new efl_ui_tab_pager_tab_bar_set_delegate(tab_bar_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tab_pager_tab_bar_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_pager_tab_bar_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.TabPager.efl_ui_tab_pager_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.TabPager.efl_ui_tab_pager_class_get();
   }


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_ui_tab_pager_tab_bar_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Object efl_ui_tab_pager_tab_bar_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_tab_pager_tab_bar_get_api_delegate> efl_ui_tab_pager_tab_bar_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_pager_tab_bar_get_api_delegate>(_Module, "efl_ui_tab_pager_tab_bar_get");
    private static Efl.Canvas.Object tab_bar_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_tab_pager_tab_bar_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((TabPager)wrapper).GetTabBar();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_tab_pager_tab_bar_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_tab_pager_tab_bar_get_delegate efl_ui_tab_pager_tab_bar_get_static_delegate;


    private delegate  void efl_ui_tab_pager_tab_bar_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object tab_bar);


    public delegate  void efl_ui_tab_pager_tab_bar_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object tab_bar);
    public static Efl.Eo.FunctionWrapper<efl_ui_tab_pager_tab_bar_set_api_delegate> efl_ui_tab_pager_tab_bar_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_pager_tab_bar_set_api_delegate>(_Module, "efl_ui_tab_pager_tab_bar_set");
    private static  void tab_bar_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object tab_bar)
   {
      Eina.Log.Debug("function efl_ui_tab_pager_tab_bar_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TabPager)wrapper).SetTabBar( tab_bar);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_tab_pager_tab_bar_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  tab_bar);
      }
   }
   private static efl_ui_tab_pager_tab_bar_set_delegate efl_ui_tab_pager_tab_bar_set_static_delegate;
}
} } 
