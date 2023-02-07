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
    private ICalenderRepository _calenderRepository;
    private readonly IUserAccessor _userAccessor;
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
        var Calender = await _calenderRepository.GetCalender();
        var Student = _userAccessor.User;
        var StudentDetails = await _repository.Student.GetStudentDetails(Student.ToString(), cancellationToken);

        var CourseRegistration = new AcademicRecord();
        /*  CourseRegistration.COURSE = request.CourseId;
         CourseRegistration.COURSE_CREDIT = request.CourseCredit;
         CourseRegistration.COURSE_LEVEL = request.CourseLevel;
         CourseRegistration.COURSE_SEMESTER = Convert.ToInt16(Calender.SEMESTER);
         CourseRegistration.COURSE_YEAR = Calender.YEAR; */
        CourseRegistration.course = request.courseId;
        CourseRegistration.dateRegistered = Convert.ToString(DateTime.UtcNow);
        CourseRegistration.student = StudentDetails.ID;
        CourseRegistration.sem = Calender.SEMESTER;
        CourseRegistration.year = Calender.YEAR;
        CourseRegistration.yrgp = StudentDetails.GRADUATING_GROUP;
        CourseRegistration.grade = 'F';
        CourseRegistration.gpoint = 0.0M;
        CourseRegistration.level = StudentDetails.LEVEL;
        CourseRegistration.lecturer = 1201610;
        await _dbContext.AcademicRecords.AddAsync(CourseRegistration);
        await _dbContext.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitAsync();
        return Unit.Value;
    }
}
