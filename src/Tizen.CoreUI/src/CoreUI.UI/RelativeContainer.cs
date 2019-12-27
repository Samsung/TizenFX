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
    /// <summary>The relative container class.
    /// 
    /// A relative container calculates the size and position of all the children based on their relationship to each other.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.RelativeContainer.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class RelativeContainer : CoreUI.UI.Widget, CoreUI.IContainer, CoreUI.IPack, CoreUI.IPackLayout
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(RelativeContainer))
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
            efl_ui_relative_container_class_get();

        /// <summary>Initializes a new instance of the <see cref="RelativeContainer"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public RelativeContainer(CoreUI.Object parent, System.String style = null) : base(efl_ui_relative_container_class_get(), parent)
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
        protected RelativeContainer(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RelativeContainer"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal RelativeContainer(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RelativeContainer"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected RelativeContainer(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
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

        /// <summary>Specifies the left side edge of the <c>child</c> object relative to the <c>base</c> object. When <c>relative_position</c> is 0 the left edges of the two objects are aligned. When <c>relative_position</c> is 1 the left edge of the <c>child</c> object is aligned to the right edge of the <c>base</c> object.</summary>
        /// <param name="child">The child object whose size and position is being changed.</param>
        /// <param name="kw_base">The object whose size and position is being used as reference. <c>NULL</c> means that the container object is used (this is the default value).</param>
        /// <param name="relative_position">The ratio between left and right of the base, ranging from 0.0 to 1.0.<br/>The default value is <c>0.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetRelationLeft(CoreUI.Gfx.IEntity child, out CoreUI.Gfx.IEntity kw_base, out CoreUI.Gfx.Align relative_position) {
            CoreUI.UI.RelativeContainer.NativeMethods.efl_ui_relative_container_relation_left_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), child, out kw_base, out relative_position);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Specifies the left side edge of the <c>child</c> object relative to the <c>base</c> object. When <c>relative_position</c> is 0 the left edges of the two objects are aligned. When <c>relative_position</c> is 1 the left edge of the <c>child</c> object is aligned to the right edge of the <c>base</c> object.</summary>
        /// <param name="child">The child object whose size and position is being changed.</param>
        /// <param name="kw_base">The object whose size and position is being used as reference. <c>NULL</c> means that the container object is used (this is the default value).</param>
        /// <param name="relative_position">The ratio between left and right of the base, ranging from 0.0 to 1.0.<br/>The default value is <c>0.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetRelationLeft(CoreUI.Gfx.IEntity child, CoreUI.Gfx.IEntity kw_base, CoreUI.Gfx.Align relative_position) {
            CoreUI.UI.RelativeContainer.NativeMethods.efl_ui_relative_container_relation_left_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), child, kw_base, relative_position);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Specifies the right side edge of the <c>child</c> object relative to the <c>base</c> object. When <c>relative_position</c> is 0 the right edge of the <c>child</c> object is aligned to the left edge of the <c>base</c> object. When <c>relative_position</c> is 1 the right edges of the two objects are aligned.</summary>
        /// <param name="child">The child object whose size and position is being changed.</param>
        /// <param name="kw_base">The object whose size and position is being used as reference. <c>NULL</c> means that the container object is used (this is the default value).</param>
        /// <param name="relative_position">The ratio between left and right of the base, ranging from 0.0 to 1.0.<br/>The default value is <c>1.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetRelationRight(CoreUI.Gfx.IEntity child, out CoreUI.Gfx.IEntity kw_base, out CoreUI.Gfx.Align relative_position) {
            CoreUI.UI.RelativeContainer.NativeMethods.efl_ui_relative_container_relation_right_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), child, out kw_base, out relative_position);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Specifies the right side edge of the <c>child</c> object relative to the <c>base</c> object. When <c>relative_position</c> is 0 the right edge of the <c>child</c> object is aligned to the left edge of the <c>base</c> object. When <c>relative_position</c> is 1 the right edges of the two objects are aligned.</summary>
        /// <param name="child">The child object whose size and position is being changed.</param>
        /// <param name="kw_base">The object whose size and position is being used as reference. <c>NULL</c> means that the container object is used (this is the default value).</param>
        /// <param name="relative_position">The ratio between left and right of the base, ranging from 0.0 to 1.0.<br/>The default value is <c>1.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetRelationRight(CoreUI.Gfx.IEntity child, CoreUI.Gfx.IEntity kw_base, CoreUI.Gfx.Align relative_position) {
            CoreUI.UI.RelativeContainer.NativeMethods.efl_ui_relative_container_relation_right_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), child, kw_base, relative_position);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Specifies the top side edge of the <c>child</c> object relative to the <c>base</c> object. When <c>relative_position</c> is 0 the top edges of the two objects are aligned. When <c>relative_position</c> is 1 the top edge of the <c>child</c> object is aligned to the bottom edge of the <c>base</c> object.</summary>
        /// <param name="child">The child object whose size and position is being changed.</param>
        /// <param name="kw_base">The object whose size and position is being used as reference. <c>NULL</c> means that the container object is used (this is the default value).</param>
        /// <param name="relative_position">The ratio between top and bottom of the base, ranging from 0.0 to 1.0.<br/>The default value is <c>0.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetRelationTop(CoreUI.Gfx.IEntity child, out CoreUI.Gfx.IEntity kw_base, out CoreUI.Gfx.Align relative_position) {
            CoreUI.UI.RelativeContainer.NativeMethods.efl_ui_relative_container_relation_top_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), child, out kw_base, out relative_position);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Specifies the top side edge of the <c>child</c> object relative to the <c>base</c> object. When <c>relative_position</c> is 0 the top edges of the two objects are aligned. When <c>relative_position</c> is 1 the top edge of the <c>child</c> object is aligned to the bottom edge of the <c>base</c> object.</summary>
        /// <param name="child">The child object whose size and position is being changed.</param>
        /// <param name="kw_base">The object whose size and position is being used as reference. <c>NULL</c> means that the container object is used (this is the default value).</param>
        /// <param name="relative_position">The ratio between top and bottom of the base, ranging from 0.0 to 1.0.<br/>The default value is <c>0.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetRelationTop(CoreUI.Gfx.IEntity child, CoreUI.Gfx.IEntity kw_base, CoreUI.Gfx.Align relative_position) {
            CoreUI.UI.RelativeContainer.NativeMethods.efl_ui_relative_container_relation_top_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), child, kw_base, relative_position);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Specifies the bottom side edge of the <c>child</c> object relative to the <c>base</c> object. When <c>relative_position</c> is 0 the bottom edge of the <c>child</c> object is aligned to the top edge of the <c>base</c> object. When <c>relative_position</c> is 1 the bottom edges of the two objects are aligned.</summary>
        /// <param name="child">The child object whose size and position is being changed.</param>
        /// <param name="kw_base">The object whose size and position is being used as reference. <c>NULL</c> means that the container object is used (this is the default value).</param>
        /// <param name="relative_position">The ratio between top and bottom of the base, ranging from 0.0 to 1.0.<br/>The default value is <c>1.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetRelationBottom(CoreUI.Gfx.IEntity child, out CoreUI.Gfx.IEntity kw_base, out CoreUI.Gfx.Align relative_position) {
            CoreUI.UI.RelativeContainer.NativeMethods.efl_ui_relative_container_relation_bottom_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), child, out kw_base, out relative_position);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Specifies the bottom side edge of the <c>child</c> object relative to the <c>base</c> object. When <c>relative_position</c> is 0 the bottom edge of the <c>child</c> object is aligned to the top edge of the <c>base</c> object. When <c>relative_position</c> is 1 the bottom edges of the two objects are aligned.</summary>
        /// <param name="child">The child object whose size and position is being changed.</param>
        /// <param name="kw_base">The object whose size and position is being used as reference. <c>NULL</c> means that the container object is used (this is the default value).</param>
        /// <param name="relative_position">The ratio between top and bottom of the base, ranging from 0.0 to 1.0.<br/>The default value is <c>1.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetRelationBottom(CoreUI.Gfx.IEntity child, CoreUI.Gfx.IEntity kw_base, CoreUI.Gfx.Align relative_position) {
            CoreUI.UI.RelativeContainer.NativeMethods.efl_ui_relative_container_relation_bottom_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), child, kw_base, relative_position);
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

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.RelativeContainer.efl_ui_relative_container_class_get();
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

                if (efl_ui_relative_container_relation_left_get_static_delegate == null)
                {
                    efl_ui_relative_container_relation_left_get_static_delegate = new efl_ui_relative_container_relation_left_get_delegate(relation_left_get);
                }

                if (methods.Contains("GetRelationLeft"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_container_relation_left_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_container_relation_left_get_static_delegate) });
                }

                if (efl_ui_relative_container_relation_left_set_static_delegate == null)
                {
                    efl_ui_relative_container_relation_left_set_static_delegate = new efl_ui_relative_container_relation_left_set_delegate(relation_left_set);
                }

                if (methods.Contains("SetRelationLeft"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_container_relation_left_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_container_relation_left_set_static_delegate) });
                }

                if (efl_ui_relative_container_relation_right_get_static_delegate == null)
                {
                    efl_ui_relative_container_relation_right_get_static_delegate = new efl_ui_relative_container_relation_right_get_delegate(relation_right_get);
                }

                if (methods.Contains("GetRelationRight"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_container_relation_right_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_container_relation_right_get_static_delegate) });
                }

                if (efl_ui_relative_container_relation_right_set_static_delegate == null)
                {
                    efl_ui_relative_container_relation_right_set_static_delegate = new efl_ui_relative_container_relation_right_set_delegate(relation_right_set);
                }

                if (methods.Contains("SetRelationRight"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_container_relation_right_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_container_relation_right_set_static_delegate) });
                }

                if (efl_ui_relative_container_relation_top_get_static_delegate == null)
                {
                    efl_ui_relative_container_relation_top_get_static_delegate = new efl_ui_relative_container_relation_top_get_delegate(relation_top_get);
                }

                if (methods.Contains("GetRelationTop"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_container_relation_top_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_container_relation_top_get_static_delegate) });
                }

                if (efl_ui_relative_container_relation_top_set_static_delegate == null)
                {
                    efl_ui_relative_container_relation_top_set_static_delegate = new efl_ui_relative_container_relation_top_set_delegate(relation_top_set);
                }

                if (methods.Contains("SetRelationTop"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_container_relation_top_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_container_relation_top_set_static_delegate) });
                }

                if (efl_ui_relative_container_relation_bottom_get_static_delegate == null)
                {
                    efl_ui_relative_container_relation_bottom_get_static_delegate = new efl_ui_relative_container_relation_bottom_get_delegate(relation_bottom_get);
                }

                if (methods.Contains("GetRelationBottom"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_container_relation_bottom_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_container_relation_bottom_get_static_delegate) });
                }

                if (efl_ui_relative_container_relation_bottom_set_static_delegate == null)
                {
                    efl_ui_relative_container_relation_bottom_set_static_delegate = new efl_ui_relative_container_relation_bottom_set_delegate(relation_bottom_set);
                }

                if (methods.Contains("SetRelationBottom"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_container_relation_bottom_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_container_relation_bottom_set_static_delegate) });
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
                return CoreUI.UI.RelativeContainer.efl_ui_relative_container_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate void efl_ui_relative_container_relation_left_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] out CoreUI.Gfx.IEntity kw_base,  out CoreUI.Gfx.Align relative_position);

            
            internal delegate void efl_ui_relative_container_relation_left_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] out CoreUI.Gfx.IEntity kw_base,  out CoreUI.Gfx.Align relative_position);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_left_get_api_delegate> efl_ui_relative_container_relation_left_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_left_get_api_delegate>(Module, "efl_ui_relative_container_relation_left_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void relation_left_get(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity child, out CoreUI.Gfx.IEntity kw_base, out CoreUI.Gfx.Align relative_position)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_relative_container_relation_left_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    kw_base = default(CoreUI.Gfx.IEntity);relative_position = default(CoreUI.Gfx.Align);
                    try
                    {
                        ((RelativeContainer)ws.Target).GetRelationLeft(child, out kw_base, out relative_position);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_relative_container_relation_left_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), child, out kw_base, out relative_position);
                }
            }

            private static efl_ui_relative_container_relation_left_get_delegate efl_ui_relative_container_relation_left_get_static_delegate;

            
            private delegate void efl_ui_relative_container_relation_left_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity kw_base,  CoreUI.Gfx.Align relative_position);

            
            internal delegate void efl_ui_relative_container_relation_left_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity kw_base,  CoreUI.Gfx.Align relative_position);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_left_set_api_delegate> efl_ui_relative_container_relation_left_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_left_set_api_delegate>(Module, "efl_ui_relative_container_relation_left_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void relation_left_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity child, CoreUI.Gfx.IEntity kw_base, CoreUI.Gfx.Align relative_position)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_relative_container_relation_left_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((RelativeContainer)ws.Target).SetRelationLeft(child, kw_base, relative_position);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_relative_container_relation_left_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), child, kw_base, relative_position);
                }
            }

            private static efl_ui_relative_container_relation_left_set_delegate efl_ui_relative_container_relation_left_set_static_delegate;

            
            private delegate void efl_ui_relative_container_relation_right_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] out CoreUI.Gfx.IEntity kw_base,  out CoreUI.Gfx.Align relative_position);

            
            internal delegate void efl_ui_relative_container_relation_right_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] out CoreUI.Gfx.IEntity kw_base,  out CoreUI.Gfx.Align relative_position);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_right_get_api_delegate> efl_ui_relative_container_relation_right_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_right_get_api_delegate>(Module, "efl_ui_relative_container_relation_right_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void relation_right_get(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity child, out CoreUI.Gfx.IEntity kw_base, out CoreUI.Gfx.Align relative_position)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_relative_container_relation_right_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    kw_base = default(CoreUI.Gfx.IEntity);relative_position = default(CoreUI.Gfx.Align);
                    try
                    {
                        ((RelativeContainer)ws.Target).GetRelationRight(child, out kw_base, out relative_position);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_relative_container_relation_right_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), child, out kw_base, out relative_position);
                }
            }

            private static efl_ui_relative_container_relation_right_get_delegate efl_ui_relative_container_relation_right_get_static_delegate;

            
            private delegate void efl_ui_relative_container_relation_right_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity kw_base,  CoreUI.Gfx.Align relative_position);

            
            internal delegate void efl_ui_relative_container_relation_right_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity kw_base,  CoreUI.Gfx.Align relative_position);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_right_set_api_delegate> efl_ui_relative_container_relation_right_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_right_set_api_delegate>(Module, "efl_ui_relative_container_relation_right_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void relation_right_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity child, CoreUI.Gfx.IEntity kw_base, CoreUI.Gfx.Align relative_position)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_relative_container_relation_right_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((RelativeContainer)ws.Target).SetRelationRight(child, kw_base, relative_position);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_relative_container_relation_right_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), child, kw_base, relative_position);
                }
            }

            private static efl_ui_relative_container_relation_right_set_delegate efl_ui_relative_container_relation_right_set_static_delegate;

            
            private delegate void efl_ui_relative_container_relation_top_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] out CoreUI.Gfx.IEntity kw_base,  out CoreUI.Gfx.Align relative_position);

            
            internal delegate void efl_ui_relative_container_relation_top_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] out CoreUI.Gfx.IEntity kw_base,  out CoreUI.Gfx.Align relative_position);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_top_get_api_delegate> efl_ui_relative_container_relation_top_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_top_get_api_delegate>(Module, "efl_ui_relative_container_relation_top_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void relation_top_get(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity child, out CoreUI.Gfx.IEntity kw_base, out CoreUI.Gfx.Align relative_position)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_relative_container_relation_top_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    kw_base = default(CoreUI.Gfx.IEntity);relative_position = default(CoreUI.Gfx.Align);
                    try
                    {
                        ((RelativeContainer)ws.Target).GetRelationTop(child, out kw_base, out relative_position);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_relative_container_relation_top_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), child, out kw_base, out relative_position);
                }
            }

            private static efl_ui_relative_container_relation_top_get_delegate efl_ui_relative_container_relation_top_get_static_delegate;

            
            private delegate void efl_ui_relative_container_relation_top_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity kw_base,  CoreUI.Gfx.Align relative_position);

            
            internal delegate void efl_ui_relative_container_relation_top_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity kw_base,  CoreUI.Gfx.Align relative_position);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_top_set_api_delegate> efl_ui_relative_container_relation_top_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_top_set_api_delegate>(Module, "efl_ui_relative_container_relation_top_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void relation_top_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity child, CoreUI.Gfx.IEntity kw_base, CoreUI.Gfx.Align relative_position)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_relative_container_relation_top_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((RelativeContainer)ws.Target).SetRelationTop(child, kw_base, relative_position);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_relative_container_relation_top_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), child, kw_base, relative_position);
                }
            }

            private static efl_ui_relative_container_relation_top_set_delegate efl_ui_relative_container_relation_top_set_static_delegate;

            
            private delegate void efl_ui_relative_container_relation_bottom_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] out CoreUI.Gfx.IEntity kw_base,  out CoreUI.Gfx.Align relative_position);

            
            internal delegate void efl_ui_relative_container_relation_bottom_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] out CoreUI.Gfx.IEntity kw_base,  out CoreUI.Gfx.Align relative_position);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_bottom_get_api_delegate> efl_ui_relative_container_relation_bottom_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_bottom_get_api_delegate>(Module, "efl_ui_relative_container_relation_bottom_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void relation_bottom_get(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity child, out CoreUI.Gfx.IEntity kw_base, out CoreUI.Gfx.Align relative_position)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_relative_container_relation_bottom_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    kw_base = default(CoreUI.Gfx.IEntity);relative_position = default(CoreUI.Gfx.Align);
                    try
                    {
                        ((RelativeContainer)ws.Target).GetRelationBottom(child, out kw_base, out relative_position);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_relative_container_relation_bottom_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), child, out kw_base, out relative_position);
                }
            }

            private static efl_ui_relative_container_relation_bottom_get_delegate efl_ui_relative_container_relation_bottom_get_static_delegate;

            
            private delegate void efl_ui_relative_container_relation_bottom_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity kw_base,  CoreUI.Gfx.Align relative_position);

            
            internal delegate void efl_ui_relative_container_relation_bottom_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity kw_base,  CoreUI.Gfx.Align relative_position);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_bottom_set_api_delegate> efl_ui_relative_container_relation_bottom_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_relative_container_relation_bottom_set_api_delegate>(Module, "efl_ui_relative_container_relation_bottom_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void relation_bottom_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity child, CoreUI.Gfx.IEntity kw_base, CoreUI.Gfx.Align relative_position)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_relative_container_relation_bottom_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((RelativeContainer)ws.Target).SetRelationBottom(child, kw_base, relative_position);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_relative_container_relation_bottom_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), child, kw_base, relative_position);
                }
            }

            private static efl_ui_relative_container_relation_bottom_set_delegate efl_ui_relative_container_relation_bottom_set_static_delegate;

            
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
                        ((RelativeContainer)ws.Target).UpdateLayout();
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

