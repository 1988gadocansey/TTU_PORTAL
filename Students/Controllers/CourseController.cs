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
        private IUnitOfWork _unitOfWork;
        private ICalenderRepository _calenderRepository;

        private readonly RepositoryContext _repositoryContext;

        public CourseController(IRepositoryManager repository, IMapper mapper, RepositoryContext repositoryContext, ICalenderRepository calenderRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryContext = repositoryContext;
            _unitOfWork = unitOfWork;
            _calenderRepository = calenderRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {

            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity?.FindFirst(ClaimTypes.Name)?.Value;

            var student = _repository.Student.GetStudentDetails(userId);


            var courses = _repository.MountedCourse.GetAllCourses(trackChanges: false)

                        .Where(a => a.COURSE_YEAR == _calenderRepository.GetCalender(false).YEAR)
                         .Where(a => a.COURSE_SEMESTER == Convert.ToInt32(_calenderRepository.GetCalender(false).SEMESTER))
                        .Where(a => a.PROGRAMME == student?.PROGRAMMECODE)
                        .Where(a => a.COURSE_LEVEL == student?.LEVEL);



            var coursesdto = _mapper.Map<IEnumerable<MountedCourseDto>>(courses);


            return await courses;


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