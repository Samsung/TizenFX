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
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ComponentApplication
        {
    		
    		[global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ComponentApplication")]
    		public static extern global::System.IntPtr ComponentApplication_New(int argc, string argv, string styleSheet);
    		
    		[global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ComponentApplication_SWIG1")]
    		public static extern global::System.IntPtr new_ComponentApplication__SWIG_1(global::System.Runtime.InteropServices.HandleRef swigCPtr);
			
    		[global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_assign_ComponentApplication")]
    		public static extern global::System.IntPtr ComponentApplication_Assign(global::System.Runtime.InteropServices.HandleRef swigCPtr, global::System.Runtime.InteropServices.HandleRef swigCPtr2);
    		
    		[global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ComponentApplication")]
    		public static extern global::System.IntPtr delete_ComponentApplication(global::System.Runtime.InteropServices.HandleRef swigCPtr);

    		[global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ComponentApplication_CreateNativeSignal")]
    		public static extern global::System.IntPtr ComponentApplication_CreateNativeSignal(global::System.Runtime.InteropServices.HandleRef swigCPtr);

    		[global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ComponentApplication_CreateNativeSignal_Connect")]
    		public static extern global::System.IntPtr ComponentApplication_CreateNativeSignal_Connect(global::System.Runtime.InteropServices.HandleRef swigCPtr, global::System.Runtime.InteropServices.HandleRef func);

    		[global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ComponentApplication_CreateNativeSignal_Disconnect")]
    		public static extern global::System.IntPtr ComponentApplication_CreateNativeSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef swigCPtr, global::System.Runtime.InteropServices.HandleRef func);				
        }
    }
}
