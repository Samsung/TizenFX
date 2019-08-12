using System;
using System.Collections.Generic;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// The class for supporting multi-components based application model.
    /// </summary>
    public class CBApplicationBase : Application
    {
        private bool _disposedValue = false;
        internal static readonly string LogTag = typeof(CBApplicationBase).Namespace;
        internal IList<BaseType> ComponentTypes = new List<BaseType>();
        private Interop.CBApplication.CBAppLifecycleCallbacks _callbacks;

        /// <summary>
        /// Initializes the CBApplicationBase class.
        /// </summary>
        /// <param name="typeInfo">The compnent type information.</param>
        /// <since_tizen> 6 </since_tizen>
        public CBApplicationBase(IDictionary<Type, string> typeInfo)
        {
            _callbacks.OnInit = new Interop.CBApplication.CBAppInitCallback(OnInitNative);
            _callbacks.OnFini = new Interop.CBApplication.CBAppFiniCallback(OnFiniNative);
            _callbacks.OnRun = new Interop.CBApplication.CBAppRunCallback(OnRunNative);
            _callbacks.OnExit = new Interop.CBApplication.CBAppExitCallback(OnExitNative);
            _callbacks.OnCreate = new Interop.CBApplication.CBAppCreateCallback(OnCreateNative);
            _callbacks.OnTerminate = new Interop.CBApplication.CBAppTerminateCallback(OnTerminateNative);

            foreach (Type t in typeInfo.Keys)
            {
                RegisterComponent(typeInfo[t], t);
            }
        }

        /// <summary>
        /// Runs the application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        /// <since_tizen> 6 </since_tizen>
        public override void Run(string[] args)
        {
            base.Run(args);

            string[] argsClone = new string[args.Length + 1];
            if (args.Length > 1)
            {
                args.CopyTo(argsClone, 1);
            }
            argsClone[0] = string.Empty;

            Interop.CBApplication.ErrorCode err = Interop.CBApplication.BaseMain(argsClone.Length, argsClone, ref _callbacks, IntPtr.Zero);
            if (err != Interop.CBApplication.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to run the application. Err = " + err);
            }
        }

        /// <summary>
        /// Exits the main loop of the application.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public override void Exit()
        {
            Interop.CBApplication.BaseExit();
        }

        /// <summary>
        /// Registers a component.
        /// </summary>
        /// <param name="compId">Component ID</param>
        /// <param name="compType">Class type</param>
        public void RegisterComponent(string compId, Type compType)
        {
            if (compType.BaseType == typeof(BaseComponent))
            {
                Log.Info(LogTag, "Add base comp");
                BaseComponent b = Activator.CreateInstance(compType) as BaseComponent;
                ComponentTypes.Add(new BaseType(compType, compId, b.GetComponentType()));
            }
            else if (compType.BaseType == typeof(FrameComponent))
            {
                Log.Info(LogTag, "Add frame comp");
                ComponentTypes.Add(new FrameType(compType, compId));
            }
            else if (compType.BaseType == typeof(ServiceComponent))
            {
                Log.Info(LogTag, "Add service comp");
                ComponentTypes.Add(new ServiceType(compType, compId));
            }
        }

        /// <summary>
        /// Registers a component.
        /// </summary>
        /// <param name="typeInfo">Class type</param>
        public void RegisterComponent(IDictionary<Type, string> typeInfo)
        {
            foreach (Type t in typeInfo.Keys)
            {
                RegisterComponent(typeInfo[t], t);
            }
        }

        private IntPtr OnCreateNative(IntPtr data)
        {
            Log.Debug(LogTag, "On create");
            IntPtr h = IntPtr.Zero;
            foreach (BaseType type in ComponentTypes)
            {
                if (type.GetComponentType() == BaseComponent.ComponentType.Frame)
                {
                    FrameType ft = (FrameType)type;
                    h = ft.Bind(h);
                    Log.Debug(LogTag, "Bind frame comp");
                }
                else if (type.GetComponentType() == BaseComponent.ComponentType.Service)
                {
                    ServiceType st = (ServiceType)type;
                    h = st.Bind(h);
                    Log.Debug(LogTag, "Bind service comp");
                }
                else
                {
                    BaseType bt = (BaseType)type;
                    h = bt.Bind(h);
                    Log.Debug(LogTag, "Bind base comp");
                }
            }

            return h;
        }

        private void OnTerminateNative(IntPtr data)
        {
        }

        private void OnRunNative(IntPtr data)
        {
            OnRun();
        }

        private void OnExitNative(IntPtr data)
        {
            OnExit();
        }

        private void OnInitNative(int argc, string[] argv, IntPtr userData)
        {
            OnInit(argv);
        }

        private void OnFiniNative(IntPtr data)
        {
            OnFini();
        }

        /// <summary>
        /// This method will be called before running main-loop
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnInit(string[] args)
        {
        }

        /// <summary>
        /// This method will be called after exiting main-loop
        /// </summary>
        protected virtual void OnFini()
        {
        }

        /// <summary>
        /// This method will be called to start main-loop
        /// </summary>
        protected virtual void OnRun()
        {
        }

        /// <summary>
        /// This method will be called to exit main-loop
        /// </summary>
        protected virtual void OnExit()
        {
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _disposedValue = true;
            }
            base.Dispose(disposing);
        }
    }
}
