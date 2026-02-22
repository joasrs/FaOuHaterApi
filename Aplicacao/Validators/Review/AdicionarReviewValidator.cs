using FluentValidation;

namespace Aplicacao.Validators.Review
{
    public class AdicionarReviewValidator : AbstractValidator<Dominio.Entidades.Review>
    {
        public AdicionarReviewValidator()
        {
            RuleFor(x => x.Artista)
                .NotEmpty().WithMessage("O artista é obrigatório.")
                .MaximumLength(255).WithMessage("O artista deve ter no máximo 255 caracteres.");
            RuleFor(x => x.Musica)
                .NotEmpty().WithMessage("A música obrigatória.")
                .MaximumLength(255).WithMessage("A música deve ter no máximo 255 caracteres.");
            RuleFor(x => x.Review1)
                 .NotEmpty().WithMessage("A descrição da review é obrigatória.")
                .MaximumLength(500).WithMessage("A descrição da review deve ter no máximo 500 caracteres.");
        }
    }
}
