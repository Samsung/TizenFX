// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE file in the project root for full license information.

/**
 * This method will be called at the start of exports.transform in conceptual.html.primary.js
 */
exports.preTransform = function (model) {
  return model;
}

/**
 * This method will be called at the end of exports.transform in conceptual.html.primary.js
 */
exports.postTransform = function (model) {
    model._tizenFeedback = model._newIssueUrl + "?labels=docs&title=Doc " + model.source.remote.path + "&body=On [page](" + model._baseUrl + model._path + ") ...";
  if(model.source && model.source.remote && model.source.remote.path.match(/^generator\//))
    model.docurl = model._docEditBaseUrl + model.source.remote.path;
  return model;
}
