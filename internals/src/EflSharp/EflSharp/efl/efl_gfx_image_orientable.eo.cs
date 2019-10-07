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

/// <summary>Interface for images which can be rotated or flipped (mirrored).
/// Compare with <see cref="Efl.Ui.ILayoutOrientable"/> which works for layout objects and does not include rotation.</summary>
[Efl.Gfx.ImageOrientableConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IImageOrientable : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Control the orientation (rotation and flipping) of a visual object.
    /// This can be used to set the rotation on an image or a window, for instance.</summary>
    /// <returns>The final orientation of the object.</returns>
    Efl.Gfx.ImageOrientation GetImageOrientation();

    /// <summary>Control the orientation (rotation and flipping) of a visual object.
    /// This can be used to set the rotation on an image or a window, for instance.</summary>
    /// <param name="dir">The final orientation of the object.<br/>The default value is <see cref="Efl.Gfx.ImageOrientation.None"/>.</param>
    void SetImageOrientation(Efl.Gfx.ImageOrientation dir);

    /// <summary>Control the orientation (rotation and flipping) of a visual object.
    /// This can be used to set the rotation on an image or a window, for instance.</summary>
    /// <value>The final orientation of the object.</value>
    Efl.Gfx.ImageOrientation ImageOrientation {
        get;
        set;
    }

}

/// <summary>Interface for images which can be rotated or flipped (mirrored).
/// Compare with <see cref="Efl.Ui.ILayoutOrientable"/> which works for layout objects and does not include rotation.</summary>
public sealed class ImageOrientableConcrete :
    Efl.Eo.EoWrapper
    , IImageOrientable
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ImageOrientableConcrete))
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
    private ImageOrientableConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_image_orientable_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IImageOrientable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ImageOrientableConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Control the orientation (rotation and flipping) of a visual object.
    /// This can be used to set the rotation on an image or a window, for instance.</summary>
    /// <returns>The final orientation of the object.</returns>
    public Efl.Gfx.ImageOrientation GetImageOrientation() {
        var _ret_var = Efl.Gfx.ImageOrientableConcrete.NativeMethods.efl_gfx_image_orientation_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the orientation (rotation and flipping) of a visual object.
    /// This can be used to set the rotation on an image or a window, for instance.</summary>
    /// <param name="dir">The final orientation of the object.<br/>The default value is <see cref="Efl.Gfx.ImageOrientation.None"/>.</param>
    public void SetImageOrientation(Efl.Gfx.ImageOrientation dir) {
        Efl.Gfx.ImageOrientableConcrete.NativeMethods.efl_gfx_image_orientation_set_ptr.Value.Delegate(this.NativeHandle,dir);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control the orientation (rotation and flipping) of a visual object.
    /// This can be used to set the rotation on an image or a window, for instance.</summary>
    /// <value>The final orientation of the object.</value>
    public Efl.Gfx.ImageOrientation ImageOrientation {
        get { return GetImageOrientation(); }
        set { SetImageOrientation(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.ImageOrientableConcrete.efl_gfx_image_orientable_interface_get();
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

            if (efl_gfx_image_orientation_get_static_delegate == null)
            {
                efl_gfx_image_orientation_get_static_delegate = new efl_gfx_image_orientation_get_delegate(image_orientation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetImageOrientation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_orientation_get_static_delegate) });
            }

            if (efl_gfx_image_orientation_set_static_delegate == null)
            {
                efl_gfx_image_orientation_set_static_delegate = new efl_gfx_image_orientation_set_delegate(image_orientation_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetImageOrientation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_orientation_set_static_delegate) });
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
            return Efl.Gfx.ImageOrientableConcrete.efl_gfx_image_orientable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.Gfx.ImageOrientation efl_gfx_image_orientation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Gfx.ImageOrientation efl_gfx_image_orientation_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_orientation_get_api_delegate> efl_gfx_image_orientation_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_orientation_get_api_delegate>(Module, "efl_gfx_image_orientation_get");

        private static Efl.Gfx.ImageOrientation image_orientation_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_orientation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Efl.Gfx.ImageOrientation _ret_var = default(Efl.Gfx.ImageOrientation);
                try
                {
                    _ret_var = ((IImageOrientable)ws.Target).GetImageOrientation();
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
                return efl_gfx_image_orientation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_orientation_get_delegate efl_gfx_image_orientation_get_static_delegate;

        
        private delegate void efl_gfx_image_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.ImageOrientation dir);

        
        public delegate void efl_gfx_image_orientation_set_api_delegate(System.IntPtr obj,  Efl.Gfx.ImageOrientation dir);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_orientation_set_api_delegate> efl_gfx_image_orientation_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_orientation_set_api_delegate>(Module, "efl_gfx_image_orientation_set");

        private static void image_orientation_set(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.ImageOrientation dir)
        {
            Eina.Log.Debug("function efl_gfx_image_orientation_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImageOrientable)ws.Target).SetImageOrientation(dir);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_orientation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir);
            }
        }

        private static efl_gfx_image_orientation_set_delegate efl_gfx_image_orientation_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_GfxImageOrientableConcrete_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Gfx.ImageOrientation> ImageOrientation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Gfx.IImageOrientable, T>magic = null) where T : Efl.Gfx.IImageOrientable {
        return new Efl.BindableProperty<Efl.Gfx.ImageOrientation>("image_orientation", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Gfx {

/// <summary>An orientation type, to rotate and flip images.
/// This is similar to EXIF&apos;s orientation. Directional values (<c>up</c>, <c>down</c>, <c>left</c>, <c>right</c>) indicate the final direction in which the top of the image will be facing (e.g. a picture of a house will have its roof pointing to the right if the <c>right</c> orientation is used). Flipping values (<c>flip_horizontal</c> and <c>flip_vertical</c>) can be additionally added to produce a mirroring in each axis. Not to be confused with <see cref="Efl.Ui.LayoutOrientation"/> which is meant for widgets, rather than images and canvases. This enum is used to rotate images, videos and the like.</summary>
[Efl.Eo.BindingEntity]
public enum ImageOrientation
{
/// <summary>Default, same as up, do not rotate.</summary>
None = 0,
/// <summary>Orient up, do not rotate.</summary>
Up = 0,
/// <summary>Orient right, rotate 90 degrees clock-wise.</summary>
Right = 1,
/// <summary>Orient down, rotate 180 degrees.</summary>
Down = 2,
/// <summary>Orient left, rotate 270 degrees clock-wise.</summary>
Left = 3,
/// <summary>Bitmask that can be used to isolate rotation values, that is, <c>none</c>, <c>up</c>, <c>down</c>, <c>left</c> and <c>right</c>.</summary>
RotationBitmask = 3,
/// <summary>Mirror horizontally. Can be added to the other values.</summary>
FlipHorizontal = 4,
/// <summary>Mirror vertically. Can be added to the other values.</summary>
FlipVertical = 8,
/// <summary>Bitmask that can be used to isolate flipping values, that is, <c>flip_vertical</c> and <c>flip_horizontal</c>.</summary>
FlipBitmask = 12,
}
}
}

