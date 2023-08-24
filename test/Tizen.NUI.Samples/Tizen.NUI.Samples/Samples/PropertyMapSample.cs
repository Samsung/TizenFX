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
