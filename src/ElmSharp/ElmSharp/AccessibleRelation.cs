/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// IAccessibleRelation is an interface, which defines the relationship between two accessible objects.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public interface IAccessibleRelation
    {

        /// <summary>
        /// Gets or sets the target object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        int Type { get; }
    }

    /// <summary>
    /// To define the label info for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class LabelledBy : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is LabelledBy.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the LabelledBy type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_LABELLED_BY; }
        }
    }

    /// <summary>
    /// To define the label info for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class LabelFor : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object which is LabelFor.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the LabelFor type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_LABEL_FOR; }
        }
    }

    /// <summary>
    /// To define the control relationship for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ControllerFor : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is ControllerFor.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the ControllerFor type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_CONTROLLER_FOR; }
        }
    }

    /// <summary>
    /// To define the control relationship for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ControlledBy : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is ControlledBy.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the ControlledBy type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_CONTROLLED_BY; }
        }
    }

    /// <summary>
    /// To define the member relationship for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class MemberOf : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is MemberOf.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the MemberOf type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_MEMBER_OF; }
        }
    }

    /// <summary>
    /// To define the tooltip for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class TooltipFor : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is TooltipFor.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the TooltipFor type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_TOOLTIP_FOR; }
        }
    }

    /// <summary>
    /// To define the child for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ChildOf : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is ChildOf.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the ChildOf type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_NODE_CHILD_OF; }
        }
    }

    /// <summary>
    /// To define the parent for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ParentOf : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is ParentOf.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the ParentOf type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_NODE_PARENT_OF; }
        }
    }

    /// <summary>
    /// To define the extend for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Extended : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is Extended.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the extended type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_EXTENDED; }
        }
    }

    /// <summary>
    /// To define the custom reading order.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class FlowsTo : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is FlowsTo.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the FlowsTo type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_FLOWS_TO; }
        }
    }

    /// <summary>
    /// To define the custom reading order.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class FlowsFrom : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is FlowsFrom.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the FlowsFrom type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_FLOWS_FROM; }
        }
    }

    /// <summary>
    /// To define the subwindow for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class SubwindowOf : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is SubwindowOf.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the SubwindowOf type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_SUBWINDOW_OF; }
        }
    }

    /// <summary>
    /// To define the embed for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Embeds : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object ,which is Embeds.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the Embeds type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_EMBEDS; }
        }
    }

    /// <summary>
    /// To define the embed for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class EmbeddedBy : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is EmbeddedBy.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the EmbeddedBy type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_EMBEDDED_BY; }
        }
    }

    /// <summary>
    /// To define the popup for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class PopupFor : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is PopupFor.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the PopupFor type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_POPUP_FOR; }
        }
    }

    /// <summary>
    /// To define the parent window for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ParentWindowOf : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is ParentWindowOf.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the ParentWindowOf type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_PARENT_WINDOW_OF; }
        }
    }

    /// <summary>
    /// To define the description for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class DescriptionFor : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is DescriptionFor.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the DescriptionFor type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_DESCRIPTION_FOR; }
        }
    }

    /// <summary>
    /// To define the description for an accessible object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class DescribedBy : IAccessibleRelation
    {
        /// <summary>
        /// Gets or sets the target object, which is DescribedBy.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AccessibleObject Target { get; set; }

        /// <summary>
        /// Gets the DescribedBy type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Type
        {
            get { return (int)Interop.Elementary.Elm_Atspi_Relation_Type.ELM_ATSPI_RELATION_DESCRIBED_BY; }
        }
    }
}
