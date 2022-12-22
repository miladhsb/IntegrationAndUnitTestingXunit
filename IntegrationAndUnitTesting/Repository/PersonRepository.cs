using IntegrationAndUnitTesting.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IntegrationAndUnitTesting.Repository
{
    public class PersonRepository:IPersonRepository
    {
        private readonly AppDbContext _dbContext;

        public PersonRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public  async Task<bool> AddPerson(Person person,CancellationToken cancellationToken=default)
        {
           await  _dbContext.AddAsync(person, cancellationToken);
           var save= await  _dbContext.SaveChangesAsync(cancellationToken);
            return save>=1;
        }

        public async Task<List<Person>> GetPersons(CancellationToken cancellationToken = default)
        {
           return await _dbContext.People.ToListAsync(cancellationToken);
           
        }

        public async Task<Person> GetPersonById(int Id,CancellationToken cancellationToken = default)
        {
            return await _dbContext.People.FirstOrDefaultAsync(p=>p.Id==Id, cancellationToken);

        }
        public async Task<bool> RemovePersonById(int Id, CancellationToken cancellationToken = default)
        {
            var Person = await _dbContext.People.FirstOrDefaultAsync(p => p.Id == Id, cancellationToken);

            if (Person == null)
            {
                throw new NullReferenceException();
            }

            _dbContext.Remove(Person);
             var save=await _dbContext.SaveChangesAsync(cancellationToken);
            return save >= 1;
        }

    }
}
