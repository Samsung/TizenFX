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
    public enum NfcRecordTypeNameFormat
    {
        /// <summary>
        /// Empty
        /// </summary>
        Empty = 0,
        /// <summary>
        /// RTD(Record Type Definition) type format [NFC RTD]
        /// </summary>
        WellKnown = 1,
        /// <summary>
        /// MIME Media types in RFC 2046 [RFC 2046]
        /// </summary>
        MimeMedia = 2,
        /// <summary>
        /// Absolute URI as defined in RFC 3986 [RFC 3986]
        /// </summary>
        Uri = 3,
        /// <summary>
        /// NFC Forum external type [NFC RTD]
        /// </summary>
        ExternalRtd = 4,
        /// <summary>
        /// The payload type is unknown
        /// </summary>
        Unknown = 5,
        /// <summary>
        ///  final chunk of a chunked NDEF Record
        /// </summary>
        UnChanged = 6
    }

    /// <summary>
    /// Enumeration for Nfc Encode type.
    /// </summary>
    public enum NfcEncodeType
    {
        /// <summary>
        /// UTF-8
        /// </summary>
        Utf8 = 0,
        /// <summary>
        /// UTF-16
        /// </summary>
        Utf16 = 1
    }
    /// <summary>
    /// Enumeration for Nfc Tag type.
    /// </summary>
    public enum NfcTagType
    {
        /// <summary> 
        /// Unknown target
        /// </summary>
        UnknownTarget = 0x00,
        /// <summary>
        /// Generic PICC
        /// </summary>
        GenericPicc,
        /// <summary>
        /// ISO14443 A PICC
        /// </summary>
        Iso14443APicc,
        /// <summary>
        /// ISO14443 4A PICC
        /// </summary>
        Iso144434APicc,
        /// <summary>
        /// ISO14443 4A PICC
        /// </summary>
        Iso144433APicc,
        /// <summary> 
        /// Mifare Mini PICC
        /// </summary>
        MifareMiniPicc,
        /// <summary>
        /// Mifare 1k PICC
        /// </summary>
        Mifare1kPicc,
        /// <summary>
        /// Mifare 4k PICC
        /// </summary>
        Mifare4kPicc,
        /// <summary>
        /// Mifare Ultra PICC
        /// </summary>
        MifareUltraPicc,
        /// <summary>
        /// Mifare Desfire PICC
        /// </summary>
        MifareDesfirePicc,
        /// <summary> 
        /// Iso14443 B PICC
        /// </summary>
        Iso14443BPicc,
        /// <summary>
        /// Iso14443 4B PICC
        /// </summary>
        Iso144434BPicc,
        /// <summary>
        /// ISO14443 B Prime PICC
        /// </summary>
        Iso14443BPrimePicc,
        /// <summary>
        /// Felica PICC
        /// </summary>
        FelicaPicc,
        /// <summary>
        /// Jewel PICC
        /// </summary>
        JewelPicc,
        /// <summary> 
        /// ISO15693 PICC
        /// </summary>
        Iso15693Picc,
        /// <summary>
        /// Barcode 128 PICC
        /// </summary>
        Barcode128Picc,
        /// <summary>
        /// Barcode 256 PICC
        /// </summary>
        Barcode256Picc,
        /// <summary>
        /// NFCIP1 Target
        /// </summary>
        NfcIp1Target,
        /// <summary>
        /// NFCIP1 Initiator
        /// </summary>
        NfcIp1Initiator
    }
    /// <summary>
    /// Enumeration for Nfc Tag Filter type.
    /// </summary>
    public enum NfcTagFilterType
    {
        /// <summary>
        /// All disable
        /// </summary>
        AllDisable = 0x0000,
        /// <summary>
        /// ISO14443A enable
        /// </summary>
        Iso14443AEnable = 0x0001,
        /// <summary>
        /// ISO14443B enable
        /// </summary>
        Iso14443BEnable = 0x0002,
        /// <summary>
        /// ISO15693 enable
        /// </summary>
        Iso15693Enable = 0x0004,
        /// <summary>
        /// FELICA enable
        /// </summary>
        FelicaEnable = 0x0008,
        /// <summary>
        /// JEWEL enable
        /// </summary>
        JewelEnable = 0x0010,
        /// <summary>
        /// IP enable
        /// </summary>
        IpEnable = 0x0020,
        /// <summary>
        /// All enable
        /// </summary>
        AllEnable = ~0
    }
    /// <summary>
    /// Enumeration for Nfc discovered type.
    /// </summary>
    public enum NfcDiscoveredType
    {
        /// <summary>
        /// Attached, discovered, activated event
        /// </summary>
        Attached,
        /// <summary>
        /// Detached, disappeared, deactivated event
        /// </summary>
        Detached
    }
    /// <summary>
    /// Enumeration for Nfc Secure Element event.
    /// </summary>
    public enum NfcSecureElementEvent
    {
        /// <summary>
        /// Start transaction
        /// </summary>
        StartTransaction,
        /// <summary>
        /// End transaction
        /// </summary>
        EndTransaction,
        /// <summary>
        /// Ready signal
        /// </summary>
        Connectivity,
        /// <summary>
        /// CLF(Contactless Front-end) detects a RF field
        /// </summary>
        FieldOn,
        /// <summary>
        /// CLF(Contactless Front-end) detects that the RF field is off
        /// </summary>
        FieldOff,
        /// <summary>
        /// External reader trys to access secure element
        /// </summary>
        Transaction,
        /// <summary>
        /// Changing the emulated secure element type
        /// </summary>
        TypeChanged,
        /// <summary>
        /// Changing the card emulation mode
        /// </summary>
        CardEmulationChanged
    }
    /// <summary>
    /// Enumeration for Nfc Filter type.
    /// </summary>
    public enum NfcSecureElementType
    {
        /// <summary>
        /// Disable card emulation
        /// </summary>
        Disable = 0x00,
        /// <summary>
        /// SmartMX type card emulation (Embedded Secure Element)
        /// </summary>
        EmbeddedSE = 0x01,
        /// <summary>
        /// UICC type card emulation (Universal IC Card)
        /// </summary>
        Uicc = 0x02,
        /// <summary>
        /// SDCARD card emulation
        /// </summary>
        Sdcard = 0x03,
        /// <summary>
        /// Host based card emulation
        /// </summary>
        Hce = 0x04
    }
    /// <summary>
    /// Enumeration for Nfc discovered type.
    /// </summary>
    public enum NfcSecureElementCardEmulationMode
    {
        /// <summary>
        /// Card Emulation mode OFF
        /// </summary>
        Off = 0x00,
        /// <summary>
        /// Card Emulation mode ON
        /// </summary>
        On = 0x01
    }
    /// <summary>
    /// Enumeration for SNEP(Simple NDEF Exchange Protocol) event.
    /// </summary>
    public enum NfcSnepEvent
    {
        /// <summary>
        /// server or client stopped
        /// </summary>
        Stop = 0x00,
        /// <summary>
        /// server started or client connected
        /// </summary>
        Start = 0x01,
        /// <summary>
        /// server received get request
        /// </summary>
        Get = 0x02,
        /// <summary>
        /// server received put request
        /// </summary>
        Put = 0x03,
        /// <summary>
        /// service registered
        /// </summary>
        Register = 0x04,
        /// <summary>
        /// service unregistered
        /// </summary>
        Unregister = 0x05
    }
    /// <summary>
    /// Enumeration for SNEP request type.
    /// </summary>
    public enum NfcSnepRequestType
    {
        /// <summary>
        /// get request
        /// </summary>
        Get = 0x01,
        /// <summary>
        /// put request
        /// </summary>
        Put = 0x02
    }
    /// <summary>
    /// Enumeration for NFC Card Emulation Category type.
    /// </summary>
    public enum NfcCardEmulationCategoryType
    {
        /// <summary>
        /// NFC payment services
        /// </summary>
        Payment = 0x01,
        /// <summary>
        /// all other card emulation services
        /// </summary>
        Other = 0x02
    }
    /// <summary>
    /// Enumeration for NFC Card Emulation HCE(Host Card Emulation) event type.
    /// </summary>
    public enum NfcHceEvent
    {
        /// <summary>
        /// HCE deactivated
        /// </summary>
        Deactivated = 0x00,
        /// <summary>
        /// HCE activated
        /// </summary>
        Activated = 0x01,
        /// <summary>
        /// HCE APDU(Application Protocol Data Unit) Received
        /// </summary>
        ApduReceived = 0x02
    }
}
