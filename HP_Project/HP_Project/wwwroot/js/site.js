// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//ChartJS voor CustomerFinancials
window.onload = function () {

    var options = {
        exportEnabled: true,
        animationEnabled: true,
        title: {
            //text: "Units Sold VS Profit"
        },
        subtitles: [{
            //text: "Click Legend to Hide or Unhide Data Series"
        }],
        axisX: {
            //title: "States"
        },
        axisY: {
            //title: "Units Sold",
            titleFontColor: "#4F81BC",
            lineColor: "#4F81BC",
            labelFontColor: "#4F81BC",
            tickColor: "#4F81BC",
            includeZero: false,
            interval: 10,
            minimum: 0
        },
        axisY2: {
            title: "GPM in %",
            titleFontColor: "#C0504E",
            lineColor: "#C0504E",
            labelFontColor: "#C0504E",
            tickColor: "#C0504E",
            includeZero: false,
            interval: 20,
            maximum: 40
        },
        toolTip: {
            shared: true
        },
        legend: {
            cursor: "pointer",
            itemclick: toggleDataSeries
        },
        data: [{
                type: "line",
                axisYType: "primary",
                connectNullData: true,
                name: "REV (M$)",
                showInLegend: true,
                indexLabel: "{y}",
                //xValueFormatString: ["Q115, Q215"],
                yValueFormatString: "##.##",
                dataPoints: [{
                        label: "Q117",
                    y: parseFloat(document.getElementById("REV2017Q1").innerHTML)
                    },
                    {
                        label: "Q217",
                        y: parseFloat(document.getElementById("REV2017Q2").innerHTML)
                    },
                    {
                        label: "Q317",
                        y: parseFloat(document.getElementById("REV2017Q3").innerHTML)
                    },
                    {
                        label: "Q417",
                        y: parseFloat(document.getElementById("REV2017Q4").innerHTML)
                    },
                ]
            },
            //{
            //    type: "line",
            //    axisYType: "primary",
            //    lineDashType: "dash",
            //    name: "SFDC pipeline",
            //    indexLabel: "{y}",
            //    showInLegend: true,
            //    //xValueFormatString: ["Q115, Q215"],
            //    yValueFormatString: "##.##",
            //    dataPoints: [{
            //            label: "Q115",
            //            y: parseFloat(document.getElementById("SFDCPQ115").innerHTML)
            //        },
            //        {
            //            label: "Q215",
            //            y: parseFloat(document.getElementById("SFDCPQ215").innerHTML)
            //        },
            //        {
            //            label: "Q315",
            //            y: parseFloat(document.getElementById("SFDCPQ315").innerHTML)
            //        },
            //        {
            //            label: "Q415",
            //            y: parseFloat(document.getElementById("SFDCPQ415").innerHTML)
            //        },
            //        {
            //            label: "Q116",
            //            y: parseFloat(document.getElementById("SFDCPQ116").innerHTML)
            //        },
            //        {
            //            label: "Q216",
            //            y: parseFloat(document.getElementById("SFDCPQ216").innerHTML)
            //        },
            //        {
            //            label: "Q316",
            //            y: parseFloat(document.getElementById("SFDCPQ316").innerHTML)
            //        },
            //        {
            //            label: "Q416",
            //            y: parseFloat(document.getElementById("SFDCPQ416").innerHTML)
            //        },
            //        {
            //            label: "Q117",
            //            y: parseFloat(document.getElementById("SFDCPQ117").innerHTML)
            //        },
            //        {
            //            label: "Q217",
            //            y: parseFloat(document.getElementById("SFDCPQ217").innerHTML)
            //        },
            //        {
            //            label: "Q317",
            //            y: parseFloat(document.getElementById("SFDCPQ317").innerHTML)
            //        },
            //        {
            //            label: "Q417",
            //            y: parseFloat(document.getElementById("SFDCPQ417").innerHTML)
            //        },
            //        {
            //            label: "Q118",
            //            y: parseFloat(document.getElementById("SFDCPQ118").innerHTML)
            //        },
            //        {
            //            label: "Q218",
            //            y: parseFloat(document.getElementById("SFDCPQ218").innerHTML)
            //        },
            //        {
            //            label: "Q318",
            //            y: parseFloat(document.getElementById("SFDCPQ318").innerHTML)
            //        },
            //        {
            //            label: "Q418",
            //            y: parseFloat(document.getElementById("SFDCPQ418").innerHTML)
            //        }
            //    ]
            //},
            //{
            //    type: "line",
            //    axisYType: "primary",
            //    lineDashType: "dash",
            //    name: "SFDC commit",
            //    indexLabel: "{y}",
            //    showInLegend: true,
            //    //xValueFormatString: ["Q115, Q215"],
            //    yValueFormatString: "##.##",
            //    dataPoints: [{
            //            label: "Q115",
            //            y: parseFloat(document.getElementById("SFDCCQ115").innerHTML)
            //        },
            //        {
            //            label: "Q215",
            //            y: parseFloat(document.getElementById("SFDCCQ215").innerHTML)
            //        },
            //        {
            //            label: "Q315",
            //            y: parseFloat(document.getElementById("SFDCCQ315").innerHTML)
            //        },
            //        {
            //            label: "Q415",
            //            y: parseFloat(document.getElementById("SFDCCQ415").innerHTML)
            //        },
            //        {
            //            label: "Q116",
            //            y: parseFloat(document.getElementById("SFDCCQ116").innerHTML)
            //        },
            //        {
            //            label: "Q216",
            //            y: parseFloat(document.getElementById("SFDCCQ216").innerHTML)
            //        },
            //        {
            //            label: "Q316",
            //            y: parseFloat(document.getElementById("SFDCCQ316").innerHTML)
            //        },
            //        {
            //            label: "Q416",
            //            y: parseFloat(document.getElementById("SFDCCQ416").innerHTML)
            //        },
            //        {
            //            label: "Q117",
            //            y: parseFloat(document.getElementById("SFDCCQ117").innerHTML)
            //        },
            //        {
            //            label: "Q217",
            //            y: parseFloat(document.getElementById("SFDCCQ217").innerHTML)
            //        },
            //        {
            //            label: "Q317",
            //            y: parseFloat(document.getElementById("SFDCCQ317").innerHTML)
            //        },
            //        {
            //            label: "Q417",
            //            y: parseFloat(document.getElementById("SFDCCQ417").innerHTML)
            //        },
            //        {
            //            label: "Q118",
            //            y: parseFloat(document.getElementById("SFDCCQ118").innerHTML)
            //        },
            //        {
            //            label: "Q218",
            //            y: parseFloat(document.getElementById("SFDCCQ218").innerHTML)
            //        },
            //        {
            //            label: "Q318",
            //            y: parseFloat(document.getElementById("SFDCCQ318").innerHTML)
            //        },
            //        {
            //            label: "Q418",
            //            y: parseFloat(document.getElementById("SFDCCQ418").innerHTML)
            //        }
            //    ]
            //},
            {
                type: "line",
                name: "GPM",
                axisYType: "secondary",
                indexLabel: "{y}",
                showInLegend: true,
                //xValueFormatString: "MMM YYYY",
                yValueFormatString: "#.#",
                dataPoints: [{
                        label: "Q117",
                        y: parseFloat(document.getElementById("GPM2017Q1percent").innerHTML)
                    },
                    {
                        label: "Q217",
                        y: parseFloat(document.getElementById("GPM2017Q2percent").innerHTML)
                    },
                    {
                        label: "Q317",
                        y: parseFloat(document.getElementById("GPM2017Q3percent").innerHTML)
                    },
                    {
                        label: "Q417",
                        y: parseFloat(document.getElementById("GPM2017Q4percent").innerHTML)
                    },
                ]
            },
            {
                type: "line",
                name: "GPM (M$)",
                axisYType: "primary",
                showInLegend: true,
                indexLabel: "{y}",
                //xValueFormatString: "MMM YYYY",
                yValueFormatString: "#.#",
                dataPoints: [{
                        label: "Q117",
                        y: parseFloat(document.getElementById("GPM2017Q1").innerHTML)
                    },
                    {
                        label: "Q217",
                        y: parseFloat(document.getElementById("GPM2017Q2").innerHTML)
                    },
                    {
                        label: "Q317",
                        y: parseFloat(document.getElementById("GPM2017Q3").innerHTML)
                    },
                    {
                        label: "Q417",
                        y: parseFloat(document.getElementById("GPM2017Q4").innerHTML)
                    },
                ]
            },
        ]
    };
    $("#chartContainer").CanvasJSChart(options);

    function toggleDataSeries(e) {
        if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
            e.dataSeries.visible = false;
        } else {
            e.dataSeries.visible = true;
        }
        e.chart.render();
    }

    // Construct options first and then pass it as a parameter
    var options1 = {
        animationEnabled: true,
        axisY: {
        interval: 0.5,
        maximum: 2.5
        },
        title: {
            text: "Revenue (M$)"
        },
        data: [{
            type: "column", //change it to line, area, bar, pie, etc
            legendText: "test",
            indexLabel: "{y}",
            showInLegend: true,
            dataPoints: [
                {y: 2.0 },
                {y: 1.2 },
                {y: 0.2 },
                {y: 0.4 },
                {y: 0.3 },
                {y: 0.0 },
                {y: 0.5 }
                ]
            }]
    };
            $("#chartContainer1").CanvasJSChart(options1);
            $("#chartContainer1").CanvasJSChart().render();

            // Construct options first and then pass it as a parameter
    var options2 = {
        animationEnabled: true,
        axisY: {
        interval: 10,
        maximum: 70
        },
        title: {
            text: "Revenue (M%)"
        },
        data: [{
            type: "column", //change it to line, area, bar, pie, etc
            legendText: "test",
            indexLabel: "{y}",
            showInLegend: true,
            dataPoints: [
                {y: 10 },
                {y: 15 },
                {y: 4 },
                {y: 25 },
                {y: 20 },
                {y: 20 },
                {y: 0 },
                {y: 60}
                ]
            }]
    };
            $("#chartContainer2").CanvasJSChart(options2);
            $("#chartContainer2").CanvasJSChart().render();
}
//einde chartjs customerfinancials

function toggleContactUpdateRow(uniqueId, isUpdateClicked) {
    var readRow = 'contactRowRead_' + uniqueId;
    var updateRow = 'contactRowUpdate_' + uniqueId;

    if (isUpdateClicked) {
        $('#' + readRow).hide();
        $('#' + updateRow).show();
    } else {
        $('#' + readRow).show();
        $('#' + updateRow).hide();
    }
}

function toggleTouchpointUpdateRow(uniqueId, isUpdateClicked) {
    var readRow = 'touchpointRowRead_' + uniqueId;
    var updateRow = 'touchpointRowUpdate_' + uniqueId;

    if (isUpdateClicked) {
        $('#' + readRow).hide();
        $('#' + updateRow).show();
    } else {
        $('#' + readRow).show();
        $('#' + updateRow).hide();
    }
}
