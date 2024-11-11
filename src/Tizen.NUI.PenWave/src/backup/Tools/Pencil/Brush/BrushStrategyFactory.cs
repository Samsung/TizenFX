// /*
//  * Copyright(c) 2024 Samsung Electronics Co., Ltd.
//  *
//  * Licensed under the Apache License, Version 2.0 (the "License");
//  * you may not use this file except in compliance with the License.
//  * You may obtain a copy of the License at
//  *
//  * http://www.apache.org/licenses/LICENSE-2.0
//  *
//  * Unless required by applicable law or agreed to in writing, software
//  * distributed under the License is distributed on an "AS IS" BASIS,
//  * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  * See the License for the specific language governing permissions and
//  * limitations under the License.
//  *
//  */

// using System;
// using System.ComponentModel;
// using System.Collections.Generic;
// using Tizen.NUI;
// using Tizen.NUI.BaseComponents;

// namespace Tizen.NUI.PenWave
// {
//     public static class BrushStrategyFactory
//     {
//         public static IBrushStrategy GetBrushStrategy(PWEngine.BrushType brushType)
//         {
//             return brushType switch
//             {
//                 PWEngine.BrushType.Stroke => new StrokeBrush(),
//                 PWEngine.BrushType.VarStroke => new VarStrokeBrush(),
//                 PWEngine.BrushType.VarStrokeInc => new VarStrokeIncBrush(),
//                 PWEngine.BrushType.SprayBrush => new SprayBrush(),
//                 PWEngine.BrushType.DotBrush => new DotBrush(),
//                 PWEngine.BrushType.DashedLine => new DashedLineBrush(),
//                 PWEngine.BrushType.Highlighter => new HighlighterBrush(),
//                 PWEngine.BrushType.SoftBrush => new SoftBrush(),
//                 PWEngine.BrushType.SharpBrush => new SharpBrush(),
//                 _ => throw new ArgumentOutOfRangeException(nameof(brushType), brushType, null)
//             };
//         }

//     }
// }
