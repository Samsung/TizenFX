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
            {typeof(Tizen.NUI.Rectangle), new List<object>() {new Tizen.NUI.Rectangle(1, 2, 3, 4), new Tizen.NUI.Rectangle(100, -100, -900, 1000), new Tizen.NUI.Rectangle(1234, -94321, 9999, 54321)}},
            {typeof(Tizen.NUI.Vector2), new List<object>() {new Tizen.NUI.Vector2(1, 2), new Tizen.NUI.Vector2(100.11f, -100.2f), new Tizen.NUI.Vector2(-123.123f, -456.456f)}},
            {typeof(Tizen.NUI.Vector3), new List<object>() {new Tizen.NUI.Vector3(1, 2, 3), new Tizen.NUI.Vector3(100.12f, -100.34f, 103.11f), new Tizen.NUI.Vector3(-123.123f, -456.456f, -789.789f)}},
            {typeof(Tizen.NUI.Vector4), new List<object>() {new Tizen.NUI.Vector4(1, 2, 3, 4), new Tizen.NUI.Vector4(100.12f, -100.34f, 103.11f, -333.33f), new Tizen.NUI.Vector4(-123.123f, -456.456f, -789.789f, -102.021f)}},
            {typeof(Tizen.NUI.Size), new List<object>() {new Tizen.NUI.Size(1, 2, 3), new Tizen.NUI.Size(100.12f, -100.34f, 103.11f), new Tizen.NUI.Size(-123.123f, -456.456f, -789.789f)}},
            {typeof(Tizen.NUI.Position), new List<object>() {new Tizen.NUI.Position(1, 2, 3), new Tizen.NUI.Position(100.12f, -100.34f, 103.11f), new Tizen.NUI.Position(-123.123f, -456.456f, -789.789f)}},
            {typeof(Tizen.NUI.Size2D), new List<object>() {new Tizen.NUI.Size2D(1, 2), new Tizen.NUI.Size2D(100, 103)}},
            {typeof(Tizen.NUI.Position2D), new List<object>() {new Tizen.NUI.Position2D(1, 2), new Tizen.NUI.Position2D(100, -100), new Tizen.NUI.Position2D(-123, -456)}},
        };

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            target = new View()
            {
                Size2D = new Size2D(100, 100),
            };

            var proInfos = target.GetType().GetProperties();

            global::System.Text.StringBuilder failedPropertyName = new global::System.Text.StringBuilder();

            uint failedCount = 0u;

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
                        if (!resSub)
                        {
                            Tizen.Log.Debug("NUI", $"{prop.Name} set=\"{val}\" but result=\"{got}\"");
                        }
                        res &= resSub;
                    }
                    string result = res ? "OK" : "BAD";
                    if (!res)
                    {
                        ++failedCount;
                        failedPropertyName.Append(prop.Name + ", ");
                        if (failedCount % 10 == 0)
                        {
                            failedPropertyName.AppendLine("");
                        }
                        Tizen.Log.Error("NUI", $"Testing {prop.Name} result={result}");
                    }
                    else
                    {
                        Tizen.Log.Debug("NUI", $"Testing {prop.Name} result={result}");
                    }
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

            if (failedCount == 0)
            {
                var tl1 = new TextLabel
                {
                    Size = new Size(600, 100),
                    Text = $"All test case pass!"
                };
                root.Add(tl1);
            }
            else
            {
                var tl1 = new TextLabel
                {
                    Size = new Size(600, 100),
                    Text = $"{failedCount} failed! please check the log"
                };
                root.Add(tl1);

                var tl2 = new TextLabel
                {
                    Position = new Position(0, 300),
                    SizeWidth = 600,
                    Text = "" + failedPropertyName,
                    MultiLine = true,
                };

                root.Add(tl2);
            }
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
                        Tizen.Log.Debug("NUI", $"a1:{a1.R}, {a1.G}, {a1.B}, {a1.A} != b1:{b1.R}, {b1.G}, {b1.B}, {b1.A}");
                    }
                    else if (a is Tizen.NUI.Rectangle a2 && b is Tizen.NUI.Rectangle b2)
                    {
                        if (Object.ReferenceEquals(a2, b2)) { return true; }
                        if (a2 == b2) { return true; }
                        Tizen.Log.Debug("NUI", $"a2:{a2.X}, {a2.Y}, {a2.Width}, {a2.Height} != b2:{b2.X}, {b2.Y}, {b2.Width}, {b2.Height}");
                    }
                    else if (a is Tizen.NUI.Vector2 av2 && b is Tizen.NUI.Vector2 bv2)
                    {
                        if (Object.ReferenceEquals(av2, bv2)) { return true; }
                        if (av2.Equals(bv2)) { return true; }
                        Tizen.Log.Debug("NUI", $"av2:{av2.X}, {av2.Y} != bv2:{bv2.X}, {bv2.Y}");
                    }
                    else if (a is Tizen.NUI.Vector3 av3 && b is Tizen.NUI.Vector3 bv3)
                    {
                        if (Object.ReferenceEquals(av3, bv3)) { return true; }
                        if (av3.Equals(bv3)) { return true; }
                        Tizen.Log.Debug("NUI", $"av3:{av3.X}, {av3.Y}, {av3.Z} != bv3:{bv3.X}, {bv3.Y}, {bv3.Z}");
                    }
                    else if (a is Tizen.NUI.Vector4 av4 && b is Tizen.NUI.Vector4 bv4)
                    {
                        if (Object.ReferenceEquals(av4, bv4)) { return true; }
                        if (av4.Equals(bv4)) { return true; }
                        Tizen.Log.Debug("NUI", $"av4:{av4.X}, {av4.Y}, {av4.Z}, {av4.W} != bv4:{bv4.X}, {bv4.Y}, {bv4.Z}, {bv4.W}");
                    }
                    else if (a is Tizen.NUI.Size asz && b is Tizen.NUI.Size bsz)
                    {
                        if (Object.ReferenceEquals(asz, bsz)) { return true; }
                        if (asz.Equals(bsz)) { return true; }
                        Tizen.Log.Debug("NUI", $"asz:{asz.Width}x{asz.Height}x{asz.Depth} != bsz:{bsz.Width}x{bsz.Height}x{bsz.Depth}");
                    }
                    else if (a is Tizen.NUI.Position aps && b is Tizen.NUI.Position bps)
                    {
                        if (Object.ReferenceEquals(aps, bps)) { return true; }
                        if (aps.Equals(bps)) { return true; }
                        Tizen.Log.Debug("NUI", $"aps:{aps.X}, {aps.Y}, {aps.Z} != bps:{bps.X}, {bps.Y}, {bps.Z}");
                    }
                    else if (a is Tizen.NUI.Size2D asz2 && b is Tizen.NUI.Size2D bsz2)
                    {
                        if (Object.ReferenceEquals(asz2, bsz2)) { return true; }
                        if (asz2.Equals(bsz2)) { return true; }
                        Tizen.Log.Debug("NUI", $"asz2:{asz2.Width}x{asz2.Height} != bsz2:{bsz2.Width}x{bsz2.Height}");
                    }
                    else if (a is Tizen.NUI.Position2D aps2 && b is Tizen.NUI.Position2D bps2)
                    {
                        if (Object.ReferenceEquals(aps2, bps2)) { return true; }
                        if (aps2.Equals(bps2)) { return true; }
                        Tizen.Log.Debug("NUI", $"aps2:{aps2.X}, {aps2.Y} != bps2:{bps2.X}, {bps2.Y}");
                    }
                    else if (a is string ast && b is string bst)
                    {
                        if (Object.ReferenceEquals(ast, bst)) { return true; }
                        if (String.Compare(ast, bst) == 0) { return true; }
                        Tizen.Log.Debug("NUI", $"as:{ast} != bs:{bst}");
                    }
                    else
                    {
                        if (Object.ReferenceEquals(a, b)) { return true; }
                        if (a == b) { return true; }
                        Tizen.Log.Debug("NUI", $"a:{a} != b:{b}");
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
