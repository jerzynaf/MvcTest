PeopleManager.module("PeopleApp.Edit", function(Edit, PeopleManager, Backbone, Marionette, $, _) {
  Edit.Controller= {
    editPerson: function(model) {
      alert("editPerson called for model ", model);
    }
  }
});