/// Copyright 2016 by Samsung Electronics, Inc.
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Interop.Telephony;

namespace Tizen.Telephony
{
    /// <summary>
    /// The Call API's allows you to get the voice and video call states.
    /// It provides the List of CallHandle which can be used to get the information about call related actions.
    /// </summary>
    public class Call
    {
        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <param name="handle">
        /// SlotHandle received in the Manager.Init API
        /// </param>
        public Call(SlotHandle handle)
        {
            _handle = handle._handle;
        }

        /// <summary>
        /// Gets the current value for the preferred voice call subscription.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The currently set preferred voicecall subscription value.
        /// </returns>
        public CallPreferredVoiceSubsubscription PreferredVoiceSubscription
        {
            get
            {
                CallPreferredVoiceSubsubscription subs = CallPreferredVoiceSubsubscription.Unknown;
                TelephonyError error = Interop.Call.GetPreferredVoiceSubscription(_handle, out subs);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetPreferredVoiceSubscription Failed with error " + error);
                    return CallPreferredVoiceSubsubscription.Unknown;
                }

                return subs;
            }
        }

        /// <summary>
        /// Gets the list of the current call.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// List of CallHandle for existing calls.
        /// </returns>
        public List<CallHandle> GetCallHandleList()
        {
            uint count;
            _callList = new IntPtr();
            _list.Clear();
            TelephonyError error = Interop.Call.GetCallList(_handle, out count, out _callList);
            if (error != TelephonyError.None)
            {
                Tizen.Log.Error(Interop.Telephony.LogTag, "GetCallList Failed with error " + error);
                return _list;
            }

            _callHandle.Clear();
            IntPtr[] handleArray = new IntPtr[count];
            Marshal.Copy(_callList, handleArray, 0, (int)count);
            foreach (IntPtr handle in handleArray)
            {
                CallHandle info = new CallHandle(handle);
                _list.Add(info);
            }

            _safeCallList = new Interop.Call.SafeCallList(_callList, count);
            return _list;
        }

        internal IntPtr _handle;
        private List<IntPtr> _callHandle = new List<IntPtr>();
        private List<CallHandle> _list = new List<CallHandle>();
        private IntPtr _callList;
        private Interop.Call.SafeCallList _safeCallList;
    }
}
