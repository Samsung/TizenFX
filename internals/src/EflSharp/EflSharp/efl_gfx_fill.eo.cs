#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl graphics fill interface</summary>
[FillConcreteNativeInherit]
public interface Fill : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.Fill.Fill"/> property to its actual geometry.
/// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.Fill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
/// 
/// This property takes precedence over <see cref="Efl.Gfx.Fill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.Fill.Fill"/> should be set.
/// 
/// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
/// <returns><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</returns>
bool GetFillAuto();
   /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.Fill.Fill"/> property to its actual geometry.
/// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.Fill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
/// 
/// This property takes precedence over <see cref="Efl.Gfx.Fill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.Fill.Fill"/> should be set.
/// 
/// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
/// <param name="filled"><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</param>
/// <returns></returns>
 void SetFillAuto( bool filled);
   /// <summary>Specifies how to tile an image to fill its rectangle geometry.
/// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
/// 
/// Setting this property will reset the <see cref="Efl.Gfx.Fill.FillAuto"/> to <c>false</c>.</summary>
/// <returns>The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</returns>
Eina.Rect GetFill();
   /// <summary>Specifies how to tile an image to fill its rectangle geometry.
/// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
/// 
/// Setting this property will reset the <see cref="Efl.Gfx.Fill.FillAuto"/> to <c>false</c>.</summary>
/// <param name="fill">The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</param>
/// <returns></returns>
 void SetFill( Eina.Rect fill);
               /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.Fill.Fill"/> property to its actual geometry.
/// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.Fill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
/// 
/// This property takes precedence over <see cref="Efl.Gfx.Fill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.Fill.Fill"/> should be set.
/// 
/// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
   bool FillAuto {
      get ;
      set ;
   }
   /// <summary>Specifies how to tile an image to fill its rectangle geometry.
/// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
/// 
/// Setting this property will reset the <see cref="Efl.Gfx.Fill.FillAuto"/> to <c>false</c>.</summary>
   Eina.Rect Fill {
      get ;
      set ;
   }
}
/// <summary>Efl graphics fill interface</summary>
sealed public class FillConcrete : 

Fill
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (FillConcrete))
            return Efl.Gfx.FillConcreteNativeInherit.GetEflClassStatic();
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
      efl_gfx_fill_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public FillConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~FillConcrete()
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
   public static FillConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new FillConcrete(obj.NativeHandle);
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
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_fill_auto_get(System.IntPtr obj);
   /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.Fill.Fill"/> property to its actual geometry.
   /// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.Fill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
   /// 
   /// This property takes precedence over <see cref="Efl.Gfx.Fill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.Fill.Fill"/> should be set.
   /// 
   /// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
   /// <returns><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</returns>
   public bool GetFillAuto() {
       var _ret_var = efl_gfx_fill_auto_get(Efl.Gfx.FillConcrete.efl_gfx_fill_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_fill_auto_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool filled);
   /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.Fill.Fill"/> property to its actual geometry.
   /// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.Fill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
   /// 
   /// This property takes precedence over <see cref="Efl.Gfx.Fill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.Fill.Fill"/> should be set.
   /// 
   /// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
   /// <param name="filled"><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</param>
   /// <returns></returns>
   public  void SetFillAuto( bool filled) {
                         efl_gfx_fill_auto_set(Efl.Gfx.FillConcrete.efl_gfx_fill_interface_get(),  filled);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Rect_StructInternal efl_gfx_fill_get(System.IntPtr obj);
   /// <summary>Specifies how to tile an image to fill its rectangle geometry.
   /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
   /// 
   /// Setting this property will reset the <see cref="Efl.Gfx.Fill.FillAuto"/> to <c>false</c>.</summary>
   /// <returns>The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</returns>
   public Eina.Rect GetFill() {
       var _ret_var = efl_gfx_fill_get(Efl.Gfx.FillConcrete.efl_gfx_fill_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_fill_set(System.IntPtr obj,   Eina.Rect_StructInternal fill);
   /// <summary>Specifies how to tile an image to fill its rectangle geometry.
   /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
   /// 
   /// Setting this property will reset the <see cref="Efl.Gfx.Fill.FillAuto"/> to <c>false</c>.</summary>
   /// <param name="fill">The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</param>
   /// <returns></returns>
   public  void SetFill( Eina.Rect fill) {
       var _in_fill = Eina.Rect_StructConversion.ToInternal(fill);
                  efl_gfx_fill_set(Efl.Gfx.FillConcrete.efl_gfx_fill_interface_get(),  _in_fill);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.Fill.Fill"/> property to its actual geometry.
/// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.Fill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
/// 
/// This property takes precedence over <see cref="Efl.Gfx.Fill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.Fill.Fill"/> should be set.
/// 
/// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
   public bool FillAuto {
      get { return GetFillAuto(); }
      set { SetFillAuto( value); }
   }
   /// <summary>Specifies how to tile an image to fill its rectangle geometry.
/// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
/// 
/// Setting this property will reset the <see cref="Efl.Gfx.Fill.FillAuto"/> to <c>false</c>.</summary>
   public Eina.Rect Fill {
      get { return GetFill(); }
      set { SetFill( value); }
   }
}
public class FillConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_fill_auto_get_static_delegate = new efl_gfx_fill_auto_get_delegate(fill_auto_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_fill_auto_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_auto_get_static_delegate)});
      efl_gfx_fill_auto_set_static_delegate = new efl_gfx_fill_auto_set_delegate(fill_auto_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_fill_auto_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_auto_set_static_delegate)});
      efl_gfx_fill_get_static_delegate = new efl_gfx_fill_get_delegate(fill_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_get_static_delegate)});
      efl_gfx_fill_set_static_delegate = new efl_gfx_fill_set_delegate(fill_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.FillConcrete.efl_gfx_fill_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.FillConcrete.efl_gfx_fill_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_fill_auto_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_fill_auto_get(System.IntPtr obj);
    private static bool fill_auto_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_fill_auto_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Fill)wrapper).GetFillAuto();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_fill_auto_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_fill_auto_get_delegate efl_gfx_fill_auto_get_static_delegate;


    private delegate  void efl_gfx_fill_auto_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool filled);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_fill_auto_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool filled);
    private static  void fill_auto_set(System.IntPtr obj, System.IntPtr pd,  bool filled)
   {
      Eina.Log.Debug("function efl_gfx_fill_auto_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Fill)wrapper).SetFillAuto( filled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_fill_auto_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  filled);
      }
   }
   private efl_gfx_fill_auto_set_delegate efl_gfx_fill_auto_set_static_delegate;


    private delegate Eina.Rect_StructInternal efl_gfx_fill_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Rect_StructInternal efl_gfx_fill_get(System.IntPtr obj);
    private static Eina.Rect_StructInternal fill_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_fill_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((Fill)wrapper).GetFill();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_fill_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_fill_get_delegate efl_gfx_fill_get_static_delegate;


    private delegate  void efl_gfx_fill_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect_StructInternal fill);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_fill_set(System.IntPtr obj,   Eina.Rect_StructInternal fill);
    private static  void fill_set(System.IntPtr obj, System.IntPtr pd,  Eina.Rect_StructInternal fill)
   {
      Eina.Log.Debug("function efl_gfx_fill_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_fill = Eina.Rect_StructConversion.ToManaged(fill);
                     
         try {
            ((Fill)wrapper).SetFill( _in_fill);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_fill_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fill);
      }
   }
   private efl_gfx_fill_set_delegate efl_gfx_fill_set_static_delegate;
}
} } 
