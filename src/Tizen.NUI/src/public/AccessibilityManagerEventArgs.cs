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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    public partial class AccessibilityManager
    {
        /// <summary>
        /// Event arguments that passed via StatusChanged signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class StatusChangedEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionNext signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ActionNextEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionPrevious signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ActionPreviousEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionActivate signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ActionActivateEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionRead signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ActionReadEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionOver signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ActionOverEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionReadNext signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ActionReadNextEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionReadPrevious signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionReadPreviousEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionUp signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionUpEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionDown signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionDownEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionClearFocus signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionClearFocusEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionBack signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionBackEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionScrollUp signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionScrollUpEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionScrollDown signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionScrollDownEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionPageLeft signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ActionPageLeftEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionPageRight signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionPageRightEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionPageUp signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionPageUpEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionPageDown signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionPageDownEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionMoveToFirst signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionMoveToFirstEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionMoveToLast signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionMoveToLastEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionReadFromTop signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionReadFromTopEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionReadFromNext signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionReadFromNextEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionZoom signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class ActionZoomEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionReadPauseResume signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ActionReadPauseResumeEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionStartStop signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ActionStartStopEventArgs : EventArgs
        {
            private AccessibilityManager _accessibilityManager;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via ActionPageUp signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class FocusChangedEventArgs : EventArgs
        {
            private View _viewCurrent;
            private View _viewNext;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via FocusedViewActivated signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class FocusedViewActivatedEventArgs : EventArgs
        {
            private View _view;


            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Event arguments that passed via FocusOvershot signal
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class FocusOvershotEventArgs : EventArgs
        {
            private View _currentFocusedView;
            private AccessibilityManager.FocusOvershotDirection _focusOvershotDirection;

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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

            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
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
