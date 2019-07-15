/*
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
using Tizen.MachineLearning.Nnstreamer;

internal static partial class Interop
{
    internal static partial class Libraries
    {
        public const string Nnstreamer = "libcapi-nnstreamer.so.0";
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
        internal static extern NNStreamerError SetTensorsName(IntPtr info, int index, string name);

        /* int ml_tensors_info_get_tensor_name (ml_tensors_info_h info, unsigned int index, char **name) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_get_tensor_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetTensorsName(IntPtr info, int index, out string name);

        /* int ml_tensors_info_set_tensor_type (ml_tensors_info_h info, unsigned int index, const ml_tensor_type_e type) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_set_tensor_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError SetTensorsType(IntPtr info, int index, TensorType type);

        /* int ml_tensors_info_get_tensor_type (ml_tensors_info_h info, unsigned int index, ml_tensor_type_e *type) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_get_tensor_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetTensorsType(IntPtr info, int index, out TensorType type);

        /* int ml_tensors_info_set_tensor_dimension (ml_tensors_info_h info, unsigned int index, const ml_tensor_dimension dimension) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_set_tensor_dimension", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError SetTensorsDimension(IntPtr info, int index, int[] dimension);

        /* int ml_tensors_info_get_tensor_dimension (ml_tensors_info_h info, unsigned int index, ml_tensor_dimension dimension) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_get_tensor_dimension", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetTensorsDimension(IntPtr info, int index, out int[] dimension);

        /* size_t ml_tensors_info_get_size (const ml_tensors_info_h info) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_get_size", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetTensorsSize(IntPtr info);

        /* int ml_tensors_data_create (const ml_tensors_info_h info, ml_tensors_data_h *data) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_data_create", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError CreateTensorsData(IntPtr info, out IntPtr data);

        /* int ml_tensors_data_destroy (ml_tensors_data_h data) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_data_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError DestroyTensorData(IntPtr data);

        /* int ml_tensors_data_get_tensor_data (ml_tensors_data_h data, unsigned int index, void **raw_data, size_t *data_size) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_data_get_tensor_data", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetTensorData(IntPtr data, int index, out byte[] raw_data, out int data_size);

        /* int ml_tensors_data_set_tensor_data (ml_tensors_data_h data, unsigned int index, const void *raw_data, const size_t data_size) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_data_set_tensor_data", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError SetTensorData(IntPtr data, int index, byte[] raw_data, int data_size);

        /* int ml_tensors_data_set_tensor_data (ml_tensors_data_h data, unsigned int index, const void *raw_data, const size_t data_size) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_check_nnfw_availability", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError CheckNNFWAvailability(NNFWType nnfw, HWType hw, out bool available);
    }
}
