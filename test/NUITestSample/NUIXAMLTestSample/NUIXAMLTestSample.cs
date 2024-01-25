using System;
using Tizen.NUI.Examples;

namespace NUIXAMLTestSample
{
    class Application
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //new TextLayoutSample().Run(args);
            //new TempTest().Run(args);
            new LayoutSample().Run(args);

            /* For Sample codes */
            // new TestAmbient().Run(args);
            // new TestDetailApps().Run(args);
            // new TestMyContents().Run(args);
            // new CommandDemoApplication().Run(args);

            /* For UTC codes */
            // new TestButton().Run(args);
            // new TestFlexContainer().Run(args);
            // new TestImageView().Run(args);
            // new TestScrollBar().Run(args);
            // new TestSlider().Run(args);
            // new TestTableView().Run(args);
            // new TestTextEditor().Run(args);
            // new TestTextField().Run(args);
            // new TestTextLabel().Run(args);

        }
    }
}
