#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Access { 
public struct StateSet {
   private  ulong payload;
   public static implicit operator StateSet( ulong x)
   {
      return new StateSet{payload=x};
   }
   public static implicit operator  ulong(StateSet x)
   {
      return x.payload;
   }
}
} } 
namespace Efl { namespace Access { 
public struct RelationSet {
   private Eina.List<Efl.Access.Relation> payload;
   public static implicit operator RelationSet(Eina.List<Efl.Access.Relation> x)
   {
      return new RelationSet{payload=x};
   }
   public static implicit operator Eina.List<Efl.Access.Relation>(RelationSet x)
   {
      return x.payload;
   }
}
} } 
namespace Efl { namespace Access { 
/// <summary>Accessibility accessible mixin</summary>
[ObjectNativeInherit]
public interface Object : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Gets an localized string describing accessible object role name.</summary>
/// <returns>Localized accessible object role name</returns>
 System.String GetLocalizedRoleName();
   /// <summary>Accessible name of the object.</summary>
/// <returns>Accessible name</returns>
 System.String GetI18nName();
   /// <summary>Accessible name of the object.</summary>
/// <param name="i18n_name">Accessible name</param>
/// <returns></returns>
 void SetI18nName(  System.String i18n_name);
   /// <summary>Sets name information callback about widget.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <param name="name_cb">reading information callback</param>
/// <param name="data"></param>
/// <returns></returns>
 void SetNameCb( Efl.Access.ReadingInfoCb name_cb,   System.IntPtr data);
   /// <summary>Gets an all relations between accessible object and other accessible objects.</summary>
/// <returns>Accessible relation set</returns>
Efl.Access.RelationSet GetRelationSet();
   /// <summary>The role of the object in accessibility domain.</summary>
/// <returns>Accessible role</returns>
Efl.Access.Role GetRole();
   /// <summary>Sets the role of the object in accessibility domain.</summary>
/// <param name="role">Accessible role</param>
/// <returns></returns>
 void SetRole( Efl.Access.Role role);
   /// <summary>Gets object&apos;s accessible parent.</summary>
/// <returns>Accessible parent</returns>
Efl.Access.Object GetAccessParent();
   /// <summary>Gets object&apos;s accessible parent.</summary>
/// <param name="parent">Accessible parent</param>
/// <returns></returns>
 void SetAccessParent( Efl.Access.Object parent);
   /// <summary>Sets contextual information callback about widget.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <param name="description_cb">The function called to provide the accessible description.</param>
/// <param name="data">The data passed to @c description_cb.</param>
/// <returns></returns>
 void SetDescriptionCb( Efl.Access.ReadingInfoCb description_cb,   System.IntPtr data);
   /// <summary>Sets gesture callback to give widget.
/// Warning: Please do not abuse this API. The purpose of this API is to support special application such as screen-reader guidance. Before using this API, please check if there is another way.
/// 
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <param name="gesture_cb"></param>
/// <param name="data"></param>
/// <returns></returns>
 void SetGestureCb( Efl.Access.GestureCb gesture_cb,   System.IntPtr data);
   /// <summary>Gets object&apos;s accessible children.</summary>
/// <returns>List of widget&apos;s children</returns>
Eina.List<Efl.Access.Object> GetAccessChildren();
   /// <summary>Gets human-readable string indentifying object accessibility role.</summary>
/// <returns>Accessible role name</returns>
 System.String GetRoleName();
   /// <summary>Gets key-value pairs indentifying object extra attributes. Must be free by a user.</summary>
/// <returns>List of object attributes, Must be freed by the user</returns>
Eina.List<Efl.Access.Attribute> GetAttributes();
   /// <summary>Gets reading information types of an accessible object.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <returns>Reading information types</returns>
Efl.Access.ReadingInfoTypeMask GetReadingInfoType();
   /// <summary>Sets reading information of an accessible object.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <param name="reading_info">Reading information types</param>
/// <returns></returns>
 void SetReadingInfoType( Efl.Access.ReadingInfoTypeMask reading_info);
   /// <summary>Gets index of the child in parent&apos;s children list.</summary>
/// <returns>Index in children list</returns>
 int GetIndexInParent();
   /// <summary>Gets contextual information about object.</summary>
/// <returns>Accessible contextual information</returns>
 System.String GetDescription();
   /// <summary>Sets widget contextual information.</summary>
/// <param name="description">Accessible contextual information</param>
/// <returns></returns>
 void SetDescription(  System.String description);
   /// <summary>Gets set describing object accessible states.</summary>
/// <returns>Accessible state set</returns>
Efl.Access.StateSet GetStateSet();
   /// <summary>Gets highlightable of given widget.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <returns>If @c true, the object is highlightable.</returns>
bool GetCanHighlight();
   /// <summary>Sets highlightable to given widget.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <param name="can_highlight">If @c true, the object is highlightable.</param>
/// <returns></returns>
 void SetCanHighlight( bool can_highlight);
   /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
/// Translation domain should be set if the application wants to support i18n for accessibility &quot;name&quot; and &quot;description&quot; properties.
/// 
/// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
/// 
/// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
/// <returns>Translation domain</returns>
 System.String GetTranslationDomain();
   /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
/// Translation domain should be set if the application wants to support i18n for accessibility &quot;name&quot; and &quot;description&quot; properties.
/// 
/// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
/// 
/// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
/// <param name="domain">Translation domain</param>
/// <returns></returns>
 void SetTranslationDomain(  System.String domain);
      /// <summary>Handles gesture on given widget.</summary>
/// <param name="gesture_info"></param>
/// <returns></returns>
bool GestureDo( Efl.Access.GestureInfo gesture_info);
   /// <summary>Add key-value pair identifying object extra attribute
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <param name="key">The string key to give extra information</param>
/// <param name="value">The string value to give extra information</param>
/// <returns></returns>
 void AppendAttribute(  System.String key,   System.String value);
   /// <summary>Removes all attributes in accessible object.</summary>
/// <returns></returns>
 void ClearAttributes();
            /// <summary>Defines the relationship between two accessible objects.
/// Adds a unique relationship between source object and relation_object of a given type.
/// 
/// Relationships can be queried by Assistive Technology clients to provide customized feedback, improving overall user experience.
/// 
/// Relationship_append API is asymmetric, which means that appending, for example, relation EFL_ACCESS_RELATION_FLOWS_TO from object A to B, do NOT append relation EFL_ACCESS_RELATION_FLOWS_FROM from object B to object A.</summary>
/// <param name="type">Relation type</param>
/// <param name="relation_object">Object to relate to</param>
/// <returns><c>true</c> if relationship was successfully appended, <c>false</c> otherwise</returns>
bool AppendRelationship( Efl.Access.RelationType type,  Efl.Access.Object relation_object);
   /// <summary>Removes the relationship between two accessible objects.
/// If relation_object is NULL function removes all relations of the given type.</summary>
/// <param name="type">Relation type</param>
/// <param name="relation_object">Object to remove relation from</param>
/// <returns></returns>
 void RelationshipRemove( Efl.Access.RelationType type,  Efl.Access.Object relation_object);
   /// <summary>Removes all relationships in accessible object.</summary>
/// <returns></returns>
 void ClearRelationships();
   /// <summary>Notifies accessibility clients about current state of the accessible object.
/// Function limits information broadcast to clients to types specified by state_types_mask parameter.
/// 
/// if recursive parameter is set, function will traverse all accessible children and call state_notify function on them.</summary>
/// <param name="state_types_mask"></param>
/// <param name="recursive"></param>
/// <returns></returns>
 void StateNotify( Efl.Access.StateSet state_types_mask,  bool recursive);
                                                                                                            /// <summary>Called when property has changed</summary>
   event EventHandler<Efl.Access.ObjectPropertyChangedEvt_Args> PropertyChangedEvt;
   /// <summary>Called when children have changed</summary>
   event EventHandler<Efl.Access.ObjectChildrenChangedEvt_Args> ChildrenChangedEvt;
   /// <summary>Called when state has changed</summary>
   event EventHandler<Efl.Access.ObjectStateChangedEvt_Args> StateChangedEvt;
   /// <summary>Called when boundaries have changed</summary>
   event EventHandler<Efl.Access.ObjectBoundsChangedEvt_Args> BoundsChangedEvt;
   /// <summary>Called when visibility has changed</summary>
   event EventHandler VisibleDataChangedEvt;
   /// <summary>Called when active state of descendant has changed</summary>
   event EventHandler<Efl.Access.ObjectActiveDescendantChangedEvt_Args> ActiveDescendantChangedEvt;
   /// <summary>Called when item is added</summary>
   event EventHandler AddedEvt;
   /// <summary>Called when item is removed</summary>
   event EventHandler RemovedEvt;
   /// <summary></summary>
   event EventHandler MoveOutedEvt;
   /// <summary>Gets an localized string describing accessible object role name.</summary>
/// <value>Localized accessible object role name</value>
    System.String LocalizedRoleName {
      get ;
   }
   /// <summary>Accessible name of the object.</summary>
/// <value>Accessible name</value>
    System.String I18nName {
      get ;
      set ;
   }
   /// <summary>Gets an all relations between accessible object and other accessible objects.</summary>
/// <value>Accessible relation set</value>
   Efl.Access.RelationSet RelationSet {
      get ;
   }
   /// <summary>The role of the object in accessibility domain.</summary>
/// <value>Accessible role</value>
   Efl.Access.Role Role {
      get ;
      set ;
   }
   /// <summary>Gets object&apos;s accessible parent.</summary>
/// <value>Accessible parent</value>
   Efl.Access.Object AccessParent {
      get ;
      set ;
   }
   /// <summary>Gets object&apos;s accessible children.</summary>
/// <value>List of widget&apos;s children</value>
   Eina.List<Efl.Access.Object> AccessChildren {
      get ;
   }
   /// <summary>Gets human-readable string indentifying object accessibility role.</summary>
/// <value>Accessible role name</value>
    System.String RoleName {
      get ;
   }
   /// <summary>Gets key-value pairs indentifying object extra attributes. Must be free by a user.</summary>
/// <value>List of object attributes, Must be freed by the user</value>
   Eina.List<Efl.Access.Attribute> Attributes {
      get ;
   }
   /// <summary>Gets reading information types of an accessible object.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <value>Reading information types</value>
   Efl.Access.ReadingInfoTypeMask ReadingInfoType {
      get ;
      set ;
   }
   /// <summary>Gets index of the child in parent&apos;s children list.</summary>
/// <value>Index in children list</value>
    int IndexInParent {
      get ;
   }
   /// <summary>Gets contextual information about object.</summary>
/// <value>Accessible contextual information</value>
    System.String Description {
      get ;
      set ;
   }
   /// <summary>Gets set describing object accessible states.</summary>
/// <value>Accessible state set</value>
   Efl.Access.StateSet StateSet {
      get ;
   }
   /// <summary>Gets highlightable of given widget.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <value>If @c true, the object is highlightable.</value>
   bool CanHighlight {
      get ;
      set ;
   }
   /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
/// Translation domain should be set if the application wants to support i18n for accessibility &quot;name&quot; and &quot;description&quot; properties.
/// 
/// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
/// 
/// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
/// <value>Translation domain</value>
    System.String TranslationDomain {
      get ;
      set ;
   }
}
///<summary>Event argument wrapper for event <see cref="Efl.Access.Object.PropertyChangedEvt"/>.</summary>
public class ObjectPropertyChangedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public  System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Access.Object.ChildrenChangedEvt"/>.</summary>
public class ObjectChildrenChangedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Access.Event.ChildrenChanged.Data arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Access.Object.StateChangedEvt"/>.</summary>
public class ObjectStateChangedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Access.Event.StateChanged.Data arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Access.Object.BoundsChangedEvt"/>.</summary>
public class ObjectBoundsChangedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Access.Event.GeometryChanged.Data arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Access.Object.ActiveDescendantChangedEvt"/>.</summary>
public class ObjectActiveDescendantChangedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Object arg { get; set; }
}
/// <summary>Accessibility accessible mixin</summary>
sealed public class ObjectConcrete : 

