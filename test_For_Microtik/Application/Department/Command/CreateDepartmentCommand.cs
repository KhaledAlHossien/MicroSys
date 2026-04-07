namespace test_For_Microtik.Application.Department.Command
{
    using MediatR;
    using test_For_Microtik.Application.Common;

    public record CreateDepartmentCommand(string Name) : IRequest<Result<int>>;
}
