using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace NUIClipboard
{
    class Program : NUIApplication
    {
        const string TAG = "clipboard";
        const string MIME_TYPE_PLAIN_TEXT = "text/plain;charset=utf-8";
        const string MIME_TYPE_TEXT_URI = "text/uri-list";
        const string MIME_TYPE_HTML = "application/xhtml+xml";

        TextField fieldCopy;
        TextField fieldPaste;

        TextLabel labelType;
        TextLabel labelData;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window.Instance.WindowSize = new Size(900, 1080);
            Window.Instance.BackgroundColor = Color.White;

            View mainView = NewView(false);
            Window.Instance.GetDefaultLayer().Add(mainView);

            TextLabel title = NewTextLabel("Tizen.NUI.Clipboard Test", LayoutParamPolicies.MatchParent);
            title.HorizontalAlignment = HorizontalAlignment.Center;
            title.PointSize = 30.0f;
            mainView.Add(title);

            string descriptionText = "[Description]\n" +
                                     "* Copy : Copy the text entered in the TextField using the Clipboard's SetData() API.\n" +
                                     "* This sample uses the 'text/plain;charset=utf-8' MIME type to send and receive data.\n" + 
                                     "* Paste : Paste the text using the Clipboard's GetData() API.\n" +
                                     "* Clear : Clear Information.";

            TextLabel description = NewTextLabel(descriptionText, LayoutParamPolicies.MatchParent);
            description.PointSize = 20.0f;
            mainView.Add(description);

            View vertView1 = NewView(true);
            mainView.Add(vertView1);

            fieldCopy = NewTextField("Enter text to copy", LayoutParamPolicies.MatchParent);
            vertView1.Add(fieldCopy);

            Button buttonCopy = NewButton("Copy");
            vertView1.Add(buttonCopy);
            buttonCopy.Clicked += (s, e) =>
            {
                string data = fieldCopy.Text;
                Clipboard.Instance.SetData(MIME_TYPE_PLAIN_TEXT, data);
                Tizen.Log.Info(TAG, $"SetData type:{MIME_TYPE_PLAIN_TEXT}, data:{data}\n");
            };


            View vertView2 = NewView(true);
            mainView.Add(vertView2);

            Button buttonPaste = NewButton("Paste");
            vertView2.Add(buttonPaste);
            buttonPaste.Clicked += (s, e) =>
            {
                Clipboard.Instance.GetData(MIME_TYPE_PLAIN_TEXT, OnClipboardDataReceived);
                Tizen.Log.Info(TAG, $"GetData request type:{MIME_TYPE_PLAIN_TEXT}\n");
            };

            Button buttonCopyClear = NewButton("Clear");
            vertView2.Add(buttonCopyClear);
            buttonCopyClear.Clicked += (s, e) =>
            {
                fieldCopy.Text = "";
                labelType.Text = " ";
                labelData.Text = " ";
            };

            View vertView3 = NewView(true);
            mainView.Add(vertView3);

            TextLabel pastedType = NewTextLabel("MIME type", 300);
            vertView3.Add(pastedType);

            labelType = NewTextLabel(" ", LayoutParamPolicies.MatchParent);
            vertView3.Add(labelType);

            View vertView4 = NewView(true);
            mainView.Add(vertView4);

            TextLabel pastedData = NewTextLabel("Data", 300);
            vertView4.Add(pastedData);

            labelData = NewTextLabel(" ", LayoutParamPolicies.MatchParent);
            vertView4.Add(labelData);
        }

        public void OnClipboardDataReceived(bool success, ClipEvent clipEvent)
        {
            if (!success)
            {
                Tizen.Log.Error(TAG, $"Data receive fail");
                return;
            }

            Tizen.Log.Info(TAG, $"OnClipboardDataReceived type:{clipEvent.MimeType}, data:{clipEvent.Data}\n");

            // info update
            labelType.Text = clipEvent.MimeType;
            labelData.Text = clipEvent.Data;
        }

        public View NewView(bool horizontal)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = horizontal ? LinearLayout.Orientation.Horizontal : LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(10, 20),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.White,
            };
            return view;
        }

        public TextLabel NewTextLabel(string text, int width)
        {
            var label = new TextLabel
            {
                Text = text,
                MultiLine = true,
                WidthSpecification = width,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                BorderlineWidth = 1.0f,
            };
            return label;
        }

        public TextField NewTextField(string placeholderText, int width)
        {
            var field = new TextField
            {
                PlaceholderText = placeholderText,
                PlaceholderTextFocused = placeholderText,
                WidthSpecification = width,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                BorderlineWidth = 1.0f,
            };
            return field;
        }

        public Button NewButton(string text)
        {
            var button = new Button(NewButtonStyle())
            {
                Text = text,
                PointSize = 25.0f,
                WidthSpecification = 200,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            return button;
        }

        public ButtonStyle NewButtonStyle()
        {
            var style = new ButtonStyle
            {
                CornerRadius = 0.0f,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(0.25f, 0.75f, 1.0f, 1.0f),
                    Pressed = new Color(0.25f, 0.75f, 1.0f, 0.3f),
                },
                Overlay = new ImageViewStyle()
                {
                    BackgroundColor = new Selector<Color>()
                    {
                        Pressed = new Color(0, 0, 0, 0.1f),
                        Other = new Color(1, 1, 1, 0.1f),
                    },
                },
                Text = new TextLabelStyle()
                {
                    TextColor = new Color(0.0f, 0.0f, 0.0f, 1.0f),
                }
            };
            return style;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
