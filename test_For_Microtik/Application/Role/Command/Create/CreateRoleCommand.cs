namespace test_For_Microtik.Application.Role.Command.Create
{
    using MediatR;
    using test_For_Microtik.Application.Common;
    using test_For_Microtik.Domain.Entities;

    public record CreateRoleCommand(string Name) : IRequest<Result<Role>>;
}
