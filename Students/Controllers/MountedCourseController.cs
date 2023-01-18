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
        private IUnitOfWork _unitOfWork;
        private ICalenderRepository _calenderRepository;

        private readonly RepositoryContext _repositoryContext;

        public MountedCourseController(IRepositoryManager repository, IMapper mapper, RepositoryContext repositoryContext, ICalenderRepository calenderRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryContext = repositoryContext;
            _unitOfWork = unitOfWork;
            _calenderRepository = calenderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMountedCourses()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity?.FindFirst(ClaimTypes.Name)?.Value;

            var student = _repository.Student.GetStudentDetails(userId);

            var courses = _repository.MountedCourse.GetAllCourses(trackChanges: false, Convert.ToInt32(_calenderRepository.GetCalender(false).SEMESTER), student?.LEVEL, student?.PROGRAMMECODE, _calenderRepository.GetCalender(false).YEAR);

            return Ok(courses);

        }



    }
}