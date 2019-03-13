#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Page { 
/// <summary>Page transition for <see cref="Efl.Ui.Pager"/>
/// A page transition is essential to <see cref="Efl.Ui.Pager"/> object and invoked whenever pages are rearranged or scrolled (see <see cref="Efl.Ui.Pager"/>).</summary>
[TransitionNativeInherit]
public class Transition : Efl.Object, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Page.TransitionNativeInherit nativeInherit = new Efl.Page.TransitionNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Transition))
            return Efl.Page.TransitionNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_page_transition_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public Transition(Efl.Object parent= null
         ) :
      base(efl_page_transition_class_get(), typeof(Transition), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Transition(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Transition(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Transition static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Transition(obj.NativeHandle);
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
   /// <summary>set object</summary>
   /// <param name="pager">pager object</param>
   /// <param name="group">a dummy object for layer adjustment</param>
   /// <returns></returns>
   virtual public  void Bind( Efl.Ui.Pager pager,  Efl.Canvas.Group group) {
                                           Efl.Page.TransitionNativeInherit.efl_page_transition_bind_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), pager,  group);
      Eina.Error.RaiseIfUnhandledException();
                               }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Page.Transition.efl_page_transition_class_get();
   }
}
public class TransitionNativeInherit : Efl.ObjectNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_page_transition_bind_static_delegate == null)
      efl_page_transition_bind_static_delegate = new efl_page_transition_bind_delegate(bind);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_page_transition_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_page_transition_bind_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Page.Transition.efl_page_transition_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Page.Transition.efl_page_transition_class_get();
   }


    private delegate  void efl_page_transition_bind_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Pager, Efl.Eo.NonOwnTag>))]  Efl.Ui.Pager pager, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Group, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Group group);


    public delegate  void efl_page_transition_bind_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Pager, Efl.Eo.NonOwnTag>))]  Efl.Ui.Pager pager, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Group, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Group group);
    public static Efl.Eo.FunctionWrapper<efl_page_transition_bind_api_delegate> efl_page_transition_bind_ptr = new Efl.Eo.FunctionWrapper<efl_page_transition_bind_api_delegate>(_Module, "efl_page_transition_bind");
    private static  void bind(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Pager pager,  Efl.Canvas.Group group)
   {
      Eina.Log.Debug("function efl_page_transition_bind was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Transition)wrapper).Bind( pager,  group);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_page_transition_bind_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pager,  group);
      }
   }
   private static efl_page_transition_bind_delegate efl_page_transition_bind_static_delegate;
}
} } 
