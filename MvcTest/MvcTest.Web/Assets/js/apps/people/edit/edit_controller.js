PeopleManager.module("PeopleApp.Edit", function (Edit, PeopleManager, Backbone, Marionette, $, _) {
  Edit.Controller = {
    editPerson: function (id) {
      //var people = PeopleManager.request("person:entities");
      //var model = people.get(id);
      var fetchingPerson = PeopleManager.request("person:entity", id);

      $.when(fetchingPerson).done(function (person) {
        var personEditView;
        var coloursView;
        if (person !== undefined) {
          personEditView = new Edit.PersonView({
            model: person
          });

          personEditView.on("person:cancelEditing", function () {
            PeopleManager.trigger("people:list");
          });

          personEditView.on("form:submit", function (data) {
            person.save(data);
            PeopleManager.trigger("people:list");
          });

          var rawColours = person.get("colours");
          var colourCollection = PeopleManager.request("colour:entities", rawColours);
          //remove
          coloursView = new Edit.ColoursView({
            collection: colourCollection
          });

        } else {
          personEditView = new Edit.MissingPerson();
        }

        // PeopleManager.mainRegion.show(personEditView);
        PeopleManager.mainRegion.show(coloursView);
      });

    }
  }
});