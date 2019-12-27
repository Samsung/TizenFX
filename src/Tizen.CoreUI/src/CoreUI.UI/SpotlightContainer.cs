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
namespace CoreUI.UI.Spotlight {
    /// <summary>The Spotlight widget is a container for other sub-widgets, where only one sub-widget is active at any given time.
    /// 
    /// Sub-widgets are added using the <see cref="CoreUI.IPackLinear"/> interface and the active one (the one in the &quot;spotlight&quot;) is selected using <see cref="CoreUI.UI.Spotlight.Container.ActiveElement"/>.
    /// 
    /// The way the different sub-widgets are rendered can be customized through the <span class="text-muted">CoreUI.UI.Spotlight.Container.SpotlightManager (object still in beta stage)</span> object. For example, only the active sub-widget might be shown, or it might be shown in a central position whereas the other sub-widgets are displayed on the sides, or grayed-out. All sub-widgets are displayed with the same size, selected with <see cref="CoreUI.UI.Spotlight.Container.SpotlightSize"/>.
    /// 
    /// Additionally, the transition from one sub-widget to another can be animated. This animation is also controlled by the <span class="text-muted">CoreUI.UI.Spotlight.Container.SpotlightManager (object still in beta stage)</span> object.
    /// 
    /// Also, an indicator widget can be used to show a visual cue of how many sub-widgets are there and which one is the active one.
    /// 
    /// This class can be used to create other widgets like Pagers, Tabbed pagers or Stacks, where each sub-widget represents a &quot;page&quot; full of other widgets. All these cases can be implemented with a different <span class="text-muted">CoreUI.UI.Spotlight.Container.SpotlightManager (object still in beta stage)</span> and use the same <see cref="CoreUI.UI.Spotlight.Container"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Spotlight.Container.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Container : CoreUI.UI.Widget, CoreUI.IContainer, CoreUI.IPack, CoreUI.IPackLinear
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Container))
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
            efl_ui_spotlight_container_class_get();

        /// <summary>Initializes a new instance of the <see cref="Container"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Container(CoreUI.Object parent, System.String style = null) : base(efl_ui_spotlight_container_class_get(), parent)
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
        protected Container(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Container"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Container(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Container"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Container(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
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

        /// <summary>Currently active sub-widget (the one with the spotlight) among all the sub-widgets added to this widget
        /// 
        /// Changing this value might trigger an animation.</summary>
        /// <returns>Sub-widget that has the spotlight. The element has to be added prior to this call via the <see cref="CoreUI.IPackLinear"/> interface.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.Widget GetActiveElement() {
            var _ret_var = CoreUI.UI.Spotlight.Container.NativeMethods.efl_ui_spotlight_active_element_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Currently active sub-widget (the one with the spotlight) among all the sub-widgets added to this widget
        /// 
        /// Changing this value might trigger an animation.</summary>
        /// <param name="element">Sub-widget that has the spotlight. The element has to be added prior to this call via the <see cref="CoreUI.IPackLinear"/> interface.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetActiveElement(CoreUI.UI.Widget element) {
            CoreUI.UI.Spotlight.Container.NativeMethods.efl_ui_spotlight_active_element_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), element);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The size to use when displaying the Sub-Widget which has the spotlight. This is used by the <span class="text-muted">CoreUI.UI.Spotlight.Container.SpotlightManager (object still in beta stage)</span> to perform the rendering. Sub-Widgets other than the Active one may or may not use this size.</summary>
        /// <returns>Render size for the spotlight. (-1, -1) means that all available space inside the container can be used.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetSpotlightSize() {
            var _ret_var = CoreUI.UI.Spotlight.Container.NativeMethods.efl_ui_spotlight_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The size to use when displaying the Sub-Widget which has the spotlight. This is used by the <span class="text-muted">CoreUI.UI.Spotlight.Container.SpotlightManager (object still in beta stage)</span> to perform the rendering. Sub-Widgets other than the Active one may or may not use this size.</summary>
        /// <param name="size">Render size for the spotlight. (-1, -1) means that all available space inside the container can be used.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetSpotlightSize(CoreUI.DataTypes.Size2D size) {
            CoreUI.DataTypes.Size2D _in_size = size;
