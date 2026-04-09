namespace test_For_Microtik.Application.Department.Command.Create
{
    using FluentValidation;

    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Department name is required");
        }
    }
}
