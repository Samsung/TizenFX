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
using System.Runtime.InteropServices;

namespace Tizen.Location
{
    /// <summary>
    /// Abstract class which provides functions related to geographic bounds information.
    /// </summary>
    public abstract class LocationBoundary
    {
        internal IntPtr handle;

        /// <summary>
        /// Gets the location boundary type.
        /// </summary>
        public BoundaryType BoundaryType{ get; internal set; }

        internal IntPtr GetHandle()
        {
            return handle;
        }

        /// <summary>
        /// Checks if the boundary contains the specified geographical coordinates.
        /// </summary>
        /// <param name="coordinate"> The coordinate which needs to be checked.</param>
        /// <returns>Returns a boolean value indicating whether or not the specified coordinate lies in the geographical area.</returns>
        public bool BoundaryContainsCoordinates(Coordinate coordinate)
        {
            Log.Info(Globals.LogTag, "Checking if coordinates are contained within boundary");
            return Interop.LocationBoundary.IsValidCoordinates(handle, coordinate);
        }
    }

    /// <summary>
    /// Class representing a rectangular location boundary.
    /// Inherits the Abstract LocationBoundary class.
    /// </summary>
    public class RectangleBoundary : LocationBoundary
    {
        /// <summary>
        /// Constructor of the Rectangle boundary class.
        /// </summary>
        /// <param name="topLeft"> The coordinate which constitute the top left handside of the rectangular boundary.</param>
        /// <param name="bottomRight"> The coordinate which constitute the bottom right handside of the rectangular boundary.</param>
        public RectangleBoundary(Coordinate topLeft, Coordinate bottomRight)
        {
            Log.Info(Globals.LogTag, "Calling RectangleBoundary constructor");
            BoundaryType = BoundaryType.Rectangle;
            IntPtr boundsHandle;
            int ret = Interop.LocationBoundary.CreateRectangularBoundary(topLeft, bottomRight, out boundsHandle);
            if ((LocationBoundError)ret != LocationBoundError.None)
            {
                Log.Error(Globals.LogTag, "Error Creating Rectangular Boundary," + (LocationBoundError)ret);
                LocationErrorFactory.ThrowLocationBoundaryException(ret);
            }
            handle = boundsHandle;
        }

        /// <summary>
        /// Gets the Top Left handside coordinate of a rectangular boundary.
        /// </summary>
        public Coordinate TopLeft
        {
            get
            {
                Log.Info(Globals.LogTag, "Calling to get CoordinateItem TopLeft");
                return GetRectangleCoordinate("TopLeft");
            }
        }

        /// <summary>
        /// Gets the Bottom Right handside coordinate of a rectangular boundary.
        /// </summary>
        public Coordinate BottomRight
        {
            get
            {
                Log.Info(Globals.LogTag, "Calling to get CoordinateItem BottomRight");
                return GetRectangleCoordinate("BottomRight");
            }
        }

        private Coordinate GetRectangleCoordinate(string tag)
        {
            Coordinate topLeft;
            Coordinate bottomRight;

            Interop.LocationBoundary.GetRectangleCoordinates(handle, out topLeft, out bottomRight);

            if (tag.Equals("TopLeft"))
            {
                return topLeft;
            }
            else
            {
                return bottomRight;
            }
        }
    }

    /// <summary>
    /// Class representing a circular location boundary.
    /// Inherits the Abstract LocationBoundary class.
    /// </summary>
    public class CircleBoundary : LocationBoundary
    {
        /// <summary>
        /// Constructor of the Circular boundary class.
        /// </summary>
        /// <param name="coordinate"> The coordinates which constitute the center of the circular boundary.</param>
        /// <param name="radius"> The radius value of the circular boundary.</param>
        public CircleBoundary(Coordinate coordinate, double radius)
        {
            Log.Info(Globals.LogTag, "Calling CircleBoundary constructor");
            BoundaryType = BoundaryType.Circle;
            IntPtr boundsHandle;
            int ret = Interop.LocationBoundary.CreateCircleBoundary(coordinate, radius, out boundsHandle);
            if ((LocationBoundError)ret != LocationBoundError.None)
            {
                Log.Error(Globals.LogTag, "Error Creating Circular Boundary," + (LocationBoundError)ret);
                LocationErrorFactory.ThrowLocationBoundaryException(ret);
            }
            handle = boundsHandle;
        }

