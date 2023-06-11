using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandValidation : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidation()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Nombre} no puede superar 50 char");


            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("la {URL} no puede estar en blanco");
        }
    }
}
