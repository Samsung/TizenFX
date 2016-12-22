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

namespace Tizen.Network.WiFiDirect
{
    /// <summary>
    /// Enumeration for Wi-Fi Direct discovery state.
    /// </summary>
    public enum WiFiDirectDiscoveryState
    {
        /// <summary>
        /// Only listen has started.
        /// </summary>
        OnlyListenStarted = 0,
        /// <summary>
        /// Discovery started.
        /// </summary>
        Started,
        /// <summary>
        /// A remote peer is found.
        /// </summary>
        Found,
        /// <summary>
        /// Discovery finished.
        /// </summary>
        Finished,
        /// <summary>
        /// A remote peer is lost.
        /// </summary>
        Lost
    }

    /// <summary>
    /// Enumeration for Wi-Fi Direct display device type.
    /// </summary>
    public enum WiFiDirectDisplayType
    {
        /// <summary>
        /// Configure as WFD source.
        /// </summary>
        Source = 0,
        /// <summary>
        /// Configure as WFD primary sink.
        /// </summary>
        Prisink,
        /// <summary>
        /// Configure as WFD secondary sink.
        /// </summary>
        Secsink,
        /// <summary>
        /// Configure as WFD dual role.
        /// </summary>
        Dual
    }

    /// <summary>
    /// Enumeration for Wi-Fi Discovery channel.
    /// </summary>
    public enum WiFiDirectDiscoveryChannel
    {
        /// <summary>
        /// Scan full channel.
        /// </summary>
        FullScan = 0,
        /// <summary>
        /// The social channel.
        /// </summary>
        SocialChannel = 1611,
        /// <summary>
        /// Scan channel 1.
        /// </summary>
        Channel1 = 1,
        /// <summary>
        /// Scan channel 6.
        /// </summary>
        Channel6 = 6,
        /// <summary>
        /// Scan channel 11.
        /// </summary>
        Channel11 = 11
    }

    /// <summary>
    /// Enumeration for Wi-Fi Direct connection state.
    /// </summary>
    public enum WiFiDirectConnectionState
    {
        /// <summary>
        /// Connection is requested.
        /// </summary>
        ConnectionRequest,
        /// <summary>
        /// Wps is requested.
        /// </summary>
        ConnectionWpsRequest,
        /// <summary>
        /// Connection in progress.
        /// </summary>
        ConnectionInProgress,
        /// <summary>
        /// Connected   .
        /// </summary>
        ConnectionRsp,
        /// <summary>
        /// Disconnected by remote group client.
        /// </summary>
        DisassociationInd,
        /// <summary>
        /// Disconnected by local device.
        /// </summary>
        DisconnectRsp,
        /// <summary>
        /// Disconnected by remote group owner.
        /// </summary>
        DisconnectInd,
        /// <summary>
        /// Group is created.
        /// </summary>
        GroupCreated,
        /// <summary>
        /// Group is destroyed.
        /// </summary>
        GroupDestroyed
    }

    /// <summary>
    /// Enumeration for Wi-Fi Direct primary device type.
    /// </summary>
    public enum WiFiDirectPrimaryDeviceType
    {
        /// <summary>
        /// Computer.
        /// </summary>
        Computer = 1,
        /// <summary>
        /// Input device.
        /// </summary>
        InputDevice = 2,
        /// <summary>
        /// Printer.
        /// </summary>
        Printer = 3,
        /// <summary>
        /// Camera.
        /// </summary>
        Camera = 4,
        /// <summary>
        /// Storage.
        /// </summary>
        Storage = 5,
        /// <summary>
        /// Network Infrastructure.
        /// </summary>
        NetworkInfrastructure = 6,
        /// <summary>
        /// Display.
        /// </summary>
        Display = 7,
        /// <summary>
        /// Multimedia device.
        /// </summary>
        MultimediaDevice = 8,
        /// <summary>
        /// Game device.
        /// </summary>
        GameDevice = 9,
        /// <summary>
        /// Telephone.
        /// </summary>
        Telephone = 10,
        /// <summary>
        /// Audio.
        /// </summary>
        Audio = 11,
        /// <summary>
        /// Others.
        /// </summary>
        Other = 255
    }

