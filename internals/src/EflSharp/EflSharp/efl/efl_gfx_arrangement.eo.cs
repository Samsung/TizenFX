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

/// <summary>This interface provides methods for manipulating how contents are arranged within a container, providing more granularity for content positioning.
/// (Since EFL 1.23)</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Gfx.ArrangementConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IArrangement : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
/// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
/// 
/// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
/// (Since EFL 1.23)</summary>
/// <param name="align_horiz">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</param>
/// <param name="align_vert">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end. The default value is 0.5.</param>
void GetContentAlign(out double align_horiz, out double align_vert);
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
/// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
/// 
/// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
/// (Since EFL 1.23)</summary>
/// <param name="align_horiz">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</param>
/// <param name="align_vert">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end. The default value is 0.5.</param>
void SetContentAlign(double align_horiz, double align_vert);
    /// <summary>This property determines the space between a container&apos;s content items.
/// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
/// 
/// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
/// (Since EFL 1.23)</summary>
/// <param name="pad_horiz">Horizontal padding. The default value is 0.0.</param>
/// <param name="pad_vert">Vertical padding. The default value is 0.0.</param>
/// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise. The default value is <c>false</c>.</param>
void GetContentPadding(out double pad_horiz, out double pad_vert, out bool scalable);
    /// <summary>This property determines the space between a container&apos;s content items.
/// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
/// 
/// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
/// (Since EFL 1.23)</summary>
/// <param name="pad_horiz">Horizontal padding. The default value is 0.0.</param>
/// <param name="pad_vert">Vertical padding. The default value is 0.0.</param>
/// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise. The default value is <c>false</c>.</param>
void SetContentPadding(double pad_horiz, double pad_vert, bool scalable);
                    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
    /// (Since EFL 1.23)</summary>
    /// <value>Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</value>
    (double, double) ContentAlign {
        get;
        set;
    }
    /// <summary>This property determines the space between a container&apos;s content items.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
    /// (Since EFL 1.23)</summary>
    /// <value>Horizontal padding. The default value is 0.0.</value>
    (double, double, bool) ContentPadding {
        get;
        set;
    }
}
/// <summary>This interface provides methods for manipulating how contents are arranged within a container, providing more granularity for content positioning.
/// (Since EFL 1.23)</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class ArrangementConcrete :
    Efl.Eo.EoWrapper
    , IArrangement
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ArrangementConcrete))
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
    private ArrangementConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_arrangement_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IArrangement"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ArrangementConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="align_horiz">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</param>
    /// <param name="align_vert">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end. The default value is 0.5.</param>
    public void GetContentAlign(out double align_horiz, out double align_vert) {
                                                         Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_align_get_ptr.Value.Delegate(this.NativeHandle,out align_horiz, out align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="align_horiz">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</param>
    /// <param name="align_vert">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end. The default value is 0.5.</param>
    public void SetContentAlign(double align_horiz, double align_vert) {
                                                         Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_align_set_ptr.Value.Delegate(this.NativeHandle,align_horiz, align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This property determines the space between a container&apos;s content items.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="pad_horiz">Horizontal padding. The default value is 0.0.</param>
    /// <param name="pad_vert">Vertical padding. The default value is 0.0.</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise. The default value is <c>false</c>.</param>
    public void GetContentPadding(out double pad_horiz, out double pad_vert, out bool scalable) {
                                                                                 Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_padding_get_ptr.Value.Delegate(this.NativeHandle,out pad_horiz, out pad_vert, out scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>This property determines the space between a container&apos;s content items.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="pad_horiz">Horizontal padding. The default value is 0.0.</param>
    /// <param name="pad_vert">Vertical padding. The default value is 0.0.</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise. The default value is <c>false</c>.</param>
    public void SetContentPadding(double pad_horiz, double pad_vert, bool scalable) {
                                                                                 Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_padding_set_ptr.Value.Delegate(this.NativeHandle,pad_horiz, pad_vert, scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
    /// (Since EFL 1.23)</summary>
    /// <value>Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</value>
    public (double, double) ContentAlign {
        get {
            double _out_align_horiz = default(double);
            double _out_align_vert = default(double);
            GetContentAlign(out _out_align_horiz,out _out_align_vert);
            return (_out_align_horiz,_out_align_vert);
        }
        set { SetContentAlign( value.Item1,  value.Item2); }
    }
    /// <summary>This property determines the space between a container&apos;s content items.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
    /// (Since EFL 1.23)</summary>
    /// <value>Horizontal padding. The default value is 0.0.</value>
    public (double, double, bool) ContentPadding {
        get {
            double _out_pad_horiz = default(double);
            double _out_pad_vert = default(double);
            bool _out_scalable = default(bool);
            GetContentPadding(out _out_pad_horiz,out _out_pad_vert,out _out_scalable);
            return (_out_pad_horiz,_out_pad_vert,_out_scalable);
        }
        set { SetContentPadding( value.Item1,  value.Item2,  value.Item3); }
    }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.ArrangementConcrete.efl_gfx_arrangement_interface_get();
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

            if (efl_gfx_arrangement_content_align_get_static_delegate == null)
            {
                efl_gfx_arrangement_content_align_get_static_delegate = new efl_gfx_arrangement_content_align_get_delegate(content_align_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContentAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_arrangement_content_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_arrangement_content_align_get_static_delegate) });
            }

            if (efl_gfx_arrangement_content_align_set_static_delegate == null)
            {
                efl_gfx_arrangement_content_align_set_static_delegate = new efl_gfx_arrangement_content_align_set_delegate(content_align_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetContentAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_arrangement_content_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_arrangement_content_align_set_static_delegate) });
            }

            if (efl_gfx_arrangement_content_padding_get_static_delegate == null)
            {
                efl_gfx_arrangement_content_padding_get_static_delegate = new efl_gfx_arrangement_content_padding_get_delegate(content_padding_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContentPadding") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_arrangement_content_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_arrangement_content_padding_get_static_delegate) });
            }

            if (efl_gfx_arrangement_content_padding_set_static_delegate == null)
            {
                efl_gfx_arrangement_content_padding_set_static_delegate = new efl_gfx_arrangement_content_padding_set_delegate(content_padding_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetContentPadding") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_arrangement_content_padding_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_arrangement_content_padding_set_static_delegate) });
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
            return Efl.Gfx.ArrangementConcrete.efl_gfx_arrangement_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_gfx_arrangement_content_align_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double align_horiz,  out double align_vert);

        
        public delegate void efl_gfx_arrangement_content_align_get_api_delegate(System.IntPtr obj,  out double align_horiz,  out double align_vert);

        public static Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_align_get_api_delegate> efl_gfx_arrangement_content_align_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_align_get_api_delegate>(Module, "efl_gfx_arrangement_content_align_get");

        private static void content_align_get(System.IntPtr obj, System.IntPtr pd, out double align_horiz, out double align_vert)
        {
            Eina.Log.Debug("function efl_gfx_arrangement_content_align_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        align_horiz = default(double);        align_vert = default(double);                            
                try
                {
                    ((IArrangement)ws.Target).GetContentAlign(out align_horiz, out align_vert);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_arrangement_content_align_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out align_horiz, out align_vert);
            }
        }

        private static efl_gfx_arrangement_content_align_get_delegate efl_gfx_arrangement_content_align_get_static_delegate;

        
        private delegate void efl_gfx_arrangement_content_align_set_delegate(System.IntPtr obj, System.IntPtr pd,  double align_horiz,  double align_vert);

        
        public delegate void efl_gfx_arrangement_content_align_set_api_delegate(System.IntPtr obj,  double align_horiz,  double align_vert);

        public static Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_align_set_api_delegate> efl_gfx_arrangement_content_align_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_align_set_api_delegate>(Module, "efl_gfx_arrangement_content_align_set");

        private static void content_align_set(System.IntPtr obj, System.IntPtr pd, double align_horiz, double align_vert)
        {
            Eina.Log.Debug("function efl_gfx_arrangement_content_align_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IArrangement)ws.Target).SetContentAlign(align_horiz, align_vert);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_arrangement_content_align_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), align_horiz, align_vert);
            }
        }

        private static efl_gfx_arrangement_content_align_set_delegate efl_gfx_arrangement_content_align_set_static_delegate;

        
        private delegate void efl_gfx_arrangement_content_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double pad_horiz,  out double pad_vert, [MarshalAs(UnmanagedType.U1)] out bool scalable);

        
        public delegate void efl_gfx_arrangement_content_padding_get_api_delegate(System.IntPtr obj,  out double pad_horiz,  out double pad_vert, [MarshalAs(UnmanagedType.U1)] out bool scalable);

        public static Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_padding_get_api_delegate> efl_gfx_arrangement_content_padding_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_padding_get_api_delegate>(Module, "efl_gfx_arrangement_content_padding_get");

        private static void content_padding_get(System.IntPtr obj, System.IntPtr pd, out double pad_horiz, out double pad_vert, out bool scalable)
        {
            Eina.Log.Debug("function efl_gfx_arrangement_content_padding_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                pad_horiz = default(double);        pad_vert = default(double);        scalable = default(bool);                                    
                try
                {
                    ((IArrangement)ws.Target).GetContentPadding(out pad_horiz, out pad_vert, out scalable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_arrangement_content_padding_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out pad_horiz, out pad_vert, out scalable);
            }
        }

        private static efl_gfx_arrangement_content_padding_get_delegate efl_gfx_arrangement_content_padding_get_static_delegate;

        
        private delegate void efl_gfx_arrangement_content_padding_set_delegate(System.IntPtr obj, System.IntPtr pd,  double pad_horiz,  double pad_vert, [MarshalAs(UnmanagedType.U1)] bool scalable);

        
        public delegate void efl_gfx_arrangement_content_padding_set_api_delegate(System.IntPtr obj,  double pad_horiz,  double pad_vert, [MarshalAs(UnmanagedType.U1)] bool scalable);

        public static Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_padding_set_api_delegate> efl_gfx_arrangement_content_padding_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_padding_set_api_delegate>(Module, "efl_gfx_arrangement_content_padding_set");

        private static void content_padding_set(System.IntPtr obj, System.IntPtr pd, double pad_horiz, double pad_vert, bool scalable)
        {
            Eina.Log.Debug("function efl_gfx_arrangement_content_padding_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((IArrangement)ws.Target).SetContentPadding(pad_horiz, pad_vert, scalable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_arrangement_content_padding_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pad_horiz, pad_vert, scalable);
            }
        }

        private static efl_gfx_arrangement_content_padding_set_delegate efl_gfx_arrangement_content_padding_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_GfxArrangementConcrete_ExtensionMethods {
    
    
}
#pragma warning restore CS1591
#endif
