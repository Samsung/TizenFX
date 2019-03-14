#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Elm { 
/// <summary></summary>
[WidgetItemContainerNativeInherit]
public interface WidgetItemContainer : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Get the focused widget item.</summary>
/// <returns>Focused item</returns>
Elm.Widget.Item GetFocusedItem();
      /// <summary>Get the focused widget item.</summary>
/// <value>Focused item</value>
   Elm.Widget.Item FocusedItem {
      get ;
   }
}
/// <summary></summary>
sealed public class WidgetItemContainerConcrete : 

WidgetItemContainer
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (WidgetItemContainerConcrete))
            return Elm.WidgetItemContainerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      elm_widget_item_container_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public WidgetItemContainerConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~WidgetItemContainerConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static WidgetItemContainerConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new WidgetItemContainerConcrete(obj.NativeHandle);
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
    void register_event_proxies()
   {
   }
   /// <summary>Get the focused widget item.</summary>
   /// <returns>Focused item</returns>
   public Elm.Widget.Item GetFocusedItem() {
       var _ret_var = Elm.WidgetItemContainerNativeInherit.elm_widget_item_container_focused_item_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the focused widget item.</summary>
/// <value>Focused item</value>
   public Elm.Widget.Item FocusedItem {
      get { return GetFocusedItem(); }
   }
}
public class WidgetItemContainerNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (elm_widget_item_container_focused_item_get_static_delegate == null)
      elm_widget_item_container_focused_item_get_static_delegate = new elm_widget_item_container_focused_item_get_delegate(focused_item_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_widget_item_container_focused_item_get"), func = Marshal.GetFunctionPointerForDelegate(elm_widget_item_container_focused_item_get_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Elm.WidgetItemContainerConcrete.elm_widget_item_container_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Elm.WidgetItemContainerConcrete.elm_widget_item_container_interface_get();
   }


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))] private delegate Elm.Widget.Item elm_widget_item_container_focused_item_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))] public delegate Elm.Widget.Item elm_widget_item_container_focused_item_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_widget_item_container_focused_item_get_api_delegate> elm_widget_item_container_focused_item_get_ptr = new Efl.Eo.FunctionWrapper<elm_widget_item_container_focused_item_get_api_delegate>(_Module, "elm_widget_item_container_focused_item_get");
    private static Elm.Widget.Item focused_item_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_widget_item_container_focused_item_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Elm.Widget.Item _ret_var = default(Elm.Widget.Item);
         try {
            _ret_var = ((WidgetItemContainer)wrapper).GetFocusedItem();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return elm_widget_item_container_focused_item_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_widget_item_container_focused_item_get_delegate elm_widget_item_container_focused_item_get_static_delegate;
}
} 
