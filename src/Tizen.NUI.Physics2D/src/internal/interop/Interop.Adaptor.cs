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
        internal static class Adaptor
        {
            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_New")]
            internal static extern global::System.IntPtr PhysicsAdaptorNew(HandleRef matrix, HandleRef size);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_new_PhysicsAdaptor__SWIG_0")]
            internal static extern global::System.IntPtr NewPhysicsAdaptor();

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_new_PhysicsAdaptor__SWIG_1")]
            internal static extern global::System.IntPtr NewPhysicsAdaptor(HandleRef rhs);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_delete_PhysicsAdaptor")]
            internal static extern void DeletePhysicsAdaptor(HandleRef handle);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_DownCast")]
            internal static extern global::System.IntPtr DownCast(HandleRef handle);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_Assign")]
            internal static extern global::System.IntPtr Assign(HandleRef destination, HandleRef source);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_SetTimestep")]
            internal static extern void SetTimestep(HandleRef adaptor, float timestep);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_GetTimestep")]
            internal static extern float GetTimestep(HandleRef adaptor);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_CreateDebugLayer")]
            internal static extern global::System.IntPtr CreateDebugLayer(HandleRef adaptor, HandleRef window);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_TranslateToPhysicsSpace_1")]
            internal static extern global::System.IntPtr TranslatePositionToPhysicsSpace(HandleRef adaptor, HandleRef position);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_TranslateToPhysicsSpace_2")]
            internal static extern global::System.IntPtr TranslateRotationToPhysicsSpace(HandleRef adaptor, HandleRef rotation);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_TranslateFromPhysicsSpace_1")]
            internal static extern global::System.IntPtr TranslatePositionFromPhysicsSpace(HandleRef adaptor, HandleRef position);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_TranslateFromPhysicsSpace_2")]
            internal static extern global::System.IntPtr TranslateRotationFromPhysicsSpace(HandleRef adaptor, HandleRef rotation);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_ConvertVectorToPhysicsSpace")]
            internal static extern global::System.IntPtr ConvertVectorToPhysicsSpace(HandleRef adaptor, HandleRef vector);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_ConvertVectorFromPhysicsSpace")]
            internal static extern global::System.IntPtr ConvertVectorFromPhysicsSpace(HandleRef adaptor, HandleRef vector);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_SetTransformAndSize")]
            internal static extern void SetTransformAndSize(HandleRef adaptor, HandleRef transform, HandleRef size);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_SetIntegrationState")]
            internal static extern void SetIntegrationState(HandleRef adaptor, int integrationState);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_GetIntegrationState")]
            internal static extern int GetIntegrationState(HandleRef adaptor);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_SetDebugState")]
            internal static extern void SetDebugState(HandleRef adaptor, int integrationState);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_GetDebugState")]
            internal static extern int GetDebugState(HandleRef adaptor);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_AddActorBody")]
            internal static extern global::System.IntPtr AddActorBody(HandleRef adaptor, HandleRef actor, global::System.IntPtr body);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_RemoveActorBody")]
            internal static extern void RemoveActorBody(HandleRef adaptor, HandleRef physicsActor);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_GetPhysicsActor")]
            internal static extern global::System.IntPtr GetPhysicsActor(HandleRef adaptor, global::System.IntPtr body);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_SetRootActor")]
            internal static extern void SetRootActor(HandleRef adaptor, HandleRef actor);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_GetRootActor")]
            internal static extern global::System.IntPtr GetRootActor(HandleRef adaptor);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_BuildPickingRay")]
            internal static extern void BuildPickingRay(HandleRef adaptor, HandleRef origin, HandleRef direction,
                                                        HandleRef rayFromWorld, HandleRef rayToWorld);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_ProjectPoint")]
            internal static extern global::System.IntPtr ProjectPoint(HandleRef adaptor, HandleRef origin, HandleRef direction, float distance);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_CreateSyncPoint")]
            internal static extern void CreateSyncPoint(HandleRef adaptor);

            [DllImport(Libraries.Physics2D, EntryPoint = "CSharp_Dali_PhysicsAdaptor_GetPhysicsWorld")]
            internal static extern global::System.IntPtr GetPhysicsWorld(HandleRef adaptor);
        }
    }
}
