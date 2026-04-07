namespace test_For_Microtik.Application.Role.Command
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using test_For_Microtik.Application.Common;
    using test_For_Microtik.Domain.Entities;
    using test_For_Microtik.Infrastructure;

    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Result<int>>
    {
        private readonly AppDbContext _context;

        public CreateRoleCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            // تحقق إذا الدور موجود
            if (await _context.Roles.AnyAsync(r => r.Name == request.Name, cancellationToken))
                return Result<int>.Failure("Role already exists");

            var role = new Role
            {
                Name = request.Name
            };

            _context.Roles.Add(role);
            await _context.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(role.Id);
        }
    }
}
