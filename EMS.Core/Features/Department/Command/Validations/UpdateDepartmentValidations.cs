using EMS.Core.Features.Departments.Command.Request;
using FluentValidation;
namespace EMS.Core.Features.Departments.Command.Validations
{
    public class UpdateDepartmentValidations : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentValidations()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(0);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(5).MaximumLength(15);
            RuleFor(x => x.Manager).NotEmpty().MinimumLength(10).MaximumLength(15);
        }
    }

}
