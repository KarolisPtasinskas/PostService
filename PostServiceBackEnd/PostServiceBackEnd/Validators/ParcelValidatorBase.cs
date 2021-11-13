using FluentValidation;
using PostServiceBackEnd.DTO;
using System;

namespace PostServiceBackEnd.Validators
{
    public class ParcelValidatorBase<T> : AbstractValidator<T> where T : ParcelDTO
    {
        public ParcelValidatorBase()
        {
            RuleFor(p => p.Weight)
                .Must(BeValidNumber)
                .WithMessage("'Weight' must be number and in grams (e.g. 300, 1200, 5200)");

            RuleFor(p => p.Phone)
                .Cascade(CascadeMode.Stop)
                .Must(BeValidNumber)
                .WithMessage("Please correct 'Phone' number.")
                .DependentRules(() =>
                {
                    RuleFor(p => p.Phone)
                    .Must(CountChars)
                    .WithMessage("'Phone' number must have 8 characters.");
                });

            RuleFor(p => p.ParcelMachineId)
                .Must(BeValidNumber)
                .WithMessage("Please select parcel machine");
        }

        private bool BeValidNumber(string amount)
        {
            if (amount == null || amount == "")
            {
                return false;
            }

            foreach (char c in amount)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            var number = Int32.Parse(amount);

            if (number < 1 || number > 69999999)
            {
                return false;
            }

            return true;
        }

        private bool CountChars(string number)
        {
            if (number.Length != 8)
            {
                return false;
            }
            return true;
        }
    }
}
