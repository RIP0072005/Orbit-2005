using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Orbit_2005.Filters
{
    public class AdminAuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 1. بنقرا الكوكي اللي اسمها Role
            var userRole = context.HttpContext.Request.Cookies["Role"];

            // 2. بنتشيك لو الكوكي فاضية أو قيمتها مش الباسورد السري بتاعنا
            if (string.IsNullOrEmpty(userRole) || userRole != "Bofteek")
            {
                // 3. بنعمله بلوك ونرجعله 404 كأن الصفحة مش موجودة
                context.Result = new NotFoundResult();
            }

            // لو الكوكي طلعت بوفيتك، الكود هيكمل عادي والأكشن هيشتغل
            base.OnActionExecuting(context);
        }
    }
}
