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
            var cPtr = NUI.Interop.PropertyMap.NewPropertyMap();
            var propertyMap = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);

            bool boolValue1, boolValue2, boolValue3;
            Interop.PropertyMap.Insert(propertyMap.Handle, 100, true);
            Interop.PropertyMap.Insert(propertyMap.Handle, 101, false);
            Interop.PropertyMap.SetValueIntKey(propertyMap.Handle, 102, true);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, 100);
            var mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            NUI.Interop.PropertyValue.PropertyValueGet(mapHandle, out boolValue1);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, 101);
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            NUI.Interop.PropertyValue.PropertyValueGet(mapHandle, out boolValue2);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, 102);
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            NUI.Interop.PropertyValue.PropertyValueGet(mapHandle, out boolValue3);

            Console.WriteLine($"{boolValue1}, {boolValue2}, {boolValue3}");
            if (boolValue1 != true || boolValue2 != false || boolValue3 != true)
            {
                FailTest();
                return;
            }

            Interop.PropertyMap.Insert(propertyMap.Handle, "boolValue1", true);
            Interop.PropertyMap.Insert(propertyMap.Handle, "boolValue2", false);
            Interop.PropertyMap.SetValueStringKey(propertyMap.Handle, "boolValue3", true);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, "boolValue1");
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            NUI.Interop.PropertyValue.PropertyValueGet(mapHandle, out boolValue1);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, "boolValue2");
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            NUI.Interop.PropertyValue.PropertyValueGet(mapHandle, out boolValue2);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, "boolValue3");
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            NUI.Interop.PropertyValue.PropertyValueGet(mapHandle, out boolValue3);

            Console.WriteLine($"{boolValue1}, {boolValue2}, {boolValue3}");
            if (boolValue1 != true || boolValue2 != false || boolValue3 != true)
            {
                FailTest();
                return;
            }

            int intValue1, intValue2;
            Interop.PropertyMap.Insert(propertyMap.Handle, 103, 9);
            Interop.PropertyMap.SetValueIntKey(propertyMap.Handle, 104, 9);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, 103);
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            NUI.Interop.PropertyValue.PropertyValueGet(mapHandle, out intValue1);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, 104);
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            NUI.Interop.PropertyValue.PropertyValueGet(mapHandle, out intValue2);
            Console.WriteLine($"{intValue1}, {intValue2}");
            if (intValue1 != 9 || intValue2 != 9)
            {
                FailTest();
                return;
            }
            Interop.PropertyMap.Insert(propertyMap.Handle, "intValue1", 9);
            Interop.PropertyMap.SetValueStringKey(propertyMap.Handle, "intValue2", 9);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, "intValue1");
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            NUI.Interop.PropertyValue.PropertyValueGet(mapHandle, out intValue1);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, "intValue2");
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            NUI.Interop.PropertyValue.PropertyValueGet(mapHandle, out intValue2);
            Console.WriteLine($"{intValue1}, {intValue2}");
            if (intValue1 != 9 || intValue2 != 9)
            {
                FailTest();
                return;
            }

            int floatValue1, floatValue2;
            Interop.PropertyMap.Insert(propertyMap.Handle, 105, 9.0f);
            Interop.PropertyMap.SetValueIntKey(propertyMap.Handle, 106, 9);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, 105);
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            NUI.Interop.PropertyValue.PropertyValueGet(mapHandle, out floatValue1);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, 106);
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            NUI.Interop.PropertyValue.PropertyValueGet(mapHandle, out floatValue2);
            Console.WriteLine($"{floatValue1}, {floatValue2}");
            if (floatValue1 != 9.0f || floatValue2 != 9.0f)
            {
                FailTest();
                return;
            }
            Interop.PropertyMap.Insert(propertyMap.Handle, "floatValue1", 9.0f);
            Interop.PropertyMap.SetValueStringKey(propertyMap.Handle, "floatValue2", 9);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, "floatValue1");
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            NUI.Interop.PropertyValue.PropertyValueGet(mapHandle, out floatValue1);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, "floatValue2");
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            NUI.Interop.PropertyValue.PropertyValueGet(mapHandle, out floatValue2);
            Console.WriteLine($"{floatValue1}, {floatValue2}");
            if (floatValue1 != 9.0f || floatValue2 != 9.0f)
            {
                FailTest();
                return;
            }

            var vector2Value1 = NUI.Interop.Vector2.NewVector2();
            var vector2Value2 = NUI.Interop.Vector2.NewVector2();
            Interop.PropertyMap.Insert(propertyMap.Handle, "vectorValue1", 9.0f, 9.0f);
            Interop.PropertyMap.SetValueStringKey(propertyMap.Handle, "vectorValue2", 10.0f, 10.0f);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, "vectorValue1");
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            var vectorHandle1 = new global::System.Runtime.InteropServices.HandleRef(this, vector2Value1);
            NUI.Interop.PropertyValue.GetVector2(mapHandle, vectorHandle1);

            cPtr = NUI.Interop.PropertyMap.ValueOfIndex(propertyMap, "vectorValue2");
            mapHandle = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            var vectorHandle2 = new global::System.Runtime.InteropServices.HandleRef(this, vector2Value2);
            NUI.Interop.PropertyValue.GetVector2(mapHandle, vectorHandle2);

            Console.WriteLine($"Vector2: {NUI.Interop.Vector2.XGet(vectorHandle1)}, {NUI.Interop.Vector2.YGet(vectorHandle1)}");
            if (NUI.Interop.Vector2.XGet(vectorHandle1) != 9.0f || NUI.Interop.Vector2.YGet(vectorHandle1) != 9.0f)
            {
                FailTest();
                return;
            }
            Console.WriteLine($"Vector2: {NUI.Interop.Vector2.XGet(vectorHandle2)}, {NUI.Interop.Vector2.YGet(vectorHandle2)}");
            if (NUI.Interop.Vector2.XGet(vectorHandle2) != 10.0f || NUI.Interop.Vector2.YGet(vectorHandle2) != 10.0f)
            {
                FailTest();
                return;
            }

            NUI.Interop.PropertyMap.DeletePropertyMap(propertyMap);
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
