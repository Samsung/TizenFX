---
uid: Tizen.Maps
remarks: *content
---
## Overview

Maps API provides a developer with a set of functions, helping to create Maps aware applications.

Maps API comprises of following features:
- [Geocoding](#geocoding) and [reverse Geocoding](#reverse-geocoding)
- Discoverying [place](#places) information
- Calculating [route](#route)
- [View](#view)

Maps API allows a Developer to choose one of Map Providers which are being included as plugins.

### Geocoding

The [Maps Geocoding](xref:Tizen.Maps.GeocodeRequest) API allows translating an address to its geographical
location defined in terms of latitude and longitude; the input can be a
qualified and structured address or a free-formed search text with full or
partial address information.

The example below shows a structured address:
 - housenumber=117,
 - street=Invaliden street
 - city=Berlin,
 - postalcode=10115,
 - country=Germany,
 - state=Berlin


### Reverse Geocoding

The [Maps Reverse Geocoding](xref:Tizen.Maps.ReverseGeocodeRequest) API allows to inverse translating a geographical
location (longitude, latitude) to an address; it can be used to answer the
question "Where am I?".


### Route

The [Maps Route](xref:Tizen.Maps.Route) API provides ways to calculate a route that defines a path
between a start and a destination and may, optionally, pass through specific
intermediate locations.

Route Preferences:
 - Travel Mode (car, pedestrian, public transit, truck),
 - Optimization (fastest, shortest),
 - Avoid/Prefer Preferences (toll road, motorway, ferry, public transit,
   tunnel, dirt road, parks, car-pool lane).
 - Route Calculations
 - Way points and preferences as input values,
 - Route geometry and maneuver (instructions for guidance) as result values:
   Geometry consists of points that visually represent the determined route,
   Maneuver contains turn-by-turn instruction and position.


### Places

The [Maps Place](xref:Tizen.Maps.Place) API allows you to find place information.

Place search
 - Depending on the location context, the number of relevant places might
   be large. Therefore this query may not only return places, but also
   suggestions for additional filter criteria that allow users to interactively
   refine the classes of places they are interested in.
 - Nearby Search: search for places within a specified area.
   You can refine your search request by supplying keywords, Name of Points
   of Interests, or Proximity.
 - Category Search: search for popular places for the given location context and matching the category filter criteria.
   You can refine your search request by specifying the categories of place you are searching for.
Result item type of searching
 - ID, name, location, distance, URI, rating, category.
Place information allows to fetch details about a place. The following place content is supported:
 - Base Attribute includes name, location, categories, contacts, ID, ratings, icon path,
   image content, review content, and editorial content.
 - Extended Attribute refers to opening hours, payment methods, annual closings, disabled access.


### View
The [Maps View](xref:Tizen.Maps.MapView) API provides a developer with a set of functions, bringing
basic interactive visual user interface in maps applications.

View widget: Drawing a map image on the map port, the specified rectangular
area of the maps application GUI.

Zoom and rotation: Changing zoom and orientation of the view in response
to user gestures, such as scrolling, tapping, zooming, rotating, etc.

Conversion of screen coordinates to geographical and vice versa.

User's gesture support:
 - Receive the event of the user gesture.
 - Enable or disable the specified gesture.
 - Re-assign the action, which should be taken in response to the user's gesture.

Various Properties:
 - Visibility and size on the screen.
 - Theme: Day, satellite, or terrain.
 - Language: English, Russian, Chinese, Italian, German, Spanish, etc.


### Related Features
To guarantee that the Maps application runs on a device with Maps profile feature,
declare the following feature requirements in the config file:
* http://tizen.org/feature/maps
* http://tizen.org/feature/internet
