Imports System
Imports System.Drawing
Imports DevExpress.XtraEditors
Imports DevExpress.DataAccess
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DashboardWin
Imports DevExpress.XtraCharts
Imports DevExpress.DataAccess.Sql

Namespace Dashboard_LoadCustomSettings_Win
    Partial Public Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
            dashboardViewer1.LoadDashboard("..\..\Data\Dashboard.xml")
        End Sub

        Private Sub dashboardViewer1_DashboardItemControlUpdated(ByVal sender As Object, _
                                                                 ByVal e As DashboardItemControlEventArgs) _
                                                             Handles dashboardViewer1.DashboardItemControlUpdated
            If e.DashboardItemName = "chartDashboardItem1" Then
                Dim chartControl As ChartControl = TryCast(e.ChartControl, ChartControl)
                Dim firstNode As String = dashboardViewer1.Dashboard.UserData.FirstNode.ToString()
                chartControl.Legend.Font = New Font(chartControl.Legend.Font.Name, Convert.ToSingle(firstNode))
            End If
        End Sub

        Private Sub dashboardViewer1_ConfigureDataConnection(ByVal sender As Object, _
                                                             ByVal e As ConfigureDataConnectionEventArgs) _
                                                         Handles dashboardViewer1.ConfigureDataConnection
            If e.ConnectionName = "nwindConnection" Then
                Dim parameters As Access97ConnectionParameters =
                    TryCast(e.ConnectionParameters, Access97ConnectionParameters)
                parameters.FileName = "..\..\Data\nwind.mdb"
            End If
        End Sub
    End Class
End Namespace
