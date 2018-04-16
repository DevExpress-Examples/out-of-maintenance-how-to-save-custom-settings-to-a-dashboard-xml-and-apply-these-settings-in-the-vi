using System.Web.Mvc;
using DevExpress.DashboardWeb.Mvc;
using DevExpress.DataAccess.ConnectionParameters;

namespace Dashboard_LoadCustomSettings_Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult DashboardViewerPartial() {
            return PartialView("_DashboardViewerPartial", DashboardViewerSettings.Model);
        }
        public FileStreamResult DashboardViewerPartialExport() {
            return DashboardViewerExtension.Export("DashboardViewer", DashboardViewerSettings.Model);
        }
    }
    class DashboardViewerSettings {
        public static DashboardSourceModel Model {
            get {
                return DashboardSourceModel();
            }
        }

        private static DashboardSourceModel DashboardSourceModel() {
            DashboardSourceModel model = new DashboardSourceModel();
            model.DashboardSource = @"App_Data/Dashboard.xml";
            model.ConfigureDataConnection = (sender, e) => {
                if (e.ConnectionName == "nwindConnection") {
                    Access97ConnectionParameters parameters =
                        (Access97ConnectionParameters)e.ConnectionParameters;
                    string databasePath =
                        System.Web.HttpContext.Current.Server.MapPath(@"~\App_Data\nwind.mdb");
                    parameters.FileName = databasePath;
                }
            };
            return model;
        }
    }
}