#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Access {

/// <summary>Accessibility object state set.</summary>
public struct StateSet
{
    private ulong payload;

    /// <summary>Converts an instance of ulong to this struct.</summary>
    /// <param name="value">The value to be converted.</param>
    /// <returns>A struct with the given value.</returns>
    public static implicit operator StateSet(ulong value)
    {
        return new StateSet{payload=value};
    }

    /// <summary>Converts an instance of this struct to ulong.</summary>
    /// <param name="value">The value to be converted packed in this struct.</param>
    /// <returns>The actual value the alias is wrapping.</returns>
    public static implicit operator ulong(StateSet value)
    {
        return value.payload;
    }

}

}

}

namespace Efl {

namespace Access {

/// <summary>Elementary Accessibility relation set type</summary>
public struct RelationSet
{
    private Eina.List<Efl.Access.Relation> payload;

    /// <summary>Converts an instance of Eina.List<Efl.Access.Relation> to this struct.</summary>
    /// <param name="value">The value to be converted.</param>
    /// <returns>A struct with the given value.</returns>
    public static implicit operator RelationSet(Eina.List<Efl.Access.Relation> value)
    {
        return new RelationSet{payload=value};
    }

    /// <summary>Converts an instance of this struct to Eina.List<Efl.Access.Relation>.</summary>
    /// <param name="value">The value to be converted packed in this struct.</param>
    /// <returns>The actual value the alias is wrapping.</returns>
    public static implicit operator Eina.List<Efl.Access.Relation>(RelationSet value)
    {
        return value.payload;
    }

}

}

}

