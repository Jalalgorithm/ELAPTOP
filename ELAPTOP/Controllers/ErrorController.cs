using ELAPTOP.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components;

namespace ELAPTOP.Controllers
{
    [Microsoft.AspNetCore.Components.Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController: BaseApiController
    {
        public IActionResult Error (int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
