<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128581337/15.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T218543)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Dashboard_AddCustomSettings/Form1.cs) (VB: [Form1.vb](./VB/Dashboard_AddCustomSettings/Form1.vb))
* [HomeController.cs](./CS/Dashboard_LoadCustomSettings_Mvc/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Dashboard_LoadCustomSettings_Mvc/Controllers/HomeController.vb))
* [WidgetsCustomization.js](./CS/Dashboard_LoadCustomSettings_Mvc/Scripts/WidgetsCustomization.js) (VB: [WidgetsCustomization.js](./VB/Dashboard_LoadCustomSettings_Mvc/Scripts/WidgetsCustomization.js))
* [WebForm1.aspx](./CS/Dashboard_LoadCustomSettings_Web/WebForm1.aspx) (VB: [WebForm1.aspx](./VB/Dashboard_LoadCustomSettings_Web/WebForm1.aspx))
* [WebForm1.aspx.cs](./CS/Dashboard_LoadCustomSettings_Web/WebForm1.aspx.cs) (VB: [WebForm1.aspx.vb](./VB/Dashboard_LoadCustomSettings_Web/WebForm1.aspx.vb))
* [Form1.cs](./CS/Dashboard_LoadCustomSettings_Win/Form1.cs) (VB: [Form1.vb](./VB/Dashboard_LoadCustomSettings_Win/Form1.vb))
<!-- default file list end -->
# How to save custom settings to a dashboard XML and apply these settings in the Viewer


<p>The following example shows how to save custom settings to a dashboard XML definition in the <a href="http://documentation.devexpress.com/#Dashboard/CustomDocument12142">Dashboard Designer</a> and apply these settings in the <a href="http://documentation.devexpress.com/#Dashboard/CustomDocument15347">Dashboard Viewer</a>.</p>
<p>This example contains four projects - the Dashboard Designer and three types of the Dashboard Viewer: <a href="http://documentation.devexpress.com/#Dashboard/CustomDocument15348">WinForms</a>, <a href="http://documentation.devexpress.com/#Dashboard/CustomDocument15364">Web</a> and <a href="http://documentation.devexpress.com/#Dashboard/CustomDocument17001">MVC</a>. In the Designer, you can change the font size of chart legend items. The <strong>DashboardItemControlUpdated</strong> event is used to access the underlying <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument8117">Chart</a> control in the Dashboard Designer and change the font size of legend items. The <a href="http://documentation.devexpress.com/#Dashboard/DevExpressDashboardCommonDashboard_UserDatatopic">Dashboard.UserData</a> property provides the capability to save this value to the <a href="http://documentation.devexpress.com/#Dashboard/CustomDocument15405">dashboard XML definition</a>. Finally, dashboard definitions included in Dashboard Viewer projects are updated using the <a href="http://documentation.devexpress.com/#Dashboard/DevExpressDashboardCommonDashboard_SaveToXmltopic">Dashboard.SaveToXml</a> method.</p>
<p>In Dashboard Viewer projects, special members are used to access underlying controls and apply the custom font size:</p>
<p>- In the WinForms DashboardViewer, the <a href="http://documentation.devexpress.com/#Dashboard/DevExpressDashboardWinDashboardViewer_DashboardItemControlUpdatedtopic">DashboardItemControlUpdated</a> event is used to access the underlying chart control.</p>
<p>- In the Web/MVC Viewer, the <a href="http://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebScriptsASPxClientDashboardViewer_ItemWidgetCreatedtopic">ItemWidgetCreated</a> event is used to access the underlying dxChart widget. The <strong>CustomJSProperties</strong> event is handled to send custom data from the server to the client.<br /><br />Note that changing specific control/widget settings may lead to various issues. To learn more, see the following topics:<br />- <a href="http://documentation.devexpress.com/#Dashboard/CustomDocument18019">Access to Underlying Controls</a><br />- <a href="http://documentation.devexpress.com/#Dashboard/CustomDocument18020">Access to Underlying Widgets</a></p>

<br/>


