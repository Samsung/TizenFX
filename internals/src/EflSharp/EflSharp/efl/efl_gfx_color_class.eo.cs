#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Gfx {

/// <summary>This mixin provides an interface for objects supporting color classes (this is, named colors) and provides a helper method to also allow hexadecimal color codes.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Gfx.ColorClassConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IColorClass : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Color for the color class.
    /// This property sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
    /// 
    /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the last two only apply to text parts).
    /// 
    /// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
    /// 
    /// When retrieving the color of an object, if no explicit object color is set, then global values will be used.
    /// 
    /// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <param name="layer">The layer to set the color</param>
    /// <param name="r">The intensity of the red color</param>
    /// <param name="g">The intensity of the green color</param>
    /// <param name="b">The intensity of the blue color</param>
    /// <param name="a">The alpha value</param>
    /// <returns><c>true</c> if getting the color succeeded, <c>false</c> otherwise</returns>
    bool GetColorClass(System.String color_class, Efl.Gfx.ColorClassLayer layer, out int r, out int g, out int b, out int a);

    /// <summary>Color for the color class.
    /// This property sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
    /// 
    /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the last two only apply to text parts).
    /// 
    /// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
    /// 
    /// When retrieving the color of an object, if no explicit object color is set, then global values will be used.
    /// 
    /// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <param name="layer">The layer to set the color</param>
    /// <param name="r">The intensity of the red color</param>
    /// <param name="g">The intensity of the green color</param>
    /// <param name="b">The intensity of the blue color</param>
    /// <param name="a">The alpha value</param>
    /// <returns><c>true</c> if setting the color succeeded, <c>false</c> otherwise</returns>
    bool SetColorClass(System.String color_class, Efl.Gfx.ColorClassLayer layer, int r, int g, int b, int a);

    /// <summary>Hexadecimal color code string of the color class.
    /// This property sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
    /// 
    /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the last two only apply to text parts).
    /// 
    /// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
    /// 
    /// When retrieving the color of an object, if no explicit object color is set, then global values will be used.
    /// 
    /// Note: These color values are expected to be premultiplied by the alpha.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <param name="layer">The layer to set the color</param>
    /// <returns>the hex color code.</returns>
    System.String GetColorClassCode(System.String color_class, Efl.Gfx.ColorClassLayer layer);

    /// <summary>Hexadecimal color code string of the color class.
    /// This property sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
    /// 
    /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the last two only apply to text parts).
    /// 
    /// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
    /// 
    /// When retrieving the color of an object, if no explicit object color is set, then global values will be used.
    /// 
    /// Note: These color values are expected to be premultiplied by the alpha.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <param name="layer">The layer to set the color</param>
    /// <param name="colorcode">the hex color code.</param>
    /// <returns><c>true</c> if setting the color succeeded, <c>false</c> otherwise</returns>
    bool SetColorClassCode(System.String color_class, Efl.Gfx.ColorClassLayer layer, System.String colorcode);

    /// <summary>Get the description of a color class.
    /// This function gets the description of a color class in use by an object.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <returns>The description of the target color class or <c>null</c> if not found</returns>
    System.String GetColorClassDescription(System.String color_class);

    /// <summary>Delete the color class.
    /// This function deletes any values for the specified color class.
    /// 
    /// Deleting the color class will revert it to the values defined by <see cref="Efl.Gfx.IColorClass.GetColorClass"/> or the color class defined in the theme file.
    /// 
    /// Deleting the color class will emit the signal &quot;color_class,del&quot; for the given Edje object.</summary>
    /// <param name="color_class">The name of color_class</param>
    void DelColorClass(System.String color_class);

    /// <summary>Delete all color classes defined in object level.
    /// This function deletes any color classes defined in object level. Clearing color classes will revert the color of all edje parts to the values defined in global level or theme file.</summary>
    void ClearColorClass();

}

