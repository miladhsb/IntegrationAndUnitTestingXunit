using IntegrationAndUnitTesting;
using IntegrationAndUnitTesting.Entities;
using IntegrationAndUnitTesting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTest
{
    public class RepositorywithDbcontextTest
    {

        private readonly IPersonRepository _personRepository;
        public RepositorywithDbcontextTest()
        {
          var  _AppDbContext= AppDbcontextFactory.CreateDbContext();
            _personRepository = new PersonRepository(_AppDbContext);
        }

        [Fact]
        public async void AddPersonTest()
        {

            Assert.True(await _personRepository.AddPerson(new Person() { FirstName = "ali", LastName = "saeedi", Age = 30, Id = 1 }));


        }
        [Fact]
        public async void GetPersonTest()
        {

            await _personRepository.AddPerson(new Person() { FirstName = "ali", LastName = "saeedi", Age = 30, Id = 4 });
            await _personRepository.AddPerson(new Person() { FirstName = "ali", LastName = "saeedi", Age = 30, Id = 2 });
            await _personRepository.AddPerson(new Person() { FirstName = "ali", LastName = "saeedi", Age = 30, Id = 3 });

            var Persons = await _personRepository.GetPersons();

            Assert.Equal(Persons.Count, 4);


        }
    }
}
