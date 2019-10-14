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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal partial class AccessibilityManager
    {
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
    }
}
