namespace Tizen.Application {
    public class Service {
        public Service() { }

        public void Terminate()
        {
            Application.StopService(GetType());
        }

        protected virtual void OnCreate() { }
        protected virtual void OnTerminate() { }
        protected virtual void OnAppControl(AppControl appControl) { }

        internal void DidCreate()
        {
            OnCreate();
        }
        internal void DidTerminate()
        {
            OnTerminate();
        }
        internal void DidAppControl(AppControl appControl)
        {
            OnAppControl(appControl);
        }
    }
}
