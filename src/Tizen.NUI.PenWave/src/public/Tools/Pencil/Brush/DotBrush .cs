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

using System.ComponentModel;

namespace Tizen.NUI.PenWave
{
    /// <summary>
    /// The dot brush strategy.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DotBrush : IBrushStrategy
    {
        /// <summary>
        /// Apply the brush settings.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyBrushSettings()
        {
            PenWaveRenderer.Instance.SetStrokeType(1);
            PenWaveRenderer.Instance.SetBrushTexture(1);
            PenWaveRenderer.Instance.SetBrushDistance(2.0f);
        }
    }
}
