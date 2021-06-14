using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpicUniversity.Test
{
    [TestClass]
    public class CourseControllerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public CourseControllerTest()
        {
            // Arrange
                _server = new TestServer(new WebHostBuilder()
                    .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [TestMethod]
        public async Task ShouldReturnCourseInformation()
        {
            //Act
            var response = await _client.GetAsync("http://localhost/Course/3");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual("Hello World!", responseString);
        }
    }
}
