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
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class SceneViewExtension
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetAlphaMaskUrl(this SceneView sceneView, string url)
        {
            var setValue = new Tizen.NUI.PropertyValue(url);
            sceneView.SetProperty(Interop.AlphaMaskURLGet(), setValue);
            setValue.Dispose();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string GetAlphaMaskUrl(this SceneView sceneView)
        {
            var returnValue = "";
            var invertYAxis = sceneView.GetProperty(Interop.AlphaMaskURLGet());
            invertYAxis?.Get(out returnValue);
            invertYAxis?.Dispose();
            return returnValue;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetMaskContentScaleFactor(this SceneView sceneView, float factor)
        {
            var setValue = new Tizen.NUI.PropertyValue(factor);
            sceneView.SetProperty(Interop.MaskContentScaleGet(), setValue);
            setValue.Dispose();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float GetMaskContentScaleFactor(this SceneView sceneView)
        {
            var returnValue = 0.0f;
            var invertYAxis = sceneView.GetProperty(Interop.MaskContentScaleGet());
            invertYAxis?.Get(out returnValue);
            invertYAxis?.Dispose();
            return returnValue;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void EnableCropToMask(this SceneView sceneView, bool enableCropToMask)
        {
            var setValue = new Tizen.NUI.PropertyValue(enableCropToMask);
            sceneView.SetProperty(Interop.CropToMaskGet(), setValue);
            setValue.Dispose();
        }

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
