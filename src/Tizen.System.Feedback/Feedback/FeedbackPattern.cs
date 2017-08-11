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

namespace Tizen.System
{
    /// <summary>
    /// String and enumeration for feedback patterns.
    /// </summary>
    internal struct FeedbackPattern
    {
        internal int PatternNumber;
        internal string PatternString;

        internal FeedbackPattern(int n, string s)
        {
            PatternNumber = n;
            PatternString = s;
        }
    }
}