namespace Efl {

namespace Access {

/// <summary>Accessibility accessible mixin</summary>
[Efl.Access.IObjectConcrete.NativeMethods]
public interface IObject : 
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
void SetI18nName(System.String i18n_name);
    /// <summary>Sets name information callback about widget.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <param name="name_cb">reading information callback</param>
void SetNameCb(Efl.Access.ReadingInfoCb name_cb, System.IntPtr data);
    /// <summary>Gets an all relations between accessible object and other accessible objects.</summary>
/// <returns>Accessible relation set</returns>
Efl.Access.RelationSet GetRelationSet();
    /// <summary>The role of the object in accessibility domain.</summary>
/// <returns>Accessible role</returns>
Efl.Access.Role GetRole();
    /// <summary>Sets the role of the object in accessibility domain.</summary>
/// <param name="role">Accessible role</param>
void SetRole(Efl.Access.Role role);
    /// <summary>Gets object&apos;s accessible parent.</summary>
/// <returns>Accessible parent</returns>
Efl.Access.IObject GetAccessParent();
    /// <summary>Gets object&apos;s accessible parent.</summary>
/// <param name="parent">Accessible parent</param>
void SetAccessParent(Efl.Access.IObject parent);
    /// <summary>Sets contextual information callback about widget.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <param name="description_cb">The function called to provide the accessible description.</param>
/// <param name="data">The data passed to @c description_cb.</param>
void SetDescriptionCb(Efl.Access.ReadingInfoCb description_cb, System.IntPtr data);
    /// <summary>Sets gesture callback to give widget.
/// Warning: Please do not abuse this API. The purpose of this API is to support special application such as screen-reader guidance. Before using this API, please check if there is another way.
/// 
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
void SetGestureCb(Efl.Access.GestureCb gesture_cb, System.IntPtr data);
    /// <summary>Gets object&apos;s accessible children.</summary>
/// <returns>List of widget&apos;s children</returns>
Eina.List<Efl.Access.IObject> GetAccessChildren();
    /// <summary>Gets human-readable string indentifying object accessibility role.</summary>
/// <returns>Accessible role name</returns>
System.String GetRoleName();
    /// <summary>Gets key-value pairs indentifying object extra attributes. Must be free by a user.</summary>
/// <returns>List of object attributes, Must be freed by the user</returns>
Eina.List<Efl.Access.Attribute> GetAttributes();
    /// <summary>Gets reading information types of an accessible object. if no reading information is set, 0 is returned which means all four reading information types will be read on object highlight
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <returns>Reading information types</returns>
Efl.Access.ReadingInfoTypeMask GetReadingInfoType();
    /// <summary>Sets reading information of an accessible object. If set as 0, existing reading info will be deleted and by default all four reading information types like name, role, state and description will be read on object highlight
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <param name="reading_info">Reading information types</param>
void SetReadingInfoType(Efl.Access.ReadingInfoTypeMask reading_info);
    /// <summary>Gets index of the child in parent&apos;s children list.</summary>
/// <returns>Index in children list</returns>
int GetIndexInParent();
    /// <summary>Gets contextual information about object.</summary>
/// <returns>Accessible contextual information</returns>
System.String GetDescription();
    /// <summary>Sets widget contextual information.</summary>
/// <param name="description">Accessible contextual information</param>
void SetDescription(System.String description);
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
void SetCanHighlight(bool can_highlight);
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
void SetTranslationDomain(System.String domain);
        /// <summary>Handles gesture on given widget.</summary>
bool GestureDo(Efl.Access.GestureInfo gesture_info);
    /// <summary>Add key-value pair identifying object extra attribute
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <param name="key">The string key to give extra information</param>
/// <param name="value">The string value to give extra information</param>
void AppendAttribute(System.String key, System.String value);
    /// <summary>delete key-value pair identifying object extra attributes when key is given</summary>
/// <param name="key">The string key to identify the key-value pair</param>
void DelAttribute(System.String key);
    /// <summary>Removes all attributes in accessible object.</summary>
void ClearAttributes();
                /// <summary>Defines the relationship between two accessible objects.
/// Adds a unique relationship between source object and relation_object of a given type.
/// 
/// Relationships can be queried by Assistive Technology clients to provide customized feedback, improving overall user experience.
/// 
/// Relationship_append API is asymmetric, which means that appending, for example, relation EFL_ACCESS_RELATION_TYPE_FLOWS_TO from object A to B, do NOT append relation EFL_ACCESS_RELATION_TYPE_FLOWS_FROM from object B to object A.</summary>
/// <param name="type">Relation type</param>
/// <param name="relation_object">Object to relate to</param>
/// <returns><c>true</c> if relationship was successfully appended, <c>false</c> otherwise</returns>
bool AppendRelationship(Efl.Access.RelationType type, Efl.Access.IObject relation_object);
    /// <summary>Removes the relationship between two accessible objects.
/// If relation_object is NULL function removes all relations of the given type.</summary>
/// <param name="type">Relation type</param>
/// <param name="relation_object">Object to remove relation from</param>
void RelationshipRemove(Efl.Access.RelationType type, Efl.Access.IObject relation_object);
    /// <summary>Removes all relationships in accessible object.</summary>
void ClearRelationships();
    /// <summary>Notifies accessibility clients about current state of the accessible object.
/// Function limits information broadcast to clients to types specified by state_types_mask parameter.
/// 
/// if recursive parameter is set, function will traverse all accessible children and call state_notify function on them.</summary>
void StateNotify(Efl.Access.StateSet state_types_mask, bool recursive);
                                                                                                                                                    /// <summary>Called when property has changed</summary>
    event EventHandler<Efl.Access.IObjectPropertyChangedEvt_Args> PropertyChangedEvt;
    /// <summary>Called when children have changed</summary>
    event EventHandler<Efl.Access.IObjectChildrenChangedEvt_Args> ChildrenChangedEvt;
    /// <summary>Called when state has changed</summary>
    event EventHandler<Efl.Access.IObjectStateChangedEvt_Args> StateChangedEvt;
    /// <summary>Called when boundaries have changed</summary>
    event EventHandler<Efl.Access.IObjectBoundsChangedEvt_Args> BoundsChangedEvt;
    /// <summary>Called when visibility has changed</summary>
    event EventHandler VisibleDataChangedEvt;
    /// <summary>Called when active state of descendant has changed</summary>
    event EventHandler<Efl.Access.IObjectActiveDescendantChangedEvt_Args> ActiveDescendantChangedEvt;
    /// <summary>Called when item is added</summary>
    event EventHandler AddedEvt;
    /// <summary>Called when item is removed</summary>
    event EventHandler RemovedEvt;
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
    Efl.Access.IObject AccessParent {
        get ;
        set ;
    }
    /// <summary>Gets object&apos;s accessible children.</summary>
    /// <value>List of widget&apos;s children</value>
    Eina.List<Efl.Access.IObject> AccessChildren {
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
    /// <summary>Gets reading information types of an accessible object. if no reading information is set, 0 is returned which means all four reading information types will be read on object highlight
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
///<summary>Event argument wrapper for event <see cref="Efl.Access.IObject.PropertyChangedEvt"/>.</summary>
public class IObjectPropertyChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Access.IObject.ChildrenChangedEvt"/>.</summary>
public class IObjectChildrenChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Access.Event.ChildrenChanged.Data arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Access.IObject.StateChangedEvt"/>.</summary>
public class IObjectStateChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Access.Event.StateChanged.Data arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Access.IObject.BoundsChangedEvt"/>.</summary>
public class IObjectBoundsChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Access.Event.GeometryChanged.Data arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Access.IObject.ActiveDescendantChangedEvt"/>.</summary>
public class IObjectActiveDescendantChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Object arg { get; set; }
}
/// <summary>Accessibility accessible mixin</summary>
sealed public class IObjectConcrete :
    Efl.Eo.EoWrapper
    , IObject
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IObjectConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_access_object_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IObject"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IObjectConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Called when property has changed</summary>
    public event EventHandler<Efl.Access.IObjectPropertyChangedEvt_Args> PropertyChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Access.IObjectPropertyChangedEvt_Args args = new Efl.Access.IObjectPropertyChangedEvt_Args();
                        args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_ACCESS_OBJECT_EVENT_PROPERTY_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_PROPERTY_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event PropertyChangedEvt.</summary>
    public void OnPropertyChangedEvt(Efl.Access.IObjectPropertyChangedEvt_Args e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_PROPERTY_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.StringConversion.ManagedStringToNativeUtf8Alloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Eina.MemoryNative.Free(info);
        }
    }
    /// <summary>Called when children have changed</summary>
    public event EventHandler<Efl.Access.IObjectChildrenChangedEvt_Args> ChildrenChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Access.IObjectChildrenChangedEvt_Args args = new Efl.Access.IObjectChildrenChangedEvt_Args();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_ACCESS_OBJECT_EVENT_CHILDREN_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_CHILDREN_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ChildrenChangedEvt.</summary>
    public void OnChildrenChangedEvt(Efl.Access.IObjectChildrenChangedEvt_Args e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_CHILDREN_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when state has changed</summary>
    public event EventHandler<Efl.Access.IObjectStateChangedEvt_Args> StateChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Access.IObjectStateChangedEvt_Args args = new Efl.Access.IObjectStateChangedEvt_Args();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_ACCESS_OBJECT_EVENT_STATE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_STATE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event StateChangedEvt.</summary>
    public void OnStateChangedEvt(Efl.Access.IObjectStateChangedEvt_Args e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_STATE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when boundaries have changed</summary>
    public event EventHandler<Efl.Access.IObjectBoundsChangedEvt_Args> BoundsChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Access.IObjectBoundsChangedEvt_Args args = new Efl.Access.IObjectBoundsChangedEvt_Args();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_ACCESS_OBJECT_EVENT_BOUNDS_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_BOUNDS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event BoundsChangedEvt.</summary>
    public void OnBoundsChangedEvt(Efl.Access.IObjectBoundsChangedEvt_Args e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_BOUNDS_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when visibility has changed</summary>
    public event EventHandler VisibleDataChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_ACCESS_OBJECT_EVENT_VISIBLE_DATA_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_VISIBLE_DATA_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event VisibleDataChangedEvt.</summary>
    public void OnVisibleDataChangedEvt(EventArgs e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_VISIBLE_DATA_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when active state of descendant has changed</summary>
    public event EventHandler<Efl.Access.IObjectActiveDescendantChangedEvt_Args> ActiveDescendantChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Access.IObjectActiveDescendantChangedEvt_Args args = new Efl.Access.IObjectActiveDescendantChangedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_ACCESS_OBJECT_EVENT_ACTIVE_DESCENDANT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_ACTIVE_DESCENDANT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ActiveDescendantChangedEvt.</summary>
    public void OnActiveDescendantChangedEvt(Efl.Access.IObjectActiveDescendantChangedEvt_Args e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_ACTIVE_DESCENDANT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when item is added</summary>
    public event EventHandler AddedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_ACCESS_OBJECT_EVENT_ADDED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_ADDED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AddedEvt.</summary>
    public void OnAddedEvt(EventArgs e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_ADDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when item is removed</summary>
    public event EventHandler RemovedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_ACCESS_OBJECT_EVENT_REMOVED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_REMOVED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event RemovedEvt.</summary>
    public void OnRemovedEvt(EventArgs e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_REMOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    public event EventHandler MoveOutedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_ACCESS_OBJECT_EVENT_MOVE_OUTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_MOVE_OUTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event MoveOutedEvt.</summary>
    public void OnMoveOutedEvt(EventArgs e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_MOVE_OUTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Gets an localized string describing accessible object role name.</summary>
    /// <returns>Localized accessible object role name</returns>
    public System.String GetLocalizedRoleName() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_localized_role_name_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Accessible name of the object.</summary>
    /// <returns>Accessible name</returns>
    public System.String GetI18nName() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_i18n_name_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Accessible name of the object.</summary>
    /// <param name="i18n_name">Accessible name</param>
    public void SetI18nName(System.String i18n_name) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_i18n_name_set_ptr.Value.Delegate(this.NativeHandle,i18n_name);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Sets name information callback about widget.
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <param name="name_cb">reading information callback</param>
    public void SetNameCb(Efl.Access.ReadingInfoCb name_cb, System.IntPtr data) {
                                                         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_name_cb_set_ptr.Value.Delegate(this.NativeHandle,name_cb, data);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Gets an all relations between accessible object and other accessible objects.</summary>
    /// <returns>Accessible relation set</returns>
    public Efl.Access.RelationSet GetRelationSet() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_relation_set_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The role of the object in accessibility domain.</summary>
    /// <returns>Accessible role</returns>
    public Efl.Access.Role GetRole() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_role_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the role of the object in accessibility domain.</summary>
    /// <param name="role">Accessible role</param>
    public void SetRole(Efl.Access.Role role) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_role_set_ptr.Value.Delegate(this.NativeHandle,role);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets object&apos;s accessible parent.</summary>
    /// <returns>Accessible parent</returns>
    public Efl.Access.IObject GetAccessParent() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_access_parent_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets object&apos;s accessible parent.</summary>
    /// <param name="parent">Accessible parent</param>
    public void SetAccessParent(Efl.Access.IObject parent) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_access_parent_set_ptr.Value.Delegate(this.NativeHandle,parent);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Sets contextual information callback about widget.
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <param name="description_cb">The function called to provide the accessible description.</param>
    /// <param name="data">The data passed to @c description_cb.</param>
    public void SetDescriptionCb(Efl.Access.ReadingInfoCb description_cb, System.IntPtr data) {
                                                         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_description_cb_set_ptr.Value.Delegate(this.NativeHandle,description_cb, data);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets gesture callback to give widget.
    /// Warning: Please do not abuse this API. The purpose of this API is to support special application such as screen-reader guidance. Before using this API, please check if there is another way.
    /// 
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    public void SetGestureCb(Efl.Access.GestureCb gesture_cb, System.IntPtr data) {
                                                         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_gesture_cb_set_ptr.Value.Delegate(this.NativeHandle,gesture_cb, data);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Gets object&apos;s accessible children.</summary>
    /// <returns>List of widget&apos;s children</returns>
    public Eina.List<Efl.Access.IObject> GetAccessChildren() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_access_children_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Access.IObject>(_ret_var, true, false);
 }
    /// <summary>Gets human-readable string indentifying object accessibility role.</summary>
    /// <returns>Accessible role name</returns>
    public System.String GetRoleName() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_role_name_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets key-value pairs indentifying object extra attributes. Must be free by a user.</summary>
    /// <returns>List of object attributes, Must be freed by the user</returns>
    public Eina.List<Efl.Access.Attribute> GetAttributes() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_attributes_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Access.Attribute>(_ret_var, true, true);
 }
    /// <summary>Gets reading information types of an accessible object. if no reading information is set, 0 is returned which means all four reading information types will be read on object highlight
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <returns>Reading information types</returns>
    public Efl.Access.ReadingInfoTypeMask GetReadingInfoType() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_reading_info_type_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets reading information of an accessible object. If set as 0, existing reading info will be deleted and by default all four reading information types like name, role, state and description will be read on object highlight
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <param name="reading_info">Reading information types</param>
    public void SetReadingInfoType(Efl.Access.ReadingInfoTypeMask reading_info) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_reading_info_type_set_ptr.Value.Delegate(this.NativeHandle,reading_info);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets index of the child in parent&apos;s children list.</summary>
    /// <returns>Index in children list</returns>
    public int GetIndexInParent() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_index_in_parent_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets contextual information about object.</summary>
    /// <returns>Accessible contextual information</returns>
    public System.String GetDescription() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_description_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets widget contextual information.</summary>
    /// <param name="description">Accessible contextual information</param>
    public void SetDescription(System.String description) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_description_set_ptr.Value.Delegate(this.NativeHandle,description);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets set describing object accessible states.</summary>
    /// <returns>Accessible state set</returns>
    public Efl.Access.StateSet GetStateSet() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_state_set_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets highlightable of given widget.
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <returns>If @c true, the object is highlightable.</returns>
    public bool GetCanHighlight() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_can_highlight_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets highlightable to given widget.
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <param name="can_highlight">If @c true, the object is highlightable.</param>
    public void SetCanHighlight(bool can_highlight) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_can_highlight_set_ptr.Value.Delegate(this.NativeHandle,can_highlight);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
    /// Translation domain should be set if the application wants to support i18n for accessibility &quot;name&quot; and &quot;description&quot; properties.
    /// 
    /// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
    /// 
    /// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
    /// <returns>Translation domain</returns>
    public System.String GetTranslationDomain() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_translation_domain_get_ptr.Value.Delegate(this.NativeHandle);
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
    public void SetTranslationDomain(System.String domain) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_translation_domain_set_ptr.Value.Delegate(this.NativeHandle,domain);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get root object of accessible object hierarchy</summary>
    /// <returns>Root object</returns>
    public static Efl.Object GetAccessRoot() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_access_root_get_ptr.Value.Delegate();
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Handles gesture on given widget.</summary>
    public bool GestureDo(Efl.Access.GestureInfo gesture_info) {
         Efl.Access.GestureInfo.NativeStruct _in_gesture_info = gesture_info;
                        var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_gesture_do_ptr.Value.Delegate(this.NativeHandle,_in_gesture_info);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Add key-value pair identifying object extra attribute
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <param name="key">The string key to give extra information</param>
    /// <param name="value">The string value to give extra information</param>
    public void AppendAttribute(System.String key, System.String value) {
                                                         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_attribute_append_ptr.Value.Delegate(this.NativeHandle,key, value);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>delete key-value pair identifying object extra attributes when key is given</summary>
    /// <param name="key">The string key to identify the key-value pair</param>
    public void DelAttribute(System.String key) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_attribute_del_ptr.Value.Delegate(this.NativeHandle,key);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Removes all attributes in accessible object.</summary>
    public void ClearAttributes() {
         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_attributes_clear_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Register accessibility event listener</summary>
    /// <param name="cb">Callback</param>
    /// <param name="data">Data</param>
    /// <returns>Event handler</returns>
    public static Efl.Access.Event.Handler AddEventHandler(Efl.EventCb cb, System.IntPtr data) {
                                                         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_event_handler_add_ptr.Value.Delegate(cb, data);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Deregister accessibility event listener</summary>
    /// <param name="handler">Event handler</param>
    public static void DelEventHandler(Efl.Access.Event.Handler handler) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_event_handler_del_ptr.Value.Delegate(handler);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Emit event</summary>
    /// <param name="accessible">Accessibility object.</param>
    /// <param name="kw_event">Accessibility event type.</param>
    /// <param name="event_info">Accessibility event details.</param>
    public static void EmitEvent(Efl.Access.IObject accessible, Efl.EventDescription kw_event, System.IntPtr event_info) {
                 var _in_kw_event = Eina.PrimitiveConversion.ManagedToPointerAlloc(kw_event);
                                                                Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_event_emit_ptr.Value.Delegate(accessible, _in_kw_event, event_info);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Defines the relationship between two accessible objects.
    /// Adds a unique relationship between source object and relation_object of a given type.
    /// 
    /// Relationships can be queried by Assistive Technology clients to provide customized feedback, improving overall user experience.
    /// 
    /// Relationship_append API is asymmetric, which means that appending, for example, relation EFL_ACCESS_RELATION_TYPE_FLOWS_TO from object A to B, do NOT append relation EFL_ACCESS_RELATION_TYPE_FLOWS_FROM from object B to object A.</summary>
    /// <param name="type">Relation type</param>
    /// <param name="relation_object">Object to relate to</param>
    /// <returns><c>true</c> if relationship was successfully appended, <c>false</c> otherwise</returns>
    public bool AppendRelationship(Efl.Access.RelationType type, Efl.Access.IObject relation_object) {
                                                         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_relationship_append_ptr.Value.Delegate(this.NativeHandle,type, relation_object);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Removes the relationship between two accessible objects.
    /// If relation_object is NULL function removes all relations of the given type.</summary>
    /// <param name="type">Relation type</param>
    /// <param name="relation_object">Object to remove relation from</param>
    public void RelationshipRemove(Efl.Access.RelationType type, Efl.Access.IObject relation_object) {
                                                         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_relationship_remove_ptr.Value.Delegate(this.NativeHandle,type, relation_object);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Removes all relationships in accessible object.</summary>
    public void ClearRelationships() {
         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_relationships_clear_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Notifies accessibility clients about current state of the accessible object.
    /// Function limits information broadcast to clients to types specified by state_types_mask parameter.
    /// 
    /// if recursive parameter is set, function will traverse all accessible children and call state_notify function on them.</summary>
    public void StateNotify(Efl.Access.StateSet state_types_mask, bool recursive) {
                                                         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_state_notify_ptr.Value.Delegate(this.NativeHandle,state_types_mask, recursive);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Gets an localized string describing accessible object role name.</summary>
    /// <value>Localized accessible object role name</value>
    public System.String LocalizedRoleName {
        get { return GetLocalizedRoleName(); }
    }
    /// <summary>Accessible name of the object.</summary>
    /// <value>Accessible name</value>
    public System.String I18nName {
        get { return GetI18nName(); }
        set { SetI18nName(value); }
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
        set { SetRole(value); }
    }
    /// <summary>Gets object&apos;s accessible parent.</summary>
    /// <value>Accessible parent</value>
    public Efl.Access.IObject AccessParent {
        get { return GetAccessParent(); }
        set { SetAccessParent(value); }
    }
    /// <summary>Gets object&apos;s accessible children.</summary>
    /// <value>List of widget&apos;s children</value>
    public Eina.List<Efl.Access.IObject> AccessChildren {
        get { return GetAccessChildren(); }
    }
    /// <summary>Gets human-readable string indentifying object accessibility role.</summary>
    /// <value>Accessible role name</value>
    public System.String RoleName {
        get { return GetRoleName(); }
    }
    /// <summary>Gets key-value pairs indentifying object extra attributes. Must be free by a user.</summary>
    /// <value>List of object attributes, Must be freed by the user</value>
    public Eina.List<Efl.Access.Attribute> Attributes {
        get { return GetAttributes(); }
    }
    /// <summary>Gets reading information types of an accessible object. if no reading information is set, 0 is returned which means all four reading information types will be read on object highlight
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <value>Reading information types</value>
    public Efl.Access.ReadingInfoTypeMask ReadingInfoType {
        get { return GetReadingInfoType(); }
        set { SetReadingInfoType(value); }
    }
    /// <summary>Gets index of the child in parent&apos;s children list.</summary>
    /// <value>Index in children list</value>
    public int IndexInParent {
        get { return GetIndexInParent(); }
    }
    /// <summary>Gets contextual information about object.</summary>
    /// <value>Accessible contextual information</value>
    public System.String Description {
        get { return GetDescription(); }
        set { SetDescription(value); }
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
        set { SetCanHighlight(value); }
    }
    /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
    /// Translation domain should be set if the application wants to support i18n for accessibility &quot;name&quot; and &quot;description&quot; properties.
    /// 
    /// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
    /// 
    /// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
    /// <value>Translation domain</value>
    public System.String TranslationDomain {
        get { return GetTranslationDomain(); }
        set { SetTranslationDomain(value); }
    }
    /// <summary>Get root object of accessible object hierarchy</summary>
    /// <value>Root object</value>
    public static Efl.Object AccessRoot {
        get { return GetAccessRoot(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Access.IObjectConcrete.efl_access_object_mixin_get();
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

            if (efl_access_object_localized_role_name_get_static_delegate == null)
            {
                efl_access_object_localized_role_name_get_static_delegate = new efl_access_object_localized_role_name_get_delegate(localized_role_name_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLocalizedRoleName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_localized_role_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_localized_role_name_get_static_delegate) });
            }

            if (efl_access_object_i18n_name_get_static_delegate == null)
            {
                efl_access_object_i18n_name_get_static_delegate = new efl_access_object_i18n_name_get_delegate(i18n_name_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetI18nName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_i18n_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_i18n_name_get_static_delegate) });
            }

            if (efl_access_object_i18n_name_set_static_delegate == null)
            {
                efl_access_object_i18n_name_set_static_delegate = new efl_access_object_i18n_name_set_delegate(i18n_name_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetI18nName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_i18n_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_i18n_name_set_static_delegate) });
            }

            if (efl_access_object_name_cb_set_static_delegate == null)
            {
                efl_access_object_name_cb_set_static_delegate = new efl_access_object_name_cb_set_delegate(name_cb_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetNameCb") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_name_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_name_cb_set_static_delegate) });
            }

            if (efl_access_object_relation_set_get_static_delegate == null)
            {
                efl_access_object_relation_set_get_static_delegate = new efl_access_object_relation_set_get_delegate(relation_set_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRelationSet") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_relation_set_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relation_set_get_static_delegate) });
            }

            if (efl_access_object_role_get_static_delegate == null)
            {
                efl_access_object_role_get_static_delegate = new efl_access_object_role_get_delegate(role_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRole") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_role_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_get_static_delegate) });
            }

            if (efl_access_object_role_set_static_delegate == null)
            {
                efl_access_object_role_set_static_delegate = new efl_access_object_role_set_delegate(role_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRole") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_role_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_set_static_delegate) });
            }

            if (efl_access_object_access_parent_get_static_delegate == null)
            {
                efl_access_object_access_parent_get_static_delegate = new efl_access_object_access_parent_get_delegate(access_parent_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAccessParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_access_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_parent_get_static_delegate) });
            }

            if (efl_access_object_access_parent_set_static_delegate == null)
            {
                efl_access_object_access_parent_set_static_delegate = new efl_access_object_access_parent_set_delegate(access_parent_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAccessParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_access_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_parent_set_static_delegate) });
            }

            if (efl_access_object_description_cb_set_static_delegate == null)
            {
                efl_access_object_description_cb_set_static_delegate = new efl_access_object_description_cb_set_delegate(description_cb_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDescriptionCb") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_description_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_cb_set_static_delegate) });
            }

            if (efl_access_object_gesture_cb_set_static_delegate == null)
            {
                efl_access_object_gesture_cb_set_static_delegate = new efl_access_object_gesture_cb_set_delegate(gesture_cb_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGestureCb") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_gesture_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_gesture_cb_set_static_delegate) });
            }

            if (efl_access_object_access_children_get_static_delegate == null)
            {
                efl_access_object_access_children_get_static_delegate = new efl_access_object_access_children_get_delegate(access_children_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAccessChildren") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_access_children_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_children_get_static_delegate) });
            }

            if (efl_access_object_role_name_get_static_delegate == null)
            {
                efl_access_object_role_name_get_static_delegate = new efl_access_object_role_name_get_delegate(role_name_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRoleName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_role_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_name_get_static_delegate) });
            }

            if (efl_access_object_attributes_get_static_delegate == null)
            {
                efl_access_object_attributes_get_static_delegate = new efl_access_object_attributes_get_delegate(attributes_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAttributes") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_attributes_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attributes_get_static_delegate) });
            }

            if (efl_access_object_reading_info_type_get_static_delegate == null)
            {
                efl_access_object_reading_info_type_get_static_delegate = new efl_access_object_reading_info_type_get_delegate(reading_info_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetReadingInfoType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_reading_info_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_reading_info_type_get_static_delegate) });
            }

            if (efl_access_object_reading_info_type_set_static_delegate == null)
            {
                efl_access_object_reading_info_type_set_static_delegate = new efl_access_object_reading_info_type_set_delegate(reading_info_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetReadingInfoType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_reading_info_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_reading_info_type_set_static_delegate) });
            }

            if (efl_access_object_index_in_parent_get_static_delegate == null)
            {
                efl_access_object_index_in_parent_get_static_delegate = new efl_access_object_index_in_parent_get_delegate(index_in_parent_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIndexInParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_index_in_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_index_in_parent_get_static_delegate) });
            }

            if (efl_access_object_description_get_static_delegate == null)
            {
                efl_access_object_description_get_static_delegate = new efl_access_object_description_get_delegate(description_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDescription") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_description_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_get_static_delegate) });
            }

            if (efl_access_object_description_set_static_delegate == null)
            {
                efl_access_object_description_set_static_delegate = new efl_access_object_description_set_delegate(description_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDescription") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_description_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_set_static_delegate) });
            }

            if (efl_access_object_state_set_get_static_delegate == null)
            {
                efl_access_object_state_set_get_static_delegate = new efl_access_object_state_set_get_delegate(state_set_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStateSet") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_state_set_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_state_set_get_static_delegate) });
            }

            if (efl_access_object_can_highlight_get_static_delegate == null)
            {
                efl_access_object_can_highlight_get_static_delegate = new efl_access_object_can_highlight_get_delegate(can_highlight_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCanHighlight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_can_highlight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_can_highlight_get_static_delegate) });
            }

            if (efl_access_object_can_highlight_set_static_delegate == null)
            {
                efl_access_object_can_highlight_set_static_delegate = new efl_access_object_can_highlight_set_delegate(can_highlight_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCanHighlight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_can_highlight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_can_highlight_set_static_delegate) });
            }

            if (efl_access_object_translation_domain_get_static_delegate == null)
            {
                efl_access_object_translation_domain_get_static_delegate = new efl_access_object_translation_domain_get_delegate(translation_domain_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTranslationDomain") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_translation_domain_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_translation_domain_get_static_delegate) });
            }

            if (efl_access_object_translation_domain_set_static_delegate == null)
            {
                efl_access_object_translation_domain_set_static_delegate = new efl_access_object_translation_domain_set_delegate(translation_domain_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTranslationDomain") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_translation_domain_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_translation_domain_set_static_delegate) });
            }

            if (efl_access_object_gesture_do_static_delegate == null)
            {
                efl_access_object_gesture_do_static_delegate = new efl_access_object_gesture_do_delegate(gesture_do);
            }

            if (methods.FirstOrDefault(m => m.Name == "GestureDo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_gesture_do"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_gesture_do_static_delegate) });
            }

            if (efl_access_object_attribute_append_static_delegate == null)
            {
                efl_access_object_attribute_append_static_delegate = new efl_access_object_attribute_append_delegate(attribute_append);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendAttribute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_attribute_append"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attribute_append_static_delegate) });
            }

            if (efl_access_object_attribute_del_static_delegate == null)
            {
                efl_access_object_attribute_del_static_delegate = new efl_access_object_attribute_del_delegate(attribute_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelAttribute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_attribute_del"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attribute_del_static_delegate) });
            }

            if (efl_access_object_attributes_clear_static_delegate == null)
            {
                efl_access_object_attributes_clear_static_delegate = new efl_access_object_attributes_clear_delegate(attributes_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearAttributes") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_attributes_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attributes_clear_static_delegate) });
            }

            if (efl_access_object_relationship_append_static_delegate == null)
            {
                efl_access_object_relationship_append_static_delegate = new efl_access_object_relationship_append_delegate(relationship_append);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendRelationship") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_relationship_append"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationship_append_static_delegate) });
            }

            if (efl_access_object_relationship_remove_static_delegate == null)
            {
                efl_access_object_relationship_remove_static_delegate = new efl_access_object_relationship_remove_delegate(relationship_remove);
            }

            if (methods.FirstOrDefault(m => m.Name == "RelationshipRemove") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_relationship_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationship_remove_static_delegate) });
            }

            if (efl_access_object_relationships_clear_static_delegate == null)
            {
                efl_access_object_relationships_clear_static_delegate = new efl_access_object_relationships_clear_delegate(relationships_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearRelationships") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_relationships_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationships_clear_static_delegate) });
            }

            if (efl_access_object_state_notify_static_delegate == null)
            {
                efl_access_object_state_notify_static_delegate = new efl_access_object_state_notify_delegate(state_notify);
            }

            if (methods.FirstOrDefault(m => m.Name == "StateNotify") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_state_notify"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_state_notify_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Access.IObjectConcrete.efl_access_object_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_object_localized_role_name_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_object_localized_role_name_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_localized_role_name_get_api_delegate> efl_access_object_localized_role_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_localized_role_name_get_api_delegate>(Module, "efl_access_object_localized_role_name_get");

        private static System.String localized_role_name_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_localized_role_name_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IObject)ws.Target).GetLocalizedRoleName();
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
                return efl_access_object_localized_role_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_localized_role_name_get_delegate efl_access_object_localized_role_name_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_object_i18n_name_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_object_i18n_name_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_get_api_delegate> efl_access_object_i18n_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_get_api_delegate>(Module, "efl_access_object_i18n_name_get");

        private static System.String i18n_name_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_i18n_name_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IObject)ws.Target).GetI18nName();
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
                return efl_access_object_i18n_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_i18n_name_get_delegate efl_access_object_i18n_name_get_static_delegate;

        
        private delegate void efl_access_object_i18n_name_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String i18n_name);

        
        public delegate void efl_access_object_i18n_name_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String i18n_name);

        public static Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_set_api_delegate> efl_access_object_i18n_name_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_set_api_delegate>(Module, "efl_access_object_i18n_name_set");

        private static void i18n_name_set(System.IntPtr obj, System.IntPtr pd, System.String i18n_name)
        {
            Eina.Log.Debug("function efl_access_object_i18n_name_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IObject)ws.Target).SetI18nName(i18n_name);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_i18n_name_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), i18n_name);
            }
        }

        private static efl_access_object_i18n_name_set_delegate efl_access_object_i18n_name_set_static_delegate;

        
        private delegate void efl_access_object_name_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoCb name_cb,  System.IntPtr data);

        
        public delegate void efl_access_object_name_cb_set_api_delegate(System.IntPtr obj,  Efl.Access.ReadingInfoCb name_cb,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_access_object_name_cb_set_api_delegate> efl_access_object_name_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_name_cb_set_api_delegate>(Module, "efl_access_object_name_cb_set");

        private static void name_cb_set(System.IntPtr obj, System.IntPtr pd, Efl.Access.ReadingInfoCb name_cb, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_access_object_name_cb_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IObject)ws.Target).SetNameCb(name_cb, data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_object_name_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name_cb, data);
            }
        }

        private static efl_access_object_name_cb_set_delegate efl_access_object_name_cb_set_static_delegate;

        
        private delegate Efl.Access.RelationSet efl_access_object_relation_set_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Access.RelationSet efl_access_object_relation_set_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_relation_set_get_api_delegate> efl_access_object_relation_set_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relation_set_get_api_delegate>(Module, "efl_access_object_relation_set_get");

        private static Efl.Access.RelationSet relation_set_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_relation_set_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Access.RelationSet _ret_var = default(Efl.Access.RelationSet);
                try
                {
                    _ret_var = ((IObject)ws.Target).GetRelationSet();
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
                return efl_access_object_relation_set_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_relation_set_get_delegate efl_access_object_relation_set_get_static_delegate;

        
        private delegate Efl.Access.Role efl_access_object_role_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Access.Role efl_access_object_role_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_role_get_api_delegate> efl_access_object_role_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_role_get_api_delegate>(Module, "efl_access_object_role_get");

        private static Efl.Access.Role role_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_role_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Access.Role _ret_var = default(Efl.Access.Role);
                try
                {
                    _ret_var = ((IObject)ws.Target).GetRole();
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
                return efl_access_object_role_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_role_get_delegate efl_access_object_role_get_static_delegate;

        
        private delegate void efl_access_object_role_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.Role role);

        
        public delegate void efl_access_object_role_set_api_delegate(System.IntPtr obj,  Efl.Access.Role role);

        public static Efl.Eo.FunctionWrapper<efl_access_object_role_set_api_delegate> efl_access_object_role_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_role_set_api_delegate>(Module, "efl_access_object_role_set");

        private static void role_set(System.IntPtr obj, System.IntPtr pd, Efl.Access.Role role)
        {
            Eina.Log.Debug("function efl_access_object_role_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IObject)ws.Target).SetRole(role);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_role_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), role);
            }
        }

        private static efl_access_object_role_set_delegate efl_access_object_role_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Access.IObject efl_access_object_access_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Access.IObject efl_access_object_access_parent_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_access_parent_get_api_delegate> efl_access_object_access_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_parent_get_api_delegate>(Module, "efl_access_object_access_parent_get");

        private static Efl.Access.IObject access_parent_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_access_parent_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Access.IObject _ret_var = default(Efl.Access.IObject);
                try
                {
                    _ret_var = ((IObject)ws.Target).GetAccessParent();
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
                return efl_access_object_access_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_access_parent_get_delegate efl_access_object_access_parent_get_static_delegate;

        
        private delegate void efl_access_object_access_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject parent);

        
        public delegate void efl_access_object_access_parent_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject parent);

        public static Efl.Eo.FunctionWrapper<efl_access_object_access_parent_set_api_delegate> efl_access_object_access_parent_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_parent_set_api_delegate>(Module, "efl_access_object_access_parent_set");

        private static void access_parent_set(System.IntPtr obj, System.IntPtr pd, Efl.Access.IObject parent)
        {
            Eina.Log.Debug("function efl_access_object_access_parent_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IObject)ws.Target).SetAccessParent(parent);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_access_parent_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), parent);
            }
        }

        private static efl_access_object_access_parent_set_delegate efl_access_object_access_parent_set_static_delegate;

        
        private delegate void efl_access_object_description_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoCb description_cb,  System.IntPtr data);

        
        public delegate void efl_access_object_description_cb_set_api_delegate(System.IntPtr obj,  Efl.Access.ReadingInfoCb description_cb,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_access_object_description_cb_set_api_delegate> efl_access_object_description_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_description_cb_set_api_delegate>(Module, "efl_access_object_description_cb_set");

        private static void description_cb_set(System.IntPtr obj, System.IntPtr pd, Efl.Access.ReadingInfoCb description_cb, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_access_object_description_cb_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IObject)ws.Target).SetDescriptionCb(description_cb, data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_object_description_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), description_cb, data);
            }
        }

        private static efl_access_object_description_cb_set_delegate efl_access_object_description_cb_set_static_delegate;

        
        private delegate void efl_access_object_gesture_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.GestureCb gesture_cb,  System.IntPtr data);

        
        public delegate void efl_access_object_gesture_cb_set_api_delegate(System.IntPtr obj,  Efl.Access.GestureCb gesture_cb,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_access_object_gesture_cb_set_api_delegate> efl_access_object_gesture_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_gesture_cb_set_api_delegate>(Module, "efl_access_object_gesture_cb_set");

        private static void gesture_cb_set(System.IntPtr obj, System.IntPtr pd, Efl.Access.GestureCb gesture_cb, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_access_object_gesture_cb_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IObject)ws.Target).SetGestureCb(gesture_cb, data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_object_gesture_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), gesture_cb, data);
            }
        }

        private static efl_access_object_gesture_cb_set_delegate efl_access_object_gesture_cb_set_static_delegate;

        
        private delegate System.IntPtr efl_access_object_access_children_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_access_object_access_children_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_access_children_get_api_delegate> efl_access_object_access_children_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_children_get_api_delegate>(Module, "efl_access_object_access_children_get");

        private static System.IntPtr access_children_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_access_children_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.List<Efl.Access.IObject> _ret_var = default(Eina.List<Efl.Access.IObject>);
                try
                {
                    _ret_var = ((IObject)ws.Target).GetAccessChildren();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        _ret_var.Own = false; return _ret_var.Handle;

            }
            else
            {
                return efl_access_object_access_children_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_access_children_get_delegate efl_access_object_access_children_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_object_role_name_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_object_role_name_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_role_name_get_api_delegate> efl_access_object_role_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_role_name_get_api_delegate>(Module, "efl_access_object_role_name_get");

        private static System.String role_name_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_role_name_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IObject)ws.Target).GetRoleName();
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
                return efl_access_object_role_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_role_name_get_delegate efl_access_object_role_name_get_static_delegate;

        
        private delegate System.IntPtr efl_access_object_attributes_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_access_object_attributes_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_attributes_get_api_delegate> efl_access_object_attributes_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_attributes_get_api_delegate>(Module, "efl_access_object_attributes_get");

        private static System.IntPtr attributes_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_attributes_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.List<Efl.Access.Attribute> _ret_var = default(Eina.List<Efl.Access.Attribute>);
                try
                {
                    _ret_var = ((IObject)ws.Target).GetAttributes();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        _ret_var.Own = false; _ret_var.OwnContent = false; return _ret_var.Handle;

            }
            else
            {
                return efl_access_object_attributes_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_attributes_get_delegate efl_access_object_attributes_get_static_delegate;

        
        private delegate Efl.Access.ReadingInfoTypeMask efl_access_object_reading_info_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Access.ReadingInfoTypeMask efl_access_object_reading_info_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_get_api_delegate> efl_access_object_reading_info_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_get_api_delegate>(Module, "efl_access_object_reading_info_type_get");

        private static Efl.Access.ReadingInfoTypeMask reading_info_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_reading_info_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Access.ReadingInfoTypeMask _ret_var = default(Efl.Access.ReadingInfoTypeMask);
                try
                {
                    _ret_var = ((IObject)ws.Target).GetReadingInfoType();
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
                return efl_access_object_reading_info_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_reading_info_type_get_delegate efl_access_object_reading_info_type_get_static_delegate;

        
        private delegate void efl_access_object_reading_info_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoTypeMask reading_info);

        
        public delegate void efl_access_object_reading_info_type_set_api_delegate(System.IntPtr obj,  Efl.Access.ReadingInfoTypeMask reading_info);

        public static Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_set_api_delegate> efl_access_object_reading_info_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_set_api_delegate>(Module, "efl_access_object_reading_info_type_set");

        private static void reading_info_type_set(System.IntPtr obj, System.IntPtr pd, Efl.Access.ReadingInfoTypeMask reading_info)
        {
            Eina.Log.Debug("function efl_access_object_reading_info_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IObject)ws.Target).SetReadingInfoType(reading_info);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_reading_info_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), reading_info);
            }
        }

        private static efl_access_object_reading_info_type_set_delegate efl_access_object_reading_info_type_set_static_delegate;

        
        private delegate int efl_access_object_index_in_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_access_object_index_in_parent_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_index_in_parent_get_api_delegate> efl_access_object_index_in_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_index_in_parent_get_api_delegate>(Module, "efl_access_object_index_in_parent_get");

        private static int index_in_parent_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_index_in_parent_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IObject)ws.Target).GetIndexInParent();
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
                return efl_access_object_index_in_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_index_in_parent_get_delegate efl_access_object_index_in_parent_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_object_description_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_object_description_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_description_get_api_delegate> efl_access_object_description_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_description_get_api_delegate>(Module, "efl_access_object_description_get");

        private static System.String description_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_description_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IObject)ws.Target).GetDescription();
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
                return efl_access_object_description_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_description_get_delegate efl_access_object_description_get_static_delegate;

        
        private delegate void efl_access_object_description_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String description);

        
        public delegate void efl_access_object_description_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String description);

        public static Efl.Eo.FunctionWrapper<efl_access_object_description_set_api_delegate> efl_access_object_description_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_description_set_api_delegate>(Module, "efl_access_object_description_set");

        private static void description_set(System.IntPtr obj, System.IntPtr pd, System.String description)
        {
            Eina.Log.Debug("function efl_access_object_description_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IObject)ws.Target).SetDescription(description);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_description_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), description);
            }
        }

        private static efl_access_object_description_set_delegate efl_access_object_description_set_static_delegate;

        
        private delegate Efl.Access.StateSet efl_access_object_state_set_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Access.StateSet efl_access_object_state_set_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_state_set_get_api_delegate> efl_access_object_state_set_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_state_set_get_api_delegate>(Module, "efl_access_object_state_set_get");

        private static Efl.Access.StateSet state_set_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_state_set_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Access.StateSet _ret_var = default(Efl.Access.StateSet);
                try
                {
                    _ret_var = ((IObject)ws.Target).GetStateSet();
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
                return efl_access_object_state_set_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_state_set_get_delegate efl_access_object_state_set_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_object_can_highlight_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_object_can_highlight_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_get_api_delegate> efl_access_object_can_highlight_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_get_api_delegate>(Module, "efl_access_object_can_highlight_get");

        private static bool can_highlight_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_can_highlight_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IObject)ws.Target).GetCanHighlight();
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
                return efl_access_object_can_highlight_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_can_highlight_get_delegate efl_access_object_can_highlight_get_static_delegate;

        
        private delegate void efl_access_object_can_highlight_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool can_highlight);

        
        public delegate void efl_access_object_can_highlight_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool can_highlight);

        public static Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_set_api_delegate> efl_access_object_can_highlight_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_set_api_delegate>(Module, "efl_access_object_can_highlight_set");

        private static void can_highlight_set(System.IntPtr obj, System.IntPtr pd, bool can_highlight)
        {
            Eina.Log.Debug("function efl_access_object_can_highlight_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IObject)ws.Target).SetCanHighlight(can_highlight);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_can_highlight_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), can_highlight);
            }
        }

        private static efl_access_object_can_highlight_set_delegate efl_access_object_can_highlight_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_object_translation_domain_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_object_translation_domain_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_get_api_delegate> efl_access_object_translation_domain_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_get_api_delegate>(Module, "efl_access_object_translation_domain_get");

        private static System.String translation_domain_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_translation_domain_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IObject)ws.Target).GetTranslationDomain();
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
                return efl_access_object_translation_domain_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_translation_domain_get_delegate efl_access_object_translation_domain_get_static_delegate;

        
        private delegate void efl_access_object_translation_domain_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String domain);

        
        public delegate void efl_access_object_translation_domain_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String domain);

        public static Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_set_api_delegate> efl_access_object_translation_domain_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_set_api_delegate>(Module, "efl_access_object_translation_domain_set");

        private static void translation_domain_set(System.IntPtr obj, System.IntPtr pd, System.String domain)
        {
            Eina.Log.Debug("function efl_access_object_translation_domain_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IObject)ws.Target).SetTranslationDomain(domain);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_translation_domain_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), domain);
            }
        }

        private static efl_access_object_translation_domain_set_delegate efl_access_object_translation_domain_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_access_object_access_root_get_delegate();

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_access_object_access_root_get_api_delegate();

        public static Efl.Eo.FunctionWrapper<efl_access_object_access_root_get_api_delegate> efl_access_object_access_root_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_root_get_api_delegate>(Module, "efl_access_object_access_root_get");

        private static Efl.Object access_root_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_access_root_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Object _ret_var = default(Efl.Object);
                try
                {
                    _ret_var = IObjectConcrete.GetAccessRoot();
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
                return efl_access_object_access_root_get_ptr.Value.Delegate();
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_object_gesture_do_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.GestureInfo.NativeStruct gesture_info);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_object_gesture_do_api_delegate(System.IntPtr obj,  Efl.Access.GestureInfo.NativeStruct gesture_info);

        public static Efl.Eo.FunctionWrapper<efl_access_object_gesture_do_api_delegate> efl_access_object_gesture_do_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_gesture_do_api_delegate>(Module, "efl_access_object_gesture_do");

        private static bool gesture_do(System.IntPtr obj, System.IntPtr pd, Efl.Access.GestureInfo.NativeStruct gesture_info)
        {
            Eina.Log.Debug("function efl_access_object_gesture_do was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Access.GestureInfo _in_gesture_info = gesture_info;
                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IObject)ws.Target).GestureDo(_in_gesture_info);
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
                return efl_access_object_gesture_do_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), gesture_info);
            }
        }

        private static efl_access_object_gesture_do_delegate efl_access_object_gesture_do_static_delegate;

        
        private delegate void efl_access_object_attribute_append_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String value);

        
        public delegate void efl_access_object_attribute_append_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String value);

        public static Efl.Eo.FunctionWrapper<efl_access_object_attribute_append_api_delegate> efl_access_object_attribute_append_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_attribute_append_api_delegate>(Module, "efl_access_object_attribute_append");

        private static void attribute_append(System.IntPtr obj, System.IntPtr pd, System.String key, System.String value)
        {
            Eina.Log.Debug("function efl_access_object_attribute_append was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IObject)ws.Target).AppendAttribute(key, value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_object_attribute_append_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key, value);
            }
        }

        private static efl_access_object_attribute_append_delegate efl_access_object_attribute_append_static_delegate;

        
        private delegate void efl_access_object_attribute_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        
        public delegate void efl_access_object_attribute_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_access_object_attribute_del_api_delegate> efl_access_object_attribute_del_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_attribute_del_api_delegate>(Module, "efl_access_object_attribute_del");

        private static void attribute_del(System.IntPtr obj, System.IntPtr pd, System.String key)
        {
            Eina.Log.Debug("function efl_access_object_attribute_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IObject)ws.Target).DelAttribute(key);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_attribute_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key);
            }
        }

        private static efl_access_object_attribute_del_delegate efl_access_object_attribute_del_static_delegate;

        
        private delegate void efl_access_object_attributes_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_access_object_attributes_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_attributes_clear_api_delegate> efl_access_object_attributes_clear_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_attributes_clear_api_delegate>(Module, "efl_access_object_attributes_clear");

        private static void attributes_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_attributes_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((IObject)ws.Target).ClearAttributes();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_access_object_attributes_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_attributes_clear_delegate efl_access_object_attributes_clear_static_delegate;

        
        private delegate Efl.Access.Event.Handler efl_access_object_event_handler_add_delegate( Efl.EventCb cb,  System.IntPtr data);

        
        public delegate Efl.Access.Event.Handler efl_access_object_event_handler_add_api_delegate( Efl.EventCb cb,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_access_object_event_handler_add_api_delegate> efl_access_object_event_handler_add_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_event_handler_add_api_delegate>(Module, "efl_access_object_event_handler_add");

        private static Efl.Access.Event.Handler event_handler_add(System.IntPtr obj, System.IntPtr pd, Efl.EventCb cb, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_access_object_event_handler_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            Efl.Access.Event.Handler _ret_var = default(Efl.Access.Event.Handler);
                try
                {
                    _ret_var = IObjectConcrete.AddEventHandler(cb, data);
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
                return efl_access_object_event_handler_add_ptr.Value.Delegate(cb, data);
            }
        }

        
        private delegate void efl_access_object_event_handler_del_delegate( Efl.Access.Event.Handler handler);

        
        public delegate void efl_access_object_event_handler_del_api_delegate( Efl.Access.Event.Handler handler);

        public static Efl.Eo.FunctionWrapper<efl_access_object_event_handler_del_api_delegate> efl_access_object_event_handler_del_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_event_handler_del_api_delegate>(Module, "efl_access_object_event_handler_del");

        private static void event_handler_del(System.IntPtr obj, System.IntPtr pd, Efl.Access.Event.Handler handler)
        {
            Eina.Log.Debug("function efl_access_object_event_handler_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    IObjectConcrete.DelEventHandler(handler);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_event_handler_del_ptr.Value.Delegate(handler);
            }
        }

        
        private delegate void efl_access_object_event_emit_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject accessible,  System.IntPtr kw_event,  System.IntPtr event_info);

        
        public delegate void efl_access_object_event_emit_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject accessible,  System.IntPtr kw_event,  System.IntPtr event_info);

        public static Efl.Eo.FunctionWrapper<efl_access_object_event_emit_api_delegate> efl_access_object_event_emit_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_event_emit_api_delegate>(Module, "efl_access_object_event_emit");

        private static void event_emit(System.IntPtr obj, System.IntPtr pd, Efl.Access.IObject accessible, System.IntPtr kw_event, System.IntPtr event_info)
        {
            Eina.Log.Debug("function efl_access_object_event_emit was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_kw_event = Eina.PrimitiveConversion.PointerToManaged<Efl.EventDescription>(kw_event);
                                                                    
                try
                {
                    IObjectConcrete.EmitEvent(accessible, _in_kw_event, event_info);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_access_object_event_emit_ptr.Value.Delegate(accessible, kw_event, event_info);
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_object_relationship_append_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject relation_object);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_object_relationship_append_api_delegate(System.IntPtr obj,  Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject relation_object);

        public static Efl.Eo.FunctionWrapper<efl_access_object_relationship_append_api_delegate> efl_access_object_relationship_append_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relationship_append_api_delegate>(Module, "efl_access_object_relationship_append");

        private static bool relationship_append(System.IntPtr obj, System.IntPtr pd, Efl.Access.RelationType type, Efl.Access.IObject relation_object)
        {
            Eina.Log.Debug("function efl_access_object_relationship_append was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IObject)ws.Target).AppendRelationship(type, relation_object);
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
                return efl_access_object_relationship_append_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type, relation_object);
            }
        }

        private static efl_access_object_relationship_append_delegate efl_access_object_relationship_append_static_delegate;

        
        private delegate void efl_access_object_relationship_remove_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject relation_object);

        
        public delegate void efl_access_object_relationship_remove_api_delegate(System.IntPtr obj,  Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject relation_object);

        public static Efl.Eo.FunctionWrapper<efl_access_object_relationship_remove_api_delegate> efl_access_object_relationship_remove_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relationship_remove_api_delegate>(Module, "efl_access_object_relationship_remove");

        private static void relationship_remove(System.IntPtr obj, System.IntPtr pd, Efl.Access.RelationType type, Efl.Access.IObject relation_object)
        {
            Eina.Log.Debug("function efl_access_object_relationship_remove was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IObject)ws.Target).RelationshipRemove(type, relation_object);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_object_relationship_remove_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type, relation_object);
            }
        }

        private static efl_access_object_relationship_remove_delegate efl_access_object_relationship_remove_static_delegate;

        
        private delegate void efl_access_object_relationships_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_access_object_relationships_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_relationships_clear_api_delegate> efl_access_object_relationships_clear_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relationships_clear_api_delegate>(Module, "efl_access_object_relationships_clear");

        private static void relationships_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_relationships_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((IObject)ws.Target).ClearRelationships();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_access_object_relationships_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_relationships_clear_delegate efl_access_object_relationships_clear_static_delegate;

        
        private delegate void efl_access_object_state_notify_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.StateSet state_types_mask, [MarshalAs(UnmanagedType.U1)] bool recursive);

        
        public delegate void efl_access_object_state_notify_api_delegate(System.IntPtr obj,  Efl.Access.StateSet state_types_mask, [MarshalAs(UnmanagedType.U1)] bool recursive);

        public static Efl.Eo.FunctionWrapper<efl_access_object_state_notify_api_delegate> efl_access_object_state_notify_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_state_notify_api_delegate>(Module, "efl_access_object_state_notify");

        private static void state_notify(System.IntPtr obj, System.IntPtr pd, Efl.Access.StateSet state_types_mask, bool recursive)
        {
            Eina.Log.Debug("function efl_access_object_state_notify was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IObject)ws.Target).StateNotify(state_types_mask, recursive);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_object_state_notify_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), state_types_mask, recursive);
            }
        }

        private static efl_access_object_state_notify_delegate efl_access_object_state_notify_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

