$(function () {
  var monikers = {
    "API9": "API Level 9 / Tizen vNext",
    "API8": "API Level 8 / Tizen 6.0",
    "API7": "API Level 7 / Tizen 5.5 M3",
    "API6": "API Level 6 / Tizen 5.5 M2",
    "API5": "API Level 5 / Tizen 5.0",
    "API4": "API Level 4 / Tizen 4.0",
  };

  var version = $('meta[name="version"]').attr('content');

  var readyForPicker = setInterval(function() {
    var picker = $('.moniker-picker-menu');
    if (picker.length) {
      clearInterval(readyForPicker);
      if (version == 'internals') {
        hideMonikerPicker();
      } else {
        registerMonikers(picker);
        registerMonikerChangedEvent(picker);
      }
    }
  }, 10);

  function hideMonikerPicker() {
    $('.moniker-picker').hide();
    $('.sidetoc').css("top", "140px");
  }

  function registerMonikers(obj) {
    var levels = Object.keys(monikers).sort().reverse();
    levels.forEach(function(k) {
      obj.append(new Option(monikers[k], k));
    });
    obj.val(version).prop('selected', true);
  }

  function registerMonikerChangedEvent(obj) {
    obj.change(function(event) {
      window.location.href = '../../' + event.target.value + '/api/';
    });
  }

  var readyForAffix = setInterval(function() {
    var items = $('#affix ul .bs-docs-sidenav a');
    if (items.length > 0) {
      clearInterval(readyForAffix);
      var obsoleteIds = $.map($('div .obsolete'), function(item) {
        return '#' + $(item).data('id');
      });
      $.each(items, function(idx, item) {
        if (obsoleteIds.indexOf(item.hash) >= 0) {
          $(item).css("text-decoration", 'line-through')
        }
      });
    }
  }, 10);

});
