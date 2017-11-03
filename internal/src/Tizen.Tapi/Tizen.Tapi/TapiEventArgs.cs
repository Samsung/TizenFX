/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Tapi
{
    /// <summary>
    /// An extended EventArgs class which contains changed tapi state.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class StateChangedEventArgs : EventArgs
    {
        private int _state;

        internal StateChangedEventArgs(int state)
        {
            _state = state;
        }

        /// <summary>
        /// Tapi ready state.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int State
        {
            get
            {
                return _state;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed TAPI notification.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class NotificationChangedEventArgs : EventArgs
    {
        private Notification _id;
        private object _data;

        internal NotificationChangedEventArgs(Notification id, object data)
        {
            _id = id;
            _data = data;
        }

        /// <summary>
        /// Notification Id.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Notification Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// Notification data.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public object Data
        {
            get
            {
                return _data;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed TAPI property.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class PropertyChangedEventArgs : EventArgs
    {
        private Property _property;
        private object _data;

        internal PropertyChangedEventArgs(Property property, object data)
        {
            _property = property;
            _data = data;
        }

        /// <summary>
        /// Property definition type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Property Property
        {
            get
            {
                return _property;
            }
        }

        /// <summary>
        /// Property data.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public object Data
        {
            get
            {
                return _data;
            }
        }
    }
}
