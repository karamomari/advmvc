using Microsoft.AspNetCore.Mvc.Filters;

namespace AdvProject.Filltter
{
    public class MyCustomAttrbiute :Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
