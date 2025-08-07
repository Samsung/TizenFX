/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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

namespace Tizen.AIAvatar
{
    internal class PreEmphasis
    {
        internal static void PreEmphasize(ref float[] block, float value)
        {
            float prevSample = block[0];

            for (int i = 0; i < block.Length; i++)
            {
                var result = block[i] - prevSample * value;
                prevSample = block[i];
                block[i] = result;
            }
        }
    }
}