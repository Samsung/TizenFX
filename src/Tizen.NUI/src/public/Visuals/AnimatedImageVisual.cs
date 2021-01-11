/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;

namespace Tizen.NUI
{
    /// <summary>
    /// A class encapsulating the property map of the animated image (AGIF) visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AnimatedImageVisual : VisualMap
    {
        private List<string> _urls = null;
        private int? _batchSize = null;
        private int? _cacheSize = null;
        private float? _frameDelay = null;
        private float? _loopCount = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AnimatedImageVisual() : base()
        {
        }

        /// <summary>
        /// Gets and Sets the url in the AnimatedImageVisual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string URL
        {
            get
            {
                if (_urls != null)
                {
                    return _urls[0];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (_urls == null)
                {
                    _urls = new List<string>();
                    _urls.Add(value);
                }
                else
                {
                    _urls[0] = value;
                }
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets and Sets the url list in the AnimatedImageVisual.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public List<string> URLS
        {
            get
            {
                return _urls;
            }
            set
            {
                _urls = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets and Sets the batch size for pre-loading images in the AnimatedImageVisual.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int BatchSize
        {
            get
            {
                return _batchSize ?? 1;
            }
            set
            {
                _batchSize = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets and Sets the cache size for loading images in the AnimatedImageVisual.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int CacheSize
        {
            get
            {
                return _cacheSize ?? 1;
            }
            set
            {
                _cacheSize = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets and Sets The number of milliseconds between each frame in the AnimatedImageVisual.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public float FrameDelay
        {
            get
            {
                return _frameDelay ?? 0.1f;
            }
            set
            {
                _frameDelay = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets and sets the number of times the AnimatedImageVisual will be looped.
        /// The default is -1. If the number is less than 0 then it loops unlimited,otherwise loop loopCount times.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public float LoopCount
        {
            get
            {
                return _loopCount ?? -1;
            }
            set
            {
                _loopCount = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            if (_urls != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.AnimatedImage));
                if (_urls.Count == 1)
                {
                    _outputVisualMap.Add(ImageVisualProperty.URL, new PropertyValue(_urls[0]));
                }
                else
                {
                    var urlArray = new PropertyArray();
                    foreach (var url in _urls)
                    {
                        urlArray.Add(new PropertyValue(url));
                    }
                    _outputVisualMap.Add(ImageVisualProperty.URL, (new PropertyValue(urlArray)));
                }
                if (_batchSize != null) { _outputVisualMap.Add(ImageVisualProperty.BatchSize, new PropertyValue((int)_batchSize)); }
                if (_cacheSize != null) { _outputVisualMap.Add(ImageVisualProperty.CacheSize, new PropertyValue((int)_cacheSize)); }
                if (_frameDelay != null) { _outputVisualMap.Add(ImageVisualProperty.FrameDelay, new PropertyValue((float)_frameDelay)); }
                if (_loopCount != null) { _outputVisualMap.Add(ImageVisualProperty.LoopCount, new PropertyValue((int)_loopCount)); }
                base.ComposingPropertyMap();
            }
        }
    }
}
