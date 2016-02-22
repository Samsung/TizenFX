using System;

namespace Tizen.Application
{
    public abstract class Actor
    {
        private enum State
        {
            Unknown,
            Created,
            Started,
            Resumed,
            Pasued
        }

        private ApplicationContext _context;
        private State _state = State.Unknown;
        private AppControl _appcontrol;

        protected Page MainPage { get; set; }
        protected AppControl ReceivedAppControl { get { return _appcontrol; } }

        protected virtual void OnCreate() { }
        protected virtual void OnStart() { }
        protected virtual void OnPause() { }
        protected virtual void OnResume() { }
        protected virtual void OnTerminate() { }

        internal void Create(ApplicationContext context)
        {
            if (_state != State.Created)
            {
                _context = context;
                OnCreate();
                _state = State.Created;
            }
        }

        internal void Start(AppControl appControl)
        {
            if (_state != State.Started)
            {
                _appcontrol = appControl;
                OnStart();
                _state = State.Started;
            }
        }

        internal void Pause()
        {
            if (_state != State.Pasued)
            {
                OnPause();
                _state = State.Pasued;
            }
        }

        internal void Resume()
        {
            if (_state != State.Resumed)
            {
                OnResume();
                _state = State.Resumed;
            }
        }

        protected void StartActor(Type actorType, AppControl appControl)
        {
            _context.StartActor(actorType, appControl);

        }

        protected void StartActor(Actor actor, AppControl appControl)
        {
            _context.StartActor(actor, appControl);
        }

        public void Finish()
        {
            throw new NotImplementedException();
        }
    }
}