/// <summary>This mixin provides an interface for objects supporting color classes (this is, named colors) and provides a helper method to also allow hexadecimal color codes.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class ColorClassConcrete :
    Efl.Eo.EoWrapper
    , IColorClass
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ColorClassConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private ColorClassConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_color_class_mixin_get();

    /// <summary>Initializes a new instance of the <see cref="IColorClass"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ColorClassConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Color for the color class.
    /// This property sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
    /// 
    /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the last two only apply to text parts).
    /// 
    /// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
    /// 
    /// When retrieving the color of an object, if no explicit object color is set, then global values will be used.
    /// 
    /// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <param name="layer">The layer to set the color</param>
    /// <param name="r">The intensity of the red color</param>
    /// <param name="g">The intensity of the green color</param>
    /// <param name="b">The intensity of the blue color</param>
    /// <param name="a">The alpha value</param>
    /// <returns><c>true</c> if getting the color succeeded, <c>false</c> otherwise</returns>
    public bool GetColorClass(System.String color_class, Efl.Gfx.ColorClassLayer layer, out int r, out int g, out int b, out int a) {
        var _ret_var = Efl.Gfx.ColorClassConcrete.NativeMethods.efl_gfx_color_class_get_ptr.Value.Delegate(this.NativeHandle,color_class, layer, out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Color for the color class.
    /// This property sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
    /// 
    /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the last two only apply to text parts).
    /// 
    /// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
    /// 
    /// When retrieving the color of an object, if no explicit object color is set, then global values will be used.
    /// 
    /// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <param name="layer">The layer to set the color</param>
    /// <param name="r">The intensity of the red color</param>
    /// <param name="g">The intensity of the green color</param>
    /// <param name="b">The intensity of the blue color</param>
    /// <param name="a">The alpha value</param>
    /// <returns><c>true</c> if setting the color succeeded, <c>false</c> otherwise</returns>
    public bool SetColorClass(System.String color_class, Efl.Gfx.ColorClassLayer layer, int r, int g, int b, int a) {
        var _ret_var = Efl.Gfx.ColorClassConcrete.NativeMethods.efl_gfx_color_class_set_ptr.Value.Delegate(this.NativeHandle,color_class, layer, r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Hexadecimal color code string of the color class.
    /// This property sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
    /// 
    /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the last two only apply to text parts).
    /// 
    /// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
    /// 
    /// When retrieving the color of an object, if no explicit object color is set, then global values will be used.
    /// 
    /// Note: These color values are expected to be premultiplied by the alpha.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <param name="layer">The layer to set the color</param>
    /// <returns>the hex color code.</returns>
    public System.String GetColorClassCode(System.String color_class, Efl.Gfx.ColorClassLayer layer) {
        var _ret_var = Efl.Gfx.ColorClassConcrete.NativeMethods.efl_gfx_color_class_code_get_ptr.Value.Delegate(this.NativeHandle,color_class, layer);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Hexadecimal color code string of the color class.
    /// This property sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
    /// 
    /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the last two only apply to text parts).
    /// 
    /// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
    /// 
    /// When retrieving the color of an object, if no explicit object color is set, then global values will be used.
    /// 
    /// Note: These color values are expected to be premultiplied by the alpha.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <param name="layer">The layer to set the color</param>
    /// <param name="colorcode">the hex color code.</param>
    /// <returns><c>true</c> if setting the color succeeded, <c>false</c> otherwise</returns>
    public bool SetColorClassCode(System.String color_class, Efl.Gfx.ColorClassLayer layer, System.String colorcode) {
        var _ret_var = Efl.Gfx.ColorClassConcrete.NativeMethods.efl_gfx_color_class_code_set_ptr.Value.Delegate(this.NativeHandle,color_class, layer, colorcode);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Get the description of a color class.
    /// This function gets the description of a color class in use by an object.</summary>
    /// <param name="color_class">The name of color class</param>
    /// <returns>The description of the target color class or <c>null</c> if not found</returns>
    public System.String GetColorClassDescription(System.String color_class) {
        var _ret_var = Efl.Gfx.ColorClassConcrete.NativeMethods.efl_gfx_color_class_description_get_ptr.Value.Delegate(this.NativeHandle,color_class);
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
    public void DelColorClass(System.String color_class) {
        Efl.Gfx.ColorClassConcrete.NativeMethods.efl_gfx_color_class_del_ptr.Value.Delegate(this.NativeHandle,color_class);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Delete all color classes defined in object level.
    /// This function deletes any color classes defined in object level. Clearing color classes will revert the color of all edje parts to the values defined in global level or theme file.</summary>
    public void ClearColorClass() {
        Efl.Gfx.ColorClassConcrete.NativeMethods.efl_gfx_color_class_clear_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.ColorClassConcrete.efl_gfx_color_class_mixin_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Efl);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gfx_color_class_get_static_delegate == null)
            {
                efl_gfx_color_class_get_static_delegate = new efl_gfx_color_class_get_delegate(color_class_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetColorClass") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_class_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_get_static_delegate) });
            }

            if (efl_gfx_color_class_set_static_delegate == null)
            {
                efl_gfx_color_class_set_static_delegate = new efl_gfx_color_class_set_delegate(color_class_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetColorClass") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_class_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_set_static_delegate) });
            }

            if (efl_gfx_color_class_code_get_static_delegate == null)
            {
                efl_gfx_color_class_code_get_static_delegate = new efl_gfx_color_class_code_get_delegate(color_class_code_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetColorClassCode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_class_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_code_get_static_delegate) });
            }

            if (efl_gfx_color_class_code_set_static_delegate == null)
            {
                efl_gfx_color_class_code_set_static_delegate = new efl_gfx_color_class_code_set_delegate(color_class_code_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetColorClassCode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_class_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_code_set_static_delegate) });
            }

            if (efl_gfx_color_class_description_get_static_delegate == null)
            {
                efl_gfx_color_class_description_get_static_delegate = new efl_gfx_color_class_description_get_delegate(color_class_description_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetColorClassDescription") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_class_description_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_description_get_static_delegate) });
            }

            if (efl_gfx_color_class_del_static_delegate == null)
            {
                efl_gfx_color_class_del_static_delegate = new efl_gfx_color_class_del_delegate(color_class_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelColorClass") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_class_del"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_del_static_delegate) });
            }

            if (efl_gfx_color_class_clear_static_delegate == null)
            {
                efl_gfx_color_class_clear_static_delegate = new efl_gfx_color_class_clear_delegate(color_class_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearColorClass") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_class_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_clear_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Gfx.ColorClassConcrete.efl_gfx_color_class_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_color_class_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String color_class,  Efl.Gfx.ColorClassLayer layer,  out int r,  out int g,  out int b,  out int a);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_color_class_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String color_class,  Efl.Gfx.ColorClassLayer layer,  out int r,  out int g,  out int b,  out int a);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_get_api_delegate> efl_gfx_color_class_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_get_api_delegate>(Module, "efl_gfx_color_class_get");

        private static bool color_class_get(System.IntPtr obj, System.IntPtr pd, System.String color_class, Efl.Gfx.ColorClassLayer layer, out int r, out int g, out int b, out int a)
        {
            Eina.Log.Debug("function efl_gfx_color_class_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                r = default(int);g = default(int);b = default(int);a = default(int);bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IColorClass)ws.Target).GetColorClass(color_class, layer, out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_color_class_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), color_class, layer, out r, out g, out b, out a);
            }
        }

        private static efl_gfx_color_class_get_delegate efl_gfx_color_class_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_color_class_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String color_class,  Efl.Gfx.ColorClassLayer layer,  int r,  int g,  int b,  int a);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_color_class_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String color_class,  Efl.Gfx.ColorClassLayer layer,  int r,  int g,  int b,  int a);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_set_api_delegate> efl_gfx_color_class_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_set_api_delegate>(Module, "efl_gfx_color_class_set");

        private static bool color_class_set(System.IntPtr obj, System.IntPtr pd, System.String color_class, Efl.Gfx.ColorClassLayer layer, int r, int g, int b, int a)
        {
            Eina.Log.Debug("function efl_gfx_color_class_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IColorClass)ws.Target).SetColorClass(color_class, layer, r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_color_class_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), color_class, layer, r, g, b, a);
            }
        }

        private static efl_gfx_color_class_set_delegate efl_gfx_color_class_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_gfx_color_class_code_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String color_class,  Efl.Gfx.ColorClassLayer layer);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_gfx_color_class_code_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String color_class,  Efl.Gfx.ColorClassLayer layer);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_code_get_api_delegate> efl_gfx_color_class_code_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_code_get_api_delegate>(Module, "efl_gfx_color_class_code_get");

        private static System.String color_class_code_get(System.IntPtr obj, System.IntPtr pd, System.String color_class, Efl.Gfx.ColorClassLayer layer)
        {
            Eina.Log.Debug("function efl_gfx_color_class_code_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IColorClass)ws.Target).GetColorClassCode(color_class, layer);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_color_class_code_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), color_class, layer);
            }
        }

        private static efl_gfx_color_class_code_get_delegate efl_gfx_color_class_code_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_color_class_code_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String color_class,  Efl.Gfx.ColorClassLayer layer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String colorcode);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_color_class_code_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String color_class,  Efl.Gfx.ColorClassLayer layer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String colorcode);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_code_set_api_delegate> efl_gfx_color_class_code_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_code_set_api_delegate>(Module, "efl_gfx_color_class_code_set");

        private static bool color_class_code_set(System.IntPtr obj, System.IntPtr pd, System.String color_class, Efl.Gfx.ColorClassLayer layer, System.String colorcode)
        {
            Eina.Log.Debug("function efl_gfx_color_class_code_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IColorClass)ws.Target).SetColorClassCode(color_class, layer, colorcode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_color_class_code_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), color_class, layer, colorcode);
            }
        }

        private static efl_gfx_color_class_code_set_delegate efl_gfx_color_class_code_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_gfx_color_class_description_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String color_class);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_gfx_color_class_description_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String color_class);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_description_get_api_delegate> efl_gfx_color_class_description_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_description_get_api_delegate>(Module, "efl_gfx_color_class_description_get");

        private static System.String color_class_description_get(System.IntPtr obj, System.IntPtr pd, System.String color_class)
        {
            Eina.Log.Debug("function efl_gfx_color_class_description_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IColorClass)ws.Target).GetColorClassDescription(color_class);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_color_class_description_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), color_class);
            }
        }

        private static efl_gfx_color_class_description_get_delegate efl_gfx_color_class_description_get_static_delegate;

        
        private delegate void efl_gfx_color_class_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String color_class);

        
        public delegate void efl_gfx_color_class_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String color_class);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_del_api_delegate> efl_gfx_color_class_del_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_del_api_delegate>(Module, "efl_gfx_color_class_del");

        private static void color_class_del(System.IntPtr obj, System.IntPtr pd, System.String color_class)
        {
            Eina.Log.Debug("function efl_gfx_color_class_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IColorClass)ws.Target).DelColorClass(color_class);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_color_class_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), color_class);
            }
        }

        private static efl_gfx_color_class_del_delegate efl_gfx_color_class_del_static_delegate;

        
        private delegate void efl_gfx_color_class_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_gfx_color_class_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_clear_api_delegate> efl_gfx_color_class_clear_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_clear_api_delegate>(Module, "efl_gfx_color_class_clear");

        private static void color_class_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_color_class_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IColorClass)ws.Target).ClearColorClass();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_color_class_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_color_class_clear_delegate efl_gfx_color_class_clear_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_GfxColorClassConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
