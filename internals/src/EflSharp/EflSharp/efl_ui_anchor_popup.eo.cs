#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>EFL UI Anchor Popup class</summary>
[AnchorPopupNativeInherit]
public class AnchorPopup : Efl.Ui.Popup, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.AnchorPopupNativeInherit nativeInherit = new Efl.Ui.AnchorPopupNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (AnchorPopup))
            return Efl.Ui.AnchorPopupNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_anchor_popup_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
   public AnchorPopup(Efl.Object parent
         ,  System.String style = null) :
      base(efl_ui_anchor_popup_class_get(), typeof(AnchorPopup), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(style))
         SetStyle(Efl.Eo.Globals.GetParamHelper(style));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public AnchorPopup(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected AnchorPopup(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static AnchorPopup static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new AnchorPopup(obj.NativeHandle);
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
   /// <summary>Returns the anchor object which the popup is following.</summary>
   /// <returns>The object which popup is following.</returns>
   virtual public Efl.Canvas.Object GetAnchor() {
       var _ret_var = Efl.Ui.AnchorPopupNativeInherit.efl_ui_anchor_popup_anchor_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set anchor popup to follow an anchor object. If anchor object is moved or parent window is resized, the anchor popup moves to the new position. If anchor object is set to NULL, the anchor popup stops following the anchor object. When the popup is moved by using gfx_position_set, anchor is set NULL.</summary>
   /// <param name="anchor">The object which popup is following.</param>
   /// <returns></returns>
   virtual public  void SetAnchor( Efl.Canvas.Object anchor) {
                         Efl.Ui.AnchorPopupNativeInherit.efl_ui_anchor_popup_anchor_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), anchor);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the align priority of a popup.</summary>
   /// <param name="first">First align priority</param>
   /// <param name="second">Second align priority</param>
   /// <param name="third">Third align priority</param>
   /// <param name="fourth">Fourth align priority</param>
   /// <param name="fifth">Fifth align priority</param>
   /// <returns></returns>
   virtual public  void GetAlignPriority( out Efl.Ui.PopupAlign first,  out Efl.Ui.PopupAlign second,  out Efl.Ui.PopupAlign third,  out Efl.Ui.PopupAlign fourth,  out Efl.Ui.PopupAlign fifth) {
                                                                                                 Efl.Ui.AnchorPopupNativeInherit.efl_ui_anchor_popup_align_priority_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out first,  out second,  out third,  out fourth,  out fifth);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }
   /// <summary>Set the align priority of a popup.</summary>
   /// <param name="first">First align priority</param>
   /// <param name="second">Second align priority</param>
   /// <param name="third">Third align priority</param>
   /// <param name="fourth">Fourth align priority</param>
   /// <param name="fifth">Fifth align priority</param>
   /// <returns></returns>
   virtual public  void SetAlignPriority( Efl.Ui.PopupAlign first,  Efl.Ui.PopupAlign second,  Efl.Ui.PopupAlign third,  Efl.Ui.PopupAlign fourth,  Efl.Ui.PopupAlign fifth) {
                                                                                                 Efl.Ui.AnchorPopupNativeInherit.efl_ui_anchor_popup_align_priority_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), first,  second,  third,  fourth,  fifth);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }
   /// <summary>Returns the anchor object which the popup is following.</summary>
