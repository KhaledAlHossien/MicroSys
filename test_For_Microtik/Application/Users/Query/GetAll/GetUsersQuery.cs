using MediatR;
using test_For_Microtik.Application.Common;
using test_For_Microtik.Domain.Entities;

namespace test_For_Microtik.Application.Users.Query.GetAll
{
    public record GetUsersQuery() : IRequest<Result<List<User>>>;
}
