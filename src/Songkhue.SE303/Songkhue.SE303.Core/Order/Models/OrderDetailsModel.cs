using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Songkhue.SE303.Core.Item;

namespace Songkhue.SE303.Core.Order.Models
{
    public class OrderDetailsModel : Sk_OrderDetails
    {
        ItemManager _itemManager = new ItemManager();


        public OrderDetailsModel(Sk_OrderDetails entity)
        {
            this.Id = entity.Id;
            this.OrderId = entity.OrderId;
            this.ItemId = entity.ItemId;
            this.Quantity = entity.Quantity;
            this.Price = entity.Price;
            this.TableId = entity.TableId;
        }

        public string ItemName
        {
            get
            {
                try
                {
                    return _itemManager.GetItemById(this.ItemId).Name;
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }

        public static IEnumerable<OrderDetailsModel> ToModelList(IEnumerable<Sk_OrderDetails> entityList)
        {
            return entityList.Select(o => new OrderDetailsModel(o)).ToList();
        }
    }
}
