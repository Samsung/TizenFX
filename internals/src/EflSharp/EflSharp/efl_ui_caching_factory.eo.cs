#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl Ui Factory that provides object caching.
/// This factory handles caching of one type of object that must be an <see cref="Efl.Gfx.Entity"/> with an <see cref="Efl.Ui.View"/> interface defined. This factory will rely on its parent class <see cref="Efl.Ui.WidgetFactory"/> for creating the subset of class that match <see cref="Efl.Ui.Widget"/> interface. The factory will automatically empties the cache when the application goes into pause.
/// 
/// Creating objects is costly and time consuming, keeping a few on hand for when you next will need them helps a lot. This is what this factory caching infrastructure provides. It will create the object from the class defined on it and set the parent and the model as needed for all created items. The View has to release the Item using the release function of the Factory interface for all of this to work properly.
/// 
/// The cache might decide to flush itself when the application event pause is triggered.</summary>
[CachingFactoryNativeInherit]
public class CachingFactory : Efl.Ui.WidgetFactory, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.CachingFactoryNativeInherit nativeInherit = new Efl.Ui.CachingFactoryNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (CachingFactory))
            return Efl.Ui.CachingFactoryNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_caching_factory_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="itemClass">Define the class of the item returned by this factory. See <see cref="Efl.Ui.WidgetFactory.SetItemClass"/></param>
   public CachingFactory(Efl.Object parent
         , Type itemClass = null) :
      base(efl_ui_caching_factory_class_get(), typeof(CachingFactory), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(itemClass))
         SetItemClass(Efl.Eo.Globals.GetParamHelper(itemClass));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public CachingFactory(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected CachingFactory(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static CachingFactory static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new CachingFactory(obj.NativeHandle);
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
   /// <summary>Define the maxium size in Bytes that all the object waiting on standby in the cache take. They must provide the <see cref="Efl.Cached.Item"/> interface for an accurate accounting.</summary>
   /// <returns>When set to zero, there is no limit on the amount of memory the cache will use.</returns>
   virtual public  uint GetMemoryLimit() {
       var _ret_var = Efl.Ui.CachingFactoryNativeInherit.efl_ui_caching_factory_memory_limit_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Define the maxium size in Bytes that all the object waiting on standby in the cache take. They must provide the <see cref="Efl.Cached.Item"/> interface for an accurate accounting.</summary>
   /// <param name="limit">When set to zero, there is no limit on the amount of memory the cache will use.</param>
   /// <returns></returns>
   virtual public  void SetMemoryLimit(  uint limit) {
                         Efl.Ui.CachingFactoryNativeInherit.efl_ui_caching_factory_memory_limit_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), limit);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Define how many maximum number of items are waiting on standby in the cache.</summary>
   /// <returns>When set to zero, there is no limit to the amount of items stored in the cache.</returns>
   virtual public  uint GetItemsLimit() {
       var _ret_var = Efl.Ui.CachingFactoryNativeInherit.efl_ui_caching_factory_items_limit_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Define how many maximum number of items are waiting on standby in the cache.</summary>
   /// <param name="limit">When set to zero, there is no limit to the amount of items stored in the cache.</param>
   /// <returns></returns>
   virtual public  void SetItemsLimit(  uint limit) {
                         Efl.Ui.CachingFactoryNativeInherit.efl_ui_caching_factory_items_limit_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), limit);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Define the maxium size in Bytes that all the object waiting on standby in the cache take. They must provide the <see cref="Efl.Cached.Item"/> interface for an accurate accounting.</summary>
/// <value>When set to zero, there is no limit on the amount of memory the cache will use.</value>
   public  uint MemoryLimit {
      get { return GetMemoryLimit(); }
      set { SetMemoryLimit( value); }
   }
   /// <summary>Define how many maximum number of items are waiting on standby in the cache.</summary>
/// <value>When set to zero, there is no limit to the amount of items stored in the cache.</value>
   public  uint ItemsLimit {
      get { return GetItemsLimit(); }
      set { SetItemsLimit( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.CachingFactory.efl_ui_caching_factory_class_get();
   }
}
public class CachingFactoryNativeInherit : Efl.Ui.WidgetFactoryNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_caching_factory_memory_limit_get_static_delegate == null)
      efl_ui_caching_factory_memory_limit_get_static_delegate = new efl_ui_caching_factory_memory_limit_get_delegate(memory_limit_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_caching_factory_memory_limit_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_memory_limit_get_static_delegate)});
      if (efl_ui_caching_factory_memory_limit_set_static_delegate == null)
      efl_ui_caching_factory_memory_limit_set_static_delegate = new efl_ui_caching_factory_memory_limit_set_delegate(memory_limit_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_caching_factory_memory_limit_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_memory_limit_set_static_delegate)});
      if (efl_ui_caching_factory_items_limit_get_static_delegate == null)
      efl_ui_caching_factory_items_limit_get_static_delegate = new efl_ui_caching_factory_items_limit_get_delegate(items_limit_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_caching_factory_items_limit_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_items_limit_get_static_delegate)});
      if (efl_ui_caching_factory_items_limit_set_static_delegate == null)
      efl_ui_caching_factory_items_limit_set_static_delegate = new efl_ui_caching_factory_items_limit_set_delegate(items_limit_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_caching_factory_items_limit_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_items_limit_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.CachingFactory.efl_ui_caching_factory_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.CachingFactory.efl_ui_caching_factory_class_get();
   }


    private delegate  uint efl_ui_caching_factory_memory_limit_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  uint efl_ui_caching_factory_memory_limit_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_caching_factory_memory_limit_get_api_delegate> efl_ui_caching_factory_memory_limit_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_caching_factory_memory_limit_get_api_delegate>(_Module, "efl_ui_caching_factory_memory_limit_get");
    private static  uint memory_limit_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_caching_factory_memory_limit_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   uint _ret_var = default( uint);
         try {
            _ret_var = ((CachingFactory)wrapper).GetMemoryLimit();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_caching_factory_memory_limit_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_caching_factory_memory_limit_get_delegate efl_ui_caching_factory_memory_limit_get_static_delegate;


    private delegate  void efl_ui_caching_factory_memory_limit_set_delegate(System.IntPtr obj, System.IntPtr pd,    uint limit);


    public delegate  void efl_ui_caching_factory_memory_limit_set_api_delegate(System.IntPtr obj,    uint limit);
    public static Efl.Eo.FunctionWrapper<efl_ui_caching_factory_memory_limit_set_api_delegate> efl_ui_caching_factory_memory_limit_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_caching_factory_memory_limit_set_api_delegate>(_Module, "efl_ui_caching_factory_memory_limit_set");
    private static  void memory_limit_set(System.IntPtr obj, System.IntPtr pd,   uint limit)
   {
      Eina.Log.Debug("function efl_ui_caching_factory_memory_limit_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((CachingFactory)wrapper).SetMemoryLimit( limit);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_caching_factory_memory_limit_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  limit);
      }
   }
   private static efl_ui_caching_factory_memory_limit_set_delegate efl_ui_caching_factory_memory_limit_set_static_delegate;


    private delegate  uint efl_ui_caching_factory_items_limit_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  uint efl_ui_caching_factory_items_limit_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_caching_factory_items_limit_get_api_delegate> efl_ui_caching_factory_items_limit_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_caching_factory_items_limit_get_api_delegate>(_Module, "efl_ui_caching_factory_items_limit_get");
    private static  uint items_limit_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_caching_factory_items_limit_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   uint _ret_var = default( uint);
         try {
            _ret_var = ((CachingFactory)wrapper).GetItemsLimit();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_caching_factory_items_limit_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_caching_factory_items_limit_get_delegate efl_ui_caching_factory_items_limit_get_static_delegate;


    private delegate  void efl_ui_caching_factory_items_limit_set_delegate(System.IntPtr obj, System.IntPtr pd,    uint limit);


    public delegate  void efl_ui_caching_factory_items_limit_set_api_delegate(System.IntPtr obj,    uint limit);
    public static Efl.Eo.FunctionWrapper<efl_ui_caching_factory_items_limit_set_api_delegate> efl_ui_caching_factory_items_limit_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_caching_factory_items_limit_set_api_delegate>(_Module, "efl_ui_caching_factory_items_limit_set");
    private static  void items_limit_set(System.IntPtr obj, System.IntPtr pd,   uint limit)
   {
      Eina.Log.Debug("function efl_ui_caching_factory_items_limit_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((CachingFactory)wrapper).SetItemsLimit( limit);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_caching_factory_items_limit_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  limit);
      }
   }
   private static efl_ui_caching_factory_items_limit_set_delegate efl_ui_caching_factory_items_limit_set_static_delegate;
}
} } 
