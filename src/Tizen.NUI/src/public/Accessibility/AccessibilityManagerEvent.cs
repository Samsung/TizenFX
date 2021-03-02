/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Accessibility
{
    public partial class AccessibilityManager
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool StatusChangedEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerStatusChangedEventHandler;
        private StatusChangedEventCallbackDelegate accessibilityManagerStatusChangedEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionNextEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionNextEventHandler;
        private ActionNextEventCallbackDelegate accessibilityManagerActionNextEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPreviousEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionPreviousEventHandler;
        private ActionPreviousEventCallbackDelegate accessibilityManagerActionPreviousEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionActivateEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionActivateEventHandler;
        private ActionActivateEventCallbackDelegate accessibilityManagerActionActivateEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionReadEventHandler;
        private ActionReadEventCallbackDelegate accessibilityManagerActionReadEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionOverEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionOverEventHandler;
        private ActionOverEventCallbackDelegate accessibilityManagerActionOverEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadNextEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionReadNextEventHandler;
        private ActionReadNextEventCallbackDelegate accessibilityManagerActionReadNextEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadPreviousEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionReadPreviousEventHandler;
        private ActionReadPreviousEventCallbackDelegate accessibilityManagerActionReadPreviousEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionUpEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionUpEventHandler;
        private ActionUpEventCallbackDelegate accessibilityManagerActionUpEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionDownEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionDownEventHandler;
        private ActionDownEventCallbackDelegate accessibilityManagerActionDownEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionClearFocusEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionClearFocusEventHandler;
        private ActionClearFocusEventCallbackDelegate accessibilityManagerActionClearFocusEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionBackEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionBackEventHandler;
        private ActionBackEventCallbackDelegate accessibilityManagerActionBackEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionScrollUpEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionScrollUpEventHandler;
        private ActionScrollUpEventCallbackDelegate accessibilityManagerActionScrollUpEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionScrollDownEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionScrollDownEventHandler;
        private ActionScrollDownEventCallbackDelegate accessibilityManagerActionScrollDownEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPageLeftEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionPageLeftEventHandler;
        private ActionPageLeftEventCallbackDelegate accessibilityManagerActionPageLeftEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPageRightEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionPageRightEventHandler;
        private ActionPageRightEventCallbackDelegate accessibilityManagerActionPageRightEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPageUpEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionPageUpEventHandler;
        private ActionPageUpEventCallbackDelegate accessibilityManagerActionPageUpEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPageDownEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionPageDownEventHandler;
        private ActionPageDownEventCallbackDelegate accessibilityManagerActionPageDownEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionMoveToFirstEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionMoveToFirstEventHandler;
        private ActionMoveToFirstEventCallbackDelegate accessibilityManagerActionMoveToFirstEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionMoveToLastEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionMoveToLastEventHandler;
        private ActionMoveToLastEventCallbackDelegate accessibilityManagerActionMoveToLastEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadFromTopEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionReadFromTopEventHandler;
        private ActionReadFromTopEventCallbackDelegate accessibilityManagerActionReadFromTopEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadFromNextEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionReadFromNextEventHandler;
        private ActionReadFromNextEventCallbackDelegate accessibilityManagerActionReadFromNextEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionZoomEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionZoomEventHandler;
        private ActionZoomEventCallbackDelegate accessibilityManagerActionZoomEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadPauseResumeEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionReadPauseResumeEventHandler;
        private ActionReadPauseResumeEventCallbackDelegate accessibilityManagerActionReadPauseResumeEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionStartStopEventCallbackDelegate(IntPtr accessibilityManager);
        private ReturnTypeEventHandler<object, EventArgs, bool> accessibilityManagerActionStartStopEventHandler;
        private ActionStartStopEventCallbackDelegate accessibilityManagerActionStartStopEventCallbackDelegate;

        /*
            // To be replaced by a new event that takes Touch
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate bool ActionScrollEventCallbackDelegate(IntPtr accessibilityManager, IntPtr touchEvent);
            private EventHandlerWithReturnType<object,ActionScrollEventArgs,bool> _accessibilityManagerActionScrollEventHandler;
            private ActionScrollEventCallbackDelegate _accessibilityManagerActionScrollEventCallbackDelegate;
        */

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FocusChangedEventCallbackDelegate(IntPtr view1, IntPtr view2);
        private EventHandler<FocusChangedEventArgs> accessibilityManagerFocusChangedEventHandler;
        private FocusChangedEventCallbackDelegate accessibilityManagerFocusChangedEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FocusedViewActivatedEventCallbackDelegate(IntPtr view);
        private EventHandler<FocusedViewActivatedEventArgs> accessibilityManagerFocusedViewActivatedEventHandler;
        private FocusedViewActivatedEventCallbackDelegate accessibilityManagerFocusedViewActivatedEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FocusOvershotEventCallbackDelegate(IntPtr currentFocusedView, AccessibilityManager.FocusOvershotDirection direction);
        private EventHandler<FocusOvershotEventArgs> accessibilityManagerFocusOvershotEventHandler;
        private FocusOvershotEventCallbackDelegate accessibilityManagerFocusOvershotEventCallbackDelegate;

        // Accessibility action signals

        /// <summary>
        /// This is emitted when accessibility(screen-reader) feature turned on or off.
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> StatusChanged
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerStatusChangedEventHandler == null)
                {
                    accessibilityManagerStatusChangedEventCallbackDelegate = new StatusChangedEventCallbackDelegate(OnStatusChanged);
                    this.StatusChangedSignal().Connect(accessibilityManagerStatusChangedEventCallbackDelegate);
                }

                accessibilityManagerStatusChangedEventHandler += value;
            }

            remove
            {
                accessibilityManagerStatusChangedEventHandler -= value;

                if (accessibilityManagerStatusChangedEventHandler == null && StatusChangedSignal().Empty() == false)
                {
                    this.StatusChangedSignal().Disconnect(accessibilityManagerStatusChangedEventCallbackDelegate);
                }

            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to move focus to the next focusable view (by one finger flick down).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionNext
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionNextEventHandler == null)
                {
                    accessibilityManagerActionNextEventCallbackDelegate = new ActionNextEventCallbackDelegate(OnActionNext);
                    this.ActionNextSignal().Connect(accessibilityManagerActionNextEventCallbackDelegate);
                }

                accessibilityManagerActionNextEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionNextEventHandler -= value;

                if (accessibilityManagerActionNextEventHandler == null && ActionNextSignal().Empty() == false)
                {
                    this.ActionNextSignal().Disconnect(accessibilityManagerActionNextEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to move focus to the previous focusable view (by one finger flick up).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionPrevious
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionPreviousEventHandler == null)
                {
                    accessibilityManagerActionPreviousEventCallbackDelegate = new ActionPreviousEventCallbackDelegate(OnActionPrevious);
                    this.ActionPreviousSignal().Connect(accessibilityManagerActionPreviousEventCallbackDelegate);
                }

                accessibilityManagerActionPreviousEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionPreviousEventHandler -= value;

                if (accessibilityManagerActionPreviousEventHandler == null && ActionPreviousSignal().Empty() == false)
                {
                    this.ActionPreviousSignal().Disconnect(accessibilityManagerActionPreviousEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to activate the current focused view (by one finger double tap).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionActivate
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionActivateEventHandler == null)
                {
                    accessibilityManagerActionActivateEventCallbackDelegate = new ActionActivateEventCallbackDelegate(OnActionActivate);
                    this.ActionActivateSignal().Connect(accessibilityManagerActionActivateEventCallbackDelegate);
                }

                accessibilityManagerActionActivateEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionActivateEventHandler -= value;

                if (accessibilityManagerActionActivateEventHandler == null && ActionActivateSignal().Empty() == false)
                {
                    this.ActionActivateSignal().Disconnect(accessibilityManagerActionActivateEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to focus and read the view (by one finger tap).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionRead
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionReadEventHandler == null)
                {
                    accessibilityManagerActionReadEventCallbackDelegate = new ActionReadEventCallbackDelegate(OnActionRead);
                    this.ActionReadSignal().Connect(accessibilityManagerActionReadEventCallbackDelegate);
                }

                accessibilityManagerActionReadEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionReadEventHandler -= value;

                if (accessibilityManagerActionReadEventHandler == null && ActionReadSignal().Empty() == false)
                {
                    this.ActionReadSignal().Disconnect(accessibilityManagerActionReadEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to focus and read the view  (by one finger move).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionOver
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionOverEventHandler == null)
                {
                    accessibilityManagerActionOverEventCallbackDelegate = new ActionOverEventCallbackDelegate(OnActionOver);
                    this.ActionOverSignal().Connect(accessibilityManagerActionOverEventCallbackDelegate);
                }

                accessibilityManagerActionOverEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionOverEventHandler -= value;

                if (accessibilityManagerActionOverEventHandler == null && ActionOverSignal().Empty() == false)
                {
                    this.ActionOverSignal().Disconnect(accessibilityManagerActionOverEventCallbackDelegate);
                }

            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to move focus to the next focusable view (by one finger flick right).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionReadNext
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionReadNextEventHandler == null)
                {
                    accessibilityManagerActionReadNextEventCallbackDelegate = new ActionReadNextEventCallbackDelegate(OnActionReadNext);
                    this.ActionReadNextSignal().Connect(accessibilityManagerActionReadNextEventCallbackDelegate);
                }

                accessibilityManagerActionReadNextEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionReadNextEventHandler -= value;

                if (accessibilityManagerActionReadNextEventHandler == null && ActionReadNextSignal().Empty() == false)
                {
                    this.ActionReadNextSignal().Disconnect(accessibilityManagerActionReadNextEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to move focus to the previous focusable view (by one finger flick left).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionReadPrevious
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionReadPreviousEventHandler == null)
                {
                    accessibilityManagerActionReadPreviousEventCallbackDelegate = new ActionReadPreviousEventCallbackDelegate(OnActionReadPrevious);
                    this.ActionReadPreviousSignal().Connect(accessibilityManagerActionReadPreviousEventCallbackDelegate);
                }

                accessibilityManagerActionReadPreviousEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionReadPreviousEventHandler -= value;

                if (accessibilityManagerActionReadPreviousEventHandler == null && ActionReadPreviousSignal().Empty() == false)
                {
                    this.ActionReadPreviousSignal().Disconnect(accessibilityManagerActionReadPreviousEventCallbackDelegate);
                }
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
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionUp
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionUpEventHandler == null)
                {
                    accessibilityManagerActionUpEventCallbackDelegate = new ActionUpEventCallbackDelegate(OnActionUp);
                    this.ActionUpSignal().Connect(accessibilityManagerActionUpEventCallbackDelegate);
                }

                accessibilityManagerActionUpEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionUpEventHandler -= value;

                if (accessibilityManagerActionUpEventHandler == null && ActionUpSignal().Empty() == false)
                {
                    this.ActionUpSignal().Disconnect(accessibilityManagerActionUpEventCallbackDelegate);
                }
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
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionDown
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionDownEventHandler == null)
                {
                    accessibilityManagerActionDownEventCallbackDelegate = new ActionDownEventCallbackDelegate(OnActionDown);
                    this.ActionDownSignal().Connect(accessibilityManagerActionDownEventCallbackDelegate);
                }

                accessibilityManagerActionDownEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionDownEventHandler -= value;

                if (accessibilityManagerActionDownEventHandler == null && ActionDownSignal().Empty() == false)
                {
                    this.ActionDownSignal().Disconnect(accessibilityManagerActionDownEventCallbackDelegate);
                }
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
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionClearFocus
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionClearFocusEventHandler == null)
                {
                    accessibilityManagerActionClearFocusEventCallbackDelegate = new ActionClearFocusEventCallbackDelegate(OnActionClearFocus);
                    this.ActionClearFocusSignal().Connect(accessibilityManagerActionClearFocusEventCallbackDelegate);
                }

                accessibilityManagerActionClearFocusEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionClearFocusEventHandler -= value;

                if (accessibilityManagerActionClearFocusEventHandler == null && ActionClearFocusSignal().Empty() == false)
                {
                    this.ActionClearFocusSignal().Disconnect(accessibilityManagerActionClearFocusEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to navigate back (by two fingers circle draw).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionBack
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionBackEventHandler == null)
                {
                    accessibilityManagerActionBackEventCallbackDelegate = new ActionBackEventCallbackDelegate(OnActionBack);
                    this.ActionBackSignal().Connect(accessibilityManagerActionBackEventCallbackDelegate);
                }

                accessibilityManagerActionBackEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionBackEventHandler -= value;

                if (accessibilityManagerActionBackEventHandler == null && ActionBackSignal().Empty() == false)
                {
                    this.ActionBackSignal().Disconnect(accessibilityManagerActionBackEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to scroll up the list (by two finger swipe up).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionScrollUp
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionScrollUpEventHandler == null)
                {
                    accessibilityManagerActionScrollUpEventCallbackDelegate = new ActionScrollUpEventCallbackDelegate(OnActionScrollUp);
                    this.ActionScrollUpSignal().Connect(accessibilityManagerActionScrollUpEventCallbackDelegate);
                }

                accessibilityManagerActionScrollUpEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionScrollUpEventHandler -= value;

                if (accessibilityManagerActionScrollUpEventHandler == null && ActionScrollUpSignal().Empty() == false)
                {
                    this.ActionScrollUpSignal().Disconnect(accessibilityManagerActionScrollUpEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to scroll down the list (by two finger swipe down).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionScrollDown
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionScrollDownEventHandler == null)
                {
                    accessibilityManagerActionScrollDownEventCallbackDelegate = new ActionScrollDownEventCallbackDelegate(OnActionScrollDown);
                    this.ActionScrollDownSignal().Connect(accessibilityManagerActionScrollDownEventCallbackDelegate);
                }

                accessibilityManagerActionScrollDownEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionScrollDownEventHandler -= value;

                if (accessibilityManagerActionScrollDownEventHandler == null && ActionScrollDownSignal().Empty() == false)
                {
                    this.ActionScrollDownSignal().Disconnect(accessibilityManagerActionScrollDownEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to scroll left to the previous page (by two finger swipe left).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionPageLeft
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionPageLeftEventHandler == null)
                {
                    accessibilityManagerActionPageLeftEventCallbackDelegate = new ActionPageLeftEventCallbackDelegate(OnActionPageLeft);
                    this.ActionPageLeftSignal().Connect(accessibilityManagerActionPageLeftEventCallbackDelegate);
                }

                accessibilityManagerActionPageLeftEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionPageLeftEventHandler -= value;

                if (accessibilityManagerActionPageLeftEventHandler == null && ActionPageLeftSignal().Empty() == false)
                {
                    this.ActionPageLeftSignal().Disconnect(accessibilityManagerActionPageLeftEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to scroll right to the next page (by two finger swipe right).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionPageRight
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionPageRightEventHandler == null)
                {
                    accessibilityManagerActionPageRightEventCallbackDelegate = new ActionPageRightEventCallbackDelegate(OnActionPageRight);
                    this.ActionPageRightSignal().Connect(accessibilityManagerActionPageRightEventCallbackDelegate);
                }

                accessibilityManagerActionPageRightEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionPageRightEventHandler -= value;

                if (accessibilityManagerActionPageRightEventHandler == null && ActionPageRightSignal().Empty() == false)
                {
                    this.ActionPageRightSignal().Disconnect(accessibilityManagerActionPageRightEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to scroll up to the previous page (by one finger swipe left and right).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionPageUp
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionPageUpEventHandler == null)
                {
                    accessibilityManagerActionPageUpEventCallbackDelegate = new ActionPageUpEventCallbackDelegate(OnActionPageUp);
                    this.ActionPageUpSignal().Connect(accessibilityManagerActionPageUpEventCallbackDelegate);
                }

                accessibilityManagerActionPageUpEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionPageUpEventHandler -= value;

                if (accessibilityManagerActionPageUpEventHandler == null && ActionPageUpSignal().Empty() == false)
                {
                    this.ActionPageUpSignal().Disconnect(accessibilityManagerActionPageUpEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to scroll down to the next page (by one finger swipe right and left).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionPageDown
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionPageDownEventHandler == null)
                {
                    accessibilityManagerActionPageDownEventCallbackDelegate = new ActionPageDownEventCallbackDelegate(OnActionPageDown);
                    this.ActionPageDownSignal().Connect(accessibilityManagerActionPageDownEventCallbackDelegate);
                }

                accessibilityManagerActionPageDownEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionPageDownEventHandler -= value;

                if (accessibilityManagerActionPageDownEventHandler == null && ActionPageDownSignal().Empty() == false)
                {
                    this.ActionPageDownSignal().Disconnect(accessibilityManagerActionPageDownEventCallbackDelegate);
                }
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
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionMoveToFirst
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionMoveToFirstEventHandler == null)
                {
                    accessibilityManagerActionMoveToFirstEventCallbackDelegate = new ActionMoveToFirstEventCallbackDelegate(OnActionMoveToFirst);
                    this.ActionMoveToFirstSignal().Connect(accessibilityManagerActionMoveToFirstEventCallbackDelegate);
                }

                accessibilityManagerActionMoveToFirstEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionMoveToFirstEventHandler -= value;

                if (accessibilityManagerActionMoveToFirstEventHandler == null && ActionMoveToFirstSignal().Empty() == false)
                {
                    this.ActionMoveToFirstSignal().Disconnect(accessibilityManagerActionMoveToFirstEventCallbackDelegate);
                }
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
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionMoveToLast
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionMoveToLastEventHandler == null)
                {
                    accessibilityManagerActionMoveToLastEventCallbackDelegate = new ActionMoveToLastEventCallbackDelegate(OnActionMoveToLast);
                    this.ActionMoveToLastSignal().Connect(accessibilityManagerActionMoveToLastEventCallbackDelegate);
                }

                accessibilityManagerActionMoveToLastEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionMoveToLastEventHandler -= value;

                if (accessibilityManagerActionMoveToLastEventHandler == null && ActionMoveToLastSignal().Empty() == false)
                {
                    this.ActionMoveToLastSignal().Disconnect(accessibilityManagerActionMoveToLastEventCallbackDelegate);
                }
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
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionReadFromTop
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionReadFromTopEventHandler == null)
                {
                    accessibilityManagerActionReadFromTopEventCallbackDelegate = new ActionReadFromTopEventCallbackDelegate(OnActionReadFromTop);
                    this.ActionReadFromTopSignal().Connect(accessibilityManagerActionReadFromTopEventCallbackDelegate);
                }

                accessibilityManagerActionReadFromTopEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionReadFromTopEventHandler -= value;

                if (accessibilityManagerActionReadFromTopEventHandler == null && ActionReadFromTopSignal().Empty() == false)
                {
                    this.ActionReadFromTopSignal().Disconnect(accessibilityManagerActionReadFromTopEventCallbackDelegate);
                }
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
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionReadFromNext
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionReadFromNextEventHandler == null)
                {
                    accessibilityManagerActionReadFromNextEventCallbackDelegate = new ActionReadFromNextEventCallbackDelegate(OnActionReadFromNext);
                    this.ActionReadFromNextSignal().Connect(accessibilityManagerActionReadFromNextEventCallbackDelegate);
                }

                accessibilityManagerActionReadFromNextEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionReadFromNextEventHandler -= value;

                if (accessibilityManagerActionReadFromNextEventHandler == null && ActionReadFromNextSignal().Empty() == false)
                {
                    this.ActionReadFromNextSignal().Disconnect(accessibilityManagerActionReadFromNextEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to zoom (by one finger triple tap)
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionZoom
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionZoomEventHandler == null)
                {
                    accessibilityManagerActionZoomEventCallbackDelegate = new ActionZoomEventCallbackDelegate(OnActionZoom);
                    this.ActionZoomSignal().Connect(accessibilityManagerActionZoomEventCallbackDelegate);
                }

                accessibilityManagerActionZoomEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionZoomEventHandler -= value;

                if (accessibilityManagerActionZoomEventHandler == null && ActionZoomSignal().Empty() == false)
                {
                    this.ActionZoomSignal().Disconnect(accessibilityManagerActionZoomEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to pause/resume the current speech (by two fingers single tap).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionReadPauseResume
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionReadPauseResumeEventHandler == null)
                {
                    accessibilityManagerActionReadPauseResumeEventCallbackDelegate = new ActionReadPauseResumeEventCallbackDelegate(OnActionReadPauseResume);
                    this.ActionReadPauseResumeSignal().Connect(accessibilityManagerActionReadPauseResumeEventCallbackDelegate);
                }

                accessibilityManagerActionReadPauseResumeEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionReadPauseResumeEventHandler -= value;

                if (accessibilityManagerActionReadPauseResumeEventHandler == null && ActionReadPauseResumeSignal().Empty() == false)
                {
                    this.ActionReadPauseResumeSignal().Disconnect(accessibilityManagerActionReadPauseResumeEventCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This is emitted when accessibility action is received to start/stop the current action (by two fingers double tap).
        /// </summary>
        /// <returns> The signal to connect to </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, EventArgs, bool> ActionStartStop
        {
            add
            {
                // Restricted to only one listener
                if (accessibilityManagerActionStartStopEventHandler == null)
                {
                    accessibilityManagerActionStartStopEventCallbackDelegate = new ActionStartStopEventCallbackDelegate(OnActionStartStop);
                    this.ActionStartStopSignal().Connect(accessibilityManagerActionStartStopEventCallbackDelegate);
                }

                accessibilityManagerActionStartStopEventHandler += value;
            }

            remove
            {
                accessibilityManagerActionStartStopEventHandler -= value;

                if (accessibilityManagerActionStartStopEventHandler == null && ActionStartStopSignal().Empty() == false)
                {
                    this.ActionStartStopSignal().Disconnect(accessibilityManagerActionStartStopEventCallbackDelegate);
                }
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
                if (accessibilityManagerFocusChangedEventHandler == null)
                {
                    accessibilityManagerFocusChangedEventCallbackDelegate = new FocusChangedEventCallbackDelegate(OnFocusChanged);
                    this.FocusChangedSignal().Connect(accessibilityManagerFocusChangedEventCallbackDelegate);
                }

                accessibilityManagerFocusChangedEventHandler += value;
            }

            remove
            {
                accessibilityManagerFocusChangedEventHandler -= value;

                if (accessibilityManagerFocusChangedEventHandler == null && FocusChangedSignal().Empty() == false)
                {
                    this.FocusChangedSignal().Disconnect(accessibilityManagerFocusChangedEventCallbackDelegate);
                }
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
                if (accessibilityManagerFocusedViewActivatedEventHandler == null)
                {
                    accessibilityManagerFocusedViewActivatedEventCallbackDelegate = new FocusedViewActivatedEventCallbackDelegate(OnFocusedViewActivated);
                    this.FocusedViewActivatedSignal().Connect(accessibilityManagerFocusedViewActivatedEventCallbackDelegate);
                }

                accessibilityManagerFocusedViewActivatedEventHandler += value;
            }

            remove
            {
                accessibilityManagerFocusedViewActivatedEventHandler -= value;

                if (accessibilityManagerFocusedViewActivatedEventHandler == null && FocusedViewActivatedSignal().Empty() == false)
                {
                    this.FocusedViewActivatedSignal().Disconnect(accessibilityManagerFocusedViewActivatedEventCallbackDelegate);
                }
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
                if (accessibilityManagerFocusOvershotEventHandler == null)
                {
                    accessibilityManagerFocusOvershotEventCallbackDelegate = new FocusOvershotEventCallbackDelegate(OnFocusOvershot);
                    this.FocusOvershotSignal().Connect(accessibilityManagerFocusOvershotEventCallbackDelegate);
                }

                accessibilityManagerFocusOvershotEventHandler += value;
            }

            remove
            {
                accessibilityManagerFocusOvershotEventHandler -= value;

                if (accessibilityManagerFocusOvershotEventHandler == null && FocusOvershotSignal().Empty() == false)
                {
                    this.FocusOvershotSignal().Disconnect(accessibilityManagerFocusOvershotEventCallbackDelegate);
                }
            }
        }
    }
}
