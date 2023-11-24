using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDtoValidator : AbstractValidator<CarWorkshopDto>
    {
        public CarWorkshopDtoValidator(ICarWorkshopRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Imię jest wymagane.")
                .MinimumLength(2).WithMessage("Imię powinno mięc minimum 2 znaki.")
                .MaximumLength(20).WithMessage("Imię powinnie mieć maksymalnie 20 znaków.")
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = repository.GetByName(value).Result;
                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure($"{value} nie jest unikalną nazwą dla warsztatu");
                    }
                });

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Podaj opis.");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
