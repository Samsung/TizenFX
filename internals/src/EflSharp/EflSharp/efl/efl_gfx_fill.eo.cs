#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl graphics fill interface</summary>
[IFillNativeInherit]
public interface IFill : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.IFill.Fill"/> property to its actual geometry.
/// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.IFill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
/// 
/// This property takes precedence over <see cref="Efl.Gfx.IFill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.IFill.Fill"/> should be set.
/// 
/// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
/// <returns><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</returns>
bool GetFillAuto();
    /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.IFill.Fill"/> property to its actual geometry.
/// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.IFill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
/// 
/// This property takes precedence over <see cref="Efl.Gfx.IFill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.IFill.Fill"/> should be set.
/// 
/// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
/// <param name="filled"><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</param>
/// <returns></returns>
void SetFillAuto( bool filled);
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
/// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
/// 
/// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
/// <returns>The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</returns>
Eina.Rect GetFill();
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
/// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
/// 
/// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
/// <param name="fill">The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</param>
/// <returns></returns>
void SetFill( Eina.Rect fill);
                    /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.IFill.Fill"/> property to its actual geometry.
/// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.IFill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
/// 
/// This property takes precedence over <see cref="Efl.Gfx.IFill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.IFill.Fill"/> should be set.
/// 
/// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
/// <value><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</value>
    bool FillAuto {
        get ;
        set ;
    }
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
/// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
/// 
/// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
/// <value>The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</value>
    Eina.Rect Fill {
        get ;
        set ;
    }
}
/// <summary>Efl graphics fill interface</summary>
sealed public class IFillConcrete : 

IFill
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IFillConcrete))
                return Efl.Gfx.IFillNativeInherit.GetEflClassStatic();
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
        efl_gfx_fill_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IFillConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IFillConcrete()
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
     void RegisterEventProxies()
    {
    }
    /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.IFill.Fill"/> property to its actual geometry.
    /// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.IFill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
    /// 
    /// This property takes precedence over <see cref="Efl.Gfx.IFill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.IFill.Fill"/> should be set.
    /// 
    /// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
    /// <returns><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</returns>
    public bool GetFillAuto() {
         var _ret_var = Efl.Gfx.IFillNativeInherit.efl_gfx_fill_auto_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.IFill.Fill"/> property to its actual geometry.
    /// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.IFill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
    /// 
    /// This property takes precedence over <see cref="Efl.Gfx.IFill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.IFill.Fill"/> should be set.
    /// 
    /// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
    /// <param name="filled"><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</param>
    /// <returns></returns>
    public void SetFillAuto( bool filled) {
                                 Efl.Gfx.IFillNativeInherit.efl_gfx_fill_auto_set_ptr.Value.Delegate(this.NativeHandle, filled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
    /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
    /// 
    /// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
    /// <returns>The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</returns>
    public Eina.Rect GetFill() {
         var _ret_var = Efl.Gfx.IFillNativeInherit.efl_gfx_fill_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
    /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
    /// 
    /// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
    /// <param name="fill">The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</param>
    /// <returns></returns>
    public void SetFill( Eina.Rect fill) {
         Eina.Rect.NativeStruct _in_fill = fill;
                        Efl.Gfx.IFillNativeInherit.efl_gfx_fill_set_ptr.Value.Delegate(this.NativeHandle, _in_fill);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.IFill.Fill"/> property to its actual geometry.
/// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.IFill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
/// 
/// This property takes precedence over <see cref="Efl.Gfx.IFill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.IFill.Fill"/> should be set.
/// 
/// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
/// <value><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</value>
    public bool FillAuto {
        get { return GetFillAuto(); }
        set { SetFillAuto( value); }
    }
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
/// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
/// 
/// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
/// <value>The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</value>
    public Eina.Rect Fill {
        get { return GetFill(); }
        set { SetFill( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IFillConcrete.efl_gfx_fill_interface_get();
    }
}
public class IFillNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_gfx_fill_auto_get_static_delegate == null)
            efl_gfx_fill_auto_get_static_delegate = new efl_gfx_fill_auto_get_delegate(fill_auto_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFillAuto") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_fill_auto_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_auto_get_static_delegate)});
        if (efl_gfx_fill_auto_set_static_delegate == null)
            efl_gfx_fill_auto_set_static_delegate = new efl_gfx_fill_auto_set_delegate(fill_auto_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFillAuto") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_fill_auto_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_auto_set_static_delegate)});
        if (efl_gfx_fill_get_static_delegate == null)
            efl_gfx_fill_get_static_delegate = new efl_gfx_fill_get_delegate(fill_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFill") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_get_static_delegate)});
        if (efl_gfx_fill_set_static_delegate == null)
            efl_gfx_fill_set_static_delegate = new efl_gfx_fill_set_delegate(fill_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFill") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_set_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Gfx.IFillConcrete.efl_gfx_fill_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IFillConcrete.efl_gfx_fill_interface_get();
    }


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_fill_auto_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_fill_auto_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_get_api_delegate> efl_gfx_fill_auto_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_get_api_delegate>(_Module, "efl_gfx_fill_auto_get");
     private static bool fill_auto_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_fill_auto_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IFill)wrapper).GetFillAuto();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_fill_auto_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_fill_auto_get_delegate efl_gfx_fill_auto_get_static_delegate;


     private delegate void efl_gfx_fill_auto_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool filled);


     public delegate void efl_gfx_fill_auto_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool filled);
     public static Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_set_api_delegate> efl_gfx_fill_auto_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_set_api_delegate>(_Module, "efl_gfx_fill_auto_set");
     private static void fill_auto_set(System.IntPtr obj, System.IntPtr pd,  bool filled)
    {
        Eina.Log.Debug("function efl_gfx_fill_auto_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IFill)wrapper).SetFillAuto( filled);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_fill_auto_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  filled);
        }
    }
    private static efl_gfx_fill_auto_set_delegate efl_gfx_fill_auto_set_static_delegate;


     private delegate Eina.Rect.NativeStruct efl_gfx_fill_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Rect.NativeStruct efl_gfx_fill_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_fill_get_api_delegate> efl_gfx_fill_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_get_api_delegate>(_Module, "efl_gfx_fill_get");
     private static Eina.Rect.NativeStruct fill_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_fill_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Rect _ret_var = default(Eina.Rect);
            try {
                _ret_var = ((IFill)wrapper).GetFill();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_fill_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_fill_get_delegate efl_gfx_fill_get_static_delegate;


     private delegate void efl_gfx_fill_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect.NativeStruct fill);


     public delegate void efl_gfx_fill_set_api_delegate(System.IntPtr obj,   Eina.Rect.NativeStruct fill);
     public static Efl.Eo.FunctionWrapper<efl_gfx_fill_set_api_delegate> efl_gfx_fill_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_set_api_delegate>(_Module, "efl_gfx_fill_set");
     private static void fill_set(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct fill)
    {
        Eina.Log.Debug("function efl_gfx_fill_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Rect _in_fill = fill;
                            
            try {
                ((IFill)wrapper).SetFill( _in_fill);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_fill_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fill);
        }
    }
    private static efl_gfx_fill_set_delegate efl_gfx_fill_set_static_delegate;
}
} } 
