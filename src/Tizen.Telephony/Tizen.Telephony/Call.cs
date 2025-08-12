﻿/*
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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Interop.Telephony;

namespace Tizen.Telephony
{
    /// <summary>
    /// The Call APIs allow you to get the voice and video call states.
    /// It provides the list of CallHandle which can be used to get the information about call related actions.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API13, will be removed in API15.")]
    public class Call
    {
        internal IntPtr _handle;
        private List<IntPtr> _callHandle = new List<IntPtr>();
        private List<CallHandle> _list = new List<CallHandle>();
        private IntPtr _callList;
        private Interop.Call.SafeCallList _safeCallList;

        /// <summary>
        /// The public constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="handle">
        /// SlotHandle received in the Manager.Init API.
        /// </param>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentNullException">
        /// This exception occurs if the handle provided is null.
        /// </exception>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public Call(SlotHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException();
            }

            _handle = handle._handle;
        }

        /// <summary>
        /// Gets the current value for the preferred voice call subscription.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The currently set preferred voicecall subscription value.
        /// </value>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public CallPreferredVoiceSubscription PreferredVoiceSubscription
        {
            get
            {
                CallPreferredVoiceSubscription subs = CallPreferredVoiceSubscription.Unknown;
                TelephonyError error = Interop.Call.GetPreferredVoiceSubscription(_handle, out subs);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetPreferredVoiceSubscription Failed with error " + error);
                    return CallPreferredVoiceSubscription.Unknown;
                }

                return subs;
            }
        }

        /// <summary>
        /// Gets the list of the current call.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// The list of the CallHandle for existing calls.
        /// </returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">In case of an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="UnauthorizedAccessException">In case of privileges not defined.</exception>
        /// <exception cref="OutOfMemoryException">In case of out of memory.</exception>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public IEnumerable<CallHandle> GetCallHandleList()
        {
            uint count;
            _callList = new IntPtr();
            _list.Clear();
            TelephonyError error = Interop.Call.GetCallList(_handle, out count, out _callList);
            if (error != TelephonyError.None)
            {
                Tizen.Log.Error(Interop.Telephony.LogTag, "GetCallList Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            _callHandle.Clear();
            if (count > 0)
            {
                IntPtr[] handleArray = new IntPtr[count];
                Marshal.Copy(_callList, handleArray, 0, (int)count);
                foreach (IntPtr handle in handleArray)
                {
                    CallHandle info = new CallHandle(handle);
                    _list.Add(info);
                }

                _safeCallList = new Interop.Call.SafeCallList(_callList, count);
            }
            return _list;
        }
    }
}
