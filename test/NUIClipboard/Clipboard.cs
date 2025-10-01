using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace NUIClipboard
{
    class Program : NUIApplication
    {
        const string TAG = "clipboard";

        // Below are the MIME Types used in Tizen World(NUI, EFL).
        const string MIME_TYPE_PLAIN_TEXT = "text/plain;charset=utf-8";
        const string MIME_TYPE_HTML = "application/xhtml+xml";
        const string MIME_TYPE_TEXT_URI = "text/uri-list";

        TextField fieldCopy;
        TextLabel labelType;
        TextLabel labelData;

        Button buttonCopy;
        Button buttonPaste;
        Button buttonCopyHtml;
        Button buttonPasteHtml;
        Button buttonCopyUri;
        Button buttonPasteUri;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            GenerateUI(900, 1080);

            // The API used by the application is Clipboard's SetData() and GetData() methods.
            // Please refer to the code in the button Clicked event below.

            // TEXT type test : "text/plain;charset=utf-8"
            buttonCopy.Clicked += (s, e) =>
            {
                string data = fieldCopy.Text;
                Tizen.Log.Info(TAG, $"SetData type:{MIME_TYPE_PLAIN_TEXT}, data:{data}\n");

                // Set "text/plain;charset=utf-8" type data on the clipboard.
                Clipboard.Instance.SetData(MIME_TYPE_PLAIN_TEXT, data);
            };

            buttonPaste.Clicked += (s, e) =>
            {
                Tizen.Log.Info(TAG, $"GetData request type:{MIME_TYPE_PLAIN_TEXT}\n");

                // Request to receive "text/plain;charset=utf-8" type data from clipboard.
                // The results can be received through the OnClipboardDataReceived callback.
                Clipboard.Instance.GetData(MIME_TYPE_PLAIN_TEXT, OnClipboardDataReceived);
            };

            // HTML type test : "application/xhtml+xml"
            buttonCopyHtml.Clicked += (s, e) =>
            {
                string data = fieldCopy.Text;
                Tizen.Log.Info(TAG, $"SetData type:{MIME_TYPE_HTML}, data:{data}\n");
                Clipboard.Instance.SetData(MIME_TYPE_HTML, data);
            };

            buttonPasteHtml.Clicked += (s, e) =>
            {
                Tizen.Log.Info(TAG, $"GetData request type:{MIME_TYPE_HTML}\n");
                Clipboard.Instance.GetData(MIME_TYPE_HTML, OnClipboardDataReceived);
            };

            // URI type test : "text/uri-list"
            buttonCopyUri.Clicked += (s, e) =>
            {
                string data = fieldCopy.Text;
                Tizen.Log.Info(TAG, $"SetData type:{MIME_TYPE_TEXT_URI}, data:{data}\n");
                Clipboard.Instance.SetData(MIME_TYPE_TEXT_URI, data);
            };

            buttonPasteUri.Clicked += (s, e) =>
            {
                Tizen.Log.Info(TAG, $"GetData request type:{MIME_TYPE_TEXT_URI}\n");
                Clipboard.Instance.GetData(MIME_TYPE_TEXT_URI, OnClipboardDataReceived);
            };
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

        // UI code
        public void GenerateUI(int width, int height)
        {
            Window.Instance.WindowSize = new Size(width, height);
            Window.Instance.BackgroundColor = Color.White;

            // Top UI
            View mainView = NewView(false);
            Window.Instance.GetDefaultLayer().Add(mainView);

            mainView.Add(NewTitle("Tizen.NUI.Clipboard Test"));
            mainView.Add(NewPadding(5));
            mainView.Add(NewInfo(" ▼ Description"));

            string descriptionText = "* <u>Copy</u> : Copy the text entered in the TextField using the Clipboard's <u><i>SetData()</i></u> API.\n" +
                                     "* <u>Paste</u> : Paste the text using the Clipboard's <u><i>GetData()</i></u> API.\n" +
                                     "* <u>Clear</u> : Clear Information.\n" +
                                     "* This sample uses three different <u><i>MIME types(TEXT, HTML, URI)</i></u> to send and receive data.\n" +
                                     "* In order to send and receive data, the requested <u><i>MIME type must be the same.</i></u>\n" +
                                     "* For example, if copy the TEXT type and try to paste the HTML type, may receive a failure callback.";

            mainView.Add(NewInfo(descriptionText, true));
            mainView.Add(NewPadding(5));
            mainView.Add(NewInfo(" ▼ Enter the text you want copy into the TextField"));

            View vertView1 = NewView(true);
            mainView.Add(vertView1);

            fieldCopy = NewTextField("Enter text to copy", LayoutParamPolicies.MatchParent);
            vertView1.Add(fieldCopy);

            Button buttonCopyClear = NewButton("Clear");
            vertView1.Add(buttonCopyClear);
            buttonCopyClear.Clicked += (s, e) =>
            {
                fieldCopy.Text = "";
                labelType.Text = " ";
                labelData.Text = " ";
            };

            //Copy & Paste Button
            mainView.Add(NewPadding(5));
            mainView.Add(NewInfo(" ▼ Select Copy or Paste with MIME type"));

            // plain text
            View vertView4 = NewView(true);
            mainView.Add(vertView4);

            vertView4.Add(NewTextLabel($"MIME type : {MIME_TYPE_PLAIN_TEXT}", LayoutParamPolicies.MatchParent));

            buttonCopy = NewButton("Copy");
            vertView4.Add(buttonCopy);

            buttonPaste = NewButton("Paste");
            vertView4.Add(buttonPaste);

            // html
            View vertView5 = NewView(true);
            mainView.Add(vertView5);

            vertView5.Add(NewTextLabel($"MIME type : {MIME_TYPE_HTML}", LayoutParamPolicies.MatchParent));

            buttonCopyHtml = NewButton("Copy");
            vertView5.Add(buttonCopyHtml);

            buttonPasteHtml = NewButton("Paste");
            vertView5.Add(buttonPasteHtml);

            // text uri
            View vertView6 = NewView(true);
            mainView.Add(vertView6);

            vertView6.Add(NewTextLabel($"MIME type : {MIME_TYPE_TEXT_URI}", LayoutParamPolicies.MatchParent));

            buttonCopyUri = NewButton("Copy");
            vertView6.Add(buttonCopyUri);

            buttonPasteUri = NewButton("Paste");
            vertView6.Add(buttonPasteUri);

            // Bottom UI
            mainView.Add(NewPadding(5));
            mainView.Add(NewInfo(" ▼ Pasted information"));

            // info type
            View vertView2 = NewView(true);
            mainView.Add(vertView2);

            vertView2.Add(NewTextLabel("MIME type", 300));

            labelType = NewTextLabel(" ", LayoutParamPolicies.MatchParent);
            vertView2.Add(labelType);

            // info data
            View vertView3 = NewView(true);
            mainView.Add(vertView3);

            vertView3.Add(NewTextLabel("Data", 300));

            labelData = NewTextLabel(" ", LayoutParamPolicies.MatchParent);
            vertView3.Add(labelData);
        }

        public View NewView(bool horizontal)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = horizontal ? LinearLayout.Orientation.Horizontal : LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.White,
            };
            return view;
        }

        public View NewPadding(int height)
        {
            var view = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = height,
            };
            return view;
        }

        public TextLabel NewTextLabel(string text, int width, bool borderLine = true)
        {
            var label = new TextLabel
            {
                Text = text,
                MultiLine = true,
                WidthSpecification = width,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
                BorderlineWidth = borderLine ? 1.0f : 0.0f,
                EnableMarkup = true,
            };
            return label;
        }

        public TextLabel NewInfo(string text, bool borderLine = false)
        {
            var info = NewTextLabel(text, LayoutParamPolicies.MatchParent, borderLine);
            info.PointSize = 16.0f;
            return info;
        }

        public TextLabel NewTitle(string text)
        {
            var title = NewTextLabel(text, LayoutParamPolicies.MatchParent);
            title.HorizontalAlignment = HorizontalAlignment.Center;
            title.PointSize = 25.0f;
            return title;
        }

        public TextField NewTextField(string placeholderText, int width)
        {
            var field = new TextField
            {
                PlaceholderText = placeholderText,
                PlaceholderTextFocused = placeholderText,
                WidthSpecification = width,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
                BorderlineWidth = 1.0f,
                MaxLength = 1000,
            };
            return field;
        }

        public Button NewButton(string text)
        {
            var button = new Button(NewButtonStyle())
            {
                Text = text,
                PointSize = 20.0f,
                WidthSpecification = 200,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                ItemHorizontalAlignment = HorizontalAlignment.Center,
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
