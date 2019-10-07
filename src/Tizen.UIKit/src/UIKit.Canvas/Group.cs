#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit {

namespace Canvas {

/// <summary>Event argument wrapper for event <see cref="UIKit.Canvas.Group.MemberAddedEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class GroupMemberAddedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when a member is added to the group.</value>
    public UIKit.Gfx.IEntity arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Canvas.Group.MemberRemovedEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class GroupMemberRemovedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when a member is removed from the group.</value>
    public UIKit.Gfx.IEntity arg { get; set; }
}

/// <summary>A group object is a container for other canvas objects. Its children move along their parent and are often clipped with a common clipper. This is part of the legacy smart object concept.
/// A group is not necessarily a container (see <see cref="UIKit.IContainer"/>) in the sense that a standard widget may not have any empty slots for content. However it&apos;s still a group of low-level canvas objects (clipper, raw objects, etc.).</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Canvas.Group.NativeMethods]
[UIKit.Wrapper.BindingEntity]
public class Group : UIKit.Canvas.Object
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Group))
            {
                return GetUIKitClassStatic();
            }
            else
            {
                return UIKit.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(UIKit.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_group_class_get();

    /// <summary>Initializes a new instance of the <see cref="Group"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <since_tizen> 6 </since_tizen>
    public Group(UIKit.Object parent= null
            ) : base(efl_canvas_group_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    /// <since_tizen> 6 </since_tizen>
    protected Group(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Group"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    /// <since_tizen> 6 </since_tizen>
    protected Group(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Group"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The UIKit.Object parent of this instance.</param>
    protected Group(IntPtr baseKlass, UIKit.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when a member is added to the group.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Canvas.GroupMemberAddedEventArgs"/></value>
    public event EventHandler<UIKit.Canvas.GroupMemberAddedEventArgs> MemberAddedEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Canvas.GroupMemberAddedEventArgs args = new UIKit.Canvas.GroupMemberAddedEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Gfx.EntityConcrete);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_ADDED";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_ADDED";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event MemberAddedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnMemberAddedEvent(UIKit.Canvas.GroupMemberAddedEventArgs e)
    {
        var key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_ADDED";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Called when a member is removed from the group.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Canvas.GroupMemberRemovedEventArgs"/></value>
    public event EventHandler<UIKit.Canvas.GroupMemberRemovedEventArgs> MemberRemovedEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Canvas.GroupMemberRemovedEventArgs args = new UIKit.Canvas.GroupMemberRemovedEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Gfx.EntityConcrete);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_REMOVED";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_REMOVED";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event MemberRemovedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnMemberRemovedEvent(UIKit.Canvas.GroupMemberRemovedEventArgs e)
    {
        var key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_REMOVED";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }


    /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
    /// If this flag is set, then the <see cref="UIKit.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
    /// 
    /// Note: setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="UIKit.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
    /// 
    /// See also <see cref="UIKit.Canvas.Group.CalculateGroup"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the group layout needs to be recalculated, <c>false</c> otherwise</returns>
    public virtual bool GetGroupNeedRecalculate() {
        var _ret_var = UIKit.Canvas.Group.NativeMethods.efl_canvas_group_need_recalculate_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
    /// If this flag is set, then the <see cref="UIKit.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
    /// 
    /// Note: setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="UIKit.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
    /// 
    /// See also <see cref="UIKit.Canvas.Group.CalculateGroup"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="value"><c>true</c> if the group layout needs to be recalculated, <c>false</c> otherwise</param>
    public virtual void SetGroupNeedRecalculate(bool value) {
        UIKit.Canvas.Group.NativeMethods.efl_canvas_group_need_recalculate_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The internal clipper object used by this group.
    /// This is the object clipping all the child objects. Do not delete or otherwise modify this clipper!</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A clipper rectangle.</returns>
    protected virtual UIKit.Canvas.Object GetGroupClipper() {
        var _ret_var = UIKit.Canvas.Group.NativeMethods.efl_canvas_group_clipper_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Marks the object as dirty.
    /// This also forcefully marks the given object as needing recalculation. As an effect, on the next rendering cycle its <see cref="UIKit.Canvas.Group.CalculateGroup"/> method will be called.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void GroupChange() {
        UIKit.Canvas.Group.NativeMethods.efl_canvas_group_change_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Triggers an immediate recalculation of this object&apos;s geometry.
    /// This will also reset the flag <see cref="UIKit.Canvas.Group.GroupNeedRecalculate"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void CalculateGroup() {
        UIKit.Canvas.Group.NativeMethods.efl_canvas_group_calculate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Returns an iterator over the children of this object, which are canvas objects.
    /// This returns the list of &quot;smart&quot; children. This might be different from both the <see cref="UIKit.Object"/> children list as well as the <see cref="UIKit.IContainer"/> content list.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Iterator to object children</returns>
    public virtual UIKit.DataTypes.Iterator<UIKit.Canvas.Object> IterateGroupMembers() {
        var _ret_var = UIKit.Canvas.Group.NativeMethods.efl_canvas_group_members_iterate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return new UIKit.DataTypes.Iterator<UIKit.Canvas.Object>(_ret_var, true);

    }

    /// <summary>Set a canvas object as a member of a given group (or smart object).
    /// Members will automatically be stacked and layered together with the smart object. The various stacking functions will operate on members relative to the other members instead of the entire canvas, since they now live on an exclusive layer (see <see cref="UIKit.Gfx.IStack.StackAbove"/>, for more details).
    /// 
    /// Subclasses inheriting from this one may override this function to ensure the proper stacking of special objects, such as clippers, event rectangles, etc...
    /// 
    /// See also <see cref="UIKit.Canvas.Group.RemoveGroupMember"/>. See also <see cref="UIKit.Canvas.Group.IsGroupMember"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="sub_obj">The member object.</param>
    public virtual void AddGroupMember(UIKit.Canvas.Object sub_obj) {
        UIKit.Canvas.Group.NativeMethods.efl_canvas_group_member_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),sub_obj);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Removes a member object from a given smart object.
    /// This removes a member object from a smart object, if it was added to any. The object will still be on the canvas, but no longer associated with whichever smart object it was associated with.
    /// 
    /// See also <see cref="UIKit.Canvas.Group.AddGroupMember"/>. See also <see cref="UIKit.Canvas.Group.IsGroupMember"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="sub_obj">The member object to remove.</param>
    public virtual void RemoveGroupMember(UIKit.Canvas.Object sub_obj) {
        UIKit.Canvas.Group.NativeMethods.efl_canvas_group_member_remove_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),sub_obj);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Finds out if a given object is a member of this group.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="sub_obj">A potential sub object.</param>
    /// <returns><c>true</c> if <c>sub_obj</c> is a member of this group.</returns>
    public virtual bool IsGroupMember(UIKit.Canvas.Object sub_obj) {
        var _ret_var = UIKit.Canvas.Group.NativeMethods.efl_canvas_group_member_is_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),sub_obj);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
    /// If this flag is set, then the <see cref="UIKit.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
    /// 
    /// Note: setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="UIKit.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
    /// 
    /// See also <see cref="UIKit.Canvas.Group.CalculateGroup"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if the group layout needs to be recalculated, <c>false</c> otherwise</value>
    public bool GroupNeedRecalculate {
        get { return GetGroupNeedRecalculate(); }
        set { SetGroupNeedRecalculate(value); }
    }

    /// <summary>The internal clipper object used by this group.
    /// This is the object clipping all the child objects. Do not delete or otherwise modify this clipper!</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>A clipper rectangle.</value>
    protected UIKit.Canvas.Object GroupClipper {
        get { return GetGroupClipper(); }
    }

    private static IntPtr GetUIKitClassStatic()
    {
        return UIKit.Canvas.Group.efl_canvas_group_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : UIKit.Canvas.Object.NativeMethods
    {
        private static UIKit.Wrapper.NativeModule Module = new UIKit.Wrapper.NativeModule(UIKit.Libs.Evas);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<UIKit_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<UIKit_Op_Description>();
            var methods = UIKit.Wrapper.Globals.GetUserMethods(type);

            if (efl_canvas_group_need_recalculate_get_static_delegate == null)
            {
                efl_canvas_group_need_recalculate_get_static_delegate = new efl_canvas_group_need_recalculate_get_delegate(group_need_recalculate_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGroupNeedRecalculate") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_need_recalculate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_need_recalculate_get_static_delegate) });
            }

            if (efl_canvas_group_need_recalculate_set_static_delegate == null)
            {
                efl_canvas_group_need_recalculate_set_static_delegate = new efl_canvas_group_need_recalculate_set_delegate(group_need_recalculate_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGroupNeedRecalculate") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_need_recalculate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_need_recalculate_set_static_delegate) });
            }

            if (efl_canvas_group_clipper_get_static_delegate == null)
            {
                efl_canvas_group_clipper_get_static_delegate = new efl_canvas_group_clipper_get_delegate(group_clipper_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGroupClipper") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_clipper_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_clipper_get_static_delegate) });
            }

            if (efl_canvas_group_change_static_delegate == null)
            {
                efl_canvas_group_change_static_delegate = new efl_canvas_group_change_delegate(group_change);
            }

            if (methods.FirstOrDefault(m => m.Name == "GroupChange") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_change"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_change_static_delegate) });
            }

            if (efl_canvas_group_calculate_static_delegate == null)
            {
                efl_canvas_group_calculate_static_delegate = new efl_canvas_group_calculate_delegate(group_calculate);
            }

            if (methods.FirstOrDefault(m => m.Name == "CalculateGroup") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_calculate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_calculate_static_delegate) });
            }

            if (efl_canvas_group_members_iterate_static_delegate == null)
            {
                efl_canvas_group_members_iterate_static_delegate = new efl_canvas_group_members_iterate_delegate(group_members_iterate);
            }

            if (methods.FirstOrDefault(m => m.Name == "IterateGroupMembers") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_members_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_members_iterate_static_delegate) });
            }

            if (efl_canvas_group_member_add_static_delegate == null)
            {
                efl_canvas_group_member_add_static_delegate = new efl_canvas_group_member_add_delegate(group_member_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddGroupMember") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_member_add"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_add_static_delegate) });
            }

            if (efl_canvas_group_member_remove_static_delegate == null)
            {
                efl_canvas_group_member_remove_static_delegate = new efl_canvas_group_member_remove_delegate(group_member_remove);
            }

            if (methods.FirstOrDefault(m => m.Name == "RemoveGroupMember") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_member_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_remove_static_delegate) });
            }

            if (efl_canvas_group_member_is_static_delegate == null)
            {
                efl_canvas_group_member_is_static_delegate = new efl_canvas_group_member_is_delegate(group_member_is);
            }

            if (methods.FirstOrDefault(m => m.Name == "IsGroupMember") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_member_is"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_is_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((UIKit.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is UIKit.Wrapper.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetUIKitClass()
        {
            return UIKit.Canvas.Group.efl_canvas_group_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_group_need_recalculate_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_group_need_recalculate_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_group_need_recalculate_get_api_delegate> efl_canvas_group_need_recalculate_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_group_need_recalculate_get_api_delegate>(Module, "efl_canvas_group_need_recalculate_get");

        private static bool group_need_recalculate_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_group_need_recalculate_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Group)ws.Target).GetGroupNeedRecalculate();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_group_need_recalculate_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_group_need_recalculate_get_delegate efl_canvas_group_need_recalculate_get_static_delegate;

        
        private delegate void efl_canvas_group_need_recalculate_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool value);

        
        public delegate void efl_canvas_group_need_recalculate_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool value);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_group_need_recalculate_set_api_delegate> efl_canvas_group_need_recalculate_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_group_need_recalculate_set_api_delegate>(Module, "efl_canvas_group_need_recalculate_set");

        private static void group_need_recalculate_set(System.IntPtr obj, System.IntPtr pd, bool value)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_group_need_recalculate_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Group)ws.Target).SetGroupNeedRecalculate(value);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_group_need_recalculate_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_canvas_group_need_recalculate_set_delegate efl_canvas_group_need_recalculate_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        private delegate UIKit.Canvas.Object efl_canvas_group_clipper_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        public delegate UIKit.Canvas.Object efl_canvas_group_clipper_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_group_clipper_get_api_delegate> efl_canvas_group_clipper_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_group_clipper_get_api_delegate>(Module, "efl_canvas_group_clipper_get");

        private static UIKit.Canvas.Object group_clipper_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_group_clipper_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Canvas.Object _ret_var = default(UIKit.Canvas.Object);
                try
                {
                    _ret_var = ((Group)ws.Target).GetGroupClipper();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_group_clipper_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_group_clipper_get_delegate efl_canvas_group_clipper_get_static_delegate;

        
        private delegate void efl_canvas_group_change_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_canvas_group_change_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_group_change_api_delegate> efl_canvas_group_change_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_group_change_api_delegate>(Module, "efl_canvas_group_change");

        private static void group_change(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_group_change was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Group)ws.Target).GroupChange();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_group_change_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_group_change_delegate efl_canvas_group_change_static_delegate;

        
        private delegate void efl_canvas_group_calculate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_canvas_group_calculate_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_group_calculate_api_delegate> efl_canvas_group_calculate_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_group_calculate_api_delegate>(Module, "efl_canvas_group_calculate");

        private static void group_calculate(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_group_calculate was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Group)ws.Target).CalculateGroup();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_group_calculate_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_group_calculate_delegate efl_canvas_group_calculate_static_delegate;

        
        private delegate System.IntPtr efl_canvas_group_members_iterate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_canvas_group_members_iterate_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_group_members_iterate_api_delegate> efl_canvas_group_members_iterate_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_group_members_iterate_api_delegate>(Module, "efl_canvas_group_members_iterate");

        private static System.IntPtr group_members_iterate(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_group_members_iterate was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Iterator<UIKit.Canvas.Object> _ret_var = default(UIKit.DataTypes.Iterator<UIKit.Canvas.Object>);
                try
                {
                    _ret_var = ((Group)ws.Target).IterateGroupMembers();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                _ret_var.Own = false; return _ret_var.Handle;
            }
            else
            {
                return efl_canvas_group_members_iterate_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_group_members_iterate_delegate efl_canvas_group_members_iterate_static_delegate;

        
        private delegate void efl_canvas_group_member_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Canvas.Object sub_obj);

        
        public delegate void efl_canvas_group_member_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Canvas.Object sub_obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_group_member_add_api_delegate> efl_canvas_group_member_add_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_group_member_add_api_delegate>(Module, "efl_canvas_group_member_add");

        private static void group_member_add(System.IntPtr obj, System.IntPtr pd, UIKit.Canvas.Object sub_obj)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_group_member_add was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Group)ws.Target).AddGroupMember(sub_obj);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_group_member_add_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), sub_obj);
            }
        }

        private static efl_canvas_group_member_add_delegate efl_canvas_group_member_add_static_delegate;

        
        private delegate void efl_canvas_group_member_remove_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Canvas.Object sub_obj);

        
        public delegate void efl_canvas_group_member_remove_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Canvas.Object sub_obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_group_member_remove_api_delegate> efl_canvas_group_member_remove_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_group_member_remove_api_delegate>(Module, "efl_canvas_group_member_remove");

        private static void group_member_remove(System.IntPtr obj, System.IntPtr pd, UIKit.Canvas.Object sub_obj)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_group_member_remove was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Group)ws.Target).RemoveGroupMember(sub_obj);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_group_member_remove_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), sub_obj);
            }
        }

        private static efl_canvas_group_member_remove_delegate efl_canvas_group_member_remove_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_group_member_is_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Canvas.Object sub_obj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_group_member_is_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Canvas.Object sub_obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_group_member_is_api_delegate> efl_canvas_group_member_is_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_group_member_is_api_delegate>(Module, "efl_canvas_group_member_is");

        private static bool group_member_is(System.IntPtr obj, System.IntPtr pd, UIKit.Canvas.Object sub_obj)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_group_member_is was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Group)ws.Target).IsGroupMember(sub_obj);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_group_member_is_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), sub_obj);
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
public static class UIKit_CanvasGroup_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
