using System.Globalization;
using AutoMapper;
using MediatR;
using Students.Contracts;
using Students.Repository;
using Students.Entities.Models;

namespace Students.Commands.CourseRegistration;
public record CreateCourseRegistrationCommand : IRequest<Unit>
{
    public int courseId { get; init; }
    public string? courseCode { get; init; }
    public string? courseLevel { get; init; }
    public int? courseCredit { get; init; }
    public string? courseType { get; init; }
    public string? courseName { get; init; }

}
public class RegisterCourseCommandHandler : IRequestHandler<CreateCourseRegistrationCommand, Unit>
{
    private readonly RepositoryContext _dbContext;
    private readonly IRepositoryManager _repository;
    private readonly ICalenderRepository _calenderRepository;
    private readonly IUserAccessor _userAccessor;
    // private readonly ICurrentUserService _currentUserService;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCourseCommandHandler(IUserAccessor userAccessor, RepositoryContext dbContext, ICalenderRepository calenderRepository, IRepositoryManager repository, IUnitOfWork unitOfWork)
    {
        _userAccessor = userAccessor;
        _calenderRepository = calenderRepository;
        _dbContext = dbContext;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateCourseRegistrationCommand request, CancellationToken cancellationToken)
    {
        var calender = await _calenderRepository.GetCalender();
        var student = _userAccessor.User ?? throw new ArgumentNullException("_userAccessor.User");
        var studentDetails = await _repository.Student.GetStudentDetails(student.ToString(), cancellationToken);
        if (studentDetails == null) throw new ArgumentNullException(nameof(studentDetails));

        var courseRegistration = new AcademicRecord();
        if (courseRegistration == null) throw new ArgumentNullException(nameof(courseRegistration));
        /*  CourseRegistration.COURSE = request.CourseId;
         CourseRegistration.COURSE_CREDIT = request.CourseCredit;
         CourseRegistration.COURSE_LEVEL = request.CourseLevel;
         CourseRegistration.COURSE_SEMESTER = Convert.ToInt16(Calender.SEMESTER);
         CourseRegistration.COURSE_YEAR = Calender.YEAR; */
        courseRegistration.course = request.courseId;
        courseRegistration.dateRegistered = Convert.ToString(DateTime.UtcNow, CultureInfo.InvariantCulture);
        courseRegistration.student = studentDetails.ID;
        courseRegistration.sem = calender.SEMESTER;
        courseRegistration.year = calender.YEAR;
        courseRegistration.yrgp = studentDetails.GRADUATING_GROUP;
        courseRegistration.grade = 'F';
        courseRegistration.gpoint = 0.0M;
        courseRegistration.level = studentDetails.LEVEL;
        courseRegistration.lecturer = 1201610;
        await _dbContext.AcademicRecords.AddAsync(courseRegistration);
        await _dbContext.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitAsync();
        return Unit.Value;
    }
}
