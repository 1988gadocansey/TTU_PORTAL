using Students.Entities.DataTransferObjects;
using MediatR;
using Students.Contracts;
using Students.Repository;
using AutoMapper;
using System.Security.Claims;
using Students.Exceptions;

namespace Students.Queries.GetMountedCourses;

public class GetMountedCourseHandler : IRequestHandler<GetMountedQuery, IEnumerable<MountedCourseDto>>
{


    private readonly RepositoryContext _dbContext;
    private ICalenderRepository _calenderRepository;
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly IUserAccessor _userAccessor;


    public GetMountedCourseHandler(RepositoryContext dbContext, ICalenderRepository calenderRepository, IRepositoryManager repository, IMapper mapper, IUserAccessor userAccessor)
    {

        _dbContext = dbContext;
        _calenderRepository = calenderRepository;
        _repository = repository;
        _mapper = mapper;
        _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
    }

    public async Task<IEnumerable<MountedCourseDto>> Handle(GetMountedQuery request, CancellationToken cancellationToken)
    {

        var claimsIdentity = _userAccessor.User;
        var userId = claimsIdentity?.FindFirst(ClaimTypes.Name)?.Value;

        var student = await _repository.Student.GetStudentDetails(userId, cancellationToken);

        var calender = await _calenderRepository.GetCalender();

        var courses = await _repository.MountedCourse.GetAllCourses(Convert.ToInt32(calender.SEMESTER), student?.LEVEL, student?.PROGRAMMECODE, calender.YEAR, cancellationToken);

        var coursesVm = _mapper.Map<IEnumerable<MountedCourseDto>>(courses);

        if (coursesVm == null) throw new NotFoundException(nameof(MountedCourseDto), request.ToString());
        return coursesVm;
    }

}
