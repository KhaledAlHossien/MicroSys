namespace test_For_Microtik.Application.Role.Command
{
    using FluentValidation;

    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Role name is required");
        }
    }
}
