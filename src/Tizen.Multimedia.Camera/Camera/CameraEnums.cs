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
using System.ComponentModel;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Enumeration for the camera device.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraDevice
    {
        /// <summary>
        /// The rear camera device.
        /// </summary>
        Rear,
        /// <summary>
        /// The front camera device.
        /// </summary>
        Front,
        /// <summary>
        /// The primary camera device.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        CameraDevice0 = Rear,
        /// <summary>
        /// The secondary camera device.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        CameraDevice1 = Front,
        /// <summary>
        /// The third camera device.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        CameraDevice2,
        /// <summary>
        /// The fourth camera device.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        CameraDevice3,
        /// <summary>
        /// The fifth camera device.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        CameraDevice4,
        /// <summary>
        /// The sixth camera device.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        CameraDevice5,
        /// <summary>
        /// The seventh camera device.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        CameraDevice6,
        /// <summary>
        /// The eighth camera device.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        CameraDevice7,
        /// <summary>
        /// The ninth camera device.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        CameraDevice8,
        /// <summary>
        /// The tenth camera device.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        CameraDevice9
    }

    /// <summary>
    /// Enumeration for the camera device state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraDeviceState
    {
        /// <summary>
        /// Not opened.
        /// </summary>
        NotOpened,
        /// <summary>
        /// Opened.
        /// </summary>
        Opened,
        /// <summary>
        /// Now previewing or capturing or is being used for the video recording.
        /// </summary>
        Working
    }

    /// <summary>
    /// Enumeration for the facing direction of camera module.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraFacingDirection
    {
        /// <summary>
        /// Rear direction.
        /// </summary>
        Rear,
        /// <summary>
        /// Front direction.
        /// </summary>
        Front
    }

    /// <summary>
    /// Enumeration for the current flash state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraFlashState
    {
        /// <summary>
        /// Flash is not used now through the camera API.
        /// </summary>
        NotUsed,
        /// <summary>
        /// Flash is used now through the camera API.
        /// </summary>
        Used
    }

    /// <summary>
    /// Enumeration for the camera focus state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraFocusState
    {
        /// <summary>
        /// Focus released.
        /// </summary>
        Released,
        /// <summary>
        /// Focus in progress.
        /// </summary>
        Ongoing,
        /// <summary>
        /// Focus succeeded.
        /// </summary>
        Focused,
        /// <summary>
        /// Focus failed.
        /// </summary>
        Failed
    }

    /// <summary>
    /// Enumeration for the camera pixel format.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraPixelFormat
    {
        /// <summary>
        /// Invalid pixel format.
        /// </summary>
        Invalid = -1,
        /// <summary>
        /// NV12 pixel format.
        /// </summary>
        Nv12,
        /// <summary>
        /// NV12 tiled pixel format.
        /// </summary>
        Nv12t,
        /// <summary>
        /// NV16 pixel format.
        /// </summary>
        Nv16,
        /// <summary>
        /// NV21 pixel format.
        /// </summary>
        Nv21,
        /// <summary>
        /// YUYV(YUY2) pixel format.
        /// </summary>
        Yuyv,
        /// <summary>
        /// UYVY pixel format.
        /// </summary>
        Uyvy,
        /// <summary>
        /// YUV422(Y:U:V) planar pixel format.
        /// </summary>
        Yuv422Planar,
        /// <summary>
        /// I420 pixel format.
        /// </summary>
        I420,
        /// <summary>
        /// YV12 pixel format.
        /// </summary>
        Yv12,
        /// <summary>
        /// RGB565 pixel format.
        /// </summary>
        Rgb565,
        /// <summary>
        /// RGB565 pixel format.
        /// </summary>
        Rgb888,
        /// <summary>
        /// RGBA pixel format.
        /// </summary>
        Rgba,
        /// <summary>
        /// ARGB pixel format.
        /// </summary>
        Argb,
        /// <summary>
        /// Encoded pixel format.
        /// </summary>
        Jpeg,
        /// <summary>
        /// Encoded pixel format : H264.
        /// </summary>
        H264 = 15,
        /// <summary>
        /// Depth pixel format.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Invz,
        /// <summary>
        /// Encoded pixel format : Motion JPEG
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Mjpeg
    }

    /// <summary>
    /// Enumeration for the camera policy.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraPolicy
    {
        /// <summary>
        /// None.
        /// </summary>
        None,
        /// <summary>
        /// Security policy.
        /// </summary>
        Security = 4,
        /// <summary>
        /// Resource conflict.
        /// </summary>
        ResourceConflict
    }

    /// <summary>
    /// Enumeration for the camera state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraState
    {
        /// <summary>
        /// Before creating.
        /// </summary>
        None,
        /// <summary>
        /// Created, but not initialized yet.
        /// </summary>
        Created,
        /// <summary>
        /// Preview.
        /// </summary>
        Preview,
        /// <summary>
        /// While capturing.
        /// </summary>
        Capturing,
        /// <summary>
        /// After capturing.
        /// </summary>
        Captured
    }

    /// <summary>
    /// Enumeration for the auto-focus mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraAutoFocusMode
    {
        /// <summary>
        /// Auto-focus is not set.
        /// </summary>
        None,
        /// <summary>
        /// Auto-focus is in the normal mode.
        /// </summary>
        Normal,
        /// <summary>
        /// Auto-focus is in the macro mode (close distance).
        /// </summary>
        Macro,
        /// <summary>
        /// Auto-focus is in the full mode (all range scan, limited by device spec).
        /// </summary>
        Full
    }

    /// <summary>
    /// Enumeration for the color tone, which provides the impression of looking through a tinted glass.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraEffectMode
    {
        /// <summary>
        /// None.
        /// </summary>
        None,
        /// <summary>
        /// Mono.
        /// </summary>
        Mono,
        /// <summary>
        /// Sepia.
        /// </summary>
        Sepia,
        /// <summary>
        /// Negative.
        /// </summary>
        Negative,
        /// <summary>
        /// Blue.
        /// </summary>
        Blue,
        /// <summary>
        /// Green.
        /// </summary>
        Green,
        /// <summary>
        /// Aqua.
        /// </summary>
        Aqua,
        /// <summary>
        /// Violet.
        /// </summary>
        Violet,
        /// <summary>
        /// Orange.
        /// </summary>
        Orange,
        /// <summary>
        /// Gray.
        /// </summary>
        Gray,
        /// <summary>
        /// Red.
        /// </summary>
        Red,
        /// <summary>
        /// Antique.
        /// </summary>
        Antique,
        /// <summary>
        /// Warm.
        /// </summary>
        Warm,
        /// <summary>
        /// Pink.
        /// </summary>
        Pink,
        /// <summary>
        /// Yellow.
        /// </summary>
        Yellow,
        /// <summary>
        /// Purple.
        /// </summary>
        Purple,
        /// <summary>
        /// Emboss.
        /// </summary>
        Emboss,
        /// <summary>
        /// Outline.
        /// </summary>
        Outline,
        /// <summary>
        /// Solarization.
        /// </summary>
        Solarization,
        /// <summary>
        /// Sketch.
        /// </summary>
        Sketch,
        /// <summary>
        /// Washed.
        /// </summary>
        Washed,
        /// <summary>
        /// Vintage warm.
        /// </summary>
        VintageWarm,
        /// <summary>
        /// Vintage cold.
        /// </summary>
        VintageCold,
        /// <summary>
        /// Posterization.
        /// </summary>
        Posterization,
        /// <summary>
        /// Cartoon.
        /// </summary>
        Cartoon,
        /// <summary>
        /// Selective color - red.
        /// </summary>
        SelectiveRed,
        /// <summary>
        /// Selective color - green.
        /// </summary>
        SelectiveGreen,
        /// <summary>
        /// Selective color - blue.
        /// </summary>
        SelectiveBlue,
        /// <summary>
        /// Selective color - yellow.
        /// </summary>
        SelectiveYellow,
        /// <summary>
        /// Selective color - red and yellow.
        /// </summary>
        SelectiveRedYellow,
        /// <summary>
        /// Other graphic effects.
        /// </summary>
        OtherGraphics
    }

    /// <summary>
    /// Enumeration for the camera exposure modes.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraExposureMode
    {
        /// <summary>
        /// Off.
        /// </summary>
        Off,
        /// <summary>
        /// All mode.
        /// </summary>
        All,
        /// <summary>
        /// Center mode.
        /// </summary>
        Center,
        /// <summary>
        /// Spot mode.
        /// </summary>
        Spot,
        /// <summary>
        /// Custom mode.
        /// </summary>
        Custom
    }

    /// <summary>
    /// Enumeration for the flash mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraFlashMode
    {
        /// <summary>
        /// Always off.
        /// </summary>
        Off,
        /// <summary>
        /// Always splashes.
        /// </summary>
        On,
        /// <summary>
        /// Depending on intensity of light, strobe starts to flash.
        /// </summary>
        Auto,
        /// <summary>
        /// Red eye reduction. Multiple flash before capturing.
        /// </summary>
        RedEyeReduction,
        /// <summary>
        /// Slow sync curtain synchronization.
        /// </summary>
        SlowSync,
        /// <summary>
        /// Front curtain synchronization.
        /// </summary>
        FrontCurtain,
        /// <summary>
        /// Rear curtain synchronization.
        /// </summary>
        RearCurtain,
        /// <summary>
        /// Keep turned on until turning off.
        /// </summary>
        Permanent
    }

    /// <summary>
    /// Enumeration for the preview fps.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraFps
    {
        /// <summary>
        /// Auto fps.
        /// </summary>
        Auto = 0,
        /// <summary>
        /// 7 fps.
        /// </summary>
        Fps7 = 7,
        /// <summary>
        /// 8 fps.
        /// </summary>
        Fps8 = 8,
        /// <summary>
        /// 15 fps.
        /// </summary>
        Fps15 = 15,
        /// <summary>
        /// 20 fps.
        /// </summary>
        Fps20 = 20,
        /// <summary>
        /// 24 fps.
        /// </summary>
        Fps24 = 24,
        /// <summary>
        /// 25 fps.
        /// </summary>
        Fps25 = 25,
        /// <summary>
        /// 30 fps.
        /// </summary>
        Fps30 = 30,
        /// <summary>
        /// 60 fps.
        /// </summary>
        Fps60 = 60,
        /// <summary>
        /// 90 fps.
        /// </summary>
        Fps90 = 90,
        /// <summary>
        /// 120 fps.
        /// </summary>
        Fps120 = 120
    }

    /// <summary>
    /// Enumeration for the HDR capture mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraHdrMode
    {
        /// <summary>
        /// Disable the HDR capture.
        /// </summary>
        Disable,
        /// <summary>
        /// Enable the HDR capture.
        /// </summary>
        Enable,
        /// <summary>
        /// Enable the HDR capture mode and keep original image data.
        /// </summary>
        KeepOriginal
    }

    /// <summary>
    /// Enumeration for the ISO levels of the camera.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraIsoLevel
    {
        /// <summary>
        /// ISO auto mode.
        /// </summary>
        Auto,
        /// <summary>
        /// ISO 50.
        /// </summary>
        Iso50,
        /// <summary>
        /// ISO 100.
        /// </summary>
        Iso100,
        /// <summary>
        /// ISO 200.
        /// </summary>
        Iso200,
        /// <summary>
        /// ISO 400.
        /// </summary>
        Iso400,
        /// <summary>
        /// ISO 800.
        /// </summary>
        Iso800,
        /// <summary>
        /// ISO 1600.
        /// </summary>
        Iso1600,
        /// <summary>
        /// ISO 3200.
        /// </summary>
        Iso3200
    }

    /// <summary>
    /// Enumeration for the PTZ(Pan Tilt Zoom) movement type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraPtzMoveType
    {
        /// <summary>
        /// Move to a specific coordinate position.
        /// </summary>
        Absoulute,
        /// <summary>
        /// Move to a specific distance from the current position.
        /// </summary>
        Relative
    }

    /// <summary>
    /// Enumeration for the PTZ(Pan Tilt Zoom) type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraPtzType
    {
        /// <summary>
        /// Move the camera device physically.
        /// </summary>
        Mechanical,
        /// <summary>
        /// Zoom digitally and move into portion of the image.
        /// </summary>
        Electronic
    }

    /// <summary>
    /// Enumeration for the camera scene mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraSceneMode
    {
        /// <summary>
        /// Normal.
        /// </summary>
        Normal,
        /// <summary>
        /// Portrait.
        /// </summary>
        Portrait,
        /// <summary>
        /// Landscape.
        /// </summary>
        Landscape,
        /// <summary>
        /// Sports.
        /// </summary>
        Sports,
        /// <summary>
        /// Party and indoor.
        /// </summary>
        PartyAndIndoor,
        /// <summary>
        /// Beach and indoor.
        /// </summary>
        BeachAndIndoor,
        /// <summary>
        /// Sunset.
        /// </summary>
        Sunset,
        /// <summary>
        /// Dusk and dawn.
        /// </summary>
        DuskAndDawn,
        /// <summary>
        /// Fall.
        /// </summary>
        FallColor,
        /// <summary>
        /// Night scene.
        /// </summary>
        NightScene,
        /// <summary>
        /// Firework.
        /// </summary>
        FireWork,
        /// <summary>
        /// Text.
        /// </summary>
        Text,
        /// <summary>
        /// Show window.
        /// </summary>
        ShowWindow,
        /// <summary>
        /// Candle light.
        /// </summary>
        CandleLight,
        /// <summary>
        /// Backlight.
        /// </summary>
        BackLight,
        /// <summary>
        /// Aqua.
        /// </summary>
        Aqua
    }

    /// <summary>
    /// Enumeration for the orientation values of tag.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraTagOrientation
    {
        /// <summary>
        /// Row #0 is at the top, column #0 is to the left.
        /// </summary>
        TopLeft = 1,
        /// <summary>
        /// Row #0 is at the top, column #0 is to the right.
        /// </summary>
        TopRight = 2,
        /// <summary>
        /// Row #0 is at the bottom, column #0 is to the right.
        /// </summary>
        BottomRight = 3,
        /// <summary>
        /// Row #0 is at the bottom, column #0 is to the left.
        /// </summary>
        BottomLeft = 4,
        /// <summary>
        /// Row #0 is at the left, column #0 is to the top.
        /// </summary>
        LeftTop = 5,
        /// <summary>
        /// Row #0 is at the right, column #0 is to the top.
        /// </summary>
        RightTop = 6,
        /// <summary>
        /// Row #0 is at the right, column #0 is to the bottom.
        /// </summary>
        RightBottom = 7,
        /// <summary>
        /// Row #0 is at the left, column #0 is to the bottom.
        /// </summary>
        LeftBottom = 8
    }

    /// <summary>
    /// Enumeration for the theater mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraTheaterMode
    {
        /// <summary>
        /// Disable the theater mode - the external display shows same image as the device display.
        /// </summary>
        Disable,
        /// <summary>
        /// Clone the mode - the preview image is displayed on an external display with full screen mode. Also, the preview image is shown by the UI on the device display.
        /// </summary>
        Clone,
        /// <summary>
        /// Enable the theater mode - the preview image is displayed on an external display with full screen mode, but the preview image is not shown on the device display.
        /// </summary>
        Enable
    }

    /// <summary>
    /// Enumeration for the white balance levels of the camera.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraWhiteBalance
    {
        /// <summary>
        /// None.
        /// </summary>
        None,
        /// <summary>
        /// Automatic.
        /// </summary>
        Automatic,
        /// <summary>
        /// Daylight.
        /// </summary>
        Daylight,
        /// <summary>
        /// Cloudy.
        /// </summary>
        Cloudy,
        /// <summary>
        /// Fluorescent.
        /// </summary>
        Fluorescent,
        /// <summary>
        /// Incandescent.
        /// </summary>
        Incandescent,
        /// <summary>
        /// Shade.
        /// </summary>
        Shade,
        /// <summary>
        /// Horizon.
        /// </summary>
        Horizon,
        /// <summary>
        /// Flash.
        /// </summary>
        Flash,
        /// <summary>
        /// Custom.
        /// </summary>
        Custom
    }

    /// <summary>
    /// Enumeration for the camera display mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraDisplayMode
    {
        /// <summary>
        /// Letter box.
        /// </summary>
        LetterBox,
        /// <summary>
        /// Original size.
        /// </summary>
        OriginSize,
        /// <summary>
        /// Full screen.
        /// </summary>
        Full,
        /// <summary>
        /// Cropped full screen.
        /// </summary>
        CroppedFull,
        /// <summary>
        /// Original size or letter box.
        /// </summary>
        OriginOrLetterBox,
        /// <summary>
        /// Custom ROI.
        /// </summary>
        CustomROI
    }

    /// <summary>
    /// Enumeration for the camera failure error.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraErrorCode
    {
        /// <summary>
        /// Device Error.
        /// </summary>
        DeviceError = CameraError.DeviceError,
        /// <summary>
        /// Internal error.
        /// </summary>
        InvalidOperation = CameraError.InvalidOperation,
        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = CameraError.OutOfMemory,
        /// <summary>
        /// Service is disconnected.
        /// </summary>
        ServiceDisconnected = CameraError.ServiceDisconnected
    }

    /// <summary>
    /// Enumeration for the image datatype.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum PlaneType
    {
        /// <summary>
        /// Single plane data.
        /// </summary>
        SinglePlane,
        /// <summary>
        /// Double plane data.
        /// </summary>
        DoublePlane,
        /// <summary>
        /// Triple plane data.
        /// </summary>
        TriplePlane,
        /// <summary>
        /// Encoded plane data.
        /// </summary>
        EncodedPlane,
        /// <summary>
        /// Depth plane data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        DepthPlane,
        /// <summary>
        /// Rgb plane data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        RgbPlane
    }

    /// <summary>
    /// Enumeration for camera device type
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum CameraDeviceType
    {
        /// <summary>
        /// Built-in camera.
        /// </summary>
        BuiltIn,
        /// <summary>
        /// USB camera.
        /// </summary>
        Usb,
        /// <summary>
        /// Network camera.
        /// </summary>
        Network
    }
}
