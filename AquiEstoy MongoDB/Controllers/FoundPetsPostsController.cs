using AquiEstoy_MongoDB.Exceptions;
using AquiEstoy_MongoDB.Models;
using AquiEstoy_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquiEstoy_MongoDB.Controllers
{
    [Route("api/users/{userId}/foundPetsPosts")]
    public class FoundPetsPostsController : ControllerBase
    {
        private IFoundPetPostService _foundPetsPostsService;

        public FoundPetsPostsController(IFoundPetPostService foundPetPostService)
        {
            _foundPetsPostsService = foundPetPostService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoundPetPostModel>>> GetFoundPetsPosts(string userId)
        {
            try
            {
                return Ok(await _foundPetsPostsService.GetAllFoundPetsPostsAsync(userId));
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

        [HttpGet("{postId}")]
        public async Task<ActionResult<FoundPetPostModel>> GetFoundPetPostAsync(string postId)//only one
        {
            try
            {
                var post = await _foundPetsPostsService.GetFoundPetPostAsync(postId);
                return Ok(post);
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

        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePetAsync(string postId, string userId, [FromBody] FoundPetPostModel foundPetPostModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var pair in ModelState)
                    {
                        if (pair.Key == nameof(foundPetPostModel.UserID) && pair.Value.Errors.Count > 0)
                        {
                            return BadRequest(pair.Value.Errors);
                        }
                    }
                }
                await _foundPetsPostsService.UpdateFoundPetPostAsync(userId, postId, foundPetPostModel);
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
        [HttpDelete("{postId}")]
        public async Task<ActionResult> DeleteFoundPetPostAsync(string postId, string userId)
        {
            try
            {
                await _foundPetsPostsService.DeleteFoundPetPostAsync(postId, userId);
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
        [HttpPost]
        public async Task<ActionResult<FoundPetPostModel>> CreateFoundPetsPostsAsync([FromBody] FoundPetPostModel foundPetPostModel, string userId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var newPublication = await _foundPetsPostsService.CreateFoundPetPostAsync(foundPetPostModel, userId);
                return Created($"/users/{newPublication.UserID}/{newPublication.IdFoundPetPost}", newPublication);
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
