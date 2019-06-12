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
using System.IO;
using Tizen.MachineLearning.Nnstreamer;

namespace Tizen.MachineLearning.Nnstreamer.Test
{
    public static class PipelineTest
    {
        const string TAG = "PipelineTest";

        public static bool ConstructDestructTest_Success00()
        {
            bool ret = true;
            Pipeline p = new Pipeline();

            try
            {
                p.Construct("videotestsrc num_buffers=2 ! fakesink");
                p.Destroy();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Fail to ConstructDestructTest_Success00: " + e.Message);
                ret = false;
            }
            return ret;
        }

        public static bool ConstructDestructTest_Failure00()
        {
            bool ret = false;
            Pipeline p = new Pipeline();

            try
            {
                p.Construct("nonexistsrc ! fakesink");
            }
            catch (IOException)
            {
                Tizen.Log.Error(TAG, "ConstructDestructTest_Failure00 test passed!!");
                ret = true;
            }

            if (!ret)
                Tizen.Log.Error(TAG, "Fail to ConstructDestructTest_Failure00");
            return ret;
        }
    }
}
