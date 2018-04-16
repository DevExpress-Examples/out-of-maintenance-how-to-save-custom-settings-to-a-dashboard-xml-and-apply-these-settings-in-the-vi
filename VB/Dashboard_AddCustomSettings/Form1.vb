Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraCharts
Imports DevExpress.DashboardWin

Namespace Dashboard_AddCustomSettings
    Partial Public Class Form1
        Inherits RibbonForm

        Private dashboardChanged As Boolean
        Private chartControl As ChartControl

        Public Sub New()
            InitializeComponent()
            AddHandler dashboardDesigner1.DashboardItemControlCreated,
                AddressOf dashboardDesigner1_DashboardItemControlCreated
            AddHandler dashboardDesigner1.DashboardItemControlUpdated,
                AddressOf dashboardDesigner1_DashboardItemControlUpdated
            AddHandler dashboardDesigner1.DashboardItemBeforeControlDisposed,
                AddressOf dashboardDesigner1_DashboardItemBeforeControlDisposed
            dashboardDesigner1.LoadDashboard("..\..\Data\Dashboard.xml")
            ribbonControl1.SelectedPage = chartDesignRibbonPage1
        End Sub

        Private Sub dashboardDesigner1_DashboardItemControlCreated(ByVal sender As Object, _
                                       ByVal e As DashboardItemControlEventArgs)
            If e.DashboardItemName = "chartDashboardItem1" Then
                chartControl = e.ChartControl
            End If
        End Sub

        Private Sub dashboardDesigner1_DashboardItemControlUpdated(ByVal sender As Object, _
                                       ByVal e As DashboardItemControlEventArgs)
            If e.DashboardItemName = "chartDashboardItem1" Then
                Dim chartControl As ChartControl = TryCast(e.ChartControl, ChartControl)
                barEditItem1.EditValue = chartControl.Legend.Font.Size
            End If
        End Sub

        Private Sub dashboardDesigner1_DashboardItemBeforeControlDisposed(ByVal sender As Object, _
                                       ByVal e As DashboardItemControlEventArgs)
            If e.DashboardItemName = "chartDashboardItem1" Then
                chartControl = Nothing
            End If
        End Sub

        Private Sub barEditItem1_EditValueChanged(ByVal sender As Object, _
                                 ByVal e As EventArgs) Handles barEditItem1.EditValueChanged
            If chartControl IsNot Nothing Then
                Dim fontSize As Single = Convert.ToSingle(DirectCast(sender, BarEditItem).EditValue)
                chartControl.Legend.Font = New Font(chartControl.Legend.Font.FontFamily, fontSize)
                dashboardChanged = True
            End If
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
            Dim path As String =
                Directory.GetParent(Application.ExecutablePath).Parent.Parent.Parent.FullName
            dashboardDesigner1.Dashboard.SaveToXml(path & "\Dashboard_LoadCustomSettings_Win\Data\Dashboard.xml")
            dashboardDesigner1.Dashboard.SaveToXml(path & "\Dashboard_LoadCustomSettings_Web\App_Data\Dashboard.xml")
            dashboardDesigner1.Dashboard.SaveToXml(path & "\Dashboard_LoadCustomSettings_Mvc\App_Data\Dashboard.xml")
            dashboardChanged = False
        End Sub
    End Class
End Namespace