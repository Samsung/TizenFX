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
namespace CoreUI {
    /// <summary>Interface for interactive (editable) text inputs (text entries).
    /// 
    /// It handles cursors, edition and selection.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.ITextInteractiveNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface ITextInteractive : 
    CoreUI.IText,
    CoreUI.ITextFontProperties,
    CoreUI.ITextFormat,
    CoreUI.ITextStyle,
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>The cursor used to insert new text, the one that&apos;s visible to the user.</summary>
        /// <returns>The cursor visible to the user.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Text.Cursor GetMainCursor();

        /// <summary>Whether or not text selection is allowed on this object.</summary>
        /// <returns><c>true</c> if enabled.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetSelectionAllowed();

        /// <summary>Whether or not text selection is allowed on this object.</summary>
        /// <param name="allowed"><c>true</c> if enabled.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetSelectionAllowed(bool allowed);

        /// <summary>The cursors used for selection handling. If the cursors are equal there&apos;s no selection.<br/>
        /// <b>Note:</b> You are allowed to retain and modify them. Modifying them modifies the selection of the object (recommended to extend selection range).</summary>
        /// <param name="start">The start of the selection.</param>
        /// <param name="end">The end of the selection.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetSelectionCursors(out CoreUI.Text.Cursor start, out CoreUI.Text.Cursor end);

        /// <summary>The cursors used for selection handling. If the cursors are equal there&apos;s no selection.<br/>
        /// <b>Note:</b> The positions of passed cursors will be used to set selection cursors positions. Further modification for passed <see cref="CoreUI.Text.Cursor"/> objects, will not affect selection. Setter is recommended to set new range for selection.</summary>
        /// <param name="start">The start of the selection.</param>
        /// <param name="end">The end of the selection.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetSelectionCursors(CoreUI.Text.Cursor start, CoreUI.Text.Cursor end);

        /// <summary>Whether the entry is editable.
        /// 
        /// By default interactive text objects are editable. Setting this property to <c>false</c> will disregard all keyboard input.</summary>
        /// <returns>If <c>true</c>, user input can modify the text. Otherwise, the entry is read-only and no user input is allowed.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetEditable();

        /// <summary>Whether the entry is editable.
        /// 
        /// By default interactive text objects are editable. Setting this property to <c>false</c> will disregard all keyboard input.</summary>
        /// <param name="editable">If <c>true</c>, user input can modify the text. Otherwise, the entry is read-only and no user input is allowed.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetEditable(bool editable);

        /// <summary>Whether the entry has a selected text.</summary>
        /// <returns>If <c>true</c>, entry has selected text.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetHaveSelection();

        /// <summary>Clears the selection.</summary>
        /// <since_tizen> 6 </since_tizen>
        void UnselectAll();

        /// <summary>Select all the content.</summary>
        /// <since_tizen> 6 </since_tizen>
        void SelectAll();

