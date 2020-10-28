using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {

        /// <summary>
        /// The ExtensionEventManager serves functions for the global extension event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class ExtensionEventManager
        {
            static Dictionary<Efl.Object, EventHandler> _backButtonEventHandlers = new Dictionary<Efl.Object, EventHandler>();
            static Dictionary<Efl.Object, Interop.Eext.EextEventCallback> _backButtonEventMap = new Dictionary<Efl.Object, Interop.Eext.EextEventCallback>();
            static Dictionary<Efl.Object, EventHandler> _moreButtonEventHandlers = new Dictionary<Efl.Object, EventHandler>();
            static Dictionary<Efl.Object, Interop.Eext.EextEventCallback> _moreButtonEventMap = new Dictionary<Efl.Object, Interop.Eext.EextEventCallback>();

            static void EnableButtonEventHandler(Efl.Object obj, Interop.Eext.EextCallbackType type)
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
                        obj.DelEvt += (s, e) => DisableButtonEventHandler(obj, type, true);
                    }
                }
                else if(type == Interop.Eext.EextCallbackType.EEXT_CALLBACK_MORE)
                {
                    if (!_moreButtonEventMap.ContainsKey(obj))
                    {
                        Interop.Eext.EextEventCallback cb = (d, o, i) =>
                        {
                            EventHandler events;
                            if (_moreButtonEventHandlers.TryGetValue(obj, out events))
                            {
                                events?.Invoke(obj, EventArgs.Empty);
                            }
                        };

                        Interop.Eext.eext_object_event_callback_add(obj.NativeHandle, type, cb, IntPtr.Zero);
                        _moreButtonEventMap[obj] = cb;
                    }
                }
            }

            static void DisableButtonEventHandler(Efl.Object obj, Interop.Eext.EextCallbackType type, bool removeHandler)
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
                else if(type == Interop.Eext.EextCallbackType.EEXT_CALLBACK_MORE)
                {
                    if (_moreButtonEventMap.TryGetValue(obj, out cb))
                    {
                        Interop.Eext.eext_object_event_callback_del(obj.NativeHandle, type, cb);
                        _moreButtonEventMap.Remove(obj);
                    }
                    if (removeHandler && _moreButtonEventHandlers.ContainsKey(obj))
                    {
                        _moreButtonEventHandlers.Remove(obj);
                    }
                }
            }

            /// <summary>
            /// Adds a handler for the back button event on a specific Efl.Object.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public static void AddBackButtonEventHandler(this Efl.Object obj, EventHandler handler)
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
            /// Removes a handler on a specific Efl.Object for the back button event.
            /// </summary>
            public static void RemoveBackButtonEventHandler(this Efl.Object obj, EventHandler handler)
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

            /// <summary>
            /// Adds a handler for the more button event on a specific Efl.Object.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public static void AddMoreButtonEventHandler(this Efl.Object obj, EventHandler handler)
            {
                EnableButtonEventHandler(obj, Interop.Eext.EextCallbackType.EEXT_CALLBACK_MORE);

                if (_moreButtonEventHandlers.ContainsKey(obj))
                {
                    _moreButtonEventHandlers[obj] += handler;
                }
                else
                {
                    _moreButtonEventHandlers[obj] = handler;
                }
            }

            /// <summary>
            /// Removes a handler on a specific Efl.Object for the more button event.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public static void RemoveMoreButtonEventHandler(this Efl.Object obj, EventHandler handler)
            {
                if (_moreButtonEventHandlers.ContainsKey(obj))
                {
                    _moreButtonEventHandlers[obj] -= handler;
                    if (_moreButtonEventHandlers[obj] == null)
                    {
                        DisableButtonEventHandler(obj, Interop.Eext.EextCallbackType.EEXT_CALLBACK_MORE, false);
                        _moreButtonEventHandlers.Remove(obj);
                    }
                }
            }
        }
    }
}
