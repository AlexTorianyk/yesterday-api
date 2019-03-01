using System.Threading.Tasks;
using IdentityServer.Core.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using YesterdayApi.Core.Users;
using YesterdayApi.Core.Users.Web;

namespace YesterdayApi.Core.Identity.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly IIdentityService _identityService;

        public IdentityController(IUserIdentityService userIdentityService, IIdentityService identityService)
        {
            _userIdentityService = userIdentityService;
            _identityService = identityService;
        }

        [HttpGet("{id}")]
        public Task<UserIdentity> GetById(int id)
        {
            return _userIdentityService.GetById(id);
        }

        [HttpPost("access")]
        public async Task<ActionResult<JObject>> GetAccessToken(UserIdentityRequest userRequest)
        {
            var accessToken = await _identityService.GetAccessToken(userRequest);

            return Ok(accessToken);
        }

        [HttpGet("refresh")]
        public async Task<ActionResult<JObject>> GetRefreshToken()
        {
            string authHeader = Request.Headers["Authorization"];

            var accessToken = await _identityService.RefreshAccessToken(authHeader);

            return Ok(accessToken);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post(UserRegistrationRequest userModel)
        {
            var result = await _identityService.RegisterUser(userModel);

            if (result.Succeeded)
            {
                var user = await _userIdentityService.FindByNameAsync(userModel.UserName);

                // Change this to findById in users controller when it's created
                return CreatedAtAction(nameof(GetById), new { id = user.Id }, userModel);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return BadRequest(result.Errors);
        }

        [HttpPut("admin/{userName}")]
        public async Task<IActionResult> SetAdmin(string userName)
        {
            await _identityService.SetAdmin(userName);

            return Ok();
        }
    }
}