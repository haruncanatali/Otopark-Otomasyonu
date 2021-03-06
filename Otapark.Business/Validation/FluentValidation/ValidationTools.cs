﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otapark.Business.Validation.FluentValidation
{
    public static class ValidationTools
    {
        public static void Validate(IValidator validator,Object entity)
        {
            var result = validator.Validate(entity);
            if (result.Errors.Count>0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
