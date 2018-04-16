using System;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.DataAccess;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DashboardWin;
using DevExpress.XtraCharts;
using DevExpress.DataAccess.Sql;

namespace Dashboard_LoadCustomSettings_Win {
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();
            dashboardViewer1.LoadDashboard(@"..\..\Data\Dashboard.xml");
        }

        private void dashboardViewer1_DashboardItemControlUpdated(object sender, 
            DashboardItemControlEventArgs e) {
            if (e.DashboardItemName == "chartDashboardItem1") {
                ChartControl chartControl = e.ChartControl as ChartControl;
                string firstNode = dashboardViewer1.Dashboard.UserData.FirstNode.ToString();
                chartControl.Legend.Font = 
                    new Font(chartControl.Legend.Font.Name, Convert.ToSingle(firstNode));
            }
        }

        private void dashboardViewer1_ConfigureDataConnection(object sender, 
            ConfigureDataConnectionEventArgs e) {
            if (e.ConnectionName == "nwindConnection") {
                Access97ConnectionParameters parameters =
                    e.ConnectionParameters as Access97ConnectionParameters;
                parameters.FileName = @"..\..\Data\nwind.mdb";
            }
        }
    }
}
