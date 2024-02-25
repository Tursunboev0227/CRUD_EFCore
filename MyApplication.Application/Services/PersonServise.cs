
using Microsoft.EntityFrameworkCore;
using MyApplication.Domain.Entities.DTOS;
using MyApplication.Domain.Entities.Models;
using MyApplication.Infrostructure.Persistance;

namespace MyApplication.Application.Services
{
    public class PersonServise : IPersonServise
    {
        private readonly ApplicationDbContext _context;
        public PersonServise(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PersonDTO> CreateNewPerson(PersonDTO newPerson)
        {
            try
            {
                var tempPerson = new Person()
                {
                    FullName = newPerson.FullName,
                    age = newPerson.age,
                    status = newPerson.status,
                };
                await _context.Persons.AddAsync(tempPerson);
                await _context.SaveChangesAsync();
                return newPerson;
            }
            catch
            {
                return null;
            }
        }


        public async Task<bool> DeletePerson(int id)
        {
            try
            {
                var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
                if (person is not null){
                    _context.Persons.Remove(person);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            try
            {
                return await _context.Persons.ToListAsync();

            }
            catch
            {
                return Enumerable.Empty<Person>();
            }
        }

        public async Task<Person> GetById(int id)
        {
            try
            {
                var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
                if (person is not null){
                    return person;
                }
                return new Person();
            }
            catch { return new Person() { }; }

        }

        public async Task<Person> UpdatePerson(PersonDTO newPerson, int id)
        {
            try
            {
                var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);

                if (person != null)
                {
                    person.FullName = newPerson.FullName;
                    person.age = newPerson.age;
                    person.status = newPerson.status;

                    await _context.SaveChangesAsync();
                }

                return person;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                return null;
            }
        }

    }
}
