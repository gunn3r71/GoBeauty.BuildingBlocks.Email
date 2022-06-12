using System;
using System.Collections.Generic;

namespace GoBeauty.Emails.Sender
{
    public class EmailException : Exception
    {
        public bool HasValidationErrors { get; private set; }
        public IEnumerable<string> ValidationErrors { get; private set; }
        
        public EmailException()
        {
        }

        public EmailException(IEnumerable<string> validationErrors)
        {
            ValidationErrors = validationErrors;
            HasValidationErrors = true;
        }

        public EmailException(string message) : base(message) {}

        public EmailException(string message, Exception innerException) : base(message, innerException) {}
    }
}
