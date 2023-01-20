using MediatR;
using Students.Entities.DataTransferObjects;
namespace Students.Queries.GetMountedCourses;

public class GetMountedQuery : IRequest<IList<MountedCourseDto>>
{
}