using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{

    public class PropertyMapSample : IExample
    {
        private View root;
        private LinearLayout layout;
        private TextLabel view1;
        private Button button1;
        private TextLabel view2;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = new Size(1920, 1080)
            };
            layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical };
            root.Layout = layout;
            window.Add(root);

            view1 = new TextLabel
            {
                Position = new Position(400, 400),
                Size = new Size(600, 100),
                Text = "Shadow on Label"
            };

            PropertyMap shadow = new PropertyMap();

            // insert
            shadow.Insert("offset", new PropertyValue(new Vector2(10, 10)));
            shadow.Insert("color", new PropertyValue(Color.Red));
            shadow.Insert("blurRadius", new PropertyValue(10f));

            // update
            shadow["color"] = new PropertyValue(Color.Blue);

            // remove
            shadow.Remove(new PropertyKey("color"));
            Log.Info("test", $"removed color: {shadow.Contains(new PropertyKey("color"))}");

            // add
            shadow.Add("color", new PropertyValue(Color.Blue));

            view1.Shadow = shadow;
            var map = view1.Shadow;

            // query
            Log.Info("test", $"offset : {map.Contains(new PropertyKey("offset"))}");
            Log.Info("test", $"color: {map.Contains(new PropertyKey("color"))}");
            Log.Info("test", $"color: {map["color"]}");

            Color vectorValue = new Color();
            map["color"].Get(vectorValue);
            bool isBlue = vectorValue.EqualTo(Color.Blue);
            Log.Info("test", $"color: {isBlue}");

            root.Add(view1);

            button1 = new Button
            {
                Text = "Test Additional APIs",
                BackgroundColor = Color.Yellow
            };
            button1.Clicked += (sender, e) =>
            {
                ExecuteTest();
            };
            root.Add(button1);

            view2 = new TextLabel
            {
                Position = new Position(400, 400),
                Size = new Size(600, 100),
                Text = "Button turns Green when Test passed."
            };
            root.Add(view2);
        }

        void ExecuteTest()
        {
            var propertyMap = Interop.PropertyMap.NewPropertyMap();

            bool boolValue1, boolValue2, boolValue3;
            Interop.PropertyMap.Insert(propertyMap, 100, true);
            Interop.PropertyMap.Insert(propertyMap, 101, false);
            Interop.PropertyMap.SetValueIntKey(propertyMap, 102, true);
            Interop.PropertyValue.PropertyValueGet(Interop.PropertyMap.ValueOfIndex(propertyMap, 100), out boolValue1);
            Interop.PropertyValue.PropertyValueGet(Interop.PropertyMap.ValueOfIndex(propertyMap, 101), out boolValue2);
            Interop.PropertyValue.PropertyValueGet(Interop.PropertyMap.ValueOfIndex(propertyMap, 102), out boolValue3);
            Console.WriteLine($"{boolValue1}, {boolValue2}, {boolValue3}");
            if (boolValue1 != true || boolValue2 != false || boolValue3 != true)
            {
                FailTest();
                return;
            }

            Interop.PropertyMap.Insert(propertyMap, "boolValue1", true);
            Interop.PropertyMap.Insert(propertyMap, "boolValue2", false);
            Interop.PropertyMap.SetValueStringKey(propertyMap, "boolValue3", true);
            Interop.PropertyValue.PropertyValueGet(Interop.PropertyMap.ValueOfIndex(propertyMap, "boolValue1"), out boolValue1);
            Interop.PropertyValue.PropertyValueGet(Interop.PropertyMap.ValueOfIndex(propertyMap, "boolValue2"), out boolValue2);
            Interop.PropertyValue.PropertyValueGet(Interop.PropertyMap.ValueOfIndex(propertyMap, "boolValue3"), out boolValue3);
            Console.WriteLine($"{boolValue1}, {boolValue2}, {boolValue3}");
            if (boolValue1 != true || boolValue2 != false || boolValue3 != true)
            {
                FailTest();
                return;
            }

            int intValue1, intValue2;
            Interop.PropertyMap.Insert(propertyMap, 103, 9);
            Interop.PropertyMap.SetValueIntKey(propertyMap, 104, 9);
            Interop.PropertyValue.PropertyValueGet(Interop.PropertyMap.ValueOfIndex(propertyMap, 103), out intValue1);
            Interop.PropertyValue.PropertyValueGet(Interop.PropertyMap.ValueOfIndex(propertyMap, 104), out intValue2);
            Console.WriteLine($"{intValue1}, {intValue2}");
            if (intValue1 != 9 || intValue2 != 9)
            {
                FailTest();
                return;
            }
            Interop.PropertyMap.Insert(propertyMap, "intValue1", 9);
            Interop.PropertyMap.SetValueStringKey(propertyMap, "intValue2", 9);
            Interop.PropertyValue.PropertyValueGet(Interop.PropertyMap.ValueOfIndex(propertyMap, "intValue1"), out intValue1);
            Interop.PropertyValue.PropertyValueGet(Interop.PropertyMap.ValueOfIndex(propertyMap, "intValue2"), out intValue2);
            Console.WriteLine($"{intValue1}, {intValue2}");
            if (intValue1 != 9 || intValue2 != 9)
            {
                FailTest();
                return;
            }

            int floatValue1, floatValue2;
            Interop.PropertyMap.Insert(propertyMap, 105, 9.0f);
            Interop.PropertyMap.SetValueIntKey(propertyMap, 106, 9);
            Interop.PropertyValue.PropertyValueGet(Interop.PropertyMap.ValueOfIndex(propertyMap, 105), out floatValue1);
            Interop.PropertyValue.PropertyValueGet(Interop.PropertyMap.ValueOfIndex(propertyMap, 106), out floatValue2);
            Console.WriteLine($"{floatValue1}, {floatValue2}");
            if (floatValue1 != 9.0f || floatValue2 != 9.0f)
            {
                FailTest();
                return;
            }
            Interop.PropertyMap.Insert(propertyMap, "floatValue1", 9.0f);
            Interop.PropertyMap.SetValueStringKey(propertyMap, "floatValue2", 9);
            Interop.PropertyValue.PropertyValueGet(Interop.PropertyMap.ValueOfIndex(propertyMap, "floatValue1"), out floatValue1);
            Interop.PropertyValue.PropertyValueGet(Interop.PropertyMap.ValueOfIndex(propertyMap, "floatValue2"), out floatValue2);
            Console.WriteLine($"{floatValue1}, {floatValue2}");
            if (floatValue1 != 9.0f || floatValue2 != 9.0f)
            {
                FailTest();
                return;
            }

            var vector2Value1 = Interop.Vector2.NewVector2();
            var vector2Value2 = Interop.Vector2.NewVector2();
            Interop.PropertyMap.Insert(propertyMap, "vectorValue1", 9.0f, 9.0f);
            Interop.PropertyMap.SetValueStringKey(propertyMap, "vectorValue2", 10.0f, 10.0f);
            Interop.PropertyValue.GetVector2(Interop.PropertyMap.ValueOfIndex(propertyMap, "vectorValue1"), vector2Value1);
            Interop.PropertyValue.GetVector2(Interop.PropertyMap.ValueOfIndex(propertyMap, "vectorValue2"), vector2Value2);
            Console.WriteLine($"Vector2: {Interop.Vector2.XGet(vector2Value1)}, {Interop.Vector2.YGet(vector2Value1)}");
            if (Interop.Vector2.XGet(vector2Value1) != 9.0f || Interop.Vector2.YGet(vector2Value1) != 9.0f)
            {
                FailTest();
                return;
            }
            Console.WriteLine($"Vector2: {Interop.Vector2.XGet(vector2Value2)}, {Interop.Vector2.YGet(vector2Value2)}");
            if (Interop.Vector2.XGet(vector2Value2) != 10.0f || Interop.Vector2.YGet(vector2Value2) != 10.0f)
            {
                FailTest();
                return;
            }

            Interop.PropertyMap.DeletePropertyMap(propertyMap);
            button1.BackgroundColor = Color.Green;
        }

        void FailTest()
        {
            button1.BackgroundColor = Color.Red;
        }

        public void Deactivate()
        {
            if (view1 != null)
            {
                NUIApplication.GetDefaultWindow().Remove(view1);
                NUIApplication.GetDefaultWindow().Remove(view2);
                NUIApplication.GetDefaultWindow().Remove(button1);
                view1.Dispose();
                view2.Dispose();
                button1.Dispose();
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
                root = null;
            }
        }
    }
}
