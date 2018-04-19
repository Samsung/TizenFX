// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE file in the project root for full license information.

/**
 * This method will be called at the start of exports.transform in ManagedReference.html.primary.js
 */
exports.preTransform = function (model) {
  return model;
}

/**
 * This method will be called at the end of exports.transform in ManagedReference.html.primary.js
 */
exports.postTransform = function (model) {
  if (model.source)
    model._tizenFeedback = model._newIssueUrl + "?labels=docs&title=" + model.uid + " " + model.type + "&body=Source: " + model.source.path + " / [page](" + model._baseUrl + model._path + ")";
  else if (model.type === "namespace")
    model._tizenFeedback = model._newIssueUrl + "?labels=docs&title=" + model.uid + " " + model.type + "&body=On [page](" + model._baseUrl + model._path + ")";
  return model;
}