namespace Efl {

namespace Access {

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

}

}

namespace Efl {

namespace Access {

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

}

}

namespace Efl {

namespace Access {

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

}

}

namespace Efl {

namespace Access {

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

}

}

namespace Efl {

namespace Access {

namespace Reading {

namespace Info {

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

}

}

}

}

namespace Efl {

namespace Access {

public enum Gesture
{
OneFingerHover = 0,
TwoFingersHover = 1,
ThreeFingersHover = 2,
OneFingerFlickLeft = 3,
OneFingerFlickRight = 4,
OneFingerFlickUp = 5,
OneFingerFlickDown = 6,
TwoFingersFlickLeft = 7,
TwoFingersFlickRight = 8,
TwoFingersFlickUp = 9,
TwoFingersFlickDown = 10,
ThreeFingersFlickLeft = 11,
ThreeFingersFlickRight = 12,
ThreeFingersFlickUp = 13,
ThreeFingersFlickDown = 14,
OneFingerSingleTap = 15,
OneFingerDoubleTap = 16,
OneFingerTripleTap = 17,
TwoFingersSingleTap = 18,
TwoFingersDoubleTap = 19,
TwoFingersTripleTap = 20,
ThreeFingersSingleTap = 21,
ThreeFingersDoubleTap = 22,
ThreeFingersTripleTap = 23,
OneFingerFlickLeftReturn = 24,
OneFingerFlickRightReturn = 25,
OneFingerFlickUpReturn = 26,
OneFingerFlickDownReturn = 27,
TwoFingersFlickLeftReturn = 28,
TwoFingersFlickRightReturn = 29,
TwoFingersFlickUpReturn = 30,
TwoFingersFlickDownReturn = 31,
ThreeFingersFlickLeftReturn = 32,
ThreeFingersFlickRightReturn = 33,
ThreeFingersFlickUpReturn = 34,
ThreeFingersFlickDownReturn = 35,
}

}

}

