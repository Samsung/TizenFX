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
    /// A class for the NFC management. It allows applications to use the NFC service.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <privilege>http://tizen.org/privilege/nfc</privilege>
    static public class NfcManager
    {
        /// <summary>
        /// Checks whether the NFC is supported.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        static public bool IsSupported
        {
            get
            {
                bool isNfcSupported = false;

                Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

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
        /// The NFC Activation state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        static public bool IsActivated
        {
            get
            {
                bool isNfcSupported = false;

                Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

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
        /// <since_tizen> 3 </since_tizen>
        static public NfcTagFilterType TagFilterType
        {
            get
            {
                bool isNfcSupported = false;
                bool isTagSupported = false;

                Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);
                Information.TryGetValue("http://tizen.org/feature/network.nfc.tag", out isTagSupported);

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
                bool isNfcSupported = false;
                bool isTagSupported = false;

                Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);
                Information.TryGetValue("http://tizen.org/feature/network.nfc.tag", out isTagSupported);

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
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/nfc.cardemulation</privilege>
        static public NfcSecureElementType SecureElementType
        {
            get
            {
                bool isNfcSupported = false;
                bool isCeSupported = false;

                Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);
                Information.TryGetValue("http://tizen.org/feature/network.nfc.card_emulation", out isCeSupported);

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
                bool isNfcSupported = false;
                bool isCeSupported = false;

                Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);
                Information.TryGetValue("http://tizen.org/feature/network.nfc.card_emulation", out isCeSupported);

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
        /// Enables or disables the system handling for the tag and target discovered event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/nfc</privilege>
        static public bool SystemHandlerEnabled
        {
            get
            {
                bool isNfcSupported = false;

                Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

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
                bool isNfcSupported = false;

                Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

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
        /// The cached NDEF message.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        static public NfcNdefMessage CachedNdefMessage
        {
            get
            {
                bool isNfcSupported = false;

                Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

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
        /// Gets the Tag adapter object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        static public NfcTagAdapter GetTagAdapter()
        {
            bool isNfcSupported = false;
            bool isTagSupported = false;

            Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);
            Information.TryGetValue("http://tizen.org/feature/network.nfc.tag", out isTagSupported);

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
        /// Gets the P2P adapter object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        static public NfcP2pAdapter GetP2pAdapter()
        {
            bool isNfcSupported = false;
            bool isP2pSupported = false;

            Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);
            Information.TryGetValue("http://tizen.org/feature/network.nfc.p2p", out isP2pSupported);

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
        /// Gets the Card Emulation adapter object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        static public NfcCardEmulationAdapter GetCardEmulationAdapter()
        {
            bool isNfcSupported = false;
            bool isCeSupported = false;

            Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);
            Information.TryGetValue("http://tizen.org/feature/network.nfc.card_emulation", out isCeSupported);

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
        /// Activates the NFC asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>A task indicates whether the Activate method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/nfc.admin</privilege>
        static public Task SetActivationAsync(bool activation)
        {
            bool isNfcSupported = false;

            Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

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
        /// <since_tizen> 3 </since_tizen>
        static public event EventHandler<ActivationChangedEventArgs> ActivationChanged
        {
            add
            {
                bool isNfcSupported = false;

                Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

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
                bool isNfcSupported = false;

                Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

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
        /// The NDEF discovered event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        static public event EventHandler<NdefMessageDiscoveredEventArgs> NdefMessageDiscovered
        {
            add
            {
                bool isNfcSupported = false;

                Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

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
                bool isNfcSupported = false;

                Information.TryGetValue("http://tizen.org/feature/network.nfc", out isNfcSupported);

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
