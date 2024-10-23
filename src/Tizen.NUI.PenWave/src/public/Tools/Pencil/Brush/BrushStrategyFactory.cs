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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.PenWave
{
    public sealed class BrushStrategyFactory
    {
        private static readonly BrushStrategyFactory instance = new BrushStrategyFactory();
        private Dictionary<PencilTool.BrushType, IBrushStrategy> brushStrategies = new Dictionary<PencilTool.BrushType, IBrushStrategy>();

        public static BrushStrategyFactory Instance => instance;

        public IBrushStrategy GetBrushStrategy(PencilTool.BrushType brushType)
        {
            if (!brushStrategies.ContainsKey(brushType))
            {
                brushStrategies[brushType] = brushType switch
                {
                    PencilTool.BrushType.Stroke => new StrokeBrush(),
                    PencilTool.BrushType.VarStroke => new VarStrokeBrush(),
                    PencilTool.BrushType.VarStrokeInc => new VarStrokeIncBrush(),
                    PencilTool.BrushType.SprayBrush => new SprayBrush(),
                    PencilTool.BrushType.DotBrush => new DotBrush(),
                    PencilTool.BrushType.DashedLine => new DashedLineBrush(),
                    PencilTool.BrushType.Highlighter => new HighlighterBrush(),
                    PencilTool.BrushType.SoftBrush => new SoftBrush(),
                    PencilTool.BrushType.SharpBrush => new SharpBrush(),
                    _ => throw new ArgumentOutOfRangeException(nameof(brushType), brushType, null)
                };
            }

            return brushStrategies[brushType];
        }

    }
}
