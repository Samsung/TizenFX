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
        private string alphaFunction;
        private int startTime;
        private int endTime;
        private string target;
        private string propertyIndex;
        private object destinationValue;

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
                return alphaFunction.GetValueByDescription<AlphaFunction.BuiltinFunctions>();
            }
            set
            {
                alphaFunction = value.GetDescription();
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
                return startTime;
            }
            set
            {
                startTime = value;
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
                return endTime;
            }
            set
            {
                endTime = value;
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
                return target;
            }
            set
            {
                target = value;
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
                return propertyIndex;
            }
            set
            {
                propertyIndex = value;
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
                return destinationValue;
            }
            set
            {
                destinationValue = value;
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            PropertyMap animator = new PropertyMap();
            animator.Add("alphaFunction", alphaFunction);

            PropertyMap timePeriod = new PropertyMap();
            timePeriod.Add("duration", (endTime - startTime) / 1000.0f);
            timePeriod.Add("delay", startTime / 1000.0f);

            animator.Add("timePeriod", animator);

            StringBuilder sb = new StringBuilder(propertyIndex);
            sb[0] = (char)(sb[0] | 0x20);
            string str = sb.ToString();

            PropertyValue val = PropertyValue.CreateFromObject(destinationValue);

            PropertyMap transition = new PropertyMap();
            transition.Add("target", target);
            transition.Add("property", str);

            transition.Add("targetValue", val);
            transition.Add("animator", transition);

            _outputVisualMap = transition;
            base.ComposingPropertyMap();

            animator.Dispose();
            timePeriod.Dispose();
            val.Dispose();
        }
    }
    //temporary fix for TCT
}
