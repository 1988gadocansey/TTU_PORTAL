using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Students.Queries.GetMountedCourses;

namespace Students.Controllers
{
    [Route("api/courses")]
    [Authorize]
    [ApiController]
    public class MountedCourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MountedCourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMountedCourses()
        {
            var courses = await _mediator.Send(new GetMountedQuery());
            return Ok(courses);
        }
    }
}