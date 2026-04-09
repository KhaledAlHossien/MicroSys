namespace test_For_Microtik.Application.Department.Command.Create
{
    using MediatR;
    using test_For_Microtik.Application.Common;
    using test_For_Microtik.Domain.Entities;

    public record CreateDepartmentCommand(string Name) : IRequest<Result<Department>>;
}
