﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace WindowsFormsApplication2
{
    public class TextBoxNotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string str = value as string;
            if (str != null)
            {
                if (str.Length > 0)
                    return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Validation error. Field input required.");
        }

        public String Message { get; set; }
    }
}
