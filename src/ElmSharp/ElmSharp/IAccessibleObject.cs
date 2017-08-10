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

namespace ElmSharp.Accessible
{
    /// <summary>
    /// IAccessibleObject is a interface which defines properties and methods of accessible object.
    /// </summary>
    public interface IAccessibleObject
    {
        ReadingInfoType ReadingInfoType { get; set; }
        AccessRole Role { get; set; }
        bool CanHighlight { get; set; }
        string TranslationDomain { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        AccessibleInfoProvider NameProvider { get; set; }
        AccessibleInfoProvider DescriptionProvider { get; set; }
        void AppendRelation(IAccessibleRelation relation);
        void RemoveRelation(IAccessibleRelation relation);
        void Highlight();
        void Unhighlight();
    }
}
