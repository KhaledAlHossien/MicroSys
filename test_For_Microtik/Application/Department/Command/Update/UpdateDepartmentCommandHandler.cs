namespace test_For_Microtik.Application.Department.Command.Update
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using test_For_Microtik.Application.Common;
    using test_For_Microtik.Domain.Entities;
    using test_For_Microtik.Infrastructure;

    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Result<Department>>
    {
        private readonly AppDbContext _context;

        public UpdateDepartmentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Department>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

            if (department == null)
                return Result<Department>.Failure("Department not found");

            if (await _context.Departments.AnyAsync(d => d.Name == request.Name && d.Id != request.Id, cancellationToken))
                return Result<Department>.Failure("Another department with the same name already exists");
            department.Name = request.Name;
            await _context.SaveChangesAsync(cancellationToken);

            return Result<Department>.Success(department);
        }
    }
}