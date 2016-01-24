PeopleManager.module("PeopleApp.List", function(List, PeopleManager, Backbone, Marionette, $, _) {
  List.Controller = {
    listPeople: function() {
      var people = PeopleManager.request("person:entities");

      var peopleListView = new List.PeopleView({
        collection: people
      });

      PeopleManager.mainRegion.show(peopleListView);
    }
  };
});