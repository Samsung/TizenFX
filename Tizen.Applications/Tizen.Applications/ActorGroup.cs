/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Linq;

namespace Tizen.Applications
{
    internal class ActorGroup
    {
        private readonly List<Actor> _actorList;

        public bool IsEmpty
        {
            get
            {
                return _actorList.Count == 0;
            }
        }

        public Actor TopActor
        {
            get
            {
                return _actorList.LastOrDefault(null);
            }
        }

        public ActorGroup()
        {
            _actorList = new List<Actor>();
        }

        public void StartActor(Type actorType, AppControl control)
        {
            Actor actor = (Actor)Activator.CreateInstance(actorType);
            actor.Create(this);
            if (actor.MainPage == null)
            {
                throw new ArgumentNullException("Actor's MainPage is not set.");
            }

            Actor prevTop = TopActor;
            _actorList.Add(actor);
            if (prevTop != null)
            {
                prevTop.Pause();
            }
            actor.Start(control);
            actor.Resume();
        }

        public void StartActor(Actor actor, AppControl control)
        {
            if (actor.MainPage == null)
            {
                throw new ArgumentNullException("Actor's MainPage is not set.");
            }

            Actor prevTop = TopActor;
            _actorList.Remove(actor);
            _actorList.Add(actor);
            if (prevTop != actor)
            {
                prevTop.Pause();
            }
            actor.Start(control);
            actor.Resume();
        }

        public void StopActor(Actor actor)
        {
            Actor prevTop = TopActor;
            _actorList.Remove(actor);
            actor.Pause();
            actor.Terminate();
            if (prevTop == actor)
            {
                if (TopActor != null)
                {
                    TopActor.Resume();
                }
            }
        }

        public Actor FindActor(Type type)
        {
            return _actorList.Find(s => s.GetType() == type);
        }

        public Actor FindActor(Actor actor)
        {
            return _actorList.Find(s => s == actor);
        }
    }
}
