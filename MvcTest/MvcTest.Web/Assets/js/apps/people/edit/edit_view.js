PeopleManager.module("PeopleApp.Edit", function(Edit, PeopleManager, Backbone, Marionette, $, _) {
  Edit.PersonView = Marionette.ItemView.extend({
  template: "#person-edit"
  });

  Edit.MissingPerson = Marionette.ItemView.extend({
  template:"#missing-person-view"
  });
});