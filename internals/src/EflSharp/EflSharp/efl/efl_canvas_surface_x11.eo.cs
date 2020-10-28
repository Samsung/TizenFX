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
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (SurfaceX11))
                return Efl.Canvas.SurfaceX11NativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_surface_x11_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public SurfaceX11(Efl.Object parent= null
            ) :
        base(efl_canvas_surface_x11_class_get(), typeof(SurfaceX11), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected SurfaceX11(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected SurfaceX11(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    /// <summary>This is a helper for <see cref="Efl.Canvas.Surface.NativeBuffer"/>.</summary>
    /// <param name="visual">X11 Visual for this Pixmap.</param>
    /// <param name="pixmap">X11 Pixmap ID.</param>
    /// <returns></returns>
    virtual public void GetPixmap( out System.IntPtr visual,  out uint pixmap) {
                                                         Efl.Canvas.SurfaceX11NativeInherit.efl_canvas_surface_x11_pixmap_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out visual,  out pixmap);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This is a helper for <see cref="Efl.Canvas.Surface.NativeBuffer"/>.</summary>
    /// <param name="visual">X11 Visual for this Pixmap.</param>
    /// <param name="pixmap">X11 Pixmap ID.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool SetPixmap( System.IntPtr visual,  uint pixmap) {
                                                         var _ret_var = Efl.Canvas.SurfaceX11NativeInherit.efl_canvas_surface_x11_pixmap_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), visual,  pixmap);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.SurfaceX11.efl_canvas_surface_x11_class_get();
    }
}
public class SurfaceX11NativeInherit : Efl.Canvas.SurfaceNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_canvas_surface_x11_pixmap_get_static_delegate == null)
            efl_canvas_surface_x11_pixmap_get_static_delegate = new efl_canvas_surface_x11_pixmap_get_delegate(pixmap_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPixmap") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_surface_x11_pixmap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_surface_x11_pixmap_get_static_delegate)});
        if (efl_canvas_surface_x11_pixmap_set_static_delegate == null)
            efl_canvas_surface_x11_pixmap_set_static_delegate = new efl_canvas_surface_x11_pixmap_set_delegate(pixmap_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPixmap") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_surface_x11_pixmap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_surface_x11_pixmap_set_static_delegate)});
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


     private delegate void efl_canvas_surface_x11_pixmap_get_delegate(System.IntPtr obj, System.IntPtr pd,   out System.IntPtr visual,   out uint pixmap);


     public delegate void efl_canvas_surface_x11_pixmap_get_api_delegate(System.IntPtr obj,   out System.IntPtr visual,   out uint pixmap);
     public static Efl.Eo.FunctionWrapper<efl_canvas_surface_x11_pixmap_get_api_delegate> efl_canvas_surface_x11_pixmap_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_surface_x11_pixmap_get_api_delegate>(_Module, "efl_canvas_surface_x11_pixmap_get");
     private static void pixmap_get(System.IntPtr obj, System.IntPtr pd,  out System.IntPtr visual,  out uint pixmap)
    {
        Eina.Log.Debug("function efl_canvas_surface_x11_pixmap_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    visual = default(System.IntPtr);        pixmap = default(uint);                            
            try {
                ((SurfaceX11)wrapper).GetPixmap( out visual,  out pixmap);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_canvas_surface_x11_pixmap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out visual,  out pixmap);
        }
    }
    private static efl_canvas_surface_x11_pixmap_get_delegate efl_canvas_surface_x11_pixmap_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_surface_x11_pixmap_set_delegate(System.IntPtr obj, System.IntPtr pd,   System.IntPtr visual,   uint pixmap);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_surface_x11_pixmap_set_api_delegate(System.IntPtr obj,   System.IntPtr visual,   uint pixmap);
     public static Efl.Eo.FunctionWrapper<efl_canvas_surface_x11_pixmap_set_api_delegate> efl_canvas_surface_x11_pixmap_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_surface_x11_pixmap_set_api_delegate>(_Module, "efl_canvas_surface_x11_pixmap_set");
     private static bool pixmap_set(System.IntPtr obj, System.IntPtr pd,  System.IntPtr visual,  uint pixmap)
    {
        Eina.Log.Debug("function efl_canvas_surface_x11_pixmap_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
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
            return efl_canvas_surface_x11_pixmap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  visual,  pixmap);
        }
    }
    private static efl_canvas_surface_x11_pixmap_set_delegate efl_canvas_surface_x11_pixmap_set_static_delegate;
}
} } 
namespace Efl { namespace Canvas { 
/// <summary>The type used by <see cref="Efl.Canvas.Surface.NativeBuffer"/>.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct SurfaceX11Pixmap
{
    /// <summary>X11 Visual for this Pixmap.</summary>
    public System.IntPtr Visual;
    /// <summary>X11 Pixmap ID.</summary>
    public uint Pixmap;
    ///<summary>Constructor for SurfaceX11Pixmap.</summary>
    public SurfaceX11Pixmap(
        System.IntPtr Visual=default(System.IntPtr),
        uint Pixmap=default(uint)    )
    {
        this.Visual = Visual;
        this.Pixmap = Pixmap;
    }

    public static implicit operator SurfaceX11Pixmap(IntPtr ptr)
    {
        var tmp = (SurfaceX11Pixmap.NativeStruct)Marshal.PtrToStructure(ptr, typeof(SurfaceX11Pixmap.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct SurfaceX11Pixmap.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public System.IntPtr Visual;
        
        public uint Pixmap;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator SurfaceX11Pixmap.NativeStruct(SurfaceX11Pixmap _external_struct)
        {
            var _internal_struct = new SurfaceX11Pixmap.NativeStruct();
            _internal_struct.Visual = _external_struct.Visual;
            _internal_struct.Pixmap = _external_struct.Pixmap;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator SurfaceX11Pixmap(SurfaceX11Pixmap.NativeStruct _internal_struct)
        {
            var _external_struct = new SurfaceX11Pixmap();
            _external_struct.Visual = _internal_struct.Visual;
            _external_struct.Pixmap = _internal_struct.Pixmap;
            return _external_struct;
        }

    }

}

} } 
