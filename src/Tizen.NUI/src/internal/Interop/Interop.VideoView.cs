/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class VideoView
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_Property_VIDEO_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VideoGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_Property_LOOPING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LoopingGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_Property_MUTED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MutedGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_Property_VOLUME_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VolumeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_Property_UNDERLAY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int UnderlayGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_New__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_New__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(string jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_New__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New([MarshalAs(UnmanagedType.U1)] bool swCodec);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_New__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(string jarg1, [MarshalAs(UnmanagedType.U1)] bool swCodec);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_VideoView", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteVideoView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_Play", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Play(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_Pause", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Pause(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_Stop", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Stop(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_Forward", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Forward(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_Backward", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Backward(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_SetAutoRotationEnabled", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetAutoRotationEnabled(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_IsAutoRotationEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsAutoRotationEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_SetLetterBoxEnabled", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetLetterBoxEnabled(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_IsLetterBoxEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsLetterBoxEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_FinishedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr FinishedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoViewSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool VideoViewSignalEmpty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoViewSignal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint VideoViewSignalGetConnectionCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoViewSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void VideoViewSignalConnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoViewSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void VideoViewSignalDisconnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoViewSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void VideoViewSignalEmit(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VideoViewSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewVideoViewSignal();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_VideoViewSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteVideoViewSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_GetNativePlayerHandle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetNativePlayerHandle(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_SetFrameInterpolationInterval", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFrameInterpolationInterval(IntPtr view, float intervalSeconds);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_GetFrameInterpolationInterval", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetFrameInterpolationInterval(IntPtr view);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_SetVideoFrameBuffer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetVideoFrameBuffer(IntPtr view, IntPtr nativeImageSource);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VideoView_EnableOffscreenFrameRendering", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableOffscreenFrameRendering(IntPtr view, [MarshalAs(UnmanagedType.U1)] bool useOffScreenFrame);

        }
    }
}





