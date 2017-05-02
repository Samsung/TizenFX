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
using Dali;
using Dali.Constants;

namespace VisualsUsingCustomView
{
    // The collection of contacts
    static class ContactsList
    {
        public static readonly ContactItem[] s_contactData = new ContactItem[]
        {
            new ContactItem ("Emmett Yates", "./images/gallery-small-43.jpg",
                             new Color((73.0f/255.0f),(182.0f/255.0f), (245.0f/255.0f), 1.0f),
                             (int)PrimitiveVisualShapeType.CONE),
            new ContactItem ("Leslie Wong", "./images/gallery-2.jpg",
                             new Color((51.0f/255.0f), (51.0f/255.0f), (102.0f/255.0f), 1.0f),
                             (int)PrimitiveVisualShapeType.SPHERE),
            new ContactItem ("Walter Jensen", "./images/gallery-0.jpg",
                             new Color((151.0f/255.0f), (214.0f/255.0f), (240.0f/255.0f), 1.0f),
                             (int)PrimitiveVisualShapeType.CYLINDER),
            new ContactItem ("Dan Haynes", "./images/gallery-1.jpg",
                             new Color((102.0f/255.0f), (251.0f/255.0f), (102.0f/255.0f), 1.0f),
                             (int)PrimitiveVisualShapeType.CONICAL_FRUSTRUM),
            new ContactItem ("Mable Hodges", "./images/gallery-3.jpg",
                             new Color((255.0f/255.0f), (102.0f/255.0f), (102.0f/255.0f), 1.0f),
                             (int)PrimitiveVisualShapeType.CUBE)
        };
    }

    // The information for an individual contact
    class ContactItem
    {
        private string _name;
        private string _imageURL;
        private Color _color;
        private int _shape;

        public ContactItem (string name, string imageURL, Color color, int shape)
        {
            _name = name;
            _imageURL = imageURL;
            _color = color;
            _shape = shape;
        }

        public string ImageURL
        {
            get
            {
                return _imageURL;
            }
            set
            {
                _imageURL = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public int Shape
        {
            get
            {
                return _shape;
            }
            set
            {
                _shape = value;
            }
        }
    }
}