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

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Specifies the type of inference backend.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum InferenceBackendType
    {
        /// <summary>
        /// OpenCV backend type
        /// </summary>
        OpenCV,

        /// <summary>
        /// Tensor Flow Lite backend type
        /// </summary>
        TFLite,

        /// <summary>
        /// ArmNN backend type
        /// </summary>
        [Obsolete("Deprecated since API11. Will be removed in API13.")]
        ArmNN,

        /// <summary>
        /// ML Single API of NNStreamer backend type
        /// </summary>
        /// <remarks>
        /// Should be set <see cref="InferenceTargetDevice"/> to <see cref="InferenceTargetDevice.Custom"/>.
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        [Obsolete("Deprecated since API11. Will be removed in API13.")]
        MLApi,

        /// <summary>
        /// On-device Neural Engine backend type
        /// </summary>
        /// <remarks>
        /// Should be set <see cref="InferenceTargetDevice"/> to <see cref="InferenceTargetDevice.CPU"/> or
        /// <see cref="InferenceTargetDevice.GPU"/>.
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        One,

        /// <summary>
        /// NNTrainer backend type
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        NNTrainer,

        /// <summary>
        /// SNPE(Snapdragon Neural Processing Engine) backend type
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        Snpe
    }

    /// <summary>
    /// Specifies the target device which is used for running <see cref="InferenceModelConfiguration.Backend"/>.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public enum InferenceTargetDevice
    {
        /// <summary>
        /// CPU device
        /// </summary>
        CPU = 1 << 0,

        /// <summary>
        /// GPU device
        /// </summary>
        GPU = 1 << 1,

        /// <summary>
        /// Custom device
        /// </summary>
        Custom = 1 << 2
    }

    /// <summary>
    /// Specifies the data type.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public enum InferenceDataType
    {
        /// <summary>
        /// Float 32 bit
        /// </summary>
        Float32,

        /// <summary>
        /// Unsigned Integer 8 bit
        /// </summary>
        UInt8
    }
}
