#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Page { 
/// <summary>Page transition for <see cref="Efl.Ui.Pager"/>
/// With this type of transition, pages are arranged linearly and move parallel to the screen by scrolling. The current page is displayed at center, and previous and next pages might be displayed optionally.</summary>
[TransitionScrollNativeInherit]
public class TransitionScroll : Efl.Page.Transition, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Page.TransitionScrollNativeInherit nativeInherit = new Efl.Page.TransitionScrollNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (TransitionScroll))
            return Efl.Page.TransitionScrollNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(TransitionScroll obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_page_transition_scroll_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public TransitionScroll(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("TransitionScroll", efl_page_transition_scroll_class_get(), typeof(TransitionScroll), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected TransitionScroll(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public TransitionScroll(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static TransitionScroll static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new TransitionScroll(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  int efl_page_transition_scroll_side_page_num_get(System.IntPtr obj);
   /// <summary>The number of pages displayed on each side of the current page</summary>
   /// <returns></returns>
   virtual public  int GetSidePageNum() {
       var _ret_var = efl_page_transition_scroll_side_page_num_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_page_transition_scroll_side_page_num_set(System.IntPtr obj,    int side_page_num);
   /// <summary>The number of pages displayed on each side of the current page</summary>
   /// <param name="side_page_num"></param>
   /// <returns></returns>
   virtual public  void SetSidePageNum(  int side_page_num) {
                         efl_page_transition_scroll_side_page_num_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  side_page_num);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The number of pages displayed on each side of the current page</summary>
   public  int SidePageNum {
      get { return GetSidePageNum(); }
      set { SetSidePageNum( value); }
   }
}
public class TransitionScrollNativeInherit : Efl.Page.TransitionNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_page_transition_scroll_side_page_num_get_static_delegate = new efl_page_transition_scroll_side_page_num_get_delegate(side_page_num_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_page_transition_scroll_side_page_num_get"), func = Marshal.GetFunctionPointerForDelegate(efl_page_transition_scroll_side_page_num_get_static_delegate)});
      efl_page_transition_scroll_side_page_num_set_static_delegate = new efl_page_transition_scroll_side_page_num_set_delegate(side_page_num_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_page_transition_scroll_side_page_num_set"), func = Marshal.GetFunctionPointerForDelegate(efl_page_transition_scroll_side_page_num_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Page.TransitionScroll.efl_page_transition_scroll_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Page.TransitionScroll.efl_page_transition_scroll_class_get();
   }


    private delegate  int efl_page_transition_scroll_side_page_num_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  int efl_page_transition_scroll_side_page_num_get(System.IntPtr obj);
    private static  int side_page_num_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_page_transition_scroll_side_page_num_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((TransitionScroll)wrapper).GetSidePageNum();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_page_transition_scroll_side_page_num_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_page_transition_scroll_side_page_num_get_delegate efl_page_transition_scroll_side_page_num_get_static_delegate;


    private delegate  void efl_page_transition_scroll_side_page_num_set_delegate(System.IntPtr obj, System.IntPtr pd,    int side_page_num);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_page_transition_scroll_side_page_num_set(System.IntPtr obj,    int side_page_num);
    private static  void side_page_num_set(System.IntPtr obj, System.IntPtr pd,   int side_page_num)
   {
      Eina.Log.Debug("function efl_page_transition_scroll_side_page_num_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TransitionScroll)wrapper).SetSidePageNum( side_page_num);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_page_transition_scroll_side_page_num_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  side_page_num);
      }
   }
   private efl_page_transition_scroll_side_page_num_set_delegate efl_page_transition_scroll_side_page_num_set_static_delegate;
}
} } 
