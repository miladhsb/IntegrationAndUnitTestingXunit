using IntegrationAndUnitTesting.Entities;
using IntegrationAndUnitTesting.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTest
{
    public class RepositoryTest
    {
        Mock<IPersonRepository> RepositoryMock = new Mock<IPersonRepository>();
        public RepositoryTest()
        {
           
        }
        [Fact]
       public async Task GetPersonTest()
        {
            RepositoryMock.Setup(p => p.GetPersons(default)).ReturnsAsync(new List<Person>()
            {
                new Person(){FirstName="ali",LastName="saeedi",Age=30,Id=1},
                new Person(){FirstName="mohammad",LastName="hasani",Age=30,Id=1},
            });
            var pesronrepo =await RepositoryMock.Object.GetPersons();

            Assert.Collection(pesronrepo, p => Assert.Equal(p.FirstName,"ali"), p => Assert.Equal(p.FirstName, "mohammad"));

        }
        [Fact]
        public async Task GetAllPersonTest()
        {
            RepositoryMock.Setup(p => p.GetPersons(default)).ReturnsAsync(new List<Person>()
            {
                new Person(){FirstName="ali",LastName="saeedi",Age=30,Id=1},
                new Person(){FirstName="ali",LastName="hasani",Age=30,Id=1},
            });
            var pesronrepo = await RepositoryMock.Object.GetPersons();

            Assert.All(pesronrepo, p => Assert.Equal(p.FirstName, "ali"));

        }
        [Fact]
        public async Task GetAllPersonCountTest()
        {
            RepositoryMock.Setup(p => p.GetPersons(default)).ReturnsAsync(new List<Person>()
            {
                new Person(){FirstName="ali",LastName="saeedi",Age=30,Id=1},
                new Person(){FirstName="ali",LastName="hasani",Age=30,Id=1},
            });
            var pesronrepo = await RepositoryMock.Object.GetPersons();

            Assert.Equal(pesronrepo.Count(), 2);

        }
        [Fact]
        public async Task GetAllPersonCountTest2()
        {

            RepositoryMock.Setup(p => p.GetPersons(default)).ReturnsAsync(new List<Person>()
            {
                Mock.Of<Person>(p=>p.FirstName=="hasan"&&p.LastName=="saeedi",MockBehavior.Strict),
                
            });
            var pesronrepo = await RepositoryMock.Object.GetPersons();

            Assert.Equal(pesronrepo.Count(), 1);

        }

    }
}
