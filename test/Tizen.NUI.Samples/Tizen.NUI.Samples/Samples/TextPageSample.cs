using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Utility;

using System;
using System.IO;
using Tizen.System;

namespace Tizen.NUI.Samples
{
    public class TextPageSample : IExample
    {
        private TextLabel label;
        private View root;

        public string LoadTerms()
        {
            string terms = null;
            var filename = "res/pl_PL.txt";

            try {
                terms = File.ReadAllText(filename);
            } catch (Exception e) {
                Tizen.Log.Debug("oobe", $"Unable to load terms: {e.Message}");
                return null;
            }
            return terms;
        }


        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            label = new TextLabel();
            label.Size = new Size(300, 700);
            label.PointSize = 11.0f;
            label.MultiLine = true;

            TextPageUtil util = new TextPageUtil();
            int pageCount = util.SetText( label, LoadTerms() );
            Tizen.Log.Error("NUI", $"pageCount: {pageCount}\n");
            label.Text = util.GetText(1);
            window.Add(label);
        }

        public void Deactivate()
        {
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}