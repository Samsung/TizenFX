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
    internal class InvalidVowelTypeException : Exception
    {
        public InvalidVowelTypeException() { }

        public InvalidVowelTypeException(string name)
            : base($"Not supported vowel type, {name}") { }
    }

    internal class FailedPersonalizeException : Exception
    {
        public FailedPersonalizeException() { }

        public FailedPersonalizeException(string name)
            : base($"Failed to personalize, file_path : {name}") { }
    }

    internal class NotInitializedException : Exception
    {
        public NotInitializedException()
            : base($"Animation Converter should be initialized with viseme_info") { }
    }
}
