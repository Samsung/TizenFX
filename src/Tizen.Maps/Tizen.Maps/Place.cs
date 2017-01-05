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
using System.Collections.Generic;

namespace Tizen.Maps
{
    /// <summary>
    /// Place information, used in Place Discovery and Search
    /// </summary>
    public class Place
    {
        internal Interop.PlaceHandle handle;

        private string _id;
        private string _name;
        private string _uri;
        private Geocoordinates _location;
        private int _distance;
        private PlaceAddress _address;
        private PlaceRating _rating;

        private Dictionary<string, string> _properties;
        private List<PlaceCategory> _categories = new List<PlaceCategory>();
        private List<PlaceAttribute> _attributes = new List<PlaceAttribute>();
        private List<PlaceContact> _contacts = new List<PlaceContact>();
        private List<PlaceEditorial> _editorials = new List<PlaceEditorial>();
        private List<PlaceImage> _images = new List<PlaceImage>();
        private List<PlaceReview> _reviews = new List<PlaceReview>();

        private PlaceLink _supplier;
        private PlaceLink _related;

        internal Place(IntPtr nativeHandle)
        {
            handle = new Interop.PlaceHandle(nativeHandle);

            Interop.Place.GetDistance(handle, out _distance);

            IntPtr supplierHandle;
            var err = Interop.Place.GetSupplierLink(handle, out supplierHandle);
            if (err.IsSuccess())
                _supplier = new PlaceLink(supplierHandle);

            IntPtr relatedHandle;
            err = Interop.Place.GetRelatedLink(handle, out relatedHandle);
            if (err.IsSuccess())
                _related = new PlaceLink(relatedHandle);
        }

