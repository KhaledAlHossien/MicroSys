namespace test_For_Microtik.Application.Department.Query.GetAll
{
    using MediatR;
    using test_For_Microtik.Application.Common;
    using test_For_Microtik.Domain.Entities;

    public record GetAllDepartmentsQuery() : IRequest<Result<List<Department>>>;
}