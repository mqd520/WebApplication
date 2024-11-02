using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc.Filters;

using WebApplication13.Exceptions;

namespace WebApplication13.Filters
{
    public class ValidatorFilter : IActionFilter
    {
        private readonly IServiceProvider _serviceProvider;
        private Type _validatorType;
        private Type _dtoType;

        public ValidatorFilter(IServiceProvider serviceProvider
            , Type validatorType
            , Type dtoType)
        {
            _serviceProvider = serviceProvider;
            _validatorType = validatorType;
            _dtoType = dtoType;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var param = context.ActionArguments
                                .Where(x => x.Value?.GetType() == _dtoType)
                                .Select(x => x.Value)
                                .FirstOrDefault();
                if (param != null)
                {
                    object instance = _serviceProvider.GetRequiredService(_validatorType);
                    var mi = _validatorType.GetMethod("Validate", [_dtoType]);
                    var result = (ValidationResult?)mi?.Invoke(instance, [param]);
                    if (!(result?.IsValid ?? true))
                    {
                        string errors = string.Join(", ", result?.Errors ?? []);
                        throw new ValidationFailureException(errors);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
