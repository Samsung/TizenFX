/**
<summary>
The Tizen.Maps namespace provides classes to get the information of Place, Geocoding, Route by querying,
or to show them on the map view with interactive gestural interface.
<summary>



<remarks>

<h2>Overview</h2>
<para>
Maps API provides a developer with a set of functions, helping to create Maps aware applications.<p>

Maps API comprises of following features:<br/>
- Geocoding and reverse Geocoding<br/>
- Discoverying Place information<br/>
- Calculating Route<br/>
- View
</para>


<para>
Maps API allows a Developer to choose one of Map Providers which are being included as plugins.<p>

<para>
<h3>Geocoding</h3>
The Maps Geocoding API allows translating an address to its geographical
location defined in terms of latitude and longitude; the input can be a
qualified and structured address or a free-formed search text with full or
partial address information.<p>

The example below shows a structured address:<br/>
 - housenumber=117,<br/>
 - street=Invaliden street<br/>
 - city=Berlin,<br/>
 - postalcode=10115,<br/>
 - country=Germany,<br/>
 - state=Berlin
</para>


<para>
<h3>Reverse Geocoding</h3>
The Maps Reverse Geocoding API allows to inverse translating a geographical
location (longitude, latitude) to an address; it can be used to answer the
question "Where am I?".
</para>


<para>
<h3>Route</h3>
The Maps Route API provides ways to calculate a route that defines a path
between a start and a destination and may, optionally, pass through specific
intermediate locations.<p>

Route Preferences:<br/>
 - Travel Mode (car, pedestrian, public transit, truck),<br/>
 - Optimization (fastest, shortest),<br/>
 - Avoid/Prefer Preferences (toll road, motorway, ferry, public transit,
   tunnel, dirt road, parks, car-pool lane).<br/>
 - Route Calculations<br/>
 - Way points and preferences as input values,<br/>
 - Route geometry and maneuver (instructions for guidance) as result values:
   Geometry consists of points that visually represent the determined route,
   Maneuver contains turn-by-turn instruction and position.
</para>


<para>
<h3>Places</h3>
The Maps Place API allows you to find place information.<p>

Place search<br/>
 - Depending on the location context, the number of relevant places might
   be large. Therefore this query may not only return places, but also
   suggestions for additional filter criteria that allow users to interactively
   refine the classes of places they are interested in.<br/>
 - Nearby Search: search for places within a specified area.
   You can refine your search request by supplying keywords, Name of Points
   of Interests, or Proximity.<br/>
 - Category Search: search for popular places for the given location context and matching the category filter criteria.
   You can refine your search request by specifying the categories of place you are searching for.<p/>
Result item type of searching<br/>
- ID, name, location, distance, URI, rating, category.<p/>
Place information allows to fetch details about a place. The following place content is supported:<br/>
 - Base Attribute includes name, location, categories, contacts, ID, ratings, icon path,
   image content, review content, and editorial content.<br/>
 - Extended Attribute refers to opening hours, payment methods, annual closings, disabled access.
</para>


<para>
<h3>View</h3>
The Maps View API provides a developer with a set of functions, bringing
basic interactive visual user interface in maps applications.<p>

View widget: Drawing a map image on the map port, the specified rectangular
area of the maps application GUI.<p>

Zoom and rotation: Changing zoom and orientation of the view in response
to user gestures, such as scrolling, tapping, zooming, rotating, etc.<p>

Conversion of screen coordinates to geographical and vise versa.<p>

User's gesture support:<br/>
 - Receive the event of the user gesture.<br/>
 - Enable or disable the specified gesture.<br/>
 - Re-assign the action, which should be taken in response to the user's gesture.<p>

Various Properties:<br/>
 - Visibility and size on the screen.<br/>
 - Theme: Day, satellite, or terrain.<br/>
 - Language: English, Russian, Chinese, Italian, German, Spanish, etc.
</para>
</para>



<h2>Related Features</h2>
<para>
To guarantee that the Maps application runs on a device with Maps profile feature,
declare the following feature requirements in the config file:<br/>
http://tizen.org/feature/maps<br/>
http://tizen.org/feature/internet
</para>

</remarks>
*/

namespace Tizen.Maps {}

