namespace test_For_Microtik.Application.Department.Command.Delete
{
    using MediatR;
    using test_For_Microtik.Application.Common;

    public record DeleteDepartmentCommand(int Id) : IRequest<Result<bool>>;
}