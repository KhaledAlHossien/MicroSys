using MediatR;
using test_For_Microtik.Application.Common;
using test_For_Microtik.Domain.Entities;

namespace test_For_Microtik.Application.Users.Command.Create
{
    public record CreateUserCommand(
     string Name,
     string Email,
     string Password,
     int RoleId,
     int DepartmentId
 ) : IRequest<Result<User>>;
}
