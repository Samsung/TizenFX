using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
    public class GetNextFocusSample : IExample
    {

        int ItemWidth = 100;
        int ItemHeight = 100;
        int ItemSpacing = 10;

        public View TargetView = new View();

        class CustomInterface : ICustomAwareDeviceFocusAlgorithm
        {
            // This method is called when a direction key is pressed.
            public View GetNextFocusableView(View current, View proposed, View.FocusDirection direction, string deviceName)
            {
                Tizen.Log.Error("NUI", $" GetNextFocusableView deviceName {deviceName}\n");
                return proposed;
            }

            // This method is never called.
            public View GetNextFocusableView(View current, View proposed, View.FocusDirection direction)
            {
                Tizen.Log.Error("NUI", $" GetNextFocusableView \n");
                return proposed;
            }
        }

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            CustomInterface custom = new CustomInterface();
            FocusManager.Instance.SetCustomAlgorithm(custom);

            var absLayout = new View
            {
                Layout = new AbsoluteLayout(),
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                Focusable = true,
                FocusableInTouch = true,
            };
            window.Add(absLayout);

            for (int row = 0; row < 5; row++)
            {
                for (int cols = 0; cols < 5; cols++)
                {
                    var btn = MakeFocusableButton($"{row * 5 + cols}");
                    btn.Position = new Position(ItemWidth + cols * (ItemWidth + ItemSpacing), ItemHeight + 300 + row * (ItemHeight + ItemSpacing));
                    absLayout.Add(btn);
                }
            }
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
