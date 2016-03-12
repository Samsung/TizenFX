/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using Tizen.UI;

namespace Tizen.Applications
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Actor : Context
    {
        private ActorState _state = ActorState.None;

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
        public event EventHandler Resumed;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler Paused;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler Destroyed;

        private enum ActorState
        {
            None = 0,
            Created = 1,
            Started = 2,
            Resumed = 3,
            Pasued = 4
        }

        internal Guid TaskId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        internal protected Page MainPage { get; set; }
        
        internal void OnCreate(Guid taskId, AppControl control)
        {
            if (_state != ActorState.Created)
            {
                TaskId = taskId;
                _control = control;
                _state = ActorState.Created;
                if (Created != null)
                {
                    Created(this, EventArgs.Empty);
                }
            }
        }

        internal void OnStart()
        {
            if (_state != ActorState.Started)
            {
                _state = ActorState.Started;
                if (Started != null)
                {
                    Started(this, EventArgs.Empty);
                }
            }
        }

        internal void OnPause()
        {
            if (_state != ActorState.Pasued)
            {
                _state = ActorState.Pasued;
                if (Paused != null)
                {
                    Paused(this, EventArgs.Empty);
                }
            }
        }

        internal void OnResume()
        {
            if (_state != ActorState.Resumed)
            {
                _state = ActorState.Resumed;
                if (Resumed != null)
                {
                    Resumed(this, EventArgs.Empty);
                }
                MainPage.Show();
            }
        }

        internal void OnDestroy()
        {
            if (_state != ActorState.None)
            {
                _state = ActorState.None;
                if (Destroyed != null)
                {
                    Destroyed(this, EventArgs.Empty);
                }
            }
        }
    }
}