        /// <summary>
        /// Gets the coordinate of the center of a circular boundary.
        /// </summary>
        public Coordinate Center
        {
            get
            {
                return GetCircleCenter();
            }
        }

        /// <summary>
        /// Gets the radius of a circular boundary.
        /// </summary>
        public double Radius
        {
            get
            {
                return GetRadius();
            }
        }

        private Coordinate GetCircleCenter()
        {
            Log.Info(Globals.LogTag, "Calling to get CoordinateItem Center");
            Coordinate center;
            double radius;
            Interop.LocationBoundary.GetCircleCoordinates(handle, out center, out radius);
            return center;
        }

        private double GetRadius()
        {
            Coordinate center;
            double radius = 0;
            Interop.LocationBoundary.GetCircleCoordinates(handle, out center, out radius);
            return radius;
        }
    }

    /// <summary>
    /// Class representing a polygonal location boundary.
    /// Inherits the Abstract LocationBoundary class.
    /// </summary>
    public class PolygonBoundary : LocationBoundary
    {
        /// <summary>
        /// Constructor of the polygon boundary class.
        /// </summary>
        /// <param name="coordinates"> The coordinates which constitute the polgonal boundary.</param>
        public PolygonBoundary(IList<Coordinate> coordinates)
        {
            Log.Info(Globals.LogTag, "Calling PolygonBoundary Constructor");
            BoundaryType = BoundaryType.Polygon;
            IntPtr[] pointers = new IntPtr[coordinates.Count];
            IntPtr listPointer = Marshal.AllocHGlobal(Marshal.SizeOf(coordinates[0]) * coordinates.Count);
            IntPtr boundsHandle;
            for (int i = 0; i < coordinates.Count; i++)
            {
                pointers[i] = Marshal.AllocHGlobal(Marshal.SizeOf(coordinates[0]));
                Marshal.StructureToPtr(coordinates[i], pointers[i], true);
                Marshal.WriteIntPtr(listPointer, i * Marshal.SizeOf(coordinates[0]), pointers[i]);
            }
            int ret = Interop.LocationBoundary.CreatePolygonBoundary(listPointer, coordinates.Count, out boundsHandle);
            if ((LocationBoundError)ret != LocationBoundError.None)
            {
                Log.Error(Globals.LogTag, "Error Creating Polygon Boundary," + (LocationBoundError)ret);
                LocationErrorFactory.ThrowLocationBoundaryException(ret);
            }
            handle = boundsHandle;
        }

        /// <summary>
        /// Gets the list of coordinates which constitute a polygonal boundary
        /// </summary>
        public IList<Coordinate> Coordinates
        {
            get
            {
                return GetCoordinates();
            }
        }

        private IList<Coordinate> GetCoordinates()
        {
            Log.Info(Globals.LogTag, "Calling to get Polygon coordinates");
            List<Coordinate> coordinateList = new List<Coordinate>();
            Interop.LocationBoundary.PolygonCoordinatesCallback callback = (Coordinate coordinate, IntPtr userData) =>
            {
                Coordinate item;
                item.Latitude = coordinate.Latitude;
                item.Longitude = coordinate.Longitude;
                coordinateList.Add(item);
                return true;
            };

            Interop.LocationBoundary.GetForEachPolygonCoordinates(handle, callback, IntPtr.Zero);
            return coordinateList;
        }
    }

    /// <summary>
    /// The structure which represents the  co-ordinates of a geographical location.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Coordinate
    {
        /// <summary>
        /// Latitude component of the co-ordinate.
        /// Should have a value between [-90.0 ~ 90.0] (degrees).
        /// </summary>
        public double Latitude;

        /// <summary>
        /// Longitude component of the co-ordinate.
        /// Should have a value between [-180.0 ~ 180.0] (degrees).
        /// </summary>
        public double Longitude;
    }
}
