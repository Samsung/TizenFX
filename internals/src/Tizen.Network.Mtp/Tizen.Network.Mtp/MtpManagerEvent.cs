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
using System.Threading.Tasks;

namespace Tizen.Network.Mtp
{
    internal static class EventHandlerExtension
    {
        internal static void SafeInvoke(this EventHandler evt, object sender, EventArgs e)
        {
            var handler = evt;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
        internal static void SafeInvoke<T>(this EventHandler<T> evt, object sender, T e) where T : EventArgs
        {
            var handler = evt;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }

    internal partial class MtpManagerImpl
    {
        private event EventHandler<MtpStateChangedEventArgs> _mtpStateChanged;

        private Interop.Mtp.MptStateChangedCallback _mtpStateChangedCallback;

        internal event EventHandler<MtpStateChangedEventArgs> MtpStateChanged
        {
            add
            {
                if (_mtpStateChanged == null)
                {
                    RegisterMtpStateChangedEvent();
                }
                _mtpStateChanged += value;
            }
            remove
            {
                _mtpStateChanged -= value;
                if (_mtpStateChanged == null)
                {
                    UnregisterMtpStateChangedEvent();
                }
            }
        }

        private void RegisterMtpStateChangedEvent()
        {
            _mtpStateChangedCallback = (int eventType, int eventParameter, IntPtr userData) =>
            {
                MtpEventType _eventType = (MtpEventType)eventType;
                int _eventParameter = eventParameter;
                MtpStateChangedEventArgs e = new MtpStateChangedEventArgs(_eventType, _eventParameter);
                _mtpStateChanged.SafeInvoke(null, e);
            };

            int ret = Interop.Mtp.AddMtpStateChangedCallback(_mtpStateChangedCallback, IntPtr.Zero);
            if (ret != (int)MtpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to add mtp state changed callback, Error - " + (MtpError)ret);
            }
        }

        private void UnregisterMtpStateChangedEvent()
        {
            int ret = Interop.Mtp.RemoveMtpStateChangedCallback(_mtpStateChangedCallback);

            if (ret != (int)MtpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove mtp state changed callback, Error - " + (MtpError)ret);
            }
        }
    }
}
