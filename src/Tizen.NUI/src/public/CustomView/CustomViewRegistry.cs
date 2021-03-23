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

using System.Reflection;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Adds this attribute to any property belonging to a view (control) you want to be scriptable from JSON.
    /// </summary>
    /// <remarks>
    /// Example:
    ///
    /// class MyView : public CustomView
    /// {
    ///  [ScriptableProperty()]
    ///  public int MyProperty
    ///  {
    ///   get
    ///   {
    ///     return _myProperty;
    ///   }
    ///   set
    ///   {
    ///    _myProperty = value;
    ///   }
    ///  }
    /// }
    ///
    /// Internally the following occurs for property registration ( this only occurs once per Type, not per Instance):
    ///
    /// - The controls static constructor should call ViewRegistry.Register() (only called once for the lifecycle of the app).
    /// - Within Register() the code will introspect the Controls properties, looking for the ScriptableProperty() attribute.
    /// - For every property with the ScriptableProperty() attribute, TypeRegistration.RegisterProperty is called.
    /// - TypeRegistration.RegisterProperty calls in to DALi C++ Code Dali::CSharpTypeRegistry::RegisterProperty().
    /// - DALi C++ now knows the existance of the property and will try calling SetProperty, if it finds the property in a JSON file (loaded using builder).
    ///
    ///  The DALi C# example:
    ///
    ///  class MyView : public CustomView
    ///  {
    ///
    ///    [ScriptableProperty()]
    ///    public double Hours
    ///    {
    ///     get { return seconds / 3600; }
    ///     set { seconds = value * 3600; }
    ///    }
    ///  }
    ///
    ///  Equivalent code in DALi C++:
    ///  in MyControl.h
    ///  class MyControl : public Control
    ///  {
    ///    struct Property
    ///    {
    ///      enum
    ///      {
    ///        HOURS =  Control::CONTROL_PROPERTY_END_INDEX + 1
    ///      }
    ///    }
    ///  }
    ///
    /// in MyControl-impl.cpp
    ///
    /// DALI_TYPE_REGISTRATION_BEGIN( Toolkit::MyControl, Toolkit::Control, Create );
    /// DALI_PROPERTY_REGISTRATION( Toolkit, MyControl, "Hours",  INTEGER, DISABLED                     )
    /// DALI_TYPE_REGISTRATION_END()
    /// </remarks>
    ///
    ///
    /// <since_tizen> 3 </since_tizen>
    [AttributeUsage(AttributeTargets.Property)]
    public class ScriptableProperty : System.Attribute
    {
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API9, Will be removed in API11, Please use Type")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "<Pending>")]
        public readonly ScriptableType type;

        /// <since_tizen> 3 </since_tizen>
        public ScriptableProperty(ScriptableType type = ScriptableType.Default)
        {
            this.type = type;
        }

        /// <summary>
        /// The enum of ScriptableType
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum ScriptableType
        {
            /// <summary>
            /// Read Writable, non-animatable property, event thread only.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Default,    // Read Writable, non-animatable property, event thread only
                        //  Animatable // Animatable property, Currently disabled, UK
        }

        /// <summary>
        /// ScriptableType. Read Writable, non-animatable property, event thread only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScriptableType Type => type;
    }

    /// <summary>
    /// View the Registry singleton.
    /// Used for registering controls and any scriptable properties they have (see ScriptableProperty).
    ///
    /// Internal Design from C# to C++
    ///
    /// - Each custom C# view should have it's static constructor called before any JSON file is loaded.
    /// Static constructors for a class will only run once ( they are run per control type, not per instance).
    /// Example of running a static constructor:
    ///      System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor (typeof(Spin).TypeHandle);
    /// Inside the static constructor the control should register it's type with the ViewRegistry
    /// For example:
    ///
    ///  static Spin()
    ///  {
    ///     ViewRegistry.Instance.Register(CreateInstance, typeof(Spin) );
    ///  }
    ///
    ///  The control should also provide a CreateInstance function, which gets passed to the ViewRegistry.
    ///  // Eventually it will be called if DALi Builderfinds a Spin control in a JSON file.
    ///  static CustomView CreateInstance()
    ///  {
    ///    return new Spin();
    ///  }
    ///
    ///
    ///
    /// The DALi C++ equivalent of this is
    ///
    ///  TypeRegistration mType( typeid(Toolkit::Spin), typeid(Toolkit::Control), CreateInstance );
    ///
    ///
    ///
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class CustomViewRegistry
    {

        /// <summary>
        /// Lookup table to match C# types to DALi types, used for the automatic property registration.
        /// </summary>
        private static readonly Dictionary<string, Tizen.NUI.PropertyType> daliPropertyTypeLookup
        = new Dictionary<string, Tizen.NUI.PropertyType>
        {
      { "float",   PropertyType.Float },
      { "int",     PropertyType.Integer },
      { "Int32",   PropertyType.Integer },
      { "Boolean", PropertyType.Boolean },
      { "string",  PropertyType.String },
      { "Vector2", PropertyType.Vector2 },
      { "Vector3", PropertyType.Vector3 },
      { "Vector4", PropertyType.Vector4 },
      { "Size",    PropertyType.Vector2 },
      { "Position",PropertyType.Vector3 },
      { "Color",   PropertyType.Vector4 },
      { "PropertyArray", PropertyType.Array },
      { "PropertyMap",   PropertyType.Map },
            //  { "Matrix3", PropertyType.MATRIX3 }, commented out until we need to use Matrices from JSON
            //  { "Matrix",  PropertyType.MATRIX },
        };

        /// <summary>
        /// ViewRegistry is a singleton.
        /// </summary>
        private static CustomViewRegistry instance = null;

        private CreateControlDelegate createCallback;
        private SetPropertyDelegate setPropertyCallback;
        private GetPropertyDelegate getPropertyCallback;
        private PropertyRangeManager propertyRangeManager;

        ///<summary>
        /// Maps the name of a custom view to a create instance function
        /// For example, given a string "Spin", we can get a function used to create the Spin View.
        ///</summary>
        private Dictionary<String, Func<CustomView>> constructorMap;

        private CustomViewRegistry()
        {
            createCallback = new CreateControlDelegate(CreateControl);
            getPropertyCallback = new GetPropertyDelegate(GetProperty);
            setPropertyCallback = new SetPropertyDelegate(SetProperty);

            constructorMap = new Dictionary<string, Func<CustomView>>();
            propertyRangeManager = new PropertyRangeManager();
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr CreateControlDelegate(IntPtr cPtrControlName);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr GetPropertyDelegate(IntPtr controlPtr, IntPtr propertyName);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void SetPropertyDelegate(IntPtr controlPtr, IntPtr propertyName, IntPtr propertyValue);

        /// <since_tizen> 3 </since_tizen>
        public static CustomViewRegistry Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomViewRegistry();
                }
                return instance;
            }
        }

        /// <summary>
        /// The function which registers a view and all it's scriptable properties with DALi's type registry.
        /// Means the view can be created or configured from a JSON script.
        ///
        /// The function uses introspection to scan a views C# properties, then selects the ones with
        ///[ScriptableProperty] attribute to be registered.
        /// Example of a Spin view registering itself:
        ///   static Spin()
        /// {
        ///   ViewRegistry registers control type with DALi type registry
        ///   also uses introspection to find any properties that need to be registered with type registry
        ///   ViewRegistry.Instance.Register(CreateInstance, typeof(Spin) );
        /// }
        ///
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when viewType is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public void Register(Func<CustomView> createFunction, System.Type viewType)
        {
            if (null == viewType)
            {
                throw new ArgumentNullException(nameof(viewType));
            }

            // add the mapping between the view name and it's create function
            constructorMap.Add(viewType.ToString(), createFunction);

            // Call into DALi C++ to register the control with the type registry
            TypeRegistration.RegisterControl(viewType.ToString(), createCallback);

            // Cycle through each property in the class
            foreach (System.Reflection.PropertyInfo propertyInfo in viewType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public))
            {
                if (propertyInfo.CanRead)
                {
                    IEnumerable<Attribute> ie_attrs = propertyInfo.GetCustomAttributes<Attribute>();
                    List<Attribute> li_attrs = new List<Attribute>(ie_attrs);
                    System.Attribute[] attrs = li_attrs.ToArray();

                    foreach (System.Attribute attr in attrs)
                    {
                        // If the Scriptable attribute exists, then register it with the type registry.
                        if (attr is ScriptableProperty)
                        {
                            NUILog.Debug("Got a DALi JSON scriptable property = " + propertyInfo.Name + ", of type " + propertyInfo.PropertyType.Name);

                            // first get the attribute type, ( default, or animatable)
                            ScriptableProperty scriptableProp = attr as ScriptableProperty;

                            // we get the start property index, based on the type and it's hierarchy, e.g. DateView (70,000)-> Spin (60,000) -> View (50,000)
                            int propertyIndex = propertyRangeManager.GetPropertyIndex(viewType.ToString(), viewType, scriptableProp.type);

                            // get the enum for the property type... E.g. registering a string property returns Tizen.NUI.PropertyType.String
                            Tizen.NUI.PropertyType propertyType = GetDaliPropertyType(propertyInfo.PropertyType.Name);

                            // Example   RegisterProperty("spin","maxValue", 50001, FLOAT, set, get );
                            // Native call to register the property
                            TypeRegistration.RegisterProperty(viewType.ToString(), propertyInfo.Name, propertyIndex, propertyType, setPropertyCallback, getPropertyCallback);
                        }
                    }
                    NUILog.Debug("property name = " + propertyInfo.Name);
                }
            }
        }

        /// <summary>
        /// Called directly from DALi C++ type registry to create a control (view) using no marshalling.
        /// </summary>
        /// <returns>Pointer to the control (views) handle.</returns>
        /// <param name="cPtrControlName">C pointer to the control (view) name.</param>
        private static IntPtr CreateControl(IntPtr cPtrControlName)
        {
            string controlName = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(cPtrControlName);

            NUILog.Debug("Create controlled called from C++ create a " + controlName);

            Func<CustomView> controlConstructor;

            // find the control constructor
            if (Instance.constructorMap.TryGetValue(controlName, out controlConstructor))
            {
                // Create the control
                CustomView newControl = controlConstructor();
                if (newControl != null)
                {
                    return newControl.GetPtrfromView();  // return pointer to handle
                }
                else
                {
                    return IntPtr.Zero;
                }
            }
            else
            {
                throw new global::System.InvalidOperationException("C# View not registered with ViewRegistry" + controlName);
            }
        }

        private static IntPtr GetProperty(IntPtr controlPtr, IntPtr propertyName)
        {
            string name = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(propertyName);
            return Instance.GetPropertyValue(controlPtr, name);
        }

        private static void SetProperty(IntPtr controlPtr, IntPtr propertyName, IntPtr propertyValue)
        {
            string name = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(propertyName);

            NUILog.Debug("SetControlProperty  called for:" + name);

            Instance.SetPropertyValue(controlPtr, name, propertyValue);
        }

        private Tizen.NUI.PropertyType GetDaliPropertyType(string cSharpTypeName)
        {
            Tizen.NUI.PropertyType daliType;
            if (daliPropertyTypeLookup.TryGetValue(cSharpTypeName, out daliType))
            {
                NUILog.Debug("mapped " + cSharpTypeName + " to dAli type " + daliType);

                return daliType;
            }
            else
            {
                NUILog.Debug("Failed to find a mapping between C# property" + cSharpTypeName + " and DALi type");

                return PropertyType.None;
            }
        }

        /// <summary>
        /// Gets a property value from a view.
        /// </summary>
        private IntPtr GetPropertyValue(IntPtr refObjectPtr, string propertyName)
        {
            // Get the C# control that maps to the C++ control
            View view = Registry.GetManagedBaseHandleFromRefObject(refObjectPtr) as View;
            if (view != null)
            {
                // call the get property function
                System.Object val = view.GetType().GetProperty(propertyName).GetAccessors()[0].Invoke(view, null);

                PropertyValue value = PropertyValue.CreateFromObject(val);
                IntPtr ptr = (IntPtr)PropertyValue.getCPtr(value);
                value.Dispose();

                return ptr;
            }
            else
            {
                return IntPtr.Zero;
            }
        }

        /// <summary>
        /// Sets a property value on a view.
        /// </summary>
        private void SetPropertyValue(IntPtr refObjectPtr, string propertyName, IntPtr propertyValuePtr)
        {
            // Get the C# control that maps to the C++ control
            NUILog.Debug("SetPropertyValue   refObjectPtr = {0:X}" + refObjectPtr);

            PropertyValue propValue = new PropertyValue(propertyValuePtr, false);

            // Get the C# control that maps to the C++ control
            View view = Registry.GetManagedBaseHandleFromRefObject(refObjectPtr) as View;
            if (view != null)
            {
                System.Reflection.PropertyInfo propertyInfo = view.GetType().GetProperty(propertyName);
                // We know the property name, we know it's type, we just need to convert from a DALi property value to native C# type
                System.Type type = propertyInfo.PropertyType;
                bool ok = false;

                if (type.Equals(typeof(Int32)))
                {
                    int value = 0;
                    ok = propValue.Get(out value);
                    if (ok)
                    {
                        propertyInfo.SetValue(view, value);
                    }
                }
                else if (type.Equals(typeof(bool)))
                {
                    bool value = false;
                    ok = propValue.Get(out value);
                    if (ok)
                    {
                        propertyInfo.SetValue(view, value);
                    }
                }
                else if (type.Equals(typeof(float)))
                {
                    float value = 0;
                    ok = propValue.Get(out value);
                    if (ok)
                    {
                        propertyInfo.SetValue(view, value);
                    }
                }
                else if (type.Equals(typeof(string)))
                {
                    string value = "";
                    ok = propValue.Get(out value);
                    if (ok)
                    {
                        propertyInfo.SetValue(view, value);
                    }
                }
                else if (type.Equals(typeof(Vector2)))
                {
                    Vector2 value = new Vector2();
                    ok = propValue.Get(value);
                    if (ok)
                    {
                        propertyInfo.SetValue(view, value);
                    }
                    value.Dispose();
                }
                else if (type.Equals(typeof(Vector3)))
                {
                    Vector3 value = new Vector3();
                    ok = propValue.Get(value);
                    if (ok)
                    {
                        propertyInfo.SetValue(view, value);
                    }
                    value.Dispose();
                }
                else if (type.Equals(typeof(Vector4)))
                {
                    Vector4 value = new Vector4();
                    ok = propValue.Get(value);

                    if (ok)
                    {
                        propertyInfo.SetValue(view, value);
                    }
                    value.Dispose();
                }
                else if (type.Equals(typeof(Position)))
                {
                    Position value = new Position();
                    ok = propValue.Get(value);
                    if (ok)
                    {
                        propertyInfo.SetValue(view, value);
                    }
                    value.Dispose();
                }
                else if (type.Equals(typeof(Size)))
                {
                    Size value = new Size();
                    ok = propValue.Get(value);
                    if (ok)
                    {
                        Size sz = new Size(value.Width, value.Height, value.Depth);
                        propertyInfo.SetValue(view, sz);
                        sz.Dispose();
                    };
                    value.Dispose();
                }
                else if (type.Equals(typeof(Color)))
                {
                    // Colors are stored as Vector4's in DALi
                    Color value = new Color();
                    ok = propValue.Get(value);
                    if (ok)
                    {
                        propertyInfo.SetValue(view, (Color)value);
                    };
                    value.Dispose();
                }
                else if (type.Equals(typeof(PropertyMap)))
                {
                    PropertyMap map = new PropertyMap();
                    ok = propValue.Get(map);
                    if (ok)
                    {
                        propertyInfo.SetValue(view, map);
                    }
                    map.Dispose();
                }
                else if (type.Equals(typeof(PropertyArray)))
                {
                    PropertyArray array = new PropertyArray();
                    ok = propValue.Get(array);
                    if (ok)
                    {
                        propertyInfo.SetValue(view, array);
                    }
                    array.Dispose();
                }
                else
                {
                    throw new global::System.InvalidOperationException("SetPropertyValue Unimplemented type for Property Value for " + type.FullName);
                }
                if (!ok)
                {
                    throw new global::System.InvalidOperationException("SetPropertyValue propValue.Get failed");
                }
            }
            else
            {
                throw new global::System.InvalidOperationException("failed to find the control to write a property to: cptr = " + refObjectPtr);
            }
            propValue.Dispose();
        }
    }
}
