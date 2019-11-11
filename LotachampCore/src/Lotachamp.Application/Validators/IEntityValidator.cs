using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Application.Validators
{
    public interface IEntityValidator<T>
    {
        /// <summary>
        /// Applies validation rules for creation
        /// </summary>
        /// <returns></returns>
        IValidationResult ValidateForCreate(T entity);

        /// <summary>
        /// Applies validation rules for creation
        /// </summary>
        /// <returns></returns>
        IValidationResult ValidateForUpdate(T entity);

        /// <summary>
        /// Validation result. Throws null if no validation has been done.
        /// </summary>
        IValidationResult Result { get; }
    }
}
