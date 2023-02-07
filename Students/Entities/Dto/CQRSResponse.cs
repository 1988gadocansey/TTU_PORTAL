using System.Net;

namespace Students.Entities.Dto;
public record CQRSResponse
{
    public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
    public string ErrorMessage { get; init; }
}