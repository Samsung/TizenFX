#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
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
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Group obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_group_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Group(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Group", efl_canvas_group_class_get(), typeof(Group), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Group(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Group(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
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
   protected override void register_event_proxies()
   {
      base.register_event_proxies();
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_group_need_recalculate_get(System.IntPtr obj);
   /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
   /// If this flag is set, then the <see cref="Efl.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
   /// 
   /// Note: setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="Efl.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
   /// 
   /// See also <see cref="Efl.Canvas.Group.CalculateGroup"/>.</summary>
   /// <returns><c>true</c> if the group layout needs to be recalculated, <c>false</c> otherwise</returns>
   virtual public bool GetGroupNeedRecalculate() {
       var _ret_var = efl_canvas_group_need_recalculate_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_group_need_recalculate_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool value);
   /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
   /// If this flag is set, then the <see cref="Efl.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
   /// 
   /// Note: setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="Efl.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
   /// 
   /// See also <see cref="Efl.Canvas.Group.CalculateGroup"/>.</summary>
   /// <param name="value"><c>true</c> if the group layout needs to be recalculated, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetGroupNeedRecalculate( bool value) {
                         efl_canvas_group_need_recalculate_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Object efl_canvas_group_clipper_get(System.IntPtr obj);
   /// <summary>Get the internal clipper.</summary>
   /// <returns>A clipper rectangle.</returns>
   virtual public Efl.Canvas.Object GetGroupClipper() {
       var _ret_var = efl_canvas_group_clipper_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_group_change(System.IntPtr obj);
   /// <summary>Marks the object as dirty.
   /// This also forcefully marks the given object as needing recalculation. As an effect, on the next rendering cycle its <see cref="Efl.Canvas.Group.CalculateGroup"/> method will be called.</summary>
   /// <returns></returns>
   virtual public  void GroupChange() {
       efl_canvas_group_change((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_group_calculate(System.IntPtr obj);
   /// <summary>Triggers an immediate recalculation of this object&apos;s geometry.
   /// This will also reset the flag <see cref="Efl.Canvas.Group.GroupNeedRecalculate"/>.</summary>
   /// <returns></returns>
   virtual public  void CalculateGroup() {
       efl_canvas_group_calculate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  System.IntPtr efl_canvas_group_members_iterate(System.IntPtr obj);
   /// <summary>Returns an iterator over the children of this object, which are canvas objects.
   /// This returns the list of &quot;smart&quot; children. This might be different from both the <see cref="Efl.Object"/> children list as well as the <see cref="Efl.Container"/> content list.</summary>
   /// <returns>Iterator to object children</returns>
   virtual public Eina.Iterator<Efl.Canvas.Object> GroupMembersIterate() {
       var _ret_var = efl_canvas_group_members_iterate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Canvas.Object>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_group_member_add(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
   /// <summary>Set a canvas object as a member of a given group (or smart object).
   /// Members will automatically be stacked and layered together with the smart object. The various stacking functions will operate on members relative to the other members instead of the entire canvas, since they now live on an exclusive layer (see <see cref="Efl.Gfx.Stack.StackAbove"/>, for more details).
   /// 
   /// Subclasses inheriting from this one may override this function to ensure the proper stacking of special objects, such as clippers, event rectangles, etc...
   /// 
   /// See also <see cref="Efl.Canvas.Group.DelGroupMember"/>. See also <see cref="Efl.Canvas.Group.IsGroupMember"/>.</summary>
   /// <param name="sub_obj">The member object.</param>
   /// <returns></returns>
   virtual public  void AddGroupMember( Efl.Canvas.Object sub_obj) {
                         efl_canvas_group_member_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  sub_obj);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_group_member_del(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
   /// <summary>Removes a member object from a given smart object.
   /// This removes a member object from a smart object, if it was added to any. The object will still be on the canvas, but no longer associated with whichever smart object it was associated with.
   /// 
   /// See also <see cref="Efl.Canvas.Group.AddGroupMember"/>. See also <see cref="Efl.Canvas.Group.IsGroupMember"/>.</summary>
   /// <param name="sub_obj">The member object to remove.</param>
   /// <returns></returns>
   virtual public  void DelGroupMember( Efl.Canvas.Object sub_obj) {
                         efl_canvas_group_member_del((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  sub_obj);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_group_member_is(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
   /// <summary>Finds out if a given object is a member of this group.</summary>
   /// <param name="sub_obj">A potential sub object.</param>
   /// <returns><c>true</c> if <c>sub_obj</c> is a member of this group.</returns>
   virtual public bool IsGroupMember( Efl.Canvas.Object sub_obj) {
                         var _ret_var = efl_canvas_group_member_is((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  sub_obj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
/// If this flag is set, then the <see cref="Efl.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
/// 
/// Note: setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="Efl.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
/// 
/// See also <see cref="Efl.Canvas.Group.CalculateGroup"/>.</summary>
   public bool GroupNeedRecalculate {
      get { return GetGroupNeedRecalculate(); }
      set { SetGroupNeedRecalculate( value); }
   }
   /// <summary>The internal clipper object used by this group.
/// This is the object clipping all the child objects. Do not delete or otherwise modify this clipper!</summary>
   public Efl.Canvas.Object GroupClipper {
      get { return GetGroupClipper(); }
   }
}
public class GroupNativeInherit : Efl.Canvas.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_canvas_group_need_recalculate_get_static_delegate = new efl_canvas_group_need_recalculate_get_delegate(group_need_recalculate_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_group_need_recalculate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_need_recalculate_get_static_delegate)});
      efl_canvas_group_need_recalculate_set_static_delegate = new efl_canvas_group_need_recalculate_set_delegate(group_need_recalculate_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_group_need_recalculate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_need_recalculate_set_static_delegate)});
      efl_canvas_group_clipper_get_static_delegate = new efl_canvas_group_clipper_get_delegate(group_clipper_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_group_clipper_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_clipper_get_static_delegate)});
      efl_canvas_group_change_static_delegate = new efl_canvas_group_change_delegate(group_change);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_group_change"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_change_static_delegate)});
      efl_canvas_group_calculate_static_delegate = new efl_canvas_group_calculate_delegate(group_calculate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_group_calculate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_calculate_static_delegate)});
      efl_canvas_group_members_iterate_static_delegate = new efl_canvas_group_members_iterate_delegate(group_members_iterate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_group_members_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_members_iterate_static_delegate)});
      efl_canvas_group_member_add_static_delegate = new efl_canvas_group_member_add_delegate(group_member_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_group_member_add"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_add_static_delegate)});
      efl_canvas_group_member_del_static_delegate = new efl_canvas_group_member_del_delegate(group_member_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_group_member_del"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_del_static_delegate)});
      efl_canvas_group_member_is_static_delegate = new efl_canvas_group_member_is_delegate(group_member_is);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_group_member_is"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_is_static_delegate)});
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_group_need_recalculate_get(System.IntPtr obj);
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
         return efl_canvas_group_need_recalculate_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_group_need_recalculate_get_delegate efl_canvas_group_need_recalculate_get_static_delegate;


    private delegate  void efl_canvas_group_need_recalculate_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_group_need_recalculate_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool value);
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
         efl_canvas_group_need_recalculate_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_canvas_group_need_recalculate_set_delegate efl_canvas_group_need_recalculate_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_canvas_group_clipper_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Object efl_canvas_group_clipper_get(System.IntPtr obj);
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
         return efl_canvas_group_clipper_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_group_clipper_get_delegate efl_canvas_group_clipper_get_static_delegate;


    private delegate  void efl_canvas_group_change_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_group_change(System.IntPtr obj);
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
         efl_canvas_group_change(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_group_change_delegate efl_canvas_group_change_static_delegate;


    private delegate  void efl_canvas_group_calculate_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_group_calculate(System.IntPtr obj);
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
         efl_canvas_group_calculate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_group_calculate_delegate efl_canvas_group_calculate_static_delegate;


    private delegate  System.IntPtr efl_canvas_group_members_iterate_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  System.IntPtr efl_canvas_group_members_iterate(System.IntPtr obj);
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
         return efl_canvas_group_members_iterate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_group_members_iterate_delegate efl_canvas_group_members_iterate_static_delegate;


    private delegate  void efl_canvas_group_member_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_group_member_add(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
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
         efl_canvas_group_member_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sub_obj);
      }
   }
   private efl_canvas_group_member_add_delegate efl_canvas_group_member_add_static_delegate;


    private delegate  void efl_canvas_group_member_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_group_member_del(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
    private static  void group_member_del(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object sub_obj)
   {
      Eina.Log.Debug("function efl_canvas_group_member_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Group)wrapper).DelGroupMember( sub_obj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_group_member_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sub_obj);
      }
   }
   private efl_canvas_group_member_del_delegate efl_canvas_group_member_del_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_group_member_is_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_group_member_is(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
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
         return efl_canvas_group_member_is(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sub_obj);
      }
   }
   private efl_canvas_group_member_is_delegate efl_canvas_group_member_is_static_delegate;
}
} } 
