using System.Security.Claims;
using Students.Entities.Models;

namespace Students.Contracts;
public interface IUserAccessor { ClaimsPrincipal User { get; } }