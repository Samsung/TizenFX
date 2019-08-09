#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
/// <param name="kw_object">The object the callback is being triggered from.</param>
/// <param name="emission">The name component of the signal.</param>
/// <param name="source">The source of a signal used as context.</param>
[Efl.Eo.BindingEntity]
public delegate void EflLayoutSignalCb(Efl.Layout.ISignal kw_object, System.String emission, System.String source);
public delegate void EflLayoutSignalCbInternal(IntPtr data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Layout.ISignal kw_object, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source);
internal class EflLayoutSignalCbWrapper : IDisposable
{

    private EflLayoutSignalCbInternal _cb;
    private IntPtr _cb_data;
    private EinaFreeCb _cb_free_cb;

    internal EflLayoutSignalCbWrapper (EflLayoutSignalCbInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~EflLayoutSignalCbWrapper()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this._cb_free_cb != null)
        {
            if (disposing)
            {
                this._cb_free_cb(this._cb_data);
            }
            else
            {
                Efl.Eo.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
            }
            this._cb_free_cb = null;
            this._cb_data = IntPtr.Zero;
            this._cb = null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    internal void ManagedCb(Efl.Layout.ISignal kw_object,System.String emission,System.String source)
    {
                                                                                _cb(_cb_data, kw_object, emission, source);
        Eina.Error.RaiseIfUnhandledException();
                                                            }

        internal static void Cb(IntPtr cb_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Layout.ISignal kw_object, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        EflLayoutSignalCb cb = (EflLayoutSignalCb)handle.Target;
                                                                                    
        try {
            cb(kw_object, emission, source);
        } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
                                                            }
}


namespace Efl {

namespace Layout {

/// <summary>Layouts asynchronous messaging and signaling interface.
/// (Since EFL 1.22)</summary>
[Efl.Layout.ISignalConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface ISignal : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Sends an (Edje) message to a given Edje object
/// This function sends an Edje message to obj and to all of its child objects, if it has any (swallowed objects are one kind of child object). Only a few types are supported: - int, - float/double, - string/stringshare, - arrays of int, float, double or strings.
/// 
/// Messages can go both ways, from code to theme, or theme to code.
/// 
/// The id argument as a form of code and theme defining a common interface on message communication. One should define the same IDs on both code and EDC declaration, to individualize messages (binding them to a given context).
/// (Since EFL 1.22)</summary>
/// <param name="id">A identification number for the message to be sent</param>
/// <param name="msg">The message&apos;s payload</param>
void MessageSend(int id, Eina.Value msg);
    /// <summary>Adds a callback for an arriving Edje signal, emitted by a given Edje object.
/// Edje signals are one of the communication interfaces between code and a given Edje object&apos;s theme. With signals, one can communicate two string values at a time, which are: - &quot;emission&quot; value: the name of the signal, in general - &quot;source&quot; value: a name for the signal&apos;s context, in general
/// 
/// Signals can go both ways, from code to theme, or theme to code.
/// 
/// Though there are those common uses for the two strings, one is free to use them however they like.
/// 
/// Signal callback registration is powerful, in the way that blobs may be used to match multiple signals at once. All the &quot;*?[&quot; set of <c>fnmatch</c>() operators can be used, both for emission and source.
/// 
/// Edje has internal signals it will emit, automatically, on various actions taking place on group parts. For example, the mouse cursor being moved, pressed, released, etc., over a given part&apos;s area, all generate individual signals.
/// 
/// With something like emission = &quot;mouse,down,*&quot;, source = &quot;button.*&quot; where &quot;button.*&quot; is the pattern for the names of parts implementing buttons on an interface, you&apos;d be registering for notifications on events of mouse buttons being pressed down on either of those parts (those events all have the &quot;mouse,down,&quot; common prefix on their names, with a suffix giving the button number). The actual emission and source strings of an event will be passed in as the emission and source parameters of the callback function (e.g. &quot;mouse,down,2&quot; and &quot;button.close&quot;), for each of those events.
/// 
/// See also the Edje Data Collection Reference for EDC files.
/// 
/// See <see cref="Efl.Layout.ISignal.EmitSignal"/> on how to emit signals from code to a an object See <see cref="Efl.Layout.ISignal.DelSignalCallback"/>.
/// (Since EFL 1.22)</summary>
/// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
/// <param name="source">The signal&apos;s &quot;source&quot; string</param>
/// <param name="func">The callback function to be executed when the signal is emitted.</param>
/// <returns><c>true</c> in case of success, <c>false</c> in case of error.</returns>
bool AddSignalCallback(System.String emission, System.String source, EflLayoutSignalCb func);
    /// <summary>Removes a signal-triggered callback from an object.
/// This function removes a callback, previously attached to the emission of a signal, from the object  obj. The parameters emission, source and func must match exactly those passed to a previous call to <see cref="Efl.Layout.ISignal.AddSignalCallback"/>.
/// 
/// See <see cref="Efl.Layout.ISignal.AddSignalCallback"/>.
/// (Since EFL 1.22)</summary>
/// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
/// <param name="source">The signal&apos;s &quot;source&quot; string</param>
/// <param name="func">The callback function to be executed when the signal is emitted.</param>
/// <returns><c>true</c> in case of success, <c>false</c> in case of error.</returns>
bool DelSignalCallback(System.String emission, System.String source, EflLayoutSignalCb func);
    /// <summary>Sends/emits an Edje signal to this layout.
/// This function sends a signal to the object. An Edje program, at the EDC specification level, can respond to a signal by having declared matching &quot;signal&quot; and &quot;source&quot; fields on its block.
/// 
/// See also the Edje Data Collection Reference for EDC files.
/// 
/// See <see cref="Efl.Layout.ISignal.AddSignalCallback"/> for more on Edje signals.
/// (Since EFL 1.22)</summary>
/// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
/// <param name="source">The signal&apos;s &quot;source&quot; string</param>
void EmitSignal(System.String emission, System.String source);
    /// <summary>Processes an object&apos;s messages and signals queue.
/// This function goes through the object message queue processing the pending messages for this specific Edje object. Normally they&apos;d be processed only at idle time.
/// 
/// If <c>recurse</c> is <c>true</c>, this function will be called recursively on all subobjects.
/// (Since EFL 1.22)</summary>
/// <param name="recurse">Whether to process messages on children objects.</param>
void SignalProcess(bool recurse);
                    }
/// <summary>Layouts asynchronous messaging and signaling interface.
/// (Since EFL 1.22)</summary>
sealed public class ISignalConcrete :
    Efl.Eo.EoWrapper
    , ISignal
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ISignalConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private ISignalConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)] internal static extern System.IntPtr
        efl_layout_signal_interface_get();
    /// <summary>Initializes a new instance of the <see cref="ISignal"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ISignalConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Sends an (Edje) message to a given Edje object
    /// This function sends an Edje message to obj and to all of its child objects, if it has any (swallowed objects are one kind of child object). Only a few types are supported: - int, - float/double, - string/stringshare, - arrays of int, float, double or strings.
    /// 
    /// Messages can go both ways, from code to theme, or theme to code.
    /// 
    /// The id argument as a form of code and theme defining a common interface on message communication. One should define the same IDs on both code and EDC declaration, to individualize messages (binding them to a given context).
    /// (Since EFL 1.22)</summary>
    /// <param name="id">A identification number for the message to be sent</param>
    /// <param name="msg">The message&apos;s payload</param>
    public void MessageSend(int id, Eina.Value msg) {
                                                         Efl.Layout.ISignalConcrete.NativeMethods.efl_layout_signal_message_send_ptr.Value.Delegate(this.NativeHandle,id, msg);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Adds a callback for an arriving Edje signal, emitted by a given Edje object.
    /// Edje signals are one of the communication interfaces between code and a given Edje object&apos;s theme. With signals, one can communicate two string values at a time, which are: - &quot;emission&quot; value: the name of the signal, in general - &quot;source&quot; value: a name for the signal&apos;s context, in general
    /// 
    /// Signals can go both ways, from code to theme, or theme to code.
    /// 
    /// Though there are those common uses for the two strings, one is free to use them however they like.
    /// 
    /// Signal callback registration is powerful, in the way that blobs may be used to match multiple signals at once. All the &quot;*?[&quot; set of <c>fnmatch</c>() operators can be used, both for emission and source.
    /// 
    /// Edje has internal signals it will emit, automatically, on various actions taking place on group parts. For example, the mouse cursor being moved, pressed, released, etc., over a given part&apos;s area, all generate individual signals.
    /// 
    /// With something like emission = &quot;mouse,down,*&quot;, source = &quot;button.*&quot; where &quot;button.*&quot; is the pattern for the names of parts implementing buttons on an interface, you&apos;d be registering for notifications on events of mouse buttons being pressed down on either of those parts (those events all have the &quot;mouse,down,&quot; common prefix on their names, with a suffix giving the button number). The actual emission and source strings of an event will be passed in as the emission and source parameters of the callback function (e.g. &quot;mouse,down,2&quot; and &quot;button.close&quot;), for each of those events.
    /// 
    /// See also the Edje Data Collection Reference for EDC files.
    /// 
    /// See <see cref="Efl.Layout.ISignal.EmitSignal"/> on how to emit signals from code to a an object See <see cref="Efl.Layout.ISignal.DelSignalCallback"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
    /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
    /// <param name="func">The callback function to be executed when the signal is emitted.</param>
    /// <returns><c>true</c> in case of success, <c>false</c> in case of error.</returns>
    public bool AddSignalCallback(System.String emission, System.String source, EflLayoutSignalCb func) {
                                                                         GCHandle func_handle = GCHandle.Alloc(func);
        var _ret_var = Efl.Layout.ISignalConcrete.NativeMethods.efl_layout_signal_callback_add_ptr.Value.Delegate(this.NativeHandle,emission, source, GCHandle.ToIntPtr(func_handle), EflLayoutSignalCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Removes a signal-triggered callback from an object.
    /// This function removes a callback, previously attached to the emission of a signal, from the object  obj. The parameters emission, source and func must match exactly those passed to a previous call to <see cref="Efl.Layout.ISignal.AddSignalCallback"/>.
    /// 
    /// See <see cref="Efl.Layout.ISignal.AddSignalCallback"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
    /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
    /// <param name="func">The callback function to be executed when the signal is emitted.</param>
    /// <returns><c>true</c> in case of success, <c>false</c> in case of error.</returns>
    public bool DelSignalCallback(System.String emission, System.String source, EflLayoutSignalCb func) {
                                                                         GCHandle func_handle = GCHandle.Alloc(func);
        var _ret_var = Efl.Layout.ISignalConcrete.NativeMethods.efl_layout_signal_callback_del_ptr.Value.Delegate(this.NativeHandle,emission, source, GCHandle.ToIntPtr(func_handle), EflLayoutSignalCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Sends/emits an Edje signal to this layout.
    /// This function sends a signal to the object. An Edje program, at the EDC specification level, can respond to a signal by having declared matching &quot;signal&quot; and &quot;source&quot; fields on its block.
    /// 
    /// See also the Edje Data Collection Reference for EDC files.
    /// 
    /// See <see cref="Efl.Layout.ISignal.AddSignalCallback"/> for more on Edje signals.
    /// (Since EFL 1.22)</summary>
    /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
    /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
    public void EmitSignal(System.String emission, System.String source) {
                                                         Efl.Layout.ISignalConcrete.NativeMethods.efl_layout_signal_emit_ptr.Value.Delegate(this.NativeHandle,emission, source);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Processes an object&apos;s messages and signals queue.
    /// This function goes through the object message queue processing the pending messages for this specific Edje object. Normally they&apos;d be processed only at idle time.
    /// 
    /// If <c>recurse</c> is <c>true</c>, this function will be called recursively on all subobjects.
    /// (Since EFL 1.22)</summary>
    /// <param name="recurse">Whether to process messages on children objects.</param>
    public void SignalProcess(bool recurse) {
                                 Efl.Layout.ISignalConcrete.NativeMethods.efl_layout_signal_process_ptr.Value.Delegate(this.NativeHandle,recurse);
        Eina.Error.RaiseIfUnhandledException();
                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Layout.ISignalConcrete.efl_layout_signal_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Edje);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_layout_signal_message_send_static_delegate == null)
            {
                efl_layout_signal_message_send_static_delegate = new efl_layout_signal_message_send_delegate(message_send);
            }

            if (methods.FirstOrDefault(m => m.Name == "MessageSend") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_message_send"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_message_send_static_delegate) });
            }

            if (efl_layout_signal_callback_add_static_delegate == null)
            {
                efl_layout_signal_callback_add_static_delegate = new efl_layout_signal_callback_add_delegate(signal_callback_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddSignalCallback") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_callback_add"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_callback_add_static_delegate) });
            }

            if (efl_layout_signal_callback_del_static_delegate == null)
            {
                efl_layout_signal_callback_del_static_delegate = new efl_layout_signal_callback_del_delegate(signal_callback_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelSignalCallback") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_callback_del"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_callback_del_static_delegate) });
            }

            if (efl_layout_signal_emit_static_delegate == null)
            {
                efl_layout_signal_emit_static_delegate = new efl_layout_signal_emit_delegate(signal_emit);
            }

            if (methods.FirstOrDefault(m => m.Name == "EmitSignal") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_emit"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_emit_static_delegate) });
            }

            if (efl_layout_signal_process_static_delegate == null)
            {
                efl_layout_signal_process_static_delegate = new efl_layout_signal_process_delegate(signal_process);
            }

            if (methods.FirstOrDefault(m => m.Name == "SignalProcess") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_process"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_process_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Layout.ISignalConcrete.efl_layout_signal_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_layout_signal_message_send_delegate(System.IntPtr obj, System.IntPtr pd,  int id,  Eina.ValueNative msg);

        
        public delegate void efl_layout_signal_message_send_api_delegate(System.IntPtr obj,  int id,  Eina.ValueNative msg);

        public static Efl.Eo.FunctionWrapper<efl_layout_signal_message_send_api_delegate> efl_layout_signal_message_send_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_message_send_api_delegate>(Module, "efl_layout_signal_message_send");

        private static void message_send(System.IntPtr obj, System.IntPtr pd, int id, Eina.ValueNative msg)
        {
            Eina.Log.Debug("function efl_layout_signal_message_send was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ISignal)ws.Target).MessageSend(id, msg);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_layout_signal_message_send_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), id, msg);
            }
        }

        private static efl_layout_signal_message_send_delegate efl_layout_signal_message_send_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_layout_signal_callback_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_layout_signal_callback_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_layout_signal_callback_add_api_delegate> efl_layout_signal_callback_add_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_callback_add_api_delegate>(Module, "efl_layout_signal_callback_add");

        private static bool signal_callback_add(System.IntPtr obj, System.IntPtr pd, System.String emission, System.String source, IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb)
        {
            Eina.Log.Debug("function efl_layout_signal_callback_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                            EflLayoutSignalCbWrapper func_wrapper = new EflLayoutSignalCbWrapper(func, func_data, func_free_cb);
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISignal)ws.Target).AddSignalCallback(emission, source, func_wrapper.ManagedCb);
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
                return efl_layout_signal_callback_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), emission, source, func_data, func, func_free_cb);
            }
        }

        private static efl_layout_signal_callback_add_delegate efl_layout_signal_callback_add_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_layout_signal_callback_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_layout_signal_callback_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_layout_signal_callback_del_api_delegate> efl_layout_signal_callback_del_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_callback_del_api_delegate>(Module, "efl_layout_signal_callback_del");

        private static bool signal_callback_del(System.IntPtr obj, System.IntPtr pd, System.String emission, System.String source, IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb)
        {
            Eina.Log.Debug("function efl_layout_signal_callback_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                            EflLayoutSignalCbWrapper func_wrapper = new EflLayoutSignalCbWrapper(func, func_data, func_free_cb);
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISignal)ws.Target).DelSignalCallback(emission, source, func_wrapper.ManagedCb);
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
                return efl_layout_signal_callback_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), emission, source, func_data, func, func_free_cb);
            }
        }

        private static efl_layout_signal_callback_del_delegate efl_layout_signal_callback_del_static_delegate;

        
        private delegate void efl_layout_signal_emit_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source);

        
        public delegate void efl_layout_signal_emit_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source);

        public static Efl.Eo.FunctionWrapper<efl_layout_signal_emit_api_delegate> efl_layout_signal_emit_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_emit_api_delegate>(Module, "efl_layout_signal_emit");

        private static void signal_emit(System.IntPtr obj, System.IntPtr pd, System.String emission, System.String source)
        {
            Eina.Log.Debug("function efl_layout_signal_emit was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ISignal)ws.Target).EmitSignal(emission, source);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_layout_signal_emit_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), emission, source);
            }
        }

        private static efl_layout_signal_emit_delegate efl_layout_signal_emit_static_delegate;

        
        private delegate void efl_layout_signal_process_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool recurse);

        
        public delegate void efl_layout_signal_process_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool recurse);

        public static Efl.Eo.FunctionWrapper<efl_layout_signal_process_api_delegate> efl_layout_signal_process_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_process_api_delegate>(Module, "efl_layout_signal_process");

        private static void signal_process(System.IntPtr obj, System.IntPtr pd, bool recurse)
        {
            Eina.Log.Debug("function efl_layout_signal_process was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ISignal)ws.Target).SignalProcess(recurse);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_layout_signal_process_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), recurse);
            }
        }

        private static efl_layout_signal_process_delegate efl_layout_signal_process_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

