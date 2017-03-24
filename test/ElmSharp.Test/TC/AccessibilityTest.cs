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
    class AccessibilityTest : TestCaseBase
    {
        public override string TestName => "AccessibilityTest";
        public override string TestDescription => "Accessibility API test";

        int sequence = 0;
        Naviframe navi;

        Array accessRoleValues;

        public override void Run(Window window)
        {
            accessRoleValues = Enum.GetValues(typeof(AccessRole));

            Conformant conformant = new Conformant(window);
            conformant.Show();

            navi = new Naviframe(window)
            {
                PreserveContentOnPop = true,
                DefaultBackButtonEnabled = true
            };

            navi.Push(CreatePage(window, "Main page"), "first page");
            navi.Show();
            conformant.SetContent(navi);
        }

        static string StatusStr(ReadingStatus status)
        {
            if (status == ReadingStatus.Unknown)
            {
                return "Unknown";
            }
            else if (status == ReadingStatus.Cancelled)
            {
                return "Cancelled";
            }
            else if (status == ReadingStatus.Stoppped)
            {
                return "Stopped";
            }
            else if (status == ReadingStatus.Skipped)
            {
                return "Skipped";
            }
            else
            {
                return "invalid";
            }
        }

        Widget CreatePage(Window win, string pageName)
        {
            Box box = new Box(win);
            ((IAccessibleObject)box).Name = pageName;

            box.Show();

            Button abutton = new Button(win)
            {
                Text = "Accessibility-normal",
                WeightX = 1,
                AlignmentX = -1
            };
            ((IAccessibleObject)abutton).TranslationDomain = "kr";
            ((IAccessibleObject)abutton).Name = "Accessibility";
            ((IAccessibleObject)abutton).Description = "Description for Accessibility";

            Label abutton_label = new Label(win)
            {
                WeightX = 1,
                AlignmentX = -1
            };
            abutton_label.Text =
                "domain : " + ((IAccessibleObject)abutton).TranslationDomain +
                ", name : " + ((IAccessibleObject)abutton).Name +
                ", desc : " + ((IAccessibleObject)abutton).Description;

            Button bbutton = new Button(win)
            {
                Text = "Accessibility-provider",
                WeightX = 1,
                AlignmentX = -1
            };
            ((IAccessibleObject)bbutton).NameProvider = (obj) => "Name-provider";
            ((IAccessibleObject)bbutton).DescriptionProvider = (obj) => "Description-provider";

            Label bbutton_label = new Label(win)
            {
                WeightX = 1,
                AlignmentX = -1
            };
            bbutton_label.Text =
                "name : " + ((IAccessibleObject)bbutton).Name +
                ", desc : " + ((IAccessibleObject)bbutton).Description;

            Button cbutton = new Button(win)
            {
                Text = "Readingtype,CanHighlight",
                WeightX = 1,
                AlignmentX = -1
            };
            ((IAccessibleObject)cbutton).ReadingInfoType =
                ReadingInfoType.Name | ReadingInfoType.Role | ReadingInfoType.Description;
            ((IAccessibleObject)cbutton).Name = "FooFoo";
            ((IAccessibleObject)cbutton).Role = AccessRole.Text;
            ((IAccessibleObject)cbutton).Description = "FooFooButton";
            Label name_onoff_label = new Label(win)
            {
                Text = "ReadingInfoType.Name : " +
                    ((((IAccessibleObject)cbutton).ReadingInfoType & ReadingInfoType.Name) != 0 ? "on" : "off"),
                WeightX = 1,
                AlignmentX = -1
            };
            Label role_onoff_label = new Label(win)
            {
                Text = "ReadingInfoType.Role : " +
                    ((((IAccessibleObject)cbutton).ReadingInfoType & ReadingInfoType.Role) != 0 ? "on" : "off"),
                WeightX = 1,
                AlignmentX = -1
            };
            Label description_onoff_label = new Label(win)
            {
                Text = "ReadingInfoType.Description : " +
                    ((((IAccessibleObject)cbutton).ReadingInfoType & ReadingInfoType.Description) != 0 ? "on" : "off"),
                WeightX = 1,
                AlignmentX = -1
            };
            Label state_onoff_label = new Label(win)
            {
                Text = "ReadingInfoType.State : " +
                    ((((IAccessibleObject)cbutton).ReadingInfoType & ReadingInfoType.State) != 0 ? "on" : "off"),
                WeightX = 1,
                AlignmentX = -1
            };

            Button saybutton = new Button(win)
            {
                Text = "HHGG with false",
                WeightX = 1,
                AlignmentX = -1
            };

            Button saybutton2 = new Button(win)
            {
                Text = "HHGG with true",
                WeightX = 1,
                AlignmentX = -1
            };

            int labelIndex = 0;
            Button roleButton = new Button(win)
            {
                WeightX = 1,
                AlignmentX = -1
            };

            roleButton.Clicked += (s, e) =>
            {
                if (labelIndex >= accessRoleValues.Length)
                {
                    labelIndex = 0;
                }

                IAccessibleObject obj = roleButton as IAccessibleObject;
                AccessRole role = (AccessRole) accessRoleValues.GetValue(labelIndex);
                obj.Role = role;
                roleButton.Text = Enum.GetName(typeof(AccessRole), obj.Role);

                labelIndex++;
            };

            Label label = new Label(win)
            {
                Text = string.Format("{0} Apple", sequence++),
                WeightX = 1,
                AlignmentX = -1
            };
            ((IAccessibleObject)label).Name = "Apple";

            Button push = new Button(win)
            {
                Text = "Push",
                WeightX = 1,
                AlignmentX = -1
            };
            ((IAccessibleObject)push).Name = "PushButton";

            Button pop = new Button(win)
            {
                Text = "pop",
                WeightX = 1,
                AlignmentX = -1,
            };
            ((IAccessibleObject)pop).Name = "PopButton";

            abutton.Show();
            abutton_label.Show();
            bbutton.Show();
            bbutton_label.Show();
            cbutton.Show();
            name_onoff_label.Show();
            role_onoff_label.Show();
            description_onoff_label.Show();
            state_onoff_label.Show();
            saybutton.Show();
            saybutton2.Show();
            roleButton.Show();
            label.Show();
            push.Show();
            pop.Show();

            push.Clicked += (s, e) =>
            {
                NaviItem item = navi.Push(CreatePage(win, string.Format("Apple {0}", sequence -1)), string.Format("Page {0}", sequence -1));
            };

            Label statusLog = new Label(win)
            {
                WeightX = 1,
                AlignmentX = -1
            };
            statusLog.Show();

            saybutton.Clicked += (s, e) =>
            {
                    AccessibleUtil.Say("The Hitchhiker's Guide to the Galaxy", false)
                        .ContinueWith(status => { statusLog.Text = StatusStr(status.Result); });
            };
            saybutton2.Clicked += (s, e) =>
            {
                    AccessibleUtil.Say("The Hitchhiker's Guide to the Galaxy", true)
                        .ContinueWith(status => { statusLog.Text = StatusStr(status.Result); });
            };

            pop.Clicked += (s, e) =>
            {
                var item = navi.NavigationStack.LastOrDefault();
                navi.Pop();
            };

            box.PackEnd(abutton);
            box.PackEnd(abutton_label);
            box.PackEnd(bbutton);
            box.PackEnd(bbutton_label);
            box.PackEnd(cbutton);
            box.PackEnd(name_onoff_label);
            box.PackEnd(role_onoff_label);
            box.PackEnd(description_onoff_label);
            box.PackEnd(state_onoff_label);
            box.PackEnd(saybutton);
            box.PackEnd(saybutton2);
            box.PackEnd(roleButton);
            box.PackEnd(label);
            box.PackEnd(push);
            box.PackEnd(pop);
            box.PackEnd(statusLog);

            return box;
        }
    }
}
