function OnItemWidgetCreated(e) {
    if (e.ItemName == "chartDashboardItem1") {
        var chart = e.GetWidget();
        chart.option({
            legend: {
                font: { size: DashboardViewer.cpChartFontSize }
            }
        });
    }
}