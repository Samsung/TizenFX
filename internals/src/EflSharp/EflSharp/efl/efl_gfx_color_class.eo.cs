#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl Gfx Color Class mixin class</summary>
[IColorClassNativeInherit]
public interface IColorClass : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Get the color of color class.
/// This function gets the color values for a color class. If no explicit object color is set, then global values will be used.
/// 
/// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
/// 
/// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
/// <param name="color_class">The name of color class</param>
/// <param name="layer">The layer to set the color</param>
/// <param name="r">The intensity of the red color</param>
/// <param name="g">The intensity of the green color</param>
/// <param name="b">The intensity of the blue color</param>
/// <param name="a">The alpha value</param>
/// <returns><c>true</c> if getting the color succeeded, <c>false</c> otherwise</returns>
bool GetColorClass( System.String color_class,  Efl.Gfx.ColorClassLayer layer,  out int r,  out int g,  out int b,  out int a);
    /// <summary>Set the color of color class.
/// This function sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
/// 
/// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
/// 
/// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
/// 
/// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
/// <param name="color_class">The name of color class</param>
/// <param name="layer">The layer to set the color</param>
/// <param name="r">The intensity of the red color</param>
/// <param name="g">The intensity of the green color</param>
/// <param name="b">The intensity of the blue color</param>
/// <param name="a">The alpha value</param>
/// <returns><c>true</c> if setting the color succeeded, <c>false</c> otherwise</returns>
bool SetColorClass( System.String color_class,  Efl.Gfx.ColorClassLayer layer,  int r,  int g,  int b,  int a);
    /// <summary>Get the hex color string of color class.
/// This function gets the color values for a color class. If no explicit object color is set, then global values will be used.
/// 
/// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
/// 
/// Returns NULL if the color class cannot be fetched.
/// 
/// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
/// <param name="color_class">The name of color class</param>
/// <param name="layer">The layer to set the color</param>
/// <returns>the hex color code.</returns>
System.String GetColorClassCode( System.String color_class,  Efl.Gfx.ColorClassLayer layer);
    /// <summary>Set the hex color string of color class.
/// This function sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
/// 
/// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
/// 
/// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
/// 
/// Note: These color values are expected to be premultiplied by the alpha.</summary>
/// <param name="color_class">The name of color class</param>
/// <param name="layer">The layer to set the color</param>
/// <param name="colorcode">the hex color code.</param>
/// <returns><c>true</c> if setting the color succeeded, <c>false</c> otherwise</returns>
bool SetColorClassCode( System.String color_class,  Efl.Gfx.ColorClassLayer layer,  System.String colorcode);
    /// <summary>Get the description of a color class.
/// This function gets the description of a color class in use by an object.</summary>
/// <param name="color_class">The name of color class</param>
/// <returns>The description of the target color class or <c>null</c> if not found</returns>
System.String GetColorClassDescription( System.String color_class);
    /// <summary>Delete the color class.
/// This function deletes any values for the specified color class.
/// 
/// Deleting the color class will revert it to the values defined by <see cref="Efl.Gfx.IColorClass.GetColorClass"/> or the color class defined in the theme file.
/// 
/// Deleting the color class will emit the signal &quot;color_class,del&quot; for the given Edje object.</summary>
/// <param name="color_class">The name of color_class</param>
/// <returns></returns>
void DelColorClass( System.String color_class);
    /// <summary>Delete all color classes defined in object level.
/// This function deletes any color classes defined in object level. Clearing color classes will revert the color of all edje parts to the values defined in global level or theme file.</summary>
/// <returns></returns>
void ClearColorClass();
                            }
/// <summary>Efl Gfx Color Class mixin class</summary>
sealed public class IColorClassConcrete : 

