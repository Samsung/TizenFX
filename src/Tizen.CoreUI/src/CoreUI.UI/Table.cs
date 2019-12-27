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
namespace CoreUI.UI {
    /// <summary>Widget container that arranges its elements in a grid.
    /// 
    /// The amount of rows and columns can be controlled with <see cref="CoreUI.IPackTable.TableRows"/> and <see cref="CoreUI.IPackTable.TableColumns"/>, and elements can be manually positioned with <see cref="CoreUI.IPackTable.PackTable"/>. Additionally, a fill direction can be defined with <see cref="CoreUI.UI.ILayoutOrientable.Orientation"/> and elements added with <see cref="CoreUI.IPack.Pack"/>. Elements are then added following this direction (horizontal or vertical) and when the amount of columns or rows has been reached, a step is taken in the orthogonal direction. In this second case there is no need to define both the amount of columns and rows, as the table will expand as needed. The default fill direction is <see cref="CoreUI.UI.LayoutOrientation.Horizontal"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Table.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Table : CoreUI.UI.Widget, CoreUI.IContainer, CoreUI.IPack, CoreUI.IPackLayout, CoreUI.IPackTable, CoreUI.Gfx.IArrangement, CoreUI.UI.ILayoutOrientable
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Table))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_table_class_get();

        /// <summary>Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Table(CoreUI.Object parent, System.String style = null) : base(efl_ui_table_class_get(), parent)
        {
            if (CoreUI.Wrapper.Globals.ParamHelperCheck(style))
            {
                SetStyle(CoreUI.Wrapper.Globals.GetParamHelper(style));
            }

            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Table(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Table"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Table(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Table"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Table(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Sent after a new sub-object was added.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ContainerContentAddedEventArgs"/></value>
        public event EventHandler<CoreUI.ContainerContentAddedEventArgs> ContentAdded
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ContainerContentAddedEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.IEntity) });
                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ContentAdded.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnContentAdded(CoreUI.ContainerContentAddedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_CONTAINER_EVENT_CONTENT_ADDED", info, null);
        }

        /// <summary>Sent after a sub-object was removed, before unref.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ContainerContentRemovedEventArgs"/></value>
        public event EventHandler<CoreUI.ContainerContentRemovedEventArgs> ContentRemoved
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ContainerContentRemovedEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.IEntity) });
                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ContentRemoved.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnContentRemoved(CoreUI.ContainerContentRemovedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_CONTAINER_EVENT_CONTENT_REMOVED", info, null);
        }

        /// <summary>Sent after the layout was updated.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler LayoutUpdated
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event LayoutUpdated.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnLayoutUpdated()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_PACK_EVENT_LAYOUT_UPDATED", IntPtr.Zero, null);
        }

        /// <summary>Control homogeneous mode.
        /// 
        /// This will enable the homogeneous mode where cells are of the same weight and of the same min size which is determined by maximum min size of cells.</summary>
        /// <param name="homogeneoush"><c>true</c> if the box is homogeneous horizontally, <c>false</c> otherwise</param>
        /// <param name="homogeneousv"><c>true</c> if the box is homogeneous vertically, <c>false</c> otherwise</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetHomogeneous(out bool homogeneoush, out bool homogeneousv) {
            CoreUI.UI.Table.NativeMethods.efl_ui_table_homogeneous_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out homogeneoush, out homogeneousv);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control homogeneous mode.
        /// 
        /// This will enable the homogeneous mode where cells are of the same weight and of the same min size which is determined by maximum min size of cells.</summary>
        /// <param name="homogeneoush"><c>true</c> if the box is homogeneous horizontally, <c>false</c> otherwise</param>
        /// <param name="homogeneousv"><c>true</c> if the box is homogeneous vertically, <c>false</c> otherwise</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetHomogeneous(bool homogeneoush, bool homogeneousv) {
            CoreUI.UI.Table.NativeMethods.efl_ui_table_homogeneous_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), homogeneoush, homogeneousv);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Begin iterating over this object&apos;s contents.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Iterator on object&apos;s content.</returns>
        public virtual IEnumerable<CoreUI.Gfx.IEntity> IterateContent() {
            var _ret_var = CoreUI.IContainerNativeMethods.efl_content_iterate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.IEntity>(_ret_var);
        }

        /// <summary>Returns the number of contained sub-objects.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Number of sub-objects.</returns>
        public virtual int ContentCount() {
            var _ret_var = CoreUI.IContainerNativeMethods.efl_content_count_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Removes all packed sub-objects and unreferences them.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
        public virtual bool ClearPack() {
            var _ret_var = CoreUI.IPackNativeMethods.efl_pack_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Removes all packed sub-objects without unreferencing them.
        /// 
        /// Use with caution.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
        public virtual bool UnpackAll() {
            var _ret_var = CoreUI.IPackNativeMethods.efl_pack_unpack_all_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Removes an existing sub-object from the container without deleting it.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">The sub-object to unpack.</param>
        /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t in the container or couldn&apos;t be removed.</returns>
        public virtual bool Unpack(CoreUI.Gfx.IEntity subobj) {
            var _ret_var = CoreUI.IPackNativeMethods.efl_pack_unpack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Adds a sub-object to this container.
        /// 
        /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">The object to pack.</param>
        /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
        public virtual bool Pack(CoreUI.Gfx.IEntity subobj) {
            var _ret_var = CoreUI.IPackNativeMethods.efl_pack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Requests EFL to recalculate the layout of this object.
        /// 
        /// Internal layout methods might be called asynchronously.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void LayoutRequest() {
            CoreUI.IPackLayoutNativeMethods.efl_pack_layout_request_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Implementation of this container&apos;s layout algorithm.
        /// 
        /// EFL will call this function whenever the contents of this container need to be re-laid out on the canvas.
        /// 
        /// This can be overridden to implement custom layout behaviors.</summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void UpdateLayout() {
            CoreUI.IPackLayoutNativeMethods.efl_pack_layout_update_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>column of the <c>subobj</c> in this container.</summary>
        /// <param name="subobj">Child object</param>
        /// <param name="col">Column number</param>
        /// <param name="colspan">Column span</param>
        /// <returns>Returns false if item is not a child</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetTableCellColumn(CoreUI.Gfx.IEntity subobj, out int col, out int colspan) {
            var _ret_var = CoreUI.IPackTableNativeMethods.efl_pack_table_cell_column_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj, out col, out colspan);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>column of the <c>subobj</c> in this container.</summary>
        /// <param name="subobj">Child object</param>
        /// <param name="col">Column number</param>
        /// <param name="colspan">Column span</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetTableCellColumn(CoreUI.Gfx.IEntity subobj, int col, int colspan) {
            CoreUI.IPackTableNativeMethods.efl_pack_table_cell_column_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj, col, colspan);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>row of the <c>subobj</c> in this container.</summary>
        /// <param name="subobj">Child object</param>
        /// <param name="row">Row number</param>
        /// <param name="rowspan">Row span</param>
        /// <returns>Returns false if item is not a child</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetTableCellRow(CoreUI.Gfx.IEntity subobj, out int row, out int rowspan) {
            var _ret_var = CoreUI.IPackTableNativeMethods.efl_pack_table_cell_row_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj, out row, out rowspan);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>row of the <c>subobj</c> in this container.</summary>
        /// <param name="subobj">Child object</param>
        /// <param name="row">Row number</param>
        /// <param name="rowspan">Row span</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetTableCellRow(CoreUI.Gfx.IEntity subobj, int row, int rowspan) {
            CoreUI.IPackTableNativeMethods.efl_pack_table_cell_row_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj, row, rowspan);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Combines <see cref="CoreUI.IPackTable.TableColumns"/> and <see cref="CoreUI.IPackTable.TableRows"/></summary>
        /// <param name="cols">Number of columns</param>
        /// <param name="rows">Number of rows</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetTableSize(out int cols, out int rows) {
            CoreUI.IPackTableNativeMethods.efl_pack_table_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out cols, out rows);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Combines <see cref="CoreUI.IPackTable.TableColumns"/> and <see cref="CoreUI.IPackTable.TableRows"/></summary>
        /// <param name="cols">Number of columns</param>
        /// <param name="rows">Number of rows</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetTableSize(int cols, int rows) {
            CoreUI.IPackTableNativeMethods.efl_pack_table_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), cols, rows);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableRows"/>.</summary>
        /// <returns>Amount of columns.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetTableColumns() {
            var _ret_var = CoreUI.IPackTableNativeMethods.efl_pack_table_columns_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableRows"/>.</summary>
        /// <param name="cols">Amount of columns.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetTableColumns(int cols) {
            CoreUI.IPackTableNativeMethods.efl_pack_table_columns_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), cols);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableColumns"/>.</summary>
        /// <returns>Amount of rows.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetTableRows() {
            var _ret_var = CoreUI.IPackTableNativeMethods.efl_pack_table_rows_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableColumns"/>.</summary>
        /// <param name="rows">Amount of rows.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetTableRows(int rows) {
            CoreUI.IPackTableNativeMethods.efl_pack_table_rows_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), rows);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Pack object at a given location in the table.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">A child object to pack in this table.</param>
        /// <param name="col">Column number</param>
        /// <param name="row">Row number</param>
        /// <param name="colspan">0 means 1, -1 means <see cref="CoreUI.IPackTable.TableColumns"/></param>
        /// <param name="rowspan">0 means 1, -1 means <see cref="CoreUI.IPackTable.TableRows"/></param>
        /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
        public virtual bool PackTable(CoreUI.Gfx.IEntity subobj, int col, int row, int colspan, int rowspan) {
            var _ret_var = CoreUI.IPackTableNativeMethods.efl_pack_table_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj, col, row, colspan, rowspan);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Returns all objects at a given position in this table.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="col">Column number</param>
        /// <param name="row">Row number</param>
        /// <param name="below">If <c>true</c> get objects spanning over this cell.</param>
        /// <returns>Iterator to table contents</returns>
        public virtual IEnumerable<CoreUI.Gfx.IEntity> GetTableContents(int col, int row, bool below) {
            var _ret_var = CoreUI.IPackTableNativeMethods.efl_pack_table_contents_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), col, row, below);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.IEntity>(_ret_var);
        }

        /// <summary>Returns a child at a given position, see <see cref="CoreUI.IPackTable.GetTableContents"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="col">Column number</param>
        /// <param name="row">Row number</param>
        /// <returns>Child object</returns>
        public virtual CoreUI.Gfx.IEntity GetTableContent(int col, int row) {
            var _ret_var = CoreUI.IPackTableNativeMethods.efl_pack_table_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), col, row);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>This property determines how contents will be aligned within a container if there is unused space.
        /// 
        /// It is different than the <see cref="CoreUI.Gfx.IHint.HintAlign"/> property in that it affects the position of all the contents within the container instead of the container itself. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
        /// 
        /// See also <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
        /// <param name="align_horiz">Controls the horizontal alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <param name="align_vert">Controls the vertical alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetContentAlign(out CoreUI.Gfx.Align align_horiz, out CoreUI.Gfx.Align align_vert) {
            CoreUI.Gfx.IArrangementNativeMethods.efl_gfx_arrangement_content_align_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out align_horiz, out align_vert);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This property determines how contents will be aligned within a container if there is unused space.
        /// 
        /// It is different than the <see cref="CoreUI.Gfx.IHint.HintAlign"/> property in that it affects the position of all the contents within the container instead of the container itself. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
        /// 
        /// See also <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
        /// <param name="align_horiz">Controls the horizontal alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <param name="align_vert">Controls the vertical alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetContentAlign(CoreUI.Gfx.Align align_horiz, CoreUI.Gfx.Align align_vert) {
            CoreUI.Gfx.IArrangementNativeMethods.efl_gfx_arrangement_content_align_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), align_horiz, align_vert);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This property determines the space between a container&apos;s content items.
        /// 
        /// It is different than the <see cref="CoreUI.Gfx.IHint.HintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
        /// 
        /// See also <see cref="CoreUI.Gfx.IHint.HintMargin"/>.</summary>
        /// <param name="pad_horiz">Horizontal padding.<br/>The default value is <c>0U</c>.</param>
        /// <param name="pad_vert">Vertical padding.<br/>The default value is <c>0U</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetContentPadding(out uint pad_horiz, out uint pad_vert) {
            CoreUI.Gfx.IArrangementNativeMethods.efl_gfx_arrangement_content_padding_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out pad_horiz, out pad_vert);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This property determines the space between a container&apos;s content items.
        /// 
        /// It is different than the <see cref="CoreUI.Gfx.IHint.HintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
        /// 
        /// See also <see cref="CoreUI.Gfx.IHint.HintMargin"/>.</summary>
        /// <param name="pad_horiz">Horizontal padding.<br/>The default value is <c>0U</c>.</param>
        /// <param name="pad_vert">Vertical padding.<br/>The default value is <c>0U</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetContentPadding(uint pad_horiz, uint pad_vert) {
            CoreUI.Gfx.IArrangementNativeMethods.efl_gfx_arrangement_content_padding_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), pad_horiz, pad_vert);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <returns>Direction of the widget.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.LayoutOrientation GetOrientation() {
            var _ret_var = CoreUI.UI.ILayoutOrientableNativeMethods.efl_ui_layout_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <param name="dir">Direction of the widget.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetOrientation(CoreUI.UI.LayoutOrientation dir) {
            CoreUI.UI.ILayoutOrientableNativeMethods.efl_ui_layout_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dir);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control homogeneous mode.
        /// 
        /// This will enable the homogeneous mode where cells are of the same weight and of the same min size which is determined by maximum min size of cells.</summary>
        /// <value><c>true</c> if the box is homogeneous horizontally, <c>false</c> otherwise</value>
        /// <since_tizen> 6 </since_tizen>
        public (bool, bool) Homogeneous {
            get {
                bool _out_homogeneoush = default(bool);
                bool _out_homogeneousv = default(bool);
                GetHomogeneous(out _out_homogeneoush, out _out_homogeneousv);
                return (_out_homogeneoush, _out_homogeneousv);
            }
            set { SetHomogeneous( value.Item1,  value.Item2); }
        }

        /// <summary>Combines <see cref="CoreUI.IPackTable.TableColumns"/> and <see cref="CoreUI.IPackTable.TableRows"/></summary>
        /// <value>Number of columns</value>
        /// <since_tizen> 6 </since_tizen>
        public (int, int) TableSize {
            get {
                int _out_cols = default(int);
                int _out_rows = default(int);
                GetTableSize(out _out_cols, out _out_rows);
                return (_out_cols, _out_rows);
            }
            set { SetTableSize( value.Item1,  value.Item2); }
        }

        /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableRows"/>.</summary>
        /// <value>Amount of columns.</value>
        /// <since_tizen> 6 </since_tizen>
        public int TableColumns {
            get { return GetTableColumns(); }
            set { SetTableColumns(value); }
        }

        /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableColumns"/>.</summary>
        /// <value>Amount of rows.</value>
        /// <since_tizen> 6 </since_tizen>
        public int TableRows {
            get { return GetTableRows(); }
            set { SetTableRows(value); }
        }

        /// <summary>This property determines how contents will be aligned within a container if there is unused space.
        /// 
        /// It is different than the <see cref="CoreUI.Gfx.IHint.HintAlign"/> property in that it affects the position of all the contents within the container instead of the container itself. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
        /// 
        /// See also <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
        /// <value>Controls the horizontal alignment.</value>
        /// <since_tizen> 6 </since_tizen>
        public (CoreUI.Gfx.Align, CoreUI.Gfx.Align) ContentAlign {
            get {
                CoreUI.Gfx.Align _out_align_horiz = default(CoreUI.Gfx.Align);
                CoreUI.Gfx.Align _out_align_vert = default(CoreUI.Gfx.Align);
                GetContentAlign(out _out_align_horiz, out _out_align_vert);
                return (_out_align_horiz, _out_align_vert);
            }
            set { SetContentAlign( value.Item1,  value.Item2); }
        }

        /// <summary>This property determines the space between a container&apos;s content items.
        /// 
        /// It is different than the <see cref="CoreUI.Gfx.IHint.HintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
        /// 
        /// See also <see cref="CoreUI.Gfx.IHint.HintMargin"/>.</summary>
        /// <value>Horizontal padding.</value>
        /// <since_tizen> 6 </since_tizen>
        public (uint, uint) ContentPadding {
            get {
                uint _out_pad_horiz = default(uint);
                uint _out_pad_vert = default(uint);
                GetContentPadding(out _out_pad_horiz, out _out_pad_vert);
                return (_out_pad_horiz, _out_pad_vert);
            }
            set { SetContentPadding( value.Item1,  value.Item2); }
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <value>Direction of the widget.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.LayoutOrientation Orientation {
            get { return GetOrientation(); }
            set { SetOrientation(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Table.efl_ui_table_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.Widget.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_ui_table_homogeneous_get_static_delegate == null)
                {
                    efl_ui_table_homogeneous_get_static_delegate = new efl_ui_table_homogeneous_get_delegate(homogeneous_get);
                }

                if (methods.Contains("GetHomogeneous"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_table_homogeneous_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_table_homogeneous_get_static_delegate) });
                }

                if (efl_ui_table_homogeneous_set_static_delegate == null)
                {
                    efl_ui_table_homogeneous_set_static_delegate = new efl_ui_table_homogeneous_set_delegate(homogeneous_set);
                }

                if (methods.Contains("SetHomogeneous"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_table_homogeneous_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_table_homogeneous_set_static_delegate) });
                }

                if (efl_pack_layout_update_static_delegate == null)
                {
                    efl_pack_layout_update_static_delegate = new efl_pack_layout_update_delegate(layout_update);
                }

                if (methods.Contains("UpdateLayout"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_layout_update"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_update_static_delegate) });
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
                return CoreUI.UI.Table.efl_ui_table_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate void efl_ui_table_homogeneous_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool homogeneoush, [MarshalAs(UnmanagedType.U1)] out bool homogeneousv);

            
            internal delegate void efl_ui_table_homogeneous_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool homogeneoush, [MarshalAs(UnmanagedType.U1)] out bool homogeneousv);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_table_homogeneous_get_api_delegate> efl_ui_table_homogeneous_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_table_homogeneous_get_api_delegate>(Module, "efl_ui_table_homogeneous_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void homogeneous_get(System.IntPtr obj, System.IntPtr pd, out bool homogeneoush, out bool homogeneousv)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_table_homogeneous_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    homogeneoush = default(bool);homogeneousv = default(bool);
                    try
                    {
                        ((Table)ws.Target).GetHomogeneous(out homogeneoush, out homogeneousv);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_table_homogeneous_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out homogeneoush, out homogeneousv);
                }
            }

            private static efl_ui_table_homogeneous_get_delegate efl_ui_table_homogeneous_get_static_delegate;

            
            private delegate void efl_ui_table_homogeneous_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool homogeneoush, [MarshalAs(UnmanagedType.U1)] bool homogeneousv);

            
            internal delegate void efl_ui_table_homogeneous_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool homogeneoush, [MarshalAs(UnmanagedType.U1)] bool homogeneousv);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_table_homogeneous_set_api_delegate> efl_ui_table_homogeneous_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_table_homogeneous_set_api_delegate>(Module, "efl_ui_table_homogeneous_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void homogeneous_set(System.IntPtr obj, System.IntPtr pd, bool homogeneoush, bool homogeneousv)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_table_homogeneous_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Table)ws.Target).SetHomogeneous(homogeneoush, homogeneousv);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_table_homogeneous_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), homogeneoush, homogeneousv);
                }
            }

            private static efl_ui_table_homogeneous_set_delegate efl_ui_table_homogeneous_set_static_delegate;

            
            private delegate void efl_pack_layout_update_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_pack_layout_update_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_layout_update_api_delegate> efl_pack_layout_update_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_layout_update_api_delegate>(Module, "efl_pack_layout_update");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void layout_update(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_pack_layout_update was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Table)ws.Target).UpdateLayout();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_pack_layout_update_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_pack_layout_update_delegate efl_pack_layout_update_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class TableExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> TableColumns<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Table, T>magic = null) where T : CoreUI.UI.Table {
            return new CoreUI.BindableProperty<int>("table_columns", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> TableRows<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Table, T>magic = null) where T : CoreUI.UI.Table {
            return new CoreUI.BindableProperty<int>("table_rows", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation> Orientation<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Table, T>magic = null) where T : CoreUI.UI.Table {
            return new CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation>("orientation", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

