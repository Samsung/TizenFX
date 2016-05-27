/**
 * Copyright (c)2005-2009 Matt Kruse (javascripttoolbox.com)
 * 
 * Dual licensed under the MIT and GPL licenses. 
 * This basically means you can use this code however you want for
 * free, but don't claim to have written it yourself!
 * Donations always accepted: http://www.JavascriptToolbox.com/donate/
 * 
 * Please do not link to the .js files on javascripttoolbox.com from
 * your site. Copy the files locally to your server instead.
 * 
 */
/* ******************************************************************* */
/*   UTIL FUNCTIONS                                                    */
/* ******************************************************************* */
var Util = {'$VERSION':1.06};

// Util functions - these are GLOBAL so they
// look like built-in functions.

// Determine if an object is an array
function isArray(o) {
	return (o!=null && typeof(o)=="object" && typeof(o.length)=="number" && (o.length==0 || defined(o[0])));
};

// Determine if an object is an Object
function isObject(o) {
	return (o!=null && typeof(o)=="object" && defined(o.constructor) && o.constructor==Object && !defined(o.nodeName));
};

// Determine if a reference is defined
function defined(o) {
	return (typeof(o)!="undefined");
};

// Iterate over an array, object, or list of items and run code against each item
// Similar functionality to Perl's map() function
function map(func) {
	var i,j,o;
	var results = [];
	if (typeof(func)=="string") {
		func = new Function('$_',func);
	}
	for (i=1; i<arguments.length; i++) {
		o = arguments[i];
		if (isArray(o)) {
			for (j=0; j<o.length; j++) {
				results[results.length] = func(o[j]);
			}
		}
		else if (isObject(o)) {
			for (j in o) {
				results[results.length] = func(o[j]);
			}
		}
		else {
			results[results.length] = func(o);
		}
	}
	return results;
};

// Set default values in an object if they are undefined
function setDefaultValues(o,values) {
	if (!defined(o) || o==null) {
		o = {};
	}
	if (!defined(values) || values==null) {
		return o;
	}
	for (var val in values) {
		if (!defined(o[val])) {
			o[val] = values[val];
		}
	}
	return o;
};

/* ******************************************************************* */
/*   DEFAULT OBJECT PROTOTYPE ENHANCEMENTS                             */
/* ******************************************************************* */
// These functions add useful functionality to built-in objects
Array.prototype.contains = function(o) {
	var i,l;
	if (!(l = this.length)) { return false; }
	for (i=0; i<l; i++) {
		if (o==this[i]) {
			return true;
		}
	}
};

/* ******************************************************************* */
/*   DOM FUNCTIONS                                                     */
/* ******************************************************************* */
var DOM = (function() { 
	var dom = {};
	
	// Get a parent tag with a given nodename
	dom.getParentByTagName = function(o,tagNames) {
		if(o==null) { return null; }
		if (isArray(tagNames)) {
			tagNames = map("return $_.toUpperCase()",tagNames);
			while (o=o.parentNode) {
				if (o.nodeName && tagNames.contains(o.nodeName)) {
					return o;
				}
			}
		}
		else {
			tagNames = tagNames.toUpperCase();
			while (o=o.parentNode) {
				if (o.nodeName && tagNames==o.nodeName) {
					return o;
				}
			}
		}
		return null;
	};
	
	// Remove a node from its parent
	dom.removeNode = function(o) {
		if (o!=null && o.parentNode && o.parentNode.removeChild) {
			// First remove all attributes which are func references, to avoid memory leaks
			for (var i in o) {
				if (typeof(o[i])=="function") {
					o[i] = null;
				}
			}
			o.parentNode.removeChild(o);
			return true;
		}
		return false;
	};

	// Get the outer width in pixels of an object, including borders, padding, and margin
	dom.getOuterWidth = function(o) {
		if (defined(o.offsetWidth)) {
			return o.offsetWidth;
		}
		return null;
	};

	// Get the outer height in pixels of an object, including borders, padding, and margin
	dom.getOuterHeight = function(o) {
		if (defined(o.offsetHeight)) {
			return o.offsetHeight;
		}
		return null;
	};

	// Resolve an item, an array of items, or an object of items
	dom.resolve = function() {
		var results = new Array();
		var i,j,o;
		for (var i=0; i<arguments.length; i++) {
			var o = arguments[i];
			if (o==null) {
				if (arguments.length==1) {
					return null;
				}
				results[results.length] = null;
			}
			else if (typeof(o)=='string') {
				if (document.getElementById) {
					o = document.getElementById(o);
				}
				else if (document.all) {
					o = document.all[o];
				}
				if (arguments.length==1) {
					return o;
				}
				results[results.length] = o;
			}
			else if (isArray(o)) {
				for (j=0; j<o.length; j++) {
					results[results.length] = o[j];
				}
			}
			else if (isObject(o)) {
				for (j in o) {
					results[results.length] = o[j];
				}
			}
			else if (arguments.length==1) {
				return o;
			}
			else {
				results[results.length] = o;
			}
	  }
	  return results;
	};
	dom.$ = dom.resolve;
	
	return dom;
})();

