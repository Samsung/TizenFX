#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Access { 
/// <summary>Elementary access selection interface</summary>
[SelectionConcreteNativeInherit]
public interface Selection : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Gets the number of currently selected children</summary>
/// <returns>Number of currently selected children</returns>
 int GetSelectedChildrenCount();
   /// <summary>Gets child for given child index</summary>
/// <param name="selected_child_index">Index of child</param>
/// <returns>Child object</returns>
Efl.Object GetSelectedChild(  int selected_child_index);
   /// <summary>Adds selection for given child index</summary>
/// <param name="child_index">Index of child</param>
/// <returns><c>true</c> if selection was added, <c>false</c> otherwise</returns>
bool ChildSelect(  int child_index);
   /// <summary>Removes selection for given child index</summary>
/// <param name="child_index">Index of child</param>
/// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
bool SelectedChildDeselect(  int child_index);
   /// <summary>Determines if child specified by index is selected</summary>
/// <param name="child_index">Index of child</param>
/// <returns><c>true</c> if child is selected, <c>false</c> otherwise</returns>
bool IsChildSelected(  int child_index);
   /// <summary>Adds selection for all children</summary>
/// <returns><c>true</c> if selection was added to all children, <c>false</c> otherwise</returns>
bool AllChildrenSelect();
   /// <summary>Clears the current selection</summary>
/// <returns><c>true</c> if selection was cleared, <c>false</c> otherwise</returns>
bool ClearAccessSelection();
   /// <summary>Removes selection for given child index</summary>
/// <param name="child_index">Index of child</param>
/// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
bool ChildDeselect(  int child_index);
                           /// <summary>Called when selection has been changed.</summary>
   event EventHandler SelectionChangedEvt;
   /// <summary>Gets the number of currently selected children</summary>
    int SelectedChildrenCount {
      get ;
   }
}
/// <summary>Elementary access selection interface</summary>
sealed public class SelectionConcrete : 

