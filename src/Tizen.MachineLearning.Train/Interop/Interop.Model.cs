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
    internal static partial class Model
    {
        /* typedef int ml_train_model_construct(ml_train_model_h *model) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_model_construct")]
        public static extern NNTrainerError Construct(out IntPtr modelHandle);

        /* typedef int ml_train_model_destroy(ml_train_model_h model) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_model_destroy")]
        public static extern NNTrainerError Destroy(IntPtr modelHandle);

        /* int ml_train_model_construct_with_conf(const char *model_conf, ml_train_model_h *model) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_model_construct_with_conf")]
        public static extern NNTrainerError ConstructWithConf(string modelConf, out IntPtr modelHandle);

        /* int ml_train_model_compile_with_params(ml_train_model_h model, const char *params) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_model_compile_with_single_param")]
        public static extern NNTrainerError Compile(IntPtr modelHandle, string compileParams);

        /* int ml_train_model_run(ml_train_model_h model, ...) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_model_run_with_single_param")]
        public static extern NNTrainerError Run(IntPtr modelHandle, string runParams);

        /* int ml_train_model_get_summary(ml_train_model_h model, ml_train_summary_type_e verbosity, char **summary) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_model_get_summary")]
        public static extern NNTrainerError GetSummary(IntPtr modelHandle, NNTrainerSummaryType verbosity, out string summary);

        /* int ml_train_model_save(ml_train_model_h model, const char *file_path, ml_train_model_format_e format) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_model_save")]
        public static extern NNTrainerError Save(IntPtr modelHandle, string filePath, NNTrainerModelFormat format);

        /* int ml_train_model_load(ml_train_model_h model, const char *file_path, ml_train_model_format_e format) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_model_load")]
        public static extern NNTrainerError Load(IntPtr modelHandle, string filePath, NNTrainerModelFormat format);

        /* int ml_train_model_add_layer(ml_train_model_h model, ml_train_layer_h layer) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_model_add_layer")]
        public static extern NNTrainerError AddLayer(IntPtr modelHandle, IntPtr layerHandle);

        /* int ml_train_model_get_layer(ml_train_model_h model, const char *layer_name, ml_train_layer_h *layer) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_model_get_layer")]
        public static extern NNTrainerError GetLayer(IntPtr modelHandle, string layerName, out IntPtr layer);

    }
}
