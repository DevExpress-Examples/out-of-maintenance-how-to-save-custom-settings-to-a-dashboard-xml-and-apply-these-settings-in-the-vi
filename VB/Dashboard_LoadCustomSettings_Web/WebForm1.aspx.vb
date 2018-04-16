Imports System
Imports System.Xml.Linq
Imports DevExpress.Web
Imports DevExpress.DashboardWeb
Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.ConnectionParameters

Namespace Dashboard_LoadCustomSettings_Web
    Partial Public Class WebForm1
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Protected Sub DashboardViewer_CustomJSProperties(ByVal sender As Object, _
                                                         ByVal e As CustomJSPropertiesEventArgs)
            Dim element As XElement =
                Dashboard.LoadUserDataFromXml(Server.MapPath("App_Data/Dashboard.xml"))
            Dim chartFontSize As String = element.FirstNode.ToString()
            e.Properties("cpChartFontSize") = Convert.ToSingle(chartFontSize)
        End Sub

        Protected Sub ASPxDashboardViewer1_ConfigureDataConnection(ByVal sender As Object, _
                                                                   ByVal e As ConfigureDataConnectionWebEventArgs)
            If e.ConnectionName = "nwindConnection" Then
                Dim parameters As Access97ConnectionParameters =
                    TryCast(e.ConnectionParameters, Access97ConnectionParameters)

                Dim databasePath As String = Server.MapPath("App_Data/nwind.mdb")
                parameters.FileName = databasePath
            End If
        End Sub
    End Class
End Namespace