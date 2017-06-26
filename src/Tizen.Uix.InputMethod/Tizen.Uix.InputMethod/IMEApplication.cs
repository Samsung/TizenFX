using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Tizen;
using ElmSharp;
using static Interop.InputMethod;

namespace Tizen.Uix.InputMethod
{
    public class IMEWindow : Xamarin.Forms.Platform.Tizen.Native.Window
    {
        /* There can be only one single IME Window, so we are declaring the size variables as static */
        static Xamarin.Forms.Size _portrait_size = new Xamarin.Forms.Size(0.0 ,0.0);
        static Xamarin.Forms.Size _landscape_size = new Xamarin.Forms.Size(0.0, 0.0);

        public static Xamarin.Forms.Size PortraitSize
        {
            get { return _portrait_size; }
            internal set
            {
                _portrait_size = value;
                ImeSetSize((int)PortraitSize.Width, (int)PortraitSize.Height,
                           (int)LandscapeSize.Width, (int)LandscapeSize.Height);
            }
        }

        public static Xamarin.Forms.Size LandscapeSize
        {
            get { return _landscape_size; }
            internal set
            {
                _landscape_size = value;
                ImeSetSize((int)PortraitSize.Width, (int)PortraitSize.Height,
                           (int)LandscapeSize.Width, (int)LandscapeSize.Height);
            }
        }

        public IMEWindow() : base()
        {
            if (_portrait_size.Width == 0 || _portrait_size.Height == 0)
            {
                Log.Warn(LogTag, "The width and/or height of portrait IME size contains value 0");
            }
            if (_landscape_size.Width == 0 || _landscape_size.Height == 0)
            {
                Log.Warn(LogTag, "The width and/or height of landscape IME size contains value 0");
            }

            ImeSetSize((int)PortraitSize.Width, (int)PortraitSize.Height,
                       (int)LandscapeSize.Width, (int)LandscapeSize.Height);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            /* We are acquiring IME Window's pointer which is expected to be created
             * when calling Create() function of the InputMethodEditor class */
            IntPtr handle = ImeGetMainWindow();
            Log.Info(LogTag, "ImeGetMainWindow returned : " + handle.ToString());

            return handle;
        }
    }

    public class IMEApplication : Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected IMEApplication()
        {
        }

        public Xamarin.Forms.Size PortraitSize
        {
            get { return IMEWindow.PortraitSize; }
            set { IMEWindow.PortraitSize = value; }
        }

        public Xamarin.Forms.Size LandscapeSize
        {
            get { return IMEWindow.LandscapeSize; }
            set { IMEWindow.LandscapeSize = value; }
        }

        protected override void OnPreCreate()
        {
            try
            {
                Application.ClearCurrent();

                /* Since the IMEWindow class acquires window handle from InputMethod module
                 * which is created internally when calling InputMethodEditor.Create() function,
                 * this needs to be called BEFORE creating new IMEWindow instance. */
                InputMethod.InputMethodEditor.Create();

                MainWindow = new IMEWindow();
                MainWindow.IndicatorMode = IndicatorMode.Hide;
                MainWindow.Show();
            }
            catch (Exception e)
            {
                Log.Error("EXCEPTION", "Exception caught : " + e.ToString());
            }
        }

        protected override void OnTerminate()
        {
            InputMethod.InputMethodEditor.Destroy();
            base.OnTerminate();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}
