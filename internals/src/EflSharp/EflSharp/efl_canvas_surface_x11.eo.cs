#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Native X11 surface for Efl canvas</summary>
[SurfaceX11NativeInherit]
public class SurfaceX11 : Efl.Canvas.Surface, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.SurfaceX11NativeInherit nativeInherit = new Efl.Canvas.SurfaceX11NativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (SurfaceX11))
            return Efl.Canvas.SurfaceX11NativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(SurfaceX11 obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_surface_x11_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public SurfaceX11(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("SurfaceX11", efl_canvas_surface_x11_class_get(), typeof(SurfaceX11), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected SurfaceX11(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public SurfaceX11(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static SurfaceX11 static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new SurfaceX11(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_surface_x11_pixmap_get(System.IntPtr obj,   out  System.IntPtr visual,   out  uint pixmap);
   /// <summary>This is a helper for <see cref="Efl.Canvas.Surface.NativeBuffer"/>.</summary>
   /// <param name="visual">X11 Visual for this Pixmap.</param>
   /// <param name="pixmap">X11 Pixmap ID.</param>
   /// <returns></returns>
   virtual public  void GetPixmap( out  System.IntPtr visual,  out  uint pixmap) {
                                           efl_canvas_surface_x11_pixmap_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out visual,  out pixmap);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_surface_x11_pixmap_set(System.IntPtr obj,    System.IntPtr visual,    uint pixmap);
   /// <summary>This is a helper for <see cref="Efl.Canvas.Surface.NativeBuffer"/>.</summary>
   /// <param name="visual">X11 Visual for this Pixmap.</param>
   /// <param name="pixmap">X11 Pixmap ID.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool SetPixmap(  System.IntPtr visual,   uint pixmap) {
                                           var _ret_var = efl_canvas_surface_x11_pixmap_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  visual,  pixmap);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
}
public class SurfaceX11NativeInherit : Efl.Canvas.SurfaceNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_canvas_surface_x11_pixmap_get_static_delegate = new efl_canvas_surface_x11_pixmap_get_delegate(pixmap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_surface_x11_pixmap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_surface_x11_pixmap_get_static_delegate)});
      efl_canvas_surface_x11_pixmap_set_static_delegate = new efl_canvas_surface_x11_pixmap_set_delegate(pixmap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_surface_x11_pixmap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_surface_x11_pixmap_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.SurfaceX11.efl_canvas_surface_x11_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.SurfaceX11.efl_canvas_surface_x11_class_get();
   }


    private delegate  void efl_canvas_surface_x11_pixmap_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr visual,   out  uint pixmap);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_surface_x11_pixmap_get(System.IntPtr obj,   out  System.IntPtr visual,   out  uint pixmap);
    private static  void pixmap_get(System.IntPtr obj, System.IntPtr pd,  out  System.IntPtr visual,  out  uint pixmap)
   {
      Eina.Log.Debug("function efl_canvas_surface_x11_pixmap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           visual = default( System.IntPtr);      pixmap = default( uint);                     
         try {
            ((SurfaceX11)wrapper).GetPixmap( out visual,  out pixmap);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_canvas_surface_x11_pixmap_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out visual,  out pixmap);
      }
   }
   private efl_canvas_surface_x11_pixmap_get_delegate efl_canvas_surface_x11_pixmap_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_surface_x11_pixmap_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr visual,    uint pixmap);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_surface_x11_pixmap_set(System.IntPtr obj,    System.IntPtr visual,    uint pixmap);
    private static bool pixmap_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr visual,   uint pixmap)
   {
      Eina.Log.Debug("function efl_canvas_surface_x11_pixmap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((SurfaceX11)wrapper).SetPixmap( visual,  pixmap);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_canvas_surface_x11_pixmap_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  visual,  pixmap);
      }
   }
   private efl_canvas_surface_x11_pixmap_set_delegate efl_canvas_surface_x11_pixmap_set_static_delegate;
}
} } 
namespace Efl { namespace Canvas { 
/// <summary>The type used by <see cref="Efl.Canvas.Surface.NativeBuffer"/>.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct SurfaceX11Pixmap
{
   /// <summary>X11 Visual for this Pixmap.</summary>
   public  System.IntPtr Visual;
   /// <summary>X11 Pixmap ID.</summary>
   public  uint Pixmap;
   ///<summary>Constructor for SurfaceX11Pixmap.</summary>
   public SurfaceX11Pixmap(
       System.IntPtr Visual=default( System.IntPtr),
       uint Pixmap=default( uint)   )
   {
      this.Visual = Visual;
      this.Pixmap = Pixmap;
   }
public static implicit operator SurfaceX11Pixmap(IntPtr ptr)
   {
      var tmp = (SurfaceX11Pixmap_StructInternal)Marshal.PtrToStructure(ptr, typeof(SurfaceX11Pixmap_StructInternal));
      return SurfaceX11Pixmap_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct SurfaceX11Pixmap.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct SurfaceX11Pixmap_StructInternal
{
   
   public  System.IntPtr Visual;
   
   public  uint Pixmap;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator SurfaceX11Pixmap(SurfaceX11Pixmap_StructInternal struct_)
   {
      return SurfaceX11Pixmap_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator SurfaceX11Pixmap_StructInternal(SurfaceX11Pixmap struct_)
   {
      return SurfaceX11Pixmap_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct SurfaceX11Pixmap</summary>
public static class SurfaceX11Pixmap_StructConversion
{
   internal static SurfaceX11Pixmap_StructInternal ToInternal(SurfaceX11Pixmap _external_struct)
   {
      var _internal_struct = new SurfaceX11Pixmap_StructInternal();

      _internal_struct.Visual = _external_struct.Visual;
      _internal_struct.Pixmap = _external_struct.Pixmap;

      return _internal_struct;
   }

   internal static SurfaceX11Pixmap ToManaged(SurfaceX11Pixmap_StructInternal _internal_struct)
   {
      var _external_struct = new SurfaceX11Pixmap();

      _external_struct.Visual = _internal_struct.Visual;
      _external_struct.Pixmap = _internal_struct.Pixmap;

      return _external_struct;
   }

}
} } 
