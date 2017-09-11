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

namespace Tizen.NUI.BaseComponents
{
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A visual view control for user add any visual to it.
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
    public class VisualView : CustomView
    {
        //private LinkedList<VisualBase> _visualList = null;
        private Dictionary<int, VisualBase> _visualDictionary = null;
        private Dictionary<int, PropertyMap> _tranformDictionary = null;
        private PropertyArray _animateArray = null;

        static CustomView CreateInstance()
        {
            return new VisualView();
        }

        // static constructor registers the control type (for user can add kinds of visuals to it)
        static VisualView()
        {
            // ViewRegistry registers control type with DALi type registery
            // also uses introspection to find any properties that need to be registered with type registry
            CustomViewRegistry.Instance.Register(CreateInstance, typeof(VisualView));
        }

        public VisualView() : base(typeof(VisualView).FullName, CustomViewBehaviour.ViewBehaviourDefault)
        {
        }

        /// <summary>
        /// Override the parent method.
        /// </summary>
        public override void OnInitialize()
        {
            //Initialize empty
            _visualDictionary = new Dictionary<int, VisualBase>();
            _tranformDictionary = new Dictionary<int, PropertyMap>();
            _animateArray = new PropertyArray();
        }

        /// <summary>
        /// Add or update a visual to visual view.
        /// </summary>
        /// <param name="visualName"> The name of visual to add. If add a existed visual name, the visual will be replaced. </param>
        /// <param name="visualMap"> The property map of visual to create.  </param>
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
        /// Remove a visual by name.
        /// </summary>
        /// <param name="visualName"> The name of visual to remove. </param>
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
        ///  Get the total number of Visuals which are added by users
        /// </summary>
        public int NumberOfVisuals
        {
            get
            {
                return _visualDictionary.Count;
            }
        }

        /// <summary>
        /// Remove all visuals of visual view.
        /// </summary>
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
        /// Override method of OnRelayout() for CustomView class.<br>
        /// Called after the size negotiation has been finished for this control.<br>
        /// The control is expected to assign this given size to itself/its children.<br>
        /// Should be overridden by derived classes if they need to layout actors differently after certain operations like add or remove actors, resize or after changing specific properties.<br>
        /// </summary>
        /// <remarks>As this function is called from inside the size negotiation algorithm, you cannot call RequestRelayout (the call would just be ignored)</remarks>
        /// <param name="size">The allocated size</param>
        /// <param name="container">The control should add actors to this container that it is not able to allocate a size for.</param>
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            foreach (var item in _visualDictionary)
            {
                item.Value.SetTransformAndSize(_tranformDictionary[item.Key], size);
                EnableVisual(item.Key, true);
            }
        }

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

        /// <summary>
        /// Create visual animation (transition) with the input parameters.
        /// </summary>
        /// <param name="target"> The visual map to animation.</param>
        /// <param name="property"> The property of visual to animation.</param>
        /// <param name="destinationValue"> The destination value of property after animation.</param>
        /// <param name="startTime"> The start time of visual animation.</param>
        /// <param name="endTime"> The end time of visual animation.</param>
        /// <param name="alphaFunction"> The alpha function of visual animation</param>
        /// <param name="initialValue"> The initial property value of visual animation </param>
        /// <returns>Animation instance</returns>
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
                    if ( _alphaFunction != null) {_animator.Add("alphaFunction", new PropertyValue(_alphaFunction));}

                    PropertyMap _timePeriod = new PropertyMap();
                    _timePeriod.Add("duration", new PropertyValue((endTime - startTime) / 1000.0f));
                    _timePeriod.Add("delay", new PropertyValue(startTime / 1000.0f));
                    _animator.Add("timePeriod", new PropertyValue(_timePeriod));

                    string _str1 = property.Substring(0, 1);
                    string _str2 = property.Substring(1);
                    string _str = _str1.ToLower() + _str2;
                    if (_str == "position") {_str = "offset";}

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
        /// Add group visual animation (transition) map with the input parameters.
        /// </summary>
        /// <param name="target"> The visual map to animation.</param>
        /// <param name="property"> The property of visual to animation.</param>
        /// <param name="destinationValue"> The destination value of property after animation.</param>
        /// <param name="startTime"> The start time of visual animation.</param>
        /// <param name="endTime"> The end time of visual animation.</param>
        /// <param name="alphaFunction"> The alpha function of visual animation</param>
        /// <param name="initialValue"> The initial property value of visual animation </param>
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
                    if ( _alphaFunction != null) {_animator.Add("alphaFunction", new PropertyValue(_alphaFunction));}

                    PropertyMap _timePeriod = new PropertyMap();
                    _timePeriod.Add("duration", new PropertyValue((endTime - startTime) / 1000.0f));
                    _timePeriod.Add("delay", new PropertyValue(startTime / 1000.0f));
                    _animator.Add("timePeriod", new PropertyValue(_timePeriod));

                    string _str1 = property.Substring(0, 1);
                    string _str2 = property.Substring(1);
                    string _str = _str1.ToLower() + _str2;
                    if (_str == "position") {_str = "offset";}

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
        /// Finish to add Visual animation (transition) map and create transition animation.
        /// </summary>
        /// <returns>Animation instance</returns>
        public Animation AnimateVisualAddFinish()
        {
            if ( _animateArray == null || _animateArray.Empty())
            {
                Tizen.Log.Fatal("NUI", "animate visual property array is empty!");
                return null;
            }
            TransitionData _transitionData = new TransitionData(_animateArray);

            return this.CreateTransition(_transitionData);
        }


        //temporary fix to pass TCT
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

    }
}
