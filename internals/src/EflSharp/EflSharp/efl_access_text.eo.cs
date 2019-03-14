#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Access { 
/// <summary>Elementary accessible text interface</summary>
[TextNativeInherit]
public interface Text : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Gets single character present in accessible widget&apos;s text at given offset.</summary>
/// <param name="offset">Position in text.</param>
/// <returns>Character at offset. 0 when out-of bounds offset has been given. Codepoints between DC80 and DCFF indicates that string includes invalid UTF8 chars.</returns>
Eina.Unicode GetCharacter(  int offset);
   /// <summary>Gets string, start and end offset in text according to given initial offset and granularity.</summary>
/// <param name="granularity">Text granularity</param>
/// <param name="start_offset">Offset indicating start of string according to given granularity.  -1 in case of error.</param>
/// <param name="end_offset">Offset indicating end of string according to given granularity. -1 in case of error.</param>
/// <returns>Newly allocated UTF-8 encoded string. Must be free by a user.</returns>
 System.String GetString( Efl.Access.TextGranularity granularity,   int start_offset,   int end_offset);
   /// <summary>Gets text of accessible widget.</summary>
/// <param name="start_offset">Position in text.</param>
/// <param name="end_offset">End offset of text.</param>
/// <returns>UTF-8 encoded text.</returns>
 System.String GetAccessText(  int start_offset,   int end_offset);
   /// <summary>Gets offset position of caret (cursor)</summary>
/// <returns>Offset</returns>
 int GetCaretOffset();
   /// <summary>Caret offset property</summary>
/// <param name="offset">Offset</param>
/// <returns><c>true</c> if caret was successfully moved, <c>false</c> otherwise.</returns>
bool SetCaretOffset(  int offset);
   /// <summary>Indicate if a text attribute with a given name is set</summary>
/// <param name="name">Text attribute name</param>
/// <param name="start_offset">Position in text from which given attribute is set.</param>
/// <param name="end_offset">Position in text to which given attribute is set.</param>
/// <param name="value">Value of text attribute. Should be free()</param>
/// <returns><c>true</c> if attribute name is set, <c>false</c> otherwise</returns>
bool GetAttribute(  System.String name,   int start_offset,   int end_offset,  out  System.String value);
   /// <summary>Gets list of all text attributes.</summary>
/// <param name="start_offset">Start offset</param>
/// <param name="end_offset">End offset</param>
/// <returns>List of text attributes</returns>
Eina.List<Efl.Access.TextAttribute> GetTextAttributes(  int start_offset,   int end_offset);
   /// <summary>Default attributes</summary>
/// <returns>List of default attributes</returns>
Eina.List<Efl.Access.TextAttribute> GetDefaultAttributes();
   /// <summary>Character extents</summary>
/// <param name="offset">Offset</param>
/// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
/// <param name="rect">Extents rectangle</param>
/// <returns><c>true</c> if character extents, <c>false</c> otherwise</returns>
bool GetCharacterExtents(  int offset,  bool screen_coords,  out Eina.Rect rect);
   /// <summary>Character count</summary>
/// <returns>Character count</returns>
 int GetCharacterCount();
   /// <summary>Offset at given point</summary>
/// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
/// <param name="x">X coordinate</param>
/// <param name="y">Y coordinate</param>
/// <returns>Offset</returns>
 int GetOffsetAtPoint( bool screen_coords,   int x,   int y);
   /// <summary>Bounded ranges</summary>
/// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
/// <param name="rect">Bounding box</param>
/// <param name="xclip">xclip</param>
/// <param name="yclip">yclip</param>
/// <returns>List of ranges</returns>
Eina.List<Efl.Access.TextRange> GetBoundedRanges( bool screen_coords,  Eina.Rect rect,  Efl.Access.TextClipType xclip,  Efl.Access.TextClipType yclip);
   /// <summary>Range extents</summary>
/// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
/// <param name="start_offset">Start offset</param>
/// <param name="end_offset">End offset</param>
/// <param name="rect">Range rectangle</param>
/// <returns><c>true</c> if range extents, <c>false</c> otherwise</returns>
bool GetRangeExtents( bool screen_coords,   int start_offset,   int end_offset,  out Eina.Rect rect);
   /// <summary>Selection count property</summary>
/// <returns>Selection counter</returns>
 int GetSelectionsCount();
   /// <summary>Selection property</summary>
/// <param name="selection_number">Selection number for identification</param>
/// <param name="start_offset">Selection start offset</param>
/// <param name="end_offset">Selection end offset</param>
/// <returns></returns>
 void GetAccessSelection(  int selection_number,  out  int start_offset,  out  int end_offset);
   /// <summary>Selection property</summary>
/// <param name="selection_number">Selection number for identification</param>
/// <param name="start_offset">Selection start offset</param>
/// <param name="end_offset">Selection end offset</param>
/// <returns><c>true</c> if selection was set, <c>false</c> otherwise</returns>
bool SetAccessSelection(  int selection_number,   int start_offset,   int end_offset);
   /// <summary>Add selection</summary>
/// <param name="start_offset">Start selection from this offset</param>
/// <param name="end_offset">End selection at this offset</param>
/// <returns><c>true</c> if selection was added, <c>false</c> otherwise</returns>
bool AddSelection(  int start_offset,   int end_offset);
   /// <summary>Remove selection</summary>
/// <param name="selection_number">Selection number to be removed</param>
/// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
bool SelectionRemove(  int selection_number);
                                                         /// <summary>Caret moved</summary>
   event EventHandler AccessTextCaretMovedEvt;
   /// <summary>Text was inserted</summary>
   event EventHandler<Efl.Access.TextAccessTextInsertedEvt_Args> AccessTextInsertedEvt;
   /// <summary>Text was removed</summary>
   event EventHandler<Efl.Access.TextAccessTextRemovedEvt_Args> AccessTextRemovedEvt;
   /// <summary>Text selection has changed</summary>
   event EventHandler AccessTextSelectionChangedEvt;
   /// <summary>Caret offset property</summary>
