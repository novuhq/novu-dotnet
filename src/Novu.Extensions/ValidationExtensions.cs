using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Novu.Extensions;

public static class ValidationExtensions
{
    public static bool IsValid<T>(
        this T model,
        out ICollection<ValidationResult> results,
        bool validateAllProperties = true)
    {
        results = new List<ValidationResult>();
        return Validator.TryValidateObject(model, new ValidationContext(model), results, validateAllProperties);
    }
}