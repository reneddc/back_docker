using AquiEstoy_MongoDB.Exceptions;
using AquiEstoy_MongoDB.Models;
using AquiEstoy_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquiEstoy_MongoDB.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUserAsync([FromBody] UserModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var newUser = await _userService.CreateUserAsync(user);
                return Created($"/users/{newUser.Id}", newUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something happend.");
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserModel>> GetUserAsync(string userId)
        {
            try
            {
                var user = await _userService.GetUserAsync(userId);
                return Ok(user);
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something happend.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsersAsync()
        {
            try
            {
                var allUsers = await _userService.GetAllUsersAsync();
                return Ok(allUsers);
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserAsync(string userId, [FromBody] UserModel userModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var pair in ModelState)
                    {
                        if (pair.Key == nameof(userModel.FirstName) && pair.Value.Errors.Count > 0)
                        {
                            return BadRequest(pair.Value.Errors);
                        }
                    }
                }
                await _userService.UpdateUserAsync(userId, userModel);
                return Ok();
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message); ;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUsersAsync(string userId)
        {
            try
            {
                await _userService.DeleteUserAsync(userId);
                return Ok();
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something happend.");
            }
        }

    }
}
