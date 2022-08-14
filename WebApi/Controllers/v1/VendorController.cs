using Application.Features.VendorFeatures.Commands;
using Application.Features.VendorFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class VendorController : BaseApiController
    {
        /// <summary>
        /// Creates a New Vendor.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateVendorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Gets all Vendors.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllVendorsQuery()));
        }
        /// <summary>
        /// Gets Vendor Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetVendorByIdQuery { Id = id }));
        }
        /// <summary>
        /// Deletes Vendor Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteVendorByIdCommand { Id = id }));
        }
        /// <summary>
        /// Updates the Vendor Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(Guid id, UpdateVendorCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
