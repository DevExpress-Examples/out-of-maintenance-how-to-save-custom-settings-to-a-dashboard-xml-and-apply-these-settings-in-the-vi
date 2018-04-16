Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraCharts
Imports DevExpress.DashboardWin
Imports DevExpress.DashboardWin.Native

Namespace Dashboard_AddCustomSettings
    Partial Public Class Form1
        Inherits RibbonForm

        Private dashboardChanged As Boolean
        Public Sub New()
            InitializeComponent()
            dashboardDesigner1.LoadDashboard("..\..\Data\Dashboard.xml")
            ribbonControl1.SelectedPage = chartDesignRibbonPage1
            Dim chartControl As ChartControl = TryCast(DirectCast(dashboardDesigner1,  _
                    IUnderlyingControlProvider).GetUnderlyingControl("chartDashboardItem1"),  _
                ChartControl)
            barEditItem1.EditValue = chartControl.Legend.Font.Size
        End Sub

        Private Sub barEditItem1_EditValueChanged(ByVal sender As Object, _
                                                  ByVal e As EventArgs) _
                                              Handles barEditItem1.EditValueChanged
            Dim fontSize As Single = Convert.ToSingle(DirectCast(sender, BarEditItem).EditValue)
            Dim chartControl As ChartControl = TryCast(DirectCast(dashboardDesigner1,  _
                    IUnderlyingControlProvider).GetUnderlyingControl("chartDashboardItem1"),  _
                ChartControl)
            chartControl.Legend.Font = New Font(chartControl.Legend.Font.FontFamily, fontSize)
            dashboardChanged = True
        End Sub

        Private Sub dashboardDesigner1_DashboardClosing(ByVal sender As Object, _
                                                        ByVal e As DashboardClosingEventArgs) _
                                                    Handles dashboardDesigner1.DashboardClosing
            If dashboardChanged Then
                e.IsDashboardModified = True
                e.Dashboard.UserData =
                    New System.Xml.Linq.XElement("chartFontSize", barEditItem1.EditValue)
                SaveDashboards()
            End If
        End Sub

        Private Sub dashboardDesigner1_DashboardSaving(ByVal sender As Object, _
                                                       ByVal e As DashboardSavingEventArgs) _
                                                   Handles dashboardDesigner1.DashboardSaving
            If e.Command = DashboardSaveCommand.Save AndAlso dashboardChanged Then
                e.Dashboard.UserData =
                    New System.Xml.Linq.XElement("chartFontSize", barEditItem1.EditValue)
                SaveDashboards()
            End If
        End Sub

        Private Sub SaveDashboards()
            Dim path As String = Directory.GetParent(Application.ExecutablePath).Parent.Parent.Parent.FullName
            dashboardDesigner1.Dashboard.SaveToXml(path & "\Dashboard_LoadCustomSettings_Win\Data\Dashboard.xml")
            dashboardDesigner1.Dashboard.SaveToXml(path & "\Dashboard_LoadCustomSettings_Web\App_Data\Dashboard.xml")
            dashboardDesigner1.Dashboard.SaveToXml(path & "\Dashboard_LoadCustomSettings_Mvc\App_Data\Dashboard.xml")
            dashboardChanged = False
        End Sub
    End Class
End Namespace
