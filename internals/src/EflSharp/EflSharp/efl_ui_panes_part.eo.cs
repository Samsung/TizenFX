#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Elementary Panes internal part class</summary>
[PanesPartNativeInherit]
public class PanesPart : Efl.Ui.LayoutPartContent, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.PanesPartNativeInherit nativeInherit = new Efl.Ui.PanesPartNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (PanesPart))
            return Efl.Ui.PanesPartNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(PanesPart obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_panes_part_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public PanesPart(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("PanesPart", efl_ui_panes_part_class_get(), typeof(PanesPart), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected PanesPart(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public PanesPart(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static PanesPart static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new PanesPart(obj.NativeHandle);
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
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_panes_part_hint_min_allow_get(System.IntPtr obj);
   /// <summary>Allows the user to set size hints to be respected and ignored combined with a minimum size. If this flag is set, the minimum size set by <see cref="Efl.Gfx.SizeHint.SetHintMin"/> is respected forcefully.</summary>
   /// <returns>If <c>true</c> minimum size is forced</returns>
   virtual public bool GetHintMinAllow() {
       var _ret_var = efl_ui_panes_part_hint_min_allow_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_panes_part_hint_min_allow_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool allow);
   /// <summary>Allows the user to set size hints to be respected and ignored combined with a minimum size. If this flag is set, the minimum size set by <see cref="Efl.Gfx.SizeHint.SetHintMin"/> is respected forcefully.</summary>
   /// <param name="allow">If <c>true</c> minimum size is forced</param>
   /// <returns></returns>
   virtual public  void SetHintMinAllow( bool allow) {
                         efl_ui_panes_part_hint_min_allow_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  allow);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern double efl_ui_panes_part_split_ratio_min_get(System.IntPtr obj);
   /// <summary>Controls the relative minimum size of panes widget&apos;s part.
   /// If <see cref="Efl.Gfx.SizeHint.SetHintMin"/> is also used along with <see cref="Efl.Ui.PanesPart.SetSplitRatioMin"/>, maximum value is set as minimum size to part.</summary>
   /// <returns>Value between 0.0 and 1.0 representing size proportion of first part&apos;s minimum size.</returns>
   virtual public double GetSplitRatioMin() {
       var _ret_var = efl_ui_panes_part_split_ratio_min_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_panes_part_split_ratio_min_set(System.IntPtr obj,   double size);
   /// <summary>Controls the relative minimum size of panes widget&apos;s part.
   /// If <see cref="Efl.Gfx.SizeHint.SetHintMin"/> is also used along with <see cref="Efl.Ui.PanesPart.SetSplitRatioMin"/>, maximum value is set as minimum size to part.</summary>
   /// <param name="size">Value between 0.0 and 1.0 representing size proportion of first part&apos;s minimum size.</param>
   /// <returns></returns>
   virtual public  void SetSplitRatioMin( double size) {
                         efl_ui_panes_part_split_ratio_min_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  size);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Allows the user to set size hints to be respected and ignored combined with a minimum size. If this flag is set, the minimum size set by <see cref="Efl.Gfx.SizeHint.SetHintMin"/> is respected forcefully.</summary>
   public bool HintMinAllow {
      get { return GetHintMinAllow(); }
      set { SetHintMinAllow( value); }
   }
   /// <summary>Controls the relative minimum size of panes widget&apos;s part.
/// If <see cref="Efl.Gfx.SizeHint.SetHintMin"/> is also used along with <see cref="Efl.Ui.PanesPart.SetSplitRatioMin"/>, maximum value is set as minimum size to part.</summary>
   public double SplitRatioMin {
      get { return GetSplitRatioMin(); }
      set { SetSplitRatioMin( value); }
   }
}
public class PanesPartNativeInherit : Efl.Ui.LayoutPartContentNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_panes_part_hint_min_allow_get_static_delegate = new efl_ui_panes_part_hint_min_allow_get_delegate(hint_min_allow_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_panes_part_hint_min_allow_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_part_hint_min_allow_get_static_delegate)});
      efl_ui_panes_part_hint_min_allow_set_static_delegate = new efl_ui_panes_part_hint_min_allow_set_delegate(hint_min_allow_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_panes_part_hint_min_allow_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_part_hint_min_allow_set_static_delegate)});
      efl_ui_panes_part_split_ratio_min_get_static_delegate = new efl_ui_panes_part_split_ratio_min_get_delegate(split_ratio_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_panes_part_split_ratio_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_part_split_ratio_min_get_static_delegate)});
      efl_ui_panes_part_split_ratio_min_set_static_delegate = new efl_ui_panes_part_split_ratio_min_set_delegate(split_ratio_min_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_panes_part_split_ratio_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_part_split_ratio_min_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.PanesPart.efl_ui_panes_part_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.PanesPart.efl_ui_panes_part_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_panes_part_hint_min_allow_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_panes_part_hint_min_allow_get(System.IntPtr obj);
    private static bool hint_min_allow_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_panes_part_hint_min_allow_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((PanesPart)wrapper).GetHintMinAllow();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_panes_part_hint_min_allow_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_panes_part_hint_min_allow_get_delegate efl_ui_panes_part_hint_min_allow_get_static_delegate;


    private delegate  void efl_ui_panes_part_hint_min_allow_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool allow);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_panes_part_hint_min_allow_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool allow);
    private static  void hint_min_allow_set(System.IntPtr obj, System.IntPtr pd,  bool allow)
   {
      Eina.Log.Debug("function efl_ui_panes_part_hint_min_allow_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((PanesPart)wrapper).SetHintMinAllow( allow);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_panes_part_hint_min_allow_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  allow);
      }
   }
   private efl_ui_panes_part_hint_min_allow_set_delegate efl_ui_panes_part_hint_min_allow_set_static_delegate;


    private delegate double efl_ui_panes_part_split_ratio_min_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern double efl_ui_panes_part_split_ratio_min_get(System.IntPtr obj);
    private static double split_ratio_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_panes_part_split_ratio_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((PanesPart)wrapper).GetSplitRatioMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_panes_part_split_ratio_min_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_panes_part_split_ratio_min_get_delegate efl_ui_panes_part_split_ratio_min_get_static_delegate;


    private delegate  void efl_ui_panes_part_split_ratio_min_set_delegate(System.IntPtr obj, System.IntPtr pd,   double size);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_panes_part_split_ratio_min_set(System.IntPtr obj,   double size);
    private static  void split_ratio_min_set(System.IntPtr obj, System.IntPtr pd,  double size)
   {
      Eina.Log.Debug("function efl_ui_panes_part_split_ratio_min_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((PanesPart)wrapper).SetSplitRatioMin( size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_panes_part_split_ratio_min_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
      }
   }
   private efl_ui_panes_part_split_ratio_min_set_delegate efl_ui_panes_part_split_ratio_min_set_static_delegate;
}
} } 
