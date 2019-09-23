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

/// <summary>Efl Gfx Color mixin class
/// (Since EFL 1.22)</summary>
[Efl.Gfx.ColorConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IColor : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The general/main color of the given Evas object.
/// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
/// 
/// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
/// 
/// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
/// 
/// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.
/// (Since EFL 1.22)</summary>
void GetColor(out int r, out int g, out int b, out int a);
    /// <summary>The general/main color of the given Evas object.
/// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
/// 
/// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
/// 
/// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
/// 
/// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.
/// (Since EFL 1.22)</summary>
void SetColor(int r, int g, int b, int a);
    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).
/// (Since EFL 1.22)</summary>
/// <returns>the hex color code.</returns>
System.String GetColorCode();
    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).
/// (Since EFL 1.22)</summary>
/// <param name="colorcode">the hex color code.</param>
void SetColorCode(System.String colorcode);
                    /// <summary>The general/main color of the given Evas object.
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    (int, int, int, int) Color {
        get;
        set;
    }
    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).
    /// (Since EFL 1.22)</summary>
    /// <value>the hex color code.</value>
    System.String ColorCode {
        get;
        set;
    }
}
/// <summary>Efl Gfx Color mixin class
/// (Since EFL 1.22)</summary>
public sealed class ColorConcrete :
    Efl.Eo.EoWrapper
    , IColor
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ColorConcrete))
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
    private ColorConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_color_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IColor"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ColorConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>The general/main color of the given Evas object.
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    public void GetColor(out int r, out int g, out int b, out int a) {
                                                                                                         Efl.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_get_ptr.Value.Delegate(this.NativeHandle,out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>The general/main color of the given Evas object.
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    public void SetColor(int r, int g, int b, int a) {
                                                                                                         Efl.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_set_ptr.Value.Delegate(this.NativeHandle,r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).
    /// (Since EFL 1.22)</summary>
    /// <returns>the hex color code.</returns>
    public System.String GetColorCode() {
         var _ret_var = Efl.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_code_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).
    /// (Since EFL 1.22)</summary>
    /// <param name="colorcode">the hex color code.</param>
    public void SetColorCode(System.String colorcode) {
                                 Efl.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_code_set_ptr.Value.Delegate(this.NativeHandle,colorcode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The general/main color of the given Evas object.
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    public (int, int, int, int) Color {
        get {
            int _out_r = default(int);
            int _out_g = default(int);
            int _out_b = default(int);
            int _out_a = default(int);
            GetColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).
    /// (Since EFL 1.22)</summary>
    /// <value>the hex color code.</value>
    public System.String ColorCode {
        get { return GetColorCode(); }
        set { SetColorCode(value); }
    }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.ColorConcrete.efl_gfx_color_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gfx_color_get_static_delegate == null)
            {
                efl_gfx_color_get_static_delegate = new efl_gfx_color_get_delegate(color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_get_static_delegate) });
            }

            if (efl_gfx_color_set_static_delegate == null)
            {
                efl_gfx_color_set_static_delegate = new efl_gfx_color_set_delegate(color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_set_static_delegate) });
            }

            if (efl_gfx_color_code_get_static_delegate == null)
            {
                efl_gfx_color_code_get_static_delegate = new efl_gfx_color_code_get_delegate(color_code_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetColorCode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_get_static_delegate) });
            }

            if (efl_gfx_color_code_set_static_delegate == null)
            {
                efl_gfx_color_code_set_static_delegate = new efl_gfx_color_code_set_delegate(color_code_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetColorCode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_set_static_delegate) });
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
            return Efl.Gfx.ColorConcrete.efl_gfx_color_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_gfx_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int r,  out int g,  out int b,  out int a);

        
        public delegate void efl_gfx_color_get_api_delegate(System.IntPtr obj,  out int r,  out int g,  out int b,  out int a);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_get_api_delegate> efl_gfx_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_get_api_delegate>(Module, "efl_gfx_color_get");

        private static void color_get(System.IntPtr obj, System.IntPtr pd, out int r, out int g, out int b, out int a)
        {
            Eina.Log.Debug("function efl_gfx_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(int);        g = default(int);        b = default(int);        a = default(int);                                            
                try
                {
                    ((IColor)ws.Target).GetColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_gfx_color_get_delegate efl_gfx_color_get_static_delegate;

        
        private delegate void efl_gfx_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  int r,  int g,  int b,  int a);

        
        public delegate void efl_gfx_color_set_api_delegate(System.IntPtr obj,  int r,  int g,  int b,  int a);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_set_api_delegate> efl_gfx_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_set_api_delegate>(Module, "efl_gfx_color_set");

        private static void color_set(System.IntPtr obj, System.IntPtr pd, int r, int g, int b, int a)
        {
            Eina.Log.Debug("function efl_gfx_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((IColor)ws.Target).SetColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_gfx_color_set_delegate efl_gfx_color_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_gfx_color_code_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_gfx_color_code_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_code_get_api_delegate> efl_gfx_color_code_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_code_get_api_delegate>(Module, "efl_gfx_color_code_get");

        private static System.String color_code_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_color_code_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IColor)ws.Target).GetColorCode();
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
                return efl_gfx_color_code_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_color_code_get_delegate efl_gfx_color_code_get_static_delegate;

        
        private delegate void efl_gfx_color_code_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String colorcode);

        
        public delegate void efl_gfx_color_code_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String colorcode);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_code_set_api_delegate> efl_gfx_color_code_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_code_set_api_delegate>(Module, "efl_gfx_color_code_set");

        private static void color_code_set(System.IntPtr obj, System.IntPtr pd, System.String colorcode)
        {
            Eina.Log.Debug("function efl_gfx_color_code_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IColor)ws.Target).SetColorCode(colorcode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_color_code_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), colorcode);
            }
        }

        private static efl_gfx_color_code_set_delegate efl_gfx_color_code_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_GfxColorConcrete_ExtensionMethods {
    
    public static Efl.BindableProperty<System.String> ColorCode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Gfx.IColor, T>magic = null) where T : Efl.Gfx.IColor {
        return new Efl.BindableProperty<System.String>("color_code", fac);
    }

}
#pragma warning restore CS1591
#endif
