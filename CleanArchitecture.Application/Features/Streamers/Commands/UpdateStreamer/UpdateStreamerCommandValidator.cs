using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidator()
        {
            RuleFor(p => p.Name)
             .NotNull().WithMessage("{Nombre} no puede estar null");

            RuleFor(p => p.Url)
             .NotNull().WithMessage("{Url} no puede estar null");

        }
    }
}
