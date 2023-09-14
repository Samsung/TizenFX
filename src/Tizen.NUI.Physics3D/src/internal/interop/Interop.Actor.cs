/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd.
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
 */

using System;
using System.Runtime.InteropServices;

namespace Tizen.NUI.Physics3D
{
    internal static partial class Interop
    {
        internal static class Actor
        {
            [DllImport(Libraries.Physics3D, EntryPoint = "CSharp_Dali_PhysicsActor_New")]
            internal static extern global::System.IntPtr PhysicsActorNew(HandleRef actor, IntPtr body, HandleRef adaptor);

            [DllImport(Libraries.Physics3D, EntryPoint = "CSharp_Dali_new_PhysicsActor__SWIG_0")]
            internal static extern global::System.IntPtr NewPhysicsActor();

            [DllImport(Libraries.Physics3D, EntryPoint = "CSharp_Dali_new_PhysicsActor__SWIG_1")]
            internal static extern global::System.IntPtr NewPhysicsActor(HandleRef rhs);

            [DllImport(Libraries.Physics3D, EntryPoint = "CSharp_Dali_PhysicsActor_DownCast")]
            internal static extern global::System.IntPtr DownCast(HandleRef handle);

            [DllImport(Libraries.Physics3D, EntryPoint = "CSharp_Dali_delete_PhysicsActor")]
            internal static extern void DeletePhysicsActor(HandleRef handle);

            [DllImport(Libraries.Physics3D, EntryPoint = "CSharp_Dali_PhysicsActor_Assign")]
            internal static extern global::System.IntPtr Assign(HandleRef destination, HandleRef source);

            [DllImport(Libraries.Physics3D, EntryPoint = "CSharp_Dali_PhysicsActor_GetId")]
            internal static extern uint GetId(HandleRef handle);

            [DllImport(Libraries.Physics3D, EntryPoint = "CSharp_Dali_PhysicsActor_GetBody")]
            internal static extern global::System.IntPtr GetBody(HandleRef handle);

            [DllImport(Libraries.Physics3D, EntryPoint = "CSharp_Dali_PhysicsActor_AsyncSetPhysicsPosition")]
            internal static extern void AsyncSetPhysicsPosition(HandleRef handle, HandleRef position);

            [DllImport(Libraries.Physics3D, EntryPoint = "CSharp_Dali_PhysicsActor_AsyncSetPhysicsRotation")]
            internal static extern void AsyncSetPhysicsRotation(HandleRef handle, HandleRef rotation);

            [DllImport(Libraries.Physics3D, EntryPoint = "CSharp_Dali_PhysicsActor_GetPhysicsPosition")]
            internal static extern global::System.IntPtr GetPhysicsPosition(HandleRef handle);

            [DllImport(Libraries.Physics3D, EntryPoint = "CSharp_Dali_PhysicsActor_GetPhysicsRotation")]
            internal static extern global::System.IntPtr GetPhysicsRotation(HandleRef handle);

            [DllImport(Libraries.Physics3D, EntryPoint = "CSharp_Dali_PhysicsActor_GetActorPosition")]
            internal static extern global::System.IntPtr GetActorPosition(HandleRef handle);

            [DllImport(Libraries.Physics3D, EntryPoint = "CSharp_Dali_PhysicsActor_GetActorRotation")]
            internal static extern global::System.IntPtr GetActorRotation(HandleRef handle);
        }
    }
}
