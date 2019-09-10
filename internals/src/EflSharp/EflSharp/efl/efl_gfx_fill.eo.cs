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

/// <summary>Efl graphics fill interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Gfx.IFillConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
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
void SetFillAuto(bool filled);
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
void SetFill(Eina.Rect fill);
                    /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.IFill.Fill"/> property to its actual geometry.
    /// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.IFill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
    /// 
    /// This property takes precedence over <see cref="Efl.Gfx.IFill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.IFill.Fill"/> should be set.
    /// 
    /// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
    /// <value><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</value>
    bool FillAuto {
        get;
        set;
    }
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
    /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
    /// 
    /// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
    /// <value>The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</value>
    Eina.Rect Fill {
        get;
        set;
    }
}
/// <summary>Efl graphics fill interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
sealed public  class IFillConcrete :
    Efl.Eo.EoWrapper
    , IFill
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IFillConcrete))
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
    private IFillConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_fill_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IFill"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IFillConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
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
         var _ret_var = Efl.Gfx.IFillConcrete.NativeMethods.efl_gfx_fill_auto_get_ptr.Value.Delegate(this.NativeHandle);
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
    public void SetFillAuto(bool filled) {
                                 Efl.Gfx.IFillConcrete.NativeMethods.efl_gfx_fill_auto_set_ptr.Value.Delegate(this.NativeHandle,filled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
    /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
    /// 
    /// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
    /// <returns>The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</returns>
    public Eina.Rect GetFill() {
         var _ret_var = Efl.Gfx.IFillConcrete.NativeMethods.efl_gfx_fill_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
    /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
    /// 
    /// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
    /// <param name="fill">The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</param>
    public void SetFill(Eina.Rect fill) {
         Eina.Rect.NativeStruct _in_fill = fill;
                        Efl.Gfx.IFillConcrete.NativeMethods.efl_gfx_fill_set_ptr.Value.Delegate(this.NativeHandle,_in_fill);
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
        set { SetFillAuto(value); }
    }
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
    /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
    /// 
    /// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
    /// <value>The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</value>
    public Eina.Rect Fill {
        get { return GetFill(); }
        set { SetFill(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IFillConcrete.efl_gfx_fill_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gfx_fill_auto_get_static_delegate == null)
            {
                efl_gfx_fill_auto_get_static_delegate = new efl_gfx_fill_auto_get_delegate(fill_auto_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFillAuto") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_fill_auto_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_auto_get_static_delegate) });
            }

            if (efl_gfx_fill_auto_set_static_delegate == null)
            {
                efl_gfx_fill_auto_set_static_delegate = new efl_gfx_fill_auto_set_delegate(fill_auto_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFillAuto") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_fill_auto_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_auto_set_static_delegate) });
            }

            if (efl_gfx_fill_get_static_delegate == null)
            {
                efl_gfx_fill_get_static_delegate = new efl_gfx_fill_get_delegate(fill_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFill") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_get_static_delegate) });
            }

            if (efl_gfx_fill_set_static_delegate == null)
            {
                efl_gfx_fill_set_static_delegate = new efl_gfx_fill_set_delegate(fill_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFill") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_set_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Gfx.IFillConcrete.efl_gfx_fill_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_fill_auto_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_fill_auto_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_get_api_delegate> efl_gfx_fill_auto_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_get_api_delegate>(Module, "efl_gfx_fill_auto_get");

        private static bool fill_auto_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_fill_auto_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IFill)ws.Target).GetFillAuto();
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
                return efl_gfx_fill_auto_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_fill_auto_get_delegate efl_gfx_fill_auto_get_static_delegate;

        
        private delegate void efl_gfx_fill_auto_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool filled);

        
        public delegate void efl_gfx_fill_auto_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool filled);

        public static Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_set_api_delegate> efl_gfx_fill_auto_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_set_api_delegate>(Module, "efl_gfx_fill_auto_set");

        private static void fill_auto_set(System.IntPtr obj, System.IntPtr pd, bool filled)
        {
            Eina.Log.Debug("function efl_gfx_fill_auto_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IFill)ws.Target).SetFillAuto(filled);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_fill_auto_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), filled);
            }
        }

        private static efl_gfx_fill_auto_set_delegate efl_gfx_fill_auto_set_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_gfx_fill_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_gfx_fill_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_fill_get_api_delegate> efl_gfx_fill_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_get_api_delegate>(Module, "efl_gfx_fill_get");

        private static Eina.Rect.NativeStruct fill_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_fill_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((IFill)ws.Target).GetFill();
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
                return efl_gfx_fill_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_fill_get_delegate efl_gfx_fill_get_static_delegate;

        
        private delegate void efl_gfx_fill_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct fill);

        
        public delegate void efl_gfx_fill_set_api_delegate(System.IntPtr obj,  Eina.Rect.NativeStruct fill);

        public static Efl.Eo.FunctionWrapper<efl_gfx_fill_set_api_delegate> efl_gfx_fill_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_set_api_delegate>(Module, "efl_gfx_fill_set");

        private static void fill_set(System.IntPtr obj, System.IntPtr pd, Eina.Rect.NativeStruct fill)
        {
            Eina.Log.Debug("function efl_gfx_fill_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Rect _in_fill = fill;
                            
                try
                {
                    ((IFill)ws.Target).SetFill(_in_fill);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_fill_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fill);
            }
        }

        private static efl_gfx_fill_set_delegate efl_gfx_fill_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_GfxIFillConcrete_ExtensionMethods {
    public static Efl.BindableProperty<bool> FillAuto<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Gfx.IFill, T>magic = null) where T : Efl.Gfx.IFill {
        return new Efl.BindableProperty<bool>("fill_auto", fac);
    }

    public static Efl.BindableProperty<Eina.Rect> Fill<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Gfx.IFill, T>magic = null) where T : Efl.Gfx.IFill {
        return new Efl.BindableProperty<Eina.Rect>("fill", fac);
    }

}
#pragma warning restore CS1591
#endif
