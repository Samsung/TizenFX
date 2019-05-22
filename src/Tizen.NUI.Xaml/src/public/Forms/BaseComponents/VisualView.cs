// Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
//

using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;

namespace Tizen.NUI.Xaml.Forms.BaseComponents
{
    /// <summary>
    /// A visual view control if a user adds any visual to it.
    /// </summary>
    /// <example>
    /// Example:
    /// <code>
    /// VisualView _visualView = new VisualView();
    /// ImageVisualMap imageVisualMap1 = new ImageVisualMap();
    /// imageVisualMap1.URL = "./NUISample/res/images/image-1.jpg";
    /// imageVisualMap1.VisualSize = new Vector2( 300.0f, 300.0f );
    /// imageVisualMap1.Offset = new Vector2( 50.0f, 50.0f );
    /// imageVisualMap1.OffsetSizeMode = new Vector4( 1.0f, 1.0f, 1.0f, 1.0f );
    /// imageVisualMap1.Origin = AlignType.TOP_BEGIN;
    /// imageVisualMap1.AnchorPoint = AlignType.TOP_BEGIN;
    /// _visualView.AddVisual("imageVisual1", imageVisualMap1);
    /// </code>
    /// </example>
    /// <since_tizen> 3 </since_tizen>
    public class VisualView : CustomView
    {
        private Tizen.NUI.BaseComponents.VisualView _visualView;
        internal Tizen.NUI.BaseComponents.VisualView visualView
        {
            get
            {
                if (null == _visualView)
                {
                    _visualView = handleInstance as Tizen.NUI.BaseComponents.VisualView;
                }

                return _visualView;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public VisualView() : base(typeof(VisualView).FullName, CustomViewBehaviour.ViewBehaviourDefault | CustomViewBehaviour.RequiresTouchEventsSupport)
        {
        }

        /// <summary>
        /// Gets the total number of visuals which are added by users.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int NumberOfVisuals
        {
            get
            {
                return visualView.NumberOfVisuals;
            }
        }

        /// <summary>
        /// Adds or updates a visual to visual view.
        /// </summary>
        /// <param name="visualName">The name of a visual to add. If a name is added to an existing visual name, the visual will be replaced.</param>
        /// <param name="visualMap">The property map of a visual to create.</param>
        /// <since_tizen> 3 </since_tizen>
        public void AddVisual(string visualName, VisualMap visualMap)
        {
            visualView.AddVisual(visualName, visualMap);
        }

        /// <summary>
        /// Removes a visual by name.
        /// </summary>
        /// <param name="visualName">The name of a visual to remove.</param>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveVisual(string visualName)
        {
            visualView.RemoveVisual(visualName);
        }

        /// <summary>
        /// Removes all visuals of the visual view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveAll()
        {
            visualView.RemoveAll();
        }

        /// <summary>
        /// Overrides the method of OnRelayout() for CustomView class.<br />
        /// Called after the size negotiation has been finished for this control.<br />
        /// The control is expected to assign this given size to itself or its children.<br />
        /// Should be overridden by derived classes if they need to layout actors differently after certain operations like add or remove actors, resize, or after changing specific properties.<br />
        /// </summary>
        /// <remarks>As this function is called from inside the size negotiation algorithm, you cannot call RequestRelayout (the call would just be ignored).</remarks>
        /// <param name="size">The allocated size.</param>
        /// <param name="container">The control should add actors to this container that it is not able to allocate a size for.</param>
        /// <since_tizen> 3 </since_tizen>
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            visualView.OnRelayout(size, container);
        }

        /// <summary>
        /// Creates a visual animation (transition) with the input parameters.
        /// </summary>
        /// <param name="target">The visual map to animation.</param>
        /// <param name="property">The property of visual to animation.</param>
        /// <param name="destinationValue">The destination value of property after animation.</param>
        /// <param name="startTime">The start time of visual animation.</param>
        /// <param name="endTime">The end time of visual animation.</param>
        /// <param name="alphaFunction">The alpha function of visual animation.</param>
        /// <param name="initialValue">The initial property value of visual animation.</param>
        /// <returns>Animation instance</returns>
        /// <since_tizen> 3 </since_tizen>
        public Animation AnimateVisual(VisualMap target, string property, object destinationValue, int startTime, int endTime, AlphaFunction.BuiltinFunctions? alphaFunction = null, object initialValue = null)
        {
            return visualView.AnimateVisual(target, property, destinationValue, startTime, endTime, alphaFunction, initialValue);
        }

        /// <summary>
        /// Adds a group visual animation (transition) map with the input parameters.
        /// </summary>
        /// <param name="target">The visual map to animation.</param>
        /// <param name="property">The property of visual to animation.</param>
        /// <param name="destinationValue">The destination value of property after animation.</param>
        /// <param name="startTime">The start time of visual animation.</param>
        /// <param name="endTime">The end time of visual animation.</param>
        /// <param name="alphaFunction">The alpha function of visual animation.</param>
        /// <param name="initialValue">The initial property value of visual animation.</param>
        /// <since_tizen> 3 </since_tizen>
        public void AnimateVisualAdd(VisualMap target, string property, object destinationValue, int startTime, int endTime, AlphaFunction.BuiltinFunctions? alphaFunction = null, object initialValue = null)
        {
            visualView.AnimateVisualAdd(target, property, destinationValue, startTime, endTime, alphaFunction, initialValue);
        }

        /// <summary>
        /// Finishes to add a visual animation (transition) map and creates a transition animation.
        /// </summary>
        /// <returns>Animation instance.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Animation AnimateVisualAddFinish()
        {
            return visualView.AnimateVisualAddFinish();
        }

        /// <summary>
        /// temporary fix to pass TCT.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Animation VisualAnimate(Tizen.NUI.VisualAnimator visualMap)
        {
            return visualView.VisualAnimate(visualMap);
        }
        //temporary fix to pass TCT
    }
}