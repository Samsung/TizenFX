/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// BackKeyManager is a class to manager back key event.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class BackKeyManager
    {
        private static readonly BackKeyManager instance = new BackKeyManager();

        /// <summary>
        /// BackKeyManager construct.
        /// </summary>
        private BackKeyManager()
        {
            NUIApplication.GetDefaultWindow().KeyEvent += OnWindowKeyEvent;
        }

        /// <summary>
        /// Subscriber.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<View> Subscriber { get; } = new List<View>();

        /// <summary>
        /// BackKeyManager static instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackKeyManager Instance { get { return instance; } }

        private Container FindParent(Container child, int step)
        {
            Container result = child;

            for (int i = 0; i < step; i++)
            {
                result = result?.GetParent();
            }

            return result;
        }

        // If false, comparison1 is on top and if true, comparison2 is on top.
        private bool CompareElevation(Container comparison1, Container comparison2)
        {
            bool result = false;

            Container parent1 = comparison1?.GetParent();
            Container parent2 = comparison2?.GetParent();

            if ((parent1 == null && parent2 != null) || (parent2 == null && parent1 != null))
            {
                // One is in DefaultLayer but the other is not
                if (parent2 == null)
                {
                    // parent1 is in DefaultLayer.
                    Layer comparison2AsLayer = comparison2 as Layer;
                    if (comparison2AsLayer != null)
                    {
                        result = comparison2AsLayer.Depth > NUIApplication.GetDefaultWindow().GetDefaultLayer().Depth;
                    }
                }
                else
                {
                    // parent2 is in DefaultLayer.
                    Layer comparison1AsLayer = comparison1 as Layer;
                    if (comparison1AsLayer != null)
                    {
                        result = NUIApplication.GetDefaultWindow().GetDefaultLayer().Depth < comparison1AsLayer.Depth;
                    }
                }
            }
            else
            {
                // If they have same parent, ready to compare!
                if (parent1 == parent2)
                {

                    if (comparison1.GetType().FullName.Contains("Layer"))
                    {
                        // If comparison1 is Layer, comparison2 is also Layer because only window can have Layer as child in NUI.
                        // Compare Depth
                        Layer comparison1AsLayer = comparison1 as Layer;
                        Layer comparison2AsLayer = comparison2 as Layer;
                        if (comparison1AsLayer != null && comparison2AsLayer != null)
                        {
                            result = comparison1AsLayer.Depth < comparison2AsLayer.Depth;
                        }
                    }
                    else
                    {
                        // If comparison1 is View, comparison2 is also View because only window can have Layer as child in NUI.
                        // Compare SiblingOrder
                        View comparison1AsView = comparison1 as View;
                        View comparison2AsView = comparison2 as View;
                        if (comparison1AsView != null && comparison2AsView != null)
                        {
                            result = comparison1AsView.SiblingOrder < comparison2AsView.SiblingOrder;
                        }
                    }
                }
                else
                {
                    // Check ancestor
                    result = CompareElevation(parent1, parent2);
                }
            }

            return result;
        }

        private void OnWindowKeyEvent(object source, Window.KeyEventArgs args)
        {
            if (args.Key.State == Key.StateType.Up && (args.Key.KeyPressedName == "Back" || args.Key.KeyPressedName == "XF86Back"))
            {
                View top = null;

                for (int i = 0; i < Subscriber.Count; i++)
                {
                    // Check visibility
                    if (Subscriber[i].Visibility && Subscriber[i].IsOnWindow)
                    {
                        // Initialize first top
                        if (top == null)
                        {
                            top = Subscriber[i];
                            continue;
                        }
                        else
                        {
                            if (top.HierarchyDepth != Subscriber[i].HierarchyDepth)
                            {
                                Container compare1 = top;
                                Container compare2 = Subscriber[i];

                                // If their depth is different, sync.
                                if (top.HierarchyDepth > Subscriber[i].HierarchyDepth)
                                {
                                    compare1 = FindParent(compare1, top.HierarchyDepth - Subscriber[i].HierarchyDepth);
                                }
                                else
                                {
                                    compare2 = FindParent(compare2, Subscriber[i].HierarchyDepth - top.HierarchyDepth);
                                }

                                if (compare1 == compare2)
                                {
                                    // One is descendant of the other. Descendant is above ancestor.
                                    top = top.HierarchyDepth > Subscriber[i].HierarchyDepth ? top : Subscriber[i];
                                }
                                else
                                {
                                    // Need to compare.
                                    top = CompareElevation(compare1, compare2) ? Subscriber[i] : top;
                                }
                            }
                            else
                            {
                                top = CompareElevation(top, Subscriber[i]) ? Subscriber[i] : top;
                            }
                        }
                    }
                }

                top?.EmitBackKeyPressed();
            }
        }
    }
}
