/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

namespace Tizen.NUI
{
    /// <since_tizen> 5 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AnimationBehavior
    {
        private string key = null;
        /// <since_tizen> 5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }

        private string property = null;

        /// <since_tizen> 5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Property
        {
            get
            {
                return property;
            }
            set
            {
                property = value;
            }
        }

        private string destValue = null;

        /// <since_tizen> 5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DestValue
        {
            get
            {
                return destValue;
            }
            set
            {
                destValue = value;
            }
        }

        private int startTime = -1;

        /// <since_tizen> 5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        private int endTime = -1;

        /// <since_tizen> 5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
    }


    /// <summary>
    /// It is the container to contain the behaviors of Transition.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BehaviorContainer : List<AnimationBehavior>
    {
        private Dictionary<string, AnimationBehavior> behaviors = new Dictionary<string, AnimationBehavior>();

        /// <summary>
        /// The method for user to add behavior.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(object obj)
        {
            var behavior = obj as AnimationBehavior;

            if (null != behavior)
            {
                behaviors.Add(behavior.Key, behavior);
            }
        }

        /// <summary>
        /// The method for user to get the behavior by the key.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimationBehavior GetAnimationBehavior(string key)
        {
            AnimationBehavior behavior = null;
            behaviors.TryGetValue(key, out behavior);

            return behavior;
        }
    }

    /// <since_tizen> 5 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Transition : Animation
    {
        private string name;

        /// <since_tizen> 5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <since_tizen> 5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AnimateTo(View instance, string behaviorKey)
        {
            AnimationBehavior behavior = Behaviors?.GetAnimationBehavior(behaviorKey);

            if (null != instance && null != behavior)
            {
                var elementType = instance.GetType();
                PropertyInfo propertyInfo = elementType.GetProperties().FirstOrDefault(fi => fi.Name == behavior.Property);

                if (propertyInfo != null)
                {
                    object destinationValue = ConvertTo(behavior.DestValue, propertyInfo.PropertyType);

                    if (destinationValue != null)
                    {
                        if (0 <= behavior.StartTime)
                        {
                            AnimateTo(instance, behavior.Property, destinationValue, behavior.StartTime, behavior.EndTime);
                        }
                        else
                        {
                            AnimateTo(instance, behavior.Property, destinationValue);
                        }
                    }
                }
            }
            else
            {
                throw new XamlParseException(string.Format("Behaviors don't have key {0}", behaviorKey), new XmlLineInfo());
            }
        }

        /// <since_tizen> 5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AnimateBy(View instance, string behaviorKey)
        {
            AnimationBehavior behavior = Behaviors?.GetAnimationBehavior(behaviorKey);

            if (null != instance && null != behavior)
            {
                var elementType = instance.GetType();
                PropertyInfo propertyInfo = elementType.GetProperties().FirstOrDefault(fi => fi.Name == behavior.Property);

                if (propertyInfo != null)
                {
                    object destinationValue = ConvertTo(behavior.DestValue, propertyInfo.PropertyType);

                    if (destinationValue != null)
                    {
                        if (0 <= behavior.StartTime)
                        {
                            AnimateBy(instance, behavior.Property, destinationValue, behavior.StartTime, behavior.EndTime);
                        }
                        else
                        {
                            AnimateBy(instance, behavior.Property, destinationValue);
                        }
                    }
                }
            }
            else
            {
                throw new XamlParseException(string.Format("Behaviors don't have key {0}", behaviorKey), new XmlLineInfo());
            }
        }

        /// <since_tizen> 5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BehaviorContainer Behaviors
        {
            get;
        } = new BehaviorContainer();
    }
}
