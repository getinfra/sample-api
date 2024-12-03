using getinfra.samples.rest.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace getinfra.samples.rest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;


        public PingController(IHttpContextAccessor contextAccessor) 
        {
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public async Task<ActionResult<List<PingEntry>>> Get()
        {
            var list = new List<PingEntry>();
            foreach (var header in _contextAccessor.HttpContext.Request.Headers)
            {
                list.Add(new PingEntry(header.Key, header.Value));

            }

            list.Add(new PingEntry("Client's IP", GetIp(_contextAccessor.HttpContext)));

            return Ok(list);
        }


        internal static string GetIp(HttpContext httpContext)
        {
            string ip;
            if (httpContext.Request.Headers.Keys.Contains("cf-connecting-ip")) // cloudflare ip handling
            {
                ip = httpContext.Request.Headers["cf-connecting-ip"];
                return ip;
            }
            else if (httpContext.Request.Headers.Keys.Contains("x-envoy-external-address")) // istio envoy ip handling 
            {
                ip = httpContext.Request.Headers["x-envoy-external-address"];
                return ip;
            }
            else // common case
            {
                if (httpContext.Connection.RemoteIpAddress != null)
                    ip = httpContext.Connection.RemoteIpAddress.ToString();
                else
                    ip = "local:127.0.0.1";
            }

            return ip;
            // cf-connecting-ip: 213.196.215.67

        }
    }
}
