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
    class LayoutPINVOKE
    {

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutParent_GetParent")]
        public static extern global::System.IntPtr LayoutParent_GetParent_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutParent_GetParent")]
        public static extern global::System.IntPtr LayoutParent_GetParent_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutParent_GetParent(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutParent_GetParent_vulkan(jarg1);
            }
            else
            {
                return LayoutParent_GetParent_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutLength__SWIG_0")]
        public static extern global::System.IntPtr new_LayoutLength__SWIG_0_gl(int jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutLength__SWIG_0")]
        public static extern global::System.IntPtr new_LayoutLength__SWIG_0_vulkan(int jarg1);

        public static global::System.IntPtr new_LayoutLength__SWIG_0(int jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutLength__SWIG_0_vulkan(jarg1);
            }
            else
            {
                return new_LayoutLength__SWIG_0_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutLength__SWIG_1")]
        public static extern global::System.IntPtr new_LayoutLength__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutLength__SWIG_1")]
        public static extern global::System.IntPtr new_LayoutLength__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_LayoutLength__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutLength__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_LayoutLength__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Assign")]
        public static extern global::System.IntPtr LayoutLength_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Assign")]
        public static extern global::System.IntPtr LayoutLength_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LayoutLength_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_EqualTo__SWIG_0")]
        public static extern bool LayoutLength_EqualTo__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_EqualTo__SWIG_0")]
        public static extern bool LayoutLength_EqualTo__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static bool LayoutLength_EqualTo__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_EqualTo__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_EqualTo__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_EqualTo__SWIG_1")]
        public static extern bool LayoutLength_EqualTo__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_EqualTo__SWIG_1")]
        public static extern bool LayoutLength_EqualTo__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static bool LayoutLength_EqualTo__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_EqualTo__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_EqualTo__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_NotEqualTo")]
        public static extern bool LayoutLength_NotEqualTo_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_NotEqualTo")]
        public static extern bool LayoutLength_NotEqualTo_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static bool LayoutLength_NotEqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_NotEqualTo_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_NotEqualTo_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_LessThan__SWIG_0")]
        public static extern bool LayoutLength_LessThan__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_LessThan__SWIG_0")]
        public static extern bool LayoutLength_LessThan__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static bool LayoutLength_LessThan__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_LessThan__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_LessThan__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_GreaterThan__SWIG_0")]
        public static extern bool LayoutLength_GreaterThan__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_GreaterThan__SWIG_0")]
        public static extern bool LayoutLength_GreaterThan__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static bool LayoutLength_GreaterThan__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_GreaterThan__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_GreaterThan__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Add__SWIG_0")]
        public static extern global::System.IntPtr LayoutLength_Add__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Add__SWIG_0")]
        public static extern global::System.IntPtr LayoutLength_Add__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LayoutLength_Add__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_Add__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_Add__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Add__SWIG_1")]
        public static extern global::System.IntPtr LayoutLength_Add__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Add__SWIG_1")]
        public static extern global::System.IntPtr LayoutLength_Add__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static global::System.IntPtr LayoutLength_Add__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_Add__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_Add__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Subtract__SWIG_0")]
        public static extern global::System.IntPtr LayoutLength_Subtract__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Subtract__SWIG_0")]
        public static extern global::System.IntPtr LayoutLength_Subtract__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LayoutLength_Subtract__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_Subtract__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_Subtract__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Subtract__SWIG_1")]
        public static extern global::System.IntPtr LayoutLength_Subtract__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Subtract__SWIG_1")]
        public static extern global::System.IntPtr LayoutLength_Subtract__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static global::System.IntPtr LayoutLength_Subtract__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_Subtract__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_Subtract__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_AddAssign__SWIG_0")]
        public static extern global::System.IntPtr LayoutLength_AddAssign__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_AddAssign__SWIG_0")]
        public static extern global::System.IntPtr LayoutLength_AddAssign__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LayoutLength_AddAssign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_AddAssign__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_AddAssign__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_AddAssign__SWIG_1")]
        public static extern global::System.IntPtr LayoutLength_AddAssign__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_AddAssign__SWIG_1")]
        public static extern global::System.IntPtr LayoutLength_AddAssign__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static global::System.IntPtr LayoutLength_AddAssign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_AddAssign__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_AddAssign__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_SubtractAssign__SWIG_0")]
        public static extern global::System.IntPtr LayoutLength_SubtractAssign__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_SubtractAssign__SWIG_0")]
        public static extern global::System.IntPtr LayoutLength_SubtractAssign__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LayoutLength_SubtractAssign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_SubtractAssign__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_SubtractAssign__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_SubtractAssign__SWIG_1")]
        public static extern global::System.IntPtr LayoutLength_SubtractAssign__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_SubtractAssign__SWIG_1")]
        public static extern global::System.IntPtr LayoutLength_SubtractAssign__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static global::System.IntPtr LayoutLength_SubtractAssign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_SubtractAssign__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_SubtractAssign__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Divide__SWIG_0")]
        public static extern global::System.IntPtr LayoutLength_Divide__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Divide__SWIG_0")]
        public static extern global::System.IntPtr LayoutLength_Divide__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LayoutLength_Divide__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_Divide__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_Divide__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Divide__SWIG_1")]
        public static extern global::System.IntPtr LayoutLength_Divide__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Divide__SWIG_1")]
        public static extern global::System.IntPtr LayoutLength_Divide__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static global::System.IntPtr LayoutLength_Divide__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_Divide__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_Divide__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Multiply__SWIG_0")]
        public static extern global::System.IntPtr LayoutLength_Multiply__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Multiply__SWIG_0")]
        public static extern global::System.IntPtr LayoutLength_Multiply__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LayoutLength_Multiply__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_Multiply__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_Multiply__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Multiply__SWIG_1")]
        public static extern global::System.IntPtr LayoutLength_Multiply__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Multiply__SWIG_1")]
        public static extern global::System.IntPtr LayoutLength_Multiply__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static global::System.IntPtr LayoutLength_Multiply__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_Multiply__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_Multiply__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Multiply__SWIG_2")]
        public static extern global::System.IntPtr LayoutLength_Multiply__SWIG_2_gl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_Multiply__SWIG_2")]
        public static extern global::System.IntPtr LayoutLength_Multiply__SWIG_2_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        public static global::System.IntPtr LayoutLength_Multiply__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_Multiply__SWIG_2_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutLength_Multiply__SWIG_2_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_mValue_set")]
        public static extern void LayoutLength_mValue_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_mValue_set")]
        public static extern void LayoutLength_mValue_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void LayoutLength_mValue_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutLength_mValue_set_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutLength_mValue_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_mValue_get")]
        public static extern int LayoutLength_mValue_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutLength_mValue_get")]
        public static extern int LayoutLength_mValue_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int LayoutLength_mValue_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutLength_mValue_get_vulkan(jarg1);
            }
            else
            {
                return LayoutLength_mValue_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_LayoutLength")]
        public static extern void delete_LayoutLength_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_LayoutLength")]
        public static extern void delete_LayoutLength_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_LayoutLength(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_LayoutLength_vulkan(jarg1);
            }
            else
            {
                delete_LayoutLength_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutSize__SWIG_0")]
        public static extern global::System.IntPtr new_LayoutSize__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutSize__SWIG_0")]
        public static extern global::System.IntPtr new_LayoutSize__SWIG_0_vulkan();

        public static global::System.IntPtr new_LayoutSize__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutSize__SWIG_0_vulkan();
            }
            else
            {
                return new_LayoutSize__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutSize__SWIG_1")]
        public static extern global::System.IntPtr new_LayoutSize__SWIG_1_gl(int jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutSize__SWIG_1")]
        public static extern global::System.IntPtr new_LayoutSize__SWIG_1_vulkan(int jarg1, int jarg2);

        public static global::System.IntPtr new_LayoutSize__SWIG_1(int jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutSize__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                return new_LayoutSize__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutSize__SWIG_2")]
        public static extern global::System.IntPtr new_LayoutSize__SWIG_2_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutSize__SWIG_2")]
        public static extern global::System.IntPtr new_LayoutSize__SWIG_2_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_LayoutSize__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutSize__SWIG_2_vulkan(jarg1);
            }
            else
            {
                return new_LayoutSize__SWIG_2_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_Assign")]
        public static extern global::System.IntPtr LayoutSize_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_Assign")]
        public static extern global::System.IntPtr LayoutSize_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LayoutSize_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutSize_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutSize_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_GetWidth")]
        public static extern int LayoutSize_GetWidth_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_GetWidth")]
        public static extern int LayoutSize_GetWidth_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int LayoutSize_GetWidth(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutSize_GetWidth_vulkan(jarg1);
            }
            else
            {
                return LayoutSize_GetWidth_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_GetHeight")]
        public static extern int LayoutSize_GetHeight_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_GetHeight")]
        public static extern int LayoutSize_GetHeight_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int LayoutSize_GetHeight(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutSize_GetHeight_vulkan(jarg1);
            }
            else
            {
                return LayoutSize_GetHeight_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_SetWidth__SWIG_0")]
        public static extern void LayoutSize_SetWidth__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_SetWidth__SWIG_0")]
        public static extern void LayoutSize_SetWidth__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void LayoutSize_SetWidth__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutSize_SetWidth__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutSize_SetWidth__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_SetHeight__SWIG_0")]
        public static extern void LayoutSize_SetHeight__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_SetHeight__SWIG_0")]
        public static extern void LayoutSize_SetHeight__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void LayoutSize_SetHeight__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutSize_SetHeight__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutSize_SetHeight__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_SetWidth__SWIG_1")]
        public static extern void LayoutSize_SetWidth__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_SetWidth__SWIG_1")]
        public static extern void LayoutSize_SetWidth__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutSize_SetWidth__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutSize_SetWidth__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutSize_SetWidth__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_SetHeight__SWIG_1")]
        public static extern void LayoutSize_SetHeight__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_SetHeight__SWIG_1")]
        public static extern void LayoutSize_SetHeight__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutSize_SetHeight__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutSize_SetHeight__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutSize_SetHeight__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_EqualTo")]
        public static extern bool LayoutSize_EqualTo_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_EqualTo")]
        public static extern bool LayoutSize_EqualTo_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static bool LayoutSize_EqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutSize_EqualTo_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutSize_EqualTo_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_x_set")]
        public static extern void LayoutSize_x_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_x_set")]
        public static extern void LayoutSize_x_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void LayoutSize_x_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutSize_x_set_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutSize_x_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_x_get")]
        public static extern int LayoutSize_x_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_x_get")]
        public static extern int LayoutSize_x_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int LayoutSize_x_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutSize_x_get_vulkan(jarg1);
            }
            else
            {
                return LayoutSize_x_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_width_set")]
        public static extern void LayoutSize_width_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_width_set")]
        public static extern void LayoutSize_width_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void LayoutSize_width_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutSize_width_set_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutSize_width_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_width_get")]
        public static extern int LayoutSize_width_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_width_get")]
        public static extern int LayoutSize_width_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int LayoutSize_width_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutSize_width_get_vulkan(jarg1);
            }
            else
            {
                return LayoutSize_width_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_y_set")]
        public static extern void LayoutSize_y_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_y_set")]
        public static extern void LayoutSize_y_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void LayoutSize_y_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutSize_y_set_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutSize_y_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_y_get")]
        public static extern int LayoutSize_y_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_y_get")]
        public static extern int LayoutSize_y_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int LayoutSize_y_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutSize_y_get_vulkan(jarg1);
            }
            else
            {
                return LayoutSize_y_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_height_set")]
        public static extern void LayoutSize_height_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_height_set")]
        public static extern void LayoutSize_height_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void LayoutSize_height_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutSize_height_set_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutSize_height_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_height_get")]
        public static extern int LayoutSize_height_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutSize_height_get")]
        public static extern int LayoutSize_height_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int LayoutSize_height_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutSize_height_get_vulkan(jarg1);
            }
            else
            {
                return LayoutSize_height_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_LayoutSize")]
        public static extern void delete_LayoutSize_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_LayoutSize")]
        public static extern void delete_LayoutSize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_LayoutSize(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_LayoutSize_vulkan(jarg1);
            }
            else
            {
                delete_LayoutSize_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_MeasuredSize__SWIG_0")]
        public static extern global::System.IntPtr new_MeasuredSize__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_MeasuredSize__SWIG_0")]
        public static extern global::System.IntPtr new_MeasuredSize__SWIG_0_vulkan();

        public static global::System.IntPtr new_MeasuredSize__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_MeasuredSize__SWIG_0_vulkan();
            }
            else
            {
                return new_MeasuredSize__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_MeasuredSize__SWIG_1")]
        public static extern global::System.IntPtr new_MeasuredSize__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_MeasuredSize__SWIG_1")]
        public static extern global::System.IntPtr new_MeasuredSize__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_MeasuredSize__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_MeasuredSize__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_MeasuredSize__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_MeasuredSize__SWIG_2")]
        public static extern global::System.IntPtr new_MeasuredSize__SWIG_2_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_MeasuredSize__SWIG_2")]
        public static extern global::System.IntPtr new_MeasuredSize__SWIG_2_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static global::System.IntPtr new_MeasuredSize__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_MeasuredSize__SWIG_2_vulkan(jarg1, jarg2);
            }
            else
            {
                return new_MeasuredSize__SWIG_2_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_MeasuredSize")]
        public static extern void delete_MeasuredSize_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_MeasuredSize")]
        public static extern void delete_MeasuredSize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_MeasuredSize(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_MeasuredSize_vulkan(jarg1);
            }
            else
            {
                delete_MeasuredSize_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_Assign__SWIG_0")]
        public static extern global::System.IntPtr MeasuredSize_Assign__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_Assign__SWIG_0")]
        public static extern global::System.IntPtr MeasuredSize_Assign__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr MeasuredSize_Assign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MeasuredSize_Assign__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                return MeasuredSize_Assign__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_Assign__SWIG_1")]
        public static extern global::System.IntPtr MeasuredSize_Assign__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_Assign__SWIG_1")]
        public static extern global::System.IntPtr MeasuredSize_Assign__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static global::System.IntPtr MeasuredSize_Assign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MeasuredSize_Assign__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                return MeasuredSize_Assign__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_EqualTo")]
        public static extern bool MeasuredSize_EqualTo_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_EqualTo")]
        public static extern bool MeasuredSize_EqualTo_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static bool MeasuredSize_EqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MeasuredSize_EqualTo_vulkan(jarg1, jarg2);
            }
            else
            {
                return MeasuredSize_EqualTo_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_NotEqualTo")]
        public static extern bool MeasuredSize_NotEqualTo_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_NotEqualTo")]
        public static extern bool MeasuredSize_NotEqualTo_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static bool MeasuredSize_NotEqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MeasuredSize_NotEqualTo_vulkan(jarg1, jarg2);
            }
            else
            {
                return MeasuredSize_NotEqualTo_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_SetState")]
        public static extern void MeasuredSize_SetState_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_SetState")]
        public static extern void MeasuredSize_SetState_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void MeasuredSize_SetState(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                MeasuredSize_SetState_vulkan(jarg1, jarg2);
            }
            else
            {
                MeasuredSize_SetState_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_GetState")]
        public static extern int MeasuredSize_GetState_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_GetState")]
        public static extern int MeasuredSize_GetState_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int MeasuredSize_GetState(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MeasuredSize_GetState_vulkan(jarg1);
            }
            else
            {
                return MeasuredSize_GetState_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_SetSize")]
        public static extern void MeasuredSize_SetSize_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_SetSize")]
        public static extern void MeasuredSize_SetSize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void MeasuredSize_SetSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                MeasuredSize_SetSize_vulkan(jarg1, jarg2);
            }
            else
            {
                MeasuredSize_SetSize_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_GetSize")]
        public static extern global::System.IntPtr MeasuredSize_GetSize_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasuredSize_GetSize")]
        public static extern global::System.IntPtr MeasuredSize_GetSize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr MeasuredSize_GetSize(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MeasuredSize_GetSize_vulkan(jarg1);
            }
            else
            {
                return MeasuredSize_GetSize_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_MeasureSpec__SWIG_0")]
        public static extern global::System.IntPtr new_MeasureSpec__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_MeasureSpec__SWIG_0")]
        public static extern global::System.IntPtr new_MeasureSpec__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static global::System.IntPtr new_MeasureSpec__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_MeasureSpec__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                return new_MeasureSpec__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_MeasureSpec__SWIG_1")]
        public static extern global::System.IntPtr new_MeasureSpec__SWIG_1_gl(int jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_MeasureSpec__SWIG_1")]
        public static extern global::System.IntPtr new_MeasureSpec__SWIG_1_vulkan(int jarg1);

        public static global::System.IntPtr new_MeasureSpec__SWIG_1(int jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_MeasureSpec__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_MeasureSpec__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_MeasureSpec")]
        public static extern void delete_MeasureSpec_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_MeasureSpec")]
        public static extern void delete_MeasureSpec_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_MeasureSpec(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_MeasureSpec_vulkan(jarg1);
            }
            else
            {
                delete_MeasureSpec_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_Assign")]
        public static extern global::System.IntPtr MeasureSpec_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_Assign")]
        public static extern global::System.IntPtr MeasureSpec_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr MeasureSpec_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MeasureSpec_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return MeasureSpec_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_EqualTo")]
        public static extern bool MeasureSpec_EqualTo_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_EqualTo")]
        public static extern bool MeasureSpec_EqualTo_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static bool MeasureSpec_EqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MeasureSpec_EqualTo_vulkan(jarg1, jarg2);
            }
            else
            {
                return MeasureSpec_EqualTo_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_NotEqualTo")]
        public static extern bool MeasureSpec_NotEqualTo_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_NotEqualTo")]
        public static extern bool MeasureSpec_NotEqualTo_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static bool MeasureSpec_NotEqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MeasureSpec_NotEqualTo_vulkan(jarg1, jarg2);
            }
            else
            {
                return MeasureSpec_NotEqualTo_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_GetMode")]
        public static extern int MeasureSpec_GetMode_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_GetMode")]
        public static extern int MeasureSpec_GetMode_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int MeasureSpec_GetMode(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MeasureSpec_GetMode_vulkan(jarg1);
            }
            else
            {
                return MeasureSpec_GetMode_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_GetSize")]
        public static extern int MeasureSpec_GetSize_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_GetSize")]
        public static extern int MeasureSpec_GetSize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int MeasureSpec_GetSize(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MeasureSpec_GetSize_vulkan(jarg1);
            }
            else
            {
                return MeasureSpec_GetSize_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_Adjust")]
        public static extern global::System.IntPtr MeasureSpec_Adjust_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_Adjust")]
        public static extern global::System.IntPtr MeasureSpec_Adjust_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static global::System.IntPtr MeasureSpec_Adjust(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MeasureSpec_Adjust_vulkan(jarg1, jarg2);
            }
            else
            {
                return MeasureSpec_Adjust_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_mSize_set")]
        public static extern void MeasureSpec_mSize_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_mSize_set")]
        public static extern void MeasureSpec_mSize_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void MeasureSpec_mSize_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                MeasureSpec_mSize_set_vulkan(jarg1, jarg2);
            }
            else
            {
                MeasureSpec_mSize_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_mSize_get")]
        public static extern int MeasureSpec_mSize_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_mSize_get")]
        public static extern int MeasureSpec_mSize_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int MeasureSpec_mSize_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MeasureSpec_mSize_get_vulkan(jarg1);
            }
            else
            {
                return MeasureSpec_mSize_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_mMode_set")]
        public static extern void MeasureSpec_mMode_set_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_mMode_set")]
        public static extern void MeasureSpec_mMode_set_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void MeasureSpec_mMode_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                MeasureSpec_mMode_set_vulkan(jarg1, jarg2);
            }
            else
            {
                MeasureSpec_mMode_set_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_mMode_get")]
        public static extern int MeasureSpec_mMode_get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_MeasureSpec_mMode_get")]
        public static extern int MeasureSpec_mMode_get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int MeasureSpec_mMode_get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return MeasureSpec_mMode_get_vulkan(jarg1);
            }
            else
            {
                return MeasureSpec_mMode_get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_ChildProperty_WIDTH_SPECIFICATION_get")]
        public static extern int LayoutItemWrapper_ChildProperty_WIDTH_SPECIFICATION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_ChildProperty_WIDTH_SPECIFICATION_get")]
        public static extern int LayoutItemWrapper_ChildProperty_WIDTH_SPECIFICATION_get_vulkan();

        public static int LayoutItemWrapper_ChildProperty_WIDTH_SPECIFICATION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapper_ChildProperty_WIDTH_SPECIFICATION_get_vulkan();
            }
            else
            {
                return LayoutItemWrapper_ChildProperty_WIDTH_SPECIFICATION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_ChildProperty_HEIGHT_SPECIFICATION_get")]
        public static extern int LayoutItemWrapper_ChildProperty_HEIGHT_SPECIFICATION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_ChildProperty_HEIGHT_SPECIFICATION_get")]
        public static extern int LayoutItemWrapper_ChildProperty_HEIGHT_SPECIFICATION_get_vulkan();

        public static int LayoutItemWrapper_ChildProperty_HEIGHT_SPECIFICATION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapper_ChildProperty_HEIGHT_SPECIFICATION_get_vulkan();
            }
            else
            {
                return LayoutItemWrapper_ChildProperty_HEIGHT_SPECIFICATION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemWrapper_ChildProperty")]
        public static extern global::System.IntPtr new_LayoutItemWrapper_ChildProperty_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemWrapper_ChildProperty")]
        public static extern global::System.IntPtr new_LayoutItemWrapper_ChildProperty_vulkan();

        public static global::System.IntPtr new_LayoutItemWrapper_ChildProperty()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutItemWrapper_ChildProperty_vulkan();
            }
            else
            {
                return new_LayoutItemWrapper_ChildProperty_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_LayoutItemWrapper_ChildProperty")]
        public static extern void delete_LayoutItemWrapper_ChildProperty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_LayoutItemWrapper_ChildProperty")]
        public static extern void delete_LayoutItemWrapper_ChildProperty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_LayoutItemWrapper_ChildProperty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_LayoutItemWrapper_ChildProperty_vulkan(jarg1);
            }
            else
            {
                delete_LayoutItemWrapper_ChildProperty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemWrapper__SWIG_0")]
        public static extern global::System.IntPtr new_LayoutItemWrapper__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemWrapper__SWIG_0")]
        public static extern global::System.IntPtr new_LayoutItemWrapper__SWIG_0_vulkan();

        public static global::System.IntPtr new_LayoutItemWrapper__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutItemWrapper__SWIG_0_vulkan();
            }
            else
            {
                return new_LayoutItemWrapper__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_LayoutItemWrapper")]
        public static extern void delete_LayoutItemWrapper_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_LayoutItemWrapper")]
        public static extern void delete_LayoutItemWrapper_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_LayoutItemWrapper(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_LayoutItemWrapper_vulkan(jarg1);
            }
            else
            {
                delete_LayoutItemWrapper_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_New")]
        public static extern global::System.IntPtr LayoutItemWrapper_New_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_New")]
        public static extern global::System.IntPtr LayoutItemWrapper_New_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapper_New(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapper_New_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapper_New_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemWrapper__SWIG_1")]
        public static extern global::System.IntPtr new_LayoutItemWrapper__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemWrapper__SWIG_1")]
        public static extern global::System.IntPtr new_LayoutItemWrapper__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_LayoutItemWrapper__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutItemWrapper__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_LayoutItemWrapper__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_Assign")]
        public static extern global::System.IntPtr LayoutItemWrapper_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_Assign")]
        public static extern global::System.IntPtr LayoutItemWrapper_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LayoutItemWrapper_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapper_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutItemWrapper_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_GetOwner")]
        public static extern global::System.IntPtr LayoutItemWrapper_GetOwner_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_GetOwner")]
        public static extern global::System.IntPtr LayoutItemWrapper_GetOwner_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapper_GetOwner(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapper_GetOwner_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapper_GetOwner_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_SetAnimateLayout")]
        public static extern void LayoutItemWrapper_SetAnimateLayout_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_SetAnimateLayout")]
        public static extern void LayoutItemWrapper_SetAnimateLayout_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void LayoutItemWrapper_SetAnimateLayout(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapper_SetAnimateLayout_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutItemWrapper_SetAnimateLayout_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_IsLayoutAnimated")]
        public static extern bool LayoutItemWrapper_IsLayoutAnimated_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_IsLayoutAnimated")]
        public static extern bool LayoutItemWrapper_IsLayoutAnimated_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool LayoutItemWrapper_IsLayoutAnimated(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapper_IsLayoutAnimated_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapper_IsLayoutAnimated_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemWrapper__SWIG_2")]
        public static extern global::System.IntPtr new_LayoutItemWrapper__SWIG_2_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemWrapper__SWIG_2")]
        public static extern global::System.IntPtr new_LayoutItemWrapper__SWIG_2_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_LayoutItemWrapper__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutItemWrapper__SWIG_2_vulkan(jarg1);
            }
            else
            {
                return new_LayoutItemWrapper__SWIG_2_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemWrapperImpl")]
        public static extern global::System.IntPtr new_LayoutItemWrapperImpl_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemWrapperImpl")]
        public static extern global::System.IntPtr new_LayoutItemWrapperImpl_vulkan();

        public static global::System.IntPtr new_LayoutItemWrapperImpl()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutItemWrapperImpl_vulkan();
            }
            else
            {
                return new_LayoutItemWrapperImpl_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_New")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_New_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_New")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_New_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapperImpl_New(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_New_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_New_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_Initialize")]
        public static extern void LayoutItemWrapperImpl_Initialize_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_Initialize")]
        public static extern void LayoutItemWrapperImpl_Initialize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3);

        public static void LayoutItemWrapperImpl_Initialize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_Initialize_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                LayoutItemWrapperImpl_Initialize_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_GetImplementation")]
        public static extern global::System.IntPtr LayoutItemWrapper_GetImplementation_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_GetImplementation")]
        public static extern global::System.IntPtr LayoutItemWrapper_GetImplementation_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr LayoutItemWrapper_GetImplementation(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapper_GetImplementation_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapper_GetImplementation_gl(jarg1); ;
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetOwner")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetOwner_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetOwner")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetOwner_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapperImpl_GetOwner(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_GetOwner_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_GetOwner_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_Unparent")]
        public static extern void LayoutItemWrapperImpl_Unparent_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_Unparent")]
        public static extern void LayoutItemWrapperImpl_Unparent_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void LayoutItemWrapperImpl_Unparent(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_Unparent_vulkan(jarg1);
            }
            else
            {
                LayoutItemWrapperImpl_Unparent_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_SetAnimateLayout")]
        public static extern void LayoutItemWrapperImpl_SetAnimateLayout_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_SetAnimateLayout")]
        public static extern void LayoutItemWrapperImpl_SetAnimateLayout_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void LayoutItemWrapperImpl_SetAnimateLayout(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_SetAnimateLayout_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutItemWrapperImpl_SetAnimateLayout_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_IsLayoutAnimated")]
        public static extern bool LayoutItemWrapperImpl_IsLayoutAnimated_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_IsLayoutAnimated")]
        public static extern bool LayoutItemWrapperImpl_IsLayoutAnimated_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool LayoutItemWrapperImpl_IsLayoutAnimated(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_IsLayoutAnimated_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_IsLayoutAnimated_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_Measure")]
        public static extern void LayoutItemWrapperImpl_Measure_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_Measure")]
        public static extern void LayoutItemWrapperImpl_Measure_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void LayoutItemWrapperImpl_Measure(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_Measure_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                LayoutItemWrapperImpl_Measure_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_Layout")]
        public static extern void LayoutItemWrapperImpl_Layout_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_Layout")]
        public static extern void LayoutItemWrapperImpl_Layout_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

        public static void LayoutItemWrapperImpl_Layout(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_Layout_vulkan(jarg1, jarg2, jarg3, jarg4, jarg5);
            }
            else
            {
                LayoutItemWrapperImpl_Layout_gl(jarg1, jarg2, jarg3, jarg4, jarg5);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetDefaultSize")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetDefaultSize_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetDefaultSize")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetDefaultSize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LayoutItemWrapperImpl_GetDefaultSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_GetDefaultSize_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutItemWrapperImpl_GetDefaultSize_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetParent")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetParent_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetParent")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetParent_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapperImpl_GetParent(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_GetParent_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_GetParent_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetParentSwigExplicitLayoutItemWrapperImpl")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetParentSwigExplicitLayoutItemWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetParentSwigExplicitLayoutItemWrapperImpl")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetParentSwigExplicitLayoutItemWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapperImpl_GetParentSwigExplicitLayoutItemWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_GetParentSwigExplicitLayoutItemWrapperImpl_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_GetParentSwigExplicitLayoutItemWrapperImpl_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_RequestLayout")]
        public static extern void LayoutItemWrapperImpl_RequestLayout_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_RequestLayout")]
        public static extern void LayoutItemWrapperImpl_RequestLayout_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void LayoutItemWrapperImpl_RequestLayout(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_RequestLayout_vulkan(jarg1);
            }
            else
            {
                LayoutItemWrapperImpl_RequestLayout_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_IsLayoutRequested")]
        public static extern bool LayoutItemWrapperImpl_IsLayoutRequested_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_IsLayoutRequested")]
        public static extern bool LayoutItemWrapperImpl_IsLayoutRequested_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool LayoutItemWrapperImpl_IsLayoutRequested(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_IsLayoutRequested_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_IsLayoutRequested_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetMeasuredWidth")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetMeasuredWidth_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetMeasuredWidth")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetMeasuredWidth_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapperImpl_GetMeasuredWidth(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_GetMeasuredWidth_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_GetMeasuredWidth_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetMeasuredHeight")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetMeasuredHeight_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetMeasuredHeight")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetMeasuredHeight_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapperImpl_GetMeasuredHeight(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_GetMeasuredHeight_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_GetMeasuredHeight_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetMeasuredWidthAndState")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetMeasuredWidthAndState_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetMeasuredWidthAndState")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetMeasuredWidthAndState_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapperImpl_GetMeasuredWidthAndState(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_GetMeasuredWidthAndState_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_GetMeasuredWidthAndState_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetMeasuredHeightAndState")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetMeasuredHeightAndState_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetMeasuredHeightAndState")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetMeasuredHeightAndState_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapperImpl_GetMeasuredHeightAndState(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_GetMeasuredHeightAndState_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_GetMeasuredHeightAndState_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetSuggestedMinimumWidth")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetSuggestedMinimumWidth_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetSuggestedMinimumWidth")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetSuggestedMinimumWidth_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapperImpl_GetSuggestedMinimumWidth(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_GetSuggestedMinimumWidth_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_GetSuggestedMinimumWidth_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetSuggestedMinimumHeight")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetSuggestedMinimumHeight_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetSuggestedMinimumHeight")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetSuggestedMinimumHeight_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapperImpl_GetSuggestedMinimumHeight(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_GetSuggestedMinimumHeight_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_GetSuggestedMinimumHeight_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_SetMinimumWidth")]
        public static extern void LayoutItemWrapperImpl_SetMinimumWidth_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_SetMinimumWidth")]
        public static extern void LayoutItemWrapperImpl_SetMinimumWidth_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutItemWrapperImpl_SetMinimumWidth(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_SetMinimumWidth_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutItemWrapperImpl_SetMinimumWidth_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_SetMinimumHeight")]
        public static extern void LayoutItemWrapperImpl_SetMinimumHeight_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_SetMinimumHeight")]
        public static extern void LayoutItemWrapperImpl_SetMinimumHeight_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutItemWrapperImpl_SetMinimumHeight(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_SetMinimumHeight_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutItemWrapperImpl_SetMinimumHeight_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetMinimumWidth")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetMinimumWidth_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetMinimumWidth")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetMinimumWidth_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapperImpl_GetMinimumWidth(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_GetMinimumWidth_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_GetMinimumWidth_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetMinimumHeight")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetMinimumHeight_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetMinimumHeight")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetMinimumHeight_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapperImpl_GetMinimumHeight(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_GetMinimumHeight_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_GetMinimumHeight_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetPadding")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetPadding_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_GetPadding")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_GetPadding_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemWrapperImpl_GetPadding(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_GetPadding_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_GetPadding_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_SetMeasuredDimensions")]
        public static extern void LayoutItemWrapperImpl_SetMeasuredDimensions_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_SetMeasuredDimensions")]
        public static extern void LayoutItemWrapperImpl_SetMeasuredDimensions_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void LayoutItemWrapperImpl_SetMeasuredDimensions(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_SetMeasuredDimensions_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                LayoutItemWrapperImpl_SetMeasuredDimensions_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnUnparent")]
        public static extern void LayoutItemWrapperImpl_OnUnparent_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnUnparent")]
        public static extern void LayoutItemWrapperImpl_OnUnparent_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void LayoutItemWrapperImpl_OnUnparent(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_OnUnparent_vulkan(jarg1);
            }
            else
            {
                LayoutItemWrapperImpl_OnUnparent_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnUnparentSwigExplicitLayoutItemWrapperImpl")]
        public static extern void LayoutItemWrapperImpl_OnUnparentSwigExplicitLayoutItemWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnUnparentSwigExplicitLayoutItemWrapperImpl")]
        public static extern void LayoutItemWrapperImpl_OnUnparentSwigExplicitLayoutItemWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void LayoutItemWrapperImpl_OnUnparentSwigExplicitLayoutItemWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_OnUnparentSwigExplicitLayoutItemWrapperImpl_vulkan(jarg1);
            }
            else
            {
                LayoutItemWrapperImpl_OnUnparentSwigExplicitLayoutItemWrapperImpl_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnRegisterChildProperties")]
        public static extern void LayoutItemWrapperImpl_OnRegisterChildProperties_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnRegisterChildProperties")]
        public static extern void LayoutItemWrapperImpl_OnRegisterChildProperties_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static void LayoutItemWrapperImpl_OnRegisterChildProperties(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_OnRegisterChildProperties_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutItemWrapperImpl_OnRegisterChildProperties_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnRegisterChildPropertiesSwigExplicitLayoutItemWrapperImpl")]
        public static extern void LayoutItemWrapperImpl_OnRegisterChildPropertiesSwigExplicitLayoutItemWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnRegisterChildPropertiesSwigExplicitLayoutItemWrapperImpl")]
        public static extern void LayoutItemWrapperImpl_OnRegisterChildPropertiesSwigExplicitLayoutItemWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static void LayoutItemWrapperImpl_OnRegisterChildPropertiesSwigExplicitLayoutItemWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_OnRegisterChildPropertiesSwigExplicitLayoutItemWrapperImpl_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutItemWrapperImpl_OnRegisterChildPropertiesSwigExplicitLayoutItemWrapperImpl_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnMeasure")]
        public static extern void LayoutItemWrapperImpl_OnMeasure_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnMeasure")]
        public static extern void LayoutItemWrapperImpl_OnMeasure_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void LayoutItemWrapperImpl_OnMeasure(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_OnMeasure_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                LayoutItemWrapperImpl_OnMeasure_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnMeasureSwigExplicitLayoutItemWrapperImpl")]
        public static extern void LayoutItemWrapperImpl_OnMeasureSwigExplicitLayoutItemWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnMeasureSwigExplicitLayoutItemWrapperImpl")]
        public static extern void LayoutItemWrapperImpl_OnMeasureSwigExplicitLayoutItemWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void LayoutItemWrapperImpl_OnMeasureSwigExplicitLayoutItemWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_OnMeasureSwigExplicitLayoutItemWrapperImpl_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                LayoutItemWrapperImpl_OnMeasureSwigExplicitLayoutItemWrapperImpl_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnLayout")]
        public static extern void LayoutItemWrapperImpl_OnLayout_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnLayout")]
        public static extern void LayoutItemWrapperImpl_OnLayout_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

        public static void LayoutItemWrapperImpl_OnLayout(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_OnLayout_vulkan(jarg1, jarg2, jarg3, jarg4, jarg5, jarg6);
            }
            else
            {
                LayoutItemWrapperImpl_OnLayout_gl(jarg1, jarg2, jarg3, jarg4, jarg5, jarg6);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnLayoutSwigExplicitLayoutItemWrapperImpl")]
        public static extern void LayoutItemWrapperImpl_OnLayoutSwigExplicitLayoutItemWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnLayoutSwigExplicitLayoutItemWrapperImpl")]
        public static extern void LayoutItemWrapperImpl_OnLayoutSwigExplicitLayoutItemWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

        public static void LayoutItemWrapperImpl_OnLayoutSwigExplicitLayoutItemWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_OnLayoutSwigExplicitLayoutItemWrapperImpl_vulkan(jarg1, jarg2, jarg3, jarg4, jarg5, jarg6);
            }
            else
            {
                LayoutItemWrapperImpl_OnLayoutSwigExplicitLayoutItemWrapperImpl_gl(jarg1, jarg2, jarg3, jarg4, jarg5, jarg6);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnSizeChanged")]
        public static extern void LayoutItemWrapperImpl_OnSizeChanged_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnSizeChanged")]
        public static extern void LayoutItemWrapperImpl_OnSizeChanged_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void LayoutItemWrapperImpl_OnSizeChanged(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_OnSizeChanged_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                LayoutItemWrapperImpl_OnSizeChanged_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnSizeChangedSwigExplicitLayoutItemWrapperImpl")]
        public static extern void LayoutItemWrapperImpl_OnSizeChangedSwigExplicitLayoutItemWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnSizeChangedSwigExplicitLayoutItemWrapperImpl")]
        public static extern void LayoutItemWrapperImpl_OnSizeChangedSwigExplicitLayoutItemWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void LayoutItemWrapperImpl_OnSizeChangedSwigExplicitLayoutItemWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_OnSizeChangedSwigExplicitLayoutItemWrapperImpl_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                LayoutItemWrapperImpl_OnSizeChangedSwigExplicitLayoutItemWrapperImpl_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnInitialize")]
        public static extern void LayoutItemWrapperImpl_OnInitialize_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnInitialize")]
        public static extern void LayoutItemWrapperImpl_OnInitialize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void LayoutItemWrapperImpl_OnInitialize(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_OnInitialize_vulkan(jarg1);
            }
            else
            {
                LayoutItemWrapperImpl_OnInitialize_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnInitializeSwigExplicitLayoutItemWrapperImpl")]
        public static extern void LayoutItemWrapperImpl_OnInitializeSwigExplicitLayoutItemWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_OnInitializeSwigExplicitLayoutItemWrapperImpl")]
        public static extern void LayoutItemWrapperImpl_OnInitializeSwigExplicitLayoutItemWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void LayoutItemWrapperImpl_OnInitializeSwigExplicitLayoutItemWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_OnInitializeSwigExplicitLayoutItemWrapperImpl_vulkan(jarg1);
            }
            else
            {
                LayoutItemWrapperImpl_OnInitializeSwigExplicitLayoutItemWrapperImpl_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_director_connect")]
        public static extern void LayoutItemWrapperImpl_director_connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_0 delegate0, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_1 delegate1, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_2 delegate2, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_3 delegate3, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_4 delegate4, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_5 delegate5, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_6 delegate6);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_director_connect")]
        public static extern void LayoutItemWrapperImpl_director_connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_0 delegate0, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_1 delegate1, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_2 delegate2, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_3 delegate3, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_4 delegate4, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_5 delegate5, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_6 delegate6);

        public static void LayoutItemWrapperImpl_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_0 delegate0, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_1 delegate1, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_2 delegate2, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_3 delegate3, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_4 delegate4, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_5 delegate5, LayoutItemWrapperImpl.SwigDelegateLayoutItemWrapperImpl_6 delegate6)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemWrapperImpl_director_connect_vulkan(jarg1, delegate0, delegate1, delegate2, delegate3, delegate4, delegate5, delegate6);
            }
            else
            {
                LayoutItemWrapperImpl_director_connect_gl(jarg1, delegate0, delegate1, delegate2, delegate3, delegate4, delegate5, delegate6);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GetImplementation__SWIG_0")]
        public static extern global::System.IntPtr GetImplementation__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GetImplementation__SWIG_0")]
        public static extern global::System.IntPtr GetImplementation__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr GetImplementation__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GetImplementation__SWIG_0_vulkan(jarg1);
            }
            else
            {
                return GetImplementation__SWIG_0_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_UNKNOWN_ID_get")]
        public static extern uint LayoutGroupWrapper_UNKNOWN_ID_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_UNKNOWN_ID_get")]
        public static extern uint LayoutGroupWrapper_UNKNOWN_ID_get_vulkan();

        public static uint LayoutGroupWrapper_UNKNOWN_ID_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapper_UNKNOWN_ID_get_vulkan();
            }
            else
            {
                return LayoutGroupWrapper_UNKNOWN_ID_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_ChildProperty_MARGIN_SPECIFICATION_get")]
        public static extern int LayoutGroupWrapper_ChildProperty_MARGIN_SPECIFICATION_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_ChildProperty_MARGIN_SPECIFICATION_get")]
        public static extern int LayoutGroupWrapper_ChildProperty_MARGIN_SPECIFICATION_get_vulkan();

        public static int LayoutGroupWrapper_ChildProperty_MARGIN_SPECIFICATION_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapper_ChildProperty_MARGIN_SPECIFICATION_get_vulkan();
            }
            else
            {
                return LayoutGroupWrapper_ChildProperty_MARGIN_SPECIFICATION_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutGroupWrapper_ChildProperty")]
        public static extern global::System.IntPtr new_LayoutGroupWrapper_ChildProperty_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutGroupWrapper_ChildProperty")]
        public static extern global::System.IntPtr new_LayoutGroupWrapper_ChildProperty_vulkan();

        public static global::System.IntPtr new_LayoutGroupWrapper_ChildProperty()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutGroupWrapper_ChildProperty_vulkan();
            }
            else
            {
                return new_LayoutGroupWrapper_ChildProperty_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_LayoutGroupWrapper_ChildProperty")]
        public static extern void delete_LayoutGroupWrapper_ChildProperty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_LayoutGroupWrapper_ChildProperty")]
        public static extern void delete_LayoutGroupWrapper_ChildProperty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_LayoutGroupWrapper_ChildProperty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_LayoutGroupWrapper_ChildProperty_vulkan(jarg1);
            }
            else
            {
                delete_LayoutGroupWrapper_ChildProperty_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutGroupWrapper__SWIG_0")]
        public static extern global::System.IntPtr new_LayoutGroupWrapper__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutGroupWrapper__SWIG_0")]
        public static extern global::System.IntPtr new_LayoutGroupWrapper__SWIG_0_vulkan();

        public static global::System.IntPtr new_LayoutGroupWrapper__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutGroupWrapper__SWIG_0_vulkan();
            }
            else
            {
                return new_LayoutGroupWrapper__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_LayoutGroupWrapper")]
        public static extern void delete_LayoutGroupWrapper_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_LayoutGroupWrapper")]
        public static extern void delete_LayoutGroupWrapper_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_LayoutGroupWrapper(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_LayoutGroupWrapper_vulkan(jarg1);
            }
            else
            {
                delete_LayoutGroupWrapper_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutGroupWrapper__SWIG_1")]
        public static extern global::System.IntPtr new_LayoutGroupWrapper__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutGroupWrapper__SWIG_1")]
        public static extern global::System.IntPtr new_LayoutGroupWrapper__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_LayoutGroupWrapper__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutGroupWrapper__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_LayoutGroupWrapper__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_Assign")]
        public static extern global::System.IntPtr LayoutGroupWrapper_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_Assign")]
        public static extern global::System.IntPtr LayoutGroupWrapper_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LayoutGroupWrapper_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapper_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutGroupWrapper_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_DownCast")]
        public static extern global::System.IntPtr LayoutGroupWrapper_DownCast_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_DownCast")]
        public static extern global::System.IntPtr LayoutGroupWrapper_DownCast_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutGroupWrapper_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapper_DownCast_vulkan(jarg1);
            }
            else
            {
                return LayoutGroupWrapper_DownCast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_Add")]
        public static extern uint LayoutGroupWrapper_Add_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_Add")]
        public static extern uint LayoutGroupWrapper_Add_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static uint LayoutGroupWrapper_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapper_Add_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutGroupWrapper_Add_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_Remove__SWIG_0")]
        public static extern void LayoutGroupWrapper_Remove__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_Remove__SWIG_0")]
        public static extern void LayoutGroupWrapper_Remove__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static void LayoutGroupWrapper_Remove__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapper_Remove__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutGroupWrapper_Remove__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_Remove__SWIG_1")]
        public static extern void LayoutGroupWrapper_Remove__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_Remove__SWIG_1")]
        public static extern void LayoutGroupWrapper_Remove__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutGroupWrapper_Remove__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapper_Remove__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutGroupWrapper_Remove__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_GetChildAt")]
        public static extern global::System.IntPtr LayoutGroupWrapper_GetChildAt_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_GetChildAt")]
        public static extern global::System.IntPtr LayoutGroupWrapper_GetChildAt_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static global::System.IntPtr LayoutGroupWrapper_GetChildAt(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapper_GetChildAt_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutGroupWrapper_GetChildAt_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_GetChildCount")]
        public static extern uint LayoutGroupWrapper_GetChildCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_GetChildCount")]
        public static extern uint LayoutGroupWrapper_GetChildCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint LayoutGroupWrapper_GetChildCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapper_GetChildCount_vulkan(jarg1);
            }
            else
            {
                return LayoutGroupWrapper_GetChildCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_GetChild")]
        public static extern global::System.IntPtr LayoutGroupWrapper_GetChild_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_GetChild")]
        public static extern global::System.IntPtr LayoutGroupWrapper_GetChild_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static global::System.IntPtr LayoutGroupWrapper_GetChild(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapper_GetChild_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutGroupWrapper_GetChild_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutGroupWrapper__SWIG_2")]
        public static extern global::System.IntPtr new_LayoutGroupWrapper__SWIG_2_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutGroupWrapper__SWIG_2")]
        public static extern global::System.IntPtr new_LayoutGroupWrapper__SWIG_2_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_LayoutGroupWrapper__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutGroupWrapper__SWIG_2_vulkan(jarg1);
            }
            else
            {
                return new_LayoutGroupWrapper__SWIG_2_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_Add")]
        public static extern uint LayoutGroupWrapperImpl_Add_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_Add")]
        public static extern uint LayoutGroupWrapperImpl_Add_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static uint LayoutGroupWrapperImpl_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapperImpl_Add_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutGroupWrapperImpl_Add_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_Remove__SWIG_0")]
        public static extern void LayoutGroupWrapperImpl_Remove__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_Remove__SWIG_0")]
        public static extern void LayoutGroupWrapperImpl_Remove__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static void LayoutGroupWrapperImpl_Remove__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_Remove__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutGroupWrapperImpl_Remove__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_Remove__SWIG_1")]
        public static extern void LayoutGroupWrapperImpl_Remove__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_Remove__SWIG_1")]
        public static extern void LayoutGroupWrapperImpl_Remove__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutGroupWrapperImpl_Remove__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_Remove__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutGroupWrapperImpl_Remove__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_RemoveAll")]
        public static extern void LayoutGroupWrapperImpl_RemoveAll_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_RemoveAll")]
        public static extern void LayoutGroupWrapperImpl_RemoveAll_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void LayoutGroupWrapperImpl_RemoveAll(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_RemoveAll_vulkan(jarg1);
            }
            else
            {
                LayoutGroupWrapperImpl_RemoveAll_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_GetChildCount")]
        public static extern uint LayoutGroupWrapperImpl_GetChildCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_GetChildCount")]
        public static extern uint LayoutGroupWrapperImpl_GetChildCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint LayoutGroupWrapperImpl_GetChildCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapperImpl_GetChildCount_vulkan(jarg1);
            }
            else
            {
                return LayoutGroupWrapperImpl_GetChildCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_GetChildAt")]
        public static extern global::System.IntPtr LayoutGroupWrapperImpl_GetChildAt_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_GetChildAt")]
        public static extern global::System.IntPtr LayoutGroupWrapperImpl_GetChildAt_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static global::System.IntPtr LayoutGroupWrapperImpl_GetChildAt(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapperImpl_GetChildAt_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutGroupWrapperImpl_GetChildAt_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_GetChildId")]
        public static extern uint LayoutGroupWrapperImpl_GetChildId_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_GetChildId")]
        public static extern uint LayoutGroupWrapperImpl_GetChildId_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static uint LayoutGroupWrapperImpl_GetChildId(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapperImpl_GetChildId_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutGroupWrapperImpl_GetChildId_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_GetChild")]
        public static extern global::System.IntPtr LayoutGroupWrapperImpl_GetChild_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_GetChild")]
        public static extern global::System.IntPtr LayoutGroupWrapperImpl_GetChild_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static global::System.IntPtr LayoutGroupWrapperImpl_GetChild(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapperImpl_GetChild_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutGroupWrapperImpl_GetChild_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_OnChildAdd")]
        public static extern void LayoutGroupWrapperImpl_OnChildAdd_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_OnChildAdd")]
        public static extern void LayoutGroupWrapperImpl_OnChildAdd_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutGroupWrapperImpl_OnChildAdd(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_OnChildAdd_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutGroupWrapperImpl_OnChildAdd_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_OnChildAddSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_OnChildAddSwigExplicitLayoutGroupWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_OnChildAddSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_OnChildAddSwigExplicitLayoutGroupWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutGroupWrapperImpl_OnChildAddSwigExplicitLayoutGroupWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_OnChildAddSwigExplicitLayoutGroupWrapperImpl_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutGroupWrapperImpl_OnChildAddSwigExplicitLayoutGroupWrapperImpl_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_OnChildRemove")]
        public static extern void LayoutGroupWrapperImpl_OnChildRemove_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_OnChildRemove")]
        public static extern void LayoutGroupWrapperImpl_OnChildRemove_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutGroupWrapperImpl_OnChildRemove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_OnChildRemove_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutGroupWrapperImpl_OnChildRemove_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_OnChildRemoveSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_OnChildRemoveSwigExplicitLayoutGroupWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_OnChildRemoveSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_OnChildRemoveSwigExplicitLayoutGroupWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutGroupWrapperImpl_OnChildRemoveSwigExplicitLayoutGroupWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_OnChildRemoveSwigExplicitLayoutGroupWrapperImpl_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutGroupWrapperImpl_OnChildRemoveSwigExplicitLayoutGroupWrapperImpl_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_GetChildMeasureSpec")]
        public static extern global::System.IntPtr LayoutGroupWrapperImpl_GetChildMeasureSpec_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_GetChildMeasureSpec")]
        public static extern global::System.IntPtr LayoutGroupWrapperImpl_GetChildMeasureSpec_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static global::System.IntPtr LayoutGroupWrapperImpl_GetChildMeasureSpec(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapperImpl_GetChildMeasureSpec_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return LayoutGroupWrapperImpl_GetChildMeasureSpec_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_DoInitialize")]
        public static extern void LayoutGroupWrapperImpl_DoInitialize_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_DoInitialize")]
        public static extern void LayoutGroupWrapperImpl_DoInitialize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void LayoutGroupWrapperImpl_DoInitialize(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_DoInitialize_vulkan(jarg1);
            }
            else
            {
                LayoutGroupWrapperImpl_DoInitialize_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_DoInitializeSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_DoInitializeSwigExplicitLayoutGroupWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_DoInitializeSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_DoInitializeSwigExplicitLayoutGroupWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void LayoutGroupWrapperImpl_DoInitializeSwigExplicitLayoutGroupWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_DoInitializeSwigExplicitLayoutGroupWrapperImpl_vulkan(jarg1);
            }
            else
            {
                LayoutGroupWrapperImpl_DoInitializeSwigExplicitLayoutGroupWrapperImpl_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_DoRegisterChildProperties")]
        public static extern void LayoutGroupWrapperImpl_DoRegisterChildProperties_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_DoRegisterChildProperties")]
        public static extern void LayoutGroupWrapperImpl_DoRegisterChildProperties_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static void LayoutGroupWrapperImpl_DoRegisterChildProperties(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_DoRegisterChildProperties_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutGroupWrapperImpl_DoRegisterChildProperties_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_DoRegisterChildPropertiesSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_DoRegisterChildPropertiesSwigExplicitLayoutGroupWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_DoRegisterChildPropertiesSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_DoRegisterChildPropertiesSwigExplicitLayoutGroupWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        public static void LayoutGroupWrapperImpl_DoRegisterChildPropertiesSwigExplicitLayoutGroupWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_DoRegisterChildPropertiesSwigExplicitLayoutGroupWrapperImpl_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutGroupWrapperImpl_DoRegisterChildPropertiesSwigExplicitLayoutGroupWrapperImpl_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValues")]
        public static extern void LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValues_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValues")]
        public static extern void LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValues_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValues(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValues_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValues_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValuesSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValuesSwigExplicitLayoutGroupWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValuesSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValuesSwigExplicitLayoutGroupWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValuesSwigExplicitLayoutGroupWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValuesSwigExplicitLayoutGroupWrapperImpl_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValuesSwigExplicitLayoutGroupWrapperImpl_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_MeasureChildren")]
        public static extern void LayoutGroupWrapperImpl_MeasureChildren_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_MeasureChildren")]
        public static extern void LayoutGroupWrapperImpl_MeasureChildren_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void LayoutGroupWrapperImpl_MeasureChildren(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_MeasureChildren_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                LayoutGroupWrapperImpl_MeasureChildren_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_MeasureChildrenSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_MeasureChildrenSwigExplicitLayoutGroupWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_MeasureChildrenSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_MeasureChildrenSwigExplicitLayoutGroupWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void LayoutGroupWrapperImpl_MeasureChildrenSwigExplicitLayoutGroupWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_MeasureChildrenSwigExplicitLayoutGroupWrapperImpl_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                LayoutGroupWrapperImpl_MeasureChildrenSwigExplicitLayoutGroupWrapperImpl_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_MeasureChild")]
        public static extern void LayoutGroupWrapperImpl_MeasureChild_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_MeasureChild")]
        public static extern void LayoutGroupWrapperImpl_MeasureChild_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

        public static void LayoutGroupWrapperImpl_MeasureChild(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_MeasureChild_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                LayoutGroupWrapperImpl_MeasureChild_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_MeasureChildSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_MeasureChildSwigExplicitLayoutGroupWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_MeasureChildSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_MeasureChildSwigExplicitLayoutGroupWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

        public static void LayoutGroupWrapperImpl_MeasureChildSwigExplicitLayoutGroupWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_MeasureChildSwigExplicitLayoutGroupWrapperImpl_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                LayoutGroupWrapperImpl_MeasureChildSwigExplicitLayoutGroupWrapperImpl_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_MeasureChildWithMargins")]
        public static extern void LayoutGroupWrapperImpl_MeasureChildWithMargins_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_MeasureChildWithMargins")]
        public static extern void LayoutGroupWrapperImpl_MeasureChildWithMargins_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

        public static void LayoutGroupWrapperImpl_MeasureChildWithMargins(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_MeasureChildWithMargins_vulkan(jarg1, jarg2, jarg3, jarg4, jarg5, jarg6);
            }
            else
            {
                LayoutGroupWrapperImpl_MeasureChildWithMargins_gl(jarg1, jarg2, jarg3, jarg4, jarg5, jarg6);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_MeasureChildWithMarginsSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_MeasureChildWithMarginsSwigExplicitLayoutGroupWrapperImpl_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_MeasureChildWithMarginsSwigExplicitLayoutGroupWrapperImpl")]
        public static extern void LayoutGroupWrapperImpl_MeasureChildWithMarginsSwigExplicitLayoutGroupWrapperImpl_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

        public static void LayoutGroupWrapperImpl_MeasureChildWithMarginsSwigExplicitLayoutGroupWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_MeasureChildWithMarginsSwigExplicitLayoutGroupWrapperImpl_vulkan(jarg1, jarg2, jarg3, jarg4, jarg5, jarg6);
            }
            else
            {
                LayoutGroupWrapperImpl_MeasureChildWithMarginsSwigExplicitLayoutGroupWrapperImpl_gl(jarg1, jarg2, jarg3, jarg4, jarg5, jarg6);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_director_connect")]
        public static extern void LayoutGroupWrapperImpl_director_connect_gl(global::System.Runtime.InteropServices.HandleRef jarg1, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_0 delegate0, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_3 delegate3, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_4 delegate4, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_5 delegate5, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_6 delegate6, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_7 delegate7, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_8 delegate8, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_9 delegate9, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_10 delegate10, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_11 delegate11, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_12 delegate12, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_13 delegate13, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_14 delegate14);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_director_connect")]
        public static extern void LayoutGroupWrapperImpl_director_connect_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_0 delegate0, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_3 delegate3, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_4 delegate4, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_5 delegate5, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_6 delegate6, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_7 delegate7, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_8 delegate8, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_9 delegate9, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_10 delegate10, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_11 delegate11, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_12 delegate12, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_13 delegate13, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_14 delegate14);

        public static void LayoutGroupWrapperImpl_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_0 delegate0, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_3 delegate3, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_4 delegate4, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_5 delegate5, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_6 delegate6, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_7 delegate7, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_8 delegate8, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_9 delegate9, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_10 delegate10, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_11 delegate11, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_12 delegate12, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_13 delegate13, LayoutGroupWrapperImpl.SwigDelegateLayoutGroupWrapperImpl_14 delegate14)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutGroupWrapperImpl_director_connect_vulkan(jarg1, delegate0, delegate3, delegate4, delegate5, delegate6, delegate7, delegate8, delegate9, delegate10, delegate11, delegate12, delegate13, delegate14);
            }
            else
            {
                LayoutGroupWrapperImpl_director_connect_gl(jarg1, delegate0, delegate3, delegate4, delegate5, delegate6, delegate7, delegate8, delegate9, delegate10, delegate11, delegate12, delegate13, delegate14);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_GetImplementation__SWIG_2")]
        public static extern global::System.IntPtr GetImplementation__SWIG_2_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_GetImplementation__SWIG_2")]
        public static extern global::System.IntPtr GetImplementation__SWIG_2_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr GetImplementation__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GetImplementation__SWIG_2_vulkan(jarg1);
            }
            else
            {
                return GetImplementation__SWIG_2_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_SWIGUpcast")]
        public static extern global::System.IntPtr LayoutItemWrapper_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapper_SWIGUpcast")]
        public static extern global::System.IntPtr LayoutItemWrapper_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr LayoutItemWrapper_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapper_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapper_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_SWIGUpcast")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemWrapperImpl_SWIGUpcast")]
        public static extern global::System.IntPtr LayoutItemWrapperImpl_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr LayoutItemWrapperImpl_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemWrapperImpl_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return LayoutItemWrapperImpl_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_SWIGUpcast")]
        public static extern global::System.IntPtr LayoutGroupWrapper_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapper_SWIGUpcast")]
        public static extern global::System.IntPtr LayoutGroupWrapper_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr LayoutGroupWrapper_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapper_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return LayoutGroupWrapper_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_SWIGUpcast")]
        public static extern global::System.IntPtr LayoutGroupWrapperImpl_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutGroupWrapperImpl_SWIGUpcast")]
        public static extern global::System.IntPtr LayoutGroupWrapperImpl_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr LayoutGroupWrapperImpl_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutGroupWrapperImpl_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return LayoutGroupWrapperImpl_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutGroupWrapperImpl")]
        public static extern global::System.IntPtr new_LayoutGroupWrapperImpl_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutGroupWrapperImpl")]
        public static extern global::System.IntPtr new_LayoutGroupWrapperImpl_vulkan();

        public static global::System.IntPtr new_LayoutGroupWrapperImpl()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutGroupWrapperImpl_vulkan();
            }
            else
            {
                return new_LayoutGroupWrapperImpl_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemPtr__SWIG_0")]
        public static extern global::System.IntPtr new_LayoutItemPtr__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemPtr__SWIG_0")]
        public static extern global::System.IntPtr new_LayoutItemPtr__SWIG_0_vulkan();

        public static global::System.IntPtr new_LayoutItemPtr__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutItemPtr__SWIG_0_vulkan();
            }
            else
            {
                return new_LayoutItemPtr__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemPtr__SWIG_1")]
        public static extern global::System.IntPtr new_LayoutItemPtr__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemPtr__SWIG_1")]
        public static extern global::System.IntPtr new_LayoutItemPtr__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_LayoutItemPtr__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutItemPtr__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_LayoutItemPtr__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemPtr__SWIG_2")]
        public static extern global::System.IntPtr new_LayoutItemPtr__SWIG_2_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LayoutItemPtr__SWIG_2")]
        public static extern global::System.IntPtr new_LayoutItemPtr__SWIG_2_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_LayoutItemPtr__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LayoutItemPtr__SWIG_2_vulkan(jarg1);
            }
            else
            {
                return new_LayoutItemPtr__SWIG_2_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_LayoutItemPtr")]
        public static extern void delete_LayoutItemPtr_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_LayoutItemPtr")]
        public static extern void delete_LayoutItemPtr_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_LayoutItemPtr(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_LayoutItemPtr_vulkan(jarg1);
            }
            else
            {
                delete_LayoutItemPtr_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Get")]
        public static extern global::System.IntPtr LayoutItemPtr_Get_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Get")]
        public static extern global::System.IntPtr LayoutItemPtr_Get_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemPtr_Get(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_Get_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_Get_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr___deref__")]
        public static extern global::System.IntPtr LayoutItemPtr___deref___gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr___deref__")]
        public static extern global::System.IntPtr LayoutItemPtr___deref___vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemPtr___deref__(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr___deref___vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr___deref___gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr___ref__")]
        public static extern global::System.IntPtr LayoutItemPtr___ref___gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr___ref__")]
        public static extern global::System.IntPtr LayoutItemPtr___ref___vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemPtr___ref__(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr___ref___vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr___ref___gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Assign__SWIG_0")]
        public static extern global::System.IntPtr LayoutItemPtr_Assign__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Assign__SWIG_0")]
        public static extern global::System.IntPtr LayoutItemPtr_Assign__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LayoutItemPtr_Assign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_Assign__SWIG_0_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutItemPtr_Assign__SWIG_0_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Assign__SWIG_1")]
        public static extern global::System.IntPtr LayoutItemPtr_Assign__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Assign__SWIG_1")]
        public static extern global::System.IntPtr LayoutItemPtr_Assign__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LayoutItemPtr_Assign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_Assign__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutItemPtr_Assign__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Reset__SWIG_0")]
        public static extern void LayoutItemPtr_Reset__SWIG_0_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Reset__SWIG_0")]
        public static extern void LayoutItemPtr_Reset__SWIG_0_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void LayoutItemPtr_Reset__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemPtr_Reset__SWIG_0_vulkan(jarg1);
            }
            else
            {
                LayoutItemPtr_Reset__SWIG_0_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Reset__SWIG_1")]
        public static extern void LayoutItemPtr_Reset__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Reset__SWIG_1")]
        public static extern void LayoutItemPtr_Reset__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutItemPtr_Reset__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemPtr_Reset__SWIG_1_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutItemPtr_Reset__SWIG_1_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Detach")]
        public static extern global::System.IntPtr LayoutItemPtr_Detach_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Detach")]
        public static extern global::System.IntPtr LayoutItemPtr_Detach_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemPtr_Detach(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_Detach_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_Detach_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_New")]
        public static extern global::System.IntPtr LayoutItemPtr_New_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_New")]
        public static extern global::System.IntPtr LayoutItemPtr_New_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LayoutItemPtr_New(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_New_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutItemPtr_New_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Initialize")]
        public static extern void LayoutItemPtr_Initialize_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Initialize")]
        public static extern void LayoutItemPtr_Initialize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3);

        public static void LayoutItemPtr_Initialize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemPtr_Initialize_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                LayoutItemPtr_Initialize_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Unparent")]
        public static extern void LayoutItemPtr_Unparent_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Unparent")]
        public static extern void LayoutItemPtr_Unparent_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void LayoutItemPtr_Unparent(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemPtr_Unparent_vulkan(jarg1);
            }
            else
            {
                LayoutItemPtr_Unparent_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_SetAnimateLayout")]
        public static extern void LayoutItemPtr_SetAnimateLayout_gl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_SetAnimateLayout")]
        public static extern void LayoutItemPtr_SetAnimateLayout_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        public static void LayoutItemPtr_SetAnimateLayout(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemPtr_SetAnimateLayout_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutItemPtr_SetAnimateLayout_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_IsLayoutAnimated")]
        public static extern bool LayoutItemPtr_IsLayoutAnimated_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_IsLayoutAnimated")]
        public static extern bool LayoutItemPtr_IsLayoutAnimated_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool LayoutItemPtr_IsLayoutAnimated(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_IsLayoutAnimated_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_IsLayoutAnimated_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Measure")]
        public static extern void LayoutItemPtr_Measure_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Measure")]
        public static extern void LayoutItemPtr_Measure_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void LayoutItemPtr_Measure(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemPtr_Measure_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                LayoutItemPtr_Measure_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Layout")]
        public static extern void LayoutItemPtr_Layout_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Layout")]
        public static extern void LayoutItemPtr_Layout_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

        public static void LayoutItemPtr_Layout(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemPtr_Layout_vulkan(jarg1, jarg2, jarg3, jarg4, jarg5);
            }
            else
            {
                LayoutItemPtr_Layout_gl(jarg1, jarg2, jarg3, jarg4, jarg5);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetDefaultSize")]
        public static extern global::System.IntPtr LayoutItemPtr_GetDefaultSize_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetDefaultSize")]
        public static extern global::System.IntPtr LayoutItemPtr_GetDefaultSize_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static global::System.IntPtr LayoutItemPtr_GetDefaultSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_GetDefaultSize_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return LayoutItemPtr_GetDefaultSize_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetParent")]
        public static extern global::System.IntPtr LayoutItemPtr_GetParent_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetParent")]
        public static extern global::System.IntPtr LayoutItemPtr_GetParent_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemPtr_GetParent(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_GetParent_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_GetParent_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_RequestLayout")]
        public static extern void LayoutItemPtr_RequestLayout_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_RequestLayout")]
        public static extern void LayoutItemPtr_RequestLayout_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void LayoutItemPtr_RequestLayout(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemPtr_RequestLayout_vulkan(jarg1);
            }
            else
            {
                LayoutItemPtr_RequestLayout_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_IsLayoutRequested")]
        public static extern bool LayoutItemPtr_IsLayoutRequested_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_IsLayoutRequested")]
        public static extern bool LayoutItemPtr_IsLayoutRequested_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static bool LayoutItemPtr_IsLayoutRequested(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_IsLayoutRequested_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_IsLayoutRequested_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetMeasuredWidth")]
        public static extern global::System.IntPtr LayoutItemPtr_GetMeasuredWidth_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetMeasuredWidth")]
        public static extern global::System.IntPtr LayoutItemPtr_GetMeasuredWidth_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemPtr_GetMeasuredWidth(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_GetMeasuredWidth_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_GetMeasuredWidth_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetMeasuredHeight")]
        public static extern global::System.IntPtr LayoutItemPtr_GetMeasuredHeight_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetMeasuredHeight")]
        public static extern global::System.IntPtr LayoutItemPtr_GetMeasuredHeight_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemPtr_GetMeasuredHeight(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_GetMeasuredHeight_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_GetMeasuredHeight_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetMeasuredWidthAndState")]
        public static extern global::System.IntPtr LayoutItemPtr_GetMeasuredWidthAndState_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetMeasuredWidthAndState")]
        public static extern global::System.IntPtr LayoutItemPtr_GetMeasuredWidthAndState_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemPtr_GetMeasuredWidthAndState(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_GetMeasuredWidthAndState_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_GetMeasuredWidthAndState_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetMeasuredHeightAndState")]
        public static extern global::System.IntPtr LayoutItemPtr_GetMeasuredHeightAndState_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetMeasuredHeightAndState")]
        public static extern global::System.IntPtr LayoutItemPtr_GetMeasuredHeightAndState_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemPtr_GetMeasuredHeightAndState(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_GetMeasuredHeightAndState_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_GetMeasuredHeightAndState_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetSuggestedMinimumWidth")]
        public static extern global::System.IntPtr LayoutItemPtr_GetSuggestedMinimumWidth_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetSuggestedMinimumWidth")]
        public static extern global::System.IntPtr LayoutItemPtr_GetSuggestedMinimumWidth_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemPtr_GetSuggestedMinimumWidth(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_GetSuggestedMinimumWidth_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_GetSuggestedMinimumWidth_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetSuggestedMinimumHeight")]
        public static extern global::System.IntPtr LayoutItemPtr_GetSuggestedMinimumHeight_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetSuggestedMinimumHeight")]
        public static extern global::System.IntPtr LayoutItemPtr_GetSuggestedMinimumHeight_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemPtr_GetSuggestedMinimumHeight(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_GetSuggestedMinimumHeight_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_GetSuggestedMinimumHeight_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_SetMinimumWidth")]
        public static extern void LayoutItemPtr_SetMinimumWidth_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_SetMinimumWidth")]
        public static extern void LayoutItemPtr_SetMinimumWidth_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutItemPtr_SetMinimumWidth(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemPtr_SetMinimumWidth_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutItemPtr_SetMinimumWidth_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_SetMinimumHeight")]
        public static extern void LayoutItemPtr_SetMinimumHeight_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_SetMinimumHeight")]
        public static extern void LayoutItemPtr_SetMinimumHeight_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LayoutItemPtr_SetMinimumHeight(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemPtr_SetMinimumHeight_vulkan(jarg1, jarg2);
            }
            else
            {
                LayoutItemPtr_SetMinimumHeight_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetMinimumWidth")]
        public static extern global::System.IntPtr LayoutItemPtr_GetMinimumWidth_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetMinimumWidth")]
        public static extern global::System.IntPtr LayoutItemPtr_GetMinimumWidth_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemPtr_GetMinimumWidth(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_GetMinimumWidth_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_GetMinimumWidth_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetMinimumHeight")]
        public static extern global::System.IntPtr LayoutItemPtr_GetMinimumHeight_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetMinimumHeight")]
        public static extern global::System.IntPtr LayoutItemPtr_GetMinimumHeight_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemPtr_GetMinimumHeight(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_GetMinimumHeight_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_GetMinimumHeight_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetPadding")]
        public static extern global::System.IntPtr LayoutItemPtr_GetPadding_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetPadding")]
        public static extern global::System.IntPtr LayoutItemPtr_GetPadding_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LayoutItemPtr_GetPadding(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_GetPadding_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_GetPadding_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_SetMeasuredDimensions")]
        public static extern void LayoutItemPtr_SetMeasuredDimensions_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_SetMeasuredDimensions")]
        public static extern void LayoutItemPtr_SetMeasuredDimensions_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static void LayoutItemPtr_SetMeasuredDimensions(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemPtr_SetMeasuredDimensions_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                LayoutItemPtr_SetMeasuredDimensions_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_DoAction")]
        public static extern bool LayoutItemPtr_DoAction_gl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_DoAction")]
        public static extern bool LayoutItemPtr_DoAction_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        public static bool LayoutItemPtr_DoAction(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_DoAction_vulkan(jarg1, jarg2, jarg3);
            }
            else
            {
                return LayoutItemPtr_DoAction_gl(jarg1, jarg2, jarg3);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetTypeName")]
        public static extern string LayoutItemPtr_GetTypeName_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetTypeName")]
        public static extern string LayoutItemPtr_GetTypeName_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static string LayoutItemPtr_GetTypeName(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_GetTypeName_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_GetTypeName_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetTypeInfo")]
        public static extern bool LayoutItemPtr_GetTypeInfo_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_GetTypeInfo")]
        public static extern bool LayoutItemPtr_GetTypeInfo_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static bool LayoutItemPtr_GetTypeInfo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_GetTypeInfo_vulkan(jarg1, jarg2);
            }
            else
            {
                return LayoutItemPtr_GetTypeInfo_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_DoConnectSignal")]
        public static extern bool LayoutItemPtr_DoConnectSignal_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_DoConnectSignal")]
        public static extern bool LayoutItemPtr_DoConnectSignal_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

        public static bool LayoutItemPtr_DoConnectSignal(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, global::System.Runtime.InteropServices.HandleRef jarg4)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_DoConnectSignal_vulkan(jarg1, jarg2, jarg3, jarg4);
            }
            else
            {
                return LayoutItemPtr_DoConnectSignal_gl(jarg1, jarg2, jarg3, jarg4);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Reference")]
        public static extern void LayoutItemPtr_Reference_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Reference")]
        public static extern void LayoutItemPtr_Reference_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void LayoutItemPtr_Reference(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemPtr_Reference_vulkan(jarg1);
            }
            else
            {
                LayoutItemPtr_Reference_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Unreference")]
        public static extern void LayoutItemPtr_Unreference_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_Unreference")]
        public static extern void LayoutItemPtr_Unreference_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void LayoutItemPtr_Unreference(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LayoutItemPtr_Unreference_vulkan(jarg1);
            }
            else
            {
                LayoutItemPtr_Unreference_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_ReferenceCount")]
        public static extern int LayoutItemPtr_ReferenceCount_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LayoutItemPtr_ReferenceCount")]
        public static extern int LayoutItemPtr_ReferenceCount_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int LayoutItemPtr_ReferenceCount(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LayoutItemPtr_ReferenceCount_vulkan(jarg1);
            }
            else
            {
                return LayoutItemPtr_ReferenceCount_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_AbsoluteLayout_SWIGUpcast")]
        public static extern global::System.IntPtr AbsoluteLayout_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_AbsoluteLayout_SWIGUpcast")]
        public static extern global::System.IntPtr AbsoluteLayout_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr AbsoluteLayout_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return AbsoluteLayout_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return AbsoluteLayout_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_AbsoluteLayout__SWIG_0")]
        public static extern global::System.IntPtr new_AbsoluteLayout__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_AbsoluteLayout__SWIG_0")]
        public static extern global::System.IntPtr new_AbsoluteLayout__SWIG_0_vulkan();

        public static global::System.IntPtr new_AbsoluteLayout__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_AbsoluteLayout__SWIG_0_vulkan();
            }
            else
            {
                return new_AbsoluteLayout__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_AbsoluteLayout_New")]
        public static extern global::System.IntPtr AbsoluteLayout_New_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_AbsoluteLayout_New")]
        public static extern global::System.IntPtr AbsoluteLayout_New_vulkan();

        public static global::System.IntPtr AbsoluteLayout_New()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return AbsoluteLayout_New_vulkan();
            }
            else
            {
                return AbsoluteLayout_New_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_AbsoluteLayout_DownCast")]
        public static extern global::System.IntPtr AbsoluteLayout_DownCast_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_AbsoluteLayout_DownCast")]
        public static extern global::System.IntPtr AbsoluteLayout_DownCast_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr AbsoluteLayout_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return AbsoluteLayout_DownCast_vulkan(jarg1);
            }
            else
            {
                return AbsoluteLayout_DownCast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_AbsoluteLayout__SWIG_1")]
        public static extern global::System.IntPtr new_AbsoluteLayout__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_AbsoluteLayout__SWIG_1")]
        public static extern global::System.IntPtr new_AbsoluteLayout__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_AbsoluteLayout__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_AbsoluteLayout__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_AbsoluteLayout__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_AbsoluteLayout_Assign")]
        public static extern global::System.IntPtr AbsoluteLayout_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_AbsoluteLayout_Assign")]
        public static extern global::System.IntPtr AbsoluteLayout_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr AbsoluteLayout_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return AbsoluteLayout_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return AbsoluteLayout_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_AbsoluteLayout")]
        public static extern void delete_AbsoluteLayout_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_AbsoluteLayout")]
        public static extern void delete_AbsoluteLayout_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_AbsoluteLayout(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_AbsoluteLayout_vulkan(jarg1);
            }
            else
            {
                delete_AbsoluteLayout_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_SWIGUpcast")]
        public static extern global::System.IntPtr FlexLayout_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_SWIGUpcast")]
        public static extern global::System.IntPtr FlexLayout_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr FlexLayout_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FlexLayout_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return FlexLayout_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_ChildProperty_FLEX_get")]
        public static extern int FlexLayout_ChildProperty_FLEX_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_ChildProperty_FLEX_get")]
        public static extern int FlexLayout_ChildProperty_FLEX_get_vulkan();

        public static int FlexLayout_ChildProperty_FLEX_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FlexLayout_ChildProperty_FLEX_get_vulkan();
            }
            else
            {
                return FlexLayout_ChildProperty_FLEX_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_ChildProperty_ALIGN_SELF_get")]
        public static extern int FlexLayout_ChildProperty_ALIGN_SELF_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_ChildProperty_ALIGN_SELF_get")]
        public static extern int FlexLayout_ChildProperty_ALIGN_SELF_get_vulkan();

        public static int FlexLayout_ChildProperty_ALIGN_SELF_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FlexLayout_ChildProperty_ALIGN_SELF_get_vulkan();
            }
            else
            {
                return FlexLayout_ChildProperty_ALIGN_SELF_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_FlexLayout__SWIG_0")]
        public static extern global::System.IntPtr new_FlexLayout__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_FlexLayout__SWIG_0")]
        public static extern global::System.IntPtr new_FlexLayout__SWIG_0_vulkan();

        public static global::System.IntPtr new_FlexLayout__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_FlexLayout__SWIG_0_vulkan();
            }
            else
            {
                return new_FlexLayout__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_New")]
        public static extern global::System.IntPtr FlexLayout_New_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_New")]
        public static extern global::System.IntPtr FlexLayout_New_vulkan();

        public static global::System.IntPtr FlexLayout_New()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FlexLayout_New_vulkan();
            }
            else
            {
                return FlexLayout_New_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_DownCast")]
        public static extern global::System.IntPtr FlexLayout_DownCast_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_DownCast")]
        public static extern global::System.IntPtr FlexLayout_DownCast_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr FlexLayout_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FlexLayout_DownCast_vulkan(jarg1);
            }
            else
            {
                return FlexLayout_DownCast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_FlexLayout__SWIG_1")]
        public static extern global::System.IntPtr new_FlexLayout__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_FlexLayout__SWIG_1")]
        public static extern global::System.IntPtr new_FlexLayout__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_FlexLayout__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_FlexLayout__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_FlexLayout__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_Assign")]
        public static extern global::System.IntPtr FlexLayout_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_Assign")]
        public static extern global::System.IntPtr FlexLayout_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr FlexLayout_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FlexLayout_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return FlexLayout_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_FlexLayout")]
        public static extern void delete_FlexLayout_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_FlexLayout")]
        public static extern void delete_FlexLayout_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_FlexLayout(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_FlexLayout_vulkan(jarg1);
            }
            else
            {
                delete_FlexLayout_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexDirection")]
        public static extern void FlexLayout_SetFlexDirection_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexDirection")]
        public static extern void FlexLayout_SetFlexDirection_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void FlexLayout_SetFlexDirection(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FlexLayout_SetFlexDirection_vulkan(jarg1, jarg2);
            }
            else
            {
                FlexLayout_SetFlexDirection_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexDirection")]
        public static extern int FlexLayout_GetFlexDirection_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexDirection")]
        public static extern int FlexLayout_GetFlexDirection_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int FlexLayout_GetFlexDirection(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FlexLayout_GetFlexDirection_vulkan(jarg1);
            }
            else
            {
                return FlexLayout_GetFlexDirection_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexJustification")]
        public static extern void FlexLayout_SetFlexJustification_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexJustification")]
        public static extern void FlexLayout_SetFlexJustification_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void FlexLayout_SetFlexJustification(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FlexLayout_SetFlexJustification_vulkan(jarg1, jarg2);
            }
            else
            {
                FlexLayout_SetFlexJustification_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexJustification")]
        public static extern int FlexLayout_GetFlexJustification_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexJustification")]
        public static extern int FlexLayout_GetFlexJustification_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int FlexLayout_GetFlexJustification(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FlexLayout_GetFlexJustification_vulkan(jarg1);
            }
            else
            {
                return FlexLayout_GetFlexJustification_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexWrap")]
        public static extern void FlexLayout_SetFlexWrap_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexWrap")]
        public static extern void FlexLayout_SetFlexWrap_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void FlexLayout_SetFlexWrap(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FlexLayout_SetFlexWrap_vulkan(jarg1, jarg2);
            }
            else
            {
                FlexLayout_SetFlexWrap_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexWrap")]
        public static extern int FlexLayout_GetFlexWrap_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexWrap")]
        public static extern int FlexLayout_GetFlexWrap_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int FlexLayout_GetFlexWrap(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FlexLayout_GetFlexWrap_vulkan(jarg1);
            }
            else
            {
                return FlexLayout_GetFlexWrap_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexAlignment")]
        public static extern void FlexLayout_SetFlexAlignment_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexAlignment")]
        public static extern void FlexLayout_SetFlexAlignment_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void FlexLayout_SetFlexAlignment(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FlexLayout_SetFlexAlignment_vulkan(jarg1, jarg2);
            }
            else
            {
                FlexLayout_SetFlexAlignment_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexAlignment")]
        public static extern int FlexLayout_GetFlexAlignment_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexAlignment")]
        public static extern int FlexLayout_GetFlexAlignment_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int FlexLayout_GetFlexAlignment(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FlexLayout_GetFlexAlignment_vulkan(jarg1);
            }
            else
            {
                return FlexLayout_GetFlexAlignment_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexItemsAlignment")]
        public static extern void FlexLayout_SetFlexItemsAlignment_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexItemsAlignment")]
        public static extern void FlexLayout_SetFlexItemsAlignment_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void FlexLayout_SetFlexItemsAlignment(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                FlexLayout_SetFlexItemsAlignment_vulkan(jarg1, jarg2);
            }
            else
            {
                FlexLayout_SetFlexItemsAlignment_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexItemsAlignment")]
        public static extern int FlexLayout_GetFlexItemsAlignment_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexItemsAlignment")]
        public static extern int FlexLayout_GetFlexItemsAlignment_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int FlexLayout_GetFlexItemsAlignment(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return FlexLayout_GetFlexItemsAlignment_vulkan(jarg1);
            }
            else
            {
                return FlexLayout_GetFlexItemsAlignment_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_SWIGUpcast")]
        public static extern global::System.IntPtr LinearLayout_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_SWIGUpcast")]
        public static extern global::System.IntPtr LinearLayout_SWIGUpcast_vulkan(global::System.IntPtr jarg1);

        public static global::System.IntPtr LinearLayout_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LinearLayout_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return LinearLayout_SWIGUpcast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LinearLayout__SWIG_0")]
        public static extern global::System.IntPtr new_LinearLayout__SWIG_0_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LinearLayout__SWIG_0")]
        public static extern global::System.IntPtr new_LinearLayout__SWIG_0_vulkan();

        public static global::System.IntPtr new_LinearLayout__SWIG_0()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LinearLayout__SWIG_0_vulkan();
            }
            else
            {
                return new_LinearLayout__SWIG_0_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_New")]
        public static extern global::System.IntPtr LinearLayout_New_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_New")]
        public static extern global::System.IntPtr LinearLayout_New_vulkan();

        public static global::System.IntPtr LinearLayout_New()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LinearLayout_New_vulkan();
            }
            else
            {
                return LinearLayout_New_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_DownCast")]
        public static extern global::System.IntPtr LinearLayout_DownCast_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_DownCast")]
        public static extern global::System.IntPtr LinearLayout_DownCast_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LinearLayout_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LinearLayout_DownCast_vulkan(jarg1);
            }
            else
            {
                return LinearLayout_DownCast_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LinearLayout__SWIG_1")]
        public static extern global::System.IntPtr new_LinearLayout__SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LinearLayout__SWIG_1")]
        public static extern global::System.IntPtr new_LinearLayout__SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_LinearLayout__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LinearLayout__SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_LinearLayout__SWIG_1_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_Assign")]
        public static extern global::System.IntPtr LinearLayout_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_Assign")]
        public static extern global::System.IntPtr LinearLayout_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr LinearLayout_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LinearLayout_Assign_vulkan(jarg1, jarg2);
            }
            else
            {
                return LinearLayout_Assign_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_LinearLayout")]
        public static extern void delete_LinearLayout_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_LinearLayout")]
        public static extern void delete_LinearLayout_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_LinearLayout(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_LinearLayout_vulkan(jarg1);
            }
            else
            {
                delete_LinearLayout_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_SetCellPadding")]
        public static extern void LinearLayout_SetCellPadding_gl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_SetCellPadding")]
        public static extern void LinearLayout_SetCellPadding_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        public static void LinearLayout_SetCellPadding(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LinearLayout_SetCellPadding_vulkan(jarg1, jarg2);
            }
            else
            {
                LinearLayout_SetCellPadding_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_GetCellPadding")]
        public static extern global::System.IntPtr LinearLayout_GetCellPadding_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_GetCellPadding")]
        public static extern global::System.IntPtr LinearLayout_GetCellPadding_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr LinearLayout_GetCellPadding(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LinearLayout_GetCellPadding_vulkan(jarg1);
            }
            else
            {
                return LinearLayout_GetCellPadding_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_SetOrientation")]
        public static extern void LinearLayout_SetOrientation_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_SetOrientation")]
        public static extern void LinearLayout_SetOrientation_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void LinearLayout_SetOrientation(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LinearLayout_SetOrientation_vulkan(jarg1, jarg2);
            }
            else
            {
                LinearLayout_SetOrientation_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_GetOrientation")]
        public static extern int LinearLayout_GetOrientation_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_GetOrientation")]
        public static extern int LinearLayout_GetOrientation_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int LinearLayout_GetOrientation(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LinearLayout_GetOrientation_vulkan(jarg1);
            }
            else
            {
                return LinearLayout_GetOrientation_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_SetAlignment")]
        public static extern void LinearLayout_SetAlignment_gl(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_SetAlignment")]
        public static extern void LinearLayout_SetAlignment_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        public static void LinearLayout_SetAlignment(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                LinearLayout_SetAlignment_vulkan(jarg1, jarg2);
            }
            else
            {
                LinearLayout_SetAlignment_gl(jarg1, jarg2);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_GetAlignment")]
        public static extern uint LinearLayout_GetAlignment_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_GetAlignment")]
        public static extern uint LinearLayout_GetAlignment_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static uint LinearLayout_GetAlignment(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LinearLayout_GetAlignment_vulkan(jarg1);
            }
            else
            {
                return LinearLayout_GetAlignment_gl(jarg1);
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_ChildProperty_WEIGHT_get")]
        public static extern int LinearLayout_ChildProperty_WEIGHT_get_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_LinearLayout_ChildProperty_WEIGHT_get")]
        public static extern int LinearLayout_ChildProperty_WEIGHT_get_vulkan();

        public static int LinearLayout_ChildProperty_WEIGHT_get()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return LinearLayout_ChildProperty_WEIGHT_get_vulkan();
            }
            else
            {
                return LinearLayout_ChildProperty_WEIGHT_get_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_new_LinearLayout_ChildProperty")]
        public static extern global::System.IntPtr new_LinearLayout_ChildProperty_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_new_LinearLayout_ChildProperty")]
        public static extern global::System.IntPtr new_LinearLayout_ChildProperty_vulkan();

        public static global::System.IntPtr new_LinearLayout_ChildProperty()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_LinearLayout_ChildProperty_vulkan();
            }
            else
            {
                return new_LinearLayout_ChildProperty_gl();
            }
        }

        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder, EntryPoint = "CSharp_Dali_delete_LinearLayout_ChildProperty")]
        public static extern void delete_LinearLayout_ChildProperty_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder, EntryPoint = "CSharp_Dali_delete_LinearLayout_ChildProperty")]
        public static extern void delete_LinearLayout_ChildProperty_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_LinearLayout_ChildProperty(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_LinearLayout_ChildProperty_vulkan(jarg1);
            }
            else
            {
                delete_LinearLayout_ChildProperty_gl(jarg1);
            }
        }

        // Grid Layout

        // GridLayout_SWIGUpcast
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder,
                                                          EntryPoint="CSharp_Dali_GridLayout_SWIGUpcast")]
        public static extern global::System.IntPtr GridLayout_SWIGUpcast_gl(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder,
                                                          EntryPoint="CSharp_Dali_GridLayoutt_SWIGUpcast")]

        public static extern global::System.IntPtr GridLayout_SWIGUpcast_vulkan(global::System.IntPtr jarg1);


        public static global::System.IntPtr GridLayout_SWIGUpcast(global::System.IntPtr jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GridLayout_SWIGUpcast_vulkan(jarg1);
            }
            else
            {
                return GridLayout_SWIGUpcast_gl(jarg1);
            }
        }

        // GridLayout_New
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder,
                                                          EntryPoint="CSharp_Dali_GridLayout_New")]
        public static extern global::System.IntPtr GridLayout_New_gl();

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder,
                                                          EntryPoint="CSharp_Dali_GridLayout_New")]
        public static extern global::System.IntPtr GridLayout_New_vulkan();

        public static global::System.IntPtr GridLayout_New()
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GridLayout_New_vulkan();
            }
            else
            {
                return GridLayout_New_gl();
            }
        }

        // delete_GridLayout
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder,
                                                          EntryPoint="CSharp_Dali_GridLayout_delete")]
        public static extern void delete_GridLayout_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder,
                                                          EntryPoint="CSharp_Dali_GridLayout_delete")]
        public static extern void delete_GridLayout_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static void delete_GridLayout(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                delete_GridLayout_vulkan(jarg1);
            }
            else
            {
                delete_GridLayout_gl(jarg1);
            }
        }

        // GridLayout_Downcast
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder,
                                                          EntryPoint="CSharp_Dali_GridLayout_DownCast")]
        public static extern global::System.IntPtr GridLayout_DownCast_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder,
                                                          EntryPoint="CSharp_Dali_GridLayout_DownCast")]
        public static extern global::System.IntPtr GridLayout_DownCast_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr GridLayout_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GridLayout_DownCast_vulkan(jarg1);
            }
            else
            {
                return GridLayout_DownCast_gl(jarg1);
            }
        }

        // new_GridLayout_SWIG_1
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder,
                                                          EntryPoint="CSharp_Dali_new_GridLayout_SWIG_1")]
        public static extern global::System.IntPtr new_GridLayout_SWIG_1_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder,
                                                          EntryPoint="CSharp_Dali_new_GridLayout_SWIG_1")]
        public static extern global::System.IntPtr new_GridLayout_SWIG_1_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static global::System.IntPtr new_GridLayout_SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return new_GridLayout_SWIG_1_vulkan(jarg1);
            }
            else
            {
                return new_GridLayout_SWIG_1_gl(jarg1);
            }
        }

        // GridLayout_Assign
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder,
                                                          EntryPoint="CSharp_Dali_GridLayout_GridLayout_Assign")]
        public static extern global::System.IntPtr GridLayout_Assign_gl(global::System.Runtime.InteropServices.HandleRef jarg1,
                                                                        global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder,
                                                          EntryPoint="CSharp_Dali_GridLayout_GridLayout_Assign")]
        public static extern global::System.IntPtr GridLayout_Assign_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1,
                                                                            global::System.Runtime.InteropServices.HandleRef jarg2);

        public static global::System.IntPtr GridLayout_Assign(global::System.Runtime.InteropServices.HandleRef jarg1,
                                                              global::System.Runtime.InteropServices.HandleRef jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GridLayout_Assign_vulkan(jarg1,jarg2);
            }
            else
            {
                return GridLayout_Assign_gl(jarg1,jarg2);
            }
        }

        // GridLayout_SetColumns
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder,
                                                          EntryPoint="CSharp_Dali_GridLayout_SetColumns")]
        public static extern void GridLayout_SetColumns_gl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder,
                                                          EntryPoint="CSharp_Dali_GridLayout_SetColumns")]
        public static extern void GridLayout_SetColumns_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        public static void GridLayout_SetColumns(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                GridLayout_SetColumns_vulkan( jarg1, jarg2);
            }
            else
            {
                GridLayout_SetColumns_gl(jarg1, jarg2);
            }
        }

        // GridLayout_GetColumns
        [global::System.Runtime.InteropServices.DllImport(Graphics.GlesCSharpBinder,
                                                          EntryPoint="CSharp_Dali_GridLayout__GetColumns")]
        public static extern int GridLayout_GetColumns_gl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(Graphics.VulkanCSharpBinder,
                                                          EntryPoint="CSharp_Dali_GridLayout_GetColumns")]
        public static extern int GridLayout_GetColumns_vulkan(global::System.Runtime.InteropServices.HandleRef jarg1);

        public static int GridLayout_GetColumns(global::System.Runtime.InteropServices.HandleRef jarg1)
        {
            if (Tizen.NUI.Graphics.Backend == Tizen.NUI.Graphics.BackendType.Vulkan)
            {
                return GridLayout_GetColumns_vulkan(jarg1);
            }
            else
            {
                return GridLayout_GetColumns_gl(jarg1);
            }
        }
    }
}
