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

namespace Tizen.NUI
{

    using System;
    using System.Runtime.InteropServices;
    using Tizen.NUI.BaseComponents;

    internal class AccessibilityManager : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal AccessibilityManager(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.AccessibilityManage.AccessibilityManager_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AccessibilityManager obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.AccessibilityManage.delete_AccessibilityManager(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /**
            * @brief Event arguments that passed via StatusChanged signal
            *
        */
        /// <since_tizen> 3 </since_tizen>
        public class StatusChangedEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionNext signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionNextEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionPrevious signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionPreviousEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionActivate signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionActivateEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionRead signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionReadEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionOver signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionOverEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionReadNext signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionReadNextEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionReadPrevious signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionReadPreviousEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionUp signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionUpEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionDown signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionDownEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionClearFocus signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionClearFocusEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionBack signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionBackEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionScrollUp signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionScrollUpEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionScrollDown signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionScrollDownEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionPageLeft signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionPageLeftEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionPageRight signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionPageRightEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionPageUp signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionPageUpEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionPageDown signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionPageDownEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionMoveToFirst signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionMoveToFirstEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionMoveToLast signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionMoveToLastEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionReadFromTop signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionReadFromTopEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionReadFromNext signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionReadFromNextEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionZoom signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionZoomEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionReadIndicatorInformation signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionReadIndicatorInformationEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionReadPauseResume signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionReadPauseResumeEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via ActionStartStop signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class ActionStartStopEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager AccessibilityManager
            {
                get
                {
                    return _accessibilityManager;
                }
                set
                {
                    _accessibilityManager = value;
                }
            }
        }

        /*
            // To be replaced by a new event that takes Touch
            public class ActionScrollEventArgs : EventArgs
            {
              private AccessibilityManager _accessibilityManager;
              private TouchEvent _touchEvent;

              public AccessibilityManager AccessibilityManager
              {
                get
                {
                  return _accessibilityManager;
                }
                set
                {
                  _accessibilityManager = value;
                }
              }

              public TouchEvent TouchEvent
              {
                get
                {
                  return _touchEvent;
                }
                set
                {
                  _touchEvent = value;
                }
              }
            }
        */

        /**
          * @brief Event arguments that passed via ActionPageUp signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class FocusChangedEventArgs : EventArgs
        {
            private View _viewCurrent;
            private View _viewNext;

            /// <since_tizen> 3 </since_tizen>
            public View ViewCurrent
            {
                get
                {
                    return _viewCurrent;
                }
                set
                {
                    _viewCurrent = value;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public View ViewNext
            {
                get
                {
                    return _viewNext;
                }
                set
                {
                    _viewNext = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via FocusedViewActivated signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class FocusedViewActivatedEventArgs : EventArgs
        {
            private View _view;


            /// <since_tizen> 3 </since_tizen>
            public View View
            {
                get
                {
                    return _view;
                }
                set
                {
                    _view = value;
                }
            }
        }

        /**
          * @brief Event arguments that passed via FocusOvershot signal
          *
          */
        /// <since_tizen> 3 </since_tizen>
        public class FocusOvershotEventArgs : EventArgs
        {
            private View _currentFocusedView;
            private AccessibilityManager.FocusOvershotDirection _focusOvershotDirection;

            /// <since_tizen> 3 </since_tizen>
            public View CurrentFocusedView
            {
                get
                {
                    return _currentFocusedView;
                }
                set
                {
                    _currentFocusedView = value;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public AccessibilityManager.FocusOvershotDirection FocusOvershotDirection
            {
                get
                {
                    return _focusOvershotDirection;
                }
                set
                {
                    _focusOvershotDirection = value;
                }
            }
        }


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

        // Callback for AccessibilityManager StatusChangedSignal
        private bool OnStatusChanged(IntPtr data)
        {
            StatusChangedEventArgs e = new StatusChangedEventArgs();

            // Populate all members of "e" (StatusChangedEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerStatusChangedEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerStatusChangedEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionNextSignal
        private bool OnActionNext(IntPtr data)
        {
            ActionNextEventArgs e = new ActionNextEventArgs();

            // Populate all members of "e" (ActionNextEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionNextEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionNextEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionPreviousSignal
        private bool OnActionPrevious(IntPtr data)
        {
            ActionPreviousEventArgs e = new ActionPreviousEventArgs();

            // Populate all members of "e" (ActionPreviousEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionPreviousEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPreviousEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionActivateSignal
        private bool OnActionActivate(IntPtr data)
        {
            ActionActivateEventArgs e = new ActionActivateEventArgs();

            // Populate all members of "e" (ActionActivateEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionActivateEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionActivateEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionReadSignal
        private bool OnActionRead(IntPtr data)
        {
            ActionReadEventArgs e = new ActionReadEventArgs();

            // Populate all members of "e" (ActionReadEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionReadEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionOverSignal
        private bool OnActionOver(IntPtr data)
        {
            ActionOverEventArgs e = new ActionOverEventArgs();

            // Populate all members of "e" (ActionOverEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionOverEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionOverEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionReadNextSignal
        private bool OnActionReadNext(IntPtr data)
        {
            ActionReadNextEventArgs e = new ActionReadNextEventArgs();

            // Populate all members of "e" (ActionReadNextEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionReadNextEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadNextEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionReadPreviousSignal
        private bool OnActionReadPrevious(IntPtr data)
        {
            ActionReadPreviousEventArgs e = new ActionReadPreviousEventArgs();

            // Populate all members of "e" (ActionReadPreviousEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionReadPreviousEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadPreviousEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionUpSignal
        private bool OnActionUp(IntPtr data)
        {
            ActionUpEventArgs e = new ActionUpEventArgs();

            // Populate all members of "e" (ActionUpEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionUpEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionUpEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionDownSignal
        private bool OnActionDown(IntPtr data)
        {
            ActionDownEventArgs e = new ActionDownEventArgs();

            // Populate all members of "e" (ActionDownEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionDownEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionDownEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionClearFocusSignal
        private bool OnActionClearFocus(IntPtr data)
        {
            ActionClearFocusEventArgs e = new ActionClearFocusEventArgs();

            // Populate all members of "e" (ActionClearFocusEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionClearFocusEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionClearFocusEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionBackSignal
        private bool OnActionBack(IntPtr data)
        {
            ActionBackEventArgs e = new ActionBackEventArgs();

            // Populate all members of "e" (ActionBackEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionBackEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionBackEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionScrollUpSignal
        private bool OnActionScrollUp(IntPtr data)
        {
            ActionScrollUpEventArgs e = new ActionScrollUpEventArgs();

            // Populate all members of "e" (ActionScrollUpEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionScrollUpEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionScrollUpEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionScrollDownSignal
        private bool OnActionScrollDown(IntPtr data)
        {
            ActionScrollDownEventArgs e = new ActionScrollDownEventArgs();

            // Populate all members of "e" (ActionScrollDownEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionScrollDownEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionScrollDownEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionPageLeftSignal
        private bool OnActionPageLeft(IntPtr data)
        {
            ActionPageLeftEventArgs e = new ActionPageLeftEventArgs();

            // Populate all members of "e" (ActionPageLeftEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionPageLeftEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPageLeftEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionPageRightSignal
        private bool OnActionPageRight(IntPtr data)
        {
            ActionPageRightEventArgs e = new ActionPageRightEventArgs();

            // Populate all members of "e" (ActionPageRightEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionPageRightEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPageRightEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionPageUpSignal
        private bool OnActionPageUp(IntPtr data)
        {
            ActionPageUpEventArgs e = new ActionPageUpEventArgs();

            // Populate all members of "e" (ActionPageUpEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionPageUpEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPageUpEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionPageDownSignal
        private bool OnActionPageDown(IntPtr data)
        {
            ActionPageDownEventArgs e = new ActionPageDownEventArgs();

            // Populate all members of "e" (ActionPageDownEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionPageDownEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPageDownEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionMoveToFirstSignal
        private bool OnActionMoveToFirst(IntPtr data)
        {
            ActionMoveToFirstEventArgs e = new ActionMoveToFirstEventArgs();

            // Populate all members of "e" (ActionMoveToFirstEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionMoveToFirstEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionMoveToFirstEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionMoveToLastSignal
        private bool OnActionMoveToLast(IntPtr data)
        {
            ActionMoveToLastEventArgs e = new ActionMoveToLastEventArgs();

            // Populate all members of "e" (ActionMoveToLastEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionMoveToLastEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionMoveToLastEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionReadFromTopSignal
        private bool OnActionReadFromTop(IntPtr data)
        {
            ActionReadFromTopEventArgs e = new ActionReadFromTopEventArgs();

            // Populate all members of "e" (ActionReadFromTopEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionReadFromTopEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadFromTopEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionReadFromNextSignal
        private bool OnActionReadFromNext(IntPtr data)
        {
            ActionReadFromNextEventArgs e = new ActionReadFromNextEventArgs();

            // Populate all members of "e" (ActionReadFromNextEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionReadFromNextEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadFromNextEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionZoomSignal
        private bool OnActionZoom(IntPtr data)
        {
            ActionZoomEventArgs e = new ActionZoomEventArgs();

            // Populate all members of "e" (ActionZoomEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionZoomEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionZoomEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionReadIndicatorInformationSignal
        private bool OnActionReadIndicatorInformation(IntPtr data)
        {
            ActionReadIndicatorInformationEventArgs e = new ActionReadIndicatorInformationEventArgs();

            // Populate all members of "e" (ActionReadIndicatorInformationEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionReadIndicatorInformationEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadIndicatorInformationEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionReadPauseResumeSignal
        private bool OnActionReadPauseResume(IntPtr data)
        {
            ActionReadPauseResumeEventArgs e = new ActionReadPauseResumeEventArgs();

            // Populate all members of "e" (ActionReadPauseResumeEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionReadPauseResumeEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadPauseResumeEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager ActionStartStopSignal
        private bool OnActionStartStop(IntPtr data)
        {
            ActionStartStopEventArgs e = new ActionStartStopEventArgs();

            // Populate all members of "e" (ActionStartStopEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionStartStopEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionStartStopEventHandler(this, e);
            }
            return false;
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

        // Callback for AccessibilityManager FocusChangedSignal
        private void OnFocusChanged(IntPtr view1, IntPtr view2)
        {
            FocusChangedEventArgs e = new FocusChangedEventArgs();

            // Populate all members of "e" (FocusChangedEventArgs) with real data
            e.ViewCurrent = Registry.GetManagedBaseHandleFromNativePtr(view1) as View;
            e.ViewNext = Registry.GetManagedBaseHandleFromNativePtr(view2) as View;

            if (_accessibilityManagerFocusChangedEventHandler != null)
            {
                //here we send all data to user event handlers
                _accessibilityManagerFocusChangedEventHandler(this, e);
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

        // Callback for AccessibilityManager FocusedViewActivatedSignal
        private void OnFocusedViewActivated(IntPtr view)
        {
            FocusedViewActivatedEventArgs e = new FocusedViewActivatedEventArgs();

            // Populate all members of "e" (FocusedViewActivatedEventArgs) with real data
            e.View = Registry.GetManagedBaseHandleFromNativePtr(view) as View;

            if (_accessibilityManagerFocusedViewActivatedEventHandler != null)
            {
                //here we send all data to user event handlers
                _accessibilityManagerFocusedViewActivatedEventHandler(this, e);
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

        // Callback for AccessibilityManager FocusOvershotSignal
        private void OnFocusOvershot(IntPtr currentFocusedView, AccessibilityManager.FocusOvershotDirection direction)
        {
            FocusOvershotEventArgs e = new FocusOvershotEventArgs();

            // Populate all members of "e" (FocusOvershotEventArgs) with real data
            e.CurrentFocusedView = Registry.GetManagedBaseHandleFromNativePtr(currentFocusedView) as View;
            e.FocusOvershotDirection = direction;

            if (_accessibilityManagerFocusOvershotEventHandler != null)
            {
                //here we send all data to user event handlers
                _accessibilityManagerFocusOvershotEventHandler(this, e);
            }
        }


        public static AccessibilityManager GetAccessibilityManagerFromPtr(global::System.IntPtr cPtr)
        {
            AccessibilityManager ret = new AccessibilityManager(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        public AccessibilityManager() : this(Interop.AccessibilityManage.new_AccessibilityManager(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static AccessibilityManager Get()
        {
            AccessibilityManager ret = new AccessibilityManager(Interop.AccessibilityManage.AccessibilityManager_Get(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetAccessibilityAttribute(View view, AccessibilityManager.AccessibilityAttribute type, string text)
        {
            Interop.AccessibilityManage.AccessibilityManager_SetAccessibilityAttribute(swigCPtr, View.getCPtr(view), (int)type, text);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public string GetAccessibilityAttribute(View view, AccessibilityManager.AccessibilityAttribute type)
        {
            string ret = Interop.AccessibilityManage.AccessibilityManager_GetAccessibilityAttribute(swigCPtr, View.getCPtr(view), (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFocusOrder(View view, uint order)
        {
            Interop.AccessibilityManage.AccessibilityManager_SetFocusOrder(swigCPtr, View.getCPtr(view), order);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public uint GetFocusOrder(View view)
        {
            uint ret = Interop.AccessibilityManage.AccessibilityManager_GetFocusOrder(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GenerateNewFocusOrder()
        {
            uint ret = Interop.AccessibilityManage.AccessibilityManager_GenerateNewFocusOrder(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View GetViewByFocusOrder(uint order)
        {
            View ret = new View(Interop.AccessibilityManage.AccessibilityManager_GetActorByFocusOrder(swigCPtr, order), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool SetCurrentFocusView(View view)
        {
            bool ret = Interop.AccessibilityManage.AccessibilityManager_SetCurrentFocusActor(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View GetCurrentFocusView()
        {
            View ret = new View(Interop.AccessibilityManage.AccessibilityManager_GetCurrentFocusActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View GetCurrentFocusGroup()
        {
            View ret = new View(Interop.AccessibilityManage.AccessibilityManager_GetCurrentFocusGroup(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetCurrentFocusOrder()
        {
            uint ret = Interop.AccessibilityManage.AccessibilityManager_GetCurrentFocusOrder(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool MoveFocusForward()
        {
            bool ret = Interop.AccessibilityManage.AccessibilityManager_MoveFocusForward(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool MoveFocusBackward()
        {
            bool ret = Interop.AccessibilityManage.AccessibilityManager_MoveFocusBackward(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void ClearFocus()
        {
            Interop.AccessibilityManage.AccessibilityManager_ClearFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public new void Reset()
        {
            Interop.AccessibilityManage.AccessibilityManager_Reset(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetFocusGroup(View view, bool isFocusGroup)
        {
            Interop.AccessibilityManage.AccessibilityManager_SetFocusGroup(swigCPtr, View.getCPtr(view), isFocusGroup);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsFocusGroup(View view)
        {
            bool ret = Interop.AccessibilityManage.AccessibilityManager_IsFocusGroup(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetGroupMode(bool enabled)
        {
            Interop.AccessibilityManage.AccessibilityManager_SetGroupMode(swigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetGroupMode()
        {
            bool ret = Interop.AccessibilityManage.AccessibilityManager_GetGroupMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetWrapMode(bool wrapped)
        {
            Interop.AccessibilityManage.AccessibilityManager_SetWrapMode(swigCPtr, wrapped);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetWrapMode()
        {
            bool ret = Interop.AccessibilityManage.AccessibilityManager_GetWrapMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFocusIndicatorView(View indicator)
        {
            Interop.AccessibilityManage.AccessibilityManager_SetFocusIndicatorActor(swigCPtr, View.getCPtr(indicator));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public View GetFocusIndicatorView()
        {
            View ret = new View(Interop.AccessibilityManage.AccessibilityManager_GetFocusIndicatorActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View GetFocusGroup(View view)
        {
            View ret = new View(Interop.AccessibilityManage.AccessibilityManager_GetFocusGroup(swigCPtr, View.getCPtr(view)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector2 GetReadPosition()
        {
            Vector2 ret = new Vector2(Interop.AccessibilityManage.AccessibilityManager_GetReadPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public FocusChangedSignal FocusChangedSignal()
        {
            FocusChangedSignal ret = new FocusChangedSignal(Interop.AccessibilityManage.AccessibilityManager_FocusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityFocusOvershotSignal FocusOvershotSignal()
        {
            AccessibilityFocusOvershotSignal ret = new AccessibilityFocusOvershotSignal(Interop.AccessibilityManage.AccessibilityManager_FocusOvershotSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public ViewSignal FocusedViewActivatedSignal()
        {
            ViewSignal ret = new ViewSignal(Interop.AccessibilityManage.AccessibilityManager_FocusedActorActivatedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal StatusChangedSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_StatusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionNextSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionNextSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionPreviousSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionPreviousSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionActivateSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionActivateSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionReadSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionReadSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionOverSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionOverSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionReadNextSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionReadNextSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionReadPreviousSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionReadPreviousSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionUpSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionUpSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionDownSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionDownSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionClearFocusSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionClearFocusSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionBackSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionBackSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionScrollUpSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionScrollUpSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionScrollDownSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionScrollDownSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionPageLeftSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionPageLeftSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionPageRightSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionPageRightSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionPageUpSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionPageUpSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionPageDownSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionPageDownSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionMoveToFirstSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionMoveToFirstSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionMoveToLastSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionMoveToLastSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionReadFromTopSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionReadFromTopSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionReadFromNextSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionReadFromNextSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionZoomSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionZoomSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionReadIndicatorInformationSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionReadIndicatorInformationSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionReadPauseResumeSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionReadPauseResumeSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionStartStopSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionStartStopSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public SWIGTYPE_p_Dali__SignalT_bool_fDali__Toolkit__AccessibilityManager_R_Dali__TouchEvent_const_RF_t ActionScrollSignal()
        {
            SWIGTYPE_p_Dali__SignalT_bool_fDali__Toolkit__AccessibilityManager_R_Dali__TouchEvent_const_RF_t ret = new SWIGTYPE_p_Dali__SignalT_bool_fDali__Toolkit__AccessibilityManager_R_Dali__TouchEvent_const_RF_t(Interop.AccessibilityManage.AccessibilityManager_ActionScrollSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public enum AccessibilityAttribute
        {
            ACCESSIBILITY_LABEL = 0,
            ACCESSIBILITY_TRAIT,
            ACCESSIBILITY_VALUE,
            ACCESSIBILITY_HINT,
            ACCESSIBILITY_ATTRIBUTE_NUM
        }

        /// <since_tizen> 3 </since_tizen>
        public enum FocusOvershotDirection
        {
            OVERSHOT_PREVIOUS = -1,
            OVERSHOT_NEXT = 1
        }
    }
}
