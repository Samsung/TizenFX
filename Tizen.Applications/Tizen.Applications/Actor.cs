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
        internal Guid TaskId { get; set; }

        private enum ActorState
        {
            None = 0,
            Created = 1,
            Started = 2, 
            Resumed = 3,
            Pasued = 4
        }

        private ActorState _state = ActorState.None;

        /// <summary>
        /// 
        /// </summary>
        internal protected Page MainPage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnCreate() { }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnStart() { }

         /// <summary>
        /// 
        /// </summary>
        protected virtual void OnPause() { }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnResume() { }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnDestroy() { }

        internal void Create()
        {
            if (_state != ActorState.Created)
            {
                OnCreate();
                _state = ActorState.Created;
            }
        }

        internal void Start()
        {
            if (_state != ActorState.Started)
            {
                OnStart();
                _state = ActorState.Started;
            }
        }

        internal void Pause()
        {
            if (_state != ActorState.Pasued)
            {
                OnPause();
                _state = ActorState.Pasued;
            }
        }

        internal void Resume()
        {
            if (_state != ActorState.Resumed)
            {
                OnResume();
                _state = ActorState.Resumed;
                MainPage.Show();
            }
        }

        internal void Destroy()
        {
            if (_state != ActorState.None)
            {
                OnDestroy();
                _state = ActorState.None;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="control"></param>
        protected void StartActor(Actor actor, AppControl control)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actorType"></param>
        /// <param name="control"></param>
        protected override void StartActor(Type actorType, AppControl control)
        {

            Application.StartActor(TaskId, actorType, control);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Finish()
        {
            Application.StopActor(this);
        }
    }
}

