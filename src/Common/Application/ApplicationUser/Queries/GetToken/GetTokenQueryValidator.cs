using FluentValidation;

namespace Application.ApplicationUser.Queries.GetToken
{
    public class GetTokenQueryValidator : AbstractValidator<GetTokenQuery>
    {
        public GetTokenQueryValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(100).WithMessage("O e-mail n�o deve ter mais de 100 caracteres.")
                .NotEmpty().WithMessage("Email � obrigat�rio.");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Senha � obrigat�rio.");
        }
    }
}