/* ******************************************************************* */
/*   CSS FUNCTIONS                                                     */
/* ******************************************************************* */
var CSS = (function(){
	var css = {};

	// Convert an RGB string in the form "rgb (255, 255, 255)" to "#ffffff"
	css.rgb2hex = function(rgbString) {
		if (typeof(rgbString)!="string" || !defined(rgbString.match)) { return null; }
		var result = rgbString.match(/^\s*rgb\s*\(\s*(\d+)\s*,\s*(\d+)\s*,\s*(\d+)\s*/);
		if (result==null) { return rgbString; }
		var rgb = +result[1] << 16 | +result[2] << 8 | +result[3];
		var hex = "";
		var digits = "0123456789abcdef";
		while(rgb!=0) { 
			hex = digits.charAt(rgb&0xf)+hex; 
			rgb>>>=4; 
		} 
		while(hex.length<6) { hex='0'+hex; }
		return "#" + hex;
	};

	// Convert hyphen style names like border-width to camel case like borderWidth
	css.hyphen2camel = function(property) {
		if (!defined(property) || property==null) { return null; }
		if (property.indexOf("-")<0) { return property; }
		var str = "";
		var c = null;
		var l = property.length;
		for (var i=0; i<l; i++) {
			c = property.charAt(i);
			str += (c!="-")?c:property.charAt(++i).toUpperCase();
		}
		return str;
	};
	
	// Determine if an object or class string contains a given class.
	css.hasClass = function(obj,className) {
		if (!defined(obj) || obj==null || !RegExp) { return false; }
		var re = new RegExp("(^|\\s)" + className + "(\\s|$)");
		if (typeof(obj)=="string") {
			return re.test(obj);
		}
		else if (typeof(obj)=="object" && obj.className) {
			return re.test(obj.className);
		}
		return false;
	};
	
	// Add a class to an object
	css.addClass = function(obj,className) {
		if (typeof(obj)!="object" || obj==null || !defined(obj.className)) { return false; }
		if (obj.className==null || obj.className=='') { 
			obj.className = className; 
			return true; 
		}
		if (css.hasClass(obj,className)) { return true; }
		obj.className = obj.className + " " + className;
		return true;
	};
	
	// Remove a class from an object
	css.removeClass = function(obj,className) {
		if (typeof(obj)!="object" || obj==null || !defined(obj.className) || obj.className==null) { return false; }
		if (!css.hasClass(obj,className)) { return false; }
		var re = new RegExp("(^|\\s+)" + className + "(\\s+|$)");
		obj.className = obj.className.replace(re,' ');
		return true;
	};
	
	// Fully replace a class with a new one
	css.replaceClass = function(obj,className,newClassName) {
		if (typeof(obj)!="object" || obj==null || !defined(obj.className) || obj.className==null) { return false; }
		css.removeClass(obj,className);
		css.addClass(obj,newClassName);
		return true;
	};
	
	// Get the currently-applied style of an object
	css.getStyle = function(o, property) {
		if (o==null) { return null; }
		var val = null;
		var camelProperty = css.hyphen2camel(property);
		// Handle "float" property as a special case
		if (property=="float") {
			val = css.getStyle(o,"cssFloat");
			if (val==null) { 
				val = css.getStyle(o,"styleFloat"); 
			}
		}
		else if (o.currentStyle && defined(o.currentStyle[camelProperty])) {
			val = o.currentStyle[camelProperty];
		}
		else if (window.getComputedStyle) {
			val = window.getComputedStyle(o,null).getPropertyValue(property);
		}
		else if (o.style && defined(o.style[camelProperty])) {
			val = o.style[camelProperty];
		}
		// For color values, make the value consistent across browsers
		// Convert rgb() colors back to hex for consistency
		if (/^\s*rgb\s*\(/.test(val)) {
			val = css.rgb2hex(val);
		}
		// Lowercase all #hex values
		if (/^#/.test(val)) {
			val = val.toLowerCase();
		}
		return val;
	};
	css.get = css.getStyle;

	// Set a style on an object
	css.setStyle = function(o, property, value) {
		if (o==null || !defined(o.style) || !defined(property) || property==null || !defined(value)) { return false; }
		if (property=="float") {
			o.style["cssFloat"] = value;
			o.style["styleFloat"] = value;
		}
		else if (property=="opacity") {
			o.style['-moz-opacity'] = value;
			o.style['-khtml-opacity'] = value;
			o.style.opacity = value;
			if (defined(o.style.filter)) {
				o.style.filter = "alpha(opacity=" + value*100 + ")";
			}
		}
		else {
			o.style[css.hyphen2camel(property)] = value;
		}
		return true;
	};
	css.set = css.setStyle;
	
	// Get a unique ID which doesn't already exist on the page
	css.uniqueIdNumber=1000;
	css.createId = function(o) {
		if (defined(o) && o!=null && defined(o.id) && o.id!=null && o.id!="") { 
			return o.id;
		}
		var id = null;
		while (id==null || document.getElementById(id)!=null) {
			id = "ID_"+(css.uniqueIdNumber++);
		}
		if (defined(o) && o!=null && (!defined(o.id)||o.id=="")) {
			o.id = id;
		}
		return id;
	};
	
	return css;
})();

/* ******************************************************************* */
/*   EVENT FUNCTIONS                                                   */
/* ******************************************************************* */

var Event = (function(){
	var ev = {};
	
	// Resolve an event using IE's window.event if necessary
	// --------------------------------------------------------------------
	ev.resolve = function(e) {
		if (!defined(e) && defined(window.event)) {
			e = window.event;
		}
		return e;
	};
	
	// Add an event handler to a function
	// Note: Don't use 'this' within functions added using this method, since
	// the attachEvent and addEventListener models differ.
	// --------------------------------------------------------------------
	ev.add = function( obj, type, fn, capture ) {
		if (obj.addEventListener) {
			obj.addEventListener( type, fn, capture );
			return true;
		}
		else if (obj.attachEvent) {
			obj.attachEvent( "on"+type, fn );
			return true;
		}
		return false;
	};

	// Get the mouse position of an event
	// --------------------------------------------------------------------
	// PageX/Y, where they exist, are more reliable than ClientX/Y because 
	// of some browser bugs in Opera/Safari
	ev.getMouseX = function(e) {
		e = ev.resolve(e);
		if (defined(e.pageX)) {
			return e.pageX;
		}
		if (defined(e.clientX)) {
			return e.clientX+Screen.getScrollLeft();
		}
		return null;
	};
	ev.getMouseY = function(e) {
		e = ev.resolve(e);
		if (defined(e.pageY)) {
			return e.pageY;
		}
		if (defined(e.clientY)) {
			return e.clientY+Screen.getScrollTop();
		}
		return null;
	};

	// Stop the event from bubbling up to parent elements.
	// Two method names map to the same function
	// --------------------------------------------------------------------
	ev.cancelBubble = function(e) {
		e = ev.resolve(e);
		if (typeof(e.stopPropagation)=="function") { e.stopPropagation(); } 
		if (defined(e.cancelBubble)) { e.cancelBubble = true; }
	};
	ev.stopPropagation = ev.cancelBubble;

	// Prevent the default handling of the event to occur
	// --------------------------------------------------------------------
	ev.preventDefault = function(e) {
		e = ev.resolve(e);
		if (typeof(e.preventDefault)=="function") { e.preventDefault(); } 
		if (defined(e.returnValue)) { e.returnValue = false; }
	};
	
	return ev;
})();

/* ******************************************************************* */
/*   SCREEN FUNCTIONS                                                  */
/* ******************************************************************* */
var Screen = (function() {
	var screen = {};

	// Get a reference to the body
	// --------------------------------------------------------------------
	screen.getBody = function() {
		if (document.body) {
			return document.body;
		}
		if (document.getElementsByTagName) {
			var bodies = document.getElementsByTagName("BODY");
			if (bodies!=null && bodies.length>0) {
				return bodies[0];
			}
		}
		return null;
	};

	// Get the amount that the main document has scrolled from top
	// --------------------------------------------------------------------
	screen.getScrollTop = function() {
		if (document.documentElement && defined(document.documentElement.scrollTop) && document.documentElement.scrollTop>0) {
			return document.documentElement.scrollTop;
		}
		if (document.body && defined(document.body.scrollTop)) {
			return document.body.scrollTop;
		}
		return null;
	};
	
	// Get the amount that the main document has scrolled from left
	// --------------------------------------------------------------------
	screen.getScrollLeft = function() {
		if (document.documentElement && defined(document.documentElement.scrollLeft) && document.documentElement.scrollLeft>0) {
			return document.documentElement.scrollLeft;
		}
		if (document.body && defined(document.body.scrollLeft)) {
			return document.body.scrollLeft;
		}
		return null;
	};
	
	// Util function to default a bad number to 0
	// --------------------------------------------------------------------
	screen.zero = function(n) {
		return (!defined(n) || isNaN(n))?0:n;
	};

	// Get the width of the entire document
	// --------------------------------------------------------------------
	screen.getDocumentWidth = function() {
		var width = 0;
		var body = screen.getBody();
		if (document.documentElement && (!document.compatMode || document.compatMode=="CSS1Compat")) {
		    var rightMargin = parseInt(CSS.get(body,'marginRight'),10) || 0;
		    var leftMargin = parseInt(CSS.get(body,'marginLeft'), 10) || 0;
			width = Math.max(body.offsetWidth + leftMargin + rightMargin, document.documentElement.clientWidth);
		}
		else {
			width =  Math.max(body.clientWidth, body.scrollWidth);
		}
		if (isNaN(width) || width==0) {
			width = screen.zero(self.innerWidth);
		}
		return width;
	};
	
	// Get the height of the entire document
	// --------------------------------------------------------------------
	screen.getDocumentHeight = function() {
		var body = screen.getBody();
		var innerHeight = (defined(self.innerHeight)&&!isNaN(self.innerHeight))?self.innerHeight:0;
		if (document.documentElement && (!document.compatMode || document.compatMode=="CSS1Compat")) {
		    var topMargin = parseInt(CSS.get(body,'marginTop'),10) || 0;
		    var bottomMargin = parseInt(CSS.get(body,'marginBottom'), 10) || 0;
			return Math.max(body.offsetHeight + topMargin + bottomMargin, document.documentElement.clientHeight, document.documentElement.scrollHeight, screen.zero(self.innerHeight));
		}
		return Math.max(body.scrollHeight, body.clientHeight, screen.zero(self.innerHeight));
	};
	
	// Get the width of the viewport (viewable area) in the browser window
	// --------------------------------------------------------------------
	screen.getViewportWidth = function() {
		if (document.documentElement && (!document.compatMode || document.compatMode=="CSS1Compat")) {
			return document.documentElement.clientWidth;
		}
		else if (document.compatMode && document.body) {
			return document.body.clientWidth;
		}
		return screen.zero(self.innerWidth);
	};
	
	// Get the height of the viewport (viewable area) in the browser window
	// --------------------------------------------------------------------
	screen.getViewportHeight = function() {
		if (!window.opera && document.documentElement && (!document.compatMode || document.compatMode=="CSS1Compat")) {
			return document.documentElement.clientHeight;
		}
		else if (document.compatMode && !window.opera && document.body) {
			return document.body.clientHeight;
		}
		return screen.zero(self.innerHeight);
	};

	return screen;
})();var Sort = (function(){
	var sort = {};
	sort.AlphaNumeric = function(a,b) {
		if (a==b) { return 0; }
		if (a<b) { return -1; }
		return 1;
	};

	sort.Default = sort.AlphaNumeric;
	
	sort.NumericConversion = function(val) {
		if (typeof(val)!="number") {
			if (typeof(val)=="string") {
				val = parseFloat(val.replace(/,/g,''));
				if (isNaN(val) || val==null) { val=0; }
			}
			else {
				val = 0;
			}
		}
		return val;
	};
	
	sort.Numeric = function(a,b) {
		return sort.NumericConversion(a)-sort.NumericConversion(b);
	};

	sort.IgnoreCaseConversion = function(val) {
		if (val==null) { val=""; }
		return (""+val).toLowerCase();
	};

	sort.IgnoreCase = function(a,b) {
		return sort.AlphaNumeric(sort.IgnoreCaseConversion(a),sort.IgnoreCaseConversion(b));
	};

	sort.CurrencyConversion = function(val) {
		if (typeof(val)=="string") {
			val = val.replace(/^[^\d\.]/,'');
		}
		return sort.NumericConversion(val);
	};
	
	sort.Currency = function(a,b) {
		return sort.Numeric(sort.CurrencyConversion(a),sort.CurrencyConversion(b));
	};
	
	sort.DateConversion = function(val) {
		// inner util function to parse date formats
		function getdate(str) {
			// inner util function to convert 2-digit years to 4
			function fixYear(yr) {
				yr = +yr;
				if (yr<50) { yr += 2000; }
				else if (yr<100) { yr += 1900; }
				return yr;
			};
			var ret;
			// YYYY-MM-DD
			if (ret=str.match(/(\d{2,4})-(\d{1,2})-(\d{1,2})/)) {
				return (fixYear(ret[1])*10000) + (ret[2]*100) + (+ret[3]);
			}
			// MM/DD/YY[YY] or MM-DD-YY[YY]
			if (ret=str.match(/(\d{1,2})[\/-](\d{1,2})[\/-](\d{2,4})/)) {
				return (fixYear(ret[3])*10000) + (ret[1]*100) + (+ret[2]);
			}
			return 99999999; // So non-parsed dates will be last, not first
		};
		return getdate(val);
	};

	sort.Date = function(a,b) {
		return sort.Numeric(sort.DateConversion(a),sort.DateConversion(b));
	};

	return sort;
})();

var Position = (function() {
	// Resolve a string identifier to an object
	// ========================================
	function resolveObject(s) {
		if (document.getElementById && document.getElementById(s)!=null) {
			return document.getElementById(s);
		}
		else if (document.all && document.all[s]!=null) {
			return document.all[s];
		}
		else if (document.anchors && document.anchors.length && document.anchors.length>0 && document.anchors[0].x) {
			for (var i=0; i<document.anchors.length; i++) {
				if (document.anchors[i].name==s) { 
					return document.anchors[i]
				}
			}
		}
	}
	
	var pos = {};
	pos.$VERSION = 1.0;
	
	// Set the position of an object
	// =============================
	pos.set = function(o,left,top) {
		if (typeof(o)=="string") {
			o = resolveObject(o);
		}
		if (o==null || !o.style) {
			return false;
		}
		
		// If the second parameter is an object, it is assumed to be the result of getPosition()
		if (typeof(left)=="object") {
			var pos = left;
			left = pos.left;
			top = pos.top;
		}
		
		o.style.left = left + "px";
		o.style.top = top + "px";
		return true;
	};
	
	// Retrieve the position and size of an object
	// ===========================================
	pos.get = function(o) {
		var fixBrowserQuirks = true;
			// If a string is passed in instead of an object ref, resolve it
		if (typeof(o)=="string") {
			o = resolveObject(o);
		}
		
		if (o==null) {
			return null;
		}
		
		var left = 0;
		var top = 0;
		var width = 0;
		var height = 0;
		var parentNode = null;
		var offsetParent = null;
	
		
		offsetParent = o.offsetParent;
		var originalObject = o;
		var el = o; // "el" will be nodes as we walk up, "o" will be saved for offsetParent references
		while (el.parentNode!=null) {
			el = el.parentNode;
			if (el.offsetParent==null) {
			}
			else {
				var considerScroll = true;
				/*
				In Opera, if parentNode of the first object is scrollable, then offsetLeft/offsetTop already 
				take its scroll position into account. If elements further up the chain are scrollable, their 
				scroll offsets still need to be added in. And for some reason, TR nodes have a scrolltop value
				which must be ignored.
				*/
				if (fixBrowserQuirks && window.opera) {
					if (el==originalObject.parentNode || el.nodeName=="TR") {
						considerScroll = false;
					}
				}
				if (considerScroll) {
					if (el.scrollTop && el.scrollTop>0) {
						top -= el.scrollTop;
					}
					if (el.scrollLeft && el.scrollLeft>0) {
						left -= el.scrollLeft;
					}
				}
			}
			// If this node is also the offsetParent, add on the offsets and reset to the new offsetParent
			if (el == offsetParent) {
				left += o.offsetLeft;
				if (el.clientLeft && el.nodeName!="TABLE") { 
					left += el.clientLeft;
				}
				top += o.offsetTop;
				if (el.clientTop && el.nodeName!="TABLE") {
					top += el.clientTop;
				}
				o = el;
				if (o.offsetParent==null) {
					if (o.offsetLeft) {
						left += o.offsetLeft;
					}
					if (o.offsetTop) {
						top += o.offsetTop;
					}
				}
				offsetParent = o.offsetParent;
			}
		}
		
	
		if (originalObject.offsetWidth) {
			width = originalObject.offsetWidth;
		}
		if (originalObject.offsetHeight) {
			height = originalObject.offsetHeight;
		}
		
		return {'left':left, 'top':top, 'width':width, 'height':height
				};
	};
	
	// Retrieve the position of an object's center point
	// =================================================
	pos.getCenter = function(o) {
		var c = this.get(o);
		if (c==null) { return null; }
		c.left = c.left + (c.width/2);
		c.top = c.top + (c.height/2);
		return c;
	};
	
	return pos;
})();// CLASS CONSTRUCTOR
// --------------------------------------------------------------------
var Popup = function(div, options) {
	this.div = defined(div)?div:null;
	this.index = Popup.maxIndex++;
	this.ref = "Popup.objects["+this.index+"]";
	Popup.objects[this.index] = this;
	// Store a reference to the DIV by id, also
	if (typeof(this.div)=="string") {
		Popup.objectsById[this.div] = this;
	}
	if (defined(this.div) && this.div!=null && defined(this.div.id)) {
		Popup.objectsById[this.div.id] = this.div.id;
	}
	// Apply passed-in options
	if (defined(options) && options!=null && typeof(options)=="object") {
		for (var i in options) {
			this[i] = options[i];
		}
	}
	return this;
};

// CLASS PROPERTIES
// --------------------------------------------------------------------
// Index of popup objects, to maintain a global reference if necessary
Popup.maxIndex = 0;
Popup.objects = {};
Popup.objectsById = {};

// The z-index value that popups will start at
Popup.minZIndex = 101;

// Class names to assign to other objects
Popup.screenClass = "PopupScreen";
Popup.iframeClass = "PopupIframe";
Popup.screenIframeClass = "PopupScreenIframe";

// CLASS METHODS
// --------------------------------------------------------------------

// Hide all currently-visible non-modal dialogs
Popup.hideAll = function() {
	for (var i in Popup.objects) {
		var p = Popup.objects[i];
		if (!p.modal && p.autoHide) {
			p.hide();
		}
	}
};
// Catch global events as a trigger to hide auto-hide popups
Event.add(document, "mouseup", Popup.hideAll, false);

// A simple class method to show a popup without creating an instance
Popup.show = function(divObject, referenceObject, position, options, modal) {
	var popup;
	if (defined(divObject)) { 
		popup = new Popup(divObject);
	}
	else {
		popup = new Popup();
		popup.destroyDivOnHide = true;
	}
	if (defined(referenceObject)) { popup.reference = DOM.resolve(referenceObject); }
	if (defined(position)) { popup.position = position; }
	if (defined(options) && options!=null && typeof(options)=="object") {
		for (var i in options) {
			popup[i] = options[i];
		}
	}
	if (typeof(modal)=="boolean") {
		popup.modal = modal;
	}
	popup.destroyObjectsOnHide = true;
	popup.show();
	return popup;
};

// A simple class method to show a modal popup
Popup.showModal = function(divObject, referenceObject, position, options) {
	Popup.show(divObject, referenceObject, position, options, true);
};

// A method to retrieve a popup object based on a div ID
Popup.get = function(divId) {
	if (defined(Popup.objectsById[divId])) {
		return Popup.objectsById[divId];
	}
	return null;
};

// A method to hide a popup based on a div id
Popup.hide = function(divId) {
	var popup = Popup.get(divId);
	if (popup!=null) {
		popup.hide();
	}
};

// PROTOTYPE PROPERTIES
// --------------------------------------------------------------------
Popup.prototype.content = null;
Popup.prototype.className = "PopupDiv";
Popup.prototype.style = null; // Styles to be applied to the DIV
Popup.prototype.width = null;
Popup.prototype.height = null;
Popup.prototype.top = null;
Popup.prototype.left = null;
Popup.prototype.offsetLeft = 0;
Popup.prototype.offsetTop = 0;
Popup.prototype.constrainToScreen = true;
Popup.prototype.autoHide = true;
Popup.prototype.useIframeShim = false; /*@cc_on @*/ /*@if (@_win32) {Popup.prototype.useIframeShim = true;} @end @*/ 
Popup.prototype.iframe = null;
Popup.prototype.position = null; // vertical: "above top center bottom below", horizontal: "adjacent-left,left,center,right,adjacent-right"
Popup.prototype.reference = null;
Popup.prototype.modal = false;
Popup.prototype.destroyDivOnHide = false;
Popup.prototype.destroyObjectsOnHide = false;
Popup.prototype.screen = null;
Popup.prototype.screenIframeShim = null;
Popup.prototype.screenOpacity=.4;
Popup.prototype.screenColor="#cccccc";

// INSTANCE METHODS
// --------------------------------------------------------------------

// Show the popup
// --------------------------------------------------------------------
Popup.prototype.show = function(options, modal) {
	this.modal = this.modal || (typeof(modal)=="boolean" && modal);
	if (defined(options) && options!=null && typeof(options)=="object") {
		for (var i in options) {
			this[i] = options[i];
		}
	}
	this.div = DOM.resolve(this.div);
	CSS.setStyle(this.div,'position','absolute');
	
	// If there is no div pre-defined to use, create one
	if (this.div==null) {
		this.div = this.createDiv();
	}
	if (this.content!=null) {
		this.div.innerHTML = this.content;
		this.content = null;
	}
	if (this.className!=null) {
		this.div.className = this.className;
	}
	if (this.style!=null) {
		this.applyStyle();
	}
	if (this.width!=null) {
		this.div.style.width = this.width+"px";
		this.div.style.overflowX="auto";
	}
	if (this.height!=null) {
		this.div.style.height = this.height+"px";
		this.div.style.overflowY="auto";
	}

	// Do the actual display - this is a separate method so display transitions can be implemented
	this.transition();
	
	// Make sure clicks on the DIV don't bubble up to the document
	this.div.onclick = function(e) { 
		Event.cancelBubble(Event.resolve(e));
	};
	this.div.onmouseup = this.div.onclick;
	
	// Focus to the DIV if possible	
	if (this.modal && this.div.focus) {
		this.div.focus();
	}
};

// Show the popup but make it modal
// --------------------------------------------------------------------
Popup.prototype.transition = function() {
	if (this.modal) {
		this.addScreen();
	}
	
	// Make the DIV displayed but hidden so its size can be measured
	CSS.setStyle(this.div,'visibility','hidden');
	CSS.setStyle(this.div,'display','block');

	// Position the popup
	this.setPosition();

	// Add the shim if necessary	
	if (this.useIframeShim) {
		this.addIframeShim();
	}

	// Make sure the DIV is higher than the shim
	this.div.style.zIndex = Popup.minZIndex++;

	CSS.setStyle(this.div,'display','block');
	CSS.setStyle(this.div,'visibility','visible');
};

// Show the popup but make it modal
// --------------------------------------------------------------------
Popup.prototype.showModal = function(options) {
	this.show(options,true);
};

// Apply user styles to the DIV
// --------------------------------------------------------------------
Popup.prototype.applyStyle = function() {
	if (this.div!=null && this.style!=null && typeof(this.style)=="object") {
		for (var i in this.style) {
			this.div.style[i] = this.style[i];
		}
	}
};

// Hide the popup
// --------------------------------------------------------------------
Popup.prototype.hide = function() {
	// If this was a temp object creating on-the-fly, then remove objects from the DOM so
	// The document doesn't get littered with extra objects
	if (this.destroyDivOnHide) {
		DOM.removeNode(this.div);
		this.div = null;
		delete Popup.objects[this.id];
	}
	else if (this.div!=null) {
		CSS.setStyle(this.div,'display','none');
	}

	if (this.destroyObjectsOnHide) {
		DOM.removeNode(this.iframe);
		DOM.removeNode(this.screen);
		DOM.removeNode(this.screenIframeShim);
	}
	else {
		if (this.iframe!=null) {
			this.iframe.style.display = "none";
		}
		if (this.screen!=null) {
			this.screen.style.display = "none";
		}
		if (this.screenIframeShim!=null) {
			this.screenIframeShim.style.display = "none";
		}
	}
};

// Util funcs for position
// --------------------------------------------------------------------
Popup.prototype.setTop = function(top) {
	this.div.style.top = top+"px";
};
Popup.prototype.setLeft = function(left) {
	this.div.style.left = left+"px";
};
Popup.prototype.getTop = function() {
	return parseInt(CSS.getStyle(this.div,"top"),10);
};
Popup.prototype.getLeft = function() {
	return parseInt(CSS.getStyle(this.div,"left"),10);
};

// All the logic to position the popup based on various criteria
// --------------------------------------------------------------------
Popup.prototype.setPosition = function() {
	if (this.position!=null) {
		var m = this.position.match(/^(\S+)\s+(\S+)/); 
		if (m!=null && m.length==3) {
			var v = m[1];
			var h = m[2];

			var ref = this.reference;
			if (ref==null) { ref = Screen.getBody(); }
			var p = Position.get(ref);
			var refTop = p.top;
			var refLeft = p.left;
			var refWidth = DOM.getOuterWidth(ref);
			var refHeight = DOM.getOuterHeight(ref);
			
			var width = DOM.getOuterWidth(this.div);
			var height = DOM.getOuterHeight(this.div);
			
			var scrollLeft = Screen.getScrollLeft();
			var scrollTop = Screen.getScrollTop();

			// Set vertical position relative to reference object
			if (v=="above") { this.setTop(refTop-height+this.offsetTop); }
			else if (v=="top") { this.setTop(refTop+this.offsetTop); }
			else if (v=="center") { this.setTop(refTop+(refHeight/2)-(height/2)+this.offsetTop); }
			else if (v=="bottom") { this.setTop(refTop+refHeight-height+this.offsetTop); }
			else if (v=="below") { this.setTop(refTop+refHeight+this.offsetTop); }

			// Set horizontal position relative to reference object
			if (h=="adjacent-left") { this.setLeft(refLeft-width+this.offsetLeft); }
			else if (h=="left") { this.setLeft(refLeft+this.offsetLeft); }
			else if (h=="center") { this.setLeft(refLeft+(refWidth/2)-(width/2)+this.offsetLeft); }
			else if (h=="right") { this.setLeft(refLeft+refWidth-width+this.offsetLeft); }
			else if (h=="adjacent-right") { this.setLeft(refLeft+refWidth+this.offsetLeft); }
		}
	}
	else if (this.top==null && this.left==null) {
		this.center();
	}
	else {
		if (this.top==null) { this.top=0; }
		if (this.left==null) { this.left=0; }
		this.div.style.top = this.top+this.offsetTop+"px";
		this.div.style.left = this.left+this.offsetLeft+"px";
	}

	// Re-position to make sure it stays on the screen
	if (this.constrainToScreen) {
		this.fitToScreen();
	}
};

// Append an object to the body
// --------------------------------------------------------------------
Popup.prototype.appendToBody = function(o) {
	var body = Screen.getBody();
	if (body && body.appendChild) {
		body.appendChild(o);
	}
};

// Create a new DIV object to be used for a popup
// --------------------------------------------------------------------
Popup.prototype.createDiv = function() {
	if (document.createElement) {
		var d = document.createElement("DIV");
		d.style.position="absolute";
		d.style.display="block";
		d.style.visibility="hidden";
		this.appendToBody(d);
		return d;
	}
	alert("ERROR: Couldn't create DIV element in Popup.prototype.createDiv()");
	return null;
};

// Create a new IFRAME object to be used behind the popup
// --------------------------------------------------------------------
Popup.prototype.createIframe = function() {
	if (document.createElement) {
		var i= document.createElement("IFRAME");
		i.style.position="absolute";
		i.style.display="block";
		i.style.visibility="hidden";
		i.style.background="none";
		this.appendToBody(i);
		return i;
	}
	else {
		alert("ERROR: Couldn't create IFRAME object in Popup.prototype.createIframe()");
	}
};

// Add an IFRAME shim for the DIV
// --------------------------------------------------------------------
Popup.prototype.addIframeShim = function() {
	if (this.iframe==null) {
		this.iframe = this.createIframe();
	}
	this.iframe.className = Popup.iframeClass;
	CSS.setStyle(this.iframe,'top',this.getTop()+"px");
	CSS.setStyle(this.iframe,'left',this.getLeft()+"px");
	CSS.setStyle(this.iframe,'width',DOM.getOuterWidth(this.div) + "px");
	CSS.setStyle(this.iframe,'height',DOM.getOuterHeight(this.div) + "px");
	CSS.setStyle(this.iframe,'zIndex',Popup.minZIndex++);
	CSS.setStyle(this.iframe,'opacity',0);
	CSS.setStyle(this.iframe,'visibility','visible');
	CSS.setStyle(this.iframe,'display','block');
};

// Create a "screen" to make a popup modal
// --------------------------------------------------------------------
Popup.prototype.addScreen = function() {
	if (this.screen==null) {
		this.screen = this.createDiv();
		this.screen.style.top="0px";
		this.screen.style.left="0px";
		this.screen.style.backgroundColor = this.screenColor;
		this.screen.className=Popup.screenClass;;
		CSS.setStyle(this.screen,"opacity",this.screenOpacity);
		this.screen.onclick = function(e) { Event.cancelBubble(Event.resolve(e)); }
	}
	if (this.screenIframeShim==null) {
		this.screenIframeShim = this.createIframe();
		this.screenIframeShim.style.top="0px";
		this.screenIframeShim.style.left="0px";
		this.screenIframeShim.className=Popup.screenIframeClass;
		CSS.setStyle(this.screenIframeShim,"opacity",0);
	}
	this.screen.style.width = Screen.getDocumentWidth()+"px";
	this.screen.style.height = Screen.getDocumentHeight()+"px";
	this.screenIframeShim.style.width = Screen.getDocumentWidth()+"px";
	this.screenIframeShim.style.height = Screen.getDocumentHeight()+"px";
	this.screenIframeShim.style.zIndex = Popup.minZIndex++;
	this.screenIframeShim.style.visibility="visible";
	this.screenIframeShim.style.display="block";
	this.screen.style.zIndex = Popup.minZIndex++;
	this.screen.style.visibility="visible";
	this.screen.style.display="block";
};

// Re-position the DIV so it stays on the screen
// --------------------------------------------------------------------
Popup.prototype.fitToScreen = function() {
	var width = DOM.getOuterWidth(this.div);
	var height = DOM.getOuterHeight(this.div);
	var top = this.getTop();
	var left = this.getLeft();
	
	var clientWidth = Screen.getViewportWidth();
	var clientHeight = Screen.getViewportHeight();
	
	var scrollLeft = Screen.getScrollLeft();
	var scrollTop = Screen.getScrollTop();

	if (top-scrollTop+height>clientHeight) {
		top = top - ((top+height) - (scrollTop+clientHeight));
		this.div.style.top = top + "px";
	}
	if (left-scrollLeft+width>clientWidth) {
		left = left - ((left+width) - (scrollLeft+clientWidth));
		this.div.style.left = left + "px";
	}
	if (top<scrollTop) {
		this.div.style.top=scrollTop+"px";
	}
	if (left<scrollLeft) {
		this.div.style.left=scrollLeft+"px";
	}
};

// Center the DIV object
// --------------------------------------------------------------------
Popup.prototype.center = function() {
	var left = DOM.getOuterWidth(this.div);
	var top = DOM.getOuterHeight(this.div);
	if (isNaN(left)) { left=0; }
	if (isNaN(top)) { top=0; }	
	var clientW = Screen.getViewportWidth();
	var clientH = Screen.getViewportHeight();
	if (clientW!=null && clientH!=null) {
		top = (clientH-top)/2;
		left = (clientW-left)/2;
	}
	top += Screen.getScrollTop();
	left += Screen.getScrollLeft();
	
	this.div.style.top = top+this.offsetTop+"px";
	this.div.style.left = left+this.offsetLeft+"px";
};