/// <value>Offset</value>
    int CaretOffset {
      get ;
      set ;
   }
   /// <summary>Default attributes</summary>
/// <value>List of default attributes</value>
   Eina.List<Efl.Access.TextAttribute> DefaultAttributes {
      get ;
   }
   /// <summary>Character count</summary>
/// <value>Character count</value>
    int CharacterCount {
      get ;
   }
   /// <summary>Selection count property</summary>
/// <value>Selection counter</value>
    int SelectionsCount {
      get ;
   }
}
///<summary>Event argument wrapper for event <see cref="Efl.Access.Text.AccessTextInsertedEvt"/>.</summary>
public class TextAccessTextInsertedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Access.TextChangeInfo arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Access.Text.AccessTextRemovedEvt"/>.</summary>
public class TextAccessTextRemovedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Access.TextChangeInfo arg { get; set; }
}
/// <summary>Elementary accessible text interface</summary>
sealed public class TextConcrete : 

Text
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (TextConcrete))
            return Efl.Access.TextNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_access_text_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public TextConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~TextConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static TextConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new TextConcrete(obj.NativeHandle);
   }
   ///<summary>Verifies if the given object is equal to this one.</summary>
   public override bool Equals(object obj)
   {
      var other = obj as Efl.Object;
      if (other == null)
         return false;
      return this.NativeHandle == other.NativeHandle;
   }
   ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
   public override int GetHashCode()
   {
      return this.NativeHandle.ToInt32();
   }
   ///<summary>Turns the native pointer into a string representation.</summary>
   public override String ToString()
   {
      return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
   }
   private readonly object eventLock = new object();
   private Dictionary<string, int> event_cb_count = new Dictionary<string, int>();
   private bool add_cpp_event_handler(string lib, string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(lib, key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
          bool result = Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } 
      event_cb_count[key]++;
      return true;
   }
   private bool remove_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 1) {
         IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
         bool result = Efl.Eo.Globals.efl_event_callback_del(handle, desc, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to remove event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } else if (event_count == 0) {
         Eina.Log.Error($"Trying to remove proxy for event {key} when there is nothing registered.");
         return false;
      } 
      event_cb_count[key]--;
      return true;
   }
