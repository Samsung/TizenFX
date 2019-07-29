/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class CubeTransitionEffect
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffect_SWIGUpcast")]
            public static extern global::System.IntPtr CubeTransitionEffect_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_CubeTransitionEffect")]
            public static extern global::System.IntPtr new_CubeTransitionEffect();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_CubeTransitionEffect")]
            public static extern void delete_CubeTransitionEffect(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffect_SetTransitionDuration")]
            public static extern void CubeTransitionEffect_SetTransitionDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffect_GetTransitionDuration")]
            public static extern float CubeTransitionEffect_GetTransitionDuration(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffect_SetCubeDisplacement")]
            public static extern void CubeTransitionEffect_SetCubeDisplacement(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffect_GetCubeDisplacement")]
            public static extern float CubeTransitionEffect_GetCubeDisplacement(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffect_IsTransitioning")]
            public static extern bool CubeTransitionEffect_IsTransitioning(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffect_SetCurrentTexture")]
            public static extern void CubeTransitionEffect_SetCurrentTexture(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffect_SetTargetTexture")]
            public static extern void CubeTransitionEffect_SetTargetTexture(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffect_StartTransition__SWIG1")]
            public static extern void CubeTransitionEffect_StartTransition__SWIG1(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffect_StartTransition__SWIG2")]
            public static extern void CubeTransitionEffect_StartTransition__SWIG2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffect_PauseTransition")]
            public static extern void CubeTransitionEffect_PauseTransition(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffect_ResumeTransition")]
            public static extern void CubeTransitionEffect_ResumeTransition(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffect_StopTransition")]
            public static extern void CubeTransitionEffect_StopTransition(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffect_TransitionCompletedSignal")]
            public static extern global::System.IntPtr CubeTransitionEffect_TransitionCompletedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffectSignal_Empty")]
            public static extern bool CubeTransitionEffectSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffectSignal_GetConnectionCount")]
            public static extern uint CubeTransitionEffectSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffectSignal_Connect")]
            public static extern void CubeTransitionEffectSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffectSignal_Disconnect")]
            public static extern void CubeTransitionEffectSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionEffectSignal_Emit")]
            public static extern void CubeTransitionEffectSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_CubeTransitionEffectSignal")]
            public static extern global::System.IntPtr new_CubeTransitionEffectSignal();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_CubeTransitionEffectSignal")]
            public static extern void delete_CubeTransitionEffectSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        }

        internal static partial class CubeTransitionWaveEffect
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionWaveEffect_New")]
            public static extern global::System.IntPtr CubeTransitionWaveEffect_New(uint numRows, uint numColumns);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionWaveEffect_SWIGUpcast")]
            public static extern global::System.IntPtr CubeTransitionWaveEffect_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_CubeTransitionWaveEffect")]
            public static extern void delete_CubeTransitionWaveEffect(global::System.Runtime.InteropServices.HandleRef jarg1);
        }

        internal static partial class CubeTransitionCrossEffect
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionCrossEffect_New")]
            public static extern global::System.IntPtr CubeTransitionCrossEffect_New(uint numRows, uint numColumns);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionCrossEffect_SWIGUpcast")]
            public static extern global::System.IntPtr CubeTransitionCrossEffect_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_CubeTransitionCrossEffect")]
            public static extern void delete_CubeTransitionCrossEffect(global::System.Runtime.InteropServices.HandleRef jarg1);
        }

        internal static partial class CubeTransitionFoldEffect
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionFoldEffect_New")]
            public static extern global::System.IntPtr CubeTransitionFoldEffect_New(uint numRows, uint numColumns);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CubeTransitionFoldEffect_SWIGUpcast")]
            public static extern global::System.IntPtr CubeTransitionFoldEffect_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_CubeTransitionFoldEffect")]
            public static extern void delete_CubeTransitionFoldEffect(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