CoreUI.UI.Spotlight.Container.NativeMethods.efl_ui_spotlight_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_size);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>When this flag is <c>true</c> the transitions caused by <see cref="CoreUI.UI.Spotlight.Container.Push"/>, <see cref="CoreUI.UI.Spotlight.Container.Pop"/> or <see cref="CoreUI.UI.Spotlight.Container.ActiveElement"/> are animated (if the <span class="text-muted">CoreUI.UI.Spotlight.Container.SpotlightManager (object still in beta stage)</span> supports that). <c>false</c> means immidiate displaying at the final position.</summary>
        /// <returns><c>true</c> to enable animated transitions. If <c>false</c>, then any transition is displayed at the final position immidiatly</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetAnimatedTransition() {
            var _ret_var = CoreUI.UI.Spotlight.Container.NativeMethods.efl_ui_spotlight_animated_transition_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>When this flag is <c>true</c> the transitions caused by <see cref="CoreUI.UI.Spotlight.Container.Push"/>, <see cref="CoreUI.UI.Spotlight.Container.Pop"/> or <see cref="CoreUI.UI.Spotlight.Container.ActiveElement"/> are animated (if the <span class="text-muted">CoreUI.UI.Spotlight.Container.SpotlightManager (object still in beta stage)</span> supports that). <c>false</c> means immidiate displaying at the final position.</summary>
        /// <param name="enable"><c>true</c> to enable animated transitions. If <c>false</c>, then any transition is displayed at the final position immidiatly</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetAnimatedTransition(bool enable) {
            CoreUI.UI.Spotlight.Container.NativeMethods.efl_ui_spotlight_animated_transition_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), enable);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Packs a new sub-widget after <see cref="CoreUI.UI.Spotlight.Container.ActiveElement"/>, and move the spotlight there.
        /// 
        /// This is the same behavior as a push operation on a stack. When sub-widgets are added using only <see cref="CoreUI.UI.Spotlight.Container.Push"/> and <see cref="CoreUI.UI.Spotlight.Container.Pop"/> you don&apos;t have to worry about <see cref="CoreUI.UI.Spotlight.Container.ActiveElement"/> since only the last sub-widget is manipulated, and this container behaves like a traditional stack.
        /// 
        /// An animation might be triggered to give the new sub-widget the spotlight and come into position.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="widget">Sub-Widget to add and set to be the spotlight sub-widget.</param>
        public virtual void Push(CoreUI.Gfx.IEntity widget) {
            CoreUI.UI.Spotlight.Container.NativeMethods.efl_ui_spotlight_push_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), widget);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Removes the sub-widget that has the spotlight from the widget.
        /// 
        /// The spotlight is moved to the previous sub-widget. This is the same behavior as a pop operation on a stack. When sub-widgets are added using only <see cref="CoreUI.UI.Spotlight.Container.Push"/> and <see cref="CoreUI.UI.Spotlight.Container.Pop"/> you don&apos;t have to worry about <see cref="CoreUI.UI.Spotlight.Container.ActiveElement"/> since only the last sub-widget is manipulated, and this container behaves like a traditional stack.
        /// 
        /// An animation might be triggered to give the new sub-widget the spotlight, come into position and the old one disappear.
        /// 
        /// The removed sub-widget can be returned to the caller or deleted (depending on <c>delete_on_transition_end</c>).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="deletion_on_transition_end">If <c>true</c>, then the object will be deleted before resolving the future, and a <c>NULL</c> pointer is the value of the future. <c>false</c> if no operation should be applied to it.</param>
        /// <returns>This Future gets resolved when any transition animation finishes and the popped sub-widget is ready for collection. If there is no animation, the Future resolves immediately. If <c>deletion_on_transition_end</c> is <c>true</c> then this widget will destroy the popped sub-widget and the Future will contain no Value. Otherwise, the caller becomes the owner of the sub-widget contained in the Future and must dispose of it appropriately.</returns>
        public virtual  CoreUI.DataTypes.Future Pop(bool deletion_on_transition_end) {
            var _ret_var = CoreUI.UI.Spotlight.Container.NativeMethods.efl_ui_spotlight_pop_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), deletion_on_transition_end);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
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

        /// <summary>Async wrapper for <see cref="Pop" />.
        /// </summary>
    /// <param name="deletion_on_transition_end">If <c>true</c>, then the object will be deleted before resolving the future, and a <c>NULL</c> pointer is the value of the future. <c>false</c> if no operation should be applied to it.</param>
        /// <param name="token">Token to notify the async operation of external request to cancel.</param>
        /// <returns>An async task wrapping the result of the operation.</returns>
        public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> PopAsync(bool deletion_on_transition_end,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
        {
            CoreUI.DataTypes.Future future = Pop( deletion_on_transition_end);
            return CoreUI.Wrapper.Globals.WrapAsync(future, token);
        }

        /// <summary>Currently active sub-widget (the one with the spotlight) among all the sub-widgets added to this widget
        /// 
        /// Changing this value might trigger an animation.</summary>
        /// <value>Sub-widget that has the spotlight. The element has to be added prior to this call via the <see cref="CoreUI.IPackLinear"/> interface.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.Widget ActiveElement {
            get { return GetActiveElement(); }
            set { SetActiveElement(value); }
        }

        /// <summary>The size to use when displaying the Sub-Widget which has the spotlight. This is used by the <span class="text-muted">CoreUI.UI.Spotlight.Container.SpotlightManager (object still in beta stage)</span> to perform the rendering. Sub-Widgets other than the Active one may or may not use this size.</summary>
        /// <value>Render size for the spotlight. (-1, -1) means that all available space inside the container can be used.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D SpotlightSize {
            get { return GetSpotlightSize(); }
            set { SetSpotlightSize(value); }
        }

        /// <summary>When this flag is <c>true</c> the transitions caused by <see cref="CoreUI.UI.Spotlight.Container.Push"/>, <see cref="CoreUI.UI.Spotlight.Container.Pop"/> or <see cref="CoreUI.UI.Spotlight.Container.ActiveElement"/> are animated (if the <span class="text-muted">CoreUI.UI.Spotlight.Container.SpotlightManager (object still in beta stage)</span> supports that). <c>false</c> means immidiate displaying at the final position.</summary>
        /// <value><c>true</c> to enable animated transitions. If <c>false</c>, then any transition is displayed at the final position immidiatly</value>
        /// <since_tizen> 6 </since_tizen>
        public bool AnimatedTransition {
            get { return GetAnimatedTransition(); }
            set { SetAnimatedTransition(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Spotlight.Container.efl_ui_spotlight_container_class_get();
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

                if (efl_ui_spotlight_active_element_get_static_delegate == null)
                {
                    efl_ui_spotlight_active_element_get_static_delegate = new efl_ui_spotlight_active_element_get_delegate(active_element_get);
                }

                if (methods.Contains("GetActiveElement"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_active_element_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_active_element_get_static_delegate) });
                }

                if (efl_ui_spotlight_active_element_set_static_delegate == null)
                {
                    efl_ui_spotlight_active_element_set_static_delegate = new efl_ui_spotlight_active_element_set_delegate(active_element_set);
                }

                if (methods.Contains("SetActiveElement"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_active_element_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_active_element_set_static_delegate) });
                }

                if (efl_ui_spotlight_size_get_static_delegate == null)
                {
                    efl_ui_spotlight_size_get_static_delegate = new efl_ui_spotlight_size_get_delegate(spotlight_size_get);
                }

                if (methods.Contains("GetSpotlightSize"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_size_get_static_delegate) });
                }

                if (efl_ui_spotlight_size_set_static_delegate == null)
                {
                    efl_ui_spotlight_size_set_static_delegate = new efl_ui_spotlight_size_set_delegate(spotlight_size_set);
                }

                if (methods.Contains("SetSpotlightSize"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_size_set_static_delegate) });
                }

                if (efl_ui_spotlight_animated_transition_get_static_delegate == null)
                {
                    efl_ui_spotlight_animated_transition_get_static_delegate = new efl_ui_spotlight_animated_transition_get_delegate(animated_transition_get);
                }

                if (methods.Contains("GetAnimatedTransition"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_animated_transition_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_animated_transition_get_static_delegate) });
                }

                if (efl_ui_spotlight_animated_transition_set_static_delegate == null)
                {
                    efl_ui_spotlight_animated_transition_set_static_delegate = new efl_ui_spotlight_animated_transition_set_delegate(animated_transition_set);
                }

                if (methods.Contains("SetAnimatedTransition"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_animated_transition_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_animated_transition_set_static_delegate) });
                }

                if (efl_ui_spotlight_push_static_delegate == null)
                {
                    efl_ui_spotlight_push_static_delegate = new efl_ui_spotlight_push_delegate(push);
                }

                if (methods.Contains("Push"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_push"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_push_static_delegate) });
                }

                if (efl_ui_spotlight_pop_static_delegate == null)
                {
                    efl_ui_spotlight_pop_static_delegate = new efl_ui_spotlight_pop_delegate(pop);
                }

                if (methods.Contains("Pop"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_pop"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_pop_static_delegate) });
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
                return CoreUI.UI.Spotlight.Container.efl_ui_spotlight_container_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.UI.Widget efl_ui_spotlight_active_element_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.UI.Widget efl_ui_spotlight_active_element_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_active_element_get_api_delegate> efl_ui_spotlight_active_element_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_active_element_get_api_delegate>(Module, "efl_ui_spotlight_active_element_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.UI.Widget active_element_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_spotlight_active_element_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.UI.Widget _ret_var = default(CoreUI.UI.Widget);
                    try
                    {
                        _ret_var = ((Container)ws.Target).GetActiveElement();
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
                    return efl_ui_spotlight_active_element_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_spotlight_active_element_get_delegate efl_ui_spotlight_active_element_get_static_delegate;

            
            private delegate void efl_ui_spotlight_active_element_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Widget element);

            
            internal delegate void efl_ui_spotlight_active_element_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Widget element);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_active_element_set_api_delegate> efl_ui_spotlight_active_element_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_active_element_set_api_delegate>(Module, "efl_ui_spotlight_active_element_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void active_element_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.Widget element)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_spotlight_active_element_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Container)ws.Target).SetActiveElement(element);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_spotlight_active_element_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), element);
                }
            }

            private static efl_ui_spotlight_active_element_set_delegate efl_ui_spotlight_active_element_set_static_delegate;

            
            private delegate CoreUI.DataTypes.Size2D efl_ui_spotlight_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.DataTypes.Size2D efl_ui_spotlight_size_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_size_get_api_delegate> efl_ui_spotlight_size_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_size_get_api_delegate>(Module, "efl_ui_spotlight_size_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Size2D spotlight_size_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_spotlight_size_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                    try
                    {
                        _ret_var = ((Container)ws.Target).GetSpotlightSize();
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
                    return efl_ui_spotlight_size_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_spotlight_size_get_delegate efl_ui_spotlight_size_get_static_delegate;

            
            private delegate void efl_ui_spotlight_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Size2D size);

            
            internal delegate void efl_ui_spotlight_size_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Size2D size);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_size_set_api_delegate> efl_ui_spotlight_size_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_size_set_api_delegate>(Module, "efl_ui_spotlight_size_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void spotlight_size_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Size2D size)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_spotlight_size_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Size2D _in_size = size;

                    try
                    {
                        ((Container)ws.Target).SetSpotlightSize(_in_size);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_spotlight_size_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), size);
                }
            }

            private static efl_ui_spotlight_size_set_delegate efl_ui_spotlight_size_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_spotlight_animated_transition_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_spotlight_animated_transition_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_animated_transition_get_api_delegate> efl_ui_spotlight_animated_transition_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_animated_transition_get_api_delegate>(Module, "efl_ui_spotlight_animated_transition_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool animated_transition_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_spotlight_animated_transition_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Container)ws.Target).GetAnimatedTransition();
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
                    return efl_ui_spotlight_animated_transition_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_spotlight_animated_transition_get_delegate efl_ui_spotlight_animated_transition_get_static_delegate;

            
            private delegate void efl_ui_spotlight_animated_transition_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable);

            
            internal delegate void efl_ui_spotlight_animated_transition_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_animated_transition_set_api_delegate> efl_ui_spotlight_animated_transition_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_animated_transition_set_api_delegate>(Module, "efl_ui_spotlight_animated_transition_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void animated_transition_set(System.IntPtr obj, System.IntPtr pd, bool enable)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_spotlight_animated_transition_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Container)ws.Target).SetAnimatedTransition(enable);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_spotlight_animated_transition_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), enable);
                }
            }

            private static efl_ui_spotlight_animated_transition_set_delegate efl_ui_spotlight_animated_transition_set_static_delegate;

            
            private delegate void efl_ui_spotlight_push_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity widget);

            
            internal delegate void efl_ui_spotlight_push_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity widget);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_push_api_delegate> efl_ui_spotlight_push_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_push_api_delegate>(Module, "efl_ui_spotlight_push");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void push(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity widget)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_spotlight_push was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Container)ws.Target).Push(widget);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_spotlight_push_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), widget);
                }
            }

            private static efl_ui_spotlight_push_delegate efl_ui_spotlight_push_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
            private delegate  CoreUI.DataTypes.Future efl_ui_spotlight_pop_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool deletion_on_transition_end);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
            internal delegate  CoreUI.DataTypes.Future efl_ui_spotlight_pop_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool deletion_on_transition_end);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_pop_api_delegate> efl_ui_spotlight_pop_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_spotlight_pop_api_delegate>(Module, "efl_ui_spotlight_pop");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static  CoreUI.DataTypes.Future pop(System.IntPtr obj, System.IntPtr pd, bool deletion_on_transition_end)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_spotlight_pop was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                     CoreUI.DataTypes.Future _ret_var = default( CoreUI.DataTypes.Future);
                    try
                    {
                        _ret_var = ((Container)ws.Target).Pop(deletion_on_transition_end);
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
                    return efl_ui_spotlight_pop_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), deletion_on_transition_end);
                }
            }

            private static efl_ui_spotlight_pop_delegate efl_ui_spotlight_pop_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI.Spotlight {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class ContainerExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.Widget> ActiveElement<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Spotlight.Container, T>magic = null) where T : CoreUI.UI.Spotlight.Container {
            return new CoreUI.BindableProperty<CoreUI.UI.Widget>("active_element", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> SpotlightSize<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Spotlight.Container, T>magic = null) where T : CoreUI.UI.Spotlight.Container {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("spotlight_size", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> AnimatedTransition<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Spotlight.Container, T>magic = null) where T : CoreUI.UI.Spotlight.Container {
            return new CoreUI.BindableProperty<bool>("animated_transition", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

