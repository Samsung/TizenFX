/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The class storing Layout properties.
    /// </summary>
    internal sealed class LayoutExtraData : IDisposable
    {
        private bool disposed;

        // Indicates whether the layout has been set by user or not.
        public bool LayoutSet { get; set; }

        // Exclusive layout assigned to this View.
        public LayoutItem Layout { get; set; }

        // The List of transitions for this View.
        public Dictionary<TransitionCondition, TransitionList> LayoutTransitions { get; set; }

        // Layout transitions for this View.
        public LayoutTransition LayoutTransition { get; set; }

        // TransitionOptions for the page transition.
        public TransitionOptions TransitionOptions { get; set; }

        // The weight of the View, used to share available space in a layout with siblings.
        public float Weight { get; set; }

        // The status of whether the view is excluded from its parent's layouting or not.
        public bool ExcludeLayouting { get; set; }

        /// <summary>
        /// Gets or sets the width of the view. It can be set to a fixed value, wrap content, or match parent.
        /// </summary>
        public LayoutDimension Width { get; set; } = LayoutDimensionMode.WrapContent;

        /// <summary>
        /// Gets or sets the height of the view. It can be set to a fixed value, wrap content, or match parent.
        /// </summary>
        public LayoutDimension Height { get; set; } = LayoutDimensionMode.WrapContent;

        ~LayoutExtraData() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                TransitionOptions?.Dispose();
            }
            disposed = true;
        }
    }
}


