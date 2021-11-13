using FluentValidation;
using PostServiceBackEnd.DTO;
using System;

namespace PostServiceBackEnd.Validators
{
    public class ParcelMachineValidatorBase<T> : AbstractValidator<T> where T : ParcelMachineDTO
    {
        public ParcelMachineValidatorBase()
        {
            RuleFor(pm => pm.Town)
                .NotEmpty()
                .WithMessage("'Town' can't be empty");

            RuleFor(pm => pm.Address)
                .NotEmpty()
                .WithMessage("'Address' can't be empty");

            RuleFor(pm => pm.Capacity)
                .Must(BeValidNumber)
                .WithMessage("'Capacity' must be a whole number.");

            RuleFor(pm => pm.IdentificationCode)
                .NotEmpty()
                .WithMessage("'Iddentification code' can't be empty and must follow the rules. Contact the technical department for more details");
        }

        private bool BeValidNumber(string obj)
        {
            if (obj == null || obj == "")
            {
                return false;
            }

            foreach (char c in obj)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            var number = Int32.Parse(obj);

            if (number < 0)
            {
                return false;
            }

            return true;
        }
    }
}
