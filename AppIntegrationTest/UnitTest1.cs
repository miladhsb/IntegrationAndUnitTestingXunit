using IntegrationAndUnitTesting;
using IntegrationAndUnitTesting.Entities;
using IntegrationAndUnitTesting.Repository;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using System.Reflection;

namespace AppIntegrationTest
{
    public class UnitTest1
    {
        [Fact]
        public async void TestStatusCode()
        {


            WebApplicationFactory<Program> webApplication = new Customwebappfactory<Program>();

            var client = webApplication.CreateClient();

            var result = await client.GetAsync("https://localhost:7223/api/Person");
            result.EnsureSuccessStatusCode();
           

        }

        [Fact]
        public async void TestContent()
        {


            WebApplicationFactory<Program> webApplication = new Customwebappfactory<Program>();

            var client = webApplication.CreateClient();

            var result = await client.GetAsync("https://localhost:7223/api/Person");
            result.EnsureSuccessStatusCode();


            var content = await result.Content.ReadFromJsonAsync<List<Person>>();

            Assert.Equal(3, content.Count);
        }

        [Fact]
        public async void TestReositoryService()
        {


            WebApplicationFactory<Program> webApplication = new Customwebappfactory<Program>();

            var client = webApplication.CreateClient();

            //Get services
            var repo = webApplication.Services.CreateScope().ServiceProvider.GetRequiredService<IPersonRepository>();

            var Persons = await repo.GetPersons();
            
            Assert.Equal(3, Persons.Count);

        }

    }
}