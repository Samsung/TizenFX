/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
/// <param name="kw_object">The object the callback is being triggered from.</param>
/// <param name="emission">The name component of the signal.</param>
/// <param name="source">The source of a signal used as context.</param>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public delegate void CoreUILayoutSignalCb(CoreUI.Layout.ISignal kw_object, System.String emission, System.String source);
internal delegate void CoreUILayoutSignalCbInternal(IntPtr data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Layout.ISignal kw_object, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String source);
internal class CoreUILayoutSignalCbWrapper
{

    private CoreUILayoutSignalCbInternal _cb;
    private IntPtr _cb_data;
    private CoreUI.DataTypes.Callbacks.EinaFreeCb _cb_free_cb;

    internal CoreUILayoutSignalCbWrapper (CoreUILayoutSignalCbInternal _cb, IntPtr _cb_data, CoreUI.DataTypes.Callbacks.EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~CoreUILayoutSignalCbWrapper()
    {
        if (this._cb_free_cb != null)
        {
            CoreUI.Wrapper.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
        }
    }

    internal void ManagedCb(CoreUI.Layout.ISignal kw_object, System.String emission, System.String source)
    {
_cb(_cb_data, kw_object, emission, source);
CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
    }

        internal static void Cb(IntPtr cb_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Layout.ISignal kw_object, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String source)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        CoreUILayoutSignalCb cb = (CoreUILayoutSignalCb)handle.Target;
        try {
            cb(kw_object, emission, source);
        } catch (Exception e) {
            CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
            CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
        }
            }
}
namespace CoreUI.Layout {
    /// <summary>Layouts asynchronous messaging and signaling interface.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Layout.ISignalNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface ISignal : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Sends an (Edje) message to a given Edje object
        /// 
        /// This function sends an Edje message to obj and to all of its child objects, if it has any (swallowed objects are one kind of child object). Only a few types are supported: - int, - float/double, - string/stringshare, - arrays of int, float, double or strings.
        /// 
        /// Messages can go both ways, from code to theme, or theme to code.
        /// 
        /// The id argument as a form of code and theme defining a common interface on message communication. One should define the same IDs on both code and EDC declaration, to individualize messages (binding them to a given context).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="id">A identification number for the message to be sent</param>
        /// <param name="msg">The message&apos;s payload</param>
        void SendMessage(int id, CoreUI.DataTypes.Value msg);

        /// <summary>Adds a callback for an arriving Edje signal, emitted by a given Edje object.
        /// 
        /// Edje signals are one of the communication interfaces between code and a given Edje object&apos;s theme. With signals, one can communicate two string values at a time, which are: - &quot;emission&quot; value: the name of the signal, in general - &quot;source&quot; value: a name for the signal&apos;s context, in general
        /// 
        /// Signals can go both ways, from code to theme, or theme to code.
        /// 
        /// Though there are those common uses for the two strings, one is free to use them however they like.
        /// 
        /// Signal callback registration is powerful, in the way that blobs may be used to match multiple signals at once. All the &quot;*?[" set of <c>fnmatch</c>() operators can be used, both for emission and source.
        /// 
        /// Edje has internal signals it will emit, automatically, on various actions taking place on group parts. For example, the mouse cursor being moved, pressed, released, etc., over a given part&apos;s area, all generate individual signals.
        /// 
        /// With something like emission = &quot;mouse,down,*&quot;, source = &quot;button.*&quot; where &quot;button.*&quot; is the pattern for the names of parts implementing buttons on an interface, you&apos;d be registering for notifications on events of mouse buttons being pressed down on either of those parts (those events all have the &quot;mouse,down,&quot; common prefix on their names, with a suffix giving the button number). The actual emission and source strings of an event will be passed in as the emission and source parameters of the callback function (e.g. &quot;mouse,down,2&quot; and &quot;button.close&quot;), for each of those events.
        /// 
        /// See also the Edje Data Collection Reference for EDC files.
        /// 
        /// See <see cref="CoreUI.Layout.ISignal.EmitSignal"/> on how to emit signals from code to a an object See <see cref="CoreUI.Layout.ISignal.DelSignalCallback"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
        /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
        /// <param name="func">The callback function to be executed when the signal is emitted.</param>
        /// <returns><c>true</c> in case of success, <c>false</c> in case of error.</returns>
        bool AddSignalCallback(System.String emission, System.String source, CoreUILayoutSignalCb func);

