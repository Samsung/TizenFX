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

namespace Tizen.NUI.BaseComponents
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
        //private LinkedList<VisualBase> _visualList = null;
        private Dictionary<int, VisualBase> _visualDictionary = null;
        private Dictionary<int, PropertyMap> _tranformDictionary = null;
        private PropertyArray _animateArray = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public VisualView() : base(typeof(VisualView).FullName, CustomViewBehaviour.ViewBehaviourDefault | CustomViewBehaviour.RequiresTouchEventsSupport)
        {
        }

        // static constructor registers the control type (for user can add kinds of visuals to it)
        static VisualView()
        {
            // ViewRegistry registers control type with DALi type registery
            // also uses introspection to find any properties that need to be registered with type registry
            CustomViewRegistry.Instance.Register(CreateInstance, typeof(VisualView));
        }

        /// <summary>
        /// Gets the total number of visuals which are added by users.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int NumberOfVisuals
        {
            get
            {
                return _visualDictionary.Count;
            }
        }

        /// <summary>
        /// Overrides the parent method.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public override void OnInitialize()
        {
            //Initialize empty
            _visualDictionary = new Dictionary<int, VisualBase>();
            _tranformDictionary = new Dictionary<int, PropertyMap>();
            _animateArray = new PropertyArray();
        }

        /// <summary>
        /// Adds or updates a visual to visual view.
        /// </summary>
        /// <param name="visualName">The name of a visual to add. If a name is added to an existing visual name, the visual will be replaced.</param>
        /// <param name="visualMap">The property map of a visual to create.</param>
        /// <since_tizen> 3 </since_tizen>
        public void AddVisual(string visualName, VisualMap visualMap)
        {
            VisualBase visual = null;
            int visualIndex = -1;

            /* If the visual had added, then replace it using RegisterVusal. */
            //visual.Name = name;
            foreach (var item in _visualDictionary)
            {
                if (item.Value.Name == visualName)
                {
                    /* Find a existed visual, its key also exited. */
                    visualIndex = item.Key;
                    UnregisterVisual(visualIndex);
                    _visualDictionary.Remove(visualIndex);
                    _tranformDictionary.Remove(visualIndex);
                    break;
                }
            }

            if (visualIndex == -1) // The visual is a new one, create index for it. */
            {
                visualIndex = RegisterProperty(visualName, new PropertyValue(visualName), PropertyAccessMode.ReadWrite);
            }

            if (visualIndex > 0)
            {
                visual = VisualFactory.Instance.CreateVisual(visualMap.OutputVisualMap); // Create a visual for the new one.
                visual.Name = visualName;
                visual.DepthIndex = visualMap.DepthIndex;

                RegisterVisual(visualIndex, visual);

                _visualDictionary.Add(visualIndex, visual);
                _tranformDictionary.Add(visualIndex, visualMap.OutputTransformMap);

                visualMap.VisualIndex = visualIndex;
                visualMap.Name = visualName;
                visualMap.Parent = this;

                RelayoutRequest();
            }
        }

        /// <summary>
        /// Removes a visual by name.
        /// </summary>
        /// <param name="visualName">The name of a visual to remove.</param>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveVisual(string visualName)
        {
            foreach (var item in _visualDictionary)
            {
                if (item.Value.Name == visualName)
                {
                    EnableVisual(item.Key, false);
                    UnregisterVisual(item.Key);
                    _tranformDictionary.Remove(item.Key);
                    _visualDictionary.Remove(item.Key);

                    RelayoutRequest();
                    break;
                }
            }
        }

        /// <summary>
        /// Removes all visuals of the visual view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveAll()
        {
            foreach (var item in _visualDictionary)
            {
                EnableVisual(item.Key, false);
                UnregisterVisual(item.Key);
            }
            _visualDictionary.Clear();
            _tranformDictionary.Clear();
            RelayoutRequest();
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
            foreach (var item in _visualDictionary)
            {
                item.Value.SetTransformAndSize(_tranformDictionary[item.Key], size);
                EnableVisual(item.Key, true);
            }
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
            string _alphaFunction = null;
            if (alphaFunction != null)
            {
                switch (alphaFunction)
                {
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Linear:
                    {
                        _alphaFunction = "LINEAR";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Reverse:
                    {
                        _alphaFunction = "REVERSE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInSquare:
                    {
                        _alphaFunction = "EASE_IN_SQUARE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutSquare:
                    {
                        _alphaFunction = "EASE_OUT_SQUARE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseIn:
                    {
                        _alphaFunction = "EASE_IN";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOut:
                    {
                        _alphaFunction = "EASE_OUT";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInOut:
                    {
                        _alphaFunction = "EASE_IN_OUT";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInSine:
                    {
                        _alphaFunction = "EASE_IN_SINE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutSine:
                    {
                        _alphaFunction = "EASE_OUT_SINE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInOutSine:
                    {
                        _alphaFunction = "EASE_IN_OUT_SINE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Bounce:
                    {
                        _alphaFunction = "BOUNCE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Sin:
                    {
                        _alphaFunction = "SIN";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutBack:
                    {
                        _alphaFunction = "EASE_OUT_BACK";
                        break;
                    }
                    default:
                    {
                        _alphaFunction = "DEFAULT";
                        break;
                    }
                }
            }

            foreach (var item in _visualDictionary.ToList())
            {
                if (item.Value.Name == target.Name)
                {
                    PropertyMap _animator = new PropertyMap();
                    if (_alphaFunction != null) { _animator.Add("alphaFunction", new PropertyValue(_alphaFunction)); }

                    PropertyMap _timePeriod = new PropertyMap();
                    _timePeriod.Add("duration", new PropertyValue((endTime - startTime) / 1000.0f));
                    _timePeriod.Add("delay", new PropertyValue(startTime / 1000.0f));
                    _animator.Add("timePeriod", new PropertyValue(_timePeriod));

                    StringBuilder sb = new StringBuilder(property);
                    sb[0] = (char)(sb[0] | 0x20);
                    string _str = sb.ToString();
                    if (_str == "position") { _str = "offset"; }

                    PropertyValue destVal = PropertyValue.CreateFromObject(destinationValue);

                    PropertyMap _transition = new PropertyMap();
                    _transition.Add("target", new PropertyValue(target.Name));
                    _transition.Add("property", new PropertyValue(_str));
                    if (initialValue != null)
                    {
                        PropertyValue initVal = PropertyValue.CreateFromObject(initialValue);
                        _transition.Add("initialValue", new PropertyValue(initVal));
                    }
                    _transition.Add("targetValue", destVal);
                    _transition.Add("animator", new PropertyValue(_animator));

                    TransitionData _transitionData = new TransitionData(_transition);
                    return this.CreateTransition(_transitionData);
                }
            }
            return null;
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
            string _alphaFunction = null;
            if (alphaFunction != null)
            {
                switch (alphaFunction)
                {
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Linear:
                    {
                        _alphaFunction = "LINEAR";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Reverse:
                    {
                        _alphaFunction = "REVERSE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInSquare:
                    {
                        _alphaFunction = "EASE_IN_SQUARE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutSquare:
                    {
                        _alphaFunction = "EASE_OUT_SQUARE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseIn:
                    {
                        _alphaFunction = "EASE_IN";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOut:
                    {
                        _alphaFunction = "EASE_OUT";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInOut:
                    {
                        _alphaFunction = "EASE_IN_OUT";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInSine:
                    {
                        _alphaFunction = "EASE_IN_SINE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutSine:
                    {
                        _alphaFunction = "EASE_OUT_SINE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInOutSine:
                    {
                        _alphaFunction = "EASE_IN_OUT_SINE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Bounce:
                    {
                        _alphaFunction = "BOUNCE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Sin:
                    {
                        _alphaFunction = "SIN";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutBack:
                    {
                        _alphaFunction = "EASE_OUT_BACK";
                        break;
                    }
                    default:
                    {
                        _alphaFunction = "DEFAULT";
                        break;
                    }
                }
            }

            foreach (var item in _visualDictionary.ToList())
            {
                if (item.Value.Name == target.Name)
                {
                    PropertyMap _animator = new PropertyMap();
                    if (_alphaFunction != null) { _animator.Add("alphaFunction", new PropertyValue(_alphaFunction)); }

                    PropertyMap _timePeriod = new PropertyMap();
                    _timePeriod.Add("duration", new PropertyValue((endTime - startTime) / 1000.0f));
                    _timePeriod.Add("delay", new PropertyValue(startTime / 1000.0f));
                    _animator.Add("timePeriod", new PropertyValue(_timePeriod));

                    StringBuilder sb = new StringBuilder(property);
                    sb[0] = (char)(sb[0] | 0x20);
                    string _str = sb.ToString();
                    if (_str == "position") { _str = "offset"; }

                    PropertyValue destVal = PropertyValue.CreateFromObject(destinationValue);

                    PropertyMap _transition = new PropertyMap();
                    _transition.Add("target", new PropertyValue(target.Name));
                    _transition.Add("property", new PropertyValue(_str));
                    if (initialValue != null)
                    {
                        PropertyValue initVal = PropertyValue.CreateFromObject(initialValue);
                        _transition.Add("initialValue", new PropertyValue(initVal));
                    }
                    _transition.Add("targetValue", destVal);
                    _transition.Add("animator", new PropertyValue(_animator));

                    _animateArray.Add(new PropertyValue(_transition));
                }
            }
        }

        /// <summary>
        /// Finishes to add a visual animation (transition) map and creates a transition animation.
        /// </summary>
        /// <returns>Animation instance.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Animation AnimateVisualAddFinish()
        {
            if (_animateArray == null || _animateArray.Empty())
            {
                Tizen.Log.Fatal("NUI", "animate visual property array is empty!");
                return null;
            }
            TransitionData _transitionData = new TransitionData(_animateArray);

            return this.CreateTransition(_transitionData);
        }

        /// <summary>
        /// temporary fix to pass TCT.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Animation VisualAnimate(Tizen.NUI.VisualAnimator visualMap)
        {
            foreach (var item in _visualDictionary.ToList())
            {
                if (item.Value.Name == visualMap.Target)
                {
                    TransitionData _transitionData = new TransitionData(visualMap.OutputVisualMap);
                    return this.CreateTransition(_transitionData);
                }
            }
            return null;
        }
        //temporary fix to pass TCT

        internal void UpdateVisual(int visualIndex, string visualName, VisualMap visualMap)
        {
            VisualBase visual = null;

            visual = VisualFactory.Instance.CreateVisual(visualMap.OutputVisualMap);
            visual.Name = visualName;
            visual.DepthIndex = visualMap.DepthIndex;

            RegisterVisual(visualIndex, visual);

            _visualDictionary[visualIndex] = visual;
            _tranformDictionary[visualIndex] = visualMap.OutputTransformMap;

            RelayoutRequest();
            NUILog.Debug("UpdateVisual() name=" + visualName);
        }

        static CustomView CreateInstance()
        {
            return new VisualView();
        }
    }
}