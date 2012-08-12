using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Songkhue.SE303.Core.Branch;

namespace Songkhue.SE303.Core.Order.Models
{
    public class OrderModel : Sk_Order
    {
        OrderDetailsManager _orderDetailsManager = new OrderDetailsManager();

        public OrderModel(Sk_Order entity)
        {
            this.Id = entity.Id;
            this.BranchId = entity.BranchId;
            this.CreatedOn = entity.CreatedOn;

        }

        public string BranchName
        {
            get
            {
                BranchManager _branchManager = new BranchManager();
                var branch = _branchManager.GetBranchById(this.BranchId);
                if (branch != null)
                {
                    return branch.Name;
                }
                else
                {
                    return string.Empty;
                }
            }

        }

        public double Total
        {
            get
            {
                return _orderDetailsManager.GetTotalOrder(this.Id);

            }
        }

        public string DetailsUrl
        {
            get
            {
                return string.Format("<a href='/Admin/Order/Grid/?order={0}'>Chi tiết</a>", this.Id);
            }
        }

        public IEnumerable<Sk_OrderDetails> OrderDetails
        {
            get
            {

                return _orderDetailsManager.GetOrderDetails(this.Id);
            }
        }

        public static IEnumerable<OrderModel> ToModelList(IEnumerable<Sk_Order> entityList)
        {
            return entityList.Select(o => new OrderModel(o)).ToList();
        }
    }
}
