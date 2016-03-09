/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;

namespace Tizen.Applications
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Context
    {
        private AppControl _control;

        /// <summary>
        /// 
        /// </summary>
        protected AppControl ReceivedAppControl
        {
            get
            {
                return _control;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnCreated() { }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnStarted() { }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnTerminated() { }

        internal void Create()
        {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actorType"></param>
        /// <param name="control"></param>
        protected abstract void StartActor(Type actorType, AppControl control);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="control"></param>
        protected void StartService(Type serviceType, AppControl control)
        {
            Application.StartService(serviceType, control);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        protected void StopService(Type serviceType)
        {
            Application.StopService(serviceType);
        }

        /// <summary>
        /// 
        /// </summary>
        protected abstract void Finish();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="destination"></param>
        protected void SendAppControl(AppControl control, string destination)
        {
            throw new NotImplementedException();
        }
    }
}
