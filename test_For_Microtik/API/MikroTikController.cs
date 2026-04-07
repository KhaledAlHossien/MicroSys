using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_For_Microtik.Application.Interfaces;


namespace test_For_Microtik.API
{
    [ApiController]
    [Route("api/mikrotik")]
    public class MikroTikController : ControllerBase
    {
        private readonly IMikroTikService _mikroTikService;

        public MikroTikController(IMikroTikService mikroTikService)
        {
            _mikroTikService = mikroTikService;
        }

        [HttpGet("hotspot-users")]
        public async Task<IActionResult> GetHotspotUsers()
        {
            var users = await _mikroTikService.GetHotspotUsersAsync();

            return Ok(users);
        }

        [HttpGet("hotspot-usersProfile")]
        public async Task<IActionResult> GetHotspotUsersProfile()
        {
            var users = await _mikroTikService.GetHotspotUsersProfileAsync();

            return Ok(users);
        }
    }


}
