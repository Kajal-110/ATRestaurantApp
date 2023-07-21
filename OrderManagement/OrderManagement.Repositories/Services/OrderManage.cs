using OrderManagement.Helpers;
using OrderManagement.Models.CustomModels;
using OrderManagement.Models.DB;
using OrderManagement.Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OrderManagement.Repositories.Services
{
    public class OrderManage : IOrderManage
    {
        public List<ITEM> GetTEMs()
        {
            AP351AteetMVCTestEntities db = new AP351AteetMVCTestEntities();
            return db.ITEMs.ToList();
        }

        public ITEM GetItemDetail(int id)
        {
            AP351AteetMVCTestEntities db = new AP351AteetMVCTestEntities();
            return db.ITEMs.Find(id);
        }
        public CouponCode GetcouponDetail(string code)
        {
            AP351AteetMVCTestEntities db = new AP351AteetMVCTestEntities();
            int index = db.CouponCodes.ToList().FindIndex(x => x.Code == code);
            return index > -1 ? db.CouponCodes.ToList()[index] : new CouponCode();
        }
        public bool PlaceOrder(Order order, HttpRequestBase Request)
        {
            LoginModel loginModel = CommonHelper.getCurrentUser(Request);
            AP351AteetMVCTestEntities db = new AP351AteetMVCTestEntities();
            ORDER newOrder = new ORDER();

            try
            {
                newOrder.OrderBy = loginModel.id;
                newOrder.OrderDate = DateTime.Today;
                newOrder.Total = order.total;
                newOrder.PromoCode = order.couponId;
                newOrder.TotalPayable = order.totalPayable;
                db.ORDERs.Add(newOrder);
                db.SaveChanges();
                foreach (var x in order.orderItems)
                {
                    db.ORDERITEMs.Add(new ORDERITEM()
                    {
                        ItemID = x.id,
                        Qty = x.qty,
                        Total = x.total,
                        OrderID = newOrder.ID
                    });
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
