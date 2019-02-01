#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Low-level polygon object</summary>
[PolygonNativeInherit]
public class Polygon : Efl.Canvas.Object, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.PolygonNativeInherit nativeInherit = new Efl.Canvas.PolygonNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Polygon))
            return Efl.Canvas.PolygonNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Polygon obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_polygon_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Polygon(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Polygon", efl_canvas_polygon_class_get(), typeof(Polygon), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Polygon(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Polygon(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Polygon static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Polygon(obj.NativeHandle);
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
    protected static extern  void efl_canvas_polygon_point_add(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
   /// <summary>Adds the given point to the given evas polygon object.</summary>
   /// <param name="pos">A point coordinate.</param>
   /// <returns></returns>
   virtual public  void AddPoint( Eina.Position2D pos) {
       var _in_pos = Eina.Position2D_StructConversion.ToInternal(pos);
                  efl_canvas_polygon_point_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_pos);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_polygon_points_clear(System.IntPtr obj);
   /// <summary>Removes all of the points from the given evas polygon object.</summary>
   /// <returns></returns>
   virtual public  void ClearPoints() {
       efl_canvas_polygon_points_clear((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
}
public class PolygonNativeInherit : Efl.Canvas.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_canvas_polygon_point_add_static_delegate = new efl_canvas_polygon_point_add_delegate(point_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_polygon_point_add"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_polygon_point_add_static_delegate)});
      efl_canvas_polygon_points_clear_static_delegate = new efl_canvas_polygon_points_clear_delegate(points_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_polygon_points_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_polygon_points_clear_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.Polygon.efl_canvas_polygon_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Polygon.efl_canvas_polygon_class_get();
   }


    private delegate  void efl_canvas_polygon_point_add_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal pos);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_polygon_point_add(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
    private static  void point_add(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D_StructInternal pos)
   {
      Eina.Log.Debug("function efl_canvas_polygon_point_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_pos = Eina.Position2D_StructConversion.ToManaged(pos);
                     
         try {
            ((Polygon)wrapper).AddPoint( _in_pos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_polygon_point_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
      }
   }
   private efl_canvas_polygon_point_add_delegate efl_canvas_polygon_point_add_static_delegate;


    private delegate  void efl_canvas_polygon_points_clear_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_polygon_points_clear(System.IntPtr obj);
    private static  void points_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_polygon_points_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Polygon)wrapper).ClearPoints();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_canvas_polygon_points_clear(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_polygon_points_clear_delegate efl_canvas_polygon_points_clear_static_delegate;
}
} } 
