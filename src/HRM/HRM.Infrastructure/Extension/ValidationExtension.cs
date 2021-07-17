using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetCore.Objects;
using FluentValidation.Results;


namespace HRM.Infrastructure.Extension
{
    public static class ValidationExtension
    {
        public static string GetErrorMessage(this List<ValidationFailure> errors)
        {
            if (errors != null && errors.Count > 0)
            {
                return string.Join(",", errors.Select(m => m.ErrorMessage).ToArray());
            }
            return string.Empty;
        }
    }
}
