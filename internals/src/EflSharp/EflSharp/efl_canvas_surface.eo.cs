#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Native surfaces usually bound to an externally-managed buffer.
/// The attached <see cref="Efl.Canvas.Surface.NativeBuffer"/> is entirely platform-dependent, which means some of this mixin&apos;s subclasses will not work (constructor returns <c>null</c>) on some platforms. This class is meant to be used from native code only (C or C++), with direct access to the display system or a buffer allocation system.</summary>
[SurfaceNativeInherit]
public class Surface : Efl.Canvas.ImageInternal, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.SurfaceNativeInherit nativeInherit = new Efl.Canvas.SurfaceNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Surface))
            return Efl.Canvas.SurfaceNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Surface obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_surface_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Surface(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Surface", efl_canvas_surface_class_get(), typeof(Surface), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Surface(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Surface(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Surface static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Surface(obj.NativeHandle);
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
    protected static extern  System.IntPtr efl_canvas_surface_native_buffer_get(System.IntPtr obj);
   /// <summary>External buffer attached to this native surface.
   /// Set to <c>null</c> to detach this surface from the external buffer.</summary>
   /// <returns>The external buffer, depends on its type.</returns>
   virtual public  System.IntPtr GetNativeBuffer() {
       var _ret_var = efl_canvas_surface_native_buffer_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_surface_native_buffer_set(System.IntPtr obj,    System.IntPtr buffer);
   /// <summary>Set the buffer. If this fails, this function returns <c>false</c>, and the surface is left without any attached buffer.</summary>
   /// <param name="buffer">The external buffer, depends on its type.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool SetNativeBuffer(  System.IntPtr buffer) {
                         var _ret_var = efl_canvas_surface_native_buffer_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  buffer);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>External buffer attached to this native surface.
/// Set to <c>null</c> to detach this surface from the external buffer.</summary>
   public  System.IntPtr NativeBuffer {
      get { return GetNativeBuffer(); }
      set { SetNativeBuffer( value); }
   }
}
public class SurfaceNativeInherit : Efl.Canvas.ImageInternalNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_canvas_surface_native_buffer_get_static_delegate = new efl_canvas_surface_native_buffer_get_delegate(native_buffer_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_surface_native_buffer_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_surface_native_buffer_get_static_delegate)});
      efl_canvas_surface_native_buffer_set_static_delegate = new efl_canvas_surface_native_buffer_set_delegate(native_buffer_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_surface_native_buffer_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_surface_native_buffer_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.Surface.efl_canvas_surface_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Surface.efl_canvas_surface_class_get();
   }


    private delegate  System.IntPtr efl_canvas_surface_native_buffer_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  System.IntPtr efl_canvas_surface_native_buffer_get(System.IntPtr obj);
    private static  System.IntPtr native_buffer_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_surface_native_buffer_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.IntPtr _ret_var = default( System.IntPtr);
         try {
            _ret_var = ((Surface)wrapper).GetNativeBuffer();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_surface_native_buffer_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_surface_native_buffer_get_delegate efl_canvas_surface_native_buffer_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_surface_native_buffer_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr buffer);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_surface_native_buffer_set(System.IntPtr obj,    System.IntPtr buffer);
    private static bool native_buffer_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr buffer)
   {
      Eina.Log.Debug("function efl_canvas_surface_native_buffer_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Surface)wrapper).SetNativeBuffer( buffer);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_surface_native_buffer_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  buffer);
      }
   }
   private efl_canvas_surface_native_buffer_set_delegate efl_canvas_surface_native_buffer_set_static_delegate;
}
} } 
