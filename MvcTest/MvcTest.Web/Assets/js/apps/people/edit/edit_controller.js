PeopleManager.module("PeopleApp.Edit", function(Edit, PeopleManager, Backbone, Marionette, $, _) {
  Edit.Controller= {
    editPerson: function(model) {
      var personEditView = new Edit.PersonView({
      model:model
      });

      PeopleManager.mainRegion.show(personEditView);
    }
  }
});