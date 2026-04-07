using MediatR;
using test_For_Microtik.Application.Common;

namespace test_For_Microtik.Application.Users.Command
{
    public record CreateUserCommand(
     string Name,
     string Email,
     string Password,
     int RoleId,
     int DepartmentId
 ) : IRequest<Result<int>>;
}
