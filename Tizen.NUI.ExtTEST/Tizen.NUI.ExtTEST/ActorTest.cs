using System;
using Tizen.NUI;
using Tizen;

namespace Tizen.NUI.ExtTEST
{
    public class ActorEXT : Actor
    {

        public Actor CreateActor()
        {
            Actor _actor = new Actor();
            Log.Debug("NUI-EXT", "_actor id=" + _actor.GetId());
            _actor.SetName("actor extension test");
            Log.Debug("NUI-EXT", "_actor name=" + _actor.GetName());
            return _actor;
        }
    }
}
