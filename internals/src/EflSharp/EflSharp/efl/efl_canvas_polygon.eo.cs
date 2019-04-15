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
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Polygon))
                return Efl.Canvas.PolygonNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_polygon_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public Polygon(Efl.Object parent= null
            ) :
        base(efl_canvas_polygon_class_get(), typeof(Polygon), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Polygon(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Polygon(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
    }
    /// <summary>Adds the given point to the given evas polygon object.</summary>
    /// <param name="pos">A point coordinate.</param>
    /// <returns></returns>
    virtual public void AddPoint( Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Canvas.PolygonNativeInherit.efl_canvas_polygon_point_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Removes all of the points from the given evas polygon object.</summary>
    /// <returns></returns>
    virtual public void ClearPoints() {
         Efl.Canvas.PolygonNativeInherit.efl_canvas_polygon_points_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Polygon.efl_canvas_polygon_class_get();
    }
}
public class PolygonNativeInherit : Efl.Canvas.ObjectNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_canvas_polygon_point_add_static_delegate == null)
            efl_canvas_polygon_point_add_static_delegate = new efl_canvas_polygon_point_add_delegate(point_add);
        if (methods.FirstOrDefault(m => m.Name == "AddPoint") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_polygon_point_add"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_polygon_point_add_static_delegate)});
        if (efl_canvas_polygon_points_clear_static_delegate == null)
            efl_canvas_polygon_points_clear_static_delegate = new efl_canvas_polygon_points_clear_delegate(points_clear);
        if (methods.FirstOrDefault(m => m.Name == "ClearPoints") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_polygon_points_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_polygon_points_clear_static_delegate)});
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


     private delegate void efl_canvas_polygon_point_add_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D.NativeStruct pos);


     public delegate void efl_canvas_polygon_point_add_api_delegate(System.IntPtr obj,   Eina.Position2D.NativeStruct pos);
     public static Efl.Eo.FunctionWrapper<efl_canvas_polygon_point_add_api_delegate> efl_canvas_polygon_point_add_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_polygon_point_add_api_delegate>(_Module, "efl_canvas_polygon_point_add");
     private static void point_add(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos)
    {
        Eina.Log.Debug("function efl_canvas_polygon_point_add was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Position2D _in_pos = pos;
                            
            try {
                ((Polygon)wrapper).AddPoint( _in_pos);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_canvas_polygon_point_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
        }
    }
    private static efl_canvas_polygon_point_add_delegate efl_canvas_polygon_point_add_static_delegate;


     private delegate void efl_canvas_polygon_points_clear_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_canvas_polygon_points_clear_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_canvas_polygon_points_clear_api_delegate> efl_canvas_polygon_points_clear_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_polygon_points_clear_api_delegate>(_Module, "efl_canvas_polygon_points_clear");
     private static void points_clear(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_canvas_polygon_points_clear was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((Polygon)wrapper).ClearPoints();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_canvas_polygon_points_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_canvas_polygon_points_clear_delegate efl_canvas_polygon_points_clear_static_delegate;
}
} } 
