/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.MachineLearning.Train;

internal static partial class Interop
{
    internal static partial class Layer
    {
        /* int ml_train_layer_create(ml_train_layer_h *layer, ml_train_layer_type_e type) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_layer_create")]
        public static extern NNTrainerError Create(out IntPtr layerHandle, NNTrainerLayerType type);

        /* int ml_train_layer_destroy(ml_train_layer_h layer) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_layer_destroy")]
        public static extern NNTrainerError Destroy(IntPtr layerHandle);

        /* int ml_train_layer_set_property_with_single_param(ml_train_layer_h layer, const char *single_param) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_layer_set_property_with_single_param")]
        public static extern NNTrainerError SetProperty(IntPtr layerHandle, string propertyParams);
    }
}