#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Event argument wrapper for event <see cref="Efl.Canvas.Group.MemberAddedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class GroupMemberAddedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when a member is added to the group.</value>
    public Efl.Gfx.IEntity arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Canvas.Group.MemberRemovedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class GroupMemberRemovedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when a member is removed from the group.</value>
    public Efl.Gfx.IEntity arg { get; set; }
}
/// <summary>A group object is a container for other canvas objects. Its children move along their parent and are often clipped with a common clipper. This is part of the legacy smart object concept.
/// A group is not necessarily a container (see <see cref="Efl.IContainer"/>) in the sense that a standard widget may not have any empty slots for content. However it&apos;s still a group of low-level canvas objects (clipper, raw objects, etc.).
/// (Since EFL 1.22)</summary>
[Efl.Canvas.Group.NativeMethods]
[Efl.Eo.BindingEntity]
public class Group : Efl.Canvas.Object
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Group))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_group_class_get();
    /// <summary>Initializes a new instance of the <see cref="Group"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Group(Efl.Object parent= null
            ) : base(efl_canvas_group_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Group(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Group"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Group(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Group"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Group(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when a member is added to the group.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.GroupMemberAddedEventArgs"/></value>
    public event EventHandler<Efl.Canvas.GroupMemberAddedEventArgs> MemberAddedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Canvas.GroupMemberAddedEventArgs args = new Efl.Canvas.GroupMemberAddedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.EntityConcrete);
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

                string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_ADDED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_ADDED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event MemberAddedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnMemberAddedEvent(Efl.Canvas.GroupMemberAddedEventArgs e)
    {
        var key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_ADDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when a member is removed from the group.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.GroupMemberRemovedEventArgs"/></value>
    public event EventHandler<Efl.Canvas.GroupMemberRemovedEventArgs> MemberRemovedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Canvas.GroupMemberRemovedEventArgs args = new Efl.Canvas.GroupMemberRemovedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.EntityConcrete);
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

                string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_REMOVED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_REMOVED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event MemberRemovedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnMemberRemovedEvent(Efl.Canvas.GroupMemberRemovedEventArgs e)
    {
        var key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_REMOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
    /// If this flag is set, then the <see cref="Efl.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
    /// 
    /// Note: setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="Efl.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
    /// 
    /// See also <see cref="Efl.Canvas.Group.CalculateGroup"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the group layout needs to be recalculated, <c>false</c> otherwise</returns>
    public virtual bool GetGroupNeedRecalculate() {
         var _ret_var = Efl.Canvas.Group.NativeMethods.efl_canvas_group_need_recalculate_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
    /// If this flag is set, then the <see cref="Efl.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
    /// 
    /// Note: setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="Efl.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
    /// 
    /// See also <see cref="Efl.Canvas.Group.CalculateGroup"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="value"><c>true</c> if the group layout needs to be recalculated, <c>false</c> otherwise</param>
    public virtual void SetGroupNeedRecalculate(bool value) {
                                 Efl.Canvas.Group.NativeMethods.efl_canvas_group_need_recalculate_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the internal clipper.
    /// (Since EFL 1.22)</summary>
    /// <returns>A clipper rectangle.</returns>
    protected virtual Efl.Canvas.Object GetGroupClipper() {
         var _ret_var = Efl.Canvas.Group.NativeMethods.efl_canvas_group_clipper_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Marks the object as dirty.
    /// This also forcefully marks the given object as needing recalculation. As an effect, on the next rendering cycle its <see cref="Efl.Canvas.Group.CalculateGroup"/> method will be called.
    /// (Since EFL 1.22)</summary>
    public virtual void GroupChange() {
         Efl.Canvas.Group.NativeMethods.efl_canvas_group_change_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Triggers an immediate recalculation of this object&apos;s geometry.
    /// This will also reset the flag <see cref="Efl.Canvas.Group.GroupNeedRecalculate"/>.
    /// (Since EFL 1.22)</summary>
    public virtual void CalculateGroup() {
         Efl.Canvas.Group.NativeMethods.efl_canvas_group_calculate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Returns an iterator over the children of this object, which are canvas objects.
    /// This returns the list of &quot;smart&quot; children. This might be different from both the <see cref="Efl.Object"/> children list as well as the <see cref="Efl.IContainer"/> content list.
    /// (Since EFL 1.22)</summary>
    /// <returns>Iterator to object children</returns>
    public virtual Eina.Iterator<Efl.Canvas.Object> GroupMembersIterate() {
         var _ret_var = Efl.Canvas.Group.NativeMethods.efl_canvas_group_members_iterate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Canvas.Object>(_ret_var, true);
 }
    /// <summary>Set a canvas object as a member of a given group (or smart object).
    /// Members will automatically be stacked and layered together with the smart object. The various stacking functions will operate on members relative to the other members instead of the entire canvas, since they now live on an exclusive layer (see <see cref="Efl.Gfx.IStack.StackAbove"/>, for more details).
    /// 
    /// Subclasses inheriting from this one may override this function to ensure the proper stacking of special objects, such as clippers, event rectangles, etc...
    /// 
    /// See also <see cref="Efl.Canvas.Group.GroupMemberRemove"/>. See also <see cref="Efl.Canvas.Group.IsGroupMember"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="sub_obj">The member object.</param>
    public virtual void AddGroupMember(Efl.Canvas.Object sub_obj) {
                                 Efl.Canvas.Group.NativeMethods.efl_canvas_group_member_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),sub_obj);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Removes a member object from a given smart object.
    /// This removes a member object from a smart object, if it was added to any. The object will still be on the canvas, but no longer associated with whichever smart object it was associated with.
    /// 
    /// See also <see cref="Efl.Canvas.Group.AddGroupMember"/>. See also <see cref="Efl.Canvas.Group.IsGroupMember"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="sub_obj">The member object to remove.</param>
    public virtual void GroupMemberRemove(Efl.Canvas.Object sub_obj) {
                                 Efl.Canvas.Group.NativeMethods.efl_canvas_group_member_remove_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),sub_obj);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Finds out if a given object is a member of this group.
    /// (Since EFL 1.22)</summary>
    /// <param name="sub_obj">A potential sub object.</param>
    /// <returns><c>true</c> if <c>sub_obj</c> is a member of this group.</returns>
    public virtual bool IsGroupMember(Efl.Canvas.Object sub_obj) {
                                 var _ret_var = Efl.Canvas.Group.NativeMethods.efl_canvas_group_member_is_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),sub_obj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
    /// If this flag is set, then the <see cref="Efl.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
    /// 
    /// Note: setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="Efl.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
    /// 
    /// See also <see cref="Efl.Canvas.Group.CalculateGroup"/>.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if the group layout needs to be recalculated, <c>false</c> otherwise</value>
    public bool GroupNeedRecalculate {
        get { return GetGroupNeedRecalculate(); }
        set { SetGroupNeedRecalculate(value); }
    }
    /// <summary>The internal clipper object used by this group.
    /// This is the object clipping all the child objects. Do not delete or otherwise modify this clipper!
    /// (Since EFL 1.22)</summary>
    /// <value>A clipper rectangle.</value>
    protected Efl.Canvas.Object GroupClipper {
        get { return GetGroupClipper(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Group.efl_canvas_group_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_canvas_group_need_recalculate_get_static_delegate == null)
            {
                efl_canvas_group_need_recalculate_get_static_delegate = new efl_canvas_group_need_recalculate_get_delegate(group_need_recalculate_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGroupNeedRecalculate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_need_recalculate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_need_recalculate_get_static_delegate) });
            }

            if (efl_canvas_group_need_recalculate_set_static_delegate == null)
            {
                efl_canvas_group_need_recalculate_set_static_delegate = new efl_canvas_group_need_recalculate_set_delegate(group_need_recalculate_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGroupNeedRecalculate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_need_recalculate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_need_recalculate_set_static_delegate) });
            }

            if (efl_canvas_group_clipper_get_static_delegate == null)
            {
                efl_canvas_group_clipper_get_static_delegate = new efl_canvas_group_clipper_get_delegate(group_clipper_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGroupClipper") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_clipper_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_clipper_get_static_delegate) });
            }

            if (efl_canvas_group_change_static_delegate == null)
            {
                efl_canvas_group_change_static_delegate = new efl_canvas_group_change_delegate(group_change);
            }

            if (methods.FirstOrDefault(m => m.Name == "GroupChange") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_change"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_change_static_delegate) });
            }

            if (efl_canvas_group_calculate_static_delegate == null)
            {
                efl_canvas_group_calculate_static_delegate = new efl_canvas_group_calculate_delegate(group_calculate);
            }

            if (methods.FirstOrDefault(m => m.Name == "CalculateGroup") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_calculate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_calculate_static_delegate) });
            }

            if (efl_canvas_group_members_iterate_static_delegate == null)
            {
                efl_canvas_group_members_iterate_static_delegate = new efl_canvas_group_members_iterate_delegate(group_members_iterate);
            }

            if (methods.FirstOrDefault(m => m.Name == "GroupMembersIterate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_members_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_members_iterate_static_delegate) });
            }

            if (efl_canvas_group_member_add_static_delegate == null)
            {
                efl_canvas_group_member_add_static_delegate = new efl_canvas_group_member_add_delegate(group_member_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddGroupMember") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_member_add"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_add_static_delegate) });
            }

            if (efl_canvas_group_member_remove_static_delegate == null)
            {
                efl_canvas_group_member_remove_static_delegate = new efl_canvas_group_member_remove_delegate(group_member_remove);
            }

            if (methods.FirstOrDefault(m => m.Name == "GroupMemberRemove") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_member_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_remove_static_delegate) });
            }

            if (efl_canvas_group_member_is_static_delegate == null)
            {
                efl_canvas_group_member_is_static_delegate = new efl_canvas_group_member_is_delegate(group_member_is);
            }

            if (methods.FirstOrDefault(m => m.Name == "IsGroupMember") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_member_is"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_is_static_delegate) });
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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Group.efl_canvas_group_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_group_need_recalculate_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_group_need_recalculate_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_group_need_recalculate_get_api_delegate> efl_canvas_group_need_recalculate_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_need_recalculate_get_api_delegate>(Module, "efl_canvas_group_need_recalculate_get");

        private static bool group_need_recalculate_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_group_need_recalculate_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Group)ws.Target).GetGroupNeedRecalculate();
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
                return efl_canvas_group_need_recalculate_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_group_need_recalculate_get_delegate efl_canvas_group_need_recalculate_get_static_delegate;

        
        private delegate void efl_canvas_group_need_recalculate_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool value);

        
        public delegate void efl_canvas_group_need_recalculate_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool value);

        public static Efl.Eo.FunctionWrapper<efl_canvas_group_need_recalculate_set_api_delegate> efl_canvas_group_need_recalculate_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_need_recalculate_set_api_delegate>(Module, "efl_canvas_group_need_recalculate_set");

        private static void group_need_recalculate_set(System.IntPtr obj, System.IntPtr pd, bool value)
        {
            Eina.Log.Debug("function efl_canvas_group_need_recalculate_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Group)ws.Target).SetGroupNeedRecalculate(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_group_need_recalculate_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_canvas_group_need_recalculate_set_delegate efl_canvas_group_need_recalculate_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_canvas_group_clipper_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_canvas_group_clipper_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_group_clipper_get_api_delegate> efl_canvas_group_clipper_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_clipper_get_api_delegate>(Module, "efl_canvas_group_clipper_get");

        private static Efl.Canvas.Object group_clipper_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_group_clipper_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((Group)ws.Target).GetGroupClipper();
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
                return efl_canvas_group_clipper_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_group_clipper_get_delegate efl_canvas_group_clipper_get_static_delegate;

        
        private delegate void efl_canvas_group_change_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_canvas_group_change_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_group_change_api_delegate> efl_canvas_group_change_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_change_api_delegate>(Module, "efl_canvas_group_change");

        private static void group_change(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_group_change was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Group)ws.Target).GroupChange();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_canvas_group_change_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_group_change_delegate efl_canvas_group_change_static_delegate;

        
        private delegate void efl_canvas_group_calculate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_canvas_group_calculate_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_group_calculate_api_delegate> efl_canvas_group_calculate_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_calculate_api_delegate>(Module, "efl_canvas_group_calculate");

        private static void group_calculate(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_group_calculate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Group)ws.Target).CalculateGroup();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_canvas_group_calculate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_group_calculate_delegate efl_canvas_group_calculate_static_delegate;

        
        private delegate System.IntPtr efl_canvas_group_members_iterate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_canvas_group_members_iterate_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_group_members_iterate_api_delegate> efl_canvas_group_members_iterate_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_members_iterate_api_delegate>(Module, "efl_canvas_group_members_iterate");

        private static System.IntPtr group_members_iterate(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_group_members_iterate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Iterator<Efl.Canvas.Object> _ret_var = default(Eina.Iterator<Efl.Canvas.Object>);
                try
                {
                    _ret_var = ((Group)ws.Target).GroupMembersIterate();
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
                return efl_canvas_group_members_iterate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_group_members_iterate_delegate efl_canvas_group_members_iterate_static_delegate;

        
        private delegate void efl_canvas_group_member_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object sub_obj);

        
        public delegate void efl_canvas_group_member_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object sub_obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_group_member_add_api_delegate> efl_canvas_group_member_add_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_member_add_api_delegate>(Module, "efl_canvas_group_member_add");

        private static void group_member_add(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object sub_obj)
        {
            Eina.Log.Debug("function efl_canvas_group_member_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Group)ws.Target).AddGroupMember(sub_obj);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_group_member_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sub_obj);
            }
        }

        private static efl_canvas_group_member_add_delegate efl_canvas_group_member_add_static_delegate;

        
        private delegate void efl_canvas_group_member_remove_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object sub_obj);

        
        public delegate void efl_canvas_group_member_remove_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object sub_obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_group_member_remove_api_delegate> efl_canvas_group_member_remove_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_member_remove_api_delegate>(Module, "efl_canvas_group_member_remove");

        private static void group_member_remove(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object sub_obj)
        {
            Eina.Log.Debug("function efl_canvas_group_member_remove was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Group)ws.Target).GroupMemberRemove(sub_obj);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_group_member_remove_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sub_obj);
            }
        }

        private static efl_canvas_group_member_remove_delegate efl_canvas_group_member_remove_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_group_member_is_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object sub_obj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_group_member_is_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object sub_obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_group_member_is_api_delegate> efl_canvas_group_member_is_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_member_is_api_delegate>(Module, "efl_canvas_group_member_is");

        private static bool group_member_is(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object sub_obj)
        {
            Eina.Log.Debug("function efl_canvas_group_member_is was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Group)ws.Target).IsGroupMember(sub_obj);
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
                return efl_canvas_group_member_is_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sub_obj);
            }
        }

        private static efl_canvas_group_member_is_delegate efl_canvas_group_member_is_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_CanvasGroup_ExtensionMethods {
    public static Efl.BindableProperty<bool> GroupNeedRecalculate<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Group, T>magic = null) where T : Efl.Canvas.Group {
        return new Efl.BindableProperty<bool>("group_need_recalculate", fac);
    }

    
}
#pragma warning restore CS1591
#endif
