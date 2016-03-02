using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Application
{
    public class ApplicationContext
    {
        private List<Actor> _actorList;

        internal event EventHandler ReleaseContext;

        internal Actor TopActor { get { return _actorList.LastOrDefault(null); } }

        internal ApplicationContext()
        {
            _actorList = new List<Actor>();
        }

        internal Actor StartActor(Type actorType, AppControl appControl)
        {
            Actor newActor = (Actor)Activator.CreateInstance(actorType);
            _actorList.Add(newActor);
            newActor.Create(this);
            newActor.Start(appControl);
            return newActor;
        }

        internal Actor StartActor(Actor actor, AppControl appControl)
        {
            Actor found = _actorList.Find(s => s == actor);
            if (found == null)
            {
                throw new ArgumentException("Could not found the actor in current context.");
            }
            _actorList.Remove(found);
            _actorList.Add(found);
            found.Start(appControl);
            return found;
        }

        internal void FinishActor(Actor actor)
        {
            Actor found = _actorList.Find(s => s == actor);
            if (found == null)
            {
                throw new ArgumentException("Could not found the actor in current context.");
            }

            found.Pause();
            found.Terminate();
            _actorList.Remove(found);

            if (IsEmpty())
            {
                ReleaseContext(this, null);
            }
        }

        internal void Pause()
        {
            if (TopActor != null)
            {
                TopActor.Pause();
            }
        }

        internal void Resume()
        {
            if (TopActor != null)
            {
                TopActor.Resume();
            }
        }

        internal bool IsEmpty()
        {
            return _actorList.Count == 0;
        }
    }
}
