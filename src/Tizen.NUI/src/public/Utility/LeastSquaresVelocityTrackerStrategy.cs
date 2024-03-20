/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd.
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

/*
 * Copyright (C) 2017 The Android Open Source Project
 *
 * Modified by Joogab Yun(joogab.yun@samsung.com)
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Utility
{
    /*
    * Velocity tracker algorithm based on least-squares linear regression.
    */
    internal class LeastSquaresVelocityTrackerStrategy : AccumulatingVelocityTrackerStrategy
    {
        public enum Weighting
        {
            None,     // No weights applied.  All data points are equally reliable.
            Delta,    // Weight by time delta.  Data points clustered together are weighted less.
            Central,  // Weight such that points within a certain horizon are weighed more than those outside of that horizon.
            Recent    // Weight such that points older than a certain amount are weighed less.
        }

        private const int mMaximumTime = 100;  //100ms
        private int mDegree;
        private Weighting mWeighting;

        /// <summary>
        /// Create an instance of LeastSquaresVelocityTrackerStrategy.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LeastSquaresVelocityTrackerStrategy(int degree, Weighting weighting = Weighting.Delta) : base(mMaximumTime)
        {
            mDegree = degree;
            mWeighting = weighting;
        }

        private T[] GetSlice<T>(T[,] array, int row)
        {
            int cols = array.GetLength(1);
            var slice = new T[cols];
            for (int col = 0; col < cols; col++)
            {
                slice[col] = array[row, col];
            }
            return slice;
        }

        private float vectorDot(float[] a, float[] b, int m)
        {
            float r = 0;
            for (int i = 0; i < m; i++)
            {
                r += a[i] * b[i];
            }
            return r;
        }

        private float vectorNorm(float[] a, int m)
        {
            float r = 0;
            for (int i = 0; i < m; i++)
            {
                r += a[i] * a[i];
            }
            return (float)Math.Sqrt((double)r);
        }

        /// <summary>
        /// Retrieve the last computed velocity
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float? GetVelocity(int pointerId)
        {
            if (!mMovements.ContainsKey(pointerId)) return null;

            List<Movement> movements = mMovements[pointerId];
            int size = movements.Count;
            if (size == 0) return null;

            int degree = mDegree;
            if (degree > size - 1)
            {
                degree = size - 1;
            }

            if (degree <= 0) return null;

            if (degree == 2 && mWeighting == Weighting.None)
            {
                return solveUnweightedLeastSquaresDeg2(movements);
            }

            List<float> positions = new List<float>();
            List<float> w = new List<float>();
            List<float> time = new List<float>();
            Movement newestMovement = movements[size - 1];
            for (int i = size - 1; i >= 0; i--)
            {
                Movement movement = movements[i];
                uint age = newestMovement.EventTime - movement.EventTime;
                positions.Add(movement.Position);
                w.Add(chooseWeight(pointerId, i));
                time.Add(-age);
            }
            return solveLeastSquares(time, positions, w, degree + 1);
        }

        private float chooseWeight(int pointerId, int index)
        {
            List<Movement> movements = mMovements[pointerId];
            int size = movements.Count;
            switch (mWeighting)
            {
                case Weighting.Delta:
                    {

                        if (index == size - 1)
                        {
                            return 1.0f;
                        }
                        float deltaMillis =
                                (movements[index + 1].EventTime - movements[index].EventTime);

                        if (deltaMillis < 0)
                        {
                            return 0.5f;
                        }
                        if (deltaMillis < 10)
                        {
                            return 0.5f + deltaMillis * 0.05f;
                        }
                        return 1.0f;
                    }
                case Weighting.Central:
                    {
                        // Weight points based on their age, weighing very recent and very old points less.
                        //   age  0ms: 0.5
                        //   age 10ms: 1.0
                        //   age 50ms: 1.0
                        //   age 60ms: 0.5
                        float ageMillis =
                                (movements[size - 1].EventTime - movements[index].EventTime);
                        if (ageMillis < 0)
                        {
                            return 0.5f;
                        }
                        if (ageMillis < 10)
                        {
                            return 0.5f + ageMillis * 0.05f;
                        }
                        if (ageMillis < 50)
                        {
                            return 1.0f;
                        }
                        if (ageMillis < 60)
                        {
                            return 0.5f + (60 - ageMillis) * 0.05f;
                        }
                        return 0.5f;
                    }
                case Weighting.Recent:
                    {
                        // Weight points based on their age, weighing older points less.
                        //   age   0ms: 1.0
                        //   age  50ms: 1.0
                        //   age 100ms: 0.5
                        float ageMillis =
                                (movements[size - 1].EventTime - movements[index].EventTime);
                        if (ageMillis < 50)
                        {
                            return 1.0f;
                        }
                        if (ageMillis < 100)
                        {
                            return 0.5f + (100 - ageMillis) * 0.01f;
                        }
                        return 0.5f;
                    }
                case Weighting.None:
                    return 1.0f;
            }
            return 0.0f;
        }

        private float? solveLeastSquares(List<float> x, List<float> y, List<float> w, int n)
        {
            int m = x.Count;
            float[,] a = new float[n, m];
            for (int h = 0; h < m; h++)
            {
                a[0, h] = w[h];
                for (int i = 1; i < n; i++)
                {
                    a[i, h] = a[i - 1, h] * x[h];
                }
            }

            float[,] q = new float[n, m];
            float[,] r = new float[n, m];
            for (int j = 0; j < n; j++)
            {
                for (int h = 0; h < m; h++)
                {
                    q[j, h] = a[j, h];
                }
                for (int i = 0; i < j; i++)
                {

                    float dot = vectorDot(GetSlice(q, j), GetSlice(q, i), m);
                    for (int h = 0; h < m; h++)
                    {
                        q[j, h] -= dot * q[i, h];
                    }
                }
                float norm = vectorNorm(GetSlice(q, j), m);
                if (norm < 0.000001f)
                {
                    return null;
                }
                float invNorm = 1.0f / norm;
                for (int h = 0; h < m; h++)
                {
                    q[j, h] *= invNorm;
                }
                for (int i = 0; i < n; i++)
                {
                    r[j, i] = i < j ? 0 : vectorDot(GetSlice(q, j), GetSlice(a, i), m);
                }
            }

            float[] wy = new float[m];
            for (int h = 0; h < m; h++)
            {
                wy[h] = y[h] * w[h];
            }
            float[] outB = new float[5];
            for (int i = n; i != 0;)
            {
                i--;
                outB[i] = vectorDot(GetSlice(q, i), wy, m);
                for (int j = n - 1; j > i; j--)
                {
                    outB[i] -= r[i, j] * outB[j];
                }
                outB[i] /= r[i, i];
            }
            float ymean = 0.0f;
            for (int h = 0; h < m; h++)
            {
                ymean += y[h];
            }
            ymean /= m;
            return outB[1];
        }

        // Velocity tracker algorithm based on least-squares linear regression.
        private float? solveUnweightedLeastSquaresDeg2(List<Movement> movements)
        {
            float sxi = 0, sxiyi = 0, syi = 0, sxi2 = 0, sxi3 = 0, sxi2yi = 0, sxi4 = 0;
            int count = movements.Count;
            Movement newestMovement = movements[count - 1];
            for (int i = 0; i < count; i++)
            {
                Movement movement = movements[i];
                uint age = newestMovement.EventTime - movement.EventTime;
                float xi = -age;
                float yi = movement.Position;
                float xi2 = xi * xi;
                float xi3 = xi2 * xi;
                float xi4 = xi3 * xi;
                float xiyi = xi * yi;
                float xi2yi = xi2 * yi;
                sxi += xi;
                sxi2 += xi2;
                sxiyi += xiyi;
                sxi2yi += xi2yi;
                syi += yi;
                sxi3 += xi3;
                sxi4 += xi4;
            }
            float Sxx = sxi2 - sxi * sxi / count;
            float Sxy = sxiyi - sxi * syi / count;
            float Sxx2 = sxi3 - sxi * sxi2 / count;
            float Sx2y = sxi2yi - sxi2 * syi / count;
            float Sx2x2 = sxi4 - sxi2 * sxi2 / count;
            float denominator = Sxx * Sx2x2 - Sxx2 * Sxx2;
            if (denominator == 0)
            {
                return null;
            }
            return (Sxy * Sx2x2 - Sx2y * Sxx2) / denominator;
        }
    }
}
