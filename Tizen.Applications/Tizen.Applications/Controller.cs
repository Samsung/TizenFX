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
    public abstract class Controller : Context
    {
        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum ControlFlags
        {
            NewInstance = 1,
            ClearTop = 2,
            MoveToTop = 4,
        }

        /// <summary>
        /// 
        /// </summary>
        protected AppControl AppControl { get; private set; }

        internal virtual void SendCreate()
        {
            AppControl = null;
            OnCreate();
        }

        internal virtual void SendStart(AppControl control)
        {
            AppControl = control;
            OnStart();
        }

        internal virtual void SendDestroy()
        {
            OnDestroy();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnCreate()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnStart()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnDestroy()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="flags"></param>
        protected void StartController(AppControl control, ControlFlags flags = ControlFlags.NewInstance)
        {
            Application.StartController(this, null, control, flags);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controllerType"></param>
        /// <param name="control"></param>
        /// <param name="flags"></param>
        protected void StartController(Type controllerType, AppControl control, ControlFlags flags = ControlFlags.NewInstance)
        {
            Application.StartController(this, controllerType, control, flags);
        }

        protected void StopController(Type controllerType)
        {
            Application.StopController(controllerType);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Finish()
        {
            Application.StopController(GetType());
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