        /// <summary>
        /// Place ID
        /// </summary>
        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(_id))
                {
                    var err = Interop.Place.GetId(handle, out _id);
                    err.WarnIfFailed("Failed to get id for this place");
                }
                return _id;
            }
        }

        /// <summary>
        /// Place Name
        /// </summary>
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    var err = Interop.Place.GetName(handle, out _name);
                    err.WarnIfFailed("Failed to get name for this place");
                }
                return _name;
            }
        }

        /// <summary>
        /// Place URI
        /// </summary>
        public string Uri
        {
            get
            {
                if (string.IsNullOrEmpty(_uri))
                {
                    var err = Interop.Place.GetUri(handle, out _uri);
                    err.WarnIfFailed("Failed to get URI for this place");
                }
                return _uri;
            }
        }

        /// <summary>
        /// Place location
        /// </summary>
        public Geocoordinates Location
        {
            get
            {
                if (_location == null)
                {
                    IntPtr locationHandle;
                    var err = Interop.Place.GetLocation(handle, out locationHandle);
                    if (err.WarnIfFailed("Failed to get coordinates for this place"))
                    {
                        _location = new Geocoordinates(locationHandle);
                    }
                }
                return _location;
            }
        }

        public int Distance { get { return _distance; } }

        /// <summary>
        /// Place address
        /// </summary>
        public PlaceAddress Address
        {
            get
            {
                if (_address == null)
                {
                    IntPtr addressHandle;
                    var err = Interop.Place.GetAddress(handle, out addressHandle);
                    if (err.WarnIfFailed("Failed to get address for this place"))
                    {
                        _address = new PlaceAddress(addressHandle);
                    }
                }
                return _address;
            }
        }

        /// <summary>
        /// Rating for the place
        /// </summary>
        public PlaceRating Rating
        {
            get
            {
                if (_rating == null)
                {
                    IntPtr ratingHandle;
                    var err = Interop.Place.GetRating(handle, out ratingHandle);
                    if (err.WarnIfFailed("Failed to get rating for this place"))
                    {
                        _rating = new PlaceRating(ratingHandle);
                    }
                }
                return _rating;
            }
        }

        /// <summary>
        /// All properties attached with this place
        /// </summary>
        public IDictionary<string, string> Properties
        {
            get
            {
                if (_properties != null) return _properties;
                _properties = new Dictionary<string, string>();
                Interop.Place.PropertiesCallback callback = (index, total, key, value, userData) =>
                {
                    _properties[key] = value;
                    return true;
                };

                var err = Interop.Place.ForeachProperty(handle, callback, IntPtr.Zero);
                err.WarnIfFailed("Failed to get all properties for this place");

                return _properties;
            }
        }

        /// <summary>
        /// All categories attached with this place
        /// </summary>
        public IEnumerable<PlaceCategory> Categories
        {
            get
            {
                if (_categories != null) return _categories;
                _categories = new List<PlaceCategory>();
                Interop.Place.CategoriesCallback callback = (index, total, categoryHandle, userData) =>
                {
                    _categories.Add(new PlaceCategory(categoryHandle));
                    return true;
                };

                var err = Interop.Place.ForeachCategory(handle, callback, IntPtr.Zero);
                err.WarnIfFailed("Failed to get all categories for this place");

                return _categories;
            }
        }

        /// <summary>
        /// All attributes attached with this place
        /// </summary>
        public IEnumerable<PlaceAttribute> Attributes
        {
            get
            {
                if (_attributes != null) return _attributes;
                _attributes = new List<PlaceAttribute>();
                Interop.Place.AttributesCallback callback = (index, total, attributeHandle, userData) =>
                {
                    _attributes.Add(new PlaceAttribute(attributeHandle));
                    return true;
                };

                var err = Interop.Place.ForeachAttribute(handle, callback, IntPtr.Zero);
                err.WarnIfFailed("Failed to get all attributes for this place");

                return _attributes;
            }
        }

        /// <summary>
        /// All contacts attached with this place
        /// </summary>
        public IEnumerable<PlaceContact> Contacts
        {
            get
            {
                if (_contacts != null) return _contacts;
                _contacts = new List<PlaceContact>();
                Interop.Place.ContactsCallback callback = (index, total, contactHandle, userData) =>
                {
                    _contacts.Add(new PlaceContact(contactHandle));
                    return true;
                };

                var err = Interop.Place.ForeachContact(handle, callback, IntPtr.Zero);
                err.WarnIfFailed("Failed to get all contacts for this place");

                return _contacts;
            }
        }

        /// <summary>
        /// All editorials attached with this place
        /// </summary>
        public IEnumerable<PlaceEditorial> Editorials
        {
            get
            {
                if (_editorials != null) return _editorials;
                _editorials = new List<PlaceEditorial>();
                Interop.Place.EditorialsCallback callback = (index, total, editorialHandle, userData) =>
                {
                    _editorials.Add(new PlaceEditorial(editorialHandle));
                    return true;
                };

                var err = Interop.Place.ForeachEditorial(handle, callback, IntPtr.Zero);
                err.WarnIfFailed("Failed to get all editorials for this place");

                return _editorials;
            }
        }

        /// <summary>
        /// All images attached with this place
        /// </summary>
        public IEnumerable<PlaceImage> Images
        {
            get
            {
                if (_images != null) return _images;
                _images = new List<PlaceImage>();
                Interop.Place.ImagesCallback callback = (index, total, imageHandle, userData) =>
                {
                    _images.Add(new PlaceImage(imageHandle));
                    return true;
                };

                var err = Interop.Place.ForeachImage(handle, callback, IntPtr.Zero);
                err.WarnIfFailed("Failed to get all images for this place");

                return _images;
            }
        }

        /// <summary>
        /// All reviews attached with this place
        /// </summary>
        public IEnumerable<PlaceReview> Reviews
        {
            get
            {
                if (_reviews != null) return _reviews;
                _reviews = new List<PlaceReview>();
                Interop.Place.ReviewsCallback callback = (index, total, reviewHandle, userData) =>
                {
                    _reviews.Add(new PlaceReview(reviewHandle));
                    return true;
                };

                var err = Interop.Place.ForeachReview(handle, callback, IntPtr.Zero);
                err.WarnIfFailed("Failed to get all reviews for this place");

                return _reviews;
            }
        }

        /// <summary>
        /// Place image supplier link
        /// </summary>
        public PlaceLink Supplier { get { return _supplier; } }

        /// <summary>
        /// Place image related link
        /// </summary>
        public PlaceLink Related { get { return _related; } }
    }
}
