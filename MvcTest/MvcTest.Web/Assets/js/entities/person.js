PeopleManager.module("Entities", function (Entities, ContactManager, Backbone, Marionette, $, _) {
  Entities.Person = Backbone.Model.extend({
    defaults: {
      id: 0,
      firstName: "",
      lastName: ""
    }
  });

  Entities.PeopleCollection = Backbone.Collection.extend({
    model: Entities.Person
  });

  var people;

  var initializePeople = function () {
    people = new PeopleManager.Entities.PeopleCollection(
                [
                    {
                      id: 1,
                      firstName: "Alice",
                      lastName: "Arten"
                    },
                    {
                      id: 2,
                      firstName: "James",
                      lastName: "Johnson"
                    }
                ]);

  };

  var API = {
    getPeopleEntities: function () {
      if (people === undefined) {
        initializePeople();
      }
      return people;
    }
  };

  PeopleManager.reqres.setHandler("person:entities", function () {
    return API.getPeopleEntities();
  });
});