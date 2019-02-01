#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary></summary>
[DndContainerConcreteNativeInherit]
public interface DndContainer : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>The time since mouse down happens to drag starts.</summary>
/// <returns>The drag delay time</returns>
double GetDragDelayTime();
   /// <summary>The time since mouse down happens to drag starts.</summary>
/// <param name="time">The drag delay time</param>
/// <returns></returns>
 void SetDragDelayTime( double time);
   /// <summary>This registers a drag for items in a container. Many items can be dragged at a time. During dragging, there are three events emitted: EFL_DND_EVENT_DRAG_POS, EFL_DND_EVENT_DRAG_ACCEPT, EFL_DND_EVENT_DRAG_DONE.</summary>
/// <param name="data_func">Data and its format</param>
/// <param name="item_func">Item to determine drag start</param>
/// <param name="icon_func">Icon used during drag</param>
/// <param name="icon_list_func">Icons used for animations CHECKING</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns></returns>
 void AddDragItem( Efl.Dnd.DragDataGet data_func,  Efl.Dnd.ItemGet item_func,  Efl.Dnd.DragIconCreate icon_func,  Efl.Dnd.DragIconListCreate icon_list_func,   uint seat);
   /// <summary>Remove drag function of items in the container object.</summary>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns></returns>
 void DelDragItem(  uint seat);
   /// <summary></summary>
/// <param name="format">Accepted data formats</param>
/// <param name="item_func">Get item at specific position</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns></returns>
 void AddDropItem( Efl.Ui.SelectionFormat format,  Efl.Dnd.ItemGet item_func,   uint seat);
   /// <summary></summary>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns></returns>
 void DelDropItem(  uint seat);
                     /// <summary>The time since mouse down happens to drag starts.</summary>
   double DragDelayTime {
      get ;
      set ;
   }
}
/// <summary></summary>
sealed public class DndContainerConcrete : 