    /// <summary>
    /// Enumeration for Wi-Fi Direct secondary device type.
    /// </summary>
    /// </summary>
    public enum WiFiDirectSecondaryDeviceType
    {
        /// <summary>
        /// Computer PC.
        /// </summary>
        ComputerPc = 1,
        /// <summary>
        /// Computer server.
        /// </summary>
        ComputerServer = 2,
        /// <summary>
        /// Computer media center.
        /// </summary>
        ComputerMediaCenter = 3,
        /// <summary>
        /// Computer UMPC.
        /// </summary>
        ComputerUmpc = 4,
        /// <summary>
        /// Computer notebook.
        /// </summary>
        ComputerNotebook = 5,
        /// <summary>
        /// Computer desktop
        /// </summary>
        ComputerDesktop = 6,
        /// <summary>
        /// Computer MID.
        /// </summary>
        ComputerMid = 7,
        /// <summary>
        /// Computer netbook.
        /// </summary>
        ComputerNetbook = 8,
        /// <summary>
        /// Input keyboard.
        /// </summary>
        InputKeyboard = 1,
        /// <summary>
        /// Input mouse.
        /// </summary>
        InputMouse = 2,
        /// <summary>
        /// Input joystick.
        /// </summary>
        InputJoystick = 3,
        /// <summary>
        /// Input trackball.
        /// </summary>
        InputTrackball = 4,
        /// <summary>
        /// Input controller.
        /// </summary>
        InputController = 5,
        /// <summary>
        /// Inpute remote.
        /// </summary>
        InputRemote = 6,
        /// <summary>
        /// Input touch screen.
        /// </summary>
        InputTouchScreen = 7,
        /// <summary>
        /// Input biometric reader.
        /// </summary>
        InputBiometricReader = 8,
        /// <summary>
        /// Input barcode reader.
        /// </summary>
        InputBarcodeReader = 9,
        /// <summary>
        /// Printer.
        /// </summary>
        Printer = 1,
        /// <summary>
        /// Printer scanner.
        /// </summary>
        PrinterScanner = 2,
        /// <summary>
        /// Printer fax.
        /// </summary>
        PrinterFax = 3,
        /// <summary>
        /// Printer copier.
        /// </summary>
        PrinterCopier = 4,
        /// <summary>
        /// Printer all-in-one.
        /// </summary>
        PrinterAllInOne = 5,
        /// <summary>
        /// Digital still camera.
        /// </summary>
        CameraDigital = 1,
        /// <summary>
        /// Video camera.
        /// </summary>
        CameraVideo = 2,
        /// <summary>
        /// Webcam.
        /// </summary>
        CameraWebcam = 3,
        /// <summary>
        /// Security camera.
        /// </summary>
        CameraSecurity = 4,
        /// <summary>
        /// Storage NAS.
        /// </summary>
        StorageNas = 1,
        /// <summary>
        /// Network ap.
        /// </summary>
        NetworkAp = 1,
        /// <summary>
        /// Network router.
        /// </summary>
        NetworkRouter = 2,
        /// <summary>
        /// Network switch.
        /// </summary>
        NetworkSwitch = 3,
        /// <summary>
        /// Network gateway.
        /// </summary>
        NetworkGateway = 4,
        /// <summary>
        /// Display tv.
        /// </summary>
        DisplayTv = 1,
        /// <summary>
        /// Display picture frame.
        /// </summary>
        DisplayPicFrame = 2,
        /// <summary>
        /// Display projector.
        /// </summary>
        DisplayProjector = 3,
        /// <summary>
        /// Display monitor.
        /// </summary>
        DisplayMonitor = 4,
        /// <summary>
        /// Multimedia DAR.
        /// </summary>
        MultimediaDar = 1,
        /// <summary>
        /// Multimedia PVR.
        /// </summary>
        MultimediaPvr = 2,
        /// <summary>
        /// Multimedia MCX.
        /// </summary>
        MultimediaMcx = 3,
        /// <summary>
        /// Multimedia set-top box.
        /// </summary>
        MultimediaStb = 4,
        /// <summary>
        /// Media Server / Media Adapter / Media Extender.
        /// </summary>
        MultimediaMsMaMe = 5,
        /// <summary>
        /// Multimedia portable video player.
        /// </summary>
        MultimediaPvp = 6,
        /// <summary>
        /// Game xbox.
        /// </summary>
        GameXbox = 1,
        /// <summary>
        /// The game xbox 360.
        /// </summary>
        GameXbox360,
        /// <summary>
        /// Game play station.
        /// </summary>
        GamePlayStation = 2,
        /// <summary>
        /// Game console.
        /// </summary>
        GameConsole = 3,
        /// <summary>
        /// Game portable.
        /// </summary>
        GamePortable = 4,
        /// <summary>
        /// Windows mobile.
        /// </summary>
        TelephoneWindowsMobile = 1,
        /// <summary>
        /// Phone - single mode.
        /// </summary>
        TelephonePhoneSingle = 2,
        /// <summary>
        /// Phone - dual mode.
        /// </summary>
        TelephonePhoneDual = 3,
        /// <summary>
        /// Smart Phone - single mode.
        /// </summary>
        TelephoneSmartphoneSingle = 4,
        /// <summary>
        /// Smart Phone - dual mode.
        /// </summary>
        TelephoneSmartphoneDual = 5,
        /// <summary>
        /// Audio tuner.
        /// </summary>
        AudioTuner = 1,
        /// <summary>
        /// Audio speaker.
        /// </summary>
        AudioSpeaker = 2,
        /// <summary>
        /// Audio pmp.
        /// </summary>
        AudioPmp = 3,
        /// <summary>
        /// Audio headset.
        /// </summary>
        AudioHeadset = 4,
        /// <summary>
        /// Audio headphone.
        /// </summary>
        AudioHeadphone = 5,
        /// <summary>
        /// Audio microphone.
        /// </summary>
        AudioMic = 6
    }

