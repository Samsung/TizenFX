

using System.Reflection;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// The helper class for calculating what property indexes should be assigned to the C# View (view) classes.
    /// </summary>
    internal class PropertyRangeManager
    {
        private Dictionary<String, PropertyRange> _propertyRange;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.NUI.PropertyRangeManager"/> class.
        /// </summary>
        public PropertyRangeManager()
        {
            _propertyRange = new Dictionary<String, PropertyRange>();
        }

        /// <summary>
        /// Only called if a view has scriptable properties.
        /// </summary>
        private PropertyRange RegisterView(string viewName, System.Type viewType)
        {
            PropertyRange range;

            if (_propertyRange.TryGetValue(viewName, out range))
            {
                // already registered
                return range;
            }

            // Find out the event and animatable start indexes for the type
            range = new PropertyRange();

            GetPropertyStartRange(viewType, ref range);

            // add it to our dictionary
            _propertyRange.Add(viewName, range);

            return range;

        }

        /// <summary>
        /// Gets the index of the property.
        /// Each property has to have unique index for this view type.
        /// </summary>
        /// <returns>The property index.</returns>
        /// <param name="viewName">The view name.</param>
        /// <param name="viewType">The view type.</param>
        /// <param name="type">Type.</param>
        public int GetPropertyIndex(string viewName, System.Type viewType, ScriptableProperty.ScriptableType type)
        {

            PropertyRange range;

            if (!_propertyRange.TryGetValue(viewName, out range))
            {
                // view not found, register it now
                range = RegisterView(viewName, viewType);
            }

            int index = range.GetNextFreePropertyIndex(type);

            // update the dictionary
            _propertyRange[viewName] = range;

            return index;

        }

        ///<summary>
        /// We calculate the start property indices, based on the type and it's class hierarchy, for example, DateView (70,000)- > Spin (60,000) -> View (50,000).
        /// </summary>
        private void GetPropertyStartRange(System.Type viewType, ref PropertyRange range)
        {
            const int maxCountPerDerivation = 1000; // For child and animtable properties we use a gap of 1000 between each
                                                    // views property range in the heirachy

            // custom views start there property index, at view_PROPERTY_END_INDEX
            // we add 1000, just incase View class (our C# custom view base) starts using scriptable properties
            int startEventPropertyIndex = (int)View.PropertyRange.CONTROL_PROPERTY_END_INDEX + maxCountPerDerivation;

            // for animatable properties current range starts at ANIMATABLE_PROPERTY_REGISTRATION_START_INDEX,
            // we add 1000, just incase View class starts using animatable properties
            int startAnimatablePropertyIndex = (int)Tizen.NUI.PropertyRanges.ANIMATABLE_PROPERTY_REGISTRATION_START_INDEX + maxCountPerDerivation;

            while (viewType.GetTypeInfo().BaseType.Name != "CustomView")   // custom view is our C# view base class. we don't go any deeper.
            {
                // for every base class increase property start index
                startEventPropertyIndex += (int)Tizen.NUI.PropertyRanges.DEFAULT_PROPERTY_MAX_COUNT_PER_DERIVATION; // DALi uses 10,000
                startAnimatablePropertyIndex += maxCountPerDerivation;
                NUILog.Debug("getStartPropertyIndex =  " + viewType.Name + "current index " + startEventPropertyIndex);
                viewType = viewType.GetTypeInfo().BaseType;
            }

            range.startEventIndex = startEventPropertyIndex;
            range.lastUsedEventIndex = startEventPropertyIndex;

            range.startAnimationIndex = startAnimatablePropertyIndex;
            range.lastUsedAnimationIndex = startAnimatablePropertyIndex;

        }

        /// <since_tizen> 3 </since_tizen>
        public struct PropertyRange
        {

            /// <since_tizen> 3 </since_tizen>
            public int GetNextFreePropertyIndex(ScriptableProperty.ScriptableType type)
            {
                if (type == ScriptableProperty.ScriptableType.Default)
                {
                    lastUsedEventIndex++;
                    return lastUsedEventIndex;
                }
                else
                {
                    lastUsedAnimationIndex++;
                    return lastUsedAnimationIndex;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public int startEventIndex;        // start of the property range
            /// <since_tizen> 3 </since_tizen>
            public int lastUsedEventIndex;     // last used of the property index

            /// <since_tizen> 3 </since_tizen>
            public int startAnimationIndex;    // start of the property range
            /// <since_tizen> 3 </since_tizen>
            public int lastUsedAnimationIndex; // last used of the property index
        };
    }
}
