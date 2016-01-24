PeopleManager.module("PeopleApp.List", function(List, PeopleManager, Backbone, Marionette, $, _) {
  List.PersonView = Marionette.ItemView.extend({
    template: "#person-template",

    events: {
      "click a": "alertFirstName"
    },

    alertFirstName: function () {
      alert(this.model.escape("firstName"));
    },
    tagName: "tr"
  });

  List.PeopleView = Marionette.CollectionView.extend({
    tagName: "table",
    className:"table table-hover",
    childView: List.PersonView
});
});