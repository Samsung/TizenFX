using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp
{
    public class EcoreTimelineAnimator
    {
        double _runtime;
        IntPtr _animator;
        Action _timelineCallback;
        Interop.Ecore.EcoreTimelineCallback _nativeCallback;
        double _position;

        public event EventHandler Finished;


        public EcoreTimelineAnimator(double runtime, Action timelineCallback)
        {
            _runtime = runtime;
            _nativeCallback = NativeCallback;
            _timelineCallback = timelineCallback;
            _position = 0;
        }

        public bool IsRunning { get; private set; }
        public double Position => _position;

        public void Start()
        {
            IsRunning = true;
            _animator = Interop.Ecore.ecore_animator_timeline_add(_runtime, _nativeCallback, IntPtr.Zero);
        }

        public void Stop()
        {
            IsRunning = false;
            _animator = IntPtr.Zero;
        }

        public void Freeze()
        {
            Interop.Ecore.ecore_animator_freeze(_animator);
        }

        public void Thaw()
        {
            Interop.Ecore.ecore_animator_thaw(_animator);
        }

        protected void OnTimeline()
        {
            _timelineCallback();
        }

        bool NativeCallback(IntPtr data, double pos)
        {
            _position = pos;
            if (!IsRunning) return false;
            OnTimeline();
            if (pos == 1.0)
            {
                IsRunning = false;
                _animator = IntPtr.Zero;
                Finished?.Invoke(this, EventArgs.Empty);
            }
            return true;
        }
    }
}
