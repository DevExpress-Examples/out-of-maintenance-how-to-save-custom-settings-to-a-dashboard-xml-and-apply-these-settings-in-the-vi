using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraCharts;
using DevExpress.DashboardWin;
using DevExpress.DashboardWin.Native;

namespace Dashboard_AddCustomSettings {
    public partial class Form1 : RibbonForm {
        bool dashboardChanged;
        public Form1() {
            InitializeComponent();
            dashboardDesigner1.LoadDashboard(@"..\..\Data\Dashboard.xml");
            ribbonControl1.SelectedPage = chartDesignRibbonPage1;
            ChartControl chartControl = ((IUnderlyingControlProvider)dashboardDesigner1).
                GetUnderlyingControl("chartDashboardItem1") as ChartControl;
            barEditItem1.EditValue = chartControl.Legend.Font.Size;
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e) {
            float fontSize = Convert.ToSingle(((BarEditItem)sender).EditValue);
            ChartControl chartControl = ((IUnderlyingControlProvider)dashboardDesigner1).
                GetUnderlyingControl("chartDashboardItem1") as ChartControl;
            chartControl.Legend.Font = new Font(chartControl.Legend.Font.FontFamily, fontSize);
            dashboardChanged = true;
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
