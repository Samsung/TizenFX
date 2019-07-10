#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Low-level polygon object</summary>
[Efl.Canvas.Polygon.NativeMethods]
public class Polygon : Efl.Canvas.Object
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Polygon))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_polygon_class_get();
    /// <summary>Initializes a new instance of the <see cref="Polygon"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Polygon(Efl.Object parent= null
            ) : base(efl_canvas_polygon_class_get(), typeof(Polygon), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Polygon"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Polygon(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Polygon"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Polygon(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Adds the given point to the given evas polygon object.</summary>
    /// <param name="pos">A point coordinate.</param>
    virtual public void AddPoint(Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Canvas.Polygon.NativeMethods.efl_canvas_polygon_point_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Removes all of the points from the given evas polygon object.</summary>
    virtual public void ClearPoints() {
         Efl.Canvas.Polygon.NativeMethods.efl_canvas_polygon_points_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Polygon.efl_canvas_polygon_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_canvas_polygon_point_add_static_delegate == null)
            {
                efl_canvas_polygon_point_add_static_delegate = new efl_canvas_polygon_point_add_delegate(point_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddPoint") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_polygon_point_add"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_polygon_point_add_static_delegate) });
            }

            if (efl_canvas_polygon_points_clear_static_delegate == null)
            {
                efl_canvas_polygon_points_clear_static_delegate = new efl_canvas_polygon_points_clear_delegate(points_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearPoints") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_polygon_points_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_polygon_points_clear_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Polygon.efl_canvas_polygon_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_canvas_polygon_point_add_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos);

        
        public delegate void efl_canvas_polygon_point_add_api_delegate(System.IntPtr obj,  Eina.Position2D.NativeStruct pos);

        public static Efl.Eo.FunctionWrapper<efl_canvas_polygon_point_add_api_delegate> efl_canvas_polygon_point_add_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_polygon_point_add_api_delegate>(Module, "efl_canvas_polygon_point_add");

        private static void point_add(System.IntPtr obj, System.IntPtr pd, Eina.Position2D.NativeStruct pos)
        {
            Eina.Log.Debug("function efl_canvas_polygon_point_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Position2D _in_pos = pos;
                            
                try
                {
                    ((Polygon)ws.Target).AddPoint(_in_pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_polygon_point_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pos);
            }
        }

        private static efl_canvas_polygon_point_add_delegate efl_canvas_polygon_point_add_static_delegate;

        
        private delegate void efl_canvas_polygon_points_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_canvas_polygon_points_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_polygon_points_clear_api_delegate> efl_canvas_polygon_points_clear_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_polygon_points_clear_api_delegate>(Module, "efl_canvas_polygon_points_clear");

        private static void points_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_polygon_points_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Polygon)ws.Target).ClearPoints();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_canvas_polygon_points_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_polygon_points_clear_delegate efl_canvas_polygon_points_clear_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

