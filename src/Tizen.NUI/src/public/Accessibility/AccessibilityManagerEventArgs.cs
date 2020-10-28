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

namespace Tizen.NUI.Accessibility
{
    public partial class AccessibilityManager
    {
        /// <summary>
        /// Event arguments that passed via FocusChangedEvent signal
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
