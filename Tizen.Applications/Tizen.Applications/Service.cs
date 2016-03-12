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
    public abstract class Service : Context
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler Created;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler Started;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler Destroyed;

        internal void OnCreate(AppControl control)
        {
            _control = control;
            if (Created != null)
            {
                Created(this, EventArgs.Empty);
            }
        }

        internal void OnStart()
        {
            if (Started != null)
            {
                Started(this, EventArgs.Empty);
            }
        }

        internal void OnDestroy()
        {
            if (Destroyed != null)
            {
                Destroyed(this, EventArgs.Empty);
            }
        }
    }
}
