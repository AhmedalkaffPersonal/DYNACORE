using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery()));

            //if (products == null)
            //{
            //    return NotFound();
            //}
            //var data = products.AsQueryable();
            //var queryString = Request.Query;
            //string filter = queryString["$filter"];
            //string auto = queryString["$inlineCount"];
            //if (filter != null) // to handle filter opertaion 
            //{
            //    var newfiltersplits = filter;
            //    var filtersplits = newfiltersplits.Split('(', ')', ' ', '\'');
            //    var filterfield = filtersplits[4];
            //    var filtervalue = filtersplits[2];

            //    if (filtersplits.Length == 7)
            //    {
            //        if (filtersplits[2] == "tolower")
            //        {
            //            filterfield = filter.Split('(', ')', '\'')[3];
            //            filtervalue = filter.Split('(', ')', '\'')[5];
            //        }
            //    }
            //    switch (filterfield)
            //    {
            //        case "Name":
            //            data = data.Where(product => product.Name.ToLower().StartsWith(filtervalue.ToString()));
            //            break;
            //    }
            //}
            //if (queryString.Keys.Contains("$inlinecount"))
            //{
            //    StringValues Skip;
            //    StringValues Take;
            //    int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
            //    int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : data.Count();
            //    var count = data.Count();
            //    return top != 0 ? new { result = data.Skip(skip).Take(top), Count = count } : new { result = data, Count = count };
            //}
            //else
            //{
            //    return data;
            //}


        }
        /// <summary>
        /// Gets Product Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
        }
        /// <summary>
        /// Deletes Product Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }
        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(Guid id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
