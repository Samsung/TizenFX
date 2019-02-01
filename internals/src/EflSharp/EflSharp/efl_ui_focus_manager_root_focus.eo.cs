#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { namespace Focus { 
/// <summary>This class ensures that the root is at least focusable, if nothing else is focusable</summary>
[ManagerRootFocusNativeInherit]
public class ManagerRootFocus : Efl.Ui.Focus.ManagerCalc, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.Focus.ManagerRootFocusNativeInherit nativeInherit = new Efl.Ui.Focus.ManagerRootFocusNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ManagerRootFocus))
            return Efl.Ui.Focus.ManagerRootFocusNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(ManagerRootFocus obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_focus_manager_root_focus_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public ManagerRootFocus(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("ManagerRootFocus", efl_ui_focus_manager_root_focus_class_get(), typeof(ManagerRootFocus), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected ManagerRootFocus(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ManagerRootFocus(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static ManagerRootFocus static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ManagerRootFocus(obj.NativeHandle);
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
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Object efl_ui_focus_manager_root_focus_canvas_object_get(System.IntPtr obj);
   /// <summary>The default replacement object for the case that there is no focusable object inside the manager is the root object. However, you can change this by setting this value to something else. <c>null</c> is triggered as the same value as Efl.Ui.Focus.Manager.root.get</summary>
   /// <returns>Canvas object</returns>
   virtual public Efl.Canvas.Object GetCanvasObject() {
       var _ret_var = efl_ui_focus_manager_root_focus_canvas_object_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_manager_root_focus_canvas_object_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object canvas_object);
   /// <summary>The default replacement object for the case that there is no focusable object inside the manager is the root object. However, you can change this by setting this value to something else. <c>null</c> is triggered as the same value as Efl.Ui.Focus.Manager.root.get</summary>
   /// <param name="canvas_object">Canvas object</param>
   /// <returns></returns>
   virtual public  void SetCanvasObject( Efl.Canvas.Object canvas_object) {
                         efl_ui_focus_manager_root_focus_canvas_object_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  canvas_object);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The default replacement object for the case that there is no focusable object inside the manager is the root object. However, you can change this by setting this value to something else. <c>null</c> is triggered as the same value as Efl.Ui.Focus.Manager.root.get</summary>
   public Efl.Canvas.Object CanvasObject {
      get { return GetCanvasObject(); }
      set { SetCanvasObject( value); }
   }
}
public class ManagerRootFocusNativeInherit : Efl.Ui.Focus.ManagerCalcNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_focus_manager_root_focus_canvas_object_get_static_delegate = new efl_ui_focus_manager_root_focus_canvas_object_get_delegate(canvas_object_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_root_focus_canvas_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_root_focus_canvas_object_get_static_delegate)});
      efl_ui_focus_manager_root_focus_canvas_object_set_static_delegate = new efl_ui_focus_manager_root_focus_canvas_object_set_delegate(canvas_object_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_root_focus_canvas_object_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_root_focus_canvas_object_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Focus.ManagerRootFocus.efl_ui_focus_manager_root_focus_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Focus.ManagerRootFocus.efl_ui_focus_manager_root_focus_class_get();
   }


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_ui_focus_manager_root_focus_canvas_object_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Object efl_ui_focus_manager_root_focus_canvas_object_get(System.IntPtr obj);
    private static Efl.Canvas.Object canvas_object_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_root_focus_canvas_object_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((ManagerRootFocus)wrapper).GetCanvasObject();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_manager_root_focus_canvas_object_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_manager_root_focus_canvas_object_get_delegate efl_ui_focus_manager_root_focus_canvas_object_get_static_delegate;


    private delegate  void efl_ui_focus_manager_root_focus_canvas_object_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object canvas_object);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_manager_root_focus_canvas_object_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object canvas_object);
    private static  void canvas_object_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object canvas_object)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_root_focus_canvas_object_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ManagerRootFocus)wrapper).SetCanvasObject( canvas_object);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_manager_root_focus_canvas_object_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  canvas_object);
      }
   }
   private efl_ui_focus_manager_root_focus_canvas_object_set_delegate efl_ui_focus_manager_root_focus_canvas_object_set_static_delegate;
}
} } } 
