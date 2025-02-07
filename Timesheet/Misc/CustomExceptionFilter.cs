using Timesheet.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Timesheet.Misc
{
    [CustomExceptionFilter]
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new BadRequestObjectResult(new ErrorObjectDto { ErrorNumber = 500, Message = context.Exception.Message });

        }
    }
}
