import graphene
from graphene import relay
from graphene_sqlalchemy import SQLAlchemyConnectionField, SQLAlchemyObjectType
from database import db_session, Station as stationModel, WeatherData as weatherDataModel

class StationData(SQLAlchemyObjectType):
	class Meta:
	    model = stationModel
	    interfaces = (relay.Node, )

class StationWeatherData(SQLAlchemyObjectType):
	class Meta:
	    model = weatherDataModel
	    interfaces = (relay.Node, )

class Query(graphene.ObjectType):
	node = relay.Node.Field()
	#queries to support UI with their functions below
	station_list = graphene.List(lambda: StationData, Province=graphene.String())
	station_info = graphene.Field(lambda: StationData, Station = graphene.String())
	station_data = graphene.List(lambda: StationWeatherData, Station = graphene.String())

	def resolve_station_list(self,args,context,info):
		query = StationData.get_query(context)
		province = args.get('Province')
		filter = '%' + province;
		return query.filter(stationModel.name.like(filter)).all()

	def resolve_station_info(self,args,context,info):
		query = StationData.get_query(context)
		station = args.get('Station')
		return query.filter(stationModel.station == station).first()

	def resolve_station_data(self,args,context,info):
		query = StationWeatherData.get_query(context)
		station = args.get('Station')
		return query.filter(weatherDataModel.station == station)

#define what data would be returned
schema = graphene.Schema(query=Query, types=[StationData, StationWeatherData])