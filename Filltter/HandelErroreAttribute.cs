using Microsoft.AspNetCore.Mvc.Filters;

namespace AdvProject.Filltter
{
    public class HandelErroreAttribute :Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
           
        }
    }
}
