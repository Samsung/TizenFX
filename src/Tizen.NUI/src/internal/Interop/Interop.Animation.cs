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
        internal static partial class Animation
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(float jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Animation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteAnimation(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Animation__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewAnimation(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_SetDuration", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetDuration(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_GetDuration", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetDuration(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_SetLooping", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetLooping(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_SetLoopCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetLoopCount(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_GetLoopCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetLoopCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_GetCurrentLoop", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetCurrentLoop(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_IsLooping", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsLooping(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_SetEndAction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetEndAction(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_GetEndAction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetEndAction(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_SetDisconnectAction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetDisconnectAction(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_GetDisconnectAction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetDisconnectAction(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_SetDefaultAlphaFunction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetDefaultAlphaFunction(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_GetDefaultAlphaFunction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetDefaultAlphaFunction(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_SetCurrentProgress", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetCurrentProgress(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_GetCurrentProgress", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetCurrentProgress(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_SetSpeedFactor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSpeedFactor(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_GetSpeedFactor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetSpeedFactor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_SetPlayRange", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPlayRange(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_GetPlayRange", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetPlayRange(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_Play", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Play(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_PlayFrom", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PlayFrom(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_Pause", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Pause(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_GetState", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetState(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_Stop", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Stop(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_Clear", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Clear(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_SetLoopingMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetLoopingMode(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_GetLoopingMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetLoopingMode(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_GetAnimationId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetAnimationId(IntPtr nuiAnimation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_SetProgressNotification", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetProgressNotification(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_GetProgressNotification", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetProgressNotification(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_SetBlendPoint", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetBlendPoint(IntPtr csAnimation, float blendPoint);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_GetBlendPoint", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetBlendPoint(IntPtr csAnimation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_FinishedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr FinishedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_ProgressReachedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ProgressReachedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_PlayAfter", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PlayAfter(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBy__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateBy(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBy__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateByAlphaFunction(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBy__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateByTimePeriod(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBy__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateBy(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4, IntPtr jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateTo__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateTo(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateTo__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateToAlphaFunction(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateTo__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateToTimePeriod(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateTo__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateTo(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4, IntPtr jarg5);


            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBy__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateBy(IntPtr jarg1, IntPtr jarg2, global::System.IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBy__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateByAlphaFunction(IntPtr jarg1, IntPtr jarg2, global::System.IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBy__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateByTimePeriod(IntPtr jarg1, IntPtr jarg2, global::System.IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBy__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateBy(IntPtr jarg1, IntPtr jarg2, global::System.IntPtr jarg3, IntPtr jarg4, IntPtr jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateTo__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateTo(IntPtr jarg1, IntPtr jarg2, global::System.IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateTo__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateToAlphaFunction(IntPtr jarg1, IntPtr jarg2, global::System.IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateTo__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateToTimePeriod(IntPtr jarg1, IntPtr jarg2, global::System.IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateTo__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateTo(IntPtr jarg1, IntPtr jarg2, global::System.IntPtr jarg3, IntPtr jarg4, IntPtr jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBetween__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateBetween(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBetween__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateBetween(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, int jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBetween__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateBetweenAlphaFunction(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBetween__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateBetweenAlphaFunctionInterpolation(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4, int jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBetween__SWIG_4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateBetweenTimePeriod(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBetween__SWIG_5", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateBetweenTimePeriodInterpolation(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4, int jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBetween__SWIG_6", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateBetween(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4, IntPtr jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_AnimateBetween__SWIG_7", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateBetween(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4, IntPtr jarg5, int jarg6);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_Animate__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Animate(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_Animate__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateAlphaFunction(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4, IntPtr jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_Animate__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimateTimePeriod(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4, IntPtr jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_Animate__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Animate(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4, IntPtr jarg5, IntPtr jarg6);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_Show", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Show(IntPtr jarg1, IntPtr jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Animation_Hide", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Hide(IntPtr jarg1, IntPtr jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AnimationSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AnimationSignalEmpty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AnimationSignal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint AnimationSignalGetConnectionCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AnimationSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimationSignalConnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AnimationSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimationSignalDisconnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AnimationSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AnimationSignalEmit(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AnimationSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewAnimationSignal();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AnimationSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteAnimationSignal(IntPtr jarg1);
        }
    }
}