/// <value>The object which popup is following.</value>
   public Efl.Canvas.Object Anchor {
      get { return GetAnchor(); }
      set { SetAnchor( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.AnchorPopup.efl_ui_anchor_popup_class_get();
   }
}
public class AnchorPopupNativeInherit : Efl.Ui.PopupNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_anchor_popup_anchor_get_static_delegate == null)
      efl_ui_anchor_popup_anchor_get_static_delegate = new efl_ui_anchor_popup_anchor_get_delegate(anchor_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_anchor_popup_anchor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_anchor_popup_anchor_get_static_delegate)});
      if (efl_ui_anchor_popup_anchor_set_static_delegate == null)
      efl_ui_anchor_popup_anchor_set_static_delegate = new efl_ui_anchor_popup_anchor_set_delegate(anchor_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_anchor_popup_anchor_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_anchor_popup_anchor_set_static_delegate)});
      if (efl_ui_anchor_popup_align_priority_get_static_delegate == null)
      efl_ui_anchor_popup_align_priority_get_static_delegate = new efl_ui_anchor_popup_align_priority_get_delegate(align_priority_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_anchor_popup_align_priority_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_anchor_popup_align_priority_get_static_delegate)});
      if (efl_ui_anchor_popup_align_priority_set_static_delegate == null)
      efl_ui_anchor_popup_align_priority_set_static_delegate = new efl_ui_anchor_popup_align_priority_set_delegate(align_priority_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_anchor_popup_align_priority_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_anchor_popup_align_priority_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.AnchorPopup.efl_ui_anchor_popup_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.AnchorPopup.efl_ui_anchor_popup_class_get();
   }


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_ui_anchor_popup_anchor_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Object efl_ui_anchor_popup_anchor_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_anchor_get_api_delegate> efl_ui_anchor_popup_anchor_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_anchor_get_api_delegate>(_Module, "efl_ui_anchor_popup_anchor_get");
    private static Efl.Canvas.Object anchor_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_anchor_popup_anchor_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((AnchorPopup)wrapper).GetAnchor();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_anchor_popup_anchor_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_anchor_popup_anchor_get_delegate efl_ui_anchor_popup_anchor_get_static_delegate;


    private delegate  void efl_ui_anchor_popup_anchor_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object anchor);


    public delegate  void efl_ui_anchor_popup_anchor_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object anchor);
    public static Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_anchor_set_api_delegate> efl_ui_anchor_popup_anchor_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_anchor_set_api_delegate>(_Module, "efl_ui_anchor_popup_anchor_set");
    private static  void anchor_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object anchor)
   {
      Eina.Log.Debug("function efl_ui_anchor_popup_anchor_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((AnchorPopup)wrapper).SetAnchor( anchor);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_anchor_popup_anchor_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  anchor);
      }
   }
   private static efl_ui_anchor_popup_anchor_set_delegate efl_ui_anchor_popup_anchor_set_static_delegate;


    private delegate  void efl_ui_anchor_popup_align_priority_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.Ui.PopupAlign first,   out Efl.Ui.PopupAlign second,   out Efl.Ui.PopupAlign third,   out Efl.Ui.PopupAlign fourth,   out Efl.Ui.PopupAlign fifth);


    public delegate  void efl_ui_anchor_popup_align_priority_get_api_delegate(System.IntPtr obj,   out Efl.Ui.PopupAlign first,   out Efl.Ui.PopupAlign second,   out Efl.Ui.PopupAlign third,   out Efl.Ui.PopupAlign fourth,   out Efl.Ui.PopupAlign fifth);
    public static Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_align_priority_get_api_delegate> efl_ui_anchor_popup_align_priority_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_align_priority_get_api_delegate>(_Module, "efl_ui_anchor_popup_align_priority_get");
    private static  void align_priority_get(System.IntPtr obj, System.IntPtr pd,  out Efl.Ui.PopupAlign first,  out Efl.Ui.PopupAlign second,  out Efl.Ui.PopupAlign third,  out Efl.Ui.PopupAlign fourth,  out Efl.Ui.PopupAlign fifth)
   {
      Eina.Log.Debug("function efl_ui_anchor_popup_align_priority_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                             first = default(Efl.Ui.PopupAlign);      second = default(Efl.Ui.PopupAlign);      third = default(Efl.Ui.PopupAlign);      fourth = default(Efl.Ui.PopupAlign);      fifth = default(Efl.Ui.PopupAlign);                                       
         try {
            ((AnchorPopup)wrapper).GetAlignPriority( out first,  out second,  out third,  out fourth,  out fifth);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_ui_anchor_popup_align_priority_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out first,  out second,  out third,  out fourth,  out fifth);
      }
   }
   private static efl_ui_anchor_popup_align_priority_get_delegate efl_ui_anchor_popup_align_priority_get_static_delegate;


    private delegate  void efl_ui_anchor_popup_align_priority_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.PopupAlign first,   Efl.Ui.PopupAlign second,   Efl.Ui.PopupAlign third,   Efl.Ui.PopupAlign fourth,   Efl.Ui.PopupAlign fifth);


    public delegate  void efl_ui_anchor_popup_align_priority_set_api_delegate(System.IntPtr obj,   Efl.Ui.PopupAlign first,   Efl.Ui.PopupAlign second,   Efl.Ui.PopupAlign third,   Efl.Ui.PopupAlign fourth,   Efl.Ui.PopupAlign fifth);
    public static Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_align_priority_set_api_delegate> efl_ui_anchor_popup_align_priority_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_align_priority_set_api_delegate>(_Module, "efl_ui_anchor_popup_align_priority_set");
    private static  void align_priority_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.PopupAlign first,  Efl.Ui.PopupAlign second,  Efl.Ui.PopupAlign third,  Efl.Ui.PopupAlign fourth,  Efl.Ui.PopupAlign fifth)
   {
      Eina.Log.Debug("function efl_ui_anchor_popup_align_priority_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((AnchorPopup)wrapper).SetAlignPriority( first,  second,  third,  fourth,  fifth);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_ui_anchor_popup_align_priority_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  first,  second,  third,  fourth,  fifth);
      }
   }
   private static efl_ui_anchor_popup_align_priority_set_delegate efl_ui_anchor_popup_align_priority_set_static_delegate;
}
} } 
