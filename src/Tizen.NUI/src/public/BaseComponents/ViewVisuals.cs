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
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        #region Internal and Private
        private List<Tizen.NUI.Visuals.VisualObjectsContainer> visualContainers;

        /// <summary>
        /// Range of visual for the container.
        /// </summary>
        internal struct ContainerRangeType
        {
            /// <summary>
            /// Visual will be rendered under the shadow.
            /// </summary>
            internal static readonly int Shadow = Interop.VisualObjectsContainer.ContainerRangeTypeBackgroundEffectGet();

            /// <summary>
            /// Visual will be rendered under the background.
            /// </summary>
            internal static readonly int Background = Interop.VisualObjectsContainer.ContainerRangeTypeBackgroundGet();

            /// <summary>
            /// Visual will be rendered under the content.
            /// It is default value.
            /// </summary>
            internal static readonly int Content = Interop.VisualObjectsContainer.ContainerRangeTypeContentGet();

            /// <summary>
            /// Visual will be rendered under the decoration.
            /// </summary>
            internal static readonly int Decoration = Interop.VisualObjectsContainer.ContainerRangeTypeDecorationGet();

            /// <summary>
            /// Visual will be rendered above the foreground effect.
            /// </summary>
            internal static readonly int ForegroundEffect = Interop.VisualObjectsContainer.ContainerRangeTypeForegroundEffectGet();
        };
        #endregion

        #region Public Methods
        /// <summary>
        /// Add a Tizen.NUI.Visuals.VisualBase to the view.
        /// </summary>
        /// <remarks>
        /// The visual is added to the top of the visuals.
        /// If the container cannot add more than maxium count of visuals
        /// or the visual is already added, It will be ignored.
        ///
        /// If input visual already added to another view,
        /// visual will be detached from old view and added to this view.
        /// </remarks>
        /// <param name="visualBase">The visual to add.</param>
        /// <param name="range">The range of visuals to be added. Default is ViewVisualContainerRange.Content</param>
        /// <returns>True if the visual was added successfully, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AddVisual(Tizen.NUI.Visuals.VisualBase visualBase, ViewVisualContainerRange range = ViewVisualContainerRange.Content)
        {
            return AddVisualInternal(visualBase, ConvertRangeToType(range));
        }

        /// <summary>
        /// Remove a Tizen.NUI.Visuals.VisualBase from the view.
        /// </summary>
        /// <remarks>
        /// The <see cref="Tizen.NUI.Visuals.VisualBase.SiblingOrder"/> value of all other Visuals.VisualBases will be changed automatically.
        /// </remarks>
        /// <param name="visualBase">The visual to remove.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveVisual(Tizen.NUI.Visuals.VisualBase visualBase)
        {
            if (visualContainers != null)
            {
                foreach (var visualContainer in visualContainers)
                {
                    visualContainer?.RemoveVisualObject(visualBase);
                }
            }
        }

        /// <summary>
        /// Get the range of given visual
        /// </summary>
        /// <param name="visualBase">The visual to get range.</param>
        /// <returns>Get the visual's range of container. Invalid if not found.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewVisualContainerRange GetVisualsRange(Visuals.VisualBase visualBase)
        {
            if (visualContainers != null)
            {
                foreach (var visualContainer in visualContainers)
                {
                    if (visualContainer != null)
                    {
                        uint count = visualContainer.GetVisualObjectsCount();
                        for (uint i = 0u; i < count; ++i)
                        {
                            if (visualBase == visualContainer[i])
                            {
                                return ConvertTypeToRange(visualContainer.GetContainerRangeType());
                            }
                        }
                    }
                }
            }
            return ViewVisualContainerRange.Invalid;
        }

        /// <summary>
        /// Get a Tizen.NUI.Visuals.VisualBase by sibling index
        /// </summary>
        /// <returns>Get visual base by sibling index</returns>
        /// <exception cref="InvalidOperationException"> Thrown when index is out of bounds. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.Visuals.VisualBase GetVisualAt(uint index, ViewVisualContainerRange range = ViewVisualContainerRange.Content)
        {
            return GetVisualAtInternal(index, ConvertRangeToType(range));
        }

        /// <summary>
        /// Get total number of Tizen.NUI.Visuals.VisualBase which we added using <see cref="AddVisual"/>.
        /// </summary>
        /// <returns>Get the number of visual base.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetVisualsCount(ViewVisualContainerRange range = ViewVisualContainerRange.Content)
        {
            return GetVisualsCountInternal(ConvertRangeToType(range));
        }

        /// <summary>
        /// Find Tizen.NUI.Visuals.VisualBase by name. Given name should not be empty.
        /// </summary>
        /// <returns>Get the visual base.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Visuals.VisualBase FindVisualByName(string name)
        {
            Visuals.VisualBase ret = null;
            if (visualContainers != null)
            {
                foreach (var visualContainer in visualContainers)
                {
                    if (visualContainer != null)
                    {
                        ret = visualContainer.FindVisualObjectByName(name);
                        if (ret != null)
                        {
                            break;
                        }
                    }
                }
            }
            return ret;
        }
        #endregion

        #region Internal Method
        internal bool AddVisualInternal(Tizen.NUI.Visuals.VisualBase visualBase, int rangeType)
        {
            var visualContainer = EnsureVisualContainer(rangeType);
            return visualContainer.AddVisualObject(visualBase);
        }

        internal Tizen.NUI.Visuals.VisualBase GetVisualAtInternal(uint index, int rangeType)
        {
            if (index >= GetVisualsCountInternal(rangeType))
            {
                throw new InvalidOperationException($"Index {index} is out of bounds. Bound is {GetVisualsCountInternal(rangeType)}");
            }
            var visualContainer = EnsureVisualContainer(rangeType);
            return visualContainer[index];
        }

        internal uint GetVisualsCountInternal(int rangeType)
        {
            uint ret = 0;
            if (visualContainers != null)
            {
                foreach (var visualContainer in visualContainers)
                {
                    if (visualContainer != null && visualContainer.GetContainerRangeType() == rangeType)
                    {
                        ret = visualContainer.GetVisualObjectsCount();
                        break;
                    }
                }
            }
            return ret;
        }

        private Tizen.NUI.Visuals.VisualObjectsContainer EnsureVisualContainer(int rangeType)
        {
            if (visualContainers == null)
            {
                visualContainers = new List<Tizen.NUI.Visuals.VisualObjectsContainer>();
            }

            foreach (var visualContainer in visualContainers)
            {
                if (visualContainer != null && visualContainer.GetContainerRangeType() == rangeType)
                {
                    return visualContainer;
                }
            }

            var newContainer = new Tizen.NUI.Visuals.VisualObjectsContainer(this, rangeType);
            visualContainers.Add(newContainer);
            return newContainer;
        }

        private static int ConvertRangeToType(ViewVisualContainerRange range)
        {
            switch (range)
            {
                case ViewVisualContainerRange.Shadow:
                {
                    return ContainerRangeType.Shadow;
                }
                case ViewVisualContainerRange.Background:
                {
                    return ContainerRangeType.Background;
                }
                case ViewVisualContainerRange.Content:
                {
                    return ContainerRangeType.Content;
                }
                case ViewVisualContainerRange.Decoration:
                {
                    return ContainerRangeType.Decoration;
                }
                case ViewVisualContainerRange.ForegroundEffect:
                {
                    return ContainerRangeType.ForegroundEffect;
                }
                default:
                {
                    return -1;
                }
            }
        }

        private static ViewVisualContainerRange ConvertTypeToRange(int range)
        {
            // Cannot use switch case here.
            if (range == ContainerRangeType.Shadow)
            {
                return ViewVisualContainerRange.Shadow;
            }
            else if (range == ContainerRangeType.Background)
            {
                return ViewVisualContainerRange.Background;
            }
            else if (range == ContainerRangeType.Content)
            {
                return ViewVisualContainerRange.Content;
            }
            else if (range == ContainerRangeType.Decoration)
            {
                return ViewVisualContainerRange.Decoration;
            }
            else if (range == ContainerRangeType.ForegroundEffect)
            {
                return ViewVisualContainerRange.ForegroundEffect;
            }

            return ViewVisualContainerRange.Invalid;
        }
        #endregion
    }
}
