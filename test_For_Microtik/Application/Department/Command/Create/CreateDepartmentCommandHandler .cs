namespace test_For_Microtik.Application.Department.Command.Create
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using test_For_Microtik.Application.Common;
    using test_For_Microtik.Domain.Entities;
    using test_For_Microtik.Infrastructure;

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Result<Department>>
    {
        private readonly AppDbContext _context;

        public CreateDepartmentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Department>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Departments.AnyAsync(d => d.Name == request.Name, cancellationToken))
                return Result<Department>.Failure("Department already exists");

            var department = new Department
            {
                Name = request.Name
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync(cancellationToken);

            return Result<Department>.Success(department);
        }
    }
}

