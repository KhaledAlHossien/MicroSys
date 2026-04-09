namespace test_For_Microtik.Application.Department.Query.GetById
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using test_For_Microtik.Application.Common;
    using test_For_Microtik.Domain.Entities;
    using test_For_Microtik.Infrastructure;

    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, Result<Department>>
    {
        private readonly AppDbContext _context;

        public GetDepartmentByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Department>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

            if (department == null)
                return Result<Department>.Failure("Department not found");

            return Result<Department>.Success(department);
        }
    }
}