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
using Tizen.System;

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
                bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

                if (!isNfcSupported)
                {
                    throw new NotSupportedException();
                }

                try
                {
                    return NfcManagerImpl.Instance.IsSupported;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// NFC Activation state.
        /// </summary>
        static public bool IsActivated
        {
            get
            {
                bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

                if (!isNfcSupported)
                {
                    throw new NotSupportedException();
                }

                try
                {
                    return NfcManagerImpl.Instance.IsActivated;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// The Tag Filter type.
        /// </summary>
        static public NfcTagFilterType TagFilterType
        {
            get
            {
                bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);
                bool isTagSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc.tag", out isTagSupported);

                if (!isNfcSupported || !isTagSupported)
                {
                    throw new NotSupportedException();
                }

                try
                {
                    return NfcManagerImpl.Instance.TagFilterType;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
            set
            {
                bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);
                bool isTagSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc.tag", out isTagSupported);

                if (!isNfcSupported || !isTagSupported)
                {
                    throw new NotSupportedException();
                }

                try
                {
                    NfcManagerImpl.Instance.TagFilterType = value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// The Secure Element type.
        /// </summary>
        static public NfcSecureElementType SecureElementType
        {
            get
            {
                bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);
                bool isCeSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc.cardemulation", out isCeSupported);

                if (!isNfcSupported || !isCeSupported)
                {
                    throw new NotSupportedException();
                }

                try
                {
                    return NfcManagerImpl.Instance.SecureElementType;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
            set
            {
                bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);
                bool isCeSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc.cardemulation", out isCeSupported);

                if (!isNfcSupported || !isCeSupported)
                {
                    throw new NotSupportedException();
                }

                try
                {
                    NfcManagerImpl.Instance.SecureElementType = value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// Enable or disable the system handling for tag and target discovered event.
        /// </summary>
        static public bool SystemHandlerEnabled
        {
            get
            {
                bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

                if (!isNfcSupported)
                {
                    throw new NotSupportedException();
                }

                try
                {
                    return NfcManagerImpl.Instance.SystemHandlerEnabled;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
            set
            {
                bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

                if (!isNfcSupported)
                {
                    throw new NotSupportedException();
                }

                try
                {
                    NfcManagerImpl.Instance.SystemHandlerEnabled = value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// The cached Ndef Message.
        /// </summary>
        static public NfcNdefMessage CachedNdefMessage
        {
            get
            {
                bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

                if (!isNfcSupported)
                {
                    throw new NotSupportedException();
                }

                try
                {
                    return NfcManagerImpl.Instance.CachedNdefMessage;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// Gets Tag adapter object.
        /// </summary>
        static public NfcTagAdapter GetTagAdapter()
        {
            bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);
            bool isTagSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc.tag", out isTagSupported);

            if (!isNfcSupported || !isTagSupported)
            {
                throw new NotSupportedException();
            }

            try
            {
                return NfcManagerImpl.Instance.TagAdapter;
            }
            catch (TypeInitializationException e)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Gets P2p adapter object.
        /// </summary>
        static public NfcP2pAdapter GetP2pAdapter()
        {
            bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);
            bool isP2pSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc.p2p", out isP2pSupported);

            if (!isNfcSupported || !isP2pSupported)
            {
                throw new NotSupportedException();
            }

            try
            {
                return NfcManagerImpl.Instance.P2pAdapter;
            }
            catch (TypeInitializationException e)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Gets Card Emulation adepter object.
        /// </summary>
        static public NfcCardEmulationAdapter GetCardEmulationAdapter()
        {
            bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);
            bool isCeSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc.cardemulation", out isCeSupported);

            if (!isNfcSupported || !isCeSupported)
            {
                throw new NotSupportedException();
            }

            try
            {
                return NfcManagerImpl.Instance.CardEmulationAdapter;
            }
            catch (TypeInitializationException e)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Activates Nfc asynchronously.
        /// </summary>
        /// <returns>A task indicates whether the Activate method is done or not.</returns>
        static public Task SetActivationAsync(bool activation)
        {
            bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

            if (!isNfcSupported)
            {
                throw new NotSupportedException();
            }

            try
            {
                return NfcManagerImpl.Instance.SetActivationAsync(activation);
            }
            catch (TypeInitializationException e)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// The Activation changed event.
        /// </summary>
        static public event EventHandler<ActivationChangedEventArgs> ActivationChanged
        {
            add
            {
                bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

                if (!isNfcSupported)
                {
                    throw new NotSupportedException();
                }

                try
                {
                    NfcManagerImpl.Instance.ActivationChanged += value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
            remove
            {
                bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

                if (!isNfcSupported)
                {
                    throw new NotSupportedException();
                }

                try
                {
                    NfcManagerImpl.Instance.ActivationChanged -= value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// The Ndef discovered event.
        /// </summary>
        static public event EventHandler<NdefMessageDiscoveredEventArgs> NdefMessageDiscovered
        {
            add
            {
                bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

                if (!isNfcSupported)
                {
                    throw new NotSupportedException();
                }

                try
                {
                    NfcManagerImpl.Instance.NdefMessageDiscovered += value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
            remove
            {
                bool isNfcSupported = SystemInfo.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

                if (!isNfcSupported)
                {
                    throw new NotSupportedException();
                }

                try
                {
                    NfcManagerImpl.Instance.NdefMessageDiscovered -= value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }
    }
}
