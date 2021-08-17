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
using System.ComponentModel;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// Enumeration for the Bluetooth states.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothState
    {
        /// <summary>
        /// The disabled state.
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// The enabled state.
        /// </summary>
        Enabled
    }

    /// <summary>
    /// Enumeration for the Bluetooth errors.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothError
    {
        /// <summary>
        /// Successful.
        /// </summary>
        None = ErrorCode.None,
        /// <summary>
        /// Operation canceled.
        /// </summary>
        Cancelled = ErrorCode.Canceled,
        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter = ErrorCode.InvalidParameter,
        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = ErrorCode.OutOfMemory,
        /// <summary>
        /// Device or resource busy.
        /// </summary>
        ResourceBusy = ErrorCode.ResourceBusy,
        /// <summary>
        /// Timeout error.
        /// </summary>
        TimedOut = ErrorCode.TimedOut,
        /// <summary>
        /// Operation now in progress.
        /// </summary>
        NowInProgress = ErrorCode.NowInProgress,
        /// <summary>
        /// Bluetooth is not supported.
        /// </summary>
        NotSupported = ErrorCode.NotSupported,
        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied = ErrorCode.PermissionDenied,
        /// <summary>
        /// Quota exceeded.
        /// </summary>
        QuotaExceeded = ErrorCode.QuotaExceeded,
        /// <summary>
        /// No data available.
        /// </summary>
        NoData = ErrorCode.NoData,
        /// <summary>
        /// Local adapter not initialized.
        /// </summary>
        NotInitialized = -0x01C00000 | 0x0101,
        /// <summary>
        /// Local adapter not enabled.
        /// </summary>
        NotEnabled = -0x01C00000 | 0x0102,
        /// <summary>
        /// Operation already done.
        /// </summary>
        AlreadyDone = -0x01C00000 | 0x0103,
        /// <summary>
        /// Operation failed.
        /// </summary>
        OperationFailed = -0x01C00000 | 0x0104,
        /// <summary>
        /// Operation not in progress.
        /// </summary>
        NotInProgress = -0x01C00000 | 0x0105,
        /// <summary>
        /// Remote device not bonded.
        /// </summary>
        RemoteDeviceNotBonded = -0x01C00000 | 0x0106,
        /// <summary>
        /// Authentication rejected.
        /// </summary>
        AuthRejected = -0x01C00000 | 0x0107,
        /// <summary>
        /// Authentication failed.
        /// </summary>
        AuthFailed = -0x01C00000 | 0x0108,
        /// <summary>
        /// Remote device not found.
        /// </summary>
        RemoteDeviceNotFound = -0x01C00000 | 0x0109,
        /// <summary>
        /// Service search failed.
        /// </summary>
        ServiceSearchFailed = -0x01C00000 | 0x010A,
        /// <summary>
        /// Remote device is not connected.
        /// </summary>
        RemoteDeviceNotConnected = -0x01C00000 | 0x010B,
        /// <summary>
        /// Resource temporarily unavailable.
        /// </summary>
        ResourceUnavailable = -0x01C00000 | 0x010C,
        /// <summary>
        /// Service Not Found.
        /// </summary>
        ServiceNotFound = -0x01C00000 | 0x010D
    }

    /// <summary>
    /// Enumeration for the Bluetooth visibility modes.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum VisibilityMode
    {
        /// <summary>
        /// The non-discoverable mode.
        /// </summary>
        NonDiscoverable = 0,
        /// <summary>
        /// The discoverable mode.
        /// </summary>
        Discoverable = 1,
        /// <summary>
        /// The discoverable mode with limited time.
        /// </summary>
        TimeLimitedDiscoverable = 2
    }

    /// <summary>
    /// Enumeration for the Bluetooth major device class types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothMajorDeviceClassType
    {
        /// <summary>
        /// The miscellaneous major class type.
        /// </summary>
        Misc = 0x00,
        /// <summary>
        /// The computer major class type.
        /// </summary>
        Computer = 0x01,
        /// <summary>
        /// The phone major class type.
        /// </summary>
        Phone = 0x02,
        /// <summary>
        /// The LAN/Network access point major class type.
        /// </summary>
        LanNetworkAccessPoint = 0x03,
        /// <summary>
        /// The audio/video major class type.
        /// </summary>
        AudioVideo = 0x04,
        /// <summary>
        /// The peripheral major class type.
        /// </summary>
        Peripheral = 0x05,
        /// <summary>
        /// The imaging major class type.
        /// </summary>
        Imaging = 0x06,
        /// <summary>
        /// The wearable major class type.
        /// </summary>
        Wearable = 0x07,
        /// <summary>
        /// The toy major class type.
        /// </summary>
        Toy = 0x08,
        /// <summary>
        /// The health major class type.
        /// </summary>
        Health = 0x09,
        /// <summary>
        /// The uncategorized major class type.
        /// </summary>
        Uncategorized = 0x1F
    }

    /// <summary>
    /// Enumeration for the Bluetooth minor device class types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothMinorDeviceClassType
    {
        /// <summary>
        /// The uncategorized computer minor class type.
        /// </summary>
        ComputerUncategorized = 0x00,
        /// <summary>
        /// The desktop workstation computer minor class type.
        /// </summary>
        ComputerDesktopWorkstation = 0x04,
        /// <summary>
        /// The server computer minor class type.
        /// </summary>
        ComputerServer = 0x08,
        /// <summary>
        /// The laptop computer minor class type.
        /// </summary>
        ComputerLaptop = 0x0C,
        /// <summary>
        /// The handheld PC/PDA computer minor class type.
        /// </summary>
        ComputerHandheldPcOrPda = 0x10,
        /// <summary>
        /// The palm sized PC/PDA computer minor class type.
        /// </summary>
        ComputerPalmSizedPcOrPda = 0x14,
        /// <summary>
        /// The wearable computer minor class type.
        /// </summary>
        ComputerWearableComputer = 0x18,

        /// <summary>
        /// The unclassified phone minor class type.
        /// </summary>
        PhoneUncategorized = 0x00,
        /// <summary>
        /// The cellular phone minor class type.
        /// </summary>
        PhoneCellular = 0x04,
        /// <summary>
        /// The cordless phone minor class type.
        /// </summary>
        PhoneCordless = 0x08,
        /// <summary>
        /// The smartphone phone minor class type.
        /// </summary>
        PhoneSmartPhone = 0x0C,
        /// <summary>
        /// The wired modem or voice gateway phone minor class type.
        /// </summary>
        PhoneWiredModemOrVoiceGateway = 0x10,
        /// <summary>
        /// The ISDN phone minor class type.
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
        /// The uncategorized audio/video minor class type.
        /// </summary>
        AudioVideoUncategorized = 0x00,
        /// <summary>
        /// The wearable headset audio/video minor class type.
        /// </summary>
        AudioVideoWearableHeadset = 0x04,
        /// <summary>
        /// The hands free audio/video minor class type.
        /// </summary>
        AudioVideoHandsFree = 0x08,
        /// <summary>
        /// The microphone audio/video minor class type.
        /// </summary>
        AudioVideoMicrophone = 0x10,
        /// <summary>
        /// The loudspeaker audio/video minor class type.
        /// </summary>
        AudioVideoLoudspeaker = 0x14,
        /// <summary>
        /// The headphones audio/video minor class type.
        /// </summary>
        AudioVideoHeadphones = 0x18,
        /// <summary>
        /// The portable audio audio/video minor class type.
        /// </summary>
        AudioVideoPortableAudio = 0x1C,
        /// <summary>
        /// The car audio audio/video minor class type.
        /// </summary>
        AudioVideoCarAudio = 0x20,
        /// <summary>
        /// The SetTopbox audio/video minor class type.
        /// </summary>
        AudioVideoSetTopBox = 0x24,
        /// <summary>
        /// The Hi-Fi audio/video minor class type.
        /// </summary>
        AudioVideoHifiAudioDevice = 0x28,
        /// <summary>
        /// The VCR audio/video minor class type.
        /// </summary>
        AudioVideoVcr = 0x2C,
        /// <summary>
        /// The video camera audio/video minor class type.
        /// </summary>
        AudioVideoVideoCamera = 0x30,
        /// <summary>
        /// Camcorder audio/video minor class type.
        /// </summary>
        AudioVideoCamcorder = 0x34,
        /// <summary>
        /// The video monitor audio/video minor class type.
        /// </summary>
        AudioVideoVideoMonitor = 0x38,
        /// <summary>
        /// The video display and loudspeaker audio/video minor class type.
        /// </summary>
        AudioVideoVideoDisplayLoudspeaker = 0x3C,
        /// <summary>
        /// The video conferencing audio/video minor class type.
        /// </summary>
        AudioVideoVideoConferencing = 0x40,
        /// <summary>
        /// The gaming/toy audio/video minor class type.
        /// </summary>
        AudioVideoGamingToy = 0x48,

        /// <summary>
        /// The uncategorized peripheral minor class type.
        /// </summary>
        PeripheralUncategorized = 0x00,
        /// <summary>
        /// The keyboard peripheral minor class type.
        /// </summary>
        PeripheralKeyBoard = 0x40,
        /// <summary>
        /// The pointing device peripheral minor class type.
        /// </summary>
        PeripheralPointingDevice = 0x80,
        /// <summary>
        /// The combo keyboard peripheral minor class type.
        /// </summary>
        PeripheralComboKeyboardPointingDevice = 0xC0,
        /// <summary>
        /// The joystick peripheral minor class type.
        /// </summary>
        PeripheralJoystick = 0x04,
        /// <summary>
        /// The game pad peripheral minor class type.
        /// </summary>
        PeripheralGamePad = 0x08,
        /// <summary>
        /// The remote control peripheral minor class type.
        /// </summary>
        PeripheralRemoteControl = 0x0C,
        /// <summary>
        /// The sensing device peripheral minor class type.
        /// </summary>
        PeripheralSensingDevice = 0x10,
        /// <summary>
        /// The digitizer peripheral minor class type.
        /// </summary>
        PeripheralDigitizerTablet = 0x14,
        /// <summary>
        /// The card reader peripheral minor class type.
        /// </summary>
        PeripheralCardReader = 0x18,
        /// <summary>
        /// The digital pen peripheral minor class type.
        /// </summary>
        PeripheralDigitalPen = 0x1C,
        /// <summary>
        /// The handheld scanner peripheral minor class type.
        /// </summary>
        PeripheralHandheldScanner = 0x20,
        /// <summary>
        /// The handheld gestural input computer minor class type.
        /// </summary>
        PeripheralHandheldGesturalInputDevice = 0x24,

        /// <summary>
        /// The display imaging minor class type.
        /// </summary>
        ImagingDisplay = 0x10,
        /// <summary>
        /// The camera imaging minor class type.
        /// </summary>
        ImagingCamera = 0x20,
        /// <summary>
        /// The scanner imaging minor class type.
        /// </summary>
        ImagingScanner = 0x40,
        /// <summary>
        /// The printer imaging minor class type.
        /// </summary>
        ImagingPrinter = 0x80,

        /// <summary>
        /// The wrist watch wearable minor class type.
        /// </summary>
        WearableWristWatch = 0x04,
        /// <summary>
        /// The pager wearable minor class type.
        /// </summary>
        WearablePager = 0x08,
        /// <summary>
        /// The jacket wearable minor class type.
        /// </summary>
        WearableJacket = 0x0C,
        /// <summary>
        /// The helmet wearable minor class type.
        /// </summary>
        WearableHelmet = 0x10,
        /// <summary>
        /// The glasses wearable minor class type.
        /// </summary>
        WearableGlasses = 0x14,

        /// <summary>
        /// The robot toy minor class type.
        /// </summary>
        ToyRobot = 0x04,
        /// <summary>
        /// The vehicle toy minor class type.
        /// </summary>
        ToyVehicle = 0x08,
        /// <summary>
        /// The doll toy minor class type.
        /// </summary>
        ToyDollAction = 0x0C,
        /// <summary>
        /// The controller toy minor class type.
        /// </summary>
        ToyController = 0x10,
        /// <summary>
        /// The game toy minor class type.
        /// </summary>
        ToyGame = 0x14,

        /// <summary>
        /// The uncategorized health minor class type.
        /// </summary>
        HealthUncategorized = 0x00,
        /// <summary>
        /// The BP monitor health minor class type.
        /// </summary>
        HealthBloodPressureMonitor = 0x04,
        /// <summary>
        /// The thermometer health minor class type.
        /// </summary>
        HealthThermometer = 0x08,
        /// <summary>
        /// The scale health minor class type.
        /// </summary>
        HealthWeighingScale = 0x0C,
        /// <summary>
        /// The glucose meter health minor class type.
        /// </summary>
        HealthGlucoseMeter= 0x10,
        /// <summary>
        /// The pulse oximeter health minor class type.
        /// </summary>
        HealthPulseOximeter = 0x14,
        /// <summary>
        /// The heart/pulse rate monitor health minor class type.
        /// </summary>
        HealthHeartPulseRateMonitor = 0x18,
        /// <summary>
        /// The display health minor class type.
        /// </summary>
        HealthDataDisplay = 0x1C,
        /// <summary>
        /// The step counter health minor class type.
        /// </summary>
        HealthStepCounter = 0x20,
        /// <summary>
        /// The body composition analyzer health minor class type.
        /// </summary>
        HealthBodyCompositionAnalyzer = 0x24,
        /// <summary>
        /// The peak flow monitor health minor class type.
        /// </summary>
        HealthPeakFlowMonitor = 0x28,
        /// <summary>
        /// The medication monitor health minor class type.
        /// </summary>
        HealthMedicationMonitor = 0x2C,
        /// <summary>
        /// The knee prosthesis health minor class type.
        /// </summary>
        HealthKneeProsthesis = 0x30,
        /// <summary>
        /// The ankle prosthesis health minor class type.
        /// </summary>
        HealthAnkleProsthesis = 0x34
    }

    /// <summary>
    /// Enumeration for the Bluetooth device discovery states.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothDeviceDiscoveryState
    {
        /// <summary>
        /// The device discovery is started.
        /// </summary>
        Started = 0,
        /// <summary>
        /// The device discovery is finished.
        /// </summary>
        Finished,
        /// <summary>
        /// The remote device is found.
        /// </summary>
        Found
    }

    /// <summary>
    /// Enumeration for the Bluetooth appearance types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Enumeration for the Bluetooth audio profile types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothAudioProfileType
    {
        /// <summary>
        /// All supported profiles of audio.
        /// </summary>
        All = 0,
        /// <summary>
        /// The Headset and Hands-Free profile.
        /// </summary>
        HspHfp,
        /// <summary>
        /// The Advanced Audio Distribution profile.
        /// </summary>
        AdvancedAudioDistribution,
        /// <summary>
        /// The Audio Gateway profile.
        /// </summary>
        AudioGateway,
        /// <summary>
        /// The Advanced Audio Distribution profile sink role.
        /// </summary>
        AdvancedAudioDistributionSink
    }

    /// <summary>
    /// Enumeration for the Bluetooth audio role.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum BluetoothAudioRole
    {
        /// <summary>
        /// The source role.
        /// </summary>
        Source = 0,
        /// <summary>
        /// The sink role.
        /// </summary>
        Sink,
    }

    /// <summary>
    /// Enumeration for the Bluetooth service class types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothServiceClassType
    {
        /// <summary>
        /// No service class.
        /// </summary>
        None = 0,
        /// <summary>
        /// The RES service class.
        /// </summary>
        Res = 0x00000001,
        /// <summary>
        /// The SPP service class.
        /// </summary>
        Spp = 0x00000002,
        /// <summary>
        /// The DUN service class.
        /// </summary>
        Dun = 0x00000004,
        /// <summary>
        /// The FAX service class.
        /// </summary>
        Fax = 0x00000008,
        /// <summary>
        /// The LAP service class.
        /// </summary>
        Lap = 0x00000010,
        /// <summary>
        /// The HSP service class.
        /// </summary>
        Hsp = 0x00000020,
        /// <summary>
        /// The HFPservice class.
        /// </summary>
        Hfp = 0x00000040,
        /// <summary>
        /// The OPP service class.
        /// </summary>
        Opp = 0x00000080,
        /// <summary>
        /// The FTP service class.
        /// </summary>
        Ftp = 0x00000100,
        /// <summary>
        /// The CTP service class.
        /// </summary>
        Ctp = 0x00000200,
        /// <summary>
        /// The ICP service class.
        /// </summary>
        Icp = 0x00000400,
        /// <summary>
        /// The Sync service class.
        /// </summary>
        Sync = 0x00000800,
        /// <summary>
        /// The BPP service class.
        /// </summary>
        Bpp = 0x00001000,
        /// <summary>
        /// The BIP service class.
        /// </summary>
        Bip = 0x00002000,
        /// <summary>
        /// The PANU service class.
        /// </summary>
        Panu = 0x00004000,
        /// <summary>
        /// The NAP service class.
        /// </summary>
        Nap = 0x00008000,
        /// <summary>
        /// The GN service class.
        /// </summary>
        Gn = 0x00010000,
        /// <summary>
        /// The SAP service class.
        /// </summary>
        Sap = 0x00020000,
        /// <summary>
        /// The A2DP service class.
        /// </summary>
        A2dp = 0x00040000,
        /// <summary>
        /// The AVRCP service class.
        /// </summary>
        Avrcp = 0x00080000,
        /// <summary>
        /// The PBAP service class.
        /// </summary>
        Pbap = 0x00100000,
        /// <summary>
        /// The HID service class.
        /// </summary>
        Hid = 0x00200000,
        /// <summary>
        /// The A2DP Source service class.
        /// </summary>
        A2dpSource = 0x00400000,
        /// <summary>
        /// All service class.
        /// </summary>
        All = 0x00FFFFFF,
        /// <summary>
        /// The Max service class.
        /// </summary>
        Max
    }

    /// <summary>
    /// Enumeration for the Bluetooth profile types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothProfileType
    {
        /// <summary>
        /// The RFCOMM profile.
        /// </summary>
        Rfcomm = 0,
        /// <summary>
        /// The Advanced Audio Distribution Profile Source role.
        /// </summary>
        AdvancedAudioDistribution,
        /// <summary>
        /// The Headset profile.
        /// </summary>
        Headset,
        /// <summary>
        /// The Human Interface Device profile.
        /// </summary>
        HumanInterfaceDevice,
        /// <summary>
        /// The Network Access Point profile.
        /// </summary>
        NetworkAccessPoint,
        /// <summary>
        /// The Audio Gateway profile.
        /// </summary>
        AudioGateway,
        /// <summary>
        /// The Generic Attribute profile.
        /// </summary>
        GenericAttribute,
        /// <summary>
        /// The NAP Server profile.
        /// </summary>
        NapServer,
        /// <summary>
        /// The advanced Audio Distribution profile sink role.
        /// </summary>
        AdvancedAudioDistributionSink
    }

    /// <summary>
    /// Enumeration for the Bluetooth authorization types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothAuthorizationType
    {
        /// <summary>
        /// The authorized type.
        /// </summary>
        Authorized = 0,
        /// <summary>
        /// The unauthorized type.
        /// </summary>
        Unauthorized
    }

    /// <summary>
    /// Enumeration for the Bluetooth connection link types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothConnectionLinkType
    {
        /// <summary>
        /// The BR/EDR link.
        /// </summary>
        BrEdr = 0,
        /// <summary>
        /// The LE link.
        /// </summary>
        Le,
        /// <summary>
        /// The default connection type.
        /// </summary>
        Default
    }

    /// <summary>
    /// Enumeration for the Bluetooth disconnect reason.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothDisconnectReason
    {
        /// <summary>
        /// The disconnected by unknown reason.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// The disconnected by timeout.
        /// </summary>
        Timeout,
        /// <summary>
        /// The disconnected by local host.
        /// </summary>
        LocalHost,
        /// <summary>
        /// The disconnected by remote.
        /// </summary>
        Remote
    }

    /// <summary>
    /// Enumeration for the connected Bluetooth device event roles.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothSocketRole
    {
        /// <summary>
        /// Unknown role.
        /// </summary>
        Unknown,
        /// <summary>
        /// The server role.
        /// </summary>
        Server,
        /// <summary>
        /// The client role.
        /// </summary>
        Client
    }

    /// <summary>
    /// Enumeration for the Bluetooth socket connection states.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothSocketState
    {
        /// <summary>
        /// The RFCOMM is connected.
        /// </summary>
        Connected,
        /// <summary>
        /// The RFCOMM is disconnected.
        /// </summary>
        Disconnected
    }

    /// <summary>
    /// Enumeration for the equalizer states.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Enumeration for the repeat modes.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Enumeration for the shuffle modes.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Enumeration for the scan modes.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Enumeration for the player states.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum PlayerState
    {
        /// <summary>
        /// The stopped state.
        /// </summary>
        Stopped = 0,
        /// <summary>
        /// The playing state.
        /// </summary>
        Playing,
        /// <summary>
        /// The paused state.
        /// </summary>
        Paused,
        /// <summary>
        /// The seek forward state.
        /// </summary>
        SeekForward,
        /// <summary>
        /// The seek rewind state.
        /// </summary>
        SeekRewind
    }

    /// <summary>
    /// Enumeration for the player command.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public enum PlayerCommand
    {
        /// <summary>
        /// Play current track
        /// </summary>
        Play = 1,
        /// <summary>
        /// Pause current track
        /// </summary>
        Pause,
        /// <summary>
        /// Stop playing track
        /// </summary>
        Stop,
        /// <summary>
        /// Go to the next track
        /// </summary>
        Next,
        /// <summary>
        /// Go to the previous track
        /// </summary>
        Previous,
        /// <summary>
        /// Fast-forward current track
        /// </summary>
        FastForward,
        /// <summary>
        /// Rewind current track
        /// </summary>
        Rewind
    }

    /// <summary>
    /// Enumeration for the Bluetooth LE device address types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothLeDeviceAddressType
    {
        /// <summary>
        /// The Buetooth LE public address.
        /// </summary>
        BluetoothLePublicAddress,
        /// <summary>
        /// The Bluetooth LE private address.
        /// </summary>
        BluetoothLePrivateAddress
    }

    /// <summary>
    /// Enumeration for the Bluetooth LePacket types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothLePacketType
    {
        /// <summary>
        /// The Bluetooth LE advertising packet.
        /// </summary>
        BluetoothLeAdvertisingPacket,
        /// <summary>
        /// The Bluetooth LE scan response packet.
        /// </summary>
        BluetoothLeScanResponsePacket
    }

    /// <summary>
    /// Enumeration for the Bluetooth LE data types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothLeDataType
    {
        /// <summary>
        /// The Bluetooth LE packet data list 16 bit service uuid.
        /// </summary>
        BluetoothLePacketDataList16BitServiceUuid,
        /// <summary>
        /// The Bluetooth LE packet manufacturer data.
        /// </summary>
        BluetoothLePacketManufacturerData
    }

    /// <summary>
    /// Enumeration for the Bluetooth LE advertising mode types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothLeAdvertisingMode
    {
        /// <summary>
        /// The Bluetooth LE advertising balanced mode.
        /// </summary>
        BluetoothLeAdvertisingBalancedMode,
        /// <summary>
        /// The Bluetooth LE advertising low latency mode.
        /// </summary>
        BluetoothLeAdvertisingLowLatencyMode,
        /// <summary>
        /// The Bluetooth LE advertising low energy mode.
        /// </summary>
        BluetoothLeAdvertisingLowEnergyMode
    }

    /// <summary>
    /// Enumeration for the Bluetooth LE advertising mode type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothLeAdvertisingState
    {
        /// <summary>
        /// The Bluetooth LE advertising stopped.
        /// </summary>
        BluetoothLeAdvertisingStopped,
        /// <summary>
        /// The Bluetooth LE advertising started.
        /// </summary>
        BluetoothLeAdvertisingStarted
    }

    /// <summary>
    /// Enumeration for the Bluetooth LE scan mode.
    /// </summary>
    /// <since_tizen> 7 </since_tizen>
    public enum BluetoothLeScanMode
    {
        /// <summary>
        /// Balanced mode of power consumption and connection latency
        /// </summary>
        Balanced,
        /// <summary>
        /// Low connection latency but high power consumption
        /// </summary>
        LowLatency,
        /// <summary>
        /// Low power consumption but high connection latency
        /// </summary>
        LowEnergy
    }

    /// <summary>
    /// Enumeration for the integer type for GATT handle's values.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum IntDataType
    {
        /// <summary>
        /// The 8-bit signed integer type.
        /// </summary>
        SignedInt8,
        /// <summary>
        /// The 16-bit signed integer type.
        /// </summary>
        SignedInt16,
        /// <summary>
        /// The 32-bit signed integer type.
        /// </summary>
        SignedInt32,
        /// <summary>
        /// The 8-bit unsigned integer type.
        /// </summary>
        UnsignedInt8,
        /// <summary>
        /// The 16-bit unsigned integer type.
        /// </summary>
        UnsignedInt16,
        /// <summary>
        /// The 32-bit unsigned integer type.
        /// </summary>
        UnsignedInt32
    }

    /// <summary>
    /// Enumerations of the float type for GATT handle's values.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum FloatDataType
    {
        /// <summary>
        /// The 32-bit float type.
        /// </summary>
        Float,
        /// <summary>
        /// The 16-bit float type.
        /// </summary>
        SFloat,
    }

    /// <summary>
    /// Enumeration for the GATT handle's types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum GattHandleType
    {
        /// <summary>
        /// The GATT service type.
        /// </summary>
        Service,
        /// <summary>
        /// The GATT characteristic type.
        /// </summary>
        Characteristic,
        /// <summary>
        /// The GATT descriptor type.
        /// </summary>
        Descriptor
    }

    /// <summary>
    /// Enumeration for the service types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothGattServiceType
    {
        /// <summary>
        /// The GATT primary service type.
        /// </summary>
        Primary,
        /// <summary>
        /// The GATT secondary service type.
        /// </summary>
        Secondary
    }

    /// <summary>
    /// Enumeration for the characteristic's property.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Flags]
    public enum BluetoothGattProperty
    {
        /// <summary>
        /// The broadcast property.
        /// </summary>
        Broadcast = 1,
        /// <summary>
        /// The read property.
        /// </summary>
        Read = 2,
        /// <summary>
        /// The write without response property.
        /// </summary>
        WriteWithoutResponse = 4,
        /// <summary>
        /// The write property.
        /// </summary>
        Write = 8,
        /// <summary>
        /// The notify property.
        /// </summary>
        Notify = 16,
        /// <summary>
        /// The indicate property.
        /// </summary>
        Indicate = 32,
        /// <summary>
        /// The authenticated signed writes property.
        /// </summary>
        AuthenticatedSignedWrites = 64,
        /// <summary>
        /// The extended properties.
        /// </summary>
        ExtendedProperties = 128,
    }

    /// <summary>
    /// Enumeration for the Bluetooth GATT permission types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Enumeration for the write types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothGattWriteType
    {
        /// <summary>
        /// The write without response.
        /// </summary>
        NoResponse,
        /// <summary>
        /// The write with response.
        /// </summary>
        WriteWithResponse
    }

    /// <summary>
    /// Enumeration for the remote device request types for attributes.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BluetoothGattRequestType
    {
        /// <summary>
        /// Read requested.
        /// </summary>
        Read = 0,
        /// <summary>
        /// Write requested.
        /// </summary>
        Write = 1,
    }

    /// <summary>
    /// Enumeration for the Bluetooth HID header type.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum BluetoothHidHeaderType
    {
        /// <summary>
        /// The Bluetooth HID header type: Handshake
        /// </summary>
        Handshake,
        /// <summary>
        /// The Bluetooth HID header type: HID control
        /// </summary>
        HidControl,
        /// <summary>
        /// The Bluetooth HID header type: Get report
        /// </summary>
        GetReport,
        /// <summary>
        /// The Bluetooth HID header type: Set report
        /// </summary>
        SetReport,
        /// <summary>
        /// The Bluetooth HID header type: Get protocol
        /// </summary>
        GetProtocol,
        /// <summary>
        /// The Bluetooth HID header type: Set protocol
        /// </summary>
        SetProtocol,
        /// <summary>
        /// The Bluetooth HID header type: Data
        /// </summary>
        Data,
        /// <summary>
        /// The Bluetooth HID header type: Unknown
        /// </summary>
        Unknown
    }

    /// <summary>
    /// Enumeration for the Bluetooth HID parameter type.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum BluetoothHidParamType
    {
        /// <summary>
        /// Parameter type: Input
        /// </summary>
        Input,
        /// <summary>
        /// Parameter type: Output
        /// </summary>
        Output
    }
}
