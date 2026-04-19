using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.ServicesExternalMenu.IServices;
using WebAPI.Services.ServicesToken.IServices;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IExternalMenuService _externalMenuService;

        public TestController(ITokenService tokenService, IExternalMenuService externalMenuService)
        {
            _tokenService = tokenService;
            _externalMenuService = externalMenuService;
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetToken()
        {
            var token = await _tokenService.GetTokenAsync();
            return Ok(new { token });
        }
        [HttpPost("externalMenu")]
        public async Task<IActionResult> GetExternalMenu()
        {
            var externalMenu = await _externalMenuService.GetExternalMenuAsync();
            return Ok(externalMenu);
        }
    }
}
