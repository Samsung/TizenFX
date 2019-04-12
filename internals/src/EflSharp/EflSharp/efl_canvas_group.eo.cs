#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Group.MemberAddedEvt"/>.</summary>
public class GroupMemberAddedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Gfx.Entity arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Group.MemberRemovedEvt"/>.</summary>
public class GroupMemberRemovedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Gfx.Entity arg { get; set; }
}
/// <summary>A group object is a container for other canvas objects. Its children move along their parent and are often clipped with a common clipper. This is part of the legacy smart object concept.
/// A group is not necessarily a container (see <see cref="Efl.Container"/>) in the sense that a standard widget may not have any empty slots for content. However it&apos;s still a group of low-level canvas objects (clipper, raw objects, etc.).</summary>
[GroupNativeInherit]
public class Group : Efl.Canvas.Object, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.GroupNativeInherit nativeInherit = new Efl.Canvas.GroupNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Group))
            return Efl.Canvas.GroupNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_group_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public Group(Efl.Object parent= null
         ) :
      base(efl_canvas_group_class_get(), typeof(Group), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Group(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Group(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Group static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Group(obj.NativeHandle);
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
private static object MemberAddedEvtKey = new object();
   /// <summary>Called when a member is added to the group.</summary>
   public event EventHandler<Efl.Canvas.GroupMemberAddedEvt_Args> MemberAddedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_ADDED";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_MemberAddedEvt_delegate)) {
               eventHandlers.AddHandler(MemberAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_ADDED";
            if (remove_cpp_event_handler(key, this.evt_MemberAddedEvt_delegate)) { 
               eventHandlers.RemoveHandler(MemberAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event MemberAddedEvt.</summary>
   public void On_MemberAddedEvt(Efl.Canvas.GroupMemberAddedEvt_Args e)
   {
      EventHandler<Efl.Canvas.GroupMemberAddedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.GroupMemberAddedEvt_Args>)eventHandlers[MemberAddedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_MemberAddedEvt_delegate;
   private void on_MemberAddedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.GroupMemberAddedEvt_Args args = new Efl.Canvas.GroupMemberAddedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_MemberAddedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object MemberRemovedEvtKey = new object();
   /// <summary>Called when a member is removed from the group.</summary>
   public event EventHandler<Efl.Canvas.GroupMemberRemovedEvt_Args> MemberRemovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_REMOVED";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_MemberRemovedEvt_delegate)) {
               eventHandlers.AddHandler(MemberRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_REMOVED";
            if (remove_cpp_event_handler(key, this.evt_MemberRemovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(MemberRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event MemberRemovedEvt.</summary>
   public void On_MemberRemovedEvt(Efl.Canvas.GroupMemberRemovedEvt_Args e)
   {
      EventHandler<Efl.Canvas.GroupMemberRemovedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.GroupMemberRemovedEvt_Args>)eventHandlers[MemberRemovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_MemberRemovedEvt_delegate;
   private void on_MemberRemovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.GroupMemberRemovedEvt_Args args = new Efl.Canvas.GroupMemberRemovedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_MemberRemovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_MemberAddedEvt_delegate = new Efl.EventCb(on_MemberAddedEvt_NativeCallback);
      evt_MemberRemovedEvt_delegate = new Efl.EventCb(on_MemberRemovedEvt_NativeCallback);
   }
   /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
   /// If this flag is set, then the <see cref="Efl.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
   /// 
   /// Note: setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="Efl.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
   /// 
   /// See also <see cref="Efl.Canvas.Group.CalculateGroup"/>.</summary>
   /// <returns><c>true</c> if the group layout needs to be recalculated, <c>false</c> otherwise</returns>
   virtual public bool GetGroupNeedRecalculate() {
       var _ret_var = Efl.Canvas.GroupNativeInherit.efl_canvas_group_need_recalculate_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
   /// If this flag is set, then the <see cref="Efl.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
   /// 
   /// Note: setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="Efl.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
   /// 
   /// See also <see cref="Efl.Canvas.Group.CalculateGroup"/>.</summary>
   /// <param name="value"><c>true</c> if the group layout needs to be recalculated, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetGroupNeedRecalculate( bool value) {
                         Efl.Canvas.GroupNativeInherit.efl_canvas_group_need_recalculate_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the internal clipper.</summary>
   /// <returns>A clipper rectangle.</returns>
   virtual public Efl.Canvas.Object GetGroupClipper() {
       var _ret_var = Efl.Canvas.GroupNativeInherit.efl_canvas_group_clipper_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Marks the object as dirty.
   /// This also forcefully marks the given object as needing recalculation. As an effect, on the next rendering cycle its <see cref="Efl.Canvas.Group.CalculateGroup"/> method will be called.</summary>
   /// <returns></returns>
   virtual public  void GroupChange() {
       Efl.Canvas.GroupNativeInherit.efl_canvas_group_change_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Triggers an immediate recalculation of this object&apos;s geometry.
   /// This will also reset the flag <see cref="Efl.Canvas.Group.GroupNeedRecalculate"/>.</summary>
   /// <returns></returns>
   virtual public  void CalculateGroup() {
       Efl.Canvas.GroupNativeInherit.efl_canvas_group_calculate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Returns an iterator over the children of this object, which are canvas objects.
   /// This returns the list of &quot;smart&quot; children. This might be different from both the <see cref="Efl.Object"/> children list as well as the <see cref="Efl.Container"/> content list.</summary>
   /// <returns>Iterator to object children</returns>
   virtual public Eina.Iterator<Efl.Canvas.Object> GroupMembersIterate() {
       var _ret_var = Efl.Canvas.GroupNativeInherit.efl_canvas_group_members_iterate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Canvas.Object>(_ret_var, true, false);
 }
   /// <summary>Set a canvas object as a member of a given group (or smart object).
   /// Members will automatically be stacked and layered together with the smart object. The various stacking functions will operate on members relative to the other members instead of the entire canvas, since they now live on an exclusive layer (see <see cref="Efl.Gfx.Stack.StackAbove"/>, for more details).
   /// 
   /// Subclasses inheriting from this one may override this function to ensure the proper stacking of special objects, such as clippers, event rectangles, etc...
   /// 
   /// See also <see cref="Efl.Canvas.Group.GroupMemberRemove"/>. See also <see cref="Efl.Canvas.Group.IsGroupMember"/>.</summary>
   /// <param name="sub_obj">The member object.</param>
   /// <returns></returns>
   virtual public  void AddGroupMember( Efl.Canvas.Object sub_obj) {
                         Efl.Canvas.GroupNativeInherit.efl_canvas_group_member_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), sub_obj);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Removes a member object from a given smart object.
   /// This removes a member object from a smart object, if it was added to any. The object will still be on the canvas, but no longer associated with whichever smart object it was associated with.
   /// 
   /// See also <see cref="Efl.Canvas.Group.AddGroupMember"/>. See also <see cref="Efl.Canvas.Group.IsGroupMember"/>.</summary>
   /// <param name="sub_obj">The member object to remove.</param>
   /// <returns></returns>
   virtual public  void GroupMemberRemove( Efl.Canvas.Object sub_obj) {
                         Efl.Canvas.GroupNativeInherit.efl_canvas_group_member_remove_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), sub_obj);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Finds out if a given object is a member of this group.</summary>
   /// <param name="sub_obj">A potential sub object.</param>
   /// <returns><c>true</c> if <c>sub_obj</c> is a member of this group.</returns>
   virtual public bool IsGroupMember( Efl.Canvas.Object sub_obj) {
                         var _ret_var = Efl.Canvas.GroupNativeInherit.efl_canvas_group_member_is_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), sub_obj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
/// If this flag is set, then the <see cref="Efl.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
/// 
/// Note: setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="Efl.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
/// 
/// See also <see cref="Efl.Canvas.Group.CalculateGroup"/>.</summary>
/// <value><c>true</c> if the group layout needs to be recalculated, <c>false</c> otherwise</value>
   public bool GroupNeedRecalculate {
      get { return GetGroupNeedRecalculate(); }
      set { SetGroupNeedRecalculate( value); }
   }
   /// <summary>The internal clipper object used by this group.
/// This is the object clipping all the child objects. Do not delete or otherwise modify this clipper!</summary>
/// <value>A clipper rectangle.</value>
   public Efl.Canvas.Object GroupClipper {
      get { return GetGroupClipper(); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Group.efl_canvas_group_class_get();
   }
}
public class GroupNativeInherit : Efl.Canvas.ObjectNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_canvas_group_need_recalculate_get_static_delegate == null)
      efl_canvas_group_need_recalculate_get_static_delegate = new efl_canvas_group_need_recalculate_get_delegate(group_need_recalculate_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_group_need_recalculate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_need_recalculate_get_static_delegate)});
      if (efl_canvas_group_need_recalculate_set_static_delegate == null)
      efl_canvas_group_need_recalculate_set_static_delegate = new efl_canvas_group_need_recalculate_set_delegate(group_need_recalculate_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_group_need_recalculate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_need_recalculate_set_static_delegate)});
      if (efl_canvas_group_clipper_get_static_delegate == null)
      efl_canvas_group_clipper_get_static_delegate = new efl_canvas_group_clipper_get_delegate(group_clipper_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_group_clipper_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_clipper_get_static_delegate)});
      if (efl_canvas_group_change_static_delegate == null)
      efl_canvas_group_change_static_delegate = new efl_canvas_group_change_delegate(group_change);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_group_change"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_change_static_delegate)});
      if (efl_canvas_group_calculate_static_delegate == null)
      efl_canvas_group_calculate_static_delegate = new efl_canvas_group_calculate_delegate(group_calculate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_group_calculate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_calculate_static_delegate)});
      if (efl_canvas_group_members_iterate_static_delegate == null)
      efl_canvas_group_members_iterate_static_delegate = new efl_canvas_group_members_iterate_delegate(group_members_iterate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_group_members_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_members_iterate_static_delegate)});
      if (efl_canvas_group_member_add_static_delegate == null)
      efl_canvas_group_member_add_static_delegate = new efl_canvas_group_member_add_delegate(group_member_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_group_member_add"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_add_static_delegate)});
      if (efl_canvas_group_member_remove_static_delegate == null)
      efl_canvas_group_member_remove_static_delegate = new efl_canvas_group_member_remove_delegate(group_member_remove);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_group_member_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_remove_static_delegate)});
      if (efl_canvas_group_member_is_static_delegate == null)
      efl_canvas_group_member_is_static_delegate = new efl_canvas_group_member_is_delegate(group_member_is);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_group_member_is"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_is_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.Group.efl_canvas_group_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Group.efl_canvas_group_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_group_need_recalculate_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_group_need_recalculate_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_group_need_recalculate_get_api_delegate> efl_canvas_group_need_recalculate_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_need_recalculate_get_api_delegate>(_Module, "efl_canvas_group_need_recalculate_get");
    private static bool group_need_recalculate_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_group_need_recalculate_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Group)wrapper).GetGroupNeedRecalculate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_group_need_recalculate_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_group_need_recalculate_get_delegate efl_canvas_group_need_recalculate_get_static_delegate;


    private delegate  void efl_canvas_group_need_recalculate_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool value);


    public delegate  void efl_canvas_group_need_recalculate_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool value);
    public static Efl.Eo.FunctionWrapper<efl_canvas_group_need_recalculate_set_api_delegate> efl_canvas_group_need_recalculate_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_need_recalculate_set_api_delegate>(_Module, "efl_canvas_group_need_recalculate_set");
    private static  void group_need_recalculate_set(System.IntPtr obj, System.IntPtr pd,  bool value)
   {
      Eina.Log.Debug("function efl_canvas_group_need_recalculate_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Group)wrapper).SetGroupNeedRecalculate( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_group_need_recalculate_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_canvas_group_need_recalculate_set_delegate efl_canvas_group_need_recalculate_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_canvas_group_clipper_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Object efl_canvas_group_clipper_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_group_clipper_get_api_delegate> efl_canvas_group_clipper_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_clipper_get_api_delegate>(_Module, "efl_canvas_group_clipper_get");
    private static Efl.Canvas.Object group_clipper_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_group_clipper_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Group)wrapper).GetGroupClipper();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_group_clipper_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_group_clipper_get_delegate efl_canvas_group_clipper_get_static_delegate;


    private delegate  void efl_canvas_group_change_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_canvas_group_change_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_group_change_api_delegate> efl_canvas_group_change_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_change_api_delegate>(_Module, "efl_canvas_group_change");
    private static  void group_change(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_group_change was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Group)wrapper).GroupChange();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_canvas_group_change_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_group_change_delegate efl_canvas_group_change_static_delegate;


    private delegate  void efl_canvas_group_calculate_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_canvas_group_calculate_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_group_calculate_api_delegate> efl_canvas_group_calculate_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_calculate_api_delegate>(_Module, "efl_canvas_group_calculate");
    private static  void group_calculate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_group_calculate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Group)wrapper).CalculateGroup();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_canvas_group_calculate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_group_calculate_delegate efl_canvas_group_calculate_static_delegate;


    private delegate  System.IntPtr efl_canvas_group_members_iterate_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_canvas_group_members_iterate_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_group_members_iterate_api_delegate> efl_canvas_group_members_iterate_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_members_iterate_api_delegate>(_Module, "efl_canvas_group_members_iterate");
    private static  System.IntPtr group_members_iterate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_group_members_iterate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.Canvas.Object> _ret_var = default(Eina.Iterator<Efl.Canvas.Object>);
         try {
            _ret_var = ((Group)wrapper).GroupMembersIterate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_canvas_group_members_iterate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_group_members_iterate_delegate efl_canvas_group_members_iterate_static_delegate;


    private delegate  void efl_canvas_group_member_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);


    public delegate  void efl_canvas_group_member_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_group_member_add_api_delegate> efl_canvas_group_member_add_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_member_add_api_delegate>(_Module, "efl_canvas_group_member_add");
    private static  void group_member_add(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object sub_obj)
   {
      Eina.Log.Debug("function efl_canvas_group_member_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Group)wrapper).AddGroupMember( sub_obj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_group_member_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sub_obj);
      }
   }
   private static efl_canvas_group_member_add_delegate efl_canvas_group_member_add_static_delegate;


    private delegate  void efl_canvas_group_member_remove_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);


    public delegate  void efl_canvas_group_member_remove_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_group_member_remove_api_delegate> efl_canvas_group_member_remove_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_member_remove_api_delegate>(_Module, "efl_canvas_group_member_remove");
    private static  void group_member_remove(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object sub_obj)
   {
      Eina.Log.Debug("function efl_canvas_group_member_remove was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Group)wrapper).GroupMemberRemove( sub_obj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_group_member_remove_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sub_obj);
      }
   }
   private static efl_canvas_group_member_remove_delegate efl_canvas_group_member_remove_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_group_member_is_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_group_member_is_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_group_member_is_api_delegate> efl_canvas_group_member_is_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_group_member_is_api_delegate>(_Module, "efl_canvas_group_member_is");
    private static bool group_member_is(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object sub_obj)
   {
      Eina.Log.Debug("function efl_canvas_group_member_is was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Group)wrapper).IsGroupMember( sub_obj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_group_member_is_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sub_obj);
      }
   }
   private static efl_canvas_group_member_is_delegate efl_canvas_group_member_is_static_delegate;
}
} } 
