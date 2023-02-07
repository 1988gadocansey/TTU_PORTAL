using System.Security.Claims;
using AutoMapper;
using Students.Contracts;
using Students.Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Students.Repository;
using Students.Entities.Models;
using Students.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace Students.Controllers;

[Route("api/dashboard")]
[Authorize]
public class HomeController : ApiControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<HomeController> _logger;
    private IUnitOfWork _unitOfWork;
    private readonly RepositoryContext _repositoryContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HomeController(IRepositoryManager repository, IMapper mapper, RepositoryContext repositoryContext, ILogger<HomeController> logger, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _mapper = mapper;
        _repositoryContext = repositoryContext;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public async Task<IActionResult> GetDashboard(CancellationToken cancellationToken)
    {

        var calender = await _repository.Calender.GetCalender();

        var calenderdto = _mapper.Map<CalenderDto>(calender);


        var claimsIdentity = this.User.Identity as ClaimsIdentity;
        var userId = claimsIdentity?.FindFirst(ClaimTypes.Name)?.Value;


        var student = await _repository.Student.GetStudentDetails(userId, cancellationToken);

        var studentinfo = _mapper.Map<DashBoardDto>(student);

        var payments = await _repository.Student.getTotalPaymentCurrent(student, calender, cancellationToken);

        var owing = await _repository.Student.GetTotalFeesCurrent(student, calender, cancellationToken);

        var issues = await _repository.Student.GetAllIssues(student, cancellationToken);

        var issuedDto = _mapper.Map<IEnumerable<IssuesDto>>(issues);


        var balance = owing - payments;

        //var paymentsDto = _mapper.Map<IEnumerable<PaymentDto>>(payments);

        // up coming lectures timetable
        var timetable = await _repository.TeachingTimeTable.GetUpComingLectures(student, Convert.ToInt16(calender.SEMESTER), calender.YEAR, cancellationToken);
        var timetableDto = _mapper.Map<IEnumerable<TeachingTimeTableDto>>(timetable);


        var log = new Event
        {
            student = userId,
            eventType = EventTypes.LoggedIn,
            activities = "Access Dashboard",
            hostname = Dns.GetHostEntry(HttpContext.Connection.RemoteIpAddress).HostName,
            usergent = $"{this.Request?.HttpContext?.Request?.Headers["user-agent"]}",
            ipaddress = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
        };
        _repository.Event.SaveEvent(false, log);
        _unitOfWork.Commit();
        return Ok(
            new
            {

                calenderdto = calenderdto,
                studentinfo = studentinfo,
                payments = payments,
                timetable = timetableDto,
                balance = balance,
                owing = owing,
                issues = issuedDto
            });


    }


}