IColorClass
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IColorClassConcrete))
                return Efl.Gfx.IColorClassNativeInherit.GetEflClassStatic();
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
        efl_gfx_color_class_mixin_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IColorClassConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IColorClassConcrete()
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
    /// <summary>Get the color of color class.
    /// This function gets the color values for a color class. If no explicit object color is set, then global values will be used.
    /// 
    /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
    /// 
    /// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <param name="layer">The layer to set the color</param>
    /// <param name="r">The intensity of the red color</param>
    /// <param name="g">The intensity of the green color</param>
    /// <param name="b">The intensity of the blue color</param>
    /// <param name="a">The alpha value</param>
    /// <returns><c>true</c> if getting the color succeeded, <c>false</c> otherwise</returns>
    public bool GetColorClass( System.String color_class,  Efl.Gfx.ColorClassLayer layer,  out int r,  out int g,  out int b,  out int a) {
                                                                                                                                                         var _ret_var = Efl.Gfx.IColorClassNativeInherit.efl_gfx_color_class_get_ptr.Value.Delegate(this.NativeHandle, color_class,  layer,  out r,  out g,  out b,  out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                        return _ret_var;
 }
    /// <summary>Set the color of color class.
    /// This function sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
    /// 
    /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
    /// 
    /// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
    /// 
    /// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <param name="layer">The layer to set the color</param>
    /// <param name="r">The intensity of the red color</param>
    /// <param name="g">The intensity of the green color</param>
    /// <param name="b">The intensity of the blue color</param>
    /// <param name="a">The alpha value</param>
    /// <returns><c>true</c> if setting the color succeeded, <c>false</c> otherwise</returns>
    public bool SetColorClass( System.String color_class,  Efl.Gfx.ColorClassLayer layer,  int r,  int g,  int b,  int a) {
                                                                                                                                                         var _ret_var = Efl.Gfx.IColorClassNativeInherit.efl_gfx_color_class_set_ptr.Value.Delegate(this.NativeHandle, color_class,  layer,  r,  g,  b,  a);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                        return _ret_var;
 }
    /// <summary>Get the hex color string of color class.
    /// This function gets the color values for a color class. If no explicit object color is set, then global values will be used.
    /// 
    /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
    /// 
    /// Returns NULL if the color class cannot be fetched.
    /// 
    /// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <param name="layer">The layer to set the color</param>
    /// <returns>the hex color code.</returns>
    public System.String GetColorClassCode( System.String color_class,  Efl.Gfx.ColorClassLayer layer) {
                                                         var _ret_var = Efl.Gfx.IColorClassNativeInherit.efl_gfx_color_class_code_get_ptr.Value.Delegate(this.NativeHandle, color_class,  layer);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Set the hex color string of color class.
    /// This function sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
    /// 
    /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
    /// 
    /// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
    /// 
    /// Note: These color values are expected to be premultiplied by the alpha.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <param name="layer">The layer to set the color</param>
    /// <param name="colorcode">the hex color code.</param>
    /// <returns><c>true</c> if setting the color succeeded, <c>false</c> otherwise</returns>
    public bool SetColorClassCode( System.String color_class,  Efl.Gfx.ColorClassLayer layer,  System.String colorcode) {
                                                                                 var _ret_var = Efl.Gfx.IColorClassNativeInherit.efl_gfx_color_class_code_set_ptr.Value.Delegate(this.NativeHandle, color_class,  layer,  colorcode);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Get the description of a color class.
    /// This function gets the description of a color class in use by an object.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <returns>The description of the target color class or <c>null</c> if not found</returns>
    public System.String GetColorClassDescription( System.String color_class) {
                                 var _ret_var = Efl.Gfx.IColorClassNativeInherit.efl_gfx_color_class_description_get_ptr.Value.Delegate(this.NativeHandle, color_class);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Delete the color class.
    /// This function deletes any values for the specified color class.
    /// 
    /// Deleting the color class will revert it to the values defined by <see cref="Efl.Gfx.IColorClass.GetColorClass"/> or the color class defined in the theme file.
    /// 
    /// Deleting the color class will emit the signal &quot;color_class,del&quot; for the given Edje object.</summary>
    /// <param name="color_class">The name of color_class</param>
    /// <returns></returns>
    public void DelColorClass( System.String color_class) {
                                 Efl.Gfx.IColorClassNativeInherit.efl_gfx_color_class_del_ptr.Value.Delegate(this.NativeHandle, color_class);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Delete all color classes defined in object level.
    /// This function deletes any color classes defined in object level. Clearing color classes will revert the color of all edje parts to the values defined in global level or theme file.</summary>
    /// <returns></returns>
    public void ClearColorClass() {
         Efl.Gfx.IColorClassNativeInherit.efl_gfx_color_class_clear_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IColorClassConcrete.efl_gfx_color_class_mixin_get();
    }
}
public class IColorClassNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_gfx_color_class_get_static_delegate == null)
            efl_gfx_color_class_get_static_delegate = new efl_gfx_color_class_get_delegate(color_class_get);
        if (methods.FirstOrDefault(m => m.Name == "GetColorClass") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_class_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_get_static_delegate)});
        if (efl_gfx_color_class_set_static_delegate == null)
            efl_gfx_color_class_set_static_delegate = new efl_gfx_color_class_set_delegate(color_class_set);
        if (methods.FirstOrDefault(m => m.Name == "SetColorClass") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_class_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_set_static_delegate)});
        if (efl_gfx_color_class_code_get_static_delegate == null)
            efl_gfx_color_class_code_get_static_delegate = new efl_gfx_color_class_code_get_delegate(color_class_code_get);
        if (methods.FirstOrDefault(m => m.Name == "GetColorClassCode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_class_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_code_get_static_delegate)});
        if (efl_gfx_color_class_code_set_static_delegate == null)
            efl_gfx_color_class_code_set_static_delegate = new efl_gfx_color_class_code_set_delegate(color_class_code_set);
        if (methods.FirstOrDefault(m => m.Name == "SetColorClassCode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_class_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_code_set_static_delegate)});
        if (efl_gfx_color_class_description_get_static_delegate == null)
            efl_gfx_color_class_description_get_static_delegate = new efl_gfx_color_class_description_get_delegate(color_class_description_get);
        if (methods.FirstOrDefault(m => m.Name == "GetColorClassDescription") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_class_description_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_description_get_static_delegate)});
        if (efl_gfx_color_class_del_static_delegate == null)
            efl_gfx_color_class_del_static_delegate = new efl_gfx_color_class_del_delegate(color_class_del);
        if (methods.FirstOrDefault(m => m.Name == "DelColorClass") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_class_del"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_del_static_delegate)});
        if (efl_gfx_color_class_clear_static_delegate == null)
            efl_gfx_color_class_clear_static_delegate = new efl_gfx_color_class_clear_delegate(color_class_clear);
        if (methods.FirstOrDefault(m => m.Name == "ClearColorClass") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_class_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_clear_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Gfx.IColorClassConcrete.efl_gfx_color_class_mixin_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IColorClassConcrete.efl_gfx_color_class_mixin_get();
    }


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_color_class_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String color_class,   Efl.Gfx.ColorClassLayer layer,   out int r,   out int g,   out int b,   out int a);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_color_class_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String color_class,   Efl.Gfx.ColorClassLayer layer,   out int r,   out int g,   out int b,   out int a);
     public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_get_api_delegate> efl_gfx_color_class_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_get_api_delegate>(_Module, "efl_gfx_color_class_get");
     private static bool color_class_get(System.IntPtr obj, System.IntPtr pd,  System.String color_class,  Efl.Gfx.ColorClassLayer layer,  out int r,  out int g,  out int b,  out int a)
    {
        Eina.Log.Debug("function efl_gfx_color_class_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                    r = default(int);        g = default(int);        b = default(int);        a = default(int);                                                            bool _ret_var = default(bool);
            try {
                _ret_var = ((IColorClassConcrete)wrapper).GetColorClass( color_class,  layer,  out r,  out g,  out b,  out a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                                        return _ret_var;
        } else {
            return efl_gfx_color_class_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class,  layer,  out r,  out g,  out b,  out a);
        }
    }
    private static efl_gfx_color_class_get_delegate efl_gfx_color_class_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_color_class_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String color_class,   Efl.Gfx.ColorClassLayer layer,   int r,   int g,   int b,   int a);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_color_class_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String color_class,   Efl.Gfx.ColorClassLayer layer,   int r,   int g,   int b,   int a);
     public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_set_api_delegate> efl_gfx_color_class_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_set_api_delegate>(_Module, "efl_gfx_color_class_set");
     private static bool color_class_set(System.IntPtr obj, System.IntPtr pd,  System.String color_class,  Efl.Gfx.ColorClassLayer layer,  int r,  int g,  int b,  int a)
    {
        Eina.Log.Debug("function efl_gfx_color_class_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IColorClassConcrete)wrapper).SetColorClass( color_class,  layer,  r,  g,  b,  a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                                        return _ret_var;
        } else {
            return efl_gfx_color_class_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class,  layer,  r,  g,  b,  a);
        }
    }
    private static efl_gfx_color_class_set_delegate efl_gfx_color_class_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_gfx_color_class_code_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String color_class,   Efl.Gfx.ColorClassLayer layer);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_gfx_color_class_code_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String color_class,   Efl.Gfx.ColorClassLayer layer);
     public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_code_get_api_delegate> efl_gfx_color_class_code_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_code_get_api_delegate>(_Module, "efl_gfx_color_class_code_get");
     private static System.String color_class_code_get(System.IntPtr obj, System.IntPtr pd,  System.String color_class,  Efl.Gfx.ColorClassLayer layer)
    {
        Eina.Log.Debug("function efl_gfx_color_class_code_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((IColorClassConcrete)wrapper).GetColorClassCode( color_class,  layer);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_gfx_color_class_code_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class,  layer);
        }
    }
    private static efl_gfx_color_class_code_get_delegate efl_gfx_color_class_code_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_color_class_code_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String color_class,   Efl.Gfx.ColorClassLayer layer,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String colorcode);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_color_class_code_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String color_class,   Efl.Gfx.ColorClassLayer layer,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String colorcode);
     public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_code_set_api_delegate> efl_gfx_color_class_code_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_code_set_api_delegate>(_Module, "efl_gfx_color_class_code_set");
     private static bool color_class_code_set(System.IntPtr obj, System.IntPtr pd,  System.String color_class,  Efl.Gfx.ColorClassLayer layer,  System.String colorcode)
    {
        Eina.Log.Debug("function efl_gfx_color_class_code_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((IColorClassConcrete)wrapper).SetColorClassCode( color_class,  layer,  colorcode);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                        return _ret_var;
        } else {
            return efl_gfx_color_class_code_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class,  layer,  colorcode);
        }
    }
    private static efl_gfx_color_class_code_set_delegate efl_gfx_color_class_code_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_gfx_color_class_description_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String color_class);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_gfx_color_class_description_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String color_class);
     public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_description_get_api_delegate> efl_gfx_color_class_description_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_description_get_api_delegate>(_Module, "efl_gfx_color_class_description_get");
     private static System.String color_class_description_get(System.IntPtr obj, System.IntPtr pd,  System.String color_class)
    {
        Eina.Log.Debug("function efl_gfx_color_class_description_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                System.String _ret_var = default(System.String);
            try {
                _ret_var = ((IColorClassConcrete)wrapper).GetColorClassDescription( color_class);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_gfx_color_class_description_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class);
        }
    }
    private static efl_gfx_color_class_description_get_delegate efl_gfx_color_class_description_get_static_delegate;


     private delegate void efl_gfx_color_class_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String color_class);


     public delegate void efl_gfx_color_class_del_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String color_class);
     public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_del_api_delegate> efl_gfx_color_class_del_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_del_api_delegate>(_Module, "efl_gfx_color_class_del");
     private static void color_class_del(System.IntPtr obj, System.IntPtr pd,  System.String color_class)
    {
        Eina.Log.Debug("function efl_gfx_color_class_del was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IColorClassConcrete)wrapper).DelColorClass( color_class);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_color_class_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class);
        }
    }
    private static efl_gfx_color_class_del_delegate efl_gfx_color_class_del_static_delegate;


     private delegate void efl_gfx_color_class_clear_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_gfx_color_class_clear_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_clear_api_delegate> efl_gfx_color_class_clear_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_clear_api_delegate>(_Module, "efl_gfx_color_class_clear");
     private static void color_class_clear(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_color_class_clear was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((IColorClassConcrete)wrapper).ClearColorClass();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_gfx_color_class_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_color_class_clear_delegate efl_gfx_color_class_clear_static_delegate;
}
} } 
