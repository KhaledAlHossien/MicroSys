namespace test_For_Microtik.Application.Department.Command
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using test_For_Microtik.Application.Common;
    using test_For_Microtik.Domain.Entities;
    using test_For_Microtik.Infrastructure;

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Result<int>>
    {
        private readonly AppDbContext _context;

        public CreateDepartmentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            // تحقق إذا القسم موجود
            if (await _context.Departments.AnyAsync(d => d.Name == request.Name, cancellationToken))
                return Result<int>.Failure("Department already exists");

            var department = new Department
            {
                Name = request.Name
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(department.Id);
        }
    }
}
