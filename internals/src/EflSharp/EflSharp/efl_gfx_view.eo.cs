#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl graphics view interface</summary>
[ViewNativeInherit]
public interface View : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>The dimensions of this object&apos;s viewport.
/// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
/// 
/// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
/// 
/// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
/// 
/// <see cref="Efl.Gfx.View.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
/// 
/// Refer to each implementing class specific documentation for more details.</summary>
/// <returns>Size of the view.</returns>
Eina.Size2D GetViewSize();
   /// <summary>The dimensions of this object&apos;s viewport.
/// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
/// 
/// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
/// 
/// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
/// 
/// <see cref="Efl.Gfx.View.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
/// 
/// Refer to each implementing class specific documentation for more details.</summary>
/// <param name="size">Size of the view.</param>
/// <returns></returns>
 void SetViewSize( Eina.Size2D size);
         /// <summary>The dimensions of this object&apos;s viewport.
/// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
/// 
/// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
/// 
/// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
/// 
/// <see cref="Efl.Gfx.View.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
/// 
/// Refer to each implementing class specific documentation for more details.</summary>
/// <value>Size of the view.</value>
   Eina.Size2D ViewSize {
      get ;
      set ;
   }
}
/// <summary>Efl graphics view interface</summary>
sealed public class ViewConcrete : 

View
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ViewConcrete))
            return Efl.Gfx.ViewNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_gfx_view_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public ViewConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ViewConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static ViewConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ViewConcrete(obj.NativeHandle);
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
    void register_event_proxies()
   {
   }
   /// <summary>The dimensions of this object&apos;s viewport.
   /// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
   /// 
   /// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
   /// 
   /// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
   /// 
   /// <see cref="Efl.Gfx.View.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
   /// 
   /// Refer to each implementing class specific documentation for more details.</summary>
   /// <returns>Size of the view.</returns>
   public Eina.Size2D GetViewSize() {
       var _ret_var = Efl.Gfx.ViewNativeInherit.efl_gfx_view_size_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>The dimensions of this object&apos;s viewport.
   /// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
   /// 
   /// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
   /// 
   /// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
   /// 
   /// <see cref="Efl.Gfx.View.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
   /// 
   /// Refer to each implementing class specific documentation for more details.</summary>
   /// <param name="size">Size of the view.</param>
   /// <returns></returns>
   public  void SetViewSize( Eina.Size2D size) {
       var _in_size = Eina.Size2D_StructConversion.ToInternal(size);
                  Efl.Gfx.ViewNativeInherit.efl_gfx_view_size_set_ptr.Value.Delegate(this.NativeHandle, _in_size);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The dimensions of this object&apos;s viewport.
/// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
/// 
/// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
/// 
/// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
/// 
/// <see cref="Efl.Gfx.View.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
/// 
/// Refer to each implementing class specific documentation for more details.</summary>
/// <value>Size of the view.</value>
   public Eina.Size2D ViewSize {
      get { return GetViewSize(); }
      set { SetViewSize( value); }
   }
}
public class ViewNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_gfx_view_size_get_static_delegate == null)
      efl_gfx_view_size_get_static_delegate = new efl_gfx_view_size_get_delegate(view_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_view_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_view_size_get_static_delegate)});
      if (efl_gfx_view_size_set_static_delegate == null)
      efl_gfx_view_size_set_static_delegate = new efl_gfx_view_size_set_delegate(view_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_view_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_view_size_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.ViewConcrete.efl_gfx_view_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.ViewConcrete.efl_gfx_view_interface_get();
   }


    private delegate Eina.Size2D_StructInternal efl_gfx_view_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Size2D_StructInternal efl_gfx_view_size_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_view_size_get_api_delegate> efl_gfx_view_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_view_size_get_api_delegate>(_Module, "efl_gfx_view_size_get");
    private static Eina.Size2D_StructInternal view_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_view_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((View)wrapper).GetViewSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_view_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_view_size_get_delegate efl_gfx_view_size_get_static_delegate;


    private delegate  void efl_gfx_view_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal size);


    public delegate  void efl_gfx_view_size_set_api_delegate(System.IntPtr obj,   Eina.Size2D_StructInternal size);
    public static Efl.Eo.FunctionWrapper<efl_gfx_view_size_set_api_delegate> efl_gfx_view_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_view_size_set_api_delegate>(_Module, "efl_gfx_view_size_set");
    private static  void view_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal size)
   {
      Eina.Log.Debug("function efl_gfx_view_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_size = Eina.Size2D_StructConversion.ToManaged(size);
                     
         try {
            ((View)wrapper).SetViewSize( _in_size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_view_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
      }
   }
   private static efl_gfx_view_size_set_delegate efl_gfx_view_size_set_static_delegate;
}
} } 
