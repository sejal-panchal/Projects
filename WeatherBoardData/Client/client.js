const { query, graph } =require('./fetch.js');

//clear UI data
function clearData(){
    $("#ddlStation").empty();
    $("#ddlStation").append('<option value="10">' + "--select option--" + '</option>');
    //$("#ddlStation").append('<option value="' + "CA00709M332" + '">' + "LOUVICOURT, QC" + '</option>');

    $("#lblName").text('');
    $("#lblStation").text('');
    $("#lblLatitude").text('');
    $("#lblLongitude").text('');
    var myElement = $("#googlemap_div");
    myElement.html('');
}

//load station list for selected province
$(document).on('click','#ulprovinceList li',function(){
        // get id of clicked li
        queryData=`{
            stationList(Province:"` + this.id + `"){
            name
            station 
            }
            }`;
            clearData();
            
            runStationListQuery(graph(queryData))
});


$(document).on('click','#ddlStation',function(){
        var station=$("#ddlStation").children("option:selected").val();
        
       if(station=="10"){
        $("#errData").text("Please select station from dropdownlist");
       }else{
        $("#errData").text("");

        //retrieve station information
        var stationQueryData=`{
        stationInfo(Station: "`+station+`") {
            name
            station
            latitude
            longitude
            }
        }`
        runStationDetailQuery(graph(stationQueryData));

        //retrieve detailed weather data
        var drawChartQuery=`{
            stationData(Station: "`+station+`") {
                                date
                                tavg
                                tmin
                                tmax
                                snow
                                prcp
                              }
            }`

           runGetChartDataQuery(graph(drawChartQuery));
       }
    }); 

$('.ls-modal').on('click', function(e){
  e.preventDefault();
  $('#myModal').modal('show').find('.modal-body').load($(this).attr('href'));
});

function runStationDetailQuery(query){
    query().then(
        res => {
            var data,data1,i;
            data =JSON.stringify(res, null, 2);
            data1 = jQuery.parseJSON(data);
           
            $("#lblName").text(data1.stationInfo.name);
            $("#lblStation").text(data1.stationInfo.station);
            $("#lblLatitude").text(data1.stationInfo.latitude);
            $("#lblLongitude").text(data1.stationInfo.longitude);
            var myElement = $("#googlemap_div");
            myElement.html(`<a href='http://maps.google.com/maps?q=`+data1.stationInfo.latitude+`,`+data1.stationInfo.longitude+`' target=”_blank” class='ls-modal'>View on maps</a>`);
        },
        err => {
            $("#errData").text(`Error: <pre><code>${JSON.stringify(err, null, 2)}</code></pre>`);
            
        }
        )
}

google.charts.load('visualization', '1.0', { 'packages': ['corechart'], callback: runGetChartDataQuery(query) });
function runGetChartDataQuery(query){
    query().then(
            res => {
                var data,data1,i;
                //store response
                data =JSON.stringify(res, null, 2);
                //load data into readable/parsable object
                data1 = jQuery.parseJSON(data);

                //define line chart definition
                var lineData = new google.visualization.DataTable();
                lineData.addColumn('date', 'WDate');
                lineData.addColumn('number', 'tavg');
                lineData.addColumn('number','tmin');
                lineData.addColumn('number','tmax');

                //define bar chart definition
                var barData=new google.visualization.DataTable();
                barData.addColumn('date','WDate');
                barData.addColumn('number','snow');
                barData.addColumn('number','percipitation');
                dataArray = [];
                dataBarArray=[];

                //parse & setup chart data
                for (i in data1.stationData) {                                 
                    d = new Date(data1.stationData[i].date);
                    
                    var newDate = d.getFullYear() + "-" + d.getMonth() + "-" + d.getDate();
                    newDate = new Date(newDate);

                    dataArray[i] = [newDate, 
                                parseFloat(data1.stationData[i].tavg), 
                                parseFloat(data1.stationData[i].tmin), 
                                parseFloat(data1.stationData[i].tmax)];

                    var rainFall=parseFloat(data1.stationData[i].prcp) - (parseFloat(data1.stationData[i].snow)/10);
                    var snowFall=parseFloat(data1.stationData[i].snow)/10;

                    dataBarArray[i]=[newDate,
                                parseFloat(rainFall),
                                parseFloat(snowFall)];


                }

                lineData.addRows(dataArray);
                barData.addRows(dataBarArray);

                // Line chart options
                var lineOptions = {
                            chart: {'title':'Min, Max and Avg temperatures',
                               'width':750,
                               'height':500},
                            hAxis: {
                                title: 'Time',
                                },
                            vAxis: {
                                title: 'Temperature' ,   
                                    viewWindow: {
                                      max:50,
                                      min:0
                                    }}};

                //Bar chart options
                var barOptions = {
                            chart: {'title':'Rainfall and Snowfall data',
                               'width':750,
                               'height':500},
                            hAxis: {
                                title: 'Time',
                                },
                            vAxis: {
                                title: 'Rainfall/Snowfall' ,   
                                    viewWindow: {
                                      max:250,
                                      min:0
                                    }}};

                //Instantiate and draw our chart, passing in some options.
                var lineChart = new google.visualization.LineChart(document.getElementById('lineChart_div'));
                var barChart=new google.visualization.ColumnChart(document.getElementById('barChart_div'));
                lineChart.draw(lineData,lineOptions);
                barChart.draw(barData,barOptions);
            },
            err => {
                $("#errData").text(`Error: <pre><code>${JSON.stringify(err, null, 2)}</code></pre>`);
                }
            )
}

function runStationListQuery (query) {
    query().then(
        res => {            
            var data,data1,i;
            data =JSON.stringify(res, null, 2);
            data1 = jQuery.parseJSON(data);

            var ele = document.getElementById('ddlStation');

            for (i in data1.stationList) {                            
                ele.innerHTML = ele.innerHTML +
                '<option value="' + data1.stationList[i].station+ '">' + data1.stationList[i].name + '</option>';
            }
        },
        err => {
            $("#errData").text(`Error: <pre><code>${JSON.stringify(err, null, 2)}</code></pre>`);
        }
    )
}