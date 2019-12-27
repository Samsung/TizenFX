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
    /// <summary>A styled container widget which overlays a window&apos;s contents.
    /// 
    /// The Popup widget is a theme-capable container which can be used for various purposes. Regular contents can be set using the <see cref="CoreUI.IContent"/> interface, or basic scrollable contents can be set through the <see cref="CoreUI.UI.IWidgetScrollableContent"/> mixin API. For contents which should be scrollable but require more fine-grained tuning, it may be necessary for users to set up and provide their own scroller object such as <see cref="CoreUI.UI.Scroller"/>.
    /// 
    /// A Popup widget will create an overlay for the window contents. This overlay is an <see cref="CoreUI.UI.PopupPartBackwall"/> object, which provides functionality for passing events through to the main window while the Popup is active as well as the ability to set background images for the Popup.
    /// 
    /// By default, a Popup is positioned by the user through the <see cref="CoreUI.Gfx.IEntity.Position"/> property. This behavior can be altered by using the <see cref="CoreUI.UI.Popup.Align"/> and <see cref="CoreUI.UI.Popup.Anchor"/> properties. Setting the <see cref="CoreUI.Gfx.IEntity.Position"/> property directly will unset both the <see cref="CoreUI.UI.Popup.Align"/> and <see cref="CoreUI.UI.Popup.Anchor"/> properties, and vice versa.
    /// 
    /// By default, a Popup will size itself based on the minimum size of its contents through the <see cref="CoreUI.Gfx.IHint"/> interface. A Popup will never size itself smaller than the minimum size of its contents, but by manually setting the <see cref="CoreUI.Gfx.IEntity.Size"/> property or the <see cref="CoreUI.Gfx.IHint.HintSizeMin"/> property, a larger size can be specified.
    /// 
    /// Users can set a given Popup widget to close automatically after a specified time using the <see cref="CoreUI.UI.Popup.ClosingTimeout"/> property.
    /// 
    /// For a Popup with a more specialized purpose, see <see cref="CoreUI.UI.AlertPopup"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Popup.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Popup : CoreUI.UI.LayoutBase, CoreUI.IContent, CoreUI.UI.IWidgetScrollableContent
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Popup))
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
            efl_ui_popup_class_get();

        /// <summary>Initializes a new instance of the <see cref="Popup"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Popup(CoreUI.Object parent, System.String style = null) : base(efl_ui_popup_class_get(), parent)
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
        protected Popup(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Popup"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Popup(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Popup"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Popup(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>This is called whenever the user clicks the backwall part of the Popup.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler BackwallClicked
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_POPUP_EVENT_BACKWALL_CLICKED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_POPUP_EVENT_BACKWALL_CLICKED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event BackwallClicked.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnBackwallClicked()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_POPUP_EVENT_BACKWALL_CLICKED", IntPtr.Zero, null);
        }

        /// <summary>This is called when Popup times out.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Timeout
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_POPUP_EVENT_TIMEOUT";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_POPUP_EVENT_TIMEOUT";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Timeout.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnTimeout()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_POPUP_EVENT_TIMEOUT", IntPtr.Zero, null);
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

        /// <summary>A backwall behind the Popup.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.PopupPartBackwall BackwallPart
        {
            get
            {
                return GetPart("backwall") as CoreUI.UI.PopupPartBackwall;
            }
        }
        /// <summary>The align property specifies a Popup&apos;s current positioning relative to its anchor.
        /// 
        /// When set, this property will override any user-provided value for the widget&apos;s <see cref="CoreUI.Gfx.IEntity.Position"/> property.</summary>
        /// <returns>Alignment of the Popup relative to its anchor. The default is <see cref="CoreUI.UI.PopupAlign.None"/>.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.PopupAlign GetAlign() {
            var _ret_var = CoreUI.UI.Popup.NativeMethods.efl_ui_popup_align_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The align property specifies a Popup&apos;s current positioning relative to its anchor.
        /// 
        /// When set, this property will override any user-provided value for the widget&apos;s <see cref="CoreUI.Gfx.IEntity.Position"/> property.</summary>
        /// <param name="type">Alignment of the Popup relative to its anchor. The default is <see cref="CoreUI.UI.PopupAlign.None"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetAlign(CoreUI.UI.PopupAlign type) {
            CoreUI.UI.Popup.NativeMethods.efl_ui_popup_align_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), type);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The closing_timeout property is the time after which the Popup widget will be automatically deleted.
        /// 
        /// The timer is initiated at the time when the popup is shown. If the value is changed prior to the timer expiring, the existing timer will be deleted. If the new value is greater than $0, a new timer will be created.</summary>
        /// <returns>If greater than $0, the Popup will close automatically after the value in seconds. The default is to not automatically delete the Popup.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetClosingTimeout() {
            var _ret_var = CoreUI.UI.Popup.NativeMethods.efl_ui_popup_closing_timeout_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The closing_timeout property is the time after which the Popup widget will be automatically deleted.
        /// 
        /// The timer is initiated at the time when the popup is shown. If the value is changed prior to the timer expiring, the existing timer will be deleted. If the new value is greater than $0, a new timer will be created.</summary>
        /// <param name="time">If greater than $0, the Popup will close automatically after the value in seconds. The default is to not automatically delete the Popup.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetClosingTimeout(double time) {
            CoreUI.UI.Popup.NativeMethods.efl_ui_popup_closing_timeout_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), time);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The anchor object is the reference object for positioning a Popup using the <see cref="CoreUI.UI.Popup.Align"/> and <see cref="CoreUI.UI.Popup.AlignPriority"/> properties.
        /// 
        /// A Popup will recalculate its alignment relative to its anchor and change its position when: - the anchor object is moved (unless the anchor is a window) - the anchor object is resized - the Popup is resized - the parent window is resized
        /// 
        /// If <see cref="CoreUI.UI.Popup.GetAnchor"/> returns <c>NULL</c>, the anchor is the parent window of the Popup. If the anchor object is set to <c>NULL</c>, the Popup will no longer recalculate its alignment or change its position under any circumstance. If the Popup is moved by using <see cref="CoreUI.Gfx.IEntity.SetPosition"/>, <c>anchor</c> is set <c>NULL</c>.</summary>
        /// <returns>The object which Popup is following. By default this is <c>NULL</c>.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Canvas.Object GetAnchor() {
            var _ret_var = CoreUI.UI.Popup.NativeMethods.efl_ui_popup_anchor_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The anchor object is the reference object for positioning a Popup using the <see cref="CoreUI.UI.Popup.Align"/> and <see cref="CoreUI.UI.Popup.AlignPriority"/> properties.
        /// 
        /// A Popup will recalculate its alignment relative to its anchor and change its position when: - the anchor object is moved (unless the anchor is a window) - the anchor object is resized - the Popup is resized - the parent window is resized
        /// 
        /// If <see cref="CoreUI.UI.Popup.GetAnchor"/> returns <c>NULL</c>, the anchor is the parent window of the Popup. If the anchor object is set to <c>NULL</c>, the Popup will no longer recalculate its alignment or change its position under any circumstance. If the Popup is moved by using <see cref="CoreUI.Gfx.IEntity.SetPosition"/>, <c>anchor</c> is set <c>NULL</c>.</summary>
        /// <param name="anchor">The object which Popup is following. By default this is <c>NULL</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetAnchor(CoreUI.Canvas.Object anchor) {
            CoreUI.UI.Popup.NativeMethods.efl_ui_popup_anchor_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), anchor);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This is the priority in which alignments will be tested using the anchor object if the value of <see cref="CoreUI.UI.Popup.Align"/> is determined to be invalid. If a given alignment would result in the popup being partially or fully outside the visible area of the window, it is deemed invalid, and the next alignment is tested until either the priority list is exhausted or a usable alignment is found.
        /// 
        /// An alignment will also be deemed invalid if the popup occludes its anchor object, except if <see cref="CoreUI.UI.PopupAlign.Center"/> is specified.</summary>
        /// <param name="first">First alignment. The default is <see cref="CoreUI.UI.PopupAlign.Top"/>.</param>
        /// <param name="second">Second alignment. The default is <see cref="CoreUI.UI.PopupAlign.Left"/>.</param>
        /// <param name="third">Third alignment. The default is <see cref="CoreUI.UI.PopupAlign.Right"/>.</param>
        /// <param name="fourth">Fourth alignment. The default is <see cref="CoreUI.UI.PopupAlign.Bottom"/>.</param>
        /// <param name="fifth">Fifth alignment. The default is <see cref="CoreUI.UI.PopupAlign.Center"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetAlignPriority(out CoreUI.UI.PopupAlign first, out CoreUI.UI.PopupAlign second, out CoreUI.UI.PopupAlign third, out CoreUI.UI.PopupAlign fourth, out CoreUI.UI.PopupAlign fifth) {
            CoreUI.UI.Popup.NativeMethods.efl_ui_popup_align_priority_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out first, out second, out third, out fourth, out fifth);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This is the priority in which alignments will be tested using the anchor object if the value of <see cref="CoreUI.UI.Popup.Align"/> is determined to be invalid. If a given alignment would result in the popup being partially or fully outside the visible area of the window, it is deemed invalid, and the next alignment is tested until either the priority list is exhausted or a usable alignment is found.
        /// 
        /// An alignment will also be deemed invalid if the popup occludes its anchor object, except if <see cref="CoreUI.UI.PopupAlign.Center"/> is specified.</summary>
        /// <param name="first">First alignment. The default is <see cref="CoreUI.UI.PopupAlign.Top"/>.</param>
        /// <param name="second">Second alignment. The default is <see cref="CoreUI.UI.PopupAlign.Left"/>.</param>
        /// <param name="third">Third alignment. The default is <see cref="CoreUI.UI.PopupAlign.Right"/>.</param>
        /// <param name="fourth">Fourth alignment. The default is <see cref="CoreUI.UI.PopupAlign.Bottom"/>.</param>
        /// <param name="fifth">Fifth alignment. The default is <see cref="CoreUI.UI.PopupAlign.Center"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetAlignPriority(CoreUI.UI.PopupAlign first, CoreUI.UI.PopupAlign second, CoreUI.UI.PopupAlign third, CoreUI.UI.PopupAlign fourth, CoreUI.UI.PopupAlign fifth) {
            CoreUI.UI.Popup.NativeMethods.efl_ui_popup_align_priority_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), first, second, third, fourth, fifth);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
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

        /// <summary>This is the content which will be placed in the internal scroller.
        /// 
        /// If a <see cref="CoreUI.UI.IWidgetScrollableContent.ScrollableText"/> string is set, this property will be <c>NULL</c>.</summary>
        /// <returns>The content object.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Canvas.Object GetScrollableContent() {
            var _ret_var = CoreUI.UI.IWidgetScrollableContentNativeMethods.efl_ui_widget_scrollable_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>This is the content which will be placed in the internal scroller.
        /// 
        /// If a <see cref="CoreUI.UI.IWidgetScrollableContent.ScrollableText"/> string is set, this property will be <c>NULL</c>.</summary>
        /// <param name="content">The content object.</param>
        /// <returns><c>true</c> on success.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool SetScrollableContent(CoreUI.Canvas.Object content) {
            var _ret_var = CoreUI.UI.IWidgetScrollableContentNativeMethods.efl_ui_widget_scrollable_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), content);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The text string to be displayed by the given text object. The text will use <see cref="CoreUI.TextFormatWrap.Mixed"/> wrapping, and it will be scrollable depending on its size relative to the object&apos;s geometry.
        /// 
        /// When reading, do not free the return value.</summary>
        /// <returns>Text string to display on it.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetScrollableText() {
            var _ret_var = CoreUI.UI.IWidgetScrollableContentNativeMethods.efl_ui_widget_scrollable_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The text string to be displayed by the given text object. The text will use <see cref="CoreUI.TextFormatWrap.Mixed"/> wrapping, and it will be scrollable depending on its size relative to the object&apos;s geometry.
        /// 
        /// When reading, do not free the return value.</summary>
        /// <param name="text">Text string to display on it.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetScrollableText(System.String text) {
            CoreUI.UI.IWidgetScrollableContentNativeMethods.efl_ui_widget_scrollable_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), text);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The align property specifies a Popup&apos;s current positioning relative to its anchor.
        /// 
        /// When set, this property will override any user-provided value for the widget&apos;s <see cref="CoreUI.Gfx.IEntity.Position"/> property.</summary>
        /// <value>Alignment of the Popup relative to its anchor. The default is <see cref="CoreUI.UI.PopupAlign.None"/>.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.PopupAlign Align {
            get { return GetAlign(); }
            set { SetAlign(value); }
        }

        /// <summary>The closing_timeout property is the time after which the Popup widget will be automatically deleted.
        /// 
        /// The timer is initiated at the time when the popup is shown. If the value is changed prior to the timer expiring, the existing timer will be deleted. If the new value is greater than $0, a new timer will be created.</summary>
        /// <value>If greater than $0, the Popup will close automatically after the value in seconds. The default is to not automatically delete the Popup.</value>
        /// <since_tizen> 6 </since_tizen>
        public double ClosingTimeout {
            get { return GetClosingTimeout(); }
            set { SetClosingTimeout(value); }
        }

        /// <summary>The anchor object is the reference object for positioning a Popup using the <see cref="CoreUI.UI.Popup.Align"/> and <see cref="CoreUI.UI.Popup.AlignPriority"/> properties.
        /// 
        /// A Popup will recalculate its alignment relative to its anchor and change its position when: - the anchor object is moved (unless the anchor is a window) - the anchor object is resized - the Popup is resized - the parent window is resized
        /// 
        /// If <see cref="CoreUI.UI.Popup.GetAnchor"/> returns <c>NULL</c>, the anchor is the parent window of the Popup. If the anchor object is set to <c>NULL</c>, the Popup will no longer recalculate its alignment or change its position under any circumstance. If the Popup is moved by using <see cref="CoreUI.Gfx.IEntity.SetPosition"/>, <c>anchor</c> is set <c>NULL</c>.</summary>
        /// <value>The object which Popup is following. By default this is <c>NULL</c>.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Canvas.Object Anchor {
            get { return GetAnchor(); }
            set { SetAnchor(value); }
        }

        /// <summary>This is the priority in which alignments will be tested using the anchor object if the value of <see cref="CoreUI.UI.Popup.Align"/> is determined to be invalid. If a given alignment would result in the popup being partially or fully outside the visible area of the window, it is deemed invalid, and the next alignment is tested until either the priority list is exhausted or a usable alignment is found.
        /// 
        /// An alignment will also be deemed invalid if the popup occludes its anchor object, except if <see cref="CoreUI.UI.PopupAlign.Center"/> is specified.</summary>
        /// <value>First alignment. The default is <see cref="CoreUI.UI.PopupAlign.Top"/>.</value>
        /// <since_tizen> 6 </since_tizen>
        public (CoreUI.UI.PopupAlign, CoreUI.UI.PopupAlign, CoreUI.UI.PopupAlign, CoreUI.UI.PopupAlign, CoreUI.UI.PopupAlign) AlignPriority {
            get {
                CoreUI.UI.PopupAlign _out_first = default(CoreUI.UI.PopupAlign);
                CoreUI.UI.PopupAlign _out_second = default(CoreUI.UI.PopupAlign);
                CoreUI.UI.PopupAlign _out_third = default(CoreUI.UI.PopupAlign);
                CoreUI.UI.PopupAlign _out_fourth = default(CoreUI.UI.PopupAlign);
                CoreUI.UI.PopupAlign _out_fifth = default(CoreUI.UI.PopupAlign);
                GetAlignPriority(out _out_first, out _out_second, out _out_third, out _out_fourth, out _out_fifth);
                return (_out_first, _out_second, _out_third, _out_fourth, _out_fifth);
            }
            set { SetAlignPriority( value.Item1,  value.Item2,  value.Item3,  value.Item4,  value.Item5); }
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

        /// <summary>This is the content which will be placed in the internal scroller.
        /// 
        /// If a <see cref="CoreUI.UI.IWidgetScrollableContent.ScrollableText"/> string is set, this property will be <c>NULL</c>.</summary>
        /// <value>The content object.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Canvas.Object ScrollableContent {
            get { return GetScrollableContent(); }
            set { SetScrollableContent(value); }
        }

        /// <summary>The text string to be displayed by the given text object. The text will use <see cref="CoreUI.TextFormatWrap.Mixed"/> wrapping, and it will be scrollable depending on its size relative to the object&apos;s geometry.
        /// 
        /// When reading, do not free the return value.</summary>
        /// <value>Text string to display on it.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String ScrollableText {
            get { return GetScrollableText(); }
            set { SetScrollableText(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Popup.efl_ui_popup_class_get();
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

                if (efl_ui_popup_align_get_static_delegate == null)
                {
                    efl_ui_popup_align_get_static_delegate = new efl_ui_popup_align_get_delegate(align_get);
                }

                if (methods.Contains("GetAlign"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_align_get_static_delegate) });
                }

                if (efl_ui_popup_align_set_static_delegate == null)
                {
                    efl_ui_popup_align_set_static_delegate = new efl_ui_popup_align_set_delegate(align_set);
                }

                if (methods.Contains("SetAlign"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_align_set_static_delegate) });
                }

                if (efl_ui_popup_closing_timeout_get_static_delegate == null)
                {
                    efl_ui_popup_closing_timeout_get_static_delegate = new efl_ui_popup_closing_timeout_get_delegate(closing_timeout_get);
                }

                if (methods.Contains("GetClosingTimeout"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_closing_timeout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_closing_timeout_get_static_delegate) });
                }

                if (efl_ui_popup_closing_timeout_set_static_delegate == null)
                {
                    efl_ui_popup_closing_timeout_set_static_delegate = new efl_ui_popup_closing_timeout_set_delegate(closing_timeout_set);
                }

                if (methods.Contains("SetClosingTimeout"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_closing_timeout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_closing_timeout_set_static_delegate) });
                }

                if (efl_ui_popup_anchor_get_static_delegate == null)
                {
                    efl_ui_popup_anchor_get_static_delegate = new efl_ui_popup_anchor_get_delegate(anchor_get);
                }

                if (methods.Contains("GetAnchor"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_anchor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_anchor_get_static_delegate) });
                }

                if (efl_ui_popup_anchor_set_static_delegate == null)
                {
                    efl_ui_popup_anchor_set_static_delegate = new efl_ui_popup_anchor_set_delegate(anchor_set);
                }

                if (methods.Contains("SetAnchor"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_anchor_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_anchor_set_static_delegate) });
                }

                if (efl_ui_popup_align_priority_get_static_delegate == null)
                {
                    efl_ui_popup_align_priority_get_static_delegate = new efl_ui_popup_align_priority_get_delegate(align_priority_get);
                }

                if (methods.Contains("GetAlignPriority"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_align_priority_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_align_priority_get_static_delegate) });
                }

                if (efl_ui_popup_align_priority_set_static_delegate == null)
                {
                    efl_ui_popup_align_priority_set_static_delegate = new efl_ui_popup_align_priority_set_delegate(align_priority_set);
                }

                if (methods.Contains("SetAlignPriority"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_align_priority_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_align_priority_set_static_delegate) });
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
                return CoreUI.UI.Popup.efl_ui_popup_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate CoreUI.UI.PopupAlign efl_ui_popup_align_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.UI.PopupAlign efl_ui_popup_align_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_align_get_api_delegate> efl_ui_popup_align_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_align_get_api_delegate>(Module, "efl_ui_popup_align_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.UI.PopupAlign align_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_popup_align_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.UI.PopupAlign _ret_var = default(CoreUI.UI.PopupAlign);
                    try
                    {
                        _ret_var = ((Popup)ws.Target).GetAlign();
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
                    return efl_ui_popup_align_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_popup_align_get_delegate efl_ui_popup_align_get_static_delegate;

            
            private delegate void efl_ui_popup_align_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.UI.PopupAlign type);

            
            internal delegate void efl_ui_popup_align_set_api_delegate(System.IntPtr obj,  CoreUI.UI.PopupAlign type);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_align_set_api_delegate> efl_ui_popup_align_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_align_set_api_delegate>(Module, "efl_ui_popup_align_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void align_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.PopupAlign type)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_popup_align_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Popup)ws.Target).SetAlign(type);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_popup_align_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), type);
                }
            }

            private static efl_ui_popup_align_set_delegate efl_ui_popup_align_set_static_delegate;

            
            private delegate double efl_ui_popup_closing_timeout_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate double efl_ui_popup_closing_timeout_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_closing_timeout_get_api_delegate> efl_ui_popup_closing_timeout_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_closing_timeout_get_api_delegate>(Module, "efl_ui_popup_closing_timeout_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static double closing_timeout_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_popup_closing_timeout_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    double _ret_var = default(double);
                    try
                    {
                        _ret_var = ((Popup)ws.Target).GetClosingTimeout();
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
                    return efl_ui_popup_closing_timeout_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_popup_closing_timeout_get_delegate efl_ui_popup_closing_timeout_get_static_delegate;

            
            private delegate void efl_ui_popup_closing_timeout_set_delegate(System.IntPtr obj, System.IntPtr pd,  double time);

            
            internal delegate void efl_ui_popup_closing_timeout_set_api_delegate(System.IntPtr obj,  double time);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_closing_timeout_set_api_delegate> efl_ui_popup_closing_timeout_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_closing_timeout_set_api_delegate>(Module, "efl_ui_popup_closing_timeout_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void closing_timeout_set(System.IntPtr obj, System.IntPtr pd, double time)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_popup_closing_timeout_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Popup)ws.Target).SetClosingTimeout(time);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_popup_closing_timeout_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), time);
                }
            }

            private static efl_ui_popup_closing_timeout_set_delegate efl_ui_popup_closing_timeout_set_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Canvas.Object efl_ui_popup_anchor_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Canvas.Object efl_ui_popup_anchor_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_anchor_get_api_delegate> efl_ui_popup_anchor_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_anchor_get_api_delegate>(Module, "efl_ui_popup_anchor_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Canvas.Object anchor_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_popup_anchor_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Canvas.Object _ret_var = default(CoreUI.Canvas.Object);
                    try
                    {
                        _ret_var = ((Popup)ws.Target).GetAnchor();
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
                    return efl_ui_popup_anchor_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_popup_anchor_get_delegate efl_ui_popup_anchor_get_static_delegate;

            
            private delegate void efl_ui_popup_anchor_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object anchor);

            
            internal delegate void efl_ui_popup_anchor_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object anchor);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_anchor_set_api_delegate> efl_ui_popup_anchor_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_anchor_set_api_delegate>(Module, "efl_ui_popup_anchor_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void anchor_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.Object anchor)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_popup_anchor_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Popup)ws.Target).SetAnchor(anchor);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_popup_anchor_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), anchor);
                }
            }

            private static efl_ui_popup_anchor_set_delegate efl_ui_popup_anchor_set_static_delegate;

            
            private delegate void efl_ui_popup_align_priority_get_delegate(System.IntPtr obj, System.IntPtr pd,  out CoreUI.UI.PopupAlign first,  out CoreUI.UI.PopupAlign second,  out CoreUI.UI.PopupAlign third,  out CoreUI.UI.PopupAlign fourth,  out CoreUI.UI.PopupAlign fifth);

            
            internal delegate void efl_ui_popup_align_priority_get_api_delegate(System.IntPtr obj,  out CoreUI.UI.PopupAlign first,  out CoreUI.UI.PopupAlign second,  out CoreUI.UI.PopupAlign third,  out CoreUI.UI.PopupAlign fourth,  out CoreUI.UI.PopupAlign fifth);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_align_priority_get_api_delegate> efl_ui_popup_align_priority_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_align_priority_get_api_delegate>(Module, "efl_ui_popup_align_priority_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void align_priority_get(System.IntPtr obj, System.IntPtr pd, out CoreUI.UI.PopupAlign first, out CoreUI.UI.PopupAlign second, out CoreUI.UI.PopupAlign third, out CoreUI.UI.PopupAlign fourth, out CoreUI.UI.PopupAlign fifth)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_popup_align_priority_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    first = default(CoreUI.UI.PopupAlign);second = default(CoreUI.UI.PopupAlign);third = default(CoreUI.UI.PopupAlign);fourth = default(CoreUI.UI.PopupAlign);fifth = default(CoreUI.UI.PopupAlign);
                    try
                    {
                        ((Popup)ws.Target).GetAlignPriority(out first, out second, out third, out fourth, out fifth);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_popup_align_priority_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out first, out second, out third, out fourth, out fifth);
                }
            }

            private static efl_ui_popup_align_priority_get_delegate efl_ui_popup_align_priority_get_static_delegate;

            
            private delegate void efl_ui_popup_align_priority_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.UI.PopupAlign first,  CoreUI.UI.PopupAlign second,  CoreUI.UI.PopupAlign third,  CoreUI.UI.PopupAlign fourth,  CoreUI.UI.PopupAlign fifth);

            
            internal delegate void efl_ui_popup_align_priority_set_api_delegate(System.IntPtr obj,  CoreUI.UI.PopupAlign first,  CoreUI.UI.PopupAlign second,  CoreUI.UI.PopupAlign third,  CoreUI.UI.PopupAlign fourth,  CoreUI.UI.PopupAlign fifth);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_align_priority_set_api_delegate> efl_ui_popup_align_priority_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_popup_align_priority_set_api_delegate>(Module, "efl_ui_popup_align_priority_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void align_priority_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.PopupAlign first, CoreUI.UI.PopupAlign second, CoreUI.UI.PopupAlign third, CoreUI.UI.PopupAlign fourth, CoreUI.UI.PopupAlign fifth)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_popup_align_priority_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Popup)ws.Target).SetAlignPriority(first, second, third, fourth, fifth);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_popup_align_priority_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), first, second, third, fourth, fifth);
                }
            }

            private static efl_ui_popup_align_priority_set_delegate efl_ui_popup_align_priority_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class PopupExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.PopupAlign> Align<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Popup, T>magic = null) where T : CoreUI.UI.Popup {
            return new CoreUI.BindableProperty<CoreUI.UI.PopupAlign>("align", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> ClosingTimeout<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Popup, T>magic = null) where T : CoreUI.UI.Popup {
            return new CoreUI.BindableProperty<double>("closing_timeout", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Canvas.Object> Anchor<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Popup, T>magic = null) where T : CoreUI.UI.Popup {
            return new CoreUI.BindableProperty<CoreUI.Canvas.Object>("anchor", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.IEntity> Content<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Popup, T>magic = null) where T : CoreUI.UI.Popup {
            return new CoreUI.BindableProperty<CoreUI.Gfx.IEntity>("content", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Canvas.Object> ScrollableContent<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Popup, T>magic = null) where T : CoreUI.UI.Popup {
            return new CoreUI.BindableProperty<CoreUI.Canvas.Object>("scrollable_content", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> ScrollableText<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Popup, T>magic = null) where T : CoreUI.UI.Popup {
            return new CoreUI.BindableProperty<System.String>("scrollable_text", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindablePart<CoreUI.UI.PopupPartBackwall> BackwallPart<T>(this CoreUI.UI.IGenericFactoryPartExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Popup, T> x=null) where T : CoreUI.UI.Popup
        {
            return new CoreUI.BindablePart<CoreUI.UI.PopupPartBackwall>("backwall", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI.UI {
    /// <summary>This is the alignment method for positioning Popup widgets.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum PopupAlign
    {
        /// <summary>Popup not aligned.</summary>
        /// <since_tizen> 6 </since_tizen>
        None = 0,
        /// <summary>Popup is aligned to the center of its anchor object.</summary>
        /// <since_tizen> 6 </since_tizen>
        Center = 1,
        /// <summary>Popup&apos;s left edge is aligned to the left side of its anchor object.</summary>
        /// <since_tizen> 6 </since_tizen>
        Left = 2,
        /// <summary>Popup&apos;s right edge is aligned to the right side of its anchor object.</summary>
        /// <since_tizen> 6 </since_tizen>
        Right = 3,
        /// <summary>Popup&apos;s top is aligned to the top of its anchor object.</summary>
        /// <since_tizen> 6 </since_tizen>
        Top = 4,
        /// <summary>Popup&apos;s bottom is aligned to the bottom of its anchor object.</summary>
        /// <since_tizen> 6 </since_tizen>
        Bottom = 5,
    }
}

