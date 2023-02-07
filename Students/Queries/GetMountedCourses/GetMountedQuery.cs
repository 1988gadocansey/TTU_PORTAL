using MediatR;
using Students.Entities.Dto;
namespace Students.Queries.GetMountedCourses;

public class GetMountedQuery : IRequest<IEnumerable<MountedCourseDto>>
{
}