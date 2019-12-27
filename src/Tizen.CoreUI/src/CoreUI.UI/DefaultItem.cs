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
    /// <summary>Default Item Class.
    /// 
    /// This class defines the standard parts for most <see cref="CoreUI.UI.Item"/>: Text, Icon and Extra. Placement and layout details for these parts are left to the extending classes like <see cref="CoreUI.UI.ListDefaultItem"/> and <see cref="CoreUI.UI.GridDefaultItem"/> which should normally be used. Text-related changes are mirrored to the <c>text</c> part for convenience. Content-related changes are mirrored to the <c>icon</c> part.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.DefaultItem.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract class DefaultItem : CoreUI.UI.Item, CoreUI.IContent, CoreUI.IText, CoreUI.ITextMarkup
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(DefaultItem))
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
            efl_ui_default_item_class_get();

        /// <summary>Initializes a new instance of the <see cref="DefaultItem"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public DefaultItem(CoreUI.Object parent, System.String style = null) : base(efl_ui_default_item_class_get(), parent)
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
        protected DefaultItem(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DefaultItem"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal DefaultItem(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        [CoreUI.Wrapper.PrivateNativeClass]
        private class DefaultItemRealized : DefaultItem
        {
            private DefaultItemRealized(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
            {
            }
        }
        /// <summary>Initializes a new instance of the <see cref="DefaultItem"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected DefaultItem(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
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

        /// <summary>The extra part for default items. This is used for additional details or badges.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.LayoutPartContent ExtraPart
        {
            get
            {
                return GetPart("extra") as CoreUI.UI.LayoutPartContent;
            }
        }
        /// <summary>The icon part for default items. This is the main content of the items.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.LayoutPartContent IconPart
        {
            get
            {
                return GetPart("icon") as CoreUI.UI.LayoutPartContent;
            }
        }
        /// <summary>The text part for default items. This is the caption of the items.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.LayoutPartText TextPart
        {
            get
            {
                return GetPart("text") as CoreUI.UI.LayoutPartText;
            }
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

        /// <summary>Markup property</summary>
        /// <returns>The markup-text representation set to this text.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetMarkup() {
            var _ret_var = CoreUI.ITextMarkupNativeMethods.efl_text_markup_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Markup property</summary>
        /// <param name="markup">The markup-text representation set to this text.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetMarkup(System.String markup) {
            CoreUI.ITextMarkupNativeMethods.efl_text_markup_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), markup);
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

        /// <summary>Markup property</summary>
        /// <value>The markup-text representation set to this text.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String Markup {
            get { return GetMarkup(); }
            set { SetMarkup(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.DefaultItem.efl_ui_default_item_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.Item.NativeMethods
        {
            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
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
                return CoreUI.UI.DefaultItem.efl_ui_default_item_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class DefaultItemExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.IEntity> Content<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.DefaultItem, T>magic = null) where T : CoreUI.UI.DefaultItem {
            return new CoreUI.BindableProperty<CoreUI.Gfx.IEntity>("content", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> Text<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.DefaultItem, T>magic = null) where T : CoreUI.UI.DefaultItem {
            return new CoreUI.BindableProperty<System.String>("text", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> Markup<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.DefaultItem, T>magic = null) where T : CoreUI.UI.DefaultItem {
            return new CoreUI.BindableProperty<System.String>("markup", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableFactoryPart<CoreUI.UI.LayoutPartContent> ExtraPart<T>(this CoreUI.UI.IGenericFactoryPartExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.DefaultItem, T> x=null) where T : CoreUI.UI.DefaultItem
        {
            return new CoreUI.BindableFactoryPart<CoreUI.UI.LayoutPartContent>("extra", fac.GetFactoryBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableFactoryPart<CoreUI.UI.LayoutPartContent> IconPart<T>(this CoreUI.UI.IGenericFactoryPartExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.DefaultItem, T> x=null) where T : CoreUI.UI.DefaultItem
        {
            return new CoreUI.BindableFactoryPart<CoreUI.UI.LayoutPartContent>("icon", fac.GetFactoryBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindablePart<CoreUI.UI.LayoutPartText> TextPart<T>(this CoreUI.UI.IGenericFactoryPartExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.DefaultItem, T> x=null) where T : CoreUI.UI.DefaultItem
        {
            return new CoreUI.BindablePart<CoreUI.UI.LayoutPartText>("text", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

