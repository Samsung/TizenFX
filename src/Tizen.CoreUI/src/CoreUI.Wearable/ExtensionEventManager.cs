using System;
using System.Collections.Generic;
using System.Text;

namespace CoreUI
{
    namespace Extension
    {
        /// <summary>
        /// The ExtensionEventManager serves functions for the global extension event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class ExtensionEventManager
        {
            static Dictionary<CoreUI.Object, EventHandler> _backButtonEventHandlers = new Dictionary<CoreUI.Object, EventHandler>();
            static Dictionary<CoreUI.Object, Interop.Eext.EextEventCallback> _backButtonEventMap = new Dictionary<CoreUI.Object, Interop.Eext.EextEventCallback>();
            static Dictionary<CoreUI.Object, EventHandler> _moreButtonEventHandlers = new Dictionary<CoreUI.Object, EventHandler>();
            static Dictionary<CoreUI.Object, Interop.Eext.EextEventCallback> _moreButtonEventMap = new Dictionary<CoreUI.Object, Interop.Eext.EextEventCallback>();

            static void EnableButtonEventHandler(CoreUI.Object obj, Interop.Eext.EextCallbackType type)
            {
                if (type == Interop.Eext.EextCallbackType.EEXT_CALLBACK_BACK)
                {
                    if (!_backButtonEventMap.ContainsKey(obj))
                    {
                        Interop.Eext.EextEventCallback cb = (d, o, i) =>
                        {
                            EventHandler events;
                            if (_backButtonEventHandlers.TryGetValue(obj, out events))
                            {
                                events?.Invoke(obj, EventArgs.Empty);
                            }
                        };

                        Interop.Eext.eext_object_event_callback_add(obj.NativeHandle, type, cb, IntPtr.Zero);
                        _backButtonEventMap[obj] = cb;

                        EventHandler delEventHandler = (s, e) => DisableButtonEventHandler(obj, type, true);
                        CoreUI.EventCb callerCb = obj.GetInternalEventCallback(delEventHandler);
                        string key = "_EFL_EVENT_DEL";
                        obj.AddNativeEventHandler(CoreUI.Libs.Eo, key, callerCb, delEventHandler);
                    }
                }
            }

            static void DisableButtonEventHandler(CoreUI.Object obj, Interop.Eext.EextCallbackType type, bool removeHandler)
            {
                Interop.Eext.EextEventCallback cb;

                if (type == Interop.Eext.EextCallbackType.EEXT_CALLBACK_BACK)
                {
                    if (_backButtonEventMap.TryGetValue(obj, out cb))
                    {
                        Interop.Eext.eext_object_event_callback_del(obj.NativeHandle, type, cb);
                        _backButtonEventMap.Remove(obj);
                    }
                    if (removeHandler && _backButtonEventHandlers.ContainsKey(obj))
                    {
                        _backButtonEventHandlers.Remove(obj);
                    }
                }
            }

            /// <summary>
            /// Adds a handler for the back button event on a specific CoreUI.Object.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public static void AddBackButtonEventHandler(this CoreUI.Object obj, EventHandler handler)
            {
                EnableButtonEventHandler(obj, Interop.Eext.EextCallbackType.EEXT_CALLBACK_BACK);

                if (_backButtonEventHandlers.ContainsKey(obj))
                {
                    _backButtonEventHandlers[obj] += handler;
                }
                else
                {
                    _backButtonEventHandlers[obj] = handler;
                }
            }

            /// <summary>
            /// Removes a handler on a specific CoreUI.Object for the back button event.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public static void RemoveBackButtonEventHandler(this CoreUI.Object obj, EventHandler handler)
            {
                if (_backButtonEventHandlers.ContainsKey(obj))
                {
                    _backButtonEventHandlers[obj] -= handler;
                    if (_backButtonEventHandlers[obj] == null)
                    {
                        DisableButtonEventHandler(obj, Interop.Eext.EextCallbackType.EEXT_CALLBACK_BACK, false);
                        _backButtonEventHandlers.Remove(obj);
                    }
                }
            }
        }
    }
}
