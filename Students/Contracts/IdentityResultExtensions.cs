using Microsoft.AspNetCore.Identity;
using Students.Entities.Models;

namespace Students.Contracts;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {

        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
