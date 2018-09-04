/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// The StyleManager informs applications of the system theme change, and supports application theme change at runtime.<br />
    /// Applies various styles to controls using the properties system.<br />
    /// On theme change, it automatically updates all controls, then raises a event to inform the application.<br />
    /// If the application wants to customize the theme, RequestThemeChange needs to be called.<br />
    /// It provides the path to the application resource root folder, from there the filename can be specified along with any subfolders, for example, Images, Models, etc.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class StyleManager : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal StyleManager(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.StyleManager_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(StyleManager obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        private static readonly StyleManager instance = StyleManager.Get();

        /// <summary>
        /// Gets the singleton of the StyleManager object.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static StyleManager Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Style changed event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class StyleChangedEventArgs : EventArgs
        {
            private StyleManager _styleManager;
            private StyleChangeType _styleChange;

            /// <summary>
            /// StyleManager.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public StyleManager StyleManager
            {
                get
                {
                    return _styleManager;
                }
                set
                {
                    _styleManager = value;
                }
            }

            /// <summary>
            /// StyleChange - contains the style change information (default font changed or
            /// default font size changed or theme has changed).<br />
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public StyleChangeType StyleChange
            {
                get
                {
                    return _styleChange;
                }
                set
                {
                    _styleChange = value;
                }
            }

        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void StyleChangedCallbackDelegate(IntPtr styleManager, Tizen.NUI.StyleChangeType styleChange);
        private EventHandler<StyleChangedEventArgs> _styleManagerStyleChangedEventHandler;
        private StyleChangedCallbackDelegate _styleManagerStyleChangedCallbackDelegate;

        /// <summary>
        /// An event for the StyleChanged signal which can be used to subscribe or unsubscribe the
        /// event handler provided by the user.<br />
        /// The StyleChanged signal is emitted after the style (for example, theme or font change) has changed
        /// and the controls have been informed.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<StyleChangedEventArgs> StyleChanged
        {
            add
            {
                if (_styleManagerStyleChangedEventHandler == null)
                {
                    _styleManagerStyleChangedCallbackDelegate = (OnStyleChanged);
                    StyleChangedSignal().Connect(_styleManagerStyleChangedCallbackDelegate);
                }
                _styleManagerStyleChangedEventHandler += value;
            }
            remove
            {
                _styleManagerStyleChangedEventHandler -= value;
                if (_styleManagerStyleChangedEventHandler == null && StyleChangedSignal().Empty() == false)
                {
                    StyleChangedSignal().Disconnect(_styleManagerStyleChangedCallbackDelegate);
                }
            }
        }

        // Callback for StyleManager StyleChangedsignal
        private void OnStyleChanged(IntPtr styleManager, StyleChangeType styleChange)
        {
            StyleChangedEventArgs e = new StyleChangedEventArgs();

            // Populate all members of "e" (StyleChangedEventArgs) with real data.
            e.StyleManager = Registry.GetManagedBaseHandleFromNativePtr(styleManager) as StyleManager;
            e.StyleChange = styleChange;

            if (_styleManagerStyleChangedEventHandler != null)
            {
                //Here we send all data to user event handlers.
                _styleManagerStyleChangedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Creates a StyleManager handle.<br />
        /// This can be initialized with StyleManager::Get().<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public StyleManager() : this(NDalicPINVOKE.new_StyleManager(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the singleton of StyleManager object.
        /// </summary>
        /// <returns>A handle to the StyleManager control.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static StyleManager Get()
        {
            StyleManager ret = new StyleManager(NDalicPINVOKE.StyleManager_Get(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Applies a new theme to the application.<br />
        /// This will be merged on the top of the default Toolkit theme.<br />
        /// If the application theme file doesn't style all controls that the
        /// application uses, then the default Toolkit theme will be used
        /// instead for those controls.<br />
        /// </summary>
        /// <param name="themeFile">A relative path is specified for style theme.</param>
        /// <since_tizen> 3 </since_tizen>
        public void ApplyTheme(string themeFile)
        {
            NDalicPINVOKE.StyleManager_ApplyTheme(swigCPtr, themeFile);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Applies the default Toolkit theme.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void ApplyDefaultTheme()
        {
            NDalicPINVOKE.StyleManager_ApplyDefaultTheme(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets a constant for use when building styles.
        /// </summary>
        /// <param name="key">The key of the constant.</param>
        /// <param name="value">The value of the constant.</param>
        /// <since_tizen> 3 </since_tizen>
        public void AddConstant(string key, PropertyValue value)
        {
            NDalicPINVOKE.StyleManager_SetStyleConstant(swigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the style constant set for a specific key.
        /// </summary>
        /// <param name="key">The key of the constant.</param>
        /// <param name="valueOut">The value of the constant if it exists.</param>
        /// <returns></returns>
        /// <since_tizen> 3 </since_tizen>
        public bool GetConstant(string key, PropertyValue valueOut)
        {
            bool ret = NDalicPINVOKE.StyleManager_GetStyleConstant(swigCPtr, key, PropertyValue.getCPtr(valueOut));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Applies the specified style to the control.
        /// </summary>
        /// <param name="control">The control to which to apply the style.</param>
        /// <param name="jsonFileName">The name of the JSON style file to apply.</param>
        /// <param name="styleName">The name of the style within the JSON file to apply.</param>
        /// <since_tizen> 3 </since_tizen>
        public void ApplyStyle(View control, string jsonFileName, string styleName)
        {
            NDalicPINVOKE.StyleManager_ApplyStyle(swigCPtr, View.getCPtr(control), jsonFileName, styleName);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal StyleChangedSignal StyleChangedSignal()
        {
            StyleChangedSignal ret = new StyleChangedSignal(NDalicPINVOKE.StyleManager_StyleChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }
}
