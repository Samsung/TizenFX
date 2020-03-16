/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    public partial class AccessibilityManager
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool StatusChangedEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerStatusChangedEventHandler;
        private StatusChangedEventCallbackDelegate _accessibilityManagerStatusChangedEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionNextEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionNextEventHandler;
        private ActionNextEventCallbackDelegate _accessibilityManagerActionNextEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPreviousEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionPreviousEventHandler;
        private ActionPreviousEventCallbackDelegate _accessibilityManagerActionPreviousEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionActivateEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionActivateEventHandler;
        private ActionActivateEventCallbackDelegate _accessibilityManagerActionActivateEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionReadEventHandler;
        private ActionReadEventCallbackDelegate _accessibilityManagerActionReadEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionOverEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionOverEventHandler;
        private ActionOverEventCallbackDelegate _accessibilityManagerActionOverEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadNextEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionReadNextEventHandler;
        private ActionReadNextEventCallbackDelegate _accessibilityManagerActionReadNextEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadPreviousEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionReadPreviousEventHandler;
        private ActionReadPreviousEventCallbackDelegate _accessibilityManagerActionReadPreviousEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionUpEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionUpEventHandler;
        private ActionUpEventCallbackDelegate _accessibilityManagerActionUpEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionDownEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionDownEventHandler;
        private ActionDownEventCallbackDelegate _accessibilityManagerActionDownEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionClearFocusEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionClearFocusEventHandler;
        private ActionClearFocusEventCallbackDelegate _accessibilityManagerActionClearFocusEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionBackEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionBackEventHandler;
        private ActionBackEventCallbackDelegate _accessibilityManagerActionBackEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionScrollUpEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionScrollUpEventHandler;
        private ActionScrollUpEventCallbackDelegate _accessibilityManagerActionScrollUpEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionScrollDownEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionScrollDownEventHandler;
        private ActionScrollDownEventCallbackDelegate _accessibilityManagerActionScrollDownEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPageLeftEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionPageLeftEventHandler;
        private ActionPageLeftEventCallbackDelegate _accessibilityManagerActionPageLeftEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPageRightEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionPageRightEventHandler;
        private ActionPageRightEventCallbackDelegate _accessibilityManagerActionPageRightEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPageUpEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionPageUpEventHandler;
        private ActionPageUpEventCallbackDelegate _accessibilityManagerActionPageUpEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPageDownEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionPageDownEventHandler;
        private ActionPageDownEventCallbackDelegate _accessibilityManagerActionPageDownEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionMoveToFirstEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionMoveToFirstEventHandler;
        private ActionMoveToFirstEventCallbackDelegate _accessibilityManagerActionMoveToFirstEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionMoveToLastEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionMoveToLastEventHandler;
        private ActionMoveToLastEventCallbackDelegate _accessibilityManagerActionMoveToLastEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadFromTopEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionReadFromTopEventHandler;
        private ActionReadFromTopEventCallbackDelegate _accessibilityManagerActionReadFromTopEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadFromNextEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionReadFromNextEventHandler;
        private ActionReadFromNextEventCallbackDelegate _accessibilityManagerActionReadFromNextEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionZoomEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionZoomEventHandler;
        private ActionZoomEventCallbackDelegate _accessibilityManagerActionZoomEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadPauseResumeEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionReadPauseResumeEventHandler;
        private ActionReadPauseResumeEventCallbackDelegate _accessibilityManagerActionReadPauseResumeEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionStartStopEventCallbackDelegate(IntPtr accessibilityManager);
        private EventHandlerWithReturnType<object, EventArgs, bool> _accessibilityManagerActionStartStopEventHandler;
        private ActionStartStopEventCallbackDelegate _accessibilityManagerActionStartStopEventCallbackDelegate;

        /*
            // To be replaced by a new event that takes Touch
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate bool ActionScrollEventCallbackDelegate(IntPtr accessibilityManager, IntPtr touchEvent);
            private EventHandlerWithReturnType<object,ActionScrollEventArgs,bool> _accessibilityManagerActionScrollEventHandler;
            private ActionScrollEventCallbackDelegate _accessibilityManagerActionScrollEventCallbackDelegate;
        */

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FocusChangedEventCallbackDelegate(IntPtr view1, IntPtr view2);
        private EventHandler<FocusChangedEventArgs> _accessibilityManagerFocusChangedEventHandler;
        private FocusChangedEventCallbackDelegate _accessibilityManagerFocusChangedEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FocusedViewActivatedEventCallbackDelegate(IntPtr view);
        private EventHandler<FocusedViewActivatedEventArgs> _accessibilityManagerFocusedViewActivatedEventHandler;
        private FocusedViewActivatedEventCallbackDelegate _accessibilityManagerFocusedViewActivatedEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FocusOvershotEventCallbackDelegate(IntPtr currentFocusedView, AccessibilityManager.FocusOvershotDirection direction);
        private EventHandler<FocusOvershotEventArgs> _accessibilityManagerFocusOvershotEventHandler;
        private FocusOvershotEventCallbackDelegate _accessibilityManagerFocusOvershotEventCallbackDelegate;

        // Accessibility action signals

        /// <summary>
        /// This is emitted when accessibility(screen-reader) feature turned on or off.
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> StatusChanged
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerStatusChangedEventHandler == null)
                {
                    _accessibilityManagerStatusChangedEventHandler += value;

                    _accessibilityManagerStatusChangedEventCallbackDelegate = new StatusChangedEventCallbackDelegate(OnStatusChanged);
                    this.StatusChangedSignal().Connect(_accessibilityManagerStatusChangedEventCallbackDelegate);
                }
            }

            remove
            {

                if (_accessibilityManagerStatusChangedEventHandler != null)
                {
                    this.StatusChangedSignal().Disconnect(_accessibilityManagerStatusChangedEventCallbackDelegate);
                }

                _accessibilityManagerStatusChangedEventHandler -= value;

            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to move focus to the next focusable view (by one finger flick down).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionNext
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionNextEventHandler == null)
                {
                    _accessibilityManagerActionNextEventHandler += value;

                    _accessibilityManagerActionNextEventCallbackDelegate = new ActionNextEventCallbackDelegate(OnActionNext);
                    this.ActionNextSignal().Connect(_accessibilityManagerActionNextEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionNextEventHandler != null)
                {
                    this.ActionNextSignal().Disconnect(_accessibilityManagerActionNextEventCallbackDelegate);
                }

                _accessibilityManagerActionNextEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to move focus to the previous focusable view (by one finger flick up).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionPrevious
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionPreviousEventHandler == null)
                {
                    _accessibilityManagerActionPreviousEventHandler += value;

                    _accessibilityManagerActionPreviousEventCallbackDelegate = new ActionPreviousEventCallbackDelegate(OnActionPrevious);
                    this.ActionPreviousSignal().Connect(_accessibilityManagerActionPreviousEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionPreviousEventHandler != null)
                {
                    this.ActionPreviousSignal().Disconnect(_accessibilityManagerActionPreviousEventCallbackDelegate);
                }

                _accessibilityManagerActionPreviousEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to activate the current focused view (by one finger double tap).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionActivate
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionActivateEventHandler == null)
                {
                    _accessibilityManagerActionActivateEventHandler += value;

                    _accessibilityManagerActionActivateEventCallbackDelegate = new ActionActivateEventCallbackDelegate(OnActionActivate);
                    this.ActionActivateSignal().Connect(_accessibilityManagerActionActivateEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionActivateEventHandler != null)
                {
                    this.ActionActivateSignal().Disconnect(_accessibilityManagerActionActivateEventCallbackDelegate);
                }

                _accessibilityManagerActionActivateEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to focus and read the view (by one finger tap).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionRead
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionReadEventHandler == null)
                {
                    _accessibilityManagerActionReadEventHandler += value;

                    _accessibilityManagerActionReadEventCallbackDelegate = new ActionReadEventCallbackDelegate(OnActionRead);
                    this.ActionReadSignal().Connect(_accessibilityManagerActionReadEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionReadEventHandler != null)
                {
                    this.ActionReadSignal().Disconnect(_accessibilityManagerActionReadEventCallbackDelegate);
                }

                _accessibilityManagerActionReadEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to focus and read the view  (by one finger move).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionOver
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionOverEventHandler == null)
                {
                    _accessibilityManagerActionOverEventHandler += value;

                    _accessibilityManagerActionOverEventCallbackDelegate = new ActionOverEventCallbackDelegate(OnActionOver);
                    this.ActionOverSignal().Connect(_accessibilityManagerActionOverEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionOverEventHandler != null)
                {
                    this.ActionOverSignal().Disconnect(_accessibilityManagerActionOverEventCallbackDelegate);
                }

                _accessibilityManagerActionOverEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to move focus to the next focusable view (by one finger flick right).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionReadNext
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionReadNextEventHandler == null)
                {
                    _accessibilityManagerActionReadNextEventHandler += value;

                    _accessibilityManagerActionReadNextEventCallbackDelegate = new ActionReadNextEventCallbackDelegate(OnActionReadNext);
                    this.ActionReadNextSignal().Connect(_accessibilityManagerActionReadNextEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionReadNextEventHandler != null)
                {
                    this.ActionReadNextSignal().Disconnect(_accessibilityManagerActionReadNextEventCallbackDelegate);
                }

                _accessibilityManagerActionReadNextEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to move focus to the previous focusable view (by one finger flick left).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionReadPrevious
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionReadPreviousEventHandler == null)
                {
                    _accessibilityManagerActionReadPreviousEventHandler += value;

                    _accessibilityManagerActionReadPreviousEventCallbackDelegate = new ActionReadPreviousEventCallbackDelegate(OnActionReadPrevious);
                    this.ActionReadPreviousSignal().Connect(_accessibilityManagerActionReadPreviousEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionReadPreviousEventHandler != null)
                {
                    this.ActionReadPreviousSignal().Disconnect(_accessibilityManagerActionReadPreviousEventCallbackDelegate);
                }

                _accessibilityManagerActionReadPreviousEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to change the value when the current focused view is a slider
        /// (by double finger down and move up and right).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionUp
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionUpEventHandler == null)
                {
                    _accessibilityManagerActionUpEventHandler += value;

                    _accessibilityManagerActionUpEventCallbackDelegate = new ActionUpEventCallbackDelegate(OnActionUp);
                    this.ActionUpSignal().Connect(_accessibilityManagerActionUpEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionUpEventHandler != null)
                {
                    this.ActionUpSignal().Disconnect(_accessibilityManagerActionUpEventCallbackDelegate);
                }

                _accessibilityManagerActionUpEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to change the value when the current focused view is a slider
        /// (by double finger down and move down and left).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionDown
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionDownEventHandler == null)
                {
                    _accessibilityManagerActionDownEventHandler += value;

                    _accessibilityManagerActionDownEventCallbackDelegate = new ActionDownEventCallbackDelegate(OnActionDown);
                    this.ActionDownSignal().Connect(_accessibilityManagerActionDownEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionDownEventHandler != null)
                {
                    this.ActionDownSignal().Disconnect(_accessibilityManagerActionDownEventCallbackDelegate);
                }

                _accessibilityManagerActionDownEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to clear the focus from the current focused view
        /// if any, so that no view is focused in the focus chain.
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionClearFocus
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionClearFocusEventHandler == null)
                {
                    _accessibilityManagerActionClearFocusEventHandler += value;

                    _accessibilityManagerActionClearFocusEventCallbackDelegate = new ActionClearFocusEventCallbackDelegate(OnActionClearFocus);
                    this.ActionClearFocusSignal().Connect(_accessibilityManagerActionClearFocusEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionClearFocusEventHandler != null)
                {
                    this.ActionClearFocusSignal().Disconnect(_accessibilityManagerActionClearFocusEventCallbackDelegate);
                }

                _accessibilityManagerActionClearFocusEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to navigate back (by two fingers circle draw).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionBack
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionBackEventHandler == null)
                {
                    _accessibilityManagerActionBackEventHandler += value;

                    _accessibilityManagerActionBackEventCallbackDelegate = new ActionBackEventCallbackDelegate(OnActionBack);
                    this.ActionBackSignal().Connect(_accessibilityManagerActionBackEventCallbackDelegate);
                }
            }

            remove
            {

                if (_accessibilityManagerActionBackEventHandler != null)
                {
                    this.ActionBackSignal().Disconnect(_accessibilityManagerActionBackEventCallbackDelegate);
                }

                _accessibilityManagerActionBackEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to scroll up the list (by two finger swipe up).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionScrollUp
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionScrollUpEventHandler == null)
                {
                    _accessibilityManagerActionScrollUpEventHandler += value;

                    _accessibilityManagerActionScrollUpEventCallbackDelegate = new ActionScrollUpEventCallbackDelegate(OnActionScrollUp);
                    this.ActionScrollUpSignal().Connect(_accessibilityManagerActionScrollUpEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionScrollUpEventHandler != null)
                {
                    this.ActionScrollUpSignal().Disconnect(_accessibilityManagerActionScrollUpEventCallbackDelegate);
                }

                _accessibilityManagerActionScrollUpEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to scroll down the list (by two finger swipe down).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionScrollDown
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionScrollDownEventHandler == null)
                {
                    _accessibilityManagerActionScrollDownEventHandler += value;

                    _accessibilityManagerActionScrollDownEventCallbackDelegate = new ActionScrollDownEventCallbackDelegate(OnActionScrollDown);
                    this.ActionScrollDownSignal().Connect(_accessibilityManagerActionScrollDownEventCallbackDelegate);
                }
            }

            remove
            {

                if (_accessibilityManagerActionScrollDownEventHandler != null)
                {
                    this.ActionScrollDownSignal().Disconnect(_accessibilityManagerActionScrollDownEventCallbackDelegate);
                }

                _accessibilityManagerActionScrollDownEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to scroll left to the previous page (by two finger swipe left).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionPageLeft
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionPageLeftEventHandler == null)
                {
                    _accessibilityManagerActionPageLeftEventHandler += value;

                    _accessibilityManagerActionPageLeftEventCallbackDelegate = new ActionPageLeftEventCallbackDelegate(OnActionPageLeft);
                    this.ActionPageLeftSignal().Connect(_accessibilityManagerActionPageLeftEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionPageLeftEventHandler != null)
                {
                    this.ActionPageLeftSignal().Disconnect(_accessibilityManagerActionPageLeftEventCallbackDelegate);
                }

                _accessibilityManagerActionPageLeftEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to scroll right to the next page (by two finger swipe right).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionPageRight
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionPageRightEventHandler == null)
                {
                    _accessibilityManagerActionPageRightEventHandler += value;

                    _accessibilityManagerActionPageRightEventCallbackDelegate = new ActionPageRightEventCallbackDelegate(OnActionPageRight);
                    this.ActionPageRightSignal().Connect(_accessibilityManagerActionPageRightEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionPageRightEventHandler != null)
                {
                    this.ActionPageRightSignal().Disconnect(_accessibilityManagerActionPageRightEventCallbackDelegate);
                }

                _accessibilityManagerActionPageRightEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to scroll up to the previous page (by one finger swipe left and right).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionPageUp
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionPageUpEventHandler == null)
                {
                    _accessibilityManagerActionPageUpEventHandler += value;

                    _accessibilityManagerActionPageUpEventCallbackDelegate = new ActionPageUpEventCallbackDelegate(OnActionPageUp);
                    this.ActionPageUpSignal().Connect(_accessibilityManagerActionPageUpEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionPageUpEventHandler != null)
                {
                    this.ActionPageUpSignal().Disconnect(_accessibilityManagerActionPageUpEventCallbackDelegate);
                }

                _accessibilityManagerActionPageUpEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to scroll down to the next page (by one finger swipe right and left).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionPageDown
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionPageDownEventHandler == null)
                {
                    _accessibilityManagerActionPageDownEventHandler += value;

                    _accessibilityManagerActionPageDownEventCallbackDelegate = new ActionPageDownEventCallbackDelegate(OnActionPageDown);
                    this.ActionPageDownSignal().Connect(_accessibilityManagerActionPageDownEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionPageDownEventHandler != null)
                {
                    this.ActionPageDownSignal().Disconnect(_accessibilityManagerActionPageDownEventCallbackDelegate);
                }

                _accessibilityManagerActionPageDownEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to move the focus to the first item on the screen
        /// (by one finger swipe up and down).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionMoveToFirst
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionMoveToFirstEventHandler == null)
                {
                    _accessibilityManagerActionMoveToFirstEventHandler += value;

                    _accessibilityManagerActionMoveToFirstEventCallbackDelegate = new ActionMoveToFirstEventCallbackDelegate(OnActionMoveToFirst);
                    this.ActionMoveToFirstSignal().Connect(_accessibilityManagerActionMoveToFirstEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionMoveToFirstEventHandler != null)
                {
                    this.ActionMoveToFirstSignal().Disconnect(_accessibilityManagerActionMoveToFirstEventCallbackDelegate);
                }

                _accessibilityManagerActionMoveToFirstEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to move the focus to the last item on the screen
        /// (by one finger swipe down and up).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionMoveToLast
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionMoveToLastEventHandler == null)
                {
                    _accessibilityManagerActionMoveToLastEventHandler += value;

                    _accessibilityManagerActionMoveToLastEventCallbackDelegate = new ActionMoveToLastEventCallbackDelegate(OnActionMoveToLast);
                    this.ActionMoveToLastSignal().Connect(_accessibilityManagerActionMoveToLastEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionMoveToLastEventHandler != null)
                {
                    this.ActionMoveToLastSignal().Disconnect(_accessibilityManagerActionMoveToLastEventCallbackDelegate);
                }

                _accessibilityManagerActionMoveToLastEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to focus and read from the first item on the top continuously
        /// (by three fingers single tap).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionReadFromTop
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionReadFromTopEventHandler == null)
                {
                    _accessibilityManagerActionReadFromTopEventHandler += value;

                    _accessibilityManagerActionReadFromTopEventCallbackDelegate = new ActionReadFromTopEventCallbackDelegate(OnActionReadFromTop);
                    this.ActionReadFromTopSignal().Connect(_accessibilityManagerActionReadFromTopEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionReadFromTopEventHandler != null)
                {
                    this.ActionReadFromTopSignal().Disconnect(_accessibilityManagerActionReadFromTopEventCallbackDelegate);
                }

                _accessibilityManagerActionReadFromTopEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to move the focus to and read from the next item continuously
        /// (by three fingers double tap).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionReadFromNext
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionReadFromNextEventHandler == null)
                {
                    _accessibilityManagerActionReadFromNextEventHandler += value;

                    _accessibilityManagerActionReadFromNextEventCallbackDelegate = new ActionReadFromNextEventCallbackDelegate(OnActionReadFromNext);
                    this.ActionReadFromNextSignal().Connect(_accessibilityManagerActionReadFromNextEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionReadFromNextEventHandler != null)
                {
                    this.ActionReadFromNextSignal().Disconnect(_accessibilityManagerActionReadFromNextEventCallbackDelegate);
                }

                _accessibilityManagerActionReadFromNextEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to zoom (by one finger triple tap)
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionZoom
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionZoomEventHandler == null)
                {
                    _accessibilityManagerActionZoomEventHandler += value;

                    _accessibilityManagerActionZoomEventCallbackDelegate = new ActionZoomEventCallbackDelegate(OnActionZoom);
                    this.ActionZoomSignal().Connect(_accessibilityManagerActionZoomEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionZoomEventHandler != null)
                {
                    this.ActionZoomSignal().Disconnect(_accessibilityManagerActionZoomEventCallbackDelegate);
                }

                _accessibilityManagerActionZoomEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to pause/resume the current speech (by two fingers single tap).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionReadPauseResume
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionReadPauseResumeEventHandler == null)
                {
                    _accessibilityManagerActionReadPauseResumeEventHandler += value;

                    _accessibilityManagerActionReadPauseResumeEventCallbackDelegate = new ActionReadPauseResumeEventCallbackDelegate(OnActionReadPauseResume);
                    this.ActionReadPauseResumeSignal().Connect(_accessibilityManagerActionReadPauseResumeEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionReadPauseResumeEventHandler != null)
                {
                    this.ActionReadPauseResumeSignal().Disconnect(_accessibilityManagerActionReadPauseResumeEventCallbackDelegate);
                }

                _accessibilityManagerActionReadPauseResumeEventHandler -= value;
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to start/stop the current action (by two fingers double tap).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> ActionStartStop
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerActionStartStopEventHandler == null)
                {
                    _accessibilityManagerActionStartStopEventHandler += value;

                    _accessibilityManagerActionStartStopEventCallbackDelegate = new ActionStartStopEventCallbackDelegate(OnActionStartStop);
                    this.ActionStartStopSignal().Connect(_accessibilityManagerActionStartStopEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerActionStartStopEventHandler != null)
                {
                    this.ActionStartStopSignal().Disconnect(_accessibilityManagerActionStartStopEventCallbackDelegate);
                }

                _accessibilityManagerActionStartStopEventHandler -= value;
            }
        }

        /*
            // To be replaced by a new event that takes Touch
            public event DaliEventHandlerWithReturnType<object,ActionScrollEventArgs,bool> ActionScroll
            {
              add
              {
                lock(this)
                {
                  // Restricted to only one listener
                  if (_accessibilityManagerActionScrollEventHandler == null)
                  {
                    _accessibilityManagerActionScrollEventHandler += value;

                    _accessibilityManagerActionScrollEventCallbackDelegate = new ActionScrollEventCallbackDelegate(OnActionScroll);
                    this.ActionScrollSignal().Connect(_accessibilityManagerActionScrollEventCallbackDelegate);
                  }
                }
              }

              remove
              {
                lock(this)
                {
                  if (_accessibilityManagerActionScrollEventHandler != null)
                  {
                    this.ActionScrollSignal().Disconnect(_accessibilityManagerActionScrollEventCallbackDelegate);
                  }

                  _accessibilityManagerActionScrollEventHandler -= value;
                }
              }
            }

            // Callback for AccessibilityManager ActionScrollSignal
            private bool OnActionScroll(IntPtr accessibilityManager, IntPtr touchEvent)
            {
              ActionScrollEventArgs e = new ActionScrollEventArgs();

              // Populate all members of "e" (ActionScrollEventArgs) with real data
              e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(accessibilityManager);
              e.TouchEvent = TouchEvent.GetTouchEventFromPtr(touchEvent);

              if (_accessibilityManagerActionScrollEventHandler != null)
              {
                //here we send all data to user event handlers
                return _accessibilityManagerActionScrollEventHandler(this, e);
              }
              return false;
            }
        */

        // Common Signals

        /// <summary>
        /// This signal is emitted when the current focused view is changed.
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<FocusChangedEventArgs> FocusChanged
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerFocusChangedEventHandler == null)
                {
                    _accessibilityManagerFocusChangedEventHandler += value;

                    _accessibilityManagerFocusChangedEventCallbackDelegate = new FocusChangedEventCallbackDelegate(OnFocusChanged);
                    this.FocusChangedSignal().Connect(_accessibilityManagerFocusChangedEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerFocusChangedEventHandler != null)
                {
                    this.FocusChangedSignal().Disconnect(_accessibilityManagerFocusChangedEventCallbackDelegate);
                }

                _accessibilityManagerFocusChangedEventHandler -= value;
            }
        }

        /// <summary>
        /// This signal is emitted when the current focused view is activated.
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<FocusedViewActivatedEventArgs> FocusedViewActivated
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerFocusedViewActivatedEventHandler == null)
                {
                    _accessibilityManagerFocusedViewActivatedEventHandler += value;

                    _accessibilityManagerFocusedViewActivatedEventCallbackDelegate = new FocusedViewActivatedEventCallbackDelegate(OnFocusedViewActivated);
                    this.FocusedViewActivatedSignal().Connect(_accessibilityManagerFocusedViewActivatedEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerFocusedViewActivatedEventHandler != null)
                {
                    this.FocusedViewActivatedSignal().Disconnect(_accessibilityManagerFocusedViewActivatedEventCallbackDelegate);
                }

                _accessibilityManagerFocusedViewActivatedEventHandler -= value;
            }
        }

        /// <summary>
        /// This signal is emitted when there is no way to move focus further.
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<FocusOvershotEventArgs> FocusOvershot
        {
            add
            {
                // Restricted to only one listener
                if (_accessibilityManagerFocusOvershotEventHandler == null)
                {
                    _accessibilityManagerFocusOvershotEventHandler += value;

                    _accessibilityManagerFocusOvershotEventCallbackDelegate = new FocusOvershotEventCallbackDelegate(OnFocusOvershot);
                    this.FocusOvershotSignal().Connect(_accessibilityManagerFocusOvershotEventCallbackDelegate);
                }
            }

            remove
            {
                if (_accessibilityManagerFocusOvershotEventHandler != null)
                {
                    this.FocusOvershotSignal().Disconnect(_accessibilityManagerFocusOvershotEventCallbackDelegate);
                }

                _accessibilityManagerFocusOvershotEventHandler -= value;
            }
        }
    }
}
