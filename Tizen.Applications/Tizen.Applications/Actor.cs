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
        private ActorGroup _group;

        /// <summary>
        /// 
        /// </summary>
        internal protected Page MainPage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnPaused() { }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnResumed() { }

        internal void Create(ActorGroup group)
        {
            _group = group;
            base.Create();
        }

        internal void Pause()
        {
            OnPaused();
        }

        internal void Resume()
        {
            OnResumed();
            MainPage.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="control"></param>
        protected void StartActor(Actor actor, AppControl control)
        {
            _group.StartActor(actor, control);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actorType"></param>
        /// <param name="control"></param>
        protected override void StartActor(Type actorType, AppControl control)
        {
            Application.StartActor(_group, actorType, control);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Finish()
        {
            Application.StopActor(_group, this);
        }
    }
}

