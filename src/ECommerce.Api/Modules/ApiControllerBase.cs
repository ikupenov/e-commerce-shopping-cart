using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Modules
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