DndContainer
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (DndContainerConcrete))
            return Efl.Ui.DndContainerConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_dnd_container_mixin_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public DndContainerConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~DndContainerConcrete()
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
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static DndContainerConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new DndContainerConcrete(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern double efl_ui_dnd_container_drag_delay_time_get(System.IntPtr obj);
   /// <summary>The time since mouse down happens to drag starts.</summary>
   /// <returns>The drag delay time</returns>
   public double GetDragDelayTime() {
       var _ret_var = efl_ui_dnd_container_drag_delay_time_get(Efl.Ui.DndContainerConcrete.efl_ui_dnd_container_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_dnd_container_drag_delay_time_set(System.IntPtr obj,   double time);
   /// <summary>The time since mouse down happens to drag starts.</summary>
   /// <param name="time">The drag delay time</param>
   /// <returns></returns>
   public  void SetDragDelayTime( double time) {
                         efl_ui_dnd_container_drag_delay_time_set(Efl.Ui.DndContainerConcrete.efl_ui_dnd_container_mixin_get(),  time);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_dnd_container_drag_item_add(System.IntPtr obj,  IntPtr data_func_data, Efl.Dnd.DragDataGetInternal data_func, EinaFreeCb data_func_free_cb,  IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,  IntPtr icon_list_func_data, Efl.Dnd.DragIconListCreateInternal icon_list_func, EinaFreeCb icon_list_func_free_cb,    uint seat);
   /// <summary>This registers a drag for items in a container. Many items can be dragged at a time. During dragging, there are three events emitted: EFL_DND_EVENT_DRAG_POS, EFL_DND_EVENT_DRAG_ACCEPT, EFL_DND_EVENT_DRAG_DONE.</summary>
   /// <param name="data_func">Data and its format</param>
   /// <param name="item_func">Item to determine drag start</param>
   /// <param name="icon_func">Icon used during drag</param>
   /// <param name="icon_list_func">Icons used for animations CHECKING</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   public  void AddDragItem( Efl.Dnd.DragDataGet data_func,  Efl.Dnd.ItemGet item_func,  Efl.Dnd.DragIconCreate icon_func,  Efl.Dnd.DragIconListCreate icon_list_func,   uint seat) {
                                                                   GCHandle data_func_handle = GCHandle.Alloc(data_func);
      GCHandle item_func_handle = GCHandle.Alloc(item_func);
      GCHandle icon_func_handle = GCHandle.Alloc(icon_func);
      GCHandle icon_list_func_handle = GCHandle.Alloc(icon_list_func);
            efl_ui_dnd_container_drag_item_add(Efl.Ui.DndContainerConcrete.efl_ui_dnd_container_mixin_get(), GCHandle.ToIntPtr(data_func_handle), Efl.Dnd.DragDataGetWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(item_func_handle), Efl.Dnd.ItemGetWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(icon_func_handle), Efl.Dnd.DragIconCreateWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(icon_list_func_handle), Efl.Dnd.DragIconListCreateWrapper.Cb, Efl.Eo.Globals.free_gchandle,  seat);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_dnd_container_drag_item_del(System.IntPtr obj,    uint seat);
   /// <summary>Remove drag function of items in the container object.</summary>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   public  void DelDragItem(  uint seat) {
                         efl_ui_dnd_container_drag_item_del(Efl.Ui.DndContainerConcrete.efl_ui_dnd_container_mixin_get(),  seat);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_dnd_container_drop_item_add(System.IntPtr obj,   Efl.Ui.SelectionFormat format,  IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,    uint seat);
   /// <summary></summary>
   /// <param name="format">Accepted data formats</param>
   /// <param name="item_func">Get item at specific position</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   public  void AddDropItem( Efl.Ui.SelectionFormat format,  Efl.Dnd.ItemGet item_func,   uint seat) {
                                                 GCHandle item_func_handle = GCHandle.Alloc(item_func);
            efl_ui_dnd_container_drop_item_add(Efl.Ui.DndContainerConcrete.efl_ui_dnd_container_mixin_get(),  format, GCHandle.ToIntPtr(item_func_handle), Efl.Dnd.ItemGetWrapper.Cb, Efl.Eo.Globals.free_gchandle,  seat);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_dnd_container_drop_item_del(System.IntPtr obj,    uint seat);
   /// <summary></summary>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   public  void DelDropItem(  uint seat) {
                         efl_ui_dnd_container_drop_item_del(Efl.Ui.DndContainerConcrete.efl_ui_dnd_container_mixin_get(),  seat);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The time since mouse down happens to drag starts.</summary>
   public double DragDelayTime {
      get { return GetDragDelayTime(); }
      set { SetDragDelayTime( value); }
   }
}
public class DndContainerConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_dnd_container_drag_delay_time_get_static_delegate = new efl_ui_dnd_container_drag_delay_time_get_delegate(drag_delay_time_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_dnd_container_drag_delay_time_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_container_drag_delay_time_get_static_delegate)});
      efl_ui_dnd_container_drag_delay_time_set_static_delegate = new efl_ui_dnd_container_drag_delay_time_set_delegate(drag_delay_time_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_dnd_container_drag_delay_time_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_container_drag_delay_time_set_static_delegate)});
      efl_ui_dnd_container_drag_item_add_static_delegate = new efl_ui_dnd_container_drag_item_add_delegate(drag_item_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_dnd_container_drag_item_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_container_drag_item_add_static_delegate)});
      efl_ui_dnd_container_drag_item_del_static_delegate = new efl_ui_dnd_container_drag_item_del_delegate(drag_item_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_dnd_container_drag_item_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_container_drag_item_del_static_delegate)});
      efl_ui_dnd_container_drop_item_add_static_delegate = new efl_ui_dnd_container_drop_item_add_delegate(drop_item_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_dnd_container_drop_item_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_container_drop_item_add_static_delegate)});
      efl_ui_dnd_container_drop_item_del_static_delegate = new efl_ui_dnd_container_drop_item_del_delegate(drop_item_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_dnd_container_drop_item_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_container_drop_item_del_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.DndContainerConcrete.efl_ui_dnd_container_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.DndContainerConcrete.efl_ui_dnd_container_mixin_get();
   }


    private delegate double efl_ui_dnd_container_drag_delay_time_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern double efl_ui_dnd_container_drag_delay_time_get(System.IntPtr obj);
    private static double drag_delay_time_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_dnd_container_drag_delay_time_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((DndContainerConcrete)wrapper).GetDragDelayTime();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_dnd_container_drag_delay_time_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_dnd_container_drag_delay_time_get_delegate efl_ui_dnd_container_drag_delay_time_get_static_delegate;


    private delegate  void efl_ui_dnd_container_drag_delay_time_set_delegate(System.IntPtr obj, System.IntPtr pd,   double time);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_dnd_container_drag_delay_time_set(System.IntPtr obj,   double time);
    private static  void drag_delay_time_set(System.IntPtr obj, System.IntPtr pd,  double time)
   {
      Eina.Log.Debug("function efl_ui_dnd_container_drag_delay_time_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((DndContainerConcrete)wrapper).SetDragDelayTime( time);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_dnd_container_drag_delay_time_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  time);
      }
   }
   private efl_ui_dnd_container_drag_delay_time_set_delegate efl_ui_dnd_container_drag_delay_time_set_static_delegate;


    private delegate  void efl_ui_dnd_container_drag_item_add_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr data_func_data, Efl.Dnd.DragDataGetInternal data_func, EinaFreeCb data_func_free_cb,  IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,  IntPtr icon_list_func_data, Efl.Dnd.DragIconListCreateInternal icon_list_func, EinaFreeCb icon_list_func_free_cb,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_dnd_container_drag_item_add(System.IntPtr obj,  IntPtr data_func_data, Efl.Dnd.DragDataGetInternal data_func, EinaFreeCb data_func_free_cb,  IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,  IntPtr icon_list_func_data, Efl.Dnd.DragIconListCreateInternal icon_list_func, EinaFreeCb icon_list_func_free_cb,    uint seat);
    private static  void drag_item_add(System.IntPtr obj, System.IntPtr pd, IntPtr data_func_data, Efl.Dnd.DragDataGetInternal data_func, EinaFreeCb data_func_free_cb, IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb, IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb, IntPtr icon_list_func_data, Efl.Dnd.DragIconListCreateInternal icon_list_func, EinaFreeCb icon_list_func_free_cb,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_dnd_container_drag_item_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                              Efl.Dnd.DragDataGetWrapper data_func_wrapper = new Efl.Dnd.DragDataGetWrapper(data_func, data_func_data, data_func_free_cb);
         Efl.Dnd.ItemGetWrapper item_func_wrapper = new Efl.Dnd.ItemGetWrapper(item_func, item_func_data, item_func_free_cb);
         Efl.Dnd.DragIconCreateWrapper icon_func_wrapper = new Efl.Dnd.DragIconCreateWrapper(icon_func, icon_func_data, icon_func_free_cb);
         Efl.Dnd.DragIconListCreateWrapper icon_list_func_wrapper = new Efl.Dnd.DragIconListCreateWrapper(icon_list_func, icon_list_func_data, icon_list_func_free_cb);
               
         try {
            ((DndContainerConcrete)wrapper).AddDragItem( data_func_wrapper.ManagedCb,  item_func_wrapper.ManagedCb,  icon_func_wrapper.ManagedCb,  icon_list_func_wrapper.ManagedCb,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_ui_dnd_container_drag_item_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), data_func_data, data_func, data_func_free_cb, item_func_data, item_func, item_func_free_cb, icon_func_data, icon_func, icon_func_free_cb, icon_list_func_data, icon_list_func, icon_list_func_free_cb,  seat);
      }
   }
   private efl_ui_dnd_container_drag_item_add_delegate efl_ui_dnd_container_drag_item_add_static_delegate;


    private delegate  void efl_ui_dnd_container_drag_item_del_delegate(System.IntPtr obj, System.IntPtr pd,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_dnd_container_drag_item_del(System.IntPtr obj,    uint seat);
    private static  void drag_item_del(System.IntPtr obj, System.IntPtr pd,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_dnd_container_drag_item_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((DndContainerConcrete)wrapper).DelDragItem( seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_dnd_container_drag_item_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private efl_ui_dnd_container_drag_item_del_delegate efl_ui_dnd_container_drag_item_del_static_delegate;


    private delegate  void efl_ui_dnd_container_drop_item_add_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionFormat format,  IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_dnd_container_drop_item_add(System.IntPtr obj,   Efl.Ui.SelectionFormat format,  IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,    uint seat);
    private static  void drop_item_add(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format, IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_dnd_container_drop_item_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                            Efl.Dnd.ItemGetWrapper item_func_wrapper = new Efl.Dnd.ItemGetWrapper(item_func, item_func_data, item_func_free_cb);
               
         try {
            ((DndContainerConcrete)wrapper).AddDropItem( format,  item_func_wrapper.ManagedCb,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_ui_dnd_container_drop_item_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  format, item_func_data, item_func, item_func_free_cb,  seat);
      }
   }
   private efl_ui_dnd_container_drop_item_add_delegate efl_ui_dnd_container_drop_item_add_static_delegate;


    private delegate  void efl_ui_dnd_container_drop_item_del_delegate(System.IntPtr obj, System.IntPtr pd,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_dnd_container_drop_item_del(System.IntPtr obj,    uint seat);
    private static  void drop_item_del(System.IntPtr obj, System.IntPtr pd,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_dnd_container_drop_item_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((DndContainerConcrete)wrapper).DelDropItem( seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_dnd_container_drop_item_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private efl_ui_dnd_container_drop_item_del_delegate efl_ui_dnd_container_drop_item_del_static_delegate;
}
} } 
