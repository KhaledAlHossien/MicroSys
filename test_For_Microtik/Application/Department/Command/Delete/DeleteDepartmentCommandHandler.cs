namespace test_For_Microtik.Application.Department.Command.Delete
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using test_For_Microtik.Application.Common;
    using test_For_Microtik.Infrastructure;

    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, Result<bool>>
    {
        private readonly AppDbContext _context;

        public DeleteDepartmentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<bool>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _context.Departments.FindAsync(new object[] { request.Id }, cancellationToken);

            if (department == null)
                return Result<bool>.Failure("Department not found");

            _context.Departments.Remove(department);

            await _context.SaveChangesAsync(cancellationToken);

            return Result<bool>.Success(true);
        }
    }
}