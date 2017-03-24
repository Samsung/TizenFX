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

using System;

namespace ElmSharp.Accessible
{

    public delegate string AccessibleInfoProvider (AccessibleObject obj);

    public abstract class AccessibleObject : EvasObject, IAccessibleObject
    {

        AccessibleInfoProvider _nameProvider;
        AccessibleInfoProvider _descriptionProvider;

        Interop.Elementary.Elm_Atspi_Reading_Info_Cb _nameProviderInternal;
        Interop.Elementary.Elm_Atspi_Reading_Info_Cb _descriptionProviderInternal;

        ReadingInfoType IAccessibleObject.ReadingInfoType
        {
            get
            {
                return (ReadingInfoType)Interop.Elementary.elm_atspi_accessible_reading_info_type_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_atspi_accessible_reading_info_type_set(Handle,
                        (Interop.Elementary.Elm_Accessible_Reading_Info_Type)value);
            }
        }
        AccessRole IAccessibleObject.Role
        {
            get
            {
                return (AccessRole)Interop.Elementary.elm_atspi_accessible_role_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_atspi_accessible_role_set(Handle,
                        (Interop.Elementary.Elm_Atspi_Role)value);
            }
        }
        bool IAccessibleObject.CanHighlight
        {
            get
            {
                return Interop.Elementary.elm_atspi_accessible_can_highlight_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_atspi_accessible_can_highlight_set(Handle, value);
            }
        }
        string IAccessibleObject.TranslationDomain
        {
            get
            {
                return Interop.Elementary.elm_atspi_accessible_translation_domain_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_atspi_accessible_translation_domain_set(Handle, value);
            }
        }
        string IAccessibleObject.Name
        {
            get
            {
                return Interop.Elementary.elm_atspi_accessible_name_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_atspi_accessible_name_set(Handle, value);
            }
        }
        string IAccessibleObject.Description
        {
            get
            {
                return Interop.Elementary.elm_atspi_accessible_description_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_atspi_accessible_description_set(Handle, value);
            }
        }

        AccessibleInfoProvider IAccessibleObject.NameProvider
        {
            get
            {
                return _nameProvider;
            }

            set
            {
                if (_nameProviderInternal == null)
                {
                    _nameProviderInternal = (data, obj) => _nameProvider(this);
                }
                if (value == null)
                {
                    _nameProvider = null;
                    Interop.Elementary.elm_atspi_accessible_name_cb_set(Handle, null, IntPtr.Zero);
                }
                else
                {
                    _nameProvider = new AccessibleInfoProvider(value);
                    Interop.Elementary.elm_atspi_accessible_name_cb_set(Handle, _nameProviderInternal, IntPtr.Zero);
                }
            }
        }
        AccessibleInfoProvider IAccessibleObject.DescriptionProvider
        {
            get
            {
                return _descriptionProvider;
            }

            set
            {
                if (_descriptionProviderInternal == null)
                {
                    _descriptionProviderInternal = (data, obj) => _descriptionProvider(this);
                }
                if (value == null)
                {
                    _descriptionProvider = null;
                    Interop.Elementary.elm_atspi_accessible_description_cb_set(Handle, null, IntPtr.Zero);
                }
                else
                {
                    _descriptionProvider = new AccessibleInfoProvider(value);
                    Interop.Elementary.elm_atspi_accessible_description_cb_set(Handle, _descriptionProviderInternal, IntPtr.Zero);
                }
            }
        }

        public AccessibleObject(EvasObject parent) : base(parent)
        {
        }

        public AccessibleObject() : base()
        {
        }

        void IAccessibleObject.AppendRelation(IAccessibleRelation relation)
        {
            if (relation.Target == null) throw new ArgumentException("Target of Accessibility relation can not be null");
            Interop.Elementary.elm_atspi_accessible_relationship_append(Handle, relation.Type, relation.Target.Handle);
        }

        void IAccessibleObject.RemoveRelation(IAccessibleRelation relation)
        {
            if (relation.Target == null) throw new ArgumentException("Target of Accessibility relation can not be null");
            Interop.Elementary.elm_atspi_accessible_relationship_remove(Handle, relation.Type, relation.Target.Handle);
        }

        public void Highlight()
        {
            Interop.Elementary.elm_atspi_component_highlight_grab(Handle);
        }

        public void Unhighlight()
        {
            Interop.Elementary.elm_atspi_component_highlight_clear(Handle);
        }
    }
}
