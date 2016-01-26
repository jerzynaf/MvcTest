$(document).ready(function () {

  $("#isAuthorisedLabel").click(function (event) {
    event.preventDefault();
    $("#isAuthorised").toggle();
  });

  $("#isEnabledLabel").click(function (event) {
    event.preventDefault();
    $("#isEnabled").toggle();
  });

});