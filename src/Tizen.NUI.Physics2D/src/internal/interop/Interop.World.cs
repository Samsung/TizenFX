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
using Tizen.NUI.Physics2D.Chipmunk;

namespace Tizen.NUI.Physics2D
{
    internal static partial class Interop
    {
        internal static partial class World
        {
            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsWorld_Lock")]
            internal static extern void Lock(global::System.IntPtr world);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsWorld_Unlock")]
            internal static extern void Unlock(global::System.IntPtr world);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsWorld_GetNative")]
            internal static extern global::System.IntPtr GetNative(global::System.IntPtr world);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsWorld_HitTest")]
            internal static extern global::System.IntPtr HitTest(global::System.IntPtr world, HandleRef rayFromWorld,
                                                                 HandleRef rayToWorld, Chipmunk.ShapeFilter nativeFilter,
                                                                 HandleRef localPivot, out float distanceFromCamera);
        }
    }
}
