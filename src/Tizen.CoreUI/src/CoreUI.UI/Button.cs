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
    /// <summary>Push-button widget
    /// 
    /// Press it and run some function. It can contain a simple label and icon object and it also has an autorepeat feature.
    /// 
    /// The icon can be set using <see cref="CoreUI.IContent.Content"/>, the text can be set using <see cref="CoreUI.IText.Text"/>.
    /// 
    /// The events of <see cref="CoreUI.Input.IClickable"/> can be used to listen to a click event from the user.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Button.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Button : CoreUI.UI.LayoutBase, CoreUI.IContent, CoreUI.IText, CoreUI.Input.IClickable, CoreUI.UI.IAutoRepeat
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Button))
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
            efl_ui_button_class_get();

        /// <summary>Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Button(CoreUI.Object parent, System.String style = null) : base(efl_ui_button_class_get(), parent)
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
        protected Button(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Button"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Button(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Button"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Button(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Sent after the content is set or unset using the current content object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ContentContentChangedEventArgs"/></value>
        public event EventHandler<CoreUI.ContentContentChangedEventArgs> ContentChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ContentContentChangedEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.IEntity) });
                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ContentChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnContentChanged(CoreUI.ContentContentChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_CONTENT_EVENT_CONTENT_CHANGED", info, null);
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

        /// <summary>Called when a repeated event is emitted</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Repeated
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_AUTOREPEAT_EVENT_REPEATED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_AUTOREPEAT_EVENT_REPEATED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Repeated.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnRepeated()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_AUTOREPEAT_EVENT_REPEATED", IntPtr.Zero, null);
        }

        /// <summary>Sub-object currently set as this object&apos;s single content.
        /// 
        /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
        /// <returns>The sub-object.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.IEntity GetContent() {
            var _ret_var = CoreUI.IContentNativeMethods.efl_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Sub-object currently set as this object&apos;s single content.
        /// 
        /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
        /// <param name="content">The sub-object.</param>
        /// <returns><c>true</c> if <c>content</c> was successfully swallowed.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool SetContent(CoreUI.Gfx.IEntity content) {
            var _ret_var = CoreUI.IContentNativeMethods.efl_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), content);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Remove the sub-object currently set as content of this object and return it. This object becomes empty.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Unswallowed object</returns>
        public virtual CoreUI.Gfx.IEntity UnsetContent() {
            var _ret_var = CoreUI.IContentNativeMethods.efl_content_unset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The text string to be displayed by the given text object.
        /// 
        /// Do not release (free) the returned value.</summary>
        /// <returns>Text string to display.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetText() {
            var _ret_var = CoreUI.ITextNativeMethods.efl_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The text string to be displayed by the given text object.
        /// 
        /// Do not release (free) the returned value.</summary>
        /// <param name="text">Text string to display.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetText(System.String text) {
            CoreUI.ITextNativeMethods.efl_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), text);
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

        /// <summary>The initial timeout before the autorepeat event is generated.
        /// 
        /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
        /// 
        /// See also <see cref="CoreUI.UI.IAutoRepeat.AutorepeatEnabled"/> and <see cref="CoreUI.UI.IAutoRepeat.AutorepeatGapTimeout"/>.</summary>
        /// <returns>Timeout in seconds.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetAutorepeatInitialTimeout() {
            var _ret_var = CoreUI.UI.IAutoRepeatNativeMethods.efl_ui_autorepeat_initial_timeout_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The initial timeout before the autorepeat event is generated.
        /// 
        /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
        /// 
        /// See also <see cref="CoreUI.UI.IAutoRepeat.AutorepeatEnabled"/> and <see cref="CoreUI.UI.IAutoRepeat.AutorepeatGapTimeout"/>.</summary>
        /// <param name="t">Timeout in seconds.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetAutorepeatInitialTimeout(double t) {
            CoreUI.UI.IAutoRepeatNativeMethods.efl_ui_autorepeat_initial_timeout_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), t);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The interval between each generated autorepeat event.
        /// 
        /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
        /// 
        /// See also <see cref="CoreUI.UI.IAutoRepeat.AutorepeatInitialTimeout"/>.</summary>
        /// <returns>Time interval in seconds.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetAutorepeatGapTimeout() {
            var _ret_var = CoreUI.UI.IAutoRepeatNativeMethods.efl_ui_autorepeat_gap_timeout_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The interval between each generated autorepeat event.
        /// 
        /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
        /// 
        /// See also <see cref="CoreUI.UI.IAutoRepeat.AutorepeatInitialTimeout"/>.</summary>
        /// <param name="t">Time interval in seconds.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetAutorepeatGapTimeout(double t) {
            CoreUI.UI.IAutoRepeatNativeMethods.efl_ui_autorepeat_gap_timeout_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), t);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
        /// 
        /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
        /// <returns>A bool to turn on/off the repeat event generation.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetAutorepeatEnabled() {
            var _ret_var = CoreUI.UI.IAutoRepeatNativeMethods.efl_ui_autorepeat_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
        /// 
        /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
        /// <param name="on">A bool to turn on/off the repeat event generation.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetAutorepeatEnabled(bool on) {
            CoreUI.UI.IAutoRepeatNativeMethods.efl_ui_autorepeat_enabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), on);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Sub-object currently set as this object&apos;s single content.
        /// 
        /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
        /// <value>The sub-object.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IEntity Content {
            get { return GetContent(); }
            set { SetContent(value); }
        }

        /// <summary>The text string to be displayed by the given text object.
        /// 
        /// Do not release (free) the returned value.</summary>
        /// <value>Text string to display.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String Text {
            get { return GetText(); }
            set { SetText(value); }
        }

        /// <summary>This returns true if the given object is currently in event emission</summary>
        /// <since_tizen> 6 </since_tizen>
        public bool Interaction {
            get { return GetInteraction(); }
        }

        /// <summary>The initial timeout before the autorepeat event is generated.
        /// 
        /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
        /// 
        /// See also <see cref="CoreUI.UI.IAutoRepeat.AutorepeatEnabled"/> and <see cref="CoreUI.UI.IAutoRepeat.AutorepeatGapTimeout"/>.</summary>
        /// <value>Timeout in seconds.</value>
        /// <since_tizen> 6 </since_tizen>
        public double AutorepeatInitialTimeout {
            get { return GetAutorepeatInitialTimeout(); }
            set { SetAutorepeatInitialTimeout(value); }
        }

        /// <summary>The interval between each generated autorepeat event.
        /// 
        /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
        /// 
        /// See also <see cref="CoreUI.UI.IAutoRepeat.AutorepeatInitialTimeout"/>.</summary>
        /// <value>Time interval in seconds.</value>
        /// <since_tizen> 6 </since_tizen>
        public double AutorepeatGapTimeout {
            get { return GetAutorepeatGapTimeout(); }
            set { SetAutorepeatGapTimeout(value); }
        }

        /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
        /// 
        /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
        /// <value>A bool to turn on/off the repeat event generation.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool AutorepeatEnabled {
            get { return GetAutorepeatEnabled(); }
            set { SetAutorepeatEnabled(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Button.efl_ui_button_class_get();
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
                return CoreUI.UI.Button.efl_ui_button_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
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
                        ((Button)ws.Target).Press(button);
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
                        ((Button)ws.Target).Unpress(button);
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
                        ((Button)ws.Target).ResetButtonState(button);
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
                        ((Button)ws.Target).LongpressAbort(button);
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
    public static class ButtonExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.IEntity> Content<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Button, T>magic = null) where T : CoreUI.UI.Button {
            return new CoreUI.BindableProperty<CoreUI.Gfx.IEntity>("content", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> Text<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Button, T>magic = null) where T : CoreUI.UI.Button {
            return new CoreUI.BindableProperty<System.String>("text", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> AutorepeatInitialTimeout<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Button, T>magic = null) where T : CoreUI.UI.Button {
            return new CoreUI.BindableProperty<double>("autorepeat_initial_timeout", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> AutorepeatGapTimeout<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Button, T>magic = null) where T : CoreUI.UI.Button {
            return new CoreUI.BindableProperty<double>("autorepeat_gap_timeout", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> AutorepeatEnabled<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Button, T>magic = null) where T : CoreUI.UI.Button {
            return new CoreUI.BindableProperty<bool>("autorepeat_enabled", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

