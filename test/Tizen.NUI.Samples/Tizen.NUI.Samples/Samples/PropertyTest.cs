using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Samples
{

    public class PropertyTest : IExample
    {
        private View target;
        private View root;
        private Dictionary<Type, List<object>> testing = new Dictionary<Type, List<object>>
        {
            {typeof(bool), new List<object>() { true, false }},
            {typeof(int), new List<object>() { -99999, -1234, 12345678, -987654321, 987654321}},
            {typeof(float), new List<object>() { -99999.99999f, -1234.1234f, 0f, 123456.123456f, -987654321.123456789f}},
            {typeof(double), new List<object>() { -99999999.99999999f, -1234567890.1234567890f, 0f, 12345699999.12345699999f, -98765432111.123456789f}},
            {typeof(string), new List<object>() { "test", "!@#$%", "][]=-"}},
            {typeof(Tizen.NUI.BaseComponents.ControlState), new List<object>() {ControlState.All, ControlState.Normal, ControlState.Pressed, ControlState.Disabled, ControlState.DisabledFocused}},
            {typeof(Tizen.NUI.Color), new List<object>() {Color.White, Color.AquaMarine, Color.Red, Color.Cyan, Color.Chocolate}},
            {typeof(Tizen.NUI.Rectangle), new List<object>() {new Tizen.NUI.Rectangle(1, 2, 3, 4), new Tizen.NUI.Rectangle(100, -100, -900, 1000), new Tizen.NUI.Rectangle(1234, -94321, 9999, 54321)}}

        };

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            target = new View()
            {
                Size2D = new Size2D(100, 100),
            };

            var proInfos = target.GetType().GetProperties();
            foreach (var prop in proInfos)
            {

                var hasEditorBrowsableNever = Attribute.GetCustomAttribute(prop, typeof(EditorBrowsableAttribute)) is EditorBrowsableAttribute attr && attr.State == EditorBrowsableState.Never;

                var hiddenOrPublic = hasEditorBrowsableNever ? "[Hidden]" : "[Public]";
                Tizen.Log.Debug("NUI", $"{hiddenOrPublic} Property Name: {prop.Name}, Type: {prop.PropertyType}, CanRead: {prop.CanRead}, CanWrite: {prop.CanWrite}, get: {prop.GetValue(target)}");

                if (!prop.CanRead || !prop.CanWrite) continue;

                if (testing.TryGetValue(prop.PropertyType, out var testVals))
                {
                    bool res = true;
                    foreach (var val in testVals)
                    {
                        prop.SetValue(target, val);
                        var got = prop.GetValue(target);
                        bool resSub = IsSame(val, got, prop.PropertyType);
                        res &= resSub;
                    }
                    string result = res ? "OK" : "BAD";
                    Tizen.Log.Debug("NUI", $"Testing {prop.Name} result={result}");
                    Tizen.Log.Debug("NUI", $"==================");
                }
                else
                {
                    Tizen.Log.Debug("NUI", $"No Testing {prop.Name} {prop.PropertyType} just skip!\n");
                    Tizen.Log.Debug("NUI", $"==================");
                    continue;
                }
            }
            Tizen.Log.Debug("NUI", $"proInfos len:{proInfos.Length}");

            root = new View();

            root.Add(target);
            window.Add(root);

            var tl1 = new TextLabel
            {
                Position = new Position(400, 400),
                Size = new Size(600, 100),
                Text = "property test"
            };

            root.Add(target);

            var tl2 = new TextLabel
            {
                Position = new Position(400, 400),
                Size = new Size(600, 100),
                Text = "please check the log"
            };
            root.Add(tl2);
        }

        private static object CreateRandomValueForProp(Type propType)
        {
            if (propType == typeof(string)) return RandomString();
            else if (propType.IsValueType)
            {
                var underlying = propType.UnderlyingSystemType;
                Tizen.Log.Debug("NUI", $"system type: {underlying}");
                return Activator.CreateInstance(propType);
            }
            else
            {
                //Todo: for class type properties, need to be added.
                return null;
            }
        }

        private static string RandomString() => Guid.NewGuid().ToString();

        private static bool IsSame(object a, object b, Type t)
        {
            if (a.GetType() != b.GetType()) { return false; }

            if (a is IEquatable<object> equatableA && b is IEquatable<object> equatableB)
            {
                return equatableA.Equals(equatableB);
            }
            else
            {
                if (a.GetType().IsValueType)
                {
                    //Tizen.Log.Debug("NUI", $"a:{a}, b:{b}");
                    return a.Equals(b);
                }
                else
                {
                    if (a is Tizen.NUI.Color a1 && b is Tizen.NUI.Color b1)
                    {
                        // var aa = a as Tizen.NUI.Color;
                        // var bb = b as Tizen.NUI.Color;
                        // var aa = global::System.Convert.ChangeType(a, t);
                        // var bb = global::System.Convert.ChangeType(b, t);
                        if (Object.ReferenceEquals(a1, b1)) { return true; }
                        if (a1 == b1) { return true; }
                    }
                    else if (a is Tizen.NUI.Rectangle a2 && b is Tizen.NUI.Rectangle b2)
                    {
                        if (Object.ReferenceEquals(a2, b2)) { return true; }
                        if (a2 == b2) { return true; }
                    }
                    else
                    {
                        //Tizen.Log.Debug("NUI", $"a:{a}, b:{b}");
                        if (Object.ReferenceEquals(a, b)) { return true; }
                        if (a == b) { return true; }
                    }
                }
            }
            return false;
        }

        public void Deactivate()
        {
        }
    }
}
