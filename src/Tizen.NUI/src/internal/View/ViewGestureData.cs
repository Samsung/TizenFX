/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;

namespace Tizen.NUI.BaseComponents
{
    internal class ViewGestureData
    {
        private PanGestureDetector _panGestureDetector;
        private LongPressGestureDetector _longGestureDetector;
        private PinchGestureDetector _pinchGestureDetector;
        private TapGestureDetector _tapGestureDetector;
        private RotationGestureDetector _rotationGestureDetector;

        public void ConfigGestureDetector(View targetView, bool dispatch)
        {
            if (dispatch && _panGestureDetector != null)
            {
                _panGestureDetector.Detach(targetView);
                _longGestureDetector.Detach(targetView);
                _pinchGestureDetector.Detach(targetView);
                _tapGestureDetector.Detach(targetView);
                _rotationGestureDetector.Detach(targetView);

                _panGestureDetector.Detected -= OnGestureDetected;
                _longGestureDetector.Detected -= OnGestureDetected;
                _pinchGestureDetector.Detected -= OnGestureDetected;
                _tapGestureDetector.Detected -= OnGestureDetected;
                _rotationGestureDetector.Detected -= OnGestureDetected;
            }
            else if (!dispatch && _panGestureDetector == null)
            {
                _panGestureDetector = new PanGestureDetector();
                _longGestureDetector = new LongPressGestureDetector();
                _pinchGestureDetector = new PinchGestureDetector();
                _tapGestureDetector = new TapGestureDetector();
                _rotationGestureDetector = new RotationGestureDetector();

                _panGestureDetector.Attach(targetView);
                _longGestureDetector.Attach(targetView);
                _pinchGestureDetector.Attach(targetView);
                _tapGestureDetector.Attach(targetView);
                _rotationGestureDetector.Attach(targetView);

                _panGestureDetector.Detected += OnGestureDetected;
                _longGestureDetector.Detected += OnGestureDetected;
                _pinchGestureDetector.Detected += OnGestureDetected;
                _tapGestureDetector.Detected += OnGestureDetected;
                _rotationGestureDetector.Detected += OnGestureDetected;
            }
        }

        public void Clear()
        {
            _panGestureDetector?.Dispose();
            _panGestureDetector = null;
            _longGestureDetector?.Dispose();
            _longGestureDetector = null;
            _pinchGestureDetector?.Dispose();
            _pinchGestureDetector = null;
            _tapGestureDetector?.Dispose();
            _tapGestureDetector = null;
            _rotationGestureDetector?.Dispose();
            _rotationGestureDetector = null;
        }

        private void OnGestureDetected(object source, EventArgs e)
        {
            // Does nothing. This is to consume the gesture.
        }
    }
}
