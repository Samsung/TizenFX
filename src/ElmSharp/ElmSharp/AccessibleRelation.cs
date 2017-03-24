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
    public interface IAccessibleRelation
    {

        AccessibleObject Target { get; set; }
        int Type { get; }
    }

    public class LabelledBy : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_LABELLED_BY; }
        }
    }

    public class LabelFor : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_LABEL_FOR; }
        }
    }

    public class ControllerFor : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_CONTROLLER_FOR; }
        }
    }

    public class ControlledBy : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_CONTROLLED_BY; }
        }
    }

    public class MemberOf : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_MEMBER_OF; }
        }
    }

    public class TooltipFor : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_TOOLTIP_FOR; }
        }
    }

    public class ChildOf : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_NODE_CHILD_OF; }
        }
    }

    public class ParentOf : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_NODE_PARENT_OF; }
        }
    }

    public class Extended : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_EXTENDED; }
        }
    }

    public class FlowsTo : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_FLOWS_TO; }
        }
    }

    public class FlowsFrom : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_FLOWS_FROM; }
        }
    }

    public class SubwindowOf : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_SUBWINDOW_OF; }
        }
    }

    public class Embeds : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_EMBEDS; }
        }
    }

    public class EmbeddedBy : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_EMBEDDED_BY; }
        }
    }

    public class PopupFor : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_POPUP_FOR; }
        }
    }

    public class ParentWindowOf : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_PARENT_WINDOW_OF; }
        }
    }

    public class DescriptionFor : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_DESCRIPTION_FOR; }
        }
    }

    public class DescribedBy : IAccessibleRelation
    {
        public AccessibleObject Target { get; set; }
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_DESCRIBED_BY; }
        }
    }
}
