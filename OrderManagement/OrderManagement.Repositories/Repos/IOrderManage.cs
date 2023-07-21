using OrderManagement.Models.CustomModels;
using OrderManagement.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OrderManagement.Repositories.Repos
{
    public interface IOrderManage
    {
        List<ITEM> GetTEMs();
        ITEM GetItemDetail(int id);
        CouponCode GetcouponDetail(string code);
        bool PlaceOrder(Order order, HttpRequestBase Request);
    }
}