Selection
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (SelectionConcrete))
            return Efl.Access.SelectionConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_access_selection_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public SelectionConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~SelectionConcrete()
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
   public static SelectionConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new SelectionConcrete(obj.NativeHandle);
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
   private bool add_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(key);
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
         IntPtr desc = Efl.EventDescription.GetNative(key);
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
private static object SelectionChangedEvtKey = new object();
   /// <summary>Called when selection has been changed.</summary>
   public event EventHandler SelectionChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_SELECTION_EVENT_SELECTION_CHANGED";
            if (add_cpp_event_handler(key, this.evt_SelectionChangedEvt_delegate)) {
               eventHandlers.AddHandler(SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_SELECTION_EVENT_SELECTION_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_SelectionChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectionChangedEvt.</summary>
   public void On_SelectionChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SelectionChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectionChangedEvt_delegate;
   private void on_SelectionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SelectionChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_SelectionChangedEvt_delegate = new Efl.EventCb(on_SelectionChangedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  int efl_access_selection_selected_children_count_get(System.IntPtr obj);
   /// <summary>Gets the number of currently selected children</summary>
   /// <returns>Number of currently selected children</returns>
   public  int GetSelectedChildrenCount() {
       var _ret_var = efl_access_selection_selected_children_count_get(Efl.Access.SelectionConcrete.efl_access_selection_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_access_selection_selected_child_get(System.IntPtr obj,    int selected_child_index);
   /// <summary>Gets child for given child index</summary>
   /// <param name="selected_child_index">Index of child</param>
   /// <returns>Child object</returns>
   public Efl.Object GetSelectedChild(  int selected_child_index) {
                         var _ret_var = efl_access_selection_selected_child_get(Efl.Access.SelectionConcrete.efl_access_selection_interface_get(),  selected_child_index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_child_select(System.IntPtr obj,    int child_index);
   /// <summary>Adds selection for given child index</summary>
   /// <param name="child_index">Index of child</param>
   /// <returns><c>true</c> if selection was added, <c>false</c> otherwise</returns>
   public bool ChildSelect(  int child_index) {
                         var _ret_var = efl_access_selection_child_select(Efl.Access.SelectionConcrete.efl_access_selection_interface_get(),  child_index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_selected_child_deselect(System.IntPtr obj,    int child_index);
   /// <summary>Removes selection for given child index</summary>
   /// <param name="child_index">Index of child</param>
   /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
   public bool SelectedChildDeselect(  int child_index) {
                         var _ret_var = efl_access_selection_selected_child_deselect(Efl.Access.SelectionConcrete.efl_access_selection_interface_get(),  child_index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_is_child_selected(System.IntPtr obj,    int child_index);
   /// <summary>Determines if child specified by index is selected</summary>
   /// <param name="child_index">Index of child</param>
   /// <returns><c>true</c> if child is selected, <c>false</c> otherwise</returns>
   public bool IsChildSelected(  int child_index) {
                         var _ret_var = efl_access_selection_is_child_selected(Efl.Access.SelectionConcrete.efl_access_selection_interface_get(),  child_index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_all_children_select(System.IntPtr obj);
   /// <summary>Adds selection for all children</summary>
   /// <returns><c>true</c> if selection was added to all children, <c>false</c> otherwise</returns>
   public bool AllChildrenSelect() {
       var _ret_var = efl_access_selection_all_children_select(Efl.Access.SelectionConcrete.efl_access_selection_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_clear(System.IntPtr obj);
   /// <summary>Clears the current selection</summary>
   /// <returns><c>true</c> if selection was cleared, <c>false</c> otherwise</returns>
   public bool ClearAccessSelection() {
       var _ret_var = efl_access_selection_clear(Efl.Access.SelectionConcrete.efl_access_selection_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_child_deselect(System.IntPtr obj,    int child_index);
   /// <summary>Removes selection for given child index</summary>
   /// <param name="child_index">Index of child</param>
   /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
   public bool ChildDeselect(  int child_index) {
                         var _ret_var = efl_access_selection_child_deselect(Efl.Access.SelectionConcrete.efl_access_selection_interface_get(),  child_index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Gets the number of currently selected children</summary>
   public  int SelectedChildrenCount {
      get { return GetSelectedChildrenCount(); }
   }
}
public class SelectionConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_access_selection_selected_children_count_get_static_delegate = new efl_access_selection_selected_children_count_get_delegate(selected_children_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_selected_children_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_selected_children_count_get_static_delegate)});
      efl_access_selection_selected_child_get_static_delegate = new efl_access_selection_selected_child_get_delegate(selected_child_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_selected_child_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_selected_child_get_static_delegate)});
      efl_access_selection_child_select_static_delegate = new efl_access_selection_child_select_delegate(child_select);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_child_select"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_child_select_static_delegate)});
      efl_access_selection_selected_child_deselect_static_delegate = new efl_access_selection_selected_child_deselect_delegate(selected_child_deselect);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_selected_child_deselect"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_selected_child_deselect_static_delegate)});
      efl_access_selection_is_child_selected_static_delegate = new efl_access_selection_is_child_selected_delegate(is_child_selected);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_is_child_selected"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_is_child_selected_static_delegate)});
      efl_access_selection_all_children_select_static_delegate = new efl_access_selection_all_children_select_delegate(all_children_select);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_all_children_select"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_all_children_select_static_delegate)});
      efl_access_selection_clear_static_delegate = new efl_access_selection_clear_delegate(access_selection_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_clear_static_delegate)});
      efl_access_selection_child_deselect_static_delegate = new efl_access_selection_child_deselect_delegate(child_deselect);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_child_deselect"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_child_deselect_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Access.SelectionConcrete.efl_access_selection_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Access.SelectionConcrete.efl_access_selection_interface_get();
   }


    private delegate  int efl_access_selection_selected_children_count_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  int efl_access_selection_selected_children_count_get(System.IntPtr obj);
    private static  int selected_children_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_selection_selected_children_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Selection)wrapper).GetSelectedChildrenCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_selection_selected_children_count_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_selection_selected_children_count_get_delegate efl_access_selection_selected_children_count_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_access_selection_selected_child_get_delegate(System.IntPtr obj, System.IntPtr pd,    int selected_child_index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_access_selection_selected_child_get(System.IntPtr obj,    int selected_child_index);
    private static Efl.Object selected_child_get(System.IntPtr obj, System.IntPtr pd,   int selected_child_index)
   {
      Eina.Log.Debug("function efl_access_selection_selected_child_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((Selection)wrapper).GetSelectedChild( selected_child_index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_selection_selected_child_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  selected_child_index);
      }
   }
   private efl_access_selection_selected_child_get_delegate efl_access_selection_selected_child_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_selection_child_select_delegate(System.IntPtr obj, System.IntPtr pd,    int child_index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_child_select(System.IntPtr obj,    int child_index);
    private static bool child_select(System.IntPtr obj, System.IntPtr pd,   int child_index)
   {
      Eina.Log.Debug("function efl_access_selection_child_select was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Selection)wrapper).ChildSelect( child_index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_selection_child_select(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child_index);
      }
   }
   private efl_access_selection_child_select_delegate efl_access_selection_child_select_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_selection_selected_child_deselect_delegate(System.IntPtr obj, System.IntPtr pd,    int child_index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_selected_child_deselect(System.IntPtr obj,    int child_index);
    private static bool selected_child_deselect(System.IntPtr obj, System.IntPtr pd,   int child_index)
   {
      Eina.Log.Debug("function efl_access_selection_selected_child_deselect was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Selection)wrapper).SelectedChildDeselect( child_index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_selection_selected_child_deselect(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child_index);
      }
   }
   private efl_access_selection_selected_child_deselect_delegate efl_access_selection_selected_child_deselect_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_selection_is_child_selected_delegate(System.IntPtr obj, System.IntPtr pd,    int child_index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_is_child_selected(System.IntPtr obj,    int child_index);
    private static bool is_child_selected(System.IntPtr obj, System.IntPtr pd,   int child_index)
   {
      Eina.Log.Debug("function efl_access_selection_is_child_selected was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Selection)wrapper).IsChildSelected( child_index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_selection_is_child_selected(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child_index);
      }
   }
   private efl_access_selection_is_child_selected_delegate efl_access_selection_is_child_selected_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_selection_all_children_select_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_all_children_select(System.IntPtr obj);
    private static bool all_children_select(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_selection_all_children_select was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Selection)wrapper).AllChildrenSelect();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_selection_all_children_select(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_selection_all_children_select_delegate efl_access_selection_all_children_select_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_selection_clear_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_clear(System.IntPtr obj);
    private static bool access_selection_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_selection_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Selection)wrapper).ClearAccessSelection();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_selection_clear(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_selection_clear_delegate efl_access_selection_clear_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_selection_child_deselect_delegate(System.IntPtr obj, System.IntPtr pd,    int child_index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_child_deselect(System.IntPtr obj,    int child_index);
    private static bool child_deselect(System.IntPtr obj, System.IntPtr pd,   int child_index)
   {
      Eina.Log.Debug("function efl_access_selection_child_deselect was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Selection)wrapper).ChildDeselect( child_index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_selection_child_deselect(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child_index);
      }
   }
   private efl_access_selection_child_deselect_delegate efl_access_selection_child_deselect_static_delegate;
}
} } 
