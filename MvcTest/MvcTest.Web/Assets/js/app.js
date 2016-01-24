var PeopleManager = new Marionette.Application();

PeopleManager.addRegions({
  mainRegion: "#main-region"
});

PeopleManager.navigate = function (route, options) {
  options || (options = {});
  Backbone.history.navigate(route, options);
};

PeopleManager.getCurrentRoute = function () {
  return Backbone.history.fragment;
};

PeopleManager.on("start", function () {
  if (Backbone.history) {
    Backbone.history.start();
  }

  if (Backbone.history.fragment === "") {
    Backbone.history.navigate("people");
    PeopleManager.PeopleApp.List.Controller.listPeople();
  }
});