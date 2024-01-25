/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    internal enum ToolkitPropertyRange
    {
        VISUAL_PROPERTY_BASE_START_INDEX = PropertyRanges.CORE_PROPERTY_MAX_INDEX + 1,
        VISUAL_PROPERTY_BASE_END_INDEX = VISUAL_PROPERTY_BASE_START_INDEX + 100,
        VISUAL_PROPERTY_START_INDEX = VISUAL_PROPERTY_BASE_END_INDEX + 1,
        VISUAL_PROPERTY_END_INDEX = VISUAL_PROPERTY_START_INDEX + 100000
    }
}
