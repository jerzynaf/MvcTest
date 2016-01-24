PeopleManager.module("PeopleApp.Edit", function (Edit, PeopleManager, Backbone, Marionette, $, _) {
  Edit.Controller = {
    editPerson: function (id) {
      var people = PeopleManager.request("person:entities");
      var model = people.get(id);
      var personEditView;

      if (model !== undefined) {
        personEditView = new Edit.PersonView({
          model: model
        });
      } else {
        personEditView = new Edit.MissingPerson();
      }

      PeopleManager.mainRegion.show(personEditView);
    }
  }
});