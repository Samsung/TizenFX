using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Resolution for video recording.
    /// </summary>
    public class RecorderVideoResolution
    {
        private int _width, _height;
        private bool _interopFlag;
        internal IntPtr _videoHandle;

        internal RecorderVideoResolution(IntPtr handle)
        {
            _videoHandle = handle;
            _interopFlag = true;
            int ret = Interop.Recorder.GetVideoResolution(_videoHandle, out _width, out _height);
            RecorderError err = (RecorderError)ret;
            Log.Info(RecorderLog.Tag, "width " + _width + " height " + _height + "return " + err.ToString());
        }

        internal RecorderVideoResolution(int width, int height)
        {
            _interopFlag = false;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// The video width.
        /// </summary>
        /// <value>The width.</value>
        public int Width {
            get {
                if(_interopFlag == true)
                    Interop.Recorder.GetVideoResolution(_videoHandle, out _width, out _height);
                return _width;
            }
            set {
                _width = value;
                if(_interopFlag == true) {
                    int ret = Interop.Recorder.SetVideoResolution(_videoHandle, _width, _height);
                    RecorderError err = (RecorderError)ret;
                    Log.Info(RecorderLog.Tag, " set width " + _width + " height " + _height + "set return " + err.ToString());
                }
            }
        }

        /// <summary>
        /// The video height.
        /// </summary>
        /// <value>The height.</value>
        public int Height {
            get {
                if(_interopFlag == true)
                    Interop.Recorder.GetVideoResolution(_videoHandle, out _width, out _height);
                return _height;
            }
            set {
                _height = value;
                if(_interopFlag == true) {
                    int ret = Interop.Recorder.SetVideoResolution(_videoHandle, _width, _height);
                    RecorderError err = (RecorderError)ret;
                    Log.Info(RecorderLog.Tag, " set width " + _width + " height " + _height + "set return " + err.ToString());
                }
            }
        }
    }
}
