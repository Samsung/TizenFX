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
        internal AppControl _control;
        
        [Flags]
        public enum ActorFlags
        {
            NewInstance = 1,
            ClearTop = 2,
            MoveToTop = 4,
        }

        /// <summary>
        /// 
        /// </summary>
        protected AppControl AppControl
        {
            get
            {
                return _control;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actorType"></param>
        /// <param name="control"></param>
        protected void StartActor(Type actorType, AppControl control, ActorFlags flags = ActorFlags.NewInstance)
        {
            Application.StartActor(this, actorType, ActorFlags.NewInstance, control);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="flags"></param>
        protected void StartActor(AppControl control, ActorFlags flags = ActorFlags.NewInstance)
        {
            Application.StartActor(this, null, ActorFlags.NewInstance, control);
        }

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
        /// <param name="control"></param>
        protected void StartService(AppControl control)
        {
            Application.StartService(null, control);
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
        protected void Finish()
        {
            Application.Finish(this);
        }

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
