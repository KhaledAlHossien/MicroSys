
namespace test_For_Microtik.Application.Department.Query
{
    using MediatR;
    using test_For_Microtik.Application.Common;
    using test_For_Microtik.Domain.Entities;
    public record GetDepartmentByIdQuery(int Id) : IRequest<Result<Department>>;
}