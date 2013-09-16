
       msgs_actions = function () {

           var self = this;
           self.allMessages = ko.observableArray([]);
           self.seriesList = ko.observableArray([]);
           self.messagesList = ko.observableArray([]);
           self.seriestitle = ko.observable("");

           self.initialize = function () {
               //load the seriesList from data in the div.
               var series = eval($("#seriesList").html());
               if (series) {
                   //unique only into series list
                   self.allMessages(series);
                   self.seriesList(self.getUniqueSeries());
                   self.getSeriesForView(self.allMessages()[0]);
               }

               //load the most recent series details
           };

           self.getUniqueSeries = function () {
               var currentseries = "";
               var uniqueseries = [];
               for (var ii = 0; ii < self.allMessages().length; ii++) {
                   if (currentseries !== self.allMessages()[ii].Series) {
                       currentseries = self.allMessages()[ii].Series;
                       uniqueseries.push(self.allMessages()[ii]);
                   }
               }
               return uniqueseries;
           };

           self.getSeriesForView = function (seriesInfo) {
               var currentseries = seriesInfo.Series;
               var msgsInSeries = [];
               var bb = 0;
               for (var ii = 0; ii < self.allMessages().length; ii++) {
                   if (currentseries === self.allMessages()[ii].Series) {
                       if (bb == 0)
                           self.allMessages()[ii].messageClass = "activemessage";
                       else
                           self.allMessages()[ii].messageClass = "notactive";
                       bb = 1;
                       msgsInSeries.push(self.allMessages()[ii]);
                   }
               }

               self.seriestitle(seriesInfo.Series);
               self.messagesList(msgsInSeries);
           };

           self.setMP3PlayerUp = function (messageInfo) {
               var xaml = document.getElementById("slobj");
               xaml.Content.Player.Url = messageInfo.mp3File;
               xaml.Content.Player.Mp3Title = messageInfo.MessageTitle;
               xaml.Content.Player.Author = messageInfo.MessageAuthor;
               xaml.Content.Player.Play();
           };

           return {
               setMP3PlayerUp: self.setMP3PlayerUp,
               getSeriesForView: self.getSeriesForView,
               initialize: self.initialize,
               seriesList: self.seriesList,
               messagesList: self.messagesList,
               seriestitle: self.seriestitle
           }
       };


$("document").ready(function () {
    var messact = new msgs_actions();
    ko.applyBindings(messact, $("#mediacenter").get(0));
    messact.initialize();
});
