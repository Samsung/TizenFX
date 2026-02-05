using System;
using System.ComponentModel;

namespace Tizen.WindowSystem
{
    /// <summary>
    /// Class for Edge Swipe Gesture.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class EdgeSwipeGesture : Gesture
    {
        private int _fingers;
        private GestureEdge _edge;

        internal EdgeSwipeGesture(InputGesture parent, SafeHandles.InputGestureHandle handler, IntPtr data, int fingers, GestureEdge edge) : base(parent, handler, data)
        {
            _fingers = fingers;
            _edge = edge;
            _parent.EdgeSwipeEventHandler += OnEdgeSwipeDetected;
        }

        internal override void FreeNative()
        {
            Interop.InputGesture.EdgeSwipeFree(_handler, _data);
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_parent != null)
                {
                    _parent.EdgeSwipeEventHandler -= OnEdgeSwipeDetected;
                }
            }
            base.Dispose(disposing);
        }

        void OnEdgeSwipeDetected(object sender, EdgeSwipeEventArgs e)
        {
            if (e.Edge == _edge && e.Fingers == _fingers)
            {
                Detected?.Invoke(this, e);
            }
        }

        /// <summary>
        /// Occurs when the edge swipe gesture is detected.
        /// </summary>
        public event EventHandler<EdgeSwipeEventArgs> Detected;

        /// <summary>
        /// Sets the size of the edge swipe gesture.
        /// </summary>
        /// <param name="edgeSize">The enum of gesture edge size.</param>
        /// <param name="startPoint">The start point of edge area.</param>
        /// <param name="endPoint">The end point of edge area.</param>
        /// <exception cref="InvalidOperationException">Thrown when operation fails.</exception>
        public void SetSize(GestureEdgeSize edgeSize, int startPoint, int endPoint)
        {
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.EdgeSwipeSizeSet(_data, edgeSize, startPoint, endPoint);
             if (res != Interop.InputGesture.ErrorCode.None)
                throw new InvalidOperationException($"Failed to set edge swipe size: {res}");
        }
    }
}
