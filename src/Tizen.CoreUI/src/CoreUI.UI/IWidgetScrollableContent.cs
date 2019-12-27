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
    /// <summary>Mixin helper to add scrollable content to widgets.
    /// 
    /// This can be used to provide scrollable contents and text for widgets. When <see cref="CoreUI.UI.IWidgetScrollableContent.ScrollableContent"/> or <see cref="CoreUI.UI.IWidgetScrollableContent.ScrollableText"/> is set, this mixin will create and manage an internal scroller object which will be the container of that text or content.
    /// 
    /// Only a single content or text can be set at any given time. Setting <see cref="CoreUI.UI.IWidgetScrollableContent.ScrollableText"/> will unset <see cref="CoreUI.UI.IWidgetScrollableContent.ScrollableContent"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.IWidgetScrollableContentNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IWidgetScrollableContent : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>This is the content which will be placed in the internal scroller.
        /// 
        /// If a <see cref="CoreUI.UI.IWidgetScrollableContent.ScrollableText"/> string is set, this property will be <c>NULL</c>.</summary>
        /// <returns>The content object.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Canvas.Object GetScrollableContent();

        /// <summary>This is the content which will be placed in the internal scroller.
        /// 
        /// If a <see cref="CoreUI.UI.IWidgetScrollableContent.ScrollableText"/> string is set, this property will be <c>NULL</c>.</summary>
        /// <param name="content">The content object.</param>
        /// <returns><c>true</c> on success.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool SetScrollableContent(CoreUI.Canvas.Object content);

        /// <summary>The text string to be displayed by the given text object. The text will use <see cref="CoreUI.TextFormatWrap.Mixed"/> wrapping, and it will be scrollable depending on its size relative to the object&apos;s geometry.
        /// 
        /// When reading, do not free the return value.</summary>
        /// <returns>Text string to display on it.</returns>
        /// <since_tizen> 6 </since_tizen>
        System.String GetScrollableText();

        /// <summary>The text string to be displayed by the given text object. The text will use <see cref="CoreUI.TextFormatWrap.Mixed"/> wrapping, and it will be scrollable depending on its size relative to the object&apos;s geometry.
        /// 
        /// When reading, do not free the return value.</summary>
        /// <param name="text">Text string to display on it.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetScrollableText(System.String text);

        /// <summary>This is the content which will be placed in the internal scroller.
        /// 
        /// If a <see cref="CoreUI.UI.IWidgetScrollableContent.ScrollableText"/> string is set, this property will be <c>NULL</c>.</summary>
        /// <value>The content object.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Canvas.Object ScrollableContent {
            get;
            set;
        }

        /// <summary>The text string to be displayed by the given text object. The text will use <see cref="CoreUI.TextFormatWrap.Mixed"/> wrapping, and it will be scrollable depending on its size relative to the object&apos;s geometry.
        /// 
        /// When reading, do not free the return value.</summary>
        /// <value>Text string to display on it.</value>
        /// <since_tizen> 6 </since_tizen>
        System.String ScrollableText {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IWidgetScrollableContentNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_widget_scrollable_content_mixin_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_widget_scrollable_content_get_static_delegate == null)
            {
                efl_ui_widget_scrollable_content_get_static_delegate = new efl_ui_widget_scrollable_content_get_delegate(scrollable_content_get);
            }

            if (methods.Contains("GetScrollableContent"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_scrollable_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scrollable_content_get_static_delegate) });
            }

            if (efl_ui_widget_scrollable_content_set_static_delegate == null)
            {
                efl_ui_widget_scrollable_content_set_static_delegate = new efl_ui_widget_scrollable_content_set_delegate(scrollable_content_set);
            }

            if (methods.Contains("SetScrollableContent"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_scrollable_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scrollable_content_set_static_delegate) });
            }

            if (efl_ui_widget_scrollable_text_get_static_delegate == null)
            {
                efl_ui_widget_scrollable_text_get_static_delegate = new efl_ui_widget_scrollable_text_get_delegate(scrollable_text_get);
            }

            if (methods.Contains("GetScrollableText"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_scrollable_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scrollable_text_get_static_delegate) });
            }

            if (efl_ui_widget_scrollable_text_set_static_delegate == null)
            {
                efl_ui_widget_scrollable_text_set_static_delegate = new efl_ui_widget_scrollable_text_set_delegate(scrollable_text_set);
            }

            if (methods.Contains("SetScrollableText"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_scrollable_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scrollable_text_set_static_delegate) });
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
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return efl_ui_widget_scrollable_content_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.Canvas.Object efl_ui_widget_scrollable_content_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.Canvas.Object efl_ui_widget_scrollable_content_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_scrollable_content_get_api_delegate> efl_ui_widget_scrollable_content_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_scrollable_content_get_api_delegate>(Module, "efl_ui_widget_scrollable_content_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Canvas.Object scrollable_content_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_widget_scrollable_content_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Canvas.Object _ret_var = default(CoreUI.Canvas.Object);
                try
                {
                    _ret_var = ((IWidgetScrollableContent)ws.Target).GetScrollableContent();
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
                return efl_ui_widget_scrollable_content_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_widget_scrollable_content_get_delegate efl_ui_widget_scrollable_content_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_scrollable_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object content);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_ui_widget_scrollable_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object content);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_scrollable_content_set_api_delegate> efl_ui_widget_scrollable_content_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_scrollable_content_set_api_delegate>(Module, "efl_ui_widget_scrollable_content_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool scrollable_content_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.Object content)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_widget_scrollable_content_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IWidgetScrollableContent)ws.Target).SetScrollableContent(content);
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
                return efl_ui_widget_scrollable_content_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), content);
            }
        }

        private static efl_ui_widget_scrollable_content_set_delegate efl_ui_widget_scrollable_content_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_widget_scrollable_text_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        internal delegate System.String efl_ui_widget_scrollable_text_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_scrollable_text_get_api_delegate> efl_ui_widget_scrollable_text_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_scrollable_text_get_api_delegate>(Module, "efl_ui_widget_scrollable_text_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.String scrollable_text_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_widget_scrollable_text_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IWidgetScrollableContent)ws.Target).GetScrollableText();
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
                return efl_ui_widget_scrollable_text_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_widget_scrollable_text_get_delegate efl_ui_widget_scrollable_text_get_static_delegate;

        
        private delegate void efl_ui_widget_scrollable_text_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String text);

        
        internal delegate void efl_ui_widget_scrollable_text_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String text);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_scrollable_text_set_api_delegate> efl_ui_widget_scrollable_text_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_scrollable_text_set_api_delegate>(Module, "efl_ui_widget_scrollable_text_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void scrollable_text_set(System.IntPtr obj, System.IntPtr pd, System.String text)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_widget_scrollable_text_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IWidgetScrollableContent)ws.Target).SetScrollableText(text);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_widget_scrollable_text_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), text);
            }
        }

        private static efl_ui_widget_scrollable_text_set_delegate efl_ui_widget_scrollable_text_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class WidgetScrollableContentExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Canvas.Object> ScrollableContent<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IWidgetScrollableContent, T>magic = null) where T : CoreUI.UI.IWidgetScrollableContent {
            return new CoreUI.BindableProperty<CoreUI.Canvas.Object>("scrollable_content", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> ScrollableText<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IWidgetScrollableContent, T>magic = null) where T : CoreUI.UI.IWidgetScrollableContent {
            return new CoreUI.BindableProperty<System.String>("scrollable_text", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

