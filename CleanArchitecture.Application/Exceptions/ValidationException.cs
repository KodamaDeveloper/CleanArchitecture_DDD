using FluentValidation.Results;

namespace CleanArchitecture.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException() : base("Se presentarón uno o más errores de validación")
        {
            Errors = new Dictionary<string, string[]>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage).ToDictionary(failuresGroup => failuresGroup.Key, failuresGroup => failuresGroup.ToArray());
        }

        public Dictionary<string, string[]> Errors { get; set; }
    }
}
