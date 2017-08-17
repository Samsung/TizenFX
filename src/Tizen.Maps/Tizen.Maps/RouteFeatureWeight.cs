/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Maps
{
    /// <summary>
    /// Route feature weights used in route search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum RouteFeatureWeight
    {
        /// <summary>
        /// Indicates normal weighting.
        /// </summary>
        Normal = Interop.RouteFeatureWeight.Normal,
        /// <summary>
        /// Indicates that a feature is preferred.
        /// </summary>
        Prefer = Interop.RouteFeatureWeight.Prefer,
        /// <summary>
        /// Indicates that a feature is to be avoided.
        /// </summary>
        Avoid = Interop.RouteFeatureWeight.Avoid,
        /// <summary>
        /// Indicates that soft-exclude applies to the feature.
        /// </summary>
        SoftExclude = Interop.RouteFeatureWeight.SoftExclude,
        /// <summary>
        /// Indicates that the feature is to be strictly excluded.
        /// </summary>
        StrictExclude = Interop.RouteFeatureWeight.StrictExclude,
    }
}
