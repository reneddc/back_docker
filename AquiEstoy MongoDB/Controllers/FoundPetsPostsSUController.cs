using AquiEstoy_MongoDB.Exceptions;
using AquiEstoy_MongoDB.Models;
using AquiEstoy_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquiEstoy_MongoDB.Controllers
{
    [Route("api/foundPetsPosts")]
    public class FoundPetsPostsSUController : ControllerBase
    {
        private IFoundPetPostService _foundPetsSUPostsService;

        public FoundPetsPostsSUController(IFoundPetPostService foundPetSUPostService)
        {
            _foundPetsSUPostsService = foundPetSUPostService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoundPetPostModel>>> GetFoundPetsSUPosts()
        {
            try
            {
                return Ok(await _foundPetsSUPostsService.GetAllFoundPetsSUPostsAsync());
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
        public async Task<ActionResult<FoundPetPostModel>> GetFoundPetSUPostAsync(string postId)
        {
            try
            {
                var post = await _foundPetsSUPostsService.GetFoundPetSUPostAsync(postId);
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
    }
}
