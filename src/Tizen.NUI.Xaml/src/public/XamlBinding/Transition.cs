using System.ComponentModel;
using System;
using System.Collections.Generic;
using Tizen.NUI.Xaml.Forms.BaseComponents;
using System.Reflection;
using System.Linq;
using Tizen.NUI.Xaml;
using System.Globalization;
using Tizen.NUI.Xaml.Internals;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AnimationBehavior
    {
        private string _key = null;
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Transition : Tizen.NUI.Xaml.Forms.BaseHandle
    {
        private Tizen.NUI.Animation _animation;
        internal Tizen.NUI.Animation animation
        {
            get
            {
                if (null == _animation)
                {
                    _animation = handleInstance as Tizen.NUI.Animation;
                }

                return _animation;
            }
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Transition() : this(new Tizen.NUI.Animation())
        {
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Transition(int durationMilliSeconds) : this(new Tizen.NUI.Animation(durationMilliSeconds))
        {
        }

        internal Transition(Tizen.NUI.Animation nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler Finished
        {
            add
            {
                animation.Finished += value;
            }
            remove
            {
                animation.Finished -= value;
            }
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ProgressReached
        {
            add
            {
                animation.ProgressReached += value;
            }
            remove
            {
                animation.ProgressReached -= value;
            }
        }

        /// <summary>
        /// Gets or sets the duration in milliseconds of the animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Duration
        {
            set
            {
                animation.Duration = value;
            }
            get
            {
                return animation.Duration;
            }
        }

        /// <summary>
        ///  Gets or sets the default alpha function for the animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AlphaFunction DefaultAlphaFunction
        {
            set
            {
                animation.DefaultAlphaFunction = value;
            }
            get
            {
                return animation.DefaultAlphaFunction;
            }
        }

        /// <summary>
        /// Queries the state of the animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.Animation.States State
        {
            get
            {
                return animation.State;
            }
        }

        /// <summary>
        /// Set: Enables looping for a specified number of repeats. A zero is the same as Looping = true; i.e., repeat forever.<br />
        /// This property resets the looping value and should not be used with the Looping property.<br />
        /// Setting this parameter does not cause the animation to Play().<br />
        /// Get: Gets the loop count. A zero is the same as Looping = true; i.e., repeat forever.<br />
        /// The loop count is initially 1 for play once.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int LoopCount
        {
            set
            {
                animation.LoopCount = value;
            }
            get
            {
                return animation.LoopCount;
            }
        }

        /// <summary>
        /// Gets or sets the status of whether the animation will loop.<br />
        /// This property resets the loop count and should not be used with the LoopCount property.<br />
        /// Setting this parameter does not cause the animation to Play().<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Looping
        {
            set
            {
                animation.Looping = value;
            }
            get
            {
                return animation.Looping;
            }
        }

        /// <summary>
        /// Gets or sets the end action of the animation.<br />
        /// This action is performed when the animation ends or if it is stopped.<br />
        /// The default end action is cancel.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.Animation.EndActions EndAction
        {
            set
            {
                animation.EndAction = value;
            }
            get
            {
                return animation.EndAction;
            }
        }

        /// <summary>
        /// Gets the current loop count.<br />
        /// A value 0 indicating the current loop count when looping.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int CurrentLoop
        {
            get
            {
                return animation.CurrentLoop;
            }
        }

        /// <summary>
        /// Gets or sets the disconnect action.<br />
        /// If any of the animated property owners are disconnected from the stage while the animation is being played, then this action is performed.<br />
        /// The default action is cancel.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.Animation.EndActions DisconnectAction
        {
            set
            {
                animation.DisconnectAction = value;
            }
            get
            {
                return animation.DisconnectAction;
            }
        }


        /// <summary>
        /// Gets or sets the progress of the animation.<br />
        /// The animation will play (or continue playing) from this point.<br />
        /// The progress must be in the 0-1 interval or in the play range interval if defined<br />
        /// otherwise, it will be ignored.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float CurrentProgress
        {
            set
            {
                animation.CurrentProgress = value;
            }
            get
            {
                return animation.CurrentProgress;
            }
        }

        /// <summary>
        /// Gets or sets specificifications of a speed factor for the animation.<br />
        /// The speed factor is a multiplier of the normal velocity of the animation.<br />
        /// Values between [0, 1] will slow down the animation and values above one will speed up the animation.<br />
        /// It is also possible to specify a negative multiplier to play the animation in reverse.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float SpeedFactor
        {
            set
            {
                animation.SpeedFactor = value;
            }
            get
            {
                return animation.SpeedFactor;
            }
        }

        /// <summary>
        /// Gets or sets the playing range.<br />
        /// Animation will play between the values specified. Both values (range.x and range.y ) should be between 0-1,
        /// otherwise they will be ignored. If the range provided is not in proper order (minimum, maximum ), it will be reordered.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector2 PlayRange
        {
            set
            {
                animation.PlayRange = value;
            }
            get
            {
                return animation.PlayRange;
            }
        }


        /// <summary>
        /// Gets or sets the progress notification marker which triggers the ProgressReachedSignal.<br />
        /// Percentage of animation progress should be greater than 0 and less than 1, for example, 0.3 for 30% <br />
        /// One notification can be set on each animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ProgressNotification
        {
            set
            {
                animation.ProgressNotification = value;
            }
            get
            {
                return animation.ProgressNotification;
            }
        }

        private string[] _properties = null;
        private string[] _destValue = null;
        private int[] _startTime = null;
        private int[] _endTime = null;

        /// <summary>
        /// Gets or sets the properties of the animation.
        /// </summary>
        public string[] Properties
        {
            get
            {
                return _properties;
            }
            set
            {
                _properties = value;
            }
        }

        /// <summary>
        /// Gets or sets the destination value for each property of the animation.
        /// </summary>
        public string[] DestValue
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

        /// <summary>
        /// Gets or sets the start time for each property of the animation.
        /// </summary>
        public int[] StartTime
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
        /// Gets or sets the end time for each property of the animation.
        /// </summary>
        public int[] EndTime
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
        /// Downcasts a handle to animation handle.<br />
        /// If handle points to an animation object, the downcast produces a valid handle.<br />
        /// If not, the returned handle is left uninitialized.<br />
        /// </summary>
        /// <param name="handle">Handle to an object.</param>
        /// <returns>Handle to an animation object or an uninitialized handle.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Transition DownCast(Tizen.NUI.BaseHandle handle)
        {
            return Tizen.NUI.Xaml.Forms.BaseHandle.GetHandle(Tizen.NUI.Animation.DownCast(handle)) as Transition;
        }

        /// <summary>
        /// Stops the animation.
        /// </summary>
        /// <param name="action">The end action can be set.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Stop(Tizen.NUI.Animation.EndActions action)
        {
            animation.Stop(action);
        }

        /// <summary>
        /// Plays the animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Play()
        {
            animation.Play();
        }

        /// <summary>
        /// Pauses the animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Pause()
        {
            animation.Pause();
        }

        /// <summary>
        /// Stops the animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Stop()
        {
            animation.Stop();
        }

        /// <summary>
        /// Clears the animation.<br />
        /// This disconnects any objects that were being animated, effectively stopping the animation.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Clear()
        {
            animation.Clear();
        }

        private string name;

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        private Dictionary<string, AnimationBehavior> behaviors = new Dictionary<string, AnimationBehavior>();

        public AnimationBehavior[] Behaviors
        {
            set
            {
                if (null != value)
                {
                    foreach (AnimationBehavior behavior in value)
                    {
                        behaviors.Add(behavior.Key, behavior);
                    }
                }
            }
        }

        public void AnimateTo(View instance, string behaviorKey)
        {
            AnimationBehavior behavior = null;
            behaviors.TryGetValue(behaviorKey, out behavior);

            if (null != behavior)
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
                            animation.AnimateTo(instance.view, behavior.Property, destinationValue, behavior.StartTime, behavior.EndTime);
                        }
                        else
                        {
                            animation.AnimateTo(instance.view, behavior.Property, destinationValue);
                        }
                    }
                }
            }
            else
            {
                throw new XamlParseException(string.Format("Behaviors don't have key {0}", behaviorKey), new XmlLineInfo());
            }
        }

        public void AnimateBy(View instance, string behaviorKey)
        {
            AnimationBehavior behavior = null;
            behaviors.TryGetValue(behaviorKey, out behavior);

            if (null != behavior)
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
                            animation.AnimateBy(instance.view, behavior.Property, destinationValue, behavior.StartTime, behavior.EndTime);
                        }
                        else
                        {
                            animation.AnimateBy(instance.view, behavior.Property, destinationValue);
                        }
                    }
                }
            }
            else
            {
                throw new XamlParseException(string.Format("Behaviors don't have key {0}", behaviorKey), new XmlLineInfo());
            }
        }

        internal object ConvertTo(object value, Type toType)
        {
            Func<object> getConverter = () =>
            {
                var converterTypeName = TypeConversionExtensions.GetConverterName(toType);

                if (null == converterTypeName)
                {
                    return null;
                }

                Type convertertype = Type.GetType(converterTypeName);
                return Activator.CreateInstance(convertertype);
            };

            return ConvertTo(value, toType, getConverter);
        }

        internal object ConvertTo(object value, Type toType, Func<object> getConverter)
        {
            if (value == null)
                return null;

            var str = value as string;
            if (str != null)
            {
                //If there's a [TypeConverter], use it
                object converter = getConverter?.Invoke();
                var xfTypeConverter = converter as TypeConverter;
                if (xfTypeConverter != null)
                    return value = xfTypeConverter.ConvertFromInvariantString(str);
                var converterType = converter?.GetType();
                if (converterType != null)
                {
                    var convertFromStringInvariant = converterType.GetRuntimeMethod("ConvertFromInvariantString",
                        new[] { typeof(string) });
                    if (convertFromStringInvariant != null)
                        return value = convertFromStringInvariant.Invoke(converter, new object[] { str });
                }

                //If the type is nullable, as the value is not null, it's safe to assume we want the built-in conversion
                if (toType.GetTypeInfo().IsGenericType && toType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    toType = Nullable.GetUnderlyingType(toType);

                //Obvious Built-in conversions
                if (toType.GetTypeInfo().IsEnum)
                    return Enum.Parse(toType, str, true);
                if (toType == typeof(SByte))
                    return SByte.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Int16))
                    return Int16.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Int32))
                    return Int32.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Int64))
                    return Int64.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Byte))
                    return Byte.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(UInt16))
                    return UInt16.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(UInt32))
                    return UInt32.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(UInt64))
                    return UInt64.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Single))
                    return Single.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Double))
                    return Double.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Boolean))
                    return Boolean.Parse(str);
                if (toType == typeof(TimeSpan))
                    return TimeSpan.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(DateTime))
                    return DateTime.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Char))
                {
                    char c = '\0';
                    Char.TryParse(str, out c);
                    return c;
                }
                if (toType == typeof(String) && str.StartsWith("{}", StringComparison.Ordinal))
                    return str.Substring(2);
                if (toType == typeof(String))
                    return value;
                if (toType == typeof(Decimal))
                    return Decimal.Parse(str, CultureInfo.InvariantCulture);
            }

            //if the value is not assignable and there's an implicit conversion, convert
            if (value != null && !toType.IsAssignableFrom(value.GetType()))
            {
                var opImplicit = GetImplicitConversionOperator(value.GetType(), value.GetType(), toType)
                                 ?? GetImplicitConversionOperator(toType, value.GetType(), toType);
                //var opImplicit = value.GetType().GetImplicitConversionOperator(fromType: value.GetType(), toType: toType)
                //                ?? toType.GetImplicitConversionOperator(fromType: value.GetType(), toType: toType);

                if (opImplicit != null)
                {
                    value = opImplicit.Invoke(null, new[] { value });
                    return value;
                }
            }

            var nativeValueConverterService = DependencyService.Get<INativeValueConverterService>();

            object nativeValue = null;
            if (nativeValueConverterService != null && nativeValueConverterService.ConvertTo(value, toType, out nativeValue))
                return nativeValue;

            return value;
        }

        internal string GetTypeConverterTypeName(IEnumerable<CustomAttributeData> attributes)
        {
            var converterAttribute =
                attributes.FirstOrDefault(cad => TypeConverterAttribute.TypeConvertersType.Contains(cad.AttributeType.FullName));
            if (converterAttribute == null)
                return null;
            if (converterAttribute.ConstructorArguments[0].ArgumentType == typeof(string))
                return (string)converterAttribute.ConstructorArguments[0].Value;
            if (converterAttribute.ConstructorArguments[0].ArgumentType == typeof(Type))
                return ((Type)converterAttribute.ConstructorArguments[0].Value).AssemblyQualifiedName;
            return null;
        }

        internal MethodInfo GetImplicitConversionOperator(Type onType, Type fromType, Type toType)
        {
#if NETSTANDARD1_0
                    var mi = onType.GetRuntimeMethod("op_Implicit", new[] { fromType });
#else
            var bindingFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;
            var mi = onType.GetMethod("op_Implicit", bindingFlags, null, new[] { fromType }, null);
#endif
            if (mi == null) return null;
            if (!mi.IsSpecialName) return null;
            if (!mi.IsPublic) return null;
            if (!mi.IsStatic) return null;
            if (!toType.IsAssignableFrom(mi.ReturnType)) return null;

            return mi;
        }
    }
}