namespace Efl {

namespace Access {

public enum GestureState
{
Start = 0,
Move = 1,
End = 2,
Abort = 3,
}

}

}

namespace Efl {

namespace Access {

namespace Event {

/// <summary>Accessibility event listener</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Handler
{
    ///<summary>Placeholder field</summary>
    public IntPtr field;
    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Handler(IntPtr ptr)
    {
        var tmp = (Handler.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Handler.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct Handler.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Handler.NativeStruct(Handler _external_struct)
        {
            var _internal_struct = new Handler.NativeStruct();
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Handler(Handler.NativeStruct _internal_struct)
        {
            var _external_struct = new Handler();
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

namespace Efl {

namespace Access {

namespace Event {

namespace StateChanged {

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
        Efl.Access.StateType Type = default(Efl.Access.StateType),
        bool New_value = default(bool)    )
    {
        this.Type = Type;
        this.New_value = New_value;
    }

    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Data(IntPtr ptr)
    {
        var tmp = (Data.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Data.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct Data.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Efl.Access.StateType Type;
        ///<summary>Internal wrapper for field New_value</summary>
        public System.Byte New_value;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Data.NativeStruct(Data _external_struct)
        {
            var _internal_struct = new Data.NativeStruct();
            _internal_struct.Type = _external_struct.Type;
            _internal_struct.New_value = _external_struct.New_value ? (byte)1 : (byte)0;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Data(Data.NativeStruct _internal_struct)
        {
            var _external_struct = new Data();
            _external_struct.Type = _internal_struct.Type;
            _external_struct.New_value = _internal_struct.New_value != 0;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

}

namespace Efl {

namespace Access {

namespace Event {

namespace GeometryChanged {

/// <summary>Accessibility geometry changed event data</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Data
{
    /// <summary>X coordinate</summary>
    public int X;
    /// <summary>Y coordinate</summary>
    public int Y;
    /// <summary>Width</summary>
    public int Width;
    /// <summary>Height</summary>
    public int Height;
    ///<summary>Constructor for Data.</summary>
    public Data(
        int X = default(int),
        int Y = default(int),
        int Width = default(int),
        int Height = default(int)    )
    {
        this.X = X;
        this.Y = Y;
        this.Width = Width;
        this.Height = Height;
    }

    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Data(IntPtr ptr)
    {
        var tmp = (Data.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Data.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct Data.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public int X;
        
        public int Y;
        
        public int Width;
        
        public int Height;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Data.NativeStruct(Data _external_struct)
        {
            var _internal_struct = new Data.NativeStruct();
            _internal_struct.X = _external_struct.X;
            _internal_struct.Y = _external_struct.Y;
            _internal_struct.Width = _external_struct.Width;
            _internal_struct.Height = _external_struct.Height;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Data(Data.NativeStruct _internal_struct)
        {
            var _external_struct = new Data();
            _external_struct.X = _internal_struct.X;
            _external_struct.Y = _internal_struct.Y;
            _external_struct.Width = _internal_struct.Width;
            _external_struct.Height = _internal_struct.Height;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

}

namespace Efl {

namespace Access {

namespace Event {

namespace ChildrenChanged {

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
        bool Is_added = default(bool),
        Efl.Object Child = default(Efl.Object)    )
    {
        this.Is_added = Is_added;
        this.Child = Child;
    }

    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Data(IntPtr ptr)
    {
        var tmp = (Data.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Data.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct Data.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        ///<summary>Internal wrapper for field Is_added</summary>
        public System.Byte Is_added;
        ///<summary>Internal wrapper for field Child</summary>
        public System.IntPtr Child;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Data.NativeStruct(Data _external_struct)
        {
            var _internal_struct = new Data.NativeStruct();
            _internal_struct.Is_added = _external_struct.Is_added ? (byte)1 : (byte)0;
            _internal_struct.Child = _external_struct.Child?.NativeHandle ?? System.IntPtr.Zero;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Data(Data.NativeStruct _internal_struct)
        {
            var _external_struct = new Data();
            _external_struct.Is_added = _internal_struct.Is_added != 0;

            _external_struct.Child = (Efl.Object) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Child);
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

}

namespace Efl {

namespace Access {

/// <summary>Accessibility Attribute</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Attribute
{
    /// <summary>Attribute key</summary>
    public System.String Key;
    /// <summary>Attribute value</summary>
    public System.String Value;
    ///<summary>Constructor for Attribute.</summary>
    public Attribute(
        System.String Key = default(System.String),
        System.String Value = default(System.String)    )
    {
        this.Key = Key;
        this.Value = Value;
    }

    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Attribute(IntPtr ptr)
    {
        var tmp = (Attribute.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Attribute.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct Attribute.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        ///<summary>Internal wrapper for field Key</summary>
        public System.IntPtr Key;
        ///<summary>Internal wrapper for field Value</summary>
        public System.IntPtr Value;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Attribute.NativeStruct(Attribute _external_struct)
        {
            var _internal_struct = new Attribute.NativeStruct();
            _internal_struct.Key = Eina.MemoryNative.StrDup(_external_struct.Key);
            _internal_struct.Value = Eina.MemoryNative.StrDup(_external_struct.Value);
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Attribute(Attribute.NativeStruct _internal_struct)
        {
            var _external_struct = new Attribute();
            _external_struct.Key = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Key);
            _external_struct.Value = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Value);
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

namespace Efl {

namespace Access {

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
        Efl.Access.RelationType Type = default(Efl.Access.RelationType),
        Eina.List<Efl.Object> Objects = default(Eina.List<Efl.Object>)    )
    {
        this.Type = Type;
        this.Objects = Objects;
    }

    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Relation(IntPtr ptr)
    {
        var tmp = (Relation.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Relation.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct Relation.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Efl.Access.RelationType Type;
        
        public System.IntPtr Objects;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Relation.NativeStruct(Relation _external_struct)
        {
            var _internal_struct = new Relation.NativeStruct();
            _internal_struct.Type = _external_struct.Type;
            _internal_struct.Objects = _external_struct.Objects.Handle;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Relation(Relation.NativeStruct _internal_struct)
        {
            var _external_struct = new Relation();
            _external_struct.Type = _internal_struct.Type;
            _external_struct.Objects = new Eina.List<Efl.Object>(_internal_struct.Objects, false, false);
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

namespace Efl {

namespace Access {

[StructLayout(LayoutKind.Sequential)]
public struct GestureInfo
{
    /// <summary>Gesture type</summary>
    public Efl.Access.Gesture Type;
    /// <summary>start gesture x co-ordinate</summary>
    public int X_beg;
    /// <summary>start gesture y co-ordinate</summary>
    public int Y_beg;
    /// <summary>end gesture x co-ordinate</summary>
    public int X_end;
    /// <summary>end gesture y co-ordinate</summary>
    public int Y_end;
    /// <summary>state of gesture</summary>
    public Efl.Access.GestureState State;
    /// <summary>gesture occurance time</summary>
    public uint Event_time;
    ///<summary>Constructor for GestureInfo.</summary>
    public GestureInfo(
        Efl.Access.Gesture Type = default(Efl.Access.Gesture),
        int X_beg = default(int),
        int Y_beg = default(int),
        int X_end = default(int),
        int Y_end = default(int),
        Efl.Access.GestureState State = default(Efl.Access.GestureState),
        uint Event_time = default(uint)    )
    {
        this.Type = Type;
        this.X_beg = X_beg;
        this.Y_beg = Y_beg;
        this.X_end = X_end;
        this.Y_end = Y_end;
        this.State = State;
        this.Event_time = Event_time;
    }

    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator GestureInfo(IntPtr ptr)
    {
        var tmp = (GestureInfo.NativeStruct)Marshal.PtrToStructure(ptr, typeof(GestureInfo.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct GestureInfo.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Efl.Access.Gesture Type;
        
        public int X_beg;
        
        public int Y_beg;
        
        public int X_end;
        
        public int Y_end;
        
        public Efl.Access.GestureState State;
        
        public uint Event_time;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator GestureInfo.NativeStruct(GestureInfo _external_struct)
        {
            var _internal_struct = new GestureInfo.NativeStruct();
            _internal_struct.Type = _external_struct.Type;
            _internal_struct.X_beg = _external_struct.X_beg;
            _internal_struct.Y_beg = _external_struct.Y_beg;
            _internal_struct.X_end = _external_struct.X_end;
            _internal_struct.Y_end = _external_struct.Y_end;
            _internal_struct.State = _external_struct.State;
            _internal_struct.Event_time = _external_struct.Event_time;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator GestureInfo(GestureInfo.NativeStruct _internal_struct)
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

    #pragma warning restore CS1591

}

}

}

