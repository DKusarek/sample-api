using FluentValidation;
using hp_api.Contracts.Requests;
using FastEndpoints;

namespace hp_api.Validators
{
    public class IceCreamRequestValidator: Validator<IceCreamRequest>
    {
        public IceCreamRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(x => x.Weight)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
