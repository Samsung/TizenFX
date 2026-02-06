using System;
using System.ComponentModel;

namespace Tizen.WindowSystem
{
    /// <summary>
    /// Class for Palm Cover Gesture.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PalmCoverGesture : Gesture
    {
        internal PalmCoverGesture(InputGesture parent, SafeHandles.InputGestureHandle handler, IntPtr data) : base(parent, handler, data)
        {
            _parent.PalmCoverEventHandler += OnPalmCoverDetected;
        }

        internal override void FreeNative()
        {
            Interop.InputGesture.PalmCoverFree(_handler, _data);
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_parent != null)
                {
                   _parent.PalmCoverEventHandler -= OnPalmCoverDetected;
                }
            }
            base.Dispose(disposing);
        }

        void OnPalmCoverDetected(object sender, PalmCoverEventArgs e)
        {
             Detected?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when the palm cover gesture is detected.
        /// </summary>
        public event EventHandler<PalmCoverEventArgs> Detected;
    }
}
