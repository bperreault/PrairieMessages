

         msgs_admin = function () {

             var self = this;
             self.allMessages = ko.observableArray([]);
             self.selectedMessage = ko.observableArray([]);

             self.initialize = function () {
                 //load the seriesList from data in the div.
                 var series = eval($("#seriesList").html());
                 if (series) {
                     self.allMessages(series);
                 }
                 self.newMessage();
             };


             self.getMessageForEdit = function (messageInfo) {
                 var msgsInSeries = [];
                 for (var ii = 0; ii < self.allMessages().length; ii++) {
                     if (messageInfo.UID === self.allMessages()[ii].UID) {

                         msgsInSeries.push(self.allMessages()[ii]);
                         break;
                     }
                 }

                 self.selectedMessage(msgsInSeries);
             };

             self.saveContent = function () {
                 var url = "PrairieMessages.MessagesController.saveMessage";

                 $.ajax({
                     type: "POST",
                     url: url,
                     data: JSON.stringify({
                         message: self.selectedMessage()[0]
                     }),
                     contentType: 'application/json',
                     dataType: 'json',
                     success: function (data, status) {
                         var itm = eval(data);

                         if (itm.errorMessage) {
                             $("#notification").html(itm.errorMessage);
                         }
                         else {
                             self.replaceInMessagesList(itm);

                         }
                     }
                 });
             };

             self.replaceInMessagesList = function (data) {
                 var foundit = false;
                 for (var ii = 0; ii < self.allMessages().length; ii++) {
                     if (self.allMessages()[ii].UID === data.UID) {
                         foundit = true;
                         self.allMessages()[ii] = data;
                         break;
                     }
                 }
                 if (!foundit) {
                     var msgs = [];
                     msgs.push(data);
                     for (var ii = 0; ii < self.allMessages().length; ii++) {
                         msgs.push(self.allMessages()[ii]);
                     }
                     self.allMessages(msgs);
                 }
             };
             
             self.newMessage = function () {
                 var msgsInSeries = [];
                 var msg = {
                         'MessageTitle':''
                          , 'DateCreated': curdate
                          ,'MessageDescription':''
                          ,'MessageAuthor':''
                          ,'MessageHardCopy':''
                          ,'Series':''
                          ,'VideoFile':''
                          ,'mp3File':''
                          , 'UID': ''
                     };
                 msgsInSeries.push(msg);
                 self.selectedMessage(msgsInSeries);
             };

             return {
                 saveContent: self.saveContent,
                 getMessageForEdit: self.getMessageForEdit,
                 initialize: self.initialize,
                 allMessages: self.allMessages,
                 selectedMessage: self.selectedMessage,
                 newMessage: self.newMessage
             }
         };

$("document").ready(function () {
    var messact = new msgs_admin();
    ko.applyBindings(messact, $("#mediacenter").get(0));
    messact.initialize();
});