private static object AccessTextCaretMovedEvtKey = new object();
   /// <summary>Caret moved</summary>
   public event EventHandler AccessTextCaretMovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_CARET_MOVED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AccessTextCaretMovedEvt_delegate)) {
               eventHandlers.AddHandler(AccessTextCaretMovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_CARET_MOVED";
            if (remove_cpp_event_handler(key, this.evt_AccessTextCaretMovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AccessTextCaretMovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AccessTextCaretMovedEvt.</summary>
   public void On_AccessTextCaretMovedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[AccessTextCaretMovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AccessTextCaretMovedEvt_delegate;
   private void on_AccessTextCaretMovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_AccessTextCaretMovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AccessTextInsertedEvtKey = new object();
   /// <summary>Text was inserted</summary>
   public event EventHandler<Efl.Access.TextAccessTextInsertedEvt_Args> AccessTextInsertedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_INSERTED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AccessTextInsertedEvt_delegate)) {
               eventHandlers.AddHandler(AccessTextInsertedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_INSERTED";
            if (remove_cpp_event_handler(key, this.evt_AccessTextInsertedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AccessTextInsertedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AccessTextInsertedEvt.</summary>
   public void On_AccessTextInsertedEvt(Efl.Access.TextAccessTextInsertedEvt_Args e)
   {
      EventHandler<Efl.Access.TextAccessTextInsertedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.TextAccessTextInsertedEvt_Args>)eventHandlers[AccessTextInsertedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AccessTextInsertedEvt_delegate;
   private void on_AccessTextInsertedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.TextAccessTextInsertedEvt_Args args = new Efl.Access.TextAccessTextInsertedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_AccessTextInsertedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AccessTextRemovedEvtKey = new object();
   /// <summary>Text was removed</summary>
   public event EventHandler<Efl.Access.TextAccessTextRemovedEvt_Args> AccessTextRemovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_REMOVED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AccessTextRemovedEvt_delegate)) {
               eventHandlers.AddHandler(AccessTextRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_REMOVED";
            if (remove_cpp_event_handler(key, this.evt_AccessTextRemovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AccessTextRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AccessTextRemovedEvt.</summary>
   public void On_AccessTextRemovedEvt(Efl.Access.TextAccessTextRemovedEvt_Args e)
   {
      EventHandler<Efl.Access.TextAccessTextRemovedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.TextAccessTextRemovedEvt_Args>)eventHandlers[AccessTextRemovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AccessTextRemovedEvt_delegate;
   private void on_AccessTextRemovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.TextAccessTextRemovedEvt_Args args = new Efl.Access.TextAccessTextRemovedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_AccessTextRemovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AccessTextSelectionChangedEvtKey = new object();
   /// <summary>Text selection has changed</summary>
   public event EventHandler AccessTextSelectionChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_SELECTION_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AccessTextSelectionChangedEvt_delegate)) {
               eventHandlers.AddHandler(AccessTextSelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_SELECTION_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_AccessTextSelectionChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AccessTextSelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AccessTextSelectionChangedEvt.</summary>
   public void On_AccessTextSelectionChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[AccessTextSelectionChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AccessTextSelectionChangedEvt_delegate;
   private void on_AccessTextSelectionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_AccessTextSelectionChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_AccessTextCaretMovedEvt_delegate = new Efl.EventCb(on_AccessTextCaretMovedEvt_NativeCallback);
      evt_AccessTextInsertedEvt_delegate = new Efl.EventCb(on_AccessTextInsertedEvt_NativeCallback);
      evt_AccessTextRemovedEvt_delegate = new Efl.EventCb(on_AccessTextRemovedEvt_NativeCallback);
      evt_AccessTextSelectionChangedEvt_delegate = new Efl.EventCb(on_AccessTextSelectionChangedEvt_NativeCallback);
   }
   /// <summary>Gets single character present in accessible widget&apos;s text at given offset.</summary>
   /// <param name="offset">Position in text.</param>
   /// <returns>Character at offset. 0 when out-of bounds offset has been given. Codepoints between DC80 and DCFF indicates that string includes invalid UTF8 chars.</returns>
   public Eina.Unicode GetCharacter(  int offset) {
                         var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_character_get_ptr.Value.Delegate(this.NativeHandle, offset);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Gets string, start and end offset in text according to given initial offset and granularity.</summary>
   /// <param name="granularity">Text granularity</param>
   /// <param name="start_offset">Offset indicating start of string according to given granularity.  -1 in case of error.</param>
   /// <param name="end_offset">Offset indicating end of string according to given granularity. -1 in case of error.</param>
   /// <returns>Newly allocated UTF-8 encoded string. Must be free by a user.</returns>
   public  System.String GetString( Efl.Access.TextGranularity granularity,   int start_offset,   int end_offset) {
             var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
      var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                                          var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_string_get_ptr.Value.Delegate(this.NativeHandle, granularity,  _in_start_offset,  _in_end_offset);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Gets text of accessible widget.</summary>
   /// <param name="start_offset">Position in text.</param>
   /// <param name="end_offset">End offset of text.</param>
   /// <returns>UTF-8 encoded text.</returns>
   public  System.String GetAccessText(  int start_offset,   int end_offset) {
                                           var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_get_ptr.Value.Delegate(this.NativeHandle, start_offset,  end_offset);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Gets offset position of caret (cursor)</summary>
   /// <returns>Offset</returns>
   public  int GetCaretOffset() {
       var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_caret_offset_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Caret offset property</summary>
   /// <param name="offset">Offset</param>
   /// <returns><c>true</c> if caret was successfully moved, <c>false</c> otherwise.</returns>
   public bool SetCaretOffset(  int offset) {
                         var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_caret_offset_set_ptr.Value.Delegate(this.NativeHandle, offset);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Indicate if a text attribute with a given name is set</summary>
   /// <param name="name">Text attribute name</param>
   /// <param name="start_offset">Position in text from which given attribute is set.</param>
   /// <param name="end_offset">Position in text to which given attribute is set.</param>
   /// <param name="value">Value of text attribute. Should be free()</param>
   /// <returns><c>true</c> if attribute name is set, <c>false</c> otherwise</returns>
   public bool GetAttribute(  System.String name,   int start_offset,   int end_offset,  out  System.String value) {
             var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
      var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                                                            var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_attribute_get_ptr.Value.Delegate(this.NativeHandle, name,  _in_start_offset,  _in_end_offset,  out value);
      Eina.Error.RaiseIfUnhandledException();
                                                      return _ret_var;
 }
   /// <summary>Gets list of all text attributes.</summary>
   /// <param name="start_offset">Start offset</param>
   /// <param name="end_offset">End offset</param>
   /// <returns>List of text attributes</returns>
   public Eina.List<Efl.Access.TextAttribute> GetTextAttributes(  int start_offset,   int end_offset) {
       var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
      var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                              var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_attributes_get_ptr.Value.Delegate(this.NativeHandle, _in_start_offset,  _in_end_offset);
      Eina.Error.RaiseIfUnhandledException();
                              return new Eina.List<Efl.Access.TextAttribute>(_ret_var, true, true);
 }
   /// <summary>Default attributes</summary>
   /// <returns>List of default attributes</returns>
   public Eina.List<Efl.Access.TextAttribute> GetDefaultAttributes() {
       var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_default_attributes_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Access.TextAttribute>(_ret_var, true, true);
 }
   /// <summary>Character extents</summary>
   /// <param name="offset">Offset</param>
   /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="rect">Extents rectangle</param>
   /// <returns><c>true</c> if character extents, <c>false</c> otherwise</returns>
   public bool GetCharacterExtents(  int offset,  bool screen_coords,  out Eina.Rect rect) {
                                     var _out_rect = new Eina.Rect_StructInternal();
                        var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_character_extents_get_ptr.Value.Delegate(this.NativeHandle, offset,  screen_coords,  out _out_rect);
      Eina.Error.RaiseIfUnhandledException();
                  rect = Eina.Rect_StructConversion.ToManaged(_out_rect);
                        return _ret_var;
 }
   /// <summary>Character count</summary>
   /// <returns>Character count</returns>
   public  int GetCharacterCount() {
       var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_character_count_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Offset at given point</summary>
   /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <returns>Offset</returns>
   public  int GetOffsetAtPoint( bool screen_coords,   int x,   int y) {
                                                             var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_offset_at_point_get_ptr.Value.Delegate(this.NativeHandle, screen_coords,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Bounded ranges</summary>
   /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="rect">Bounding box</param>
   /// <param name="xclip">xclip</param>
   /// <param name="yclip">yclip</param>
   /// <returns>List of ranges</returns>
   public Eina.List<Efl.Access.TextRange> GetBoundedRanges( bool screen_coords,  Eina.Rect rect,  Efl.Access.TextClipType xclip,  Efl.Access.TextClipType yclip) {
             var _in_rect = Eina.Rect_StructConversion.ToInternal(rect);
                                                                  var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_bounded_ranges_get_ptr.Value.Delegate(this.NativeHandle, screen_coords,  _in_rect,  xclip,  yclip);
      Eina.Error.RaiseIfUnhandledException();
                                                      return new Eina.List<Efl.Access.TextRange>(_ret_var, true, true);
 }
   /// <summary>Range extents</summary>
   /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="start_offset">Start offset</param>
   /// <param name="end_offset">End offset</param>
   /// <param name="rect">Range rectangle</param>
   /// <returns><c>true</c> if range extents, <c>false</c> otherwise</returns>
   public bool GetRangeExtents( bool screen_coords,   int start_offset,   int end_offset,  out Eina.Rect rect) {
                                                 var _out_rect = new Eina.Rect_StructInternal();
                              var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_range_extents_get_ptr.Value.Delegate(this.NativeHandle, screen_coords,  start_offset,  end_offset,  out _out_rect);
      Eina.Error.RaiseIfUnhandledException();
                        rect = Eina.Rect_StructConversion.ToManaged(_out_rect);
                              return _ret_var;
 }
   /// <summary>Selection count property</summary>
   /// <returns>Selection counter</returns>
   public  int GetSelectionsCount() {
       var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_selections_count_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Selection property</summary>
   /// <param name="selection_number">Selection number for identification</param>
   /// <param name="start_offset">Selection start offset</param>
   /// <param name="end_offset">Selection end offset</param>
   /// <returns></returns>
   public  void GetAccessSelection(  int selection_number,  out  int start_offset,  out  int end_offset) {
                                                             Efl.Access.TextNativeInherit.efl_access_text_access_selection_get_ptr.Value.Delegate(this.NativeHandle, selection_number,  out start_offset,  out end_offset);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Selection property</summary>
   /// <param name="selection_number">Selection number for identification</param>
   /// <param name="start_offset">Selection start offset</param>
   /// <param name="end_offset">Selection end offset</param>
   /// <returns><c>true</c> if selection was set, <c>false</c> otherwise</returns>
   public bool SetAccessSelection(  int selection_number,   int start_offset,   int end_offset) {
                                                             var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_access_selection_set_ptr.Value.Delegate(this.NativeHandle, selection_number,  start_offset,  end_offset);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Add selection</summary>
   /// <param name="start_offset">Start selection from this offset</param>
   /// <param name="end_offset">End selection at this offset</param>
   /// <returns><c>true</c> if selection was added, <c>false</c> otherwise</returns>
   public bool AddSelection(  int start_offset,   int end_offset) {
                                           var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_selection_add_ptr.Value.Delegate(this.NativeHandle, start_offset,  end_offset);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Remove selection</summary>
   /// <param name="selection_number">Selection number to be removed</param>
   /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
   public bool SelectionRemove(  int selection_number) {
                         var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_selection_remove_ptr.Value.Delegate(this.NativeHandle, selection_number);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Caret offset property</summary>
/// <value>Offset</value>
   public  int CaretOffset {
      get { return GetCaretOffset(); }
      set { SetCaretOffset( value); }
   }
   /// <summary>Default attributes</summary>
/// <value>List of default attributes</value>
   public Eina.List<Efl.Access.TextAttribute> DefaultAttributes {
      get { return GetDefaultAttributes(); }
   }
   /// <summary>Character count</summary>
/// <value>Character count</value>
   public  int CharacterCount {
      get { return GetCharacterCount(); }
   }
   /// <summary>Selection count property</summary>
/// <value>Selection counter</value>
   public  int SelectionsCount {
      get { return GetSelectionsCount(); }
   }
}
public class TextNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_access_text_character_get_static_delegate == null)
      efl_access_text_character_get_static_delegate = new efl_access_text_character_get_delegate(character_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_character_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_character_get_static_delegate)});
      if (efl_access_text_string_get_static_delegate == null)
      efl_access_text_string_get_static_delegate = new efl_access_text_string_get_delegate(string_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_string_get_static_delegate)});
      if (efl_access_text_get_static_delegate == null)
      efl_access_text_get_static_delegate = new efl_access_text_get_delegate(access_text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_get_static_delegate)});
      if (efl_access_text_caret_offset_get_static_delegate == null)
      efl_access_text_caret_offset_get_static_delegate = new efl_access_text_caret_offset_get_delegate(caret_offset_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_caret_offset_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_caret_offset_get_static_delegate)});
      if (efl_access_text_caret_offset_set_static_delegate == null)
      efl_access_text_caret_offset_set_static_delegate = new efl_access_text_caret_offset_set_delegate(caret_offset_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_caret_offset_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_caret_offset_set_static_delegate)});
      if (efl_access_text_attribute_get_static_delegate == null)
      efl_access_text_attribute_get_static_delegate = new efl_access_text_attribute_get_delegate(attribute_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_attribute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_attribute_get_static_delegate)});
      if (efl_access_text_attributes_get_static_delegate == null)
      efl_access_text_attributes_get_static_delegate = new efl_access_text_attributes_get_delegate(text_attributes_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_attributes_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_attributes_get_static_delegate)});
      if (efl_access_text_default_attributes_get_static_delegate == null)
      efl_access_text_default_attributes_get_static_delegate = new efl_access_text_default_attributes_get_delegate(default_attributes_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_default_attributes_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_default_attributes_get_static_delegate)});
      if (efl_access_text_character_extents_get_static_delegate == null)
      efl_access_text_character_extents_get_static_delegate = new efl_access_text_character_extents_get_delegate(character_extents_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_character_extents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_character_extents_get_static_delegate)});
      if (efl_access_text_character_count_get_static_delegate == null)
      efl_access_text_character_count_get_static_delegate = new efl_access_text_character_count_get_delegate(character_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_character_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_character_count_get_static_delegate)});
      if (efl_access_text_offset_at_point_get_static_delegate == null)
      efl_access_text_offset_at_point_get_static_delegate = new efl_access_text_offset_at_point_get_delegate(offset_at_point_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_offset_at_point_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_offset_at_point_get_static_delegate)});
      if (efl_access_text_bounded_ranges_get_static_delegate == null)
      efl_access_text_bounded_ranges_get_static_delegate = new efl_access_text_bounded_ranges_get_delegate(bounded_ranges_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_bounded_ranges_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_bounded_ranges_get_static_delegate)});
      if (efl_access_text_range_extents_get_static_delegate == null)
      efl_access_text_range_extents_get_static_delegate = new efl_access_text_range_extents_get_delegate(range_extents_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_range_extents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_range_extents_get_static_delegate)});
      if (efl_access_text_selections_count_get_static_delegate == null)
      efl_access_text_selections_count_get_static_delegate = new efl_access_text_selections_count_get_delegate(selections_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_selections_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_selections_count_get_static_delegate)});
      if (efl_access_text_access_selection_get_static_delegate == null)
      efl_access_text_access_selection_get_static_delegate = new efl_access_text_access_selection_get_delegate(access_selection_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_access_selection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_access_selection_get_static_delegate)});
      if (efl_access_text_access_selection_set_static_delegate == null)
      efl_access_text_access_selection_set_static_delegate = new efl_access_text_access_selection_set_delegate(access_selection_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_access_selection_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_access_selection_set_static_delegate)});
      if (efl_access_text_selection_add_static_delegate == null)
      efl_access_text_selection_add_static_delegate = new efl_access_text_selection_add_delegate(selection_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_selection_add"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_selection_add_static_delegate)});
      if (efl_access_text_selection_remove_static_delegate == null)
      efl_access_text_selection_remove_static_delegate = new efl_access_text_selection_remove_delegate(selection_remove);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_selection_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_selection_remove_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Access.TextConcrete.efl_access_text_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Access.TextConcrete.efl_access_text_interface_get();
   }


    private delegate Eina.Unicode efl_access_text_character_get_delegate(System.IntPtr obj, System.IntPtr pd,    int offset);


    public delegate Eina.Unicode efl_access_text_character_get_api_delegate(System.IntPtr obj,    int offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_character_get_api_delegate> efl_access_text_character_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_character_get_api_delegate>(_Module, "efl_access_text_character_get");
    private static Eina.Unicode character_get(System.IntPtr obj, System.IntPtr pd,   int offset)
   {
      Eina.Log.Debug("function efl_access_text_character_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Eina.Unicode _ret_var = default(Eina.Unicode);
         try {
            _ret_var = ((Text)wrapper).GetCharacter( offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_text_character_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  offset);
      }
   }
   private static efl_access_text_character_get_delegate efl_access_text_character_get_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] private delegate  System.String efl_access_text_string_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.TextGranularity granularity,    System.IntPtr start_offset,    System.IntPtr end_offset);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] public delegate  System.String efl_access_text_string_get_api_delegate(System.IntPtr obj,   Efl.Access.TextGranularity granularity,    System.IntPtr start_offset,    System.IntPtr end_offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_string_get_api_delegate> efl_access_text_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_string_get_api_delegate>(_Module, "efl_access_text_string_get");
    private static  System.String string_get(System.IntPtr obj, System.IntPtr pd,  Efl.Access.TextGranularity granularity,   System.IntPtr start_offset,   System.IntPtr end_offset)
   {
      Eina.Log.Debug("function efl_access_text_string_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_start_offset = Eina.PrimitiveConversion.PointerToManaged< int>(start_offset);
      var _in_end_offset = Eina.PrimitiveConversion.PointerToManaged< int>(end_offset);
                                              System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Text)wrapper).GetString( granularity,  _in_start_offset,  _in_end_offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_access_text_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  granularity,  start_offset,  end_offset);
      }
   }
   private static efl_access_text_string_get_delegate efl_access_text_string_get_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] private delegate  System.String efl_access_text_get_delegate(System.IntPtr obj, System.IntPtr pd,    int start_offset,    int end_offset);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] public delegate  System.String efl_access_text_get_api_delegate(System.IntPtr obj,    int start_offset,    int end_offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_get_api_delegate> efl_access_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_get_api_delegate>(_Module, "efl_access_text_get");
    private static  System.String access_text_get(System.IntPtr obj, System.IntPtr pd,   int start_offset,   int end_offset)
   {
      Eina.Log.Debug("function efl_access_text_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Text)wrapper).GetAccessText( start_offset,  end_offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start_offset,  end_offset);
      }
   }
   private static efl_access_text_get_delegate efl_access_text_get_static_delegate;


    private delegate  int efl_access_text_caret_offset_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_access_text_caret_offset_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_get_api_delegate> efl_access_text_caret_offset_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_get_api_delegate>(_Module, "efl_access_text_caret_offset_get");
    private static  int caret_offset_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_text_caret_offset_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Text)wrapper).GetCaretOffset();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_text_caret_offset_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_text_caret_offset_get_delegate efl_access_text_caret_offset_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_text_caret_offset_set_delegate(System.IntPtr obj, System.IntPtr pd,    int offset);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_text_caret_offset_set_api_delegate(System.IntPtr obj,    int offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_set_api_delegate> efl_access_text_caret_offset_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_set_api_delegate>(_Module, "efl_access_text_caret_offset_set");
    private static bool caret_offset_set(System.IntPtr obj, System.IntPtr pd,   int offset)
   {
      Eina.Log.Debug("function efl_access_text_caret_offset_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).SetCaretOffset( offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_text_caret_offset_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  offset);
      }
   }
   private static efl_access_text_caret_offset_set_delegate efl_access_text_caret_offset_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_text_attribute_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,    System.IntPtr start_offset,    System.IntPtr end_offset,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]  out  System.String value);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_text_attribute_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,    System.IntPtr start_offset,    System.IntPtr end_offset,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]  out  System.String value);
    public static Efl.Eo.FunctionWrapper<efl_access_text_attribute_get_api_delegate> efl_access_text_attribute_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_attribute_get_api_delegate>(_Module, "efl_access_text_attribute_get");
    private static bool attribute_get(System.IntPtr obj, System.IntPtr pd,   System.String name,   System.IntPtr start_offset,   System.IntPtr end_offset,  out  System.String value)
   {
      Eina.Log.Debug("function efl_access_text_attribute_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_start_offset = Eina.PrimitiveConversion.PointerToManaged< int>(start_offset);
      var _in_end_offset = Eina.PrimitiveConversion.PointerToManaged< int>(end_offset);
                              value = default( System.String);                                 bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetAttribute( name,  _in_start_offset,  _in_end_offset,  out value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                      return _ret_var;
      } else {
         return efl_access_text_attribute_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  start_offset,  end_offset,  out value);
      }
   }
   private static efl_access_text_attribute_get_delegate efl_access_text_attribute_get_static_delegate;


    private delegate  System.IntPtr efl_access_text_attributes_get_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr start_offset,    System.IntPtr end_offset);


    public delegate  System.IntPtr efl_access_text_attributes_get_api_delegate(System.IntPtr obj,    System.IntPtr start_offset,    System.IntPtr end_offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_attributes_get_api_delegate> efl_access_text_attributes_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_attributes_get_api_delegate>(_Module, "efl_access_text_attributes_get");
    private static  System.IntPtr text_attributes_get(System.IntPtr obj, System.IntPtr pd,   System.IntPtr start_offset,   System.IntPtr end_offset)
   {
      Eina.Log.Debug("function efl_access_text_attributes_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_start_offset = Eina.PrimitiveConversion.PointerToManaged< int>(start_offset);
      var _in_end_offset = Eina.PrimitiveConversion.PointerToManaged< int>(end_offset);
                                 Eina.List<Efl.Access.TextAttribute> _ret_var = default(Eina.List<Efl.Access.TextAttribute>);
         try {
            _ret_var = ((Text)wrapper).GetTextAttributes( _in_start_offset,  _in_end_offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              _ret_var.Own = false; _ret_var.OwnContent = false; return _ret_var.Handle;
      } else {
         return efl_access_text_attributes_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start_offset,  end_offset);
      }
   }
   private static efl_access_text_attributes_get_delegate efl_access_text_attributes_get_static_delegate;


    private delegate  System.IntPtr efl_access_text_default_attributes_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_access_text_default_attributes_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_text_default_attributes_get_api_delegate> efl_access_text_default_attributes_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_default_attributes_get_api_delegate>(_Module, "efl_access_text_default_attributes_get");
    private static  System.IntPtr default_attributes_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_text_default_attributes_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Access.TextAttribute> _ret_var = default(Eina.List<Efl.Access.TextAttribute>);
         try {
            _ret_var = ((Text)wrapper).GetDefaultAttributes();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; _ret_var.OwnContent = false; return _ret_var.Handle;
      } else {
         return efl_access_text_default_attributes_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_text_default_attributes_get_delegate efl_access_text_default_attributes_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_text_character_extents_get_delegate(System.IntPtr obj, System.IntPtr pd,    int offset,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   out Eina.Rect_StructInternal rect);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_text_character_extents_get_api_delegate(System.IntPtr obj,    int offset,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   out Eina.Rect_StructInternal rect);
    public static Efl.Eo.FunctionWrapper<efl_access_text_character_extents_get_api_delegate> efl_access_text_character_extents_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_character_extents_get_api_delegate>(_Module, "efl_access_text_character_extents_get");
    private static bool character_extents_get(System.IntPtr obj, System.IntPtr pd,   int offset,  bool screen_coords,  out Eina.Rect_StructInternal rect)
   {
      Eina.Log.Debug("function efl_access_text_character_extents_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                             Eina.Rect _out_rect = default(Eina.Rect);
                           bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetCharacterExtents( offset,  screen_coords,  out _out_rect);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  rect = Eina.Rect_StructConversion.ToInternal(_out_rect);
                        return _ret_var;
      } else {
         return efl_access_text_character_extents_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  offset,  screen_coords,  out rect);
      }
   }
   private static efl_access_text_character_extents_get_delegate efl_access_text_character_extents_get_static_delegate;


    private delegate  int efl_access_text_character_count_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_access_text_character_count_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_text_character_count_get_api_delegate> efl_access_text_character_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_character_count_get_api_delegate>(_Module, "efl_access_text_character_count_get");
    private static  int character_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_text_character_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Text)wrapper).GetCharacterCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_text_character_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_text_character_count_get_delegate efl_access_text_character_count_get_static_delegate;


    private delegate  int efl_access_text_offset_at_point_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);


    public delegate  int efl_access_text_offset_at_point_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
    public static Efl.Eo.FunctionWrapper<efl_access_text_offset_at_point_get_api_delegate> efl_access_text_offset_at_point_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_offset_at_point_get_api_delegate>(_Module, "efl_access_text_offset_at_point_get");
    private static  int offset_at_point_get(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,   int x,   int y)
   {
      Eina.Log.Debug("function efl_access_text_offset_at_point_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                         int _ret_var = default( int);
         try {
            _ret_var = ((Text)wrapper).GetOffsetAtPoint( screen_coords,  x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_access_text_offset_at_point_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  x,  y);
      }
   }
   private static efl_access_text_offset_at_point_get_delegate efl_access_text_offset_at_point_get_static_delegate;


    private delegate  System.IntPtr efl_access_text_bounded_ranges_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   Eina.Rect_StructInternal rect,   Efl.Access.TextClipType xclip,   Efl.Access.TextClipType yclip);


    public delegate  System.IntPtr efl_access_text_bounded_ranges_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   Eina.Rect_StructInternal rect,   Efl.Access.TextClipType xclip,   Efl.Access.TextClipType yclip);
    public static Efl.Eo.FunctionWrapper<efl_access_text_bounded_ranges_get_api_delegate> efl_access_text_bounded_ranges_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_bounded_ranges_get_api_delegate>(_Module, "efl_access_text_bounded_ranges_get");
    private static  System.IntPtr bounded_ranges_get(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,  Eina.Rect_StructInternal rect,  Efl.Access.TextClipType xclip,  Efl.Access.TextClipType yclip)
   {
      Eina.Log.Debug("function efl_access_text_bounded_ranges_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_rect = Eina.Rect_StructConversion.ToManaged(rect);
                                                                     Eina.List<Efl.Access.TextRange> _ret_var = default(Eina.List<Efl.Access.TextRange>);
         try {
            _ret_var = ((Text)wrapper).GetBoundedRanges( screen_coords,  _in_rect,  xclip,  yclip);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                      _ret_var.Own = false; _ret_var.OwnContent = false; return _ret_var.Handle;
      } else {
         return efl_access_text_bounded_ranges_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  rect,  xclip,  yclip);
      }
   }
   private static efl_access_text_bounded_ranges_get_delegate efl_access_text_bounded_ranges_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_text_range_extents_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int start_offset,    int end_offset,   out Eina.Rect_StructInternal rect);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_text_range_extents_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int start_offset,    int end_offset,   out Eina.Rect_StructInternal rect);
    public static Efl.Eo.FunctionWrapper<efl_access_text_range_extents_get_api_delegate> efl_access_text_range_extents_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_range_extents_get_api_delegate>(_Module, "efl_access_text_range_extents_get");
    private static bool range_extents_get(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,   int start_offset,   int end_offset,  out Eina.Rect_StructInternal rect)
   {
      Eina.Log.Debug("function efl_access_text_range_extents_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                         Eina.Rect _out_rect = default(Eina.Rect);
                                 bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetRangeExtents( screen_coords,  start_offset,  end_offset,  out _out_rect);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        rect = Eina.Rect_StructConversion.ToInternal(_out_rect);
                              return _ret_var;
      } else {
         return efl_access_text_range_extents_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  start_offset,  end_offset,  out rect);
      }
   }
   private static efl_access_text_range_extents_get_delegate efl_access_text_range_extents_get_static_delegate;


    private delegate  int efl_access_text_selections_count_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_access_text_selections_count_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_text_selections_count_get_api_delegate> efl_access_text_selections_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_selections_count_get_api_delegate>(_Module, "efl_access_text_selections_count_get");
    private static  int selections_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_text_selections_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Text)wrapper).GetSelectionsCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_text_selections_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_text_selections_count_get_delegate efl_access_text_selections_count_get_static_delegate;


    private delegate  void efl_access_text_access_selection_get_delegate(System.IntPtr obj, System.IntPtr pd,    int selection_number,   out  int start_offset,   out  int end_offset);


    public delegate  void efl_access_text_access_selection_get_api_delegate(System.IntPtr obj,    int selection_number,   out  int start_offset,   out  int end_offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_access_selection_get_api_delegate> efl_access_text_access_selection_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_access_selection_get_api_delegate>(_Module, "efl_access_text_access_selection_get");
    private static  void access_selection_get(System.IntPtr obj, System.IntPtr pd,   int selection_number,  out  int start_offset,  out  int end_offset)
   {
      Eina.Log.Debug("function efl_access_text_access_selection_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       start_offset = default( int);      end_offset = default( int);                           
         try {
            ((Text)wrapper).GetAccessSelection( selection_number,  out start_offset,  out end_offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_access_text_access_selection_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  selection_number,  out start_offset,  out end_offset);
      }
   }
   private static efl_access_text_access_selection_get_delegate efl_access_text_access_selection_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_text_access_selection_set_delegate(System.IntPtr obj, System.IntPtr pd,    int selection_number,    int start_offset,    int end_offset);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_text_access_selection_set_api_delegate(System.IntPtr obj,    int selection_number,    int start_offset,    int end_offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_access_selection_set_api_delegate> efl_access_text_access_selection_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_access_selection_set_api_delegate>(_Module, "efl_access_text_access_selection_set");
    private static bool access_selection_set(System.IntPtr obj, System.IntPtr pd,   int selection_number,   int start_offset,   int end_offset)
   {
      Eina.Log.Debug("function efl_access_text_access_selection_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).SetAccessSelection( selection_number,  start_offset,  end_offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_access_text_access_selection_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  selection_number,  start_offset,  end_offset);
      }
   }
   private static efl_access_text_access_selection_set_delegate efl_access_text_access_selection_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_text_selection_add_delegate(System.IntPtr obj, System.IntPtr pd,    int start_offset,    int end_offset);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_text_selection_add_api_delegate(System.IntPtr obj,    int start_offset,    int end_offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_selection_add_api_delegate> efl_access_text_selection_add_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_selection_add_api_delegate>(_Module, "efl_access_text_selection_add");
    private static bool selection_add(System.IntPtr obj, System.IntPtr pd,   int start_offset,   int end_offset)
   {
      Eina.Log.Debug("function efl_access_text_selection_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).AddSelection( start_offset,  end_offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_text_selection_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start_offset,  end_offset);
      }
   }
   private static efl_access_text_selection_add_delegate efl_access_text_selection_add_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_text_selection_remove_delegate(System.IntPtr obj, System.IntPtr pd,    int selection_number);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_text_selection_remove_api_delegate(System.IntPtr obj,    int selection_number);
    public static Efl.Eo.FunctionWrapper<efl_access_text_selection_remove_api_delegate> efl_access_text_selection_remove_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_selection_remove_api_delegate>(_Module, "efl_access_text_selection_remove");
    private static bool selection_remove(System.IntPtr obj, System.IntPtr pd,   int selection_number)
   {
      Eina.Log.Debug("function efl_access_text_selection_remove was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).SelectionRemove( selection_number);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_text_selection_remove_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  selection_number);
      }
   }
   private static efl_access_text_selection_remove_delegate efl_access_text_selection_remove_static_delegate;
}
} } 
namespace Efl { namespace Access { 
/// <summary>Text accessibility granularity</summary>
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
} } 
namespace Efl { namespace Access { 
/// <summary>Text clip type</summary>
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
} } 
namespace Efl { namespace Access { 
/// <summary>Text attribute</summary>
[StructLayout(LayoutKind.Sequential)]
public struct TextAttribute
{
   /// <summary>Text attribute name</summary>
   public  System.String Name;
   /// <summary>Text attribute value</summary>
   public  System.String Value;
   ///<summary>Constructor for TextAttribute.</summary>
   public TextAttribute(
       System.String Name=default( System.String),
       System.String Value=default( System.String)   )
   {
      this.Name = Name;
      this.Value = Value;
   }
public static implicit operator TextAttribute(IntPtr ptr)
   {
      var tmp = (TextAttribute_StructInternal)Marshal.PtrToStructure(ptr, typeof(TextAttribute_StructInternal));
      return TextAttribute_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct TextAttribute.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct TextAttribute_StructInternal
{
///<summary>Internal wrapper for field Name</summary>
public System.IntPtr Name;
///<summary>Internal wrapper for field Value</summary>
public System.IntPtr Value;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator TextAttribute(TextAttribute_StructInternal struct_)
   {
      return TextAttribute_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator TextAttribute_StructInternal(TextAttribute struct_)
   {
      return TextAttribute_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct TextAttribute</summary>
public static class TextAttribute_StructConversion
{
   internal static TextAttribute_StructInternal ToInternal(TextAttribute _external_struct)
   {
      var _internal_struct = new TextAttribute_StructInternal();

      _internal_struct.Name = Eina.MemoryNative.StrDup(_external_struct.Name);
      _internal_struct.Value = Eina.MemoryNative.StrDup(_external_struct.Value);

      return _internal_struct;
   }

   internal static TextAttribute ToManaged(TextAttribute_StructInternal _internal_struct)
   {
      var _external_struct = new TextAttribute();

      _external_struct.Name = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Name);
      _external_struct.Value = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Value);

      return _external_struct;
   }

}
} } 
namespace Efl { namespace Access { 
/// <summary>Text range</summary>
[StructLayout(LayoutKind.Sequential)]
public struct TextRange
{
   /// <summary>Range start offset</summary>
   public  int Start_offset;
   /// <summary>Range end offset</summary>
   public  int End_offset;
   /// <summary>Range content</summary>
   public char Content;
   ///<summary>Constructor for TextRange.</summary>
   public TextRange(
       int Start_offset=default( int),
       int End_offset=default( int),
      char Content=default(char)   )
   {
      this.Start_offset = Start_offset;
      this.End_offset = End_offset;
      this.Content = Content;
   }
public static implicit operator TextRange(IntPtr ptr)
   {
      var tmp = (TextRange_StructInternal)Marshal.PtrToStructure(ptr, typeof(TextRange_StructInternal));
      return TextRange_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct TextRange.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct TextRange_StructInternal
{
   
   public  int Start_offset;
   
   public  int End_offset;
   
   public  System.IntPtr Content;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator TextRange(TextRange_StructInternal struct_)
   {
      return TextRange_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator TextRange_StructInternal(TextRange struct_)
   {
      return TextRange_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct TextRange</summary>
public static class TextRange_StructConversion
{
   internal static TextRange_StructInternal ToInternal(TextRange _external_struct)
   {
      var _internal_struct = new TextRange_StructInternal();

      _internal_struct.Start_offset = _external_struct.Start_offset;
      _internal_struct.End_offset = _external_struct.End_offset;
      _internal_struct.Content = Eina.PrimitiveConversion.ManagedToPointerAlloc(_external_struct.Content);

      return _internal_struct;
   }

   internal static TextRange ToManaged(TextRange_StructInternal _internal_struct)
   {
      var _external_struct = new TextRange();

      _external_struct.Start_offset = _internal_struct.Start_offset;
      _external_struct.End_offset = _internal_struct.End_offset;
      _external_struct.Content = Eina.PrimitiveConversion.PointerToManaged<char>(_internal_struct.Content);

      return _external_struct;
   }

}
} } 
namespace Efl { namespace Access { 
/// <summary>Text change information</summary>
[StructLayout(LayoutKind.Sequential)]
public struct TextChangeInfo
{
   /// <summary>Change content</summary>
   public  System.String Content;
   /// <summary><c>true</c> if text got inserted</summary>
   public bool Inserted;
   /// <summary>Change position</summary>
   public  uint Pos;
   /// <summary>Change length</summary>
   public  uint Len;
   ///<summary>Constructor for TextChangeInfo.</summary>
   public TextChangeInfo(
       System.String Content=default( System.String),
      bool Inserted=default(bool),
       uint Pos=default( uint),
       uint Len=default( uint)   )
   {
      this.Content = Content;
      this.Inserted = Inserted;
      this.Pos = Pos;
      this.Len = Len;
   }
public static implicit operator TextChangeInfo(IntPtr ptr)
   {
      var tmp = (TextChangeInfo_StructInternal)Marshal.PtrToStructure(ptr, typeof(TextChangeInfo_StructInternal));
      return TextChangeInfo_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct TextChangeInfo.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct TextChangeInfo_StructInternal
{
///<summary>Internal wrapper for field Content</summary>
public System.IntPtr Content;
///<summary>Internal wrapper for field Inserted</summary>
public System.Byte Inserted;
   
   public  uint Pos;
   
   public  uint Len;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator TextChangeInfo(TextChangeInfo_StructInternal struct_)
   {
      return TextChangeInfo_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator TextChangeInfo_StructInternal(TextChangeInfo struct_)
   {
      return TextChangeInfo_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct TextChangeInfo</summary>
public static class TextChangeInfo_StructConversion
{
   internal static TextChangeInfo_StructInternal ToInternal(TextChangeInfo _external_struct)
   {
      var _internal_struct = new TextChangeInfo_StructInternal();

      _internal_struct.Content = Eina.MemoryNative.StrDup(_external_struct.Content);
      _internal_struct.Inserted = _external_struct.Inserted ? (byte)1 : (byte)0;
      _internal_struct.Pos = _external_struct.Pos;
      _internal_struct.Len = _external_struct.Len;

      return _internal_struct;
   }

   internal static TextChangeInfo ToManaged(TextChangeInfo_StructInternal _internal_struct)
   {
      var _external_struct = new TextChangeInfo();

      _external_struct.Content = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Content);
      _external_struct.Inserted = _internal_struct.Inserted != 0;
      _external_struct.Pos = _internal_struct.Pos;
      _external_struct.Len = _internal_struct.Len;

      return _external_struct;
   }

}
} } 
