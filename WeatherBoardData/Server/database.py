from sqlalchemy import create_engine
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import scoped_session, sessionmaker
from sqlalchemy import Column, DateTime, ForeignKey, Integer, Text, func, String

#database engine definition
engine = create_engine('mssql+pyodbc://(local)/WeatherBoard?driver=SQL+Server+Native+Client+11.0', echo=True)
db_session = scoped_session(sessionmaker(autocommit=False,
                                         autoflush=False,
                                         bind=engine))
Base = declarative_base()
Base.query = db_session.query_property()

#object mapping to data
class Station(Base):
    __tablename__ = 'dataset'
    name = Column(String, primary_key=True)
    station = Column(String, primary_key=True)
    latitude = Column(String)
    longitude = Column(String)

#object mapping to data
class WeatherData(Base):
    __tablename__ = 'dataset'
    __table_args__ = {'extend_existing': True}
    station = Column(String, primary_key=True)
    date = Column(String, primary_key=True)
    tavg = Column(Integer)
    tmin = Column(Integer)
    tmax = Column(Integer)
    prcp = Column(Integer)
    snow = Column(Integer)