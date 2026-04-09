using MediatR;
using Microsoft.EntityFrameworkCore;
using test_For_Microtik.Application.Common;
using test_For_Microtik.Domain.Entities;
using test_For_Microtik.Infrastructure;

namespace test_For_Microtik.Application.Users.Query.GetAll
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, Result<List<User>>>
    {
        private readonly AppDbContext _context;

        public GetUsersHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<User>>> Handle(GetUsersQuery request, CancellationToken ct)
        {
            var users = await _context.Users
                .Include(x => x.Role)
                .Include(x => x.Department)
                .ToListAsync(ct);

            return Result<List<User>>.Success(users);
        }
    }
}
