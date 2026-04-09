namespace test_For_Microtik.Application.Department.Query.GetAll
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using test_For_Microtik.Application.Common;
    using test_For_Microtik.Domain.Entities;
    using test_For_Microtik.Infrastructure;

    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, Result<List<Department>>>
    {
        private readonly AppDbContext _context;

        public GetAllDepartmentsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<Department>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _context.Departments.ToListAsync(cancellationToken);

            return Result<List<Department>>.Success(departments);
        }
    }
}