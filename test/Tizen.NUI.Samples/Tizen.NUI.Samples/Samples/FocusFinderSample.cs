using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
    public class FocusFinderSample : IExample
    {

        int ItemWidth = 100;
        int ItemHeight = 100;
        int ItemSpacing = 10;

        public View TargetView = new View();
        TextLabel _textLabel;


        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            FocusManager.Instance.EnableDefaultAlgorithm(true);

            var absLayout = new View
            {
                Layout = new AbsoluteLayout(),
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                // FocusableChildren = false,
            };
            window.Add(absLayout);

            List<View> buttons = new List<View>();

            for (int row = 0; row < 5; row++)
            {
                for (int cols = 0; cols < 5; cols++)
                {
                    var btn = MakeFocusableButton($"{row * 5 + cols}");
                    btn.Position = new Position(ItemWidth + cols * (ItemWidth + ItemSpacing), ItemHeight + 300 + row * (ItemHeight + ItemSpacing));
                    buttons.Add(btn);
                    absLayout.Add(btn);
                }
            }

            var changeLayout = new Button
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = "Change Position",
                SizeWidth = 300,
                SizeHeight = 100,
            };

            changeLayout.Position = new Position(10, 10);

            absLayout.Add(changeLayout);
            changeLayout.Clicked += (s, e) =>
            {
                buttons.Reverse();

                for (int row = 0; row < 5; row++)
                {
                    for (int cols = 0; cols < 5; cols++)
                    {

                        var btn = buttons[row * 5 + cols];
                        btn.Position = new Position(ItemWidth + cols * (ItemWidth + ItemSpacing), ItemHeight + 300 + row * (ItemHeight + ItemSpacing));
                    }
                }
            };

            var hideButton = new Button
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = "Hide button",
                SizeWidth = 400,
                SizeHeight = 100,
            };

            hideButton.Position = new Position(340, 10);
            hideButton.Clicked += (s, e) =>
            {

                for (int i = 0; i < buttons.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (buttons[i].Visibility)
                        {
                            buttons[i].Hide();
                        }
                        else
                        {
                            buttons[i].Show();
                        }
                    }
                }
            };
            absLayout.Add(hideButton);


            var overlap = new Button
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = "Overlap view",
                SizeWidth = 300,
                SizeHeight = 100,
            };
            overlap.Position = new Position(10, 120);
            absLayout.Add(overlap);

            View overlappedView = null;
            overlap.Clicked += (s, e) =>
            {
                if (overlappedView != null)
                {
                    overlappedView.Unparent();
                    overlappedView.Dispose();
                    overlappedView = null;
                    return;
                }

                overlappedView = new View
                {
                    Focusable = true,
                    FocusableInTouch = true,
                    Layout = new AbsoluteLayout(),
                    SizeWidth = 400,
                    SizeHeight = 400,
                    BackgroundColor = new Color(1f, 0.5f, 0.5f, 0.5f)
                };
                overlappedView.Position = new Position(ItemWidth, ItemHeight + 300);
                absLayout.Add(overlappedView);

                var innerButton = MakeFocusableButton("InnerButton");
                innerButton.SizeWidth = 350;
                innerButton.SizeHeight = 350;
                overlappedView.Add(innerButton);
                innerButton.Position = new Position(10, 10);
            };

            _textLabel = new TextLabel
            {
                Text = "Focused : ",
                SizeWidth = 500,
                SizeHeight = 200,
            };
            _textLabel.Position = new Position(340, 220);
            absLayout.Add(_textLabel);






            var absLayout2 = new View
            {
                Layout = new AbsoluteLayout(),
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            window.Add(absLayout2);

            var btn1 = MakeFocusableButton("#");
            btn1.Position = new Position(ItemWidth, ItemHeight + 170);
            ((Button)btn1).TextColor = Color.Red;
            absLayout2.Add(btn1);

            var btn2 = MakeFocusableButton("%");
            btn2.Position = new Position(ItemWidth + 1 * (ItemWidth + ItemSpacing), ItemHeight + 170);
            ((Button)btn2).TextColor = Color.Red;
            absLayout2.Add(btn2);

            var btn3 = MakeFocusableButton("*");
            btn3.Position = new Position(ItemWidth + 2 * (ItemWidth + ItemSpacing), ItemHeight + 170);
            ((Button)btn3).TextColor = Color.Red;
            absLayout2.Add(btn3);

            var btn4 = MakeFocusableButton("+");
            btn4.Position = new Position(ItemWidth + 3 * (ItemWidth + ItemSpacing), ItemHeight + 170);
            ((Button)btn4).TextColor = Color.Red;
            absLayout2.Add(btn4);

            var btn5 = MakeFocusableButton("-");
            btn5.Position = new Position(ItemWidth + 4 * (ItemWidth + ItemSpacing), ItemHeight + 170);
            ((Button)btn5).TextColor = Color.Red;
            absLayout2.Add(btn5);


            var focusableChildrenView = new Button
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = "FocusableChildren",
                SizeWidth = 400,
                SizeHeight = 100,
            };
            focusableChildrenView.Position = new Position(340, 120);
            absLayout.Add(focusableChildrenView);

            focusableChildrenView.Clicked += (s, e) =>
            {
                absLayout2.FocusableChildren = false;
            };
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
            };

            btn.FocusGained += (s, e) => btn.Text = $"[{title}]";
            btn.FocusLost += (s, e) => btn.Text = $"{title}";
            btn.FocusGained += (s, e) => _textLabel.Text = $"Focused : {title}";
            return btn;
        }

        public void Deactivate()
        {
        }
    }
}