    /// <summary>
    /// Enumeration for Wi-Fi Direct link status.
    /// </summary>
    /// </summary>
    public enum WiFiDirectState
    {
        /// <summary>
        /// Deactivated.
        /// </summary>
        Deactivated = 0,
        /// <summary>
        /// Deactivating.
        /// </summary>
        Deactivating,
        /// <summary>
        /// Activating.
        /// </summary>
        Activating,
        /// <summary>
        /// Activated.
        /// </summary>
        Activated,
        /// <summary>
        /// Discovering.
        /// </summary>
        Discovering,
        /// <summary>
        /// Connecting.
        /// </summary>
        Connecting,
        /// <summary>
        /// Disconnecting.
        /// </summary>
        Disconnecting,
        /// <summary>
        /// Connected.
        /// </summary>
        Connected,
        /// <summary>
        /// Group owner.
        /// </summary>
        GroupOwner
    }

    /// <summary>
    /// Enumeration for Wi-Fi WPS type.
    /// </summary>
    public enum WiFiDirectWpsType
    {
        /// <summary>
        /// No WPS type.
        /// </summary>
        None = 0x00,
        /// <summary>
        /// Push button configuration.
        /// </summary>
        Pbc = 0x01,
        /// <summary>
        /// Display pin code.
        /// </summary>
        PinDisplay = 0x02,
        /// <summary>
        /// Provide the keypad to input the pin.
        /// </summary>
        PinKeypad = 0x04
    }

