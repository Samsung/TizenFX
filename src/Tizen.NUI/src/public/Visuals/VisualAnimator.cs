/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using System.Text;

namespace Tizen.NUI
{
    //temporary fix for TCT
    /// <summary>
    /// A class encapsulating the property map of the transition data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class VisualAnimator : VisualMap
    {
        private string _alphaFunction = null;
        private int _startTime = 0;
        private int _endTime = 0;
        private string _target = null;
        private string _propertyIndex = null;
        private object _destinationValue = null;

        /// <summary>
        /// Create VisualAnimator object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public VisualAnimator() : base()
        {
        }

        /// <summary>
        /// Sets and Gets the AlphaFunction of this transition.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AlphaFunction.BuiltinFunctions AlphaFunction
        {
            get
            {
                return _alphaFunction.GetValueByDescription<AlphaFunction.BuiltinFunctions>();
            }
            set
            {
                _alphaFunction = value.GetDescription();
            }
        }

        /// <summary>
        /// Sets and Gets the StartTime of this transition.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        /// <summary>
        /// Sets and Gets the EndTime of this transition.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        /// <summary>
        /// Sets and Gets the Target of this transition.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }

        /// <summary>
        /// Sets and Gets the PropertyIndex of this transition.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string PropertyIndex
        {
            get
            {
                return _propertyIndex;
            }
            set
            {
                _propertyIndex = value;
            }
        }

        /// <summary>
        /// Sets and Gets the DestinationValue of this transition.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public object DestinationValue
        {
            get
            {
                return _destinationValue;
            }
            set
            {
                _destinationValue = value;
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            PropertyMap _animator = new PropertyMap();
            _animator.Add("alphaFunction", new PropertyValue(_alphaFunction));

            PropertyMap _timePeriod = new PropertyMap();
            _timePeriod.Add("duration", new PropertyValue((_endTime - _startTime) / 1000.0f));
            _timePeriod.Add("delay", new PropertyValue(_startTime / 1000.0f));
            _animator.Add("timePeriod", new PropertyValue(_timePeriod));

            StringBuilder sb = new StringBuilder(_propertyIndex);
            sb[0] = (char)(sb[0] | 0x20);
            string _str = sb.ToString();

            PropertyValue val = PropertyValue.CreateFromObject(_destinationValue);

            PropertyMap _transition = new PropertyMap();
            _transition.Add("target", new PropertyValue(_target));
            _transition.Add("property", new PropertyValue(_str));
            _transition.Add("targetValue", val);
            _transition.Add("animator", new PropertyValue(_animator));

            _outputVisualMap = _transition;
            base.ComposingPropertyMap();
        }
    }
    //temporary fix for TCT
}
