using Application;
using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandDto createdBrandDto = await Mediator.Send(createBrandCommand);
            return Created("", createdBrandDto);
        }
        [HttpGet("")]
        public async Task<IActionResult> GetList([FromQuery] GetListBrandQuery getListBrandQuery)
        {
            BrandListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBrandById([FromRoute] GetBrandByIdQuery getBrandByIdQuery)
        {
            GetBrandByIdDto result = await Mediator.Send(getBrandByIdQuery);
            return Ok(result);
        }
    }
}
