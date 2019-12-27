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
    /// <summary>A container that arranges children widgets in a vertical or horizontal fashion.
    /// 
    /// The Box widget is the most basic (and the most used) of the container widgets. Other widgets are added to the Box through the <see cref="CoreUI.IPackLinear"/> interface, and the layout direction (either vertical or horizontal) is controlled through the <see cref="CoreUI.UI.ILayoutOrientable.Orientation"/> property.
    /// 
    /// The Box widget itself is invisible, as are most container widgets: Their purpose is to handle the position and size of all their children so you don&apos;t have to.
    /// 
    /// All widgets inside a vertical Box container will have the same width as the container, and their heights will be automatically chosen so that they cover the whole surface of the container from top to bottom (Imagine a stack of pizza boxes neatly fitting inside your oven). The <see cref="CoreUI.UI.Box.Homogeneous"/> property then controls whether all widgets have the same height (homogeneous) or not.
    /// 
    /// A horizontal Box container example would be the button toolbar at the top of most word processing programs.
    /// 
    /// Precise layout can be further customized through the <see cref="CoreUI.Gfx.IArrangement"/> interface on the Box itself, or through the <see cref="CoreUI.Gfx.IHint"/> interface on each of the children widgets.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Box.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Box : CoreUI.UI.Widget, CoreUI.IContainer, CoreUI.IPack, CoreUI.IPackLayout, CoreUI.IPackLinear, CoreUI.Gfx.IArrangement, CoreUI.UI.ILayoutOrientable
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Box))
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
            efl_ui_box_class_get();

        /// <summary>Initializes a new instance of the <see cref="Box"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Box(CoreUI.Object parent, System.String style = null) : base(efl_ui_box_class_get(), parent)
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
        protected Box(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Box"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Box(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Box"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Box(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
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

        /// <summary>In homogeneous mode all children of a vertical Box have the same height, equal to the height of the tallest widget. Children of a horizontal Box have the same width, equal to the width of the widest widget. Otherwise, individual widget sizes are not modified.</summary>
        /// <returns><c>true</c> if the Box is homogeneous, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetHomogeneous() {
            var _ret_var = CoreUI.UI.Box.NativeMethods.efl_ui_box_homogeneous_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>In homogeneous mode all children of a vertical Box have the same height, equal to the height of the tallest widget. Children of a horizontal Box have the same width, equal to the width of the widest widget. Otherwise, individual widget sizes are not modified.</summary>
        /// <param name="homogeneous"><c>true</c> if the Box is homogeneous, <c>false</c> otherwise.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetHomogeneous(bool homogeneous) {
            CoreUI.UI.Box.NativeMethods.efl_ui_box_homogeneous_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), homogeneous);
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

        /// <summary>Prepend an object at the beginning of this container.
        /// 
        /// This is the same as <see cref="CoreUI.IPackLinear.PackAt"/> with a <c>0</c> index.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack at the beginning.</param>
        /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
        public virtual bool PackBegin(CoreUI.Gfx.IEntity subobj) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_begin_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Append object at the end of this container.
        /// 
        /// This is the same as <see cref="CoreUI.IPackLinear.PackAt"/> with a <c>-1</c> index.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack at the end.</param>
        /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
        public virtual bool PackEnd(CoreUI.Gfx.IEntity subobj) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_end_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Prepend an object before the <c>existing</c> sub-object.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.
        /// 
        /// If <c>existing</c> is <c>NULL</c> this method behaves like <see cref="CoreUI.IPackLinear.PackBegin"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack before <c>existing</c>.</param>
        /// <param name="existing">Existing reference sub-object. Must already belong to the container or be <c>NULL</c>.</param>
        /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
        public virtual bool PackBefore(CoreUI.Gfx.IEntity subobj, CoreUI.Gfx.IEntity existing) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_before_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj, existing);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Append an object after the <c>existing</c> sub-object.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.
        /// 
        /// If <c>existing</c> is <c>NULL</c> this method behaves like <see cref="CoreUI.IPackLinear.PackEnd"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack after <c>existing</c>.</param>
        /// <param name="existing">Existing reference sub-object. Must already belong to the container or be <c>NULL</c>.</param>
        /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
        public virtual bool PackAfter(CoreUI.Gfx.IEntity subobj, CoreUI.Gfx.IEntity existing) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_after_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj, existing);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Inserts <c>subobj</c> BEFORE the sub-object at position <c>index</c>.
        /// 
        /// <c>index</c> ranges from <c>-count</c> to <c>count-1</c>, where positive numbers go from first sub-object (<c>0</c>) to last (<c>count-1</c>), and negative numbers go from last sub-object (<c>-1</c>) to first (<c>-count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="CoreUI.IContainer.ContentCount"/>.
        /// 
        /// If <c>index</c> is less than <c>-count</c>, it will trigger <see cref="CoreUI.IPackLinear.PackBegin"/> whereas <c>index</c> greater than <c>count-1</c> will trigger <see cref="CoreUI.IPackLinear.PackEnd"/>.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack.</param>
        /// <param name="index">Index of existing sub-object to insert BEFORE. Valid range is <c>-count</c> to <c>count-1</c>).</param>
        /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
        public virtual bool PackAt(CoreUI.Gfx.IEntity subobj, int index) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_at_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj, index);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Sub-object at a given <c>index</c> in this container.
        /// 
        /// <c>index</c> ranges from <c>-count</c> to <c>count-1</c>, where positive numbers go from first sub-object (<c>0</c>) to last (<c>count-1</c>), and negative numbers go from last sub-object (<c>-1</c>) to first (<c>-count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="CoreUI.IContainer.ContentCount"/>.
        /// 
        /// If <c>index</c> is less than <c>-count</c>, it will return the first sub-object whereas <c>index</c> greater than <c>count-1</c> will return the last sub-object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="index">Index of the existing sub-object to retrieve. Valid range is <c>-count</c> to <c>count-1</c>.</param>
        /// <returns>The sub-object contained at the given <c>index</c>.</returns>
        public virtual CoreUI.Gfx.IEntity GetPackContent(int index) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), index);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Get the index of a sub-object in this container.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">An existing sub-object in this container.</param>
        /// <returns>-1 in case <c>subobj</c> is not found, or the index of <c>subobj</c> in the range <c>0</c> to <c>count-1</c>.</returns>
        public virtual int GetPackIndex(CoreUI.Gfx.IEntity subobj) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_index_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Pop out (remove) the sub-object at the specified <c>index</c>.
        /// 
        /// <c>index</c> ranges from <c>-count</c> to <c>count-1</c>, where positive numbers go from first sub-object (<c>0</c>) to last (<c>count-1</c>), and negative numbers go from last sub-object (<c>-1</c>) to first (<c>-count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="CoreUI.IContainer.ContentCount"/>.
        /// 
        /// If <c>index</c> is less than -<c>count</c>, it will remove the first sub-object whereas <c>index</c> greater than <c>count</c>-1 will remove the last sub-object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="index">Index of the sub-object to remove. Valid range is <c>-count</c> to <c>count-1</c>.</param>
        /// <returns>The sub-object if it could be removed.</returns>
        public virtual CoreUI.Gfx.IEntity PackUnpackAt(int index) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_unpack_at_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), index);
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

        /// <summary>In homogeneous mode all children of a vertical Box have the same height, equal to the height of the tallest widget. Children of a horizontal Box have the same width, equal to the width of the widest widget. Otherwise, individual widget sizes are not modified.</summary>
        /// <value><c>true</c> if the Box is homogeneous, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Homogeneous {
            get { return GetHomogeneous(); }
            set { SetHomogeneous(value); }
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
            return CoreUI.UI.Box.efl_ui_box_class_get();
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

                if (efl_ui_box_homogeneous_get_static_delegate == null)
                {
                    efl_ui_box_homogeneous_get_static_delegate = new efl_ui_box_homogeneous_get_delegate(homogeneous_get);
                }

                if (methods.Contains("GetHomogeneous"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_box_homogeneous_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_box_homogeneous_get_static_delegate) });
                }

                if (efl_ui_box_homogeneous_set_static_delegate == null)
                {
                    efl_ui_box_homogeneous_set_static_delegate = new efl_ui_box_homogeneous_set_delegate(homogeneous_set);
                }

                if (methods.Contains("SetHomogeneous"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_box_homogeneous_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_box_homogeneous_set_static_delegate) });
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
                return CoreUI.UI.Box.efl_ui_box_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_box_homogeneous_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_box_homogeneous_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_box_homogeneous_get_api_delegate> efl_ui_box_homogeneous_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_box_homogeneous_get_api_delegate>(Module, "efl_ui_box_homogeneous_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool homogeneous_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_box_homogeneous_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Box)ws.Target).GetHomogeneous();
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
                    return efl_ui_box_homogeneous_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_box_homogeneous_get_delegate efl_ui_box_homogeneous_get_static_delegate;

            
            private delegate void efl_ui_box_homogeneous_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool homogeneous);

            
            internal delegate void efl_ui_box_homogeneous_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool homogeneous);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_box_homogeneous_set_api_delegate> efl_ui_box_homogeneous_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_box_homogeneous_set_api_delegate>(Module, "efl_ui_box_homogeneous_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void homogeneous_set(System.IntPtr obj, System.IntPtr pd, bool homogeneous)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_box_homogeneous_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Box)ws.Target).SetHomogeneous(homogeneous);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_box_homogeneous_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), homogeneous);
                }
            }

            private static efl_ui_box_homogeneous_set_delegate efl_ui_box_homogeneous_set_static_delegate;

            
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
                        ((Box)ws.Target).UpdateLayout();
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
    public static class BoxExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Homogeneous<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Box, T>magic = null) where T : CoreUI.UI.Box {
            return new CoreUI.BindableProperty<bool>("homogeneous", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation> Orientation<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Box, T>magic = null) where T : CoreUI.UI.Box {
            return new CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation>("orientation", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

