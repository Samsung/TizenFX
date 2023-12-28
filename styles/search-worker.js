(function () {
  importScripts('lunr.min.js');

  var lunrIndex;
  var stopWords = null;
  var searchData = {};
  var indexData = {};

  lunr.tokenizer.separator = /[\s\-\.\(\)]+/;

  var stopWordsRequest = new XMLHttpRequest();
  stopWordsRequest.open('GET', '../search-stopwords.json');
  stopWordsRequest.onload = function () {
    if (this.status != 200) {
      return;
    }
    stopWords = JSON.parse(this.responseText);
    loadIndex();
  }
  stopWordsRequest.send();

  var searchDataRequest = new XMLHttpRequest();
  searchDataRequest.open('GET', '../index.json');
  searchDataRequest.onload = function () {
    if (this.status != 200) {
      return;
    }
    searchData = JSON.parse(this.responseText);
    loadIndex();
  }
  searchDataRequest.send();

  var indexDataRequest = new XMLHttpRequest();
  indexDataRequest.open('GET', '../index-prebuilt.json');
  indexDataRequest.onload = function () {
    if (this.status != 200) {
      return;
    }
    indexData = JSON.parse(this.responseText);
    loadIndex();
    postMessage({ e: 'index-ready' });
  }
  indexDataRequest.send();

  onmessage = function (oEvent) {
    var q = oEvent.data.q;
    var hits = lunrIndex.search(q);
    var results = [];
    hits.forEach(function (hit) {
      var item = searchData[hit.ref];
      results.push({ 'href': item.href, 'title': item.title, 'keywords': item.keywords });
    });
    postMessage({ e: 'query-ready', q: q, d: results });
  }

  function loadIndex() {
    if (stopWords !== null && !isEmpty(searchData) && !isEmpty(indexData)) {
      var docfxStopWordFilter = lunr.generateStopWordFilter(stopWords);
      lunr.Pipeline.registerFunction(docfxStopWordFilter, 'docfxStopWordFilter');
      lunrIndex = lunr.Index.load(indexData);
    }
  }

  function isEmpty(obj) {
    if(!obj) return true;

    for (var prop in obj) {
      if (obj.hasOwnProperty(prop))
        return false;
    }

    return true;
  }

})();
