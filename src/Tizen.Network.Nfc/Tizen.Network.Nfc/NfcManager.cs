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
    /// The NfcManager class provides methods for managing the NFC service in Tizen applications.
    /// It allows applications to initialize and terminate the NFC service, register and unregister NFC tags, and handle NFC events.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <privilege>http://tizen.org/privilege/nfc</privilege>
    static public class NfcManager
    {
        /// <summary>
        /// The IsSupported property checks whether the NFC feature is supported on the device.
        /// It returns a boolean value indicating whether the NFC service is available.
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
        /// The IsActivated property checks whether the NFC service is currently activated on the device.
        /// It returns a boolean value indicating whether the NFC service is active.
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
        /// The TagFilterType property specifies the type of tag filtering to be used by the NFC service.
        /// It can be set to either NfcTagFilterType.All or NfcTagFilterType.NdefOnly, depending on the desired behavior.
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
        /// The SecureElementType property specifies the type of Secure Element (SE) to be used by the NFC service.
        /// It can be set to either NfcSecureElementType.Uicc or NfcSecureElementType.Ese, depending on the desired behavior.
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
        /// The CachedNdefMessage property returns the cached NDEF message, which is a representation of the data stored on an NFC tag.
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
        /// The GetTagAdapter method returns the Tag adapter object, which is used to manage NFC tags in the NFC service.
        /// The Tag adapter provides methods for reading, writing, and formatting NFC tags.
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
        /// The GetP2pAdapter method returns the P2P adapter object,
        /// which is used to manage NFC peer-to-peer (P2P) communication in the NFC service.
        /// The P2P adapter provides methods for initiating and receiving P2P communication.
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
        /// The GetCardEmulationAdapter method returns the Card Emulation adapter object,
        /// which is used to manage NFC card emulation in the NFC service.
        /// The Card Emulation adapter provides methods for registering and deregistering services, and for handling card emulation events.
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
        /// The SetActivationAsync method activates or deactivates the NFC service asynchronously.
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
        /// The ActivationChanged event is triggered when the NFC activation state changes.
        /// The event handler receives an ActivationChangedEventArgs object containing information about the activation state change.
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
        /// The NdefMessageDiscovered event is triggered when an NDEF message is discovered by the NFC service.
        /// The event handler receives an NdefMessageDiscoveredEventArgs object containing information about the discovered NDEF message.
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
