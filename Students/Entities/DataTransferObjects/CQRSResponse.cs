using System.Net;

namespace Students.Entities.DataTransferObjects;
public record CQRSResponse
{
    public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
    public string ErrorMessage { get; init; }
}