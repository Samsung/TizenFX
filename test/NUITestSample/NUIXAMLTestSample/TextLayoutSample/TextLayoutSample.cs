
using Tizen.NUI;

namespace Tizen.NUI.Examples
{
    using log = Tizen.Log;
    public class TextLayoutSample : NUIApplication
    {
        private const string tag = "NUITEST";
        TextLayoutPage page;
        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.Cyan;
            window.KeyEvent += OnKeyEvent;

            page = new TextLayoutPage();
            page.PositionUsesPivotPoint = true;
            page.ParentOrigin = ParentOrigin.Center;
            page.PivotPoint = PivotPoint.Center;
            page.Size = new Size(720, 1280, 0);
            window.Add(page);

            //page.text.PropertyChanged += TextPropertyChanged;
            //page.text2.PropertySet += TextPropertySet;
        }

        private void TextPropertySet(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
        {
            log.Debug(tag, $"TextPropertySet() name={e.PropertyName} ");
        }

        private void TextPropertyChanged(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
        {
            log.Debug(tag, $"TextPropertyChanged() name={e.PropertyName} ");
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            //log.Debug(tag, $"OnKeyEvent() {e.Key.KeyPressedName}, page.slider.CurrentValue={page.slider.CurrentValue}");
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }
    }
}
