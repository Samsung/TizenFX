﻿/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;
using Tizen.MachineLearning.Inference;

internal static partial class Interop
{
    internal static partial class Libraries
    {
        public const string Nnstreamer = "libcapi-nnstreamer.so.0";
    }

    internal static partial class SingleShot
    {
        /* int ml_single_open (ml_single_h *single, const char *model, const ml_tensors_info_h input_info, const ml_tensors_info_h output_info, ml_nnfw_type_e nnfw, ml_nnfw_hw_e hw) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_single_open", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError OpenSingle(out IntPtr single_handle, string model_path, IntPtr input_info, IntPtr output_info, NNFWType nn_type, HWType hw_type);

        /* int ml_single_close (ml_single_h single) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_single_close", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError CloseSingle(IntPtr single_handle);

        /* int ml_single_invoke (ml_single_h single, const ml_tensors_data_h input, ml_tensors_data_h *output) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_single_invoke", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError InvokeSingle(IntPtr single_handle, IntPtr input_data, out IntPtr output_data);

        /* int ml_single_get_input_info (ml_single_h single, ml_tensors_info_h *info) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_single_invoke", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetInputTensorsInfoFromSingle(IntPtr single_handle, out IntPtr input_info);

        /* int ml_single_get_output_info (ml_single_h single, ml_tensors_info_h *info) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_single_get_output_info", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetOutputTensorsInfoFromSingle(IntPtr single_handle, out IntPtr output_info);
    }

    internal static partial class Util
    {
        /* int ml_tensors_info_create (ml_tensors_info_h *info) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_create", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError CreateTensorsInfo(out IntPtr info);
            
        /* int ml_tensors_info_destroy (ml_tensors_info_h info) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError DestroyTensorsInfo(IntPtr info);

        /* int ml_tensors_info_validate (const ml_tensors_info_h info, bool *valid) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_validate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError ValidateTensorsInfo(IntPtr info, out bool valid);

        /* int ml_tensors_info_clone (ml_tensors_info_h dest, const ml_tensors_info_h src) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_clone", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError CloneTensorsInfo(out IntPtr dest_info, IntPtr src_info);

        /* int ml_tensors_info_set_count (ml_tensors_info_h info, unsigned int count) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_set_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError SetTensorsCount(IntPtr info, int count);

        /* int ml_tensors_info_get_count (ml_tensors_info_h info, unsigned int *count) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_get_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetTensorsCount(IntPtr info, out int count);

        /* int ml_tensors_info_set_tensor_name (ml_tensors_info_h info, unsigned int index, const char *name) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_set_tensor_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError SetTensorName(IntPtr info, int index, string name);

        /* int ml_tensors_info_get_tensor_name (ml_tensors_info_h info, unsigned int index, char **name) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_get_tensor_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetTensorName(IntPtr info, int index, out string name);

        /* int ml_tensors_info_set_tensor_type (ml_tensors_info_h info, unsigned int index, const ml_tensor_type_e type) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_set_tensor_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError SetTensorType(IntPtr info, int index, TensorType type);

        /* int ml_tensors_info_get_tensor_type (ml_tensors_info_h info, unsigned int index, ml_tensor_type_e *type) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_get_tensor_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetTensorType(IntPtr info, int index, out TensorType type);

        /* int ml_tensors_info_set_tensor_dimension (ml_tensors_info_h info, unsigned int index, const ml_tensor_dimension dimension) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_set_tensor_dimension", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError SetTensorDimension(IntPtr info, int index, int[] dimension);

        /* int ml_tensors_info_get_tensor_dimension (ml_tensors_info_h info, unsigned int index, ml_tensor_dimension dimension) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_get_tensor_dimension", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetTensorDimension(IntPtr info, int index, out int[] dimension);

        /* size_t ml_tensors_info_get_size (const ml_tensors_info_h info) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_get_size", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetTensorsSize(IntPtr info);

        /* int ml_tensors_data_create (const ml_tensors_info_h info, ml_tensors_data_h *data) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_data_create", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError CreateTensorsData(IntPtr info, out IntPtr data);

        /* int ml_tensors_data_destroy (ml_tensors_data_h data) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_data_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError DestroyTensorsData(IntPtr data);

        /* int ml_tensors_data_get_tensor_data (ml_tensors_data_h data, unsigned int index, void **raw_data, size_t *data_size) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_data_get_tensor_data", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetTensorData(IntPtr data, int index, out IntPtr raw_data, out int data_size);

        /* int ml_tensors_data_set_tensor_data (ml_tensors_data_h data, unsigned int index, const void *raw_data, const size_t data_size) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_data_set_tensor_data", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError SetTensorData(IntPtr data, int index, byte[] raw_data, int data_size);

        /* int ml_check_nnfw_availability (ml_nnfw_type_e nnfw, ml_nnfw_hw_e hw, bool *available); */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_check_nnfw_availability", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError CheckNNFWAvailability(NNFWType nnfw, HWType hw, out bool available);

        /* ml_tensors_data_get_tensor_count (ml_tensors_data_h data, unsigned int *num_tensors) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_data_get_tensor_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetTensorsCount(IntPtr data, out uint count);

        internal static byte[] IntPtrToByteArray(IntPtr unmanagedByteArray, int size)
        {
            byte[] retByte = new byte[size];
            Marshal.Copy(unmanagedByteArray, retByte, 0, size);
            return retByte;
        }
    }
}
