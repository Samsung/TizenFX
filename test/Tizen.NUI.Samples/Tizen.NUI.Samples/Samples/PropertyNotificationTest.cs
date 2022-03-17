
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class PropertyNotificationTest : IExample
    {
        Window win;
        int cnt = 0;
        int cnt2 = 0;
        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();
            win.BackgroundColor = Color.White;

            View root = new View()
            {
                Size = new Size(300, 300),
                BackgroundColor = Color.Red,
                Name = "test view",
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(0, 20),
                },
            };
            View view1 = new View()
            {
                HeightSpecification = 30,
                WidthSpecification = 30,
                BackgroundColor = Color.Blue,
            };
            View view2 = new View()
            {
                HeightSpecification = 30,
                WidthSpecification = 30,
                BackgroundColor = Color.Green,
            };
            View view3 = new View()
            {
                HeightSpecification = 30,
                WidthSpecification = 30,
                BackgroundColor = Color.White,
            };

            Button button = new Button()
            {
                Size = new Size(100, 100),
                Position = new Position(300, 300),
                Text = "Offset Change",
                BackgroundColor = Color.Lime,
                Name = "test button",
            };
            Button button2 = new Button()
            {
                Size = new Size(100, 100),
                Position = new Position(300, 400),
                Text = "Layout method change",
                BackgroundColor = Color.Lime,
                Name = "test button",
            };

            button.Clicked += (o, e) => {
                /*
                PropertyMap map = new PropertyMap();
                map.Insert((int)VisualTransformPropertyType.Offset, new PropertyValue(new Vector2(0.05f, 0.05f)));

                PropertyMap back = view2.Background;
                PropertyMap backt = new PropertyMap();
                PropertyValue value = back.Find(Visual.Property.Transform);
                value.Get(backt);

                backt.Merge(map);

                PropertyMap map2 = new PropertyMap();
                map2.Insert(Visual.Property.Transform, new PropertyValue(backt));

                back.Merge(map2);
                view2.Background = back;
                */
                if(cnt2 % 3 == 0){
                    view2.LayoutedPositionOffset = new Vector3(4, 8, 0);
                }
                else if(cnt2 % 3 == 1){
                    view2.LayoutedPositionOffset = new Vector3(-4, -8, 0);
                }
                else{
                    view2.LayoutedPositionOffset = new Vector3(40, 80, 0);
                }
                cnt2++;
            };
            button2.Clicked += (o, e) => {
                if(cnt % 2 == 0){
                    root.Layout =  new LinearLayout()
                    {
                        LinearOrientation = LinearLayout.Orientation.Horizontal,
                        VerticalAlignment = VerticalAlignment.Center,
                        CellPadding = new Size2D(20, 0),
                    };
                }
                else
                {
                    root.Layout =  new LinearLayout()
                    {
                        LinearOrientation = LinearLayout.Orientation.Vertical,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        CellPadding = new Size2D(0, 20),
                    };
                }
                cnt++;
            };

            root.Add(view1);
            root.Add(view2);
            root.Add(view3);


            var animation = new Animation(2000);
            animation.AnimateTo(root, "PositionX", 100, 0, 1000);
            animation.AnimateTo(root, "PositionX", 000, 1000, 2000);
            animation.Looping = true;
            animation.Play();

            win.GetDefaultLayer().Add(button);
            win.GetDefaultLayer().Add(button2);

            win.GetDefaultLayer().Add(root);
        }

        public void Deactivate()
        {
            win.GetDefaultLayer().FindChildByName("test view")?.Unparent();
            win.GetDefaultLayer().FindChildByName("test button")?.Unparent();
        }
    }
}
