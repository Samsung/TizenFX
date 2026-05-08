/*
 * Copyright(c) 2026 Samsung Electronics Co., Ltd.
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

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// UIContext provides access to UI-related functionality and context.
    /// UIContext is a singleton that provides access to UI context information including the default window,
    /// idle callbacks, and application locale settings.
    /// </summary>
    internal class UIContext : BaseHandle
    {
        private static UIContext instance;
        private Dictionary<System.Delegate, bool> idleCallbackMap;
        private delegate void RootIdleCallbackType();
        private static RootIdleCallbackType rootIdleCallback;
        private static bool rootIdleAdded = false;

        internal UIContext(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
        {
            // Singleton should not release native object.
            // The native UIContext is managed by the native Application lifecycle.
            //Interop.UiContext.DeleteUiContext(swigCPtr);
        }

        /// <summary>
        /// Constructs an empty handle.
        /// </summary>
        private UIContext()
        {
        }

        /// <summary>
        /// Gets the singleton UIContext instance.
        /// Returns null if the Application has not been created yet or has already been terminated.
        /// </summary>
        public static UIContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GetInternal();
                }
                return instance;
            }
        }

        private static UIContext GetInternal()
        {
            global::System.IntPtr cPtr = Interop.UiContext.Get();

            if (cPtr == global::System.IntPtr.Zero)
            {
                NUILog.ErrorBacktrace("UIContext.Instance called before Application created, or after Application terminated!");
                return null;
            }

            UIContext ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as UIContext;
            if (ret != null)
            {
                NUILog.ErrorBacktrace("UIContext.GetInternal() Should be called only one time!");
                object dummyObject = new object();
                HandleRef CPtr = new HandleRef(dummyObject, cPtr);
                Interop.BaseHandle.DeleteBaseHandle(CPtr);
                CPtr = new HandleRef(null, global::System.IntPtr.Zero);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }

            ret = new UIContext(cPtr, true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the main window. The application writer can use the window to build a scene.
        /// Returns null when the native window instance is invalid due to certain issues.
        /// </summary>
        /// <returns>A handle to the window. Returns null if the native window handle is invalid.</returns>
        public Window GetDefaultWindow()
        {
            var nativeWindow = Interop.UiContext.GetDefaultWindow(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // Return null if the native window handle is invalid
            if (nativeWindow == global::System.IntPtr.Zero)
            {
                return null;
            }

            Window ret = Registry.GetManagedBaseHandleFromNativePtr(nativeWindow) as Window;
            if (ret != null)
            {
                HandleRef cPtr = new HandleRef(this, nativeWindow);
                Interop.BaseHandle.DeleteBaseHandle(cPtr);
                cPtr = new HandleRef(null, global::System.IntPtr.Zero);
            }
            else
            {
                ret = new Window(nativeWindow, true);
            }
            return ret;
        }

        /// <summary>
        /// Retrieves the list of all windows in the application.
        /// </summary>
        /// <returns>A list of Window objects, or null if the dali adaptor is not initialized.</returns>
        /// <remarks>
        /// This method returns null if the dali adaptor and dali window are not ready.
        /// </remarks>
        public List<Window> GetWindowList()
        {
            if (Interop.Stage.IsInstalled() == false)
            {
                NUILog.ErrorBacktrace($"[ERROR] dali adaptor and dali window is not ready. just return NULL here");
                return null;
            }

            uint ListSize = Interop.Application.GetWindowsListSize();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            List<Window> WindowList = new List<Window>();
            for (uint i = 0; i < ListSize; ++i)
            {
                Window currWin = WindowList.GetInstanceSafely<Window>(Interop.Application.GetWindowsFromList(i));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                if (currWin != null)
                {
                    WindowList.Add(currWin);
                }
            }
            return WindowList;
        }

        private void RootIdleCallback()
        {
            if (idleCallbackMap == null)
            {
                return;
            }

            Tizen.Log.Debug("NUI", $"UIContext RootIdleCallback comes\n");

            foreach (var kvp in idleCallbackMap)
            {
                if (kvp.Value)
                {
                    bool result = (bool)kvp.Key.DynamicInvoke(null);
                    if (!result)
                    {
                        idleCallbackMap[kvp.Key] = false;
                    }
                }
            }

            Tizen.Log.Debug("NUI", $"UIContext RootIdleCallback finished\n");
        }

        /// <summary>
        /// Ensures that the function passed in is called from the main loop when it is idle.
        /// The callback will be called repeatedly as long as it returns true. A return of false deletes this callback.
        /// </summary>
        /// <param name="func">The function to call.</param>
        /// <returns>true if added successfully, false otherwise.</returns>
        /// <remarks>This function must be called from the main event thread only.</remarks>
        public bool AddIdle(System.Delegate func)
        {
            bool idleAdded = false; // default value is false

            if (idleCallbackMap == null || IsDisposedOrQueued)
            {
                Tizen.Log.Error("NUI", $"[Error] UIContext disposed! failed to add idle {func}\n");
                return false;
            }

            // Register root idle callback for UIContext
            if (!rootIdleAdded)
            {
                rootIdleCallback = RootIdleCallback;
                global::System.IntPtr ip = Marshal.GetFunctionPointerForDelegate<RootIdleCallbackType>(rootIdleCallback);
                global::System.IntPtr ip2 = Interop.Application.MakeCallback(new HandleRef(this, ip));

                bool ret = Interop.UiContext.AddIdle(SwigCPtr, new HandleRef(this, ip2));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                if (!ret)
                {
                    // Free the native callback pointer created by MakeCallback to prevent memory leak
                    Interop.BaseHandle.DeleteBaseHandle(new HandleRef(this, ip2));
                    rootIdleCallback = null;
                    Tizen.Log.Error("NUI", $"[Error] failed to add idle {func}\n");
                    return false;
                }
                rootIdleAdded = true;
            }

            if (idleCallbackMap.TryGetValue(func, out bool isValid))
            {
                idleAdded = true; // success case
                if (!isValid)
                {
                    idleCallbackMap[func] = true;
                }
                else
                {
                    Tizen.Log.Debug("NUI", $"Already added idle {func}\n");
                }
            }
            else if (idleCallbackMap.TryAdd(func, true))
            {
                idleAdded = true; // success case
            }

            if (!idleAdded)
            {
                Tizen.Log.Error("NUI", $"[Error] failed to add idle {func}\n");
            }

            return idleAdded;
        }

        /// <summary>
        /// Removes a previously added idle callback.
        /// </summary>
        /// <param name="func">The function to remove.</param>
        /// <remarks>This function must be called from the main event thread only.</remarks>
        public void RemoveIdle(System.Delegate func)
        {
            if (idleCallbackMap == null || IsDisposedOrQueued)
            {
                Tizen.Log.Error("NUI", $"[Error] UIContext disposed! failed to remove idle {func}\n");
                return;
            }

            if (idleCallbackMap.TryGetValue(func, out bool isValid))
            {
                if (isValid)
                {
                    idleCallbackMap[func] = false;
                }
            }
        }

        /// <summary>
        /// Relayouts the application and ensures all pending operations are flushed to the update thread.
        /// </summary>
        public void FlushUpdateMessages()
        {
            Interop.UiContext.FlushUpdateMessages(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the application's language independently of the system language.
        /// </summary>
        /// <param name="locale">The application's language and region in BCP 47 format (e.g., "en-US", "ko-KR").</param>
        public void SetApplicationLocale(string locale)
        {
            Interop.UiContext.SetApplicationLocale(SwigCPtr, locale);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                NUILog.ErrorBacktrace("We should not manually dispose for singleton class!");
            }
            else
            {
                base.Dispose(disposing);
            }
        }
    }
}
