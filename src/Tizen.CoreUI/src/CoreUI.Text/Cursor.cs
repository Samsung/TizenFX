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
namespace CoreUI.Text {
    /// <summary>Cursor API.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Text.Cursor.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract class Cursor : CoreUI.Object
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Cursor))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Evas)] internal static extern System.IntPtr
            efl_text_cursor_class_get();

        /// <summary>Initializes a new instance of the <see cref="Cursor"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public Cursor(CoreUI.Object parent= null) : base(efl_text_cursor_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Cursor(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Cursor"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Cursor(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        [CoreUI.Wrapper.PrivateNativeClass]
        private class CursorRealized : Cursor
        {
            private CursorRealized(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
            {
            }
        }
        /// <summary>Initializes a new instance of the <see cref="Cursor"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Cursor(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Called when its position has changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Changed
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_TEXT_CURSOR_EVENT_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_TEXT_CURSOR_EVENT_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event Changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnChanged()
        {
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_TEXT_CURSOR_EVENT_CHANGED", IntPtr.Zero, null);
        }


        /// <summary>Cursor position.</summary>
        /// <returns>Cursor position.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetPosition() {
            var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Cursor position.</summary>
        /// <param name="position">Cursor position.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPosition(int position) {
            CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), position);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The content of the cursor (the character under the cursor).</summary>
        /// <returns>The unicode codepoint of the character.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Unicode GetContent() {
            var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The geometry of the item/char pointed by the cursor.</summary>
        /// <returns>The geometry in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Rect GetContentGeometry() {
            var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_content_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The line the cursor is on.</summary>
        /// <returns>The line number.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetLineNumber() {
            var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_line_number_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The line the cursor is on.</summary>
        /// <param name="line_number">The line number.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLineNumber(int line_number) {
            CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_line_number_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), line_number);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Returns the geometry of cursor, if cursor is shown for the text  of the same direction as paragraph,else  (&quot;split cursor&quot;) will return  and you need to consider the lower (&quot;split cursor&quot;) <see cref="CoreUI.Text.Cursor.GetLowerCursorGeometry"/>
        /// 
        /// Split cursor geometry is valid only  in <see cref="CoreUI.Text.CursorType.Before"/> cursor mode.</summary>
        /// <param name="ctype">The type of the cursor.</param>
        /// <returns>The geometry of the cursor (or upper cursor) in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Rect GetCursorGeometry(CoreUI.Text.CursorType ctype) {
            var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), ctype);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Returns the geometry of the lower (&quot;split cursor&quot;), if logical cursor is between LTR/RTL text.
        /// 
        /// To get the upper (&quot;split cursor&quot;) <see cref="CoreUI.Text.Cursor.GetCursorGeometry"/> with <see cref="CoreUI.Text.CursorType.Before"/> cursor mode.</summary>
        /// <param name="geometry">The geometry of the lower cursor in pixels.</param>
        /// <returns><c>true</c> if split cursor, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetLowerCursorGeometry(out CoreUI.DataTypes.Rect geometry) {
            var _out_geometry = new CoreUI.DataTypes.Rect();
