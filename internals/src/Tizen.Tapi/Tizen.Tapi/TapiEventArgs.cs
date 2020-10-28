/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
        public object Data
        {
            get
            {
                return _data;
            }
        }
    }
}
