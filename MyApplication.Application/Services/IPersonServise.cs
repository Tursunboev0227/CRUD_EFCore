using MyApplication.Domain.Entities.DTOS;
using MyApplication.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Application.Services
{
    public interface IPersonServise
    {
        public Task<PersonDTO> CreateNewPerson(PersonDTO newPerson);
        public Task<Person> UpdatePerson(PersonDTO newPerson, int id);
        public Task<bool> DeletePerson(int id);
        public Task<Person> GetById(int id);
        public Task<IEnumerable<Person>> GetAll();

    }
}