        /// <summary>Removes a signal-triggered callback from an object.
        /// 
        /// This function removes a callback, previously attached to the emission of a signal, from the object  obj. The parameters emission, source and func must match exactly those passed to a previous call to <see cref="CoreUI.Layout.ISignal.AddSignalCallback"/>.
        /// 
        /// See <see cref="CoreUI.Layout.ISignal.AddSignalCallback"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
        /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
        /// <param name="func">The callback function to be executed when the signal is emitted.</param>
        /// <returns><c>true</c> in case of success, <c>false</c> in case of error.</returns>
        bool DelSignalCallback(System.String emission, System.String source, CoreUILayoutSignalCb func);

        /// <summary>Sends/emits an Edje signal to this layout.
        /// 
        /// This function sends a signal to the object. An Edje program, at the EDC specification level, can respond to a signal by having declared matching &quot;signal&quot; and &quot;source&quot; fields on its block.
        /// 
        /// See also the Edje Data Collection Reference for EDC files.
        /// 
        /// See <see cref="CoreUI.Layout.ISignal.AddSignalCallback"/> for more on Edje signals.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
        /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
        void EmitSignal(System.String emission, System.String source);

        /// <summary>Processes an object&apos;s messages and signals queue.
        /// 
        /// This function goes through the object message queue processing the pending messages for this specific Edje object. Normally they&apos;d be processed only at idle time.
        /// 
        /// If <c>recurse</c> is <c>true</c>, this function will be called recursively on all subobjects.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="recurse">Whether to process messages on children objects.</param>
        void ProcessSignal(bool recurse);

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ISignalNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Edje)] internal static extern System.IntPtr
            efl_layout_signal_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Edje);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_layout_signal_message_send_static_delegate == null)
            {
                efl_layout_signal_message_send_static_delegate = new efl_layout_signal_message_send_delegate(message_send);
            }

            if (methods.Contains("SendMessage"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_message_send"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_message_send_static_delegate) });
            }

            if (efl_layout_signal_callback_add_static_delegate == null)
            {
                efl_layout_signal_callback_add_static_delegate = new efl_layout_signal_callback_add_delegate(signal_callback_add);
            }

            if (methods.Contains("AddSignalCallback"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_callback_add"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_callback_add_static_delegate) });
            }

            if (efl_layout_signal_callback_del_static_delegate == null)
            {
                efl_layout_signal_callback_del_static_delegate = new efl_layout_signal_callback_del_delegate(signal_callback_del);
            }

            if (methods.Contains("DelSignalCallback"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_callback_del"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_callback_del_static_delegate) });
            }

            if (efl_layout_signal_emit_static_delegate == null)
            {
                efl_layout_signal_emit_static_delegate = new efl_layout_signal_emit_delegate(signal_emit);
            }

            if (methods.Contains("EmitSignal"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_emit"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_emit_static_delegate) });
            }

            if (efl_layout_signal_process_static_delegate == null)
            {
                efl_layout_signal_process_static_delegate = new efl_layout_signal_process_delegate(signal_process);
            }

            if (methods.Contains("ProcessSignal"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_process"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_process_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return efl_layout_signal_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_layout_signal_message_send_delegate(System.IntPtr obj, System.IntPtr pd,  int id,  CoreUI.DataTypes.ValueNative msg);

        
        internal delegate void efl_layout_signal_message_send_api_delegate(System.IntPtr obj,  int id,  CoreUI.DataTypes.ValueNative msg);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_signal_message_send_api_delegate> efl_layout_signal_message_send_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_signal_message_send_api_delegate>(Module, "efl_layout_signal_message_send");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void message_send(System.IntPtr obj, System.IntPtr pd, int id, CoreUI.DataTypes.ValueNative msg)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_signal_message_send was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ISignal)ws.Target).SendMessage(id, msg);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_layout_signal_message_send_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), id, msg);
            }
        }

        private static efl_layout_signal_message_send_delegate efl_layout_signal_message_send_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_layout_signal_callback_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String source,  IntPtr func_data, CoreUILayoutSignalCbInternal func, CoreUI.DataTypes.Callbacks.EinaFreeCb func_free_cb);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_layout_signal_callback_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String source,  IntPtr func_data, CoreUILayoutSignalCbInternal func, CoreUI.DataTypes.Callbacks.EinaFreeCb func_free_cb);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_signal_callback_add_api_delegate> efl_layout_signal_callback_add_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_signal_callback_add_api_delegate>(Module, "efl_layout_signal_callback_add");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool signal_callback_add(System.IntPtr obj, System.IntPtr pd, System.String emission, System.String source, IntPtr func_data, CoreUILayoutSignalCbInternal func, CoreUI.DataTypes.Callbacks.EinaFreeCb func_free_cb)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_signal_callback_add was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                    CoreUILayoutSignalCbWrapper func_wrapper = new CoreUILayoutSignalCbWrapper(func, func_data, func_free_cb);
bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISignal)ws.Target).AddSignalCallback(emission, source, func_wrapper.ManagedCb);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_layout_signal_callback_add_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), emission, source, func_data, func, func_free_cb);
            }
        }

        private static efl_layout_signal_callback_add_delegate efl_layout_signal_callback_add_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_layout_signal_callback_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String source,  IntPtr func_data, CoreUILayoutSignalCbInternal func, CoreUI.DataTypes.Callbacks.EinaFreeCb func_free_cb);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_layout_signal_callback_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String source,  IntPtr func_data, CoreUILayoutSignalCbInternal func, CoreUI.DataTypes.Callbacks.EinaFreeCb func_free_cb);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_signal_callback_del_api_delegate> efl_layout_signal_callback_del_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_signal_callback_del_api_delegate>(Module, "efl_layout_signal_callback_del");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool signal_callback_del(System.IntPtr obj, System.IntPtr pd, System.String emission, System.String source, IntPtr func_data, CoreUILayoutSignalCbInternal func, CoreUI.DataTypes.Callbacks.EinaFreeCb func_free_cb)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_signal_callback_del was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                    CoreUILayoutSignalCbWrapper func_wrapper = new CoreUILayoutSignalCbWrapper(func, func_data, func_free_cb);
bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISignal)ws.Target).DelSignalCallback(emission, source, func_wrapper.ManagedCb);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_layout_signal_callback_del_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), emission, source, func_data, func, func_free_cb);
            }
        }

        private static efl_layout_signal_callback_del_delegate efl_layout_signal_callback_del_static_delegate;

        
        private delegate void efl_layout_signal_emit_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String source);

        
        internal delegate void efl_layout_signal_emit_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String source);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_signal_emit_api_delegate> efl_layout_signal_emit_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_signal_emit_api_delegate>(Module, "efl_layout_signal_emit");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void signal_emit(System.IntPtr obj, System.IntPtr pd, System.String emission, System.String source)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_signal_emit was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ISignal)ws.Target).EmitSignal(emission, source);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_layout_signal_emit_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), emission, source);
            }
        }

        private static efl_layout_signal_emit_delegate efl_layout_signal_emit_static_delegate;

        
        private delegate void efl_layout_signal_process_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool recurse);

        
        internal delegate void efl_layout_signal_process_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool recurse);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_signal_process_api_delegate> efl_layout_signal_process_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_signal_process_api_delegate>(Module, "efl_layout_signal_process");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void signal_process(System.IntPtr obj, System.IntPtr pd, bool recurse)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_signal_process was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ISignal)ws.Target).ProcessSignal(recurse);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_layout_signal_process_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), recurse);
            }
        }

        private static efl_layout_signal_process_delegate efl_layout_signal_process_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

