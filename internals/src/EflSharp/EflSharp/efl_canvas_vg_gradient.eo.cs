#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { namespace Vg { 
/// <summary>Efl vectopr graphics gradient abstract class</summary>
[GradientNativeInherit]
public class Gradient : Efl.Canvas.Vg.Node, Efl.Eo.IWrapper,Efl.Gfx.Gradient
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.Vg.GradientNativeInherit nativeInherit = new Efl.Canvas.Vg.GradientNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Gradient))
            return Efl.Canvas.Vg.GradientNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Gradient obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_vg_gradient_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Gradient(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Gradient", efl_canvas_vg_gradient_class_get(), typeof(Gradient), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Gradient(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Gradient(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Gradient static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Gradient(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_gradient_stop_get(System.IntPtr obj,   out  System.IntPtr colors,   out  uint length);
   /// <summary>Get the list of color stops.</summary>
   /// <param name="colors">Color stops list</param>
   /// <param name="length">Length of the list</param>
   /// <returns></returns>
   virtual public  void GetStop( out Efl.Gfx.GradientStop colors,  out  uint length) {
                   var _out_colors = new  System.IntPtr();
                        efl_gfx_gradient_stop_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out _out_colors,  out length);
      Eina.Error.RaiseIfUnhandledException();
      colors = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.GradientStop>(_out_colors);
                         }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_gradient_stop_set(System.IntPtr obj,   ref Efl.Gfx.GradientStop_StructInternal colors,    uint length);
   /// <summary>Set the list of color stops for the gradient</summary>
   /// <param name="colors">Color stops list</param>
   /// <param name="length">Length of the list</param>
   /// <returns></returns>
   virtual public  void SetStop( ref Efl.Gfx.GradientStop colors,   uint length) {
       var _in_colors = Efl.Gfx.GradientStop_StructConversion.ToInternal(colors);
                                    efl_gfx_gradient_stop_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  ref _in_colors,  length);
      Eina.Error.RaiseIfUnhandledException();
                  colors = Efl.Gfx.GradientStop_StructConversion.ToManaged(_in_colors);
             }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Gfx.GradientSpread efl_gfx_gradient_spread_get(System.IntPtr obj);
   /// <summary>Returns the spread method use by this gradient. The default is EFL_GFX_GRADIENT_SPREAD_PAD.</summary>
   /// <returns>Spread type to be used</returns>
   virtual public Efl.Gfx.GradientSpread GetSpread() {
       var _ret_var = efl_gfx_gradient_spread_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_gradient_spread_set(System.IntPtr obj,   Efl.Gfx.GradientSpread s);
   /// <summary>Specifies the spread method that should be used for this gradient.</summary>
   /// <param name="s">Spread type to be used</param>
   /// <returns></returns>
   virtual public  void SetSpread( Efl.Gfx.GradientSpread s) {
                         efl_gfx_gradient_spread_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  s);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Returns the spread method use by this gradient. The default is EFL_GFX_GRADIENT_SPREAD_PAD.</summary>
   public Efl.Gfx.GradientSpread Spread {
      get { return GetSpread(); }
      set { SetSpread( value); }
   }
}
public class GradientNativeInherit : Efl.Canvas.Vg.NodeNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_gradient_stop_get_static_delegate = new efl_gfx_gradient_stop_get_delegate(stop_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_stop_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_stop_get_static_delegate)});
      efl_gfx_gradient_stop_set_static_delegate = new efl_gfx_gradient_stop_set_delegate(stop_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_stop_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_stop_set_static_delegate)});
      efl_gfx_gradient_spread_get_static_delegate = new efl_gfx_gradient_spread_get_delegate(spread_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_spread_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_spread_get_static_delegate)});
      efl_gfx_gradient_spread_set_static_delegate = new efl_gfx_gradient_spread_set_delegate(spread_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_spread_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_spread_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.Vg.Gradient.efl_canvas_vg_gradient_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Vg.Gradient.efl_canvas_vg_gradient_class_get();
   }


    private delegate  void efl_gfx_gradient_stop_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr colors,   out  uint length);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_stop_get(System.IntPtr obj,   out  System.IntPtr colors,   out  uint length);
    private static  void stop_get(System.IntPtr obj, System.IntPtr pd,  out  System.IntPtr colors,  out  uint length)
   {
      Eina.Log.Debug("function efl_gfx_gradient_stop_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           Efl.Gfx.GradientStop _out_colors = default(Efl.Gfx.GradientStop);
      length = default( uint);                     
         try {
            ((Gradient)wrapper).GetStop( out _out_colors,  out length);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      colors = Eina.PrimitiveConversion.ManagedToPointerAlloc(_out_colors);
                              } else {
         efl_gfx_gradient_stop_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out colors,  out length);
      }
   }
   private efl_gfx_gradient_stop_get_delegate efl_gfx_gradient_stop_get_static_delegate;


    private delegate  void efl_gfx_gradient_stop_set_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Gfx.GradientStop_StructInternal colors,    uint length);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_stop_set(System.IntPtr obj,   ref Efl.Gfx.GradientStop_StructInternal colors,    uint length);
    private static  void stop_set(System.IntPtr obj, System.IntPtr pd,  ref Efl.Gfx.GradientStop_StructInternal colors,   uint length)
   {
      Eina.Log.Debug("function efl_gfx_gradient_stop_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_colors = Efl.Gfx.GradientStop_StructConversion.ToManaged(colors);
                                       
         try {
            ((Gradient)wrapper).SetStop( ref _in_colors,  length);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  colors = Efl.Gfx.GradientStop_StructConversion.ToInternal(_in_colors);
                  } else {
         efl_gfx_gradient_stop_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref colors,  length);
      }
   }
   private efl_gfx_gradient_stop_set_delegate efl_gfx_gradient_stop_set_static_delegate;


    private delegate Efl.Gfx.GradientSpread efl_gfx_gradient_spread_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Gfx.GradientSpread efl_gfx_gradient_spread_get(System.IntPtr obj);
    private static Efl.Gfx.GradientSpread spread_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_gradient_spread_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.GradientSpread _ret_var = default(Efl.Gfx.GradientSpread);
         try {
            _ret_var = ((Gradient)wrapper).GetSpread();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_gradient_spread_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_gradient_spread_get_delegate efl_gfx_gradient_spread_get_static_delegate;


    private delegate  void efl_gfx_gradient_spread_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.GradientSpread s);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_spread_set(System.IntPtr obj,   Efl.Gfx.GradientSpread s);
    private static  void spread_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.GradientSpread s)
   {
      Eina.Log.Debug("function efl_gfx_gradient_spread_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Gradient)wrapper).SetSpread( s);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_gradient_spread_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  s);
      }
   }
   private efl_gfx_gradient_spread_set_delegate efl_gfx_gradient_spread_set_static_delegate;
}
} } } 
