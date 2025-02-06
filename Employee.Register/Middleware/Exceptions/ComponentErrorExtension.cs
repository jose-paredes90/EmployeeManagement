using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Employee.Register.Middleware.Exceptions
{
    public static class ComponentErrorExtension
    {
        public static ComponentError FromModelState(this ComponentError ce, ModelStateDictionary modelState)
        {
            foreach (var item in modelState)
            {
                foreach (var error in item.Value.Errors)
                    ce.AddModelError(item.Key, error.Exception, errorCode: null, message: error.ErrorMessage);
            }

            return ce;
        }
    }
}
