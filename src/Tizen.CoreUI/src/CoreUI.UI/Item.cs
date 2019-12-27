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
    /// <summary>Selectable Item abstraction.
    /// 
    /// This class serves as the basis to create widgets acting as selectable items inside containers like <see cref="CoreUI.UI.List"/> or <see cref="CoreUI.UI.Grid"/>, for example.
    /// 
    /// <see cref="CoreUI.UI.Item"/> provides user interaction through the <see cref="CoreUI.Input.IClickable"/> mixin. Items can be pressed, long-pressed, etc, and appropriate events are generated. <see cref="CoreUI.UI.Item"/> also implements the <see cref="CoreUI.UI.ISelectable"/> interface, meaning that &quot;selected&quot; and &quot;unselected&quot; events are automatically generated.
    /// 
    /// Classes inheriting from this one only need to deal with the visual representation of the widget. See for example <see cref="CoreUI.UI.GridDefaultItem"/> and <see cref="CoreUI.UI.ListDefaultItem"/>.
    /// 
    /// Some events are converted to edje signals so the theme can react to them: <see cref="CoreUI.Input.IClickable.Pressed"/> -&gt; &quot;efl,state,pressed&quot;, <see cref="CoreUI.Input.IClickable.Unpressed"/> -&gt; &quot;efl,state,unpressed&quot;, <see cref="CoreUI.UI.ISelectable.SelectedChanged"/> (true) -&gt; &quot;efl,state,selected&quot;, <see cref="CoreUI.UI.ISelectable.SelectedChanged"/> (false) -&gt; &quot;efl,state,unselected&quot;.
    /// 
    /// Item grouping inside containers is handled through the <span class="text-muted">CoreUI.UI.GroupItem (object still in beta stage)</span> class.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Item.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract class Item : CoreUI.UI.LayoutBase, CoreUI.Input.IClickable, CoreUI.UI.ISelectable
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Item))
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
            efl_ui_item_class_get();

        /// <summary>Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Item(CoreUI.Object parent, System.String style = null) : base(efl_ui_item_class_get(), parent)
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
        protected Item(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Item"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Item(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        [CoreUI.Wrapper.PrivateNativeClass]
        private class ItemRealized : Item
        {
            private ItemRealized(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
            {
            }
        }
        /// <summary>Initializes a new instance of the <see cref="Item"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Item(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Called when object is in sequence pressed and unpressed by the primary button</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickableClickedEventArgs"/></value>
        public event EventHandler<CoreUI.Input.ClickableClickedEventArgs> Clicked
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickableClickedEventArgs{ Arg =  info });
                string key = "_EFL_INPUT_EVENT_CLICKED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_INPUT_EVENT_CLICKED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Clicked.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnClicked(CoreUI.Input.ClickableClickedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_INPUT_EVENT_CLICKED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickableClickedAnyEventArgs"/></value>
        public event EventHandler<CoreUI.Input.ClickableClickedAnyEventArgs> ClickedAny
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickableClickedAnyEventArgs{ Arg =  info });
                string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ClickedAny.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnClickedAny(CoreUI.Input.ClickableClickedAnyEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_INPUT_EVENT_CLICKED_ANY", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when the object is pressed, event_info is the button that got pressed</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickablePressedEventArgs"/></value>
        public event EventHandler<CoreUI.Input.ClickablePressedEventArgs> Pressed
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickablePressedEventArgs{ Arg = Marshal.ReadInt32(info) });
                string key = "_EFL_INPUT_EVENT_PRESSED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_INPUT_EVENT_PRESSED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Pressed.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPressed(CoreUI.Input.ClickablePressedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_INPUT_EVENT_PRESSED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when the object is no longer pressed, event_info is the button that got pressed</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickableUnpressedEventArgs"/></value>
        public event EventHandler<CoreUI.Input.ClickableUnpressedEventArgs> Unpressed
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickableUnpressedEventArgs{ Arg = Marshal.ReadInt32(info) });
                string key = "_EFL_INPUT_EVENT_UNPRESSED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_INPUT_EVENT_UNPRESSED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Unpressed.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnUnpressed(CoreUI.Input.ClickableUnpressedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_INPUT_EVENT_UNPRESSED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when the object receives a long press, event_info is the button that got pressed</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickableLongpressedEventArgs"/></value>
        public event EventHandler<CoreUI.Input.ClickableLongpressedEventArgs> Longpressed
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickableLongpressedEventArgs{ Arg = Marshal.ReadInt32(info) });
                string key = "_EFL_INPUT_EVENT_LONGPRESSED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_INPUT_EVENT_LONGPRESSED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Longpressed.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnLongpressed(CoreUI.Input.ClickableLongpressedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_INPUT_EVENT_LONGPRESSED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when the selected state has changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.SelectableSelectedChangedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.SelectableSelectedChangedEventArgs> SelectedChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.SelectableSelectedChangedEventArgs{ Arg = Marshal.ReadByte(info) != 0 });
                string key = "_EFL_UI_EVENT_SELECTED_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_SELECTED_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event SelectedChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnSelectedChanged(CoreUI.UI.SelectableSelectedChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg ? (byte) 1 : (byte) 0);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_SELECTED_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>The index of this item inside its container.
        /// 
        /// The container must be set through the <see cref="CoreUI.UI.Item.Container"/> property and be exposing an <see cref="CoreUI.IPackLinear"/> interface. If the container is not an <see cref="CoreUI.IPackLinear"/>, -1 will be returned.
        /// 
        /// Finally, it is a very slow API that must not be used in any performance constrained case.</summary>
        /// <returns>The index where to find this item in its <see cref="CoreUI.UI.Item.Container"/>.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetIndex() {
            var _ret_var = CoreUI.UI.Item.NativeMethods.efl_ui_item_index_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The container this object is part of.
        /// 
        /// You should never use this property directly, the container will set it when the item is added. Unsetting this while the item is packed inside a container does not remove the item from the container.</summary>
        /// <returns>The container this item is in.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.Widget GetContainer() {
            var _ret_var = CoreUI.UI.Item.NativeMethods.efl_ui_item_container_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The container this object is part of.
        /// 
        /// You should never use this property directly, the container will set it when the item is added. Unsetting this while the item is packed inside a container does not remove the item from the container.</summary>
        /// <param name="container">The container this item is in.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetContainer(CoreUI.UI.Widget container) {
            CoreUI.UI.Item.NativeMethods.efl_ui_item_container_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), container);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The parent of the item.
        /// 
        /// This property expresses a tree structure of items. If the parent is <c>NULL</c> the item is added to the root level of the content. The item parent can only be set once. When the object is invalidated, the item parent is set to <c>NULL</c> and still cannot be reset.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.Item GetItemParent() {
            var _ret_var = CoreUI.UI.Item.NativeMethods.efl_ui_item_parent_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The parent of the item.
        /// 
        /// This property expresses a tree structure of items. If the parent is <c>NULL</c> the item is added to the root level of the content. The item parent can only be set once. When the object is invalidated, the item parent is set to <c>NULL</c> and still cannot be reset.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetItemParent(CoreUI.UI.Item parent) {
            CoreUI.UI.Item.NativeMethods.efl_ui_item_parent_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), parent);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>If the item has its calc locked it will not trigger <see cref="CoreUI.Canvas.Group.SetGroupNeedRecalculate"/> done.
        /// 
        /// This is done automatically by <see cref="CoreUI.UI.WidgetFactory"/>, but you can use this information to meaningfully set the hint when items are not <see cref="CoreUI.UI.Item.CalcLocked"/>.</summary>
        /// <returns>If set to <c>true</c>, no more <see cref="CoreUI.Canvas.Group.SetGroupNeedRecalculate"/></returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetCalcLocked() {
            var _ret_var = CoreUI.UI.Item.NativeMethods.efl_ui_item_calc_locked_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>If the item has its calc locked it will not trigger <see cref="CoreUI.Canvas.Group.SetGroupNeedRecalculate"/> done.
        /// 
        /// This is done automatically by <see cref="CoreUI.UI.WidgetFactory"/>, but you can use this information to meaningfully set the hint when items are not <see cref="CoreUI.UI.Item.CalcLocked"/>.</summary>
        /// <param name="locked">If set to <c>true</c>, no more <see cref="CoreUI.Canvas.Group.SetGroupNeedRecalculate"/></param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetCalcLocked(bool locked) {
            CoreUI.UI.Item.NativeMethods.efl_ui_item_calc_locked_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), locked);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This returns true if the given object is currently in event emission</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetInteraction() {
            var _ret_var = CoreUI.Input.IClickableNativeMethods.efl_input_clickable_interaction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Change internal states that a button got pressed.
        /// 
        /// When the button is already pressed, this is silently ignored.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
        protected virtual void Press(uint button) {
            CoreUI.Input.IClickableNativeMethods.efl_input_clickable_press_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), button);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Change internal states that a button got unpressed.
        /// 
        /// When the button is not pressed, this is silently ignored.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
        protected virtual void Unpress(uint button) {
            CoreUI.Input.IClickableNativeMethods.efl_input_clickable_unpress_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), button);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This aborts the internal state after a press call.
        /// 
        /// This will stop the timer for longpress and set the state of the clickable mixin back into the unpressed state.</summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void ResetButtonState(uint button) {
            CoreUI.Input.IClickableNativeMethods.efl_input_clickable_button_state_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), button);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This aborts ongoing longpress event.
        /// 
        /// That is, this will stop the timer for longpress.</summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void LongpressAbort(uint button) {
            CoreUI.Input.IClickableNativeMethods.efl_input_clickable_longpress_abort_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), button);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The selected state of this object
        /// 
        /// A change to this property emits the changed event.</summary>
        /// <returns>The selected state of this object.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetSelected() {
            var _ret_var = CoreUI.UI.ISelectableNativeMethods.efl_ui_selectable_selected_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The selected state of this object
        /// 
        /// A change to this property emits the changed event.</summary>
        /// <param name="selected">The selected state of this object.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetSelected(bool selected) {
            CoreUI.UI.ISelectableNativeMethods.efl_ui_selectable_selected_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), selected);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The index of this item inside its container.
        /// 
        /// The container must be set through the <see cref="CoreUI.UI.Item.Container"/> property and be exposing an <see cref="CoreUI.IPackLinear"/> interface. If the container is not an <see cref="CoreUI.IPackLinear"/>, -1 will be returned.
        /// 
        /// Finally, it is a very slow API that must not be used in any performance constrained case.</summary>
        /// <value>The index where to find this item in its <see cref="CoreUI.UI.Item.Container"/>.</value>
        /// <since_tizen> 6 </since_tizen>
        public int Index {
            get { return GetIndex(); }
        }

        /// <summary>The container this object is part of.
        /// 
        /// You should never use this property directly, the container will set it when the item is added. Unsetting this while the item is packed inside a container does not remove the item from the container.</summary>
        /// <value>The container this item is in.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.Widget Container {
            get { return GetContainer(); }
            set { SetContainer(value); }
        }

        /// <summary>The parent of the item.
        /// 
        /// This property expresses a tree structure of items. If the parent is <c>NULL</c> the item is added to the root level of the content. The item parent can only be set once. When the object is invalidated, the item parent is set to <c>NULL</c> and still cannot be reset.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.Item ItemParent {
            get { return GetItemParent(); }
            set { SetItemParent(value); }
        }

        /// <summary>If the item has its calc locked it will not trigger <see cref="CoreUI.Canvas.Group.SetGroupNeedRecalculate"/> done.
        /// 
        /// This is done automatically by <see cref="CoreUI.UI.WidgetFactory"/>, but you can use this information to meaningfully set the hint when items are not <see cref="CoreUI.UI.Item.CalcLocked"/>.</summary>
        /// <value>If set to <c>true</c>, no more <see cref="CoreUI.Canvas.Group.SetGroupNeedRecalculate"/></value>
        /// <since_tizen> 6 </since_tizen>
        public bool CalcLocked {
            get { return GetCalcLocked(); }
            set { SetCalcLocked(value); }
        }

        /// <summary>This returns true if the given object is currently in event emission</summary>
        /// <since_tizen> 6 </since_tizen>
        public bool Interaction {
            get { return GetInteraction(); }
        }

        /// <summary>The selected state of this object
        /// 
        /// A change to this property emits the changed event.</summary>
        /// <value>The selected state of this object.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Selected {
            get { return GetSelected(); }
            set { SetSelected(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Item.efl_ui_item_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.LayoutBase.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_ui_item_index_get_static_delegate == null)
                {
                    efl_ui_item_index_get_static_delegate = new efl_ui_item_index_get_delegate(index_get);
                }

                if (methods.Contains("GetIndex"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_item_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_index_get_static_delegate) });
                }

                if (efl_ui_item_container_get_static_delegate == null)
                {
                    efl_ui_item_container_get_static_delegate = new efl_ui_item_container_get_delegate(container_get);
                }

                if (methods.Contains("GetContainer"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_item_container_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_container_get_static_delegate) });
                }

                if (efl_ui_item_container_set_static_delegate == null)
                {
                    efl_ui_item_container_set_static_delegate = new efl_ui_item_container_set_delegate(container_set);
                }

                if (methods.Contains("SetContainer"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_item_container_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_container_set_static_delegate) });
                }

                if (efl_ui_item_parent_get_static_delegate == null)
                {
                    efl_ui_item_parent_get_static_delegate = new efl_ui_item_parent_get_delegate(item_parent_get);
                }

                if (methods.Contains("GetItemParent"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_item_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_parent_get_static_delegate) });
                }

                if (efl_ui_item_parent_set_static_delegate == null)
                {
                    efl_ui_item_parent_set_static_delegate = new efl_ui_item_parent_set_delegate(item_parent_set);
                }

                if (methods.Contains("SetItemParent"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_item_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_parent_set_static_delegate) });
                }

                if (efl_ui_item_calc_locked_get_static_delegate == null)
                {
                    efl_ui_item_calc_locked_get_static_delegate = new efl_ui_item_calc_locked_get_delegate(calc_locked_get);
                }

                if (methods.Contains("GetCalcLocked"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_item_calc_locked_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_calc_locked_get_static_delegate) });
                }

                if (efl_ui_item_calc_locked_set_static_delegate == null)
                {
                    efl_ui_item_calc_locked_set_static_delegate = new efl_ui_item_calc_locked_set_delegate(calc_locked_set);
                }

                if (methods.Contains("SetCalcLocked"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_item_calc_locked_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_calc_locked_set_static_delegate) });
                }

                if (efl_input_clickable_press_static_delegate == null)
                {
                    efl_input_clickable_press_static_delegate = new efl_input_clickable_press_delegate(press);
                }

                if (methods.Contains("Press"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_press"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_press_static_delegate) });
                }

                if (efl_input_clickable_unpress_static_delegate == null)
                {
                    efl_input_clickable_unpress_static_delegate = new efl_input_clickable_unpress_delegate(unpress);
                }

                if (methods.Contains("Unpress"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_unpress"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_unpress_static_delegate) });
                }

                if (efl_input_clickable_button_state_reset_static_delegate == null)
                {
                    efl_input_clickable_button_state_reset_static_delegate = new efl_input_clickable_button_state_reset_delegate(button_state_reset);
                }

                if (methods.Contains("ResetButtonState"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_button_state_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_button_state_reset_static_delegate) });
                }

                if (efl_input_clickable_longpress_abort_static_delegate == null)
                {
                    efl_input_clickable_longpress_abort_static_delegate = new efl_input_clickable_longpress_abort_delegate(longpress_abort);
                }

                if (methods.Contains("LongpressAbort"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_longpress_abort"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_longpress_abort_static_delegate) });
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
                return CoreUI.UI.Item.efl_ui_item_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate int efl_ui_item_index_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_ui_item_index_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_item_index_get_api_delegate> efl_ui_item_index_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_item_index_get_api_delegate>(Module, "efl_ui_item_index_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int index_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_item_index_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Item)ws.Target).GetIndex();
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
                    return efl_ui_item_index_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_item_index_get_delegate efl_ui_item_index_get_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.UI.Widget efl_ui_item_container_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.UI.Widget efl_ui_item_container_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_item_container_get_api_delegate> efl_ui_item_container_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_item_container_get_api_delegate>(Module, "efl_ui_item_container_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.UI.Widget container_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_item_container_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.UI.Widget _ret_var = default(CoreUI.UI.Widget);
                    try
                    {
                        _ret_var = ((Item)ws.Target).GetContainer();
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
                    return efl_ui_item_container_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_item_container_get_delegate efl_ui_item_container_get_static_delegate;

            
            private delegate void efl_ui_item_container_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Widget container);

            
            internal delegate void efl_ui_item_container_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Widget container);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_item_container_set_api_delegate> efl_ui_item_container_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_item_container_set_api_delegate>(Module, "efl_ui_item_container_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void container_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.Widget container)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_item_container_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Item)ws.Target).SetContainer(container);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_item_container_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), container);
                }
            }

            private static efl_ui_item_container_set_delegate efl_ui_item_container_set_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.UI.Item efl_ui_item_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.UI.Item efl_ui_item_parent_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_item_parent_get_api_delegate> efl_ui_item_parent_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_item_parent_get_api_delegate>(Module, "efl_ui_item_parent_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.UI.Item item_parent_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_item_parent_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.UI.Item _ret_var = default(CoreUI.UI.Item);
                    try
                    {
                        _ret_var = ((Item)ws.Target).GetItemParent();
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
                    return efl_ui_item_parent_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_item_parent_get_delegate efl_ui_item_parent_get_static_delegate;

            
            private delegate void efl_ui_item_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Item parent);

            
            internal delegate void efl_ui_item_parent_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Item parent);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_item_parent_set_api_delegate> efl_ui_item_parent_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_item_parent_set_api_delegate>(Module, "efl_ui_item_parent_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void item_parent_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.Item parent)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_item_parent_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Item)ws.Target).SetItemParent(parent);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_item_parent_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), parent);
                }
            }

            private static efl_ui_item_parent_set_delegate efl_ui_item_parent_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_item_calc_locked_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_item_calc_locked_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_item_calc_locked_get_api_delegate> efl_ui_item_calc_locked_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_item_calc_locked_get_api_delegate>(Module, "efl_ui_item_calc_locked_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool calc_locked_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_item_calc_locked_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Item)ws.Target).GetCalcLocked();
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
                    return efl_ui_item_calc_locked_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_item_calc_locked_get_delegate efl_ui_item_calc_locked_get_static_delegate;

            
            private delegate void efl_ui_item_calc_locked_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool locked);

            
            internal delegate void efl_ui_item_calc_locked_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool locked);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_item_calc_locked_set_api_delegate> efl_ui_item_calc_locked_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_item_calc_locked_set_api_delegate>(Module, "efl_ui_item_calc_locked_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void calc_locked_set(System.IntPtr obj, System.IntPtr pd, bool locked)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_item_calc_locked_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Item)ws.Target).SetCalcLocked(locked);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_item_calc_locked_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), locked);
                }
            }

            private static efl_ui_item_calc_locked_set_delegate efl_ui_item_calc_locked_set_static_delegate;

            
            private delegate void efl_input_clickable_press_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

            
            internal delegate void efl_input_clickable_press_api_delegate(System.IntPtr obj,  uint button);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_press_api_delegate> efl_input_clickable_press_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_press_api_delegate>(Module, "efl_input_clickable_press");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void press(System.IntPtr obj, System.IntPtr pd, uint button)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_clickable_press was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Item)ws.Target).Press(button);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_clickable_press_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), button);
                }
            }

            private static efl_input_clickable_press_delegate efl_input_clickable_press_static_delegate;

            
            private delegate void efl_input_clickable_unpress_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

            
            internal delegate void efl_input_clickable_unpress_api_delegate(System.IntPtr obj,  uint button);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_unpress_api_delegate> efl_input_clickable_unpress_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_unpress_api_delegate>(Module, "efl_input_clickable_unpress");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void unpress(System.IntPtr obj, System.IntPtr pd, uint button)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_clickable_unpress was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Item)ws.Target).Unpress(button);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_clickable_unpress_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), button);
                }
            }

            private static efl_input_clickable_unpress_delegate efl_input_clickable_unpress_static_delegate;

            
            private delegate void efl_input_clickable_button_state_reset_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

            
            internal delegate void efl_input_clickable_button_state_reset_api_delegate(System.IntPtr obj,  uint button);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate> efl_input_clickable_button_state_reset_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate>(Module, "efl_input_clickable_button_state_reset");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void button_state_reset(System.IntPtr obj, System.IntPtr pd, uint button)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_clickable_button_state_reset was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Item)ws.Target).ResetButtonState(button);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_clickable_button_state_reset_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), button);
                }
            }

            private static efl_input_clickable_button_state_reset_delegate efl_input_clickable_button_state_reset_static_delegate;

            
            private delegate void efl_input_clickable_longpress_abort_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

            
            internal delegate void efl_input_clickable_longpress_abort_api_delegate(System.IntPtr obj,  uint button);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate> efl_input_clickable_longpress_abort_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate>(Module, "efl_input_clickable_longpress_abort");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void longpress_abort(System.IntPtr obj, System.IntPtr pd, uint button)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_clickable_longpress_abort was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Item)ws.Target).LongpressAbort(button);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_clickable_longpress_abort_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), button);
                }
            }

            private static efl_input_clickable_longpress_abort_delegate efl_input_clickable_longpress_abort_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class ItemExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.Widget> Container<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Item, T>magic = null) where T : CoreUI.UI.Item {
            return new CoreUI.BindableProperty<CoreUI.UI.Widget>("container", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.Item> ItemParent<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Item, T>magic = null) where T : CoreUI.UI.Item {
            return new CoreUI.BindableProperty<CoreUI.UI.Item>("item_parent", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> CalcLocked<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Item, T>magic = null) where T : CoreUI.UI.Item {
            return new CoreUI.BindableProperty<bool>("calc_locked", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Selected<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Item, T>magic = null) where T : CoreUI.UI.Item {
            return new CoreUI.BindableProperty<bool>("selected", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

