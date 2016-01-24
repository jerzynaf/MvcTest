PeopleManager.module("Entities", function(Entities, ContactManager, Backbone, Marionette, $, _) {
  Entities.Person = Backbone.Model.extend({
    defaults: {
      firstName: "",
      lastName: ""
    }
  });

  Entities.PeopleCollection = Backbone.Collection.extend({
    model: Entities.Person
  });

  var people;

  var initializePeople = function() {
    people = new PeopleManager.Entities.PeopleCollection(
                [
                    {
                      firstName: "Alice",
                      lastName: "Arten"
                    },
                    {
                      firstName: "James",
                      lastName: "Johnson"
                    }
                ]);

  };

  var API = {
    getPeopleEntities: function() {
      if (people === undefined) {
        initializePeople();
      }
      return people;
    }
  };

  PeopleManager.reqres.setHandler("person:entities", function() {
    return API.getPeopleEntities();
  });
});