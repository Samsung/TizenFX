using System;

namespace Tizen.Applications
{
    public abstract class Actor : Context
    {
        protected virtual void OnPaused() { }
        protected virtual void OnResumed() { }

        internal void Pause()
        {
            OnPaused();
        }

        internal void Resume()
        {
            OnResumed();
        }

        protected void StartActor(Actor actor, AppControl control)
        {
            Actor target = (Actor)CurrentGroup.MoveToTop(actor);
            if (target != null)
            {
                Pause();
                target.Start(control);
                target.Resume();
            }
        }

        protected override void StartActor(Type actorType, AppControl control)
        {
            Application.StartActor(CurrentGroup, actorType, control);
        }

        protected override void Finish()
        {
            Application.StopActor(CurrentGroup, this);
        }

    }
}

