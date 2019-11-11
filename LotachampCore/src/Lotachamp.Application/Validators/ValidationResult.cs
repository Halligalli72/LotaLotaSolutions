using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Application.Validators
{
    public interface IValidationResult
    {
        ICollection<ValidationError> Errors { get; }
        bool Success { get; }
    }
    public class ValidationResult : IValidationResult
    {
        public ICollection<ValidationError> Errors { get; private set; }
        public ValidationResult()
        {
            Errors = new List<ValidationError>();
        }
        public bool Success
        {
            get { return Errors.Count == 0; }
        }
    }

}
