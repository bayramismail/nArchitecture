using Application.Features.Models.Queries.GetListModel;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {

        [HttpGet("")]
        public async Task<IActionResult> GetList([FromQuery] GetListModelQuery getListModelQuery)
        {
            var result = await Mediator.Send(getListModelQuery);
            return Ok(result);
        }
        [HttpPost("GetListByDynemic")]
        public async Task<IActionResult> GetListByDynemic([FromQuery] PageRequest pageRequest,[FromBody]Dynamic  dynamic)
        {
            var getListModelByDynamicQuery = new GetListModelByDynamicQuery { PageRequest=pageRequest,Dynamic=dynamic};
            var result = await Mediator.Send(getListModelByDynamicQuery);
            return Ok(result);
        }
    }
}
