#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Access {

/// <summary>Elementary accessible text interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Access.TextConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IText : 
    Efl.Eo.IWrapper, IDisposable
{
                                                                                                                                                    /// <summary>Caret moved</summary>
    event EventHandler AccessTextCaretMovedEvent;
    /// <summary>Text was inserted</summary>
    /// <value><see cref="Efl.Access.TextAccessTextInsertedEventArgs"/></value>
    event EventHandler<Efl.Access.TextAccessTextInsertedEventArgs> AccessTextInsertedEvent;
    /// <summary>Text was removed</summary>
    /// <value><see cref="Efl.Access.TextAccessTextRemovedEventArgs"/></value>
    event EventHandler<Efl.Access.TextAccessTextRemovedEventArgs> AccessTextRemovedEvent;
    /// <summary>Text selection has changed</summary>
    event EventHandler AccessTextSelectionChangedEvent;
}
/// <summary>Event argument wrapper for event <see cref="Efl.Access.IText.AccessTextInsertedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextAccessTextInsertedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Text was inserted</value>
    public Efl.Access.TextChangeInfo arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Access.IText.AccessTextRemovedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextAccessTextRemovedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Text was removed</value>
    public Efl.Access.TextChangeInfo arg { get; set; }
}
/// <summary>Elementary accessible text interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class TextConcrete :
    Efl.Eo.EoWrapper
    , IText
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(TextConcrete))
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
    private TextConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_access_text_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IText"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private TextConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Caret moved</summary>
    public event EventHandler AccessTextCaretMovedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_CARET_MOVED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_CARET_MOVED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event AccessTextCaretMovedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAccessTextCaretMovedEvent(EventArgs e)
    {
        var key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_CARET_MOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Text was inserted</summary>
    /// <value><see cref="Efl.Access.TextAccessTextInsertedEventArgs"/></value>
    public event EventHandler<Efl.Access.TextAccessTextInsertedEventArgs> AccessTextInsertedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Access.TextAccessTextInsertedEventArgs args = new Efl.Access.TextAccessTextInsertedEventArgs();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_INSERTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_INSERTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event AccessTextInsertedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAccessTextInsertedEvent(Efl.Access.TextAccessTextInsertedEventArgs e)
    {
        var key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_INSERTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Text was removed</summary>
    /// <value><see cref="Efl.Access.TextAccessTextRemovedEventArgs"/></value>
    public event EventHandler<Efl.Access.TextAccessTextRemovedEventArgs> AccessTextRemovedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Access.TextAccessTextRemovedEventArgs args = new Efl.Access.TextAccessTextRemovedEventArgs();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_REMOVED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_REMOVED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event AccessTextRemovedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAccessTextRemovedEvent(Efl.Access.TextAccessTextRemovedEventArgs e)
    {
        var key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_REMOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Text selection has changed</summary>
    public event EventHandler AccessTextSelectionChangedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_SELECTION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event AccessTextSelectionChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAccessTextSelectionChangedEvent(EventArgs e)
    {
        var key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_SELECTION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
#pragma warning disable CS0628
    /// <summary>Gets single character present in accessible widget&apos;s text at given offset.</summary>
    /// <param name="offset">Position in text.</param>
    /// <returns>Character at offset. 0 when out-of bounds offset has been given. Codepoints between DC80 and DCFF indicate that string includes invalid UTF8 chars.</returns>
    protected Eina.Unicode GetCharacter(int offset) {
                                 var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_character_get_ptr.Value.Delegate(this.NativeHandle,offset);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Gets string, start and end offset in text according to given initial offset and granularity.</summary>
    /// <param name="granularity">Text granularity</param>
    /// <param name="start_offset">Offset indicating start of string according to given granularity. -1 in case of error.</param>
    /// <param name="end_offset">Offset indicating end of string according to given granularity. -1 in case of error.</param>
    /// <returns>Newly allocated UTF-8 encoded string. Must be free by a user.</returns>
    protected System.String GetString(Efl.Access.TextGranularity granularity, int start_offset, int end_offset) {
                 var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
        var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                                                        var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_string_get_ptr.Value.Delegate(this.NativeHandle,granularity, _in_start_offset, _in_end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Gets text of accessible widget.</summary>
    /// <param name="start_offset">Position in text.</param>
    /// <param name="end_offset">End offset of text.</param>
    /// <returns>UTF-8 encoded text.</returns>
    protected System.String GetAccessText(int start_offset, int end_offset) {
                                                         var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_get_ptr.Value.Delegate(this.NativeHandle,start_offset, end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Gets offset position of caret (cursor)</summary>
    /// <returns>Offset</returns>
    protected int GetCaretOffset() {
         var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_caret_offset_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Caret offset property</summary>
    /// <param name="offset">Offset</param>
    /// <returns><c>true</c> if caret was successfully moved, <c>false</c> otherwise.</returns>
    protected bool SetCaretOffset(int offset) {
                                 var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_caret_offset_set_ptr.Value.Delegate(this.NativeHandle,offset);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Indicate if a text attribute with a given name is set</summary>
    /// <param name="name">Text attribute name</param>
    /// <param name="start_offset">Position in text from which given attribute is set.</param>
    /// <param name="end_offset">Position in text to which given attribute is set.</param>
    /// <param name="value">Value of text attribute. Should be free()</param>
    /// <returns><c>true</c> if attribute name is set, <c>false</c> otherwise</returns>
    protected bool GetAttribute(System.String name, int start_offset, int end_offset, out System.String value) {
                 var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
        var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                                                                                var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_attribute_get_ptr.Value.Delegate(this.NativeHandle,name, _in_start_offset, _in_end_offset, out value);
        Eina.Error.RaiseIfUnhandledException();
                                                                        return _ret_var;
 }
    /// <summary>Gets list of all text attributes.</summary>
    /// <param name="start_offset">Start offset</param>
    /// <param name="end_offset">End offset</param>
    /// <returns>List of text attributes</returns>
    protected Eina.List<Efl.Access.TextAttribute> GetTextAttributes(int start_offset, int end_offset) {
         var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
        var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                                        var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_attributes_get_ptr.Value.Delegate(this.NativeHandle,_in_start_offset, _in_end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                        return new Eina.List<Efl.Access.TextAttribute>(_ret_var, true, true);
 }
    /// <summary>Default attributes</summary>
    /// <returns>List of default attributes</returns>
    protected Eina.List<Efl.Access.TextAttribute> GetDefaultAttributes() {
         var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_default_attributes_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Access.TextAttribute>(_ret_var, true, true);
 }
    /// <summary>Character extents</summary>
    /// <param name="offset">Offset</param>
    /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="rect">Extents rectangle</param>
    /// <returns><c>true</c> if character extents, <c>false</c> otherwise</returns>
    protected bool GetCharacterExtents(int offset, bool screen_coords, out Eina.Rect rect) {
                                                 var _out_rect = new Eina.Rect.NativeStruct();
                                var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_character_extents_get_ptr.Value.Delegate(this.NativeHandle,offset, screen_coords, out _out_rect);
        Eina.Error.RaiseIfUnhandledException();
                        rect = _out_rect;
                                return _ret_var;
 }
    /// <summary>Character count</summary>
    /// <returns>Character count</returns>
    protected int GetCharacterCount() {
         var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_character_count_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Offset at given point</summary>
    /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <returns>Offset</returns>
    protected int GetOffsetAtPoint(bool screen_coords, int x, int y) {
                                                                                 var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_offset_at_point_get_ptr.Value.Delegate(this.NativeHandle,screen_coords, x, y);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Bounded ranges</summary>
    /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="rect">Bounding box</param>
    /// <param name="xclip">xclip</param>
    /// <param name="yclip">yclip</param>
    /// <returns>List of ranges</returns>
    protected Eina.List<Efl.Access.TextRange> GetBoundedRanges(bool screen_coords, Eina.Rect rect, Efl.Access.TextClipType xclip, Efl.Access.TextClipType yclip) {
                 Eina.Rect.NativeStruct _in_rect = rect;
                                                                                        var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_bounded_ranges_get_ptr.Value.Delegate(this.NativeHandle,screen_coords, _in_rect, xclip, yclip);
        Eina.Error.RaiseIfUnhandledException();
                                                                        return new Eina.List<Efl.Access.TextRange>(_ret_var, true, true);
 }
    /// <summary>Range extents</summary>
    /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="start_offset">Start offset</param>
    /// <param name="end_offset">End offset</param>
    /// <param name="rect">Range rectangle</param>
    /// <returns><c>true</c> if range extents, <c>false</c> otherwise</returns>
    protected bool GetRangeExtents(bool screen_coords, int start_offset, int end_offset, out Eina.Rect rect) {
                                                                 var _out_rect = new Eina.Rect.NativeStruct();
                                        var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_range_extents_get_ptr.Value.Delegate(this.NativeHandle,screen_coords, start_offset, end_offset, out _out_rect);
        Eina.Error.RaiseIfUnhandledException();
                                rect = _out_rect;
                                        return _ret_var;
 }
    /// <summary>Selection count property</summary>
    /// <returns>Selection counter</returns>
    protected int GetSelectionsCount() {
         var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_selections_count_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Selection property</summary>
    /// <param name="selection_number">Selection number for identification</param>
    /// <param name="start_offset">Selection start offset</param>
    /// <param name="end_offset">Selection end offset</param>
    protected void GetAccessSelection(int selection_number, out int start_offset, out int end_offset) {
                                                                                 Efl.Access.TextConcrete.NativeMethods.efl_access_text_access_selection_get_ptr.Value.Delegate(this.NativeHandle,selection_number, out start_offset, out end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Selection property</summary>
    /// <param name="selection_number">Selection number for identification</param>
    /// <param name="start_offset">Selection start offset</param>
    /// <param name="end_offset">Selection end offset</param>
    /// <returns><c>true</c> if selection was set, <c>false</c> otherwise</returns>
    protected bool SetAccessSelection(int selection_number, int start_offset, int end_offset) {
                                                                                 var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_access_selection_set_ptr.Value.Delegate(this.NativeHandle,selection_number, start_offset, end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Add selection</summary>
    /// <param name="start_offset">Start selection from this offset</param>
    /// <param name="end_offset">End selection at this offset</param>
    /// <returns><c>true</c> if selection was added, <c>false</c> otherwise</returns>
    protected bool AddSelection(int start_offset, int end_offset) {
                                                         var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_selection_add_ptr.Value.Delegate(this.NativeHandle,start_offset, end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Remove selection</summary>
    /// <param name="selection_number">Selection number to be removed</param>
    /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
    protected bool SelectionRemove(int selection_number) {
                                 var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_selection_remove_ptr.Value.Delegate(this.NativeHandle,selection_number);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Caret offset property</summary>
    /// <value>Offset</value>
    protected int CaretOffset {
        get { return GetCaretOffset(); }
        set { SetCaretOffset(value); }
    }
    /// <summary>Default attributes</summary>
    /// <value>List of default attributes</value>
    protected Eina.List<Efl.Access.TextAttribute> DefaultAttributes {
        get { return GetDefaultAttributes(); }
    }
    /// <summary>Character count</summary>
    /// <value>Character count</value>
    protected int CharacterCount {
        get { return GetCharacterCount(); }
    }
    /// <summary>Selection count property</summary>
    /// <value>Selection counter</value>
    protected int SelectionsCount {
        get { return GetSelectionsCount(); }
    }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Access.TextConcrete.efl_access_text_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
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
            return Efl.Access.TextConcrete.efl_access_text_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Eina.Unicode efl_access_text_character_get_delegate(System.IntPtr obj, System.IntPtr pd,  int offset);

        
        public delegate Eina.Unicode efl_access_text_character_get_api_delegate(System.IntPtr obj,  int offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_character_get_api_delegate> efl_access_text_character_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_character_get_api_delegate>(Module, "efl_access_text_character_get");

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        private delegate System.String efl_access_text_string_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.TextGranularity granularity,  System.IntPtr start_offset,  System.IntPtr end_offset);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        public delegate System.String efl_access_text_string_get_api_delegate(System.IntPtr obj,  Efl.Access.TextGranularity granularity,  System.IntPtr start_offset,  System.IntPtr end_offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_string_get_api_delegate> efl_access_text_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_string_get_api_delegate>(Module, "efl_access_text_string_get");

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        private delegate System.String efl_access_text_get_delegate(System.IntPtr obj, System.IntPtr pd,  int start_offset,  int end_offset);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        public delegate System.String efl_access_text_get_api_delegate(System.IntPtr obj,  int start_offset,  int end_offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_get_api_delegate> efl_access_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_get_api_delegate>(Module, "efl_access_text_get");

        
        private delegate int efl_access_text_caret_offset_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_access_text_caret_offset_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_get_api_delegate> efl_access_text_caret_offset_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_get_api_delegate>(Module, "efl_access_text_caret_offset_get");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_text_caret_offset_set_delegate(System.IntPtr obj, System.IntPtr pd,  int offset);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_text_caret_offset_set_api_delegate(System.IntPtr obj,  int offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_set_api_delegate> efl_access_text_caret_offset_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_set_api_delegate>(Module, "efl_access_text_caret_offset_set");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_text_attribute_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name,  System.IntPtr start_offset,  System.IntPtr end_offset, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] out System.String value);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_text_attribute_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name,  System.IntPtr start_offset,  System.IntPtr end_offset, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] out System.String value);

        public static Efl.Eo.FunctionWrapper<efl_access_text_attribute_get_api_delegate> efl_access_text_attribute_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_attribute_get_api_delegate>(Module, "efl_access_text_attribute_get");

        
        private delegate System.IntPtr efl_access_text_attributes_get_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr start_offset,  System.IntPtr end_offset);

        
        public delegate System.IntPtr efl_access_text_attributes_get_api_delegate(System.IntPtr obj,  System.IntPtr start_offset,  System.IntPtr end_offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_attributes_get_api_delegate> efl_access_text_attributes_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_attributes_get_api_delegate>(Module, "efl_access_text_attributes_get");

        
        private delegate System.IntPtr efl_access_text_default_attributes_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_access_text_default_attributes_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_text_default_attributes_get_api_delegate> efl_access_text_default_attributes_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_default_attributes_get_api_delegate>(Module, "efl_access_text_default_attributes_get");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_text_character_extents_get_delegate(System.IntPtr obj, System.IntPtr pd,  int offset, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  out Eina.Rect.NativeStruct rect);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_text_character_extents_get_api_delegate(System.IntPtr obj,  int offset, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  out Eina.Rect.NativeStruct rect);

        public static Efl.Eo.FunctionWrapper<efl_access_text_character_extents_get_api_delegate> efl_access_text_character_extents_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_character_extents_get_api_delegate>(Module, "efl_access_text_character_extents_get");

        
        private delegate int efl_access_text_character_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_access_text_character_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_text_character_count_get_api_delegate> efl_access_text_character_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_character_count_get_api_delegate>(Module, "efl_access_text_character_count_get");

        
        private delegate int efl_access_text_offset_at_point_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int x,  int y);

        
        public delegate int efl_access_text_offset_at_point_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int x,  int y);

        public static Efl.Eo.FunctionWrapper<efl_access_text_offset_at_point_get_api_delegate> efl_access_text_offset_at_point_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_offset_at_point_get_api_delegate>(Module, "efl_access_text_offset_at_point_get");

        
        private delegate System.IntPtr efl_access_text_bounded_ranges_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  Eina.Rect.NativeStruct rect,  Efl.Access.TextClipType xclip,  Efl.Access.TextClipType yclip);

        
        public delegate System.IntPtr efl_access_text_bounded_ranges_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  Eina.Rect.NativeStruct rect,  Efl.Access.TextClipType xclip,  Efl.Access.TextClipType yclip);

        public static Efl.Eo.FunctionWrapper<efl_access_text_bounded_ranges_get_api_delegate> efl_access_text_bounded_ranges_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_bounded_ranges_get_api_delegate>(Module, "efl_access_text_bounded_ranges_get");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_text_range_extents_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int start_offset,  int end_offset,  out Eina.Rect.NativeStruct rect);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_text_range_extents_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int start_offset,  int end_offset,  out Eina.Rect.NativeStruct rect);

        public static Efl.Eo.FunctionWrapper<efl_access_text_range_extents_get_api_delegate> efl_access_text_range_extents_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_range_extents_get_api_delegate>(Module, "efl_access_text_range_extents_get");

        
        private delegate int efl_access_text_selections_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_access_text_selections_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_text_selections_count_get_api_delegate> efl_access_text_selections_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_selections_count_get_api_delegate>(Module, "efl_access_text_selections_count_get");

        
        private delegate void efl_access_text_access_selection_get_delegate(System.IntPtr obj, System.IntPtr pd,  int selection_number,  out int start_offset,  out int end_offset);

        
        public delegate void efl_access_text_access_selection_get_api_delegate(System.IntPtr obj,  int selection_number,  out int start_offset,  out int end_offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_access_selection_get_api_delegate> efl_access_text_access_selection_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_access_selection_get_api_delegate>(Module, "efl_access_text_access_selection_get");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_text_access_selection_set_delegate(System.IntPtr obj, System.IntPtr pd,  int selection_number,  int start_offset,  int end_offset);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_text_access_selection_set_api_delegate(System.IntPtr obj,  int selection_number,  int start_offset,  int end_offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_access_selection_set_api_delegate> efl_access_text_access_selection_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_access_selection_set_api_delegate>(Module, "efl_access_text_access_selection_set");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_text_selection_add_delegate(System.IntPtr obj, System.IntPtr pd,  int start_offset,  int end_offset);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_text_selection_add_api_delegate(System.IntPtr obj,  int start_offset,  int end_offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_selection_add_api_delegate> efl_access_text_selection_add_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_selection_add_api_delegate>(Module, "efl_access_text_selection_add");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_text_selection_remove_delegate(System.IntPtr obj, System.IntPtr pd,  int selection_number);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_text_selection_remove_api_delegate(System.IntPtr obj,  int selection_number);

        public static Efl.Eo.FunctionWrapper<efl_access_text_selection_remove_api_delegate> efl_access_text_selection_remove_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_selection_remove_api_delegate>(Module, "efl_access_text_selection_remove");

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_AccessTextConcrete_ExtensionMethods {
    
    
    
    public static Efl.BindableProperty<int> CaretOffset<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Access.IText, T>magic = null) where T : Efl.Access.IText {
        return new Efl.BindableProperty<int>("caret_offset", fac);
    }

    
    
    
    
    
    
    
    
    
    
}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Access {

/// <summary>Text accessibility granularity</summary>
[Efl.Eo.BindingEntity]
public enum TextGranularity
{
/// <summary>Character granularity</summary>
Char = 0,
/// <summary>Word granularity</summary>
Word = 1,
/// <summary>Sentence granularity</summary>
Sentence = 2,
/// <summary>Line granularity</summary>
Line = 3,
/// <summary>Paragraph granularity</summary>
Paragraph = 4,
}

}

}

namespace Efl {

namespace Access {

/// <summary>Text clip type</summary>
[Efl.Eo.BindingEntity]
public enum TextClipType
{
/// <summary>No clip type</summary>
None = 0,
/// <summary>Minimum clip type</summary>
Min = 1,
/// <summary>Maximum clip type</summary>
Max = 2,
/// <summary>Both clip types</summary>
Both = 3,
}

}

}

namespace Efl {

namespace Access {

/// <summary>Text attribute</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct TextAttribute
{
    /// <summary>Text attribute name</summary>
    public System.String Name;
    /// <summary>Text attribute value</summary>
    public System.String Value;
    /// <summary>Constructor for TextAttribute.</summary>
    /// <param name="Name">Text attribute name</param>
    /// <param name="Value">Text attribute value</param>
    public TextAttribute(
        System.String Name = default(System.String),
        System.String Value = default(System.String)    )
    {
        this.Name = Name;
        this.Value = Value;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator TextAttribute(IntPtr ptr)
    {
        var tmp = (TextAttribute.NativeStruct)Marshal.PtrToStructure(ptr, typeof(TextAttribute.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct TextAttribute.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        /// <summary>Internal wrapper for field Name</summary>
        public System.IntPtr Name;
        /// <summary>Internal wrapper for field Value</summary>
        public System.IntPtr Value;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator TextAttribute.NativeStruct(TextAttribute _external_struct)
        {
            var _internal_struct = new TextAttribute.NativeStruct();
            _internal_struct.Name = Eina.MemoryNative.StrDup(_external_struct.Name);
            _internal_struct.Value = Eina.MemoryNative.StrDup(_external_struct.Value);
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator TextAttribute(TextAttribute.NativeStruct _internal_struct)
        {
            var _external_struct = new TextAttribute();
            _external_struct.Name = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Name);
            _external_struct.Value = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Value);
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

namespace Efl {

namespace Access {

/// <summary>Text range</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct TextRange
{
    /// <summary>Range start offset</summary>
    public int Start_offset;
    /// <summary>Range end offset</summary>
    public int End_offset;
    /// <summary>Range content</summary>
    public char Content;
    /// <summary>Constructor for TextRange.</summary>
    /// <param name="Start_offset">Range start offset</param>
    /// <param name="End_offset">Range end offset</param>
    /// <param name="Content">Range content</param>
    public TextRange(
        int Start_offset = default(int),
        int End_offset = default(int),
        char Content = default(char)    )
    {
        this.Start_offset = Start_offset;
        this.End_offset = End_offset;
        this.Content = Content;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator TextRange(IntPtr ptr)
    {
        var tmp = (TextRange.NativeStruct)Marshal.PtrToStructure(ptr, typeof(TextRange.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct TextRange.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public int Start_offset;
        
        public int End_offset;
        
        public System.IntPtr Content;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator TextRange.NativeStruct(TextRange _external_struct)
        {
            var _internal_struct = new TextRange.NativeStruct();
            _internal_struct.Start_offset = _external_struct.Start_offset;
            _internal_struct.End_offset = _external_struct.End_offset;
            _internal_struct.Content = Eina.PrimitiveConversion.ManagedToPointerAlloc(_external_struct.Content);
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator TextRange(TextRange.NativeStruct _internal_struct)
        {
            var _external_struct = new TextRange();
            _external_struct.Start_offset = _internal_struct.Start_offset;
            _external_struct.End_offset = _internal_struct.End_offset;
            _external_struct.Content = Eina.PrimitiveConversion.PointerToManaged<char>(_internal_struct.Content);
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

namespace Efl {

namespace Access {

/// <summary>Text change information</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct TextChangeInfo
{
    /// <summary>Change content</summary>
    public System.String Content;
    /// <summary><c>true</c> if text got inserted</summary>
    public bool Inserted;
    /// <summary>Change position</summary>
    public uint Pos;
    /// <summary>Change length</summary>
    public uint Len;
    /// <summary>Constructor for TextChangeInfo.</summary>
    /// <param name="Content">Change content</param>
    /// <param name="Inserted"><c>true</c> if text got inserted</param>
    /// <param name="Pos">Change position</param>
    /// <param name="Len">Change length</param>
    public TextChangeInfo(
        System.String Content = default(System.String),
        bool Inserted = default(bool),
        uint Pos = default(uint),
        uint Len = default(uint)    )
    {
        this.Content = Content;
        this.Inserted = Inserted;
        this.Pos = Pos;
        this.Len = Len;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator TextChangeInfo(IntPtr ptr)
    {
        var tmp = (TextChangeInfo.NativeStruct)Marshal.PtrToStructure(ptr, typeof(TextChangeInfo.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct TextChangeInfo.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        /// <summary>Internal wrapper for field Content</summary>
        public System.IntPtr Content;
        /// <summary>Internal wrapper for field Inserted</summary>
        public System.Byte Inserted;
        
        public uint Pos;
        
        public uint Len;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator TextChangeInfo.NativeStruct(TextChangeInfo _external_struct)
        {
            var _internal_struct = new TextChangeInfo.NativeStruct();
            _internal_struct.Content = Eina.MemoryNative.StrDup(_external_struct.Content);
            _internal_struct.Inserted = _external_struct.Inserted ? (byte)1 : (byte)0;
            _internal_struct.Pos = _external_struct.Pos;
            _internal_struct.Len = _external_struct.Len;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator TextChangeInfo(TextChangeInfo.NativeStruct _internal_struct)
        {
            var _external_struct = new TextChangeInfo();
            _external_struct.Content = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Content);
            _external_struct.Inserted = _internal_struct.Inserted != 0;
            _external_struct.Pos = _internal_struct.Pos;
            _external_struct.Len = _internal_struct.Len;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

