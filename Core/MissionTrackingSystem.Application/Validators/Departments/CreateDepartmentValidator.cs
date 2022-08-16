using FluentValidation;
using MissionTrackingSystem.Application.ViewModels.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Application.Validators.Departments
{
    public class CreateDepartmentValidator: AbstractValidator<VM_Create_Department>
    {
        public CreateDepartmentValidator()
        {
            RuleFor(d => d.DepartmentName)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen departman adını boş geçmeyiniz. ")
                .MaximumLength(150)
                .MinimumLength(2)
                    .WithMessage("Lütfen departman adını 2 ile 50 arasında girin");
        }           
    }
}
