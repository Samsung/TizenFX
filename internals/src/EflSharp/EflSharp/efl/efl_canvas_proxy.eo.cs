#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Low-level proxy image object.
/// A proxy is a special kind of image containing the pixels from a source object attached to it. It can be used to apply some sort of image transformation to any object (eg. filters, map or zoom).</summary>
[Efl.Canvas.Proxy.NativeMethods]
public class Proxy : Efl.Canvas.ImageInternal
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Proxy))
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
        efl_canvas_proxy_class_get();
    /// <summary>Initializes a new instance of the <see cref="Proxy"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Proxy(Efl.Object parent= null
            ) : base(efl_canvas_proxy_class_get(), typeof(Proxy), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Proxy"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Proxy(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Proxy"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Proxy(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>The source object for this proxy.
    /// The proxy object will mirror the rendering contents of a given source object in its drawing region, without affecting that source in any way. The source must be another valid <see cref="Efl.Canvas.Object"/>. Other effects may be applied to the proxy, such as a map (see <see cref="Efl.Gfx.IMapping"/>) to create a reflection of the original object (for example).
    /// 
    /// Any existing source object will be removed after this call.
    /// 
    /// Note: This property should be set as soon as creating a proxy object, otherwise the proxy will do nothing.
    /// 
    /// Warning: You cannot set a proxy as another proxy&apos;s source.</summary>
    /// <returns>Source object to use for the proxy.</returns>
    virtual public Efl.Canvas.Object GetSource() {
         var _ret_var = Efl.Canvas.Proxy.NativeMethods.efl_canvas_proxy_source_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The source object for this proxy.
    /// The proxy object will mirror the rendering contents of a given source object in its drawing region, without affecting that source in any way. The source must be another valid <see cref="Efl.Canvas.Object"/>. Other effects may be applied to the proxy, such as a map (see <see cref="Efl.Gfx.IMapping"/>) to create a reflection of the original object (for example).
    /// 
    /// Any existing source object will be removed after this call.
    /// 
    /// Note: This property should be set as soon as creating a proxy object, otherwise the proxy will do nothing.
    /// 
    /// Warning: You cannot set a proxy as another proxy&apos;s source.</summary>
    /// <param name="src">Source object to use for the proxy.</param>
    /// <returns>Returns <c>true</c> in case of success.</returns>
    virtual public bool SetSource(Efl.Canvas.Object src) {
                                 var _ret_var = Efl.Canvas.Proxy.NativeMethods.efl_canvas_proxy_source_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),src);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Clip this proxy object with the source object&apos;s clipper.
    /// Use this if you want to overlay an existing object with its proxy, and apply some sort of transformation on it.
    /// 
    /// <c>true</c> means both objects will share the same clip.</summary>
    /// <returns>Whether <c>obj</c> is clipped by the source clipper (<c>true</c>) or not (<c>false</c>).</returns>
    virtual public bool GetSourceClip() {
         var _ret_var = Efl.Canvas.Proxy.NativeMethods.efl_canvas_proxy_source_clip_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Clip this proxy object with the source object&apos;s clipper.
    /// Use this if you want to overlay an existing object with its proxy, and apply some sort of transformation on it.
    /// 
    /// <c>true</c> means both objects will share the same clip.</summary>
    /// <param name="source_clip">Whether <c>obj</c> is clipped by the source clipper (<c>true</c>) or not (<c>false</c>).</param>
    virtual public void SetSourceClip(bool source_clip) {
                                 Efl.Canvas.Proxy.NativeMethods.efl_canvas_proxy_source_clip_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),source_clip);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Defines whether the events on this object are repeated to the source.
    /// If <c>source</c> is <c>true</c>, it will make events on <c>obj</c> to also be repeated for the source object (see <see cref="Efl.Canvas.Proxy.SetSource"/>). Even the <c>obj</c> and source geometries are different, the event position will be transformed to the source object&apos;s space.
    /// 
    /// If <c>source</c> is <c>false</c>, events occurring on <c>obj</c> will be processed only on it.</summary>
    /// <returns>Whether this object should pass events (<c>true</c>) or not (<c>false</c>) to its source.</returns>
    virtual public bool GetSourceEvents() {
         var _ret_var = Efl.Canvas.Proxy.NativeMethods.efl_canvas_proxy_source_events_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Defines whether the events on this object are repeated to the source.
    /// If <c>source</c> is <c>true</c>, it will make events on <c>obj</c> to also be repeated for the source object (see <see cref="Efl.Canvas.Proxy.SetSource"/>). Even the <c>obj</c> and source geometries are different, the event position will be transformed to the source object&apos;s space.
    /// 
    /// If <c>source</c> is <c>false</c>, events occurring on <c>obj</c> will be processed only on it.</summary>
    /// <param name="repeat">Whether this object should pass events (<c>true</c>) or not (<c>false</c>) to its source.</param>
    virtual public void SetSourceEvents(bool repeat) {
                                 Efl.Canvas.Proxy.NativeMethods.efl_canvas_proxy_source_events_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),repeat);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The source object for this proxy.
    /// The proxy object will mirror the rendering contents of a given source object in its drawing region, without affecting that source in any way. The source must be another valid <see cref="Efl.Canvas.Object"/>. Other effects may be applied to the proxy, such as a map (see <see cref="Efl.Gfx.IMapping"/>) to create a reflection of the original object (for example).
    /// 
    /// Any existing source object will be removed after this call.
    /// 
    /// Note: This property should be set as soon as creating a proxy object, otherwise the proxy will do nothing.
    /// 
    /// Warning: You cannot set a proxy as another proxy&apos;s source.</summary>
    /// <value>Source object to use for the proxy.</value>
    public Efl.Canvas.Object Source {
        get { return GetSource(); }
        set { SetSource(value); }
    }
    /// <summary>Clip this proxy object with the source object&apos;s clipper.
    /// Use this if you want to overlay an existing object with its proxy, and apply some sort of transformation on it.
    /// 
    /// <c>true</c> means both objects will share the same clip.</summary>
    /// <value>Whether <c>obj</c> is clipped by the source clipper (<c>true</c>) or not (<c>false</c>).</value>
    public bool SourceClip {
        get { return GetSourceClip(); }
        set { SetSourceClip(value); }
    }
    /// <summary>Defines whether the events on this object are repeated to the source.
    /// If <c>source</c> is <c>true</c>, it will make events on <c>obj</c> to also be repeated for the source object (see <see cref="Efl.Canvas.Proxy.SetSource"/>). Even the <c>obj</c> and source geometries are different, the event position will be transformed to the source object&apos;s space.
    /// 
    /// If <c>source</c> is <c>false</c>, events occurring on <c>obj</c> will be processed only on it.</summary>
    /// <value>Whether this object should pass events (<c>true</c>) or not (<c>false</c>) to its source.</value>
    public bool SourceEvents {
        get { return GetSourceEvents(); }
        set { SetSourceEvents(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Proxy.efl_canvas_proxy_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.ImageInternal.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_canvas_proxy_source_get_static_delegate == null)
            {
                efl_canvas_proxy_source_get_static_delegate = new efl_canvas_proxy_source_get_delegate(source_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSource") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_proxy_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_proxy_source_get_static_delegate) });
            }

            if (efl_canvas_proxy_source_set_static_delegate == null)
            {
                efl_canvas_proxy_source_set_static_delegate = new efl_canvas_proxy_source_set_delegate(source_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSource") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_proxy_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_proxy_source_set_static_delegate) });
            }

            if (efl_canvas_proxy_source_clip_get_static_delegate == null)
            {
                efl_canvas_proxy_source_clip_get_static_delegate = new efl_canvas_proxy_source_clip_get_delegate(source_clip_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSourceClip") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_proxy_source_clip_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_proxy_source_clip_get_static_delegate) });
            }

            if (efl_canvas_proxy_source_clip_set_static_delegate == null)
            {
                efl_canvas_proxy_source_clip_set_static_delegate = new efl_canvas_proxy_source_clip_set_delegate(source_clip_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSourceClip") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_proxy_source_clip_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_proxy_source_clip_set_static_delegate) });
            }

            if (efl_canvas_proxy_source_events_get_static_delegate == null)
            {
                efl_canvas_proxy_source_events_get_static_delegate = new efl_canvas_proxy_source_events_get_delegate(source_events_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSourceEvents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_proxy_source_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_proxy_source_events_get_static_delegate) });
            }

            if (efl_canvas_proxy_source_events_set_static_delegate == null)
            {
                efl_canvas_proxy_source_events_set_static_delegate = new efl_canvas_proxy_source_events_set_delegate(source_events_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSourceEvents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_proxy_source_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_proxy_source_events_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Proxy.efl_canvas_proxy_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_canvas_proxy_source_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_canvas_proxy_source_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_proxy_source_get_api_delegate> efl_canvas_proxy_source_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_proxy_source_get_api_delegate>(Module, "efl_canvas_proxy_source_get");

        private static Efl.Canvas.Object source_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_proxy_source_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((Proxy)ws.Target).GetSource();
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
                return efl_canvas_proxy_source_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_proxy_source_get_delegate efl_canvas_proxy_source_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_proxy_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object src);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_proxy_source_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object src);

        public static Efl.Eo.FunctionWrapper<efl_canvas_proxy_source_set_api_delegate> efl_canvas_proxy_source_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_proxy_source_set_api_delegate>(Module, "efl_canvas_proxy_source_set");

        private static bool source_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object src)
        {
            Eina.Log.Debug("function efl_canvas_proxy_source_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Proxy)ws.Target).SetSource(src);
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
                return efl_canvas_proxy_source_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), src);
            }
        }

        private static efl_canvas_proxy_source_set_delegate efl_canvas_proxy_source_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_proxy_source_clip_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_proxy_source_clip_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_proxy_source_clip_get_api_delegate> efl_canvas_proxy_source_clip_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_proxy_source_clip_get_api_delegate>(Module, "efl_canvas_proxy_source_clip_get");

        private static bool source_clip_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_proxy_source_clip_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Proxy)ws.Target).GetSourceClip();
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
                return efl_canvas_proxy_source_clip_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_proxy_source_clip_get_delegate efl_canvas_proxy_source_clip_get_static_delegate;

        
        private delegate void efl_canvas_proxy_source_clip_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool source_clip);

        
        public delegate void efl_canvas_proxy_source_clip_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool source_clip);

        public static Efl.Eo.FunctionWrapper<efl_canvas_proxy_source_clip_set_api_delegate> efl_canvas_proxy_source_clip_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_proxy_source_clip_set_api_delegate>(Module, "efl_canvas_proxy_source_clip_set");

        private static void source_clip_set(System.IntPtr obj, System.IntPtr pd, bool source_clip)
        {
            Eina.Log.Debug("function efl_canvas_proxy_source_clip_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Proxy)ws.Target).SetSourceClip(source_clip);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_proxy_source_clip_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), source_clip);
            }
        }

        private static efl_canvas_proxy_source_clip_set_delegate efl_canvas_proxy_source_clip_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_proxy_source_events_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_proxy_source_events_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_proxy_source_events_get_api_delegate> efl_canvas_proxy_source_events_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_proxy_source_events_get_api_delegate>(Module, "efl_canvas_proxy_source_events_get");

        private static bool source_events_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_proxy_source_events_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Proxy)ws.Target).GetSourceEvents();
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
                return efl_canvas_proxy_source_events_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_proxy_source_events_get_delegate efl_canvas_proxy_source_events_get_static_delegate;

        
        private delegate void efl_canvas_proxy_source_events_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool repeat);

        
        public delegate void efl_canvas_proxy_source_events_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool repeat);

        public static Efl.Eo.FunctionWrapper<efl_canvas_proxy_source_events_set_api_delegate> efl_canvas_proxy_source_events_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_proxy_source_events_set_api_delegate>(Module, "efl_canvas_proxy_source_events_set");

        private static void source_events_set(System.IntPtr obj, System.IntPtr pd, bool repeat)
        {
            Eina.Log.Debug("function efl_canvas_proxy_source_events_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Proxy)ws.Target).SetSourceEvents(repeat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_proxy_source_events_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), repeat);
            }
        }

        private static efl_canvas_proxy_source_events_set_delegate efl_canvas_proxy_source_events_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

