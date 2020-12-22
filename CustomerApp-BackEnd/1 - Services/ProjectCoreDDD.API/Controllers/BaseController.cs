using Microsoft.AspNetCore.Mvc;
using ProjectCoreDDD.Application.ResponseEvent;

namespace ProjectCoreDDD.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected new ActionResult Response(ResponseResult responseResult)
        {
            if (!responseResult.Success)
            {
                return BadRequest(responseResult);
            }
            else
            {
                return Ok(responseResult);
            }
        }

        protected ActionResult CustomResponse(object data, bool success, string message)
        {
            var responseResult = new ResponseResult(data, success, message);
            if (!responseResult.Success)
            {
                return BadRequest(responseResult);
            }
            else
            {
                return Ok(responseResult);
            }
        }
    }
}