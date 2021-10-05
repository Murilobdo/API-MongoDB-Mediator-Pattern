using API.Interfaces;
using API.Domain.Product.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System;
using API.Extensions;

namespace API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(Task.FromResult("Algo aconteceu ao tentar cadastrar o produto, " + ex.GetFullMessage()));
            }
        }

        [HttpPost("EditProduct")]
        public async Task<IActionResult> EditProduct([FromBody] UpdateProductCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(Task.FromResult("Algo aconteceu ao tentar editar um produto, " + ex.GetFullMessage()));
            }
        }

        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(Task.FromResult("Algo aconteceu ao tentar deletar um produto, " + ex.GetFullMessage()));
            }
        }

        [HttpGet("ListProducts")]
        public async Task<IActionResult> ListProducts()
        {
            try
            {
                var response = await _mediator.Send(new ListProductCommand());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(Task.FromResult("Algo aconteceu ao tentar deletar um produto, " + ex.GetFullMessage()));
            }
        }
    }
}
