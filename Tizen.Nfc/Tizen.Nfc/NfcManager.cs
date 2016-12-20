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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.Network.Nfc
{
    /// <summary>
    /// A class for NFC management. It allows applications to use NFC service.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/nfc</privilege>
    static public class NfcManager
    {
        /// <summary>
        /// Whether NFC is supported.
        /// </summary>
        static public bool IsSupported
        {
            get
            {
                return NfcManagerImpl.Instance.IsSupported;
            }
        }

        /// <summary>
        /// NFC Activation state.
        /// </summary>
        static public bool IsActivated
        {
            get
            {
                return NfcManagerImpl.Instance.IsActivated;
            }
        }

        /// <summary>
        /// The Tag Filter type.
        /// </summary>
        static public NfcTagFilterType TagFilterType
        {
            get
            {
                return NfcManagerImpl.Instance.TagFilterType;
            }
            set
            {
                NfcManagerImpl.Instance.TagFilterType = value;
            }
        }

        /// <summary>
        /// The Secure Element type.
        /// </summary>
        static public NfcSecureElementType SecureElementType
        {
            get
            {
                return NfcManagerImpl.Instance.SecureElementType;
            }
            set
            {
                NfcManagerImpl.Instance.SecureElementType = value;
            }
        }

        /// <summary>
        /// Enable or disable the system handling for tag and target discovered event.
        /// </summary>
        static public bool SystemHandlerEnabled
        {
            get
            {
                return NfcManagerImpl.Instance.SystemHandlerEnabled;
            }
            set
            {
                NfcManagerImpl.Instance.SystemHandlerEnabled = value;
            }
        }

        /// <summary>
        /// The cached Ndef Message.
        /// </summary>
        static public NfcNdefMessage CachedNdefMessage
        {
            get
            {
                return NfcManagerImpl.Instance.CachedNdefMessage;
            }
        }

        /// <summary>
        /// Gets Tag adapter object.
        /// </summary>
        static public NfcTagAdapter GetTagAdapter()
        {
            return NfcManagerImpl.Instance.TagAdapter;
        }

        /// <summary>
        /// Gets P2p adapter object.
        /// </summary>
        static public NfcP2pAdapter GetP2pAdapter()
        {
            return NfcManagerImpl.Instance.P2pAdapter;
        }

        /// <summary>
        /// Gets Card Emulation adepter object.
        /// </summary>
        static public NfcCardEmulationAdapter GetCardEmulationAdapter()
        {
            return NfcManagerImpl.Instance.CardEmulationAdapter;
        }

        /// <summary>
        /// Activates Nfc asynchronously. 
        /// </summary>
        /// <returns>A task indicates whether the Activate method is done or not.</returns>
        static public Task SetActivateAsync(bool activation)
        {
            return NfcManagerImpl.Instance.SetActivateAsync(activation);
        }

        /// <summary>
        /// The Activation changed event.
        /// </summary>
        static public event EventHandler<ActivationChangedEventArgs> ActivationChanged
        {
            add
            {
                NfcManagerImpl.Instance.ActivationChanged += value;
            }
            remove
            {
                NfcManagerImpl.Instance.ActivationChanged -= value;
            }
        }

        /// <summary>
        /// The Ndef discovered event.
        /// </summary>
        static public event EventHandler<NdefMessageDiscoveredEventArgs> NdefMessageDiscovered
        {
            add
            {
                NfcManagerImpl.Instance.NdefMessageDiscovered += value;
            }
            remove
            {
                NfcManagerImpl.Instance.NdefMessageDiscovered -= value;
            }
        }
    }
}
