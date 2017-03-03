/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using Tizen.NUI;

// A contentView control (for use can add image or text to it.)

namespace Tizen.NUI
{
    public class ContentView : CustomView
    {
        private int _iconVisualIndex;
        private string _iconVisualUrl;
        private bool _activeContent = false;
        private bool _transitionInProgress = false;

        private VisualBase _iconVisual;
        private Animation _animation;
        private TransitionData _growTransitionData;
        private TransitionData _shrinkTransitionData;


        // Called by DALi Builder if it finds a ContentView control in a JSON file
        static CustomView CreateInstance()
        {
            return new ContentView();
        }

        // static constructor registers the control type (only runs once)
        static ContentView()
        {
            // ViewRegistry registers control type with DALi type registery
            // also uses introspection to find any properties that need to be registered with type registry
            ViewRegistry.Instance.Register(CreateInstance, typeof(ContentView));
        }

        public ContentView() : base(typeof(ContentView).Name, ViewBehaviour.ViewBehaviourDefault | ViewBehaviour.RequiresKeyboardNavigationSupport)
        {

        }

        public override void OnInitialize()
        {
            _iconVisualIndex = RegisterProperty("iconVisual", new PropertyValue("./image/application-icon-0.png"), PropertyAccessMode.ReadWrite);

            PropertyMap animator = new PropertyMap();
            animator.Add("alphaFunction", new PropertyValue("LINEAR"));

            PropertyMap timePeriod = new PropertyMap();
            timePeriod.Add("duration", new PropertyValue(0.8f));
            timePeriod.Add("delay", new PropertyValue(0.0f));
            animator.Add("timePeriod", new PropertyValue(timePeriod));

            PropertyMap growTransition = new PropertyMap();
            growTransition.Add("target", new PropertyValue("iconVisual"));
            growTransition.Add("property", new PropertyValue("size"));
            growTransition.Add("targetValue", new PropertyValue(new Vector2(100.0f, 100.0f)));
            growTransition.Add("animator", new PropertyValue(animator));
            _growTransitionData = new TransitionData(growTransition);


            PropertyMap shrinkTransition = new PropertyMap();
            shrinkTransition.Add("target", new PropertyValue("iconVisual"));
            shrinkTransition.Add("property", new PropertyValue("size"));
            shrinkTransition.Add("targetValue", new PropertyValue(new Vector2(50.0f, 50.0f)));
            shrinkTransition.Add("animator", new PropertyValue(animator));
            _shrinkTransitionData = new TransitionData(shrinkTransition);
        }

        /*public virtual void OnRelayout(Vector2 size, RelayoutContainer container)
        {
          Console.WriteLine ("--------------OnRelayout.");
          RelayoutVisuals( size);
        }*/

        private void RelayoutVisuals(Vector2 size)
        {
            if (!_transitionInProgress)
            {
                if (_iconVisual)
                {
                    PropertyMap iconVisualTransform = new PropertyMap();
                    iconVisualTransform.Add((int)VisualTransformPropertyType.SIZE, new PropertyValue(new Vector2(50.0f, 50.0f)));
                    iconVisualTransform.Add((int)VisualTransformPropertyType.OFFSET, new PropertyValue(new Vector2(5.0f, 5.0f)));
                    iconVisualTransform.Add((int)VisualTransformPropertyType.OFFSET_SIZE_MODE, new PropertyValue(new Vector4(1.0f, 1.0f, 1.0f, 1.0f)));
                    iconVisualTransform.Add((int)VisualTransformPropertyType.ORIGIN, new PropertyValue((int)AlignType.TOP_BEGIN));
                    iconVisualTransform.Add((int)VisualTransformPropertyType.ANCHOR_POINT, new PropertyValue((int)AlignType.TOP_BEGIN));
                    _iconVisual.SetTransformAndSize(iconVisualTransform, size);
                }
            }
        }

        [ScriptableProperty()]
        public string IconVisual
        {
            get
            {
                return _iconVisualUrl;
            }
            set
            {
                _iconVisualUrl = value;
                if (_iconVisual)
                {
                    //RelayoutRequest();
                    EnableVisual(_iconVisualIndex, false);
                    UnregisterVisual(_iconVisualIndex);
                }

                PropertyMap iconVisualMap = new PropertyMap(); ;
                iconVisualMap.Add(Tizen.NUI.Constants.Visual.Property.Type, new PropertyValue((int)Tizen.NUI.Constants.Visual.Type.Image));
                iconVisualMap.Add(Tizen.NUI.Constants.ImageVisualProperty.URL, new PropertyValue(_iconVisualUrl));
                _iconVisual = VisualFactory.Get().CreateVisual(iconVisualMap);
                _iconVisual.Name = ("iconVisual");

                RelayoutVisuals(new Vector2(250.0f, 250.0f));
                RegisterVisual(_iconVisualIndex, _iconVisual);
                _iconVisual.DepthIndex = (1.0f);
            }

        }



        [ScriptableProperty()]
        public bool ActiveContent
        {
            get
            {
                return _activeContent;
            }
            set
            {
                _activeContent = value;
                StartTransition(_activeContent);
            }
        }

        private void StartTransition(bool activate)
        {
            if (_animation)
            {
                _animation.Stop();
                _animation.Finished += OnTransitionFinished;
            }
            if (activate)
            {
                _animation = CreateTransition(_growTransitionData);
            }
            else
            {
                _animation = CreateTransition(_shrinkTransitionData);
            }

            if (_animation)
            {
                _animation.Finished += OnTransitionFinished;
                _transitionInProgress = true;
                _animation.Play();
            }
        }

        private void OnTransitionFinished(object sender, EventArgs e)
        {
            _transitionInProgress = false;
            if (_animation)
            {
                _animation.Finished += OnTransitionFinished;
                _animation.Reset();
            }
        }

        public ImageVisualMap ImageVisual
        {
            set
            {
                if (value.URL != "")
                {
                    VisualBase _imageVisual;
                    int _imageVisualIndex = RegisterProperty("ImageVisual", new PropertyValue(value.URL), PropertyAccessMode.ReadWrite);
                    _imageVisual = VisualFactory.Get().CreateVisual(value.OutputMap);
                    RegisterVisual(_imageVisualIndex, _imageVisual);
                    _imageVisual.DepthIndex = value.DepthIndex;
                }
            }
        }

        public TextVisualMap TextVisual
        {
            set
            {
                if (value.Text != "" && value.PointSize != 0)
                {
                    Tizen.Log.Debug("NUI", "p2 !!!!!");

                    PropertyMap _outputMap = new PropertyMap(); ;
                    _outputMap.Add(Tizen.NUI.Constants.Visual.Property.Type, new PropertyValue((int)Tizen.NUI.Constants.Visual.Type.WireFrame + 1));
                    _outputMap.Add(Tizen.NUI.Constants.TextVisualProperty.Text, new PropertyValue("ABCD"));
                    _outputMap.Add(Tizen.NUI.Constants.TextVisualProperty.PointSize, new PropertyValue(10.0f));

                    VisualBase _textVisual;
                    int _textVisualIndex = RegisterProperty("TextVisual", new PropertyValue(_outputMap), PropertyAccessMode.ReadWrite);
                    _textVisual = VisualFactory.Get().CreateVisual(_outputMap);
                    RegisterVisual(_textVisualIndex, _textVisual, true);
                    _textVisual.DepthIndex = value.DepthIndex;
                    Tizen.Log.Debug("NUI", "p2 !!!!! _textVisualIndex=" + _textVisualIndex + "is enabled?=" + IsVisualEnabled(_textVisualIndex));
                }
            }
        }

    }
}