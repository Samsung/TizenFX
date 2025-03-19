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
    /// Enumeration for the Wi-Fi Direct discovery state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Enumeration for the Wi-Fi Direct display device types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WiFiDirectDisplayType
    {
        /// <summary>
        /// Configure as the WFD source.
        /// </summary>
        Source = 0,
        /// <summary>
        /// Configure as the WFD primary sink.
        /// </summary>
        Prisink,
        /// <summary>
        /// Configure as the WFD secondary sink.
        /// </summary>
        Secsink,
        /// <summary>
        /// Configure as the WFD dual role.
        /// </summary>
        Dual
    }

    /// <summary>
    /// Enumeration for the Wi-Fi Discovery channel.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Enumeration for the Wi-Fi Direct connection state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WiFiDirectConnectionState
    {
        /// <summary>
        /// Connection is requested.
        /// </summary>
        ConnectionRequest,
        /// <summary>
        /// WPS is requested.
        /// </summary>
        ConnectionWpsRequest,
        /// <summary>
        /// Connection in progress.
        /// </summary>
        ConnectionInProgress,
        /// <summary>
        /// Connected.
        /// </summary>
        ConnectionRsp,
        /// <summary>
        /// Disconnected by the remote group client.
        /// </summary>
        DisassociationInd,
        /// <summary>
        /// Disconnected by the local device.
        /// </summary>
        DisconnectRsp,
        /// <summary>
        /// Disconnected by the remote group owner.
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
    /// Enumeration for the Wi-Fi Direct primary device type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Enumeration for the Wi-Fi Direct secondary device type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        /// Computer desktop.
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
        /// Input remote.
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
        /// Network AP.
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
        /// Display TV.
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
        /// Media Server/Media Adapter/Media Extender.
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
        /// Game xbox 360.
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
        /// Smartphone - single mode.
        /// </summary>
        TelephoneSmartphoneSingle = 4,
        /// <summary>
        /// Smartphone - dual mode.
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
        /// Audio PMP.
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
    /// Enumeration for the Wi-Fi Direct link status.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Enumeration for the Wi-Fi WPS type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Enumeration for the service discovery type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WiFiDirectServiceType
    {
        /// <summary>
        /// The service discovery type All.
        /// </summary>
        All,
        /// <summary>
        /// The service discovery type Bonjour.
        /// </summary>
        Bonjour,
        /// <summary>
        /// The service discovery type UPNP.
        /// </summary>
        Upnp,
        /// <summary>
        /// The service discovery type WS Discovery.
        /// </summary>
        WsDiscovery,
        /// <summary>
        /// The service discovery type Wi-Fi Display.
        /// </summary>
        WiFiDisplay,
        /// <summary>
        /// The service discovery type BT Address.
        /// </summary>
        BtAddress,
        /// <summary>
        /// The service discovery type Contact Info.
        /// </summary>
        ContactInfo,
        /// <summary>
        /// The service discovery type vendor-specific.
        /// </summary>
        Vendor
    }

    /// <summary>
    /// Enumeration for the Wi-Fi Direct service discovery state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WiFiDirectServiceDiscoveryState
    {
        /// <summary>
        /// The service discovery Started.
        /// </summary>
        Started,
        /// <summary>
        /// The service discovery Found.
        /// </summary>
        Found,
        /// <summary>
        /// The service discovery Finished.
        /// </summary>
        Finished
    }

    /// <summary>
    /// Enumeration for the Wi-Fi Direct device state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// Enumeration for the Wi-Fi Direct error code.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        /// Device or the resource is busy.
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
        /// Wi-Fi is being used.
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
        /// Too many clients.
        /// </summary>
        TooManyClient = -0x01C60000 | 0x08,
        /// <summary>
        /// Already initialized the client.
        /// </summary>
        AlreadyInitialized = -0x01C60000 | 0x09,
        /// <summary>
        /// Connection cancelled by the local device.
        /// </summary>
        ConnectionCancelled = -0x01C60000 | 0x10
    }

    /// <summary>
    /// Enumeration for Wi-Fi frame type.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    public enum WiFiDirectVsieFrame
    {
        /// <summary>
        /// P2P probe request frame.
        /// </summary>
        P2P_PROBE_REQ,
        /// <summary>
        /// P2P probe response frame.
        /// </summary>
        P2P_PROBE_RESP,
        /// <summary>
        ///P2P group owner probe response frame.
        /// </summary>
        P2P_GO_PROBE_RESP,
        /// <summary>
        /// P2P probe request frame.
        /// </summary>
        P2P_GO_BEACON,
        /// <summary>
        /// P2P provision discovery request frame.
        /// </summary>
        P2P_PD_REQ,
        /// <summary>
        /// P2P provision discovery response frame.
        /// </summary>
        P2P_PD_RESP,
        /// <summary>
        /// P2P probe request frame.
        /// </summary>
        P2P_GO_NEG_REQ,
        /// <summary>
        /// P2P group owner negotiation response frame.
        /// </summary>
        P2P_GO_NEG_RESP,
        /// <summary>
        /// P2P group owner negotiation confirmation frame.
        /// </summary>
        P2P_GO_NEG_CONF,
        /// <summary>
        /// P2P invitation request frame.
        /// </summary>
        P2P_INV_REQ,
        /// <summary>
        /// P2P invitation response frame.
        /// </summary>
        P2P_INV_RESP,
        /// <summary>
        /// P2P association request frame.
        /// </summary>
        P2P_ASSOC_REQ,
        /// <summary>
        /// P2P association response frame.
        /// </summary>
        P2P_ASSOC_RESP,
        /// <summary>
        /// Association request frame.
        /// </summary>
        ASSOC_REQ
    }
}
