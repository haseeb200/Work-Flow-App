using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterDetail.DataLayer;
using MasterDetail.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MasterDetail.Context;
using MasterDetail.Enums;

namespace MasterDetail.Controllers
{
    [Authorize]
    public class WorkListController : Controller
    {
        ApplicationDbContext _applicationDbContext = new ApplicationDbContext();


        public ApplicationUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }


        private IEnumerable<IWorkListItems> GetWorkOrders(string userId, List<string> userRolesList)
        {
            IEnumerable<IWorkListItems> claimableWorkOrders = _applicationDbContext.WorkOrders.Where(
                wo => wo.WorkOrderStatus != WorkOrderStatus.Approved)
                .ToList()
                .Where(
                    wo => userRolesList.Any(ur => wo.RolesWhichCanClaim.Contains(ur)));

            IEnumerable<IWorkListItems> workOrdersIAmWOrkingOn = _applicationDbContext.WorkOrders.Where(
                wo => wo.CurrentWorkerId == userId);

            return claimableWorkOrders.Concat(workOrdersIAmWOrkingOn);
        }


        private IEnumerable<IWorkListItems> GetWidgets(string userId, List<string> userRolesList)
        {
            IEnumerable<IWorkListItems> claimableWidgets = _applicationDbContext.Widgets.Where(
                w => w.WidgetStatus != WidgetStatus.Approved)
                .ToList()
                .Where(
                    wo => userRolesList.Any(ur => wo.RolesWhichCanClaim.Contains(ur)));

            IEnumerable<IWorkListItems> widgetsIAmWorkingOn =
                _applicationDbContext.Widgets.Where(w => w.CurrentWorkerId == userId);

            return claimableWidgets.Concat(widgetsIAmWorkingOn);
        }


        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            List<string> userRolesList = UserManager.GetRoles(userId).ToList();

            IEnumerable<IWorkListItems> workListItemsToDisplay = new List<IWorkListItems>();
            workListItemsToDisplay = workListItemsToDisplay.Concat(GetWorkOrders(userId, userRolesList));
            workListItemsToDisplay = workListItemsToDisplay.Concat(GetWidgets(userId, userRolesList));

            return View(workListItemsToDisplay.OrderByDescending(wl => wl.PriorityScore));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _applicationDbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}