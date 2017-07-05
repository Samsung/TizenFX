
using System;
//using Tizen;
using Tizen.NUI;

namespace Tizen.NUI.Extension.Test
{
    public class ActorTest : Actor
    {
        public Actor CreateActor()
        {
            Actor _actor = new Actor();
            //Tizen.Log.Debug("NUI-EXT", "_actor id=" + _actor.GetId());
            _actor.SetName("actor-extension-test id:" + _actor.GetId());
            //Tizen.Log.Debug("NUI-EXT", "_actor name=" + _actor.GetName());
            return _actor;
        }
    }
}
