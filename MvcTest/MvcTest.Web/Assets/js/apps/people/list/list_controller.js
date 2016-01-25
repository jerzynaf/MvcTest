PeopleManager.module("PeopleApp.List", function (List, PeopleManager, Backbone, Marionette, $, _) {
  List.Controller = {
    listPeople: function () {
      var fetchingPeople = PeopleManager.request("person:entities");

      $.when(fetchingPeople).done(function(people) {

        var peopleListView = new List.PeopleView({
          collection: people
        });

        peopleListView.on("childview:person:edit", function (childView, model) {
          //PeopleManager.navigate("people/edit/" + model.get("id"));
          //PeopleManager.PeopleApp.Edit.Controller.editPerson(model);
          PeopleManager.trigger("person:edit", model.get("id"));
        });



        PeopleManager.mainRegion.show(peopleListView);

      });



    }
  };
});