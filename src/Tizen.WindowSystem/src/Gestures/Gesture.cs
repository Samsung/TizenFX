using System;
using System.ComponentModel;

namespace Tizen.WindowSystem
{
    /// <summary>
    /// Base class for Tizen Input Gestures.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class Gesture : IDisposable
    {
        internal SafeHandles.InputGestureHandle _handler;
        internal IntPtr _data;
        bool disposed = false;
        internal InputGesture _parent;
        private GestureGrabMode _grabMode;

        internal Gesture(InputGesture parent, SafeHandles.InputGestureHandle handler, IntPtr data)
        {
            _parent = parent;
            _handler = handler;
            _data = data;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                // Managed resources if any
            }
            
            if (_data != IntPtr.Zero && !_handler.IsInvalid)
            {
                FreeNative();
                _data = IntPtr.Zero;
            }
            
            disposed = true;
        }

        internal abstract void FreeNative();


        /// <summary>
        /// Gets or sets the grab mode of the gesture.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when operation fails.</exception>
        public GestureGrabMode GrabMode
        {
            get
            {
                return _grabMode;
            }
            set
            {
                Interop.InputGesture.ErrorCode res = Interop.InputGesture.SetGestureGrabMode(_handler, _data, value);
                if (res != Interop.InputGesture.ErrorCode.None)
                    throw new InvalidOperationException($"Failed to set grab mode: {res}");
                _grabMode = value;
            }
        }

        /// <summary>
        /// Grabs the gesture.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when operation fails.</exception>
        public void Grab()
        {
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.GestureGrab(_handler, _data);
            if (res != Interop.InputGesture.ErrorCode.None)
                throw new InvalidOperationException($"Failed to grab gesture: {res}");
        }

        /// <summary>
        /// Ungrabs the gesture.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when operation fails.</exception>
        public void Ungrab()
        {
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.GestureUngrab(_handler, _data);
             if (res != Interop.InputGesture.ErrorCode.None)
                throw new InvalidOperationException($"Failed to ungrab gesture: {res}");
        }
    }
}
