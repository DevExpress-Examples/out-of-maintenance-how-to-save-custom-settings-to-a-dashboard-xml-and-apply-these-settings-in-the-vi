using System;
using System.Xml.Linq;
using DevExpress.Web;
using DevExpress.DashboardWeb;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;

namespace Dashboard_LoadCustomSettings_Web {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void DashboardViewer_CustomJSProperties(object sender, CustomJSPropertiesEventArgs e) {
            XElement element = Dashboard.LoadUserDataFromXml(Server.MapPath("App_Data/Dashboard.xml"));
            string chartFontSize = element.FirstNode.ToString();
            e.Properties["cpChartFontSize"] = Convert.ToSingle(chartFontSize);        
        }

        protected void ASPxDashboardViewer1_ConfigureDataConnection(object sender, 
            ConfigureDataConnectionWebEventArgs e) {
            if (e.ConnectionName == "nwindConnection") {
                Access97ConnectionParameters parameters =
                    e.ConnectionParameters as Access97ConnectionParameters; ;
                string databasePath = Server.MapPath("App_Data/nwind.mdb");
                parameters.FileName = databasePath;
            }
        }
    }
}