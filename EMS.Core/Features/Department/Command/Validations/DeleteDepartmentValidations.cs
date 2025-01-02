using EMS.Core.Features.Departments.Command.Request;
using FluentValidation;
namespace EMS.Core.Features.Departments.Command.Validations
{
    public class DeleteDepartmentValidations : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentValidations()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(0);
        }
    }

}
