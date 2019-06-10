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

    internal static partial class Pipeline
    {
        internal enum Error
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
            StreamsPipe = Tizen.Internals.Errors.ErrorCode.StreamsPipe,
            TryAgain = Tizen.Internals.Errors.ErrorCode.TryAgain,
        }

        // @TODO Need to update since C API is going to be update
        [DllImport(Libraries.Nnstreamer, EntryPoint = "nns_pipeline_construct", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError Construct(string pipelineDesc, out IntPtr pipe);

        // @TODO Need to update since C API is going to be update
        [DllImport(Libraries.Nnstreamer, EntryPoint = "nns_pipeline_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NNStreamerError Destroy(IntPtr pipe);
    }
}