    /// <summary>
    /// Enumeration for Service Discovery type.
    /// </summary>
    public enum WiFiDirectServiceType
    {
        /// <summary>
        /// Service discovery Type all.
        /// </summary>
        All,
        /// <summary>
        /// Service discovery Type bonjour.
        /// </summary>
        Bonjour,
        /// <summary>
        /// Service discovery Type UPNP.
        /// </summary>
        Upnp,
        /// <summary>
        /// Service discovery Type ws discovery.
        /// </summary>
        WsDiscovery,
        /// <summary>
        /// Service discovery Type wifi-display.
        /// </summary>
        WiFiDisplay,
        /// <summary>
        /// Service discovery Type bt address.
        /// </summary>
        BtAddress,
        /// <summary>
        /// Service discovery Type contact info.
        /// </summary>
        ContactInfo,
        /// <summary>
        /// Service discovery Type vendor-specific.
        /// </summary>
        Vendor
    }

    /// <summary>
    /// Enumeration for Wi-Fi Direct service Discovery state.
    /// </summary>
    public enum WiFiDirectServiceDiscoveryState
    {
        /// <summary>
        /// Service discovery started.
        /// </summary>
        Started,
        /// <summary>
        /// Service discovery found.
        /// </summary>
        Found,
        /// <summary>
        /// Service discovery finished.
        /// </summary>
        Finished
    }

    /// <summary>
    /// Enumeration for Wi-Fi Direct device state.
    /// </summary>
    public enum WiFiDirectDeviceState
    {
        /// <summary>
        /// Activated.
        /// </summary>
        Activated,
        /// <summary>
        /// Deactivated.
        /// </summary>
        Deactivated
    }

    /// <summary>
    /// Enumeration for Wi-Fi Direct error code.
    /// </summary>
    public enum WiFiDirectError
    {
        /// <summary>
        /// Successful.
        /// </summary>
        None = ErrorCode.None,
        /// <summary>
        /// Operation not permitted.
        /// </summary>
        NotPermitted = ErrorCode.NotPermitted,
        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = ErrorCode.OutOfMemory,
        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied = ErrorCode.PermissionDenied,
        /// <summary>
        /// Device or resource busy.
        /// </summary>
        ResourceBusy = ErrorCode.ResourceBusy,
        /// <summary>
        /// Invalid function parameter.
        /// </summary>
        InvalidParameter = ErrorCode.InvalidParameter,
        /// <summary>
        /// Connection timed out.
        /// </summary>
        ConnectionTimeOut = ErrorCode.ConnectionTimeout,
        /// <summary>
        /// Not supported.
        /// </summary>
        NotSupported = ErrorCode.NotSupported,
        /// <summary>
        /// Not initialized.
        /// </summary>
        NotInitialized = -0x01C60000 | 0x01,
        /// <summary>
        /// I/O error.
        /// </summary>
        CommunicationFailed = -0x01C60000 | 0x02,
        /// <summary>
        /// WiFi is being used.
        /// </summary>
        WiFiUsed = -0x01C60000 | 0x03,
        /// <summary>
        /// Mobile AP is being used.
        /// </summary>
        MobileApUsed = -0x01C60000 | 0x04,
        /// <summary>
        /// Connection failed.
        /// </summary>
        ConnectionFailed = -0x01C60000 | 0x05,
        /// <summary>
        /// Authentication failed.
        /// </summary>
        AuthFailed = -0x01C60000 | 0x06,
        /// <summary>
        /// Operation failed.
        /// </summary>
        OperationFailed = -0x01C60000 | 0x07,
        /// <summary>
        /// Too many client.
        /// </summary>
        TooManyClient = -0x01C60000 | 0x08,
        /// <summary>
        /// Already initialized client.
        /// </summary>
        AlreadyInitialized = -0x01C60000 | 0x09,
        /// <summary>
        /// Connection cancelled by local device.
        /// </summary>
        ConnectionCancelled = -0x01C60000 | 0x10
    }
}
