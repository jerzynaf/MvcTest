PeopleManager.module("PeopleApp.Edit", function(Edit, PeopleManager, Backbone, Marionette, $, _) {
  Edit.PersonView = Marionette.ItemView.extend({
  template: "#person-form",
  events: {
    "click button.js-submit": "submitClicked"
  },

    submitClicked:function(e) {
      e.preventDefault();
      alert("edit contact");
    }

  });


  Edit.MissingPerson = Marionette.ItemView.extend({
  template:"#missing-person-view"
  });
});