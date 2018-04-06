namespace Tizen.Appium
{
    /// <summary>
    /// This class is to start/stop service for UI test.
    /// </summary>
    public class TizenAppium
    {
        static bool IsInitialized { get; set; }

        static readonly string Tag = "TizenAppium";

        static TizenAppiumDbus _dbus;
        static TizenAppiumElement _elementManager;

        /// <summary>
        /// Starts a service to communicate with UI automator.
        /// </summary>
        /// <param name="app"> The application to be tested.</param>
        public static void StartService(Xamarin.Forms.Application app = null)
        {
            Log.Debug("StartService : initialize dbus");

            if (IsInitialized)
                return;

            _dbus = new TizenAppiumDbus();
            _elementManager = new TizenAppiumElement(app);

            IsInitialized = true;
        }

        /// <summary>
        /// Stops service.
        /// </summary>
        public static void StopService()
        {
            Log.Debug("StopService");
            _dbus.Dispose();
            IsInitialized = false;
        }
    }
}