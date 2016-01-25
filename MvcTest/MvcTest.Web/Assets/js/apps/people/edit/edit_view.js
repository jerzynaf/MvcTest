PeopleManager.module("PeopleApp.Edit", function (Edit, PeopleManager, Backbone, Marionette, $, _) {
  Edit.PersonView = Marionette.ItemView.extend({
    template: "#person-form",
    events: {
      "click button.js-submit": "submitClicked",
      "click button.js-cancel": "cancelClicked"
    },

    onShow: function() {
      console.log("showing the person edit view");
    },

    submitClicked: function (e) {
      e.preventDefault();
      var data = Backbone.Syphon.serialize(this);
      this.trigger("form:submit", data);
    },

    cancelClicked: function (e) {
      e.preventDefault();
      this.trigger("person:cancelEditing", this.model);
    }
  });


  Edit.ColourView = Marionette.ItemView.extend({
    template: "#colour-template"
  });

  Edit.ColoursView = Marionette.CollectionView.extend({
    tagName: "div",
    childView: Edit.ColourView
  });

  Edit.MissingPerson = Marionette.ItemView.extend({
    template: "#missing-person-view"
  });
});