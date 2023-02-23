﻿using LSCode.Notifications.Models;
using LSCode.Validations.BooleanValidations.Extensions;
using System;

namespace LSCode.Validations.ValueObjects.Contacts
{
    /// <summary>Assists in the use, validation and formatting of telephone numbers.</summary>
    public class Telephone : Notifiable
    {
        /// <value>Telephone number.</value>
        public string Value { get; private set; }

        /// <summary>Telephone class constructor.</summary>
        /// <remarks>
        ///     Valid formats: 3238887777 ou 323888-7777 ou (32)38887777 ou (32)3888-7777. <br></br>
        ///     Output format: (32)3888-7777. <br></br>
        ///     Regex: ^(\(?)([0-9]{2})(\)?)[0-9]{4}-?[0-9]{4}$
        /// </remarks>
        /// <param name="value">Telephone number.</param>
        /// <returns>Create an instance of the Telephone class.</returns>
        public Telephone(string value)
        {
            Value = value;

            if (Value.IsNullOrEmptyOrWhiteSpace())
                AddNotification("Telephone", "Telephone cannot be null, empty or white espaces");
            else if (!Value.IsBrazilianTelephone())
                AddNotification("Telephone", "Invalid telephone");
            else
                Value = Format(value);
        }

        /// <summary>Format the Telephone number.</summary>
        /// <param name="value">Telephone number.</param>
        /// <returns>Telephone number in format: (32)3888-7777.</returns>
        private string Format(string value)
        {
            if (value.Length == 13)
            {
                return value;
            }
            else
            {
                value = value.Trim();
                value = value.Replace("(", "").Replace(")", "").Replace("-", "");
                value = Convert.ToUInt64(value).ToString(@"\(00\)0000\-0000");
                return value;
            }
        }

        /// <summary>Returns Telephone number.</summary>
        public override string ToString() => Value;
    }
}