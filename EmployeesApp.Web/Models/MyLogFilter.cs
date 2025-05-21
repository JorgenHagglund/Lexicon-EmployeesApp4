using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace EmployeesApp.Web.Models
{
    public class MyLogFilter(ILogger<MyLogFilter> logger) : ActionFilterAttribute
    {
        static Stopwatch _watch = null!;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _watch = Stopwatch.StartNew();
            logger.LogInformation($"{context.ActionDescriptor.DisplayName?.Split(' ')[0].Split(".").Last()} Actionen ska köras!");
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogWarning($"Den har körts! Det tog {_watch.ElapsedMilliseconds} ms");
        }
    }
}
