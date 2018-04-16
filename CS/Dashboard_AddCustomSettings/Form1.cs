using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraCharts;
using DevExpress.DashboardWin;

namespace Dashboard_AddCustomSettings {
    public partial class Form1 : RibbonForm {
        bool dashboardChanged;
        ChartControl chartControl;

        public Form1() {
            InitializeComponent();
            dashboardDesigner1.DashboardItemControlCreated += 
                dashboardDesigner1_DashboardItemControlCreated;
            dashboardDesigner1.DashboardItemControlUpdated += 
                dashboardDesigner1_DashboardItemControlUpdated;
            dashboardDesigner1.DashboardItemBeforeControlDisposed += 
                dashboardDesigner1_DashboardItemBeforeControlDisposed;
            dashboardDesigner1.LoadDashboard(@"..\..\Data\Dashboard.xml");
            ribbonControl1.SelectedPage = chartDesignRibbonPage1;
        }

        void dashboardDesigner1_DashboardItemControlCreated(object sender, 
            DashboardItemControlEventArgs e) {
            if (e.DashboardItemName == "chartDashboardItem1") {
                chartControl = e.ChartControl;
            }
        }

        void dashboardDesigner1_DashboardItemControlUpdated(object sender, 
            DashboardItemControlEventArgs e) {
            if (e.DashboardItemName == "chartDashboardItem1") {
                ChartControl chartControl = e.ChartControl as ChartControl;
                barEditItem1.EditValue = chartControl.Legend.Font.Size;
            }
        }

        void dashboardDesigner1_DashboardItemBeforeControlDisposed(object sender, 
            DashboardItemControlEventArgs e) {
            if (e.DashboardItemName == "chartDashboardItem1") {
                chartControl = null;
            }
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e) {
            if (chartControl != null) {
                float fontSize = Convert.ToSingle(((BarEditItem)sender).EditValue);
                chartControl.Legend.Font = new Font(chartControl.Legend.Font.FontFamily, fontSize);
                dashboardChanged = true;
            }
        }

        private void dashboardDesigner1_DashboardClosing(object sender, DashboardClosingEventArgs e) {
            if (dashboardChanged) {
                e.IsDashboardModified = true;
                e.Dashboard.UserData =
                    new System.Xml.Linq.XElement("chartFontSize", barEditItem1.EditValue);
                SaveDashboards();
            }
        }

        private void dashboardDesigner1_DashboardSaving(object sender, DashboardSavingEventArgs e) {
            if (e.Command == DashboardSaveCommand.Save && dashboardChanged) {
                e.Dashboard.UserData =
                    new System.Xml.Linq.XElement("chartFontSize", barEditItem1.EditValue);
                SaveDashboards();
            }
        }

        private void SaveDashboards() {
            string path = Directory.GetParent(Application.ExecutablePath).Parent.Parent.Parent.FullName;
            dashboardDesigner1.Dashboard.SaveToXml(path +
                "\\Dashboard_LoadCustomSettings_Win\\Data\\Dashboard.xml");
            dashboardDesigner1.Dashboard.SaveToXml(path +
                "\\Dashboard_LoadCustomSettings_Web\\App_Data\\Dashboard.xml");
            dashboardDesigner1.Dashboard.SaveToXml(path +
                "\\Dashboard_LoadCustomSettings_Mvc\\App_Data\\Dashboard.xml");
            dashboardChanged = false;
        }
    }
}