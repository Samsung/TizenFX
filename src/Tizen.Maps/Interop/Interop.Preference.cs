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
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal enum DistanceUnit
    {
        Meter, // MAPS_DISTANCE_UNIT_M
        Kilometer, // MAPS_DISTANCE_UNIT_KM
        Foot, // MAPS_DISTANCE_UNIT_FT
        Yard, // MAPS_DISTANCE_UNIT_YD
    }

    internal enum RouteOptimization
    {
        Fastest, // MAPS_ROUTE_TYPE_FASTEST
        Shortest, // MAPS_ROUTE_TYPE_SHORTEST
        Economic, // MAPS_ROUTE_TYPE_ECONOMIC
        Scenic, // MAPS_ROUTE_TYPE_SCENIC
        FastestNow, // MAPS_ROUTE_TYPE_FASTESTNOW
        DirectDrive, // MAPS_ROUTE_TYPE_DIRECTDRIVE
    }

    internal enum RouteTransportMode
    {
        Car, // MAPS_ROUTE_TRANSPORT_MODE_CAR
        Pedestrian, // MAPS_ROUTE_TRANSPORT_MODE_PEDESTRIAN
        Bicycle, // MAPS_ROUTE_TRANSPORT_MODE_BICYCLE
        PublicTransit, // MAPS_ROUTE_TRANSPORT_MODE_PUBLICTRANSIT
        Truck, // MAPS_ROUTE_TRANSPORT_MODE_TRUCK
    }

    internal enum RouteFeatureWeight
    {
        Normal, // MAPS_ROUTE_FEATURE_WEIGHT_NORMAL
        Prefer, // MAPS_ROUTE_FEATURE_WEIGHT_PREFER
        Avoid, // MAPS_ROUTE_FEATURE_WEIGHT_AVOID
        SoftExclude, // MAPS_ROUTE_FEATURE_WEIGHT_SOFTEXCLUDE
        StrictExclude, // MAPS_ROUTE_FEATURE_WEIGHT_STRICTEXCLUDE
    }

    internal enum RouteRequestFeature
    {
        None, // MAPS_ROUTE_FEATURE_NO
        Toll, // MAPS_ROUTE_FEATURE_TOLL
        MotorWay, // MAPS_ROUTE_FEATURE_MOTORWAY
        BoatFerry, // MAPS_ROUTE_FEATURE_BOATFERRY
        RailFerry, // MAPS_ROUTE_FEATURE_RAILFERRY
        PublicTransit, // MAPS_ROUTE_FEATURE_PUBLICTTRANSIT
        Tunnel, // MAPS_ROUTE_FEATURE_TUNNEL
        DirtRoad, // MAPS_ROUTE_FEATURE_DIRTROAD
        Parks, // MAPS_ROUTE_FEATURE_PARKS
        Hovlane, // MAPS_ROUTE_FEATURE_HOVLANE
        Stairs, // MAPS_ROUTE_FEATURE_STAIRS
    }

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_get_distance_unit")]
    internal static extern ErrorCode GetDistanceUnit(this PreferenceHandle /* maps_preference_h */ preference, out DistanceUnit /* maps_distance_unit_e */ unit);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_set_distance_unit")]
    internal static extern ErrorCode SetDistanceUnit(this PreferenceHandle /* maps_preference_h */ preference, DistanceUnit /* maps_distance_unit_e */ unit);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_get_language")]
    internal static extern ErrorCode GetLanguage(this PreferenceHandle /* maps_preference_h */ preference, out string language);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_set_language")]
    internal static extern ErrorCode SetLanguage(this PreferenceHandle /* maps_preference_h */ preference, string language);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_get_max_results")]
    internal static extern ErrorCode GetMaxResults(this PreferenceHandle /* maps_preference_h */ preference, out int maxResults);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_set_max_results")]
    internal static extern ErrorCode SetMaxResults(this PreferenceHandle /* maps_preference_h */ preference, int maxResults);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_get_country_code")]
    internal static extern ErrorCode GetCountryCode(this PreferenceHandle /* maps_preference_h */ preference, out string countryCode);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_set_country_code")]
    internal static extern ErrorCode SetCountryCode(this PreferenceHandle /* maps_preference_h */ preference, string countryCode);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_get_route_optimization")]
    internal static extern ErrorCode GetRouteOptimization(this PreferenceHandle /* maps_preference_h */ preference, out RouteOptimization /* maps_route_optimization_e */ optimization);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_set_route_optimization")]
    internal static extern ErrorCode SetRouteOptimization(this PreferenceHandle /* maps_preference_h */ preference, RouteOptimization /* maps_route_optimization_e */ optimization);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_get_route_transport_mode")]
    internal static extern ErrorCode GetRouteTransportMode(this PreferenceHandle /* maps_preference_h */ preference, out RouteTransportMode /* maps_route_transport_mode_e */ transportMode);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_set_route_transport_mode")]
    internal static extern ErrorCode SetRouteTransportMode(this PreferenceHandle /* maps_preference_h */ preference, RouteTransportMode /* maps_route_transport_mode_e */ transportMode);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_get_route_feature_weight")]
    internal static extern ErrorCode GetRouteFeatureWeight(this PreferenceHandle /* maps_preference_h */ preference, out RouteFeatureWeight /* maps_route_feature_weight_e */ featureWeight);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_set_route_feature_weight")]
    internal static extern ErrorCode SetRouteFeatureWeight(this PreferenceHandle /* maps_preference_h */ preference, RouteFeatureWeight /* maps_route_feature_weight_e */ featureWeight);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_get_route_feature")]
    internal static extern ErrorCode GetRouteFeature(this PreferenceHandle /* maps_preference_h */ preference, out RouteRequestFeature /* maps_route_feature_e */ feature);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_set_route_feature")]
    internal static extern ErrorCode SetRouteFeature(this PreferenceHandle /* maps_preference_h */ preference, RouteRequestFeature /* maps_route_feature_e */ feature);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_get_route_alternatives_enabled")]
    internal static extern ErrorCode GetRouteAlternativesEnabled(this PreferenceHandle /* maps_preference_h */ preference, out bool enable);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_set_route_alternatives_enabled")]
    internal static extern ErrorCode SetRouteAlternativesEnabled(this PreferenceHandle /* maps_preference_h */ preference, bool enable);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_get")]
    internal static extern ErrorCode GetProperty(this PreferenceHandle /* maps_preference_h */ preference, string key, out string value);

    [DllImport(Libraries.MapService, EntryPoint = "maps_preference_set_property")]
    internal static extern ErrorCode SetProperty(this PreferenceHandle /* maps_preference_h */ preference, string key, string value);

    internal class PreferenceHandle : SafeMapsHandle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PropertiesCallback(int index, int total, string key, string value, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_preference_foreach_property")]
        internal static extern ErrorCode ForeachProperty(IntPtr /* maps_preference_h */ preference, PropertiesCallback callback, IntPtr /* void */ userData);


        [DllImport(Libraries.MapService, EntryPoint = "maps_preference_create")]
        internal static extern ErrorCode Create(out IntPtr /* maps_preference_h */ preference);

        [DllImport(Libraries.MapService, EntryPoint = "maps_preference_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_preference_h */ preference);

        internal DistanceUnit Unit
        {
            get { return NativeGet<DistanceUnit>(this.GetDistanceUnit); }
            set { NativeSet(this.SetDistanceUnit, value); }
        }

        internal string Language
        {
            get { return NativeGet(this.GetLanguage); }
            set { NativeSet(this.SetLanguage, value); }
        }

        internal int MaxResult
        {
            get { return NativeGet<int>(this.GetMaxResults); }
            set { NativeSet(this.SetMaxResults, value); }
        }

        internal string CountryCode
        {
            get { return NativeGet(this.GetCountryCode); }
            set { NativeSet(this.SetCountryCode, value); }
        }

        internal RouteOptimization Optimization
        {
            get { return NativeGet<RouteOptimization>(this.GetRouteOptimization); }
            set { NativeSet(this.SetRouteOptimization, value); }
        }

        internal RouteTransportMode TransportMode
        {
            get { return NativeGet<RouteTransportMode>(this.GetRouteTransportMode); }
            set { NativeSet(this.SetRouteTransportMode, value); }
        }

        internal RouteRequestFeature Feature
        {
            get { return NativeGet<RouteRequestFeature>(this.GetRouteFeature); }
            set { NativeSet(this.SetRouteFeature, value); }
        }

        internal RouteFeatureWeight FeatureWeight
        {
            get { return NativeGet<RouteFeatureWeight>(this.GetRouteFeatureWeight); }
            set { NativeSet(this.SetRouteFeatureWeight, value); }
        }

        internal bool AlternativesEnabled
        {
            get { return NativeGet<bool>(this.GetRouteAlternativesEnabled); }
            set { NativeSet(this.SetRouteAlternativesEnabled, value); }
        }

        internal PreferenceHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }

        internal PreferenceHandle() : this(IntPtr.Zero, true)
        {
            Create(out handle).ThrowIfFailed("Failed to create native handle");
        }

        internal void ForeachProperty(Action<string, string> action)
        {
            PropertiesCallback callback = (index, total, key, value, userData) =>
            {
                action(key, value);
                return true;
            };

            ForeachProperty(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get property list from native handle");
        }

        internal static PreferenceHandle Create(IntPtr nativeHandle)
        {
            return new PreferenceHandle(nativeHandle, true);
        }
    }
}
