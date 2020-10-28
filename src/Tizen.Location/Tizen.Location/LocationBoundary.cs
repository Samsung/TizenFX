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

using Tizen.Internals;

namespace Tizen.Location
{
    /// <summary>
    /// The LocationBoundary class is an abstract class that provides functions related to the geographic bounds information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class LocationBoundary : IDisposable
    {
        internal IntPtr handle;
        private bool _disposed = false;

        /// <summary>
        /// Gets the location boundary type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BoundaryType BoundaryType{ get; internal set; }

        internal LocationBoundary() { }
        /// <summary>
        /// The destructor of the LocationBoundary class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ~LocationBoundary()
        {
            Log.Info(Globals.LogTag, "The destructor of LocationBoundary class");
            Dispose(false);
        }

        internal IntPtr GetHandle()
        {
            return handle;
        }

        /// <summary>
        /// Checks if the boundary contains the specified geographical coordinates.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="coordinate"> The coordinate which needs to be checked.</param>
        /// <returns>Returns a boolean value indicating whether or not the specified coordinate lies in the geographical area.</returns>
        public bool BoundaryContainsCoordinates(Coordinate coordinate)
        {
            Log.Info(Globals.LogTag, "Checking if coordinates are contained within boundary");
            return Interop.LocationBoundary.IsValidCoordinates(handle, coordinate);
        }

        /// <summary>
        /// The overidden Dispose method of the IDisposable class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported.</exception>
        public void Dispose()
        {
            Log.Info(Globals.LogTag, "Dispose");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            Log.Info(Globals.LogTag, "Dispose");
            if (_disposed)
                return;

            if (disposing)
                DestroyHandle();

            _disposed = true;
        }

        private void DestroyHandle()
        {
            Log.Info(Globals.LogTag, "DestroyBoundaryHandle");
            int ret = Interop.LocationBoundary.DestroyBoundary(handle);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error in DestroyBoundary handle" + (LocationError)ret);
                throw LocationErrorFactory.ThrowLocationException(ret);
            }
        }
    }

    /// <summary>
    /// This class represents a rectangular location boundary.
    /// Inherits the Abstract LocationBoundary class.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class RectangleBoundary : LocationBoundary
    {
        /// <summary>
        /// The constructor of the Rectangle boundary class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="topLeft"> The coordinate which constitutes the top-left handside of the rectangular boundary.</param>
        /// <param name="bottomRight"> The coordinate which constitutes the bottom-right handside of the rectangular boundary.</param>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported.</exception>
        public RectangleBoundary(Coordinate topLeft, Coordinate bottomRight)
        {
            Log.Info(Globals.LogTag, "Calling RectangleBoundary constructor");
            BoundaryType = BoundaryType.Rectangle;
            IntPtr boundsHandle;
            int ret = Interop.LocationBoundary.CreateRectangularBoundary(topLeft, bottomRight, out boundsHandle);
            if ((LocationBoundError)ret != LocationBoundError.None)
            {
                Log.Error(Globals.LogTag, "Error Creating Rectangular Boundary," + (LocationBoundError)ret);
                throw LocationErrorFactory.ThrowLocationBoundaryException(ret);
            }
            handle = boundsHandle;
        }

        /// <summary>
        /// Gets the top-left handside coordinate of a rectangular boundary.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Coordinate TopLeft
        {
            get
            {
                Log.Info(Globals.LogTag, "Calling to get CoordinateItem TopLeft");
                return GetRectangleCoordinate("TopLeft");
            }
        }

        /// <summary>
        /// Gets the bottom-right handside coordinate of a rectangular boundary.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
    /// This class represents a circular location boundary.
    /// Inherits the Abstract LocationBoundary class.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CircleBoundary : LocationBoundary
    {
        /// <summary>
        /// The constructor of the Circular boundary class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="coordinate"> The coordinates which constitute the center of the circular boundary.</param>
        /// <param name="radius"> The radius value of the circular boundary.</param>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported.</exception>
        public CircleBoundary(Coordinate coordinate, double radius)
        {
            Log.Info(Globals.LogTag, "Calling CircleBoundary constructor");
            BoundaryType = BoundaryType.Circle;
            IntPtr boundsHandle;
            int ret = Interop.LocationBoundary.CreateCircleBoundary(coordinate, radius, out boundsHandle);
            if ((LocationBoundError)ret != LocationBoundError.None)
            {
                Log.Error(Globals.LogTag, "Error Creating Circular Boundary," + (LocationBoundError)ret);
                throw LocationErrorFactory.ThrowLocationBoundaryException(ret);
            }
            handle = boundsHandle;
        }

        /// <summary>
        /// Gets the coordinate of the center of a circular boundary.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported.</exception>
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
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported.</exception>
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
            int ret = Interop.LocationBoundary.GetCircleCoordinates(handle, out center, out radius);
            if ((LocationBoundError)ret != LocationBoundError.None)
            {
                Log.Error(Globals.LogTag, "Error Get Circle Center," + (LocationBoundError)ret);
                throw LocationErrorFactory.ThrowLocationBoundaryException(ret);
            }
            return center;
        }

        private double GetRadius()
        {
            Coordinate center;
            double radius = 0;
            int ret = Interop.LocationBoundary.GetCircleCoordinates(handle, out center, out radius);
            if ((LocationBoundError)ret != LocationBoundError.None)
            {
                Log.Error(Globals.LogTag, "Error Get Radius," + (LocationBoundError)ret);
                throw LocationErrorFactory.ThrowLocationBoundaryException(ret);
            }
            return radius;
        }
    }

    /// <summary>
    /// This class represents a polygonal location boundary.
    /// Inherits the Abstract LocationBoundary class.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PolygonBoundary : LocationBoundary
    {
        /// <summary>
        /// The constructor of the Polygon Boundary class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="coordinates"> The coordinates which constitute the polgonal boundary.</param>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported.</exception>
        public PolygonBoundary(IList<Coordinate> coordinates)
        {
            Log.Info(Globals.LogTag, "Calling PolygonBoundary Constructor");
            if (coordinates == null)
            {
                Log.Error(Globals.LogTag, "coordingtes list is null");
                throw LocationErrorFactory.ThrowLocationException((int)LocationError.InvalidParameter);
            }

            BoundaryType = BoundaryType.Polygon;
            IntPtr listPointer = Marshal.AllocHGlobal(Marshal.SizeOf(coordinates[0]) * coordinates.Count);
            IntPtr boundsHandle;
            for (int i = 0; i < coordinates.Count; i++)
            {
                Marshal.StructureToPtr(coordinates[i], listPointer + i * Marshal.SizeOf(coordinates[0]), false);
            }
            int ret = Interop.LocationBoundary.CreatePolygonBoundary(listPointer, coordinates.Count, out boundsHandle);
            if ((LocationBoundError)ret != LocationBoundError.None)
            {
                Log.Error(Globals.LogTag, "Error Creating Polygon Boundary," + (LocationBoundError)ret);
                throw LocationErrorFactory.ThrowLocationBoundaryException(ret);
            }
            handle = boundsHandle;
        }

        /// <summary>
        /// Gets the list of coordinates which constitute a polygonal boundary.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the location is not supported.</exception>
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

            int ret = Interop.LocationBoundary.GetForEachPolygonCoordinates(handle, callback, IntPtr.Zero);
            if ((LocationBoundError)ret != LocationBoundError.None)
            {
                Log.Error(Globals.LogTag, "Error Get foreach Boundary," + (LocationBoundError)ret);
                throw LocationErrorFactory.ThrowLocationBoundaryException(ret);
            }
            return coordinateList;
        }
    }

    /// <summary>
    /// This structure represents the coordinates of a geographical location.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [NativeStruct("location_coords_s", Include="locations.h", PkgConfig="capi-location-manager")]
    [StructLayout(LayoutKind.Sequential)]
    public struct Coordinate
    {
        /// <summary>
        /// Latitude component of the coordinate.
        /// Should have a value between [-90.0 ~ 90.0] \(degrees).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public double Latitude;

        /// <summary>
        /// Longitude component of the coordinate.
        /// Should have a value between [-180.0 ~ 180.0] \(degrees).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public double Longitude;
    }
}
