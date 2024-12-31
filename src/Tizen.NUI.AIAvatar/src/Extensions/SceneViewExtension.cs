/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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

using Tizen.NUI.Scene3D;
using System.ComponentModel;

namespace Tizen.AIAvatar
{
    /// <summary>
    /// Extension methods for SceneView to manipulate alpha mask URL, mask content scale factor, and crop to mask settings.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class SceneViewExtension
    {
        /// <summary>
        /// Sets the URL of the alpha mask for the SceneView.
        /// </summary>
        /// <param name="sceneView">The SceneView instance to apply the property.</param>
        /// <param name="url">The URL of the alpha mask image.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetAlphaMaskUrl(this SceneView sceneView, string url)
        {
            var setValue = new Tizen.NUI.PropertyValue(url);
            sceneView.SetProperty(Interop.AlphaMaskURLGet(), setValue);
            setValue.Dispose();
        }

        /// <summary>
        /// Retrieves the URL of the alpha mask for the SceneView.
        /// </summary>
        /// <param name="sceneView">The SceneView instance to retrieve the property from.</param>
        /// <returns>The URL of the alpha mask image.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string GetAlphaMaskUrl(this SceneView sceneView)
        {
            var returnValue = "";
            var invertYAxis = sceneView.GetProperty(Interop.AlphaMaskURLGet());
            invertYAxis?.Get(out returnValue);
            invertYAxis?.Dispose();
            return returnValue;
        }

        /// <summary>
        /// Sets the content scale factor for the mask applied to the SceneView.
        /// </summary>
        /// <param name="sceneView">The SceneView instance to apply the property.</param>
        /// <param name="factor">The scaling factor for the mask content.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetMaskContentScaleFactor(this SceneView sceneView, float factor)
        {
            var setValue = new Tizen.NUI.PropertyValue(factor);
            sceneView.SetProperty(Interop.MaskContentScaleGet(), setValue);
            setValue.Dispose();
        }

        /// <summary>
        /// Retrieves the content scale factor for the mask applied to the SceneView.
        /// </summary>
        /// <param name="sceneView">The SceneView instance to retrieve the property from.</param>
        /// <returns>The scaling factor for the mask content.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float GetMaskContentScaleFactor(this SceneView sceneView)
        {
            var returnValue = 0.0f;
            var invertYAxis = sceneView.GetProperty(Interop.MaskContentScaleGet());
            invertYAxis?.Get(out returnValue);
            invertYAxis?.Dispose();
            return returnValue;
        }

        /// <summary>
        /// Enables or disables cropping to the mask for the SceneView.
        /// </summary>
        /// <param name="sceneView">The SceneView instance to apply the property.</param>
        /// <param name="enableCropToMask">True to enable cropping to the mask, false otherwise.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void EnableCropToMask(this SceneView sceneView, bool enableCropToMask)
        {
            var setValue = new Tizen.NUI.PropertyValue(enableCropToMask);
            sceneView.SetProperty(Interop.CropToMaskGet(), setValue);
            setValue.Dispose();
        }

        /// <summary>
        /// Checks if cropping to the mask is enabled for the SceneView.
        /// </summary>
        /// <param name="sceneView">The SceneView instance to retrieve the property from.</param>
        /// <returns>True if cropping to the mask is enabled, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsEnabledCropToMask(this SceneView sceneView)
        {
            bool returnValue = false;
            var invertYAxis = sceneView.GetProperty(Interop.CropToMaskGet());
            invertYAxis?.Get(out returnValue);
            invertYAxis?.Dispose();
            return returnValue;
        }
    }
}
