using System.Diagnostics;

/*
 * Copyright (c) 2016 Samsung Electronics Co. Ltd All Rights Reserved
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

namespace ElmSharp.Test
{
    class EventTest1 : TestCaseBase
    {
        public override string TestName => "EventTest1";
        public override string TestDescription => "event propagation test";

        Box gParent;
        GestureLayer _gParentLayer, _parentLayer, childLayer, chLayer;

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            gParent = new Box(window)
            {
                BackgroundColor = Color.Yellow,
                PassEvents = false,
                PropagateEvents = false,
            };
            conformant.SetContent(gParent);

            Box parent = new Box(gParent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = Color.Green,
                PassEvents = false,
                PropagateEvents = false,
            };
            Box child = new Box(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = Color.Blue,
                PassEvents = false,
                PropagateEvents = false,
            };

            Check ch = new Check(child)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = Color.Silver,
                PassEvents = false,
                PropagateEvents = false,
            };

            gParent.PackEnd(parent);
            parent.PackEnd(child);
            child.PackEnd(ch);

            gParent.Show();
            parent.Show();
            child.Show();
            ch.Show();

            _gParentLayer = new GestureLayer(gParent);
            _gParentLayer.Attach(gParent);
            _gParentLayer.SetTapCallback(GestureLayer.GestureType.Tap, GestureLayer.GestureState.End, (info) =>
            {
                Debug.WriteLine($"@@@ Grand Parent Tap : {gParent.PassEvents}, {gParent.PropagateEvents}, {gParent.RepeatEvents}");
            });
            _parentLayer = new GestureLayer(parent);
            _parentLayer.Attach(parent);
            _parentLayer.SetTapCallback(GestureLayer.GestureType.Tap, GestureLayer.GestureState.End, (info) =>
            {
                Debug.WriteLine($"@@@ Parent Tap : {parent.PassEvents}, {parent.PropagateEvents}, {parent.RepeatEvents}");
            });
            childLayer = new GestureLayer(child);
            childLayer.Attach(child);
            childLayer.SetTapCallback(GestureLayer.GestureType.Tap, GestureLayer.GestureState.End, (info) =>
            {
                Debug.WriteLine($"@@@ Child Tap : {child.PassEvents}, {child.PropagateEvents}, {child.RepeatEvents}");
            });

            chLayer = new GestureLayer(ch);
            chLayer.Attach(ch);
            chLayer.SetTapCallback(GestureLayer.GestureType.Tap, GestureLayer.GestureState.End, (info) =>
            {
                Debug.WriteLine($"@@@ Check1 Tap : {ch.PassEvents}, {ch.PropagateEvents}, {ch.RepeatEvents}");
            });

            EvasObjectEvent eventGrand = new EvasObjectEvent(gParent, EvasObjectCallbackType.MouseDown);
            eventGrand.On += (s, e) =>
            {
                Debug.WriteLine($"@@@ Grand Parent down : {gParent.PassEvents}, {gParent.PropagateEvents}, {gParent.RepeatEvents}");
            };
            EvasObjectEvent evnetParent = new EvasObjectEvent(parent, EvasObjectCallbackType.MouseDown);
            evnetParent.On += (s, e) =>
            {
                Debug.WriteLine($"@@@ Parent down : {parent.PassEvents}, {parent.PropagateEvents}, {parent.RepeatEvents}");
            };
            EvasObjectEvent eventChild = new EvasObjectEvent(child, EvasObjectCallbackType.MouseDown);
            eventChild.On += (s, e) =>
            {
                Debug.WriteLine($"@@@ Child down : {child.PassEvents}, {child.PropagateEvents}, {child.RepeatEvents}");
            };
            EvasObjectEvent eventCh = new EvasObjectEvent(ch, ch.RealHandle, EvasObjectCallbackType.MouseDown);
            eventCh.On += (s, e) =>
            {
                Debug.WriteLine($"@@@ Check down : {ch.PassEvents}, {ch.PropagateEvents}, {ch.RepeatEvents}");
            };
        }
    }
}