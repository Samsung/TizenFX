using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
    public class CustomWheelEventSample : IExample
    {

        int ItemWidth = 100;
        int ItemHeight = 100;
        int ItemSpacing = 10;

        public View TargetView = new View();

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            var absLayout = new View
            {
                Layout = new AbsoluteLayout(),
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                Focusable = true,
                FocusableInTouch = true,
            };
            window.Add(absLayout);

            var btn1 = MakeFocusableButton("1");
            btn1.Position = new Position(ItemWidth + 1 * (ItemWidth + ItemSpacing), ItemHeight);
            absLayout.Add(btn1);

            var btn2 = MakeFocusableButton("2");
            btn2.Position = new Position(ItemWidth + 2 * (ItemWidth + ItemSpacing), ItemHeight);
            absLayout.Add(btn2);

            var btn3 = MakeFocusableButton("3");
            btn3.Position = new Position(ItemWidth + 3 * (ItemWidth + ItemSpacing), ItemHeight);
            absLayout.Add(btn3);

            var btn4 = MakeFocusableButton("4");
            btn4.Position = new Position(ItemWidth + 4 * (ItemWidth + ItemSpacing), ItemHeight);
            absLayout.Add(btn4);


            btn1.ClockwiseFocusableView = btn2;
            btn2.ClockwiseFocusableView = btn3;
            btn3.ClockwiseFocusableView = btn4;
            btn4.ClockwiseFocusableView = btn1;

            btn1.CounterClockwiseFocusableView = btn4;
            btn2.CounterClockwiseFocusableView = btn1;
            btn3.CounterClockwiseFocusableView = btn2;
            btn4.CounterClockwiseFocusableView = btn3;

            FocusManager.Instance.SetCurrentFocusView(btn1);
        }

        View MakeFocusableButton(string title)
        {
            var btn = new Button
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = title,
                SizeWidth = ItemWidth,
                SizeHeight = ItemHeight,
                BackgroundColor = Color.Blue,
            };

            btn.FocusGained += (s, e) => btn.Text = $"[{title}]";
            btn.FocusLost += (s, e) => btn.Text = $"{title}";
            return btn;
        }

        public void Deactivate()
        {
        }
    }
}
