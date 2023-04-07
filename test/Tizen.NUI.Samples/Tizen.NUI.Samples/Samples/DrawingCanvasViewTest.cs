using Tizen.NUI.BaseComponents;
using Tizen.NUI.Extension;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class DrawingCanvasViewTest : IExample
    {
        private Window _window;
        private Layer _defaultLayer;
        private TextLabel _textLabel;
        private Button _deleteButton;

        private DrawingCanvasView _canvas;

        public void Activate()
        {
            _window = NUIApplication.GetDefaultWindow();
            _defaultLayer = _window.GetDefaultLayer();

            _textLabel = new TextLabel
            {
                Text = "",
                Position = new Position(0, 0),
                Size = new Size(720, 120),
            };

            _deleteButton = new Button
            {
                Text = "Delete",
                Position = new Position(0, 130),
                Size = new Size(720, 50),
            };
            _deleteButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                if(!_canvas)
                    return;

                _canvas.Delete();
                _textLabel.Text = "Deleted DrawingCanvasView";
            };

            _canvas = new DrawingCanvasView();

            if (_canvas)
                _textLabel.Text = "Created DrawingCanvasView";
            else
                _textLabel.Text = "Failed to create DrawingCanvasView";

            _defaultLayer.Add(_textLabel);
            _defaultLayer.Add(_deleteButton);
        }

        public void Deactivate()
        {
            if (_canvas)
                _canvas.Delete();

            if (_textLabel)
                _defaultLayer.Remove(_textLabel);

            if (_deleteButton)
                _defaultLayer.Remove(_deleteButton);
        }
    }
}
