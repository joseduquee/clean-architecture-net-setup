using FluentValidation.Results;

namespace TimyApp.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
        : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
        public IDictionary<string, string[]> Errors { get; }


        //Otra forma
        //public List<string> ValidationErrors { get; set; }

        //public ValidationException(ValidationResult validationResult)
        //{
        //    ValidationErrors = new List<string>();

        //    foreach (var validationError in validationResult.Errors)
        //    {
        //        ValidationErrors.Add(validationError.ErrorMessage);
        //    }
        //}
    }
}
