from flask import Flask, render_template, request
from flask_graphql import GraphQLView
from database import db_session
from schema import schema
from flask_cors import CORS

app = Flask(__name__)
CORS(app)
app.debug = True

app.add_url_rule('/graphql', view_func=GraphQLView.as_view('graphql', schema=schema, graphiql=True, context={'session': db_session}))

@app.route("/", methods=["GET"])
def index():
	return "Go to /graphql"

if __name__ == "__main__":
	app.run()
