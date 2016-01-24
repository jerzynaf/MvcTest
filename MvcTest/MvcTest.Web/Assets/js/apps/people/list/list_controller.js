PeopleManager.module("PeopleApp.List", function (List, PeopleManager, Backbone, Marionette, $, _) {
  List.Controller = {
    listPeople: function () {
      var people = PeopleManager.request("person:entities");

      var peopleListView = new List.PeopleView({
        collection: people
      });

      peopleListView.on("childview:person:edit", function (childView, model) {
        PeopleManager.PeopleApp.Edit.Controller.editPerson(model);
      });

      PeopleManager.mainRegion.show(peopleListView);
    }
  };
});