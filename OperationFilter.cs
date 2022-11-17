using BBService.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBService.Filters
{
    public class OperationFilter : ActionFilterAttribute
    {
        private readonly BBServiceEntities _context;

        public OperationFilter(IBBServiceEntities context)
        {
            _context = context;
        }

        /// <summary>
        /// Custom filter if user can access or not
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool Access = false;
            string action = (string)filterContext.RouteData.Values["action"];
            int ActionId = 0;

            if (_context.Actions.FirstOrDefault(a => a.Name == action) != null)
            {
                ActionId = _context.Actions.FirstOrDefault(a => a.Name == action).Id;
            }


            int UserId = (int)HttpContext.Current.Session["UserId"];
            bool Status = false;
            if (_context.Users.Find(UserId).IsAdmin == true)
            {
                Status = true;
            }


            if (Status)
            {
                Access = true;
            }
            else
            {
                Permissions permissions = _context.Permissions.ToList();

                foreach (var item in permissions)
                {
                    if (item.UserId == UserId && item.ActionId == ActionId)
                    {
                        Access = true;
                    }
                }
            }

            if (Access == false)
            {
                filterContext.Result = new RedirectResult("~/home/index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}