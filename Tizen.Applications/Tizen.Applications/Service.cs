using System;

namespace Tizen.Applications
{
    public abstract class Service : Context
    {
        protected override void StartActor(Type actorType, AppControl control)
        {
            Application.StartActor(null, actorType, control);
        }

        protected override void Finish()
        {
            Application.StopService(GetType());
        }
    }
}
