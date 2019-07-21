Notes:
# Database used is SQL Server.
# Database Name: WeatherBoard
# Table Name: dataset
	Data from CSV was imported as-it-is into this table.
	Table structure can be re-designed to achieve normalization, performance & simplification in querying.
# There is no data for current year so it is not filtered by last 12 months. By default, all records for stations are displayed.
# Loading of stations when selecting a province takes some time. You might have to wait for few seconds to have station list updated.
# Server is created in Python based on GraphQL
# Client is simple web-page using NodeJS, jQuery, Google charts
Setting Up Client:
## npm install

Setting Up Server:
## Install Python (2.7)
## Install the packages: 
pip install -r requirements.txt

## Update the database details in *database.py* file
## (local)/WeatherBoard where (local) = ServerName & WeatherBoard = DatabaseName
## Run Server:
python app.py

## Testing server: to http://localhost:5000/graphql 
## Below Queries:

#List of Stations for province:
{
  stationList(Province: "BC") {
    name    
  }
}

#Station Details:
{
  stationInfo(Station: "CA00709M332") {
    name
    station
    latitude
    longitude
  }
}

#Station weather data
{
  stationData(Station: "CA00709M332") {
		date
    tavg
    tmin
    tmax
    snow
    prcp
  }
}