#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI image factory class</summary>
[ImageFactoryNativeInherit]
public class ImageFactory : Efl.Ui.CachingFactory, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.ImageFactoryNativeInherit nativeInherit = new Efl.Ui.ImageFactoryNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ImageFactory))
            return Efl.Ui.ImageFactoryNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_image_factory_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="itemClass">Define the class of the item returned by this factory. See <see cref="Efl.Ui.WidgetFactory.SetItemClass"/></param>
   public ImageFactory(Efl.Object parent
         , Type itemClass = null) :
      base(efl_ui_image_factory_class_get(), typeof(ImageFactory), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(itemClass))
         SetItemClass(Efl.Eo.Globals.GetParamHelper(itemClass));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public ImageFactory(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected ImageFactory(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static ImageFactory static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ImageFactory(obj.NativeHandle);
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
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.ImageFactory.efl_ui_image_factory_class_get();
   }
}
public class ImageFactoryNativeInherit : Efl.Ui.CachingFactoryNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.ImageFactory.efl_ui_image_factory_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.ImageFactory.efl_ui_image_factory_class_get();
   }
}
} } 
