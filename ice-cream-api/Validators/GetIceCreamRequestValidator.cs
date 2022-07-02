using FastEndpoints;
using FluentValidation;
using hp_api.Contracts.Requests;

namespace hp_api.Validators
{
    public class GetIceCreamRequestValidator: Validator<GetIceCreamRequest>
    {
        public GetIceCreamRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(x => x.Portions)
                .GreaterThan(0);
        }
    }
}
