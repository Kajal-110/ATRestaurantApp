using OrderManagement.Helpers;
using OrderManagement.Models.CustomModels;
using OrderManagement.Models.DB;
using OrderManagement.Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.Controllers
{
    public class HomeController : Controller
    {
        public IOrderManage orderService;
        public static List<OrderItem> orderItems = new List<OrderItem>();
        public static CouponCode couponCode = new CouponCode();
        public static Order order = new Order();
        public HomeController(IOrderManage _orderService)
        {
            orderService = _orderService;
        }
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Items = orderService.GetTEMs();
            LoginModel loginModel = CommonHelper.getCurrentUser(Request);
            order.orderItems = orderItems;
            order.total = orderItems.Sum(x => x.total);
            order.totalItem = orderItems.Count();
            order.totalPayable = order.total + Convert.ToInt32((order.total * 0.05)*2);
            order.couponId = couponCode.CouponICoded;
            order.couponCode = couponCode.Code;
            if (couponCode.CouponICoded == 1 )
            {
                order.netPayable = order.totalPayable - couponCode.Flat ?? 0;
            }
            else
            {
                double per = (couponCode.Percentage / 100) ?? 0.00;
                order.netPayable = order.totalPayable -  Convert.ToInt32((order.totalPayable * per));
            }
            couponCode = new CouponCode();
            return View(order);
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddItem(Order order, int? index)
        {
            ITEM item = orderService.GetItemDetail(order.AddItem.ItemId);
            orderItems.Add(new OrderItem()
            {
                Name = item.Name,
                id = item.ID,
                amount = item.Amount,
                total = item.Amount * order.AddItem.Qty,
                qty = order.AddItem.Qty
            });
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            orderItems.RemoveAt(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetCouponDetail(Order order)
        {
            if(orderService.GetcouponDetail(order.couponCode).CouponICoded > 0)
            {
                couponCode = orderService.GetcouponDetail(order.couponCode);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult PlaceOrder()
        {
            if(orderService.PlaceOrder(order, Request))
            {
                return RedirectToAction("OrderList");
            }
            else
            {
                return View("Error");
            }
            orderItems.Clear();
        }
        [Authorize]
        public ActionResult OrderList()
        {
            AP351AteetMVCTestEntities db = new AP351AteetMVCTestEntities();
            LoginModel loginModel = CommonHelper.getCurrentUser(Request);
            List<ORDER> orders = db.ORDERs.Include("ORDERITEMs").ToList().FindAll(x => x.OrderBy == loginModel.id);
            return View(orders);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}