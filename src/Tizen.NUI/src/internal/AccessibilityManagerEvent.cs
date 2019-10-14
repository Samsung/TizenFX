/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    internal partial class AccessibilityManager
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool StatusChangedEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, StatusChangedEventArgs, bool> _accessibilityManagerStatusChangedEventHandler;
        private StatusChangedEventCallbackDelegate _accessibilityManagerStatusChangedEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionNextEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionNextEventArgs, bool> _accessibilityManagerActionNextEventHandler;
        private ActionNextEventCallbackDelegate _accessibilityManagerActionNextEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPreviousEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionPreviousEventArgs, bool> _accessibilityManagerActionPreviousEventHandler;
        private ActionPreviousEventCallbackDelegate _accessibilityManagerActionPreviousEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionActivateEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionActivateEventArgs, bool> _accessibilityManagerActionActivateEventHandler;
        private ActionActivateEventCallbackDelegate _accessibilityManagerActionActivateEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionReadEventArgs, bool> _accessibilityManagerActionReadEventHandler;
        private ActionReadEventCallbackDelegate _accessibilityManagerActionReadEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionOverEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionOverEventArgs, bool> _accessibilityManagerActionOverEventHandler;
        private ActionOverEventCallbackDelegate _accessibilityManagerActionOverEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadNextEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionReadNextEventArgs, bool> _accessibilityManagerActionReadNextEventHandler;
        private ActionReadNextEventCallbackDelegate _accessibilityManagerActionReadNextEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadPreviousEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionReadPreviousEventArgs, bool> _accessibilityManagerActionReadPreviousEventHandler;
        private ActionReadPreviousEventCallbackDelegate _accessibilityManagerActionReadPreviousEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionUpEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionUpEventArgs, bool> _accessibilityManagerActionUpEventHandler;
        private ActionUpEventCallbackDelegate _accessibilityManagerActionUpEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionDownEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionDownEventArgs, bool> _accessibilityManagerActionDownEventHandler;
        private ActionDownEventCallbackDelegate _accessibilityManagerActionDownEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionClearFocusEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionClearFocusEventArgs, bool> _accessibilityManagerActionClearFocusEventHandler;
        private ActionClearFocusEventCallbackDelegate _accessibilityManagerActionClearFocusEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionBackEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionBackEventArgs, bool> _accessibilityManagerActionBackEventHandler;
        private ActionBackEventCallbackDelegate _accessibilityManagerActionBackEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionScrollUpEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionScrollUpEventArgs, bool> _accessibilityManagerActionScrollUpEventHandler;
        private ActionScrollUpEventCallbackDelegate _accessibilityManagerActionScrollUpEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionScrollDownEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionScrollDownEventArgs, bool> _accessibilityManagerActionScrollDownEventHandler;
        private ActionScrollDownEventCallbackDelegate _accessibilityManagerActionScrollDownEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPageLeftEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionPageLeftEventArgs, bool> _accessibilityManagerActionPageLeftEventHandler;
        private ActionPageLeftEventCallbackDelegate _accessibilityManagerActionPageLeftEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPageRightEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionPageRightEventArgs, bool> _accessibilityManagerActionPageRightEventHandler;
        private ActionPageRightEventCallbackDelegate _accessibilityManagerActionPageRightEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPageUpEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionPageUpEventArgs, bool> _accessibilityManagerActionPageUpEventHandler;
        private ActionPageUpEventCallbackDelegate _accessibilityManagerActionPageUpEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionPageDownEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionPageDownEventArgs, bool> _accessibilityManagerActionPageDownEventHandler;
        private ActionPageDownEventCallbackDelegate _accessibilityManagerActionPageDownEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionMoveToFirstEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionMoveToFirstEventArgs, bool> _accessibilityManagerActionMoveToFirstEventHandler;
        private ActionMoveToFirstEventCallbackDelegate _accessibilityManagerActionMoveToFirstEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionMoveToLastEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionMoveToLastEventArgs, bool> _accessibilityManagerActionMoveToLastEventHandler;
        private ActionMoveToLastEventCallbackDelegate _accessibilityManagerActionMoveToLastEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadFromTopEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionReadFromTopEventArgs, bool> _accessibilityManagerActionReadFromTopEventHandler;
        private ActionReadFromTopEventCallbackDelegate _accessibilityManagerActionReadFromTopEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadFromNextEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionReadFromNextEventArgs, bool> _accessibilityManagerActionReadFromNextEventHandler;
        private ActionReadFromNextEventCallbackDelegate _accessibilityManagerActionReadFromNextEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionZoomEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionZoomEventArgs, bool> _accessibilityManagerActionZoomEventHandler;
        private ActionZoomEventCallbackDelegate _accessibilityManagerActionZoomEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadIndicatorInformationEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionReadIndicatorInformationEventArgs, bool> _accessibilityManagerActionReadIndicatorInformationEventHandler;
        private ActionReadIndicatorInformationEventCallbackDelegate _accessibilityManagerActionReadIndicatorInformationEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionReadPauseResumeEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionReadPauseResumeEventArgs, bool> _accessibilityManagerActionReadPauseResumeEventHandler;
        private ActionReadPauseResumeEventCallbackDelegate _accessibilityManagerActionReadPauseResumeEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ActionStartStopEventCallbackDelegate(IntPtr accessibilityManager);
        private DaliEventHandlerWithReturnType<object, ActionStartStopEventArgs, bool> _accessibilityManagerActionStartStopEventHandler;
        private ActionStartStopEventCallbackDelegate _accessibilityManagerActionStartStopEventCallbackDelegate;

        /*
            // To be replaced by a new event that takes Touch
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate bool ActionScrollEventCallbackDelegate(IntPtr accessibilityManager, IntPtr touchEvent);
            private DaliEventHandlerWithReturnType<object,ActionScrollEventArgs,bool> _accessibilityManagerActionScrollEventHandler;
            private ActionScrollEventCallbackDelegate _accessibilityManagerActionScrollEventCallbackDelegate;
        */

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FocusChangedEventCallbackDelegate(IntPtr view1, IntPtr view2);
        private DaliEventHandler<object, FocusChangedEventArgs> _accessibilityManagerFocusChangedEventHandler;
        private FocusChangedEventCallbackDelegate _accessibilityManagerFocusChangedEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FocusedViewActivatedEventCallbackDelegate(IntPtr view);
        private DaliEventHandler<object, FocusedViewActivatedEventArgs> _accessibilityManagerFocusedViewActivatedEventHandler;
        private FocusedViewActivatedEventCallbackDelegate _accessibilityManagerFocusedViewActivatedEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FocusOvershotEventCallbackDelegate(IntPtr currentFocusedView, AccessibilityManager.FocusOvershotDirection direction);
        private DaliEventHandler<object, FocusOvershotEventArgs> _accessibilityManagerFocusOvershotEventHandler;
        private FocusOvershotEventCallbackDelegate _accessibilityManagerFocusOvershotEventCallbackDelegate;

        public event DaliEventHandlerWithReturnType<object, StatusChangedEventArgs, bool> StatusChanged
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerStatusChangedEventHandler == null)
                    {
                        _accessibilityManagerStatusChangedEventHandler += value;

                        _accessibilityManagerStatusChangedEventCallbackDelegate = new StatusChangedEventCallbackDelegate(OnStatusChanged);
                        this.StatusChangedSignal().Connect(_accessibilityManagerStatusChangedEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerStatusChangedEventHandler != null)
                    {
                        this.StatusChangedSignal().Disconnect(_accessibilityManagerStatusChangedEventCallbackDelegate);
                    }

                    _accessibilityManagerStatusChangedEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionNextEventArgs, bool> ActionNext
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionNextEventHandler == null)
                    {
                        _accessibilityManagerActionNextEventHandler += value;

                        _accessibilityManagerActionNextEventCallbackDelegate = new ActionNextEventCallbackDelegate(OnActionNext);
                        this.ActionNextSignal().Connect(_accessibilityManagerActionNextEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionNextEventHandler != null)
                    {
                        this.ActionNextSignal().Disconnect(_accessibilityManagerActionNextEventCallbackDelegate);
                    }

                    _accessibilityManagerActionNextEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionPreviousEventArgs, bool> ActionPrevious
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionPreviousEventHandler == null)
                    {
                        _accessibilityManagerActionPreviousEventHandler += value;

                        _accessibilityManagerActionPreviousEventCallbackDelegate = new ActionPreviousEventCallbackDelegate(OnActionPrevious);
                        this.ActionPreviousSignal().Connect(_accessibilityManagerActionPreviousEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionPreviousEventHandler != null)
                    {
                        this.ActionPreviousSignal().Disconnect(_accessibilityManagerActionPreviousEventCallbackDelegate);
                    }

                    _accessibilityManagerActionPreviousEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionActivateEventArgs, bool> ActionActivate
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionActivateEventHandler == null)
                    {
                        _accessibilityManagerActionActivateEventHandler += value;

                        _accessibilityManagerActionActivateEventCallbackDelegate = new ActionActivateEventCallbackDelegate(OnActionActivate);
                        this.ActionActivateSignal().Connect(_accessibilityManagerActionActivateEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionActivateEventHandler != null)
                    {
                        this.ActionActivateSignal().Disconnect(_accessibilityManagerActionActivateEventCallbackDelegate);
                    }

                    _accessibilityManagerActionActivateEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionReadEventArgs, bool> ActionRead
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionReadEventHandler == null)
                    {
                        _accessibilityManagerActionReadEventHandler += value;

                        _accessibilityManagerActionReadEventCallbackDelegate = new ActionReadEventCallbackDelegate(OnActionRead);
                        this.ActionReadSignal().Connect(_accessibilityManagerActionReadEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionReadEventHandler != null)
                    {
                        this.ActionReadSignal().Disconnect(_accessibilityManagerActionReadEventCallbackDelegate);
                    }

                    _accessibilityManagerActionReadEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionOverEventArgs, bool> ActionOver
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionOverEventHandler == null)
                    {
                        _accessibilityManagerActionOverEventHandler += value;

                        _accessibilityManagerActionOverEventCallbackDelegate = new ActionOverEventCallbackDelegate(OnActionOver);
                        this.ActionOverSignal().Connect(_accessibilityManagerActionOverEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionOverEventHandler != null)
                    {
                        this.ActionOverSignal().Disconnect(_accessibilityManagerActionOverEventCallbackDelegate);
                    }

                    _accessibilityManagerActionOverEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionReadNextEventArgs, bool> ActionReadNext
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionReadNextEventHandler == null)
                    {
                        _accessibilityManagerActionReadNextEventHandler += value;

                        _accessibilityManagerActionReadNextEventCallbackDelegate = new ActionReadNextEventCallbackDelegate(OnActionReadNext);
                        this.ActionReadNextSignal().Connect(_accessibilityManagerActionReadNextEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionReadNextEventHandler != null)
                    {
                        this.ActionReadNextSignal().Disconnect(_accessibilityManagerActionReadNextEventCallbackDelegate);
                    }

                    _accessibilityManagerActionReadNextEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionReadPreviousEventArgs, bool> ActionReadPrevious
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionReadPreviousEventHandler == null)
                    {
                        _accessibilityManagerActionReadPreviousEventHandler += value;

                        _accessibilityManagerActionReadPreviousEventCallbackDelegate = new ActionReadPreviousEventCallbackDelegate(OnActionReadPrevious);
                        this.ActionReadPreviousSignal().Connect(_accessibilityManagerActionReadPreviousEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionReadPreviousEventHandler != null)
                    {
                        this.ActionReadPreviousSignal().Disconnect(_accessibilityManagerActionReadPreviousEventCallbackDelegate);
                    }

                    _accessibilityManagerActionReadPreviousEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionUpEventArgs, bool> ActionUp
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionUpEventHandler == null)
                    {
                        _accessibilityManagerActionUpEventHandler += value;

                        _accessibilityManagerActionUpEventCallbackDelegate = new ActionUpEventCallbackDelegate(OnActionUp);
                        this.ActionUpSignal().Connect(_accessibilityManagerActionUpEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionUpEventHandler != null)
                    {
                        this.ActionUpSignal().Disconnect(_accessibilityManagerActionUpEventCallbackDelegate);
                    }

                    _accessibilityManagerActionUpEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionDownEventArgs, bool> ActionDown
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionDownEventHandler == null)
                    {
                        _accessibilityManagerActionDownEventHandler += value;

                        _accessibilityManagerActionDownEventCallbackDelegate = new ActionDownEventCallbackDelegate(OnActionDown);
                        this.ActionDownSignal().Connect(_accessibilityManagerActionDownEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionDownEventHandler != null)
                    {
                        this.ActionDownSignal().Disconnect(_accessibilityManagerActionDownEventCallbackDelegate);
                    }

                    _accessibilityManagerActionDownEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionClearFocusEventArgs, bool> ActionClearFocus
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionClearFocusEventHandler == null)
                    {
                        _accessibilityManagerActionClearFocusEventHandler += value;

                        _accessibilityManagerActionClearFocusEventCallbackDelegate = new ActionClearFocusEventCallbackDelegate(OnActionClearFocus);
                        this.ActionClearFocusSignal().Connect(_accessibilityManagerActionClearFocusEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionClearFocusEventHandler != null)
                    {
                        this.ActionClearFocusSignal().Disconnect(_accessibilityManagerActionClearFocusEventCallbackDelegate);
                    }

                    _accessibilityManagerActionClearFocusEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionBackEventArgs, bool> ActionBack
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionBackEventHandler == null)
                    {
                        _accessibilityManagerActionBackEventHandler += value;

                        _accessibilityManagerActionBackEventCallbackDelegate = new ActionBackEventCallbackDelegate(OnActionBack);
                        this.ActionBackSignal().Connect(_accessibilityManagerActionBackEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionBackEventHandler != null)
                    {
                        this.ActionBackSignal().Disconnect(_accessibilityManagerActionBackEventCallbackDelegate);
                    }

                    _accessibilityManagerActionBackEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionScrollUpEventArgs, bool> ActionScrollUp
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionScrollUpEventHandler == null)
                    {
                        _accessibilityManagerActionScrollUpEventHandler += value;

                        _accessibilityManagerActionScrollUpEventCallbackDelegate = new ActionScrollUpEventCallbackDelegate(OnActionScrollUp);
                        this.ActionScrollUpSignal().Connect(_accessibilityManagerActionScrollUpEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionScrollUpEventHandler != null)
                    {
                        this.ActionScrollUpSignal().Disconnect(_accessibilityManagerActionScrollUpEventCallbackDelegate);
                    }

                    _accessibilityManagerActionScrollUpEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionScrollDownEventArgs, bool> ActionScrollDown
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionScrollDownEventHandler == null)
                    {
                        _accessibilityManagerActionScrollDownEventHandler += value;

                        _accessibilityManagerActionScrollDownEventCallbackDelegate = new ActionScrollDownEventCallbackDelegate(OnActionScrollDown);
                        this.ActionScrollDownSignal().Connect(_accessibilityManagerActionScrollDownEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionScrollDownEventHandler != null)
                    {
                        this.ActionScrollDownSignal().Disconnect(_accessibilityManagerActionScrollDownEventCallbackDelegate);
                    }

                    _accessibilityManagerActionScrollDownEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionPageLeftEventArgs, bool> ActionPageLeft
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionPageLeftEventHandler == null)
                    {
                        _accessibilityManagerActionPageLeftEventHandler += value;

                        _accessibilityManagerActionPageLeftEventCallbackDelegate = new ActionPageLeftEventCallbackDelegate(OnActionPageLeft);
                        this.ActionPageLeftSignal().Connect(_accessibilityManagerActionPageLeftEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionPageLeftEventHandler != null)
                    {
                        this.ActionPageLeftSignal().Disconnect(_accessibilityManagerActionPageLeftEventCallbackDelegate);
                    }

                    _accessibilityManagerActionPageLeftEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionPageRightEventArgs, bool> ActionPageRight
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionPageRightEventHandler == null)
                    {
                        _accessibilityManagerActionPageRightEventHandler += value;

                        _accessibilityManagerActionPageRightEventCallbackDelegate = new ActionPageRightEventCallbackDelegate(OnActionPageRight);
                        this.ActionPageRightSignal().Connect(_accessibilityManagerActionPageRightEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionPageRightEventHandler != null)
                    {
                        this.ActionPageRightSignal().Disconnect(_accessibilityManagerActionPageRightEventCallbackDelegate);
                    }

                    _accessibilityManagerActionPageRightEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionPageUpEventArgs, bool> ActionPageUp
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionPageUpEventHandler == null)
                    {
                        _accessibilityManagerActionPageUpEventHandler += value;

                        _accessibilityManagerActionPageUpEventCallbackDelegate = new ActionPageUpEventCallbackDelegate(OnActionPageUp);
                        this.ActionPageUpSignal().Connect(_accessibilityManagerActionPageUpEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionPageUpEventHandler != null)
                    {
                        this.ActionPageUpSignal().Disconnect(_accessibilityManagerActionPageUpEventCallbackDelegate);
                    }

                    _accessibilityManagerActionPageUpEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionPageDownEventArgs, bool> ActionPageDown
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionPageDownEventHandler == null)
                    {
                        _accessibilityManagerActionPageDownEventHandler += value;

                        _accessibilityManagerActionPageDownEventCallbackDelegate = new ActionPageDownEventCallbackDelegate(OnActionPageDown);
                        this.ActionPageDownSignal().Connect(_accessibilityManagerActionPageDownEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionPageDownEventHandler != null)
                    {
                        this.ActionPageDownSignal().Disconnect(_accessibilityManagerActionPageDownEventCallbackDelegate);
                    }

                    _accessibilityManagerActionPageDownEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionMoveToFirstEventArgs, bool> ActionMoveToFirst
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionMoveToFirstEventHandler == null)
                    {
                        _accessibilityManagerActionMoveToFirstEventHandler += value;

                        _accessibilityManagerActionMoveToFirstEventCallbackDelegate = new ActionMoveToFirstEventCallbackDelegate(OnActionMoveToFirst);
                        this.ActionMoveToFirstSignal().Connect(_accessibilityManagerActionMoveToFirstEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionMoveToFirstEventHandler != null)
                    {
                        this.ActionMoveToFirstSignal().Disconnect(_accessibilityManagerActionMoveToFirstEventCallbackDelegate);
                    }

                    _accessibilityManagerActionMoveToFirstEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionMoveToLastEventArgs, bool> ActionMoveToLast
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionMoveToLastEventHandler == null)
                    {
                        _accessibilityManagerActionMoveToLastEventHandler += value;

                        _accessibilityManagerActionMoveToLastEventCallbackDelegate = new ActionMoveToLastEventCallbackDelegate(OnActionMoveToLast);
                        this.ActionMoveToLastSignal().Connect(_accessibilityManagerActionMoveToLastEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionMoveToLastEventHandler != null)
                    {
                        this.ActionMoveToLastSignal().Disconnect(_accessibilityManagerActionMoveToLastEventCallbackDelegate);
                    }

                    _accessibilityManagerActionMoveToLastEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionReadFromTopEventArgs, bool> ActionReadFromTop
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionReadFromTopEventHandler == null)
                    {
                        _accessibilityManagerActionReadFromTopEventHandler += value;

                        _accessibilityManagerActionReadFromTopEventCallbackDelegate = new ActionReadFromTopEventCallbackDelegate(OnActionReadFromTop);
                        this.ActionReadFromTopSignal().Connect(_accessibilityManagerActionReadFromTopEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionReadFromTopEventHandler != null)
                    {
                        this.ActionReadFromTopSignal().Disconnect(_accessibilityManagerActionReadFromTopEventCallbackDelegate);
                    }

                    _accessibilityManagerActionReadFromTopEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionReadFromNextEventArgs, bool> ActionReadFromNext
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionReadFromNextEventHandler == null)
                    {
                        _accessibilityManagerActionReadFromNextEventHandler += value;

                        _accessibilityManagerActionReadFromNextEventCallbackDelegate = new ActionReadFromNextEventCallbackDelegate(OnActionReadFromNext);
                        this.ActionReadFromNextSignal().Connect(_accessibilityManagerActionReadFromNextEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionReadFromNextEventHandler != null)
                    {
                        this.ActionReadFromNextSignal().Disconnect(_accessibilityManagerActionReadFromNextEventCallbackDelegate);
                    }

                    _accessibilityManagerActionReadFromNextEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionZoomEventArgs, bool> ActionZoom
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionZoomEventHandler == null)
                    {
                        _accessibilityManagerActionZoomEventHandler += value;

                        _accessibilityManagerActionZoomEventCallbackDelegate = new ActionZoomEventCallbackDelegate(OnActionZoom);
                        this.ActionZoomSignal().Connect(_accessibilityManagerActionZoomEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionZoomEventHandler != null)
                    {
                        this.ActionZoomSignal().Disconnect(_accessibilityManagerActionZoomEventCallbackDelegate);
                    }

                    _accessibilityManagerActionZoomEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionReadIndicatorInformationEventArgs, bool> ActionReadIndicatorInformation
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionReadIndicatorInformationEventHandler == null)
                    {
                        _accessibilityManagerActionReadIndicatorInformationEventHandler += value;

                        _accessibilityManagerActionReadIndicatorInformationEventCallbackDelegate = new ActionReadIndicatorInformationEventCallbackDelegate(OnActionReadIndicatorInformation);
                        this.ActionReadIndicatorInformationSignal().Connect(_accessibilityManagerActionReadIndicatorInformationEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionReadIndicatorInformationEventHandler != null)
                    {
                        this.ActionReadIndicatorInformationSignal().Disconnect(_accessibilityManagerActionReadIndicatorInformationEventCallbackDelegate);
                    }

                    _accessibilityManagerActionReadIndicatorInformationEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionReadPauseResumeEventArgs, bool> ActionReadPauseResume
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionReadPauseResumeEventHandler == null)
                    {
                        _accessibilityManagerActionReadPauseResumeEventHandler += value;

                        _accessibilityManagerActionReadPauseResumeEventCallbackDelegate = new ActionReadPauseResumeEventCallbackDelegate(OnActionReadPauseResume);
                        this.ActionReadPauseResumeSignal().Connect(_accessibilityManagerActionReadPauseResumeEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionReadPauseResumeEventHandler != null)
                    {
                        this.ActionReadPauseResumeSignal().Disconnect(_accessibilityManagerActionReadPauseResumeEventCallbackDelegate);
                    }

                    _accessibilityManagerActionReadPauseResumeEventHandler -= value;
                }
            }
        }

        public event DaliEventHandlerWithReturnType<object, ActionStartStopEventArgs, bool> ActionStartStop
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerActionStartStopEventHandler == null)
                    {
                        _accessibilityManagerActionStartStopEventHandler += value;

                        _accessibilityManagerActionStartStopEventCallbackDelegate = new ActionStartStopEventCallbackDelegate(OnActionStartStop);
                        this.ActionStartStopSignal().Connect(_accessibilityManagerActionStartStopEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerActionStartStopEventHandler != null)
                    {
                        this.ActionStartStopSignal().Disconnect(_accessibilityManagerActionStartStopEventCallbackDelegate);
                    }

                    _accessibilityManagerActionStartStopEventHandler -= value;
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

        public event DaliEventHandler<object, FocusChangedEventArgs> FocusChanged
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerFocusChangedEventHandler == null)
                    {
                        _accessibilityManagerFocusChangedEventHandler += value;

                        _accessibilityManagerFocusChangedEventCallbackDelegate = new FocusChangedEventCallbackDelegate(OnFocusChanged);
                        this.FocusChangedSignal().Connect(_accessibilityManagerFocusChangedEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerFocusChangedEventHandler != null)
                    {
                        this.FocusChangedSignal().Disconnect(_accessibilityManagerFocusChangedEventCallbackDelegate);
                    }

                    _accessibilityManagerFocusChangedEventHandler -= value;
                }
            }
        }

        public event DaliEventHandler<object, FocusedViewActivatedEventArgs> FocusedViewActivated
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerFocusedViewActivatedEventHandler == null)
                    {
                        _accessibilityManagerFocusedViewActivatedEventHandler += value;

                        _accessibilityManagerFocusedViewActivatedEventCallbackDelegate = new FocusedViewActivatedEventCallbackDelegate(OnFocusedViewActivated);
                        this.FocusedViewActivatedSignal().Connect(_accessibilityManagerFocusedViewActivatedEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_accessibilityManagerFocusedViewActivatedEventHandler != null)
                    {
                        this.FocusedViewActivatedSignal().Disconnect(_accessibilityManagerFocusedViewActivatedEventCallbackDelegate);
                    }

                    _accessibilityManagerFocusedViewActivatedEventHandler -= value;
                }
            }
        }

        public event DaliEventHandler<object, FocusOvershotEventArgs> FocusOvershot
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_accessibilityManagerFocusOvershotEventHandler == null)
                    {
                        _accessibilityManagerFocusOvershotEventHandler += value;

                        _accessibilityManagerFocusOvershotEventCallbackDelegate = new FocusOvershotEventCallbackDelegate(OnFocusOvershot);
                        this.FocusOvershotSignal().Connect(_accessibilityManagerFocusOvershotEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
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
}
