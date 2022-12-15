using AquiEstoy_MongoDB.Exceptions;
using AquiEstoy_MongoDB.Models;
using AquiEstoy_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquiEstoy_MongoDB.Controllers
{
    [Route("api/lostPetsPosts")]
    public class LostPetsSUPostsController : ControllerBase
    {
        private ILostPetPostService _lostPetsSUPostsService;

        public LostPetsSUPostsController(ILostPetPostService publicationService)
        {
            _lostPetsSUPostsService = publicationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LostPetPostModel>>> GetLostPetsSUPosts()
        {
            try
            {
                return Ok(await _lostPetsSUPostsService.GetAllLostPetsSUPostsAsync());
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
        public async Task<ActionResult<UserModel>> GetLostPetSUPostAsync(string postId)
        {
            try
            {
                var post = await _lostPetsSUPostsService.GetLostPetSUPostAsync(postId);
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
