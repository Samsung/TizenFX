using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class PropertyMapSample : IExample
    {
        private TextLabel view1;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

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

            window.Add(view1);

            PropertyValue pv1 = new PropertyValue("test");
            PropertyValue pv2 = PropertyValue.New(true);
            PropertyValue pv3 = PropertyValue.New(100);
            PropertyValue pv4 = PropertyValue.New(100.0f);
            PropertyValue pv5 = PropertyValue.New(Vector2.New(100, 100));
            PropertyValue pv6 = PropertyValue.New(new Vector3(100, 100, 100));
            PropertyValue pv7 = PropertyValue.New(new Vector4(100, 100, 100, 100));
            PropertyValue pv8 = PropertyValue.New(new Rectangle(100, 100, 100, 100));

            var t1 = pv1.GetType();
            var t2 = pv2.GetType();
            var t3 = pv3.GetType();
            var t4 = pv4.GetType();
            var t5 = pv5.GetType();
            var t6 = pv6.GetType();
            var t7 = pv7.GetType();
            var t8 = pv8.GetType();

            bool b1 = false;
            pv2.Get(out b1);
            global::System.Console.WriteLine($"b1={b1} should be true");

            Vector2 tempVec = Vector2.New(-1, -1);
            pv5.Get(tempVec);
            global::System.Console.WriteLine($"tempVec X={tempVec.X} Y={tempVec.Y} should be (100, 100)");

            string tempStr = "-1";
            pv1.Get(out tempStr);
            global::System.Console.WriteLine($"tempStr={tempStr} should be test");
        }

        public void Deactivate()
        {
            if (view1 != null)
            {
                NUIApplication.GetDefaultWindow().Remove(view1);
                view1.Dispose();
            }
        }
    }
}
