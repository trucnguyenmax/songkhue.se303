using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Songkhue.SE303.Core.Order
{
    public class OrderDetailsManager
    {
        private Dev_Sk_SE303Entities _context;
        private Repository<Sk_OrderDetails> _reporsitory;

        public OrderDetailsManager()
        {
            _context = new Dev_Sk_SE303Entities();
            _reporsitory = new Repository<Sk_OrderDetails>(_context, true);
        }

        public IEnumerable<Sk_OrderDetails> GetOrderDetails(int orderId)
        {
            return _reporsitory.Fetch().Where(x => x.OrderId == orderId).OrderByDescending(x => x.Id).AsEnumerable();
        }

        public double GetTotalOrder(int orderId)
        {
            var total = _reporsitory.Fetch().Where(x => x.OrderId == orderId).Sum(x => x.Quantity * x.Price).ToString();
            return int.Parse(total);
        }

    }
}
