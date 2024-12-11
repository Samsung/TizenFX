// Copyright (c) 2025 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI
{
    /// <summary>
    /// DepthIndex is used to define order of Renderable in a View
    /// A Renderable has larger number of DepthIndex will be rendered after than those have small number of DepthIndex.
    /// </summary>
    /// This will be opened API after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class DepthIndexRanges
    {
        /// <summary>
        /// If DepthIndex of a Renderable is set below the BackgroundEffect,
        /// The Renderable is rendered before the shadow of the View.
        /// </summary>
        /// This will be opened API after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int BackgroundEffect = Interop.Renderer.RangesBackgroundEffectGet();

        /// <summary>
        /// If DepthIndex of a Renderable is between BackgroundEffect and Background
        /// The Renderable is rendered after shadow and before background of the View.
        /// </summary>
        /// This will be opened API after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int Background = Interop.Renderer.RangesBackgroundGet();

        /// <summary>
        /// If DepthIndex of a Renderable is between Background and Content
        /// The Renderable is rendered after background and before content of the View.
        /// For example, the Content of ImageView is image.
        /// </summary>
        /// This will be opened API after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int Content = Interop.Renderer.RangesContentGet();

        /// <summary>
        /// If DepthIndex of a Renderable is between Content and Decoration
        /// </summary>
        /// This will be opened API after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int Decoration = Interop.Renderer.RangesDecorationGet();

        /// <summary>
        /// If DepthIndex of a Renderable is between Content and Decoration
        /// </summary>
        /// This will be opened API after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int ForegroundEffect = Interop.Renderer.RangesForegroundEffectGet();

        // TODO: Min, max
        // TODO: Needs Decoration and ForegroundEffect? more accuratly.
    }
}