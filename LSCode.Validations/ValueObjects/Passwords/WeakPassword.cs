﻿using LSCode.Validations.NotifiableValidations;
using LSCode.Validations.SimpleValidations;
using System;

namespace LSCode.Validations.ValueObjects.Passwords
{
    /// <summary>Assists in the use and validation of passwords.</summary>
    public class WeakPassword : Notifier
    {
        /// <value>Password.</value>
        public string Value { get; private set; }

        /// <summary>WeakPassword class constructor.</summary>
        /// <remarks>It must contain at least six and at most fifteen characters; One letter; A number.</remarks>
        /// <param name="value">Password.</param>
        /// <returns>Creates an instance of the WeakPassword class.</returns>
        public WeakPassword(string value)
        {
            try
            {
                Value = value;

                if (string.IsNullOrWhiteSpace(Value))
                    AddNotification("Password", "Password cannot be null or empty");
                else
                {
                    if (!BooleanValidations.HasMinimumLength(value, 6))
                        AddNotification("Password", "Password must contain at least 6 characters");

                    if (!BooleanValidations.HasMaximumLength(value, 15))
                        AddNotification("Password", "Password must contain a maximum of 15 characters");

                    if (!BooleanValidations.ContainsLetter(value))
                        AddNotification("Password", "Password must contain at least 1 capital letter ou minúscula");

                    if (!BooleanValidations.ContainsNumber(value))
                        AddNotification("Password", "Password must contain at least 1 number");
                }
            }
            catch (Exception ex)
            {
                AddNotification("Password", $"Error: {ex.Message}");
            }
        }

        /// <summary>Return password.</summary>
        public override string ToString() => Value;
    }
}