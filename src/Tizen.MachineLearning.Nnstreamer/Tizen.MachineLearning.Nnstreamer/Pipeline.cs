/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
*
* Licensed under the Apache License, Version 2.0 (the License);
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an AS IS BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using Log = Tizen.Log;

namespace Tizen.MachineLearning.Nnstreamer
{
    /// <summary>
    /// The Pipeline API provides interfaces to create and execute stream pipelines with neural networks and sensors.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <remarks>
    /// The Pipeline API creates a stream pipeline with NNStreamer plugins, GStreamer plugins, and sensor input devices.
    /// It provides the interface to push data to the pipeline from the application get the inference result from the pipeline to the application.
    /// It also provides the Interfaces to start/stop/destroy the pipeline and other utility functions such as controling switches and valves in the pipeline.
    /// </remarks>
    public class Pipeline
    {
        static string Tag = "Nnstreamer.Pipeline";
        private IntPtr _pipelineHandle;
        private string _pipelineDescription;

        /// <summary>
        /// Initializes a new instance of the Pipeline class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Pipeline()
        {
            _pipelineHandle = IntPtr.Zero;
            _pipelineDescription = null;
        }

        /// <summary>
        /// API to construct the pipeline (GStreamer + NNStreamer)
        /// </summary>
        /// <param name="pipelineDesc">
        /// The pipeline description compatible with GStreamer gst_parse_launch(). 
        /// Refer to GStreamer manual or NNStreamer (github.com/nnsuite/nnstreamer) documentation for examples and the grammar.
        /// </param>
        /// <exception cref="InvalidParameter">Invalid Parameter</exception>
        /// <exception cref="IOException">Pipeline construction is failed because of wrong parameter or initialization failure.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void Construct(string pipelineDesc)
        {
            NNStreamerError ret = NNStreamerError.None;
            _pipelineDescription = pipelineDesc;

            ret = Interop.Pipeline.Construct(_pipelineDescription, out _pipelineHandle);
            if (ret != NNStreamerError.None)
            {
                Log.Error(Tag, "unable to construct pipeline: " + _pipelineDescription);
                throw NNStreamerExceptionFactory.CreateException(ret, "unable to construct pipeline: " + _pipelineDescription);
            }
            return;
        }

        /// <summary>
        /// API to destroy the pipeline
        /// </summary>
        /// <exception cref="InvalidParameter">Invalid Parameter</exception>
        /// <exception cref="IOException">Pipeline destruction is failed because of wrong parameter or initialization failure.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void Destroy()
        {
            NNStreamerError ret = NNStreamerError.None;

            ret = Interop.Pipeline.Destroy(_pipelineHandle);
            if (ret != NNStreamerError.None)
            {
                Log.Error(Tag, "unable to destroy pipeline");
                throw NNStreamerExceptionFactory.CreateException(ret, "unable to destroy pipeline");
            }
            return;
        }
    }
}