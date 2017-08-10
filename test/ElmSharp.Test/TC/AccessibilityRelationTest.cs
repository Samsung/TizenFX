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
using System.Linq;
using ElmSharp;
using ElmSharp.Accessible;

namespace ElmSharp.Test
{
    class AccessibilityRelationTest : TestCaseBase
    {
        public override string TestName => "AccessibilityRelationTest";
        public override string TestDescription => "Accessibility Relation API test";

        public override void Run(Window win)
        {
            Conformant conformant = new Conformant(win);
            conformant.Show();

            Box box = new Box(win);
            box.Show();
            conformant.SetContent(box);

            Button button1 = new Button(win) { WeightX = 1, AlignmentX = -1,  Text = "LabelledBy" };
            Label label1 = new Label(win) { Text = "LabelFor" };

            button1.Show();
            label1.Show();

            box.PackEnd(button1);
            box.PackEnd(label1);

            ((IAccessibleObject)button1).AppendRelation(new LabelledBy() { Target = label1 });
            ((IAccessibleObject)label1).AppendRelation(new LabelFor() { Target = button1 });

            button1.Clicked += (s, e) =>
            {
                ((IAccessibleObject)button1).RemoveRelation(new LabelledBy() { Target = label1 });
                ((IAccessibleObject)label1).RemoveRelation(new LabelFor() { Target = button1 });
            };

            Label label8 = new Label(win) { WeightX = 1, AlignmentX = -1,  Text = "ControlledBy" };
            Button button3 = new Button(win) { WeightX = 1, AlignmentX = -1,  Text = "ControllerFor" };

            label8.Show();
            button3.Show();

            box.PackEnd(label8);
            box.PackEnd(button3);

            ((IAccessibleObject)label8).AppendRelation(new ControlledBy() { Target = button3 });
            ((IAccessibleObject)button3).AppendRelation(new ControllerFor() { Target = label8 });

            button3.Clicked += (s, e) =>
            {
                ((IAccessibleObject)label8).RemoveRelation(new ControlledBy() { Target = button3 });
                ((IAccessibleObject)button3).RemoveRelation(new ControllerFor() { Target = label8 });
            };

            Box box2 = new Box(win) { WeightX = 1, AlignmentX = -1};
            Label label2 = new Label(win) { Text = "Group" };
            Button button4 = new Button(win) { WeightX = 1, AlignmentX = -1,  Text = "Member" };

            box2.Show();
            label2.Show();
            button4.Show();

            ((IAccessibleObject)label2).AppendRelation(new LabelFor() { Target = box2 });
            ((IAccessibleObject)label2).AppendRelation(new MemberOf() { Target = box2 });
            ((IAccessibleObject)box2).AppendRelation(new LabelledBy() { Target = label2 });
            ((IAccessibleObject)button4).AppendRelation(new MemberOf() { Target = box2 });

            box2.PackEnd(label2);
            box2.PackEnd(button4);
            box.PackEnd(box2);

            button4.Clicked += (s, e) =>
            {
                ((IAccessibleObject)label2).RemoveRelation(new LabelFor() { Target = box2 });
                ((IAccessibleObject)label2).RemoveRelation(new MemberOf() { Target = box2 });
                ((IAccessibleObject)box2).RemoveRelation(new LabelledBy() { Target = label2 });
                ((IAccessibleObject)button4).RemoveRelation(new MemberOf() { Target = box2 });
            };

            Button button6 = new Button(win) { WeightX = 1, AlignmentX = -1,  Text = "Xbutton" };
            Label label3 = new Label(win) { Text = "Tooltip of Xbutton" };

            button6.Show();
            label3.Show();

            ((IAccessibleObject)label3).AppendRelation(new TooltipFor() { Target = button6 });

            box.PackEnd(button6);
            box.PackEnd(label3);

            button6.Clicked += (s, e) =>
            {
                ((IAccessibleObject)label3).RemoveRelation(new TooltipFor() { Target = button6 });
            };

            Box box3 = new Box(win) { WeightX = 1, AlignmentX = -1};
            Label label4 = new Label(win) { Text = "Child of inner box" };
            Button button7 = new Button(win) { WeightX = 1, AlignmentX = -1,  Text = "child of inner box" };

            box3.Show();
            label4.Show();
            button7.Show();

            ((IAccessibleObject)box3).AppendRelation(new ParentOf() { Target = label4 });
            ((IAccessibleObject)box3).AppendRelation(new ParentOf() { Target = button7 });
            ((IAccessibleObject)label4).AppendRelation(new ChildOf() { Target = box3 });
            ((IAccessibleObject)button7).AppendRelation(new ChildOf() { Target = box3 });

            box3.PackEnd(label4);
            box3.PackEnd(button7);
            box.PackEnd(box3);

            button7.Clicked += (s, e) =>
            {
                ((IAccessibleObject)box3).RemoveRelation(new ParentOf() { Target = label4 });
                ((IAccessibleObject)box3).RemoveRelation(new ParentOf() { Target = button7 });
                ((IAccessibleObject)label4).RemoveRelation(new ChildOf() { Target = box3 });
                ((IAccessibleObject)button7).RemoveRelation(new ChildOf() { Target = box3 });
            };

            Label label6 = new Label(win) { Text = "Extended" };
            Button button12 = new Button(win) { WeightX = 1, AlignmentX = -1, Text = "Not Extended" };

            label6.Show();
            button12.Show();

            ((IAccessibleObject)label6).AppendRelation(new Extended() { Target = button12 });

            box.PackEnd(button12);
            box.PackEnd(label6);

            button12.Clicked += (s, e) =>
            {
                ((IAccessibleObject)label6).RemoveRelation(new Extended() { Target = button12 });
            };

            Button button8 = new Button(win) { WeightX = 1, AlignmentX = -1,  Text = "FlowsTo" };
            Button button9 = new Button(win) { WeightX = 1, AlignmentX = -1,  Text = "FlowsFrom" };

            button8.Show();
            button9.Show();

            ((IAccessibleObject)button8).AppendRelation(new FlowsTo() { Target = button9 });
            ((IAccessibleObject)button9).AppendRelation(new FlowsFrom() { Target = button8 });

            box.PackEnd(button8);
            box.PackEnd(button9);

            button8.Clicked += (s, e) =>
            {
                ((IAccessibleObject)button8).RemoveRelation(new FlowsTo() { Target = button9 });
            };

            button9.Clicked += (s, e) =>
            {
                ((IAccessibleObject)button9).RemoveRelation(new FlowsFrom() { Target = button8 });
            };

            Button button10 = new Button(win) { WeightX = 1, AlignmentX = -1, Text = "EmbeddedBy" };

            button10.Show();

            ((IAccessibleObject)button10).AppendRelation(new EmbeddedBy() { Target = box });
            ((IAccessibleObject)box).AppendRelation(new Embeds() { Target = button10 });

            box.PackEnd(button10);

            button10.Clicked += (s, e) =>
            {
                ((IAccessibleObject)button10).RemoveRelation(new EmbeddedBy() { Target = box });
                ((IAccessibleObject)box).RemoveRelation(new Embeds() { Target = button10 });
            };

            Button button11 = new Button(win) { WeightX = 1, AlignmentX = -1, Text = "popup" };

            button11.Show();

            Popup popup = new Popup(win)
            {
                Orientation = PopupOrientation.Top,
                Timeout = 5
            };
            popup.Append("Popup!!");

            ((IAccessibleObject)popup).AppendRelation(new PopupFor() { Target = button11 });
            ((IAccessibleObject)popup).AppendRelation(new SubwindowOf() { Target = box });
            ((IAccessibleObject)box).AppendRelation(new ParentWindowOf() { Target = popup });

            popup.OutsideClicked += (s, e) =>
            {
                popup.Hide();
            };


            button11.Clicked += (s, e) =>
            {
                popup.Show();
            };

            box.PackEnd(button11);

            Button button13 = new Button(win) { WeightX = 1, AlignmentX = -1, Text = "Remove Popup Relation"};

            button13.Show();

            box.PackEnd(button13);

            button13.Clicked += (s, e) =>
            {
                ((IAccessibleObject)popup).RemoveRelation(new PopupFor() { Target = button11 });
                ((IAccessibleObject)popup).RemoveRelation(new SubwindowOf() { Target = box });
                ((IAccessibleObject)box).RemoveRelation(new ParentWindowOf() { Target = popup });
            };

            Label label7 = new Label(win) { WeightX = 1, AlignmentX = -1,
                Text = "This is Test for Accessibility Relation Append Test"};
            label7.Show();

            ((IAccessibleObject)label7).AppendRelation(new DescriptionFor() { Target = box });
            ((IAccessibleObject)box).AppendRelation(new DescribedBy() { Target = label7 });

            box.PackEnd(label7);

            Button button14 = new Button(win) { WeightX = 1, AlignmentX = -1, Text = "Remove Description Relation"};
            button14.Show();
            box.PackEnd(button14);

            button14.Clicked += (s, e) =>
            {
                ((IAccessibleObject)label7).RemoveRelation(new DescriptionFor() { Target = box });
                ((IAccessibleObject)box).RemoveRelation(new DescribedBy() { Target = label7 });
            };
        }
    }
}
