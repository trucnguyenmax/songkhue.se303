using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Songkhue.SE303.Core.Order
{
    public class OrderManager
    {
        private Dev_Sk_SE303Entities _context;
        private Repository<Sk_Order> _reporsitory;

        private OrderManager()
        {
            _context = new Dev_Sk_SE303Entities();
            _reporsitory = new Repository<Sk_Order>(_context, true);
        }

        public IQueryable<Sk_Order> GetOrders(DateTime date)
        {
            // remove time
            return _reporsitory.Fetch().Where(x => DateTime.Parse(x.CreatedOn.ToShortDateString()) == date);
        }
    }
}
