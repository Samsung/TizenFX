/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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
    class NDalicManualPINVOKE
    {
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_new_KeyboardFocusManager")]
        public static extern global::System.IntPtr new_FocusManager_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_new_KeyboardFocusManager")]
        public static extern global::System.IntPtr new_FocusManager_vulkan();

        public static global::System.IntPtr new_FocusManager()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_FocusManager_vulkan();
            }
            else
            {
                return new_FocusManager_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_delete_KeyboardFocusManager")]
        public static extern void delete_FocusManager_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_delete_KeyboardFocusManager")]
        public static extern void delete_FocusManager_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_FocusManager(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_FocusManager_vulkan(jarg1);
            }
            else
            {
                delete_FocusManager_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_Get")]
        public static extern global::System.IntPtr FocusManager_Get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_Get")]
        public static extern global::System.IntPtr FocusManager_Get_vulkan();

        public static global::System.IntPtr FocusManager_Get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FocusManager_Get_vulkan();
            }
            else
            {
                return FocusManager_Get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_SetCurrentFocusActor")]
        public static extern bool FocusManager_SetCurrentFocusActor_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_SetCurrentFocusActor")]
        public static extern bool FocusManager_SetCurrentFocusActor_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static bool FocusManager_SetCurrentFocusActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FocusManager_SetCurrentFocusActor_vulkan(jarg1, jarg2);
            }
            else
            {
                return FocusManager_SetCurrentFocusActor_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_GetCurrentFocusActor")]
        public static extern global::System.IntPtr FocusManager_GetCurrentFocusActor_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_GetCurrentFocusActor")]
        public static extern global::System.IntPtr FocusManager_GetCurrentFocusActor_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr FocusManager_GetCurrentFocusActor(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FocusManager_GetCurrentFocusActor_vulkan(jarg1);
            }
            else
            {
                return FocusManager_GetCurrentFocusActor_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_MoveFocus")]
        public static extern bool FocusManager_MoveFocus_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_MoveFocus")]
        public static extern bool FocusManager_MoveFocus_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static bool FocusManager_MoveFocus(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FocusManager_MoveFocus_vulkan(jarg1, jarg2);
            }
            else
            {
                return FocusManager_MoveFocus_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_ClearFocus")]
        public static extern void FocusManager_ClearFocus_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_ClearFocus")]
        public static extern void FocusManager_ClearFocus_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void FocusManager_ClearFocus(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FocusManager_ClearFocus_vulkan(jarg1);
            }
            else
            {
                FocusManager_ClearFocus_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_SetFocusGroupLoop")]
        public static extern void FocusManager_SetFocusGroupLoop_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_SetFocusGroupLoop")]
        public static extern void FocusManager_SetFocusGroupLoop_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void FocusManager_SetFocusGroupLoop(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FocusManager_SetFocusGroupLoop_vulkan(jarg1, jarg2);
            }
            else
            {
                FocusManager_SetFocusGroupLoop_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_GetFocusGroupLoop")]
        public static extern bool FocusManager_GetFocusGroupLoop_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_GetFocusGroupLoop")]
        public static extern bool FocusManager_GetFocusGroupLoop_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool FocusManager_GetFocusGroupLoop(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FocusManager_GetFocusGroupLoop_vulkan(jarg1);
            }
            else
            {
                return FocusManager_GetFocusGroupLoop_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_SetAsFocusGroup")]
        public static extern void FocusManager_SetAsFocusGroup_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_SetAsFocusGroup")]
        public static extern void FocusManager_SetAsFocusGroup_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3);

        public static void FocusManager_SetAsFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FocusManager_SetAsFocusGroup_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                FocusManager_SetAsFocusGroup_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_IsFocusGroup")]
        public static extern bool FocusManager_IsFocusGroup_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_IsFocusGroup")]
        public static extern bool FocusManager_IsFocusGroup_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static bool FocusManager_IsFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FocusManager_IsFocusGroup_vulkan(jarg1, jarg2);
            }
            else
            {
                return FocusManager_IsFocusGroup_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_GetFocusGroup")]
        public static extern global::System.IntPtr FocusManager_GetFocusGroup_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_GetFocusGroup")]
        public static extern global::System.IntPtr FocusManager_GetFocusGroup_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr FocusManager_GetFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FocusManager_GetFocusGroup_vulkan(jarg1, jarg2);
            }
            else
            {
                return FocusManager_GetFocusGroup_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_SetFocusIndicatorActor")]
        public static extern void FocusManager_SetFocusIndicatorActor_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_SetFocusIndicatorActor")]
        public static extern void FocusManager_SetFocusIndicatorActor_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void FocusManager_SetFocusIndicatorActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FocusManager_SetFocusIndicatorActor_vulkan(jarg1, jarg2);
            }
            else
            {
                FocusManager_SetFocusIndicatorActor_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_GetFocusIndicatorActor")]
        public static extern global::System.IntPtr FocusManager_GetFocusIndicatorActor_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_GetFocusIndicatorActor")]
        public static extern global::System.IntPtr FocusManager_GetFocusIndicatorActor_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr FocusManager_GetFocusIndicatorActor(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FocusManager_GetFocusIndicatorActor_vulkan(jarg1);
            }
            else
            {
                return FocusManager_GetFocusIndicatorActor_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_MoveFocusBackward")]
        public static extern void FocusManager_MoveFocusBackward_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_MoveFocusBackward")]
        public static extern void FocusManager_MoveFocusBackward_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void FocusManager_MoveFocusBackward(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FocusManager_MoveFocusBackward_vulkan(jarg1);
            }
            else
            {
                FocusManager_MoveFocusBackward_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_PreFocusChangeSignal")]
        public static extern global::System.IntPtr FocusManager_PreFocusChangeSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_PreFocusChangeSignal")]
        public static extern global::System.IntPtr FocusManager_PreFocusChangeSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr FocusManager_PreFocusChangeSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FocusManager_PreFocusChangeSignal_vulkan(jarg1);
            }
            else
            {
                return FocusManager_PreFocusChangeSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_FocusChangedSignal")]
        public static extern global::System.IntPtr FocusManager_FocusChangedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_FocusChangedSignal")]
        public static extern global::System.IntPtr FocusManager_FocusChangedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr FocusManager_FocusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FocusManager_FocusChangedSignal_vulkan(jarg1);
            }
            else
            {
                return FocusManager_FocusChangedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_FocusGroupChangedSignal")]
        public static extern global::System.IntPtr FocusManager_FocusGroupChangedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_FocusGroupChangedSignal")]
        public static extern global::System.IntPtr FocusManager_FocusGroupChangedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr FocusManager_FocusGroupChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FocusManager_FocusGroupChangedSignal_vulkan(jarg1);
            }
            else
            {
                return FocusManager_FocusGroupChangedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_FocusedActorEnterKeySignal")]
        public static extern global::System.IntPtr FocusManager_FocusedActorEnterKeySignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_FocusedActorEnterKeySignal")]
        public static extern global::System.IntPtr FocusManager_FocusedActorEnterKeySignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr FocusManager_FocusedActorEnterKeySignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FocusManager_FocusedActorEnterKeySignal_vulkan(jarg1);
            }
            else
            {
                return FocusManager_FocusedActorEnterKeySignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Empty")]
        public static extern bool PreFocusChangeSignal_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Empty")]
        public static extern bool PreFocusChangeSignal_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool PreFocusChangeSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return PreFocusChangeSignal_Empty_vulkan(jarg1);
            }
            else
            {
                return PreFocusChangeSignal_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_GetConnectionCount")]
        public static extern uint PreFocusChangeSignal_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_GetConnectionCount")]
        public static extern uint PreFocusChangeSignal_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint PreFocusChangeSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return PreFocusChangeSignal_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return PreFocusChangeSignal_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Connect")]
        public static extern void PreFocusChangeSignal_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, FocusManager.PreFocusChangeEventCallback delegate1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Connect")]
        public static extern void PreFocusChangeSignal_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, FocusManager.PreFocusChangeEventCallback delegate1);

        public static void PreFocusChangeSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, FocusManager.PreFocusChangeEventCallback delegate1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                PreFocusChangeSignal_Connect_vulkan(jarg1, delegate1);
            }
            else
            {
                PreFocusChangeSignal_Connect_gl(jarg1, delegate1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Disconnect")]
        public static extern void PreFocusChangeSignal_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Disconnect")]
        public static extern void PreFocusChangeSignal_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void PreFocusChangeSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                PreFocusChangeSignal_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                PreFocusChangeSignal_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Emit")]
        public static extern global::System.IntPtr PreFocusChangeSignal_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Emit")]
        public static extern global::System.IntPtr PreFocusChangeSignal_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4);

        public static global::System.IntPtr PreFocusChangeSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return PreFocusChangeSignal_Emit_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                return PreFocusChangeSignal_Emit_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_new_KeyboardPreFocusChangeSignal")]
        public static extern global::System.IntPtr new_PreFocusChangeSignal_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_new_KeyboardPreFocusChangeSignal")]
        public static extern global::System.IntPtr new_PreFocusChangeSignal_vulkan();

        public static global::System.IntPtr new_PreFocusChangeSignal()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_PreFocusChangeSignal_vulkan();
            }
            else
            {
                return new_PreFocusChangeSignal_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_delete_KeyboardPreFocusChangeSignal")]
        public static extern void delete_PreFocusChangeSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_delete_KeyboardPreFocusChangeSignal")]
        public static extern void delete_PreFocusChangeSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_PreFocusChangeSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_PreFocusChangeSignal_vulkan(jarg1);
            }
            else
            {
                delete_PreFocusChangeSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_SWIGUpcast")]
        public static extern global::System.IntPtr FocusManager_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_KeyboardFocusManager_SWIGUpcast")]
        public static extern global::System.IntPtr FocusManager_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr FocusManager_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FocusManager_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return FocusManager_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get")]
        public static extern int ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get")]
        public static extern int ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get_vulkan();

        public static int ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get_vulkan();
            }
            else
            {
                return ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_ViewWrapperImpl")]
        public static extern global::System.IntPtr new_ViewWrapperImpl_gl(int jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_ViewWrapperImpl")]
        public static extern global::System.IntPtr new_ViewWrapperImpl_vulkan(int jarg1);

        public static global::System.IntPtr new_ViewWrapperImpl(int jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_ViewWrapperImpl_vulkan(jarg1);
            }
            else
            {
                return new_ViewWrapperImpl_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapperImpl_New")]
        public static extern global::System.IntPtr ViewWrapperImpl_New_gl(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapperImpl_New")]
        public static extern global::System.IntPtr ViewWrapperImpl_New_vulkan(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr ViewWrapperImpl_New(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapperImpl_New_vulkan(jarg1, jarg2);
            }
            else
            {
                return ViewWrapperImpl_New_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_ViewWrapperImpl")]
        public static extern void delete_ViewWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_ViewWrapperImpl")]
        public static extern void delete_ViewWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_ViewWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_ViewWrapperImpl_vulkan(jarg1);
            }
            else
            {
                delete_ViewWrapperImpl_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapperImpl_director_connect")]
        public static extern void ViewWrapperImpl_director_connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, ViewWrapperImpl.DelegateViewWrapperImpl_0 delegate0, ViewWrapperImpl.DelegateViewWrapperImpl_1 delegate1, ViewWrapperImpl.DelegateViewWrapperImpl_2 delegate2, ViewWrapperImpl.DelegateViewWrapperImpl_3 delegate3, ViewWrapperImpl.DelegateViewWrapperImpl_4 delegate4, ViewWrapperImpl.DelegateViewWrapperImpl_5 delegate5, ViewWrapperImpl.DelegateViewWrapperImpl_6 delegate6, ViewWrapperImpl.DelegateViewWrapperImpl_7 delegate7, ViewWrapperImpl.DelegateViewWrapperImpl_8 delegate8, ViewWrapperImpl.DelegateViewWrapperImpl_9 delegate9, ViewWrapperImpl.DelegateViewWrapperImpl_10 delegate10, ViewWrapperImpl.DelegateViewWrapperImpl_11 delegate11, ViewWrapperImpl.DelegateViewWrapperImpl_12 delegate12, ViewWrapperImpl.DelegateViewWrapperImpl_13 delegate13, ViewWrapperImpl.DelegateViewWrapperImpl_14 delegate14, ViewWrapperImpl.DelegateViewWrapperImpl_15 delegate15, ViewWrapperImpl.DelegateViewWrapperImpl_16 delegate16, ViewWrapperImpl.DelegateViewWrapperImpl_17 delegate17, ViewWrapperImpl.DelegateViewWrapperImpl_18 delegate18, ViewWrapperImpl.DelegateViewWrapperImpl_19 delegate19, ViewWrapperImpl.DelegateViewWrapperImpl_20 delegate20, ViewWrapperImpl.DelegateViewWrapperImpl_21 delegate21, ViewWrapperImpl.DelegateViewWrapperImpl_22 delegate22, ViewWrapperImpl.DelegateViewWrapperImpl_23 delegate23, ViewWrapperImpl.DelegateViewWrapperImpl_24 delegate24, ViewWrapperImpl.DelegateViewWrapperImpl_25 delegate25, ViewWrapperImpl.DelegateViewWrapperImpl_26 delegate26, ViewWrapperImpl.DelegateViewWrapperImpl_27 delegate27, ViewWrapperImpl.DelegateViewWrapperImpl_28 delegate28, ViewWrapperImpl.DelegateViewWrapperImpl_29 delegate29, ViewWrapperImpl.DelegateViewWrapperImpl_30 delegate30, ViewWrapperImpl.DelegateViewWrapperImpl_31 delegate31, ViewWrapperImpl.DelegateViewWrapperImpl_32 delegate32, ViewWrapperImpl.DelegateViewWrapperImpl_33 delegate33, ViewWrapperImpl.DelegateViewWrapperImpl_34 delegate34, ViewWrapperImpl.DelegateViewWrapperImpl_35 delegate35, ViewWrapperImpl.DelegateViewWrapperImpl_36 delegate36, ViewWrapperImpl.DelegateViewWrapperImpl_37 delegate37, ViewWrapperImpl.DelegateViewWrapperImpl_38 delegate38, ViewWrapperImpl.DelegateViewWrapperImpl_39 delegate39, ViewWrapperImpl.DelegateViewWrapperImpl_40 delegate40);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapperImpl_director_connect")]
        public static extern void ViewWrapperImpl_director_connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, ViewWrapperImpl.DelegateViewWrapperImpl_0 delegate0, ViewWrapperImpl.DelegateViewWrapperImpl_1 delegate1, ViewWrapperImpl.DelegateViewWrapperImpl_2 delegate2, ViewWrapperImpl.DelegateViewWrapperImpl_3 delegate3, ViewWrapperImpl.DelegateViewWrapperImpl_4 delegate4, ViewWrapperImpl.DelegateViewWrapperImpl_5 delegate5, ViewWrapperImpl.DelegateViewWrapperImpl_6 delegate6, ViewWrapperImpl.DelegateViewWrapperImpl_7 delegate7, ViewWrapperImpl.DelegateViewWrapperImpl_8 delegate8, ViewWrapperImpl.DelegateViewWrapperImpl_9 delegate9, ViewWrapperImpl.DelegateViewWrapperImpl_10 delegate10, ViewWrapperImpl.DelegateViewWrapperImpl_11 delegate11, ViewWrapperImpl.DelegateViewWrapperImpl_12 delegate12, ViewWrapperImpl.DelegateViewWrapperImpl_13 delegate13, ViewWrapperImpl.DelegateViewWrapperImpl_14 delegate14, ViewWrapperImpl.DelegateViewWrapperImpl_15 delegate15, ViewWrapperImpl.DelegateViewWrapperImpl_16 delegate16, ViewWrapperImpl.DelegateViewWrapperImpl_17 delegate17, ViewWrapperImpl.DelegateViewWrapperImpl_18 delegate18, ViewWrapperImpl.DelegateViewWrapperImpl_19 delegate19, ViewWrapperImpl.DelegateViewWrapperImpl_20 delegate20, ViewWrapperImpl.DelegateViewWrapperImpl_21 delegate21, ViewWrapperImpl.DelegateViewWrapperImpl_22 delegate22, ViewWrapperImpl.DelegateViewWrapperImpl_23 delegate23, ViewWrapperImpl.DelegateViewWrapperImpl_24 delegate24, ViewWrapperImpl.DelegateViewWrapperImpl_25 delegate25, ViewWrapperImpl.DelegateViewWrapperImpl_26 delegate26, ViewWrapperImpl.DelegateViewWrapperImpl_27 delegate27, ViewWrapperImpl.DelegateViewWrapperImpl_28 delegate28, ViewWrapperImpl.DelegateViewWrapperImpl_29 delegate29, ViewWrapperImpl.DelegateViewWrapperImpl_30 delegate30, ViewWrapperImpl.DelegateViewWrapperImpl_31 delegate31, ViewWrapperImpl.DelegateViewWrapperImpl_32 delegate32, ViewWrapperImpl.DelegateViewWrapperImpl_33 delegate33, ViewWrapperImpl.DelegateViewWrapperImpl_34 delegate34, ViewWrapperImpl.DelegateViewWrapperImpl_35 delegate35, ViewWrapperImpl.DelegateViewWrapperImpl_36 delegate36, ViewWrapperImpl.DelegateViewWrapperImpl_37 delegate37, ViewWrapperImpl.DelegateViewWrapperImpl_38 delegate38, ViewWrapperImpl.DelegateViewWrapperImpl_39 delegate39, ViewWrapperImpl.DelegateViewWrapperImpl_40 delegate40);

        public static void ViewWrapperImpl_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, ViewWrapperImpl.DelegateViewWrapperImpl_0 delegate0, ViewWrapperImpl.DelegateViewWrapperImpl_1 delegate1, ViewWrapperImpl.DelegateViewWrapperImpl_2 delegate2, ViewWrapperImpl.DelegateViewWrapperImpl_3 delegate3, ViewWrapperImpl.DelegateViewWrapperImpl_4 delegate4, ViewWrapperImpl.DelegateViewWrapperImpl_5 delegate5, ViewWrapperImpl.DelegateViewWrapperImpl_6 delegate6, ViewWrapperImpl.DelegateViewWrapperImpl_7 delegate7, ViewWrapperImpl.DelegateViewWrapperImpl_8 delegate8, ViewWrapperImpl.DelegateViewWrapperImpl_9 delegate9, ViewWrapperImpl.DelegateViewWrapperImpl_10 delegate10, ViewWrapperImpl.DelegateViewWrapperImpl_11 delegate11, ViewWrapperImpl.DelegateViewWrapperImpl_12 delegate12, ViewWrapperImpl.DelegateViewWrapperImpl_13 delegate13, ViewWrapperImpl.DelegateViewWrapperImpl_14 delegate14, ViewWrapperImpl.DelegateViewWrapperImpl_15 delegate15, ViewWrapperImpl.DelegateViewWrapperImpl_16 delegate16, ViewWrapperImpl.DelegateViewWrapperImpl_17 delegate17, ViewWrapperImpl.DelegateViewWrapperImpl_18 delegate18, ViewWrapperImpl.DelegateViewWrapperImpl_19 delegate19, ViewWrapperImpl.DelegateViewWrapperImpl_20 delegate20, ViewWrapperImpl.DelegateViewWrapperImpl_21 delegate21, ViewWrapperImpl.DelegateViewWrapperImpl_22 delegate22, ViewWrapperImpl.DelegateViewWrapperImpl_23 delegate23, ViewWrapperImpl.DelegateViewWrapperImpl_24 delegate24, ViewWrapperImpl.DelegateViewWrapperImpl_25 delegate25, ViewWrapperImpl.DelegateViewWrapperImpl_26 delegate26, ViewWrapperImpl.DelegateViewWrapperImpl_27 delegate27, ViewWrapperImpl.DelegateViewWrapperImpl_28 delegate28, ViewWrapperImpl.DelegateViewWrapperImpl_29 delegate29, ViewWrapperImpl.DelegateViewWrapperImpl_30 delegate30, ViewWrapperImpl.DelegateViewWrapperImpl_31 delegate31, ViewWrapperImpl.DelegateViewWrapperImpl_32 delegate32, ViewWrapperImpl.DelegateViewWrapperImpl_33 delegate33, ViewWrapperImpl.DelegateViewWrapperImpl_34 delegate34, ViewWrapperImpl.DelegateViewWrapperImpl_35 delegate35, ViewWrapperImpl.DelegateViewWrapperImpl_36 delegate36, ViewWrapperImpl.DelegateViewWrapperImpl_37 delegate37, ViewWrapperImpl.DelegateViewWrapperImpl_38 delegate38, ViewWrapperImpl.DelegateViewWrapperImpl_39 delegate39, ViewWrapperImpl.DelegateViewWrapperImpl_40 delegate40)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ViewWrapperImpl_director_connect_vulkan(jarg1, delegate0, delegate1, delegate2, delegate3, delegate4, delegate5, delegate6, delegate7, delegate8, delegate9, delegate10, delegate11, delegate12, delegate13, delegate14, delegate15, delegate16, delegate17, delegate18, delegate19, delegate20, delegate21, delegate22, delegate23, delegate24, delegate25, delegate26, delegate27, delegate28, delegate29, delegate30, delegate31, delegate32, delegate33, delegate34, delegate35, delegate36, delegate37, delegate38, delegate39, delegate40);
            }
            else
            {
                ViewWrapperImpl_director_connect_gl(jarg1, delegate0, delegate1, delegate2, delegate3, delegate4, delegate5, delegate6, delegate7, delegate8, delegate9, delegate10, delegate11, delegate12, delegate13, delegate14, delegate15, delegate16, delegate17, delegate18, delegate19, delegate20, delegate21, delegate22, delegate23, delegate24, delegate25, delegate26, delegate27, delegate28, delegate29, delegate30, delegate31, delegate32, delegate33, delegate34, delegate35, delegate36, delegate37, delegate38, delegate39, delegate40);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GetControlWrapperImpl__SWIG_0")]
        public static extern global::System.IntPtr GetControlWrapperImpl__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GetControlWrapperImpl__SWIG_0")]
        public static extern global::System.IntPtr GetControlWrapperImpl__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr GetControlWrapperImpl__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GetControlWrapperImpl__SWIG_0_vulkan(jarg1);
            }
            else
            {
                return GetControlWrapperImpl__SWIG_0_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapper_New")]
        public static extern global::System.IntPtr ViewWrapper_New_gl(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapper_New")]
        public static extern global::System.IntPtr ViewWrapper_New_vulkan(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr ViewWrapper_New(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapper_New_vulkan(jarg1, jarg2);
            }
            else
            {
                return ViewWrapper_New_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_ViewWrapper__SWIG_0")]
        public static extern global::System.IntPtr new_ViewWrapper__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_ViewWrapper__SWIG_0")]
        public static extern global::System.IntPtr new_ViewWrapper__SWIG_0_vulkan();

        public static global::System.IntPtr new_ViewWrapper__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_ViewWrapper__SWIG_0_vulkan();
            }
            else
            {
                return new_ViewWrapper__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_ViewWrapper")]
        public static extern void delete_ViewWrapper_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_ViewWrapper")]
        public static extern void delete_ViewWrapper_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_ViewWrapper(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_ViewWrapper_vulkan(jarg1);
            }
            else
            {
                delete_ViewWrapper_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_ViewWrapper__SWIG_1")]
        public static extern global::System.IntPtr new_ViewWrapper__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_ViewWrapper__SWIG_1")]
        public static extern global::System.IntPtr new_ViewWrapper__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_ViewWrapper__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_ViewWrapper__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_ViewWrapper__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapper_Assign")]
        public static extern global::System.IntPtr ViewWrapper_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapper_Assign")]
        public static extern global::System.IntPtr ViewWrapper_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr ViewWrapper_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapper_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return ViewWrapper_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapper_DownCast")]
        public static extern global::System.IntPtr ViewWrapper_DownCast_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapper_DownCast")]
        public static extern global::System.IntPtr ViewWrapper_DownCast_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr ViewWrapper_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapper_DownCast_vulkan(jarg1);
            }
            else
            {
                return ViewWrapper_DownCast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapperImpl_SWIGUpcast")]
        public static extern global::System.IntPtr ViewWrapperImpl_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapperImpl_SWIGUpcast")]
        public static extern global::System.IntPtr ViewWrapperImpl_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr ViewWrapperImpl_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapperImpl_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return ViewWrapperImpl_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapper_SWIGUpcast")]
        public static extern global::System.IntPtr ViewWrapper_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapper_SWIGUpcast")]
        public static extern global::System.IntPtr ViewWrapper_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr ViewWrapper_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapper_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return ViewWrapper_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutRequest")]
        public static extern void ViewWrapperImpl_RelayoutRequest_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutRequest")]
        public static extern void ViewWrapperImpl_RelayoutRequest_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void ViewWrapperImpl_RelayoutRequest(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ViewWrapperImpl_RelayoutRequest_vulkan(jarg1);
            }
            else
            {
                ViewWrapperImpl_RelayoutRequest_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_GetHeightForWidthBase")]
        public static extern float ViewWrapperImpl_GetHeightForWidthBase_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_GetHeightForWidthBase")]
        public static extern float ViewWrapperImpl_GetHeightForWidthBase_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static float ViewWrapperImpl_GetHeightForWidthBase(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapperImpl_GetHeightForWidthBase_vulkan(jarg1, jarg2);
            }
            else
            {
                return ViewWrapperImpl_GetHeightForWidthBase_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_GetWidthForHeightBase")]
        public static extern float ViewWrapperImpl_GetWidthForHeightBase_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_GetWidthForHeightBase")]
        public static extern float ViewWrapperImpl_GetWidthForHeightBase_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static float ViewWrapperImpl_GetWidthForHeightBase(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapperImpl_GetWidthForHeightBase_vulkan(jarg1, jarg2);
            }
            else
            {
                return ViewWrapperImpl_GetWidthForHeightBase_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_CalculateChildSizeBase")]
        public static extern float ViewWrapperImpl_CalculateChildSizeBase_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_CalculateChildSizeBase")]
        public static extern float ViewWrapperImpl_CalculateChildSizeBase_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

        public static float ViewWrapperImpl_CalculateChildSizeBase(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapperImpl_CalculateChildSizeBase_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return ViewWrapperImpl_CalculateChildSizeBase_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0")]
        public static extern bool ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0")]
        public static extern bool ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static bool ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                return ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1")]
        public static extern bool ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1")]
        public static extern bool ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_RegisterVisual__SWIG_0")]
        public static extern void ViewWrapperImpl_RegisterVisual__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_RegisterVisual__SWIG_0")]
        public static extern void ViewWrapperImpl_RegisterVisual__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void ViewWrapperImpl_RegisterVisual__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ViewWrapperImpl_RegisterVisual__SWIG_0_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                ViewWrapperImpl_RegisterVisual__SWIG_0_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_RegisterVisual__SWIG_1")]
        public static extern void ViewWrapperImpl_RegisterVisual__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, bool jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_RegisterVisual__SWIG_1")]
        public static extern void ViewWrapperImpl_RegisterVisual__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, bool jarg4);

        public static void ViewWrapperImpl_RegisterVisual__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, bool jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ViewWrapperImpl_RegisterVisual__SWIG_1_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                ViewWrapperImpl_RegisterVisual__SWIG_1_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_UnregisterVisual")]
        public static extern void ViewWrapperImpl_UnregisterVisual_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_UnregisterVisual")]
        public static extern void ViewWrapperImpl_UnregisterVisual_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void ViewWrapperImpl_UnregisterVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ViewWrapperImpl_UnregisterVisual_vulkan(jarg1, jarg2);
            }
            else
            {
                ViewWrapperImpl_UnregisterVisual_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_GetVisual")]
        public static extern global::System.IntPtr ViewWrapperImpl_GetVisual_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_GetVisual")]
        public static extern global::System.IntPtr ViewWrapperImpl_GetVisual_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static global::System.IntPtr ViewWrapperImpl_GetVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapperImpl_GetVisual_vulkan(jarg1, jarg2);
            }
            else
            {
                return ViewWrapperImpl_GetVisual_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_EnableVisual")]
        public static extern void ViewWrapperImpl_EnableVisual_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, bool jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_EnableVisual")]
        public static extern void ViewWrapperImpl_EnableVisual_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, bool jarg3);

        public static void ViewWrapperImpl_EnableVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, bool jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ViewWrapperImpl_EnableVisual_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                ViewWrapperImpl_EnableVisual_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_IsVisualEnabled")]
        public static extern bool ViewWrapperImpl_IsVisualEnabled_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_IsVisualEnabled")]
        public static extern bool ViewWrapperImpl_IsVisualEnabled_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static bool ViewWrapperImpl_IsVisualEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapperImpl_IsVisualEnabled_vulkan(jarg1, jarg2);
            }
            else
            {
                return ViewWrapperImpl_IsVisualEnabled_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_CreateTransition")]
        public static extern global::System.IntPtr ViewWrapperImpl_CreateTransition_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_CreateTransition")]
        public static extern global::System.IntPtr ViewWrapperImpl_CreateTransition_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr ViewWrapperImpl_CreateTransition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewWrapperImpl_CreateTransition_vulkan(jarg1, jarg2);
            }
            else
            {
                return ViewWrapperImpl_CreateTransition_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_View_GetVisualResourceStatus")]
        public static extern int View_GetVisualResourceStatus_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_View_GetVisualResourceStatus")]
        public static extern int View_GetVisualResourceStatus_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static int View_GetVisualResourceStatus(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return View_GetVisualResourceStatus_vulkan(jarg1, jarg2);
            }
            else
            {
                return View_GetVisualResourceStatus_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_View_CreateTransition")]
        public static extern global::System.IntPtr View_CreateTransition_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_View_CreateTransition")]
        public static extern global::System.IntPtr View_CreateTransition_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr View_CreateTransition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return View_CreateTransition_vulkan(jarg1, jarg2);
            }
            else
            {
                return View_CreateTransition_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_View_DoAction")]
        public static extern void View_DoAction_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_View_DoAction")]
        public static extern void View_DoAction_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

        public static void View_DoAction(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                View_DoAction_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                View_DoAction_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }


        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_EmitKeyInputFocusSignal")]
        public static extern void ViewWrapperImpl_EmitKeyInputFocusSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ViewWrapperImpl_EmitKeyInputFocusSignal")]
        public static extern void ViewWrapperImpl_EmitKeyInputFocusSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void ViewWrapperImpl_EmitKeyInputFocusSignal(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ViewWrapperImpl_EmitKeyInputFocusSignal_vulkan(jarg1, jarg2);
            }
            else
            {
                ViewWrapperImpl_EmitKeyInputFocusSignal_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapperImpl_ApplyThemeStyle")]
        public static extern void ViewWrapperImpl_ApplyThemeStyle_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ViewWrapperImpl_ApplyThemeStyle")]
        public static extern void ViewWrapperImpl_ApplyThemeStyle_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void ViewWrapperImpl_ApplyThemeStyle(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ViewWrapperImpl_ApplyThemeStyle_vulkan(jarg1);
            }
            else
            {
                ViewWrapperImpl_ApplyThemeStyle_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_EventThreadCallback")]
        public static extern global::System.IntPtr new_EventThreadCallback_gl(EventThreadCallback.CallbackDelegate delegate1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_EventThreadCallback")]
        public static extern global::System.IntPtr new_EventThreadCallback_vulkan(EventThreadCallback.CallbackDelegate delegate1);

        public static global::System.IntPtr new_EventThreadCallback(EventThreadCallback.CallbackDelegate delegate1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_EventThreadCallback_vulkan(delegate1);
            }
            else
            {
                return new_EventThreadCallback_gl(delegate1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_EventThreadCallback")]
        public static extern void delete_EventThreadCallback_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_EventThreadCallback")]
        public static extern void delete_EventThreadCallback_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_EventThreadCallback(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_EventThreadCallback_vulkan(jarg1);
            }
            else
            {
                delete_EventThreadCallback_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_EventThreadCallback_Trigger")]
        public static extern void EventThreadCallback_Trigger_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_EventThreadCallback_Trigger")]
        public static extern void EventThreadCallback_Trigger_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void EventThreadCallback_Trigger(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                EventThreadCallback_Trigger_vulkan(jarg1);
            }
            else
            {
                EventThreadCallback_Trigger_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Actor_Property_SIBLING_ORDER_get")]
        public static extern int Actor_Property_SIBLING_ORDER_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Actor_Property_SIBLING_ORDER_get")]
        public static extern int Actor_Property_SIBLING_ORDER_get_vulkan();

        public static int Actor_Property_SIBLING_ORDER_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Actor_Property_SIBLING_ORDER_get_vulkan();
            }
            else
            {
                return Actor_Property_SIBLING_ORDER_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Actor_Property_OPACITY_get")]
        public static extern int Actor_Property_OPACITY_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Actor_Property_OPACITY_get")]
        public static extern int Actor_Property_OPACITY_get_vulkan();

        public static int Actor_Property_OPACITY_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Actor_Property_OPACITY_get_vulkan();
            }
            else
            {
                return Actor_Property_OPACITY_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Actor_Property_SCREEN_POSITION_get")]
        public static extern int Actor_Property_SCREEN_POSITION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Actor_Property_SCREEN_POSITION_get")]
        public static extern int Actor_Property_SCREEN_POSITION_get_vulkan();

        public static int Actor_Property_SCREEN_POSITION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Actor_Property_SCREEN_POSITION_get_vulkan();
            }
            else
            {
                return Actor_Property_SCREEN_POSITION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Actor_Property_POSITION_USES_ANCHOR_POINT_get")]
        public static extern int Actor_Property_POSITION_USES_ANCHOR_POINT_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Actor_Property_POSITION_USES_ANCHOR_POINT_get")]
        public static extern int Actor_Property_POSITION_USES_ANCHOR_POINT_get_vulkan();

        public static int Actor_Property_POSITION_USES_ANCHOR_POINT_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Actor_Property_POSITION_USES_ANCHOR_POINT_get_vulkan();
            }
            else
            {
                return Actor_Property_POSITION_USES_ANCHOR_POINT_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_View_Property_TOOLTIP_get")]
        public static extern int View_Property_TOOLTIP_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_View_Property_TOOLTIP_get")]
        public static extern int View_Property_TOOLTIP_get_vulkan();

        public static int View_Property_TOOLTIP_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return View_Property_TOOLTIP_get_vulkan();
            }
            else
            {
                return View_Property_TOOLTIP_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_View_Property_STATE_get")]
        public static extern int View_Property_STATE_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_View_Property_STATE_get")]
        public static extern int View_Property_STATE_get_vulkan();

        public static int View_Property_STATE_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return View_Property_STATE_get_vulkan();
            }
            else
            {
                return View_Property_STATE_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_View_Property_SUB_STATE_get")]
        public static extern int View_Property_SUB_STATE_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_View_Property_SUB_STATE_get")]
        public static extern int View_Property_SUB_STATE_get_vulkan();

        public static int View_Property_SUB_STATE_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return View_Property_SUB_STATE_get_vulkan();
            }
            else
            {
                return View_Property_SUB_STATE_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_View_Property_LEFT_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_LEFT_FOCUSABLE_ACTOR_ID_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_View_Property_LEFT_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_LEFT_FOCUSABLE_ACTOR_ID_get_vulkan();

        public static int View_Property_LEFT_FOCUSABLE_ACTOR_ID_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return View_Property_LEFT_FOCUSABLE_ACTOR_ID_get_vulkan();
            }
            else
            {
                return View_Property_LEFT_FOCUSABLE_ACTOR_ID_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get_vulkan();

        public static int View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get_vulkan();
            }
            else
            {
                return View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_View_Property_UP_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_UP_FOCUSABLE_ACTOR_ID_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_View_Property_UP_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_UP_FOCUSABLE_ACTOR_ID_get_vulkan();

        public static int View_Property_UP_FOCUSABLE_ACTOR_ID_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return View_Property_UP_FOCUSABLE_ACTOR_ID_get_vulkan();
            }
            else
            {
                return View_Property_UP_FOCUSABLE_ACTOR_ID_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_View_Property_DOWN_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_DOWN_FOCUSABLE_ACTOR_ID_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_View_Property_DOWN_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_DOWN_FOCUSABLE_ACTOR_ID_get_vulkan();

        public static int View_Property_DOWN_FOCUSABLE_ACTOR_ID_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return View_Property_DOWN_FOCUSABLE_ACTOR_ID_get_vulkan();
            }
            else
            {
                return View_Property_DOWN_FOCUSABLE_ACTOR_ID_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ItemView_Property_LAYOUT_get")]
        public static extern int ItemView_Property_LAYOUT_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ItemView_Property_LAYOUT_get")]
        public static extern int ItemView_Property_LAYOUT_get_vulkan();

        public static int ItemView_Property_LAYOUT_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ItemView_Property_LAYOUT_get_vulkan();
            }
            else
            {
                return ItemView_Property_LAYOUT_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Button_Property_UNSELECTED_VISUAL_get")]
        public static extern int Button_Property_UNSELECTED_VISUAL_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Button_Property_UNSELECTED_VISUAL_get")]
        public static extern int Button_Property_UNSELECTED_VISUAL_get_vulkan();

        public static int Button_Property_UNSELECTED_VISUAL_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Button_Property_UNSELECTED_VISUAL_get_vulkan();
            }
            else
            {
                return Button_Property_UNSELECTED_VISUAL_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Button_Property_SELECTED_VISUAL_get")]
        public static extern int Button_Property_SELECTED_VISUAL_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Button_Property_SELECTED_VISUAL_get")]
        public static extern int Button_Property_SELECTED_VISUAL_get_vulkan();

        public static int Button_Property_SELECTED_VISUAL_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Button_Property_SELECTED_VISUAL_get_vulkan();
            }
            else
            {
                return Button_Property_SELECTED_VISUAL_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Button_Property_DISABLED_SELECTED_VISUAL_get")]
        public static extern int Button_Property_DISABLED_SELECTED_VISUAL_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Button_Property_DISABLED_SELECTED_VISUAL_get")]
        public static extern int Button_Property_DISABLED_SELECTED_VISUAL_get_vulkan();

        public static int Button_Property_DISABLED_SELECTED_VISUAL_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Button_Property_DISABLED_SELECTED_VISUAL_get_vulkan();
            }
            else
            {
                return Button_Property_DISABLED_SELECTED_VISUAL_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Button_Property_DISABLED_UNSELECTED_VISUAL_get")]
        public static extern int Button_Property_DISABLED_UNSELECTED_VISUAL_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Button_Property_DISABLED_UNSELECTED_VISUAL_get")]
        public static extern int Button_Property_DISABLED_UNSELECTED_VISUAL_get_vulkan();

        public static int Button_Property_DISABLED_UNSELECTED_VISUAL_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Button_Property_DISABLED_UNSELECTED_VISUAL_get_vulkan();
            }
            else
            {
                return Button_Property_DISABLED_UNSELECTED_VISUAL_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Button_Property_UNSELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_UNSELECTED_BACKGROUND_VISUAL_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Button_Property_UNSELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_UNSELECTED_BACKGROUND_VISUAL_get_vulkan();

        public static int Button_Property_UNSELECTED_BACKGROUND_VISUAL_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Button_Property_UNSELECTED_BACKGROUND_VISUAL_get_vulkan();
            }
            else
            {
                return Button_Property_UNSELECTED_BACKGROUND_VISUAL_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Button_Property_SELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_SELECTED_BACKGROUND_VISUAL_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Button_Property_SELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_SELECTED_BACKGROUND_VISUAL_get_vulkan();

        public static int Button_Property_SELECTED_BACKGROUND_VISUAL_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Button_Property_SELECTED_BACKGROUND_VISUAL_get_vulkan();
            }
            else
            {
                return Button_Property_SELECTED_BACKGROUND_VISUAL_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Button_Property_DISABLED_UNSELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_DISABLED_UNSELECTED_BACKGROUND_VISUAL_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Button_Property_DISABLED_UNSELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_DISABLED_UNSELECTED_BACKGROUND_VISUAL_get_vulkan();

        public static int Button_Property_DISABLED_UNSELECTED_BACKGROUND_VISUAL_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Button_Property_DISABLED_UNSELECTED_BACKGROUND_VISUAL_get_vulkan();
            }
            else
            {
                return Button_Property_DISABLED_UNSELECTED_BACKGROUND_VISUAL_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Button_Property_DISABLED_SELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_DISABLED_SELECTED_BACKGROUND_VISUAL_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Button_Property_DISABLED_SELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_DISABLED_SELECTED_BACKGROUND_VISUAL_get_vulkan();

        public static int Button_Property_DISABLED_SELECTED_BACKGROUND_VISUAL_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Button_Property_DISABLED_SELECTED_BACKGROUND_VISUAL_get_vulkan();
            }
            else
            {
                return Button_Property_DISABLED_SELECTED_BACKGROUND_VISUAL_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Button_Property_LABEL_RELATIVE_ALIGNMENT_get")]
        public static extern int Button_Property_LABEL_RELATIVE_ALIGNMENT_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Button_Property_LABEL_RELATIVE_ALIGNMENT_get")]
        public static extern int Button_Property_LABEL_RELATIVE_ALIGNMENT_get_vulkan();

        public static int Button_Property_LABEL_RELATIVE_ALIGNMENT_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Button_Property_LABEL_RELATIVE_ALIGNMENT_get_vulkan();
            }
            else
            {
                return Button_Property_LABEL_RELATIVE_ALIGNMENT_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Button_Property_LABEL_PADDING_get")]
        public static extern int Button_Property_LABEL_PADDING_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Button_Property_LABEL_PADDING_get")]
        public static extern int Button_Property_LABEL_PADDING_get_vulkan();

        public static int Button_Property_LABEL_PADDING_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Button_Property_LABEL_PADDING_get_vulkan();
            }
            else
            {
                return Button_Property_LABEL_PADDING_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Button_Property_VISUAL_PADDING_get")]
        public static extern int Button_Property_VISUAL_PADDING_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Button_Property_VISUAL_PADDING_get")]
        public static extern int Button_Property_VISUAL_PADDING_get_vulkan();

        public static int Button_Property_VISUAL_PADDING_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Button_Property_VISUAL_PADDING_get_vulkan();
            }
            else
            {
                return Button_Property_VISUAL_PADDING_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Visual_Property_TRANSFORM_get")]
        public static extern int Visual_Property_TRANSFORM_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Visual_Property_TRANSFORM_get")]
        public static extern int Visual_Property_TRANSFORM_get_vulkan();

        public static int Visual_Property_TRANSFORM_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Visual_Property_TRANSFORM_get_vulkan();
            }
            else
            {
                return Visual_Property_TRANSFORM_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Visual_Property_PREMULTIPLIED_ALPHA_get")]
        public static extern int Visual_Property_PREMULTIPLIED_ALPHA_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Visual_Property_PREMULTIPLIED_ALPHA_get")]
        public static extern int Visual_Property_PREMULTIPLIED_ALPHA_get_vulkan();

        public static int Visual_Property_PREMULTIPLIED_ALPHA_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Visual_Property_PREMULTIPLIED_ALPHA_get_vulkan();
            }
            else
            {
                return Visual_Property_PREMULTIPLIED_ALPHA_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Visual_Property_MIX_COLOR_get")]
        public static extern int Visual_Property_MIX_COLOR_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Visual_Property_MIX_COLOR_get")]
        public static extern int Visual_Property_MIX_COLOR_get_vulkan();

        public static int Visual_Property_MIX_COLOR_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Visual_Property_MIX_COLOR_get_vulkan();
            }
            else
            {
                return Visual_Property_MIX_COLOR_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Image_Visual_BORDER_get")]
        public static extern int Image_Visual_BORDER_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Image_Visual_BORDER_get")]
        public static extern int Image_Visual_BORDER_get_vulkan();

        public static int Image_Visual_BORDER_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Image_Visual_BORDER_get_vulkan();
            }
            else
            {
                return Image_Visual_BORDER_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_NativeVersionCheck")]
        public static extern bool NativeVersionCheck_gl(ref int ver1, ref int ver2, ref int ver3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_NativeVersionCheck")]
        public static extern bool NativeVersionCheck_vulkan(ref int ver1, ref int ver2, ref int ver3);

        public static bool NativeVersionCheck(ref int ver1, ref int ver2, ref int ver3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return NativeVersionCheck_vulkan(ref ver1, ref ver2, ref ver3);
            }
            else
            {
                return NativeVersionCheck_gl(ref ver1, ref ver2, ref ver3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GrabKeyTopmost")]
        public static extern bool GrabKeyTopmost_gl(System.IntPtr Window, int DaliKey);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GrabKeyTopmost")]
        public static extern bool GrabKeyTopmost_vulkan(System.IntPtr Window, int DaliKey);

        public static bool GrabKeyTopmost(System.IntPtr Window, int DaliKey)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GrabKeyTopmost_vulkan(Window, DaliKey);
            }
            else
            {
                return GrabKeyTopmost_gl(Window, DaliKey);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_UngrabKeyTopmost")]
        public static extern bool UngrabKeyTopmost_gl(System.IntPtr Window, int DaliKey);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_UngrabKeyTopmost")]
        public static extern bool UngrabKeyTopmost_vulkan(System.IntPtr Window, int DaliKey);

        public static bool UngrabKeyTopmost(System.IntPtr Window, int DaliKey)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return UngrabKeyTopmost_vulkan(Window, DaliKey);
            }
            else
            {
                return UngrabKeyTopmost_gl(Window, DaliKey);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GrabKey")]
        public static extern bool GrabKey_gl(System.IntPtr Window, int DaliKey, int GrabMode);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GrabKey")]
        public static extern bool GrabKey_vulkan(System.IntPtr Window, int DaliKey, int GrabMode);

        public static bool GrabKey(System.IntPtr Window, int DaliKey, int GrabMode)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GrabKey_vulkan(Window, DaliKey, GrabMode);
            }
            else
            {
                return GrabKey_gl(Window, DaliKey, GrabMode);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_UngrabKey")]
        public static extern bool UngrabKey_gl(System.IntPtr Window, int DaliKey);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_UngrabKey")]
        public static extern bool UngrabKey_vulkan(System.IntPtr Window, int DaliKey);

        public static bool UngrabKey(System.IntPtr Window, int DaliKey)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return UngrabKey_vulkan(Window, DaliKey);
            }
            else
            {
                return UngrabKey_gl(Window, DaliKey);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Keyboard_SetRepeatInfo")]
        public static extern bool SetKeyboardRepeatInfo_gl(float rate, float delay);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Keyboard_SetRepeatInfo")]
        public static extern bool SetKeyboardRepeatInfo_vulkan(float rate, float delay);

        public static bool SetKeyboardRepeatInfo(float rate, float delay)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return SetKeyboardRepeatInfo_vulkan(rate, delay);
            }
            else
            {
                return SetKeyboardRepeatInfo_gl(rate, delay);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Keyboard_GetRepeatInfo")]
        public static extern bool GetKeyboardRepeatInfo_gl(out float rate, out float delay);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Keyboard_GetRepeatInfo")]
        public static extern bool GetKeyboardRepeatInfo_vulkan(out float rate, out float delay);

        public static bool GetKeyboardRepeatInfo(out float rate, out float delay)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GetKeyboardRepeatInfo_vulkan(out rate, out delay);
            }
            else
            {
                return GetKeyboardRepeatInfo_gl(out rate, out delay);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GetNativeWindowHandler")]
        public static extern System.IntPtr GetNativeWindowHandler_gl(System.IntPtr Window);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GetNativeWindowHandler")]
        public static extern System.IntPtr GetNativeWindowHandler_vulkan(System.IntPtr Window);

        public static System.IntPtr GetNativeWindowHandler(System.IntPtr Window)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GetNativeWindowHandler_vulkan(Window);
            }
            else
            {
                return GetNativeWindowHandler_gl(Window);
            }
        }

        //////////////////////InputMethodContext

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_SWIGUpcast")]
        public static extern global::System.IntPtr InputMethodContext_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_SWIGUpcast")]
        public static extern global::System.IntPtr InputMethodContext_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr InputMethodContext_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_InputMethodContext_EventData__SWIG_0")]
        public static extern global::System.IntPtr new_InputMethodContext_EventData__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_InputMethodContext_EventData__SWIG_0")]
        public static extern global::System.IntPtr new_InputMethodContext_EventData__SWIG_0_vulkan();

        public static global::System.IntPtr new_InputMethodContext_EventData__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_InputMethodContext_EventData__SWIG_0_vulkan();
            }
            else
            {
                return new_InputMethodContext_EventData__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_InputMethodContext_EventData__SWIG_1")]
        public static extern global::System.IntPtr new_InputMethodContext_EventData__SWIG_1_gl(int jarg1, string jarg2, int jarg3, int jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_InputMethodContext_EventData__SWIG_1")]
        public static extern global::System.IntPtr new_InputMethodContext_EventData__SWIG_1_vulkan(int jarg1, string jarg2, int jarg3, int jarg4);

        public static global::System.IntPtr new_InputMethodContext_EventData__SWIG_1(int jarg1, string jarg2, int jarg3, int jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_InputMethodContext_EventData__SWIG_1_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                return new_InputMethodContext_EventData__SWIG_1_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_predictiveString_set")]
        public static extern void InputMethodContext_EventData_predictiveString_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_predictiveString_set")]
        public static extern void InputMethodContext_EventData_predictiveString_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static void InputMethodContext_EventData_predictiveString_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_EventData_predictiveString_set_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_EventData_predictiveString_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_predictiveString_get")]
        public static extern string InputMethodContext_EventData_predictiveString_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_predictiveString_get")]
        public static extern string InputMethodContext_EventData_predictiveString_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static string InputMethodContext_EventData_predictiveString_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_EventData_predictiveString_get_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_EventData_predictiveString_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_eventName_set")]
        public static extern void InputMethodContext_EventData_eventName_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_eventName_set")]
        public static extern void InputMethodContext_EventData_eventName_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void InputMethodContext_EventData_eventName_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_EventData_eventName_set_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_EventData_eventName_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_eventName_get")]
        public static extern int InputMethodContext_EventData_eventName_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_eventName_get")]
        public static extern int InputMethodContext_EventData_eventName_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int InputMethodContext_EventData_eventName_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_EventData_eventName_get_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_EventData_eventName_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_cursorOffset_set")]
        public static extern void InputMethodContext_EventData_cursorOffset_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_cursorOffset_set")]
        public static extern void InputMethodContext_EventData_cursorOffset_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void InputMethodContext_EventData_cursorOffset_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_EventData_cursorOffset_set_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_EventData_cursorOffset_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_cursorOffset_get")]
        public static extern int InputMethodContext_EventData_cursorOffset_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_cursorOffset_get")]
        public static extern int InputMethodContext_EventData_cursorOffset_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int InputMethodContext_EventData_cursorOffset_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_EventData_cursorOffset_get_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_EventData_cursorOffset_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_numberOfChars_set")]
        public static extern void InputMethodContext_EventData_numberOfChars_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_numberOfChars_set")]
        public static extern void InputMethodContext_EventData_numberOfChars_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void InputMethodContext_EventData_numberOfChars_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_EventData_numberOfChars_set_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_EventData_numberOfChars_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_numberOfChars_get")]
        public static extern int InputMethodContext_EventData_numberOfChars_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_numberOfChars_get")]
        public static extern int InputMethodContext_EventData_numberOfChars_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int InputMethodContext_EventData_numberOfChars_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_EventData_numberOfChars_get_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_EventData_numberOfChars_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_InputMethodContext_EventData")]
        public static extern void delete_InputMethodContext_EventData_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_InputMethodContext_EventData")]
        public static extern void delete_InputMethodContext_EventData_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_InputMethodContext_EventData(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_InputMethodContext_EventData_vulkan(jarg1);
            }
            else
            {
                delete_InputMethodContext_EventData_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_InputMethodContext_CallbackData__SWIG_0")]
        public static extern global::System.IntPtr new_InputMethodContext_CallbackData__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_InputMethodContext_CallbackData__SWIG_0")]
        public static extern global::System.IntPtr new_InputMethodContext_CallbackData__SWIG_0_vulkan();

        public static global::System.IntPtr new_InputMethodContext_CallbackData__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_InputMethodContext_CallbackData__SWIG_0_vulkan();
            }
            else
            {
                return new_InputMethodContext_CallbackData__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_InputMethodContext_CallbackData__SWIG_1")]
        public static extern global::System.IntPtr new_InputMethodContext_CallbackData__SWIG_1_gl(bool jarg1, int jarg2, string jarg3, bool jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_InputMethodContext_CallbackData__SWIG_1")]
        public static extern global::System.IntPtr new_InputMethodContext_CallbackData__SWIG_1_vulkan(bool jarg1, int jarg2, string jarg3, bool jarg4);

        public static global::System.IntPtr new_InputMethodContext_CallbackData__SWIG_1(bool jarg1, int jarg2, string jarg3, bool jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_InputMethodContext_CallbackData__SWIG_1_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                return new_InputMethodContext_CallbackData__SWIG_1_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_currentText_set")]
        public static extern void InputMethodContext_CallbackData_currentText_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_currentText_set")]
        public static extern void InputMethodContext_CallbackData_currentText_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static void InputMethodContext_CallbackData_currentText_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_CallbackData_currentText_set_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_CallbackData_currentText_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_currentText_get")]
        public static extern string InputMethodContext_CallbackData_currentText_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_currentText_get")]
        public static extern string InputMethodContext_CallbackData_currentText_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static string InputMethodContext_CallbackData_currentText_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_CallbackData_currentText_get_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_CallbackData_currentText_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_cursorPosition_set")]
        public static extern void InputMethodContext_CallbackData_cursorPosition_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_cursorPosition_set")]
        public static extern void InputMethodContext_CallbackData_cursorPosition_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void InputMethodContext_CallbackData_cursorPosition_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_CallbackData_cursorPosition_set_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_CallbackData_cursorPosition_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_cursorPosition_get")]
        public static extern int InputMethodContext_CallbackData_cursorPosition_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_cursorPosition_get")]
        public static extern int InputMethodContext_CallbackData_cursorPosition_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int InputMethodContext_CallbackData_cursorPosition_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_CallbackData_cursorPosition_get_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_CallbackData_cursorPosition_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_update_set")]
        public static extern void InputMethodContext_CallbackData_update_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_update_set")]
        public static extern void InputMethodContext_CallbackData_update_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void InputMethodContext_CallbackData_update_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_CallbackData_update_set_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_CallbackData_update_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_update_get")]
        public static extern bool InputMethodContext_CallbackData_update_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_update_get")]
        public static extern bool InputMethodContext_CallbackData_update_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool InputMethodContext_CallbackData_update_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_CallbackData_update_get_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_CallbackData_update_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_preeditResetRequired_set")]
        public static extern void InputMethodContext_CallbackData_preeditResetRequired_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_preeditResetRequired_set")]
        public static extern void InputMethodContext_CallbackData_preeditResetRequired_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void InputMethodContext_CallbackData_preeditResetRequired_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_CallbackData_preeditResetRequired_set_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_CallbackData_preeditResetRequired_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_preeditResetRequired_get")]
        public static extern bool InputMethodContext_CallbackData_preeditResetRequired_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_preeditResetRequired_get")]
        public static extern bool InputMethodContext_CallbackData_preeditResetRequired_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool InputMethodContext_CallbackData_preeditResetRequired_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_CallbackData_preeditResetRequired_get_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_CallbackData_preeditResetRequired_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_InputMethodContext_CallbackData")]
        public static extern void delete_InputMethodContext_CallbackData_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_InputMethodContext_CallbackData")]
        public static extern void delete_InputMethodContext_CallbackData_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_InputMethodContext_CallbackData(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_InputMethodContext_CallbackData_vulkan(jarg1);
            }
            else
            {
                delete_InputMethodContext_CallbackData_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_Finalize")]
        public static extern void InputMethodContext_Finalize_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_Finalize")]
        public static extern void InputMethodContext_Finalize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void InputMethodContext_Finalize(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_Finalize_vulkan(jarg1);
            }
            else
            {
                InputMethodContext_Finalize_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_InputMethodContext__SWIG_0")]
        public static extern global::System.IntPtr new_InputMethodContext__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_InputMethodContext__SWIG_0")]
        public static extern global::System.IntPtr new_InputMethodContext__SWIG_0_vulkan();

        public static global::System.IntPtr new_InputMethodContext__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_InputMethodContext__SWIG_0_vulkan();
            }
            else
            {
                return new_InputMethodContext__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_InputMethodContext")]
        public static extern void delete_InputMethodContext_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_InputMethodContext")]
        public static extern void delete_InputMethodContext_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_InputMethodContext(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_InputMethodContext_vulkan(jarg1);
            }
            else
            {
                delete_InputMethodContext_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_New")]
        public static extern global::System.IntPtr InputMethodContext_New_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_New")]
        public static extern global::System.IntPtr InputMethodContext_New_vulkan();

        public static global::System.IntPtr InputMethodContext_New()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_New_vulkan();
            }
            else
            {
                return InputMethodContext_New_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_InputMethodContext__SWIG_1")]
        public static extern global::System.IntPtr new_InputMethodContext__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_InputMethodContext__SWIG_1")]
        public static extern global::System.IntPtr new_InputMethodContext__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_InputMethodContext__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_InputMethodContext__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_InputMethodContext__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_Assign")]
        public static extern global::System.IntPtr InputMethodContext_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_Assign")]
        public static extern global::System.IntPtr InputMethodContext_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr InputMethodContext_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return InputMethodContext_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_DownCast")]
        public static extern global::System.IntPtr InputMethodContext_DownCast_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_DownCast")]
        public static extern global::System.IntPtr InputMethodContext_DownCast_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr InputMethodContext_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_DownCast_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_DownCast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_Activate")]
        public static extern void InputMethodContext_Activate_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_Activate")]
        public static extern void InputMethodContext_Activate_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void InputMethodContext_Activate(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_Activate_vulkan(jarg1);
            }
            else
            {
                InputMethodContext_Activate_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_Deactivate")]
        public static extern void InputMethodContext_Deactivate_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_Deactivate")]
        public static extern void InputMethodContext_Deactivate_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void InputMethodContext_Deactivate(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_Deactivate_vulkan(jarg1);
            }
            else
            {
                InputMethodContext_Deactivate_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_RestoreAfterFocusLost")]
        public static extern bool InputMethodContext_RestoreAfterFocusLost_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_RestoreAfterFocusLost")]
        public static extern bool InputMethodContext_RestoreAfterFocusLost_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool InputMethodContext_RestoreAfterFocusLost(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_RestoreAfterFocusLost_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_RestoreAfterFocusLost_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_SetRestoreAfterFocusLost")]
        public static extern void InputMethodContext_SetRestoreAfterFocusLost_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_SetRestoreAfterFocusLost")]
        public static extern void InputMethodContext_SetRestoreAfterFocusLost_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void InputMethodContext_SetRestoreAfterFocusLost(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_SetRestoreAfterFocusLost_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_SetRestoreAfterFocusLost_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_Reset")]
        public static extern void InputMethodContext_Reset_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_Reset")]
        public static extern void InputMethodContext_Reset_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void InputMethodContext_Reset(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_Reset_vulkan(jarg1);
            }
            else
            {
                InputMethodContext_Reset_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_NotifyCursorPosition")]
        public static extern void InputMethodContext_NotifyCursorPosition_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_NotifyCursorPosition")]
        public static extern void InputMethodContext_NotifyCursorPosition_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void InputMethodContext_NotifyCursorPosition(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_NotifyCursorPosition_vulkan(jarg1);
            }
            else
            {
                InputMethodContext_NotifyCursorPosition_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_SetCursorPosition")]
        public static extern void InputMethodContext_SetCursorPosition_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_SetCursorPosition")]
        public static extern void InputMethodContext_SetCursorPosition_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static void InputMethodContext_SetCursorPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_SetCursorPosition_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_SetCursorPosition_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetCursorPosition")]
        public static extern uint InputMethodContext_GetCursorPosition_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetCursorPosition")]
        public static extern uint InputMethodContext_GetCursorPosition_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint InputMethodContext_GetCursorPosition(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_GetCursorPosition_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_GetCursorPosition_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_SetSurroundingText")]
        public static extern void InputMethodContext_SetSurroundingText_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_SetSurroundingText")]
        public static extern void InputMethodContext_SetSurroundingText_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static void InputMethodContext_SetSurroundingText(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_SetSurroundingText_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_SetSurroundingText_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetSurroundingText")]
        public static extern string InputMethodContext_GetSurroundingText_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetSurroundingText")]
        public static extern string InputMethodContext_GetSurroundingText_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static string InputMethodContext_GetSurroundingText(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_GetSurroundingText_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_GetSurroundingText_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_NotifyTextInputMultiLine")]
        public static extern void InputMethodContext_NotifyTextInputMultiLine_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_NotifyTextInputMultiLine")]
        public static extern void InputMethodContext_NotifyTextInputMultiLine_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void InputMethodContext_NotifyTextInputMultiLine(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_NotifyTextInputMultiLine_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_NotifyTextInputMultiLine_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetTextDirection")]
        public static extern int InputMethodContext_GetTextDirection_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetTextDirection")]
        public static extern int InputMethodContext_GetTextDirection_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int InputMethodContext_GetTextDirection(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_GetTextDirection_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_GetTextDirection_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputMethodArea")]
        public static extern global::System.IntPtr InputMethodContext_GetInputMethodArea_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputMethodArea")]
        public static extern global::System.IntPtr InputMethodContext_GetInputMethodArea_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr InputMethodContext_GetInputMethodArea(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_GetInputMethodArea_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_GetInputMethodArea_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_ApplyOptions")]
        public static extern void InputMethodContext_ApplyOptions_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_ApplyOptions")]
        public static extern void InputMethodContext_ApplyOptions_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void InputMethodContext_ApplyOptions(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_ApplyOptions_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_ApplyOptions_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_SetInputPanelUserData")]
        public static extern void InputMethodContext_SetInputPanelUserData_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_SetInputPanelUserData")]
        public static extern void InputMethodContext_SetInputPanelUserData_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static void InputMethodContext_SetInputPanelUserData(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_SetInputPanelUserData_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_SetInputPanelUserData_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelUserData")]
        public static extern void InputMethodContext_GetInputPanelUserData_gl(global::System.Runtime.InteropServices.HandleRef jarg1, out string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelUserData")]
        public static extern void InputMethodContext_GetInputPanelUserData_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, out string jarg2);

        public static void InputMethodContext_GetInputPanelUserData(global::System.Runtime.InteropServices.HandleRef jarg1, out string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_GetInputPanelUserData_vulkan(jarg1, out jarg2);
            }
            else
            {
                InputMethodContext_GetInputPanelUserData_gl(jarg1, out jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelState")]
        public static extern int InputMethodContext_GetInputPanelState_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelState")]
        public static extern int InputMethodContext_GetInputPanelState_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int InputMethodContext_GetInputPanelState(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_GetInputPanelState_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_GetInputPanelState_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_SetReturnKeyState")]
        public static extern void InputMethodContext_SetReturnKeyState_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_SetReturnKeyState")]
        public static extern void InputMethodContext_SetReturnKeyState_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void InputMethodContext_SetReturnKeyState(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_SetReturnKeyState_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_SetReturnKeyState_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_AutoEnableInputPanel")]
        public static extern void InputMethodContext_AutoEnableInputPanel_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_AutoEnableInputPanel")]
        public static extern void InputMethodContext_AutoEnableInputPanel_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void InputMethodContext_AutoEnableInputPanel(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_AutoEnableInputPanel_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_AutoEnableInputPanel_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_ShowInputPanel")]
        public static extern void InputMethodContext_ShowInputPanel_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_ShowInputPanel")]
        public static extern void InputMethodContext_ShowInputPanel_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void InputMethodContext_ShowInputPanel(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_ShowInputPanel_vulkan(jarg1);
            }
            else
            {
                InputMethodContext_ShowInputPanel_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_HideInputPanel")]
        public static extern void InputMethodContext_HideInputPanel_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_HideInputPanel")]
        public static extern void InputMethodContext_HideInputPanel_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void InputMethodContext_HideInputPanel(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_HideInputPanel_vulkan(jarg1);
            }
            else
            {
                InputMethodContext_HideInputPanel_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetKeyboardType")]
        public static extern int InputMethodContext_GetKeyboardType_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetKeyboardType")]
        public static extern int InputMethodContext_GetKeyboardType_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int InputMethodContext_GetKeyboardType(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_GetKeyboardType_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_GetKeyboardType_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelLocale")]
        public static extern string InputMethodContext_GetInputPanelLocale_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelLocale")]
        public static extern string InputMethodContext_GetInputPanelLocale_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static string InputMethodContext_GetInputPanelLocale(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_GetInputPanelLocale_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_GetInputPanelLocale_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_AllowTextPrediction")]
        public static extern void InputMethodContext_AllowTextPrediction_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_AllowTextPrediction")]
        public static extern void InputMethodContext_AllowTextPrediction_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void InputMethodContext_AllowTextPrediction(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodContext_AllowTextPrediction_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodContext_AllowTextPrediction_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_IsTextPredictionAllowed")]
        public static extern bool InputMethodContext_IsTextPredictionAllowed_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_IsTextPredictionAllowed")]
        public static extern bool InputMethodContext_IsTextPredictionAllowed_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool InputMethodContext_IsTextPredictionAllowed(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_IsTextPredictionAllowed_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_IsTextPredictionAllowed_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_ActivatedSignal")]
        public static extern global::System.IntPtr InputMethodContext_ActivatedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_ActivatedSignal")]
        public static extern global::System.IntPtr InputMethodContext_ActivatedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr InputMethodContext_ActivatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_ActivatedSignal_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_ActivatedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventReceivedSignal")]
        public static extern global::System.IntPtr InputMethodContext_EventReceivedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_EventReceivedSignal")]
        public static extern global::System.IntPtr InputMethodContext_EventReceivedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr InputMethodContext_EventReceivedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_EventReceivedSignal_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_EventReceivedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_StatusChangedSignal")]
        public static extern global::System.IntPtr InputMethodContext_StatusChangedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_StatusChangedSignal")]
        public static extern global::System.IntPtr InputMethodContext_StatusChangedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr InputMethodContext_StatusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_StatusChangedSignal_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_StatusChangedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_ResizedSignal")]
        public static extern global::System.IntPtr InputMethodContext_ResizedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_ResizedSignal")]
        public static extern global::System.IntPtr InputMethodContext_ResizedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr InputMethodContext_ResizedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_ResizedSignal_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_ResizedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_LanguageChangedSignal")]
        public static extern global::System.IntPtr InputMethodContext_LanguageChangedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_LanguageChangedSignal")]
        public static extern global::System.IntPtr InputMethodContext_LanguageChangedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr InputMethodContext_LanguageChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_LanguageChangedSignal_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_LanguageChangedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_KeyboardTypeChangedSignal")]
        public static extern global::System.IntPtr InputMethodContext_KeyboardTypeChangedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodContext_KeyboardTypeChangedSignal")]
        public static extern global::System.IntPtr InputMethodContext_KeyboardTypeChangedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr InputMethodContext_KeyboardTypeChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodContext_KeyboardTypeChangedSignal_vulkan(jarg1);
            }
            else
            {
                return InputMethodContext_KeyboardTypeChangedSignal_gl(jarg1);
            }
        }


        ////////////////////// InputMethodContext signals
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ActivatedSignalType_Empty")]
        public static extern bool ActivatedSignalType_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ActivatedSignalType_Empty")]
        public static extern bool ActivatedSignalType_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool ActivatedSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ActivatedSignalType_Empty_vulkan(jarg1);
            }
            else
            {
                return ActivatedSignalType_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ActivatedSignalType_GetConnectionCount")]
        public static extern uint ActivatedSignalType_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ActivatedSignalType_GetConnectionCount")]
        public static extern uint ActivatedSignalType_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint ActivatedSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ActivatedSignalType_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return ActivatedSignalType_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ActivatedSignalType_Connect")]
        public static extern void ActivatedSignalType_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ActivatedSignalType_Connect")]
        public static extern void ActivatedSignalType_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void ActivatedSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ActivatedSignalType_Connect_vulkan(jarg1, jarg2);
            }
            else
            {
                ActivatedSignalType_Connect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ActivatedSignalType_Disconnect")]
        public static extern void ActivatedSignalType_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ActivatedSignalType_Disconnect")]
        public static extern void ActivatedSignalType_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void ActivatedSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ActivatedSignalType_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                ActivatedSignalType_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ActivatedSignalType_Emit")]
        public static extern void ActivatedSignalType_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ActivatedSignalType_Emit")]
        public static extern void ActivatedSignalType_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void ActivatedSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ActivatedSignalType_Emit_vulkan(jarg1, jarg2);
            }
            else
            {
                ActivatedSignalType_Emit_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_ActivatedSignalType")]
        public static extern global::System.IntPtr new_ActivatedSignalType_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_ActivatedSignalType")]
        public static extern global::System.IntPtr new_ActivatedSignalType_vulkan();

        public static global::System.IntPtr new_ActivatedSignalType()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_ActivatedSignalType_vulkan();
            }
            else
            {
                return new_ActivatedSignalType_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_ActivatedSignalType")]
        public static extern void delete_ActivatedSignalType_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_ActivatedSignalType")]
        public static extern void delete_ActivatedSignalType_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_ActivatedSignalType(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_ActivatedSignalType_vulkan(jarg1);
            }
            else
            {
                delete_ActivatedSignalType_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardEventSignalType_Empty")]
        public static extern bool KeyboardEventSignalType_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardEventSignalType_Empty")]
        public static extern bool KeyboardEventSignalType_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool KeyboardEventSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return KeyboardEventSignalType_Empty_vulkan(jarg1);
            }
            else
            {
                return KeyboardEventSignalType_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardEventSignalType_GetConnectionCount")]
        public static extern uint KeyboardEventSignalType_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardEventSignalType_GetConnectionCount")]
        public static extern uint KeyboardEventSignalType_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint KeyboardEventSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return KeyboardEventSignalType_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return KeyboardEventSignalType_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardEventSignalType_Connect")]
        public static extern void KeyboardEventSignalType_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardEventSignalType_Connect")]
        public static extern void KeyboardEventSignalType_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void KeyboardEventSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                KeyboardEventSignalType_Connect_vulkan(jarg1, jarg2);
            }
            else
            {
                KeyboardEventSignalType_Connect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardEventSignalType_Disconnect")]
        public static extern void KeyboardEventSignalType_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardEventSignalType_Disconnect")]
        public static extern void KeyboardEventSignalType_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void KeyboardEventSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                KeyboardEventSignalType_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                KeyboardEventSignalType_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardEventSignalType_Emit")]
        public static extern global::System.IntPtr KeyboardEventSignalType_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardEventSignalType_Emit")]
        public static extern global::System.IntPtr KeyboardEventSignalType_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static global::System.IntPtr KeyboardEventSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return KeyboardEventSignalType_Emit_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return KeyboardEventSignalType_Emit_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_KeyboardEventSignalType")]
        public static extern global::System.IntPtr new_KeyboardEventSignalType_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_KeyboardEventSignalType")]
        public static extern global::System.IntPtr new_KeyboardEventSignalType_vulkan();

        public static global::System.IntPtr new_KeyboardEventSignalType()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_KeyboardEventSignalType_vulkan();
            }
            else
            {
                return new_KeyboardEventSignalType_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_KeyboardEventSignalType")]
        public static extern void delete_KeyboardEventSignalType_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_KeyboardEventSignalType")]
        public static extern void delete_KeyboardEventSignalType_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_KeyboardEventSignalType(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_KeyboardEventSignalType_vulkan(jarg1);
            }
            else
            {
                delete_KeyboardEventSignalType_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_VoidSignalType")]
        public static extern global::System.IntPtr new_VoidSignalType_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_VoidSignalType")]
        public static extern global::System.IntPtr new_VoidSignalType_vulkan();

        public static global::System.IntPtr new_VoidSignalType()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_VoidSignalType_vulkan();
            }
            else
            {
                return new_VoidSignalType_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_VoidSignalType")]
        public static extern void delete_VoidSignalType_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_VoidSignalType")]
        public static extern void delete_VoidSignalType_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_VoidSignalType(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_VoidSignalType_vulkan(jarg1);
            }
            else
            {
                delete_VoidSignalType_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_VoidSignalType_Empty")]
        public static extern bool VoidSignalType_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_VoidSignalType_Empty")]
        public static extern bool VoidSignalType_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool VoidSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return VoidSignalType_Empty_vulkan(jarg1);
            }
            else
            {
                return VoidSignalType_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_VoidSignalType_GetConnectionCount")]
        public static extern uint VoidSignalType_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_VoidSignalType_GetConnectionCount")]
        public static extern uint VoidSignalType_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint VoidSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return VoidSignalType_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return VoidSignalType_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_VoidSignalType_Connect__SWIG_0")]
        public static extern void VoidSignalType_Connect__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_VoidSignalType_Connect__SWIG_0")]
        public static extern void VoidSignalType_Connect__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void VoidSignalType_Connect__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                VoidSignalType_Connect__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                VoidSignalType_Connect__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_VoidSignalType_Disconnect")]
        public static extern void VoidSignalType_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_VoidSignalType_Disconnect")]
        public static extern void VoidSignalType_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void VoidSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                VoidSignalType_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                VoidSignalType_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_VoidSignalType_Connect__SWIG_4")]
        public static extern void VoidSignalType_Connect__SWIG_4_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_VoidSignalType_Connect__SWIG_4")]
        public static extern void VoidSignalType_Connect__SWIG_4_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void VoidSignalType_Connect__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                VoidSignalType_Connect__SWIG_4_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                VoidSignalType_Connect__SWIG_4_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_VoidSignalType_Emit")]
        public static extern void VoidSignalType_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_VoidSignalType_Emit")]
        public static extern void VoidSignalType_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void VoidSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                VoidSignalType_Emit_vulkan(jarg1);
            }
            else
            {
                VoidSignalType_Emit_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_StatusSignalType_Empty")]
        public static extern bool StatusSignalType_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_StatusSignalType_Empty")]
        public static extern bool StatusSignalType_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool StatusSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return StatusSignalType_Empty_vulkan(jarg1);
            }
            else
            {
                return StatusSignalType_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_StatusSignalType_GetConnectionCount")]
        public static extern uint StatusSignalType_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_StatusSignalType_GetConnectionCount")]
        public static extern uint StatusSignalType_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint StatusSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return StatusSignalType_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return StatusSignalType_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_StatusSignalType_Connect")]
        public static extern void StatusSignalType_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_StatusSignalType_Connect")]
        public static extern void StatusSignalType_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void StatusSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                StatusSignalType_Connect_vulkan(jarg1, jarg2);
            }
            else
            {
                StatusSignalType_Connect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_StatusSignalType_Disconnect")]
        public static extern void StatusSignalType_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_StatusSignalType_Disconnect")]
        public static extern void StatusSignalType_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void StatusSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                StatusSignalType_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                StatusSignalType_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_StatusSignalType_Emit")]
        public static extern void StatusSignalType_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_StatusSignalType_Emit")]
        public static extern void StatusSignalType_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void StatusSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                StatusSignalType_Emit_vulkan(jarg1, jarg2);
            }
            else
            {
                StatusSignalType_Emit_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_StatusSignalType")]
        public static extern global::System.IntPtr new_StatusSignalType_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_StatusSignalType")]
        public static extern global::System.IntPtr new_StatusSignalType_vulkan();

        public static global::System.IntPtr new_StatusSignalType()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_StatusSignalType_vulkan();
            }
            else
            {
                return new_StatusSignalType_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_StatusSignalType")]
        public static extern void delete_StatusSignalType_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_StatusSignalType")]
        public static extern void delete_StatusSignalType_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_StatusSignalType(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_StatusSignalType_vulkan(jarg1);
            }
            else
            {
                delete_StatusSignalType_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_Empty")]
        public static extern bool KeyboardTypeSignalType_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_Empty")]
        public static extern bool KeyboardTypeSignalType_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool KeyboardTypeSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return KeyboardTypeSignalType_Empty_vulkan(jarg1);
            }
            else
            {
                return KeyboardTypeSignalType_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_GetConnectionCount")]
        public static extern uint KeyboardTypeSignalType_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_GetConnectionCount")]
        public static extern uint KeyboardTypeSignalType_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint KeyboardTypeSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return KeyboardTypeSignalType_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return KeyboardTypeSignalType_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_Connect")]
        public static extern void KeyboardTypeSignalType_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_Connect")]
        public static extern void KeyboardTypeSignalType_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void KeyboardTypeSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                KeyboardTypeSignalType_Connect_vulkan(jarg1, jarg2);
            }
            else
            {
                KeyboardTypeSignalType_Connect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_Disconnect")]
        public static extern void KeyboardTypeSignalType_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_Disconnect")]
        public static extern void KeyboardTypeSignalType_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void KeyboardTypeSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                KeyboardTypeSignalType_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                KeyboardTypeSignalType_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_Emit")]
        public static extern void KeyboardTypeSignalType_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_Emit")]
        public static extern void KeyboardTypeSignalType_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void KeyboardTypeSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                KeyboardTypeSignalType_Emit_vulkan(jarg1, jarg2);
            }
            else
            {
                KeyboardTypeSignalType_Emit_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_KeyboardTypeSignalType")]
        public static extern global::System.IntPtr new_KeyboardTypeSignalType_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_KeyboardTypeSignalType")]
        public static extern global::System.IntPtr new_KeyboardTypeSignalType_vulkan();

        public static global::System.IntPtr new_KeyboardTypeSignalType()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_KeyboardTypeSignalType_vulkan();
            }
            else
            {
                return new_KeyboardTypeSignalType_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_KeyboardTypeSignalType")]
        public static extern void delete_KeyboardTypeSignalType_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_KeyboardTypeSignalType")]
        public static extern void delete_KeyboardTypeSignalType_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_KeyboardTypeSignalType(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_KeyboardTypeSignalType_vulkan(jarg1);
            }
            else
            {
                delete_KeyboardTypeSignalType_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Empty")]
        public static extern bool LanguageChangedSignalType_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Empty")]
        public static extern bool LanguageChangedSignalType_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool LanguageChangedSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LanguageChangedSignalType_Empty_vulkan(jarg1);
            }
            else
            {
                return LanguageChangedSignalType_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LanguageChangedSignalType_GetConnectionCount")]
        public static extern uint LanguageChangedSignalType_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LanguageChangedSignalType_GetConnectionCount")]
        public static extern uint LanguageChangedSignalType_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint LanguageChangedSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LanguageChangedSignalType_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return LanguageChangedSignalType_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Connect")]
        public static extern void LanguageChangedSignalType_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Connect")]
        public static extern void LanguageChangedSignalType_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LanguageChangedSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LanguageChangedSignalType_Connect_vulkan(jarg1, jarg2);
            }
            else
            {
                LanguageChangedSignalType_Connect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Disconnect")]
        public static extern void LanguageChangedSignalType_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Disconnect")]
        public static extern void LanguageChangedSignalType_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LanguageChangedSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LanguageChangedSignalType_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                LanguageChangedSignalType_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Emit")]
        public static extern void LanguageChangedSignalType_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Emit")]
        public static extern void LanguageChangedSignalType_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void LanguageChangedSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LanguageChangedSignalType_Emit_vulkan(jarg1, jarg2);
            }
            else
            {
                LanguageChangedSignalType_Emit_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LanguageChangedSignalType")]
        public static extern global::System.IntPtr new_LanguageChangedSignalType_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LanguageChangedSignalType")]
        public static extern global::System.IntPtr new_LanguageChangedSignalType_vulkan();

        public static global::System.IntPtr new_LanguageChangedSignalType()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LanguageChangedSignalType_vulkan();
            }
            else
            {
                return new_LanguageChangedSignalType_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_LanguageChangedSignalType")]
        public static extern void delete_LanguageChangedSignalType_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_LanguageChangedSignalType")]
        public static extern void delete_LanguageChangedSignalType_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_LanguageChangedSignalType(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_LanguageChangedSignalType_vulkan(jarg1);
            }
            else
            {
                delete_LanguageChangedSignalType_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Empty")]
        public static extern bool KeyboardResizedSignalType_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Empty")]
        public static extern bool KeyboardResizedSignalType_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool KeyboardResizedSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return KeyboardResizedSignalType_Empty_vulkan(jarg1);
            }
            else
            {
                return KeyboardResizedSignalType_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_GetConnectionCount")]
        public static extern uint KeyboardResizedSignalType_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_GetConnectionCount")]
        public static extern uint KeyboardResizedSignalType_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint KeyboardResizedSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return KeyboardResizedSignalType_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return KeyboardResizedSignalType_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Connect")]
        public static extern void KeyboardResizedSignalType_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Connect")]
        public static extern void KeyboardResizedSignalType_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void KeyboardResizedSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                KeyboardResizedSignalType_Connect_vulkan(jarg1, jarg2);
            }
            else
            {
                KeyboardResizedSignalType_Connect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Disconnect")]
        public static extern void KeyboardResizedSignalType_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Disconnect")]
        public static extern void KeyboardResizedSignalType_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void KeyboardResizedSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                KeyboardResizedSignalType_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                KeyboardResizedSignalType_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Emit")]
        public static extern void KeyboardResizedSignalType_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Emit")]
        public static extern void KeyboardResizedSignalType_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void KeyboardResizedSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                KeyboardResizedSignalType_Emit_vulkan(jarg1, jarg2);
            }
            else
            {
                KeyboardResizedSignalType_Emit_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_KeyboardResizedSignalType")]
        public static extern global::System.IntPtr new_KeyboardResizedSignalType_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_KeyboardResizedSignalType")]
        public static extern global::System.IntPtr new_KeyboardResizedSignalType_vulkan();

        public static global::System.IntPtr new_KeyboardResizedSignalType()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_KeyboardResizedSignalType_vulkan();
            }
            else
            {
                return new_KeyboardResizedSignalType_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_KeyboardResizedSignalType")]
        public static extern void delete_KeyboardResizedSignalType_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_KeyboardResizedSignalType")]
        public static extern void delete_KeyboardResizedSignalType_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_KeyboardResizedSignalType(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_KeyboardResizedSignalType_vulkan(jarg1);
            }
            else
            {
                delete_KeyboardResizedSignalType_gl(jarg1);
            }
        }

        //////////////////////InputMethodOptions

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_InputMethodOptions")]
        public static extern global::System.IntPtr new_InputMethodOptions_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_InputMethodOptions")]
        public static extern global::System.IntPtr new_InputMethodOptions_vulkan();

        public static global::System.IntPtr new_InputMethodOptions()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_InputMethodOptions_vulkan();
            }
            else
            {
                return new_InputMethodOptions_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodOptions_IsPassword")]
        public static extern bool InputMethodOptions_IsPassword_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodOptions_IsPassword")]
        public static extern bool InputMethodOptions_IsPassword_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool InputMethodOptions_IsPassword(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodOptions_IsPassword_vulkan(jarg1);
            }
            else
            {
                return InputMethodOptions_IsPassword_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodOptions_ApplyProperty")]
        public static extern void InputMethodOptions_ApplyProperty_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodOptions_ApplyProperty")]
        public static extern void InputMethodOptions_ApplyProperty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void InputMethodOptions_ApplyProperty(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodOptions_ApplyProperty_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodOptions_ApplyProperty_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodOptions_RetrieveProperty")]
        public static extern void InputMethodOptions_RetrieveProperty_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodOptions_RetrieveProperty")]
        public static extern void InputMethodOptions_RetrieveProperty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void InputMethodOptions_RetrieveProperty(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                InputMethodOptions_RetrieveProperty_vulkan(jarg1, jarg2);
            }
            else
            {
                InputMethodOptions_RetrieveProperty_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodOptions_CompareAndSet")]
        public static extern bool InputMethodOptions_CompareAndSet_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_InputMethodOptions_CompareAndSet")]
        public static extern bool InputMethodOptions_CompareAndSet_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

        public static bool InputMethodOptions_CompareAndSet(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InputMethodOptions_CompareAndSet_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                return InputMethodOptions_CompareAndSet_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_InputMethodOptions")]
        public static extern void delete_InputMethodOptions_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_InputMethodOptions")]
        public static extern void delete_InputMethodOptions_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_InputMethodOptions(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_InputMethodOptions_vulkan(jarg1);
            }
            else
            {
                delete_InputMethodOptions_gl(jarg1);
            }
        }


        /////////////////////////////////////////////////////////////
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_SMOOTH_SCROLL_get")]
        public static extern int TextEditor_Property_SMOOTH_SCROLL_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_SMOOTH_SCROLL_get")]
        public static extern int TextEditor_Property_SMOOTH_SCROLL_get_vulkan();

        public static int TextEditor_Property_SMOOTH_SCROLL_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextEditor_Property_SMOOTH_SCROLL_get_vulkan();
            }
            else
            {
                return TextEditor_Property_SMOOTH_SCROLL_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_SMOOTH_SCROLL_DURATION_get")]
        public static extern int TextEditor_Property_SMOOTH_SCROLL_DURATION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_SMOOTH_SCROLL_DURATION_get")]
        public static extern int TextEditor_Property_SMOOTH_SCROLL_DURATION_get_vulkan();

        public static int TextEditor_Property_SMOOTH_SCROLL_DURATION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextEditor_Property_SMOOTH_SCROLL_DURATION_get_vulkan();
            }
            else
            {
                return TextEditor_Property_SMOOTH_SCROLL_DURATION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_ENABLE_SCROLL_BAR_get")]
        public static extern int TextEditor_Property_ENABLE_SCROLL_BAR_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_ENABLE_SCROLL_BAR_get")]
        public static extern int TextEditor_Property_ENABLE_SCROLL_BAR_get_vulkan();

        public static int TextEditor_Property_ENABLE_SCROLL_BAR_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextEditor_Property_ENABLE_SCROLL_BAR_get_vulkan();
            }
            else
            {
                return TextEditor_Property_ENABLE_SCROLL_BAR_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_SCROLL_BAR_SHOW_DURATION_get")]
        public static extern int TextEditor_Property_SCROLL_BAR_SHOW_DURATION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_SCROLL_BAR_SHOW_DURATION_get")]
        public static extern int TextEditor_Property_SCROLL_BAR_SHOW_DURATION_get_vulkan();

        public static int TextEditor_Property_SCROLL_BAR_SHOW_DURATION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextEditor_Property_SCROLL_BAR_SHOW_DURATION_get_vulkan();
            }
            else
            {
                return TextEditor_Property_SCROLL_BAR_SHOW_DURATION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_SCROLL_BAR_FADE_DURATION_get")]
        public static extern int TextEditor_Property_SCROLL_BAR_FADE_DURATION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_SCROLL_BAR_FADE_DURATION_get")]
        public static extern int TextEditor_Property_SCROLL_BAR_FADE_DURATION_get_vulkan();

        public static int TextEditor_Property_SCROLL_BAR_FADE_DURATION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextEditor_Property_SCROLL_BAR_FADE_DURATION_get_vulkan();
            }
            else
            {
                return TextEditor_Property_SCROLL_BAR_FADE_DURATION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_PIXEL_SIZE_get")]
        public static extern int TextEditor_Property_PIXEL_SIZE_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_PIXEL_SIZE_get")]
        public static extern int TextEditor_Property_PIXEL_SIZE_get_vulkan();

        public static int TextEditor_Property_PIXEL_SIZE_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextEditor_Property_PIXEL_SIZE_get_vulkan();
            }
            else
            {
                return TextEditor_Property_PIXEL_SIZE_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_LINE_COUNT_get")]
        public static extern int TextEditor_Property_LINE_COUNT_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_LINE_COUNT_get")]
        public static extern int TextEditor_Property_LINE_COUNT_get_vulkan();

        public static int TextEditor_Property_LINE_COUNT_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextEditor_Property_LINE_COUNT_get_vulkan();
            }
            else
            {
                return TextEditor_Property_LINE_COUNT_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_PLACEHOLDER_TEXT_get")]
        public static extern int TextEditor_Property_PLACEHOLDER_TEXT_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_PLACEHOLDER_TEXT_get")]
        public static extern int TextEditor_Property_PLACEHOLDER_TEXT_get_vulkan();

        public static int TextEditor_Property_PLACEHOLDER_TEXT_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextEditor_Property_PLACEHOLDER_TEXT_get_vulkan();
            }
            else
            {
                return TextEditor_Property_PLACEHOLDER_TEXT_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_PLACEHOLDER_TEXT_COLOR_get")]
        public static extern int TextEditor_Property_PLACEHOLDER_TEXT_COLOR_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_PLACEHOLDER_TEXT_COLOR_get")]
        public static extern int TextEditor_Property_PLACEHOLDER_TEXT_COLOR_get_vulkan();

        public static int TextEditor_Property_PLACEHOLDER_TEXT_COLOR_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextEditor_Property_PLACEHOLDER_TEXT_COLOR_get_vulkan();
            }
            else
            {
                return TextEditor_Property_PLACEHOLDER_TEXT_COLOR_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_ENABLE_SELECTION_get")]
        public static extern int TextEditor_Property_ENABLE_SELECTION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_ENABLE_SELECTION_get")]
        public static extern int TextEditor_Property_ENABLE_SELECTION_get_vulkan();

        public static int TextEditor_Property_ENABLE_SELECTION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextEditor_Property_ENABLE_SELECTION_get_vulkan();
            }
            else
            {
                return TextEditor_Property_ENABLE_SELECTION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_PLACEHOLDER_get")]
        public static extern int TextEditor_Property_PLACEHOLDER_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_PLACEHOLDER_get")]
        public static extern int TextEditor_Property_PLACEHOLDER_get_vulkan();

        public static int TextEditor_Property_PLACEHOLDER_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextEditor_Property_PLACEHOLDER_get_vulkan();
            }
            else
            {
                return TextEditor_Property_PLACEHOLDER_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_LINE_WRAP_MODE_get")]
        public static extern int TextEditor_Property_LINE_WRAP_MODE_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_LINE_WRAP_MODE_get")]
        public static extern int TextEditor_Property_LINE_WRAP_MODE_get_vulkan();

        public static int TextEditor_Property_LINE_WRAP_MODE_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextEditor_Property_LINE_WRAP_MODE_get_vulkan();
            }
            else
            {
                return TextEditor_Property_LINE_WRAP_MODE_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextField_Property_HIDDEN_INPUT_SETTINGS_get")]
        public static extern int TextField_Property_HIDDEN_INPUT_SETTINGS_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextField_Property_HIDDEN_INPUT_SETTINGS_get")]
        public static extern int TextField_Property_HIDDEN_INPUT_SETTINGS_get_vulkan();

        public static int TextField_Property_HIDDEN_INPUT_SETTINGS_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextField_Property_HIDDEN_INPUT_SETTINGS_get_vulkan();
            }
            else
            {
                return TextField_Property_HIDDEN_INPUT_SETTINGS_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextField_Property_PIXEL_SIZE_get")]
        public static extern int TextField_Property_PIXEL_SIZE_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextField_Property_PIXEL_SIZE_get")]
        public static extern int TextField_Property_PIXEL_SIZE_get_vulkan();

        public static int TextField_Property_PIXEL_SIZE_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextField_Property_PIXEL_SIZE_get_vulkan();
            }
            else
            {
                return TextField_Property_PIXEL_SIZE_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextField_Property_ENABLE_SELECTION_get")]
        public static extern int TextField_Property_ENABLE_SELECTION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextField_Property_ENABLE_SELECTION_get")]
        public static extern int TextField_Property_ENABLE_SELECTION_get_vulkan();

        public static int TextField_Property_ENABLE_SELECTION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextField_Property_ENABLE_SELECTION_get_vulkan();
            }
            else
            {
                return TextField_Property_ENABLE_SELECTION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextField_Property_PLACEHOLDER_get")]
        public static extern int TextField_Property_PLACEHOLDER_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextField_Property_PLACEHOLDER_get")]
        public static extern int TextField_Property_PLACEHOLDER_get_vulkan();

        public static int TextField_Property_PLACEHOLDER_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextField_Property_PLACEHOLDER_get_vulkan();
            }
            else
            {
                return TextField_Property_PLACEHOLDER_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextField_Property_ELLIPSIS_get")]
        public static extern int TextField_Property_ELLIPSIS_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextField_Property_ELLIPSIS_get")]
        public static extern int TextField_Property_ELLIPSIS_get_vulkan();

        public static int TextField_Property_ELLIPSIS_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextField_Property_ELLIPSIS_get_vulkan();
            }
            else
            {
                return TextField_Property_ELLIPSIS_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_PIXEL_SIZE_get")]
        public static extern int TextLabel_Property_PIXEL_SIZE_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_PIXEL_SIZE_get")]
        public static extern int TextLabel_Property_PIXEL_SIZE_get_vulkan();

        public static int TextLabel_Property_PIXEL_SIZE_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextLabel_Property_PIXEL_SIZE_get_vulkan();
            }
            else
            {
                return TextLabel_Property_PIXEL_SIZE_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_ELLIPSIS_get")]
        public static extern int TextLabel_Property_ELLIPSIS_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_ELLIPSIS_get")]
        public static extern int TextLabel_Property_ELLIPSIS_get_vulkan();

        public static int TextLabel_Property_ELLIPSIS_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextLabel_Property_ELLIPSIS_get_vulkan();
            }
            else
            {
                return TextLabel_Property_ELLIPSIS_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_AUTO_SCROLL_STOP_MODE_get")]
        public static extern int TextLabel_Property_AUTO_SCROLL_STOP_MODE_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_AUTO_SCROLL_STOP_MODE_get")]
        public static extern int TextLabel_Property_AUTO_SCROLL_STOP_MODE_get_vulkan();

        public static int TextLabel_Property_AUTO_SCROLL_STOP_MODE_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextLabel_Property_AUTO_SCROLL_STOP_MODE_get_vulkan();
            }
            else
            {
                return TextLabel_Property_AUTO_SCROLL_STOP_MODE_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get")]
        public static extern int TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get")]
        public static extern int TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get_vulkan();

        public static int TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get_vulkan();
            }
            else
            {
                return TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_LINE_COUNT_get")]
        public static extern int TextLabel_Property_LINE_COUNT_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_LINE_COUNT_get")]
        public static extern int TextLabel_Property_LINE_COUNT_get_vulkan();

        public static int TextLabel_Property_LINE_COUNT_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextLabel_Property_LINE_COUNT_get_vulkan();
            }
            else
            {
                return TextLabel_Property_LINE_COUNT_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_LINE_WRAP_MODE_get")]
        public static extern int TextLabel_Property_LINE_WRAP_MODE_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_LINE_WRAP_MODE_get")]
        public static extern int TextLabel_Property_LINE_WRAP_MODE_get_vulkan();

        public static int TextLabel_Property_LINE_WRAP_MODE_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextLabel_Property_LINE_WRAP_MODE_get_vulkan();
            }
            else
            {
                return TextLabel_Property_LINE_WRAP_MODE_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_TEXT_DIRECTION_get")]
        public static extern int TextLabel_Property_TEXT_DIRECTION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_TEXT_DIRECTION_get")]
        public static extern int TextLabel_Property_TEXT_DIRECTION_get_vulkan();

        public static int TextLabel_Property_TEXT_DIRECTION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextLabel_Property_TEXT_DIRECTION_get_vulkan();
            }
            else
            {
                return TextLabel_Property_TEXT_DIRECTION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_VERTICAL_LINE_ALIGNMENT_get")]
        public static extern int TextLabel_Property_VERTICAL_LINE_ALIGNMENT_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextLabel_Property_VERTICAL_LINE_ALIGNMENT_get")]
        public static extern int TextLabel_Property_VERTICAL_LINE_ALIGNMENT_get_vulkan();

        public static int TextLabel_Property_VERTICAL_LINE_ALIGNMENT_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextLabel_Property_VERTICAL_LINE_ALIGNMENT_get_vulkan();
            }
            else
            {
                return TextLabel_Property_VERTICAL_LINE_ALIGNMENT_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_MODE_get")]
        public static extern int HIDDENINPUT_PROPERTY_MODE_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_MODE_get")]
        public static extern int HIDDENINPUT_PROPERTY_MODE_get_vulkan();

        public static int HIDDENINPUT_PROPERTY_MODE_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return HIDDENINPUT_PROPERTY_MODE_get_vulkan();
            }
            else
            {
                return HIDDENINPUT_PROPERTY_MODE_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SUBSTITUTE_CHARACTER_get")]
        public static extern int HIDDENINPUT_PROPERTY_SUBSTITUTE_CHARACTER_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SUBSTITUTE_CHARACTER_get")]
        public static extern int HIDDENINPUT_PROPERTY_SUBSTITUTE_CHARACTER_get_vulkan();

        public static int HIDDENINPUT_PROPERTY_SUBSTITUTE_CHARACTER_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return HIDDENINPUT_PROPERTY_SUBSTITUTE_CHARACTER_get_vulkan();
            }
            else
            {
                return HIDDENINPUT_PROPERTY_SUBSTITUTE_CHARACTER_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SUBSTITUTE_COUNT_get")]
        public static extern int HIDDENINPUT_PROPERTY_SUBSTITUTE_COUNT_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SUBSTITUTE_COUNT_get")]
        public static extern int HIDDENINPUT_PROPERTY_SUBSTITUTE_COUNT_get_vulkan();

        public static int HIDDENINPUT_PROPERTY_SUBSTITUTE_COUNT_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return HIDDENINPUT_PROPERTY_SUBSTITUTE_COUNT_get_vulkan();
            }
            else
            {
                return HIDDENINPUT_PROPERTY_SUBSTITUTE_COUNT_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SHOW_LAST_CHARACTER_DURATION_get")]
        public static extern int HIDDENINPUT_PROPERTY_SHOW_LAST_CHARACTER_DURATION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SHOW_LAST_CHARACTER_DURATION_get")]
        public static extern int HIDDENINPUT_PROPERTY_SHOW_LAST_CHARACTER_DURATION_get_vulkan();

        public static int HIDDENINPUT_PROPERTY_SHOW_LAST_CHARACTER_DURATION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return HIDDENINPUT_PROPERTY_SHOW_LAST_CHARACTER_DURATION_get_vulkan();
            }
            else
            {
                return HIDDENINPUT_PROPERTY_SHOW_LAST_CHARACTER_DURATION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_SWIGUpcast")]
        public static extern global::System.IntPtr TtsPlayer_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_SWIGUpcast")]
        public static extern global::System.IntPtr TtsPlayer_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr TtsPlayer_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TtsPlayer_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return TtsPlayer_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_TtsPlayer__SWIG_0")]
        public static extern global::System.IntPtr new_TtsPlayer__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_TtsPlayer__SWIG_0")]
        public static extern global::System.IntPtr new_TtsPlayer__SWIG_0_vulkan();

        public static global::System.IntPtr new_TtsPlayer__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_TtsPlayer__SWIG_0_vulkan();
            }
            else
            {
                return new_TtsPlayer__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_Get__SWIG_0")]
        public static extern global::System.IntPtr TtsPlayer_Get__SWIG_0_gl(int jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_Get__SWIG_0")]
        public static extern global::System.IntPtr TtsPlayer_Get__SWIG_0_vulkan(int jarg1);

        public static global::System.IntPtr TtsPlayer_Get__SWIG_0(int jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TtsPlayer_Get__SWIG_0_vulkan(jarg1);
            }
            else
            {
                return TtsPlayer_Get__SWIG_0_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_Get__SWIG_1")]
        public static extern global::System.IntPtr TtsPlayer_Get__SWIG_1_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_Get__SWIG_1")]
        public static extern global::System.IntPtr TtsPlayer_Get__SWIG_1_vulkan();

        public static global::System.IntPtr TtsPlayer_Get__SWIG_1()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TtsPlayer_Get__SWIG_1_vulkan();
            }
            else
            {
                return TtsPlayer_Get__SWIG_1_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_TtsPlayer")]
        public static extern void delete_TtsPlayer_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_TtsPlayer")]
        public static extern void delete_TtsPlayer_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_TtsPlayer(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_TtsPlayer_vulkan(jarg1);
            }
            else
            {
                delete_TtsPlayer_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_TtsPlayer__SWIG_1")]
        public static extern global::System.IntPtr new_TtsPlayer__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_TtsPlayer__SWIG_1")]
        public static extern global::System.IntPtr new_TtsPlayer__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_TtsPlayer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_TtsPlayer__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_TtsPlayer__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_Assign")]
        public static extern global::System.IntPtr TtsPlayer_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_Assign")]
        public static extern global::System.IntPtr TtsPlayer_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr TtsPlayer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TtsPlayer_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return TtsPlayer_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_Play")]
        public static extern void TtsPlayer_Play_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_Play")]
        public static extern void TtsPlayer_Play_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static void TtsPlayer_Play(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                TtsPlayer_Play_vulkan(jarg1, jarg2);
            }
            else
            {
                TtsPlayer_Play_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_Stop")]
        public static extern void TtsPlayer_Stop_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_Stop")]
        public static extern void TtsPlayer_Stop_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void TtsPlayer_Stop(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                TtsPlayer_Stop_vulkan(jarg1);
            }
            else
            {
                TtsPlayer_Stop_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_Pause")]
        public static extern void TtsPlayer_Pause_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_Pause")]
        public static extern void TtsPlayer_Pause_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void TtsPlayer_Pause(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                TtsPlayer_Pause_vulkan(jarg1);
            }
            else
            {
                TtsPlayer_Pause_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_Resume")]
        public static extern void TtsPlayer_Resume_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_Resume")]
        public static extern void TtsPlayer_Resume_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void TtsPlayer_Resume(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                TtsPlayer_Resume_vulkan(jarg1);
            }
            else
            {
                TtsPlayer_Resume_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_GetState")]
        public static extern int TtsPlayer_GetState_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_GetState")]
        public static extern int TtsPlayer_GetState_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int TtsPlayer_GetState(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TtsPlayer_GetState_vulkan(jarg1);
            }
            else
            {
                return TtsPlayer_GetState_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_StateChangedSignal")]
        public static extern global::System.IntPtr TtsPlayer_StateChangedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_TtsPlayer_StateChangedSignal")]
        public static extern global::System.IntPtr TtsPlayer_StateChangedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr TtsPlayer_StateChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TtsPlayer_StateChangedSignal_vulkan(jarg1);
            }
            else
            {
                return TtsPlayer_StateChangedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_StateChangedSignalType_Empty")]
        public static extern bool StateChangedSignalType_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_StateChangedSignalType_Empty")]
        public static extern bool StateChangedSignalType_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool StateChangedSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return StateChangedSignalType_Empty_vulkan(jarg1);
            }
            else
            {
                return StateChangedSignalType_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_StateChangedSignalType_GetConnectionCount")]
        public static extern uint StateChangedSignalType_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_StateChangedSignalType_GetConnectionCount")]
        public static extern uint StateChangedSignalType_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint StateChangedSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return StateChangedSignalType_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return StateChangedSignalType_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_StateChangedSignalType_Connect")]
        public static extern void StateChangedSignalType_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_StateChangedSignalType_Connect")]
        public static extern void StateChangedSignalType_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void StateChangedSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                StateChangedSignalType_Connect_vulkan(jarg1, jarg2);
            }
            else
            {
                StateChangedSignalType_Connect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_StateChangedSignalType_Disconnect")]
        public static extern void StateChangedSignalType_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_StateChangedSignalType_Disconnect")]
        public static extern void StateChangedSignalType_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void StateChangedSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                StateChangedSignalType_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                StateChangedSignalType_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_StateChangedSignalType_Emit")]
        public static extern void StateChangedSignalType_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_StateChangedSignalType_Emit")]
        public static extern void StateChangedSignalType_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

        public static void StateChangedSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                StateChangedSignalType_Emit_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                StateChangedSignalType_Emit_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_StateChangedSignalType")]
        public static extern global::System.IntPtr new_StateChangedSignalType_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_StateChangedSignalType")]
        public static extern global::System.IntPtr new_StateChangedSignalType_vulkan();

        public static global::System.IntPtr new_StateChangedSignalType()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_StateChangedSignalType_vulkan();
            }
            else
            {
                return new_StateChangedSignalType_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_StateChangedSignalType")]
        public static extern void delete_StateChangedSignalType_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_StateChangedSignalType")]
        public static extern void delete_StateChangedSignalType_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_StateChangedSignalType(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_StateChangedSignalType_vulkan(jarg1);
            }
            else
            {
                delete_StateChangedSignalType_gl(jarg1);
            }
        }

        //manual pinvoke for text-editor ScrollStateChangedSignal
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_TextEditor_ScrollStateChangedSignal")]
        public static extern global::System.IntPtr TextEditor_ScrollStateChangedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_TextEditor_ScrollStateChangedSignal")]
        public static extern global::System.IntPtr TextEditor_ScrollStateChangedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr TextEditor_ScrollStateChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextEditor_ScrollStateChangedSignal_vulkan(jarg1);
            }
            else
            {
                return TextEditor_ScrollStateChangedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Empty")]
        public static extern bool ScrollStateChangedSignal_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Empty")]
        public static extern bool ScrollStateChangedSignal_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool ScrollStateChangedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ScrollStateChangedSignal_Empty_vulkan(jarg1);
            }
            else
            {
                return ScrollStateChangedSignal_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_GetConnectionCount")]
        public static extern uint ScrollStateChangedSignal_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_GetConnectionCount")]
        public static extern uint ScrollStateChangedSignal_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint ScrollStateChangedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ScrollStateChangedSignal_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return ScrollStateChangedSignal_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Connect")]
        public static extern void ScrollStateChangedSignal_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Connect")]
        public static extern void ScrollStateChangedSignal_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void ScrollStateChangedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ScrollStateChangedSignal_Connect_vulkan(jarg1, jarg2);
            }
            else
            {
                ScrollStateChangedSignal_Connect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Disconnect")]
        public static extern void ScrollStateChangedSignal_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Disconnect")]
        public static extern void ScrollStateChangedSignal_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void ScrollStateChangedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ScrollStateChangedSignal_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                ScrollStateChangedSignal_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Emit")]
        public static extern void ScrollStateChangedSignal_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Emit")]
        public static extern void ScrollStateChangedSignal_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void ScrollStateChangedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ScrollStateChangedSignal_Emit_vulkan(jarg1, jarg2);
            }
            else
            {
                ScrollStateChangedSignal_Emit_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_ScrollStateChangedSignal")]
        public static extern global::System.IntPtr new_ScrollStateChangedSignal_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_ScrollStateChangedSignal")]
        public static extern global::System.IntPtr new_ScrollStateChangedSignal_vulkan();

        public static global::System.IntPtr new_ScrollStateChangedSignal()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_ScrollStateChangedSignal_vulkan();
            }
            else
            {
                return new_ScrollStateChangedSignal_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_ScrollStateChangedSignal")]
        public static extern void delete_ScrollStateChangedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_ScrollStateChangedSignal")]
        public static extern void delete_ScrollStateChangedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_ScrollStateChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_ScrollStateChangedSignal_vulkan(jarg1);
            }
            else
            {
                delete_ScrollStateChangedSignal_gl(jarg1);
            }
        }

        // For windows resized signal
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Window_ResizedSignal")]
        public static extern global::System.IntPtr Window_ResizedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Window_ResizedSignal")]
        public static extern global::System.IntPtr Window_ResizedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr Window_ResizedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Window_ResizedSignal_vulkan(jarg1);
            }
            else
            {
                return Window_ResizedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ResizedSignal_Empty")]
        public static extern bool ResizedSignal_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ResizedSignal_Empty")]
        public static extern bool ResizedSignal_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool ResizedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ResizedSignal_Empty_vulkan(jarg1);
            }
            else
            {
                return ResizedSignal_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ResizedSignal_GetConnectionCount")]
        public static extern uint ResizedSignal_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ResizedSignal_GetConnectionCount")]
        public static extern uint ResizedSignal_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint ResizedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ResizedSignal_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return ResizedSignal_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ResizedSignal_Connect")]
        public static extern void ResizedSignal_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ResizedSignal_Connect")]
        public static extern void ResizedSignal_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void ResizedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ResizedSignal_Connect_vulkan(jarg1, jarg2);
            }
            else
            {
                ResizedSignal_Connect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ResizedSignal_Disconnect")]
        public static extern void ResizedSignal_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ResizedSignal_Disconnect")]
        public static extern void ResizedSignal_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void ResizedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ResizedSignal_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                ResizedSignal_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ResizedSignal_Emit")]
        public static extern void ResizedSignal_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ResizedSignal_Emit")]
        public static extern void ResizedSignal_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void ResizedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ResizedSignal_Emit_vulkan(jarg1, jarg2);
            }
            else
            {
                ResizedSignal_Emit_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_ResizedSignal")]
        public static extern global::System.IntPtr new_ResizedSignal_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_ResizedSignal")]
        public static extern global::System.IntPtr new_ResizedSignal_vulkan();

        public static global::System.IntPtr new_ResizedSignal()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_ResizedSignal_vulkan();
            }
            else
            {
                return new_ResizedSignal_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_ResizedSignal")]
        public static extern void delete_ResizedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_ResizedSignal")]
        public static extern void delete_ResizedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_ResizedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_ResizedSignal_vulkan(jarg1);
            }
            else
            {
                delete_ResizedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Window_SetSize")]
        public static extern void SetSize_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Window_SetSize")]
        public static extern void SetSize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void SetSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                SetSize_vulkan(jarg1, jarg2);
            }
            else
            {
                SetSize_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Window_GetSize")]
        public static extern global::System.IntPtr GetSize_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Window_GetSize")]
        public static extern global::System.IntPtr GetSize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr GetSize(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GetSize_vulkan(jarg1);
            }
            else
            {
                return GetSize_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Window_SetPosition")]
        public static extern void SetPosition_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Window_SetPosition")]
        public static extern void SetPosition_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void SetPosition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                SetPosition_vulkan(jarg1, jarg2);
            }
            else
            {
                SetPosition_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Window_GetPosition")]
        public static extern global::System.IntPtr GetPosition_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Window_GetPosition")]
        public static extern global::System.IntPtr GetPosition_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr GetPosition(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GetPosition_vulkan(jarg1);
            }
            else
            {
                return GetPosition_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Window_SetTransparency")]
        public static extern global::System.IntPtr SetTransparency_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Window_SetTransparency")]
        public static extern global::System.IntPtr SetTransparency_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static global::System.IntPtr SetTransparency(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return SetTransparency_vulkan(jarg1, jarg2);
            }
            else
            {
                return SetTransparency_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Window_FeedKeyEvent")]
        public static extern void Window_FeedKeyEvent_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Window_FeedKeyEvent")]
        public static extern void Window_FeedKeyEvent_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void Window_FeedKeyEvent(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Window_FeedKeyEvent_vulkan(jarg1);
            }
            else
            {
                Window_FeedKeyEvent_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MakeCallback")]
        public static extern global::System.IntPtr MakeCallback_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MakeCallback")]
        public static extern global::System.IntPtr MakeCallback_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr MakeCallback(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MakeCallback_vulkan(jarg1);
            }
            else
            {
                return MakeCallback_gl(jarg1);
            }
        }

        //for widget view
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_WIDGET_ID_get")]
        public static extern int WidgetView_Property_WIDGET_ID_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_WIDGET_ID_get")]
        public static extern int WidgetView_Property_WIDGET_ID_get_vulkan();

        public static int WidgetView_Property_WIDGET_ID_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_Property_WIDGET_ID_get_vulkan();
            }
            else
            {
                return WidgetView_Property_WIDGET_ID_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_INSTANCE_ID_get")]
        public static extern int WidgetView_Property_INSTANCE_ID_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_INSTANCE_ID_get")]
        public static extern int WidgetView_Property_INSTANCE_ID_get_vulkan();

        public static int WidgetView_Property_INSTANCE_ID_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_Property_INSTANCE_ID_get_vulkan();
            }
            else
            {
                return WidgetView_Property_INSTANCE_ID_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_CONTENT_INFO_get")]
        public static extern int WidgetView_Property_CONTENT_INFO_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_CONTENT_INFO_get")]
        public static extern int WidgetView_Property_CONTENT_INFO_get_vulkan();

        public static int WidgetView_Property_CONTENT_INFO_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_Property_CONTENT_INFO_get_vulkan();
            }
            else
            {
                return WidgetView_Property_CONTENT_INFO_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_TITLE_get")]
        public static extern int WidgetView_Property_TITLE_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_TITLE_get")]
        public static extern int WidgetView_Property_TITLE_get_vulkan();

        public static int WidgetView_Property_TITLE_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_Property_TITLE_get_vulkan();
            }
            else
            {
                return WidgetView_Property_TITLE_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_UPDATE_PERIOD_get")]
        public static extern int WidgetView_Property_UPDATE_PERIOD_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_UPDATE_PERIOD_get")]
        public static extern int WidgetView_Property_UPDATE_PERIOD_get_vulkan();

        public static int WidgetView_Property_UPDATE_PERIOD_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_Property_UPDATE_PERIOD_get_vulkan();
            }
            else
            {
                return WidgetView_Property_UPDATE_PERIOD_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_PREVIEW_get")]
        public static extern int WidgetView_Property_PREVIEW_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_PREVIEW_get")]
        public static extern int WidgetView_Property_PREVIEW_get_vulkan();

        public static int WidgetView_Property_PREVIEW_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_Property_PREVIEW_get_vulkan();
            }
            else
            {
                return WidgetView_Property_PREVIEW_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_LOADING_TEXT_get")]
        public static extern int WidgetView_Property_LOADING_TEXT_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_LOADING_TEXT_get")]
        public static extern int WidgetView_Property_LOADING_TEXT_get_vulkan();

        public static int WidgetView_Property_LOADING_TEXT_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_Property_LOADING_TEXT_get_vulkan();
            }
            else
            {
                return WidgetView_Property_LOADING_TEXT_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_WIDGET_STATE_FAULTED_get")]
        public static extern int WidgetView_Property_WIDGET_STATE_FAULTED_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_WIDGET_STATE_FAULTED_get")]
        public static extern int WidgetView_Property_WIDGET_STATE_FAULTED_get_vulkan();

        public static int WidgetView_Property_WIDGET_STATE_FAULTED_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_Property_WIDGET_STATE_FAULTED_get_vulkan();
            }
            else
            {
                return WidgetView_Property_WIDGET_STATE_FAULTED_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_PERMANENT_DELETE_get")]
        public static extern int WidgetView_Property_PERMANENT_DELETE_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_PERMANENT_DELETE_get")]
        public static extern int WidgetView_Property_PERMANENT_DELETE_get_vulkan();

        public static int WidgetView_Property_PERMANENT_DELETE_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_Property_PERMANENT_DELETE_get_vulkan();
            }
            else
            {
                return WidgetView_Property_PERMANENT_DELETE_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_RETRY_TEXT_get")]
        public static extern int WidgetView_Property_RETRY_TEXT_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_RETRY_TEXT_get")]
        public static extern int WidgetView_Property_RETRY_TEXT_get_vulkan();

        public static int WidgetView_Property_RETRY_TEXT_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_Property_RETRY_TEXT_get_vulkan();
            }
            else
            {
                return WidgetView_Property_RETRY_TEXT_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_EFFECT_get")]
        public static extern int WidgetView_Property_EFFECT_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Property_EFFECT_get")]
        public static extern int WidgetView_Property_EFFECT_get_vulkan();

        public static int WidgetView_Property_EFFECT_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_Property_EFFECT_get_vulkan();
            }
            else
            {
                return WidgetView_Property_EFFECT_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetView_Property")]
        public static extern global::System.IntPtr new_WidgetView_Property_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetView_Property")]
        public static extern global::System.IntPtr new_WidgetView_Property_vulkan();

        public static global::System.IntPtr new_WidgetView_Property()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_WidgetView_Property_vulkan();
            }
            else
            {
                return new_WidgetView_Property_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_WidgetView_Property")]
        public static extern void delete_WidgetView_Property_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_WidgetView_Property")]
        public static extern void delete_WidgetView_Property_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_WidgetView_Property(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_WidgetView_Property_vulkan(jarg1);
            }
            else
            {
                delete_WidgetView_Property_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_New")]
        public static extern global::System.IntPtr WidgetView_New_gl(string jarg1, string jarg2, int jarg3, int jarg4, float jarg5);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_New")]
        public static extern global::System.IntPtr WidgetView_New_vulkan(string jarg1, string jarg2, int jarg3, int jarg4, float jarg5);

        public static global::System.IntPtr WidgetView_New(string jarg1, string jarg2, int jarg3, int jarg4, float jarg5)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_New_vulkan(jarg1, jarg2, jarg3, jarg4, jarg5);
            }
            else
            {
                return WidgetView_New_gl(jarg1, jarg2, jarg3, jarg4, jarg5);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_DownCast")]
        public static extern global::System.IntPtr WidgetView_DownCast_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_DownCast")]
        public static extern global::System.IntPtr WidgetView_DownCast_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr WidgetView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_DownCast_vulkan(jarg1);
            }
            else
            {
                return WidgetView_DownCast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetView__SWIG_0")]
        public static extern global::System.IntPtr new_WidgetView__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetView__SWIG_0")]
        public static extern global::System.IntPtr new_WidgetView__SWIG_0_vulkan();

        public static global::System.IntPtr new_WidgetView__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_WidgetView__SWIG_0_vulkan();
            }
            else
            {
                return new_WidgetView__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetView__SWIG_1")]
        public static extern global::System.IntPtr new_WidgetView__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetView__SWIG_1")]
        public static extern global::System.IntPtr new_WidgetView__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_WidgetView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_WidgetView__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_WidgetView__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Assign")]
        public static extern global::System.IntPtr WidgetView_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_Assign")]
        public static extern global::System.IntPtr WidgetView_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr WidgetView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return WidgetView_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_WidgetView")]
        public static extern void delete_WidgetView_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_WidgetView")]
        public static extern void delete_WidgetView_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_WidgetView(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_WidgetView_vulkan(jarg1);
            }
            else
            {
                delete_WidgetView_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_PauseWidget")]
        public static extern bool WidgetView_PauseWidget_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_PauseWidget")]
        public static extern bool WidgetView_PauseWidget_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool WidgetView_PauseWidget(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_PauseWidget_vulkan(jarg1);
            }
            else
            {
                return WidgetView_PauseWidget_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_ResumeWidget")]
        public static extern bool WidgetView_ResumeWidget_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_ResumeWidget")]
        public static extern bool WidgetView_ResumeWidget_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool WidgetView_ResumeWidget(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_ResumeWidget_vulkan(jarg1);
            }
            else
            {
                return WidgetView_ResumeWidget_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_CancelTouchEvent")]
        public static extern bool WidgetView_CancelTouchEvent_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_CancelTouchEvent")]
        public static extern bool WidgetView_CancelTouchEvent_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool WidgetView_CancelTouchEvent(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_CancelTouchEvent_vulkan(jarg1);
            }
            else
            {
                return WidgetView_CancelTouchEvent_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_ActivateFaultedWidget")]
        public static extern void WidgetView_ActivateFaultedWidget_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_ActivateFaultedWidget")]
        public static extern void WidgetView_ActivateFaultedWidget_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void WidgetView_ActivateFaultedWidget(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetView_ActivateFaultedWidget_vulkan(jarg1);
            }
            else
            {
                WidgetView_ActivateFaultedWidget_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_TerminateWidget")]
        public static extern bool WidgetView_TerminateWidget_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_TerminateWidget")]
        public static extern bool WidgetView_TerminateWidget_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool WidgetView_TerminateWidget(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_TerminateWidget_vulkan(jarg1);
            }
            else
            {
                return WidgetView_TerminateWidget_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_WidgetAddedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetAddedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_WidgetAddedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetAddedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr WidgetView_WidgetAddedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_WidgetAddedSignal_vulkan(jarg1);
            }
            else
            {
                return WidgetView_WidgetAddedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_WidgetDeletedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetDeletedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_WidgetDeletedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetDeletedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr WidgetView_WidgetDeletedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_WidgetDeletedSignal_vulkan(jarg1);
            }
            else
            {
                return WidgetView_WidgetDeletedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_WidgetCreationAbortedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetCreationAbortedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_WidgetCreationAbortedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetCreationAbortedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr WidgetView_WidgetCreationAbortedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_WidgetCreationAbortedSignal_vulkan(jarg1);
            }
            else
            {
                return WidgetView_WidgetCreationAbortedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_WidgetContentUpdatedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetContentUpdatedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_WidgetContentUpdatedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetContentUpdatedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr WidgetView_WidgetContentUpdatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_WidgetContentUpdatedSignal_vulkan(jarg1);
            }
            else
            {
                return WidgetView_WidgetContentUpdatedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_WidgetUpdatePeriodChangedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetUpdatePeriodChangedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_WidgetUpdatePeriodChangedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetUpdatePeriodChangedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr WidgetView_WidgetUpdatePeriodChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_WidgetUpdatePeriodChangedSignal_vulkan(jarg1);
            }
            else
            {
                return WidgetView_WidgetUpdatePeriodChangedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_WidgetFaultedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetFaultedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_WidgetFaultedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetFaultedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr WidgetView_WidgetFaultedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_WidgetFaultedSignal_vulkan(jarg1);
            }
            else
            {
                return WidgetView_WidgetFaultedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewSignal_Empty")]
        public static extern bool WidgetViewSignal_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewSignal_Empty")]
        public static extern bool WidgetViewSignal_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool WidgetViewSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetViewSignal_Empty_vulkan(jarg1);
            }
            else
            {
                return WidgetViewSignal_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewSignal_GetConnectionCount")]
        public static extern uint WidgetViewSignal_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewSignal_GetConnectionCount")]
        public static extern uint WidgetViewSignal_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint WidgetViewSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetViewSignal_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return WidgetViewSignal_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewSignal_Connect")]
        public static extern void WidgetViewSignal_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewSignal_Connect")]
        public static extern void WidgetViewSignal_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void WidgetViewSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetViewSignal_Connect_vulkan(jarg1, jarg2);
            }
            else
            {
                WidgetViewSignal_Connect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewSignal_Disconnect")]
        public static extern void WidgetViewSignal_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewSignal_Disconnect")]
        public static extern void WidgetViewSignal_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void WidgetViewSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetViewSignal_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                WidgetViewSignal_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewSignal_Emit")]
        public static extern void WidgetViewSignal_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewSignal_Emit")]
        public static extern void WidgetViewSignal_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void WidgetViewSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetViewSignal_Emit_vulkan(jarg1, jarg2);
            }
            else
            {
                WidgetViewSignal_Emit_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetViewSignal")]
        public static extern global::System.IntPtr new_WidgetViewSignal_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetViewSignal")]
        public static extern global::System.IntPtr new_WidgetViewSignal_vulkan();

        public static global::System.IntPtr new_WidgetViewSignal()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_WidgetViewSignal_vulkan();
            }
            else
            {
                return new_WidgetViewSignal_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_WidgetViewSignal")]
        public static extern void delete_WidgetViewSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_WidgetViewSignal")]
        public static extern void delete_WidgetViewSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_WidgetViewSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_WidgetViewSignal_vulkan(jarg1);
            }
            else
            {
                delete_WidgetViewSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_SWIGUpcast")]
        public static extern global::System.IntPtr WidgetView_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetView_SWIGUpcast")]
        public static extern global::System.IntPtr WidgetView_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr WidgetView_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetView_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return WidgetView_SWIGUpcast_gl(jarg1);
            }
        }

        // For widget view manager
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewManager_New")]
        public static extern global::System.IntPtr WidgetViewManager_New_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewManager_New")]
        public static extern global::System.IntPtr WidgetViewManager_New_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static global::System.IntPtr WidgetViewManager_New(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetViewManager_New_vulkan(jarg1, jarg2);
            }
            else
            {
                return WidgetViewManager_New_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewManager_DownCast")]
        public static extern global::System.IntPtr WidgetViewManager_DownCast_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewManager_DownCast")]
        public static extern global::System.IntPtr WidgetViewManager_DownCast_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr WidgetViewManager_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetViewManager_DownCast_vulkan(jarg1);
            }
            else
            {
                return WidgetViewManager_DownCast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetViewManager__SWIG_0")]
        public static extern global::System.IntPtr new_WidgetViewManager__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetViewManager__SWIG_0")]
        public static extern global::System.IntPtr new_WidgetViewManager__SWIG_0_vulkan();

        public static global::System.IntPtr new_WidgetViewManager__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_WidgetViewManager__SWIG_0_vulkan();
            }
            else
            {
                return new_WidgetViewManager__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetViewManager__SWIG_1")]
        public static extern global::System.IntPtr new_WidgetViewManager__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetViewManager__SWIG_1")]
        public static extern global::System.IntPtr new_WidgetViewManager__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_WidgetViewManager__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_WidgetViewManager__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_WidgetViewManager__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewManager_Assign")]
        public static extern global::System.IntPtr WidgetViewManager_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewManager_Assign")]
        public static extern global::System.IntPtr WidgetViewManager_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr WidgetViewManager_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetViewManager_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return WidgetViewManager_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_WidgetViewManager")]
        public static extern void delete_WidgetViewManager_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_WidgetViewManager")]
        public static extern void delete_WidgetViewManager_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_WidgetViewManager(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_WidgetViewManager_vulkan(jarg1);
            }
            else
            {
                delete_WidgetViewManager_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewManager_AddWidget")]
        public static extern global::System.IntPtr WidgetViewManager_AddWidget_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3, int jarg4, int jarg5, float jarg6);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewManager_AddWidget")]
        public static extern global::System.IntPtr WidgetViewManager_AddWidget_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3, int jarg4, int jarg5, float jarg6);

        public static global::System.IntPtr WidgetViewManager_AddWidget(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3, int jarg4, int jarg5, float jarg6)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetViewManager_AddWidget_vulkan(jarg1, jarg2, jarg3, jarg4, jarg5, jarg6);
            }
            else
            {
                return WidgetViewManager_AddWidget_gl(jarg1, jarg2, jarg3, jarg4, jarg5, jarg6);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewManager_SWIGUpcast")]
        public static extern global::System.IntPtr WidgetViewManager_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetViewManager_SWIGUpcast")]
        public static extern global::System.IntPtr WidgetViewManager_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr WidgetViewManager_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetViewManager_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return WidgetViewManager_SWIGUpcast_gl(jarg1);
            }
        }


        //For Adaptor
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_0")]
        public static extern global::System.IntPtr Adaptor_New__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_0")]
        public static extern global::System.IntPtr Adaptor_New__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr Adaptor_New__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Adaptor_New__SWIG_0_vulkan(jarg1);
            }
            else
            {
                return Adaptor_New__SWIG_0_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_1")]
        public static extern global::System.IntPtr Adaptor_New__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_1")]
        public static extern global::System.IntPtr Adaptor_New__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr Adaptor_New__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Adaptor_New__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                return Adaptor_New__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_2")]
        public static extern global::System.IntPtr Adaptor_New__SWIG_2_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_2")]
        public static extern global::System.IntPtr Adaptor_New__SWIG_2_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr Adaptor_New__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Adaptor_New__SWIG_2_vulkan(jarg1, jarg2);
            }
            else
            {
                return Adaptor_New__SWIG_2_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_3")]
        public static extern global::System.IntPtr Adaptor_New__SWIG_3_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_3")]
        public static extern global::System.IntPtr Adaptor_New__SWIG_3_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static global::System.IntPtr Adaptor_New__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Adaptor_New__SWIG_3_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return Adaptor_New__SWIG_3_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_Adaptor")]
        public static extern void delete_Adaptor_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_Adaptor")]
        public static extern void delete_Adaptor_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_Adaptor(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_Adaptor_vulkan(jarg1);
            }
            else
            {
                delete_Adaptor_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_Start")]
        public static extern void Adaptor_Start_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_Start")]
        public static extern void Adaptor_Start_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void Adaptor_Start(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_Start_vulkan(jarg1);
            }
            else
            {
                Adaptor_Start_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_Pause")]
        public static extern void Adaptor_Pause_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_Pause")]
        public static extern void Adaptor_Pause_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void Adaptor_Pause(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_Pause_vulkan(jarg1);
            }
            else
            {
                Adaptor_Pause_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_Resume")]
        public static extern void Adaptor_Resume_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_Resume")]
        public static extern void Adaptor_Resume_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void Adaptor_Resume(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_Resume_vulkan(jarg1);
            }
            else
            {
                Adaptor_Resume_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_Stop")]
        public static extern void Adaptor_Stop_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_Stop")]
        public static extern void Adaptor_Stop_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void Adaptor_Stop(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_Stop_vulkan(jarg1);
            }
            else
            {
                Adaptor_Stop_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_AddIdle")]
        public static extern bool Adaptor_AddIdle_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_AddIdle")]
        public static extern bool Adaptor_AddIdle_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static bool Adaptor_AddIdle(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Adaptor_AddIdle_vulkan(jarg1, jarg2);
            }
            else
            {
                return Adaptor_AddIdle_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_RemoveIdle")]
        public static extern void Adaptor_RemoveIdle_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_RemoveIdle")]
        public static extern void Adaptor_RemoveIdle_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void Adaptor_RemoveIdle(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_RemoveIdle_vulkan(jarg1, jarg2);
            }
            else
            {
                Adaptor_RemoveIdle_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_ReplaceSurface")]
        public static extern void Adaptor_ReplaceSurface_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_ReplaceSurface")]
        public static extern void Adaptor_ReplaceSurface_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void Adaptor_ReplaceSurface(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_ReplaceSurface_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                Adaptor_ReplaceSurface_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_GetSurface")]
        public static extern global::System.IntPtr Adaptor_GetSurface_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_GetSurface")]
        public static extern global::System.IntPtr Adaptor_GetSurface_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr Adaptor_GetSurface(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Adaptor_GetSurface_vulkan(jarg1);
            }
            else
            {
                return Adaptor_GetSurface_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_GetNativeWindowHandle")]
        public static extern global::System.IntPtr Adaptor_GetNativeWindowHandle_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_GetNativeWindowHandle")]
        public static extern global::System.IntPtr Adaptor_GetNativeWindowHandle_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr Adaptor_GetNativeWindowHandle(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Adaptor_GetNativeWindowHandle_vulkan(jarg1);
            }
            else
            {
                return Adaptor_GetNativeWindowHandle_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_ReleaseSurfaceLock")]
        public static extern void Adaptor_ReleaseSurfaceLock_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_ReleaseSurfaceLock")]
        public static extern void Adaptor_ReleaseSurfaceLock_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void Adaptor_ReleaseSurfaceLock(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_ReleaseSurfaceLock_vulkan(jarg1);
            }
            else
            {
                Adaptor_ReleaseSurfaceLock_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_SetRenderRefreshRate")]
        public static extern void Adaptor_SetRenderRefreshRate_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_SetRenderRefreshRate")]
        public static extern void Adaptor_SetRenderRefreshRate_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static void Adaptor_SetRenderRefreshRate(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_SetRenderRefreshRate_vulkan(jarg1, jarg2);
            }
            else
            {
                Adaptor_SetRenderRefreshRate_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_SetUseHardwareVSync")]
        public static extern void Adaptor_SetUseHardwareVSync_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_SetUseHardwareVSync")]
        public static extern void Adaptor_SetUseHardwareVSync_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void Adaptor_SetUseHardwareVSync(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_SetUseHardwareVSync_vulkan(jarg1, jarg2);
            }
            else
            {
                Adaptor_SetUseHardwareVSync_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_Get")]
        public static extern global::System.IntPtr Adaptor_Get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_Get")]
        public static extern global::System.IntPtr Adaptor_Get_vulkan();

        public static global::System.IntPtr Adaptor_Get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Adaptor_Get_vulkan();
            }
            else
            {
                return Adaptor_Get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_IsAvailable")]
        public static extern bool Adaptor_IsAvailable_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_IsAvailable")]
        public static extern bool Adaptor_IsAvailable_vulkan();

        public static bool Adaptor_IsAvailable()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Adaptor_IsAvailable_vulkan();
            }
            else
            {
                return Adaptor_IsAvailable_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_NotifySceneCreated")]
        public static extern void Adaptor_NotifySceneCreated_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_NotifySceneCreated")]
        public static extern void Adaptor_NotifySceneCreated_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void Adaptor_NotifySceneCreated(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_NotifySceneCreated_vulkan(jarg1);
            }
            else
            {
                Adaptor_NotifySceneCreated_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_NotifyLanguageChanged")]
        public static extern void Adaptor_NotifyLanguageChanged_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_NotifyLanguageChanged")]
        public static extern void Adaptor_NotifyLanguageChanged_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void Adaptor_NotifyLanguageChanged(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_NotifyLanguageChanged_vulkan(jarg1);
            }
            else
            {
                Adaptor_NotifyLanguageChanged_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_SetMinimumPinchDistance")]
        public static extern void Adaptor_SetMinimumPinchDistance_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_SetMinimumPinchDistance")]
        public static extern void Adaptor_SetMinimumPinchDistance_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static void Adaptor_SetMinimumPinchDistance(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_SetMinimumPinchDistance_vulkan(jarg1, jarg2);
            }
            else
            {
                Adaptor_SetMinimumPinchDistance_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_FeedTouchPoint")]
        public static extern void Adaptor_FeedTouchPoint_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_FeedTouchPoint")]
        public static extern void Adaptor_FeedTouchPoint_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

        public static void Adaptor_FeedTouchPoint(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_FeedTouchPoint_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                Adaptor_FeedTouchPoint_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_FeedWheelEvent")]
        public static extern void Adaptor_FeedWheelEvent_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_FeedWheelEvent")]
        public static extern void Adaptor_FeedWheelEvent_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void Adaptor_FeedWheelEvent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_FeedWheelEvent_vulkan(jarg1, jarg2);
            }
            else
            {
                Adaptor_FeedWheelEvent_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_FeedKeyEvent")]
        public static extern void Adaptor_FeedKeyEvent_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_FeedKeyEvent")]
        public static extern void Adaptor_FeedKeyEvent_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void Adaptor_FeedKeyEvent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_FeedKeyEvent_vulkan(jarg1, jarg2);
            }
            else
            {
                Adaptor_FeedKeyEvent_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_SceneCreated")]
        public static extern void Adaptor_SceneCreated_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_SceneCreated")]
        public static extern void Adaptor_SceneCreated_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void Adaptor_SceneCreated(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_SceneCreated_vulkan(jarg1);
            }
            else
            {
                Adaptor_SceneCreated_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_SetViewMode")]
        public static extern void Adaptor_SetViewMode_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_SetViewMode")]
        public static extern void Adaptor_SetViewMode_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void Adaptor_SetViewMode(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_SetViewMode_vulkan(jarg1, jarg2);
            }
            else
            {
                Adaptor_SetViewMode_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_SetStereoBase")]
        public static extern void Adaptor_SetStereoBase_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_SetStereoBase")]
        public static extern void Adaptor_SetStereoBase_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static void Adaptor_SetStereoBase(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Adaptor_SetStereoBase_vulkan(jarg1, jarg2);
            }
            else
            {
                Adaptor_SetStereoBase_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_ResizedSignal")]
        public static extern global::System.IntPtr Adaptor_ResizedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_ResizedSignal")]
        public static extern global::System.IntPtr Adaptor_ResizedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr Adaptor_ResizedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Adaptor_ResizedSignal_vulkan(jarg1);
            }
            else
            {
                return Adaptor_ResizedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_LanguageChangedSignal")]
        public static extern global::System.IntPtr Adaptor_LanguageChangedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_LanguageChangedSignal")]
        public static extern global::System.IntPtr Adaptor_LanguageChangedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr Adaptor_LanguageChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Adaptor_LanguageChangedSignal_vulkan(jarg1);
            }
            else
            {
                return Adaptor_LanguageChangedSignal_gl(jarg1);
            }
        }

        //Adaptor Signal Type
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_AdaptorSignalType_Empty")]
        public static extern bool AdaptorSignalType_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_AdaptorSignalType_Empty")]
        public static extern bool AdaptorSignalType_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool AdaptorSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return AdaptorSignalType_Empty_vulkan(jarg1);
            }
            else
            {
                return AdaptorSignalType_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_AdaptorSignalType_GetConnectionCount")]
        public static extern uint AdaptorSignalType_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_AdaptorSignalType_GetConnectionCount")]
        public static extern uint AdaptorSignalType_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint AdaptorSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return AdaptorSignalType_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return AdaptorSignalType_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_AdaptorSignalType_Connect")]
        public static extern void AdaptorSignalType_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_AdaptorSignalType_Connect")]
        public static extern void AdaptorSignalType_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void AdaptorSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                AdaptorSignalType_Connect_vulkan(jarg1, jarg2);
            }
            else
            {
                AdaptorSignalType_Connect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_AdaptorSignalType_Disconnect")]
        public static extern void AdaptorSignalType_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_AdaptorSignalType_Disconnect")]
        public static extern void AdaptorSignalType_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void AdaptorSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                AdaptorSignalType_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                AdaptorSignalType_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_AdaptorSignalType_Emit")]
        public static extern void AdaptorSignalType_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_AdaptorSignalType_Emit")]
        public static extern void AdaptorSignalType_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void AdaptorSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                AdaptorSignalType_Emit_vulkan(jarg1, jarg2);
            }
            else
            {
                AdaptorSignalType_Emit_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_AdaptorSignalType")]
        public static extern global::System.IntPtr new_AdaptorSignalType_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_AdaptorSignalType")]
        public static extern global::System.IntPtr new_AdaptorSignalType_vulkan();

        public static global::System.IntPtr new_AdaptorSignalType()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_AdaptorSignalType_vulkan();
            }
            else
            {
                return new_AdaptorSignalType_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_AdaptorSignalType")]
        public static extern void delete_AdaptorSignalType_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_AdaptorSignalType")]
        public static extern void delete_AdaptorSignalType_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_AdaptorSignalType(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_AdaptorSignalType_vulkan(jarg1);
            }
            else
            {
                delete_AdaptorSignalType_gl(jarg1);
            }
        }

        //For widget

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Widget_SWIGUpcast")]
        public static extern global::System.IntPtr Widget_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Widget_SWIGUpcast")]
        public static extern global::System.IntPtr Widget_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr Widget_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Widget_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return Widget_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_SWIGUpcast")]
        public static extern global::System.IntPtr WidgetImpl_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_SWIGUpcast")]
        public static extern global::System.IntPtr WidgetImpl_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr WidgetImpl_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetImpl_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return WidgetImpl_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Widget_New__SWIG_0")]
        public static extern global::System.IntPtr Widget_New__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Widget_New__SWIG_0")]
        public static extern global::System.IntPtr Widget_New__SWIG_0_vulkan();

        public static global::System.IntPtr Widget_New__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Widget_New__SWIG_0_vulkan();
            }
            else
            {
                return Widget_New__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Widget_New__SWIG_1")]
        public static extern global::System.IntPtr Widget_New__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Widget_New__SWIG_1")]
        public static extern global::System.IntPtr Widget_New__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr Widget_New__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Widget_New__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return Widget_New__SWIG_1_gl(jarg1);
            }
        }


        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_Widget")]
        public static extern global::System.IntPtr new_Widget_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_Widget")]
        public static extern global::System.IntPtr new_Widget_vulkan();

        public static global::System.IntPtr new_Widget()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_Widget_vulkan();
            }
            else
            {
                return new_Widget_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Widget_Assign")]
        public static extern global::System.IntPtr Widget_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Widget_Assign")]
        public static extern global::System.IntPtr Widget_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr Widget_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Widget_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return Widget_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_Widget")]
        public static extern void delete_Widget_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_Widget")]
        public static extern void delete_Widget_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_Widget(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_Widget_vulkan(jarg1);
            }
            else
            {
                delete_Widget_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_New")]
        public static extern global::System.IntPtr WidgetImpl_New_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_New")]
        public static extern global::System.IntPtr WidgetImpl_New_vulkan();

        public static global::System.IntPtr WidgetImpl_New()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetImpl_New_vulkan();
            }
            else
            {
                return WidgetImpl_New_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnCreate")]
        public static extern void WidgetImpl_OnCreate_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnCreate")]
        public static extern void WidgetImpl_OnCreate_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void WidgetImpl_OnCreate(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_OnCreate_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                WidgetImpl_OnCreate_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnCreateSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnCreateSwigExplicitWidgetImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnCreateSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnCreateSwigExplicitWidgetImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void WidgetImpl_OnCreateSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_OnCreateSwigExplicitWidgetImpl_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                WidgetImpl_OnCreateSwigExplicitWidgetImpl_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnTerminate")]
        public static extern void WidgetImpl_OnTerminate_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnTerminate")]
        public static extern void WidgetImpl_OnTerminate_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

        public static void WidgetImpl_OnTerminate(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_OnTerminate_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                WidgetImpl_OnTerminate_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnTerminateSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnTerminateSwigExplicitWidgetImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnTerminateSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnTerminateSwigExplicitWidgetImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

        public static void WidgetImpl_OnTerminateSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_OnTerminateSwigExplicitWidgetImpl_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                WidgetImpl_OnTerminateSwigExplicitWidgetImpl_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnPause")]
        public static extern void WidgetImpl_OnPause_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnPause")]
        public static extern void WidgetImpl_OnPause_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void WidgetImpl_OnPause(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_OnPause_vulkan(jarg1);
            }
            else
            {
                WidgetImpl_OnPause_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnPauseSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnPauseSwigExplicitWidgetImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnPauseSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnPauseSwigExplicitWidgetImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void WidgetImpl_OnPauseSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_OnPauseSwigExplicitWidgetImpl_vulkan(jarg1);
            }
            else
            {
                WidgetImpl_OnPauseSwigExplicitWidgetImpl_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnResume")]
        public static extern void WidgetImpl_OnResume_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnResume")]
        public static extern void WidgetImpl_OnResume_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void WidgetImpl_OnResume(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_OnResume_vulkan(jarg1);
            }
            else
            {
                WidgetImpl_OnResume_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnResumeSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnResumeSwigExplicitWidgetImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnResumeSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnResumeSwigExplicitWidgetImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void WidgetImpl_OnResumeSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_OnResumeSwigExplicitWidgetImpl_vulkan(jarg1);
            }
            else
            {
                WidgetImpl_OnResumeSwigExplicitWidgetImpl_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnResize")]
        public static extern void WidgetImpl_OnResize_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnResize")]
        public static extern void WidgetImpl_OnResize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void WidgetImpl_OnResize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_OnResize_vulkan(jarg1, jarg2);
            }
            else
            {
                WidgetImpl_OnResize_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnResizeSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnResizeSwigExplicitWidgetImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnResizeSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnResizeSwigExplicitWidgetImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void WidgetImpl_OnResizeSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_OnResizeSwigExplicitWidgetImpl_vulkan(jarg1, jarg2);
            }
            else
            {
                WidgetImpl_OnResizeSwigExplicitWidgetImpl_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnUpdate")]
        public static extern void WidgetImpl_OnUpdate_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnUpdate")]
        public static extern void WidgetImpl_OnUpdate_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

        public static void WidgetImpl_OnUpdate(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_OnUpdate_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                WidgetImpl_OnUpdate_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnUpdateSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnUpdateSwigExplicitWidgetImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_OnUpdateSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnUpdateSwigExplicitWidgetImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

        public static void WidgetImpl_OnUpdateSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_OnUpdateSwigExplicitWidgetImpl_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                WidgetImpl_OnUpdateSwigExplicitWidgetImpl_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_SignalConnected")]
        public static extern void WidgetImpl_SignalConnected_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_SignalConnected")]
        public static extern void WidgetImpl_SignalConnected_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void WidgetImpl_SignalConnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_SignalConnected_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                WidgetImpl_SignalConnected_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_SignalConnectedSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_SignalConnectedSwigExplicitWidgetImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_SignalConnectedSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_SignalConnectedSwigExplicitWidgetImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void WidgetImpl_SignalConnectedSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_SignalConnectedSwigExplicitWidgetImpl_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                WidgetImpl_SignalConnectedSwigExplicitWidgetImpl_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_SignalDisconnected")]
        public static extern void WidgetImpl_SignalDisconnected_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_SignalDisconnected")]
        public static extern void WidgetImpl_SignalDisconnected_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void WidgetImpl_SignalDisconnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_SignalDisconnected_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                WidgetImpl_SignalDisconnected_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_SignalDisconnectedSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_SignalDisconnectedSwigExplicitWidgetImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_SignalDisconnectedSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_SignalDisconnectedSwigExplicitWidgetImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void WidgetImpl_SignalDisconnectedSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_SignalDisconnectedSwigExplicitWidgetImpl_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                WidgetImpl_SignalDisconnectedSwigExplicitWidgetImpl_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_SetContentInfo")]
        public static extern void WidgetImpl_SetContentInfo_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_SetContentInfo")]
        public static extern void WidgetImpl_SetContentInfo_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static void WidgetImpl_SetContentInfo(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_SetContentInfo_vulkan(jarg1, jarg2);
            }
            else
            {
                WidgetImpl_SetContentInfo_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_SetImpl")]
        public static extern void WidgetImpl_SetImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_SetImpl")]
        public static extern void WidgetImpl_SetImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void WidgetImpl_SetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_SetImpl_vulkan(jarg1, jarg2);
            }
            else
            {
                WidgetImpl_SetImpl_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_director_connect")]
        public static extern void WidgetImpl_director_connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, WidgetImpl.SwigDelegateWidgetImpl_0 delegate0, WidgetImpl.SwigDelegateWidgetImpl_1 delegate1, WidgetImpl.SwigDelegateWidgetImpl_2 delegate2, WidgetImpl.SwigDelegateWidgetImpl_3 delegate3, WidgetImpl.SwigDelegateWidgetImpl_4 delegate4, WidgetImpl.SwigDelegateWidgetImpl_5 delegate5, WidgetImpl.SwigDelegateWidgetImpl_6 delegate6, WidgetImpl.SwigDelegateWidgetImpl_7 delegate7);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetImpl_director_connect")]
        public static extern void WidgetImpl_director_connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, WidgetImpl.SwigDelegateWidgetImpl_0 delegate0, WidgetImpl.SwigDelegateWidgetImpl_1 delegate1, WidgetImpl.SwigDelegateWidgetImpl_2 delegate2, WidgetImpl.SwigDelegateWidgetImpl_3 delegate3, WidgetImpl.SwigDelegateWidgetImpl_4 delegate4, WidgetImpl.SwigDelegateWidgetImpl_5 delegate5, WidgetImpl.SwigDelegateWidgetImpl_6 delegate6, WidgetImpl.SwigDelegateWidgetImpl_7 delegate7);

        public static void WidgetImpl_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, WidgetImpl.SwigDelegateWidgetImpl_0 delegate0, WidgetImpl.SwigDelegateWidgetImpl_1 delegate1, WidgetImpl.SwigDelegateWidgetImpl_2 delegate2, WidgetImpl.SwigDelegateWidgetImpl_3 delegate3, WidgetImpl.SwigDelegateWidgetImpl_4 delegate4, WidgetImpl.SwigDelegateWidgetImpl_5 delegate5, WidgetImpl.SwigDelegateWidgetImpl_6 delegate6, WidgetImpl.SwigDelegateWidgetImpl_7 delegate7)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetImpl_director_connect_vulkan(jarg1, delegate0, delegate1, delegate2, delegate3, delegate4, delegate5, delegate6, delegate7);
            }
            else
            {
                WidgetImpl_director_connect_gl(jarg1, delegate0, delegate1, delegate2, delegate3, delegate4, delegate5, delegate6, delegate7);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Widget_GetImplementation__SWIG_0")]
        public static extern global::System.IntPtr Widget_GetImplementation__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Widget_GetImplementation__SWIG_0")]
        public static extern global::System.IntPtr Widget_GetImplementation__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr Widget_GetImplementation__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Widget_GetImplementation__SWIG_0_vulkan(jarg1);
            }
            else
            {
                return Widget_GetImplementation__SWIG_0_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetApplication_New")]
        public static extern global::System.IntPtr WidgetApplication_New_gl(int jarg1, string jarg2, string jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetApplication_New")]
        public static extern global::System.IntPtr WidgetApplication_New_vulkan(int jarg1, string jarg2, string jarg3);

        public static global::System.IntPtr WidgetApplication_New(int jarg1, string jarg2, string jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetApplication_New_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return WidgetApplication_New_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetApplication__SWIG_0")]
        public static extern global::System.IntPtr new_WidgetApplication__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetApplication__SWIG_0")]
        public static extern global::System.IntPtr new_WidgetApplication__SWIG_0_vulkan();

        public static global::System.IntPtr new_WidgetApplication__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_WidgetApplication__SWIG_0_vulkan();
            }
            else
            {
                return new_WidgetApplication__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetApplication__SWIG_1")]
        public static extern global::System.IntPtr new_WidgetApplication__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_WidgetApplication__SWIG_1")]
        public static extern global::System.IntPtr new_WidgetApplication__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_WidgetApplication__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_WidgetApplication__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_WidgetApplication__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetApplication_Assign")]
        public static extern global::System.IntPtr WidgetApplication_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetApplication_Assign")]
        public static extern global::System.IntPtr WidgetApplication_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr WidgetApplication_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WidgetApplication_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return WidgetApplication_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_WidgetApplication")]
        public static extern void delete_WidgetApplication_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_WidgetApplication")]
        public static extern void delete_WidgetApplication_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_WidgetApplication(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_WidgetApplication_vulkan(jarg1);
            }
            else
            {
                delete_WidgetApplication_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WidgetApplication_RegisterWidgetCreatingFunction")]
        public static extern void WidgetApplication_RegisterWidgetCreatingFunction_gl(global::System.Runtime.InteropServices.HandleRef jarg1, ref string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WidgetApplication_RegisterWidgetCreatingFunction")]
        public static extern void WidgetApplication_RegisterWidgetCreatingFunction_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, ref string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void WidgetApplication_RegisterWidgetCreatingFunction(global::System.Runtime.InteropServices.HandleRef jarg1, ref string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WidgetApplication_RegisterWidgetCreatingFunction_vulkan(jarg1, ref jarg2, jarg3);
            }
            else
            {
                WidgetApplication_RegisterWidgetCreatingFunction_gl(jarg1, ref jarg2, jarg3);
            }
        }
        // End widget

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Actor_Property_INHERIT_LAYOUT_DIRECTION_get")]
        public static extern int Actor_Property_INHERIT_LAYOUT_DIRECTION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Actor_Property_INHERIT_LAYOUT_DIRECTION_get")]
        public static extern int Actor_Property_INHERIT_LAYOUT_DIRECTION_get_vulkan();

        public static int Actor_Property_INHERIT_LAYOUT_DIRECTION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Actor_Property_INHERIT_LAYOUT_DIRECTION_get_vulkan();
            }
            else
            {
                return Actor_Property_INHERIT_LAYOUT_DIRECTION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Actor_Property_LAYOUT_DIRECTION_get")]
        public static extern int Actor_Property_LAYOUT_DIRECTION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Actor_Property_LAYOUT_DIRECTION_get")]
        public static extern int Actor_Property_LAYOUT_DIRECTION_get_vulkan();

        public static int Actor_Property_LAYOUT_DIRECTION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Actor_Property_LAYOUT_DIRECTION_get_vulkan();
            }
            else
            {
                return Actor_Property_LAYOUT_DIRECTION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutDirectionChangedSignal")]
        public static extern global::System.IntPtr LayoutDirectionChangedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutDirectionChangedSignal")]
        public static extern global::System.IntPtr LayoutDirectionChangedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutDirectionChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutDirectionChangedSignal_vulkan(jarg1);
            }
            else
            {
                return LayoutDirectionChangedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ViewLayoutDirectionChangedSignal_Empty")]
        public static extern bool ViewLayoutDirectionChangedSignal_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ViewLayoutDirectionChangedSignal_Empty")]
        public static extern bool ViewLayoutDirectionChangedSignal_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool ViewLayoutDirectionChangedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewLayoutDirectionChangedSignal_Empty_vulkan(jarg1);
            }
            else
            {
                return ViewLayoutDirectionChangedSignal_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_GetConnectionCount")]
        public static extern uint ViewLayoutDirectionChangedSignal_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_GetConnectionCount")]
        public static extern uint ViewLayoutDirectionChangedSignal_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint ViewLayoutDirectionChangedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ViewLayoutDirectionChangedSignal_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return ViewLayoutDirectionChangedSignal_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Connect")]
        public static extern void ViewLayoutDirectionChangedSignal_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Connect")]
        public static extern void ViewLayoutDirectionChangedSignal_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void ViewLayoutDirectionChangedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ViewLayoutDirectionChangedSignal_Connect_vulkan(jarg1, jarg2);
            }
            else
            {
                ViewLayoutDirectionChangedSignal_Connect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Disconnect")]
        public static extern void ViewLayoutDirectionChangedSignal_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Disconnect")]
        public static extern void ViewLayoutDirectionChangedSignal_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void ViewLayoutDirectionChangedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ViewLayoutDirectionChangedSignal_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                ViewLayoutDirectionChangedSignal_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Emit")]
        public static extern void ViewLayoutDirectionChangedSignal_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Emit")]
        public static extern void ViewLayoutDirectionChangedSignal_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void ViewLayoutDirectionChangedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                ViewLayoutDirectionChangedSignal_Emit_vulkan(jarg1, jarg2);
            }
            else
            {
                ViewLayoutDirectionChangedSignal_Emit_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_View_SetLayout")]
        public static extern void View_SetLayout_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_View_SetLayout")]
        public static extern void View_SetLayout_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void View_SetLayout(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                View_SetLayout_vulkan(jarg1, jarg2);
            }
            else
            {
                View_SetLayout_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_View_GetLayout")]
        public static extern global::System.IntPtr View_GetLayout_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_View_GetLayout")]
        public static extern global::System.IntPtr View_GetLayout_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr View_GetLayout(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return View_GetLayout_vulkan(jarg1);
            }
            else
            {
                return View_GetLayout_gl(jarg1);
            }
        }


        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_SetLayoutingRequired")]
        public static extern void View_SetLayoutingRequired_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_SetLayoutingRequired")]
        public static extern void View_SetLayoutRequired_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void View_SetLayoutingRequired(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                View_SetLayoutRequired_vulkan(jarg1, jarg2);
            }
            else
            {
                View_SetLayoutingRequired_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_View_IsLayoutingRequired")]
        public static extern bool View_IsLayoutingRequired_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_View_IsLayoutingRequired")]
        public static extern bool View_IsLayoutingRequired_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool View_IsLayoutingRequired(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return View_IsLayoutingRequired_vulkan(jarg1);
            }
            else
            {
                return View_IsLayoutingRequired_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_ViewLayoutDirectionSignal")]
        public static extern global::System.IntPtr new_ViewLayoutDirectionChangedSignal_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_ViewLayoutDirectionSignal")]
        public static extern global::System.IntPtr new_ViewLayoutDirectionChangedSignal_vulkan();

        public static global::System.IntPtr new_ViewLayoutDirectionChangedSignal()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_ViewLayoutDirectionChangedSignal_vulkan();
            }
            else
            {
                return new_ViewLayoutDirectionChangedSignal_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_ViewLayoutDirectionSignal")]
        public static extern void delete_ViewLayoutDirectionChangedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_ViewLayoutDirectionSignal")]
        public static extern void delete_ViewLayoutDirectionChangedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_ViewLayoutDirectionChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_ViewLayoutDirectionChangedSignal_vulkan(jarg1);
            }
            else
            {
                delete_ViewLayoutDirectionChangedSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_RenderOnce")]
        public static extern void Window_RenderOnce_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Adaptor_RenderOnce")]
        public static extern void Window_RenderOnce_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void Window_RenderOnce(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                Window_RenderOnce_vulkan(jarg1);
            }
            else
            {
                Window_RenderOnce_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Window_New_Root_Layout")]
        public static extern global::System.IntPtr Window_NewRootLayout_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Window_New_Root_Layout")]
        public static extern global::System.IntPtr Window_NewRootLayout_vulkan();

        public static global::System.IntPtr Window_NewRootLayout()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Window_NewRootLayout_vulkan();
            }
            else
            {
                return Window_NewRootLayout_gl();
            }
        }

        //for watch
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_WatchTime")]
        public static extern global::System.IntPtr new_WatchTime_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_WatchTime")]
        public static extern global::System.IntPtr new_WatchTime_vulkan();

        public static global::System.IntPtr new_WatchTime()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_WatchTime_vulkan();
            }
            else
            {
                return new_WatchTime_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_WatchTime")]
        public static extern void delete_WatchTime_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_WatchTime")]
        public static extern void delete_WatchTime_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_WatchTime(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_WatchTime_vulkan(jarg1);
            }
            else
            {
                delete_WatchTime_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetHour")]
        public static extern int WatchTime_GetHour_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetHour")]
        public static extern int WatchTime_GetHour_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int WatchTime_GetHour(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTime_GetHour_vulkan(jarg1);
            }
            else
            {
                return WatchTime_GetHour_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetHour24")]
        public static extern int WatchTime_GetHour24_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetHour24")]
        public static extern int WatchTime_GetHour24_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int WatchTime_GetHour24(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTime_GetHour24_vulkan(jarg1);
            }
            else
            {
                return WatchTime_GetHour24_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetMinute")]
        public static extern int WatchTime_GetMinute_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetMinute")]
        public static extern int WatchTime_GetMinute_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int WatchTime_GetMinute(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTime_GetMinute_vulkan(jarg1);
            }
            else
            {
                return WatchTime_GetMinute_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetSecond")]
        public static extern int WatchTime_GetSecond_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetSecond")]
        public static extern int WatchTime_GetSecond_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int WatchTime_GetSecond(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTime_GetSecond_vulkan(jarg1);
            }
            else
            {
                return WatchTime_GetSecond_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetMillisecond")]
        public static extern int WatchTime_GetMillisecond_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetMillisecond")]
        public static extern int WatchTime_GetMillisecond_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int WatchTime_GetMillisecond(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTime_GetMillisecond_vulkan(jarg1);
            }
            else
            {
                return WatchTime_GetMillisecond_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetYear")]
        public static extern int WatchTime_GetYear_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetYear")]
        public static extern int WatchTime_GetYear_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int WatchTime_GetYear(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTime_GetYear_vulkan(jarg1);
            }
            else
            {
                return WatchTime_GetYear_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetMonth")]
        public static extern int WatchTime_GetMonth_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetMonth")]
        public static extern int WatchTime_GetMonth_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int WatchTime_GetMonth(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTime_GetMonth_vulkan(jarg1);
            }
            else
            {
                return WatchTime_GetMonth_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetDay")]
        public static extern int WatchTime_GetDay_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetDay")]
        public static extern int WatchTime_GetDay_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int WatchTime_GetDay(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTime_GetDay_vulkan(jarg1);
            }
            else
            {
                return WatchTime_GetDay_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetDayOfWeek")]
        public static extern int WatchTime_GetDayOfWeek_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetDayOfWeek")]
        public static extern int WatchTime_GetDayOfWeek_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int WatchTime_GetDayOfWeek(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTime_GetDayOfWeek_vulkan(jarg1);
            }
            else
            {
                return WatchTime_GetDayOfWeek_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetUtcTime")]
        public static extern global::System.IntPtr WatchTime_GetUtcTime_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetUtcTime")]
        public static extern global::System.IntPtr WatchTime_GetUtcTime_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr WatchTime_GetUtcTime(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTime_GetUtcTime_vulkan(jarg1);
            }
            else
            {
                return WatchTime_GetUtcTime_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetUtcTimeStamp")]
        public static extern global::System.IntPtr WatchTime_GetUtcTimeStamp_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetUtcTimeStamp")]
        public static extern global::System.IntPtr WatchTime_GetUtcTimeStamp_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr WatchTime_GetUtcTimeStamp(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTime_GetUtcTimeStamp_vulkan(jarg1);
            }
            else
            {
                return WatchTime_GetUtcTimeStamp_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetTimeZone")]
        public static extern string WatchTime_GetTimeZone_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetTimeZone")]
        public static extern string WatchTime_GetTimeZone_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static string WatchTime_GetTimeZone(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTime_GetTimeZone_vulkan(jarg1);
            }
            else
            {
                return WatchTime_GetTimeZone_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetDaylightSavingTimeStatus")]
        public static extern bool WatchTime_GetDaylightSavingTimeStatus_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTime_GetDaylightSavingTimeStatus")]
        public static extern bool WatchTime_GetDaylightSavingTimeStatus_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool WatchTime_GetDaylightSavingTimeStatus(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTime_GetDaylightSavingTimeStatus_vulkan(jarg1);
            }
            else
            {
                return WatchTime_GetDaylightSavingTimeStatus_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchApplication_New__SWIG_0")]
        public static extern global::System.IntPtr WatchApplication_New__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchApplication_New__SWIG_0")]
        public static extern global::System.IntPtr WatchApplication_New__SWIG_0_vulkan();

        public static global::System.IntPtr WatchApplication_New__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchApplication_New__SWIG_0_vulkan();
            }
            else
            {
                return WatchApplication_New__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchApplication_New__SWIG_1")]
        public static extern global::System.IntPtr WatchApplication_New__SWIG_1_gl(int jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchApplication_New__SWIG_1")]
        public static extern global::System.IntPtr WatchApplication_New__SWIG_1_vulkan(int jarg1, string jarg2);

        public static global::System.IntPtr WatchApplication_New__SWIG_1(int jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchApplication_New__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                return WatchApplication_New__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchApplication_New__SWIG_2")]
        public static extern global::System.IntPtr WatchApplication_New__SWIG_2_gl(int jarg1, string jarg2, string jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchApplication_New__SWIG_2")]
        public static extern global::System.IntPtr WatchApplication_New__SWIG_2_vulkan(int jarg1, string jarg2, string jarg3);

        public static global::System.IntPtr WatchApplication_New__SWIG_2(int jarg1, string jarg2, string jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchApplication_New__SWIG_2_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return WatchApplication_New__SWIG_2_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_WatchApplication__SWIG_0")]
        public static extern global::System.IntPtr new_WatchApplication__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_WatchApplication__SWIG_0")]
        public static extern global::System.IntPtr new_WatchApplication__SWIG_0_vulkan();

        public static global::System.IntPtr new_WatchApplication__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_WatchApplication__SWIG_0_vulkan();
            }
            else
            {
                return new_WatchApplication__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_WatchApplication__SWIG_1")]
        public static extern global::System.IntPtr new_WatchApplication__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_WatchApplication__SWIG_1")]
        public static extern global::System.IntPtr new_WatchApplication__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_WatchApplication__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_WatchApplication__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_WatchApplication__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchApplication_Assign")]
        public static extern global::System.IntPtr WatchApplication_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchApplication_Assign")]
        public static extern global::System.IntPtr WatchApplication_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr WatchApplication_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchApplication_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return WatchApplication_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_WatchApplication")]
        public static extern void delete_WatchApplication_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_WatchApplication")]
        public static extern void delete_WatchApplication_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_WatchApplication(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_WatchApplication_vulkan(jarg1);
            }
            else
            {
                delete_WatchApplication_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchApplication_TimeTickSignal")]
        public static extern global::System.IntPtr WatchApplication_TimeTickSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchApplication_TimeTickSignal")]
        public static extern global::System.IntPtr WatchApplication_TimeTickSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr WatchApplication_TimeTickSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchApplication_TimeTickSignal_vulkan(jarg1);
            }
            else
            {
                return WatchApplication_TimeTickSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchApplication_AmbientTickSignal")]
        public static extern global::System.IntPtr WatchApplication_AmbientTickSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchApplication_AmbientTickSignal")]
        public static extern global::System.IntPtr WatchApplication_AmbientTickSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr WatchApplication_AmbientTickSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchApplication_AmbientTickSignal_vulkan(jarg1);
            }
            else
            {
                return WatchApplication_AmbientTickSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchApplication_AmbientChangedSignal")]
        public static extern global::System.IntPtr WatchApplication_AmbientChangedSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchApplication_AmbientChangedSignal")]
        public static extern global::System.IntPtr WatchApplication_AmbientChangedSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr WatchApplication_AmbientChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchApplication_AmbientChangedSignal_vulkan(jarg1);
            }
            else
            {
                return WatchApplication_AmbientChangedSignal_gl(jarg1);
            }
        }

        //for watch signal
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTimeSignal_Empty")]
        public static extern bool WatchTimeSignal_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTimeSignal_Empty")]
        public static extern bool WatchTimeSignal_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool WatchTimeSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTimeSignal_Empty_vulkan(jarg1);
            }
            else
            {
                return WatchTimeSignal_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTimeSignal_GetConnectionCount")]
        public static extern uint WatchTimeSignal_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTimeSignal_GetConnectionCount")]
        public static extern uint WatchTimeSignal_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint WatchTimeSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchTimeSignal_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return WatchTimeSignal_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTimeSignal_Connect")]
        public static extern void WatchTimeSignal_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTimeSignal_Connect")]
        public static extern void WatchTimeSignal_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void WatchTimeSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WatchTimeSignal_Connect_vulkan(jarg1, jarg2);
            }
            else
            {
                WatchTimeSignal_Connect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTimeSignal_Disconnect")]
        public static extern void WatchTimeSignal_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTimeSignal_Disconnect")]
        public static extern void WatchTimeSignal_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void WatchTimeSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WatchTimeSignal_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                WatchTimeSignal_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchTimeSignal_Emit")]
        public static extern void WatchTimeSignal_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchTimeSignal_Emit")]
        public static extern void WatchTimeSignal_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void WatchTimeSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WatchTimeSignal_Emit_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                WatchTimeSignal_Emit_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_WatchTimeSignal")]
        public static extern global::System.IntPtr new_WatchTimeSignal_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_WatchTimeSignal")]
        public static extern global::System.IntPtr new_WatchTimeSignal_vulkan();

        public static global::System.IntPtr new_WatchTimeSignal()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_WatchTimeSignal_vulkan();
            }
            else
            {
                return new_WatchTimeSignal_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_WatchTimeSignal")]
        public static extern void delete_WatchTimeSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_WatchTimeSignal")]
        public static extern void delete_WatchTimeSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_WatchTimeSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_WatchTimeSignal_vulkan(jarg1);
            }
            else
            {
                delete_WatchTimeSignal_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchBoolSignal_Empty")]
        public static extern bool WatchBoolSignal_Empty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchBoolSignal_Empty")]
        public static extern bool WatchBoolSignal_Empty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool WatchBoolSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchBoolSignal_Empty_vulkan(jarg1);
            }
            else
            {
                return WatchBoolSignal_Empty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchBoolSignal_GetConnectionCount")]
        public static extern uint WatchBoolSignal_GetConnectionCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchBoolSignal_GetConnectionCount")]
        public static extern uint WatchBoolSignal_GetConnectionCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint WatchBoolSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WatchBoolSignal_GetConnectionCount_vulkan(jarg1);
            }
            else
            {
                return WatchBoolSignal_GetConnectionCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchBoolSignal_Connect")]
        public static extern void WatchBoolSignal_Connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchBoolSignal_Connect")]
        public static extern void WatchBoolSignal_Connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void WatchBoolSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WatchBoolSignal_Connect_vulkan(jarg1, jarg2);
            }
            else
            {
                WatchBoolSignal_Connect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchBoolSignal_Disconnect")]
        public static extern void WatchBoolSignal_Disconnect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchBoolSignal_Disconnect")]
        public static extern void WatchBoolSignal_Disconnect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void WatchBoolSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WatchBoolSignal_Disconnect_vulkan(jarg1, jarg2);
            }
            else
            {
                WatchBoolSignal_Disconnect_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WatchBoolSignal_Emit")]
        public static extern void WatchBoolSignal_Emit_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WatchBoolSignal_Emit")]
        public static extern void WatchBoolSignal_Emit_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3);

        public static void WatchBoolSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                WatchBoolSignal_Emit_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                WatchBoolSignal_Emit_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_WatchBoolSignal")]
        public static extern global::System.IntPtr new_WatchBoolSignal_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_WatchBoolSignal")]
        public static extern global::System.IntPtr new_WatchBoolSignal_vulkan();

        public static global::System.IntPtr new_WatchBoolSignal()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_WatchBoolSignal_vulkan();
            }
            else
            {
                return new_WatchBoolSignal_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_WatchBoolSignal")]
        public static extern void delete_WatchBoolSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_WatchBoolSignal")]
        public static extern void delete_WatchBoolSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_WatchBoolSignal(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_WatchBoolSignal_vulkan(jarg1);
            }
            else
            {
                delete_WatchBoolSignal_gl(jarg1);
            }
        }

        //for FontClient
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_SWIGUpcast")]
        public static extern global::System.IntPtr FontClient_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_SWIGUpcast")]
        public static extern global::System.IntPtr FontClient_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr FontClient_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return FontClient_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontWidthName_get")]
        public static extern global::System.IntPtr FontWidthName_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontWidthName_get")]
        public static extern global::System.IntPtr FontWidthName_get_vulkan();

        public static global::System.IntPtr FontWidthName_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontWidthName_get_vulkan();
            }
            else
            {
                return FontWidthName_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontWeightName_get")]
        public static extern global::System.IntPtr FontWeightName_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontWeightName_get")]
        public static extern global::System.IntPtr FontWeightName_get_vulkan();

        public static global::System.IntPtr FontWeightName_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontWeightName_get_vulkan();
            }
            else
            {
                return FontWeightName_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontSlantName_get")]
        public static extern global::System.IntPtr FontSlantName_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontSlantName_get")]
        public static extern global::System.IntPtr FontSlantName_get_vulkan();

        public static global::System.IntPtr FontSlantName_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontSlantName_get_vulkan();
            }
            else
            {
                return FontSlantName_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_FontDescription")]
        public static extern global::System.IntPtr new_FontDescription_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_FontDescription")]
        public static extern global::System.IntPtr new_FontDescription_vulkan();

        public static global::System.IntPtr new_FontDescription()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_FontDescription_vulkan();
            }
            else
            {
                return new_FontDescription_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_FontDescription")]
        public static extern void delete_FontDescription_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_FontDescription")]
        public static extern void delete_FontDescription_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_FontDescription(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_FontDescription_vulkan(jarg1);
            }
            else
            {
                delete_FontDescription_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_path_set")]
        public static extern void FontDescription_path_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_path_set")]
        public static extern void FontDescription_path_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static void FontDescription_path_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontDescription_path_set_vulkan(jarg1, jarg2);
            }
            else
            {
                FontDescription_path_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_path_get")]
        public static extern string FontDescription_path_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_path_get")]
        public static extern string FontDescription_path_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static string FontDescription_path_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontDescription_path_get_vulkan(jarg1);
            }
            else
            {
                return FontDescription_path_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_family_set")]
        public static extern void FontDescription_family_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_family_set")]
        public static extern void FontDescription_family_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static void FontDescription_family_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontDescription_family_set_vulkan(jarg1, jarg2);
            }
            else
            {
                FontDescription_family_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_family_get")]
        public static extern string FontDescription_family_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_family_get")]
        public static extern string FontDescription_family_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static string FontDescription_family_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontDescription_family_get_vulkan(jarg1);
            }
            else
            {
                return FontDescription_family_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_width_set")]
        public static extern void FontDescription_width_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_width_set")]
        public static extern void FontDescription_width_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void FontDescription_width_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontDescription_width_set_vulkan(jarg1, jarg2);
            }
            else
            {
                FontDescription_width_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_width_get")]
        public static extern int FontDescription_width_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_width_get")]
        public static extern int FontDescription_width_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int FontDescription_width_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontDescription_width_get_vulkan(jarg1);
            }
            else
            {
                return FontDescription_width_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_weight_set")]
        public static extern void FontDescription_weight_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_weight_set")]
        public static extern void FontDescription_weight_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void FontDescription_weight_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontDescription_weight_set_vulkan(jarg1, jarg2);
            }
            else
            {
                FontDescription_weight_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_weight_get")]
        public static extern int FontDescription_weight_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_weight_get")]
        public static extern int FontDescription_weight_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int FontDescription_weight_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontDescription_weight_get_vulkan(jarg1);
            }
            else
            {
                return FontDescription_weight_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_slant_set")]
        public static extern void FontDescription_slant_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_slant_set")]
        public static extern void FontDescription_slant_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void FontDescription_slant_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontDescription_slant_set_vulkan(jarg1, jarg2);
            }
            else
            {
                FontDescription_slant_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_slant_get")]
        public static extern int FontDescription_slant_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontDescription_slant_get")]
        public static extern int FontDescription_slant_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int FontDescription_slant_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontDescription_slant_get_vulkan(jarg1);
            }
            else
            {
                return FontDescription_slant_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_FontMetrics__SWIG_0")]
        public static extern global::System.IntPtr new_FontMetrics__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_FontMetrics__SWIG_0")]
        public static extern global::System.IntPtr new_FontMetrics__SWIG_0_vulkan();

        public static global::System.IntPtr new_FontMetrics__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_FontMetrics__SWIG_0_vulkan();
            }
            else
            {
                return new_FontMetrics__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_FontMetrics__SWIG_1")]
        public static extern global::System.IntPtr new_FontMetrics__SWIG_1_gl(float jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_FontMetrics__SWIG_1")]
        public static extern global::System.IntPtr new_FontMetrics__SWIG_1_vulkan(float jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

        public static global::System.IntPtr new_FontMetrics__SWIG_1(float jarg1, float jarg2, float jarg3, float jarg4, float jarg5)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_FontMetrics__SWIG_1_vulkan(jarg1, jarg2, jarg3, jarg4, jarg5);
            }
            else
            {
                return new_FontMetrics__SWIG_1_gl(jarg1, jarg2, jarg3, jarg4, jarg5);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_ascender_set")]
        public static extern void FontMetrics_ascender_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_ascender_set")]
        public static extern void FontMetrics_ascender_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static void FontMetrics_ascender_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontMetrics_ascender_set_vulkan(jarg1, jarg2);
            }
            else
            {
                FontMetrics_ascender_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_ascender_get")]
        public static extern float FontMetrics_ascender_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_ascender_get")]
        public static extern float FontMetrics_ascender_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static float FontMetrics_ascender_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontMetrics_ascender_get_vulkan(jarg1);
            }
            else
            {
                return FontMetrics_ascender_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_descender_set")]
        public static extern void FontMetrics_descender_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_descender_set")]
        public static extern void FontMetrics_descender_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static void FontMetrics_descender_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontMetrics_descender_set_vulkan(jarg1, jarg2);
            }
            else
            {
                FontMetrics_descender_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_descender_get")]
        public static extern float FontMetrics_descender_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_descender_get")]
        public static extern float FontMetrics_descender_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static float FontMetrics_descender_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontMetrics_descender_get_vulkan(jarg1);
            }
            else
            {
                return FontMetrics_descender_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_height_set")]
        public static extern void FontMetrics_height_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_height_set")]
        public static extern void FontMetrics_height_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static void FontMetrics_height_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontMetrics_height_set_vulkan(jarg1, jarg2);
            }
            else
            {
                FontMetrics_height_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_height_get")]
        public static extern float FontMetrics_height_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_height_get")]
        public static extern float FontMetrics_height_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static float FontMetrics_height_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontMetrics_height_get_vulkan(jarg1);
            }
            else
            {
                return FontMetrics_height_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_underlinePosition_set")]
        public static extern void FontMetrics_underlinePosition_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_underlinePosition_set")]
        public static extern void FontMetrics_underlinePosition_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static void FontMetrics_underlinePosition_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontMetrics_underlinePosition_set_vulkan(jarg1, jarg2);
            }
            else
            {
                FontMetrics_underlinePosition_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_underlinePosition_get")]
        public static extern float FontMetrics_underlinePosition_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_underlinePosition_get")]
        public static extern float FontMetrics_underlinePosition_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static float FontMetrics_underlinePosition_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontMetrics_underlinePosition_get_vulkan(jarg1);
            }
            else
            {
                return FontMetrics_underlinePosition_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_underlineThickness_set")]
        public static extern void FontMetrics_underlineThickness_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_underlineThickness_set")]
        public static extern void FontMetrics_underlineThickness_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static void FontMetrics_underlineThickness_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontMetrics_underlineThickness_set_vulkan(jarg1, jarg2);
            }
            else
            {
                FontMetrics_underlineThickness_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_underlineThickness_get")]
        public static extern float FontMetrics_underlineThickness_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontMetrics_underlineThickness_get")]
        public static extern float FontMetrics_underlineThickness_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static float FontMetrics_underlineThickness_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontMetrics_underlineThickness_get_vulkan(jarg1);
            }
            else
            {
                return FontMetrics_underlineThickness_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_FontMetrics")]
        public static extern void delete_FontMetrics_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_FontMetrics")]
        public static extern void delete_FontMetrics_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_FontMetrics(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_FontMetrics_vulkan(jarg1);
            }
            else
            {
                delete_FontMetrics_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LINE_MUST_BREAK_get")]
        public static extern int LINE_MUST_BREAK_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LINE_MUST_BREAK_get")]
        public static extern int LINE_MUST_BREAK_get_vulkan();

        public static int LINE_MUST_BREAK_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LINE_MUST_BREAK_get_vulkan();
            }
            else
            {
                return LINE_MUST_BREAK_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LINE_ALLOW_BREAK_get")]
        public static extern int LINE_ALLOW_BREAK_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LINE_ALLOW_BREAK_get")]
        public static extern int LINE_ALLOW_BREAK_get_vulkan();

        public static int LINE_ALLOW_BREAK_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LINE_ALLOW_BREAK_get_vulkan();
            }
            else
            {
                return LINE_ALLOW_BREAK_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LINE_NO_BREAK_get")]
        public static extern int LINE_NO_BREAK_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LINE_NO_BREAK_get")]
        public static extern int LINE_NO_BREAK_get_vulkan();

        public static int LINE_NO_BREAK_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LINE_NO_BREAK_get_vulkan();
            }
            else
            {
                return LINE_NO_BREAK_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WORD_BREAK_get")]
        public static extern int WORD_BREAK_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WORD_BREAK_get")]
        public static extern int WORD_BREAK_get_vulkan();

        public static int WORD_BREAK_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WORD_BREAK_get_vulkan();
            }
            else
            {
                return WORD_BREAK_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_WORD_NO_BREAK_get")]
        public static extern int WORD_NO_BREAK_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_WORD_NO_BREAK_get")]
        public static extern int WORD_NO_BREAK_get_vulkan();

        public static int WORD_NO_BREAK_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return WORD_NO_BREAK_get_vulkan();
            }
            else
            {
                return WORD_NO_BREAK_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_r_set")]
        public static extern void VectorBlob_r_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_r_set")]
        public static extern void VectorBlob_r_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

        public static void VectorBlob_r_set(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                VectorBlob_r_set_vulkan(jarg1, jarg2);
            }
            else
            {
                VectorBlob_r_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_r_get")]
        public static extern byte VectorBlob_r_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_r_get")]
        public static extern byte VectorBlob_r_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static byte VectorBlob_r_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return VectorBlob_r_get_vulkan(jarg1);
            }
            else
            {
                return VectorBlob_r_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_g_set")]
        public static extern void VectorBlob_g_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_g_set")]
        public static extern void VectorBlob_g_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

        public static void VectorBlob_g_set(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                VectorBlob_g_set_vulkan(jarg1, jarg2);
            }
            else
            {
                VectorBlob_g_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_g_get")]
        public static extern byte VectorBlob_g_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_g_get")]
        public static extern byte VectorBlob_g_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static byte VectorBlob_g_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return VectorBlob_g_get_vulkan(jarg1);
            }
            else
            {
                return VectorBlob_g_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_b_set")]
        public static extern void VectorBlob_b_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_b_set")]
        public static extern void VectorBlob_b_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

        public static void VectorBlob_b_set(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                VectorBlob_b_set_vulkan(jarg1, jarg2);
            }
            else
            {
                VectorBlob_b_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_b_get")]
        public static extern byte VectorBlob_b_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_b_get")]
        public static extern byte VectorBlob_b_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static byte VectorBlob_b_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return VectorBlob_b_get_vulkan(jarg1);
            }
            else
            {
                return VectorBlob_b_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_a_set")]
        public static extern void VectorBlob_a_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_a_set")]
        public static extern void VectorBlob_a_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

        public static void VectorBlob_a_set(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                VectorBlob_a_set_vulkan(jarg1, jarg2);
            }
            else
            {
                VectorBlob_a_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_a_get")]
        public static extern byte VectorBlob_a_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_VectorBlob_a_get")]
        public static extern byte VectorBlob_a_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static byte VectorBlob_a_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return VectorBlob_a_get_vulkan(jarg1);
            }
            else
            {
                return VectorBlob_a_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_VectorBlob")]
        public static extern global::System.IntPtr new_VectorBlob_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_VectorBlob")]
        public static extern global::System.IntPtr new_VectorBlob_vulkan();

        public static global::System.IntPtr new_VectorBlob()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_VectorBlob_vulkan();
            }
            else
            {
                return new_VectorBlob_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_VectorBlob")]
        public static extern void delete_VectorBlob_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_VectorBlob")]
        public static extern void delete_VectorBlob_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_VectorBlob(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_VectorBlob_vulkan(jarg1);
            }
            else
            {
                delete_VectorBlob_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_GlyphInfo__SWIG_0")]
        public static extern global::System.IntPtr new_GlyphInfo__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_GlyphInfo__SWIG_0")]
        public static extern global::System.IntPtr new_GlyphInfo__SWIG_0_vulkan();

        public static global::System.IntPtr new_GlyphInfo__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_GlyphInfo__SWIG_0_vulkan();
            }
            else
            {
                return new_GlyphInfo__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_GlyphInfo__SWIG_1")]
        public static extern global::System.IntPtr new_GlyphInfo__SWIG_1_gl(uint jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_GlyphInfo__SWIG_1")]
        public static extern global::System.IntPtr new_GlyphInfo__SWIG_1_vulkan(uint jarg1, uint jarg2);

        public static global::System.IntPtr new_GlyphInfo__SWIG_1(uint jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_GlyphInfo__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                return new_GlyphInfo__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_fontId_set")]
        public static extern void GlyphInfo_fontId_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_fontId_set")]
        public static extern void GlyphInfo_fontId_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static void GlyphInfo_fontId_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                GlyphInfo_fontId_set_vulkan(jarg1, jarg2);
            }
            else
            {
                GlyphInfo_fontId_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_fontId_get")]
        public static extern uint GlyphInfo_fontId_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_fontId_get")]
        public static extern uint GlyphInfo_fontId_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint GlyphInfo_fontId_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GlyphInfo_fontId_get_vulkan(jarg1);
            }
            else
            {
                return GlyphInfo_fontId_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_index_set")]
        public static extern void GlyphInfo_index_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_index_set")]
        public static extern void GlyphInfo_index_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static void GlyphInfo_index_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                GlyphInfo_index_set_vulkan(jarg1, jarg2);
            }
            else
            {
                GlyphInfo_index_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_index_get")]
        public static extern uint GlyphInfo_index_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_index_get")]
        public static extern uint GlyphInfo_index_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint GlyphInfo_index_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GlyphInfo_index_get_vulkan(jarg1);
            }
            else
            {
                return GlyphInfo_index_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_width_set")]
        public static extern void GlyphInfo_width_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_width_set")]
        public static extern void GlyphInfo_width_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static void GlyphInfo_width_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                GlyphInfo_width_set_vulkan(jarg1, jarg2);
            }
            else
            {
                GlyphInfo_width_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_width_get")]
        public static extern float GlyphInfo_width_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_width_get")]
        public static extern float GlyphInfo_width_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static float GlyphInfo_width_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GlyphInfo_width_get_vulkan(jarg1);
            }
            else
            {
                return GlyphInfo_width_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_height_set")]
        public static extern void GlyphInfo_height_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_height_set")]
        public static extern void GlyphInfo_height_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static void GlyphInfo_height_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                GlyphInfo_height_set_vulkan(jarg1, jarg2);
            }
            else
            {
                GlyphInfo_height_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_height_get")]
        public static extern float GlyphInfo_height_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_height_get")]
        public static extern float GlyphInfo_height_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static float GlyphInfo_height_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GlyphInfo_height_get_vulkan(jarg1);
            }
            else
            {
                return GlyphInfo_height_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_xBearing_set")]
        public static extern void GlyphInfo_xBearing_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_xBearing_set")]
        public static extern void GlyphInfo_xBearing_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static void GlyphInfo_xBearing_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                GlyphInfo_xBearing_set_vulkan(jarg1, jarg2);
            }
            else
            {
                GlyphInfo_xBearing_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_xBearing_get")]
        public static extern float GlyphInfo_xBearing_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_xBearing_get")]
        public static extern float GlyphInfo_xBearing_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static float GlyphInfo_xBearing_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GlyphInfo_xBearing_get_vulkan(jarg1);
            }
            else
            {
                return GlyphInfo_xBearing_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_yBearing_set")]
        public static extern void GlyphInfo_yBearing_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_yBearing_set")]
        public static extern void GlyphInfo_yBearing_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static void GlyphInfo_yBearing_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                GlyphInfo_yBearing_set_vulkan(jarg1, jarg2);
            }
            else
            {
                GlyphInfo_yBearing_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_yBearing_get")]
        public static extern float GlyphInfo_yBearing_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_yBearing_get")]
        public static extern float GlyphInfo_yBearing_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static float GlyphInfo_yBearing_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GlyphInfo_yBearing_get_vulkan(jarg1);
            }
            else
            {
                return GlyphInfo_yBearing_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_advance_set")]
        public static extern void GlyphInfo_advance_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_advance_set")]
        public static extern void GlyphInfo_advance_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static void GlyphInfo_advance_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                GlyphInfo_advance_set_vulkan(jarg1, jarg2);
            }
            else
            {
                GlyphInfo_advance_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_advance_get")]
        public static extern float GlyphInfo_advance_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_advance_get")]
        public static extern float GlyphInfo_advance_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static float GlyphInfo_advance_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GlyphInfo_advance_get_vulkan(jarg1);
            }
            else
            {
                return GlyphInfo_advance_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_scaleFactor_set")]
        public static extern void GlyphInfo_scaleFactor_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_scaleFactor_set")]
        public static extern void GlyphInfo_scaleFactor_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static void GlyphInfo_scaleFactor_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                GlyphInfo_scaleFactor_set_vulkan(jarg1, jarg2);
            }
            else
            {
                GlyphInfo_scaleFactor_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_scaleFactor_get")]
        public static extern float GlyphInfo_scaleFactor_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GlyphInfo_scaleFactor_get")]
        public static extern float GlyphInfo_scaleFactor_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static float GlyphInfo_scaleFactor_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GlyphInfo_scaleFactor_get_vulkan(jarg1);
            }
            else
            {
                return GlyphInfo_scaleFactor_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_GlyphInfo")]
        public static extern void delete_GlyphInfo_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_GlyphInfo")]
        public static extern void delete_GlyphInfo_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_GlyphInfo(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_GlyphInfo_vulkan(jarg1);
            }
            else
            {
                delete_GlyphInfo_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_DEFAULT_POINT_SIZE_get")]
        public static extern uint FontClient_DEFAULT_POINT_SIZE_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_DEFAULT_POINT_SIZE_get")]
        public static extern uint FontClient_DEFAULT_POINT_SIZE_get_vulkan();

        public static uint FontClient_DEFAULT_POINT_SIZE_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_DEFAULT_POINT_SIZE_get_vulkan();
            }
            else
            {
                return FontClient_DEFAULT_POINT_SIZE_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_FontClient_GlyphBufferData")]
        public static extern global::System.IntPtr new_FontClient_GlyphBufferData_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_FontClient_GlyphBufferData")]
        public static extern global::System.IntPtr new_FontClient_GlyphBufferData_vulkan();

        public static global::System.IntPtr new_FontClient_GlyphBufferData()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_FontClient_GlyphBufferData_vulkan();
            }
            else
            {
                return new_FontClient_GlyphBufferData_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_FontClient_GlyphBufferData")]
        public static extern void delete_FontClient_GlyphBufferData_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_FontClient_GlyphBufferData")]
        public static extern void delete_FontClient_GlyphBufferData_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_FontClient_GlyphBufferData(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_FontClient_GlyphBufferData_vulkan(jarg1);
            }
            else
            {
                delete_FontClient_GlyphBufferData_gl(jarg1);
            }
        }
        /*
                [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint="CSharp_Dali_FontClient_GlyphBufferData_buffer_set")]
                public static extern void FontClient_GlyphBufferData_buffer_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg2);

                [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint="CSharp_Dali_FontClient_GlyphBufferData_buffer_set")]
                public static extern void FontClient_GlyphBufferData_buffer_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg2);

                public static void FontClient_GlyphBufferData_buffer_set(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg2)
                {
                    if(Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
                    {
                        FontClient_GlyphBufferData_buffer_set_vulkan(jarg1, jarg2);
                    }
                    else
                    {
                        FontClient_GlyphBufferData_buffer_set_gl(jarg1, jarg2);
                    }
                }

                [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint="CSharp_Dali_FontClient_GlyphBufferData_buffer_get")]
                public static extern byte[] FontClient_GlyphBufferData_buffer_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

                [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint="CSharp_Dali_FontClient_GlyphBufferData_buffer_get")]
                public static extern byte[] FontClient_GlyphBufferData_buffer_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

                public static byte[] FontClient_GlyphBufferData_buffer_get(global::System.Runtime.InteropServices.HandleRef jarg1)
                {
                    if(Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
                    {
                        return FontClient_GlyphBufferData_buffer_get_vulkan(jarg1);
                    }
                    else
                    {
                        return FontClient_GlyphBufferData_buffer_get_gl(jarg1);
                    }
                }
        */
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_width_set")]
        public static extern void FontClient_GlyphBufferData_width_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_width_set")]
        public static extern void FontClient_GlyphBufferData_width_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static void FontClient_GlyphBufferData_width_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_GlyphBufferData_width_set_vulkan(jarg1, jarg2);
            }
            else
            {
                FontClient_GlyphBufferData_width_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_width_get")]
        public static extern uint FontClient_GlyphBufferData_width_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_width_get")]
        public static extern uint FontClient_GlyphBufferData_width_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint FontClient_GlyphBufferData_width_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GlyphBufferData_width_get_vulkan(jarg1);
            }
            else
            {
                return FontClient_GlyphBufferData_width_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_height_set")]
        public static extern void FontClient_GlyphBufferData_height_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_height_set")]
        public static extern void FontClient_GlyphBufferData_height_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static void FontClient_GlyphBufferData_height_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_GlyphBufferData_height_set_vulkan(jarg1, jarg2);
            }
            else
            {
                FontClient_GlyphBufferData_height_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_height_get")]
        public static extern uint FontClient_GlyphBufferData_height_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_height_get")]
        public static extern uint FontClient_GlyphBufferData_height_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint FontClient_GlyphBufferData_height_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GlyphBufferData_height_get_vulkan(jarg1);
            }
            else
            {
                return FontClient_GlyphBufferData_height_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_format_set")]
        public static extern void FontClient_GlyphBufferData_format_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_format_set")]
        public static extern void FontClient_GlyphBufferData_format_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void FontClient_GlyphBufferData_format_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_GlyphBufferData_format_set_vulkan(jarg1, jarg2);
            }
            else
            {
                FontClient_GlyphBufferData_format_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_format_get")]
        public static extern int FontClient_GlyphBufferData_format_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_format_get")]
        public static extern int FontClient_GlyphBufferData_format_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int FontClient_GlyphBufferData_format_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GlyphBufferData_format_get_vulkan(jarg1);
            }
            else
            {
                return FontClient_GlyphBufferData_format_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_Get")]
        public static extern global::System.IntPtr FontClient_Get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_Get")]
        public static extern global::System.IntPtr FontClient_Get_vulkan();

        public static global::System.IntPtr FontClient_Get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_Get_vulkan();
            }
            else
            {
                return FontClient_Get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_FontClient__SWIG_0")]
        public static extern global::System.IntPtr new_FontClient__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_FontClient__SWIG_0")]
        public static extern global::System.IntPtr new_FontClient__SWIG_0_vulkan();

        public static global::System.IntPtr new_FontClient__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_FontClient__SWIG_0_vulkan();
            }
            else
            {
                return new_FontClient__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_FontClient")]
        public static extern void delete_FontClient_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_FontClient")]
        public static extern void delete_FontClient_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_FontClient(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_FontClient_vulkan(jarg1);
            }
            else
            {
                delete_FontClient_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_FontClient__SWIG_1")]
        public static extern global::System.IntPtr new_FontClient__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_FontClient__SWIG_1")]
        public static extern global::System.IntPtr new_FontClient__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_FontClient__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_FontClient__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_FontClient__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_Assign")]
        public static extern global::System.IntPtr FontClient_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_Assign")]
        public static extern global::System.IntPtr FontClient_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr FontClient_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return FontClient_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_SetDpi")]
        public static extern void FontClient_SetDpi_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_SetDpi")]
        public static extern void FontClient_SetDpi_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        public static void FontClient_SetDpi(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_SetDpi_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                FontClient_SetDpi_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetDpi")]
        public static extern void FontClient_GetDpi_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetDpi")]
        public static extern void FontClient_GetDpi_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void FontClient_GetDpi(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_GetDpi_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                FontClient_GetDpi_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetDefaultFontSize")]
        public static extern int FontClient_GetDefaultFontSize_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetDefaultFontSize")]
        public static extern int FontClient_GetDefaultFontSize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int FontClient_GetDefaultFontSize(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GetDefaultFontSize_vulkan(jarg1);
            }
            else
            {
                return FontClient_GetDefaultFontSize_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_ResetSystemDefaults")]
        public static extern void FontClient_ResetSystemDefaults_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_ResetSystemDefaults")]
        public static extern void FontClient_ResetSystemDefaults_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void FontClient_ResetSystemDefaults(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_ResetSystemDefaults_vulkan(jarg1);
            }
            else
            {
                FontClient_ResetSystemDefaults_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetDefaultFonts")]
        public static extern void FontClient_GetDefaultFonts_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetDefaultFonts")]
        public static extern void FontClient_GetDefaultFonts_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void FontClient_GetDefaultFonts(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_GetDefaultFonts_vulkan(jarg1, jarg2);
            }
            else
            {
                FontClient_GetDefaultFonts_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetDefaultPlatformFontDescription")]
        public static extern void FontClient_GetDefaultPlatformFontDescription_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetDefaultPlatformFontDescription")]
        public static extern void FontClient_GetDefaultPlatformFontDescription_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void FontClient_GetDefaultPlatformFontDescription(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_GetDefaultPlatformFontDescription_vulkan(jarg1, jarg2);
            }
            else
            {
                FontClient_GetDefaultPlatformFontDescription_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetSystemFonts")]
        public static extern void FontClient_GetSystemFonts_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetSystemFonts")]
        public static extern void FontClient_GetSystemFonts_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void FontClient_GetSystemFonts(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_GetSystemFonts_vulkan(jarg1, jarg2);
            }
            else
            {
                FontClient_GetSystemFonts_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetDescription")]
        public static extern void FontClient_GetDescription_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetDescription")]
        public static extern void FontClient_GetDescription_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void FontClient_GetDescription(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_GetDescription_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                FontClient_GetDescription_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetPointSize")]
        public static extern uint FontClient_GetPointSize_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetPointSize")]
        public static extern uint FontClient_GetPointSize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static uint FontClient_GetPointSize(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GetPointSize_vulkan(jarg1, jarg2);
            }
            else
            {
                return FontClient_GetPointSize_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_IsCharacterSupportedByFont")]
        public static extern bool FontClient_IsCharacterSupportedByFont_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_IsCharacterSupportedByFont")]
        public static extern bool FontClient_IsCharacterSupportedByFont_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        public static bool FontClient_IsCharacterSupportedByFont(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_IsCharacterSupportedByFont_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return FontClient_IsCharacterSupportedByFont_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_0")]
        public static extern uint FontClient_FindDefaultFont__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, bool jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_0")]
        public static extern uint FontClient_FindDefaultFont__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, bool jarg4);

        public static uint FontClient_FindDefaultFont__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, bool jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_FindDefaultFont__SWIG_0_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                return FontClient_FindDefaultFont__SWIG_0_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_1")]
        public static extern uint FontClient_FindDefaultFont__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_1")]
        public static extern uint FontClient_FindDefaultFont__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        public static uint FontClient_FindDefaultFont__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_FindDefaultFont__SWIG_1_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return FontClient_FindDefaultFont__SWIG_1_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_2")]
        public static extern uint FontClient_FindDefaultFont__SWIG_2_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_2")]
        public static extern uint FontClient_FindDefaultFont__SWIG_2_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static uint FontClient_FindDefaultFont__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_FindDefaultFont__SWIG_2_vulkan(jarg1, jarg2);
            }
            else
            {
                return FontClient_FindDefaultFont__SWIG_2_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_0")]
        public static extern uint FontClient_FindFallbackFont__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, uint jarg4, bool jarg5);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_0")]
        public static extern uint FontClient_FindFallbackFont__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, uint jarg4, bool jarg5);

        public static uint FontClient_FindFallbackFont__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, uint jarg4, bool jarg5)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_FindFallbackFont__SWIG_0_vulkan(jarg1, jarg2, jarg3, jarg4, jarg5);
            }
            else
            {
                return FontClient_FindFallbackFont__SWIG_0_gl(jarg1, jarg2, jarg3, jarg4, jarg5);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_1")]
        public static extern uint FontClient_FindFallbackFont__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, uint jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_1")]
        public static extern uint FontClient_FindFallbackFont__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, uint jarg4);

        public static uint FontClient_FindFallbackFont__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, uint jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_FindFallbackFont__SWIG_1_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                return FontClient_FindFallbackFont__SWIG_1_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_2")]
        public static extern uint FontClient_FindFallbackFont__SWIG_2_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_2")]
        public static extern uint FontClient_FindFallbackFont__SWIG_2_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static uint FontClient_FindFallbackFont__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_FindFallbackFont__SWIG_2_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return FontClient_FindFallbackFont__SWIG_2_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_0")]
        public static extern uint FontClient_GetFontId__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, uint jarg3, uint jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_0")]
        public static extern uint FontClient_GetFontId__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, uint jarg3, uint jarg4);

        public static uint FontClient_GetFontId__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, uint jarg3, uint jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GetFontId__SWIG_0_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                return FontClient_GetFontId__SWIG_0_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_1")]
        public static extern uint FontClient_GetFontId__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, uint jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_1")]
        public static extern uint FontClient_GetFontId__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, uint jarg3);

        public static uint FontClient_GetFontId__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, uint jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GetFontId__SWIG_1_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return FontClient_GetFontId__SWIG_1_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_2")]
        public static extern uint FontClient_GetFontId__SWIG_2_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_2")]
        public static extern uint FontClient_GetFontId__SWIG_2_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static uint FontClient_GetFontId__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GetFontId__SWIG_2_vulkan(jarg1, jarg2);
            }
            else
            {
                return FontClient_GetFontId__SWIG_2_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_3")]
        public static extern uint FontClient_GetFontId__SWIG_3_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, uint jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_3")]
        public static extern uint FontClient_GetFontId__SWIG_3_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, uint jarg4);

        public static uint FontClient_GetFontId__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, uint jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GetFontId__SWIG_3_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                return FontClient_GetFontId__SWIG_3_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_4")]
        public static extern uint FontClient_GetFontId__SWIG_4_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_4")]
        public static extern uint FontClient_GetFontId__SWIG_4_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3);

        public static uint FontClient_GetFontId__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GetFontId__SWIG_4_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return FontClient_GetFontId__SWIG_4_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_5")]
        public static extern uint FontClient_GetFontId__SWIG_5_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_5")]
        public static extern uint FontClient_GetFontId__SWIG_5_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static uint FontClient_GetFontId__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GetFontId__SWIG_5_vulkan(jarg1, jarg2);
            }
            else
            {
                return FontClient_GetFontId__SWIG_5_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_IsScalable__SWIG_0")]
        public static extern bool FontClient_IsScalable__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_IsScalable__SWIG_0")]
        public static extern bool FontClient_IsScalable__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static bool FontClient_IsScalable__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_IsScalable__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                return FontClient_IsScalable__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_IsScalable__SWIG_1")]
        public static extern bool FontClient_IsScalable__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_IsScalable__SWIG_1")]
        public static extern bool FontClient_IsScalable__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static bool FontClient_IsScalable__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_IsScalable__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                return FontClient_IsScalable__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFixedSizes__SWIG_0")]
        public static extern void FontClient_GetFixedSizes__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFixedSizes__SWIG_0")]
        public static extern void FontClient_GetFixedSizes__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void FontClient_GetFixedSizes__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_GetFixedSizes__SWIG_0_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                FontClient_GetFixedSizes__SWIG_0_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFixedSizes__SWIG_1")]
        public static extern void FontClient_GetFixedSizes__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFixedSizes__SWIG_1")]
        public static extern void FontClient_GetFixedSizes__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void FontClient_GetFixedSizes__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_GetFixedSizes__SWIG_1_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                FontClient_GetFixedSizes__SWIG_1_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFontMetrics")]
        public static extern void FontClient_GetFontMetrics_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetFontMetrics")]
        public static extern void FontClient_GetFontMetrics_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void FontClient_GetFontMetrics(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_GetFontMetrics_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                FontClient_GetFontMetrics_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetGlyphIndex")]
        public static extern uint FontClient_GetGlyphIndex_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetGlyphIndex")]
        public static extern uint FontClient_GetGlyphIndex_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        public static uint FontClient_GetGlyphIndex(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GetGlyphIndex_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return FontClient_GetGlyphIndex_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetGlyphMetrics__SWIG_0")]
        public static extern bool FontClient_GetGlyphMetrics__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, int jarg4, bool jarg5);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetGlyphMetrics__SWIG_0")]
        public static extern bool FontClient_GetGlyphMetrics__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, int jarg4, bool jarg5);

        public static bool FontClient_GetGlyphMetrics__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, int jarg4, bool jarg5)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GetGlyphMetrics__SWIG_0_vulkan(jarg1, jarg2, jarg3, jarg4, jarg5);
            }
            else
            {
                return FontClient_GetGlyphMetrics__SWIG_0_gl(jarg1, jarg2, jarg3, jarg4, jarg5);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetGlyphMetrics__SWIG_1")]
        public static extern bool FontClient_GetGlyphMetrics__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, int jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetGlyphMetrics__SWIG_1")]
        public static extern bool FontClient_GetGlyphMetrics__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, int jarg4);

        public static bool FontClient_GetGlyphMetrics__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, int jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GetGlyphMetrics__SWIG_1_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                return FontClient_GetGlyphMetrics__SWIG_1_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_CreateBitmap__SWIG_0")]
        public static extern void FontClient_CreateBitmap__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, bool jarg4, bool jarg5, global::System.Runtime.InteropServices.HandleRef jarg6, int jarg7);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_CreateBitmap__SWIG_0")]
        public static extern void FontClient_CreateBitmap__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, bool jarg4, bool jarg5, global::System.Runtime.InteropServices.HandleRef jarg6, int jarg7);

        public static void FontClient_CreateBitmap__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, bool jarg4, bool jarg5, global::System.Runtime.InteropServices.HandleRef jarg6, int jarg7)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_CreateBitmap__SWIG_0_vulkan(jarg1, jarg2, jarg3, jarg4, jarg5, jarg6, jarg7);
            }
            else
            {
                FontClient_CreateBitmap__SWIG_0_gl(jarg1, jarg2, jarg3, jarg4, jarg5, jarg6, jarg7);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_CreateBitmap__SWIG_1")]
        public static extern global::System.IntPtr FontClient_CreateBitmap__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, int jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_CreateBitmap__SWIG_1")]
        public static extern global::System.IntPtr FontClient_CreateBitmap__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, int jarg4);

        public static global::System.IntPtr FontClient_CreateBitmap__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, int jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_CreateBitmap__SWIG_1_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                return FontClient_CreateBitmap__SWIG_1_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_CreateVectorBlob")]
        public static extern void FontClient_CreateVectorBlob_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6, global::System.Runtime.InteropServices.HandleRef jarg7);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_CreateVectorBlob")]
        public static extern void FontClient_CreateVectorBlob_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6, global::System.Runtime.InteropServices.HandleRef jarg7);

        public static void FontClient_CreateVectorBlob(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6, global::System.Runtime.InteropServices.HandleRef jarg7)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FontClient_CreateVectorBlob_vulkan(jarg1, jarg2, jarg3, jarg4, jarg5, jarg6, jarg7);
            }
            else
            {
                FontClient_CreateVectorBlob_gl(jarg1, jarg2, jarg3, jarg4, jarg5, jarg6, jarg7);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetEllipsisGlyph")]
        public static extern global::System.IntPtr FontClient_GetEllipsisGlyph_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_GetEllipsisGlyph")]
        public static extern global::System.IntPtr FontClient_GetEllipsisGlyph_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static global::System.IntPtr FontClient_GetEllipsisGlyph(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_GetEllipsisGlyph_vulkan(jarg1, jarg2);
            }
            else
            {
                return FontClient_GetEllipsisGlyph_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_IsColorGlyph")]
        public static extern bool FontClient_IsColorGlyph_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_IsColorGlyph")]
        public static extern bool FontClient_IsColorGlyph_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        public static bool FontClient_IsColorGlyph(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_IsColorGlyph_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return FontClient_IsColorGlyph_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_AddCustomFontDirectory")]
        public static extern bool FontClient_AddCustomFontDirectory_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FontClient_AddCustomFontDirectory")]
        public static extern bool FontClient_AddCustomFontDirectory_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static bool FontClient_AddCustomFontDirectory(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FontClient_AddCustomFontDirectory_vulkan(jarg1, jarg2);
            }
            else
            {
                return FontClient_AddCustomFontDirectory_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextField_Property_ENABLE_SHIFT_SELECTION_get")]
        public static extern int TextField_Property_ENABLE_SHIFT_SELECTION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextField_Property_ENABLE_SHIFT_SELECTION_get")]
        public static extern int TextField_Property_ENABLE_SHIFT_SELECTION_get_vulkan();

        public static int TextField_Property_ENABLE_SHIFT_SELECTION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextField_Property_ENABLE_SHIFT_SELECTION_get_vulkan();
            }
            else
            {
                return TextField_Property_ENABLE_SHIFT_SELECTION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_ENABLE_SHIFT_SELECTION_get")]
        public static extern int TextEditor_Property_ENABLE_SHIFT_SELECTION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_TextEditor_Property_ENABLE_SHIFT_SELECTION_get")]
        public static extern int TextEditor_Property_ENABLE_SHIFT_SELECTION_get_vulkan();

        public static int TextEditor_Property_ENABLE_SHIFT_SELECTION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return TextEditor_Property_ENABLE_SHIFT_SELECTION_get_vulkan();
            }
            else
            {
                return TextEditor_Property_ENABLE_SHIFT_SELECTION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_RELOAD_get")]
        public static extern int ImageView_IMAGE_VISUAL_ACTION_RELOAD_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_RELOAD_get")]
        public static extern int ImageView_IMAGE_VISUAL_ACTION_RELOAD_get_vulkan();

        public static int ImageView_IMAGE_VISUAL_ACTION_RELOAD_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ImageView_IMAGE_VISUAL_ACTION_RELOAD_get_vulkan();
            }
            else
            {
                return ImageView_IMAGE_VISUAL_ACTION_RELOAD_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_PLAY_get")]
        public static extern int ImageView_IMAGE_VISUAL_ACTION_PLAY_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_PLAY_get")]
        public static extern int ImageView_IMAGE_VISUAL_ACTION_PLAY_get_vulkan();

        public static int ImageView_IMAGE_VISUAL_ACTION_PLAY_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ImageView_IMAGE_VISUAL_ACTION_PLAY_get_vulkan();
            }
            else
            {
                return ImageView_IMAGE_VISUAL_ACTION_PLAY_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_PAUSE_get")]
        public static extern int ImageView_IMAGE_VISUAL_ACTION_PAUSE_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_PAUSE_get")]
        public static extern int ImageView_IMAGE_VISUAL_ACTION_PAUSE_get_vulkan();

        public static int ImageView_IMAGE_VISUAL_ACTION_PAUSE_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ImageView_IMAGE_VISUAL_ACTION_PAUSE_get_vulkan();
            }
            else
            {
                return ImageView_IMAGE_VISUAL_ACTION_PAUSE_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_STOP_get")]
        public static extern int ImageView_IMAGE_VISUAL_ACTION_STOP_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_STOP_get")]
        public static extern int ImageView_IMAGE_VISUAL_ACTION_STOP_get_vulkan();

        public static int ImageView_IMAGE_VISUAL_ACTION_STOP_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return ImageView_IMAGE_VISUAL_ACTION_STOP_get_vulkan();
            }
            else
            {
                return ImageView_IMAGE_VISUAL_ACTION_STOP_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_NUI_InternalAPIVersionCheck")]
        public static extern bool InternalAPIVersionCheck_gl(ref int ver1, ref int ver2, ref int ver3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_NUI_InternalAPIVersionCheck")]
        public static extern bool InternalAPIVersionCheck_vulkan(ref int ver1, ref int ver2, ref int ver3);

        public static bool InternalAPIVersionCheck(ref int ver1, ref int ver2, ref int ver3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return InternalAPIVersionCheck_vulkan(ref ver1, ref ver2, ref ver3);
            }
            else
            {
                return InternalAPIVersionCheck_gl(ref ver1, ref ver2, ref ver3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GetLayout__SWIG_0")]
        public static extern global::System.IntPtr GetLayout__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GetLayout__SWIG_0")]
        public static extern global::System.IntPtr GetLayout__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr GetLayout__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GetLayout__SWIG_0_vulkan(jarg1);
            }
            else
            {
                return GetLayout__SWIG_0_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GetLayout__SWIG_1")]
        public static extern global::System.IntPtr GetLayout__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GetLayout__SWIG_1")]
        public static extern global::System.IntPtr GetLayout__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr GetLayout__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GetLayout__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return GetLayout__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_SetLayout__SWIG_0")]
        public static extern void SetLayout__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_SetLayout__SWIG_0")]
        public static extern void SetLayout__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void SetLayout__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                SetLayout__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                SetLayout__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_SetLayout__SWIG_1")]
        public static extern void SetLayout__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_SetLayout__SWIG_1")]
        public static extern void SetLayout__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void SetLayout__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                SetLayout__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                SetLayout__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_Touch_GetMouseButton")]
        public static extern int Touch_GetMouseButton_gl(global::System.Runtime.InteropServices.HandleRef jarg1, ulong jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_Touch_GetMouseButton")]
        public static extern int Touch_GetMouseButton_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, ulong jarg2);

        public static int Touch_GetMouseButton(global::System.Runtime.InteropServices.HandleRef jarg1, ulong jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return Touch_GetMouseButton_vulkan(jarg1, jarg2);
            }
            else
            {
                return Touch_GetMouseButton_gl(jarg1, jarg2);
            }
        }

    }
}
