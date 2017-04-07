// Copyright (c) 2017 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Tizen.NUI
{
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A visual view control for user add any visual to it.<br>
    /// Example:<br>
    /// VisualView _visualView = new VisualView();<br>
    /// ImageVisualMap imageVisualMap1 = new ImageVisualMap();<br>
    /// imageVisualMap1.URL = "./NUISample/res/images/image-1.jpg";<br>
    /// imageVisualMap1.VisualSize = new Vector2( 300.0f, 300.0f );<br>
    /// imageVisualMap1.Offset = new Vector2( 50.0f, 50.0f );<br>
    /// imageVisualMap1.OffsetSizeMode = new Vector4( 1.0f, 1.0f, 1.0f, 1.0f );<br>
    /// imageVisualMap1.Origin = AlignType.TOP_BEGIN;<br>
    /// imageVisualMap1.AnchorPoint = AlignType.TOP_BEGIN;<br>
    /// _visualView.AddVisual("imageVisual1", imageVisualMap1);<br>
    /// </summary>
    public class VisualView : CustomView
    {
        //private LinkedList<VisualBase> _visualList = null;
        private Dictionary<int, VisualBase> _visualDictionary = null;
        private Dictionary<int, PropertyMap> _tranformDictionary = null;

        static CustomView CreateInstance()
        {
            return new VisualView();
        }

        // static constructor registers the control type (for user can add kinds of visuals to it)
        static VisualView()
        {
            // ViewRegistry registers control type with DALi type registery
            // also uses introspection to find any properties that need to be registered with type registry
            ViewRegistry.Instance.Register(CreateInstance, typeof(VisualView));
        }

        public VisualView() : base(typeof(VisualView).Name, CustomViewBehaviour.ViewBehaviourDefault)
        {
        }

        /// <summary>
        /// Override the parent method.
        /// </summary>
        public override void OnInitialize()
        {
            //Initialize empty
            _visualDictionary = new Dictionary<int, VisualBase>();
            _tranformDictionary = new Dictionary<int, PropertyMap>();
        }

        /// <summary>
        /// Add or update a visual to visual view.
        /// </summary>
        /// <param name="visualName"> The name of visual to add. If add a existed visual name, the visual will be replaced. </param>
        /// <param name="visualMap"> The property map of visual to create.  </param>
        public void AddVisual(string visualName, VisualMap visualMap)
        {
            VisualBase visual = null;
            int visualIndex = -1;

            /* If the visual had added, then replace it using RegisterVusal. */
            //visual.Name = name;
            foreach (var item in _visualDictionary)
            {
                if (item.Value.Name == visualName)
                {
                    /* Find a existed visual, its key also exited. */
                    visualIndex = item.Key;
                    UnregisterVisual(visualIndex);
                    _visualDictionary.Remove(visualIndex);
                    _tranformDictionary.Remove(visualIndex);
                    break;
                }
            }

            if (visualIndex == -1) // The visual is a new one, create index for it. */
            {
                visualIndex = RegisterProperty(visualName, new PropertyValue(visualName), PropertyAccessMode.ReadWrite);
            }

            if (visualIndex > 0)
            {
                visual = VisualFactory.Get().CreateVisual(visualMap.OutputVisualMap); // Create a visual for the new one.
                visual.Name = visualName;
                visual.DepthIndex = visualMap.DepthIndex;

                RegisterVisual(visualIndex, visual);

                _visualDictionary.Add(visualIndex, visual);
                _tranformDictionary.Add(visualIndex, visualMap.OutputTransformMap);

                RelayoutRequest();
            }
        }

        /// <summary>
        /// Remove a visual by name.
        /// </summary>
        /// <param name="visualName"> The name of visual to remove. </param>
        public void RemoveVisual(string visualName)
        {
            foreach (var item in _visualDictionary.ToList())
            {
                if (item.Value.Name == visualName)
                {
                    EnableVisual(item.Key, false);
                    UnregisterVisual(item.Key);
                    _visualDictionary.Remove(item.Key);
                }
            }
        }

        /// <summary>
        ///  Get the total number of Visuals which are added by users
        /// </summary>
        public int NumberOfVisuals
        {
            get
            {
                return _visualDictionary.Count;
            }
        }


        /// <summary>
        /// Remove all visuals of visual view.
        /// </summary>
        public void RemoveAll()
        {
            _visualDictionary.Clear();
        }

        /// <summary>
        /// Override method of OnRelayout() for CustomView class.<br>
        /// Called after the size negotiation has been finished for this control.<br>
        /// The control is expected to assign this given size to itself/its children.<br>
        /// Should be overridden by derived classes if they need to layout actors differently after certain operations like add or remove actors, resize or after changing specific properties.<br>
        /// Note! As this function is called from inside the size negotiation algorithm, you cannot call RequestRelayout (the call would just be ignored).<br>
        /// </summary>
        /// <param name="size">The allocated size</param>
        /// <param name="container">The control should add actors to this container that it is not able to allocate a size for.</param>
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            foreach (var item in _visualDictionary)
            {
                item.Value.SetTransformAndSize(_tranformDictionary[item.Key], size);
                EnableVisual(item.Key, true);
            }
        }
    }

}
