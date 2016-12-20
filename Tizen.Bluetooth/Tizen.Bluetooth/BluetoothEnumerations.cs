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
using Tizen.Internals.Errors;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// Enumeration for Bluetooth state.
    /// </summary>
    public enum BluetoothState
    {
        /// <summary>
        /// Disabled state.
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// Enabled state.
        /// </summary>
        Enabled
    }

    /// <summary>
    /// Enumeration for Bluetooth errors.
    /// </summary>
    public enum BluetoothError
    {
        /// <summary>
        /// Successful
        /// </summary>
        None = ErrorCode.None,
        /// <summary>
        /// Operation cancelled
        /// </summary>
        Cancelled = ErrorCode.Canceled,
        /// <summary>
        /// Invalid parameter
        /// </summary>
        InvalidParameter = ErrorCode.InvalidParameter,
        /// <summary>
        /// Out of memory
        /// </summary>
        OutOfMemory = ErrorCode.OutOfMemory,
        /// <summary>
        /// Device or resource busy
        /// </summary>
        ResourceBusy = ErrorCode.ResourceBusy,
        /// <summary>
        /// Timeout error
        /// </summary>
        TimedOut = ErrorCode.TimedOut,
        /// <summary>
        /// Operation now in progress
        /// </summary>
        NowInProgress = ErrorCode.NowInProgress,
        /// <summary>
        /// Bluetooth is Not Supported
        /// </summary>
        NotSupported = ErrorCode.NotSupported,
        /// <summary>
        /// Permission denied
        /// </summary>
        PermissionDenied = ErrorCode.PermissionDenied,
        /// <summary>
        /// Quota exceeded
        /// </summary>
        QuotaExceeded = ErrorCode.QuotaExceeded,
        /// <summary>
        /// No data available
        /// </summary>
        NoData = ErrorCode.NoData,
        /// <summary>
        /// Local adapter not initialized
        /// </summary>
        NotInitialized = -0x01C00000 | 0x0101,
        /// <summary>
        /// Local adapter not enabled
        /// </summary>
        NotEnabled = -0x01C00000 | 0x0102,
        /// <summary>
        /// Operation already done
        /// </summary>
        AlreadyDone = -0x01C00000 | 0x0103,
        /// <summary>
        /// Operation failed
        /// </summary>
        OperationFailed = -0x01C00000 | 0x0104,
        /// <summary>
        /// Operation not in progress
        /// </summary>
        NotInProgress = -0x01C00000 | 0x0105,
        /// <summary>
        /// Remote device not bonded
        /// </summary>
        RemoteDeviceNotBonded = -0x01C00000 | 0x0106,
        /// <summary>
        /// Authentication rejected
        /// </summary>
        AuthRejected = -0x01C00000 | 0x0107,
        /// <summary>
        /// Authentication failed
        /// </summary>
        AuthFailed = -0x01C00000 | 0x0108,
        /// <summary>
        /// Remote device not found
        /// </summary>
        RemoteDeviceNotFound = -0x01C00000 | 0x0109,
        /// <summary>
        /// Service search failed
        /// </summary>
        ServiceSearchFailed = -0x01C00000 | 0x010A,
        /// <summary>
        /// Remote device is not connected
        /// </summary>
        RemoteDeviceNotConnected = -0x01C00000 | 0x010B,
        /// <summary>
        /// Resource temporarily unavailable
        /// </summary>
        ResourceUnavailable = -0x01C00000 | 0x010C,
        /// <summary>
        /// Service Not Found
        /// </summary>
        ServiceNotFound = -0x01C00000 | 0x010D
    }

    /// <summary>
    /// Enumeration for Bluetooth visibility mode.
    /// </summary>
    public enum VisibilityMode
    {
        /// <summary>
        /// Non discoverable mode.
        /// </summary>
        NonDiscoverable = 0,
        /// <summary>
        /// Discoverable mode.
        /// </summary>
        Discoverable = 1,
        /// <summary>
        /// Discoverable mode with limited time.
        /// </summary>
        TimeLimitedDiscoverable = 2
    }

    /// <summary>
    /// Enumeration for Bluetooth major device class type.
    /// </summary>
    public enum BluetoothMajorDeviceClassType
    {
        /// <summary>
        /// Miscellaneous major class type.
        /// </summary>
        Misc = 0x00,
        /// <summary>
        /// Computer major class type.
        /// </summary>
        Computer = 0x01,
        /// <summary>
        /// Phone major class type.
        /// </summary>
        Phone = 0x02,
        /// <summary>
        /// LAN/Network access point major class type.
        /// </summary>
        LanNetworkAccessPoint = 0x03,
        /// <summary>
        /// Audio/Video major class type.
        /// </summary>
        AudioVideo = 0x04,
        /// <summary>
        /// Peripheral major class type.
        /// </summary>
        Peripheral = 0x05,
        /// <summary>
        /// Imaging major class type.
        /// </summary>
        Imaging = 0x06,
        /// <summary>
        /// Wearable major class type.
        /// </summary>
        Wearable = 0x07,
        /// <summary>
        /// Toy major class type.
        /// </summary>
        Toy = 0x08,
        /// <summary>
        /// Health major class type.
        /// </summary>
        Health = 0x09,
        /// <summary>
        /// Uncategorized major class type.
        /// </summary>
        Uncategorized = 0x1F
    }

    /// <summary>
    /// Enumeration for Bluetooth minor device class type.
    /// </summary>
    public enum BluetoothMinorDeviceClassType
    {
        /// <summary>
        /// Uncategorized computer minor class type.
        /// </summary>
        ComputerUncategorized = 0x00,
        /// <summary>
        /// Desktop workstation computer minor class type.
        /// </summary>
        ComputerDesktopWorkstation = 0x04,
        /// <summary>
        /// Server computer minor class type.
        /// </summary>
        ComputerServer = 0x08,
        /// <summary>
        /// Laptop computer minor class type.
        /// </summary>
        ComputerLaptop = 0x0C,
        /// <summary>
        /// Handheld PC/PDA computer minor class type.
        /// </summary>
        ComputerHandheldPcOrPda = 0x10,
        /// <summary>
        /// Palm sized PC/PDA  computer minor class type.
        /// </summary>
        ComputerPalmSizedPcOrPda = 0x14,
        /// <summary>
        /// Wearable computer minor class type.
        /// </summary>
        ComputerWearableComputer = 0x18,

        /// <summary>
        /// Unclassified phone minor class type.
        /// </summary>
        PhoneUncategorized = 0x00,
        /// <summary>
        /// Cellular phone minor class type.
        /// </summary>
        PhoneCellular = 0x04,
        /// <summary>
        /// Cordless phone minor class type.
        /// </summary>
        PhoneCordless = 0x08,
        /// <summary>
        /// SmartPhone phone minor class type.
        /// </summary>
        PhoneSmartPhone = 0x0C,
        /// <summary>
        /// Wired modem or voice gateway phone minor class type.
        /// </summary>
        PhoneWiredModemOrVoiceGateway = 0x10,
        /// <summary>
        /// ISDN phone minor class type.
        /// </summary>
        PhoneCommonIsdnAccess = 0x14,

        /// <summary>
        /// Fully available LAN/Network access point minor class type.
        /// </summary>
        LanNetworkAccessPointFullyAvailable = 0x04,
        /// <summary>
        /// 1-17% utilized LAN/Network access point minor class type.
        /// </summary>
        LanNetworkAccessPoint1To17PercentUtilized = 0x20,
        /// <summary>
        /// 17-33% utilized LAN/Network access point minor class type.
        /// </summary>
        LanNetworkAccessPoint17To33PercentUtilized = 0x40,
        /// <summary>
        /// 33-50% utilized LAN/Network access point minor class type.
        /// </summary>
        LanNetworkAccessPoint33To50PercentUtilized = 0x60,
        /// <summary>
        /// 50-67% utilized LAN/Network access point minor class type.
        /// </summary>
        LanNetworkAccessPoint50To67PercentUtilized = 0x80,
        /// <summary>
        /// 67-83% utilized LAN/Network access point minor class type.
        /// </summary>
        LanNetworkAccessPoint67To83PercentUtilized = 0xA0,
        /// <summary>
        /// 83-99% utilized LAN/Network access point minor class type.
        /// </summary>
        LanNetworkAccessPoint83To99PercentUtilized = 0xC0,
        /// <summary>
        /// No service available LAN/Network access point minor class type.
        /// </summary>
        LanNetworkAccessPointNoServiceAvailable = 0xE0,

        /// <summary>
        /// Uncategorized audio/video minor class type.
        /// </summary>
        AudioVideoUncategorized = 0x00,
        /// <summary>
        /// Wearable headset audio/video minor class type.
        /// </summary>
        AudioVideoWearableHeadset = 0x04,
        /// <summary>
        /// Hands free audio/video minor class type.
        /// </summary>
        AudioVideoHandsFree = 0x08,
        /// <summary>
        /// Microphone audio/video minor class type.
        /// </summary>
        AudioVideoMicrophone = 0x10,
        /// <summary>
        /// Loudspeaker audio/video minor class type.
        /// </summary>
        AudioVideoLoudspeaker = 0x14,
        /// <summary>
        /// Headphones audio/video minor class type.
        /// </summary>
        AudioVideoHeadphones = 0x18,
        /// <summary>
        /// Portable audio audio/video minor class type.
        /// </summary>
        AudioVideoPortableAudio = 0x1C,
        /// <summary>
        /// Car audio audio/video minor class type.
        /// </summary>
        AudioVideoCarAudio = 0x20,
        /// <summary>
        /// SetTopbox audio/video minor class type.
        /// </summary>
        AudioVideoSetTopBox = 0x24,
        /// <summary>
        /// Hifi audio audio/video minor class type.
        /// </summary>
        AudioVideoHifiAudioDevice = 0x28,
        /// <summary>
        /// VCR audio/video minor class type.
        /// </summary>
        AudioVideoVcr = 0x2C,
        /// <summary>
        /// Video camera audio/video minor class type.
        /// </summary>
        AudioVideoVideoCamera = 0x30,
        /// <summary>
        /// Camcorder audio/video minor class type.
        /// </summary>
        AudioVideoCamcorder = 0x34,
        /// <summary>
        /// Video monitor audio/video minor class type.
        /// </summary>
        AudioVideoVideoMonitor = 0x38,
        /// <summary>
        /// Video display and loudspeaker audio/video minor class type.
        /// </summary>
        AudioVideoVideoDisplayLoudspeaker = 0x3C,
        /// <summary>
        /// Video conferencing audio/video minor class type.
        /// </summary>
        AudioVideoVideoConferencing = 0x40,
        /// <summary>
        /// Gaming/toy audio/video minor class type.
        /// </summary>
        AudioVideoGamingToy = 0x48,

        /// <summary>
        /// Uncategorized peripheral minor class type.
        /// </summary>
        PeripheralUncategorized = 0x00,
        /// <summary>
        /// Keyboard peripheral minor class type.
        /// </summary>
        PeripheralKeyBoard = 0x40,
        /// <summary>
        /// Pointing device peripheral minor class type.
        /// </summary>
        PeripheralPointingDevice = 0x80,
        /// <summary>
        /// Combo keyboard peripheral minor class type.
        /// </summary>
        PeripheralComboKeyboardPointingDevice = 0xC0,
        /// <summary>
        /// Joystick peripheral minor class type.
        /// </summary>
        PeripheralJoystick = 0x04,
        /// <summary>
        /// Game pad peripheral minor class type.
        /// </summary>
        PeripheralGamePad = 0x08,
        /// <summary>
        /// Remote control peripheral minor class type.
        /// </summary>
        PeripheralRemoteControl = 0x0C,
        /// <summary>
        /// Sensing device peripheral minor class type.
        /// </summary>
        PeripheralSensingDevice = 0x10,
        /// <summary>
        /// Digitizer peripheral minor class type.
        /// </summary>
        PeripheralDigitizerTablet = 0x14,
        /// <summary>
        /// Card reader peripheral minor class type.
        /// </summary>
        PeripheralCardReader = 0x18,
        /// <summary>
        /// Digital pen peripheral minor class type.
        /// </summary>
        PeripheralDigitalPen = 0x1C,
        /// <summary>
        /// Handheld scanner peripheral minor class type.
        /// </summary>
        PeripheralHandheldScanner = 0x20,
        /// <summary>
        /// Handheld gestural input computer minor class type.
        /// </summary>
        PeripheralHandheldGesturalInputDevice = 0x24,

        /// <summary>
        /// Display imaging minor class type.
        /// </summary>
        ImagingDisplay = 0x10,
        /// <summary>
        /// Camera imaging minor class type.
        /// </summary>
        ImagingCamera = 0x20,
        /// <summary>
        /// Scanner imaging minor class type.
        /// </summary>
        ImagingScanner = 0x40,
        /// <summary>
        /// Printer imaging minor class type.
        /// </summary>
        ImagingPrinter = 0x80,

        /// <summary>
        /// Wrist watch wearable minor class type.
        /// </summary>
        WearableWristWatch = 0x04,
        /// <summary>
        /// Pager wearable minor class type.
        /// </summary>
        WearablePager = 0x08,
        /// <summary>
        /// Jacket wearable minor class type.
        /// </summary>
        WearableJacket = 0x0C,
        /// <summary>
        /// Helmet wearable minor class type.
        /// </summary>
        WearableHelmet = 0x10,
        /// <summary>
        /// Glasses wearable minor class type.
        /// </summary>
        WearableGlasses = 0x14,

        /// <summary>
        /// Robot toy minor class type.
        /// </summary>
        ToyRobot = 0x04,
        /// <summary>
        /// Vehicle toy minor class type.
        /// </summary>
        ToyVehicle = 0x08,
        /// <summary>
        /// Doll toy minor class type.
        /// </summary>
        ToyDollAction = 0x0C,
        /// <summary>
        /// Controller toy minor class type.
        /// </summary>
        ToyController = 0x10,
        /// <summary>
        /// Game toy minor class type.
        /// </summary>
        ToyGame = 0x14,

        /// <summary>
        /// Uncategorized health minor class type.
        /// </summary>
        HealthUncategorized = 0x00,
        /// <summary>
        /// BP monitor health minor class type.
        /// </summary>
        HealthBloodPressureMonitor = 0x04,
        /// <summary>
        /// Thermometer health minor class type.
        /// </summary>
        HealthThermometer = 0x08,
        /// <summary>
        /// Scale health minor class type.
        /// </summary>
        HealthWeighingScale = 0x0C,
        /// <summary>
        /// Glucose meter health minor class type.
        /// </summary>
        HealthGlucoseMeter= 0x10,
        /// <summary>
        /// Pulse oximeter health minor class type.
        /// </summary>
        HealthPulseOximeter = 0x14,
        /// <summary>
        /// Heart/Pulse rate monitor health minor class type.
        /// </summary>
        HealthHeartPulseRateMonitor = 0x18,
        /// <summary>
        /// Display health minor class type.
        /// </summary>
        HealthDataDisplay = 0x1C,
        /// <summary>
        /// Step counter health minor class type.
        /// </summary>
        HealthStepCounter = 0x20,
        /// <summary>
        /// Body composition analyzer health minor class type.
        /// </summary>
        HealthBodyCompositionAnalyzer = 0x24,
        /// <summary>
        /// Peak flow monitor health minor class type.
        /// </summary>
        HealthPeakFlowMonitor = 0x28,
        /// <summary>
        /// Medication monitor health minor class type.
        /// </summary>
        HealthMedicationMonitor = 0x2C,
        /// <summary>
        /// Knee prosthesis health minor class type.
        /// </summary>
        HealthKneeProsthesis = 0x30,
        /// <summary>
        /// Ankle prosthesis health minor class type.
        /// </summary>
        HealthAnkleProsthesis = 0x34
    }

    /// <summary>
    /// Enumeration for Bluetooth device discovery state.
    /// </summary>
    public enum BluetoothDeviceDiscoveryState
    {
        /// <summary>
        /// Device discovery is started.
        /// </summary>
        Started = 0,
        /// <summary>
        /// Device discovery is finished.
        /// </summary>
        Finished,
        /// <summary>
        /// The remote device is found.
        /// </summary>
        Found
    }

    /// <summary>
    /// Enumeration for Bluetooth appearance type.
    /// </summary>
    public enum BluetoothAppearanceType
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Generic phone.
        /// </summary>
        GenericPhone = 1,
        /// <summary>
        /// Generic computer.
        /// </summary>
        GenericComputer = 2,
        /// <summary>
        /// Generic watch.
        /// </summary>
        GenericWatch = 3
    }

    /// <summary>
    /// Enumeration for Bluetooth audio profile type.
    /// </summary>
    public enum BluetoothAudioProfileType
    {
        /// <summary>
        /// All supported profiles of audio.
        /// </summary>
        All = 0,
        /// <summary>
        /// Headset and Hands-Free profile.
        /// </summary>
        HspHfp,
        /// <summary>
        /// Advanced audio distribution profile.
        /// </summary>
        AdvancedAudioDistribution,
        /// <summary>
        /// Audio Gateway profile.
        /// </summary>
        AudioGateway,
        /// <summary>
        /// Advanced Audio Distribution profile sink role.
        /// </summary>
        AdvancedAudioDistributionSink
    }

    /// <summary>
    /// Enumeration for Bluetooth service class type.
    /// </summary>
    public enum BluetoothServiceClassType
    {
        /// <summary>
        /// No service class.
        /// </summary>
        None = 0,
        /// <summary>
        /// Res service class.
        /// </summary>
        Res = 0x00000001,
        /// <summary>
        /// Spp service class.
        /// </summary>
        Spp = 0x00000002,
        /// <summary>
        /// Dun service class.
        /// </summary>
        Dun = 0x00000004,
        /// <summary>
        /// Fax service class.
        /// </summary>
        Fax = 0x00000008,
        /// <summary>
        /// Lap service class.
        /// </summary>
        Lap = 0x00000010,
        /// <summary>
        /// Hsp service class.
        /// </summary>
        Hsp = 0x00000020,
        /// <summary>
        /// Hfp service class.
        /// </summary>
        Hfp = 0x00000040,
        /// <summary>
        /// Opp service class.
        /// </summary>
        Opp = 0x00000080,
        /// <summary>
        /// Ftp service class.
        /// </summary>
        Ftp = 0x00000100,
        /// <summary>
        /// Ctp service class.
        /// </summary>
        Ctp = 0x00000200,
        /// <summary>
        /// Icp service class.
        /// </summary>
        Icp = 0x00000400,
        /// <summary>
        /// Sync service class.
        /// </summary>
        Sync = 0x00000800,
        /// <summary>
        /// Bpp service class.
        /// </summary>
        Bpp = 0x00001000,
        /// <summary>
        /// Bip service class.
        /// </summary>
        Bip = 0x00002000,
        /// <summary>
        /// Panu service class.
        /// </summary>
        Panu = 0x00004000,
        /// <summary>
        /// Nap service class.
        /// </summary>
        Nap = 0x00008000,
        /// <summary>
        /// Gn service class.
        /// </summary>
        Gn = 0x00010000,
        /// <summary>
        /// Sap service class.
        /// </summary>
        Sap = 0x00020000,
        /// <summary>
        /// A2dp service class.
        /// </summary>
        A2dp = 0x00040000,
        /// <summary>
        /// Avrcp service class.
        /// </summary>
        Avrcp = 0x00080000,
        /// <summary>
        /// Pbap service class.
        /// </summary>
        Pbap = 0x00100000,
        /// <summary>
        /// Hid service class.
        /// </summary>
        Hid = 0x00200000,
        /// <summary>
        /// A2dp Source service class.
        /// </summary>
        A2dpSource = 0x00400000,
        /// <summary>
        /// All service class.
        /// </summary>
        All = 0x00FFFFFF,
        /// <summary>
        /// Max service class.
        /// </summary>
        Max
    }

    /// <summary>
    /// Enumeration for Bluetooth profile type.
    /// </summary>
    public enum BluetoothProfileType
    {
        /// <summary>
        /// Rfcomm profile.
        /// </summary>
        Rfcomm = 0,
        /// <summary>
        /// Advanced Audio Distribution Profile Source role
        /// </summary>
        AdvancedAudioDistribution,
        /// <summary>
        /// Headset profile.
        /// </summary>
        Headset,
        /// <summary>
        /// Human Interface Device profile.
        /// </summary>
        HumanInterfaceDevice,
        /// <summary>
        /// Network Access Point profile.
        /// </summary>
        NetworkAccessPoint,
        /// <summary>
        /// Audio Gateway profile.
        /// </summary>
        AudioGateway,
        /// <summary>
        /// Generic Attribute profile.
        /// </summary>
        GenericAttribute,
        /// <summary>
        /// Nap Server profile.
        /// </summary>
        NapServer,
        /// <summary>
        /// Advanced Audio Distribution profile sink role.
        /// </summary>
        AdvancedAudioDistributionSink
    }

    /// <summary>
    /// Enumeration for Bluetooth authorization type.
    /// </summary>
    public enum BluetoothAuthorizationType
    {
        /// <summary>
        /// Authorized type.
        /// </summary>
        Authorized = 0,
        /// <summary>
        /// Unauthorized type.
        /// </summary>
        Unauthorized
    }

    /// <summary>
    /// Enumeration for Bluetooth connection link type.
    /// </summary>
    public enum BluetoothConnectionLinkType
    {
        /// <summary>
        /// BR/EDR link.
        /// </summary>
        BrEdr = 0,
        /// <summary>
        /// LE link.
        /// </summary>
        Le,
        /// <summary>
        /// The default connection type.
        /// </summary>
        Default
    }

    /// <summary>
    /// Enumeration for Bluetooth disconnect reason.
    /// </summary>
    public enum BluetoothDisconnectReason
    {
        /// <summary>
        /// Disconnected by unknown reason.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Disconnected by timeout.
        /// </summary>
        Timeout,
        /// <summary>
        /// Disconnected by local host.
        /// </summary>
        LocalHost,
        /// <summary>
        /// Disconnected by remote.
        /// </summary>
        Remote
    }

    /// <summary>
    /// Enumerations of connected Bluetooth device event role.
    /// </summary>
    public enum BluetoothSocketRole
    {
        /// <summary>
        /// Unknown role.
        /// </summary>
        Unknown,
        /// <summary>
        /// Server role.
        /// </summary>
        Server,
        /// <summary>
        /// Client role.
        /// </summary>
        Client
    }

    /// <summary>
    /// Enumerations of Bluetooth socket connection state.
    /// </summary>
    public enum BluetoothSocketState
    {
        /// <summary>
        /// RFCOMM is connected.
        /// </summary>
        Connected,
        /// <summary>
        /// RFCOMM is disconnected.
        /// </summary>
        Disconnected
    }

    /// <summary>
    /// Enumeration for equalizer state.
    /// </summary>
    public enum EqualizerState
    {
        /// <summary>
        /// Equalizer Off.
        /// </summary>
        Off = 0,
        /// <summary>
        /// Equalizer On.
        /// </summary>
        On
    }

    /// <summary>
    /// Enumeration for repeat mode.
    /// </summary>
    public enum RepeatMode
    {
        /// <summary>
        /// Repeat off.
        /// </summary>
        Off = 0,
        /// <summary>
        /// Single track repeat.
        /// </summary>
        SingleTrack,
        /// <summary>
        /// All track repeat.
        /// </summary>
        AllTrack,
        /// <summary>
        /// Group repeat.
        /// </summary>
        Group
    }

    /// <summary>
    /// Enumeration for shuffle mode.
    /// </summary>
    public enum ShuffleMode
    {
        /// <summary>
        /// Shuffle off.
        /// </summary>
        Off = 0,
        /// <summary>
        /// All tracks shuffle.
        /// </summary>
        AllTrack,
        /// <summary>
        /// Group shuffle.
        /// </summary>
        Group
    }

    /// <summary>
    /// Enumeration for scan mode.
    /// </summary>
    public enum ScanMode
    {
        /// <summary>
        /// Scan off.
        /// </summary>
        Off = 0,
        /// <summary>
        /// All tracks scan.
        /// </summary>
        AllTrack,
        /// <summary>
        /// Group scan.
        /// </summary>
        Group
    }

    /// <summary>
    /// Enumeration for player state.
    /// </summary>
    public enum PlayerState
    {
        /// <summary>
        /// Stopped state.
        /// </summary>
        Stopped = 0,
        /// <summary>
        /// Playing state.
        /// </summary>
        Playing,
        /// <summary>
        /// Paused state.
        /// </summary>
        Paused,
        /// <summary>
        /// Seek forward state.
        /// </summary>
        SeekForward,
        /// <summary>
        /// Seek rewind state.
        /// </summary>
        SeekRewind
    }

    /// <summary>
    /// Enumeration for Bluetooth Le device address type.
    /// </summary>
    public enum BluetoothLeDeviceAddressType
    {
        /// <summary>
        /// The bluetooth le public address.
        /// </summary>
        BluetoothLePublicAddress,
        /// <summary>
        /// The bluetooth le private address.
        /// </summary>
        BluetoothLePrivateAddress
    }

    /// <summary>
    /// Enumeration for Bluetooth LePacket type.
    /// </summary>
    public enum BluetoothLePacketType
    {
        /// <summary>
        /// The bluetooth le advertising packet.
        /// </summary>
        BluetoothLeAdvertisingPacket,
        /// <summary>
        /// The bluetooth le scan response packet.
        /// </summary>
        BluetoothLeScanResponsePacket
    }

    /// <summary>
    /// Enumeration for Bluetooth Le data type.
    /// </summary>
    public enum BluetoothLeDataType
    {
        /// <summary>
        /// The bluetooth le packet data list 16 bit service uuid.
        /// </summary>
        BluetoothLePacketDataList16BitServiceUuid,
        /// <summary>
        /// The bluetooth le packet manufacturer data.
        /// </summary>
        BluetoothLePacketManufacturerData
    }

    /// <summary>
    /// Enumeration for Bluetooth Le Advertising mode type.
    /// </summary>
    public enum BluetoothLeAdvertisingMode
    {
        /// <summary>
        /// The bluetooth le advertising balanced mode.
        /// </summary>
        BluetoothLeAdvertisingBalancedMode,
        /// <summary>
        /// The bluetooth le advertising low latency mode.
        /// </summary>
        BluetoothLeAdvertisingLowLatencyMode,
        /// <summary>
        /// The bluetooth le advertising low energy mode.
        /// </summary>
        BluetoothLeAdvertisingLowEnergyMode
    }

    /// <summary>
    /// Enumeration for Bluetooth Le Advertising mode type.
    /// </summary>
    public enum BluetoothLeAdvertisingState
    {
        /// <summary>
        /// The bluetooth le advertising stopped.
        /// </summary>
        BluetoothLeAdvertisingStopped,
        /// <summary>
        /// The bluetooth le advertising started.
        /// </summary>
        BluetoothLeAdvertisingStarted
    }

    /// <summary>
    /// Enumerations of the integer type for GATT handle's value.
    /// </summary>
    public enum IntDataType
    {
        /// <summary>
        /// 8 bit signed int type.
        /// </summary>
        SignedInt8,
        /// <summary>
        /// 16 bit signed int type.
        /// </summary>
        SignedInt16,
        /// <summary>
        /// 32 bit signed int type.
        /// </summary>
        SignedInt32,
        /// <summary>
        /// 8 bit unsigned int type.
        /// </summary>
        UnsignedInt8,
        /// <summary>
        /// 16 bit unsigned int type.
        /// </summary>
        UnsignedInt16,
        /// <summary>
        /// 32 bit unsigned int type.
        /// </summary>
        UnsignedInt32
    }

    /// <summary>
    /// Enumerations of the float type for GATT handle's value.
    /// </summary>
    public enum FloatDataType
    {
        /// <summary>
        /// 32 bit float type.
        /// </summary>
        Float,
        /// <summary>
        /// 16 bit float type.
        /// </summary>
        SFloat,
    }

    /// <summary>
    /// Enumerations of the GATT handle's type.
    /// </summary>
    public enum GattHandleType
    {
        /// <summary>
        /// GATT service type.
        /// </summary>
        Service,
        /// <summary>
        /// GATT characteristic type.
        /// </summary>
        Characteristic,
        /// <summary>
        /// GATT descriptor type.
        /// </summary>
        Descriptor
    }

    /// <summary>
    /// Enumerations of the service type.
    /// </summary>
    public enum BluetoothGattServiceType
    {
        /// <summary>
        /// GATT primary service type.
        /// </summary>
        Primary,
        /// <summary>
        /// GATT secondary service type.
        /// </summary>
        Secondary
    }

    /// <summary>
    /// Enumerations of the characteristic's property.
    /// </summary>
    [Flags]
    public enum BluetoothGattProperty
    {
        /// <summary>
        /// Broadcast property.
        /// </summary>
        Broadcast = 1,
        /// <summary>
        /// Read property.
        /// </summary>
        Read = 2,
        /// <summary>
        /// Write without response property.
        /// </summary>
        WriteWithoutResponse = 4,
        /// <summary>
        /// Write property.
        /// </summary>
        Write = 8,
        /// <summary>
        /// Notify property.
        /// </summary>
        Notify = 16,
        /// <summary>
        /// Indicate property.
        /// </summary>
        Indicate = 32,
        /// <summary>
        /// Authenticated signed writes property.
        /// </summary>
        AuthenticatedSignedWrites = 64,
        /// <summary>
        /// Extended properties.
        /// </summary>
        ExtendedProperties = 128,
    }

    /// <summary>
    /// Enumerations of bluetooth gatt permission type.
    /// </summary>
    [Flags]
    public enum BluetoothGattPermission
    {
        /// <summary>
        /// Read permission.
        /// </summary>
        Read = 1,
        /// <summary>
        /// Write permission.
        /// </summary>
        Write = 2,
    }

    /// <summary>
    /// Enumerations of the write type.
    /// </summary>
    public enum BluetoothGattWriteType
    {
        /// <summary>
        /// Write without response.
        /// </summary>
        NoResponse,
        /// <summary>
        /// Write with response.
        /// </summary>
        WriteWithResponse
    }
}
