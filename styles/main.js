$(function () {
  const apiVersions = {
    "API10": "version 10",
    "API9": "version 9",
    "API8": "version 8",
    "API7": "version 7",
    "API6": "version 6",
    "API5": "version 5",
    "API4": "version 4",
  };

  const apiVersion = $('meta[name="version"]').attr('content');

  const readyForDropdownVersionsApi = setInterval(function() {
    const $menu = $('#dropdownApiVersionMenu');
    if ($menu.length) {
      clearInterval(readyForDropdownVersionsApi);
      createDropdownVersionsMenuItems($menu);
      registerDropdownVersionsEvents($menu);
    }
  }, 10);

  function createDropdownVersionsMenuItems($menu) {
    Object.keys(apiVersions).sort().reverse().forEach(function(version) {
      const $item = $('<a class="dropdown-item" data-value="' + version + '">' + apiVersions[version] + '</a>');

      if (apiVersion === version) {
        $item.addClass('active');
      }

      $menu.append($item);
    });
    $('#dropdownApiVersionButton').html(apiVersions[apiVersion]);
  }

  function registerDropdownVersionsEvents($menu) {
    $menu.find('a').each(function () {
      $(this).on('click', function (e) {
        const $target = $(e.target);

        $menu.find('.active').removeClass('active');
        $target.addClass('active');

        const locationSplitted = window.location.href.split('/');
        locationSplitted[locationSplitted.length - 3] = $target.data('value');
        const newURL = locationSplitted.join('/');

        $('#dropdownApiVersionButton').html(apiVersions[$target.data('value')]);

        $.ajax({
          type: 'HEAD',
          url: newURL,
          complete: function(xhr) {
            if (xhr.status === 200) {
              window.location.href = newURL;
            } else {
              $('#_content').html('<div class="content-not-found"><img src="../../styles/404.svg" />Not found</div>');
              history.pushState({}, 'Document not found', newURL);
            }
          }
        });
      });
    });
  }

  var readyForAffix = setInterval(function() {
    var items = $('#affix ul .bs-docs-sidenav a');
    if (items.length > 0) {
      clearInterval(readyForAffix);
      var obsoleteIds = $.map($('h4.obsolete'), function(item) {
        return '#' + $(item).attr('id');
      });
      $.each(items, function(idx, item) {
        if (obsoleteIds.indexOf(item.hash) >= 0) {
          $(item).css("text-decoration", 'line-through')
        }
      });
    }
  }, 10);

  const readyForDropdownApi = setInterval(function() {
    const $menu = $('#dropdownApiMenu');
    if ($menu.length) {
      clearInterval(readyForDropdownApi);

      if (window.apiList) {
        createDropdownApiMenuItems($menu, window.apiList);
      }
      
    }
  }, 10);

  function createDropdownApiMenuItems($menu, apiList) {
    $menu.empty();
    apiList.forEach(function(api) {
      const $item = $('<a class="dropdown-item" href="' + api.dropdownUrl + '">' + api.dropdownName + '</a>');

      if (location.href.indexOf(api.rootUrl) !== -1) {
        $item.addClass('active');
        $('#dropdownApiButton').html(api.dropdownName);
      }

      $menu.append($item);
    });
  }

});
