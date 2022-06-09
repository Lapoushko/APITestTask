using APITestTask.Model;
using APITestTask.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalsAccountController : ControllerBase
    {
        private readonly IPersonalsRepositoryAccount _personalRepository;
        public PersonalsAccountController(IPersonalsRepositoryAccount personalRepository)
        {
            _personalRepository = personalRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonalAccount>> GetInfo()
        {
            return await _personalRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalAccount>> GetInfoId(int id)
        {
            return await _personalRepository.GetId(id);
        }

        [HttpPost]
        public async Task<ActionResult<PersonalAccount>> PostBooks([FromBody] PersonalAccount personal)
        {
            var newInfo = await _personalRepository.Create(personal);
            return CreatedAtAction(nameof(GetInfo), new { id = newInfo.Id }, newInfo);
        }

        [HttpPut]
        public async Task<ActionResult> PutInfo(int id, [FromBody] PersonalAccount personal)
        {
            if (id != personal.Id)
            {
                return BadRequest();
            }
            await _personalRepository.Update(personal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id,[FromBody] PersonalAccount personal)
        {
            var personalToDelete = await _personalRepository.GetId(id);
            if (personalToDelete == null)
            {
                return NotFound();
            }
            await _personalRepository.Delete(personalToDelete.Id, personal);
            return NotFound();
        }
    }
}
