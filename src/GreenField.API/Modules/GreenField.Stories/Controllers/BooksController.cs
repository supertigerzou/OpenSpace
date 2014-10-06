using GreenField.Books.Services;
using GreenField.Books.ViewModels;
using System.Linq;
using System.Web.Http;

namespace GreenField.Books.Controllers
{
    [RoutePrefix("api/Stories")]
    public class StoriesController : ApiController
    {
        private readonly IStoryService _storyService;

        public StoriesController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_storyService.GetAll().Select(story => new StoryViewModel
                {
                    Name = story.Name,
                    Teller = story.Teller.FirstName + " " + story.Teller.LastName
                }));
        }
    }
}
