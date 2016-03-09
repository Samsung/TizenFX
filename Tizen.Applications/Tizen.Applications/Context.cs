using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    public abstract class Context
    {
        private ContextGroup _group;
        private AppControl _control;

        internal ContextGroup CurrentGroup
        {
            get
            {
                return _group;
            }
        }

        protected AppControl ReceivedAppControl
        {
            get
            {
                return _control;
            }
        }

        protected virtual void OnCreated() { }
        protected virtual void OnStarted() { }
        protected virtual void OnTerminated() { }

        internal void Create(ContextGroup group)
        {
            _group = group;
            OnCreated();
        }

        internal void Start(AppControl control)
        {
            _control = control;
            OnStarted();
        }

        internal void Terminate()
        {
            OnTerminated();
        }

        protected abstract void StartActor(Type actorType, AppControl control);

        protected void StartService(Type serviceType, AppControl control)
        {
            Application.StartService(serviceType, control);
        }

        protected void StopService(Type serviceType)
        {
            Application.StopService(serviceType);
        }

        protected abstract void Finish();

        protected void SendAppControl(AppControl control, string destination)
        {
            throw new NotImplementedException();
        }
    }
}
