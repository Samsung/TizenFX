#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl graphics view interface</summary>
[ViewConcreteNativeInherit]
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
            return Efl.Gfx.ViewConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_gfx_view_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
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
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Size2D_StructInternal efl_gfx_view_size_get(System.IntPtr obj);
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
       var _ret_var = efl_gfx_view_size_get(Efl.Gfx.ViewConcrete.efl_gfx_view_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_view_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal size);
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
                  efl_gfx_view_size_set(Efl.Gfx.ViewConcrete.efl_gfx_view_interface_get(),  _in_size);
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
   public Eina.Size2D ViewSize {
      get { return GetViewSize(); }
      set { SetViewSize( value); }
   }
}
public class ViewConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_view_size_get_static_delegate = new efl_gfx_view_size_get_delegate(view_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_view_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_view_size_get_static_delegate)});
      efl_gfx_view_size_set_static_delegate = new efl_gfx_view_size_set_delegate(view_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_view_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_view_size_set_static_delegate)});
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_view_size_get(System.IntPtr obj);
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
         return efl_gfx_view_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_view_size_get_delegate efl_gfx_view_size_get_static_delegate;


    private delegate  void efl_gfx_view_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal size);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_view_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal size);
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
         efl_gfx_view_size_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
      }
   }
   private efl_gfx_view_size_set_delegate efl_gfx_view_size_set_static_delegate;
}
} } 
