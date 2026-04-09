namespace test_For_Microtik.Application.Department.Command.Update
{
    using MediatR;
    using test_For_Microtik.Application.Common;
    using test_For_Microtik.Domain.Entities;

    public record UpdateDepartmentCommand(int Id, string Name) : IRequest<Result<Department>>;
}