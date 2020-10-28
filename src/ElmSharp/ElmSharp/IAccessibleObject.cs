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
    /// IAccessibleObject is an interface, which defines the properties and methods of an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public interface IAccessibleObject
    {
        /// <summary>
        /// Gets or sets the reading information types of an accessible object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        ReadingInfoType ReadingInfoType { get; set; }

        /// <summary>
        /// Gets or sets the role of the object in an accessibility domain.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        AccessRole Role { get; set; }

        /// <summary>
        /// Gets or sets the highlightable of the given widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        bool CanHighlight { get; set; }

        /// <summary>
        /// Gets or sets the translation domain of the "name" and "description" properties.
        /// Translation domain should be set if the application wants to support i18n for accessing the "name" and "description" properties.
        /// When the translation domain is set, values of the "name" and "description" properties will be translated with dgettext function using the current translation domain as "domainname" parameter.
        /// It is the application developer's responsibility to ensure that translation files are loaded and binded to the translation domain when accessibility is enabled.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        string TranslationDomain { get; set; }

        /// <summary>
        /// Gets or sets an accessible name of the object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets contextual information about the object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the delegate for <see cref="IAccessibleObject.Name"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        AccessibleInfoProvider NameProvider { get; set; }

        /// <summary>
        /// Gets or sets the delegate for <see cref="IAccessibleObject.Description"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        AccessibleInfoProvider DescriptionProvider { get; set; }

        /// <summary>
        /// Defines the relationship between two accessible objects.
        /// Relationships can be queried by Assistive Technology clients to provide customized feedback, improving overall user experience.
        /// AppendRelation API is asymmetric, which means that appending (For example, relation <see cref="FlowsTo"/> from object A to B) do not append relation <see cref="FlowsFrom"/> from object B to object A.
        /// </summary>
        /// <param name="relation">The relationship between the source object and target object of a given type.</param>
        /// <since_tizen> preview </since_tizen>
        void AppendRelation(IAccessibleRelation relation);

        /// <summary>
        /// Removes the relationship between two accessible objects.
        /// </summary>
        /// <param name="relation">The relationship between the source object and target object of a given type.</param>
        /// <since_tizen> preview </since_tizen>
        void RemoveRelation(IAccessibleRelation relation);

        /// <summary>
        /// Highlights the accessible widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        void Highlight();

        /// <summary>
        /// Clears the highlight of the accessible widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        void Unhighlight();
    }
}
