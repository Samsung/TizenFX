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
    internal class FFT
    {
        private int fftSize;

        private float[] re, im;
        private float[] realSpectrum, imagSpectrum;
        private float[] cosTbl, sinTbl;
        private float[] ar, br, ai, bi;

        public FFT(int size)
        {
            fftSize = size / 2;

            // Precalculate FFT Parameter
            re = new float[fftSize];
            im = new float[fftSize];
            realSpectrum = new float[fftSize + 1];
            imagSpectrum = new float[fftSize + 1];

            var tblSize = (int)Math.Log(fftSize, 2);

            cosTbl = new float[tblSize];
            sinTbl = new float[tblSize];

            for (int i = 1, pos = 0; i < fftSize; i *= 2, pos++)
            {
                cosTbl[pos] = (float)Math.Cos(2 * Math.PI * i / fftSize);
                sinTbl[pos] = (float)Math.Sin(2 * Math.PI * i / fftSize);
            }

            ar = new float[fftSize];
            br = new float[fftSize];
            ai = new float[fftSize];
            bi = new float[fftSize];

            var f = MathF.PI / fftSize;

            for (var i = 0; i < fftSize; i++)
            {
                ar[i] = (float)(0.5 * (1 - Math.Sin(f * i)));
                ai[i] = (float)(-0.5 * Math.Cos(f * i));
                br[i] = (float)(0.5 * (1 + Math.Sin(f * i)));
                bi[i] = (float)(0.5 * Math.Cos(f * i));
            }
        }

        public void Direct(float[] input, float[] output)
        {
            for (int i = 0, k = 0; i < fftSize; i++)
            {
                re[i] = input[k++];
                im[i] = input[k++];
            }

            fftSize = Math.Max(fftSize, 0);
            var L = fftSize;
            var M = fftSize >> 1;
            var S = fftSize - 1;
            var ti = 0;
            while (L >= 2)
            {
                var l = L >> 1;
                var u1 = 1.0f;
                var u2 = 0.0f;
                var c = cosTbl[ti];
                var s = -sinTbl[ti];
                ti++;
                for (var j = 0; j < l; j++)
                {
                    for (var i = j; i < fftSize; i += L)
                    {
                        var p = i + l;
                        var t1 = re[i] + re[p];
                        var t2 = im[i] + im[p];
                        var t3 = re[i] - re[p];
                        var t4 = im[i] - im[p];
                        re[p] = t3 * u1 - t4 * u2;
                        im[p] = t4 * u1 + t3 * u2;
                        re[i] = t1;
                        im[i] = t2;
                    }
                    var u3 = u1 * c - u2 * s;
                    u2 = u2 * c + u1 * s;
                    u1 = u3;
                }
                L >>= 1;
            }
            for (int i = 0, j = 0; i < S; i++)
            {
                if (i > j)
                {
                    var t1 = re[j];
                    var t2 = im[j];
                    re[j] = re[i];
                    im[j] = im[i];
                    re[i] = t1;
                    im[i] = t2;
                }
                var k = M;
                while (j >= k)
                {
                    j -= k;
                    k >>= 1;
                }
                j += k;
            }

            realSpectrum[0] = re[0] * ar[0] - im[0] * ai[0] + re[0] * br[0] + im[0] * bi[0];
            imagSpectrum[0] = im[0] * ar[0] + re[0] * ai[0] + re[0] * bi[0] - im[0] * br[0];

            for (var k = 1; k < fftSize; k++)
            {
                realSpectrum[k] = re[k] * ar[k] - im[k] * ai[k] + re[fftSize - k] * br[k] + im[fftSize - k] * bi[k];
                imagSpectrum[k] = im[k] * ar[k] + re[k] * ai[k] + re[fftSize - k] * bi[k] - im[fftSize - k] * br[k];
            }

            realSpectrum[fftSize] = re[0] - im[0];
            imagSpectrum[fftSize] = 0;

            for (int i = 0; i < fftSize; i++)
            {
                output[i] = realSpectrum[i] * realSpectrum[i] + imagSpectrum[i] * imagSpectrum[i];
            }
        }
    }
}