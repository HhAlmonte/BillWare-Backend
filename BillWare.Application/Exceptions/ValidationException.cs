﻿using FluentValidation.Results;

namespace BillWare.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException() : base("Se presentaron uno o más errores de validación")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(string message) : base(message)
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                     .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                     .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup
                     .ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }

}