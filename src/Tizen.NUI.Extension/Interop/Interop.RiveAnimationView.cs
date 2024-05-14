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

namespace Tizen.NUI.Extension
{
    internal static partial class Interop
    {
        internal static partial class RiveAnimationView
        {
            public const string Lib = "libdali2-csharp-binder-rive-animation.so";

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CSharp_Dali_RiveAnimationView_New__SWIG_0")]
            public static extern global::System.IntPtr New(string url);

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CSharp_Dali_RiveAnimationView_EnableAnimation")]
            public static extern void EnableAnimation(global::System.Runtime.InteropServices.HandleRef handle, string animationName, bool on);
            
            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CSharp_Dali_RiveAnimationView_SetShapeFillColor")]
            public static extern void SetShapeFillColor(global::System.Runtime.InteropServices.HandleRef handle, string shapeFillName, global::System.Runtime.InteropServices.HandleRef color);

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CSharp_Dali_RiveAnimationView_SetShapeStrokeColor")]
            public static extern void SetShapeStrokeColor(global::System.Runtime.InteropServices.HandleRef handle, string shapeStrokeName, global::System.Runtime.InteropServices.HandleRef color);

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CSharp_Dali_RiveAnimationView_SetNodeOpacity")]
            public static extern void SetNodeOpacity(global::System.Runtime.InteropServices.HandleRef handle, string nodeOpacity, float opacity);

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CSharp_Dali_RiveAnimationView_SetNodeScale")]
            public static extern void SetNodeScale(global::System.Runtime.InteropServices.HandleRef handle, string nodeScale, global::System.Runtime.InteropServices.HandleRef scale);

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CSharp_Dali_RiveAnimationView_SetNodeRotation")]
            public static extern void SetNodeRotation(global::System.Runtime.InteropServices.HandleRef handle, string nodeRotation, global::System.Runtime.InteropServices.HandleRef degree);
            
            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CSharp_Dali_RiveAnimationView_SetNodePosition")]
            public static extern void SetNodePosition(global::System.Runtime.InteropServices.HandleRef handle, string nodeName, global::System.Runtime.InteropServices.HandleRef position);

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CSharp_Dali_RiveAnimationView_PlayAnimation")]
            public static extern void Play(global::System.Runtime.InteropServices.HandleRef handle);
            
            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CSharp_Dali_RiveAnimationView_PauseAnimation")]
            public static extern void Pause(global::System.Runtime.InteropServices.HandleRef handle);
            
            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CSharp_Dali_RiveAnimationView_StopAnimation")]
            public static extern void Stop(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CSharp_Dali_RiveAnimationView_SetAnimationElapsedTime")]
            public static extern void SetAnimationElapsedTime(global::System.Runtime.InteropServices.HandleRef handle, string animationName, float elapsed);
        }
    }
}
