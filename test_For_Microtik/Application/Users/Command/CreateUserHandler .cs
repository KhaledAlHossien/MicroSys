using BCrypt.Net;
using MediatR;
using test_For_Microtik.Application.Common;
using test_For_Microtik.Domain.Entities;
using test_For_Microtik.Infrastructure;

namespace test_For_Microtik.Application.Users.Command
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<int>>
    {
        private readonly AppDbContext _context;

        public CreateUserHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken ct)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                RoleId = request.RoleId,
                DepartmentId = request.DepartmentId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(ct);

            return Result<int>.Success(user.Id);
        }
    }
}
