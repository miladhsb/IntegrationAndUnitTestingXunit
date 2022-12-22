using IntegrationAndUnitTesting.Entities;

namespace IntegrationAndUnitTesting.Repository
{
    public interface IPersonRepository
    {
        Task<bool> AddPerson(Person person, CancellationToken cancellationToken = default);
        Task<Person> GetPersonById(int Id, CancellationToken cancellationToken = default);
        Task<List<Person>> GetPersons(CancellationToken cancellationToken = default);
        Task<bool> RemovePersonById(int Id, CancellationToken cancellationToken = default);
    }
}
