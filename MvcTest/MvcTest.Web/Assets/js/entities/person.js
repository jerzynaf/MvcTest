﻿PeopleManager.module("Entities", function (Entities, ContactManager, Backbone, Marionette, $, _) {
  Entities.Person = Backbone.Model.extend({
    urlRoot: "http://localhost:1288/api/PeopleApi",
    defaults: {
      firstName: "a",
      lastName: "a"
    }
  });

  Entities.PeopleCollection = Backbone.Collection.extend({
    url: "http://localhost:1288/api/PeopleApi",
    model: Entities.Person
  });


  //var initializePeople = function () {
  //  var people = new PeopleManager.Entities.PeopleCollection(
  //              [
  //                  {
  //                    id: 1,
  //                    firstName: "Alice",
  //                    lastName: "Arten"
  //                  },
  //                  {
  //                    id: 2,
  //                    firstName: "James",
  //                    lastName: "Johnson"
  //                  }
  //              ]);
  //  contacts.forEach(function(contact) {
  //    contact.save();
  //  });
  //  return people.models;



  var API = {
    getPeopleEntities: function () {
      var people = new Entities.PeopleCollection();
      var defer = $.Deferred();
      people.fetch({
        success: function (data) {
          defer.resolve(data);
        }
      });
      var promise = defer.promise();
      $.when(promise).done(function (people) {
        if (people.length === 0) {
          alert("The people collection is empty");
        }
      });
      return promise;
    },

    getPersonEntity: function (personId) {
      var person = new Entities.Person({ id: personId });
      var defer = $.Deferred();
      //setTimeout(function () {
      person.fetch({
        success: function (data) {
          defer.resolve(data);
        },
        error: function (data) {
          defer.resolve(undefined);
        }
      });
      //}, 2000);

      return defer.promise();
    }

  };

  PeopleManager.reqres.setHandler("person:entities", function () {
    return API.getPeopleEntities();
  });

  PeopleManager.reqres.setHandler("person:entity", function (id) {
    return API.getPersonEntity(id);
  });
});