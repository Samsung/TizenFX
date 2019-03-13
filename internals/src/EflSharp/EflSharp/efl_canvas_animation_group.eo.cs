#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Efl group animation abstract class</summary>
[AnimationGroupNativeInherit]
public class AnimationGroup : Efl.Canvas.Animation, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.AnimationGroupNativeInherit nativeInherit = new Efl.Canvas.AnimationGroupNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (AnimationGroup))
            return Efl.Canvas.AnimationGroupNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_animation_group_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public AnimationGroup(Efl.Object parent= null
         ) :
      base(efl_canvas_animation_group_class_get(), typeof(AnimationGroup), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public AnimationGroup(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected AnimationGroup(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static AnimationGroup static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new AnimationGroup(obj.NativeHandle);
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
   /// <summary>Add the given animation to the animation group.</summary>
   /// <param name="animation">The animation which needs to be added to the animation group</param>
   /// <returns></returns>
   virtual public  void AddAnimation( Efl.Canvas.Animation animation) {
                         Efl.Canvas.AnimationGroupNativeInherit.efl_animation_group_animation_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), animation);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Delete the given animation from the animation group.</summary>
   /// <param name="animation">The animation which needs to be deleted from the animation group</param>
   /// <returns></returns>
   virtual public  void DelAnimation( Efl.Canvas.Animation animation) {
                         Efl.Canvas.AnimationGroupNativeInherit.efl_animation_group_animation_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), animation);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the animations of the animation group.</summary>
   /// <returns>The animations of the animation group</returns>
   virtual public Eina.List<Efl.Canvas.Animation> GetAnimations() {
       var _ret_var = Efl.Canvas.AnimationGroupNativeInherit.efl_animation_group_animations_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Canvas.Animation>(_ret_var, false, false);
 }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.AnimationGroup.efl_canvas_animation_group_class_get();
   }
}
public class AnimationGroupNativeInherit : Efl.Canvas.AnimationNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_animation_group_animation_add_static_delegate == null)
      efl_animation_group_animation_add_static_delegate = new efl_animation_group_animation_add_delegate(animation_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_animation_group_animation_add"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_group_animation_add_static_delegate)});
      if (efl_animation_group_animation_del_static_delegate == null)
      efl_animation_group_animation_del_static_delegate = new efl_animation_group_animation_del_delegate(animation_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_animation_group_animation_del"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_group_animation_del_static_delegate)});
      if (efl_animation_group_animations_get_static_delegate == null)
      efl_animation_group_animations_get_static_delegate = new efl_animation_group_animations_get_delegate(animations_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_animation_group_animations_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_group_animations_get_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.AnimationGroup.efl_canvas_animation_group_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.AnimationGroup.efl_canvas_animation_group_class_get();
   }


    private delegate  void efl_animation_group_animation_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Animation animation);


    public delegate  void efl_animation_group_animation_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Animation animation);
    public static Efl.Eo.FunctionWrapper<efl_animation_group_animation_add_api_delegate> efl_animation_group_animation_add_ptr = new Efl.Eo.FunctionWrapper<efl_animation_group_animation_add_api_delegate>(_Module, "efl_animation_group_animation_add");
    private static  void animation_add(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Animation animation)
   {
      Eina.Log.Debug("function efl_animation_group_animation_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((AnimationGroup)wrapper).AddAnimation( animation);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_animation_group_animation_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  animation);
      }
   }
   private static efl_animation_group_animation_add_delegate efl_animation_group_animation_add_static_delegate;


    private delegate  void efl_animation_group_animation_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Animation animation);


    public delegate  void efl_animation_group_animation_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Animation animation);
    public static Efl.Eo.FunctionWrapper<efl_animation_group_animation_del_api_delegate> efl_animation_group_animation_del_ptr = new Efl.Eo.FunctionWrapper<efl_animation_group_animation_del_api_delegate>(_Module, "efl_animation_group_animation_del");
    private static  void animation_del(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Animation animation)
   {
      Eina.Log.Debug("function efl_animation_group_animation_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((AnimationGroup)wrapper).DelAnimation( animation);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_animation_group_animation_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  animation);
      }
   }
   private static efl_animation_group_animation_del_delegate efl_animation_group_animation_del_static_delegate;


    private delegate  System.IntPtr efl_animation_group_animations_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_animation_group_animations_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_animation_group_animations_get_api_delegate> efl_animation_group_animations_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_group_animations_get_api_delegate>(_Module, "efl_animation_group_animations_get");
    private static  System.IntPtr animations_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_animation_group_animations_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Canvas.Animation> _ret_var = default(Eina.List<Efl.Canvas.Animation>);
         try {
            _ret_var = ((AnimationGroup)wrapper).GetAnimations();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_animation_group_animations_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_animation_group_animations_get_delegate efl_animation_group_animations_get_static_delegate;
}
} } 
