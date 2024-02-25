using Microsoft.AspNetCore.Mvc;
using MyApplication.Domain.Entities.DTOS;
using MyApplication.Domain.Entities.Models;
using MyApplication.Application.Services;



namespace MyApplication.API.Contrlollers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServise _personService;

        public PersonController(IPersonServise personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _personService.GetAll();
        }

        [HttpGet]
        public Task<Person> GetById(int id)
        {
            return _personService.GetById(id);
        }

        [HttpPost]
        public async Task<PersonDTO> CreateNewPerson(PersonDTO personDTO)
        {
            await _personService.CreateNewPerson(personDTO);
            return personDTO;
        }
        
        

        [HttpPut]
        public async Task<Person> UpdatePerson(int id,PersonDTO personDTO)
        {
            return await _personService.UpdatePerson(personDTO,id);
            
        }
        
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await _personService.DeletePerson(id);
        }
    }
}
