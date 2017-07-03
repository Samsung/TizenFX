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

namespace Tizen.Network.Nfc
{
    /// <summary>
    /// Enumeration for Nfc record TNF (Type Name Format).
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NfcRecordTypeNameFormat
    {
        /// <summary>
        /// Empty
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Empty = 0,
        /// <summary>
        /// RTD(Record Type Definition) type format [NFC RTD]
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        WellKnown = 1,
        /// <summary>
        /// MIME Media types in RFC 2046 [RFC 2046]
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        MimeMedia = 2,
        /// <summary>
        /// Absolute URI as defined in RFC 3986 [RFC 3986]
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Uri = 3,
        /// <summary>
        /// NFC Forum external type [NFC RTD]
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ExternalRtd = 4,
        /// <summary>
        /// The payload type is unknown
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Unknown = 5,
        /// <summary>
        ///  final chunk of a chunked NDEF Record
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        UnChanged = 6
    }

    /// <summary>
    /// Enumeration for Nfc Encode type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NfcEncodeType
    {
        /// <summary>
        /// UTF-8
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Utf8 = 0,
        /// <summary>
        /// UTF-16
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Utf16 = 1
    }
    /// <summary>
    /// Enumeration for Nfc Tag type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NfcTagType
    {
        /// <summary> 
        /// Unknown target
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        UnknownTarget = 0x00,
        /// <summary>
        /// Generic PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        GenericPicc,
        /// <summary>
        /// ISO14443 A PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Iso14443APicc,
        /// <summary>
        /// ISO14443 4A PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Iso144434APicc,
        /// <summary>
        /// ISO14443 4A PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Iso144433APicc,
        /// <summary> 
        /// Mifare Mini PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        MifareMiniPicc,
        /// <summary>
        /// Mifare 1k PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Mifare1kPicc,
        /// <summary>
        /// Mifare 4k PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Mifare4kPicc,
        /// <summary>
        /// Mifare Ultra PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        MifareUltraPicc,
        /// <summary>
        /// Mifare Desfire PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        MifareDesfirePicc,
        /// <summary> 
        /// Iso14443 B PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Iso14443BPicc,
        /// <summary>
        /// Iso14443 4B PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Iso144434BPicc,
        /// <summary>
        /// ISO14443 B Prime PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Iso14443BPrimePicc,
        /// <summary>
        /// Felica PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        FelicaPicc,
        /// <summary>
        /// Jewel PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        JewelPicc,
        /// <summary> 
        /// ISO15693 PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Iso15693Picc,
        /// <summary>
        /// Barcode 128 PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Barcode128Picc,
        /// <summary>
        /// Barcode 256 PICC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Barcode256Picc,
        /// <summary>
        /// NFCIP1 Target
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NfcIp1Target,
        /// <summary>
        /// NFCIP1 Initiator
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NfcIp1Initiator
    }
    /// <summary>
    /// Enumeration for Nfc Tag Filter type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NfcTagFilterType
    {
        /// <summary>
        /// All disable
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        AllDisable = 0x0000,
        /// <summary>
        /// ISO14443A enable
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Iso14443AEnable = 0x0001,
        /// <summary>
        /// ISO14443B enable
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Iso14443BEnable = 0x0002,
        /// <summary>
        /// ISO15693 enable
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Iso15693Enable = 0x0004,
        /// <summary>
        /// FELICA enable
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        FelicaEnable = 0x0008,
        /// <summary>
        /// JEWEL enable
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        JewelEnable = 0x0010,
        /// <summary>
        /// IP enable
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        IpEnable = 0x0020,
        /// <summary>
        /// All enable
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        AllEnable = ~0
    }
    /// <summary>
    /// Enumeration for Nfc discovered type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NfcDiscoveredType
    {
        /// <summary>
        /// Attached, discovered, activated event
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Attached,
        /// <summary>
        /// Detached, disappeared, deactivated event
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Detached
    }
    /// <summary>
    /// Enumeration for Nfc Secure Element event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NfcSecureElementEvent
    {
        /// <summary>
        /// Start transaction
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        StartTransaction,
        /// <summary>
        /// End transaction
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        EndTransaction,
        /// <summary>
        /// Ready signal
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Connectivity,
        /// <summary>
        /// CLF(Contactless Front-end) detects a RF field
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        FieldOn,
        /// <summary>
        /// CLF(Contactless Front-end) detects that the RF field is off
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        FieldOff,
        /// <summary>
        /// External reader trys to access secure element
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Transaction,
        /// <summary>
        /// Changing the emulated secure element type
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        TypeChanged,
        /// <summary>
        /// Changing the card emulation mode
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        CardEmulationChanged
    }
    /// <summary>
    /// Enumeration for Nfc Filter type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NfcSecureElementType
    {
        /// <summary>
        /// Disable card emulation
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Disable = 0x00,
        /// <summary>
        /// SmartMX type card emulation (Embedded Secure Element)
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        EmbeddedSE = 0x01,
        /// <summary>
        /// UICC type card emulation (Universal IC Card)
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Uicc = 0x02,
        /// <summary>
        /// SDCARD card emulation
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Sdcard = 0x03,
        /// <summary>
        /// Host based card emulation
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Hce = 0x04
    }
    /// <summary>
    /// Enumeration for Nfc discovered type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NfcSecureElementCardEmulationMode
    {
        /// <summary>
        /// Card Emulation mode OFF
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Off = 0x00,
        /// <summary>
        /// Card Emulation mode ON
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        On = 0x01
    }
    /// <summary>
    /// Enumeration for SNEP(Simple NDEF Exchange Protocol) event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NfcSnepEvent
    {
        /// <summary>
        /// server or client stopped
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Stop = 0x00,
        /// <summary>
        /// server started or client connected
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Start = 0x01,
        /// <summary>
        /// server received get request
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Get = 0x02,
        /// <summary>
        /// server received put request
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Put = 0x03,
        /// <summary>
        /// service registered
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Register = 0x04,
        /// <summary>
        /// service unregistered
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Unregister = 0x05
    }
    /// <summary>
    /// Enumeration for SNEP request type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NfcSnepRequestType
    {
        /// <summary>
        /// get request
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Get = 0x01,
        /// <summary>
        /// put request
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Put = 0x02
    }
    /// <summary>
    /// Enumeration for NFC Card Emulation Category type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NfcCardEmulationCategoryType
    {
        /// <summary>
        /// NFC payment services
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Payment = 0x01,
        /// <summary>
        /// all other card emulation services
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Other = 0x02
    }
    /// <summary>
    /// Enumeration for NFC Card Emulation HCE(Host Card Emulation) event type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NfcHceEvent
    {
        /// <summary>
        /// HCE deactivated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Deactivated = 0x00,
        /// <summary>
        /// HCE activated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Activated = 0x01,
        /// <summary>
        /// HCE APDU(Application Protocol Data Unit) Received
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ApduReceived = 0x02
    }
}
