var PeopleManager = new Marionette.Application();

PeopleManager.addRegions({
  mainRegion: "#main-region"
});

PeopleManager.on("start", function () {
  PeopleManager.PeopleApp.List.Controller.listPeople();
});