using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand )
        {
            CreatedBrandDto createdBrandDto = await Mediator.Send(createBrandCommand);
            return Created("", createdBrandDto);
        }
    }
}
