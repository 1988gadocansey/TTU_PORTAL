using System.Security.Claims;
using AutoMapper;
using Students.Contracts;
using Students.Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Students.Repository;

namespace Students.Controllers
{
    [Route("api/courses/mounted")]
   
    [ApiController]
    public class MountedCourseController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

              private readonly RepositoryContext _repositoryContext;
        
        public MountedCourseController(IRepositoryManager repository, IMapper mapper, RepositoryContext repositoryContext)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryContext=repositoryContext;
        }

         [HttpGet]
        public IActionResult GetMountedCourses()
        {
              
                var user = User.FindFirst(ClaimTypes.NameIdentifier);
                var claims = User.Claims;

                var courses = _repository.MountedCourse.GetAllCourses(trackChanges: false);

                var coursesdto = _mapper.Map<IEnumerable<MountedCourseDto>>(courses);
              
                

                return Ok(coursesdto);
           
        } 
        

       
    }
}