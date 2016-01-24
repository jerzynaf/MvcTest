var PeopleManager = new Marionette.Application();

PeopleManager.addRegions({
  mainRegion: "#main-region"
});

PeopleManager.on("start", function () {
  if (Backbone.history) {
    Backbone.history.start();
  }
  //PeopleManager.PeopleApp.List.Controller.listPeople();
});