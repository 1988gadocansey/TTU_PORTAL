using System.Security.Claims;
using AutoMapper;
using Students.Contracts;
using Students.Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Students.Repository;
using Students.Entities.Models;
using Students.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace Students.Controllers;

[Route("api/dashboard")]
[Authorize]
[ApiController]
public class HomeController : ControllerBase
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
    public IActionResult GetDashboard()
    {


        var claimsIdentity = this.User.Identity as ClaimsIdentity;
        var userId = claimsIdentity?.FindFirst(ClaimTypes.Name)?.Value;

        var student = _repository.Student.GetStudentDetails(userId);

        var studentinfo = _mapper.Map<DashBoardDto>(student);

        _logger.LogInformation("Student visited dashboard details " + studentinfo.Programme);

        var calender = _repository.Calender.GetCalender(trackChanges: false);

        var calenderdto = _mapper.Map<IEnumerable<CalenderDto>>(calender);

        // lets created event of login
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
                studentinfo = studentinfo
            });


    }


}