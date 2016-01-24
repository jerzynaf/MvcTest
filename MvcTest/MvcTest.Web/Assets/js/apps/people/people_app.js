PeopleManager.module("PeopleApp", function (PeopleApp, PeopleManager, Backbone, Marionette, $, _) {
  PeopleApp.Router = Marionette.AppRouter.extend({
    appRoutes: {
      "people": "listPeople"
    }
  });

  var API = {
    listPeople: function () {
      PeopleApp.List.Controller.listPeople();
    }
  };

  PeopleManager.addInitializer(function () {
    new PeopleApp.Router({
      controller: API
    });
  });
});