var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_lower_cursor_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out _out_geometry);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
geometry = _out_geometry;
            return _ret_var;
        }

        /// <summary>The text object this cursor is associated with.</summary>
        /// <returns>The text object.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Canvas.Object GetTextObject() {
            var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_text_object_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Check if two cursors are equal - faster than compare if all you want is equality.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="dst">Destination Cursor.</param>
        /// <returns><c>true</c> if cursors are equal, <c>false</c> otherwise.</returns>
        public virtual bool Equal(CoreUI.Text.Cursor dst) {
            var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_equal_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dst);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Compare two cursors Return &lt;0 if cursor position less than dst, 0 if cursor == dest and &gt;0 otherwise.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="dst">Destination Cursor.</param>
        /// <returns>Difference between cursors.</returns>
        public virtual int Compare(CoreUI.Text.Cursor dst) {
            var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_compare_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dst);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Move the cursor.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="type">The type of movement.</param>
        /// <returns>True if actually moved.</returns>
        public virtual bool Move(CoreUI.Text.CursorMoveType type) {
            var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_move_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), type);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Deletes a single character from position pointed by given cursor.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void DeleteChar() {
            CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_char_delete_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Jump the cursor by the given number of lines.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="by">Number of lines.</param>
        /// <returns>True if actually moved.</returns>
        public virtual bool LineJumpBy(int by) {
            var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_line_jump_by_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), by);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Set cursor coordinates.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="coord">The coordinates to set to.</param>
        public virtual void SetCharCoord(CoreUI.DataTypes.Position2D coord) {
            CoreUI.DataTypes.Position2D _in_coord = coord;
CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_char_coord_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_coord);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Set cursor coordinates according to grapheme clusters. It does not allow to put a cursor to the middle of a grapheme cluster.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="coord">The coordinates to set to.</param>
        public virtual void SetClusterCoord(CoreUI.DataTypes.Position2D coord) {
            CoreUI.DataTypes.Position2D _in_coord = coord;
CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_cluster_coord_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_coord);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Adds text to the current cursor position and set the cursor to *after* the start of the text just added.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="text">Text to append (UTF-8 format).</param>
        public virtual void InsertText(System.String text) {
            CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_text_insert_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), text);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Inserts a markup text at cursor position.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="markup">Text to append (UTF-8 format).</param>
        public virtual void InsertMarkup(System.String markup) {
            CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_markup_insert_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), markup);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Markup of a given range in the text.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="cur2">End of range.</param>
        /// <returns>The markup in the given range.</returns>
        public virtual System.String GetRangeMarkup(CoreUI.Text.Cursor cur2) {
            var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_range_markup_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), cur2);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Returns the text in the range between cursor and <c>cur2</c>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="cur2">End of range.</param>
        /// <returns>The text in the given range.</returns>
        public virtual System.String GetRangeText(CoreUI.Text.Cursor cur2) {
            var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_range_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), cur2);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Get the simple geometry in pixels of a range in the text.
        /// 
        /// The geometry is the geometry in which rectangles in middle lines of range are merged into one big rectangle. This is an optimized version of <see cref="CoreUI.Text.Cursor.GetRangePreciseGeometry"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="cur2">End of range.</param>
        /// <returns>Iterator on all geometries of the given range.</returns>
        public virtual IEnumerable<CoreUI.DataTypes.Rect> GetRangeGeometry(CoreUI.Text.Cursor cur2) {
            var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_range_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), cur2);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.DataTypes.Rect>(_ret_var);
        }

        /// <summary>Get the &quot;precise&quot; geometry in pixels of a range.
        /// 
        /// The geometry is represented as rectangles for each of the line segments in the given range [<c>cur1</c>, <c>cur2</c>].</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="cur2">End of range.</param>
        /// <returns>Iterator on all simple geometries of the given range.</returns>
        public virtual IEnumerable<CoreUI.DataTypes.Rect> GetRangePreciseGeometry(CoreUI.Text.Cursor cur2) {
            var _ret_var = CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_range_precise_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), cur2);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.DataTypes.Rect>(_ret_var);
        }

        /// <summary>Deletes the range between given cursors.
        /// 
        /// This removes all the text in given range [<c>start</c>,<c>end</c>].</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="cur2">Range end position.</param>
        public virtual void DeleteRange(CoreUI.Text.Cursor cur2) {
            CoreUI.Text.Cursor.NativeMethods.efl_text_cursor_range_delete_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), cur2);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Cursor position.</summary>
        /// <value>Cursor position.</value>
        /// <since_tizen> 6 </since_tizen>
        public int Position {
            get { return GetPosition(); }
            set { SetPosition(value); }
        }

        /// <summary>The content of the cursor (the character under the cursor).</summary>
        /// <value>The unicode codepoint of the character.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Unicode Content {
            get { return GetContent(); }
        }

        /// <summary>The geometry of the item/char pointed by the cursor.</summary>
        /// <value>The geometry in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Rect ContentGeometry {
            get { return GetContentGeometry(); }
        }

        /// <summary>The line the cursor is on.</summary>
        /// <value>The line number.</value>
        /// <since_tizen> 6 </since_tizen>
        public int LineNumber {
            get { return GetLineNumber(); }
            set { SetLineNumber(value); }
        }

        /// <summary>Returns the geometry of the lower (&quot;split cursor&quot;), if logical cursor is between LTR/RTL text.
        /// 
        /// To get the upper (&quot;split cursor&quot;) <see cref="CoreUI.Text.Cursor.GetCursorGeometry"/> with <see cref="CoreUI.Text.CursorType.Before"/> cursor mode.</summary>
        /// <value><c>true</c> if split cursor, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Rect LowerCursorGeometry {
            get {
                CoreUI.DataTypes.Rect _out_geometry = default(CoreUI.DataTypes.Rect);
                GetLowerCursorGeometry(out _out_geometry);
                return (_out_geometry);
            }
        }

        /// <summary>The text object this cursor is associated with.</summary>
        /// <value>The text object.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Canvas.Object TextObject {
            get { return GetTextObject(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.Text.Cursor.efl_text_cursor_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Object.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Evas);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_text_cursor_position_get_static_delegate == null)
                {
                    efl_text_cursor_position_get_static_delegate = new efl_text_cursor_position_get_delegate(position_get);
                }

                if (methods.Contains("GetPosition"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_position_get_static_delegate) });
                }

                if (efl_text_cursor_position_set_static_delegate == null)
                {
                    efl_text_cursor_position_set_static_delegate = new efl_text_cursor_position_set_delegate(position_set);
                }

                if (methods.Contains("SetPosition"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_position_set_static_delegate) });
                }

                if (efl_text_cursor_content_get_static_delegate == null)
                {
                    efl_text_cursor_content_get_static_delegate = new efl_text_cursor_content_get_delegate(content_get);
                }

                if (methods.Contains("GetContent"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_content_get_static_delegate) });
                }

                if (efl_text_cursor_content_geometry_get_static_delegate == null)
                {
                    efl_text_cursor_content_geometry_get_static_delegate = new efl_text_cursor_content_geometry_get_delegate(content_geometry_get);
                }

                if (methods.Contains("GetContentGeometry"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_content_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_content_geometry_get_static_delegate) });
                }

                if (efl_text_cursor_line_number_get_static_delegate == null)
                {
                    efl_text_cursor_line_number_get_static_delegate = new efl_text_cursor_line_number_get_delegate(line_number_get);
                }

                if (methods.Contains("GetLineNumber"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_line_number_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_number_get_static_delegate) });
                }

                if (efl_text_cursor_line_number_set_static_delegate == null)
                {
                    efl_text_cursor_line_number_set_static_delegate = new efl_text_cursor_line_number_set_delegate(line_number_set);
                }

                if (methods.Contains("SetLineNumber"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_line_number_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_number_set_static_delegate) });
                }

                if (efl_text_cursor_geometry_get_static_delegate == null)
                {
                    efl_text_cursor_geometry_get_static_delegate = new efl_text_cursor_geometry_get_delegate(cursor_geometry_get);
                }

                if (methods.Contains("GetCursorGeometry"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_geometry_get_static_delegate) });
                }

                if (efl_text_cursor_lower_cursor_geometry_get_static_delegate == null)
                {
                    efl_text_cursor_lower_cursor_geometry_get_static_delegate = new efl_text_cursor_lower_cursor_geometry_get_delegate(lower_cursor_geometry_get);
                }

                if (methods.Contains("GetLowerCursorGeometry"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_lower_cursor_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_lower_cursor_geometry_get_static_delegate) });
                }

                if (efl_text_cursor_text_object_get_static_delegate == null)
                {
                    efl_text_cursor_text_object_get_static_delegate = new efl_text_cursor_text_object_get_delegate(text_object_get);
                }

                if (methods.Contains("GetTextObject"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_text_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_text_object_get_static_delegate) });
                }

                if (efl_text_cursor_equal_static_delegate == null)
                {
                    efl_text_cursor_equal_static_delegate = new efl_text_cursor_equal_delegate(equal);
                }

                if (methods.Contains("Equal"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_equal"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_equal_static_delegate) });
                }

                if (efl_text_cursor_compare_static_delegate == null)
                {
                    efl_text_cursor_compare_static_delegate = new efl_text_cursor_compare_delegate(compare);
                }

                if (methods.Contains("Compare"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_compare"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_compare_static_delegate) });
                }

                if (efl_text_cursor_move_static_delegate == null)
                {
                    efl_text_cursor_move_static_delegate = new efl_text_cursor_move_delegate(move);
                }

                if (methods.Contains("Move"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_move"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_move_static_delegate) });
                }

                if (efl_text_cursor_char_delete_static_delegate == null)
                {
                    efl_text_cursor_char_delete_static_delegate = new efl_text_cursor_char_delete_delegate(char_delete);
                }

                if (methods.Contains("DeleteChar"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_char_delete"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_char_delete_static_delegate) });
                }

                if (efl_text_cursor_line_jump_by_static_delegate == null)
                {
                    efl_text_cursor_line_jump_by_static_delegate = new efl_text_cursor_line_jump_by_delegate(line_jump_by);
                }

                if (methods.Contains("LineJumpBy"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_line_jump_by"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_jump_by_static_delegate) });
                }

                if (efl_text_cursor_char_coord_set_static_delegate == null)
                {
                    efl_text_cursor_char_coord_set_static_delegate = new efl_text_cursor_char_coord_set_delegate(char_coord_set);
                }

                if (methods.Contains("SetCharCoord"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_char_coord_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_char_coord_set_static_delegate) });
                }

                if (efl_text_cursor_cluster_coord_set_static_delegate == null)
                {
                    efl_text_cursor_cluster_coord_set_static_delegate = new efl_text_cursor_cluster_coord_set_delegate(cluster_coord_set);
                }

                if (methods.Contains("SetClusterCoord"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_cluster_coord_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_cluster_coord_set_static_delegate) });
                }

                if (efl_text_cursor_text_insert_static_delegate == null)
                {
                    efl_text_cursor_text_insert_static_delegate = new efl_text_cursor_text_insert_delegate(text_insert);
                }

                if (methods.Contains("InsertText"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_text_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_text_insert_static_delegate) });
                }

                if (efl_text_cursor_markup_insert_static_delegate == null)
                {
                    efl_text_cursor_markup_insert_static_delegate = new efl_text_cursor_markup_insert_delegate(markup_insert);
                }

                if (methods.Contains("InsertMarkup"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_markup_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_markup_insert_static_delegate) });
                }

                if (efl_text_cursor_range_markup_get_static_delegate == null)
                {
                    efl_text_cursor_range_markup_get_static_delegate = new efl_text_cursor_range_markup_get_delegate(range_markup_get);
                }

                if (methods.Contains("GetRangeMarkup"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_range_markup_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_range_markup_get_static_delegate) });
                }

                if (efl_text_cursor_range_text_get_static_delegate == null)
                {
                    efl_text_cursor_range_text_get_static_delegate = new efl_text_cursor_range_text_get_delegate(range_text_get);
                }

                if (methods.Contains("GetRangeText"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_range_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_range_text_get_static_delegate) });
                }

                if (efl_text_cursor_range_geometry_get_static_delegate == null)
                {
                    efl_text_cursor_range_geometry_get_static_delegate = new efl_text_cursor_range_geometry_get_delegate(range_geometry_get);
                }

                if (methods.Contains("GetRangeGeometry"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_range_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_range_geometry_get_static_delegate) });
                }

                if (efl_text_cursor_range_precise_geometry_get_static_delegate == null)
                {
                    efl_text_cursor_range_precise_geometry_get_static_delegate = new efl_text_cursor_range_precise_geometry_get_delegate(range_precise_geometry_get);
                }

                if (methods.Contains("GetRangePreciseGeometry"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_range_precise_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_range_precise_geometry_get_static_delegate) });
                }

                if (efl_text_cursor_range_delete_static_delegate == null)
                {
                    efl_text_cursor_range_delete_static_delegate = new efl_text_cursor_range_delete_delegate(range_delete);
                }

                if (methods.Contains("DeleteRange"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_range_delete"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_range_delete_static_delegate) });
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
                descs.AddRange(base.GetEoOps(type, false));
                return descs;
            }

            /// <summary>Returns the Eo class for the native methods of this class.
            /// </summary>
            /// <returns>The native class pointer.</returns>
            internal override IntPtr GetCoreUIClass()
            {
                return CoreUI.Text.Cursor.efl_text_cursor_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate int efl_text_cursor_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_text_cursor_position_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_position_get_api_delegate> efl_text_cursor_position_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_position_get_api_delegate>(Module, "efl_text_cursor_position_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int position_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_position_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).GetPosition();
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
                    return efl_text_cursor_position_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_text_cursor_position_get_delegate efl_text_cursor_position_get_static_delegate;

            
            private delegate void efl_text_cursor_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  int position);

            
            internal delegate void efl_text_cursor_position_set_api_delegate(System.IntPtr obj,  int position);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_position_set_api_delegate> efl_text_cursor_position_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_position_set_api_delegate>(Module, "efl_text_cursor_position_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void position_set(System.IntPtr obj, System.IntPtr pd, int position)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_position_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Cursor)ws.Target).SetPosition(position);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_text_cursor_position_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), position);
                }
            }

            private static efl_text_cursor_position_set_delegate efl_text_cursor_position_set_static_delegate;

            
            private delegate CoreUI.DataTypes.Unicode efl_text_cursor_content_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.DataTypes.Unicode efl_text_cursor_content_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_content_get_api_delegate> efl_text_cursor_content_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_content_get_api_delegate>(Module, "efl_text_cursor_content_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Unicode content_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_content_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Unicode _ret_var = default(CoreUI.DataTypes.Unicode);
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).GetContent();
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
                    return efl_text_cursor_content_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_text_cursor_content_get_delegate efl_text_cursor_content_get_static_delegate;

            
            private delegate CoreUI.DataTypes.Rect efl_text_cursor_content_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.DataTypes.Rect efl_text_cursor_content_geometry_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_content_geometry_get_api_delegate> efl_text_cursor_content_geometry_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_content_geometry_get_api_delegate>(Module, "efl_text_cursor_content_geometry_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Rect content_geometry_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_content_geometry_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Rect _ret_var = default(CoreUI.DataTypes.Rect);
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).GetContentGeometry();
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
                    return efl_text_cursor_content_geometry_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_text_cursor_content_geometry_get_delegate efl_text_cursor_content_geometry_get_static_delegate;

            
            private delegate int efl_text_cursor_line_number_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_text_cursor_line_number_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_line_number_get_api_delegate> efl_text_cursor_line_number_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_line_number_get_api_delegate>(Module, "efl_text_cursor_line_number_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int line_number_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_line_number_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).GetLineNumber();
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
                    return efl_text_cursor_line_number_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_text_cursor_line_number_get_delegate efl_text_cursor_line_number_get_static_delegate;

            
            private delegate void efl_text_cursor_line_number_set_delegate(System.IntPtr obj, System.IntPtr pd,  int line_number);

            
            internal delegate void efl_text_cursor_line_number_set_api_delegate(System.IntPtr obj,  int line_number);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_line_number_set_api_delegate> efl_text_cursor_line_number_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_line_number_set_api_delegate>(Module, "efl_text_cursor_line_number_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void line_number_set(System.IntPtr obj, System.IntPtr pd, int line_number)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_line_number_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Cursor)ws.Target).SetLineNumber(line_number);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_text_cursor_line_number_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), line_number);
                }
            }

            private static efl_text_cursor_line_number_set_delegate efl_text_cursor_line_number_set_static_delegate;

            
            private delegate CoreUI.DataTypes.Rect efl_text_cursor_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Text.CursorType ctype);

            
            internal delegate CoreUI.DataTypes.Rect efl_text_cursor_geometry_get_api_delegate(System.IntPtr obj,  CoreUI.Text.CursorType ctype);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_geometry_get_api_delegate> efl_text_cursor_geometry_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_geometry_get_api_delegate>(Module, "efl_text_cursor_geometry_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Rect cursor_geometry_get(System.IntPtr obj, System.IntPtr pd, CoreUI.Text.CursorType ctype)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_geometry_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Rect _ret_var = default(CoreUI.DataTypes.Rect);
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).GetCursorGeometry(ctype);
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
                    return efl_text_cursor_geometry_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), ctype);
                }
            }

            private static efl_text_cursor_geometry_get_delegate efl_text_cursor_geometry_get_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_text_cursor_lower_cursor_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd,  out CoreUI.DataTypes.Rect geometry);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_text_cursor_lower_cursor_geometry_get_api_delegate(System.IntPtr obj,  out CoreUI.DataTypes.Rect geometry);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_lower_cursor_geometry_get_api_delegate> efl_text_cursor_lower_cursor_geometry_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_lower_cursor_geometry_get_api_delegate>(Module, "efl_text_cursor_lower_cursor_geometry_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool lower_cursor_geometry_get(System.IntPtr obj, System.IntPtr pd, out CoreUI.DataTypes.Rect geometry)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_lower_cursor_geometry_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Rect _out_geometry = default(CoreUI.DataTypes.Rect);
bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).GetLowerCursorGeometry(out _out_geometry);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

            geometry = _out_geometry;
        return _ret_var;
                }
                else
                {
                    return efl_text_cursor_lower_cursor_geometry_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out geometry);
                }
            }

            private static efl_text_cursor_lower_cursor_geometry_get_delegate efl_text_cursor_lower_cursor_geometry_get_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Canvas.Object efl_text_cursor_text_object_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Canvas.Object efl_text_cursor_text_object_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_text_object_get_api_delegate> efl_text_cursor_text_object_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_text_object_get_api_delegate>(Module, "efl_text_cursor_text_object_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Canvas.Object text_object_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_text_object_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Canvas.Object _ret_var = default(CoreUI.Canvas.Object);
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).GetTextObject();
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
                    return efl_text_cursor_text_object_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_text_cursor_text_object_get_delegate efl_text_cursor_text_object_get_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_text_cursor_equal_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor dst);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_text_cursor_equal_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor dst);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_equal_api_delegate> efl_text_cursor_equal_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_equal_api_delegate>(Module, "efl_text_cursor_equal");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool equal(System.IntPtr obj, System.IntPtr pd, CoreUI.Text.Cursor dst)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_equal was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).Equal(dst);
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
                    return efl_text_cursor_equal_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), dst);
                }
            }

            private static efl_text_cursor_equal_delegate efl_text_cursor_equal_static_delegate;

            
            private delegate int efl_text_cursor_compare_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor dst);

            
            internal delegate int efl_text_cursor_compare_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor dst);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_compare_api_delegate> efl_text_cursor_compare_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_compare_api_delegate>(Module, "efl_text_cursor_compare");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int compare(System.IntPtr obj, System.IntPtr pd, CoreUI.Text.Cursor dst)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_compare was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).Compare(dst);
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
                    return efl_text_cursor_compare_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), dst);
                }
            }

            private static efl_text_cursor_compare_delegate efl_text_cursor_compare_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_text_cursor_move_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Text.CursorMoveType type);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_text_cursor_move_api_delegate(System.IntPtr obj,  CoreUI.Text.CursorMoveType type);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_move_api_delegate> efl_text_cursor_move_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_move_api_delegate>(Module, "efl_text_cursor_move");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool move(System.IntPtr obj, System.IntPtr pd, CoreUI.Text.CursorMoveType type)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_move was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).Move(type);
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
                    return efl_text_cursor_move_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), type);
                }
            }

            private static efl_text_cursor_move_delegate efl_text_cursor_move_static_delegate;

            
            private delegate void efl_text_cursor_char_delete_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_text_cursor_char_delete_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_char_delete_api_delegate> efl_text_cursor_char_delete_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_char_delete_api_delegate>(Module, "efl_text_cursor_char_delete");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void char_delete(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_char_delete was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Cursor)ws.Target).DeleteChar();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_text_cursor_char_delete_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_text_cursor_char_delete_delegate efl_text_cursor_char_delete_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_text_cursor_line_jump_by_delegate(System.IntPtr obj, System.IntPtr pd,  int by);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_text_cursor_line_jump_by_api_delegate(System.IntPtr obj,  int by);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_line_jump_by_api_delegate> efl_text_cursor_line_jump_by_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_line_jump_by_api_delegate>(Module, "efl_text_cursor_line_jump_by");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool line_jump_by(System.IntPtr obj, System.IntPtr pd, int by)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_line_jump_by was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).LineJumpBy(by);
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
                    return efl_text_cursor_line_jump_by_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), by);
                }
            }

            private static efl_text_cursor_line_jump_by_delegate efl_text_cursor_line_jump_by_static_delegate;

            
            private delegate void efl_text_cursor_char_coord_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Position2D coord);

            
            internal delegate void efl_text_cursor_char_coord_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Position2D coord);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_char_coord_set_api_delegate> efl_text_cursor_char_coord_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_char_coord_set_api_delegate>(Module, "efl_text_cursor_char_coord_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void char_coord_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Position2D coord)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_char_coord_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Position2D _in_coord = coord;

                    try
                    {
                        ((Cursor)ws.Target).SetCharCoord(_in_coord);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_text_cursor_char_coord_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), coord);
                }
            }

            private static efl_text_cursor_char_coord_set_delegate efl_text_cursor_char_coord_set_static_delegate;

            
            private delegate void efl_text_cursor_cluster_coord_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Position2D coord);

            
            internal delegate void efl_text_cursor_cluster_coord_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Position2D coord);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_cluster_coord_set_api_delegate> efl_text_cursor_cluster_coord_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_cluster_coord_set_api_delegate>(Module, "efl_text_cursor_cluster_coord_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void cluster_coord_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Position2D coord)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_cluster_coord_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Position2D _in_coord = coord;

                    try
                    {
                        ((Cursor)ws.Target).SetClusterCoord(_in_coord);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_text_cursor_cluster_coord_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), coord);
                }
            }

            private static efl_text_cursor_cluster_coord_set_delegate efl_text_cursor_cluster_coord_set_static_delegate;

            
            private delegate void efl_text_cursor_text_insert_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String text);

            
            internal delegate void efl_text_cursor_text_insert_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String text);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_text_insert_api_delegate> efl_text_cursor_text_insert_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_text_insert_api_delegate>(Module, "efl_text_cursor_text_insert");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void text_insert(System.IntPtr obj, System.IntPtr pd, System.String text)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_text_insert was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Cursor)ws.Target).InsertText(text);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_text_cursor_text_insert_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), text);
                }
            }

            private static efl_text_cursor_text_insert_delegate efl_text_cursor_text_insert_static_delegate;

            
            private delegate void efl_text_cursor_markup_insert_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String markup);

            
            internal delegate void efl_text_cursor_markup_insert_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String markup);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_markup_insert_api_delegate> efl_text_cursor_markup_insert_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_markup_insert_api_delegate>(Module, "efl_text_cursor_markup_insert");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void markup_insert(System.IntPtr obj, System.IntPtr pd, System.String markup)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_markup_insert was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Cursor)ws.Target).InsertMarkup(markup);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_text_cursor_markup_insert_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), markup);
                }
            }

            private static efl_text_cursor_markup_insert_delegate efl_text_cursor_markup_insert_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringPassOwnershipMarshaler))]
            private delegate System.String efl_text_cursor_range_markup_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor cur2);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringPassOwnershipMarshaler))]
            internal delegate System.String efl_text_cursor_range_markup_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor cur2);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_range_markup_get_api_delegate> efl_text_cursor_range_markup_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_range_markup_get_api_delegate>(Module, "efl_text_cursor_range_markup_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.String range_markup_get(System.IntPtr obj, System.IntPtr pd, CoreUI.Text.Cursor cur2)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_range_markup_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    System.String _ret_var = default(System.String);
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).GetRangeMarkup(cur2);
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
                    return efl_text_cursor_range_markup_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), cur2);
                }
            }

            private static efl_text_cursor_range_markup_get_delegate efl_text_cursor_range_markup_get_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringPassOwnershipMarshaler))]
            private delegate System.String efl_text_cursor_range_text_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor cur2);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringPassOwnershipMarshaler))]
            internal delegate System.String efl_text_cursor_range_text_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor cur2);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_range_text_get_api_delegate> efl_text_cursor_range_text_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_range_text_get_api_delegate>(Module, "efl_text_cursor_range_text_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.String range_text_get(System.IntPtr obj, System.IntPtr pd, CoreUI.Text.Cursor cur2)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_range_text_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    System.String _ret_var = default(System.String);
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).GetRangeText(cur2);
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
                    return efl_text_cursor_range_text_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), cur2);
                }
            }

            private static efl_text_cursor_range_text_get_delegate efl_text_cursor_range_text_get_static_delegate;

            
            private delegate System.IntPtr efl_text_cursor_range_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor cur2);

            
            internal delegate System.IntPtr efl_text_cursor_range_geometry_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor cur2);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_range_geometry_get_api_delegate> efl_text_cursor_range_geometry_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_range_geometry_get_api_delegate>(Module, "efl_text_cursor_range_geometry_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.IntPtr range_geometry_get(System.IntPtr obj, System.IntPtr pd, CoreUI.Text.Cursor cur2)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_range_geometry_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    IEnumerable<CoreUI.DataTypes.Rect> _ret_var = null;
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).GetRangeGeometry(cur2);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return CoreUI.Wrapper.Globals.IEnumerableToIterator(_ret_var, true);
                }
                else
                {
                    return efl_text_cursor_range_geometry_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), cur2);
                }
            }

            private static efl_text_cursor_range_geometry_get_delegate efl_text_cursor_range_geometry_get_static_delegate;

            
            private delegate System.IntPtr efl_text_cursor_range_precise_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor cur2);

            
            internal delegate System.IntPtr efl_text_cursor_range_precise_geometry_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor cur2);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_range_precise_geometry_get_api_delegate> efl_text_cursor_range_precise_geometry_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_range_precise_geometry_get_api_delegate>(Module, "efl_text_cursor_range_precise_geometry_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.IntPtr range_precise_geometry_get(System.IntPtr obj, System.IntPtr pd, CoreUI.Text.Cursor cur2)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_range_precise_geometry_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    IEnumerable<CoreUI.DataTypes.Rect> _ret_var = null;
                    try
                    {
                        _ret_var = ((Cursor)ws.Target).GetRangePreciseGeometry(cur2);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return CoreUI.Wrapper.Globals.IEnumerableToIterator(_ret_var, true);
                }
                else
                {
                    return efl_text_cursor_range_precise_geometry_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), cur2);
                }
            }

            private static efl_text_cursor_range_precise_geometry_get_delegate efl_text_cursor_range_precise_geometry_get_static_delegate;

            
            private delegate void efl_text_cursor_range_delete_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor cur2);

            
            internal delegate void efl_text_cursor_range_delete_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor cur2);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_range_delete_api_delegate> efl_text_cursor_range_delete_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_cursor_range_delete_api_delegate>(Module, "efl_text_cursor_range_delete");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void range_delete(System.IntPtr obj, System.IntPtr pd, CoreUI.Text.Cursor cur2)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_cursor_range_delete was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Cursor)ws.Target).DeleteRange(cur2);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_text_cursor_range_delete_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), cur2);
                }
            }

            private static efl_text_cursor_range_delete_delegate efl_text_cursor_range_delete_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.Text {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class CursorExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> Position<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Text.Cursor, T>magic = null) where T : CoreUI.Text.Cursor {
            return new CoreUI.BindableProperty<int>("position", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> LineNumber<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Text.Cursor, T>magic = null) where T : CoreUI.Text.Cursor {
            return new CoreUI.BindableProperty<int>("line_number", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI.Text {
    /// <summary>Shape of the text cursor. This is normally used in <see cref="CoreUI.Text.Cursor"/> methods to retrieve the cursor&apos;s geometry.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum CursorType
    {
        /// <summary>Cursor is a vertical bar (I-beam) placed before the selected character.</summary>
        /// <since_tizen> 6 </since_tizen>
        Before = 0,
        /// <summary>Cursor is an horizontal line (underscore) placed under the selected character.</summary>
        /// <since_tizen> 6 </since_tizen>
        Under = 1,
    }
}

namespace CoreUI.Text {
    /// <summary>Text cursor movement types.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum CursorMoveType
    {
        /// <summary>Advances to the next character.</summary>
        /// <since_tizen> 6 </since_tizen>
        CharacterNext = 0,
        /// <summary>Advances to the previous character.</summary>
        /// <since_tizen> 6 </since_tizen>
        CharacterPrevious = 1,
        /// <summary>Advances to the next grapheme cluster (A character sequence rendered together. See https://unicode.org/reports/tr29/).</summary>
        /// <since_tizen> 6 </since_tizen>
        ClusterNext = 2,
        /// <summary>Advances to the previous grapheme cluster (A character sequence rendered together. See https://unicode.org/reports/tr29/).</summary>
        /// <since_tizen> 6 </since_tizen>
        ClusterPrevious = 3,
        /// <summary>Advances to the first character in current paragraph.</summary>
        /// <since_tizen> 6 </since_tizen>
        ParagraphStart = 4,
        /// <summary>Advances to the last character in current paragraph.</summary>
        /// <since_tizen> 6 </since_tizen>
        ParagraphEnd = 5,
        /// <summary>Advance to current word start.</summary>
        /// <since_tizen> 6 </since_tizen>
        WordStart = 6,
        /// <summary>Advance to current word end.</summary>
        /// <since_tizen> 6 </since_tizen>
        WordEnd = 7,
        /// <summary>Advance to current line first character.</summary>
        /// <since_tizen> 6 </since_tizen>
        LineStart = 8,
        /// <summary>Advance to current line last character.</summary>
        /// <since_tizen> 6 </since_tizen>
        LineEnd = 9,
        /// <summary>Advance to first character in the first paragraph.</summary>
        /// <since_tizen> 6 </since_tizen>
        First = 10,
        /// <summary>Advance to last character in the  last  paragraph.</summary>
        /// <since_tizen> 6 </since_tizen>
        Last = 11,
        /// <summary>Advances to the start of the next paragraph.</summary>
        /// <since_tizen> 6 </since_tizen>
        ParagraphNext = 12,
        /// <summary>Advances to the end of the previous paragraph.</summary>
        /// <since_tizen> 6 </since_tizen>
        ParagraphPrevious = 13,
    }
}