        /// <summary>Emitted when key presses do not result in a new character being added. Multiple key presses are needed to produce a character in some languages like Korean, for example. Each of these key presses will emit a @[.preedit,changed] event but only the last one will emit a @[.changed,user] event.</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler PreeditChanged;
        /// <summary>Emitted when the <see cref="CoreUI.ITextInteractive.GetHaveSelection"/> property value changes.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.TextInteractiveHaveSelectionChangedEventArgs"/></value>
        event EventHandler<CoreUI.TextInteractiveHaveSelectionChangedEventArgs> HaveSelectionChanged;
        /// <summary>Emitted when selection has changed. Query using <see cref="CoreUI.ITextInteractive.SelectionCursors"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.TextInteractiveSelectionChangedEventArgs"/></value>
        event EventHandler<CoreUI.TextInteractiveSelectionChangedEventArgs> SelectionChanged;
        /// <summary>Emitted when a redo operation is requested.</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler RedoRequest;
        /// <summary>Emitted when a undo operation is requested.</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler UndoRequest;
        /// <summary>Emitted when the text content has changed due to user interaction.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.TextInteractiveChangedUserEventArgs"/></value>
        event EventHandler<CoreUI.TextInteractiveChangedUserEventArgs> ChangedUser;
        /// <summary>The cursor used to insert new text, the one that&apos;s visible to the user.</summary>
        /// <value>The cursor visible to the user.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Text.Cursor MainCursor {
            get;
        }

        /// <summary>Whether or not text selection is allowed on this object.</summary>
        /// <value><c>true</c> if enabled.</value>
        /// <since_tizen> 6 </since_tizen>
        bool SelectionAllowed {
            get;
            set;
        }

        /// <summary>The cursors used for selection handling. If the cursors are equal there&apos;s no selection.<br/>
        /// <b>Note on writing:</b> The positions of passed cursors will be used to set selection cursors positions. Further modification for passed <see cref="CoreUI.Text.Cursor"/> objects, will not affect selection. Setter is recommended to set new range for selection.<br/>
        /// <b>Note on reading:</b> You are allowed to retain and modify them. Modifying them modifies the selection of the object (recommended to extend selection range).</summary>
        /// <value>The start of the selection.</value>
        /// <since_tizen> 6 </since_tizen>
        (CoreUI.Text.Cursor, CoreUI.Text.Cursor) SelectionCursors {
            get;
            set;
        }

        /// <summary>Whether the entry is editable.
        /// 
        /// By default interactive text objects are editable. Setting this property to <c>false</c> will disregard all keyboard input.</summary>
        /// <value>If <c>true</c>, user input can modify the text. Otherwise, the entry is read-only and no user input is allowed.</value>
        /// <since_tizen> 6 </since_tizen>
        bool Editable {
            get;
            set;
        }

        /// <summary>Whether the entry has a selected text.</summary>
        /// <value>If <c>true</c>, entry has selected text.</value>
        /// <since_tizen> 6 </since_tizen>
        bool HaveSelection {
            get;
        }

    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.ITextInteractive.HaveSelectionChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class TextInteractiveHaveSelectionChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Emitted when the <see cref="CoreUI.ITextInteractive.GetHaveSelection"/> property value changes.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.ITextInteractive.SelectionChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class TextInteractiveSelectionChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Emitted when selection has changed. Query using <see cref="CoreUI.ITextInteractive.SelectionCursors"/>.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Range Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.ITextInteractive.ChangedUser"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class TextInteractiveChangedUserEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Emitted when the text content has changed due to user interaction.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.TextChangeInfo Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ITextInteractiveNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_text_interactive_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_text_interactive_main_cursor_get_static_delegate == null)
            {
                efl_text_interactive_main_cursor_get_static_delegate = new efl_text_interactive_main_cursor_get_delegate(main_cursor_get);
            }

            if (methods.Contains("GetMainCursor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_main_cursor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_main_cursor_get_static_delegate) });
            }

            if (efl_text_interactive_selection_allowed_get_static_delegate == null)
            {
                efl_text_interactive_selection_allowed_get_static_delegate = new efl_text_interactive_selection_allowed_get_delegate(selection_allowed_get);
            }

            if (methods.Contains("GetSelectionAllowed"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_selection_allowed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_allowed_get_static_delegate) });
            }

            if (efl_text_interactive_selection_allowed_set_static_delegate == null)
            {
                efl_text_interactive_selection_allowed_set_static_delegate = new efl_text_interactive_selection_allowed_set_delegate(selection_allowed_set);
            }

            if (methods.Contains("SetSelectionAllowed"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_selection_allowed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_allowed_set_static_delegate) });
            }

            if (efl_text_interactive_selection_cursors_get_static_delegate == null)
            {
                efl_text_interactive_selection_cursors_get_static_delegate = new efl_text_interactive_selection_cursors_get_delegate(selection_cursors_get);
            }

            if (methods.Contains("GetSelectionCursors"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_selection_cursors_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_cursors_get_static_delegate) });
            }

            if (efl_text_interactive_selection_cursors_set_static_delegate == null)
            {
                efl_text_interactive_selection_cursors_set_static_delegate = new efl_text_interactive_selection_cursors_set_delegate(selection_cursors_set);
            }

            if (methods.Contains("SetSelectionCursors"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_selection_cursors_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_cursors_set_static_delegate) });
            }

            if (efl_text_interactive_editable_get_static_delegate == null)
            {
                efl_text_interactive_editable_get_static_delegate = new efl_text_interactive_editable_get_delegate(editable_get);
            }

            if (methods.Contains("GetEditable"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_editable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_editable_get_static_delegate) });
            }

            if (efl_text_interactive_editable_set_static_delegate == null)
            {
                efl_text_interactive_editable_set_static_delegate = new efl_text_interactive_editable_set_delegate(editable_set);
            }

            if (methods.Contains("SetEditable"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_editable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_editable_set_static_delegate) });
            }

            if (efl_text_interactive_have_selection_get_static_delegate == null)
            {
                efl_text_interactive_have_selection_get_static_delegate = new efl_text_interactive_have_selection_get_delegate(have_selection_get);
            }

            if (methods.Contains("GetHaveSelection"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_have_selection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_have_selection_get_static_delegate) });
            }

            if (efl_text_interactive_all_unselect_static_delegate == null)
            {
                efl_text_interactive_all_unselect_static_delegate = new efl_text_interactive_all_unselect_delegate(all_unselect);
            }

            if (methods.Contains("UnselectAll"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_all_unselect"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_all_unselect_static_delegate) });
            }

            if (efl_text_interactive_all_select_static_delegate == null)
            {
                efl_text_interactive_all_select_static_delegate = new efl_text_interactive_all_select_delegate(all_select);
            }

            if (methods.Contains("SelectAll"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_all_select"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_all_select_static_delegate) });
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
            return efl_text_interactive_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.Text.Cursor efl_text_interactive_main_cursor_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.Text.Cursor efl_text_interactive_main_cursor_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_main_cursor_get_api_delegate> efl_text_interactive_main_cursor_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_main_cursor_get_api_delegate>(Module, "efl_text_interactive_main_cursor_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Text.Cursor main_cursor_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_interactive_main_cursor_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Text.Cursor _ret_var = default(CoreUI.Text.Cursor);
                try
                {
                    _ret_var = ((ITextInteractive)ws.Target).GetMainCursor();
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
                return efl_text_interactive_main_cursor_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_interactive_main_cursor_get_delegate efl_text_interactive_main_cursor_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_interactive_selection_allowed_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_text_interactive_selection_allowed_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_selection_allowed_get_api_delegate> efl_text_interactive_selection_allowed_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_selection_allowed_get_api_delegate>(Module, "efl_text_interactive_selection_allowed_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool selection_allowed_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_interactive_selection_allowed_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextInteractive)ws.Target).GetSelectionAllowed();
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
                return efl_text_interactive_selection_allowed_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_interactive_selection_allowed_get_delegate efl_text_interactive_selection_allowed_get_static_delegate;

        
        private delegate void efl_text_interactive_selection_allowed_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool allowed);

        
        internal delegate void efl_text_interactive_selection_allowed_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool allowed);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_selection_allowed_set_api_delegate> efl_text_interactive_selection_allowed_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_selection_allowed_set_api_delegate>(Module, "efl_text_interactive_selection_allowed_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void selection_allowed_set(System.IntPtr obj, System.IntPtr pd, bool allowed)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_interactive_selection_allowed_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextInteractive)ws.Target).SetSelectionAllowed(allowed);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_interactive_selection_allowed_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), allowed);
            }
        }

        private static efl_text_interactive_selection_allowed_set_delegate efl_text_interactive_selection_allowed_set_static_delegate;

        
        private delegate void efl_text_interactive_selection_cursors_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] out CoreUI.Text.Cursor start, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] out CoreUI.Text.Cursor end);

        
        internal delegate void efl_text_interactive_selection_cursors_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] out CoreUI.Text.Cursor start, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] out CoreUI.Text.Cursor end);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_selection_cursors_get_api_delegate> efl_text_interactive_selection_cursors_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_selection_cursors_get_api_delegate>(Module, "efl_text_interactive_selection_cursors_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void selection_cursors_get(System.IntPtr obj, System.IntPtr pd, out CoreUI.Text.Cursor start, out CoreUI.Text.Cursor end)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_interactive_selection_cursors_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                start = default(CoreUI.Text.Cursor);end = default(CoreUI.Text.Cursor);
                try
                {
                    ((ITextInteractive)ws.Target).GetSelectionCursors(out start, out end);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_interactive_selection_cursors_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out start, out end);
            }
        }

        private static efl_text_interactive_selection_cursors_get_delegate efl_text_interactive_selection_cursors_get_static_delegate;

        
        private delegate void efl_text_interactive_selection_cursors_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor start, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor end);

        
        internal delegate void efl_text_interactive_selection_cursors_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor start, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor end);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_selection_cursors_set_api_delegate> efl_text_interactive_selection_cursors_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_selection_cursors_set_api_delegate>(Module, "efl_text_interactive_selection_cursors_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void selection_cursors_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Text.Cursor start, CoreUI.Text.Cursor end)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_interactive_selection_cursors_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextInteractive)ws.Target).SetSelectionCursors(start, end);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_interactive_selection_cursors_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), start, end);
            }
        }

        private static efl_text_interactive_selection_cursors_set_delegate efl_text_interactive_selection_cursors_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_interactive_editable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_text_interactive_editable_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_editable_get_api_delegate> efl_text_interactive_editable_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_editable_get_api_delegate>(Module, "efl_text_interactive_editable_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool editable_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_interactive_editable_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextInteractive)ws.Target).GetEditable();
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
                return efl_text_interactive_editable_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_interactive_editable_get_delegate efl_text_interactive_editable_get_static_delegate;

        
        private delegate void efl_text_interactive_editable_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool editable);

        
        internal delegate void efl_text_interactive_editable_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool editable);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_editable_set_api_delegate> efl_text_interactive_editable_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_editable_set_api_delegate>(Module, "efl_text_interactive_editable_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void editable_set(System.IntPtr obj, System.IntPtr pd, bool editable)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_interactive_editable_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextInteractive)ws.Target).SetEditable(editable);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_interactive_editable_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), editable);
            }
        }

        private static efl_text_interactive_editable_set_delegate efl_text_interactive_editable_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_interactive_have_selection_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_text_interactive_have_selection_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_have_selection_get_api_delegate> efl_text_interactive_have_selection_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_have_selection_get_api_delegate>(Module, "efl_text_interactive_have_selection_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool have_selection_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_interactive_have_selection_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextInteractive)ws.Target).GetHaveSelection();
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
                return efl_text_interactive_have_selection_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_interactive_have_selection_get_delegate efl_text_interactive_have_selection_get_static_delegate;

        
        private delegate void efl_text_interactive_all_unselect_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_text_interactive_all_unselect_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_all_unselect_api_delegate> efl_text_interactive_all_unselect_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_all_unselect_api_delegate>(Module, "efl_text_interactive_all_unselect");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void all_unselect(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_interactive_all_unselect was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextInteractive)ws.Target).UnselectAll();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_interactive_all_unselect_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_interactive_all_unselect_delegate efl_text_interactive_all_unselect_static_delegate;

        
        private delegate void efl_text_interactive_all_select_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_text_interactive_all_select_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_all_select_api_delegate> efl_text_interactive_all_select_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_interactive_all_select_api_delegate>(Module, "efl_text_interactive_all_select");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void all_select(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_interactive_all_select was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextInteractive)ws.Target).SelectAll();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_interactive_all_select_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_interactive_all_select_delegate efl_text_interactive_all_select_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class TextInteractiveExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> SelectionAllowed<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<bool>("selection_allowed", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Editable<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<bool>("editable", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> Text<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<System.String>("text", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> FontFamily<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<System.String>("font_family", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Font.Size> FontSize<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<CoreUI.Font.Size>("font_size", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> FontSource<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<System.String>("font_source", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> FontFallbacks<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<System.String>("font_fallbacks", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextFontWeight> FontWeight<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<CoreUI.TextFontWeight>("font_weight", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextFontSlant> FontSlant<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<CoreUI.TextFontSlant>("font_slant", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextFontWidth> FontWidth<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<CoreUI.TextFontWidth>("font_width", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> FontLang<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<System.String>("font_lang", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextFontBitmapScalable> FontBitmapScalable<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<CoreUI.TextFontBitmapScalable>("font_bitmap_scalable", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> Ellipsis<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<double>("ellipsis", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextFormatWrap> Wrap<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<CoreUI.TextFormatWrap>("wrap", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Multiline<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<bool>("multiline", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextFormatHorizontalAlignmentAutoType> TextHorizontalAlignAutoType<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<CoreUI.TextFormatHorizontalAlignmentAutoType>("text_horizontal_align_auto_type", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> TextHorizontalAlign<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<double>("text_horizontal_align", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> TextVerticalAlign<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<double>("text_vertical_align", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> LineGap<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<double>("line_gap", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> LineRelGap<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<double>("line_rel_gap", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> TabStops<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<int>("tab_stops", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Password<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<bool>("password", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> ReplacementChar<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<System.String>("replacement_char", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextStyleBackgroundType> TextBackgroundType<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<CoreUI.TextStyleBackgroundType>("text_background_type", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextStyleUnderlineType> TextUnderlineType<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<CoreUI.TextStyleUnderlineType>("text_underline_type", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> TextUnderlineHeight<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<double>("text_underline_height", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> TextUnderlineDashedWidth<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<int>("text_underline_dashed_width", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> TextUnderlineDashedGap<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<int>("text_underline_dashed_gap", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextStyleStrikethroughType> TextStrikethroughType<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<CoreUI.TextStyleStrikethroughType>("text_strikethrough_type", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextStyleEffectType> TextEffectType<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<CoreUI.TextStyleEffectType>("text_effect_type", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextStyleShadowDirection> TextShadowDirection<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<CoreUI.TextStyleShadowDirection>("text_shadow_direction", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> TextGfxFilter<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextInteractive, T>magic = null) where T : CoreUI.ITextInteractive {
            return new CoreUI.BindableProperty<System.String>("text_gfx_filter", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

