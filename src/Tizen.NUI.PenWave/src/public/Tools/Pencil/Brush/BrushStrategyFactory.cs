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

using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Tizen.NUI.PenWave
{
    /// <summary>
    /// The factory class that creates brush strategies.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class BrushStrategyFactory
    {
        private static readonly BrushStrategyFactory s_instance = new BrushStrategyFactory();
        private Dictionary<BrushType, IBrushStrategy> _brushStrategies = new Dictionary<BrushType, IBrushStrategy>();

        /// <summary>
        /// Private constructor.
        /// </summary>
        private BrushStrategyFactory() { }

        /// <summary>
        /// Gets the singleton instance of the BrushStrategyFactory.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BrushStrategyFactory Instance => s_instance;

        /// <summary>
        /// Gets the brush strategy for the specified brush type.
        /// </summary>
        /// <param name="brushType">The brush type.</param>
        public IBrushStrategy GetBrushStrategy(BrushType brushType)
        {
            if (!_brushStrategies.ContainsKey(brushType))
            {
                _brushStrategies[brushType] = brushType switch
                {
                    BrushType.Stroke => new StrokeBrush(),
                    BrushType.VarStroke => new VarStrokeBrush(),
                    BrushType.VarStrokeInc => new VarStrokeIncBrush(),
                    BrushType.SprayBrush => new SprayBrush(),
                    BrushType.DotBrush => new DotBrush(),
                    BrushType.DashedLine => new DashedLineBrush(),
                    BrushType.Highlighter => new HighlighterBrush(),
                    BrushType.SoftBrush => new SoftBrush(),
                    BrushType.SharpBrush => new SharpBrush(),
                    _ => throw new ArgumentOutOfRangeException(nameof(brushType), brushType, null)
                };
            }

            return _brushStrategies[brushType];
        }

    }
}