Object
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ObjectConcrete))
            return Efl.Access.ObjectNativeInherit.GetEflClassStatic();
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_access_object_mixin_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public ObjectConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ObjectConcrete()
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
   public static ObjectConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ObjectConcrete(obj.NativeHandle);
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
         IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
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
private static object PropertyChangedEvtKey = new object();
   /// <summary>Called when property has changed</summary>
   public event EventHandler<Efl.Access.ObjectPropertyChangedEvt_Args> PropertyChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_PROPERTY_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_PropertyChangedEvt_delegate)) {
               eventHandlers.AddHandler(PropertyChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_PROPERTY_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_PropertyChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(PropertyChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PropertyChangedEvt.</summary>
   public void On_PropertyChangedEvt(Efl.Access.ObjectPropertyChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectPropertyChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectPropertyChangedEvt_Args>)eventHandlers[PropertyChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PropertyChangedEvt_delegate;
   private void on_PropertyChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectPropertyChangedEvt_Args args = new Efl.Access.ObjectPropertyChangedEvt_Args();
      args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
      try {
         On_PropertyChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ChildrenChangedEvtKey = new object();
   /// <summary>Called when children have changed</summary>
   public event EventHandler<Efl.Access.ObjectChildrenChangedEvt_Args> ChildrenChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_CHILDREN_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_ChildrenChangedEvt_delegate)) {
               eventHandlers.AddHandler(ChildrenChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_CHILDREN_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ChildrenChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ChildrenChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ChildrenChangedEvt.</summary>
   public void On_ChildrenChangedEvt(Efl.Access.ObjectChildrenChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectChildrenChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectChildrenChangedEvt_Args>)eventHandlers[ChildrenChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ChildrenChangedEvt_delegate;
   private void on_ChildrenChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectChildrenChangedEvt_Args args = new Efl.Access.ObjectChildrenChangedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_ChildrenChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object StateChangedEvtKey = new object();
   /// <summary>Called when state has changed</summary>
   public event EventHandler<Efl.Access.ObjectStateChangedEvt_Args> StateChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_STATE_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_StateChangedEvt_delegate)) {
               eventHandlers.AddHandler(StateChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_STATE_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_StateChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(StateChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event StateChangedEvt.</summary>
   public void On_StateChangedEvt(Efl.Access.ObjectStateChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectStateChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectStateChangedEvt_Args>)eventHandlers[StateChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_StateChangedEvt_delegate;
   private void on_StateChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectStateChangedEvt_Args args = new Efl.Access.ObjectStateChangedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_StateChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object BoundsChangedEvtKey = new object();
   /// <summary>Called when boundaries have changed</summary>
   public event EventHandler<Efl.Access.ObjectBoundsChangedEvt_Args> BoundsChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_BOUNDS_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_BoundsChangedEvt_delegate)) {
               eventHandlers.AddHandler(BoundsChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_BOUNDS_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_BoundsChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(BoundsChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event BoundsChangedEvt.</summary>
   public void On_BoundsChangedEvt(Efl.Access.ObjectBoundsChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectBoundsChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectBoundsChangedEvt_Args>)eventHandlers[BoundsChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_BoundsChangedEvt_delegate;
   private void on_BoundsChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectBoundsChangedEvt_Args args = new Efl.Access.ObjectBoundsChangedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_BoundsChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object VisibleDataChangedEvtKey = new object();
   /// <summary>Called when visibility has changed</summary>
   public event EventHandler VisibleDataChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_VISIBLE_DATA_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_VisibleDataChangedEvt_delegate)) {
               eventHandlers.AddHandler(VisibleDataChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_VISIBLE_DATA_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_VisibleDataChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(VisibleDataChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event VisibleDataChangedEvt.</summary>
   public void On_VisibleDataChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[VisibleDataChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_VisibleDataChangedEvt_delegate;
   private void on_VisibleDataChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_VisibleDataChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ActiveDescendantChangedEvtKey = new object();
   /// <summary>Called when active state of descendant has changed</summary>
   public event EventHandler<Efl.Access.ObjectActiveDescendantChangedEvt_Args> ActiveDescendantChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_ACTIVE_DESCENDANT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_ActiveDescendantChangedEvt_delegate)) {
               eventHandlers.AddHandler(ActiveDescendantChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_ACTIVE_DESCENDANT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ActiveDescendantChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ActiveDescendantChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ActiveDescendantChangedEvt.</summary>
   public void On_ActiveDescendantChangedEvt(Efl.Access.ObjectActiveDescendantChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectActiveDescendantChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectActiveDescendantChangedEvt_Args>)eventHandlers[ActiveDescendantChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ActiveDescendantChangedEvt_delegate;
   private void on_ActiveDescendantChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectActiveDescendantChangedEvt_Args args = new Efl.Access.ObjectActiveDescendantChangedEvt_Args();
      args.arg = new Efl.Object(evt.Info);
      try {
         On_ActiveDescendantChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AddedEvtKey = new object();
   /// <summary>Called when item is added</summary>
   public event EventHandler AddedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_ADDED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AddedEvt_delegate)) {
               eventHandlers.AddHandler(AddedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_ADDED";
            if (remove_cpp_event_handler(key, this.evt_AddedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AddedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AddedEvt.</summary>
   public void On_AddedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[AddedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AddedEvt_delegate;
   private void on_AddedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_AddedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object RemovedEvtKey = new object();
   /// <summary>Called when item is removed</summary>
   public event EventHandler RemovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_REMOVED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_RemovedEvt_delegate)) {
               eventHandlers.AddHandler(RemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_REMOVED";
            if (remove_cpp_event_handler(key, this.evt_RemovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(RemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event RemovedEvt.</summary>
   public void On_RemovedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[RemovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_RemovedEvt_delegate;
   private void on_RemovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_RemovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object MoveOutedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler MoveOutedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_MOVE_OUTED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_MoveOutedEvt_delegate)) {
               eventHandlers.AddHandler(MoveOutedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_MOVE_OUTED";
            if (remove_cpp_event_handler(key, this.evt_MoveOutedEvt_delegate)) { 
               eventHandlers.RemoveHandler(MoveOutedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event MoveOutedEvt.</summary>
   public void On_MoveOutedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[MoveOutedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_MoveOutedEvt_delegate;
   private void on_MoveOutedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_MoveOutedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_PropertyChangedEvt_delegate = new Efl.EventCb(on_PropertyChangedEvt_NativeCallback);
      evt_ChildrenChangedEvt_delegate = new Efl.EventCb(on_ChildrenChangedEvt_NativeCallback);
      evt_StateChangedEvt_delegate = new Efl.EventCb(on_StateChangedEvt_NativeCallback);
      evt_BoundsChangedEvt_delegate = new Efl.EventCb(on_BoundsChangedEvt_NativeCallback);
      evt_VisibleDataChangedEvt_delegate = new Efl.EventCb(on_VisibleDataChangedEvt_NativeCallback);
      evt_ActiveDescendantChangedEvt_delegate = new Efl.EventCb(on_ActiveDescendantChangedEvt_NativeCallback);
      evt_AddedEvt_delegate = new Efl.EventCb(on_AddedEvt_NativeCallback);
      evt_RemovedEvt_delegate = new Efl.EventCb(on_RemovedEvt_NativeCallback);
      evt_MoveOutedEvt_delegate = new Efl.EventCb(on_MoveOutedEvt_NativeCallback);
   }
   /// <summary>Gets an localized string describing accessible object role name.</summary>
   /// <returns>Localized accessible object role name</returns>
   public  System.String GetLocalizedRoleName() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_localized_role_name_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Accessible name of the object.</summary>
   /// <returns>Accessible name</returns>
   public  System.String GetI18nName() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_i18n_name_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Accessible name of the object.</summary>
   /// <param name="i18n_name">Accessible name</param>
   /// <returns></returns>
   public  void SetI18nName(  System.String i18n_name) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_i18n_name_set_ptr.Value.Delegate(this.NativeHandle, i18n_name);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Sets name information callback about widget.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="name_cb">reading information callback</param>
   /// <param name="data"></param>
   /// <returns></returns>
   public  void SetNameCb( Efl.Access.ReadingInfoCb name_cb,   System.IntPtr data) {
                                           Efl.Access.ObjectNativeInherit.efl_access_object_name_cb_set_ptr.Value.Delegate(this.NativeHandle, name_cb,  data);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Gets an all relations between accessible object and other accessible objects.</summary>
   /// <returns>Accessible relation set</returns>
   public Efl.Access.RelationSet GetRelationSet() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_relation_set_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The role of the object in accessibility domain.</summary>
   /// <returns>Accessible role</returns>
   public Efl.Access.Role GetRole() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_role_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets the role of the object in accessibility domain.</summary>
   /// <param name="role">Accessible role</param>
   /// <returns></returns>
   public  void SetRole( Efl.Access.Role role) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_role_set_ptr.Value.Delegate(this.NativeHandle, role);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets object&apos;s accessible parent.</summary>
   /// <returns>Accessible parent</returns>
   public Efl.Access.Object GetAccessParent() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_access_parent_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gets object&apos;s accessible parent.</summary>
   /// <param name="parent">Accessible parent</param>
   /// <returns></returns>
   public  void SetAccessParent( Efl.Access.Object parent) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_access_parent_set_ptr.Value.Delegate(this.NativeHandle, parent);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Sets contextual information callback about widget.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="description_cb">The function called to provide the accessible description.</param>
   /// <param name="data">The data passed to @c description_cb.</param>
   /// <returns></returns>
   public  void SetDescriptionCb( Efl.Access.ReadingInfoCb description_cb,   System.IntPtr data) {
                                           Efl.Access.ObjectNativeInherit.efl_access_object_description_cb_set_ptr.Value.Delegate(this.NativeHandle, description_cb,  data);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Sets gesture callback to give widget.
   /// Warning: Please do not abuse this API. The purpose of this API is to support special application such as screen-reader guidance. Before using this API, please check if there is another way.
   /// 
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="gesture_cb"></param>
   /// <param name="data"></param>
   /// <returns></returns>
   public  void SetGestureCb( Efl.Access.GestureCb gesture_cb,   System.IntPtr data) {
                                           Efl.Access.ObjectNativeInherit.efl_access_object_gesture_cb_set_ptr.Value.Delegate(this.NativeHandle, gesture_cb,  data);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Gets object&apos;s accessible children.</summary>
   /// <returns>List of widget&apos;s children</returns>
   public Eina.List<Efl.Access.Object> GetAccessChildren() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_access_children_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Access.Object>(_ret_var, true, false);
 }
   /// <summary>Gets human-readable string indentifying object accessibility role.</summary>
   /// <returns>Accessible role name</returns>
   public  System.String GetRoleName() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_role_name_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gets key-value pairs indentifying object extra attributes. Must be free by a user.</summary>
   /// <returns>List of object attributes, Must be freed by the user</returns>
   public Eina.List<Efl.Access.Attribute> GetAttributes() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_attributes_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Access.Attribute>(_ret_var, true, true);
 }
   /// <summary>Gets reading information types of an accessible object.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <returns>Reading information types</returns>
   public Efl.Access.ReadingInfoTypeMask GetReadingInfoType() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_reading_info_type_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets reading information of an accessible object.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="reading_info">Reading information types</param>
   /// <returns></returns>
   public  void SetReadingInfoType( Efl.Access.ReadingInfoTypeMask reading_info) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_reading_info_type_set_ptr.Value.Delegate(this.NativeHandle, reading_info);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets index of the child in parent&apos;s children list.</summary>
   /// <returns>Index in children list</returns>
   public  int GetIndexInParent() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_index_in_parent_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gets contextual information about object.</summary>
   /// <returns>Accessible contextual information</returns>
   public  System.String GetDescription() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_description_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets widget contextual information.</summary>
   /// <param name="description">Accessible contextual information</param>
   /// <returns></returns>
   public  void SetDescription(  System.String description) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_description_set_ptr.Value.Delegate(this.NativeHandle, description);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets set describing object accessible states.</summary>
   /// <returns>Accessible state set</returns>
   public Efl.Access.StateSet GetStateSet() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_state_set_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gets highlightable of given widget.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <returns>If @c true, the object is highlightable.</returns>
   public bool GetCanHighlight() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_can_highlight_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets highlightable to given widget.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="can_highlight">If @c true, the object is highlightable.</param>
   /// <returns></returns>
   public  void SetCanHighlight( bool can_highlight) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_can_highlight_set_ptr.Value.Delegate(this.NativeHandle, can_highlight);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
   /// Translation domain should be set if the application wants to support i18n for accessibility &quot;name&quot; and &quot;description&quot; properties.
   /// 
   /// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
   /// 
   /// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
   /// <returns>Translation domain</returns>
   public  System.String GetTranslationDomain() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_translation_domain_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
   /// Translation domain should be set if the application wants to support i18n for accessibility &quot;name&quot; and &quot;description&quot; properties.
   /// 
   /// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
   /// 
   /// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
   /// <param name="domain">Translation domain</param>
   /// <returns></returns>
   public  void SetTranslationDomain(  System.String domain) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_translation_domain_set_ptr.Value.Delegate(this.NativeHandle, domain);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get root object of accessible object hierarchy</summary>
   /// <returns>Root object</returns>
   public static Efl.Object GetAccessRoot() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_access_root_get_ptr.Value.Delegate();
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Handles gesture on given widget.</summary>
   /// <param name="gesture_info"></param>
   /// <returns></returns>
   public bool GestureDo( Efl.Access.GestureInfo gesture_info) {
       var _in_gesture_info = Efl.Access.GestureInfo_StructConversion.ToInternal(gesture_info);
                  var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_gesture_do_ptr.Value.Delegate(this.NativeHandle, _in_gesture_info);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Add key-value pair identifying object extra attribute
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="key">The string key to give extra information</param>
   /// <param name="value">The string value to give extra information</param>
   /// <returns></returns>
   public  void AppendAttribute(  System.String key,   System.String value) {
                                           Efl.Access.ObjectNativeInherit.efl_access_object_attribute_append_ptr.Value.Delegate(this.NativeHandle, key,  value);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Removes all attributes in accessible object.</summary>
   /// <returns></returns>
   public  void ClearAttributes() {
       Efl.Access.ObjectNativeInherit.efl_access_object_attributes_clear_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Register accessibility event listener</summary>
   /// <param name="cb">Callback</param>
   /// <param name="data">Data</param>
   /// <returns>Event handler</returns>
   public static Efl.Access.Event.Handler AddEventHandler( Efl.EventCb cb,   System.IntPtr data) {
                                           var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_event_handler_add_ptr.Value.Delegate( cb,  data);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Deregister accessibility event listener</summary>
   /// <param name="handler">Event handler</param>
   /// <returns></returns>
   public static  void DelEventHandler( Efl.Access.Event.Handler handler) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_event_handler_del_ptr.Value.Delegate( handler);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Emit event</summary>
   /// <param name="accessible">Accessibility object.</param>
   /// <param name="kw_event">Accessibility event type.</param>
   /// <param name="event_info">Accessibility event details.</param>
   /// <returns></returns>
   public static  void EmitEvent( Efl.Access.Object accessible,  Efl.EventDescription kw_event,   System.IntPtr event_info) {
             var _in_kw_event = Eina.PrimitiveConversion.ManagedToPointerAlloc(kw_event);
                                                Efl.Access.ObjectNativeInherit.efl_access_object_event_emit_ptr.Value.Delegate( accessible,  _in_kw_event,  event_info);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Defines the relationship between two accessible objects.
   /// Adds a unique relationship between source object and relation_object of a given type.
   /// 
   /// Relationships can be queried by Assistive Technology clients to provide customized feedback, improving overall user experience.
   /// 
   /// Relationship_append API is asymmetric, which means that appending, for example, relation EFL_ACCESS_RELATION_FLOWS_TO from object A to B, do NOT append relation EFL_ACCESS_RELATION_FLOWS_FROM from object B to object A.</summary>
   /// <param name="type">Relation type</param>
   /// <param name="relation_object">Object to relate to</param>
   /// <returns><c>true</c> if relationship was successfully appended, <c>false</c> otherwise</returns>
   public bool AppendRelationship( Efl.Access.RelationType type,  Efl.Access.Object relation_object) {
                                           var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_relationship_append_ptr.Value.Delegate(this.NativeHandle, type,  relation_object);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Removes the relationship between two accessible objects.
   /// If relation_object is NULL function removes all relations of the given type.</summary>
   /// <param name="type">Relation type</param>
   /// <param name="relation_object">Object to remove relation from</param>
   /// <returns></returns>
   public  void RelationshipRemove( Efl.Access.RelationType type,  Efl.Access.Object relation_object) {
                                           Efl.Access.ObjectNativeInherit.efl_access_object_relationship_remove_ptr.Value.Delegate(this.NativeHandle, type,  relation_object);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Removes all relationships in accessible object.</summary>
   /// <returns></returns>
   public  void ClearRelationships() {
       Efl.Access.ObjectNativeInherit.efl_access_object_relationships_clear_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Notifies accessibility clients about current state of the accessible object.
   /// Function limits information broadcast to clients to types specified by state_types_mask parameter.
   /// 
   /// if recursive parameter is set, function will traverse all accessible children and call state_notify function on them.</summary>
   /// <param name="state_types_mask"></param>
   /// <param name="recursive"></param>
   /// <returns></returns>
   public  void StateNotify( Efl.Access.StateSet state_types_mask,  bool recursive) {
                                           Efl.Access.ObjectNativeInherit.efl_access_object_state_notify_ptr.Value.Delegate(this.NativeHandle, state_types_mask,  recursive);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Gets an localized string describing accessible object role name.</summary>
/// <value>Localized accessible object role name</value>
   public  System.String LocalizedRoleName {
      get { return GetLocalizedRoleName(); }
   }
   /// <summary>Accessible name of the object.</summary>
/// <value>Accessible name</value>
   public  System.String I18nName {
      get { return GetI18nName(); }
      set { SetI18nName( value); }
   }
   /// <summary>Gets an all relations between accessible object and other accessible objects.</summary>
/// <value>Accessible relation set</value>
   public Efl.Access.RelationSet RelationSet {
      get { return GetRelationSet(); }
   }
   /// <summary>The role of the object in accessibility domain.</summary>
/// <value>Accessible role</value>
   public Efl.Access.Role Role {
      get { return GetRole(); }
      set { SetRole( value); }
   }
   /// <summary>Gets object&apos;s accessible parent.</summary>
/// <value>Accessible parent</value>
   public Efl.Access.Object AccessParent {
      get { return GetAccessParent(); }
      set { SetAccessParent( value); }
   }
   /// <summary>Gets object&apos;s accessible children.</summary>
/// <value>List of widget&apos;s children</value>
   public Eina.List<Efl.Access.Object> AccessChildren {
      get { return GetAccessChildren(); }
   }
   /// <summary>Gets human-readable string indentifying object accessibility role.</summary>
/// <value>Accessible role name</value>
   public  System.String RoleName {
      get { return GetRoleName(); }
   }
   /// <summary>Gets key-value pairs indentifying object extra attributes. Must be free by a user.</summary>
/// <value>List of object attributes, Must be freed by the user</value>
   public Eina.List<Efl.Access.Attribute> Attributes {
      get { return GetAttributes(); }
   }
   /// <summary>Gets reading information types of an accessible object.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <value>Reading information types</value>
   public Efl.Access.ReadingInfoTypeMask ReadingInfoType {
      get { return GetReadingInfoType(); }
      set { SetReadingInfoType( value); }
   }
   /// <summary>Gets index of the child in parent&apos;s children list.</summary>
/// <value>Index in children list</value>
   public  int IndexInParent {
      get { return GetIndexInParent(); }
   }
   /// <summary>Gets contextual information about object.</summary>
/// <value>Accessible contextual information</value>
   public  System.String Description {
      get { return GetDescription(); }
      set { SetDescription( value); }
   }
   /// <summary>Gets set describing object accessible states.</summary>
/// <value>Accessible state set</value>
   public Efl.Access.StateSet StateSet {
      get { return GetStateSet(); }
   }
   /// <summary>Gets highlightable of given widget.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <value>If @c true, the object is highlightable.</value>
   public bool CanHighlight {
      get { return GetCanHighlight(); }
      set { SetCanHighlight( value); }
   }
   /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
/// Translation domain should be set if the application wants to support i18n for accessibility &quot;name&quot; and &quot;description&quot; properties.
/// 
/// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
/// 
/// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
/// <value>Translation domain</value>
   public  System.String TranslationDomain {
      get { return GetTranslationDomain(); }
      set { SetTranslationDomain( value); }
   }
   /// <summary>Get root object of accessible object hierarchy</summary>
/// <value>Root object</value>
   public static Efl.Object AccessRoot {
      get { return GetAccessRoot(); }
   }
}
public class ObjectNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_access_object_localized_role_name_get_static_delegate == null)
      efl_access_object_localized_role_name_get_static_delegate = new efl_access_object_localized_role_name_get_delegate(localized_role_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_localized_role_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_localized_role_name_get_static_delegate)});
      if (efl_access_object_i18n_name_get_static_delegate == null)
      efl_access_object_i18n_name_get_static_delegate = new efl_access_object_i18n_name_get_delegate(i18n_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_i18n_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_i18n_name_get_static_delegate)});
      if (efl_access_object_i18n_name_set_static_delegate == null)
      efl_access_object_i18n_name_set_static_delegate = new efl_access_object_i18n_name_set_delegate(i18n_name_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_i18n_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_i18n_name_set_static_delegate)});
      if (efl_access_object_name_cb_set_static_delegate == null)
      efl_access_object_name_cb_set_static_delegate = new efl_access_object_name_cb_set_delegate(name_cb_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_name_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_name_cb_set_static_delegate)});
      if (efl_access_object_relation_set_get_static_delegate == null)
      efl_access_object_relation_set_get_static_delegate = new efl_access_object_relation_set_get_delegate(relation_set_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_relation_set_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relation_set_get_static_delegate)});
      if (efl_access_object_role_get_static_delegate == null)
      efl_access_object_role_get_static_delegate = new efl_access_object_role_get_delegate(role_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_role_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_get_static_delegate)});
      if (efl_access_object_role_set_static_delegate == null)
      efl_access_object_role_set_static_delegate = new efl_access_object_role_set_delegate(role_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_role_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_set_static_delegate)});
      if (efl_access_object_access_parent_get_static_delegate == null)
      efl_access_object_access_parent_get_static_delegate = new efl_access_object_access_parent_get_delegate(access_parent_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_access_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_parent_get_static_delegate)});
      if (efl_access_object_access_parent_set_static_delegate == null)
      efl_access_object_access_parent_set_static_delegate = new efl_access_object_access_parent_set_delegate(access_parent_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_access_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_parent_set_static_delegate)});
      if (efl_access_object_description_cb_set_static_delegate == null)
      efl_access_object_description_cb_set_static_delegate = new efl_access_object_description_cb_set_delegate(description_cb_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_description_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_cb_set_static_delegate)});
      if (efl_access_object_gesture_cb_set_static_delegate == null)
      efl_access_object_gesture_cb_set_static_delegate = new efl_access_object_gesture_cb_set_delegate(gesture_cb_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_gesture_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_gesture_cb_set_static_delegate)});
      if (efl_access_object_access_children_get_static_delegate == null)
      efl_access_object_access_children_get_static_delegate = new efl_access_object_access_children_get_delegate(access_children_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_access_children_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_children_get_static_delegate)});
      if (efl_access_object_role_name_get_static_delegate == null)
      efl_access_object_role_name_get_static_delegate = new efl_access_object_role_name_get_delegate(role_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_role_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_name_get_static_delegate)});
      if (efl_access_object_attributes_get_static_delegate == null)
      efl_access_object_attributes_get_static_delegate = new efl_access_object_attributes_get_delegate(attributes_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_attributes_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attributes_get_static_delegate)});
      if (efl_access_object_reading_info_type_get_static_delegate == null)
      efl_access_object_reading_info_type_get_static_delegate = new efl_access_object_reading_info_type_get_delegate(reading_info_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_reading_info_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_reading_info_type_get_static_delegate)});
      if (efl_access_object_reading_info_type_set_static_delegate == null)
      efl_access_object_reading_info_type_set_static_delegate = new efl_access_object_reading_info_type_set_delegate(reading_info_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_reading_info_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_reading_info_type_set_static_delegate)});
      if (efl_access_object_index_in_parent_get_static_delegate == null)
      efl_access_object_index_in_parent_get_static_delegate = new efl_access_object_index_in_parent_get_delegate(index_in_parent_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_index_in_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_index_in_parent_get_static_delegate)});
      if (efl_access_object_description_get_static_delegate == null)
      efl_access_object_description_get_static_delegate = new efl_access_object_description_get_delegate(description_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_description_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_get_static_delegate)});
      if (efl_access_object_description_set_static_delegate == null)
      efl_access_object_description_set_static_delegate = new efl_access_object_description_set_delegate(description_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_description_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_set_static_delegate)});
      if (efl_access_object_state_set_get_static_delegate == null)
      efl_access_object_state_set_get_static_delegate = new efl_access_object_state_set_get_delegate(state_set_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_state_set_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_state_set_get_static_delegate)});
      if (efl_access_object_can_highlight_get_static_delegate == null)
      efl_access_object_can_highlight_get_static_delegate = new efl_access_object_can_highlight_get_delegate(can_highlight_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_can_highlight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_can_highlight_get_static_delegate)});
      if (efl_access_object_can_highlight_set_static_delegate == null)
      efl_access_object_can_highlight_set_static_delegate = new efl_access_object_can_highlight_set_delegate(can_highlight_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_can_highlight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_can_highlight_set_static_delegate)});
      if (efl_access_object_translation_domain_get_static_delegate == null)
      efl_access_object_translation_domain_get_static_delegate = new efl_access_object_translation_domain_get_delegate(translation_domain_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_translation_domain_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_translation_domain_get_static_delegate)});
      if (efl_access_object_translation_domain_set_static_delegate == null)
      efl_access_object_translation_domain_set_static_delegate = new efl_access_object_translation_domain_set_delegate(translation_domain_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_translation_domain_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_translation_domain_set_static_delegate)});
      if (efl_access_object_gesture_do_static_delegate == null)
      efl_access_object_gesture_do_static_delegate = new efl_access_object_gesture_do_delegate(gesture_do);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_gesture_do"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_gesture_do_static_delegate)});
      if (efl_access_object_attribute_append_static_delegate == null)
      efl_access_object_attribute_append_static_delegate = new efl_access_object_attribute_append_delegate(attribute_append);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_attribute_append"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attribute_append_static_delegate)});
      if (efl_access_object_attributes_clear_static_delegate == null)
      efl_access_object_attributes_clear_static_delegate = new efl_access_object_attributes_clear_delegate(attributes_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_attributes_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attributes_clear_static_delegate)});
      if (efl_access_object_relationship_append_static_delegate == null)
      efl_access_object_relationship_append_static_delegate = new efl_access_object_relationship_append_delegate(relationship_append);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_relationship_append"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationship_append_static_delegate)});
      if (efl_access_object_relationship_remove_static_delegate == null)
      efl_access_object_relationship_remove_static_delegate = new efl_access_object_relationship_remove_delegate(relationship_remove);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_relationship_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationship_remove_static_delegate)});
      if (efl_access_object_relationships_clear_static_delegate == null)
      efl_access_object_relationships_clear_static_delegate = new efl_access_object_relationships_clear_delegate(relationships_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_relationships_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationships_clear_static_delegate)});
      if (efl_access_object_state_notify_static_delegate == null)
      efl_access_object_state_notify_static_delegate = new efl_access_object_state_notify_delegate(state_notify);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_state_notify"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_state_notify_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Access.ObjectConcrete.efl_access_object_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Access.ObjectConcrete.efl_access_object_mixin_get();
   }


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_access_object_localized_role_name_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_access_object_localized_role_name_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_localized_role_name_get_api_delegate> efl_access_object_localized_role_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_localized_role_name_get_api_delegate>(_Module, "efl_access_object_localized_role_name_get");
    private static  System.String localized_role_name_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_localized_role_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetLocalizedRoleName();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_localized_role_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_localized_role_name_get_delegate efl_access_object_localized_role_name_get_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_access_object_i18n_name_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_access_object_i18n_name_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_get_api_delegate> efl_access_object_i18n_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_get_api_delegate>(_Module, "efl_access_object_i18n_name_get");
    private static  System.String i18n_name_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_i18n_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetI18nName();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_i18n_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_i18n_name_get_delegate efl_access_object_i18n_name_get_static_delegate;


    private delegate  void efl_access_object_i18n_name_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String i18n_name);


    public delegate  void efl_access_object_i18n_name_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String i18n_name);
    public static Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_set_api_delegate> efl_access_object_i18n_name_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_set_api_delegate>(_Module, "efl_access_object_i18n_name_set");
    private static  void i18n_name_set(System.IntPtr obj, System.IntPtr pd,   System.String i18n_name)
   {
      Eina.Log.Debug("function efl_access_object_i18n_name_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ObjectConcrete)wrapper).SetI18nName( i18n_name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_i18n_name_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  i18n_name);
      }
   }
   private static efl_access_object_i18n_name_set_delegate efl_access_object_i18n_name_set_static_delegate;


    private delegate  void efl_access_object_name_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.ReadingInfoCb name_cb,    System.IntPtr data);


    public delegate  void efl_access_object_name_cb_set_api_delegate(System.IntPtr obj,   Efl.Access.ReadingInfoCb name_cb,    System.IntPtr data);
    public static Efl.Eo.FunctionWrapper<efl_access_object_name_cb_set_api_delegate> efl_access_object_name_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_name_cb_set_api_delegate>(_Module, "efl_access_object_name_cb_set");
    private static  void name_cb_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoCb name_cb,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_access_object_name_cb_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ObjectConcrete)wrapper).SetNameCb( name_cb,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_name_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name_cb,  data);
      }
   }
   private static efl_access_object_name_cb_set_delegate efl_access_object_name_cb_set_static_delegate;


    private delegate Efl.Access.RelationSet efl_access_object_relation_set_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Access.RelationSet efl_access_object_relation_set_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_relation_set_get_api_delegate> efl_access_object_relation_set_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relation_set_get_api_delegate>(_Module, "efl_access_object_relation_set_get");
    private static Efl.Access.RelationSet relation_set_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_relation_set_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.RelationSet _ret_var = default(Efl.Access.RelationSet);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetRelationSet();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_relation_set_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_relation_set_get_delegate efl_access_object_relation_set_get_static_delegate;


    private delegate Efl.Access.Role efl_access_object_role_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Access.Role efl_access_object_role_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_role_get_api_delegate> efl_access_object_role_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_role_get_api_delegate>(_Module, "efl_access_object_role_get");
    private static Efl.Access.Role role_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_role_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.Role _ret_var = default(Efl.Access.Role);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetRole();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_role_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_role_get_delegate efl_access_object_role_get_static_delegate;


    private delegate  void efl_access_object_role_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.Role role);


    public delegate  void efl_access_object_role_set_api_delegate(System.IntPtr obj,   Efl.Access.Role role);
    public static Efl.Eo.FunctionWrapper<efl_access_object_role_set_api_delegate> efl_access_object_role_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_role_set_api_delegate>(_Module, "efl_access_object_role_set");
    private static  void role_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.Role role)
   {
      Eina.Log.Debug("function efl_access_object_role_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ObjectConcrete)wrapper).SetRole( role);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_role_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  role);
      }
   }
   private static efl_access_object_role_set_delegate efl_access_object_role_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Access.Object efl_access_object_access_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Access.Object efl_access_object_access_parent_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_access_parent_get_api_delegate> efl_access_object_access_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_parent_get_api_delegate>(_Module, "efl_access_object_access_parent_get");
    private static Efl.Access.Object access_parent_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_access_parent_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.Object _ret_var = default(Efl.Access.Object);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetAccessParent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_access_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_access_parent_get_delegate efl_access_object_access_parent_get_static_delegate;


    private delegate  void efl_access_object_access_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object parent);


    public delegate  void efl_access_object_access_parent_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object parent);
    public static Efl.Eo.FunctionWrapper<efl_access_object_access_parent_set_api_delegate> efl_access_object_access_parent_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_parent_set_api_delegate>(_Module, "efl_access_object_access_parent_set");
    private static  void access_parent_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.Object parent)
   {
      Eina.Log.Debug("function efl_access_object_access_parent_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ObjectConcrete)wrapper).SetAccessParent( parent);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_access_parent_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  parent);
      }
   }
   private static efl_access_object_access_parent_set_delegate efl_access_object_access_parent_set_static_delegate;


    private delegate  void efl_access_object_description_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.ReadingInfoCb description_cb,    System.IntPtr data);


    public delegate  void efl_access_object_description_cb_set_api_delegate(System.IntPtr obj,   Efl.Access.ReadingInfoCb description_cb,    System.IntPtr data);
    public static Efl.Eo.FunctionWrapper<efl_access_object_description_cb_set_api_delegate> efl_access_object_description_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_description_cb_set_api_delegate>(_Module, "efl_access_object_description_cb_set");
    private static  void description_cb_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoCb description_cb,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_access_object_description_cb_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ObjectConcrete)wrapper).SetDescriptionCb( description_cb,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_description_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  description_cb,  data);
      }
   }
   private static efl_access_object_description_cb_set_delegate efl_access_object_description_cb_set_static_delegate;


    private delegate  void efl_access_object_gesture_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.GestureCb gesture_cb,    System.IntPtr data);


    public delegate  void efl_access_object_gesture_cb_set_api_delegate(System.IntPtr obj,   Efl.Access.GestureCb gesture_cb,    System.IntPtr data);
    public static Efl.Eo.FunctionWrapper<efl_access_object_gesture_cb_set_api_delegate> efl_access_object_gesture_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_gesture_cb_set_api_delegate>(_Module, "efl_access_object_gesture_cb_set");
    private static  void gesture_cb_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.GestureCb gesture_cb,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_access_object_gesture_cb_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ObjectConcrete)wrapper).SetGestureCb( gesture_cb,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_gesture_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  gesture_cb,  data);
      }
   }
   private static efl_access_object_gesture_cb_set_delegate efl_access_object_gesture_cb_set_static_delegate;


    private delegate  System.IntPtr efl_access_object_access_children_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_access_object_access_children_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_access_children_get_api_delegate> efl_access_object_access_children_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_children_get_api_delegate>(_Module, "efl_access_object_access_children_get");
    private static  System.IntPtr access_children_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_access_children_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Access.Object> _ret_var = default(Eina.List<Efl.Access.Object>);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetAccessChildren();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_access_object_access_children_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_access_children_get_delegate efl_access_object_access_children_get_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_access_object_role_name_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_access_object_role_name_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_role_name_get_api_delegate> efl_access_object_role_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_role_name_get_api_delegate>(_Module, "efl_access_object_role_name_get");
    private static  System.String role_name_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_role_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetRoleName();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_role_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_role_name_get_delegate efl_access_object_role_name_get_static_delegate;


    private delegate  System.IntPtr efl_access_object_attributes_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_access_object_attributes_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_attributes_get_api_delegate> efl_access_object_attributes_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_attributes_get_api_delegate>(_Module, "efl_access_object_attributes_get");
    private static  System.IntPtr attributes_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_attributes_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Access.Attribute> _ret_var = default(Eina.List<Efl.Access.Attribute>);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetAttributes();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; _ret_var.OwnContent = false; return _ret_var.Handle;
      } else {
         return efl_access_object_attributes_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_attributes_get_delegate efl_access_object_attributes_get_static_delegate;


    private delegate Efl.Access.ReadingInfoTypeMask efl_access_object_reading_info_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Access.ReadingInfoTypeMask efl_access_object_reading_info_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_get_api_delegate> efl_access_object_reading_info_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_get_api_delegate>(_Module, "efl_access_object_reading_info_type_get");
    private static Efl.Access.ReadingInfoTypeMask reading_info_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_reading_info_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.ReadingInfoTypeMask _ret_var = default(Efl.Access.ReadingInfoTypeMask);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetReadingInfoType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_reading_info_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_reading_info_type_get_delegate efl_access_object_reading_info_type_get_static_delegate;


    private delegate  void efl_access_object_reading_info_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.ReadingInfoTypeMask reading_info);


    public delegate  void efl_access_object_reading_info_type_set_api_delegate(System.IntPtr obj,   Efl.Access.ReadingInfoTypeMask reading_info);
    public static Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_set_api_delegate> efl_access_object_reading_info_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_set_api_delegate>(_Module, "efl_access_object_reading_info_type_set");
    private static  void reading_info_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoTypeMask reading_info)
   {
      Eina.Log.Debug("function efl_access_object_reading_info_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ObjectConcrete)wrapper).SetReadingInfoType( reading_info);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_reading_info_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  reading_info);
      }
   }
   private static efl_access_object_reading_info_type_set_delegate efl_access_object_reading_info_type_set_static_delegate;


    private delegate  int efl_access_object_index_in_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_access_object_index_in_parent_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_index_in_parent_get_api_delegate> efl_access_object_index_in_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_index_in_parent_get_api_delegate>(_Module, "efl_access_object_index_in_parent_get");
    private static  int index_in_parent_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_index_in_parent_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetIndexInParent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_index_in_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_index_in_parent_get_delegate efl_access_object_index_in_parent_get_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_access_object_description_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_access_object_description_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_description_get_api_delegate> efl_access_object_description_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_description_get_api_delegate>(_Module, "efl_access_object_description_get");
    private static  System.String description_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_description_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetDescription();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_description_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_description_get_delegate efl_access_object_description_get_static_delegate;


    private delegate  void efl_access_object_description_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String description);


    public delegate  void efl_access_object_description_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String description);
    public static Efl.Eo.FunctionWrapper<efl_access_object_description_set_api_delegate> efl_access_object_description_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_description_set_api_delegate>(_Module, "efl_access_object_description_set");
    private static  void description_set(System.IntPtr obj, System.IntPtr pd,   System.String description)
   {
      Eina.Log.Debug("function efl_access_object_description_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ObjectConcrete)wrapper).SetDescription( description);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_description_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  description);
      }
   }
   private static efl_access_object_description_set_delegate efl_access_object_description_set_static_delegate;


    private delegate Efl.Access.StateSet efl_access_object_state_set_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Access.StateSet efl_access_object_state_set_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_state_set_get_api_delegate> efl_access_object_state_set_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_state_set_get_api_delegate>(_Module, "efl_access_object_state_set_get");
    private static Efl.Access.StateSet state_set_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_state_set_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.StateSet _ret_var = default(Efl.Access.StateSet);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetStateSet();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_state_set_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_state_set_get_delegate efl_access_object_state_set_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_object_can_highlight_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_object_can_highlight_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_get_api_delegate> efl_access_object_can_highlight_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_get_api_delegate>(_Module, "efl_access_object_can_highlight_get");
    private static bool can_highlight_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_can_highlight_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetCanHighlight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_can_highlight_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_can_highlight_get_delegate efl_access_object_can_highlight_get_static_delegate;


    private delegate  void efl_access_object_can_highlight_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool can_highlight);


    public delegate  void efl_access_object_can_highlight_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool can_highlight);
    public static Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_set_api_delegate> efl_access_object_can_highlight_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_set_api_delegate>(_Module, "efl_access_object_can_highlight_set");
    private static  void can_highlight_set(System.IntPtr obj, System.IntPtr pd,  bool can_highlight)
   {
      Eina.Log.Debug("function efl_access_object_can_highlight_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ObjectConcrete)wrapper).SetCanHighlight( can_highlight);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_can_highlight_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  can_highlight);
      }
   }
   private static efl_access_object_can_highlight_set_delegate efl_access_object_can_highlight_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_access_object_translation_domain_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_access_object_translation_domain_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_get_api_delegate> efl_access_object_translation_domain_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_get_api_delegate>(_Module, "efl_access_object_translation_domain_get");
    private static  System.String translation_domain_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_translation_domain_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetTranslationDomain();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_translation_domain_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_translation_domain_get_delegate efl_access_object_translation_domain_get_static_delegate;


    private delegate  void efl_access_object_translation_domain_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain);


    public delegate  void efl_access_object_translation_domain_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain);
    public static Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_set_api_delegate> efl_access_object_translation_domain_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_set_api_delegate>(_Module, "efl_access_object_translation_domain_set");
    private static  void translation_domain_set(System.IntPtr obj, System.IntPtr pd,   System.String domain)
   {
      Eina.Log.Debug("function efl_access_object_translation_domain_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ObjectConcrete)wrapper).SetTranslationDomain( domain);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_translation_domain_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  domain);
      }
   }
   private static efl_access_object_translation_domain_set_delegate efl_access_object_translation_domain_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_access_object_access_root_get_delegate();


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Object efl_access_object_access_root_get_api_delegate();
    public static Efl.Eo.FunctionWrapper<efl_access_object_access_root_get_api_delegate> efl_access_object_access_root_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_root_get_api_delegate>(_Module, "efl_access_object_access_root_get");
    private static Efl.Object access_root_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_access_root_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ObjectConcrete.GetAccessRoot();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_access_root_get_ptr.Value.Delegate();
      }
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_object_gesture_do_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.GestureInfo_StructInternal gesture_info);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_object_gesture_do_api_delegate(System.IntPtr obj,   Efl.Access.GestureInfo_StructInternal gesture_info);
    public static Efl.Eo.FunctionWrapper<efl_access_object_gesture_do_api_delegate> efl_access_object_gesture_do_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_gesture_do_api_delegate>(_Module, "efl_access_object_gesture_do");
    private static bool gesture_do(System.IntPtr obj, System.IntPtr pd,  Efl.Access.GestureInfo_StructInternal gesture_info)
   {
      Eina.Log.Debug("function efl_access_object_gesture_do was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_gesture_info = Efl.Access.GestureInfo_StructConversion.ToManaged(gesture_info);
                     bool _ret_var = default(bool);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GestureDo( _in_gesture_info);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_object_gesture_do_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  gesture_info);
      }
   }
   private static efl_access_object_gesture_do_delegate efl_access_object_gesture_do_static_delegate;


    private delegate  void efl_access_object_attribute_append_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value);


    public delegate  void efl_access_object_attribute_append_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value);
    public static Efl.Eo.FunctionWrapper<efl_access_object_attribute_append_api_delegate> efl_access_object_attribute_append_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_attribute_append_api_delegate>(_Module, "efl_access_object_attribute_append");
    private static  void attribute_append(System.IntPtr obj, System.IntPtr pd,   System.String key,   System.String value)
   {
      Eina.Log.Debug("function efl_access_object_attribute_append was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ObjectConcrete)wrapper).AppendAttribute( key,  value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_attribute_append_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  value);
      }
   }
   private static efl_access_object_attribute_append_delegate efl_access_object_attribute_append_static_delegate;


    private delegate  void efl_access_object_attributes_clear_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_access_object_attributes_clear_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_attributes_clear_api_delegate> efl_access_object_attributes_clear_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_attributes_clear_api_delegate>(_Module, "efl_access_object_attributes_clear");
    private static  void attributes_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_attributes_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ObjectConcrete)wrapper).ClearAttributes();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_access_object_attributes_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_attributes_clear_delegate efl_access_object_attributes_clear_static_delegate;


    private delegate Efl.Access.Event.Handler efl_access_object_event_handler_add_delegate(  Efl.EventCb cb,    System.IntPtr data);


    public delegate Efl.Access.Event.Handler efl_access_object_event_handler_add_api_delegate(  Efl.EventCb cb,    System.IntPtr data);
    public static Efl.Eo.FunctionWrapper<efl_access_object_event_handler_add_api_delegate> efl_access_object_event_handler_add_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_event_handler_add_api_delegate>(_Module, "efl_access_object_event_handler_add");
    private static Efl.Access.Event.Handler event_handler_add(System.IntPtr obj, System.IntPtr pd,  Efl.EventCb cb,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_access_object_event_handler_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      Efl.Access.Event.Handler _ret_var = default(Efl.Access.Event.Handler);
         try {
            _ret_var = ObjectConcrete.AddEventHandler( cb,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_object_event_handler_add_ptr.Value.Delegate( cb,  data);
      }
   }


    private delegate  void efl_access_object_event_handler_del_delegate(  Efl.Access.Event.Handler handler);


    public delegate  void efl_access_object_event_handler_del_api_delegate(  Efl.Access.Event.Handler handler);
    public static Efl.Eo.FunctionWrapper<efl_access_object_event_handler_del_api_delegate> efl_access_object_event_handler_del_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_event_handler_del_api_delegate>(_Module, "efl_access_object_event_handler_del");
    private static  void event_handler_del(System.IntPtr obj, System.IntPtr pd,  Efl.Access.Event.Handler handler)
   {
      Eina.Log.Debug("function efl_access_object_event_handler_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ObjectConcrete.DelEventHandler( handler);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_event_handler_del_ptr.Value.Delegate( handler);
      }
   }


    private delegate  void efl_access_object_event_emit_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object accessible,    System.IntPtr kw_event,    System.IntPtr event_info);


    public delegate  void efl_access_object_event_emit_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object accessible,    System.IntPtr kw_event,    System.IntPtr event_info);
    public static Efl.Eo.FunctionWrapper<efl_access_object_event_emit_api_delegate> efl_access_object_event_emit_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_event_emit_api_delegate>(_Module, "efl_access_object_event_emit");
    private static  void event_emit(System.IntPtr obj, System.IntPtr pd,  Efl.Access.Object accessible,   System.IntPtr kw_event,   System.IntPtr event_info)
   {
      Eina.Log.Debug("function efl_access_object_event_emit was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_kw_event = Eina.PrimitiveConversion.PointerToManaged<Efl.EventDescription>(kw_event);
                                                   
         try {
            ObjectConcrete.EmitEvent( accessible,  _in_kw_event,  event_info);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_access_object_event_emit_ptr.Value.Delegate( accessible,  kw_event,  event_info);
      }
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_object_relationship_append_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object relation_object);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_object_relationship_append_api_delegate(System.IntPtr obj,   Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object relation_object);
    public static Efl.Eo.FunctionWrapper<efl_access_object_relationship_append_api_delegate> efl_access_object_relationship_append_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relationship_append_api_delegate>(_Module, "efl_access_object_relationship_append");
    private static bool relationship_append(System.IntPtr obj, System.IntPtr pd,  Efl.Access.RelationType type,  Efl.Access.Object relation_object)
   {
      Eina.Log.Debug("function efl_access_object_relationship_append was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((ObjectConcrete)wrapper).AppendRelationship( type,  relation_object);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_object_relationship_append_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  relation_object);
      }
   }
   private static efl_access_object_relationship_append_delegate efl_access_object_relationship_append_static_delegate;


    private delegate  void efl_access_object_relationship_remove_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object relation_object);


    public delegate  void efl_access_object_relationship_remove_api_delegate(System.IntPtr obj,   Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object relation_object);
    public static Efl.Eo.FunctionWrapper<efl_access_object_relationship_remove_api_delegate> efl_access_object_relationship_remove_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relationship_remove_api_delegate>(_Module, "efl_access_object_relationship_remove");
    private static  void relationship_remove(System.IntPtr obj, System.IntPtr pd,  Efl.Access.RelationType type,  Efl.Access.Object relation_object)
   {
      Eina.Log.Debug("function efl_access_object_relationship_remove was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ObjectConcrete)wrapper).RelationshipRemove( type,  relation_object);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_relationship_remove_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  relation_object);
      }
   }
   private static efl_access_object_relationship_remove_delegate efl_access_object_relationship_remove_static_delegate;


    private delegate  void efl_access_object_relationships_clear_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_access_object_relationships_clear_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_relationships_clear_api_delegate> efl_access_object_relationships_clear_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relationships_clear_api_delegate>(_Module, "efl_access_object_relationships_clear");
    private static  void relationships_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_relationships_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ObjectConcrete)wrapper).ClearRelationships();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_access_object_relationships_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_relationships_clear_delegate efl_access_object_relationships_clear_static_delegate;


    private delegate  void efl_access_object_state_notify_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.StateSet state_types_mask,  [MarshalAs(UnmanagedType.U1)]  bool recursive);


    public delegate  void efl_access_object_state_notify_api_delegate(System.IntPtr obj,   Efl.Access.StateSet state_types_mask,  [MarshalAs(UnmanagedType.U1)]  bool recursive);
    public static Efl.Eo.FunctionWrapper<efl_access_object_state_notify_api_delegate> efl_access_object_state_notify_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_state_notify_api_delegate>(_Module, "efl_access_object_state_notify");
    private static  void state_notify(System.IntPtr obj, System.IntPtr pd,  Efl.Access.StateSet state_types_mask,  bool recursive)
   {
      Eina.Log.Debug("function efl_access_object_state_notify was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ObjectConcrete)wrapper).StateNotify( state_types_mask,  recursive);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_state_notify_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  state_types_mask,  recursive);
      }
   }
   private static efl_access_object_state_notify_delegate efl_access_object_state_notify_static_delegate;
}
} } 
namespace Efl { namespace Access { 
/// <summary>Type of accessibility object</summary>
public enum Type
{
/// <summary>default accessible object</summary>
Regular = 0,
/// <summary>skip object and its children in accessibility hierarchy</summary>
Disabled = 1,
/// <summary>skip object in accessibility hierarchy</summary>
Skipped = 2,
}
} } 
namespace Efl { namespace Access { 
/// <summary>Describes the role of an object visible to Accessibility Clients.</summary>
public enum Role
{
/// <summary>Role: invalid</summary>
Invalid = 0,
/// <summary>Role: accelerator label</summary>
AcceleratorLabel = 1,
/// <summary>Role: alert</summary>
Alert = 2,
/// <summary>Role: animation</summary>
Animation = 3,
/// <summary>Role: arrow</summary>
Arrow = 4,
/// <summary>Role: calendar</summary>
Calendar = 5,
/// <summary>Role: canvas</summary>
Canvas = 6,
/// <summary>Role: check box</summary>
CheckBox = 7,
/// <summary>Role: check menu item</summary>
CheckMenuItem = 8,
/// <summary>Role: color chooser</summary>
ColorChooser = 9,
/// <summary>Role: column header</summary>
ColumnHeader = 10,
/// <summary>Role: combo box</summary>
ComboBox = 11,
/// <summary>Role: data editor</summary>
DateEditor = 12,
/// <summary>Role: desktop icon</summary>
DesktopIcon = 13,
/// <summary>Role: desktop frame</summary>
DesktopFrame = 14,
/// <summary>Role: dial</summary>
Dial = 15,
/// <summary>Role: dialog</summary>
Dialog = 16,
/// <summary>Role: directory pane</summary>
DirectoryPane = 17,
/// <summary>Role: drawing area</summary>
DrawingArea = 18,
/// <summary>Role: file chooser</summary>
FileChooser = 19,
/// <summary>Role: filler</summary>
Filler = 20,
/// <summary>Role: focus traversable</summary>
FocusTraversable = 21,
/// <summary>Role: font chooser</summary>
FontChooser = 22,
/// <summary>Role: frame</summary>
Frame = 23,
/// <summary>Role: glass pane</summary>
GlassPane = 24,
/// <summary>Role: HTML container</summary>
HtmlContainer = 25,
/// <summary>Role: icon</summary>
Icon = 26,
/// <summary>Role: image</summary>
Image = 27,
/// <summary>Role: internal frame</summary>
InternalFrame = 28,
/// <summary>Role: label</summary>
Label = 29,
/// <summary>Role: layered pane</summary>
LayeredPane = 30,
/// <summary>Role: list</summary>
List = 31,
/// <summary>Role: list item</summary>
ListItem = 32,
/// <summary>Role: menu</summary>
Menu = 33,
/// <summary>Role: menu bar</summary>
MenuBar = 34,
/// <summary>Role: menu item</summary>
MenuItem = 35,
/// <summary>Role: option pane</summary>
OptionPane = 36,
/// <summary>Role: page tab</summary>
PageTab = 37,
/// <summary>Role: page tab list</summary>
PageTabList = 38,
/// <summary>Role: panel</summary>
Panel = 39,
/// <summary>Role: password text</summary>
PasswordText = 40,
/// <summary>Role: popup menu</summary>
PopupMenu = 41,
/// <summary>Role: progress bar</summary>
ProgressBar = 42,
/// <summary>Role: push button</summary>
PushButton = 43,
/// <summary>Role: radio button</summary>
RadioButton = 44,
/// <summary>Role: radio menu item</summary>
RadioMenuItem = 45,
/// <summary>Role: root pane</summary>
RootPane = 46,
/// <summary>Role: row header</summary>
RowHeader = 47,
/// <summary>Role: scroll bar</summary>
ScrollBar = 48,
/// <summary>Role: scroll pane</summary>
ScrollPane = 49,
/// <summary>Role: separator</summary>
Separator = 50,
/// <summary>Role: slider</summary>
Slider = 51,
/// <summary>Role: spin button</summary>
SpinButton = 52,
/// <summary>Role: split pane</summary>
SplitPane = 53,
/// <summary>Role: status bar</summary>
StatusBar = 54,
/// <summary>Role: table</summary>
Table = 55,
/// <summary>Role: table cell</summary>
TableCell = 56,
/// <summary>Role: table column header</summary>
TableColumnHeader = 57,
/// <summary>Role: table row header</summary>
TableRowHeader = 58,
/// <summary>Role: tearoff menu item</summary>
TearoffMenuItem = 59,
/// <summary>Role: terminal</summary>
Terminal = 60,
/// <summary>Role: text</summary>
Text = 61,
/// <summary>Role: toggle button</summary>
ToggleButton = 62,
/// <summary>Role: too bar</summary>
ToolBar = 63,
/// <summary>Role: tool tip</summary>
ToolTip = 64,
/// <summary>Role: tree</summary>
Tree = 65,
/// <summary>Role: tree table</summary>
TreeTable = 66,
/// <summary>Role: unknown</summary>
Unknown = 67,
/// <summary>Role: viewport</summary>
Viewport = 68,
/// <summary>Role: window</summary>
Window = 69,
/// <summary>Role: extended</summary>
Extended = 70,
/// <summary>Role: header</summary>
Header = 71,
/// <summary>Role: footer</summary>
Footer = 72,
/// <summary>Role: paragraph</summary>
Paragraph = 73,
/// <summary>Role: ruler</summary>
Ruler = 74,
/// <summary>Role: application</summary>
Application = 75,
/// <summary>Role: autocomplete</summary>
Autocomplete = 76,
/// <summary>Role: editbar</summary>
Editbar = 77,
/// <summary>Role: embedded</summary>
Embedded = 78,
/// <summary>Role: entry</summary>
Entry = 79,
/// <summary>Role: chart</summary>
Chart = 80,
/// <summary>Role: caption</summary>
Caption = 81,
/// <summary>Role: document frame</summary>
DocumentFrame = 82,
/// <summary>Role: heading</summary>
Heading = 83,
/// <summary>Role: page</summary>
Page = 84,
/// <summary>Role: section</summary>
Section = 85,
/// <summary>Role: redundant object</summary>
RedundantObject = 86,
/// <summary>Role: form</summary>
Form = 87,
/// <summary>Role: link</summary>
Link = 88,
/// <summary>Role: input method window</summary>
InputMethodWindow = 89,
/// <summary>Role: table row</summary>
TableRow = 90,
/// <summary>Role: table item</summary>
TreeItem = 91,
/// <summary>Role: document spreadsheet</summary>
DocumentSpreadsheet = 92,
/// <summary>Role: document presentation</summary>
DocumentPresentation = 93,
/// <summary>Role: document text</summary>
DocumentText = 94,
/// <summary>Role: document web</summary>
DocumentWeb = 95,
/// <summary>Role: document email</summary>
DocumentEmail = 96,
/// <summary>Role: comment</summary>
Comment = 97,
/// <summary>Role: list box</summary>
ListBox = 98,
/// <summary>Role: grouping</summary>
Grouping = 99,
/// <summary>Role: image map</summary>
ImageMap = 100,
/// <summary>Role: notification</summary>
Notification = 101,
/// <summary>Role: info bar</summary>
InfoBar = 102,
/// <summary>Last enum entry sentinel</summary>
LastDefined = 103,
}
} } 
namespace Efl { namespace Access { 
/// <summary>Describes the possible states for an object visible to accessibility clients.</summary>
public enum StateType
{
/// <summary>State: invalid</summary>
Invalid = 0,
/// <summary>State: active</summary>
Active = 1,
/// <summary>State: armed</summary>
Armed = 2,
/// <summary>State: busy</summary>
Busy = 3,
/// <summary>State: checked</summary>
Checked = 4,
/// <summary>State: collapsed</summary>
Collapsed = 5,
/// <summary>State: defunct</summary>
Defunct = 6,
/// <summary>State: editable</summary>
Editable = 7,
/// <summary>State: enabled</summary>
Enabled = 8,
/// <summary>State: expandable</summary>
Expandable = 9,
/// <summary>State: expanded</summary>
Expanded = 10,
/// <summary>State: focusable</summary>
Focusable = 11,
/// <summary>State: focused</summary>
Focused = 12,
/// <summary>State: has a tooltip</summary>
HasTooltip = 13,
/// <summary>State: horizontal</summary>
Horizontal = 14,
/// <summary>State: minimized</summary>
Minimized = 15,
/// <summary>State: modal</summary>
Modal = 16,
/// <summary>State: multi line</summary>
MultiLine = 17,
/// <summary>State: multiselectable</summary>
Multiselectable = 18,
/// <summary>State: opaque</summary>
Opaque = 19,
/// <summary>State: pressed</summary>
Pressed = 20,
/// <summary>State: resizable</summary>
Resizable = 21,
/// <summary>State: selectable</summary>
Selectable = 22,
/// <summary>State: selected</summary>
Selected = 23,
/// <summary>State: sensitive</summary>
Sensitive = 24,
/// <summary>State: showing</summary>
Showing = 25,
/// <summary>State: single line</summary>
SingleLine = 26,
/// <summary>State: stale</summary>
Stale = 27,
/// <summary>State: transient</summary>
Transient = 28,
/// <summary>State: vertical</summary>
Vertical = 29,
/// <summary>State: visible</summary>
Visible = 30,
/// <summary>State: manage descendants</summary>
ManagesDescendants = 31,
/// <summary>State: indeterminate</summary>
Indeterminate = 32,
/// <summary>State: required</summary>
Required = 33,
/// <summary>State: truncated</summary>
Truncated = 34,
/// <summary>State: animated</summary>
Animated = 35,
/// <summary>State: invalid entry</summary>
InvalidEntry = 36,
/// <summary>State: supports autocompletion</summary>
SupportsAutocompletion = 37,
/// <summary>State: selectable text</summary>
SelectableText = 38,
/// <summary>State: is default</summary>
IsDefault = 39,
/// <summary>State: visited</summary>
Visited = 40,
/// <summary>State: checkable</summary>
Checkable = 41,
/// <summary>State: has popup</summary>
HasPopup = 42,
/// <summary>State: read only</summary>
ReadOnly = 43,
/// <summary>State: highlighted</summary>
Highlighted = 44,
/// <summary>State: highlightable</summary>
Highlightable = 45,
/// <summary>Last enum entry sentinel</summary>
LastDefined = 46,
}
} } 
namespace Efl { namespace Access { 
/// <summary>Describes the relationship between two objects.</summary>
public enum RelationType
{
/// <summary>No relation</summary>
Null = 0,
/// <summary>Label for relation</summary>
LabelFor = 1,
/// <summary>Labelled by relation</summary>
LabelledBy = 2,
/// <summary>Controller for relation</summary>
ControllerFor = 3,
/// <summary>Controlled by relation</summary>
ControlledBy = 4,
/// <summary>Member of relation</summary>
MemberOf = 5,
/// <summary>Tooltip for relation</summary>
TooltipFor = 6,
/// <summary>Node child of relation</summary>
NodeChildOf = 7,
/// <summary>Node parent of relation</summary>
NodeParentOf = 8,
/// <summary>Extended relation</summary>
Extended = 9,
/// <summary>Flows to relation</summary>
FlowsTo = 10,
/// <summary>Flows from relation</summary>
FlowsFrom = 11,
/// <summary>Subwindow of relation</summary>
SubwindowOf = 12,
/// <summary>Embeds relation</summary>
Embeds = 13,
/// <summary>Embedded by relation</summary>
EmbeddedBy = 14,
/// <summary>Popup for relation</summary>
PopupFor = 15,
/// <summary>Parent window of relation</summary>
ParentWindowOf = 16,
/// <summary>Description for relation</summary>
DescriptionFor = 17,
/// <summary>Described by relation</summary>
DescribedBy = 18,
/// <summary>Last enum entry sentinel</summary>
LastDefined = 19,
}
} } 
namespace Efl { namespace Access { namespace Reading { namespace Info { 
/// <summary>The accessible Reading information type that can be read.</summary>
public enum Type
{
/// <summary>Name should be read</summary>
Name = 1,
/// <summary>Role should be read</summary>
Role = 2,
/// <summary>description should be read.</summary>
Description = 4,
/// <summary>State should be read.</summary>
State = 8,
}
} } } } 
namespace Efl { namespace Access { 
/// <summary></summary>
public enum Gesture
{
/// <summary></summary>
OneFingerHover = 0,
/// <summary></summary>
TwoFingersHover = 1,
/// <summary></summary>
ThreeFingersHover = 2,
/// <summary></summary>
OneFingerFlickLeft = 3,
/// <summary></summary>
OneFingerFlickRight = 4,
/// <summary></summary>
OneFingerFlickUp = 5,
/// <summary></summary>
OneFingerFlickDown = 6,
/// <summary></summary>
TwoFingersFlickLeft = 7,
/// <summary></summary>
TwoFingersFlickRight = 8,
/// <summary></summary>
TwoFingersFlickUp = 9,
/// <summary></summary>
TwoFingersFlickDown = 10,
/// <summary></summary>
ThreeFingersFlickLeft = 11,
/// <summary></summary>
ThreeFingersFlickRight = 12,
/// <summary></summary>
ThreeFingersFlickUp = 13,
/// <summary></summary>
ThreeFingersFlickDown = 14,
/// <summary></summary>
OneFingerSingleTap = 15,
/// <summary></summary>
OneFingerDoubleTap = 16,
/// <summary></summary>
OneFingerTripleTap = 17,
/// <summary></summary>
TwoFingersSingleTap = 18,
/// <summary></summary>
TwoFingersDoubleTap = 19,
/// <summary></summary>
TwoFingersTripleTap = 20,
/// <summary></summary>
ThreeFingersSingleTap = 21,
/// <summary></summary>
ThreeFingersDoubleTap = 22,
/// <summary></summary>
ThreeFingersTripleTap = 23,
/// <summary></summary>
OneFingerFlickLeftReturn = 24,
/// <summary></summary>
OneFingerFlickRightReturn = 25,
/// <summary></summary>
OneFingerFlickUpReturn = 26,
/// <summary></summary>
OneFingerFlickDownReturn = 27,
/// <summary></summary>
TwoFingersFlickLeftReturn = 28,
/// <summary></summary>
TwoFingersFlickRightReturn = 29,
/// <summary></summary>
TwoFingersFlickUpReturn = 30,
/// <summary></summary>
TwoFingersFlickDownReturn = 31,
/// <summary></summary>
ThreeFingersFlickLeftReturn = 32,
/// <summary></summary>
ThreeFingersFlickRightReturn = 33,
/// <summary></summary>
ThreeFingersFlickUpReturn = 34,
/// <summary></summary>
ThreeFingersFlickDownReturn = 35,
}
} } 
namespace Efl { namespace Access { 
/// <summary></summary>
public enum GestureState
{
/// <summary></summary>
Start = 0,
/// <summary></summary>
Move = 1,
/// <summary></summary>
End = 2,
/// <summary></summary>
Abort = 3,
}
} } 
namespace Efl { namespace Access { namespace Event { 
/// <summary>Accessibility event listener</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Handler
{
///<summary>Placeholder field</summary>
public IntPtr field;
public static implicit operator Handler(IntPtr ptr)
   {
      var tmp = (Handler_StructInternal)Marshal.PtrToStructure(ptr, typeof(Handler_StructInternal));
      return Handler_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct Handler.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Handler_StructInternal
{
internal IntPtr field;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator Handler(Handler_StructInternal struct_)
   {
      return Handler_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator Handler_StructInternal(Handler struct_)
   {
      return Handler_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct Handler</summary>
public static class Handler_StructConversion
{
   internal static Handler_StructInternal ToInternal(Handler _external_struct)
   {
      var _internal_struct = new Handler_StructInternal();


      return _internal_struct;
   }

   internal static Handler ToManaged(Handler_StructInternal _internal_struct)
   {
      var _external_struct = new Handler();


      return _external_struct;
   }

}
} } } 
namespace Efl { namespace Access { namespace Event { namespace StateChanged { 
/// <summary>Accessibility state changed event data</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Data
{
   /// <summary>Type of the state changed event</summary>
   public Efl.Access.StateType Type;
   /// <summary>New value</summary>
   public bool New_value;
   ///<summary>Constructor for Data.</summary>
   public Data(
      Efl.Access.StateType Type=default(Efl.Access.StateType),
      bool New_value=default(bool)   )
   {
      this.Type = Type;
      this.New_value = New_value;
   }
public static implicit operator Data(IntPtr ptr)
   {
      var tmp = (Data_StructInternal)Marshal.PtrToStructure(ptr, typeof(Data_StructInternal));
      return Data_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct Data.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Data_StructInternal
{
   
   public Efl.Access.StateType Type;
///<summary>Internal wrapper for field New_value</summary>
public System.Byte New_value;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator Data(Data_StructInternal struct_)
   {
      return Data_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator Data_StructInternal(Data struct_)
   {
      return Data_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct Data</summary>
public static class Data_StructConversion
{
   internal static Data_StructInternal ToInternal(Data _external_struct)
   {
      var _internal_struct = new Data_StructInternal();

      _internal_struct.Type = _external_struct.Type;
      _internal_struct.New_value = _external_struct.New_value ? (byte)1 : (byte)0;

      return _internal_struct;
   }

   internal static Data ToManaged(Data_StructInternal _internal_struct)
   {
      var _external_struct = new Data();

      _external_struct.Type = _internal_struct.Type;
      _external_struct.New_value = _internal_struct.New_value != 0;

      return _external_struct;
   }

}
} } } } 
namespace Efl { namespace Access { namespace Event { namespace GeometryChanged { 
/// <summary>Accessibility geometry changed event data</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Data
{
   /// <summary>X coordinate</summary>
   public  int X;
   /// <summary>Y coordinate</summary>
   public  int Y;
   /// <summary>Width</summary>
   public  int Width;
   /// <summary>Height</summary>
   public  int Height;
   ///<summary>Constructor for Data.</summary>
   public Data(
       int X=default( int),
       int Y=default( int),
       int Width=default( int),
       int Height=default( int)   )
   {
      this.X = X;
      this.Y = Y;
      this.Width = Width;
      this.Height = Height;
   }
public static implicit operator Data(IntPtr ptr)
   {
      var tmp = (Data_StructInternal)Marshal.PtrToStructure(ptr, typeof(Data_StructInternal));
      return Data_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct Data.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Data_StructInternal
{
   
   public  int X;
   
   public  int Y;
   
   public  int Width;
   
   public  int Height;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator Data(Data_StructInternal struct_)
   {
      return Data_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator Data_StructInternal(Data struct_)
   {
      return Data_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct Data</summary>
public static class Data_StructConversion
{
   internal static Data_StructInternal ToInternal(Data _external_struct)
   {
      var _internal_struct = new Data_StructInternal();

      _internal_struct.X = _external_struct.X;
      _internal_struct.Y = _external_struct.Y;
      _internal_struct.Width = _external_struct.Width;
      _internal_struct.Height = _external_struct.Height;

      return _internal_struct;
   }

   internal static Data ToManaged(Data_StructInternal _internal_struct)
   {
      var _external_struct = new Data();

      _external_struct.X = _internal_struct.X;
      _external_struct.Y = _internal_struct.Y;
      _external_struct.Width = _internal_struct.Width;
      _external_struct.Height = _internal_struct.Height;

      return _external_struct;
   }

}
} } } } 
namespace Efl { namespace Access { namespace Event { namespace ChildrenChanged { 
/// <summary>Accessibility children changed event data</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Data
{
   /// <summary>Child is added or not</summary>
   public bool Is_added;
   /// <summary>Child object</summary>
   public Efl.Object Child;
   ///<summary>Constructor for Data.</summary>
   public Data(
      bool Is_added=default(bool),
      Efl.Object Child=default(Efl.Object)   )
   {
      this.Is_added = Is_added;
      this.Child = Child;
   }
public static implicit operator Data(IntPtr ptr)
   {
      var tmp = (Data_StructInternal)Marshal.PtrToStructure(ptr, typeof(Data_StructInternal));
      return Data_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct Data.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Data_StructInternal
{
///<summary>Internal wrapper for field Is_added</summary>
public System.Byte Is_added;
///<summary>Internal wrapper for field Child</summary>
public System.IntPtr Child;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator Data(Data_StructInternal struct_)
   {
      return Data_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator Data_StructInternal(Data struct_)
   {
      return Data_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct Data</summary>
public static class Data_StructConversion
{
   internal static Data_StructInternal ToInternal(Data _external_struct)
   {
      var _internal_struct = new Data_StructInternal();

      _internal_struct.Is_added = _external_struct.Is_added ? (byte)1 : (byte)0;
      _internal_struct.Child = _external_struct.Child.NativeHandle;

      return _internal_struct;
   }

   internal static Data ToManaged(Data_StructInternal _internal_struct)
   {
      var _external_struct = new Data();

      _external_struct.Is_added = _internal_struct.Is_added != 0;

      _external_struct.Child = (Efl.Object) System.Activator.CreateInstance(typeof(Efl.Object), new System.Object[] {_internal_struct.Child});
      Efl.Eo.Globals.efl_ref(_internal_struct.Child);


      return _external_struct;
   }

}
} } } } 
namespace Efl { namespace Access { 
/// <summary>Accessibility Attribute</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Attribute
{
   /// <summary>Attribute key</summary>
   public  System.String Key;
   /// <summary>Attribute value</summary>
   public  System.String Value;
   ///<summary>Constructor for Attribute.</summary>
   public Attribute(
       System.String Key=default( System.String),
       System.String Value=default( System.String)   )
   {
      this.Key = Key;
      this.Value = Value;
   }
public static implicit operator Attribute(IntPtr ptr)
   {
      var tmp = (Attribute_StructInternal)Marshal.PtrToStructure(ptr, typeof(Attribute_StructInternal));
      return Attribute_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct Attribute.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Attribute_StructInternal
{
///<summary>Internal wrapper for field Key</summary>
public System.IntPtr Key;
///<summary>Internal wrapper for field Value</summary>
public System.IntPtr Value;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator Attribute(Attribute_StructInternal struct_)
   {
      return Attribute_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator Attribute_StructInternal(Attribute struct_)
   {
      return Attribute_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct Attribute</summary>
public static class Attribute_StructConversion
{
   internal static Attribute_StructInternal ToInternal(Attribute _external_struct)
   {
      var _internal_struct = new Attribute_StructInternal();

      _internal_struct.Key = Eina.MemoryNative.StrDup(_external_struct.Key);
      _internal_struct.Value = Eina.MemoryNative.StrDup(_external_struct.Value);

      return _internal_struct;
   }

   internal static Attribute ToManaged(Attribute_StructInternal _internal_struct)
   {
      var _external_struct = new Attribute();

      _external_struct.Key = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Key);
      _external_struct.Value = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Value);

      return _external_struct;
   }

}
} } 
namespace Efl { namespace Access { 
/// <summary>Accessibility Relation</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Relation
{
   /// <summary>Relation type</summary>
   public Efl.Access.RelationType Type;
   /// <summary>List with relation objects</summary>
   public Eina.List<Efl.Object> Objects;
   ///<summary>Constructor for Relation.</summary>
   public Relation(
      Efl.Access.RelationType Type=default(Efl.Access.RelationType),
      Eina.List<Efl.Object> Objects=default(Eina.List<Efl.Object>)   )
   {
      this.Type = Type;
      this.Objects = Objects;
   }
public static implicit operator Relation(IntPtr ptr)
   {
      var tmp = (Relation_StructInternal)Marshal.PtrToStructure(ptr, typeof(Relation_StructInternal));
      return Relation_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct Relation.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Relation_StructInternal
{
   
   public Efl.Access.RelationType Type;
   
   public  System.IntPtr Objects;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator Relation(Relation_StructInternal struct_)
   {
      return Relation_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator Relation_StructInternal(Relation struct_)
   {
      return Relation_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct Relation</summary>
public static class Relation_StructConversion
{
   internal static Relation_StructInternal ToInternal(Relation _external_struct)
   {
      var _internal_struct = new Relation_StructInternal();

      _internal_struct.Type = _external_struct.Type;
      _internal_struct.Objects = _external_struct.Objects.Handle;

      return _internal_struct;
   }

   internal static Relation ToManaged(Relation_StructInternal _internal_struct)
   {
      var _external_struct = new Relation();

      _external_struct.Type = _internal_struct.Type;
      _external_struct.Objects = new Eina.List<Efl.Object>(_internal_struct.Objects, false, false);

      return _external_struct;
   }

}
} } 
namespace Efl { namespace Access { 
/// <summary></summary>
[StructLayout(LayoutKind.Sequential)]
public struct GestureInfo
{
   /// <summary>Gesture type</summary>
   public Efl.Access.Gesture Type;
   /// <summary>start gesture x co-ordinate</summary>
   public  int X_beg;
   /// <summary>start gesture y co-ordinate</summary>
   public  int Y_beg;
   /// <summary>end gesture x co-ordinate</summary>
   public  int X_end;
   /// <summary>end gesture y co-ordinate</summary>
   public  int Y_end;
   /// <summary>state of gesture</summary>
   public Efl.Access.GestureState State;
   /// <summary>gesture occurance time</summary>
   public  uint Event_time;
   ///<summary>Constructor for GestureInfo.</summary>
   public GestureInfo(
      Efl.Access.Gesture Type=default(Efl.Access.Gesture),
       int X_beg=default( int),
       int Y_beg=default( int),
       int X_end=default( int),
       int Y_end=default( int),
      Efl.Access.GestureState State=default(Efl.Access.GestureState),
       uint Event_time=default( uint)   )
   {
      this.Type = Type;
      this.X_beg = X_beg;
      this.Y_beg = Y_beg;
      this.X_end = X_end;
      this.Y_end = Y_end;
      this.State = State;
      this.Event_time = Event_time;
   }
public static implicit operator GestureInfo(IntPtr ptr)
   {
      var tmp = (GestureInfo_StructInternal)Marshal.PtrToStructure(ptr, typeof(GestureInfo_StructInternal));
      return GestureInfo_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct GestureInfo.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct GestureInfo_StructInternal
{
   
   public Efl.Access.Gesture Type;
   
   public  int X_beg;
   
   public  int Y_beg;
   
   public  int X_end;
   
   public  int Y_end;
   
   public Efl.Access.GestureState State;
   
   public  uint Event_time;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator GestureInfo(GestureInfo_StructInternal struct_)
   {
      return GestureInfo_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator GestureInfo_StructInternal(GestureInfo struct_)
   {
      return GestureInfo_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct GestureInfo</summary>
public static class GestureInfo_StructConversion
{
   internal static GestureInfo_StructInternal ToInternal(GestureInfo _external_struct)
   {
      var _internal_struct = new GestureInfo_StructInternal();

      _internal_struct.Type = _external_struct.Type;
      _internal_struct.X_beg = _external_struct.X_beg;
      _internal_struct.Y_beg = _external_struct.Y_beg;
      _internal_struct.X_end = _external_struct.X_end;
      _internal_struct.Y_end = _external_struct.Y_end;
      _internal_struct.State = _external_struct.State;
      _internal_struct.Event_time = _external_struct.Event_time;

      return _internal_struct;
   }

   internal static GestureInfo ToManaged(GestureInfo_StructInternal _internal_struct)
   {
      var _external_struct = new GestureInfo();

      _external_struct.Type = _internal_struct.Type;
      _external_struct.X_beg = _internal_struct.X_beg;
      _external_struct.Y_beg = _internal_struct.Y_beg;
      _external_struct.X_end = _internal_struct.X_end;
      _external_struct.Y_end = _internal_struct.Y_end;
      _external_struct.State = _internal_struct.State;
      _external_struct.Event_time = _internal_struct.Event_time;

      return _external_struct;
   }

}
} } 
