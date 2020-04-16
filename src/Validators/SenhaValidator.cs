using FluentValidation;
using System.Text.RegularExpressions;
using ValidaSenha.Models;

namespace ValidaSenha.Validators
{
    public class SenhaValidator : AbstractValidator<Senha>
    {
        public SenhaValidator()
        {
            RuleFor(x => x.input)
                .MinimumLength(9)
                .Must(FormatoVálido);
        }

        public bool éValida(Senha senha) 
            => this.Validate(senha).IsValid;

        private bool FormatoVálido(string senha) 
            => Regex.IsMatch(senha, "^.*(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\\W).*$");
    }
}
