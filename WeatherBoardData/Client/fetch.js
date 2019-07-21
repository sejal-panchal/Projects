const graphql = require('graphql.js');
const graph = graphql('http://127.0.0.1:5000/graphql');

//Sample query defined
const query = graph(`{        
  stationList(Province: "NS") {
    name    
  }
}`);

if (require.main === module) {
  query().then(
    res => console.log(JSON.stringify(res, null, 2)),
    err => console.error(err)
  );
}

module.exports = {
  query,
  graph
};