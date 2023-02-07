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

[Route("api/activities")]
[Authorize]
[ApiController]
public class LogController : ControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<HomeController> _logger;
    private IUnitOfWork _unitOfWork;
    private readonly RepositoryContext _repositoryContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogController(IRepositoryManager repository, IMapper mapper, RepositoryContext repositoryContext, ILogger<HomeController> logger, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _mapper = mapper;
        _repositoryContext = repositoryContext;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }


    [Produces("application/json")]
    public async Task<IActionResult> GetLogAsync()
    {

        var claimsIdentity = this.User.Identity as ClaimsIdentity;
        var userId = claimsIdentity?.FindFirst(ClaimTypes.Name)?.Value;
        var events = _repository.Event.GetAllEvent(false, userId);
        //var logs = _mapper.Map<EventDto>(events);
        var log = new Event
        {
            student = userId,
            eventType = EventTypes.LoggedIn,
            activities = "Accessed user activities",
            hostname = Dns.GetHostEntry(HttpContext.Connection.RemoteIpAddress).HostName,
            usergent = $"{this.Request?.HttpContext?.Request?.Headers["user-agent"]}",
            ipaddress = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
        };
        _repository.Event.SaveEvent(false, log);
        await _unitOfWork.CommitAsync();

        return Ok(events);

    }


}