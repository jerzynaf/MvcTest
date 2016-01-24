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

  if (this.getCurrentRoute() === "") {
    PeopleManager.trigger("people:list");
  }
});