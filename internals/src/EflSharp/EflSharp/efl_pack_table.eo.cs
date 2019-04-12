#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>2D containers aligned on a table with rows and columns</summary>
[PackTableNativeInherit]
public interface PackTable : 
   Efl.PackLinear ,
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Position and span of the <c>subobj</c> in this container, may be modified to move the <c>subobj</c></summary>
/// <param name="subobj">Child object</param>
/// <param name="col">Column number</param>
/// <param name="row">Row number</param>
/// <param name="colspan">Column span</param>
/// <param name="rowspan">Row span</param>
/// <returns>Returns false if item is not a child</returns>
bool GetTablePosition( Efl.Gfx.Entity subobj,  out  int col,  out  int row,  out  int colspan,  out  int rowspan);
   /// <summary>Combines <see cref="Efl.PackTable.TableColumns"/> and <see cref="Efl.PackTable.TableRows"/></summary>
/// <param name="cols">Number of columns</param>
/// <param name="rows">Number of rows</param>
/// <returns></returns>
 void GetTableSize( out  int cols,  out  int rows);
   /// <summary>Combines <see cref="Efl.PackTable.TableColumns"/> and <see cref="Efl.PackTable.TableRows"/></summary>
/// <param name="cols">Number of columns</param>
/// <param name="rows">Number of rows</param>
/// <returns></returns>
 void SetTableSize(  int cols,   int rows);
   /// <summary>Gird columns property</summary>
/// <returns>Number of columns</returns>
 int GetTableColumns();
   /// <summary>Specifies limit for linear adds - if direction is horizontal</summary>
/// <param name="cols">Number of columns</param>
/// <returns></returns>
 void SetTableColumns(  int cols);
   /// <summary>Table rows property</summary>
/// <returns>Number of rows</returns>
 int GetTableRows();
   /// <summary>Specifies limit for linear adds - if direction is vertical</summary>
/// <param name="rows">Number of rows</param>
/// <returns></returns>
 void SetTableRows(  int rows);
   /// <summary>Primary and secondary up/left/right/down directions for linear apis.
/// Default is horizontal and vertical. This overrides <see cref="Efl.Ui.Direction.Direction"/>.</summary>
/// <param name="primary">Primary direction</param>
/// <param name="secondary">Secondary direction</param>
/// <returns></returns>
 void GetTableDirection( out Efl.Ui.Dir primary,  out Efl.Ui.Dir secondary);
   /// <summary>Primary and secondary up/left/right/down directions for linear apis.
/// Default is horizontal and vertical. This overrides <see cref="Efl.Ui.Direction.Direction"/>.</summary>
/// <param name="primary">Primary direction</param>
/// <param name="secondary">Secondary direction</param>
/// <returns></returns>
 void SetTableDirection( Efl.Ui.Dir primary,  Efl.Ui.Dir secondary);
   /// <summary>Pack object at a given location in the table.
/// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
/// <param name="subobj">A child object to pack in this table.</param>
/// <param name="col">Column number</param>
/// <param name="row">Row number</param>
/// <param name="colspan">0 means 1, -1 means <see cref="Efl.PackTable.TableColumns"/></param>
/// <param name="rowspan">0 means 1, -1 means <see cref="Efl.PackTable.TableRows"/></param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool PackTable( Efl.Gfx.Entity subobj,   int col,   int row,   int colspan,   int rowspan);
   /// <summary>Returns all objects at a given position in this table.</summary>
/// <param name="col">Column number</param>
/// <param name="row">Row number</param>
/// <param name="below">If <c>true</c> get objects spanning over this cell.</param>
/// <returns>Iterator to table contents</returns>
Eina.Iterator<Efl.Gfx.Entity> GetTableContents(  int col,   int row,  bool below);
   /// <summary>Returns a child at a given position, see <see cref="Efl.PackTable.GetTableContents"/>.</summary>
/// <param name="col">Column number</param>
/// <param name="row">Row number</param>
/// <returns>Child object</returns>
Efl.Gfx.Entity GetTableContent(  int col,   int row);
                                       /// <summary>Gird columns property</summary>
/// <value>Number of columns</value>
    int TableColumns {
      get ;
      set ;
   }
   /// <summary>Table rows property</summary>
/// <value>Number of rows</value>
    int TableRows {
      get ;
      set ;
   }
}
/// <summary>2D containers aligned on a table with rows and columns</summary>
sealed public class PackTableConcrete : 

PackTable
   , Efl.Container, Efl.Pack, Efl.PackLinear
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (PackTableConcrete))
            return Efl.PackTableNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_pack_table_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public PackTableConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~PackTableConcrete()
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
   public static PackTableConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new PackTableConcrete(obj.NativeHandle);
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
   private readonly object eventLock = new object();
   private Dictionary<string, int> event_cb_count = new Dictionary<string, int>();
   private bool add_cpp_event_handler(string lib, string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(lib, key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
          bool result = Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } 
      event_cb_count[key]++;
      return true;
   }
   private bool remove_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 1) {
         IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
         bool result = Efl.Eo.Globals.efl_event_callback_del(handle, desc, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to remove event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } else if (event_count == 0) {
         Eina.Log.Error($"Trying to remove proxy for event {key} when there is nothing registered.");
         return false;
      } 
      event_cb_count[key]--;
      return true;
   }
