using System;
using System.ComponentModel;

namespace Tizen.WindowSystem
{
    /// <summary>
    /// Class for Edge Drag Gesture.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class EdgeDragGesture : Gesture
    {
        int _fingers;
        GestureEdge _edge;

        internal EdgeDragGesture(InputGesture parent, SafeHandles.InputGestureHandle handler, IntPtr data, int fingers, GestureEdge edge) : base(parent, handler, data)
        {
            _fingers = fingers;
            _edge = edge;
            _parent.EdgeDragEventHandler += OnEdgeDragDetected;
        }

        internal override void FreeNative()
        {
            Interop.InputGesture.EdgeDragFree(_handler, _data);
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_parent != null)
                {
                   _parent.EdgeDragEventHandler -= OnEdgeDragDetected;
                }
            }
            base.Dispose(disposing);
        }

        void OnEdgeDragDetected(object sender, EdgeDragEventArgs e)
        {
            if (e.Edge == _edge && e.Fingers == _fingers)
            {
                Detected?.Invoke(this, e);
            }
        }

        /// <summary>
        /// Occurs when the edge drag gesture is detected.
        /// </summary>
        public event EventHandler<EdgeDragEventArgs> Detected;

        /// <summary>
        /// Sets the size of the edge drag gesture.
        /// </summary>
        /// <param name="edgeSize">The enum of gesture edge size.</param>
        /// <param name="startPoint">The start point of edge area.</param>
        /// <param name="endPoint">The end point of edge area.</param>
        /// <exception cref="InvalidOperationException">Thrown when operation fails.</exception>
        public void SetSize(GestureEdgeSize edgeSize, int startPoint, int endPoint)
        {
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.EdgeDragSizeSet(_data, edgeSize, startPoint, endPoint);
             if (res != Interop.InputGesture.ErrorCode.None)
                throw new InvalidOperationException($"Failed to set edge drag size: {res}");
        }
    }
}
