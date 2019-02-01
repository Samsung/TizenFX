#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>A custom layout engine for <see cref="Efl.Ui.Box"/>.</summary>
[BoxFlowNativeInherit]
public class BoxFlow : Efl.Ui.Box, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.BoxFlowNativeInherit nativeInherit = new Efl.Ui.BoxFlowNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (BoxFlow))
            return Efl.Ui.BoxFlowNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(BoxFlow obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_box_flow_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public BoxFlow(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("BoxFlow", efl_ui_box_flow_class_get(), typeof(BoxFlow), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected BoxFlow(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public BoxFlow(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static BoxFlow static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new BoxFlow(obj.NativeHandle);
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
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_box_flow_homogenous_get(System.IntPtr obj);
   /// <summary>Box flow homogenous property</summary>
   /// <returns><c>true</c> if the box flow layout is homogenous, <c>false</c> otherwise</returns>
   virtual public bool GetBoxFlowHomogenous() {
       var _ret_var = efl_ui_box_flow_homogenous_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_box_flow_homogenous_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
   /// <summary>Box flow homogenous property</summary>
   /// <param name="val"><c>true</c> if the box flow layout is homogenous, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetBoxFlowHomogenous( bool val) {
                         efl_ui_box_flow_homogenous_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_box_flow_max_size_get(System.IntPtr obj);
   /// <summary>Box flow maximum size property</summary>
   /// <returns><c>true</c> if the box flow layout has the maximal size, <c>false</c> otherwise</returns>
   virtual public bool GetBoxFlowMaxSize() {
       var _ret_var = efl_ui_box_flow_max_size_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_box_flow_max_size_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
   /// <summary>Box flow maximum size property</summary>
   /// <param name="val"><c>true</c> if the box flow layout has the maximal size, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetBoxFlowMaxSize( bool val) {
                         efl_ui_box_flow_max_size_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Box flow homogenous property</summary>
   public bool BoxFlowHomogenous {
      get { return GetBoxFlowHomogenous(); }
      set { SetBoxFlowHomogenous( value); }
   }
   /// <summary>Box flow maximum size property</summary>
   public bool BoxFlowMaxSize {
      get { return GetBoxFlowMaxSize(); }
      set { SetBoxFlowMaxSize( value); }
   }
}
public class BoxFlowNativeInherit : Efl.Ui.BoxNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_box_flow_homogenous_get_static_delegate = new efl_ui_box_flow_homogenous_get_delegate(box_flow_homogenous_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_box_flow_homogenous_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_box_flow_homogenous_get_static_delegate)});
      efl_ui_box_flow_homogenous_set_static_delegate = new efl_ui_box_flow_homogenous_set_delegate(box_flow_homogenous_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_box_flow_homogenous_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_box_flow_homogenous_set_static_delegate)});
      efl_ui_box_flow_max_size_get_static_delegate = new efl_ui_box_flow_max_size_get_delegate(box_flow_max_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_box_flow_max_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_box_flow_max_size_get_static_delegate)});
      efl_ui_box_flow_max_size_set_static_delegate = new efl_ui_box_flow_max_size_set_delegate(box_flow_max_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_box_flow_max_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_box_flow_max_size_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.BoxFlow.efl_ui_box_flow_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.BoxFlow.efl_ui_box_flow_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_box_flow_homogenous_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_box_flow_homogenous_get(System.IntPtr obj);
    private static bool box_flow_homogenous_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_box_flow_homogenous_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((BoxFlow)wrapper).GetBoxFlowHomogenous();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_box_flow_homogenous_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_box_flow_homogenous_get_delegate efl_ui_box_flow_homogenous_get_static_delegate;


    private delegate  void efl_ui_box_flow_homogenous_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_box_flow_homogenous_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    private static  void box_flow_homogenous_set(System.IntPtr obj, System.IntPtr pd,  bool val)
   {
      Eina.Log.Debug("function efl_ui_box_flow_homogenous_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((BoxFlow)wrapper).SetBoxFlowHomogenous( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_box_flow_homogenous_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private efl_ui_box_flow_homogenous_set_delegate efl_ui_box_flow_homogenous_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_box_flow_max_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_box_flow_max_size_get(System.IntPtr obj);
    private static bool box_flow_max_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_box_flow_max_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((BoxFlow)wrapper).GetBoxFlowMaxSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_box_flow_max_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_box_flow_max_size_get_delegate efl_ui_box_flow_max_size_get_static_delegate;


    private delegate  void efl_ui_box_flow_max_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_box_flow_max_size_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    private static  void box_flow_max_size_set(System.IntPtr obj, System.IntPtr pd,  bool val)
   {
      Eina.Log.Debug("function efl_ui_box_flow_max_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((BoxFlow)wrapper).SetBoxFlowMaxSize( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_box_flow_max_size_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private efl_ui_box_flow_max_size_set_delegate efl_ui_box_flow_max_size_set_static_delegate;
}
} } 
