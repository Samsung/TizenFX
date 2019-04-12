#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { namespace Vg { 
/// <summary>Efl vector graphics container class</summary>
[ContainerNativeInherit]
public class Container : Efl.Canvas.Vg.Node, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.Vg.ContainerNativeInherit nativeInherit = new Efl.Canvas.Vg.ContainerNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Container))
            return Efl.Canvas.Vg.ContainerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_vg_container_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public Container(Efl.Object parent= null
         ) :
      base(efl_canvas_vg_container_class_get(), typeof(Container), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Container(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Container(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Container static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Container(obj.NativeHandle);
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
   /// <summary>Get child of container</summary>
   /// <param name="name">Child node name</param>
   /// <returns>Child object</returns>
   virtual public Efl.Canvas.Vg.Node GetChild(  System.String name) {
                         var _ret_var = Efl.Canvas.Vg.ContainerNativeInherit.efl_canvas_vg_container_child_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Get all children of container</summary>
   /// <returns>Iterator to children</returns>
   virtual public Eina.Iterator<Efl.Canvas.Vg.Node> GetChildren() {
       var _ret_var = Efl.Canvas.Vg.ContainerNativeInherit.efl_canvas_vg_container_children_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Canvas.Vg.Node>(_ret_var, true, false);
 }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Vg.Container.efl_canvas_vg_container_class_get();
   }
}
public class ContainerNativeInherit : Efl.Canvas.Vg.NodeNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_canvas_vg_container_child_get_static_delegate == null)
      efl_canvas_vg_container_child_get_static_delegate = new efl_canvas_vg_container_child_get_delegate(child_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_vg_container_child_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_container_child_get_static_delegate)});
      if (efl_canvas_vg_container_children_get_static_delegate == null)
      efl_canvas_vg_container_children_get_static_delegate = new efl_canvas_vg_container_children_get_delegate(children_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_vg_container_children_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_container_children_get_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.Vg.Container.efl_canvas_vg_container_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Vg.Container.efl_canvas_vg_container_class_get();
   }


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Vg.Node efl_canvas_vg_container_child_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Vg.Node efl_canvas_vg_container_child_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    public static Efl.Eo.FunctionWrapper<efl_canvas_vg_container_child_get_api_delegate> efl_canvas_vg_container_child_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_container_child_get_api_delegate>(_Module, "efl_canvas_vg_container_child_get");
    private static Efl.Canvas.Vg.Node child_get(System.IntPtr obj, System.IntPtr pd,   System.String name)
   {
      Eina.Log.Debug("function efl_canvas_vg_container_child_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Canvas.Vg.Node _ret_var = default(Efl.Canvas.Vg.Node);
         try {
            _ret_var = ((Container)wrapper).GetChild( name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_vg_container_child_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
      }
   }
   private static efl_canvas_vg_container_child_get_delegate efl_canvas_vg_container_child_get_static_delegate;


    private delegate  System.IntPtr efl_canvas_vg_container_children_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_canvas_vg_container_children_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_vg_container_children_get_api_delegate> efl_canvas_vg_container_children_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_container_children_get_api_delegate>(_Module, "efl_canvas_vg_container_children_get");
    private static  System.IntPtr children_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_vg_container_children_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.Canvas.Vg.Node> _ret_var = default(Eina.Iterator<Efl.Canvas.Vg.Node>);
         try {
            _ret_var = ((Container)wrapper).GetChildren();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_canvas_vg_container_children_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_vg_container_children_get_delegate efl_canvas_vg_container_children_get_static_delegate;
}
} } } 
