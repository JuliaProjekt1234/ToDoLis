using System.Security.Claims;

namespace ToDoList.Services;

public class UserHttpContextService: IUserHttpContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserHttpContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetUserId()
    {
        var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        return int.Parse(userIdClaim);
    }
}
