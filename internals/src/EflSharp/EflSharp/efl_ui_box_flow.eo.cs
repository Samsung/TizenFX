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
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_box_flow_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
   public BoxFlow(Efl.Object parent
         ,  System.String style = null) :
      base(efl_ui_box_flow_class_get(), typeof(BoxFlow), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(style))
         SetStyle(Efl.Eo.Globals.GetParamHelper(style));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public BoxFlow(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected BoxFlow(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
   /// <summary>Box flow homogenous property</summary>
   /// <returns><c>true</c> if the box flow layout is homogenous, <c>false</c> otherwise</returns>
   virtual public bool GetBoxFlowHomogenous() {
       var _ret_var = Efl.Ui.BoxFlowNativeInherit.efl_ui_box_flow_homogenous_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Box flow homogenous property</summary>
   /// <param name="val"><c>true</c> if the box flow layout is homogenous, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetBoxFlowHomogenous( bool val) {
                         Efl.Ui.BoxFlowNativeInherit.efl_ui_box_flow_homogenous_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Box flow maximum size property</summary>
   /// <returns><c>true</c> if the box flow layout has the maximal size, <c>false</c> otherwise</returns>
   virtual public bool GetBoxFlowMaxSize() {
       var _ret_var = Efl.Ui.BoxFlowNativeInherit.efl_ui_box_flow_max_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Box flow maximum size property</summary>
   /// <param name="val"><c>true</c> if the box flow layout has the maximal size, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetBoxFlowMaxSize( bool val) {
                         Efl.Ui.BoxFlowNativeInherit.efl_ui_box_flow_max_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Box flow homogenous property</summary>
/// <value><c>true</c> if the box flow layout is homogenous, <c>false</c> otherwise</value>
   public bool BoxFlowHomogenous {
      get { return GetBoxFlowHomogenous(); }
      set { SetBoxFlowHomogenous( value); }
   }
   /// <summary>Box flow maximum size property</summary>
/// <value><c>true</c> if the box flow layout has the maximal size, <c>false</c> otherwise</value>
   public bool BoxFlowMaxSize {
      get { return GetBoxFlowMaxSize(); }
      set { SetBoxFlowMaxSize( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.BoxFlow.efl_ui_box_flow_class_get();
   }
}
public class BoxFlowNativeInherit : Efl.Ui.BoxNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_box_flow_homogenous_get_static_delegate == null)
      efl_ui_box_flow_homogenous_get_static_delegate = new efl_ui_box_flow_homogenous_get_delegate(box_flow_homogenous_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_box_flow_homogenous_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_box_flow_homogenous_get_static_delegate)});
      if (efl_ui_box_flow_homogenous_set_static_delegate == null)
      efl_ui_box_flow_homogenous_set_static_delegate = new efl_ui_box_flow_homogenous_set_delegate(box_flow_homogenous_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_box_flow_homogenous_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_box_flow_homogenous_set_static_delegate)});
      if (efl_ui_box_flow_max_size_get_static_delegate == null)
      efl_ui_box_flow_max_size_get_static_delegate = new efl_ui_box_flow_max_size_get_delegate(box_flow_max_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_box_flow_max_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_box_flow_max_size_get_static_delegate)});
      if (efl_ui_box_flow_max_size_set_static_delegate == null)
      efl_ui_box_flow_max_size_set_static_delegate = new efl_ui_box_flow_max_size_set_delegate(box_flow_max_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_box_flow_max_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_box_flow_max_size_set_static_delegate)});
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


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_box_flow_homogenous_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_box_flow_homogenous_get_api_delegate> efl_ui_box_flow_homogenous_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_box_flow_homogenous_get_api_delegate>(_Module, "efl_ui_box_flow_homogenous_get");
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
         return efl_ui_box_flow_homogenous_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_box_flow_homogenous_get_delegate efl_ui_box_flow_homogenous_get_static_delegate;


    private delegate  void efl_ui_box_flow_homogenous_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);


    public delegate  void efl_ui_box_flow_homogenous_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    public static Efl.Eo.FunctionWrapper<efl_ui_box_flow_homogenous_set_api_delegate> efl_ui_box_flow_homogenous_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_box_flow_homogenous_set_api_delegate>(_Module, "efl_ui_box_flow_homogenous_set");
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
         efl_ui_box_flow_homogenous_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private static efl_ui_box_flow_homogenous_set_delegate efl_ui_box_flow_homogenous_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_box_flow_max_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_box_flow_max_size_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_box_flow_max_size_get_api_delegate> efl_ui_box_flow_max_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_box_flow_max_size_get_api_delegate>(_Module, "efl_ui_box_flow_max_size_get");
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
         return efl_ui_box_flow_max_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_box_flow_max_size_get_delegate efl_ui_box_flow_max_size_get_static_delegate;


    private delegate  void efl_ui_box_flow_max_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);


    public delegate  void efl_ui_box_flow_max_size_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    public static Efl.Eo.FunctionWrapper<efl_ui_box_flow_max_size_set_api_delegate> efl_ui_box_flow_max_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_box_flow_max_size_set_api_delegate>(_Module, "efl_ui_box_flow_max_size_set");
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
         efl_ui_box_flow_max_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private static efl_ui_box_flow_max_size_set_delegate efl_ui_box_flow_max_size_set_static_delegate;
}
} } 
