using ALTIMETRIK.Application.ZipUsers.Dto;
using ALTIMETRIK.Domain.Entities;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ALTIMETRIK.ZipUserAPI.Validators
{
    public class ZipUserValidator : AbstractValidator<ZipUserDto>
    {
        public ZipUserValidator()
        {
            RuleFor(p => p.FirstName).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("{PropertyName} should not be empty !").Length(1, 50);
            RuleFor(p => p.LastName).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("{PropertyName} should not be empty !").Length(1, 50);
            RuleFor(p => p.Email).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().EmailAddress().WithMessage("{PropertyName} is not a valid Email!");
            RuleFor(p => p.JobTitle).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("{PropertyName} should not be empty !").Length(1, 20);
            RuleFor(p => p.Phone).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
       .NotEmpty()
       .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
       .MinimumLength(10).WithMessage("{PropertyName} must not be less than 10 characters.")
       .MaximumLength(20).WithMessage("{PropertyName} must not exceed 50 characters.")
       .Matches(new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")).WithMessage("{PropertyName} not valid");
            RuleFor(p => p.MonthlySalary).Must((model,field) => (model.MonthlySalary - model.MonthlyExpense) >= 1000 ).WithMessage("User is not eligible for Zip pay, User income should be greate than 1000$, Enter valid {PropertyName}");
        }

    }
}