private static object ContentAddedEvtKey = new object();
   /// <summary>Sent after a new item was added.</summary>
   public event EventHandler<Efl.ContainerContentAddedEvt_Args> ContentAddedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ContentAddedEvt_delegate)) {
               eventHandlers.AddHandler(ContentAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
            if (remove_cpp_event_handler(key, this.evt_ContentAddedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContentAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContentAddedEvt.</summary>
   public void On_ContentAddedEvt(Efl.ContainerContentAddedEvt_Args e)
   {
      EventHandler<Efl.ContainerContentAddedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ContainerContentAddedEvt_Args>)eventHandlers[ContentAddedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContentAddedEvt_delegate;
   private void on_ContentAddedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ContainerContentAddedEvt_Args args = new Efl.ContainerContentAddedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_ContentAddedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ContentRemovedEvtKey = new object();
   /// <summary>Sent after an item was removed, before unref.</summary>
   public event EventHandler<Efl.ContainerContentRemovedEvt_Args> ContentRemovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ContentRemovedEvt_delegate)) {
               eventHandlers.AddHandler(ContentRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
            if (remove_cpp_event_handler(key, this.evt_ContentRemovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContentRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContentRemovedEvt.</summary>
   public void On_ContentRemovedEvt(Efl.ContainerContentRemovedEvt_Args e)
   {
      EventHandler<Efl.ContainerContentRemovedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ContainerContentRemovedEvt_Args>)eventHandlers[ContentRemovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContentRemovedEvt_delegate;
   private void on_ContentRemovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ContainerContentRemovedEvt_Args args = new Efl.ContainerContentRemovedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_ContentRemovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_ContentAddedEvt_delegate = new Efl.EventCb(on_ContentAddedEvt_NativeCallback);
      evt_ContentRemovedEvt_delegate = new Efl.EventCb(on_ContentRemovedEvt_NativeCallback);
   }
   /// <summary>Position and span of the <c>subobj</c> in this container, may be modified to move the <c>subobj</c></summary>
   /// <param name="subobj">Child object</param>
   /// <param name="col">Column number</param>
   /// <param name="row">Row number</param>
   /// <param name="colspan">Column span</param>
   /// <param name="rowspan">Row span</param>
   /// <returns>Returns false if item is not a child</returns>
   public bool GetTablePosition( Efl.Gfx.Entity subobj,  out  int col,  out  int row,  out  int colspan,  out  int rowspan) {
                                                                                                 var _ret_var = Efl.PackTableNativeInherit.efl_pack_table_position_get_ptr.Value.Delegate(this.NativeHandle, subobj,  out col,  out row,  out colspan,  out rowspan);
      Eina.Error.RaiseIfUnhandledException();
                                                                  return _ret_var;
 }
   /// <summary>Combines <see cref="Efl.PackTable.TableColumns"/> and <see cref="Efl.PackTable.TableRows"/></summary>
   /// <param name="cols">Number of columns</param>
   /// <param name="rows">Number of rows</param>
   /// <returns></returns>
   public  void GetTableSize( out  int cols,  out  int rows) {
                                           Efl.PackTableNativeInherit.efl_pack_table_size_get_ptr.Value.Delegate(this.NativeHandle, out cols,  out rows);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Combines <see cref="Efl.PackTable.TableColumns"/> and <see cref="Efl.PackTable.TableRows"/></summary>
   /// <param name="cols">Number of columns</param>
   /// <param name="rows">Number of rows</param>
   /// <returns></returns>
   public  void SetTableSize(  int cols,   int rows) {
                                           Efl.PackTableNativeInherit.efl_pack_table_size_set_ptr.Value.Delegate(this.NativeHandle, cols,  rows);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Gird columns property</summary>
   /// <returns>Number of columns</returns>
   public  int GetTableColumns() {
       var _ret_var = Efl.PackTableNativeInherit.efl_pack_table_columns_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Specifies limit for linear adds - if direction is horizontal</summary>
   /// <param name="cols">Number of columns</param>
   /// <returns></returns>
   public  void SetTableColumns(  int cols) {
                         Efl.PackTableNativeInherit.efl_pack_table_columns_set_ptr.Value.Delegate(this.NativeHandle, cols);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Table rows property</summary>
   /// <returns>Number of rows</returns>
   public  int GetTableRows() {
       var _ret_var = Efl.PackTableNativeInherit.efl_pack_table_rows_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Specifies limit for linear adds - if direction is vertical</summary>
   /// <param name="rows">Number of rows</param>
   /// <returns></returns>
   public  void SetTableRows(  int rows) {
                         Efl.PackTableNativeInherit.efl_pack_table_rows_set_ptr.Value.Delegate(this.NativeHandle, rows);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Primary and secondary up/left/right/down directions for linear apis.
   /// Default is horizontal and vertical. This overrides <see cref="Efl.Ui.Direction.Direction"/>.</summary>
   /// <param name="primary">Primary direction</param>
   /// <param name="secondary">Secondary direction</param>
   /// <returns></returns>
   public  void GetTableDirection( out Efl.Ui.Dir primary,  out Efl.Ui.Dir secondary) {
                                           Efl.PackTableNativeInherit.efl_pack_table_direction_get_ptr.Value.Delegate(this.NativeHandle, out primary,  out secondary);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Primary and secondary up/left/right/down directions for linear apis.
   /// Default is horizontal and vertical. This overrides <see cref="Efl.Ui.Direction.Direction"/>.</summary>
   /// <param name="primary">Primary direction</param>
   /// <param name="secondary">Secondary direction</param>
   /// <returns></returns>
   public  void SetTableDirection( Efl.Ui.Dir primary,  Efl.Ui.Dir secondary) {
                                           Efl.PackTableNativeInherit.efl_pack_table_direction_set_ptr.Value.Delegate(this.NativeHandle, primary,  secondary);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Pack object at a given location in the table.
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">A child object to pack in this table.</param>
   /// <param name="col">Column number</param>
   /// <param name="row">Row number</param>
   /// <param name="colspan">0 means 1, -1 means <see cref="Efl.PackTable.TableColumns"/></param>
   /// <param name="rowspan">0 means 1, -1 means <see cref="Efl.PackTable.TableRows"/></param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   public bool PackTable( Efl.Gfx.Entity subobj,   int col,   int row,   int colspan,   int rowspan) {
                                                                                                 var _ret_var = Efl.PackTableNativeInherit.efl_pack_table_ptr.Value.Delegate(this.NativeHandle, subobj,  col,  row,  colspan,  rowspan);
      Eina.Error.RaiseIfUnhandledException();
                                                                  return _ret_var;
 }
   /// <summary>Returns all objects at a given position in this table.</summary>
   /// <param name="col">Column number</param>
   /// <param name="row">Row number</param>
   /// <param name="below">If <c>true</c> get objects spanning over this cell.</param>
   /// <returns>Iterator to table contents</returns>
   public Eina.Iterator<Efl.Gfx.Entity> GetTableContents(  int col,   int row,  bool below) {
                                                             var _ret_var = Efl.PackTableNativeInherit.efl_pack_table_contents_get_ptr.Value.Delegate(this.NativeHandle, col,  row,  below);
      Eina.Error.RaiseIfUnhandledException();
                                          return new Eina.Iterator<Efl.Gfx.Entity>(_ret_var, true, false);
 }
   /// <summary>Returns a child at a given position, see <see cref="Efl.PackTable.GetTableContents"/>.</summary>
   /// <param name="col">Column number</param>
   /// <param name="row">Row number</param>
   /// <returns>Child object</returns>
   public Efl.Gfx.Entity GetTableContent(  int col,   int row) {
                                           var _ret_var = Efl.PackTableNativeInherit.efl_pack_table_content_get_ptr.Value.Delegate(this.NativeHandle, col,  row);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Begin iterating over this object&apos;s contents.</summary>
   /// <returns>Iterator to object content</returns>
   public Eina.Iterator<Efl.Gfx.Entity> ContentIterate() {
       var _ret_var = Efl.ContainerNativeInherit.efl_content_iterate_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Gfx.Entity>(_ret_var, true, false);
 }
   /// <summary>Returns the number of UI elements packed in this container.</summary>
   /// <returns>Number of packed UI elements</returns>
   public  int ContentCount() {
       var _ret_var = Efl.ContainerNativeInherit.efl_content_count_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Alignment of the container within its bounds</summary>
   /// <param name="align_horiz">Horizontal alignment</param>
   /// <param name="align_vert">Vertical alignment</param>
   /// <returns></returns>
   public  void GetPackAlign( out double align_horiz,  out double align_vert) {
                                           Efl.PackNativeInherit.efl_pack_align_get_ptr.Value.Delegate(this.NativeHandle, out align_horiz,  out align_vert);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Alignment of the container within its bounds</summary>
   /// <param name="align_horiz">Horizontal alignment</param>
   /// <param name="align_vert">Vertical alignment</param>
   /// <returns></returns>
   public  void SetPackAlign( double align_horiz,  double align_vert) {
                                           Efl.PackNativeInherit.efl_pack_align_set_ptr.Value.Delegate(this.NativeHandle, align_horiz,  align_vert);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Padding between items contained in this object.</summary>
   /// <param name="pad_horiz">Horizontal padding</param>
   /// <param name="pad_vert">Vertical padding</param>
   /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise</param>
   /// <returns></returns>
   public  void GetPackPadding( out double pad_horiz,  out double pad_vert,  out bool scalable) {
                                                             Efl.PackNativeInherit.efl_pack_padding_get_ptr.Value.Delegate(this.NativeHandle, out pad_horiz,  out pad_vert,  out scalable);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Padding between items contained in this object.</summary>
   /// <param name="pad_horiz">Horizontal padding</param>
   /// <param name="pad_vert">Vertical padding</param>
   /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise</param>
   /// <returns></returns>
   public  void SetPackPadding( double pad_horiz,  double pad_vert,  bool scalable) {
                                                             Efl.PackNativeInherit.efl_pack_padding_set_ptr.Value.Delegate(this.NativeHandle, pad_horiz,  pad_vert,  scalable);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Removes all packed contents, and unreferences them.</summary>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   public bool ClearPack() {
       var _ret_var = Efl.PackNativeInherit.efl_pack_clear_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Removes all packed contents, without unreferencing them.
   /// Use with caution.</summary>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   public bool UnpackAll() {
       var _ret_var = Efl.PackNativeInherit.efl_pack_unpack_all_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Removes an existing item from the container, without deleting it.</summary>
   /// <param name="subobj">The unpacked object.</param>
   /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t a child or can&apos;t be removed</returns>
   public bool Unpack( Efl.Gfx.Entity subobj) {
                         var _ret_var = Efl.PackNativeInherit.efl_pack_unpack_ptr.Value.Delegate(this.NativeHandle, subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Adds an item to this container.
   /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
   /// 
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">An object to pack.</param>
   /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
   public bool DoPack( Efl.Gfx.Entity subobj) {
                         var _ret_var = Efl.PackNativeInherit.efl_pack_ptr.Value.Delegate(this.NativeHandle, subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Prepend an object at the beginning of this container.
   /// This is the same as <see cref="Efl.PackLinear.PackAt"/>(<c>subobj</c>, 0).
   /// 
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack.</param>
   /// <returns><c>false</c> if <c>subobj</c> could not be packed</returns>
   public bool PackBegin( Efl.Gfx.Entity subobj) {
                         var _ret_var = Efl.PackLinearNativeInherit.efl_pack_begin_ptr.Value.Delegate(this.NativeHandle, subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Append object at the end of this container.
   /// This is the same as <see cref="Efl.PackLinear.PackAt"/>(<c>subobj</c>, -1).
   /// 
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack at the end.</param>
   /// <returns><c>false</c> if <c>subobj</c> could not be packed</returns>
   public bool PackEnd( Efl.Gfx.Entity subobj) {
                         var _ret_var = Efl.PackLinearNativeInherit.efl_pack_end_ptr.Value.Delegate(this.NativeHandle, subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Prepend item before other sub object.
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack before <c>existing</c>.</param>
   /// <param name="existing">Item to refer to.</param>
   /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
   public bool PackBefore( Efl.Gfx.Entity subobj,  Efl.Gfx.Entity existing) {
                                           var _ret_var = Efl.PackLinearNativeInherit.efl_pack_before_ptr.Value.Delegate(this.NativeHandle, subobj,  existing);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Append item after other sub object.
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack after <c>existing</c>.</param>
   /// <param name="existing">Item to refer to.</param>
   /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
   public bool PackAfter( Efl.Gfx.Entity subobj,  Efl.Gfx.Entity existing) {
                                           var _ret_var = Efl.PackLinearNativeInherit.efl_pack_after_ptr.Value.Delegate(this.NativeHandle, subobj,  existing);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Inserts <c>subobj</c> at the specified <c>index</c>.
   /// Valid range: -<c>count</c> to +<c>count</c>. -1 refers to the last element. Out of range indices will trigger an append.
   /// 
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack at given index.</param>
   /// <param name="index">A position.</param>
   /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
   public bool PackAt( Efl.Gfx.Entity subobj,   int index) {
                                           var _ret_var = Efl.PackLinearNativeInherit.efl_pack_at_ptr.Value.Delegate(this.NativeHandle, subobj,  index);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Content at a given index in this container.
   /// Index -1 refers to the last item. The valid range is -(count - 1) to (count - 1).</summary>
   /// <param name="index">Index number</param>
   /// <returns>The object contained at the given <c>index</c>.</returns>
   public Efl.Gfx.Entity GetPackContent(  int index) {
                         var _ret_var = Efl.PackLinearNativeInherit.efl_pack_content_get_ptr.Value.Delegate(this.NativeHandle, index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Get the index of a child in this container.</summary>
   /// <param name="subobj">An object contained in this pack.</param>
   /// <returns>-1 in case of failure, or the index of this item.</returns>
   public  int GetPackIndex( Efl.Gfx.Entity subobj) {
                         var _ret_var = Efl.PackLinearNativeInherit.efl_pack_index_get_ptr.Value.Delegate(this.NativeHandle, subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Pop out item at specified <c>index</c>.
   /// Equivalent to unpack(content_at(<c>index</c>)).</summary>
   /// <param name="index">Index number</param>
   /// <returns>The child item if it could be removed.</returns>
   public Efl.Gfx.Entity PackUnpackAt(  int index) {
                         var _ret_var = Efl.PackLinearNativeInherit.efl_pack_unpack_at_ptr.Value.Delegate(this.NativeHandle, index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Gird columns property</summary>
/// <value>Number of columns</value>
   public  int TableColumns {
      get { return GetTableColumns(); }
      set { SetTableColumns( value); }
   }
   /// <summary>Table rows property</summary>
/// <value>Number of rows</value>
   public  int TableRows {
      get { return GetTableRows(); }
      set { SetTableRows( value); }
   }
}
public class PackTableNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_pack_table_position_get_static_delegate == null)
      efl_pack_table_position_get_static_delegate = new efl_pack_table_position_get_delegate(table_position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_position_get_static_delegate)});
      if (efl_pack_table_size_get_static_delegate == null)
      efl_pack_table_size_get_static_delegate = new efl_pack_table_size_get_delegate(table_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_size_get_static_delegate)});
      if (efl_pack_table_size_set_static_delegate == null)
      efl_pack_table_size_set_static_delegate = new efl_pack_table_size_set_delegate(table_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_size_set_static_delegate)});
      if (efl_pack_table_columns_get_static_delegate == null)
      efl_pack_table_columns_get_static_delegate = new efl_pack_table_columns_get_delegate(table_columns_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_columns_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_columns_get_static_delegate)});
      if (efl_pack_table_columns_set_static_delegate == null)
      efl_pack_table_columns_set_static_delegate = new efl_pack_table_columns_set_delegate(table_columns_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_columns_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_columns_set_static_delegate)});
      if (efl_pack_table_rows_get_static_delegate == null)
      efl_pack_table_rows_get_static_delegate = new efl_pack_table_rows_get_delegate(table_rows_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_rows_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_rows_get_static_delegate)});
      if (efl_pack_table_rows_set_static_delegate == null)
      efl_pack_table_rows_set_static_delegate = new efl_pack_table_rows_set_delegate(table_rows_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_rows_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_rows_set_static_delegate)});
      if (efl_pack_table_direction_get_static_delegate == null)
      efl_pack_table_direction_get_static_delegate = new efl_pack_table_direction_get_delegate(table_direction_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_direction_get_static_delegate)});
      if (efl_pack_table_direction_set_static_delegate == null)
      efl_pack_table_direction_set_static_delegate = new efl_pack_table_direction_set_delegate(table_direction_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_direction_set_static_delegate)});
      if (efl_pack_table_static_delegate == null)
      efl_pack_table_static_delegate = new efl_pack_table_delegate(pack_table);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_static_delegate)});
      if (efl_pack_table_contents_get_static_delegate == null)
      efl_pack_table_contents_get_static_delegate = new efl_pack_table_contents_get_delegate(table_contents_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_contents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_contents_get_static_delegate)});
      if (efl_pack_table_content_get_static_delegate == null)
      efl_pack_table_content_get_static_delegate = new efl_pack_table_content_get_delegate(table_content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_content_get_static_delegate)});
      if (efl_content_iterate_static_delegate == null)
      efl_content_iterate_static_delegate = new efl_content_iterate_delegate(content_iterate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_content_iterate_static_delegate)});
      if (efl_content_count_static_delegate == null)
      efl_content_count_static_delegate = new efl_content_count_delegate(content_count);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_count"), func = Marshal.GetFunctionPointerForDelegate(efl_content_count_static_delegate)});
      if (efl_pack_align_get_static_delegate == null)
      efl_pack_align_get_static_delegate = new efl_pack_align_get_delegate(pack_align_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_align_get_static_delegate)});
      if (efl_pack_align_set_static_delegate == null)
      efl_pack_align_set_static_delegate = new efl_pack_align_set_delegate(pack_align_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_align_set_static_delegate)});
      if (efl_pack_padding_get_static_delegate == null)
      efl_pack_padding_get_static_delegate = new efl_pack_padding_get_delegate(pack_padding_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_padding_get_static_delegate)});
      if (efl_pack_padding_set_static_delegate == null)
      efl_pack_padding_set_static_delegate = new efl_pack_padding_set_delegate(pack_padding_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_padding_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_padding_set_static_delegate)});
      if (efl_pack_clear_static_delegate == null)
      efl_pack_clear_static_delegate = new efl_pack_clear_delegate(pack_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_clear_static_delegate)});
      if (efl_pack_unpack_all_static_delegate == null)
      efl_pack_unpack_all_static_delegate = new efl_pack_unpack_all_delegate(unpack_all);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_unpack_all"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_all_static_delegate)});
      if (efl_pack_unpack_static_delegate == null)
      efl_pack_unpack_static_delegate = new efl_pack_unpack_delegate(unpack);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_unpack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_static_delegate)});
      if (efl_pack_static_delegate == null)
      efl_pack_static_delegate = new efl_pack_delegate(pack);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_static_delegate)});
      if (efl_pack_begin_static_delegate == null)
      efl_pack_begin_static_delegate = new efl_pack_begin_delegate(pack_begin);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_begin"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_begin_static_delegate)});
      if (efl_pack_end_static_delegate == null)
      efl_pack_end_static_delegate = new efl_pack_end_delegate(pack_end);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_end"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_end_static_delegate)});
      if (efl_pack_before_static_delegate == null)
      efl_pack_before_static_delegate = new efl_pack_before_delegate(pack_before);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_before"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_before_static_delegate)});
      if (efl_pack_after_static_delegate == null)
      efl_pack_after_static_delegate = new efl_pack_after_delegate(pack_after);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_after"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_after_static_delegate)});
      if (efl_pack_at_static_delegate == null)
      efl_pack_at_static_delegate = new efl_pack_at_delegate(pack_at);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_at"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_at_static_delegate)});
      if (efl_pack_content_get_static_delegate == null)
      efl_pack_content_get_static_delegate = new efl_pack_content_get_delegate(pack_content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_content_get_static_delegate)});
      if (efl_pack_index_get_static_delegate == null)
      efl_pack_index_get_static_delegate = new efl_pack_index_get_delegate(pack_index_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_index_get_static_delegate)});
      if (efl_pack_unpack_at_static_delegate == null)
      efl_pack_unpack_at_static_delegate = new efl_pack_unpack_at_delegate(pack_unpack_at);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_unpack_at"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_at_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.PackTableConcrete.efl_pack_table_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.PackTableConcrete.efl_pack_table_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_table_position_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj,   out  int col,   out  int row,   out  int colspan,   out  int rowspan);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_table_position_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj,   out  int col,   out  int row,   out  int colspan,   out  int rowspan);
    public static Efl.Eo.FunctionWrapper<efl_pack_table_position_get_api_delegate> efl_pack_table_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_position_get_api_delegate>(_Module, "efl_pack_table_position_get");
    private static bool table_position_get(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj,  out  int col,  out  int row,  out  int colspan,  out  int rowspan)
   {
      Eina.Log.Debug("function efl_pack_table_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                   col = default( int);      row = default( int);      colspan = default( int);      rowspan = default( int);                                       bool _ret_var = default(bool);
         try {
            _ret_var = ((PackTable)wrapper).GetTablePosition( subobj,  out col,  out row,  out colspan,  out rowspan);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                  return _ret_var;
      } else {
         return efl_pack_table_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  out col,  out row,  out colspan,  out rowspan);
      }
   }
   private static efl_pack_table_position_get_delegate efl_pack_table_position_get_static_delegate;


    private delegate  void efl_pack_table_size_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int cols,   out  int rows);


    public delegate  void efl_pack_table_size_get_api_delegate(System.IntPtr obj,   out  int cols,   out  int rows);
    public static Efl.Eo.FunctionWrapper<efl_pack_table_size_get_api_delegate> efl_pack_table_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_size_get_api_delegate>(_Module, "efl_pack_table_size_get");
    private static  void table_size_get(System.IntPtr obj, System.IntPtr pd,  out  int cols,  out  int rows)
   {
      Eina.Log.Debug("function efl_pack_table_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           cols = default( int);      rows = default( int);                     
         try {
            ((PackTable)wrapper).GetTableSize( out cols,  out rows);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_pack_table_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out cols,  out rows);
      }
   }
   private static efl_pack_table_size_get_delegate efl_pack_table_size_get_static_delegate;


    private delegate  void efl_pack_table_size_set_delegate(System.IntPtr obj, System.IntPtr pd,    int cols,    int rows);


    public delegate  void efl_pack_table_size_set_api_delegate(System.IntPtr obj,    int cols,    int rows);
    public static Efl.Eo.FunctionWrapper<efl_pack_table_size_set_api_delegate> efl_pack_table_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_size_set_api_delegate>(_Module, "efl_pack_table_size_set");
    private static  void table_size_set(System.IntPtr obj, System.IntPtr pd,   int cols,   int rows)
   {
      Eina.Log.Debug("function efl_pack_table_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((PackTable)wrapper).SetTableSize( cols,  rows);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_pack_table_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cols,  rows);
      }
   }
   private static efl_pack_table_size_set_delegate efl_pack_table_size_set_static_delegate;


    private delegate  int efl_pack_table_columns_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_pack_table_columns_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_pack_table_columns_get_api_delegate> efl_pack_table_columns_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_columns_get_api_delegate>(_Module, "efl_pack_table_columns_get");
    private static  int table_columns_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_pack_table_columns_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((PackTable)wrapper).GetTableColumns();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_pack_table_columns_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_pack_table_columns_get_delegate efl_pack_table_columns_get_static_delegate;


    private delegate  void efl_pack_table_columns_set_delegate(System.IntPtr obj, System.IntPtr pd,    int cols);


    public delegate  void efl_pack_table_columns_set_api_delegate(System.IntPtr obj,    int cols);
    public static Efl.Eo.FunctionWrapper<efl_pack_table_columns_set_api_delegate> efl_pack_table_columns_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_columns_set_api_delegate>(_Module, "efl_pack_table_columns_set");
    private static  void table_columns_set(System.IntPtr obj, System.IntPtr pd,   int cols)
   {
      Eina.Log.Debug("function efl_pack_table_columns_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((PackTable)wrapper).SetTableColumns( cols);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_pack_table_columns_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cols);
      }
   }
   private static efl_pack_table_columns_set_delegate efl_pack_table_columns_set_static_delegate;


    private delegate  int efl_pack_table_rows_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_pack_table_rows_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_pack_table_rows_get_api_delegate> efl_pack_table_rows_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_rows_get_api_delegate>(_Module, "efl_pack_table_rows_get");
    private static  int table_rows_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_pack_table_rows_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((PackTable)wrapper).GetTableRows();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_pack_table_rows_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_pack_table_rows_get_delegate efl_pack_table_rows_get_static_delegate;


    private delegate  void efl_pack_table_rows_set_delegate(System.IntPtr obj, System.IntPtr pd,    int rows);


    public delegate  void efl_pack_table_rows_set_api_delegate(System.IntPtr obj,    int rows);
    public static Efl.Eo.FunctionWrapper<efl_pack_table_rows_set_api_delegate> efl_pack_table_rows_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_rows_set_api_delegate>(_Module, "efl_pack_table_rows_set");
    private static  void table_rows_set(System.IntPtr obj, System.IntPtr pd,   int rows)
   {
      Eina.Log.Debug("function efl_pack_table_rows_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((PackTable)wrapper).SetTableRows( rows);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_pack_table_rows_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rows);
      }
   }
   private static efl_pack_table_rows_set_delegate efl_pack_table_rows_set_static_delegate;


    private delegate  void efl_pack_table_direction_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.Ui.Dir primary,   out Efl.Ui.Dir secondary);


    public delegate  void efl_pack_table_direction_get_api_delegate(System.IntPtr obj,   out Efl.Ui.Dir primary,   out Efl.Ui.Dir secondary);
    public static Efl.Eo.FunctionWrapper<efl_pack_table_direction_get_api_delegate> efl_pack_table_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_direction_get_api_delegate>(_Module, "efl_pack_table_direction_get");
    private static  void table_direction_get(System.IntPtr obj, System.IntPtr pd,  out Efl.Ui.Dir primary,  out Efl.Ui.Dir secondary)
   {
      Eina.Log.Debug("function efl_pack_table_direction_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           primary = default(Efl.Ui.Dir);      secondary = default(Efl.Ui.Dir);                     
         try {
            ((PackTable)wrapper).GetTableDirection( out primary,  out secondary);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_pack_table_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out primary,  out secondary);
      }
   }
   private static efl_pack_table_direction_get_delegate efl_pack_table_direction_get_static_delegate;


    private delegate  void efl_pack_table_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Dir primary,   Efl.Ui.Dir secondary);


    public delegate  void efl_pack_table_direction_set_api_delegate(System.IntPtr obj,   Efl.Ui.Dir primary,   Efl.Ui.Dir secondary);
    public static Efl.Eo.FunctionWrapper<efl_pack_table_direction_set_api_delegate> efl_pack_table_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_direction_set_api_delegate>(_Module, "efl_pack_table_direction_set");
    private static  void table_direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir primary,  Efl.Ui.Dir secondary)
   {
      Eina.Log.Debug("function efl_pack_table_direction_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((PackTable)wrapper).SetTableDirection( primary,  secondary);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_pack_table_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  primary,  secondary);
      }
   }
   private static efl_pack_table_direction_set_delegate efl_pack_table_direction_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_table_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj,    int col,    int row,    int colspan,    int rowspan);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_table_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj,    int col,    int row,    int colspan,    int rowspan);
    public static Efl.Eo.FunctionWrapper<efl_pack_table_api_delegate> efl_pack_table_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_api_delegate>(_Module, "efl_pack_table");
    private static bool pack_table(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj,   int col,   int row,   int colspan,   int rowspan)
   {
      Eina.Log.Debug("function efl_pack_table was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            bool _ret_var = default(bool);
         try {
            _ret_var = ((PackTable)wrapper).PackTable( subobj,  col,  row,  colspan,  rowspan);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                  return _ret_var;
      } else {
         return efl_pack_table_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  col,  row,  colspan,  rowspan);
      }
   }
   private static efl_pack_table_delegate efl_pack_table_static_delegate;


    private delegate  System.IntPtr efl_pack_table_contents_get_delegate(System.IntPtr obj, System.IntPtr pd,    int col,    int row,  [MarshalAs(UnmanagedType.U1)]  bool below);


    public delegate  System.IntPtr efl_pack_table_contents_get_api_delegate(System.IntPtr obj,    int col,    int row,  [MarshalAs(UnmanagedType.U1)]  bool below);
    public static Efl.Eo.FunctionWrapper<efl_pack_table_contents_get_api_delegate> efl_pack_table_contents_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_contents_get_api_delegate>(_Module, "efl_pack_table_contents_get");
    private static  System.IntPtr table_contents_get(System.IntPtr obj, System.IntPtr pd,   int col,   int row,  bool below)
   {
      Eina.Log.Debug("function efl_pack_table_contents_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        Eina.Iterator<Efl.Gfx.Entity> _ret_var = default(Eina.Iterator<Efl.Gfx.Entity>);
         try {
            _ret_var = ((PackTable)wrapper).GetTableContents( col,  row,  below);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_pack_table_contents_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  col,  row,  below);
      }
   }
   private static efl_pack_table_contents_get_delegate efl_pack_table_contents_get_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_pack_table_content_get_delegate(System.IntPtr obj, System.IntPtr pd,    int col,    int row);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Entity efl_pack_table_content_get_api_delegate(System.IntPtr obj,    int col,    int row);
    public static Efl.Eo.FunctionWrapper<efl_pack_table_content_get_api_delegate> efl_pack_table_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_content_get_api_delegate>(_Module, "efl_pack_table_content_get");
    private static Efl.Gfx.Entity table_content_get(System.IntPtr obj, System.IntPtr pd,   int col,   int row)
   {
      Eina.Log.Debug("function efl_pack_table_content_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((PackTable)wrapper).GetTableContent( col,  row);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_pack_table_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  col,  row);
      }
   }
   private static efl_pack_table_content_get_delegate efl_pack_table_content_get_static_delegate;


    private delegate  System.IntPtr efl_content_iterate_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_content_iterate_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_content_iterate_api_delegate> efl_content_iterate_ptr = new Efl.Eo.FunctionWrapper<efl_content_iterate_api_delegate>(_Module, "efl_content_iterate");
    private static  System.IntPtr content_iterate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_iterate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.Gfx.Entity> _ret_var = default(Eina.Iterator<Efl.Gfx.Entity>);
         try {
            _ret_var = ((PackTable)wrapper).ContentIterate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_content_iterate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_content_iterate_delegate efl_content_iterate_static_delegate;


    private delegate  int efl_content_count_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_content_count_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_content_count_api_delegate> efl_content_count_ptr = new Efl.Eo.FunctionWrapper<efl_content_count_api_delegate>(_Module, "efl_content_count");
    private static  int content_count(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_count was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((PackTable)wrapper).ContentCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_count_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_content_count_delegate efl_content_count_static_delegate;


    private delegate  void efl_pack_align_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double align_horiz,   out double align_vert);


    public delegate  void efl_pack_align_get_api_delegate(System.IntPtr obj,   out double align_horiz,   out double align_vert);
    public static Efl.Eo.FunctionWrapper<efl_pack_align_get_api_delegate> efl_pack_align_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_align_get_api_delegate>(_Module, "efl_pack_align_get");
    private static  void pack_align_get(System.IntPtr obj, System.IntPtr pd,  out double align_horiz,  out double align_vert)
   {
      Eina.Log.Debug("function efl_pack_align_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           align_horiz = default(double);      align_vert = default(double);                     
         try {
            ((PackTable)wrapper).GetPackAlign( out align_horiz,  out align_vert);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_pack_align_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out align_horiz,  out align_vert);
      }
   }
   private static efl_pack_align_get_delegate efl_pack_align_get_static_delegate;


    private delegate  void efl_pack_align_set_delegate(System.IntPtr obj, System.IntPtr pd,   double align_horiz,   double align_vert);


    public delegate  void efl_pack_align_set_api_delegate(System.IntPtr obj,   double align_horiz,   double align_vert);
    public static Efl.Eo.FunctionWrapper<efl_pack_align_set_api_delegate> efl_pack_align_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_align_set_api_delegate>(_Module, "efl_pack_align_set");
    private static  void pack_align_set(System.IntPtr obj, System.IntPtr pd,  double align_horiz,  double align_vert)
   {
      Eina.Log.Debug("function efl_pack_align_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((PackTable)wrapper).SetPackAlign( align_horiz,  align_vert);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_pack_align_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  align_horiz,  align_vert);
      }
   }
   private static efl_pack_align_set_delegate efl_pack_align_set_static_delegate;


    private delegate  void efl_pack_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double pad_horiz,   out double pad_vert,  [MarshalAs(UnmanagedType.U1)]  out bool scalable);


    public delegate  void efl_pack_padding_get_api_delegate(System.IntPtr obj,   out double pad_horiz,   out double pad_vert,  [MarshalAs(UnmanagedType.U1)]  out bool scalable);
    public static Efl.Eo.FunctionWrapper<efl_pack_padding_get_api_delegate> efl_pack_padding_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_padding_get_api_delegate>(_Module, "efl_pack_padding_get");
    private static  void pack_padding_get(System.IntPtr obj, System.IntPtr pd,  out double pad_horiz,  out double pad_vert,  out bool scalable)
   {
      Eina.Log.Debug("function efl_pack_padding_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                 pad_horiz = default(double);      pad_vert = default(double);      scalable = default(bool);                           
         try {
            ((PackTable)wrapper).GetPackPadding( out pad_horiz,  out pad_vert,  out scalable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_pack_padding_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out pad_horiz,  out pad_vert,  out scalable);
      }
   }
   private static efl_pack_padding_get_delegate efl_pack_padding_get_static_delegate;


    private delegate  void efl_pack_padding_set_delegate(System.IntPtr obj, System.IntPtr pd,   double pad_horiz,   double pad_vert,  [MarshalAs(UnmanagedType.U1)]  bool scalable);


    public delegate  void efl_pack_padding_set_api_delegate(System.IntPtr obj,   double pad_horiz,   double pad_vert,  [MarshalAs(UnmanagedType.U1)]  bool scalable);
    public static Efl.Eo.FunctionWrapper<efl_pack_padding_set_api_delegate> efl_pack_padding_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_padding_set_api_delegate>(_Module, "efl_pack_padding_set");
    private static  void pack_padding_set(System.IntPtr obj, System.IntPtr pd,  double pad_horiz,  double pad_vert,  bool scalable)
   {
      Eina.Log.Debug("function efl_pack_padding_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((PackTable)wrapper).SetPackPadding( pad_horiz,  pad_vert,  scalable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_pack_padding_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pad_horiz,  pad_vert,  scalable);
      }
   }
   private static efl_pack_padding_set_delegate efl_pack_padding_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_clear_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_clear_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_pack_clear_api_delegate> efl_pack_clear_ptr = new Efl.Eo.FunctionWrapper<efl_pack_clear_api_delegate>(_Module, "efl_pack_clear");
    private static bool pack_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_pack_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((PackTable)wrapper).ClearPack();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_pack_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_pack_clear_delegate efl_pack_clear_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_unpack_all_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_unpack_all_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_pack_unpack_all_api_delegate> efl_pack_unpack_all_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_all_api_delegate>(_Module, "efl_pack_unpack_all");
    private static bool unpack_all(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_pack_unpack_all was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((PackTable)wrapper).UnpackAll();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_pack_unpack_all_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_pack_unpack_all_delegate efl_pack_unpack_all_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_unpack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_unpack_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    public static Efl.Eo.FunctionWrapper<efl_pack_unpack_api_delegate> efl_pack_unpack_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_api_delegate>(_Module, "efl_pack_unpack");
    private static bool unpack(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack_unpack was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((PackTable)wrapper).Unpack( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_unpack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private static efl_pack_unpack_delegate efl_pack_unpack_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    public static Efl.Eo.FunctionWrapper<efl_pack_api_delegate> efl_pack_ptr = new Efl.Eo.FunctionWrapper<efl_pack_api_delegate>(_Module, "efl_pack");
    private static bool pack(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((PackTable)wrapper).DoPack( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private static efl_pack_delegate efl_pack_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_begin_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_begin_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    public static Efl.Eo.FunctionWrapper<efl_pack_begin_api_delegate> efl_pack_begin_ptr = new Efl.Eo.FunctionWrapper<efl_pack_begin_api_delegate>(_Module, "efl_pack_begin");
    private static bool pack_begin(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack_begin was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((PackTable)wrapper).PackBegin( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_begin_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private static efl_pack_begin_delegate efl_pack_begin_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_end_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_end_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    public static Efl.Eo.FunctionWrapper<efl_pack_end_api_delegate> efl_pack_end_ptr = new Efl.Eo.FunctionWrapper<efl_pack_end_api_delegate>(_Module, "efl_pack_end");
    private static bool pack_end(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack_end was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((PackTable)wrapper).PackEnd( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_end_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private static efl_pack_end_delegate efl_pack_end_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_before_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity existing);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_before_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity existing);
    public static Efl.Eo.FunctionWrapper<efl_pack_before_api_delegate> efl_pack_before_ptr = new Efl.Eo.FunctionWrapper<efl_pack_before_api_delegate>(_Module, "efl_pack_before");
    private static bool pack_before(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj,  Efl.Gfx.Entity existing)
   {
      Eina.Log.Debug("function efl_pack_before was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((PackTable)wrapper).PackBefore( subobj,  existing);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_pack_before_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  existing);
      }
   }
   private static efl_pack_before_delegate efl_pack_before_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_after_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity existing);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_after_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity existing);
    public static Efl.Eo.FunctionWrapper<efl_pack_after_api_delegate> efl_pack_after_ptr = new Efl.Eo.FunctionWrapper<efl_pack_after_api_delegate>(_Module, "efl_pack_after");
    private static bool pack_after(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj,  Efl.Gfx.Entity existing)
   {
      Eina.Log.Debug("function efl_pack_after was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((PackTable)wrapper).PackAfter( subobj,  existing);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_pack_after_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  existing);
      }
   }
   private static efl_pack_after_delegate efl_pack_after_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_at_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj,    int index);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_at_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj,    int index);
    public static Efl.Eo.FunctionWrapper<efl_pack_at_api_delegate> efl_pack_at_ptr = new Efl.Eo.FunctionWrapper<efl_pack_at_api_delegate>(_Module, "efl_pack_at");
    private static bool pack_at(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj,   int index)
   {
      Eina.Log.Debug("function efl_pack_at was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((PackTable)wrapper).PackAt( subobj,  index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_pack_at_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  index);
      }
   }
   private static efl_pack_at_delegate efl_pack_at_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_pack_content_get_delegate(System.IntPtr obj, System.IntPtr pd,    int index);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Entity efl_pack_content_get_api_delegate(System.IntPtr obj,    int index);
    public static Efl.Eo.FunctionWrapper<efl_pack_content_get_api_delegate> efl_pack_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_content_get_api_delegate>(_Module, "efl_pack_content_get");
    private static Efl.Gfx.Entity pack_content_get(System.IntPtr obj, System.IntPtr pd,   int index)
   {
      Eina.Log.Debug("function efl_pack_content_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((PackTable)wrapper).GetPackContent( index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index);
      }
   }
   private static efl_pack_content_get_delegate efl_pack_content_get_static_delegate;


    private delegate  int efl_pack_index_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);


    public delegate  int efl_pack_index_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    public static Efl.Eo.FunctionWrapper<efl_pack_index_get_api_delegate> efl_pack_index_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_index_get_api_delegate>(_Module, "efl_pack_index_get");
    private static  int pack_index_get(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack_index_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     int _ret_var = default( int);
         try {
            _ret_var = ((PackTable)wrapper).GetPackIndex( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_index_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private static efl_pack_index_get_delegate efl_pack_index_get_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_pack_unpack_at_delegate(System.IntPtr obj, System.IntPtr pd,    int index);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Entity efl_pack_unpack_at_api_delegate(System.IntPtr obj,    int index);
    public static Efl.Eo.FunctionWrapper<efl_pack_unpack_at_api_delegate> efl_pack_unpack_at_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_at_api_delegate>(_Module, "efl_pack_unpack_at");
    private static Efl.Gfx.Entity pack_unpack_at(System.IntPtr obj, System.IntPtr pd,   int index)
   {
      Eina.Log.Debug("function efl_pack_unpack_at was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((PackTable)wrapper).PackUnpackAt( index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_unpack_at_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index);
      }
   }
   private static efl_pack_unpack_at_delegate efl_pack_unpack_at_static_delegate;
}
} 
