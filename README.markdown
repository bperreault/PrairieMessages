[Prairie CMS](https://github.com/bperreault/PrairieCMS/) - Prairie Software CMS
=================================================================
This project is a plugin that works with Prairie CMS to enable a content page which presents You Tube videos for viewing.

This project is written in C# and uses SQL Server for data storage. 

Plugins construction is described in PrairieCMS documentation.


script urls consist of Namespace.Class.Method/parameter
(plugin supported public entry)friendlyUrl = "PrairieMessages.MessagesController.getSeriesForView"
POSTED
        /// support dynamic links for ajax requests from scripts.
        /// first section is entryController name
        /// second section is dataController name
        /// third section is specific method requested
        /// anything posted are json encoded parameters to the specific method to be called.

ADMIN PAGES: CMS has a tab, Plugins.  Go to the Plugins tab, and select your plugin - PrairieCMS will call into the IModule interface for any admin functionality that may be present in the plugin dll.
