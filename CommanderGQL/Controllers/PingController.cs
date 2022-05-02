using Microsoft.AspNetCore.Mvc;

namespace CommanderGQL.Controllers
{
    [ApiController]
    public class PingController
        : ControllerBase
    {
        [HttpGet("")]
        public string Ping() => "Pong";
    }
}