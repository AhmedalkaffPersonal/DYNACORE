using Application.Features.ContactPersonFeatures.Commands;
using Application.Features.ContactPersonFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ContactPersonController : BaseApiController
    {
        /// <summary>
        /// Creates a New Contact Person.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactPersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Gets all Contact Persons.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllContactPersonsQuery()));
        }
        /// <summary>
        /// Gets Contact Person Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetContactPersonByIdQuery { Id = id }));
        }
        /// <summary>
        /// Deletes Contact Person Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteContactPersonByIdCommand { Id = id }));
        }
        /// <summary>
        /// Updates the Contact Person Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(Guid id, UpdateContactPersonCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
