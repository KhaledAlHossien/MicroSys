namespace test_For_Microtik.Application.Role.Command
{
    using MediatR;
    using test_For_Microtik.Application.Common;

    public record CreateRoleCommand(string Name) : IRequest<Result<int>>;
}
