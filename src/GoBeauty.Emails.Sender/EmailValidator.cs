using FluentValidation;

namespace GoBeauty.Emails.Sender
{
    internal class EmailValidator : AbstractValidator<Email>
    {
        private const string InvalidEmailMessage = "Invalid email, please check and try again.";
        private const string BurstMaximumLength = "The {PropertyName} field has exceeded the maximum number of characters allowed.";
        private const string BelowMinimumSize = "The {PropertyName} field has not reached the minimum number of characters allowed.";
        private const string CannotBeNullOrEmpty = "The {PropertyName} field must be informed.";

        public EmailValidator()
        {
            RuleForEach(x => x.To)
                .EmailAddress()
                .WithMessage(InvalidEmailMessage);

            RuleFor(x => x.From)
                .EmailAddress()
                .WithMessage(x => $"{InvalidEmailMessage} {x.From}");

            RuleFor(x => x.Subject)
                .MinimumLength(2)
                .WithMessage(BelowMinimumSize)
                .MaximumLength(30)
                .WithMessage(BurstMaximumLength)
                .NotNull()
                .WithMessage(CannotBeNullOrEmpty)
                .NotEmpty()
                .WithMessage(CannotBeNullOrEmpty);

            RuleFor(x => x.Body)
                .NotNull()
                .WithMessage(CannotBeNullOrEmpty)
                .NotEmpty()
                .WithMessage(CannotBeNullOrEmpty);
        }
    }
}
