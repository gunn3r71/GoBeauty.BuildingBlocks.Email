using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace GoBeauty.Emails.Sender
{
    public class Email
    {
        public Email(string[] to, string from, string subject, string body, bool isHtml)
        {
            To = to;
            From = from;
            Subject = subject;
            Body = body;
            IsHtml = isHtml;

            Validate();
        }

        public string[] To { get; private set; }
        public string From { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public bool IsHtml { get; private set; } = true;
        public List<IFormFile> Attachments { get; private set; } = new List<IFormFile>();

        public void AddAttachment(IFormFile attachment) => Attachments.Add(attachment);
        public void AddAttachments(IList<IFormFile> attachments) => Attachments.AddRange(attachments);

        private void Validate()
        {
            var result = new EmailValidator().Validate(this);

            if (result.Errors.Any())
                throw new EmailException(result.Errors.Select(x => x.ErrorMessage).Distinct());
        }
    }
}
