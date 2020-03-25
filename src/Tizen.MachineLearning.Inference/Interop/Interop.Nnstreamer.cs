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

        /* int ml_single_invoke_dynamic (ml_single_h single, const ml_tensors_data_h input, const ml_tensors_info_h in_info, ml_tensors_data_h * output, ml_tensors_info_h * out_info) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_single_invoke_dynamic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError InvokeSingleDynamic(IntPtr single_handle, IntPtr input_data, IntPtr input_info, out IntPtr output_data, out IntPtr output_info);

        /* int ml_single_get_input_info (ml_single_h single, ml_tensors_info_h *info) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_single_get_input_info", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetInputTensorsInfo(IntPtr single_handle, out IntPtr input_info);

        /* int ml_single_get_output_info (ml_single_h single, ml_tensors_info_h *info) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_single_get_output_info", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetOutputTensorsInfo(IntPtr single_handle, out IntPtr output_info);

        /* int ml_single_set_input_info (ml_single_h single, const ml_tensors_info_h info) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_single_set_input_info", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError SetInputInfo(IntPtr single_handle, IntPtr in_handle);

        /* int ml_single_set_timeout (ml_single_h single, unsigned int timeout)*/
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_single_set_timeout", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError SetTimeout(IntPtr single_handle, int time_ms);

        /* int ml_single_set_property (ml_single_h single, const char *name, const char *value) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_single_set_property", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError SetValue(IntPtr single_handle, string name, string value);

        /* int ml_single_get_property (ml_single_h single, const char *name, char **value) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_single_get_property", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError GetValue(IntPtr single_handle, string name, out IntPtr value);
    }

    internal static partial class Util
    {
        /* int ml_tensors_info_create (ml_tensors_info_h *info) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_create", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError CreateTensorsInfo(out IntPtr info);
            
        /* int ml_tensors_info_destroy (ml_tensors_info_h info) */
        [DllImport(Libraries.Nnstreamer, EntryPoint = "ml_tensors_info_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError DestroyTensorsInfo(IntPtr info);

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
        internal static extern NNStreamerError GetTensorDimension(IntPtr info, int index, [In, Out] uint[] dimension);

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

        internal static byte[] IntPtrToByteArray(IntPtr unmanagedByteArray, int size)
        {
            byte[] retByte = new byte[size];
            Marshal.Copy(unmanagedByteArray, retByte, 0, size);
            return retByte;
        }

        internal static string IntPtrToString(IntPtr val)
        {
            return (val != IntPtr.Zero) ? Marshal.PtrToStringAnsi(val) : string.Empty;
        }
    }
}
