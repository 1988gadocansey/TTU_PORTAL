using System.Security.Claims;
using AutoMapper;
using Students.Contracts;
using Students.Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Students.Repository;

namespace Students.Controllers
{
    [Route("api/courses")]
   
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

              private readonly RepositoryContext _repositoryContext;
        
        public CourseController(IRepositoryManager repository, IMapper mapper, RepositoryContext repositoryContext)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryContext=repositoryContext;
        }

         [HttpGet]
        public IActionResult GetCourses()
        {
              
                var user = User.FindFirst(ClaimTypes.NameIdentifier);
                var claims = User.Claims;

                var courses = _repository.MountedCourse.GetAllCourses(trackChanges: false);

                var coursesdto = _mapper.Map<IEnumerable<MountedCourseDto>>(courses);
              
                

                return Ok(coursesdto);
           
        } 
         /*   [HttpGet]
        public IQueryable<MountedCourseDto> GetCourses()
{
    var books = from b in _repositoryContext.MountedCourses
                select new MountedCourseDto()
                {
                    CourseName = b.Course.COURSE_NAME,
                    CourseCode = b.Course.COURSE_CODE
                     
                };

    return books;
} */

       
    }
}