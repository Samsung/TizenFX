using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using static Tizen.NUI.Animation;

namespace Tizen.NUI
{
    /// <since_tizen> 5 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AnimationBehavior
    {
        private string _key = null;
        /// <since_tizen> 5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }

        private string _property = null;

        /// <since_tizen> 5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Property
        {
            get
            {
                return _property;
            }
            set
            {
                _property = value;
            }
        }

        private string _destValue = null;

        /// <since_tizen> 5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DestValue
        {
            get
            {
                return _destValue;
            }
            set
            {
                _destValue = value;
            }
        }

        private int _startTime = -1;

        /// <since_tizen> 5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        private int _endTime = -1;

        /// <since_tizen> 5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
