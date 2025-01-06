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

using System;

namespace Tizen.AIAvatar
{
    internal class DCT
    {
        private int dctSize;
        private int featureCount;

        private float[][] dctMatrix;

        public DCT(int filterBankSize, int featureCount = 12)
        {
            dctSize = filterBankSize;
            this.featureCount = featureCount;

            dctMatrix = new float[dctSize][];

            float m = MathF.PI / (dctSize << 1);

            for (var k = 0; k < dctSize; k++)
            {
                dctMatrix[k] = new float[dctSize];

                for (var n = 0; n < dctSize; n++)
                {
                    dctMatrix[k][n] = (float)(2 * Math.Cos(((n << 1) + 1) * k * m));
                }
            }
        }

        public void DirectNorm(float[] input, float[] output)
        {

            var norm0 = (float)Math.Sqrt(0.5f);
            var norm = (float)Math.Sqrt(0.5f / dctSize);

            for (var k = 0; k < featureCount; k++)
            {
                output[k] = 0.0f;
                for (var n = 0; n < input.Length; n++)
                {
                    output[k] += input[n] * dctMatrix[k][n];
                }
                output[k] *= norm;
            }
            output[0] *= norm0;
        }
    }
}