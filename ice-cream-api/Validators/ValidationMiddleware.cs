using FluentValidation;
using hp_api.Contracts.Responces;

namespace hp_api.Validators
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ValidationMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (ValidationException validationException)
            {
                httpContext.Response.StatusCode = 400;
                var validationFailureResponse = new ValidationFailureResponse()
                {
                    Errors = validationException.Errors.Select(x => x.ErrorMessage).ToList()
                };
                await httpContext.Response.WriteAsJsonAsync(validationFailureResponse);
            }
        }
    }
}
