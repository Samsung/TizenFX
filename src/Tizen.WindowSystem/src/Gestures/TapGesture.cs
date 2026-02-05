using System;
using System.ComponentModel;

namespace Tizen.WindowSystem
{
    /// <summary>
    /// Class for Tap Gesture.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TapGesture : Gesture
    {
        int _fingers;
        int _repeats;

        internal TapGesture(InputGesture parent, SafeHandles.InputGestureHandle handler, IntPtr data, int fingers, int repeats) : base(parent, handler, data)
        {
            _fingers = fingers;
            _repeats = repeats;
            _parent.TapEventHandler += OnTapDetected;
        }

        internal override void FreeNative()
        {
            Interop.InputGesture.TapFree(_handler, _data);
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_parent != null)
                {
                   _parent.TapEventHandler -= OnTapDetected;
                }
            }
            base.Dispose(disposing);
        }

        void OnTapDetected(object sender, TapEventArgs e)
        {
            if (e.Fingers == _fingers && e.Repeats == _repeats)
            {
                Detected?.Invoke(this, e);
            }
        }

        /// <summary>
        /// Occurs when the tap gesture is detected.
        /// </summary>
        public event EventHandler<TapEventArgs> Detected;
    }
}
